namespace SensorAnalizi
{
    partial class FormSensorAnalizi
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageCompare = new System.Windows.Forms.TabPage();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.plotAltitude = new ScottPlot.WinForms.FormsPlot();
            this.plotVelocity = new ScottPlot.WinForms.FormsPlot();
            this.topControlPanel = new System.Windows.Forms.Panel();
            this.grpCustomSim = new System.Windows.Forms.GroupBox();
            this.lblErrorPercent = new System.Windows.Forms.Label();
            this.numErrorPercent = new System.Windows.Forms.NumericUpDown();
            this.chkUseFusion = new System.Windows.Forms.CheckBox();
            this.btnRunCustom = new System.Windows.Forms.Button();
            this.btnRunAllCompare = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.dgvMetrics = new System.Windows.Forms.DataGridView();
            this.colScenario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScaleError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFusion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImpactVel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLandingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEvaluation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPanel = new System.Windows.Forms.Panel();
            this.btnExportPng = new System.Windows.Forms.Button();

            // Tab 2: Dikey Fizik Motoru & Oynatıcı
            this.tabPagePhysics = new System.Windows.Forms.TabPage();
            this.physicsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelPhysicsParams = new System.Windows.Forms.Panel();

            // Yeni Kütle & Aerodinami GroupBox
            this.grpMassAero = new System.Windows.Forms.GroupBox();
            this.lblMassCarrier = new System.Windows.Forms.Label();
            this.numMassCarrier = new System.Windows.Forms.NumericUpDown();
            this.lblMassPayload = new System.Windows.Forms.Label();
            this.numMassPayload = new System.Windows.Forms.NumericUpDown();
            this.lblAreaCarrier = new System.Windows.Forms.Label();
            this.numAreaCarrier = new System.Windows.Forms.NumericUpDown();
            this.lblAreaPayload = new System.Windows.Forms.Label();
            this.numAreaPayload = new System.Windows.Forms.NumericUpDown();
            this.lblAreaApam = new System.Windows.Forms.Label();
            this.numAreaApam = new System.Windows.Forms.NumericUpDown();
            this.lblAirDensity = new System.Windows.Forms.Label();
            this.numAirDensity = new System.Windows.Forms.NumericUpDown();

            // Yeni Görev ve Alt-Senaryo GroupBox
            this.grpMission = new System.Windows.Forms.GroupBox();
            this.lblHoverDuration = new System.Windows.Forms.Label();
            this.numHoverDuration = new System.Windows.Forms.NumericUpDown();
            this.lblHoverAltitude = new System.Windows.Forms.Label();
            this.numHoverAltitude = new System.Windows.Forms.NumericUpDown();
            this.lblSeparationAlt = new System.Windows.Forms.Label();
            this.numSeparationAlt = new System.Windows.Forms.NumericUpDown();

            this.grpPID = new System.Windows.Forms.GroupBox();
            this.lblKp = new System.Windows.Forms.Label();
            this.numKp = new System.Windows.Forms.NumericUpDown();
            this.lblKi = new System.Windows.Forms.Label();
            this.numKi = new System.Windows.Forms.NumericUpDown();
            this.lblKd = new System.Windows.Forms.Label();
            this.numKd = new System.Windows.Forms.NumericUpDown();

            this.grpNoise = new System.Windows.Forms.GroupBox();
            this.lblBaroNoise = new System.Windows.Forms.Label();
            this.numBaroNoise = new System.Windows.Forms.NumericUpDown();
            this.lblBaroErrPct = new System.Windows.Forms.Label();
            this.numBaroErrPct = new System.Windows.Forms.NumericUpDown();
            this.lblImuNoise = new System.Windows.Forms.Label();
            this.numImuNoise = new System.Windows.Forms.NumericUpDown();

            this.grpBucket = new System.Windows.Forms.GroupBox();
            this.lblFillRate = new System.Windows.Forms.Label();
            this.numFillRate = new System.Windows.Forms.NumericUpDown();
            this.lblLeakRate = new System.Windows.Forms.Label();
            this.numLeakRate = new System.Windows.Forms.NumericUpDown();
            this.lblBucketThresh = new System.Windows.Forms.Label();
            this.numBucketThresh = new System.Windows.Forms.NumericUpDown();

            this.btnRunPhysics = new System.Windows.Forms.Button();
            this.panelBucketStatus = new System.Windows.Forms.Panel();
            this.lblBucketStatusTitle = new System.Windows.Forms.Label();
            this.lblBucketStatusText = new System.Windows.Forms.Label();
            this.progBucket = new System.Windows.Forms.ProgressBar();

            // Oynatıcı ve Canlı Durum Paneli
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnStepBack = new System.Windows.Forms.Button();
            this.btnStepFwd = new System.Windows.Forms.Button();
            this.trackTimeline = new System.Windows.Forms.TrackBar();
            this.lblCurrentTime = new System.Windows.Forms.Label();

            this.panelLiveDashboard = new System.Windows.Forms.Panel();
            this.lblDashState = new System.Windows.Forms.Label();
            this.lblDashSubState = new System.Windows.Forms.Label();
            this.lblDashPhysics = new System.Windows.Forms.Label();
            this.lblDashKinematics = new System.Windows.Forms.Label();
            this.lblDashActuators = new System.Windows.Forms.Label();

            this.plotPhysicsAltitude = new ScottPlot.WinForms.FormsPlot();
            this.panelDualCoreDashboard = new System.Windows.Forms.TableLayoutPanel();
            this.grpLeakyBucketCore = new System.Windows.Forms.GroupBox();
            this.progBucketCore = new System.Windows.Forms.ProgressBar();
            this.lblBucketCoreStatus = new System.Windows.Forms.Label();
            this.lblBucketCoreFactors = new System.Windows.Forms.Label();
            this.grpEkfKernelCore = new System.Windows.Forms.GroupBox();
            this.picEkfStackedBar = new System.Windows.Forms.PictureBox();
            this.lblEkfTrustDetails = new System.Windows.Forms.Label();
            this.timerPlayback = new System.Windows.Forms.Timer(this.components);

