using System;
using System.Collections.Generic;

namespace SensorAnalizi.Simulation
{
    public enum FlightState
    {
        S1_ASCENT = 1,
        S2_PASSIVE_DESCENT = 2,
        S3_SEPARATION = 3,
        S4_ACTIVE_DESCENT = 4,
        S5_RECOVERY = 5,
        APAM_EMERGENCY = 8
    }

    public enum FlightSubState
    {
        S1_RocketAscent,
        S2_CruciformParachuteDescent,
        S3_PayloadSeparationShock,
        S4a_RapidApproachDescent,
        S4b_BonusHover200m,
        S4c_SigmaControlledDescent,
        S5_TouchdownRecovery,
        APAM_EmergencyDeployment
    }

    public class PhysicsParameters
    {
        // 1. Kütle Parametreleri (Taşıyıcı ve Görev Yükü Ayrı Ayrı)
        public double MassCarrier { get; set; } = 0.55; // kg (Taşıyıcı Modül)
        public double MassPayload { get; set; } = 1.25; // kg (Görev Yükü)
        public double MassTotal => MassCarrier + MassPayload; // Toplam fırlatma/pasif iniş kütlesi

        // 2. Aerodinamik & Paraşüt Yüzey Genişlikleri (m²) ve Sürtünme Katsayıları (Cd)
        public double AirDensity { get; set; } = 1.10; // kg/m³ (Aksaray 900m rakım kabulü)
        public double DragCoeffCarrier { get; set; } = 1.50;  // Çapraz Ana Paraşüt Cd
        public double AreaCarrierParachute { get; set; } = 0.1256; // Ana Paraşüt Yüzey Genişliği (m²)
        
        public double DragCoeffPayload { get; set; } = 1.30;  // Görev Yükü Cd
        public double AreaPayloadParachute { get; set; } = 0.0804; // Görev Yükü Yüzey Genişliği (m²)
        
        public double AreaApamParachute { get; set; } = 0.5026; // Acil Durum APAM Paraşüt Yüzey Genişliği (m²)
        public double Gravity { get; set; } = 9.81;

        // 3. Görev ve Alt-Senaryo Hedef Parametreleri
        public double SeparationAltitudeS3 { get; set; } = 1000.0; // metre (S2 -> S3 ayrılma irtifası)
        public double HoverAltitudeS4b { get; set; } = 200.0; // metre (S4b asılı kalma irtifası)
        public double HoverDurationS4b { get; set; } = 10.0; // saniye (S4b asılı kalma süresi)

        // 4. EMAX ECO II Motor İtki Katsayısı
        public double MotorThrustCoeff { get; set; } = 1.5e-8; // N/RPM^2

        // 5. Dikey PID Kontrol Katsayıları
        public double Kp { get; set; } = 3.5;
        public double Ki { get; set; } = 0.4;
        public double Kd { get; set; } = 4.2;

        // 6. Gürültü ve Sensör Hata Parametreleri
        public double BaroNoiseStd { get; set; } = 1.2; // m
        public double ImuNoiseStd { get; set; } = 0.08; // m/s²
        public double BaroScaleErrorPct { get; set; } = 20.0; // %20 Hatalı ölçüm
        public double ImuBiasShift { get; set; } = 0.12; // m/s² Zero-g shift

        // 7. Sızdıran Kova (Leaky Bucket) Parametreleri
        public double BucketFillRate { get; set; } = 2.5;
        public double BucketLeakRate { get; set; } = 1.2;
        public double BucketThreshold { get; set; } = 4.0;

        public bool UseEKFFusion { get; set; } = true;
    }

    public class PhysicsSimPoint
    {
        public double Time { get; set; }
        public double TrueAltitude { get; set; }
        public double TrueVelocity { get; set; }
        public double TrueAccel { get; set; }

        public double SensorAltitude { get; set; }
        public double EstimatedAltitude { get; set; }
        public double EstimatedVelocity { get; set; }

