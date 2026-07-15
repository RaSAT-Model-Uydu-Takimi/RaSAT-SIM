using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    public partial class SensorSettingsSubPanel : UserControl
    {
        private Random random = new Random();

        // Hafızada anlık tutulan son üretilmiş / işlenmiş veri listeleri
        private List<double> lastGeneratedRawSamples = new List<double>();
        private List<double> lastExportedCalSamples = new List<double>();

        // Sayfa 2 analizi için aktif veri setleri
        private List<double> p2RawSamples = new List<double>();
        private List<double> p2CalSamples = new List<double>();

        // Dosya yolları
        private string ref1FilePath = string.Empty;
        private string ref2FilePath = string.Empty;
        private string inputSensorFilePath = string.Empty;
        private string p2RawFilePath = string.Empty;
        private string p2CalFilePath = string.Empty;

        public SensorSettingsSubPanel()
        {
            InitializeComponent();
            SetupEventHandlers();
            cmbSensorType.SelectedIndex = 0;
            LogToConsole("Sensör Hata ve Kalibrasyon Modülü (Faz 5) başarıyla başlatıldı.", Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129))))));
        }

        private void SetupEventHandlers()
        {
            // Sayfa Geçişleri
            btnPage1_Settings.Click += (s, e) => SwitchToPage(1);
            btnPage2_Chart.Click += (s, e) => SwitchToPage(2);

            // Sayfa 1 - 3.1: Sensör Verisi Üret
            btnGenerateAndSaveCsv.Click += BtnGenerateAndSaveCsv_Click;

            // Sayfa 1 - 3.2: Kalibrasyon Hesapla
            btnSelectRef1File.Click += BtnSelectRef1File_Click;
            btnSelectRef2File.Click += BtnSelectRef2File_Click;
            btnCalculateCalibration.Click += BtnCalculateCalibration_Click;

            // Sayfa 1 - 3.3: Kalibre Edilmiş Çıktı Üret
            btnSelectInputFile.Click += BtnSelectInputFile_Click;
            btnExportCalibratedCsv.Click += BtnExportCalibratedCsv_Click;

            // Sayfa 1 - Rezidüel güncelleme ve uygulama
            btnApplyToSim.Click += (s, e) => UpdateComparisonAndResiduals();

            // Sayfa 2 - Analiz & Çizim
            btnP2SelectRawFile.Click += BtnP2SelectRawFile_Click;
            btnP2SelectCalFile.Click += BtnP2SelectCalFile_Click;
            btnP2UseLastGenerated.Click += BtnP2UseLastGenerated_Click;
            btnP2PlotAll.Click += BtnP2PlotAll_Click;

            picDistributionGraph.Paint += PicDistributionGraph_Paint;
            if (trkBinCount != null) trkBinCount.ValueChanged += TrkBinCount_ValueChanged;
        }

        private void TrkBinCount_ValueChanged(object? sender, EventArgs e)
        {
            if (lblBinCount != null && trkBinCount != null)
            {
                lblBinCount.Text = $"Histogram Dilim: {trkBinCount.Value}";
            }
            if (picDistributionGraph != null)
            {
                picDistributionGraph.Invalidate();
            }
        }

        private void SwitchToPage(int pageIndex)
        {
            if (pageIndex == 1)
            {
                grpRange.Visible = true;
                grpErrorsAndCalculated.Visible = true;
                grpFileAndCalibrationModules.Visible = true;
                grpConsoleLog.Visible = true;
                grpPage2_AnalysisAndPlots.Visible = false;

                btnPage1_Settings.BackColor = Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
                btnPage2_Chart.BackColor = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
                LogToConsole("Sayfa 1: Ayarlar, Kalibrasyon ve Dosya Modülleri aktifleştirildi.");
            }
            else
            {
                grpRange.Visible = false;
                grpErrorsAndCalculated.Visible = false;
                grpFileAndCalibrationModules.Visible = false;
                grpConsoleLog.Visible = false;
                grpPage2_AnalysisAndPlots.Visible = true;

                btnPage1_Settings.BackColor = Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
                btnPage2_Chart.BackColor = Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
                LogToConsole("Sayfa 2: ScottPlot Zaman Serisi ve Çift Çan Eğrisi (PDF) Analiz ekranına geçildi.");
            }
        }

        private void LogToConsole(string message, Color? color = null)
        {
            string timeStamp = DateTime.Now.ToString("HH:mm:ss");
            string logLine = $"[ {timeStamp} ] -> {message}\r\n";
            txtConsoleLog.AppendText(logLine);
        }

        #region Matematiksel ve Metrolojik Fonksiyonlar (Hata Üretim ve Kalibrasyon)

        private double GetNextGaussian(double mean, double stdDev)
        {
            double u1 = 1.0 - random.NextDouble();
            double u2 = 1.0 - random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return mean + stdDev * randStdNormal;
        }

        private double GetSimulatedRawSensorValue(double trueValue, int sampleIndex = -1, int totalCount = -1)
        {
            double val = trueValue;

            // 1. Bağıl Scale Hatası (% S)
            if (chkEnableScale.Checked && numScaleErrorPercent.Value != 0)
            {
                double scaleFactor = 1.0 + (double)numScaleErrorPercent.Value / 100.0;
                val = trueValue * scaleFactor;
            }

            // 2. Mutlak Bias Hatası (b)
            if (chkEnableBias.Checked && numBias.Value != 0)
            {
                val += (double)numBias.Value;
            }

            // 3. Sabit Termal Gürültü (σ_sabit)
            if (chkEnableThermal.Checked && numThermalStdDev.Value > 0)
            {
                val += GetNextGaussian(0.0, (double)numThermalStdDev.Value);
            }

            // 4. Bağıl Termal Gürültü (% FS)
            if (chkEnableRelativeNoise.Checked && numRelativeNoisePercent.Value > 0)
            {
                double fsSpan = (double)(numRangeMax.Value - numRangeMin.Value);
                if (fsSpan <= 0) fsSpan = 5000.0;
                double relStdDev = (double)numRelativeNoisePercent.Value * fsSpan / 100.0;
                val += GetNextGaussian(0.0, relStdDev);
            }

            // 5. Darbe Gürültüsü (Spike Noise)
            if (chkEnableSpike.Checked && numSpikeProbPercent.Value > 0)
            {
                if (random.NextDouble() * 100.0 < (double)numSpikeProbPercent.Value)
                {
                    double sign = random.NextDouble() > 0.5 ? 1.0 : -1.0;
                    val += sign * (double)numSpikeAmplitude.Value;
                }
            }

            // 6. Ayrılma / Faz Gürültüsü (Separation Burst Noise - örneğin uçuşun %25-%35 aralığında ekstra titreşim)
            if (chkEnablePhaseBurst != null && chkEnablePhaseBurst.Checked && numPhaseNoiseStdDev != null && numPhaseNoiseStdDev.Value > 0)
            {
                if (sampleIndex >= 0 && totalCount > 0)
                {
                    double frac = (double)sampleIndex / totalCount;
                    if (frac >= 0.25 && frac <= 0.35)
                    {
                        val += GetNextGaussian(0.0, (double)numPhaseNoiseStdDev.Value);
                    }
                }
                else
                {
                    // Eğer tekil anlık çekim veya indeks belirtilmemişse %10 olasılıkla sarsıntı ekle
                    if (random.NextDouble() < 0.10)
                    {
                        val += GetNextGaussian(0.0, (double)numPhaseNoiseStdDev.Value);
                    }
                }
            }

            return val;
        }

        private double GetCalibratedValue(double rawValue)
        {
            double bCalc = (double)numProcessedBias.Value;
            double sPercentCalc = (double)numProcessedScale.Value;
            double denominator = 1.0 + (sPercentCalc / 100.0);
            if (Math.Abs(denominator) < 1e-9) return rawValue;
            return (rawValue - bCalc) / denominator;
        }

        private List<double> GenerateSampleSet(double trueValue, int count)
        {
            List<double> samples = new List<double>(count);
            for (int i = 0; i < count; i++)
            {
                samples.Add(GetSimulatedRawSensorValue(trueValue, i, count));
            }
            return samples;
        }

        private double CalculateMeanWithOutlierRejection(List<double> data, bool trimOutliers)
        {
            if (data == null || data.Count == 0) return 0.0;
            if (!trimOutliers || data.Count < 20)
            {
                return data.Average();
            }

            // %5 Medyan/IQR Budama: Alttan ve üstten %5 uç darbeleri ele
            var sorted = data.OrderBy(x => x).ToList();
            int trimCount = (int)(sorted.Count * 0.05);
            if (trimCount * 2 >= sorted.Count) return sorted.Average();

            var trimmed = sorted.Skip(trimCount).Take(sorted.Count - 2 * trimCount).ToList();
            return trimmed.Average();
        }

        #endregion

        #region Sayfa 1 - 3. Bölüm Buton İşlemleri (Üret, Hesapla, Çıkar)

        private void BtnGenerateAndSaveCsv_Click(object? sender, EventArgs e)
        {
            int n = (int)numGenCount.Value;
            double trueVal = (double)numGenTrueVal.Value;

            lastGeneratedRawSamples = GenerateSampleSet(trueVal, n);
            lastExportedCalSamples = lastGeneratedRawSamples.Select(GetCalibratedValue).ToList();

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Sensör Ölçüm Dosyasını Kaydet (Klasik Format)";
                sfd.Filter = "Metin Veri Dosyası (*.txt;*.csv)|*.txt;*.csv|Tüm Dosyalar (*.*)|*.*";
                sfd.FileName = $"SensorOlcum_N{n}_Gercek{trueVal}.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0} 1", n));

                        List<string> strVals = lastGeneratedRawSamples.Select(v => v.ToString("F4", CultureInfo.InvariantCulture)).ToList();
                        sb.AppendLine(string.Join(" ", strVals));

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        LogToConsole($"Başarılı: {n} adet veri oluşturuldu ve dosyaya yazıldı -> {Path.GetFileName(sfd.FileName)}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Dosya kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogToConsole($"HATA: Dosya kaydı başarısız ({ex.Message})");
                    }
                }
            }
        }

        private void BtnSelectRef1File_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "1. Referans Noktası Ölçüm Dosyası Seç";
                ofd.Filter = "Veri Dosyaları (*.txt;*.csv)|*.txt;*.csv|Tüm Dosyalar (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ref1FilePath = ofd.FileName;
                    lblRef1FileName.Text = Path.GetFileName(ref1FilePath);
                    LogToConsole($"Ref 1 Dosyası seçildi: {lblRef1FileName.Text}");
                    AutoDetectTrueValueFromFileName(ref1FilePath, numCalRefTrue1);
                }
            }
        }

        private void BtnSelectRef2File_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "2. Referans Noktası Ölçüm Dosyası Seç";
                ofd.Filter = "Veri Dosyaları (*.txt;*.csv)|*.txt;*.csv|Tüm Dosyalar (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ref2FilePath = ofd.FileName;
                    lblRef2FileName.Text = Path.GetFileName(ref2FilePath);
                    LogToConsole($"Ref 2 Dosyası seçildi: {lblRef2FileName.Text}");
                    AutoDetectTrueValueFromFileName(ref2FilePath, numCalRefTrue2);
                }
            }
        }

        private void AutoDetectTrueValueFromFileName(string fileName, NumericUpDown targetNum)
        {
            if (string.IsNullOrEmpty(fileName)) return;
            try
            {
                string name = Path.GetFileNameWithoutExtension(fileName);
                var match = Regex.Match(name, @"Ger[cç]ek[_\-\s]*([\d\.]+)");
                if (match.Success && decimal.TryParse(match.Groups[1].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val))
                {
                    if (val >= targetNum.Minimum && val <= targetNum.Maximum)
                    {
                        targetNum.Value = val;
                        LogToConsole($" -> Dosya adından gerçek değer otomatik okundu ve atandı: {val}");
                    }
                }
            }
            catch { }
        }

        private List<double> ParseClassicalFile(string filePath)
        {
            List<double> list = new List<double>();
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath)) return list;

            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line)) continue;

                string[] tokens = line.Split(new char[] { ' ', '\t', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
                
                // İlk satır "N M" formatındaysa (Örn: 500 1) atlayabilir veya parse edebiliriz
                if (i == 0 && tokens.Length == 2 && int.TryParse(tokens[0], out int count) && int.TryParse(tokens[1], out int cols))
                {
                    continue;
                }

                foreach (var tok in tokens)
                {
                    if (double.TryParse(tok, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                    {
                        list.Add(val);
                    }
                }
            }
            return list;
        }

        private void BtnCalculateCalibration_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ref1FilePath) || !File.Exists(ref1FilePath) ||
                string.IsNullOrEmpty(ref2FilePath) || !File.Exists(ref2FilePath))
            {
                MessageBox.Show("Lütfen önce hem Ref 1 hem de Ref 2 dosyalarını seçiniz!", "Eksik Dosya", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<double> dataRef1 = ParseClassicalFile(ref1FilePath);
            List<double> dataRef2 = ParseClassicalFile(ref2FilePath);

            if (dataRef1.Count == 0 || dataRef2.Count == 0)
            {
                MessageBox.Show("Seçilen dosyalarda geçerli ölçüm verisi okunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double true1 = (double)numCalRefTrue1.Value;
            double true2 = (double)numCalRefTrue2.Value;

            if (Math.Abs(true2 - true1) < 1e-6)
            {
                MessageBox.Show("Ref 1 ve Ref 2 gerçek değerleri aynı olamaz! Lütfen farklı iki referans noktası giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool trim = chkOutlierRejection.Checked;
            double mean1 = CalculateMeanWithOutlierRejection(dataRef1, trim);
            double mean2 = CalculateMeanWithOutlierRejection(dataRef2, trim);

            // 2 Noktadan Doğrusal Regresyon: m = (Y2 - Y1) / (X2 - X1), b = Y1 - m * X1
            double m = (mean2 - mean1) / (true2 - true1);
            double b = mean1 - (m * true1);
            double sPercent = (m - 1.0) * 100.0;

            string logMsg = $"Kalibrasyon Hesaplandı -> Ref1_Ort: {mean1:F2}, Ref2_Ort: {mean2:F2} | Eğim m: {m:F4}, Bias b: {b:F4}, Scale: %{sPercent:F4}";
            LogToConsole(logMsg);

            if (chkAutoSaveToCalculated.Checked)
            {
                numProcessedBias.Value = (decimal)Math.Max((double)numProcessedBias.Minimum, Math.Min((double)numProcessedBias.Maximum, b));
                numProcessedScale.Value = (decimal)Math.Max((double)numProcessedScale.Minimum, Math.Min((double)numProcessedScale.Maximum, sPercent));
                UpdateComparisonAndResiduals();
                LogToConsole("Bulunan kalibrasyon parametreleri 'Hesaplanan Hatalar' alanına işlendi.");
            }
        }

        private void BtnSelectInputFile_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Kalibre Edilecek Girdi Sensör Dosyasını Seç";
                ofd.Filter = "Veri Dosyaları (*.txt;*.csv)|*.txt;*.csv|Tüm Dosyalar (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inputSensorFilePath = ofd.FileName;
                    lblInputFileName.Text = Path.GetFileName(inputSensorFilePath);
                    LogToConsole($"Girdi Dosyası seçildi: {lblInputFileName.Text}");
                }
            }
        }

        private void BtnExportCalibratedCsv_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputSensorFilePath) || !File.Exists(inputSensorFilePath))
            {
                // Eğer dosya seçili değilse ve hafızada son üretilmiş veri varsa kullanıcıya sor veya onu kullan
                if (lastGeneratedRawSamples.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("Girdi dosyası seçilmedi, ancak RAM'de son üretilen sensör verisi (S1) mevcut. Bu veri kalibre edilerek kaydedilsin mi?", "Hafızadaki Veriyi Kullan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;
                }
                else
                {
                    MessageBox.Show("Lütfen önce kalibre edilecek bir girdi dosyası seçiniz veya yeni veri üretiniz!", "Eksik Dosya", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            List<double> rawInput = string.IsNullOrEmpty(inputSensorFilePath) ? lastGeneratedRawSamples : ParseClassicalFile(inputSensorFilePath);
            if (rawInput.Count == 0)
            {
                MessageBox.Show("Girdi verisinde okunabilir ölçüm bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lastExportedCalSamples = rawInput.Select(GetCalibratedValue).ToList();

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Kalibre Edilmiş Çıktı Dosyasını Kaydet (Klasik Format)";
                sfd.Filter = "Metin Veri Dosyası (*.txt;*.csv)|*.txt;*.csv|Tüm Dosyalar (*.*)|*.*";
                sfd.FileName = $"KalibreEdilmisVeri_N{lastExportedCalSamples.Count}.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "{0} 1", lastExportedCalSamples.Count));

                        List<string> strVals = lastExportedCalSamples.Select(v => v.ToString("F4", CultureInfo.InvariantCulture)).ToList();
                        sb.AppendLine(string.Join(" ", strVals));

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        LogToConsole($"Başarılı: {lastExportedCalSamples.Count} adet veri kalibre edildi ve dosyaya kaydedildi -> {Path.GetFileName(sfd.FileName)}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Dosya kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UpdateComparisonAndResiduals()
        {
            double injBias = chkEnableBias.Checked ? (double)numBias.Value : 0.0;
            double injScale = chkEnableScale.Checked ? (double)numScaleErrorPercent.Value : 0.0;

            double calcBias = (double)numProcessedBias.Value;
            double calcScale = (double)numProcessedScale.Value;

            double resBias = injBias - calcBias;
            double resScale = injScale - calcScale;

            lblResidualInfo.Text = $"Rezidüel Fark: b = {resBias:F4} | S = %{resScale:F4}";
            LogToConsole($"Rezidüeller güncellendi (Fark: b={resBias:F4}, S=%{resScale:F4}).");
        }

        #endregion

        #region Sayfa 2 - ScottPlot & Çift Çan Eğrisi Analiz İşlemleri

        private void BtnP2SelectRawFile_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Analiz İçin Ham Sensör Dosyası Seç";
                ofd.Filter = "Veri Dosyaları (*.txt;*.csv)|*.txt;*.csv|Tüm Dosyalar (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    p2RawFilePath = ofd.FileName;
                    txtP2RawFilePath.Text = Path.GetFileName(p2RawFilePath);
                    p2RawSamples = ParseClassicalFile(p2RawFilePath);
                    LogToConsole($"Sayfa 2 Ham Dosya yüklendi ({p2RawSamples.Count} veri): {txtP2RawFilePath.Text}");
                }
            }
        }

        private void BtnP2SelectCalFile_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Analiz İçin Kalibre Edilmiş Dosya Seç";
                ofd.Filter = "Veri Dosyaları (*.txt;*.csv)|*.txt;*.csv|Tüm Dosyalar (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    p2CalFilePath = ofd.FileName;
                    txtP2CalFilePath.Text = Path.GetFileName(p2CalFilePath);
                    p2CalSamples = ParseClassicalFile(p2CalFilePath);
                    LogToConsole($"Sayfa 2 Kalibre Dosya yüklendi ({p2CalSamples.Count} veri): {txtP2CalFilePath.Text}");
                }
            }
        }

        private void BtnP2UseLastGenerated_Click(object? sender, EventArgs e)
        {
            if (lastGeneratedRawSamples.Count == 0)
            {
                MessageBox.Show("Sayfa 1'de henüz veri üretilmedi veya dosya işlenmedi! Önce Sayfa 1'den veri üretin.", "Veri Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            p2RawSamples = new List<double>(lastGeneratedRawSamples);
            if (lastExportedCalSamples.Count == p2RawSamples.Count)
            {
                p2CalSamples = new List<double>(lastExportedCalSamples);
            }
            else
            {
                p2CalSamples = p2RawSamples.Select(GetCalibratedValue).ToList();
            }

            txtP2RawFilePath.Text = "(S1'den Anlık Çekildi)";
            txtP2CalFilePath.Text = "(S1'den Anlık Çekildi)";
            numP2TrueVal.Value = numGenTrueVal.Value;

            LogToConsole($"Sayfa 1'deki son aktif veri setleri ({p2RawSamples.Count} adet) Sayfa 2 analize çekildi.");
            BtnP2PlotAll_Click(this, EventArgs.Empty);
        }

        private void BtnP2PlotAll_Click(object? sender, EventArgs e)
        {
            if (p2RawSamples.Count == 0)
            {
                // Eğer hiç veri seçilmediyse anlık çekilmeyi dene
                if (lastGeneratedRawSamples.Count > 0)
                {
                    BtnP2UseLastGenerated_Click(this, EventArgs.Empty);
                    return;
                }
                MessageBox.Show("Lütfen analiz edilecek Ham Sensör Dosyasını seçiniz veya Sayfa 1'den Anlık Çek butonunu kullanınız!", "Veri Yok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (p2CalSamples.Count == 0 || p2CalSamples.Count != p2RawSamples.Count)
            {
                // Eğer kalibre dosya seçilmediyse, şu anki aktif kalibrasyon parametreleriyle hesapla
                p2CalSamples = p2RawSamples.Select(GetCalibratedValue).ToList();
                txtP2CalFilePath.Text = "(Aktif Kalibrasyon ile Otomatik)";
            }

            double trueVal = (double)numP2TrueVal.Value;
            int n = p2RawSamples.Count;

            // 1. Üst Grafik: ScottPlot Zaman Serisi / Titreşim Grafiği
            plotTimeSeries.Plot.Clear();

            double[] xs = new double[n];
            double[] trues = new double[n];
            double[] raws = p2RawSamples.ToArray();
            double[] cals = p2CalSamples.ToArray();

            for (int i = 0; i < n; i++)
            {
                xs[i] = i;
                trues[i] = trueVal;
            }

            // Ham Sensör Verisi (Kırmızı)
            var sRaw = plotTimeSeries.Plot.Add.Scatter(xs, raws);
            sRaw.LegendText = $"Ham Sensör Verisi (Ort: {raws.Average():F2} m)";
            sRaw.Color = ScottPlot.Colors.OrangeRed;
            sRaw.LineWidth = 1.0f;
            sRaw.MarkerSize = 2.0f;

            // Kalibre Edilmiş Veri (Yeşil)
            var sCal = plotTimeSeries.Plot.Add.Scatter(xs, cals);
            sCal.LegendText = $"Kalibre Edilmiş Veri (Ort: {cals.Average():F2} m)";
            sCal.Color = ScottPlot.Colors.LimeGreen;
            sCal.LineWidth = 1.5f;
            sCal.MarkerSize = 3.0f;

            // Gerçek Veri Referans Çizgisi (Sarı / Gold) - En üst katmanda, kalın ve markersız net çizgi
            var sTrue = plotTimeSeries.Plot.Add.Scatter(xs, trues);
            sTrue.LegendText = $"Gerçek Referans ({trueVal:F1} m)";
            sTrue.Color = ScottPlot.Colors.Gold;
            sTrue.LineWidth = 3.2f;
            sTrue.MarkerSize = 0f;

            plotTimeSeries.Plot.Title("Örneklem Bazlı Zaman Serisi & Titreşim Karşılaştırması");
            plotTimeSeries.Plot.XLabel("Örneklem İndeksi / Zaman Adımı (i)");
            plotTimeSeries.Plot.YLabel("Ölçüm Büyüklüğü (Birim)");
            plotTimeSeries.Plot.ShowLegend();
            plotTimeSeries.Refresh();

            // 2. Alt Grafik: Çift Çan Eğrisi Tuvalini Yenile
            picDistributionGraph.Invalidate();

            // 3. İstatistik ve Metrik Özet Tablosunu Yaz
            double rawMean = p2RawSamples.Average();
            double rawStd = Math.Sqrt(p2RawSamples.Select(v => Math.Pow(v - rawMean, 2)).Sum() / n);
            double rawAbsErr = Math.Abs(rawMean - trueVal);

            double calMean = p2CalSamples.Average();
            double calStd = Math.Sqrt(p2CalSamples.Select(v => Math.Pow(v - calMean, 2)).Sum() / n);
            double calAbsErr = Math.Abs(calMean - trueVal);

            double accuracyImp = rawAbsErr > 1e-6 ? ((rawAbsErr - calAbsErr) / rawAbsErr) * 100.0 : 100.0;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[ ANALİZ ÖZETİ (N = {n} Ölçüm | Referans X = {trueVal:F2}) ]");
            sb.AppendLine($"--------------------------------------------------------------------------------------------------");
            sb.AppendLine($"-> HAM SENSÖR DOSYASI : Ortalama = {rawMean,10:F4} | Std Sapma σ = ±{rawStd,8:F4} | Mutlak Sapma = {rawAbsErr,8:F4}");
            sb.AppendLine($"-> KALİBRE DOSYA      : Ortalama = {calMean,10:F4} | Std Sapma σ = ±{calStd,8:F4} | Mutlak Sapma = {calAbsErr,8:F4}");
            sb.AppendLine($"-> METROLOJİK DEĞER   : Sistematik Hata İyileşmesi = %{Math.Max(0.0, accuracyImp):F2} | Gürültü Standart Sapması σ Korundu.");

            txtP2SummaryTable.Text = sb.ToString();
            LogToConsole("ScottPlot zaman serisi grafiği ve PDF dağılım eğrileri çizildi.");
        }

        private void PicDistributionGraph_Paint(object? sender, PaintEventArgs e)
        {
            if (p2RawSamples == null || p2RawSamples.Count == 0) return;

            DrawDistributionGraph(e.Graphics, picDistributionGraph.Width, picDistributionGraph.Height, (double)numP2TrueVal.Value, p2RawSamples, p2CalSamples);
        }

        private void DrawDistributionGraph(Graphics g, int width, int height, double trueVal, List<double> rawData, List<double> calData)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42))))));

            if (rawData == null || rawData.Count < 5) return;

            int padLeft = 55, padRight = 30, padTop = 30, padBottom = 45;
            int plotW = width - padLeft - padRight;
            int plotH = height - padTop - padBottom;

            using (Pen penGrid = new Pen(Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85))))), 1f) { DashStyle = DashStyle.Dash })
            using (Pen penAxis = new Pen(Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184))))), 1.5f))
            {
                g.DrawLine(penAxis, padLeft, padTop, padLeft, height - padBottom);
                g.DrawLine(penAxis, padLeft, height - padBottom, width - padRight, height - padBottom);

                for (int i = 1; i <= 4; i++)
                {
                    int y = height - padBottom - (i * plotH / 4);
                    g.DrawLine(penGrid, padLeft, y, width - padRight, y);
                }
            }

            double minVal = Math.Min(trueVal, Math.Min(rawData.Min(), calData != null && calData.Count > 0 ? calData.Min() : rawData.Min()));
            double maxVal = Math.Max(trueVal, Math.Max(rawData.Max(), calData != null && calData.Count > 0 ? calData.Max() : rawData.Max()));

            double span = maxVal - minVal;
            if (span < 1.0) span = 10.0;
            minVal -= span * 0.15;
            maxVal += span * 0.15;
            span = maxVal - minVal;

            int numBins = trkBinCount != null && trkBinCount.Value >= 10 ? trkBinCount.Value : 36;
            double binWidth = span / numBins;
            int[] binsRaw = new int[numBins];
            int[] binsCal = new int[numBins];

            foreach (var v in rawData)
            {
                int idx = (int)((v - minVal) / binWidth);
                if (idx < 0) idx = 0;
                if (idx >= numBins) idx = numBins - 1;
                binsRaw[idx]++;
            }

            if (calData != null && calData.Count > 0)
            {
                foreach (var v in calData)
                {
                    int idx = (int)((v - minVal) / binWidth);
                    if (idx < 0) idx = 0;
                    if (idx >= numBins) idx = numBins - 1;
                    binsCal[idx]++;
                }
            }

            int maxCount = Math.Max(binsRaw.Max(), binsCal.Max());
            if (maxCount < 1) maxCount = 1;

            // Kırmızı ve Yeşil histogram çubukları
            using (SolidBrush brushRawBin = new SolidBrush(Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))))))
            using (Pen penRawBin = new Pen(Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68))))), 1f))
            using (SolidBrush brushCalBin = new SolidBrush(Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))))))
            using (Pen penCalBin = new Pen(Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129))))), 1f))
            {
                for (int i = 0; i < numBins; i++)
                {
                    float xBin = padLeft + (float)(i * binWidth * plotW / span);
                    float wBin = (float)(binWidth * plotW / span);

                    if (binsRaw[i] > 0)
                    {
                        float hRaw = (float)binsRaw[i] / maxCount * plotH;
                        float yRaw = height - padBottom - hRaw;
                        g.FillRectangle(brushRawBin, xBin, yRaw, wBin, hRaw);
                        g.DrawRectangle(penRawBin, xBin, yRaw, wBin, hRaw);
                    }

                    if (calData != null && calData.Count > 0 && binsCal[i] > 0)
                    {
                        float hCal = (float)binsCal[i] / maxCount * plotH;
                        float yCal = height - padBottom - hCal;
                        g.FillRectangle(brushCalBin, xBin + wBin * 0.2f, yCal, wBin * 0.6f, hCal);
                        g.DrawRectangle(penCalBin, xBin + wBin * 0.2f, yCal, wBin * 0.6f, hCal);
                    }
                }
            }

            // Teori/Dağılım Gauss Çift Çan Eğrisi (Kırmızı vs Yeşil)
            double rawMean = rawData.Average();
            double rawStd = Math.Sqrt(rawData.Select(v => Math.Pow(v - rawMean, 2)).Sum() / rawData.Count);
            if (rawStd < 1e-4) rawStd = 1.0;

            DrawBellCurve(g, padLeft, padBottom, plotW, plotH, minVal, maxVal, rawMean, rawStd, maxCount, binWidth, rawData.Count, Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68))))), 2.5f);

            if (calData != null && calData.Count > 0)
            {
                double calMean = calData.Average();
                double calStd = Math.Sqrt(calData.Select(v => Math.Pow(v - calMean, 2)).Sum() / calData.Count);
                if (calStd < 1e-4) calStd = 1.0;
                DrawBellCurve(g, padLeft, padBottom, plotW, plotH, minVal, maxVal, calMean, calStd, maxCount, binWidth, calData.Count, Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129))))), 2.5f);
            }

            // Referans Dikey Çizgisi (Sarı / Gold) - En üst katmanda, gölgeli ve belirgin
            float xTrue = padLeft + (float)((trueVal - minVal) / span * plotW);
            using (Pen penTrueShadow = new Pen(Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42))))), 4f))
            using (Pen penTrue = new Pen(Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0))))), 2.8f) { DashStyle = DashStyle.Dash })
            {
                g.DrawLine(penTrueShadow, xTrue, padTop, xTrue, height - padBottom);
                g.DrawLine(penTrue, xTrue, padTop, xTrue, height - padBottom);
            }

            // Metinler ve Eksen Etiketleri
            using (Font fontLabel = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            using (Font fontInfo = new Font("Segoe UI", 9F, FontStyle.Bold))
            using (SolidBrush brushText = new SolidBrush(Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))))))
            using (SolidBrush brushTrueText = new SolidBrush(Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(179)))), ((int)(((byte)(8)))))))
            {
                g.DrawString($"Min: {minVal:F1}", fontLabel, brushText, padLeft, height - padBottom + 8);
                g.DrawString($"Max: {maxVal:F1}", fontLabel, brushText, width - padRight - 55, height - padBottom + 8);
                g.DrawString($"Gerçek Değer: {trueVal:F1} m", fontLabel, brushTrueText, xTrue + 5, padTop + 5);

                g.DrawString("Olasılık Yoğunluk Histogramı ve Çift Çan Eğrisi (Kırmızı: Ham vs Yeşil: Kalibre Edilmiş)", fontInfo, brushText, padLeft + 10, 8);
            }
        }

        private void DrawBellCurve(Graphics g, int padLeft, int padBottom, int plotW, int plotH, double minVal, double maxVal, double mean, double stdDev, int maxCount, double binWidth, int n, Color color, float penWidth)
        {
            double span = maxVal - minVal;
            int steps = 150;
            PointF[] points = new PointF[steps];

            for (int i = 0; i < steps; i++)
            {
                double x = minVal + (span * i / (steps - 1));
                double exponent = -0.5 * Math.Pow((x - mean) / stdDev, 2);
                double pdf = (1.0 / (stdDev * Math.Sqrt(2.0 * Math.PI))) * Math.Exp(exponent);

                double expectedCount = pdf * n * binWidth;
                float yPx = picDistributionGraph.Height - padBottom - (float)(expectedCount / maxCount * plotH);
                float xPx = padLeft + (float)((x - minVal) / span * plotW);

                points[i] = new PointF(xPx, yPx);
            }

            using (Pen penCurve = new Pen(color, penWidth))
            {
                g.DrawLines(penCurve, points);
            }
        }

        #endregion
    }
}
