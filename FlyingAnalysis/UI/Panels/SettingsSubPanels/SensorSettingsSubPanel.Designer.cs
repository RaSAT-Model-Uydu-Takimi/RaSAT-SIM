using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    partial class SensorSettingsSubPanel
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lblPanelTitle = new Label();
            lblSensorSelect = new Label();
            cmbSensorType = new ComboBox();
            btnPage1_Settings = new Button();
            btnPage2_Chart = new Button();
            btnPage3_Estimation = new Button();
            btnMasterSaveCsv = new Button();
            pnlPage3_Estimation = new Panel();
            grpRange = new GroupBox();
            lblFullScaleInfo = new Label();
            lblRangeMax = new Label();
            numRangeMax = new NumericUpDown();
            lblRangeMin = new Label();
            numRangeMin = new NumericUpDown();
            grpErrorsAndCalculated = new GroupBox();
            grpSensorErrors = new GroupBox();
            chkEnableBias = new CheckBox();
            numBias = new NumericUpDown();
            chkEnableScale = new CheckBox();
            numScaleErrorPercent = new NumericUpDown();
            grpSensorNoise = new GroupBox();
            chkEnableThermal = new CheckBox();
            numThermalStdDev = new NumericUpDown();
            chkEnableRelativeNoise = new CheckBox();
            numRelativeNoisePercent = new NumericUpDown();
            chkEnableSpike = new CheckBox();
            numSpikeProbPercent = new NumericUpDown();
            lblSpikeAmp = new Label();
            numSpikeAmplitude = new NumericUpDown();
            grpCalculatedErrors = new GroupBox();
            lblCalcBiasTitle = new Label();
            numProcessedBias = new NumericUpDown();
            lblCalcScaleTitle = new Label();
            numProcessedScale = new NumericUpDown();
            lblResidualInfo = new Label();
            btnApplyToSim = new Button();
            grpFileAndCalibrationModules = new GroupBox();
            grpSubModuleGenerate = new GroupBox();
            lblGenCount = new Label();
            numGenCount = new NumericUpDown();
            lblGenTrueVal = new Label();
            numGenTrueVal = new NumericUpDown();
            btnGenerateAndSaveCsv = new Button();
            grpSubModuleCalibrate = new GroupBox();
            btnSelectRef1File = new Button();
            lblRef1FileName = new Label();
            btnSelectRef2File = new Button();
            lblRef2FileName = new Label();
            numCalRefTrue1 = new NumericUpDown();
            numCalRefTrue2 = new NumericUpDown();
            chkOutlierRejection = new CheckBox();
            chkAutoSaveToCalculated = new CheckBox();
            btnCalculateCalibration = new Button();
            grpSubModuleExport = new GroupBox();
            btnSelectInputFile = new Button();
            lblInputFileName = new Label();
            btnExportCalibratedCsv = new Button();
            grpConsoleLog = new GroupBox();
            txtConsoleLog = new TextBox();
            grpPage2_AnalysisAndPlots = new GroupBox();
            lblP2TrueVal = new Label();
            numP2TrueVal = new NumericUpDown();
            btnP2SelectRawFile = new Button();
            txtP2RawFilePath = new TextBox();
            btnP2ClearRawFile = new Button();
            btnP2SelectCalFile = new Button();
            txtP2CalFilePath = new TextBox();
            btnP2ClearCalFile = new Button();
            btnP2UseLastGenerated = new Button();
            btnP2PlotAll = new Button();
            lblBinCount = new Label();
            trkBinCount = new TrackBar();
            btnP2AutoCalibrate = new Button();
            plotTimeSeries = new ScottPlot.WinForms.FormsPlot();
            plotDistributionGraph = new ScottPlot.WinForms.FormsPlot();
            btnP2ViewSplit = new Button();
            btnP2ViewTimeSeries = new Button();
            btnP2ViewDistribution = new Button();
            btnP2ChartLayers = new Button();
            txtP2SummaryTable = new TextBox();
            grpRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numRangeMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRangeMin).BeginInit();
            grpErrorsAndCalculated.SuspendLayout();
            grpSensorErrors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numScaleErrorPercent).BeginInit();
            grpSensorNoise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numThermalStdDev).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRelativeNoisePercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSpikeProbPercent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSpikeAmplitude).BeginInit();
            grpCalculatedErrors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numProcessedBias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numProcessedScale).BeginInit();
            grpFileAndCalibrationModules.SuspendLayout();
            grpSubModuleGenerate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numGenCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGenTrueVal).BeginInit();
            grpSubModuleCalibrate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCalRefTrue1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCalRefTrue2).BeginInit();
            grpSubModuleExport.SuspendLayout();
            grpConsoleLog.SuspendLayout();
            grpPage2_AnalysisAndPlots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numP2TrueVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkBinCount).BeginInit();
            SuspendLayout();
            // 
            // lblPanelTitle
            // 
            lblPanelTitle.AutoSize = true;
            lblPanelTitle.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPanelTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblPanelTitle.Location = new Point(20, 15);
            lblPanelTitle.Name = "lblPanelTitle";
            lblPanelTitle.Size = new Size(588, 36);
            lblPanelTitle.TabIndex = 0;
            lblPanelTitle.Text = "SENSÖR HATA ENJEKSİYONU VE KALİBRASYONU";
            // 
            // lblSensorSelect
            // 
            lblSensorSelect.AutoSize = true;
            lblSensorSelect.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSensorSelect.ForeColor = Color.FromArgb(51, 65, 85);
            lblSensorSelect.Location = new Point(640, 20);
            lblSensorSelect.Name = "lblSensorSelect";
            lblSensorSelect.Size = new Size(142, 28);
            lblSensorSelect.TabIndex = 1;
            lblSensorSelect.Text = "Hedef Sensör:";
            // 
            // cmbSensorType
            // 
            cmbSensorType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSensorType.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSensorType.FormattingEnabled = true;
            cmbSensorType.Items.AddRange(new object[] { "Barometre (İrtifa Eşdeğeri [m])", "Sıcaklık Sensörü (°C)", "İvmeölçer / IMU (m/s²)" });
            cmbSensorType.Location = new Point(790, 17);
            cmbSensorType.Name = "cmbSensorType";
            cmbSensorType.Size = new Size(260, 36);
            cmbSensorType.TabIndex = 2;
            // 
            // btnPage1_Settings
            // 
            btnPage1_Settings.BackColor = Color.FromArgb(15, 118, 110);
            btnPage1_Settings.FlatAppearance.BorderSize = 0;
            btnPage1_Settings.FlatStyle = FlatStyle.Flat;
            btnPage1_Settings.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPage1_Settings.ForeColor = Color.White;
            btnPage1_Settings.Location = new Point(25, 60);
            btnPage1_Settings.Name = "btnPage1_Settings";
            btnPage1_Settings.Size = new Size(560, 44);
            btnPage1_Settings.TabIndex = 3;
            btnPage1_Settings.Text = "Sayfa 1: Hata Enjeksiyonu, Kalibrasyon & Dosya Modülleri";
            btnPage1_Settings.UseVisualStyleBackColor = false;
            // 
            // btnPage2_Chart
            // 
            btnPage2_Chart.BackColor = Color.FromArgb(51, 65, 85);
            btnPage2_Chart.FlatAppearance.BorderSize = 0;
            btnPage2_Chart.FlatStyle = FlatStyle.Flat;
            btnPage2_Chart.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPage2_Chart.ForeColor = Color.White;
            btnPage2_Chart.Location = new Point(605, 60);
            btnPage2_Chart.Name = "btnPage2_Chart";
            btnPage2_Chart.Size = new Size(380, 44);
            btnPage2_Chart.TabIndex = 4;
            btnPage2_Chart.Text = "Sayfa 2: Zaman Serisi & Dağılım Analizi";
            btnPage2_Chart.UseVisualStyleBackColor = false;
            // 
            // btnPage3_Estimation
            // 
            btnPage3_Estimation.BackColor = Color.FromArgb(51, 65, 85);
            btnPage3_Estimation.FlatAppearance.BorderSize = 0;
            btnPage3_Estimation.FlatStyle = FlatStyle.Flat;
            btnPage3_Estimation.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPage3_Estimation.ForeColor = Color.White;
            btnPage3_Estimation.Location = new Point(1005, 60);
            btnPage3_Estimation.Name = "btnPage3_Estimation";
            btnPage3_Estimation.Size = new Size(310, 44);
            btnPage3_Estimation.TabIndex = 5;
            btnPage3_Estimation.Text = "Sayfa 3: Kestirim Çekirdeği (EKF)";
            btnPage3_Estimation.UseVisualStyleBackColor = false;
            // 
            // btnMasterSaveCsv
            // 
            btnMasterSaveCsv.BackColor = Color.FromArgb(22, 163, 74);
            btnMasterSaveCsv.FlatAppearance.BorderSize = 0;
            btnMasterSaveCsv.FlatStyle = FlatStyle.Flat;
            btnMasterSaveCsv.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMasterSaveCsv.ForeColor = Color.White;
            btnMasterSaveCsv.Location = new Point(380, 15);
            btnMasterSaveCsv.Name = "btnMasterSaveCsv";
            btnMasterSaveCsv.Size = new Size(280, 38);
            btnMasterSaveCsv.TabIndex = 10;
            btnMasterSaveCsv.Text = "💾 TÜM SİSTEMİ & AYARLARI KAYDET";
            btnMasterSaveCsv.UseVisualStyleBackColor = false;
            // 
            // pnlPage3_Estimation
            // 
            pnlPage3_Estimation.BackColor = Color.FromArgb(15, 23, 42);
            pnlPage3_Estimation.Location = new Point(25, 120);
            pnlPage3_Estimation.Name = "pnlPage3_Estimation";
            pnlPage3_Estimation.Size = new Size(1340, 750);
            pnlPage3_Estimation.TabIndex = 0;
            pnlPage3_Estimation.Visible = false;
            // 
            // grpRange
            // 
            grpRange.Controls.Add(lblFullScaleInfo);
            grpRange.Controls.Add(lblRangeMax);
            grpRange.Controls.Add(numRangeMax);
            grpRange.Controls.Add(lblRangeMin);
            grpRange.Controls.Add(numRangeMin);
            grpRange.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpRange.Location = new Point(25, 115);
            grpRange.Name = "grpRange";
            grpRange.Size = new Size(1140, 85);
            grpRange.TabIndex = 5;
            grpRange.TabStop = false;
            grpRange.Text = "1. Sensör Çalışma Aralığı & Referans (Tam Skala FS Span)";
            // 
            // lblFullScaleInfo
            // 
            lblFullScaleInfo.AutoSize = true;
            lblFullScaleInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFullScaleInfo.ForeColor = Color.FromArgb(37, 99, 235);
            lblFullScaleInfo.Location = new Point(780, 36);
            lblFullScaleInfo.Name = "lblFullScaleInfo";
            lblFullScaleInfo.Size = new Size(351, 25);
            lblFullScaleInfo.TabIndex = 4;
            lblFullScaleInfo.Text = "Tam Skala Açıklığı (FS Span): 5000.0 birim";
            // 
            // lblRangeMax
            // 
            lblRangeMax.AutoSize = true;
            lblRangeMax.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRangeMax.Location = new Point(400, 36);
            lblRangeMax.Name = "lblRangeMax";
            lblRangeMax.Size = new Size(221, 25);
            lblRangeMax.TabIndex = 2;
            lblRangeMax.Text = "Maksimum Ölçüm [Max]:";
            // 
            // numRangeMax
            // 
            numRangeMax.DecimalPlaces = 1;
            numRangeMax.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numRangeMax.Location = new Point(615, 34);
            numRangeMax.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numRangeMax.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numRangeMax.Name = "numRangeMax";
            numRangeMax.Size = new Size(140, 34);
            numRangeMax.TabIndex = 3;
            numRangeMax.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // lblRangeMin
            // 
            lblRangeMin.AutoSize = true;
            lblRangeMin.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRangeMin.Location = new Point(20, 36);
            lblRangeMin.Name = "lblRangeMin";
            lblRangeMin.Size = new Size(207, 25);
            lblRangeMin.TabIndex = 0;
            lblRangeMin.Text = "Minimum Ölçüm [Min]:";
            // 
            // numRangeMin
            // 
            numRangeMin.DecimalPlaces = 1;
            numRangeMin.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numRangeMin.Location = new Point(230, 34);
            numRangeMin.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numRangeMin.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numRangeMin.Name = "numRangeMin";
            numRangeMin.Size = new Size(140, 34);
            numRangeMin.TabIndex = 1;
            // 
            // grpErrorsAndCalculated
            // 
            grpErrorsAndCalculated.Controls.Add(grpSensorErrors);
            grpErrorsAndCalculated.Controls.Add(grpSensorNoise);
            grpErrorsAndCalculated.Controls.Add(grpCalculatedErrors);
            grpErrorsAndCalculated.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpErrorsAndCalculated.Location = new Point(25, 205);
            grpErrorsAndCalculated.Name = "grpErrorsAndCalculated";
            grpErrorsAndCalculated.Size = new Size(1140, 255);
            grpErrorsAndCalculated.TabIndex = 6;
            grpErrorsAndCalculated.TabStop = false;
            grpErrorsAndCalculated.Text = "2. Sensör Hataları, Gürültüleri ve Hesaplanan Hatalar (Yan Yana 3 Alan)";
            // 
            // grpSensorErrors
            // 
            grpSensorErrors.Controls.Add(chkEnableBias);
            grpSensorErrors.Controls.Add(numBias);
            grpSensorErrors.Controls.Add(chkEnableScale);
            grpSensorErrors.Controls.Add(numScaleErrorPercent);
            grpSensorErrors.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSensorErrors.ForeColor = Color.FromArgb(185, 28, 28);
            grpSensorErrors.Location = new Point(15, 30);
            grpSensorErrors.Name = "grpSensorErrors";
            grpSensorErrors.Size = new Size(360, 215);
            grpSensorErrors.TabIndex = 0;
            grpSensorErrors.TabStop = false;
            grpSensorErrors.Text = "[ Sensör Hatası (Sistematik) ]";
            // 
            // chkEnableBias
            // 
            chkEnableBias.AutoSize = true;
            chkEnableBias.Checked = true;
            chkEnableBias.CheckState = CheckState.Checked;
            chkEnableBias.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkEnableBias.ForeColor = Color.FromArgb(15, 23, 42);
            chkEnableBias.Location = new Point(15, 45);
            chkEnableBias.Name = "chkEnableBias";
            chkEnableBias.Size = new Size(167, 29);
            chkEnableBias.TabIndex = 0;
            chkEnableBias.Text = "Mutlak Bias (b):";
            chkEnableBias.UseVisualStyleBackColor = true;
            // 
            // numBias
            // 
            numBias.DecimalPlaces = 2;
            numBias.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numBias.Location = new Point(230, 42);
            numBias.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numBias.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numBias.Name = "numBias";
            numBias.Size = new Size(115, 34);
            numBias.TabIndex = 1;
            numBias.Value = new decimal(new int[] { 150, 0, 0, 131072 });
            // 
            // chkEnableScale
            // 
            chkEnableScale.AutoSize = true;
            chkEnableScale.Checked = true;
            chkEnableScale.CheckState = CheckState.Checked;
            chkEnableScale.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkEnableScale.ForeColor = Color.FromArgb(15, 23, 42);
            chkEnableScale.Location = new Point(15, 105);
            chkEnableScale.Name = "chkEnableScale";
            chkEnableScale.Size = new Size(181, 29);
            chkEnableScale.TabIndex = 2;
            chkEnableScale.Text = "Bağıl Scale (S %):";
            chkEnableScale.UseVisualStyleBackColor = true;
            // 
            // numScaleErrorPercent
            // 
            numScaleErrorPercent.DecimalPlaces = 2;
            numScaleErrorPercent.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numScaleErrorPercent.Location = new Point(230, 102);
            numScaleErrorPercent.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numScaleErrorPercent.Name = "numScaleErrorPercent";
            numScaleErrorPercent.Size = new Size(115, 34);
            numScaleErrorPercent.TabIndex = 3;
            numScaleErrorPercent.Value = new decimal(new int[] { 200, 0, 0, 131072 });
            // 
            // grpSensorNoise
            // 
            grpSensorNoise.Controls.Add(chkEnableThermal);
            grpSensorNoise.Controls.Add(numThermalStdDev);
            grpSensorNoise.Controls.Add(chkEnableRelativeNoise);
            grpSensorNoise.Controls.Add(numRelativeNoisePercent);
            grpSensorNoise.Controls.Add(chkEnableSpike);
            grpSensorNoise.Controls.Add(numSpikeProbPercent);
            grpSensorNoise.Controls.Add(lblSpikeAmp);
            grpSensorNoise.Controls.Add(numSpikeAmplitude);
            grpSensorNoise.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSensorNoise.ForeColor = Color.FromArgb(180, 83, 9);
            grpSensorNoise.Location = new Point(390, 30);
            grpSensorNoise.Name = "grpSensorNoise";
            grpSensorNoise.Size = new Size(360, 215);
            grpSensorNoise.TabIndex = 1;
            grpSensorNoise.TabStop = false;
            grpSensorNoise.Text = "[ Sensör Gürültüsü (Stokastik) ]";
            // 
            // chkEnableThermal
            // 
            chkEnableThermal.AutoSize = true;
            chkEnableThermal.Checked = true;
            chkEnableThermal.CheckState = CheckState.Checked;
            chkEnableThermal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkEnableThermal.ForeColor = Color.FromArgb(15, 23, 42);
            chkEnableThermal.Location = new Point(12, 32);
            chkEnableThermal.Name = "chkEnableThermal";
            chkEnableThermal.Size = new Size(198, 29);
            chkEnableThermal.TabIndex = 0;
            chkEnableThermal.Text = "Sabit Termal σ_sabit:";
            chkEnableThermal.UseVisualStyleBackColor = true;
            // 
            // numThermalStdDev
            // 
            numThermalStdDev.DecimalPlaces = 2;
            numThermalStdDev.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numThermalStdDev.Location = new Point(235, 29);
            numThermalStdDev.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numThermalStdDev.Name = "numThermalStdDev";
            numThermalStdDev.Size = new Size(110, 33);
            numThermalStdDev.TabIndex = 1;
            numThermalStdDev.Value = new decimal(new int[] { 50, 0, 0, 131072 });
            // 
            // chkEnableRelativeNoise
            // 
            chkEnableRelativeNoise.AutoSize = true;
            chkEnableRelativeNoise.Checked = true;
            chkEnableRelativeNoise.CheckState = CheckState.Checked;
            chkEnableRelativeNoise.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkEnableRelativeNoise.ForeColor = Color.FromArgb(15, 23, 42);
            chkEnableRelativeNoise.Location = new Point(12, 68);
            chkEnableRelativeNoise.Name = "chkEnableRelativeNoise";
            chkEnableRelativeNoise.Size = new Size(180, 29);
            chkEnableRelativeNoise.TabIndex = 2;
            chkEnableRelativeNoise.Text = "Bağıl Termal % FS:";
            chkEnableRelativeNoise.UseVisualStyleBackColor = true;
            // 
            // numRelativeNoisePercent
            // 
            numRelativeNoisePercent.DecimalPlaces = 2;
            numRelativeNoisePercent.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numRelativeNoisePercent.Location = new Point(235, 65);
            numRelativeNoisePercent.Name = "numRelativeNoisePercent";
            numRelativeNoisePercent.Size = new Size(110, 33);
            numRelativeNoisePercent.TabIndex = 3;
            numRelativeNoisePercent.Value = new decimal(new int[] { 150, 0, 0, 131072 });
            // 
            // chkEnableSpike
            // 
            chkEnableSpike.AutoSize = true;
            chkEnableSpike.Checked = true;
            chkEnableSpike.CheckState = CheckState.Checked;
            chkEnableSpike.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkEnableSpike.ForeColor = Color.FromArgb(15, 23, 42);
            chkEnableSpike.Location = new Point(12, 104);
            chkEnableSpike.Name = "chkEnableSpike";
            chkEnableSpike.Size = new Size(187, 29);
            chkEnableSpike.TabIndex = 4;
            chkEnableSpike.Text = "Darbe Olasılığı (%):";
            chkEnableSpike.UseVisualStyleBackColor = true;
            // 
            // numSpikeProbPercent
            // 
            numSpikeProbPercent.DecimalPlaces = 2;
            numSpikeProbPercent.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numSpikeProbPercent.Location = new Point(235, 101);
            numSpikeProbPercent.Name = "numSpikeProbPercent";
            numSpikeProbPercent.Size = new Size(110, 33);
            numSpikeProbPercent.TabIndex = 5;
            numSpikeProbPercent.Value = new decimal(new int[] { 100, 0, 0, 131072 });
            // 
            // lblSpikeAmp
            // 
            lblSpikeAmp.AutoSize = true;
            lblSpikeAmp.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSpikeAmp.ForeColor = Color.FromArgb(15, 23, 42);
            lblSpikeAmp.Location = new Point(30, 140);
            lblSpikeAmp.Name = "lblSpikeAmp";
            lblSpikeAmp.Size = new Size(186, 25);
            lblSpikeAmp.TabIndex = 6;
            lblSpikeAmp.Text = "Darbe Çarpanı (K × σ):";
            // 
            // numSpikeAmplitude
            // 
            numSpikeAmplitude.DecimalPlaces = 1;
            numSpikeAmplitude.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numSpikeAmplitude.Location = new Point(235, 137);
            numSpikeAmplitude.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numSpikeAmplitude.Name = "numSpikeAmplitude";
            numSpikeAmplitude.Size = new Size(110, 33);
            numSpikeAmplitude.TabIndex = 7;
            numSpikeAmplitude.Value = new decimal(new int[] { 150, 0, 0, 65536 });
            // 
            // grpCalculatedErrors
            // 
            grpCalculatedErrors.Controls.Add(lblCalcBiasTitle);
            grpCalculatedErrors.Controls.Add(numProcessedBias);
            grpCalculatedErrors.Controls.Add(lblCalcScaleTitle);
            grpCalculatedErrors.Controls.Add(numProcessedScale);
            grpCalculatedErrors.Controls.Add(lblResidualInfo);
            grpCalculatedErrors.Controls.Add(btnApplyToSim);
            grpCalculatedErrors.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpCalculatedErrors.ForeColor = Color.FromArgb(16, 185, 129);
            grpCalculatedErrors.Location = new Point(765, 30);
            grpCalculatedErrors.Name = "grpCalculatedErrors";
            grpCalculatedErrors.Size = new Size(360, 215);
            grpCalculatedErrors.TabIndex = 2;
            grpCalculatedErrors.TabStop = false;
            grpCalculatedErrors.Text = "[ Hesaplanan Hatalar (Aktif) ]";
            // 
            // lblCalcBiasTitle
            // 
            lblCalcBiasTitle.AutoSize = true;
            lblCalcBiasTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCalcBiasTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblCalcBiasTitle.Location = new Point(15, 43);
            lblCalcBiasTitle.Name = "lblCalcBiasTitle";
            lblCalcBiasTitle.Size = new Size(170, 25);
            lblCalcBiasTitle.TabIndex = 0;
            lblCalcBiasTitle.Text = "Hesaplanan Bias (b):";
            // 
            // numProcessedBias
            // 
            numProcessedBias.DecimalPlaces = 4;
            numProcessedBias.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            numProcessedBias.ForeColor = Color.FromArgb(15, 23, 42);
            numProcessedBias.Location = new Point(220, 40);
            numProcessedBias.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numProcessedBias.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            numProcessedBias.Name = "numProcessedBias";
            numProcessedBias.Size = new Size(125, 33);
            numProcessedBias.TabIndex = 1;
            // 
            // lblCalcScaleTitle
            // 
            lblCalcScaleTitle.AutoSize = true;
            lblCalcScaleTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCalcScaleTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblCalcScaleTitle.Location = new Point(15, 87);
            lblCalcScaleTitle.Name = "lblCalcScaleTitle";
            lblCalcScaleTitle.Size = new Size(198, 25);
            lblCalcScaleTitle.TabIndex = 2;
            lblCalcScaleTitle.Text = "Hesaplanan Scale (S %):";
            // 
            // numProcessedScale
            // 
            numProcessedScale.DecimalPlaces = 4;
            numProcessedScale.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            numProcessedScale.ForeColor = Color.FromArgb(15, 23, 42);
            numProcessedScale.Location = new Point(220, 84);
            numProcessedScale.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numProcessedScale.Name = "numProcessedScale";
            numProcessedScale.Size = new Size(125, 33);
            numProcessedScale.TabIndex = 3;
            // 
            // lblResidualInfo
            // 
            lblResidualInfo.AutoSize = true;
            lblResidualInfo.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResidualInfo.ForeColor = Color.FromArgb(100, 116, 139);
            lblResidualInfo.Location = new Point(15, 126);
            lblResidualInfo.Name = "lblResidualInfo";
            lblResidualInfo.Size = new Size(303, 23);
            lblResidualInfo.TabIndex = 4;
            lblResidualInfo.Text = "Fark (Rezidüel): b=0.0000 | S=%0.0000";
            // 
            // btnApplyToSim
            // 
            btnApplyToSim.BackColor = Color.FromArgb(124, 58, 237);
            btnApplyToSim.FlatAppearance.BorderSize = 0;
            btnApplyToSim.FlatStyle = FlatStyle.Flat;
            btnApplyToSim.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnApplyToSim.ForeColor = Color.White;
            btnApplyToSim.Location = new Point(15, 160);
            btnApplyToSim.Name = "btnApplyToSim";
            btnApplyToSim.Size = new Size(330, 40);
            btnApplyToSim.TabIndex = 5;
            btnApplyToSim.Text = "Hesaplananları Aktif Et / Uygula";
            btnApplyToSim.UseVisualStyleBackColor = false;
            // 
            // grpFileAndCalibrationModules
            // 
            grpFileAndCalibrationModules.Controls.Add(grpSubModuleGenerate);
            grpFileAndCalibrationModules.Controls.Add(grpSubModuleCalibrate);
            grpFileAndCalibrationModules.Controls.Add(grpSubModuleExport);
            grpFileAndCalibrationModules.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpFileAndCalibrationModules.Location = new Point(25, 465);
            grpFileAndCalibrationModules.Name = "grpFileAndCalibrationModules";
            grpFileAndCalibrationModules.Size = new Size(1140, 240);
            grpFileAndCalibrationModules.TabIndex = 7;
            grpFileAndCalibrationModules.TabStop = false;
            grpFileAndCalibrationModules.Text = "3. Veri Üretme, Kalibrasyon ve Dosya Dönüşüm Modülleri (3 Alt İşlem Modülü)";
            // 
            // grpSubModuleGenerate
            // 
            grpSubModuleGenerate.Controls.Add(lblGenCount);
            grpSubModuleGenerate.Controls.Add(numGenCount);
            grpSubModuleGenerate.Controls.Add(lblGenTrueVal);
            grpSubModuleGenerate.Controls.Add(numGenTrueVal);
            grpSubModuleGenerate.Controls.Add(btnGenerateAndSaveCsv);
            grpSubModuleGenerate.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSubModuleGenerate.ForeColor = Color.FromArgb(15, 118, 110);
            grpSubModuleGenerate.Location = new Point(15, 30);
            grpSubModuleGenerate.Name = "grpSubModuleGenerate";
            grpSubModuleGenerate.Size = new Size(360, 195);
            grpSubModuleGenerate.TabIndex = 0;
            grpSubModuleGenerate.TabStop = false;
            grpSubModuleGenerate.Text = "[ 3.1. Sensör Verisi Üret ]";
            // 
            // lblGenCount
            // 
            lblGenCount.AutoSize = true;
            lblGenCount.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGenCount.ForeColor = Color.FromArgb(15, 23, 42);
            lblGenCount.Location = new Point(15, 40);
            lblGenCount.Name = "lblGenCount";
            lblGenCount.Size = new Size(153, 25);
            lblGenCount.TabIndex = 0;
            lblGenCount.Text = "Üretilecek Adet N:";
            // 
            // numGenCount
            // 
            numGenCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numGenCount.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numGenCount.Location = new Point(220, 37);
            numGenCount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numGenCount.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numGenCount.Name = "numGenCount";
            numGenCount.Size = new Size(125, 33);
            numGenCount.TabIndex = 1;
            numGenCount.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // lblGenTrueVal
            // 
            lblGenTrueVal.AutoSize = true;
            lblGenTrueVal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGenTrueVal.ForeColor = Color.FromArgb(15, 23, 42);
            lblGenTrueVal.Location = new Point(15, 85);
            lblGenTrueVal.Name = "lblGenTrueVal";
            lblGenTrueVal.Size = new Size(188, 25);
            lblGenTrueVal.TabIndex = 2;
            lblGenTrueVal.Text = "Gerçek Veri (X_gerçek):";
            // 
            // numGenTrueVal
            // 
            numGenTrueVal.DecimalPlaces = 1;
            numGenTrueVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numGenTrueVal.Location = new Point(220, 82);
            numGenTrueVal.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numGenTrueVal.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numGenTrueVal.Name = "numGenTrueVal";
            numGenTrueVal.Size = new Size(125, 33);
            numGenTrueVal.TabIndex = 3;
            numGenTrueVal.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // btnGenerateAndSaveCsv
            // 
            btnGenerateAndSaveCsv.BackColor = Color.FromArgb(15, 118, 110);
            btnGenerateAndSaveCsv.FlatAppearance.BorderSize = 0;
            btnGenerateAndSaveCsv.FlatStyle = FlatStyle.Flat;
            btnGenerateAndSaveCsv.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateAndSaveCsv.ForeColor = Color.White;
            btnGenerateAndSaveCsv.Location = new Point(15, 135);
            btnGenerateAndSaveCsv.Name = "btnGenerateAndSaveCsv";
            btnGenerateAndSaveCsv.Size = new Size(330, 42);
            btnGenerateAndSaveCsv.TabIndex = 4;
            btnGenerateAndSaveCsv.Text = "Sensör Verisi Üret (CSV Kaydet)";
            btnGenerateAndSaveCsv.UseVisualStyleBackColor = false;
            // 
            // grpSubModuleCalibrate
            // 
            grpSubModuleCalibrate.Controls.Add(btnSelectRef1File);
            grpSubModuleCalibrate.Controls.Add(lblRef1FileName);
            grpSubModuleCalibrate.Controls.Add(btnSelectRef2File);
            grpSubModuleCalibrate.Controls.Add(lblRef2FileName);
            grpSubModuleCalibrate.Controls.Add(numCalRefTrue1);
            grpSubModuleCalibrate.Controls.Add(numCalRefTrue2);
            grpSubModuleCalibrate.Controls.Add(chkOutlierRejection);
            grpSubModuleCalibrate.Controls.Add(chkAutoSaveToCalculated);
            grpSubModuleCalibrate.Controls.Add(btnCalculateCalibration);
            grpSubModuleCalibrate.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSubModuleCalibrate.ForeColor = Color.FromArgb(37, 99, 235);
            grpSubModuleCalibrate.Location = new Point(390, 30);
            grpSubModuleCalibrate.Name = "grpSubModuleCalibrate";
            grpSubModuleCalibrate.Size = new Size(360, 195);
            grpSubModuleCalibrate.TabIndex = 1;
            grpSubModuleCalibrate.TabStop = false;
            grpSubModuleCalibrate.Text = "[ 3.2. Kalibrasyon Hesapla ]";
            // 
            // btnSelectRef1File
            // 
            btnSelectRef1File.BackColor = Color.FromArgb(226, 232, 240);
            btnSelectRef1File.FlatAppearance.BorderSize = 0;
            btnSelectRef1File.FlatStyle = FlatStyle.Flat;
            btnSelectRef1File.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnSelectRef1File.ForeColor = Color.FromArgb(30, 41, 59);
            btnSelectRef1File.Location = new Point(10, 30);
            btnSelectRef1File.Name = "btnSelectRef1File";
            btnSelectRef1File.Size = new Size(95, 30);
            btnSelectRef1File.TabIndex = 0;
            btnSelectRef1File.Text = "Ref 1 Seç";
            btnSelectRef1File.UseVisualStyleBackColor = false;
            // 
            // lblRef1FileName
            // 
            lblRef1FileName.AutoSize = true;
            lblRef1FileName.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblRef1FileName.ForeColor = Color.FromArgb(71, 85, 105);
            lblRef1FileName.Location = new Point(200, 35);
            lblRef1FileName.Name = "lblRef1FileName";
            lblRef1FileName.Size = new Size(111, 21);
            lblRef1FileName.TabIndex = 1;
            lblRef1FileName.Text = "Dosya (Ref 1)...";
            // 
            // btnSelectRef2File
            // 
            btnSelectRef2File.BackColor = Color.FromArgb(226, 232, 240);
            btnSelectRef2File.FlatAppearance.BorderSize = 0;
            btnSelectRef2File.FlatStyle = FlatStyle.Flat;
            btnSelectRef2File.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnSelectRef2File.ForeColor = Color.FromArgb(30, 41, 59);
            btnSelectRef2File.Location = new Point(10, 65);
            btnSelectRef2File.Name = "btnSelectRef2File";
            btnSelectRef2File.Size = new Size(95, 30);
            btnSelectRef2File.TabIndex = 2;
            btnSelectRef2File.Text = "Ref 2 Seç";
            btnSelectRef2File.UseVisualStyleBackColor = false;
            // 
            // lblRef2FileName
            // 
            lblRef2FileName.AutoSize = true;
            lblRef2FileName.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblRef2FileName.ForeColor = Color.FromArgb(71, 85, 105);
            lblRef2FileName.Location = new Point(200, 70);
            lblRef2FileName.Name = "lblRef2FileName";
            lblRef2FileName.Size = new Size(111, 21);
            lblRef2FileName.TabIndex = 3;
            lblRef2FileName.Text = "Dosya (Ref 2)...";
            // 
            // numCalRefTrue1
            // 
            numCalRefTrue1.DecimalPlaces = 1;
            numCalRefTrue1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numCalRefTrue1.Location = new Point(110, 30);
            numCalRefTrue1.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numCalRefTrue1.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numCalRefTrue1.Name = "numCalRefTrue1";
            numCalRefTrue1.Size = new Size(85, 31);
            numCalRefTrue1.TabIndex = 10;
            numCalRefTrue1.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // numCalRefTrue2
            // 
            numCalRefTrue2.DecimalPlaces = 1;
            numCalRefTrue2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numCalRefTrue2.Location = new Point(110, 65);
            numCalRefTrue2.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numCalRefTrue2.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numCalRefTrue2.Name = "numCalRefTrue2";
            numCalRefTrue2.Size = new Size(85, 31);
            numCalRefTrue2.TabIndex = 11;
            numCalRefTrue2.Value = new decimal(new int[] { 4000, 0, 0, 0 });
            // 
            // chkOutlierRejection
            // 
            chkOutlierRejection.AutoSize = true;
            chkOutlierRejection.Checked = true;
            chkOutlierRejection.CheckState = CheckState.Checked;
            chkOutlierRejection.Font = new Font("Segoe UI", 8F);
            chkOutlierRejection.ForeColor = Color.FromArgb(15, 23, 42);
            chkOutlierRejection.Location = new Point(12, 102);
            chkOutlierRejection.Name = "chkOutlierRejection";
            chkOutlierRejection.Size = new Size(304, 25);
            chkOutlierRejection.TabIndex = 4;
            chkOutlierRejection.Text = "Aykırı Değerleri Kırp (%5 Medyan/IQR)";
            chkOutlierRejection.UseVisualStyleBackColor = true;
            // 
            // chkAutoSaveToCalculated
            // 
            chkAutoSaveToCalculated.AutoSize = true;
            chkAutoSaveToCalculated.Checked = true;
            chkAutoSaveToCalculated.CheckState = CheckState.Checked;
            chkAutoSaveToCalculated.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            chkAutoSaveToCalculated.ForeColor = Color.FromArgb(16, 185, 129);
            chkAutoSaveToCalculated.Location = new Point(12, 126);
            chkAutoSaveToCalculated.Name = "chkAutoSaveToCalculated";
            chkAutoSaveToCalculated.Size = new Size(328, 25);
            chkAutoSaveToCalculated.TabIndex = 5;
            chkAutoSaveToCalculated.Text = "Sonuçları Hesaplanan Hatalara Kaydet";
            chkAutoSaveToCalculated.UseVisualStyleBackColor = true;
            // 
            // btnCalculateCalibration
            // 
            btnCalculateCalibration.BackColor = Color.FromArgb(37, 99, 235);
            btnCalculateCalibration.FlatAppearance.BorderSize = 0;
            btnCalculateCalibration.FlatStyle = FlatStyle.Flat;
            btnCalculateCalibration.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalculateCalibration.ForeColor = Color.White;
            btnCalculateCalibration.Location = new Point(12, 153);
            btnCalculateCalibration.Name = "btnCalculateCalibration";
            btnCalculateCalibration.Size = new Size(335, 34);
            btnCalculateCalibration.TabIndex = 6;
            btnCalculateCalibration.Text = "Kalibrasyonu Hesapla (Ref 1 & Ref 2)";
            btnCalculateCalibration.UseVisualStyleBackColor = false;
            // 
            // grpSubModuleExport
            // 
            grpSubModuleExport.Controls.Add(btnSelectInputFile);
            grpSubModuleExport.Controls.Add(lblInputFileName);
            grpSubModuleExport.Controls.Add(btnExportCalibratedCsv);
            grpSubModuleExport.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpSubModuleExport.ForeColor = Color.FromArgb(124, 58, 237);
            grpSubModuleExport.Location = new Point(765, 30);
            grpSubModuleExport.Name = "grpSubModuleExport";
            grpSubModuleExport.Size = new Size(360, 195);
            grpSubModuleExport.TabIndex = 2;
            grpSubModuleExport.TabStop = false;
            grpSubModuleExport.Text = "[ 3.3. Kalibre Edilmiş Çıktı Üret ]";
            // 
            // btnSelectInputFile
            // 
            btnSelectInputFile.BackColor = Color.FromArgb(226, 232, 240);
            btnSelectInputFile.FlatAppearance.BorderSize = 0;
            btnSelectInputFile.FlatStyle = FlatStyle.Flat;
            btnSelectInputFile.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnSelectInputFile.ForeColor = Color.FromArgb(30, 41, 59);
            btnSelectInputFile.Location = new Point(15, 45);
            btnSelectInputFile.Name = "btnSelectInputFile";
            btnSelectInputFile.Size = new Size(130, 36);
            btnSelectInputFile.TabIndex = 0;
            btnSelectInputFile.Text = "Girdi Dosya Seç";
            btnSelectInputFile.UseVisualStyleBackColor = false;
            // 
            // lblInputFileName
            // 
            lblInputFileName.AutoSize = true;
            lblInputFileName.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblInputFileName.ForeColor = Color.FromArgb(71, 85, 105);
            lblInputFileName.Location = new Point(155, 52);
            lblInputFileName.Name = "lblInputFileName";
            lblInputFileName.Size = new Size(175, 23);
            lblInputFileName.TabIndex = 1;
            lblInputFileName.Text = "Girdi dosya seçilmedi...";
            // 
            // btnExportCalibratedCsv
            // 
            btnExportCalibratedCsv.BackColor = Color.FromArgb(124, 58, 237);
            btnExportCalibratedCsv.FlatAppearance.BorderSize = 0;
            btnExportCalibratedCsv.FlatStyle = FlatStyle.Flat;
            btnExportCalibratedCsv.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportCalibratedCsv.ForeColor = Color.White;
            btnExportCalibratedCsv.Location = new Point(15, 135);
            btnExportCalibratedCsv.Name = "btnExportCalibratedCsv";
            btnExportCalibratedCsv.Size = new Size(330, 42);
            btnExportCalibratedCsv.TabIndex = 2;
            btnExportCalibratedCsv.Text = "Kalibre Edilmiş Dosyayı Çıkar (Save)";
            btnExportCalibratedCsv.UseVisualStyleBackColor = false;
            // 
            // grpConsoleLog
            // 
            grpConsoleLog.Controls.Add(txtConsoleLog);
            grpConsoleLog.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpConsoleLog.Location = new Point(25, 715);
            grpConsoleLog.Name = "grpConsoleLog";
            grpConsoleLog.Size = new Size(1140, 135);
            grpConsoleLog.TabIndex = 8;
            grpConsoleLog.TabStop = false;
            grpConsoleLog.Text = "4. İşlem ve Kalibrasyon Konsol Bilgi Ekranı";
            // 
            // txtConsoleLog
            // 
            txtConsoleLog.BackColor = Color.FromArgb(15, 23, 42);
            txtConsoleLog.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConsoleLog.ForeColor = Color.FromArgb(226, 232, 240);
            txtConsoleLog.Location = new Point(15, 30);
            txtConsoleLog.Multiline = true;
            txtConsoleLog.Name = "txtConsoleLog";
            txtConsoleLog.ReadOnly = true;
            txtConsoleLog.ScrollBars = ScrollBars.Vertical;
            txtConsoleLog.Size = new Size(1110, 90);
            txtConsoleLog.TabIndex = 0;
            // 
            // grpPage2_AnalysisAndPlots
            // 
            grpPage2_AnalysisAndPlots.Controls.Add(lblP2TrueVal);
            grpPage2_AnalysisAndPlots.Controls.Add(numP2TrueVal);
            grpPage2_AnalysisAndPlots.Controls.Add(btnP2SelectRawFile);
            grpPage2_AnalysisAndPlots.Controls.Add(txtP2RawFilePath);
            grpPage2_AnalysisAndPlots.Controls.Add(btnP2ClearRawFile);
            grpPage2_AnalysisAndPlots.Controls.Add(btnP2SelectCalFile);
            grpPage2_AnalysisAndPlots.Controls.Add(txtP2CalFilePath);
            grpPage2_AnalysisAndPlots.Controls.Add(btnP2ClearCalFile);
            grpPage2_AnalysisAndPlots.Controls.Add(btnP2UseLastGenerated);
            grpPage2_AnalysisAndPlots.Controls.Add(btnP2PlotAll);
            grpPage2_AnalysisAndPlots.Controls.Add(lblBinCount);
            grpPage2_AnalysisAndPlots.Controls.Add(trkBinCount);
            grpPage2_AnalysisAndPlots.Controls.Add(btnP2AutoCalibrate);
            grpPage2_AnalysisAndPlots.Controls.Add(txtP2SummaryTable);
            grpPage2_AnalysisAndPlots.Controls.Add(plotTimeSeries);
            grpPage2_AnalysisAndPlots.Controls.Add(plotDistributionGraph);
            grpPage2_AnalysisAndPlots.Controls.Add(btnP2ViewSplit);
            grpPage2_AnalysisAndPlots.Controls.Add(btnP2ViewTimeSeries);
            grpPage2_AnalysisAndPlots.Controls.Add(btnP2ViewDistribution);
            grpPage2_AnalysisAndPlots.Controls.Add(btnP2ChartLayers);
            grpPage2_AnalysisAndPlots.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpPage2_AnalysisAndPlots.Location = new Point(25, 115);
            grpPage2_AnalysisAndPlots.Name = "grpPage2_AnalysisAndPlots";
            grpPage2_AnalysisAndPlots.Size = new Size(1360, 980);
            grpPage2_AnalysisAndPlots.TabIndex = 9;
            grpPage2_AnalysisAndPlots.TabStop = false;
            grpPage2_AnalysisAndPlots.Text = "Sayfa 2: Zaman Serisi Titreşim Grafiği (ScottPlot) & Doğruluk/Kesinlik Çift Çan Eğrisi (PDF)";
            grpPage2_AnalysisAndPlots.Visible = false;
            // 
            // lblP2TrueVal
            // 
            lblP2TrueVal.AutoSize = true;
            lblP2TrueVal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblP2TrueVal.Location = new Point(15, 36);
            lblP2TrueVal.Name = "lblP2TrueVal";
            lblP2TrueVal.Size = new Size(119, 25);
            lblP2TrueVal.TabIndex = 0;
            lblP2TrueVal.Text = "Gerçek Veri X:";
            // 
            // numP2TrueVal
            // 
            numP2TrueVal.DecimalPlaces = 1;
            numP2TrueVal.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numP2TrueVal.Location = new Point(155, 34);
            numP2TrueVal.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numP2TrueVal.Minimum = new decimal(new int[] { 100000, 0, 0, int.MinValue });
            numP2TrueVal.Name = "numP2TrueVal";
            numP2TrueVal.Size = new Size(100, 33);
            numP2TrueVal.TabIndex = 1;
            numP2TrueVal.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // btnP2SelectRawFile
            // 
            btnP2SelectRawFile.BackColor = Color.FromArgb(239, 68, 68);
            btnP2SelectRawFile.FlatAppearance.BorderSize = 0;
            btnP2SelectRawFile.FlatStyle = FlatStyle.Flat;
            btnP2SelectRawFile.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnP2SelectRawFile.ForeColor = Color.White;
            btnP2SelectRawFile.Location = new Point(265, 33);
            btnP2SelectRawFile.Name = "btnP2SelectRawFile";
            btnP2SelectRawFile.Size = new Size(115, 34);
            btnP2SelectRawFile.TabIndex = 2;
            btnP2SelectRawFile.Text = "Ham Dosya Seç";
            btnP2SelectRawFile.UseVisualStyleBackColor = false;
            // 
            // txtP2RawFilePath
            // 
            txtP2RawFilePath.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtP2RawFilePath.Location = new Point(385, 35);
            txtP2RawFilePath.Name = "txtP2RawFilePath";
            txtP2RawFilePath.ReadOnly = true;
            txtP2RawFilePath.Size = new Size(135, 30);
            txtP2RawFilePath.TabIndex = 3;
            txtP2RawFilePath.Text = "(Ham Sensör Dosyası)";
            // 
            // btnP2ClearRawFile
            // 
            btnP2ClearRawFile.BackColor = Color.FromArgb(185, 28, 28);
            btnP2ClearRawFile.FlatAppearance.BorderSize = 0;
            btnP2ClearRawFile.FlatStyle = FlatStyle.Flat;
            btnP2ClearRawFile.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnP2ClearRawFile.ForeColor = Color.White;
            btnP2ClearRawFile.Location = new Point(523, 33);
            btnP2ClearRawFile.Name = "btnP2ClearRawFile";
            btnP2ClearRawFile.Size = new Size(30, 34);
            btnP2ClearRawFile.TabIndex = 4;
            btnP2ClearRawFile.Text = "✖";
            btnP2ClearRawFile.UseVisualStyleBackColor = false;
            // 
            // btnP2SelectCalFile
            // 
            btnP2SelectCalFile.BackColor = Color.FromArgb(16, 185, 129);
            btnP2SelectCalFile.FlatAppearance.BorderSize = 0;
            btnP2SelectCalFile.FlatStyle = FlatStyle.Flat;
            btnP2SelectCalFile.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnP2SelectCalFile.ForeColor = Color.White;
            btnP2SelectCalFile.Location = new Point(558, 33);
            btnP2SelectCalFile.Name = "btnP2SelectCalFile";
            btnP2SelectCalFile.Size = new Size(120, 34);
            btnP2SelectCalFile.TabIndex = 5;
            btnP2SelectCalFile.Text = "Kalibre Dosya Seç";
            btnP2SelectCalFile.UseVisualStyleBackColor = false;
            // 
            // txtP2CalFilePath
            // 
            txtP2CalFilePath.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtP2CalFilePath.Location = new Point(683, 35);
            txtP2CalFilePath.Name = "txtP2CalFilePath";
            txtP2CalFilePath.ReadOnly = true;
            txtP2CalFilePath.Size = new Size(135, 30);
            txtP2CalFilePath.TabIndex = 6;
            txtP2CalFilePath.Text = "(Kalibre Dosyası)";
            // 
            // btnP2ClearCalFile
            // 
            btnP2ClearCalFile.BackColor = Color.FromArgb(4, 120, 87);
            btnP2ClearCalFile.FlatAppearance.BorderSize = 0;
            btnP2ClearCalFile.FlatStyle = FlatStyle.Flat;
            btnP2ClearCalFile.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnP2ClearCalFile.ForeColor = Color.White;
            btnP2ClearCalFile.Location = new Point(821, 33);
            btnP2ClearCalFile.Name = "btnP2ClearCalFile";
            btnP2ClearCalFile.Size = new Size(30, 34);
            btnP2ClearCalFile.TabIndex = 7;
            btnP2ClearCalFile.Text = "✖";
            btnP2ClearCalFile.UseVisualStyleBackColor = false;
            // 
            // btnP2UseLastGenerated
            // 
            btnP2UseLastGenerated.BackColor = Color.FromArgb(37, 99, 235);
            btnP2UseLastGenerated.FlatAppearance.BorderSize = 0;
            btnP2UseLastGenerated.FlatStyle = FlatStyle.Flat;
            btnP2UseLastGenerated.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnP2UseLastGenerated.ForeColor = Color.White;
            btnP2UseLastGenerated.Location = new Point(856, 33);
            btnP2UseLastGenerated.Name = "btnP2UseLastGenerated";
            btnP2UseLastGenerated.Size = new Size(125, 34);
            btnP2UseLastGenerated.TabIndex = 8;
            btnP2UseLastGenerated.Text = "Anlık Çek (S1)";
            btnP2UseLastGenerated.UseVisualStyleBackColor = false;
            // 
            // btnP2PlotAll
            // 
            btnP2PlotAll.BackColor = Color.FromArgb(15, 118, 110);
            btnP2PlotAll.FlatAppearance.BorderSize = 0;
            btnP2PlotAll.FlatStyle = FlatStyle.Flat;
            btnP2PlotAll.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnP2PlotAll.ForeColor = Color.White;
            btnP2PlotAll.Location = new Point(986, 33);
            btnP2PlotAll.Name = "btnP2PlotAll";
            btnP2PlotAll.Size = new Size(130, 34);
            btnP2PlotAll.TabIndex = 9;
            btnP2PlotAll.Text = "Grafikleri Çiz";
            btnP2PlotAll.UseVisualStyleBackColor = false;
            // 
            // lblBinCount
            // 
            lblBinCount.AutoSize = true;
            lblBinCount.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBinCount.ForeColor = Color.FromArgb(15, 23, 42);
            lblBinCount.Location = new Point(1135, 58);
            lblBinCount.Name = "lblBinCount";
            lblBinCount.Size = new Size(161, 23);
            lblBinCount.TabIndex = 11;
            lblBinCount.Text = "Histogram Dilim: 50";
            // 
            // trkBinCount
            // 
            trkBinCount.AutoSize = false;
            trkBinCount.Location = new Point(1135, 78);
            trkBinCount.Maximum = 1000;
            trkBinCount.Minimum = 10;
            trkBinCount.Name = "trkBinCount";
            trkBinCount.Size = new Size(190, 28);
            trkBinCount.TabIndex = 12;
            trkBinCount.TickFrequency = 25;
            trkBinCount.Value = 50;
            trkBinCount.ValueChanged += TrkBinCount_ValueChanged;
            // 
            // btnP2AutoCalibrate
            // 
            btnP2AutoCalibrate.BackColor = Color.FromArgb(217, 119, 6);
            btnP2AutoCalibrate.FlatAppearance.BorderSize = 0;
            btnP2AutoCalibrate.FlatStyle = FlatStyle.Flat;
            btnP2AutoCalibrate.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            btnP2AutoCalibrate.ForeColor = Color.White;
            btnP2AutoCalibrate.Location = new Point(1126, 17);
            btnP2AutoCalibrate.Name = "btnP2AutoCalibrate";
            btnP2AutoCalibrate.Size = new Size(195, 36);
            btnP2AutoCalibrate.TabIndex = 10;
            btnP2AutoCalibrate.Text = "🎯 OTOMATİK KALİBRASYON";
            btnP2AutoCalibrate.UseVisualStyleBackColor = false;
            // 
            // plotTimeSeries
            // 
            plotTimeSeries.DisplayScale = 1.5F;
            plotTimeSeries.Location = new Point(15, 115);
            plotTimeSeries.Name = "plotTimeSeries";
            plotTimeSeries.Size = new Size(1330, 290);
            plotTimeSeries.TabIndex = 8;
            // 
            // plotDistributionGraph
            // 
            plotDistributionGraph.DisplayScale = 1.5F;
            plotDistributionGraph.Location = new Point(15, 415);
            plotDistributionGraph.Name = "plotDistributionGraph";
            plotDistributionGraph.Size = new Size(1330, 290);
            plotDistributionGraph.TabIndex = 9;
            // 
            // btnP2ViewSplit
            // 
            btnP2ViewSplit.BackColor = Color.FromArgb(15, 118, 110);
            btnP2ViewSplit.FlatAppearance.BorderSize = 0;
            btnP2ViewSplit.FlatStyle = FlatStyle.Flat;
            btnP2ViewSplit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnP2ViewSplit.ForeColor = Color.White;
            btnP2ViewSplit.Location = new Point(15, 73);
            btnP2ViewSplit.Name = "btnP2ViewSplit";
            btnP2ViewSplit.Size = new Size(185, 33);
            btnP2ViewSplit.TabIndex = 12;
            btnP2ViewSplit.Text = "📊 İkili Görünüm (50/50)";
            btnP2ViewSplit.UseVisualStyleBackColor = false;
            // 
            // btnP2ViewTimeSeries
            // 
            btnP2ViewTimeSeries.BackColor = Color.FromArgb(51, 65, 85);
            btnP2ViewTimeSeries.FlatAppearance.BorderSize = 0;
            btnP2ViewTimeSeries.FlatStyle = FlatStyle.Flat;
            btnP2ViewTimeSeries.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnP2ViewTimeSeries.ForeColor = Color.White;
            btnP2ViewTimeSeries.Location = new Point(210, 73);
            btnP2ViewTimeSeries.Name = "btnP2ViewTimeSeries";
            btnP2ViewTimeSeries.Size = new Size(230, 33);
            btnP2ViewTimeSeries.TabIndex = 13;
            btnP2ViewTimeSeries.Text = "📈 Zaman Serisi Tam Ekran";
            btnP2ViewTimeSeries.UseVisualStyleBackColor = false;
            // 
            // btnP2ViewDistribution
            // 
            btnP2ViewDistribution.BackColor = Color.FromArgb(51, 65, 85);
            btnP2ViewDistribution.FlatAppearance.BorderSize = 0;
            btnP2ViewDistribution.FlatStyle = FlatStyle.Flat;
            btnP2ViewDistribution.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnP2ViewDistribution.ForeColor = Color.White;
            btnP2ViewDistribution.Location = new Point(450, 73);
            btnP2ViewDistribution.Name = "btnP2ViewDistribution";
            btnP2ViewDistribution.Size = new Size(280, 33);
            btnP2ViewDistribution.TabIndex = 14;
            btnP2ViewDistribution.Text = "🔔 Olasılık Dağılımı Tam Ekran (DEV)";
            btnP2ViewDistribution.UseVisualStyleBackColor = false;
            // 
            // btnP2ChartLayers
            // 
            btnP2ChartLayers.BackColor = Color.FromArgb(124, 58, 237);
            btnP2ChartLayers.FlatAppearance.BorderSize = 0;
            btnP2ChartLayers.FlatStyle = FlatStyle.Flat;
            btnP2ChartLayers.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnP2ChartLayers.ForeColor = Color.White;
            btnP2ChartLayers.Location = new Point(740, 73);
            btnP2ChartLayers.Name = "btnP2ChartLayers";
            btnP2ChartLayers.Size = new Size(260, 33);
            btnP2ChartLayers.TabIndex = 15;
            btnP2ChartLayers.Text = "🎨 Grafik Katman & Çizim Ayarları";
            btnP2ChartLayers.UseVisualStyleBackColor = false;
            // 
            // txtP2SummaryTable
            // 
            txtP2SummaryTable.BackColor = Color.FromArgb(15, 23, 42);
            txtP2SummaryTable.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtP2SummaryTable.ForeColor = Color.FromArgb(226, 232, 240);
            txtP2SummaryTable.Location = new Point(0, 761);
            txtP2SummaryTable.Multiline = true;
            txtP2SummaryTable.Name = "txtP2SummaryTable";
            txtP2SummaryTable.ReadOnly = true;
            txtP2SummaryTable.ScrollBars = ScrollBars.Vertical;
            txtP2SummaryTable.Size = new Size(1340, 213);
            txtP2SummaryTable.TabIndex = 10;
            // 
            // SensorSettingsSubPanel
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(241, 245, 249);
            Controls.Add(pnlPage3_Estimation);
            Controls.Add(grpPage2_AnalysisAndPlots);
            Controls.Add(grpConsoleLog);
            Controls.Add(grpFileAndCalibrationModules);
            Controls.Add(grpErrorsAndCalculated);
            Controls.Add(grpRange);
            Controls.Add(btnPage3_Estimation);
            Controls.Add(btnPage2_Chart);
            Controls.Add(btnPage1_Settings);
            Controls.Add(btnMasterSaveCsv);
            Controls.Add(cmbSensorType);
            Controls.Add(lblSensorSelect);
            Controls.Add(lblPanelTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "SensorSettingsSubPanel";
            Size = new Size(1602, 1148);
            grpRange.ResumeLayout(false);
            grpRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numRangeMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRangeMin).EndInit();
            grpErrorsAndCalculated.ResumeLayout(false);
            grpSensorErrors.ResumeLayout(false);
            grpSensorErrors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBias).EndInit();
            ((System.ComponentModel.ISupportInitialize)numScaleErrorPercent).EndInit();
            grpSensorNoise.ResumeLayout(false);
            grpSensorNoise.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numThermalStdDev).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRelativeNoisePercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSpikeProbPercent).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSpikeAmplitude).EndInit();
            grpCalculatedErrors.ResumeLayout(false);
            grpCalculatedErrors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numProcessedBias).EndInit();
            ((System.ComponentModel.ISupportInitialize)numProcessedScale).EndInit();
            grpFileAndCalibrationModules.ResumeLayout(false);
            grpSubModuleGenerate.ResumeLayout(false);
            grpSubModuleGenerate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numGenCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGenTrueVal).EndInit();
            grpSubModuleCalibrate.ResumeLayout(false);
            grpSubModuleCalibrate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCalRefTrue1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCalRefTrue2).EndInit();
            grpSubModuleExport.ResumeLayout(false);
            grpSubModuleExport.PerformLayout();
            grpConsoleLog.ResumeLayout(false);
            grpConsoleLog.PerformLayout();
            grpPage2_AnalysisAndPlots.ResumeLayout(false);
            grpPage2_AnalysisAndPlots.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numP2TrueVal).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkBinCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPanelTitle;
        private System.Windows.Forms.Label lblSensorSelect;
        private System.Windows.Forms.ComboBox cmbSensorType;
        private System.Windows.Forms.Button btnPage1_Settings;
        private System.Windows.Forms.Button btnPage2_Chart;
        private System.Windows.Forms.Button btnPage3_Estimation;
        private System.Windows.Forms.Panel pnlPage3_Estimation;

        private System.Windows.Forms.GroupBox grpRange;
        private System.Windows.Forms.Label lblRangeMin;
        private System.Windows.Forms.NumericUpDown numRangeMin;
        private System.Windows.Forms.Label lblRangeMax;
        private System.Windows.Forms.NumericUpDown numRangeMax;
        private System.Windows.Forms.Label lblFullScaleInfo;

        private System.Windows.Forms.GroupBox grpErrorsAndCalculated;
        private System.Windows.Forms.GroupBox grpSensorErrors;
        private System.Windows.Forms.CheckBox chkEnableBias;
        private System.Windows.Forms.NumericUpDown numBias;
        private System.Windows.Forms.CheckBox chkEnableScale;
        private System.Windows.Forms.NumericUpDown numScaleErrorPercent;

        private System.Windows.Forms.GroupBox grpSensorNoise;
        private System.Windows.Forms.CheckBox chkEnableThermal;
        private System.Windows.Forms.NumericUpDown numThermalStdDev;
        private System.Windows.Forms.CheckBox chkEnableRelativeNoise;
        private System.Windows.Forms.NumericUpDown numRelativeNoisePercent;
        private System.Windows.Forms.CheckBox chkEnableSpike;
        private System.Windows.Forms.NumericUpDown numSpikeProbPercent;
        private System.Windows.Forms.Label lblSpikeAmp;
        private System.Windows.Forms.NumericUpDown numSpikeAmplitude;

        private System.Windows.Forms.GroupBox grpCalculatedErrors;
        private System.Windows.Forms.Label lblCalcBiasTitle;
        private System.Windows.Forms.NumericUpDown numProcessedBias;
        private System.Windows.Forms.Label lblCalcScaleTitle;
        private System.Windows.Forms.NumericUpDown numProcessedScale;
        private System.Windows.Forms.Label lblResidualInfo;
        private System.Windows.Forms.Button btnApplyToSim;

        private System.Windows.Forms.GroupBox grpFileAndCalibrationModules;
        private System.Windows.Forms.GroupBox grpSubModuleGenerate;
        private System.Windows.Forms.Label lblGenCount;
        private System.Windows.Forms.NumericUpDown numGenCount;
        private System.Windows.Forms.Label lblGenTrueVal;
        private System.Windows.Forms.NumericUpDown numGenTrueVal;
        private System.Windows.Forms.Button btnGenerateAndSaveCsv;

        private System.Windows.Forms.GroupBox grpSubModuleCalibrate;
        private System.Windows.Forms.Button btnSelectRef1File;
        private System.Windows.Forms.Label lblRef1FileName;
        private System.Windows.Forms.Button btnSelectRef2File;
        private System.Windows.Forms.Label lblRef2FileName;
        private System.Windows.Forms.NumericUpDown numCalRefTrue1;
        private System.Windows.Forms.NumericUpDown numCalRefTrue2;
        private System.Windows.Forms.CheckBox chkOutlierRejection;
        private System.Windows.Forms.CheckBox chkAutoSaveToCalculated;
        private System.Windows.Forms.Button btnCalculateCalibration;

        private System.Windows.Forms.GroupBox grpSubModuleExport;
        private System.Windows.Forms.Button btnSelectInputFile;
        private System.Windows.Forms.Label lblInputFileName;
        private System.Windows.Forms.Button btnExportCalibratedCsv;

        private System.Windows.Forms.GroupBox grpConsoleLog;
        private System.Windows.Forms.TextBox txtConsoleLog;

        private System.Windows.Forms.GroupBox grpPage2_AnalysisAndPlots;
        private System.Windows.Forms.Label lblP2TrueVal;
        private System.Windows.Forms.NumericUpDown numP2TrueVal;
        private System.Windows.Forms.Button btnP2SelectRawFile;
        private System.Windows.Forms.TextBox txtP2RawFilePath;
        private System.Windows.Forms.Button btnP2ClearRawFile;
        private System.Windows.Forms.Button btnP2SelectCalFile;
        private System.Windows.Forms.TextBox txtP2CalFilePath;
        private System.Windows.Forms.Button btnP2ClearCalFile;
        private System.Windows.Forms.Button btnP2UseLastGenerated;
        private System.Windows.Forms.Button btnP2PlotAll;
        private System.Windows.Forms.Label lblBinCount;
        private System.Windows.Forms.TrackBar trkBinCount;
        private ScottPlot.WinForms.FormsPlot plotTimeSeries;
        private ScottPlot.WinForms.FormsPlot plotDistributionGraph;
        private System.Windows.Forms.Button btnP2ViewSplit;
        private System.Windows.Forms.Button btnP2ViewTimeSeries;
        private System.Windows.Forms.Button btnP2ViewDistribution;
        private System.Windows.Forms.Button btnP2ChartLayers;
        private System.Windows.Forms.Button btnP2AutoCalibrate;
        private System.Windows.Forms.Button btnMasterSaveCsv;
        private System.Windows.Forms.TextBox txtP2SummaryTable;
    }
}