        // Ana Durum ve Modüler Alt-Senaryo Durumu
        public FlightState State { get; set; }
        public string StateName { get; set; } = string.Empty;
        public FlightSubState SubState { get; set; }
        public string SubStateName { get; set; } = string.Empty;

        // Anlık Aktif Aerodinamik & Kütle Parametreleri
        public double ActiveMassKg { get; set; }
        public double ActiveCd { get; set; }
        public double ActiveAreaM2 { get; set; }
        public double TerminalVelocityMs { get; set; }
        public double TargetVelocityMs { get; set; }

        // Sızdıran Kova (Leaky Bucket) Durumu
        public double BucketACC { get; set; }
        public string BucketStatus { get; set; } = "Idle"; // "Filling", "Leaking", "Latched"

        // Eyleyici Çıktıları
        public double MotorRPM { get; set; }
        public double ThrustNewton { get; set; }
    }

    public class PhysicsSimulationResult
    {
        public List<PhysicsSimPoint> Trajectory { get; set; } = new List<PhysicsSimPoint>();
        public double ImpactVelocity { get; set; }
        public double TotalTime { get; set; }
        public double ApogeeAltitude { get; set; }
        public double SeparationAltitude { get; set; }
        public bool ApamTriggered { get; set; }
    }

    public static class VerticalPhysicsEngine
    {
        private static double GenerateGaussianNoise(Random rand, double mean, double stdDev)
        {
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return mean + stdDev * randStdNormal;
        }

