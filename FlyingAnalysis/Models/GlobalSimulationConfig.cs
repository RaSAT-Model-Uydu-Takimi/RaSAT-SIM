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
        // Barometre Hata ve Kalibrasyon Parametreleri
        public static double BaroBiasMeter { get; set; } = 0.5;
        public static double BaroScaleErrorPercent { get; set; } = 0.0;
        public static double BaroNoiseStdMeter { get; set; } = 1.2;
        public static double BaroRelativeNoisePercent { get; set; } = 0.0;
        public static double BaroSpikeProbPercent { get; set; } = 0.0;
        public static double BaroSpikeAmplitudeMeter { get; set; } = 0.0;
        public static double BaroProcessedBias { get; set; } = 0.0;
        public static double BaroProcessedScalePercent { get; set; } = 0.0;

        // İvmeölçer Hata ve Kalibrasyon Parametreleri
        public static double AccBiasMps2 { get; set; } = 0.05;
        public static double AccScaleErrorPercent { get; set; } = 0.0;
        public static double AccNoiseStdMps2 { get; set; } = 0.15;
        public static double AccRelativeNoisePercent { get; set; } = 0.0;
        public static double AccSpikeProbPercent { get; set; } = 0.0;
        public static double AccSpikeAmplitudeMps2 { get; set; } = 0.0;
        public static double AccProcessedBias { get; set; } = 0.0;
        public static double AccProcessedScalePercent { get; set; } = 0.0;

        // Merkezi Sensör Ham Hata Uygulayıcısı (Forward Error Model)
        public static double ApplySensorForwardError(double trueValue, bool isBaro, Random rand, int step = -1, int totalSteps = -1, bool isSpecialCondition = false, double extraSigma = 0.0)
        {
            double val = trueValue;
            double scaleErr = isBaro ? BaroScaleErrorPercent : AccScaleErrorPercent;
            double bias = isBaro ? BaroBiasMeter : AccBiasMps2;
            double thermalStd = isBaro ? BaroNoiseStdMeter : AccNoiseStdMps2;
            double relNoise = isBaro ? BaroRelativeNoisePercent : AccRelativeNoisePercent;
            double spikeProb = isBaro ? BaroSpikeProbPercent : AccSpikeProbPercent;
            double spikeAmp = isBaro ? BaroSpikeAmplitudeMeter : AccSpikeAmplitudeMps2;

            // 1. Bağıl Scale Hatası (% S)
            if (scaleErr != 0)
            {
                val = trueValue * (1.0 + scaleErr / 100.0);
            }

            // 2. Mutlak Bias Hatası (b)
            val += bias;

            // 3. Sabit Termal Gürültü ve Özel Durum Gürültüsü
            double totalSigma = thermalStd + (isSpecialCondition ? extraSigma : 0.0);
            if (totalSigma > 0)
            {
                // Box-Muller normal dağılım
                double u1 = 1.0 - rand.NextDouble();
                double u2 = 1.0 - rand.NextDouble();
                double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
                val += totalSigma * randStdNormal;
            }

            // 4. Bağıl Termal Gürültü (% FS)
            if (relNoise > 0)
            {
                double fsSpan = isBaro ? 5000.0 : 100.0; // Baro için 5km span, ivme için 100 m/s² span
                double relSigma = relNoise * fsSpan / 100.0;
                double u1 = 1.0 - rand.NextDouble();
                double u2 = 1.0 - rand.NextDouble();
                double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
                val += relSigma * randStdNormal;
            }

            // 5. Darbe Gürültüsü (Spike Noise)
            if (spikeProb > 0 && rand.NextDouble() * 100.0 < spikeProb)
            {
                double sign = rand.NextDouble() > 0.5 ? 1.0 : -1.0;
                val += sign * spikeAmp;
            }

            return val;
        }

        // Merkezi Sensör Ters Kalibrasyon Çıktısı (Reverse Calibration Equation)
        public static double ApplySensorReverseCalibration(double rawValue, bool isBaro)
        {
            double procBias = isBaro ? BaroProcessedBias : AccProcessedBias;
            double procScale = isBaro ? BaroProcessedScalePercent : AccProcessedScalePercent;
            double denominator = 1.0 + (procScale / 100.0);
            if (Math.Abs(denominator) < 1e-9) return rawValue;
            return (rawValue - procBias) / denominator;
        }

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

        // 9. Grafik Görsel Özelleştirme & Katman Kontrolü (Chart Layers & Styling)
        public static ChartStylingProfile ChartProfile { get; } = new ChartStylingProfile();
        public static event Action? OnChartStylingChanged;

        public static void NotifyChartStylingChanged()
        {
            OnChartStylingChanged?.Invoke();
        }

        // JSON Profil ve Sayfa Kaydet/Yükle Yardımcı Metodları
        public static void SaveSensorProfileToFile(string filePath, bool isBaro)
        {
            try
            {
                var profile = new
                {
                    IsBarometer = isBaro,
                    Bias = isBaro ? BaroBiasMeter : AccBiasMps2,
                    ScaleErrorPercent = isBaro ? BaroScaleErrorPercent : AccScaleErrorPercent,
                    NoiseStd = isBaro ? BaroNoiseStdMeter : AccNoiseStdMps2,
                    RelativeNoisePercent = isBaro ? BaroRelativeNoisePercent : AccRelativeNoisePercent,
                    SpikeProbPercent = isBaro ? BaroSpikeProbPercent : AccSpikeProbPercent,
                    SpikeAmplitude = isBaro ? BaroSpikeAmplitudeMeter : AccSpikeAmplitudeMps2,
                    ProcessedBias = isBaro ? BaroProcessedBias : AccProcessedBias,
                    ProcessedScalePercent = isBaro ? BaroProcessedScalePercent : AccProcessedScalePercent
                };
                string json = System.Text.Json.JsonSerializer.Serialize(profile, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Sensör profili kaydedilirken hata: {ex.Message}");
            }
        }

        public static bool LoadSensorProfileFromFile(string filePath, bool isBaro)
        {
            try
            {
                if (!System.IO.File.Exists(filePath)) return false;
                string json = System.IO.File.ReadAllText(filePath);
                using var doc = System.Text.Json.JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (isBaro)
                {
                    if (root.TryGetProperty("Bias", out var p1)) BaroBiasMeter = p1.GetDouble();
                    if (root.TryGetProperty("ScaleErrorPercent", out var p2)) BaroScaleErrorPercent = p2.GetDouble();
                    if (root.TryGetProperty("NoiseStd", out var p3)) BaroNoiseStdMeter = p3.GetDouble();
                    if (root.TryGetProperty("RelativeNoisePercent", out var p4)) BaroRelativeNoisePercent = p4.GetDouble();
                    if (root.TryGetProperty("SpikeProbPercent", out var p5)) BaroSpikeProbPercent = p5.GetDouble();
                    if (root.TryGetProperty("SpikeAmplitude", out var p6)) BaroSpikeAmplitudeMeter = p6.GetDouble();
                    if (root.TryGetProperty("ProcessedBias", out var p7)) BaroProcessedBias = p7.GetDouble();
                    if (root.TryGetProperty("ProcessedScalePercent", out var p8)) BaroProcessedScalePercent = p8.GetDouble();
                }
                else
                {
                    if (root.TryGetProperty("Bias", out var p1)) AccBiasMps2 = p1.GetDouble();
                    if (root.TryGetProperty("ScaleErrorPercent", out var p2)) AccScaleErrorPercent = p2.GetDouble();
                    if (root.TryGetProperty("NoiseStd", out var p3)) AccNoiseStdMps2 = p3.GetDouble();
                    if (root.TryGetProperty("RelativeNoisePercent", out var p4)) AccRelativeNoisePercent = p4.GetDouble();
                    if (root.TryGetProperty("SpikeProbPercent", out var p5)) AccSpikeProbPercent = p5.GetDouble();
                    if (root.TryGetProperty("SpikeAmplitude", out var p6)) AccSpikeAmplitudeMps2 = p6.GetDouble();
                    if (root.TryGetProperty("ProcessedBias", out var p7)) AccProcessedBias = p7.GetDouble();
                    if (root.TryGetProperty("ProcessedScalePercent", out var p8)) AccProcessedScalePercent = p8.GetDouble();
                }
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Sensör profili yüklenirken hata: {ex.Message}");
                return false;
            }
        }

        public static void SaveGlobalConfigToFile(string filePath)
        {
            try
            {
                var cfg = new
                {
                    Gravity, AirDensity, SeaLevelTemperature, LapseRate,
                    CarrierMassGram, PayloadMassGram,
                    CarrierCrossSectionArea, CarrierCd, MainParachuteArea, MainParachuteCd,
                    WingClosedArea, WingOpenedArea, BodyCd,
                    ApamParachuteArea, ApamParachuteCd,
                    Phase1Duration, Phase2ToPhase3Delay, Phase3ToPhase4DeployTime, Phase4ToApamDelay
                };
                string json = System.Text.Json.JsonSerializer.Serialize(cfg, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Global ayarlar kaydedilirken hata: {ex.Message}");
            }
        }

        public static bool LoadGlobalConfigFromFile(string filePath)
        {
            try
            {
                if (!System.IO.File.Exists(filePath)) return false;
                string json = System.IO.File.ReadAllText(filePath);
                using var doc = System.Text.Json.JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (root.TryGetProperty("Gravity", out var p1)) Gravity = p1.GetDouble();
                if (root.TryGetProperty("AirDensity", out var p2)) AirDensity = p2.GetDouble();
                if (root.TryGetProperty("SeaLevelTemperature", out var p3)) SeaLevelTemperature = p3.GetDouble();
                if (root.TryGetProperty("LapseRate", out var p4)) LapseRate = p4.GetDouble();
                if (root.TryGetProperty("CarrierMassGram", out var p5)) CarrierMassGram = p5.GetDouble();
                if (root.TryGetProperty("PayloadMassGram", out var p6)) PayloadMassGram = p6.GetDouble();
                if (root.TryGetProperty("CarrierCrossSectionArea", out var p7)) CarrierCrossSectionArea = p7.GetDouble();
                else if (root.TryGetProperty("CarrierArea", out var p7old)) CarrierCrossSectionArea = p7old.GetDouble();
                if (root.TryGetProperty("CarrierCd", out var p8)) CarrierCd = p8.GetDouble();
                if (root.TryGetProperty("MainParachuteArea", out var p9)) MainParachuteArea = p9.GetDouble();
                if (root.TryGetProperty("MainParachuteCd", out var p10)) MainParachuteCd = p10.GetDouble();
                if (root.TryGetProperty("WingClosedArea", out var p11)) WingClosedArea = p11.GetDouble();
                if (root.TryGetProperty("WingOpenedArea", out var p12)) WingOpenedArea = p12.GetDouble();
                if (root.TryGetProperty("BodyCd", out var p13)) BodyCd = p13.GetDouble();
                if (root.TryGetProperty("ApamParachuteArea", out var p14)) ApamParachuteArea = p14.GetDouble();
                if (root.TryGetProperty("ApamParachuteCd", out var p15)) ApamParachuteCd = p15.GetDouble();
                if (root.TryGetProperty("Phase1Duration", out var p16)) Phase1Duration = p16.GetDouble();
                if (root.TryGetProperty("Phase2ToPhase3Delay", out var p17)) Phase2ToPhase3Delay = p17.GetDouble();
                if (root.TryGetProperty("Phase3ToPhase4DeployTime", out var p18)) Phase3ToPhase4DeployTime = p18.GetDouble();
                if (root.TryGetProperty("Phase4ToApamDelay", out var p19)) Phase4ToApamDelay = p19.GetDouble();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Global ayarlar yüklenirken hata: {ex.Message}");
                return false;
            }
        }

        public static Dictionary<string, ChartLayerInfo> ChartLayers { get; } = new Dictionary<string, ChartLayerInfo>()
        {
            { "RawData", new ChartLayerInfo { DisplayName = "Ham Sensör Verisi", ColorHex = "#FF4500", LineWidth = 1.0f, DrawOrder = 1, Show = true } },
            { "CalibratedData", new ChartLayerInfo { DisplayName = "Kalibre Edilmiş Veri", ColorHex = "#32CD32", LineWidth = 1.5f, DrawOrder = 2, Show = true } },
            { "TrueData", new ChartLayerInfo { DisplayName = "Gerçek Referans Verisi", ColorHex = "#FFD700", LineWidth = 3.2f, DrawOrder = 3, Show = true } }
        };
    }

    public class ChartLayerInfo
    {
        public string DisplayName { get; set; } = string.Empty;
        public bool Show { get; set; } = true;
        public bool Visible { get => Show; set => Show = value; }
        public System.Drawing.Color Color { get; set; } = System.Drawing.Color.White;
        public string ColorHex
        {
            get => System.Drawing.ColorTranslator.ToHtml(Color);
            set
            {
                try { Color = System.Drawing.ColorTranslator.FromHtml(value); } catch { }
            }
        }
        public float LineWidth { get; set; } = 2f;
        public int DrawOrder { get; set; } = 1; // 1 = En Arkada, 2 = Ortada, 3 = En Önde
    }

    public class ChartStylingProfile
    {
        // 1. Konum Grafiği Katmanları
        public ChartLayerInfo PosTrue { get; set; } = new ChartLayerInfo { DisplayName = "Gerçek Konum", Show = true, Color = System.Drawing.Color.FromArgb(255, 215, 0), LineWidth = 3f, DrawOrder = 1 }; // Gold
        public ChartLayerInfo PosRaw { get; set; } = new ChartLayerInfo { DisplayName = "Ham Barometre Konum", Show = true, Color = System.Drawing.Color.FromArgb(255, 69, 0), LineWidth = 1f, DrawOrder = 2 }; // OrangeRed
        public ChartLayerInfo PosCal { get; set; } = new ChartLayerInfo { DisplayName = "Kalibre Barometre Konum", Show = true, Color = System.Drawing.Color.FromArgb(50, 205, 50), LineWidth = 2f, DrawOrder = 3 }; // LimeGreen

        // 2. Hız Grafiği Katmanları
        public ChartLayerInfo VelTrue { get; set; } = new ChartLayerInfo { DisplayName = "Gerçek Hız", Show = true, Color = System.Drawing.Color.FromArgb(135, 206, 235), LineWidth = 2.5f, DrawOrder = 1 }; // SkyBlue

        // 3. İvme Grafiği Katmanları
        public ChartLayerInfo AccTrue { get; set; } = new ChartLayerInfo { DisplayName = "Gerçek İvme", Show = true, Color = System.Drawing.Color.FromArgb(0, 255, 255), LineWidth = 2.5f, DrawOrder = 1 }; // Cyan
        public ChartLayerInfo AccRaw { get; set; } = new ChartLayerInfo { DisplayName = "Ham İvme", Show = true, Color = System.Drawing.Color.FromArgb(255, 69, 0), LineWidth = 1f, DrawOrder = 2 }; // OrangeRed
        public ChartLayerInfo AccCal { get; set; } = new ChartLayerInfo { DisplayName = "Kalibre İvme", Show = true, Color = System.Drawing.Color.FromArgb(50, 205, 50), LineWidth = 2f, DrawOrder = 3 }; // LimeGreen

        // 4. Sensör Kalibrasyon Sayfa 2 - Zaman Serisi Grafiği Katmanları
        public ChartLayerInfo SensorTsTrue { get; set; } = new ChartLayerInfo { DisplayName = "Sensor Referans", Show = true, Color = System.Drawing.Color.FromArgb(255, 215, 0), LineWidth = 3.2f, DrawOrder = 1 }; // Gold
        public ChartLayerInfo SensorTsRaw { get; set; } = new ChartLayerInfo { DisplayName = "Sensor Ham", Show = true, Color = System.Drawing.Color.FromArgb(255, 69, 0), LineWidth = 1f, DrawOrder = 2 }; // OrangeRed
        public ChartLayerInfo SensorTsCal { get; set; } = new ChartLayerInfo { DisplayName = "Sensor Kalibre", Show = true, Color = System.Drawing.Color.FromArgb(50, 205, 50), LineWidth = 2f, DrawOrder = 3 }; // LimeGreen

        // 5. Sensör Kalibrasyon Sayfa 2 - Olasılık Dağılım Grafiği Katmanları
        public ChartLayerInfo SensorDistTrueLine { get; set; } = new ChartLayerInfo { DisplayName = "Sensor Dağılım Referans", Show = true, Color = System.Drawing.Color.FromArgb(255, 215, 0), LineWidth = 3.2f, DrawOrder = 3 }; // Gold
        public ChartLayerInfo SensorDistRaw { get; set; } = new ChartLayerInfo { DisplayName = "Sensor Dağılım Ham", Show = true, Color = System.Drawing.Color.FromArgb(255, 69, 0), LineWidth = 2f, DrawOrder = 1 }; // OrangeRed
        public ChartLayerInfo SensorDistCal { get; set; } = new ChartLayerInfo { DisplayName = "Sensor Dağılım Kalibre", Show = true, Color = System.Drawing.Color.FromArgb(50, 205, 50), LineWidth = 2.5f, DrawOrder = 2 }; // LimeGreen

        public bool ShowPosTrue { get => PosTrue.Show; set => PosTrue.Show = value; }
        public System.Drawing.Color ColorPosTrue { get => PosTrue.Color; set => PosTrue.Color = value; }
        public bool ShowPosRaw { get => PosRaw.Show; set => PosRaw.Show = value; }
        public System.Drawing.Color ColorPosRaw { get => PosRaw.Color; set => PosRaw.Color = value; }
        public bool ShowPosCal { get => PosCal.Show; set => PosCal.Show = value; }
        public System.Drawing.Color ColorPosCal { get => PosCal.Color; set => PosCal.Color = value; }

        public bool ShowVelTrue { get => VelTrue.Show; set => VelTrue.Show = value; }
        public System.Drawing.Color ColorVelTrue { get => VelTrue.Color; set => VelTrue.Color = value; }

        public bool ShowAccTrue { get => AccTrue.Show; set => AccTrue.Show = value; }
        public System.Drawing.Color ColorAccTrue { get => AccTrue.Color; set => AccTrue.Color = value; }
        public bool ShowAccRaw { get => AccRaw.Show; set => AccRaw.Show = value; }
        public System.Drawing.Color ColorAccRaw { get => AccRaw.Color; set => AccRaw.Color = value; }
        public bool ShowAccCal { get => AccCal.Show; set => AccCal.Show = value; }
        public System.Drawing.Color ColorAccCal { get => AccCal.Color; set => AccCal.Color = value; }

        public int RowIndexPos { get; set; } = 0;
        public int RowIndexVel { get; set; } = 1;
        public int RowIndexAcc { get; set; } = 2;
    }
}
