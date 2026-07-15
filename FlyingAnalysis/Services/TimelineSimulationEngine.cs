using System;
using System.Collections.Generic;
using System.Linq;
using FlyingAnalysis.Models;
using FlyingAnalysis.Models.Timeline;

namespace FlyingAnalysis.Services
{
    public class TimelineSimulationEngine
    {
        private readonly Random _rand = new Random();

        // Sensör Gürültü ve Kalibrasyon Varsayılanları
        public double BaroBiasMeter { get; set; } = 3.5;
        public double BaroScaleError { get; set; } = 0.012; // %1.2 ölçek hatası
        public double BaroSigmaMeter { get; set; } = 0.8;

        public double AccBiasMss { get; set; } = 0.25;
        public double AccScaleError { get; set; } = -0.008; // -%0.8 ölçek hatası
        public double AccSigmaMss { get; set; } = 0.15;

        public List<TimelineSimulationFrame> RunSimulation(
            double durationSeconds,
            double frequencyHz,
            double initialAltitudeMeter,
            List<TimelineEventItem> events)
        {
            if (frequencyHz < 1.0) frequencyHz = 1.0;
            if (frequencyHz > 1000.0) frequencyHz = 1000.0;
            double dt = 1.0 / frequencyHz;

            double massKg = GlobalSimulationConfig.PayloadMassKg;
            if (massKg <= 0) massKg = 1.25; // Güvenli varsayılan (1250g - Sadece Görev Yükü)

            double areaM2 = GlobalSimulationConfig.WingOpenedArea;
            if (areaM2 <= 0) areaM2 = 0.0450;

            double cd = GlobalSimulationConfig.BodyCd;
            if (cd <= 0) cd = 0.80;

            double gravity = GlobalSimulationConfig.Gravity;
            double airDensity = GlobalSimulationConfig.AirDensity;

            // Global kalibrasyon profilinden otomatik çek
            double baroBias = GlobalSimulationConfig.BaroBiasMeter;
            double baroSigma = GlobalSimulationConfig.BaroNoiseStdMeter;
            double accBias = GlobalSimulationConfig.AccBiasMps2;
            double accSigma = GlobalSimulationConfig.AccNoiseStdMps2;

            var frames = new List<TimelineSimulationFrame>();

            double currentPos = initialAltitudeMeter < 0.0 ? 0.0 : initialAltitudeMeter;
            double currentVel = 0.0;

            int totalSteps = (int)Math.Round(durationSeconds / dt);
            if (totalSteps < 1) totalSteps = 1;

            bool hasBeenAirborne = initialAltitudeMeter > 0.1;

            for (int step = 0; step <= totalSteps; step++)
            {
                double t = step * dt;

                // 1. Olayları Tara
                double activeForceNewton = 0.0;
                bool isCutoff = false;
                bool isSpecialNoise = false;
                double extraNoiseSigma = 0.0;

                if (events != null)
                {
                    foreach (var ev in events)
                    {
                        if (t >= ev.StartTime && t <= ev.EndTime)
                        {
                            if (ev.EventType == TimelineEventType.Force)
                            {
                                activeForceNewton += ev.GetInterpolatedValue(t);
                            }
                            else if (ev.EventType == TimelineEventType.SensorCutoff)
                            {
                                isCutoff = true;
                            }
                            else if (ev.EventType == TimelineEventType.SpecialConditionNoise)
                            {
                                isSpecialNoise = true;
                                double noiseVal = Math.Abs(ev.GetInterpolatedValue(t));
                                if (noiseVal > extraNoiseSigma) extraNoiseSigma = noiseVal;
                            }
                        }
                    }
                }

                // 2. Sıcaklık ve Basınç (Atmosferik Hidrostatik Zincir)
                double temp = GlobalSimulationConfig.CalculateTemperatureCelsius(currentPos);
                double truePressurePa = GlobalSimulationConfig.CalculatePressurePa(currentPos);

                // 3. Kuvvetler ve İvme (Aşağı yön -gravity, hareket yönüne ters sürtünme)
                double fGravity = -massKg * gravity;
                double dragDirection = currentVel > 0 ? -1.0 : (currentVel < 0 ? 1.0 : 0.0);
                double fDrag = 0.5 * airDensity * (currentVel * currentVel) * cd * areaM2 * dragDirection;
                double fNet = fGravity + fDrag + activeForceNewton;
                double currentAcc = fNet / massKg;

                // Yerde durma kontrolü: Eğer yerde iken (currentPos <= 0) net kuvvet aşağı yönlü ise yer delinip aşağı inilemez
                if (currentPos <= 0.0 && fNet <= 0.0)
                {
                    currentAcc = 0.0;
                    currentVel = 0.0;
                    currentPos = 0.0;
                }
                else if (currentPos > 0.1)
                {
                    hasBeenAirborne = true;
                }

                // 4. Sensör Çıktıları Üret (Hidrostatik barometrik ters formül zinciri)
                double rawBaro = double.NaN;
                double calBaro = double.NaN;
                double rawAcc = double.NaN;
                double calAcc = double.NaN;

                if (!isCutoff)
                {
                    // Barometre: İrtifa -> Basınç -> Forward Error Model -> İrtifa -> Ters Kalibrasyon
                    double noisyAltitude = GlobalSimulationConfig.ApplySensorForwardError(currentPos, true, _rand, step, totalSteps, isSpecialNoise, extraNoiseSigma * 1.5);
                    double measuredPressurePa = GlobalSimulationConfig.CalculatePressurePa(Math.Max(0.0, noisyAltitude));
                    rawBaro = GlobalSimulationConfig.CalculateAltitudeFromPressure(measuredPressurePa);
                    calBaro = GlobalSimulationConfig.ApplySensorReverseCalibration(rawBaro, true);

                    // İvmeölçer: Doğrudan İvme -> Forward Error Model -> Ters Kalibrasyon
                    rawAcc = GlobalSimulationConfig.ApplySensorForwardError(currentAcc, false, _rand, step, totalSteps, isSpecialNoise, extraNoiseSigma * 0.4);
                    calAcc = GlobalSimulationConfig.ApplySensorReverseCalibration(rawAcc, false);
                }

                var frame = new TimelineSimulationFrame
                {
                    Time = Math.Round(t, 4),
                    TruePosition = currentPos,
                    RawBaroPosition = rawBaro,
                    CalibratedBaroPosition = calBaro,
                    TrueVelocity = currentVel,
                    TrueAcceleration = currentAcc,
                    RawAcceleration = rawAcc,
                    CalibratedAcceleration = calAcc,
                    Temperature = temp,
                    AppliedExternalForceNewton = activeForceNewton,
                    GravityForceNewton = fGravity,
                    DragForceNewton = fDrag,
                    NetForceNewton = fNet,
                    IsSensorCutoffActive = isCutoff,
                    IsSpecialNoiseActive = isSpecialNoise
                };
                frames.Add(frame);

                // Yere Çarpma / İniş (Impact Stop) Kontrolü: Havalanıp tekrar yere düştüğünde simülasyon anında durur
                if (step > 0 && currentPos <= 0.0 && currentVel <= 0.0 && hasBeenAirborne)
                {
                    frame.TruePosition = 0.0;
                    frame.TrueVelocity = 0.0;
                    frame.TrueAcceleration = 0.0;
                    break;
                }

                // 5. Konum ve Hız İntegrasyonu
                if (step < totalSteps)
                {
                    currentPos += currentVel * dt + 0.5 * currentAcc * dt * dt;
                    currentVel += currentAcc * dt;
                    if (currentPos <= 0.0)
                    {
                        currentPos = 0.0;
                        if (currentVel < 0.0) currentVel = 0.0;
                    }
                }
            }

            return frames;
        }

        private double NextGaussian(double mean, double sigma)
        {
            if (sigma <= 0.0) return mean;
            double u1 = 1.0 - _rand.NextDouble();
            double u2 = 1.0 - _rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return mean + sigma * randStdNormal;
        }
    }
}