        public static PhysicsSimulationResult RunFullMission(PhysicsParameters p, double dt = 0.05)
        {
            var result = new PhysicsSimulationResult();
            var rand = new Random(801470);

            // Başlangıç: S1 Yükselme (Roket tırmanış)
            double y = 0.0;
            double v = 0.0; // m/s rampadan fırlatma
            double a = 0.0;

            FlightState state = FlightState.S1_ASCENT;
            FlightSubState subState = FlightSubState.S1_RocketAscent;
            double time = 0.0;

            double estAlt = 0.0;
            double estVel = v;

            double pidIntegral = 0.0;
            double prevError = 0.0;

            double bucketACC = 0.0;
            string bucketStatus = "Idle";

            double hoverTimer = 0.0;
            bool hoverCompleted = false;

            double maxTime = 300.0;

            while (time <= maxTime)
            {
                // 1. Sensör Okuması
                double scaleMult = 1.0 + (p.BaroScaleErrorPct / 100.0);
                double baroNoise = GenerateGaussianNoise(rand, 0.0, p.BaroNoiseStd);
                double imuNoise = GenerateGaussianNoise(rand, 0.0, p.ImuNoiseStd);

                double sensorAlt = Math.Max(0.0, y * scaleMult + baroNoise);
                double sensorAccel = a + p.ImuBiasShift + imuNoise;

                // 2. Kestirim Çekirdeği (EKF 3. Kademe)
                if (p.UseEKFFusion)
                {
                    double predAlt = estAlt + estVel * dt + 0.5 * sensorAccel * dt * dt;
                    double predVel = estVel + sensorAccel * dt;

                    double innov = sensorAlt - predAlt;
                    double K_h = 0.18;
                    double K_v = 0.005;

                    estAlt = predAlt + K_h * innov;
                    estVel = predVel + K_v * innov;
                }
                else
                {
                    estAlt = sensorAlt;
                    estVel = v;
                }

                // 3. Durum ve Modüler Alt-Senaryo Yönetimi
                double activeMass = p.MassTotal;
                double activeCd = 0.4;
                double activeArea = 0.01; // Roket gövde
                double targetVel = 0.0;
                double rocketThrustN = 0.0;

                switch (state)
                {
                    case FlightState.S1_ASCENT:
                        subState = FlightSubState.S1_RocketAscent;
                        activeMass = p.MassTotal;
                        activeCd = 0.4;
                        activeArea = 0.02;

                        // Roket İtki Safhası (115 N itki ile tam 1800 metre tepe noktasına tırmanış)
                        if (time <= 7.8)
                        {
                            rocketThrustN = 115.0;
                            targetVel = 175.0;
                        }
                        else
                        {
                            targetVel = 0.0;
                        }

                        if (time > 7.8 && estVel <= 0.0)
                        {
                            bucketACC += p.BucketFillRate * dt;
                            bucketStatus = "Filling";
                            if (bucketACC >= p.BucketThreshold * 0.3)
                            {
                                state = FlightState.S2_PASSIVE_DESCENT;
                                subState = FlightSubState.S2_CruciformParachuteDescent;
                                result.ApogeeAltitude = y;
                                bucketACC = 0.0;
                                bucketStatus = "Latched";
                            }
                        }
                        else
                        {
                            bucketACC = Math.Max(0.0, bucketACC - p.BucketLeakRate * dt);
                            bucketStatus = bucketACC > 0 ? "Leaking" : "Idle";
                        }
                        break;

                    case FlightState.S2_PASSIVE_DESCENT:
                        subState = FlightSubState.S2_CruciformParachuteDescent;
                        activeMass = p.MassTotal;
                        activeCd = p.DragCoeffCarrier;
                        activeArea = p.AreaCarrierParachute;

                        if (estAlt <= p.SeparationAltitudeS3)
                        {
                            bucketACC += p.BucketFillRate * dt;
                            bucketStatus = "Filling";
                            if (bucketACC >= p.BucketThreshold)
                            {
                                state = FlightState.S3_SEPARATION;
                                subState = FlightSubState.S3_PayloadSeparationShock;
                                result.SeparationAltitude = y;
                                bucketACC = 0.0;
                                bucketStatus = "Latched";
                            }
                        }
                        else
                        {
                            bucketACC = Math.Max(0.0, bucketACC - p.BucketLeakRate * dt);
                            bucketStatus = bucketACC > 0 ? "Leaking" : "Idle";
                        }
                        break;

                    case FlightState.S3_SEPARATION:
                        subState = FlightSubState.S3_PayloadSeparationShock;
                        activeMass = p.MassPayload;
                        activeCd = p.DragCoeffPayload;
                        activeArea = p.AreaPayloadParachute;

                        bucketACC += p.BucketFillRate * dt * 2.0;
                        bucketStatus = "Filling";
                        if (bucketACC >= p.BucketThreshold)
                        {
                            state = FlightState.S4_ACTIVE_DESCENT;
                            subState = FlightSubState.S4a_RapidApproachDescent;
                            bucketACC = 0.0;
                            bucketStatus = "Latched";
                        }
                        break;

                    case FlightState.S4_ACTIVE_DESCENT:
                        activeMass = p.MassPayload;
                        activeCd = p.DragCoeffPayload;
                        activeArea = p.AreaPayloadParachute;

                        // APAM Koruma (Gerçek aşırı hız eşiği: 20 m/s)
                        if (Math.Abs(estVel) > 20.0 && estAlt > 100.0)
                        {
                            result.ApamTriggered = true;
                            state = FlightState.APAM_EMERGENCY;
                            subState = FlightSubState.APAM_EmergencyDeployment;
                        }

                        // Alt-Senaryo Seçimi (S4a, S4b Hover, S4c Sigma İnişi)
                        double hoverUpper = p.HoverAltitudeS4b + 15.0;
                        double hoverLower = p.HoverAltitudeS4b - 20.0;

                        if (!hoverCompleted && estAlt <= hoverUpper && estAlt >= hoverLower)
                        {
                            subState = FlightSubState.S4b_BonusHover200m;
                            double altError = p.HoverAltitudeS4b - estAlt;
                            targetVel = Math.Clamp(altError * 0.35, -3.5, 3.5);
                            hoverTimer += dt;
                            if (hoverTimer >= p.HoverDurationS4b)
                            {
                                hoverCompleted = true;
                            }
                        }
                        else if (!hoverCompleted && estAlt > hoverUpper)
                        {
                            subState = FlightSubState.S4a_RapidApproachDescent;
                            targetVel = -14.0;
                        }
                        else
                        {
                            // 10 saniye Hover tamamlandıktan sonra veya 180m altında S4c Kontrollü İniş (-4.0 m/s)
                            subState = FlightSubState.S4c_SigmaControlledDescent;
                            targetVel = -4.0;
                        }

                        // S4 -> S5 Yer Bildirim Şartı (FallingStop)
                        if (y <= 0.5)
                        {
                            bucketACC += p.BucketFillRate * dt * 3.0;
                            bucketStatus = "Filling";
                            if (bucketACC >= p.BucketThreshold || y <= 0.05)
                            {
                                state = FlightState.S5_RECOVERY;
                                subState = FlightSubState.S5_TouchdownRecovery;
                                bucketACC = p.BucketThreshold;
                                bucketStatus = "Latched";
                            }
                        }
                        else
                        {
                            bucketACC = Math.Max(0.0, bucketACC - p.BucketLeakRate * dt);
                            bucketStatus = bucketACC > 0 ? "Leaking" : "Idle";
                        }
                        break;

                    case FlightState.APAM_EMERGENCY:
                        subState = FlightSubState.APAM_EmergencyDeployment;
                        activeMass = p.MassPayload;
                        activeCd = 1.6;
                        activeArea = p.AreaApamParachute;
                        targetVel = 0.0;
                        break;
                }

                // Limit Hız (Terminal Velocity) Hesabı
                double termVel = 0.0;
                if (activeCd > 0 && activeArea > 0)
                {
                    termVel = -Math.Sqrt((2.0 * activeMass * p.Gravity) / (p.AirDensity * activeCd * activeArea));
                }

                // Pasif paraşüt inişi fazlarında (S2, S3 ve APAM) fiziksel hedef hız aerodinamik limit hızdır (Terminal Velocity)
                if (state == FlightState.S2_PASSIVE_DESCENT || state == FlightState.S3_SEPARATION || state == FlightState.APAM_EMERGENCY)
                {
                    targetVel = termVel;
                }

                // 4. PID Kontrolcüsü ve İtki Kuvveti Hesabı (Feedforward + PID)
                double thrustN = 0.0;
                double motorRPM = 0.0;

                if (state == FlightState.S4_ACTIVE_DESCENT)
                {
                    double error = targetVel - estVel;
                    pidIntegral += error * dt;
                    pidIntegral = Math.Max(-12.0, Math.Min(12.0, pidIntegral));
                    double derivative = (error - prevError) / dt;
                    prevError = error;

                    double pidOutput = p.Kp * error + p.Ki * pidIntegral + p.Kd * derivative;

                    // Doğru Fiziksel Denge İtkisi (Feedforward): mg - fDrag
                    double fDragEst = 0.5 * p.AirDensity * activeCd * activeArea * estVel * estVel * (estVel < 0 ? 1.0 : -1.0);
                    double fFeedForward = Math.Max(0.0, activeMass * p.Gravity - fDragEst);

                    double maxThrustAllowed = 45.0;
                    // İniş fazında (targetVel < 0 iken) araç yukarı çıkarsa veya durursa motor itkisini sıfırla, yerçekimi aşağı indirsin
                    if (targetVel < 0.0 && (v >= -0.2 || estVel >= -0.2))
                    {
                        maxThrustAllowed = 0.0;
                        pidIntegral = 0.0;
                    }

                    thrustN = Math.Clamp(fFeedForward + pidOutput, 0.0, maxThrustAllowed);

                    double tMotor = thrustN / 4.0;
                    motorRPM = Math.Sqrt(Math.Max(0.0, tMotor / p.MotorThrustCoeff));
                }

                // 5. Sayısal Analiz Fizik Entegrasyonu (Dikey Hareket Denklemi)
                double fDrag = 0.5 * p.AirDensity * activeCd * activeArea * v * v * (v < 0 ? 1.0 : -1.0);
                double fNet = -activeMass * p.Gravity + rocketThrustN + thrustN + fDrag;
                a = fNet / activeMass;

                y += v * dt + 0.5 * a * dt * dt;
                v += a * dt;

                if (y <= 0.0)
                {
                    y = 0.0;
                    v = 0.0;
                    a = 0.0;
                    state = FlightState.S5_RECOVERY;
                    subState = FlightSubState.S5_TouchdownRecovery;
                    bucketStatus = "Latched";
                }

                result.Trajectory.Add(new PhysicsSimPoint
                {
                    Time = Math.Round(time, 3),
                    TrueAltitude = y,
                    TrueVelocity = v,
                    TrueAccel = a,
                    SensorAltitude = sensorAlt,
                    EstimatedAltitude = estAlt,
                    EstimatedVelocity = estVel,
                    State = state,
                    StateName = GetStateDisplayName(state),
                    SubState = subState,
                    SubStateName = GetSubStateDisplayName(subState),
                    ActiveMassKg = activeMass,
                    ActiveCd = activeCd,
                    ActiveAreaM2 = activeArea,
                    TerminalVelocityMs = Math.Round(termVel, 2),
                    TargetVelocityMs = Math.Round(targetVel, 2),
                    BucketACC = Math.Round(bucketACC, 2),
                    BucketStatus = bucketStatus,
                    MotorRPM = Math.Round(motorRPM, 0),
                    ThrustNewton = Math.Round(thrustN, 2)
                });

                if (state == FlightState.S5_RECOVERY)
                {
                    result.ImpactVelocity = Math.Abs(v);
                    result.TotalTime = time;
                    break;
                }

                time += dt;
            }

            return result;
        }

