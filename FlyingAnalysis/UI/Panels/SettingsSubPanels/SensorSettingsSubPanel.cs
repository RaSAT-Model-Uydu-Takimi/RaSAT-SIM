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
using FlyingAnalysis.Models;
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
            LoadUIFromGlobalSensorProfile();
            SyncToGlobalSensorProfile();
            LogToConsole("Sensör Hata ve Kalibrasyon Modülü (Faz 5) başarıyla başlatıldı.", Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129))))));
        }

        private void SetupEventHandlers()
        {
            // Sayfa Geçişleri
            btnPage1_Settings.Click += (s, e) => SwitchToPage(1);
            btnPage2_Chart.Click += (s, e) => SwitchToPage(2);
            btnPage3_Estimation.Click += (s, e) => SwitchToPage(3);

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
            numBias.ValueChanged += (s, e) => SyncToGlobalSensorProfile();
            numScaleErrorPercent.ValueChanged += (s, e) => SyncToGlobalSensorProfile();
            numThermalStdDev.ValueChanged += (s, e) => SyncToGlobalSensorProfile();
            numRelativeNoisePercent.ValueChanged += (s, e) => SyncToGlobalSensorProfile();
            numSpikeProbPercent.ValueChanged += (s, e) => SyncToGlobalSensorProfile();
            numSpikeAmplitude.ValueChanged += (s, e) => SyncToGlobalSensorProfile();
            numProcessedBias.ValueChanged += (s, e) => SyncToGlobalSensorProfile();
            numProcessedScale.ValueChanged += (s, e) => SyncToGlobalSensorProfile();

            chkEnableBias.CheckedChanged += (s, e) => SyncToGlobalSensorProfile();
            chkEnableScale.CheckedChanged += (s, e) => SyncToGlobalSensorProfile();
            chkEnableThermal.CheckedChanged += (s, e) => SyncToGlobalSensorProfile();
            chkEnableRelativeNoise.CheckedChanged += (s, e) => SyncToGlobalSensorProfile();
            chkEnableSpike.CheckedChanged += (s, e) => SyncToGlobalSensorProfile();

            cmbSensorType.SelectedIndexChanged += (s, e) => { LoadUIFromGlobalSensorProfile(); SyncToGlobalSensorProfile(); };

            if (btnSaveSensorProfile != null) btnSaveSensorProfile.Click += BtnSaveSensorProfile_Click;
            if (btnLoadSensorProfile != null) btnLoadSensorProfile.Click += BtnLoadSensorProfile_Click;
            if (btnMasterSaveCsv != null) btnMasterSaveCsv.Click += BtnMasterSaveCsv_Click;
            if (btnP2ChartLayers != null) btnP2ChartLayers.Click += BtnP2ChartLayers_Click;

            // Sayfa 2 - Analiz & Çizim
            btnP2SelectRawFile.Click += BtnP2SelectRawFile_Click;
            btnP2SelectCalFile.Click += BtnP2SelectCalFile_Click;
            btnP2UseLastGenerated.Click += BtnP2UseLastGenerated_Click;
            btnP2PlotAll.Click += BtnP2PlotAll_Click;

            btnP2ViewSplit.Click += (s, e) => SetP2ViewMode(0);
            btnP2ViewTimeSeries.Click += (s, e) => SetP2ViewMode(1);
            btnP2ViewDistribution.Click += (s, e) => SetP2ViewMode(2);
            if (trkBinCount != null) trkBinCount.ValueChanged += TrkBinCount_ValueChanged;
        }

        private void TrkBinCount_ValueChanged(object? sender, EventArgs e)
        {
            if (lblBinCount != null && trkBinCount != null)
            {
                lblBinCount.Text = $"Histogram Dilim: {trkBinCount.Value}";
            }
            if (p2RawSamples != null && p2RawSamples.Count > 0)
            {
                BtnP2PlotAll_Click(this, EventArgs.Empty);
            }
        }

        private void SwitchToPage(int pageIndex)
        {
            // Tüm sayfaları gizle
            grpRange.Visible = false;
            grpErrorsAndCalculated.Visible = false;
            grpFileAndCalibrationModules.Visible = false;
            grpConsoleLog.Visible = false;
            grpPage2_AnalysisAndPlots.Visible = false;
            pnlPage3_Estimation.Visible = false;

            // Butonları pasif renge al
            btnPage1_Settings.BackColor = Color.FromArgb(51, 65, 85);
            btnPage2_Chart.BackColor = Color.FromArgb(51, 65, 85);
            btnPage3_Estimation.BackColor = Color.FromArgb(51, 65, 85);

            if (pageIndex == 1)
            {
                grpRange.Visible = true;
                grpErrorsAndCalculated.Visible = true;
                grpFileAndCalibrationModules.Visible = true;
                grpConsoleLog.Visible = true;
                btnPage1_Settings.BackColor = Color.FromArgb(15, 118, 110);
                LogToConsole("Sayfa 1: Ayarlar, Kalibrasyon ve Dosya Modülleri aktifleştirildi.");
            }
            else if (pageIndex == 2)
            {
                grpPage2_AnalysisAndPlots.Visible = true;
                btnPage2_Chart.BackColor = Color.FromArgb(15, 118, 110);
                LogToConsole("Sayfa 2: ScottPlot Zaman Serisi ve Çift Çan Eğrisi (PDF) Analiz ekranına geçildi.");
            }
            else if (pageIndex == 3)
            {
                pnlPage3_Estimation.Visible = true;
                btnPage3_Estimation.BackColor = Color.FromArgb(15, 118, 110);

                // Dinamik yükle (ilk açılışta)
                if (pnlPage3_Estimation.Controls.Count == 0)
                {
                    var estPanel = new SensorEstimationSubPanel { Dock = DockStyle.Fill };
                    pnlPage3_Estimation.Controls.Add(estPanel);
                }
                LogToConsole("Sayfa 3: Kestirim Çekirdeği (Gelişmiş Kalman Filtresi) parametreleri açıldı.");
            }
        }

        private void SetP2ViewMode(int mode)
        {
            if (mode == 0) // 📊 İkili Görünüm
            {
                plotTimeSeries.Visible = true;
                plotTimeSeries.Location = new Point(15, 115);
                plotTimeSeries.Size = new Size(1330, 290);

                plotDistributionGraph.Visible = true;
                plotDistributionGraph.Location = new Point(15, 415);
                plotDistributionGraph.Size = new Size(1330, 290);

                btnP2ViewSplit.BackColor = Color.FromArgb(15, 118, 110);
                btnP2ViewTimeSeries.BackColor = Color.FromArgb(51, 65, 85);
                btnP2ViewDistribution.BackColor = Color.FromArgb(51, 65, 85);
                LogToConsole("Sayfa 2: İkili görünüm (Zaman Serisi + Olasılık Dağılımı) aktifleştirildi.");
            }
            else if (mode == 1) // 📈 Zaman Serisi Tam Ekran
            {
                plotTimeSeries.Visible = true;
                plotTimeSeries.Location = new Point(15, 115);
                plotTimeSeries.Size = new Size(1330, 590);

                plotDistributionGraph.Visible = false;

                btnP2ViewSplit.BackColor = Color.FromArgb(51, 65, 85);
                btnP2ViewTimeSeries.BackColor = Color.FromArgb(15, 118, 110);
                btnP2ViewDistribution.BackColor = Color.FromArgb(51, 65, 85);
                LogToConsole("Sayfa 2: Zaman Serisi tam ekran moduna geçildi.");
            }
            else if (mode == 2) // 🔔 Olasılık Dağılımı Tam Ekran (DEV)
            {
                plotTimeSeries.Visible = false;

                plotDistributionGraph.Visible = true;
                plotDistributionGraph.Location = new Point(15, 115);
                plotDistributionGraph.Size = new Size(1330, 590);

                btnP2ViewSplit.BackColor = Color.FromArgb(51, 65, 85);
                btnP2ViewTimeSeries.BackColor = Color.FromArgb(51, 65, 85);
                btnP2ViewDistribution.BackColor = Color.FromArgb(15, 118, 110);
                LogToConsole("Sayfa 2: Olasılık Dağılımı tam ekran (DEV Histogram & Çift Çan Eğrisi) moduna geçildi.");
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
                        // 1. Satır: Gerçek / Referans Değer (True Value - X_true)
                        sb.AppendLine(trueVal.ToString("F4", CultureInfo.InvariantCulture));
                        // 2. Satır: Kaç Adet Örneklem Üretildiği (Sample Count - N)
                        sb.AppendLine(n.ToString(CultureInfo.InvariantCulture));
                        // 3. Satır ve Sonrası: Satır Satır Örneklem Değerleri
                        foreach (var val in lastGeneratedRawSamples)
                        {
                            sb.AppendLine(val.ToString("F4", CultureInfo.InvariantCulture));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        LogToConsole($"Başarılı: {n} adet veri (Ref: {trueVal:F1}m) dikey formatta oluşturuldu ve dosyaya yazıldı -> {Path.GetFileName(sfd.FileName)}");
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
            if (lines.Length == 0) return list;

            int startLineIndex = 0;
            string firstLine = lines[0].Trim();
            string[] firstTokens = firstLine.Split(new char[] { ' ', '\t', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);

            // Eski format ("500 1" gibi 2 adet tamsayı varsa)
            if (firstTokens.Length == 2 && int.TryParse(firstTokens[0], out int countOld) && int.TryParse(firstTokens[1], out int colsOld))
            {
                startLineIndex = 1;
            }
            // Yeni Dikey Standart Format: 1. Satır -> Referans Değer (double), 2. Satır -> Örneklem Adedi (int)
            else if (lines.Length >= 2 && double.TryParse(firstLine, NumberStyles.Any, CultureInfo.InvariantCulture, out _) &&
                     int.TryParse(lines[1].Trim(), out _) && firstTokens.Length == 1)
            {
                startLineIndex = 2; // 3. satırdan (indeks 2) itibaren veriler başlıyor
            }

            for (int i = startLineIndex; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line)) continue;

                string[] tokens = line.Split(new char[] { ' ', '\t', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
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
                        double currentRef = (double)numP2TrueVal.Value;
                        // 1. Satır: Gerçek / Referans Değer
                        sb.AppendLine(currentRef.ToString("F4", CultureInfo.InvariantCulture));
                        // 2. Satır: Kaç Adet Üretildiği
                        sb.AppendLine(lastExportedCalSamples.Count.ToString(CultureInfo.InvariantCulture));
                        // 3. Satır ve Sonrası: Satır Satır Kalibre Edilmiş Değerler
                        foreach (var val in lastExportedCalSamples)
                        {
                            sb.AppendLine(val.ToString("F4", CultureInfo.InvariantCulture));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        LogToConsole($"Başarılı: {lastExportedCalSamples.Count} adet veri dikey formatta kalibre edildi ve kaydedildi -> {Path.GetFileName(sfd.FileName)}");
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

            SyncToGlobalSensorProfile();
            lblResidualInfo.Text = $"Rezidüel Fark: b = {resBias:F4} | S = %{resScale:F4}";
            LogToConsole($"Rezidüeller güncellendi (Fark: b={resBias:F4}, S=%{resScale:F4}).");
        }

        private bool isSyncingUI = false;
        private void LoadUIFromGlobalSensorProfile()
        {
            try
            {
                isSyncingUI = true;
                bool isBaro = (cmbSensorType.SelectedIndex == 0 || cmbSensorType.SelectedItem?.ToString()?.Contains("Barometre") == true);
                if (isBaro)
                {
                    numBias.Value = (decimal)Math.Clamp(GlobalSimulationConfig.BaroBiasMeter, (double)numBias.Minimum, (double)numBias.Maximum);
                    numScaleErrorPercent.Value = (decimal)Math.Clamp(GlobalSimulationConfig.BaroScaleErrorPercent, (double)numScaleErrorPercent.Minimum, (double)numScaleErrorPercent.Maximum);
                    numThermalStdDev.Value = (decimal)Math.Clamp(GlobalSimulationConfig.BaroNoiseStdMeter, (double)numThermalStdDev.Minimum, (double)numThermalStdDev.Maximum);
                    numRelativeNoisePercent.Value = (decimal)Math.Clamp(GlobalSimulationConfig.BaroRelativeNoisePercent, (double)numRelativeNoisePercent.Minimum, (double)numRelativeNoisePercent.Maximum);
                    numSpikeProbPercent.Value = (decimal)Math.Clamp(GlobalSimulationConfig.BaroSpikeProbPercent, (double)numSpikeProbPercent.Minimum, (double)numSpikeProbPercent.Maximum);
                    numSpikeAmplitude.Value = (decimal)Math.Clamp(GlobalSimulationConfig.BaroSpikeAmplitudeMeter, (double)numSpikeAmplitude.Minimum, (double)numSpikeAmplitude.Maximum);
                    numProcessedBias.Value = (decimal)Math.Clamp(GlobalSimulationConfig.BaroProcessedBias, (double)numProcessedBias.Minimum, (double)numProcessedBias.Maximum);
                    numProcessedScale.Value = (decimal)Math.Clamp(GlobalSimulationConfig.BaroProcessedScalePercent, (double)numProcessedScale.Minimum, (double)numProcessedScale.Maximum);
                }
                else
                {
                    numBias.Value = (decimal)Math.Clamp(GlobalSimulationConfig.AccBiasMps2, (double)numBias.Minimum, (double)numBias.Maximum);
                    numScaleErrorPercent.Value = (decimal)Math.Clamp(GlobalSimulationConfig.AccScaleErrorPercent, (double)numScaleErrorPercent.Minimum, (double)numScaleErrorPercent.Maximum);
                    numThermalStdDev.Value = (decimal)Math.Clamp(GlobalSimulationConfig.AccNoiseStdMps2, (double)numThermalStdDev.Minimum, (double)numThermalStdDev.Maximum);
                    numRelativeNoisePercent.Value = (decimal)Math.Clamp(GlobalSimulationConfig.AccRelativeNoisePercent, (double)numRelativeNoisePercent.Minimum, (double)numRelativeNoisePercent.Maximum);
                    numSpikeProbPercent.Value = (decimal)Math.Clamp(GlobalSimulationConfig.AccSpikeProbPercent, (double)numSpikeProbPercent.Minimum, (double)numSpikeProbPercent.Maximum);
                    numSpikeAmplitude.Value = (decimal)Math.Clamp(GlobalSimulationConfig.AccSpikeAmplitudeMps2, (double)numSpikeAmplitude.Minimum, (double)numSpikeAmplitude.Maximum);
                    numProcessedBias.Value = (decimal)Math.Clamp(GlobalSimulationConfig.AccProcessedBias, (double)numProcessedBias.Minimum, (double)numProcessedBias.Maximum);
                    numProcessedScale.Value = (decimal)Math.Clamp(GlobalSimulationConfig.AccProcessedScalePercent, (double)numProcessedScale.Minimum, (double)numProcessedScale.Maximum);
                }
            }
            catch (Exception ex)
            {
                LogToConsole($"Profil yükleme hatası: {ex.Message}");
            }
            finally
            {
                isSyncingUI = false;
            }
        }

        private void SyncToGlobalSensorProfile()
        {
            if (isSyncingUI) return;
            try
            {
                double biasVal = chkEnableBias.Checked ? (double)numBias.Value : 0.0;
                double scaleVal = chkEnableScale.Checked ? (double)numScaleErrorPercent.Value : 0.0;
                double thermalVal = chkEnableThermal.Checked ? (double)numThermalStdDev.Value : 0.0;
                double relVal = chkEnableRelativeNoise.Checked ? (double)numRelativeNoisePercent.Value : 0.0;
                double spikeProbVal = chkEnableSpike.Checked ? (double)numSpikeProbPercent.Value : 0.0;
                double spikeAmpVal = chkEnableSpike.Checked ? (double)numSpikeAmplitude.Value : 0.0;

                double procBias = (double)numProcessedBias.Value;
                double procScale = (double)numProcessedScale.Value;

                if (cmbSensorType.SelectedIndex == 0 || cmbSensorType.SelectedItem?.ToString()?.Contains("Barometre") == true)
                {
                    GlobalSimulationConfig.BaroBiasMeter = biasVal;
                    GlobalSimulationConfig.BaroScaleErrorPercent = scaleVal;
                    GlobalSimulationConfig.BaroNoiseStdMeter = thermalVal;
                    GlobalSimulationConfig.BaroRelativeNoisePercent = relVal;
                    GlobalSimulationConfig.BaroSpikeProbPercent = spikeProbVal;
                    GlobalSimulationConfig.BaroSpikeAmplitudeMeter = spikeAmpVal;
                    GlobalSimulationConfig.BaroProcessedBias = procBias;
                    GlobalSimulationConfig.BaroProcessedScalePercent = procScale;
                }
                else
                {
                    GlobalSimulationConfig.AccBiasMps2 = biasVal;
                    GlobalSimulationConfig.AccScaleErrorPercent = scaleVal;
                    GlobalSimulationConfig.AccNoiseStdMps2 = thermalVal;
                    GlobalSimulationConfig.AccRelativeNoisePercent = relVal;
                    GlobalSimulationConfig.AccSpikeProbPercent = spikeProbVal;
                    GlobalSimulationConfig.AccSpikeAmplitudeMps2 = spikeAmpVal;
                    GlobalSimulationConfig.AccProcessedBias = procBias;
                    GlobalSimulationConfig.AccProcessedScalePercent = procScale;
                }
            }
            catch
            {
                // UI başlatılırken veya değer dönüştürülürken istisnaları yoksay
            }
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

            // Katman ve Sıralama (Z-Order) Ayarlarına Göre Çizim (ScottPlot)
            var layerItems = new List<(int Order, Action DrawAction)>();

            // 1. Ham Sensör Verisi
            if (!GlobalSimulationConfig.ChartLayers.TryGetValue("RawData", out var lRaw))
                lRaw = new ChartLayerInfo { DisplayName = "Ham Sensör Verisi", ColorHex = "#FF4500", LineWidth = 1.0f, DrawOrder = 1, Visible = true };
            if (lRaw.Visible)
            {
                layerItems.Add((lRaw.DrawOrder, () => {
                    var sRaw = plotTimeSeries.Plot.Add.Scatter(xs, raws);
                    sRaw.LegendText = $"Ham Sensör Verisi (Ort: {raws.Average():F2} m)";
                    sRaw.Color = ScottPlot.Color.FromHex(lRaw.ColorHex);
                    sRaw.LineWidth = lRaw.LineWidth;
                    sRaw.MarkerSize = lRaw.LineWidth > 0 ? 2.0f : 0f;
                }));
            }

            // 2. Kalibre Edilmiş Veri
            if (!GlobalSimulationConfig.ChartLayers.TryGetValue("CalibratedData", out var lCal))
                lCal = new ChartLayerInfo { DisplayName = "Kalibre Edilmiş Veri", ColorHex = "#32CD32", LineWidth = 1.5f, DrawOrder = 2, Visible = true };
            if (lCal.Visible)
            {
                layerItems.Add((lCal.DrawOrder, () => {
                    var sCal = plotTimeSeries.Plot.Add.Scatter(xs, cals);
                    sCal.LegendText = $"Kalibre Edilmiş Veri (Ort: {cals.Average():F2} m)";
                    sCal.Color = ScottPlot.Color.FromHex(lCal.ColorHex);
                    sCal.LineWidth = lCal.LineWidth;
                    sCal.MarkerSize = lCal.LineWidth > 0 ? 3.0f : 0f;
                }));
            }

            // 3. Gerçek Veri Referans Çizgisi
            if (!GlobalSimulationConfig.ChartLayers.TryGetValue("TrueData", out var lTrue))
                lTrue = new ChartLayerInfo { DisplayName = "Gerçek Referans Verisi", ColorHex = "#FFD700", LineWidth = 3.2f, DrawOrder = 3, Visible = true };
            if (lTrue.Visible)
            {
                layerItems.Add((lTrue.DrawOrder, () => {
                    var sTrue = plotTimeSeries.Plot.Add.Scatter(xs, trues);
                    sTrue.LegendText = $"Gerçek Referans ({trueVal:F1} m)";
                    sTrue.Color = ScottPlot.Color.FromHex(lTrue.ColorHex);
                    sTrue.LineWidth = lTrue.LineWidth;
                    sTrue.MarkerSize = 0f;
                }));
            }

            // 4. Gelişmiş Kalman Kestirimi (EstimatedData)
            if (!GlobalSimulationConfig.ChartLayers.TryGetValue("EstimatedData", out var lEst))
                lEst = new ChartLayerInfo { DisplayName = "Gelişmiş Kalman Kestirimi", ColorHex = "#00FFFF", LineWidth = 2.5f, DrawOrder = 4, Visible = true };
            if (lEst.Visible)
            {
                layerItems.Add((lEst.DrawOrder, () => {
                    // Sayfa 2 üzerindeki ham/kalibre veriye basit 1D Kalman filtresi uygulayıp çizelim
                    double[] ests = new double[n];
                    double pState = 1.0;
                    double qNoise = GlobalSimulationConfig.EstProcessNoiseQBase;
                    double rNoise = GlobalSimulationConfig.EstBaroNoiseRBase;
                    double xEst = cals.Length > 0 ? cals[0] : trueVal;
                    for (int i = 0; i < n; i++)
                    {
                        pState += qNoise;
                        double kGain = pState / (pState + rNoise);
                        xEst += kGain * (cals[i] - xEst);
                        pState *= (1.0 - kGain);
                        ests[i] = xEst;
                    }
                    var sEst = plotTimeSeries.Plot.Add.Scatter(xs, ests);
                    sEst.LegendText = $"Gelişmiş Kalman Kestirimi (Ort: {ests.Average():F2} m)";
                    sEst.Color = ScottPlot.Color.FromHex(lEst.ColorHex);
                    sEst.LineWidth = lEst.LineWidth;
                    sEst.MarkerSize = 0f;
                }));
            }

            foreach (var item in layerItems.OrderBy(x => x.Order))
            {
                item.DrawAction();
            }

            plotTimeSeries.Plot.Title("Örneklem Bazlı Zaman Serisi & Titreşim Karşılaştırması");
            plotTimeSeries.Plot.XLabel("Örneklem İndeksi / Zaman Adımı (i)");
            plotTimeSeries.Plot.YLabel("Ölçüm Büyüklüğü (Birim)");
            plotTimeSeries.Plot.ShowLegend();
            plotTimeSeries.Refresh();

            // 2. Alt Grafik: ScottPlot Çift Çan Eğrisi ve Histogram Grafiğini Çiz
            DrawDistributionGraphScottPlot(trueVal);

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

        private void DrawDistributionGraphScottPlot(double trueVal)
        {
            if (p2RawSamples == null || p2RawSamples.Count < 5) return;

            plotDistributionGraph.Plot.Clear();

            double minVal = Math.Min(trueVal, Math.Min(p2RawSamples.Min(), p2CalSamples != null && p2CalSamples.Count > 0 ? p2CalSamples.Min() : p2RawSamples.Min()));
            double maxVal = Math.Max(trueVal, Math.Max(p2RawSamples.Max(), p2CalSamples != null && p2CalSamples.Count > 0 ? p2CalSamples.Max() : p2RawSamples.Max()));

            double span = maxVal - minVal;
            if (span < 1.0) span = 10.0;
            minVal -= span * 0.15;
            maxVal += span * 0.15;
            span = maxVal - minVal;

            int numBins = trkBinCount != null && trkBinCount.Value >= 10 ? trkBinCount.Value : 36;
            double binWidth = span / numBins;
            int[] binsRaw = new int[numBins];
            int[] binsCal = new int[numBins];

            foreach (var v in p2RawSamples)
            {
                int idx = (int)((v - minVal) / binWidth);
                if (idx < 0) idx = 0;
                if (idx >= numBins) idx = numBins - 1;
                binsRaw[idx]++;
            }

            if (p2CalSamples != null && p2CalSamples.Count > 0)
            {
                foreach (var v in p2CalSamples)
                {
                    int idx = (int)((v - minVal) / binWidth);
                    if (idx < 0) idx = 0;
                    if (idx >= numBins) idx = numBins - 1;
                    binsCal[idx]++;
                }
            }

            int n = p2RawSamples.Count;

            double rawMean = p2RawSamples.Average();
            double rawStd = Math.Sqrt(p2RawSamples.Select(v => Math.Pow(v - rawMean, 2)).Sum() / n);
            if (rawStd < 1e-4) rawStd = 1.0;

            int curveSteps = 200;
            double[] curveXs = new double[curveSteps];
            double[] rawPdfYs = new double[curveSteps];
            for (int i = 0; i < curveSteps; i++)
            {
                double x = minVal + i * (span / (curveSteps - 1));
                curveXs[i] = x;
                double expRaw = -0.5 * Math.Pow((x - rawMean) / rawStd, 2);
                double pdfRaw = (1.0 / (rawStd * Math.Sqrt(2.0 * Math.PI))) * Math.Exp(expRaw);
                rawPdfYs[i] = pdfRaw * n * binWidth;
            }

            // 1. Kırmızı & Yeşil Histogram Çubukları (Birbirini örtmeyecek şekilde hafif kaydırılmış ve yarı şeffaf)
            List<ScottPlot.Bar> rawBars = new List<ScottPlot.Bar>();
            List<ScottPlot.Bar> calBars = new List<ScottPlot.Bar>();

            for (int i = 0; i < numBins; i++)
            {
                double center = minVal + (i + 0.5) * binWidth;
                if (binsRaw[i] > 0)
                {
                    rawBars.Add(new ScottPlot.Bar()
                    {
                        Position = center - binWidth * 0.18,
                        Value = binsRaw[i],
                        FillColor = ScottPlot.Colors.OrangeRed.WithAlpha(0.6),
                        Size = binWidth * 0.45
                    });
                }
                if (p2CalSamples != null && p2CalSamples.Count > 0 && binsCal[i] > 0)
                {
                    calBars.Add(new ScottPlot.Bar()
                    {
                        Position = center + binWidth * 0.18,
                        Value = binsCal[i],
                        FillColor = ScottPlot.Colors.LimeGreen.WithAlpha(0.65),
                        Size = binWidth * 0.45
                    });
                }
            }

            // Dağılım Grafiği (Olasılık Histogramı ve Çan Eğrileri) - Katman ve Renk Ayarlarına Göre Çizim
            if (!GlobalSimulationConfig.ChartLayers.TryGetValue("RawData", out var lRaw))
                lRaw = new ChartLayerInfo { DisplayName = "Ham Sensör Verisi", ColorHex = "#FF4500", LineWidth = 2.5f, DrawOrder = 1, Visible = true };
            if (!GlobalSimulationConfig.ChartLayers.TryGetValue("CalibratedData", out var lCal))
                lCal = new ChartLayerInfo { DisplayName = "Kalibre Edilmiş Veri", ColorHex = "#32CD32", LineWidth = 2.8f, DrawOrder = 2, Visible = true };
            if (!GlobalSimulationConfig.ChartLayers.TryGetValue("TrueData", out var lTrue))
                lTrue = new ChartLayerInfo { DisplayName = "Gerçek Referans Verisi", ColorHex = "#FFD700", LineWidth = 3.2f, DrawOrder = 3, Visible = true };

            var distLayers = new List<(int Order, Action DrawAction)>();

            if (lRaw.Visible)
            {
                distLayers.Add((lRaw.DrawOrder, () => {
                    if (rawBars.Count > 0)
                    {
                        var bRaw = plotDistributionGraph.Plot.Add.Bars(rawBars);
                        bRaw.LegendText = "Ham Olasılık Histogramı";
                    }
                    var sRawCurve = plotDistributionGraph.Plot.Add.Scatter(curveXs, rawPdfYs);
                    sRawCurve.Color = ScottPlot.Color.FromHex(lRaw.ColorHex);
                    sRawCurve.LineWidth = lRaw.LineWidth;
                    sRawCurve.MarkerSize = 0f;
                    sRawCurve.LegendText = $"Ham Dağılım Eğrisi (μ={rawMean:F2}, σ={rawStd:F2})";
                }));
            }

            if (lCal.Visible && p2CalSamples != null && p2CalSamples.Count > 0)
            {
                double calMean = p2CalSamples.Average();
                double calStd = Math.Sqrt(p2CalSamples.Select(v => Math.Pow(v - calMean, 2)).Sum() / p2CalSamples.Count);
                if (calStd < 1e-4) calStd = 1.0;

                double[] calPdfYs = new double[curveSteps];
                for (int i = 0; i < curveSteps; i++)
                {
                    double x = curveXs[i];
                    double expCal = -0.5 * Math.Pow((x - calMean) / calStd, 2);
                    double pdfCal = (1.0 / (calStd * Math.Sqrt(2.0 * Math.PI))) * Math.Exp(expCal);
                    calPdfYs[i] = pdfCal * p2CalSamples.Count * binWidth;
                }

                distLayers.Add((lCal.DrawOrder, () => {
                    if (calBars.Count > 0)
                    {
                        var bCal = plotDistributionGraph.Plot.Add.Bars(calBars);
                        bCal.LegendText = "Kalibre Olasılık Histogramı";
                    }
                    var sCalCurve = plotDistributionGraph.Plot.Add.Scatter(curveXs, calPdfYs);
                    sCalCurve.Color = ScottPlot.Color.FromHex(lCal.ColorHex);
                    sCalCurve.LineWidth = lCal.LineWidth;
                    sCalCurve.MarkerSize = 0f;
                    sCalCurve.LegendText = $"Kalibre Dağılım Eğrisi (μ={calMean:F2}, σ={calStd:F2})";
                }));
            }

            if (lTrue.Visible)
            {
                distLayers.Add((lTrue.DrawOrder, () => {
                    var vTrue = plotDistributionGraph.Plot.Add.VerticalLine(trueVal);
                    vTrue.Color = ScottPlot.Color.FromHex(lTrue.ColorHex);
                    vTrue.LineWidth = lTrue.LineWidth;
                    vTrue.LegendText = $"Gerçek Değer ({trueVal:F2} m)";
                }));
            }

            foreach (var item in distLayers.OrderBy(x => x.Order))
            {
                item.DrawAction();
            }

            plotDistributionGraph.Plot.Title($"Olasılık Yoğunluk ve Örneklem Histogramı (Dilim Sayısı: {numBins})");
            plotDistributionGraph.Plot.XLabel("Ölçüm Değeri / Genlik (m)");
            plotDistributionGraph.Plot.YLabel("Örneklem Frekansı (Adet) / Dağılım Yoğunluğu");
            plotDistributionGraph.Plot.ShowLegend();
            plotDistributionGraph.Refresh();
        }

        #endregion

        #region Profil Kaydetme/Yükleme & Grafik Katman Ayarları Modal

        private void BtnMasterSaveCsv_Click(object? sender, EventArgs e)
        {
            try
            {
                SyncToGlobalSensorProfile();
                int count = (int)numGenCount.Value;
                if (count <= 0) count = 500;
                double dt = 0.02; // 50 Hz

                double trueAltBase = (double)numGenTrueVal.Value;
                double trueAccBase = 15.0; // roket ivmesi örneği
                double trueTempBase = 15.0;

                using var sfd = new SaveFileDialog
                {
                    Filter = "CSV Dosyaları (*.csv)|*.csv|Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*",
                    FileName = $"Master_Flight_And_Sensor_Data_N{count}_{DateTime.Now:yyyyMMdd_HHmmss}.csv",
                    Title = "Tüm Sistem & Sensör & Kestirim Verilerini Evrensel Formatla Kaydet"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Time_s,True_Altitude_m,Raw_Baro_Altitude_m,Calibrated_Baro_Altitude_m,True_Acc_mps2,Raw_Acc_mps2,Calibrated_Acc_mps2,True_Temp_C,Raw_Temp_C,Calibrated_Temp_C,EKF_Estimated_Altitude_m,EKF_Estimated_Velocity_mps,EKF_Estimated_Acc_mps2,Confidence_General_Percent,Confidence_BaroTemp_Percent,Confidence_IMU_Percent");

                    double ekfPos = trueAltBase;
                    double ekfVel = 0.0;
                    double ekfAcc = trueAccBase;
                    double pState = 1.0;
                    Random rnd = new Random();

                    for (int i = 0; i < count; i++)
                    {
                        double t = i * dt;
                        double trueAlt = trueAltBase + (0.5 * trueAccBase * t * t * 0.01);
                        double trueAcc = trueAccBase;
                        double trueTemp = trueTempBase - (trueAlt * 0.0065);

                        // Barometre (İrtifa Eşdeğeri)
                        double rawBaro = GlobalSimulationConfig.ApplySensorForwardError(trueAlt, true, rnd, i, count);
                        double calBaro = GlobalSimulationConfig.ApplySensorReverseCalibration(rawBaro, true);

                        // İvmeölçer
                        double rawAcc = GlobalSimulationConfig.ApplySensorForwardError(trueAcc, false, rnd, i, count);
                        double calAcc = GlobalSimulationConfig.ApplySensorReverseCalibration(rawAcc, false);

                        // Sıcaklık (Hafif gürültü)
                        double rawTemp = trueTemp + (rnd.NextDouble() - 0.5) * 0.2;
                        double calTemp = rawTemp;

                        // Basit EKF adım simülasyonu
                        pState += GlobalSimulationConfig.EstProcessNoiseQBase;
                        double kGain = pState / (pState + GlobalSimulationConfig.EstBaroNoiseRBase);
                        ekfPos += kGain * (calBaro - ekfPos);
                        ekfVel = (ekfPos - trueAltBase) / (t + dt);
                        ekfAcc = calAcc;
                        pState *= (1.0 - kGain);

                        double confGen = Math.Clamp(100.0 - Math.Abs(calBaro - ekfPos) * 2.0, 0.0, 100.0);
                        double confBaro = Math.Clamp(100.0 - Math.Abs(rawBaro - calBaro) * 5.0, 0.0, 100.0);
                        double confAcc = Math.Clamp(100.0 - Math.Abs(rawAcc - calAcc) * 10.0, 0.0, 100.0);

                        sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
                            "{0:F4},{1:F4},{2:F4},{3:F4},{4:F4},{5:F4},{6:F4},{7:F4},{8:F4},{9:F4},{10:F4},{11:F4},{12:F4},{13:F1},{14:F1},{15:F1}",
                            t, trueAlt, rawBaro, calBaro, trueAcc, rawAcc, calAcc, trueTemp, rawTemp, calTemp, ekfPos, ekfVel, ekfAcc, confGen, confBaro, confAcc));
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    LogToConsole($"MASTER CSV Kaydedildi -> {Path.GetFileName(sfd.FileName)} ({count} adım, 15 sütun)");
                    MessageBox.Show($"Tüm sistem, sensör ve kestirim verileri başarıyla çok sütunlu evrensel CSV dosyasına kaydedildi!\n\nDosya: {sfd.FileName}\nSütun Sayısı: 16\nÖrneklem: {count}", "Master CSV Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Master CSV kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSaveSensorProfile_Click(object? sender, EventArgs e)
        {
            try
            {
                SyncToGlobalSensorProfile();
                bool isBaro = (cmbSensorType.SelectedIndex == 0 || cmbSensorType.SelectedItem?.ToString()?.Contains("Barometre") == true);
                using var sfd = new SaveFileDialog
                {
                    Filter = "JSON Dosyaları (*.json)|*.json",
                    FileName = isBaro ? "BaroSensorProfile.json" : "AccSensorProfile.json",
                    Title = "Sensör Profilini JSON Olarak Kaydet"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    GlobalSimulationConfig.SaveSensorProfileToFile(sfd.FileName, isBaro);
                    LogToConsole($"Sensör profili (.json) başarıyla kaydedildi: {sfd.FileName}");
                    MessageBox.Show("Sensör profili JSON dosyası olarak başarıyla kaydedildi.", "Profil Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Profil kaydedilirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLoadSensorProfile_Click(object? sender, EventArgs e)
        {
            try
            {
                bool isBaro = (cmbSensorType.SelectedIndex == 0 || cmbSensorType.SelectedItem?.ToString()?.Contains("Barometre") == true);
                using var ofd = new OpenFileDialog
                {
                    Filter = "JSON Dosyaları (*.json)|*.json",
                    Title = "Sensör Profilini JSON Dosyasından Yükle"
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (GlobalSimulationConfig.LoadSensorProfileFromFile(ofd.FileName, isBaro))
                    {
                        LoadUIFromGlobalSensorProfile();
                        LogToConsole($"Sensör profili (.json) başarıyla yüklendi ve arayüze uygulandı: {ofd.FileName}");
                        MessageBox.Show("Sensör profili JSON dosyasından başarıyla yüklendi.", "Profil Yüklendi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Profil dosyası okunamadı veya biçim geçersiz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Profil yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnP2ChartLayers_Click(object? sender, EventArgs e)
        {
            using (Form dlg = new Form())
            {
                dlg.Text = "🎨 Grafik Katman, Renk, Kalınlık ve Çizilme Sırası (Z-Order) Ayarları";
                dlg.Size = new Size(680, 420);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.BackColor = Color.FromArgb(30, 41, 59);
                dlg.ForeColor = Color.White;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;

                TableLayoutPanel table = new TableLayoutPanel();
                table.Dock = DockStyle.Top;
                table.Height = 280;
                table.ColumnCount = 5;
                table.RowCount = 4;
                table.Padding = new Padding(15);
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));

                table.Controls.Add(new Label { Text = "Katman / Veri Tipi", Font = new Font("Segoe UI Semibold", 10F), AutoSize = true }, 0, 0);
                table.Controls.Add(new Label { Text = "Görünür", Font = new Font("Segoe UI Semibold", 10F), AutoSize = true }, 1, 0);
                table.Controls.Add(new Label { Text = "Renk Seçimi", Font = new Font("Segoe UI Semibold", 10F), AutoSize = true }, 2, 0);
                table.Controls.Add(new Label { Text = "Kalınlık", Font = new Font("Segoe UI Semibold", 10F), AutoSize = true }, 3, 0);
                table.Controls.Add(new Label { Text = "Çizim Sırası", Font = new Font("Segoe UI Semibold", 10F), AutoSize = true }, 4, 0);

                string[] keys = { "RawData", "CalibratedData", "TrueData", "EstimatedData" };
                string[] names = { "Ham Sensör Verisi", "Kalibre Edilmiş Veri", "Gerçek Referans Verisi", "Gelişmiş Kalman Kestirimi" };
                string[] defaultHex = { "#FF4500", "#32CD32", "#FFD700", "#00FFFF" };
                float[] defaultWidth = { 2.5f, 2.8f, 3.2f, 2.5f };
                int[] defaultOrder = { 1, 2, 3, 4 };

                var rowControls = new List<(string Key, CheckBox chk, Button btnColor, NumericUpDown numWidth, NumericUpDown numOrder)>();

                for (int i = 0; i < keys.Length; i++)
                {
                    string key = keys[i];
                    if (!GlobalSimulationConfig.ChartLayers.TryGetValue(key, out var info))
                    {
                        info = new ChartLayerInfo { DisplayName = names[i], ColorHex = defaultHex[i], LineWidth = defaultWidth[i], DrawOrder = defaultOrder[i], Visible = true };
                        GlobalSimulationConfig.ChartLayers[key] = info;
                    }

                    Label lblName = new Label { Text = info.DisplayName, AutoSize = true, Anchor = AnchorStyles.Left };
                    CheckBox chkVis = new CheckBox { Checked = info.Visible, Anchor = AnchorStyles.Left };
                    
                    Button btnColor = new Button { Text = "🎨 Renk", BackColor = ColorTranslator.FromHtml(info.ColorHex), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Height = 32, Width = 80 };
                    btnColor.Click += (s, ev) => {
                        using (ColorDialog cd = new ColorDialog())
                        {
                            cd.Color = btnColor.BackColor;
                            if (cd.ShowDialog() == DialogResult.OK)
                            {
                                btnColor.BackColor = cd.Color;
                            }
                        }
                    };

                    NumericUpDown numWidth = new NumericUpDown { DecimalPlaces = 1, Minimum = (decimal)0.5, Maximum = (decimal)15.0, Increment = (decimal)0.5, Value = (decimal)info.LineWidth, Width = 70 };
                    NumericUpDown numOrder = new NumericUpDown { Minimum = 1, Maximum = 20, Value = info.DrawOrder, Width = 60 };

                    table.Controls.Add(lblName, 0, i + 1);
                    table.Controls.Add(chkVis, 1, i + 1);
                    table.Controls.Add(btnColor, 2, i + 1);
                    table.Controls.Add(numWidth, 3, i + 1);
                    table.Controls.Add(numOrder, 4, i + 1);

                    rowControls.Add((key, chkVis, btnColor, numWidth, numOrder));
                }

                Button btnSave = new Button { Text = "✅ Uygula ve Yenile", BackColor = Color.FromArgb(16, 185, 129), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI Semibold", 10F), Width = 180, Height = 40, Location = new Point(460, 310) };
                btnSave.Click += (s, ev) => {
                    foreach (var rc in rowControls)
                    {
                        if (GlobalSimulationConfig.ChartLayers.TryGetValue(rc.Key, out var info))
                        {
                            info.Visible = rc.chk.Checked;
                            info.ColorHex = ColorTranslator.ToHtml(rc.btnColor.BackColor);
                            info.LineWidth = (float)rc.numWidth.Value;
                            info.DrawOrder = (int)rc.numOrder.Value;
                        }
                    }
                    dlg.DialogResult = DialogResult.OK;
                    dlg.Close();
                };

                Button btnCancel = new Button { Text = "İptal", BackColor = Color.FromArgb(100, 116, 139), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Width = 100, Height = 40, Location = new Point(340, 310) };
                btnCancel.Click += (s, ev) => dlg.Close();

                dlg.Controls.Add(table);
                dlg.Controls.Add(btnSave);
                dlg.Controls.Add(btnCancel);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    BtnP2PlotAll_Click(null, EventArgs.Empty);
                    LogToConsole("Grafik katman renkleri, kalınlıkları ve çizilme sıraları güncellendi.");
                }
            }
        }

        #endregion
    }
}