            this.tabMain.SuspendLayout();
            this.tabPageCompare.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.topControlPanel.SuspendLayout();
            this.grpCustomSim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numErrorPercent)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetrics)).BeginInit();
            this.btnPanel.SuspendLayout();

            this.tabPagePhysics.SuspendLayout();
            this.physicsLayout.SuspendLayout();
            this.panelPhysicsParams.SuspendLayout();
            this.panelDualCoreDashboard.SuspendLayout();
            this.grpLeakyBucketCore.SuspendLayout();
            this.grpEkfKernelCore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEkfStackedBar)).BeginInit();
            
            this.grpMassAero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMassCarrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMassPayload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAreaCarrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAreaPayload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAreaApam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAirDensity)).BeginInit();

            this.grpMission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHoverDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoverAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeparationAlt)).BeginInit();

            this.grpPID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKd)).BeginInit();
            this.grpNoise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaroNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBaroErrPct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImuNoise)).BeginInit();
            this.grpBucket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFillRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeakRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBucketThresh)).BeginInit();
            this.panelBucketStatus.SuspendLayout();
            this.panelPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackTimeline)).BeginInit();
            this.panelLiveDashboard.SuspendLayout();
            this.SuspendLayout();

            // tabMain
            this.tabMain.Controls.Add(this.tabPagePhysics);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1380, 880);
            this.tabMain.TabIndex = 0;

            // tabPageCompare
            this.tabPageCompare.Controls.Add(this.mainLayout);
            this.tabPageCompare.Location = new System.Drawing.Point(4, 26);
            this.tabPageCompare.Name = "tabPageCompare";
            this.tabPageCompare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCompare.Size = new System.Drawing.Size(1372, 850);
            this.tabPageCompare.TabIndex = 0;
            this.tabPageCompare.Text = "📊 4 Senaryo Karşılaştırması & Hızlı Analiz";
            this.tabPageCompare.UseVisualStyleBackColor = true;

            // mainLayout
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.Controls.Add(this.topControlPanel, 0, 0);
            this.mainLayout.SetColumnSpan(this.topControlPanel, 2);
            this.mainLayout.Controls.Add(this.plotAltitude, 0, 1);
            this.mainLayout.Controls.Add(this.plotVelocity, 1, 1);
            this.mainLayout.Controls.Add(this.bottomPanel, 0, 2);
            this.mainLayout.SetColumnSpan(this.bottomPanel, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(3, 3);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mainLayout.Size = new System.Drawing.Size(1366, 844);
            this.mainLayout.TabIndex = 0;

            // topControlPanel
            this.topControlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.topControlPanel.Controls.Add(this.grpCustomSim);
            this.topControlPanel.Controls.Add(this.btnRunAllCompare);
            this.topControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topControlPanel.Location = new System.Drawing.Point(3, 3);
            this.topControlPanel.Name = "topControlPanel";
            this.topControlPanel.Size = new System.Drawing.Size(1360, 64);
            this.topControlPanel.TabIndex = 0;

            this.grpCustomSim.Controls.Add(this.lblErrorPercent);
            this.grpCustomSim.Controls.Add(this.numErrorPercent);
            this.grpCustomSim.Controls.Add(this.chkUseFusion);
            this.grpCustomSim.Controls.Add(this.btnRunCustom);
            this.grpCustomSim.Location = new System.Drawing.Point(10, 4);
            this.grpCustomSim.Name = "grpCustomSim";
            this.grpCustomSim.Size = new System.Drawing.Size(640, 56);
            this.grpCustomSim.TabIndex = 0;
            this.grpCustomSim.TabStop = false;
            this.grpCustomSim.Text = "Etkileşimli Simülasyon Kontrolü";

            this.lblErrorPercent.AutoSize = true;
            this.lblErrorPercent.Location = new System.Drawing.Point(15, 25);
            this.lblErrorPercent.Name = "lblErrorPercent";
            this.lblErrorPercent.Size = new System.Drawing.Size(151, 17);
            this.lblErrorPercent.TabIndex = 0;
            this.lblErrorPercent.Text = "Barometre Hata Payı (%):";

            this.numErrorPercent.Location = new System.Drawing.Point(175, 23);
            this.numErrorPercent.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numErrorPercent.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
            this.numErrorPercent.Name = "numErrorPercent";
            this.numErrorPercent.Size = new System.Drawing.Size(65, 24);
            this.numErrorPercent.TabIndex = 1;
            this.numErrorPercent.Value = new decimal(new int[] { 20, 0, 0, 0 });

            this.chkUseFusion.AutoSize = true;
            this.chkUseFusion.Checked = true;
            this.chkUseFusion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseFusion.Location = new System.Drawing.Point(255, 24);
            this.chkUseFusion.Name = "chkUseFusion";
            this.chkUseFusion.Size = new System.Drawing.Size(178, 21);
            this.chkUseFusion.TabIndex = 2;
            this.chkUseFusion.Text = "Sensör Füzyonu (EKF) Aktif";
            this.chkUseFusion.UseVisualStyleBackColor = true;

            this.btnRunCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(124)))), ((int)(((byte)(65)))));
            this.btnRunCustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunCustom.ForeColor = System.Drawing.Color.White;
            this.btnRunCustom.Location = new System.Drawing.Point(450, 18);
            this.btnRunCustom.Name = "btnRunCustom";
            this.btnRunCustom.Size = new System.Drawing.Size(175, 30);
            this.btnRunCustom.TabIndex = 3;
            this.btnRunCustom.Text = "🎯 Özel Senaryoyu Çiz";
            this.btnRunCustom.UseVisualStyleBackColor = false;
            this.btnRunCustom.Click += new System.EventHandler(this.BtnRunCustom_Click);

            this.btnRunAllCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnRunAllCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunAllCompare.ForeColor = System.Drawing.Color.White;
            this.btnRunAllCompare.Location = new System.Drawing.Point(670, 20);
            this.btnRunAllCompare.Name = "btnRunAllCompare";
            this.btnRunAllCompare.Size = new System.Drawing.Size(260, 32);
            this.btnRunAllCompare.TabIndex = 1;
            this.btnRunAllCompare.Text = "🚀 Yarışma 4 Senaryosunu Karşılaştır";
            this.btnRunAllCompare.UseVisualStyleBackColor = false;
            this.btnRunAllCompare.Click += new System.EventHandler(this.BtnRunAllCompare_Click);

            this.plotAltitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotAltitude.Location = new System.Drawing.Point(4, 74);
            this.plotAltitude.Margin = new System.Windows.Forms.Padding(4);
            this.plotAltitude.Name = "plotAltitude";
            this.plotAltitude.Size = new System.Drawing.Size(675, 456);
            this.plotAltitude.TabIndex = 1;

            this.plotVelocity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotVelocity.Location = new System.Drawing.Point(687, 74);
            this.plotVelocity.Margin = new System.Windows.Forms.Padding(4);
            this.plotVelocity.Name = "plotVelocity";
            this.plotVelocity.Size = new System.Drawing.Size(675, 456);
            this.plotVelocity.TabIndex = 2;

            this.bottomPanel.Controls.Add(this.dgvMetrics);
            this.bottomPanel.Controls.Add(this.btnPanel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(3, 537);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1360, 304);
            this.bottomPanel.TabIndex = 3;

            this.dgvMetrics.AllowUserToAddRows = false;
            this.dgvMetrics.AllowUserToDeleteRows = false;
            this.dgvMetrics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMetrics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetrics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colScenario,
            this.colScaleError,
            this.colFusion,
            this.colImpactVel,
            this.colLandingTime,
            this.colEvaluation});
            this.dgvMetrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMetrics.Location = new System.Drawing.Point(0, 0);
            this.dgvMetrics.Name = "dgvMetrics";
            this.dgvMetrics.ReadOnly = true;
            this.dgvMetrics.RowHeadersVisible = false;
            this.dgvMetrics.Size = new System.Drawing.Size(1360, 258);
            this.dgvMetrics.TabIndex = 0;

            this.colScenario.HeaderText = "Senaryo Adı";
            this.colScenario.Name = "colScenario";
            this.colScenario.ReadOnly = true;
            this.colScaleError.HeaderText = "Sensör Hata Oranı";
            this.colScaleError.Name = "colScaleError";
            this.colScaleError.ReadOnly = true;
            this.colFusion.HeaderText = "Füzyon Durumu";
            this.colFusion.Name = "colFusion";
            this.colFusion.ReadOnly = true;
            this.colImpactVel.HeaderText = "Yere Çarpma Hızı (m/s)";
            this.colImpactVel.Name = "colImpactVel";
            this.colImpactVel.ReadOnly = true;
            this.colLandingTime.HeaderText = "İniş Süresi (s)";
            this.colLandingTime.Name = "colLandingTime";
            this.colLandingTime.ReadOnly = true;
            this.colEvaluation.HeaderText = "Risk Değerlendirmesi";
            this.colEvaluation.Name = "colEvaluation";
            this.colEvaluation.ReadOnly = true;

            this.btnPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPanel.Height = 46;
            this.btnPanel.Controls.Add(this.btnExportPng);

            this.btnExportPng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnExportPng.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPng.ForeColor = System.Drawing.Color.White;
            this.btnExportPng.Location = new System.Drawing.Point(10, 8);
            this.btnExportPng.Name = "btnExportPng";
            this.btnExportPng.Size = new System.Drawing.Size(200, 32);
            this.btnExportPng.TabIndex = 0;
            this.btnExportPng.Text = "📷 PNG Olarak Kaydet";
            this.btnExportPng.UseVisualStyleBackColor = false;
            this.btnExportPng.Click += new System.EventHandler(this.BtnExportPng_Click);

            // =========================================================================
            // Tab 2: Dikey Fizik Motoru & Oynatıcı & Modüler Senaryolar
            // =========================================================================
            this.tabPagePhysics.Controls.Add(this.physicsLayout);
            this.tabPagePhysics.Location = new System.Drawing.Point(4, 26);
            this.tabPagePhysics.Name = "tabPagePhysics";
            this.tabPagePhysics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhysics.Size = new System.Drawing.Size(1372, 850);
            this.tabPagePhysics.TabIndex = 1;
            this.tabPagePhysics.Text = "🎬 Dikey Fizik Motoru & Zaman Oynatıcı + Modüler Alt-Senaryolar";
            this.tabPagePhysics.UseVisualStyleBackColor = true;

            this.physicsLayout.ColumnCount = 2;
            this.physicsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.physicsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.physicsLayout.Controls.Add(this.panelPhysicsParams, 0, 0);
            this.physicsLayout.SetRowSpan(this.panelPhysicsParams, 4);
            
            this.physicsLayout.Controls.Add(this.panelPlayer, 1, 0);
            this.physicsLayout.Controls.Add(this.panelLiveDashboard, 1, 1);
            this.physicsLayout.Controls.Add(this.plotPhysicsAltitude, 1, 2);
            this.physicsLayout.Controls.Add(this.panelDualCoreDashboard, 1, 3);

            this.physicsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.physicsLayout.Location = new System.Drawing.Point(3, 3);
            this.physicsLayout.Name = "physicsLayout";
            this.physicsLayout.RowCount = 4;
            this.physicsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.physicsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.physicsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.physicsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.physicsLayout.Size = new System.Drawing.Size(1366, 844);
            this.physicsLayout.TabIndex = 0;

            // panelPhysicsParams (Sol Kolon - Geniş Kapsamlı Parametre Paneli)
            this.panelPhysicsParams.AutoScroll = true;
            this.panelPhysicsParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelPhysicsParams.Controls.Add(this.grpMassAero);
            this.panelPhysicsParams.Controls.Add(this.grpMission);
            this.panelPhysicsParams.Controls.Add(this.grpPID);
            this.panelPhysicsParams.Controls.Add(this.grpNoise);
            this.panelPhysicsParams.Controls.Add(this.grpBucket);
            this.panelPhysicsParams.Controls.Add(this.btnRunPhysics);
            this.panelPhysicsParams.Controls.Add(this.panelBucketStatus);
            this.panelPhysicsParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPhysicsParams.Location = new System.Drawing.Point(3, 3);
            this.panelPhysicsParams.Name = "panelPhysicsParams";
            this.panelPhysicsParams.Padding = new System.Windows.Forms.Padding(6);
            this.panelPhysicsParams.Size = new System.Drawing.Size(324, 838);
            this.panelPhysicsParams.TabIndex = 0;

            // 1. grpMassAero: Kütle ve Aerodinamik Yüzey Genişlikleri
            this.grpMassAero.Controls.Add(this.lblMassCarrier);
            this.grpMassAero.Controls.Add(this.numMassCarrier);
            this.grpMassAero.Controls.Add(this.lblMassPayload);
            this.grpMassAero.Controls.Add(this.numMassPayload);
            this.grpMassAero.Controls.Add(this.lblAreaCarrier);
            this.grpMassAero.Controls.Add(this.numAreaCarrier);
            this.grpMassAero.Controls.Add(this.lblAreaPayload);
            this.grpMassAero.Controls.Add(this.numAreaPayload);
            this.grpMassAero.Controls.Add(this.lblAreaApam);
            this.grpMassAero.Controls.Add(this.numAreaApam);
            this.grpMassAero.Controls.Add(this.lblAirDensity);
            this.grpMassAero.Controls.Add(this.numAirDensity);
            this.grpMassAero.Location = new System.Drawing.Point(8, 8);
            this.grpMassAero.Name = "grpMassAero";
            this.grpMassAero.Size = new System.Drawing.Size(306, 195);
            this.grpMassAero.TabIndex = 0;
            this.grpMassAero.TabStop = false;
            this.grpMassAero.Text = "Kütle (kg) & Paraşüt Yüzey Alanları (m²)";

            this.lblMassCarrier.Location = new System.Drawing.Point(12, 25);
            this.lblMassCarrier.Text = "Taşıyıcı Kütle (kg):";
            this.numMassCarrier.Location = new System.Drawing.Point(170, 23);
            this.numMassCarrier.DecimalPlaces = 2;
            this.numMassCarrier.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numMassCarrier.Value = new decimal(new int[] { 55, 0, 0, 131072 });

            this.lblMassPayload.Location = new System.Drawing.Point(12, 52);
            this.lblMassPayload.Text = "Görev Yükü Kütle (kg):";
            this.numMassPayload.Location = new System.Drawing.Point(170, 50);
            this.numMassPayload.DecimalPlaces = 2;
            this.numMassPayload.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numMassPayload.Value = new decimal(new int[] { 125, 0, 0, 131072 });

            this.lblAreaCarrier.Location = new System.Drawing.Point(12, 79);
            this.lblAreaCarrier.Text = "Ana Paraşüt Alanı (m²):";
            this.numAreaCarrier.Location = new System.Drawing.Point(170, 77);
            this.numAreaCarrier.DecimalPlaces = 4;
            this.numAreaCarrier.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.numAreaCarrier.Value = new decimal(new int[] { 1256, 0, 0, 262144 });

            this.lblAreaPayload.Location = new System.Drawing.Point(12, 106);
            this.lblAreaPayload.Text = "Görev Yükü Alanı (m²):";
            this.numAreaPayload.Location = new System.Drawing.Point(170, 104);
            this.numAreaPayload.DecimalPlaces = 4;
            this.numAreaPayload.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            this.numAreaPayload.Value = new decimal(new int[] { 804, 0, 0, 262144 });

            this.lblAreaApam.Location = new System.Drawing.Point(12, 133);
            this.lblAreaApam.Text = "APAM Paraşüt Alanı (m²):";
            this.numAreaApam.Location = new System.Drawing.Point(170, 131);
            this.numAreaApam.DecimalPlaces = 4;
            this.numAreaApam.Increment = new decimal(new int[] { 2, 0, 0, 131072 });
            this.numAreaApam.Value = new decimal(new int[] { 5026, 0, 0, 262144 });

            this.lblAirDensity.Location = new System.Drawing.Point(12, 160);
            this.lblAirDensity.Text = "Hava Yoğunluğu (kg/m³):";
            this.numAirDensity.Location = new System.Drawing.Point(170, 158);
            this.numAirDensity.DecimalPlaces = 2;
            this.numAirDensity.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numAirDensity.Value = new decimal(new int[] { 110, 0, 0, 131072 });

            // 2. grpMission: Görev Süreleri ve İrtifa Hedefleri
            this.grpMission.Controls.Add(this.lblHoverDuration);
            this.grpMission.Controls.Add(this.numHoverDuration);
            this.grpMission.Controls.Add(this.lblHoverAltitude);
            this.grpMission.Controls.Add(this.numHoverAltitude);
            this.grpMission.Controls.Add(this.lblSeparationAlt);
            this.grpMission.Controls.Add(this.numSeparationAlt);
            this.grpMission.Location = new System.Drawing.Point(8, 209);
            this.grpMission.Name = "grpMission";
            this.grpMission.Size = new System.Drawing.Size(306, 115);
            this.grpMission.TabIndex = 1;
            this.grpMission.TabStop = false;
            this.grpMission.Text = "Görev Süreleri & Hedef İrtifalar";

            this.lblHoverDuration.Location = new System.Drawing.Point(12, 28);
            this.lblHoverDuration.Text = "S4b Hover Süresi (sn):";
            this.numHoverDuration.Location = new System.Drawing.Point(170, 26);
            this.numHoverDuration.DecimalPlaces = 1;
            this.numHoverDuration.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            this.numHoverDuration.Value = new decimal(new int[] { 10, 0, 0, 0 });

            this.lblHoverAltitude.Location = new System.Drawing.Point(12, 56);
            this.lblHoverAltitude.Text = "S4b Hover İrtifası (m):";
            this.numHoverAltitude.Location = new System.Drawing.Point(170, 54);
            this.numHoverAltitude.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numHoverAltitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            this.numHoverAltitude.Value = new decimal(new int[] { 200, 0, 0, 0 });

            this.lblSeparationAlt.Location = new System.Drawing.Point(12, 84);
            this.lblSeparationAlt.Text = "S3 Ayrılma İrtifası (m):";
            this.numSeparationAlt.Location = new System.Drawing.Point(170, 82);
            this.numSeparationAlt.Maximum = new decimal(new int[] { 1800, 0, 0, 0 });
            this.numSeparationAlt.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            this.numSeparationAlt.Value = new decimal(new int[] { 1000, 0, 0, 0 });

            // 3. grpPID
            this.grpPID.Controls.Add(this.lblKp);
            this.grpPID.Controls.Add(this.numKp);
            this.grpPID.Controls.Add(this.lblKi);
            this.grpPID.Controls.Add(this.numKi);
            this.grpPID.Controls.Add(this.lblKd);
            this.grpPID.Controls.Add(this.numKd);
            this.grpPID.Location = new System.Drawing.Point(8, 330);
            this.grpPID.Name = "grpPID";
            this.grpPID.Size = new System.Drawing.Size(306, 115);
            this.grpPID.TabIndex = 2;
            this.grpPID.TabStop = false;
            this.grpPID.Text = "Dikey PID Kontrol Katsayıları";

            this.lblKp.Location = new System.Drawing.Point(12, 28);
            this.lblKp.Text = "Kp (Orantısal):";
            this.numKp.Location = new System.Drawing.Point(170, 26);
            this.numKp.DecimalPlaces = 2;
            this.numKp.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numKp.Value = new decimal(new int[] { 35, 0, 0, 65536 });

            this.lblKi.Location = new System.Drawing.Point(12, 56);
            this.lblKi.Text = "Ki (İntegral):";
            this.numKi.Location = new System.Drawing.Point(170, 54);
            this.numKi.DecimalPlaces = 2;
            this.numKi.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numKi.Value = new decimal(new int[] { 4, 0, 0, 65536 });

            this.lblKd.Location = new System.Drawing.Point(12, 84);
            this.lblKd.Text = "Kd (Türevsel):";
            this.numKd.Location = new System.Drawing.Point(170, 82);
            this.numKd.DecimalPlaces = 2;
            this.numKd.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numKd.Value = new decimal(new int[] { 42, 0, 0, 65536 });

            // 4. grpNoise
            this.grpNoise.Controls.Add(this.lblBaroNoise);
            this.grpNoise.Controls.Add(this.numBaroNoise);
            this.grpNoise.Controls.Add(this.lblBaroErrPct);
            this.grpNoise.Controls.Add(this.numBaroErrPct);
            this.grpNoise.Controls.Add(this.lblImuNoise);
            this.grpNoise.Controls.Add(this.numImuNoise);
            this.grpNoise.Location = new System.Drawing.Point(8, 451);
            this.grpNoise.Name = "grpNoise";
            this.grpNoise.Size = new System.Drawing.Size(306, 115);
            this.grpNoise.TabIndex = 3;
            this.grpNoise.TabStop = false;
            this.grpNoise.Text = "Sensör Gürültü ve % Hata Parametreleri";

            this.lblBaroNoise.Location = new System.Drawing.Point(12, 28);
            this.lblBaroNoise.Text = "Baro σ_gürültü (m):";
            this.numBaroNoise.Location = new System.Drawing.Point(170, 26);
            this.numBaroNoise.DecimalPlaces = 1;
            this.numBaroNoise.Increment = new decimal(new int[] { 2, 0, 0, 65536 });
            this.numBaroNoise.Value = new decimal(new int[] { 12, 0, 0, 65536 });

            this.lblBaroErrPct.Location = new System.Drawing.Point(12, 56);
            this.lblBaroErrPct.Text = "Barometre Hata (%):";
            this.numBaroErrPct.Location = new System.Drawing.Point(170, 54);
            this.numBaroErrPct.Minimum = -50;
            this.numBaroErrPct.Maximum = 50;
            this.numBaroErrPct.Value = new decimal(new int[] { 20, 0, 0, 0 });

            this.lblImuNoise.Location = new System.Drawing.Point(12, 84);
            this.lblImuNoise.Text = "IMU Titreşim σ (m/s²):";
            this.numImuNoise.Location = new System.Drawing.Point(170, 82);
            this.numImuNoise.DecimalPlaces = 2;
            this.numImuNoise.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numImuNoise.Value = new decimal(new int[] { 8, 0, 0, 131072 });

            // 5. grpBucket
            this.grpBucket.Controls.Add(this.lblFillRate);
            this.grpBucket.Controls.Add(this.numFillRate);
            this.grpBucket.Controls.Add(this.lblLeakRate);
            this.grpBucket.Controls.Add(this.numLeakRate);
            this.grpBucket.Controls.Add(this.lblBucketThresh);
            this.grpBucket.Controls.Add(this.numBucketThresh);
            this.grpBucket.Location = new System.Drawing.Point(8, 572);
            this.grpBucket.Name = "grpBucket";
            this.grpBucket.Size = new System.Drawing.Size(306, 115);
            this.grpBucket.TabIndex = 4;
            this.grpBucket.TabStop = false;
            this.grpBucket.Text = "Sızdıran Kova (Leaky Bucket) Ayarları";

            this.lblFillRate.Location = new System.Drawing.Point(12, 28);
            this.lblFillRate.Text = "Dolum Hızı (R_fill):";
            this.numFillRate.Location = new System.Drawing.Point(170, 26);
            this.numFillRate.DecimalPlaces = 1;
            this.numFillRate.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numFillRate.Value = new decimal(new int[] { 25, 0, 0, 65536 });

            this.lblLeakRate.Location = new System.Drawing.Point(12, 56);
            this.lblLeakRate.Text = "Sızma Hızı (R_leak):";
            this.numLeakRate.Location = new System.Drawing.Point(170, 54);
            this.numLeakRate.DecimalPlaces = 1;
            this.numLeakRate.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numLeakRate.Value = new decimal(new int[] { 12, 0, 0, 65536 });

            this.lblBucketThresh.Location = new System.Drawing.Point(12, 84);
            this.lblBucketThresh.Text = "Mühür Eşiği (TT):";
            this.numBucketThresh.Location = new System.Drawing.Point(170, 82);
            this.numBucketThresh.DecimalPlaces = 1;
            this.numBucketThresh.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numBucketThresh.Value = new decimal(new int[] { 40, 0, 0, 65536 });

            this.btnRunPhysics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnRunPhysics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunPhysics.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRunPhysics.ForeColor = System.Drawing.Color.White;
            this.btnRunPhysics.Location = new System.Drawing.Point(8, 695);
            this.btnRunPhysics.Name = "btnRunPhysics";
            this.btnRunPhysics.Size = new System.Drawing.Size(306, 40);
            this.btnRunPhysics.TabIndex = 5;
            this.btnRunPhysics.Text = "⚡ Fizik Simülasyonu Yeniden Hesapla";
            this.btnRunPhysics.UseVisualStyleBackColor = false;
            this.btnRunPhysics.Click += new System.EventHandler(this.BtnRunPhysics_Click);

            this.panelBucketStatus.BackColor = System.Drawing.Color.White;
            this.panelBucketStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBucketStatus.Controls.Add(this.lblBucketStatusTitle);
            this.panelBucketStatus.Controls.Add(this.lblBucketStatusText);
            this.panelBucketStatus.Controls.Add(this.progBucket);
            this.panelBucketStatus.Location = new System.Drawing.Point(8, 745);
            this.panelBucketStatus.Name = "panelBucketStatus";
            this.panelBucketStatus.Size = new System.Drawing.Size(306, 105);
            this.panelBucketStatus.TabIndex = 6;

            this.lblBucketStatusTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBucketStatusTitle.Location = new System.Drawing.Point(8, 8);
            this.lblBucketStatusTitle.Text = "Sızdıran Kova Canlı Durum İzleyicisi:";
            this.lblBucketStatusTitle.AutoSize = true;

            this.lblBucketStatusText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBucketStatusText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(124)))), ((int)(((byte)(65)))));
            this.lblBucketStatusText.Location = new System.Drawing.Point(8, 32);
            this.lblBucketStatusText.Text = "DURUM: BEKLEMEDE (IDLE)";
            this.lblBucketStatusText.AutoSize = true;

            this.progBucket.Location = new System.Drawing.Point(8, 62);
            this.progBucket.Name = "progBucket";
            this.progBucket.Size = new System.Drawing.Size(286, 24);
            this.progBucket.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progBucket.Value = 0;

            // =========================================================================
            // panelPlayer (Zaman Çizelgesi & Oynatıcı Kontrolleri)
            // =========================================================================
            this.panelPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(248)))));
            this.panelPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPlayer.Controls.Add(this.btnPlayPause);
            this.panelPlayer.Controls.Add(this.btnStepBack);
            this.panelPlayer.Controls.Add(this.btnStepFwd);
            this.panelPlayer.Controls.Add(this.trackTimeline);
            this.panelPlayer.Controls.Add(this.lblCurrentTime);
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayer.Location = new System.Drawing.Point(333, 3);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(1030, 44);
            this.panelPlayer.TabIndex = 5;

            this.btnPlayPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(212)))));
            this.btnPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayPause.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPlayPause.ForeColor = System.Drawing.Color.White;
            this.btnPlayPause.Location = new System.Drawing.Point(8, 6);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(105, 30);
            this.btnPlayPause.TabIndex = 0;
            this.btnPlayPause.Text = "▶ Oynat";
            this.btnPlayPause.UseVisualStyleBackColor = false;
            this.btnPlayPause.Click += new System.EventHandler(this.BtnPlayPause_Click);

            this.btnStepBack.BackColor = System.Drawing.Color.White;
            this.btnStepBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStepBack.Location = new System.Drawing.Point(120, 6);
            this.btnStepBack.Name = "btnStepBack";
            this.btnStepBack.Size = new System.Drawing.Size(85, 30);
            this.btnStepBack.TabIndex = 1;
            this.btnStepBack.Text = "⏮ Geri Al";
            this.btnStepBack.UseVisualStyleBackColor = false;
            this.btnStepBack.Click += new System.EventHandler(this.BtnStepBack_Click);

            this.btnStepFwd.BackColor = System.Drawing.Color.White;
            this.btnStepFwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStepFwd.Location = new System.Drawing.Point(212, 6);
            this.btnStepFwd.Name = "btnStepFwd";
            this.btnStepFwd.Size = new System.Drawing.Size(85, 30);
            this.btnStepFwd.TabIndex = 2;
            this.btnStepFwd.Text = "⏭ İleri Al";
            this.btnStepFwd.UseVisualStyleBackColor = false;
            this.btnStepFwd.Click += new System.EventHandler(this.BtnStepFwd_Click);

            this.trackTimeline.Location = new System.Drawing.Point(305, 6);
            this.trackTimeline.Name = "trackTimeline";
            this.trackTimeline.Size = new System.Drawing.Size(520, 35);
            this.trackTimeline.TabIndex = 3;
            this.trackTimeline.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackTimeline.Scroll += new System.EventHandler(this.TrackTimeline_Scroll);

            this.lblCurrentTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.lblCurrentTime.Location = new System.Drawing.Point(835, 11);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(185, 22);
            this.lblCurrentTime.TabIndex = 4;
            this.lblCurrentTime.Text = "Zaman: 0.00 / 0.00 s";

            // =========================================================================
            // panelLiveDashboard (Canlı Modüler Senaryo & Telemetri Paneli)
            // =========================================================================
            this.panelLiveDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelLiveDashboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLiveDashboard.Controls.Add(this.lblDashState);
            this.panelLiveDashboard.Controls.Add(this.lblDashSubState);
            this.panelLiveDashboard.Controls.Add(this.lblDashPhysics);
            this.panelLiveDashboard.Controls.Add(this.lblDashKinematics);
            this.panelLiveDashboard.Controls.Add(this.lblDashActuators);
            this.panelLiveDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLiveDashboard.Location = new System.Drawing.Point(333, 53);
            this.panelLiveDashboard.Name = "panelLiveDashboard";
            this.panelLiveDashboard.Size = new System.Drawing.Size(1030, 104);
            this.panelLiveDashboard.TabIndex = 6;

            this.lblDashState.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDashState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblDashState.Location = new System.Drawing.Point(12, 8);
            this.lblDashState.Name = "lblDashState";
            this.lblDashState.Size = new System.Drawing.Size(480, 24);
            this.lblDashState.TabIndex = 0;
            this.lblDashState.Text = "ANA HAL: S1: YÜKSELME";

            this.lblDashSubState.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDashSubState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblDashSubState.Location = new System.Drawing.Point(12, 34);
            this.lblDashSubState.Name = "lblDashSubState";
            this.lblDashSubState.Size = new System.Drawing.Size(980, 22);
            this.lblDashSubState.TabIndex = 1;
            this.lblDashSubState.Text = "ALT SENARYO: Roket ile Tepe Noktasına (1800m) Tırmanış";

            this.lblDashPhysics.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblDashPhysics.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDashPhysics.Location = new System.Drawing.Point(12, 58);
            this.lblDashPhysics.Name = "lblDashPhysics";
            this.lblDashPhysics.Size = new System.Drawing.Size(980, 20);
            this.lblDashPhysics.TabIndex = 2;
            this.lblDashPhysics.Text = "FİZİK MODEL: Kütle = 1.80 kg | Paraşüt Alanı = 0.02 m² | Cd = 0.40 | Limit Hız = 0.0 m/s";

            this.lblDashKinematics.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblDashKinematics.ForeColor = System.Drawing.Color.LightGreen;
            this.lblDashKinematics.Location = new System.Drawing.Point(12, 78);
            this.lblDashKinematics.Name = "lblDashKinematics";
            this.lblDashKinematics.Size = new System.Drawing.Size(490, 20);
            this.lblDashKinematics.TabIndex = 3;
            this.lblDashKinematics.Text = "KİNEMATİK: Gerçek İrtifa = 0.0 m | Kestirim = 0.0 m | Hız = 0.0 m/s";

            this.lblDashActuators.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblDashActuators.ForeColor = System.Drawing.Color.LightPink;
            this.lblDashActuators.Location = new System.Drawing.Point(510, 78);
            this.lblDashActuators.Name = "lblDashActuators";
            this.lblDashActuators.Size = new System.Drawing.Size(490, 20);
            this.lblDashActuators.TabIndex = 4;
            this.lblDashActuators.Text = "KONTROL: Motor RPM = 0 | İtki = 0.0 N | Kova Havuz (ACC) = 0.00";

            // plotPhysicsAltitude
            this.plotPhysicsAltitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotPhysicsAltitude.Location = new System.Drawing.Point(334, 164);
            this.plotPhysicsAltitude.Margin = new System.Windows.Forms.Padding(4);
            this.plotPhysicsAltitude.Name = "plotPhysicsAltitude";
            this.plotPhysicsAltitude.Size = new System.Drawing.Size(1028, 524);
            this.plotPhysicsAltitude.TabIndex = 1;

            // panelDualCoreDashboard (Alt Kestirim Çekirdeği Paneli)
            this.panelDualCoreDashboard.ColumnCount = 1;
            this.panelDualCoreDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDualCoreDashboard.Controls.Add(this.grpEkfKernelCore, 0, 0);
            this.panelDualCoreDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDualCoreDashboard.Location = new System.Drawing.Point(334, 692);
            this.panelDualCoreDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.panelDualCoreDashboard.Name = "panelDualCoreDashboard";
            this.panelDualCoreDashboard.RowCount = 1;
            this.panelDualCoreDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelDualCoreDashboard.Size = new System.Drawing.Size(1028, 140);
            this.panelDualCoreDashboard.TabIndex = 2;

            // grpLeakyBucketCore
            this.grpLeakyBucketCore.Controls.Add(this.progBucketCore);
            this.grpLeakyBucketCore.Controls.Add(this.lblBucketCoreStatus);
            this.grpLeakyBucketCore.Controls.Add(this.lblBucketCoreFactors);
            this.grpLeakyBucketCore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLeakyBucketCore.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpLeakyBucketCore.ForeColor = System.Drawing.Color.White;
            this.grpLeakyBucketCore.Location = new System.Drawing.Point(4, 4);
            this.grpLeakyBucketCore.Name = "grpLeakyBucketCore";
            this.grpLeakyBucketCore.Size = new System.Drawing.Size(506, 132);
            this.grpLeakyBucketCore.TabIndex = 0;
            this.grpLeakyBucketCore.TabStop = false;
            this.grpLeakyBucketCore.Text = "🔒 SIZDIRAN KOVA KARAR VE TETİKLEME ÇEKİRDEĞİ";

            // progBucketCore
            this.progBucketCore.Location = new System.Drawing.Point(12, 24);
            this.progBucketCore.Name = "progBucketCore";
            this.progBucketCore.Size = new System.Drawing.Size(482, 22);
            this.progBucketCore.TabIndex = 0;

            // lblBucketCoreStatus
            this.lblBucketCoreStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBucketCoreStatus.ForeColor = System.Drawing.Color.LightGreen;
            this.lblBucketCoreStatus.Location = new System.Drawing.Point(12, 50);
            this.lblBucketCoreStatus.Name = "lblBucketCoreStatus";
            this.lblBucketCoreStatus.Size = new System.Drawing.Size(482, 22);
            this.lblBucketCoreStatus.TabIndex = 1;
            this.lblBucketCoreStatus.Text = "🟢 BEKLEMEDE (ACC = 0.00 / 4.50)";

            // lblBucketCoreFactors
            this.lblBucketCoreFactors.Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Regular);
            this.lblBucketCoreFactors.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblBucketCoreFactors.Location = new System.Drawing.Point(12, 74);
            this.lblBucketCoreFactors.Name = "lblBucketCoreFactors";
            this.lblBucketCoreFactors.Size = new System.Drawing.Size(482, 50);
            this.lblBucketCoreFactors.TabIndex = 2;
            this.lblBucketCoreFactors.Text = "Etkileyen Faktörler: İrtifa eşiği ve sızıntı hızı bekleniyor...";

            // grpEkfKernelCore
            this.grpEkfKernelCore.Controls.Add(this.picEkfStackedBar);
            this.grpEkfKernelCore.Controls.Add(this.lblEkfTrustDetails);
            this.grpEkfKernelCore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEkfKernelCore.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpEkfKernelCore.ForeColor = System.Drawing.Color.White;
            this.grpEkfKernelCore.Location = new System.Drawing.Point(518, 4);
            this.grpEkfKernelCore.Name = "grpEkfKernelCore";
            this.grpEkfKernelCore.Size = new System.Drawing.Size(506, 132);
            this.grpEkfKernelCore.TabIndex = 1;
            this.grpEkfKernelCore.TabStop = false;
            this.grpEkfKernelCore.Text = "🧠 ADAPTİF KALMAN FİLTRESİ (CANLI SENSÖR GÜVEN DAĞILIMI)";

            // picEkfStackedBar
            this.picEkfStackedBar.Location = new System.Drawing.Point(12, 24);
            this.picEkfStackedBar.Name = "picEkfStackedBar";
            this.picEkfStackedBar.Size = new System.Drawing.Size(482, 26);
            this.picEkfStackedBar.TabIndex = 0;
            this.picEkfStackedBar.TabStop = false;
            this.picEkfStackedBar.Paint += new System.Windows.Forms.PaintEventHandler(this.PicEkfStackedBar_Paint);

            // lblEkfTrustDetails
            this.lblEkfTrustDetails.Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Regular);
            this.lblEkfTrustDetails.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEkfTrustDetails.Location = new System.Drawing.Point(12, 55);
            this.lblEkfTrustDetails.Name = "lblEkfTrustDetails";
            this.lblEkfTrustDetails.Size = new System.Drawing.Size(482, 70);
            this.lblEkfTrustDetails.TabIndex = 1;
            this.lblEkfTrustDetails.Text = "🔵 Barometre: %52.0  |  🟠 İvmeölçer (IMU): %33.0  |  🟢 Fizik Model: %15.0";

            // timerPlayback
            this.timerPlayback.Interval = 50;
            this.timerPlayback.Tick += new System.EventHandler(this.TimerPlayback_Tick);

            // FormSensorAnalizi
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1380, 880);
            this.Controls.Add(this.tabMain);
            this.MinimumSize = new System.Drawing.Size(1150, 720);
            this.Name = "FormSensorAnalizi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÜRKSAT Model Uydu 2026 - RASAT #801470 Uçuş ve Hatalı Tetikleme Analiz Platformu";

            this.tabMain.ResumeLayout(false);
            this.tabPageCompare.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            this.topControlPanel.ResumeLayout(false);
            this.grpCustomSim.ResumeLayout(false);
            this.grpCustomSim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numErrorPercent)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetrics)).EndInit();
            this.btnPanel.ResumeLayout(false);

            this.tabPagePhysics.ResumeLayout(false);
            this.physicsLayout.ResumeLayout(false);
            this.panelPhysicsParams.ResumeLayout(false);
            
            this.grpMassAero.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMassCarrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMassPayload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAreaCarrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAreaPayload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAreaApam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAirDensity)).EndInit();

            this.grpMission.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numHoverDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoverAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSeparationAlt)).EndInit();

            this.grpPID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numKp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKd)).EndInit();
            this.grpNoise.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBaroNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBaroErrPct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImuNoise)).EndInit();
            this.grpBucket.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFillRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeakRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBucketThresh)).EndInit();
            this.panelBucketStatus.ResumeLayout(false);
            this.panelBucketStatus.PerformLayout();
            this.panelPlayer.ResumeLayout(false);
            this.panelPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackTimeline)).EndInit();
            this.panelLiveDashboard.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageCompare;
        private System.Windows.Forms.TabPage tabPagePhysics;

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private ScottPlot.WinForms.FormsPlot plotAltitude;
        private ScottPlot.WinForms.FormsPlot plotVelocity;
        private System.Windows.Forms.Panel topControlPanel;
        private System.Windows.Forms.GroupBox grpCustomSim;
        private System.Windows.Forms.Label lblErrorPercent;
        private System.Windows.Forms.NumericUpDown numErrorPercent;
        private System.Windows.Forms.CheckBox chkUseFusion;
        private System.Windows.Forms.Button btnRunCustom;
        private System.Windows.Forms.Button btnRunAllCompare;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.DataGridView dgvMetrics;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScenario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScaleError;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFusion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImpactVel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLandingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEvaluation;
        private System.Windows.Forms.Panel btnPanel;
        private System.Windows.Forms.Button btnExportPng;

        // Tab 2 Kontrolleri
        private System.Windows.Forms.TableLayoutPanel physicsLayout;
        private System.Windows.Forms.Panel panelPhysicsParams;

        private System.Windows.Forms.GroupBox grpMassAero;
        private System.Windows.Forms.Label lblMassCarrier;
        private System.Windows.Forms.NumericUpDown numMassCarrier;
        private System.Windows.Forms.Label lblMassPayload;
        private System.Windows.Forms.NumericUpDown numMassPayload;
        private System.Windows.Forms.Label lblAreaCarrier;
        private System.Windows.Forms.NumericUpDown numAreaCarrier;
        private System.Windows.Forms.Label lblAreaPayload;
        private System.Windows.Forms.NumericUpDown numAreaPayload;
        private System.Windows.Forms.Label lblAreaApam;
        private System.Windows.Forms.NumericUpDown numAreaApam;
        private System.Windows.Forms.Label lblAirDensity;
        private System.Windows.Forms.NumericUpDown numAirDensity;

        private System.Windows.Forms.GroupBox grpMission;
        private System.Windows.Forms.Label lblHoverDuration;
        private System.Windows.Forms.NumericUpDown numHoverDuration;
        private System.Windows.Forms.Label lblHoverAltitude;
        private System.Windows.Forms.NumericUpDown numHoverAltitude;
        private System.Windows.Forms.Label lblSeparationAlt;
        private System.Windows.Forms.NumericUpDown numSeparationAlt;

        private System.Windows.Forms.GroupBox grpPID;
        private System.Windows.Forms.Label lblKp;
        private System.Windows.Forms.NumericUpDown numKp;
        private System.Windows.Forms.Label lblKi;
        private System.Windows.Forms.NumericUpDown numKi;
        private System.Windows.Forms.Label lblKd;
        private System.Windows.Forms.NumericUpDown numKd;

        private System.Windows.Forms.GroupBox grpNoise;
        private System.Windows.Forms.Label lblBaroNoise;
        private System.Windows.Forms.NumericUpDown numBaroNoise;
        private System.Windows.Forms.Label lblBaroErrPct;
        private System.Windows.Forms.NumericUpDown numBaroErrPct;
        private System.Windows.Forms.Label lblImuNoise;
        private System.Windows.Forms.NumericUpDown numImuNoise;

        private System.Windows.Forms.GroupBox grpBucket;
        private System.Windows.Forms.Label lblFillRate;
        private System.Windows.Forms.NumericUpDown numFillRate;
        private System.Windows.Forms.Label lblLeakRate;
        private System.Windows.Forms.NumericUpDown numLeakRate;
        private System.Windows.Forms.Label lblBucketThresh;
        private System.Windows.Forms.NumericUpDown numBucketThresh;

        private System.Windows.Forms.Button btnRunPhysics;
        private System.Windows.Forms.Panel panelBucketStatus;
        private System.Windows.Forms.Label lblBucketStatusTitle;
        private System.Windows.Forms.Label lblBucketStatusText;
        private System.Windows.Forms.ProgressBar progBucket;

        // Oynatıcı Kontrolleri
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnStepBack;
        private System.Windows.Forms.Button btnStepFwd;
        private System.Windows.Forms.TrackBar trackTimeline;
        private System.Windows.Forms.Label lblCurrentTime;

        // Canlı Gösterge Paneli
        private System.Windows.Forms.Panel panelLiveDashboard;
        private System.Windows.Forms.Label lblDashState;
        private System.Windows.Forms.Label lblDashSubState;
        private System.Windows.Forms.Label lblDashPhysics;
        private System.Windows.Forms.Label lblDashKinematics;
        private System.Windows.Forms.Label lblDashActuators;

        private ScottPlot.WinForms.FormsPlot plotPhysicsAltitude;
        private System.Windows.Forms.TableLayoutPanel panelDualCoreDashboard;
        private System.Windows.Forms.GroupBox grpLeakyBucketCore;
        private System.Windows.Forms.ProgressBar progBucketCore;
        private System.Windows.Forms.Label lblBucketCoreStatus;
        private System.Windows.Forms.Label lblBucketCoreFactors;
        private System.Windows.Forms.GroupBox grpEkfKernelCore;
        private System.Windows.Forms.PictureBox picEkfStackedBar;
        private System.Windows.Forms.Label lblEkfTrustDetails;
        private System.Windows.Forms.Timer timerPlayback;
    }
}