        private static string GetStateDisplayName(FlightState s)
        {
            switch (s)
            {
                case FlightState.S1_ASCENT: return "S1: YÜKSELME";
                case FlightState.S2_PASSIVE_DESCENT: return "S2: PASİF İNİŞ";
                case FlightState.S3_SEPARATION: return "S3: AYRILMA";
                case FlightState.S4_ACTIVE_DESCENT: return "S4: AKTİF İNİŞ";
                case FlightState.S5_RECOVERY: return "S5: YER BİLDİRİM";
                case FlightState.APAM_EMERGENCY: return "ACİL DURUM: APAM";
                default: return s.ToString();
            }
        }

        private static string GetSubStateDisplayName(FlightSubState ss)
        {
            switch (ss)
            {
                case FlightSubState.S1_RocketAscent: return "Roket ile Tepe Noktasına (1800m) Tırmanış";
                case FlightSubState.S2_CruciformParachuteDescent: return "Taşıyıcı + Görev Yükü Ana Paraşütle Süzülme";
                case FlightSubState.S3_PayloadSeparationShock: return "Görev Yükü Ayrılma Şoku";
                case FlightSubState.S4a_RapidApproachDescent: return "Hızlı Süzülme ve Yaklaşma (Hedef: -14 m/s)";
                case FlightSubState.S4b_BonusHover200m: return "BONUS-1 HOVER: Asılı Kalma Görevi (Hedef: 0 m/s)";
                case FlightSubState.S4c_SigmaControlledDescent: return "Kontrollü İniş ve Sabit Hız Profili (Hedef: -4 m/s)";
                case FlightSubState.S5_TouchdownRecovery: return "Yere Temas Edildi (Touchdown & Recovery)";
                case FlightSubState.APAM_EmergencyDeployment: return "ACİL DURUM: APAM Paraşütü Açıldı";
                default: return ss.ToString();
            }
        }
    }
}
