using System;

namespace FlyingAnalysis.Models
{
    public static class GlobalSimulationConfig
    {
        // 1. Dünya ve Çevre Değişkenleri (World Variables)
        public static double Gravity { get; set; } = 9.807;
        public static double AirDensity { get; set; } = 1.18; // Standart oda/test sıcaklığı yoğunluğu (Emax 2306 test ortamı ~1.18 kg/m³)
        public static double SeaLevelTemperature { get; set; } = 15.0;
        public static double LapseRate { get; set; } = 6.5;

        // 2. Kütle Parametreleri [Gram]
        public static double CarrierMassGram { get; set; } = 550.0;
        public static double PayloadMassGram { get; set; } = 1250.0;
        public static double TotalMassGram => CarrierMassGram + PayloadMassGram;
        public static double TotalMassKg => TotalMassGram / 1000.0;
        public static double PayloadMassKg => PayloadMassGram / 1000.0;

        // 3. Faz Bazlı Referans Alanları ve Sürüklenme Katsayıları [m² & Cd]
        public static double CarrierCrossSectionArea { get; set; } = 0.0314; // Faz 1: Taşıyıcı kesit alanı
        public static double CarrierCd { get; set; } = 0.45; // Faz 1: Taşıyıcı Cd

        public static double MainParachuteArea { get; set; } = 0.1256; // Faz 2: Ana paraşüt alanı
        public static double MainParachuteCd { get; set; } = 1.5; // Faz 2: Ana paraşüt Cd

        public static double ApamParachuteArea { get; set; } = 0.45; // Faz 4 -> APAM acil durum paraşütü
        public static double ApamParachuteCd { get; set; } = 1.6;

        // 4. Kanat ve Gövde Aerodinamik Alanları (Faz 3 & Faz 4)
        public static double WingClosedArea { get; set; } = 0.0150; // Faz 3: Kanatlar kapalı kesit alanı
        public static double WingOpenedArea { get; set; } = 0.0450; // Faz 4: Kanatlar açık kesit alanı
        public static double BodyCd { get; set; } = 0.80; // Faz 3 ve Faz 4 için ortak sürüklenme katsayısı

        // 5. Faz Geçiş ve Mekanizma Süreleri [Saniye]
        public static double Phase1Duration { get; set; } = 16.0; // Faz 1 -> Faz 2 Roket tırmanış süresi
        public static double Phase2ToPhase3Delay { get; set; } = 2.0; // Faz 2 -> Faz 3 Ayrılma tetikleme gecikmesi
        public static double Phase3ToPhase4DeployTime { get; set; } = 1.5; // Faz 3 -> Faz 4 Kanat açılma süresi
        public static double Phase4ToApamDelay { get; set; } = 1.5; // Faz 4 -> APAM Acil durum algılama/şişme gecikmesi

        // 6. İtki Sistemi (Thrust & BLDC Motors - İki Yöntemli Seçim)
        // Emax Eco 2306 2400KV & HQ v1s 5x4x3 pervane datasheet varsayılanları
        public static bool IsPropellerMethodEnabled { get; set; } = false; // false = Seçenek A (Doğrudan giriş), true = Seçenek B (Aerodinamik Formül)
        public static int MotorCount { get; set; } = 4; // 4 adet Emax 2306 fırçasız motor
        public static double PropellerCt { get; set; } = 0.1415; // HQ v1s 5x4x3 Pervane itki katsayısı (C_T)
        public static double MotorMaxRps { get; set; } = 519.0; // Maksimum saniyelik devir (~31,140 RPM)
        public static double PropellerDiameterMeter { get; set; } = 0.1270; // 5 inç pervane çapı (0.127 m)
        public static double MaxThrustGram { get; set; } = 4780.0; // 4x1195g katalog doğrudan itki kapasitesi [Gram]
        public static double ThrustCoeff { get; set; } = 1.5e-8; // Eski aerodinamik katsayı uyumluluk

        // Pervane Formülü ile Toplam Maksimum İtki Hesaplama: T = N * C_T * rho * n^2 * D^4
        public static double CalculatePropellerMaxThrustGram()
        {
            if (AirDensity <= 0 || PropellerDiameterMeter <= 0 || MotorMaxRps <= 0 || PropellerCt <= 0 || MotorCount <= 0)
                return 0.0;

            double thrustNewtonSingle = PropellerCt * AirDensity * (MotorMaxRps * MotorMaxRps) * Math.Pow(PropellerDiameterMeter, 4.0);
            double thrustNewtonTotal = MotorCount * thrustNewtonSingle;
            if (Gravity <= 0) return 0.0;
            return (thrustNewtonTotal / Gravity) * 1000.0;
        }

        // Limit Hız (Terminal Velocity) Hesaplama Formülü: v = √( 2·m·g / (ρ·Cd·A) )
        public static double CalculateTerminalVelocity(double massKg, double areaM2, double cd)
        {
            if (AirDensity <= 0 || cd <= 0 || areaM2 <= 0) return 0.0;
            double numerator = 2.0 * massKg * Gravity;
            double denominator = AirDensity * cd * areaM2;
            if (denominator <= 0) return 0.0;
            return Math.Sqrt(numerator / denominator);
        }

        // 7. Sensör Kalibrasyon & Hata Profili (SensorSettingsSubPanel tarafından otomatik beslenir)
        public static double BaroBiasMeter { get; set; } = 0.5;
        public static double BaroNoiseStdMeter { get; set; } = 1.2;
        public static double AccBiasMps2 { get; set; } = 0.05;
        public static double AccNoiseStdMps2 { get; set; } = 0.15;

        // Atmosferik Hidrostatik Sabitler
        public static double SeaLevelPressurePa { get; set; } = 101325.0; // P0 [Pa]
        public static double GasConstantR { get; set; } = 287.05; // R [J/(kg·K)]

        // Atmosferik Yükseklikten Sıcaklık [°C] ve Basınç [Pa] Hesaplama
        public static double CalculateTemperatureCelsius(double altitudeMeter)
        {
            double lapseRatePerMeter = LapseRate / 1000.0;
            return SeaLevelTemperature - (lapseRatePerMeter * altitudeMeter);
        }

        public static double CalculatePressurePa(double altitudeMeter)
        {
            double lapseRatePerMeter = LapseRate / 1000.0;
            if (lapseRatePerMeter <= 0) return SeaLevelPressurePa;
            double tKelvin = SeaLevelTemperature + 273.15;
            double tempRatio = 1.0 - ((lapseRatePerMeter * altitudeMeter) / tKelvin);
            if (tempRatio <= 0) return 0.0;
            return SeaLevelPressurePa * Math.Pow(tempRatio, Gravity / (GasConstantR * lapseRatePerMeter));
        }

        // Basınç [Pa] üzerinden Ters Barometrik Formül ile Yükseklik [m]
        public static double CalculateAltitudeFromPressure(double pressurePa)
        {
            if (pressurePa <= 0 || SeaLevelPressurePa <= 0) return 0.0;
            double lapseRatePerMeter = LapseRate / 1000.0;
            if (lapseRatePerMeter <= 0) return 0.0;
            double tKelvin = SeaLevelTemperature + 273.15;
            double exponent = (GasConstantR * lapseRatePerMeter) / Gravity;
            return (tKelvin / lapseRatePerMeter) * (1.0 - Math.Pow(pressurePa / SeaLevelPressurePa, exponent));
        }
    }
}
