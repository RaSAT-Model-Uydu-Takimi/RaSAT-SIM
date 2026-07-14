using System;
using System.Collections.Generic;

namespace SensorAnalizi.Simulation
{
    public class SimPoint
    {
        public double Time { get; set; }
        public double TrueAltitude { get; set; }
        public double TrueVelocity { get; set; }
        public double SensorAltitude { get; set; }
        public double EstimatedAltitude { get; set; }
        public double EstimatedVelocity { get; set; }
        public double Throttle { get; set; }
    }

    public class SimulationScenarioResult
    {
        public string ScenarioName { get; set; } = string.Empty;
        public double SensorScaleError { get; set; }
        public bool UseSensorFusion { get; set; }
        public double ImpactVelocity { get; set; }
        public double TotalLandingTime { get; set; }
        public List<SimPoint> Trajectory { get; set; } = new List<SimPoint>();
    }

    public static class LandingSimulator
    {
        public static SimulationScenarioResult RunSimulation(
            string scenarioName,
            double sensorScaleError,
            bool useSensorFusion,
            double initialAltitude = 400.0,
            double dt = 0.05)
        {
            var result = new SimulationScenarioResult
            {
                ScenarioName = scenarioName,
                SensorScaleError = sensorScaleError,
                UseSensorFusion = useSensorFusion
            };

            double mass = 2.5; // kg
            double gravity = 9.80665;
            double maxThrust = 45.0; // N (Maksimum motor itkisi)

            double trueAlt = initialAltitude;
            double trueVel = 0.0; // Aşağı yön negatif (-m/s)
            double estAlt = initialAltitude;
            double estVel = 0.0;

            Random rand = new Random(42);

            double t = 0.0;
            while (trueAlt > 0.01 && t < 120.0)
            {
                // Barometre okuması (Gerçek irtifa * ölçek hatası + hafif sensör gürültüsü)
                double noise = (rand.NextDouble() - 0.5) * 0.5;
                double baroAlt = (trueAlt * sensorScaleError) + noise;

                // Kontrolcünün kararlarında kullandığı irtifa ve hız
                double controlAlt = useSensorFusion ? estAlt : baroAlt;
                double controlVel = useSensorFusion ? estVel : trueVel;

                // İrtifaya göre hedef alçalma hızı (targetVel negatif m/s)
                double targetVel;
                if (controlAlt > 160.0)
                {
                    targetVel = -14.0; // Yüksek irtifa hızlı iniş
                }
                else if (controlAlt > 70.0)
                {
                    targetVel = -7.0;  // Orta kademe yavaşlama
                }
                else if (controlAlt > 20.0)
                {
                    targetVel = -3.5;  // Alçak irtifa yaklaşma
                }
                else
                {
                    targetVel = -1.5;  // Son metreler yumuşak temas
                }

                // Hız hatası: İstenen Hız - Gerçek Hız
                // Örn: İstenen = -3.5, Gerçek = -8.0 -> velError = -3.5 - (-8.0) = +4.5 (Çok hızlı düşüyor, gaz ver!)
                double velError = targetVel - controlVel;

                // PD Kontrolcü (Doğru işaret: Hızlı düşüyorsa throttle ARTAR)
                double baseThrottle = (mass * gravity) / maxThrust; // ~0.54 (süzülme itkisi)
                double throttle = baseThrottle + (0.15 * velError);
                throttle = Math.Clamp(throttle, 0.0, 1.0);

                // Fiziksel kuvvetler
                double drag = -0.5 * 1.225 * 0.6 * 0.1256 * trueVel * Math.Abs(trueVel);
                double thrustForce = throttle * maxThrust;
                double forceY = -mass * gravity + thrustForce + drag;
                double accelY = forceY / mass;

                // İvmeölçer (yerçekimi arındırılmış net dikey itme ivmesi)
                double accelSensor = (thrustForce + drag) / mass - gravity;

                // Sensör Füzyonu (Tamamlayıcı Filtre / EKF)
                if (useSensorFusion)
                {
                    double predAlt = estAlt + estVel * dt + 0.5 * accelSensor * (dt * dt);
                    double predVel = estVel + accelSensor * dt;

                    double innovation = baroAlt - predAlt;
                    estAlt = predAlt + 0.15 * innovation;
                    estVel = predVel + 0.05 * innovation;
                }
                else
                {
                    estAlt = baroAlt;
                    estVel = trueVel;
                }

                // Fizik entegrasyonu
                trueVel += accelY * dt;
                trueAlt += trueVel * dt;
                t += dt;

                if (trueAlt < 0.0)
                {
                    trueAlt = 0.0;
                }

                result.Trajectory.Add(new SimPoint
                {
                    Time = t,
                    TrueAltitude = trueAlt,
                    TrueVelocity = trueVel,
                    SensorAltitude = baroAlt,
                    EstimatedAltitude = estAlt,
                    EstimatedVelocity = useSensorFusion ? estVel : trueVel,
                    Throttle = throttle
                });

                if (trueAlt <= 0.0) break;
            }

            result.TotalLandingTime = t;
            result.ImpactVelocity = Math.Abs(trueVel);
            return result;
        }
    }
}
