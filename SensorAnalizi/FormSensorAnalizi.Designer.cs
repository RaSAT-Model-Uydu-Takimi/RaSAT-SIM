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
            components = new System.ComponentModel.Container();
            tabMain = new TabControl();
            tabPagePhysics = new TabPage();
            physicsLayout = new TableLayoutPanel();
            panelPhysicsParams = new FlowLayoutPanel();
            grpMassAero = new GroupBox();
            chkToggleMassAero = new CheckBox();
            lblMassCarrier = new Label();
            numMassCarrier = new NumericUpDown();
            lblMassPayload = new Label();
            numMassPayload = new NumericUpDown();
            lblAreaCarrier = new Label();
            numAreaCarrier = new NumericUpDown();
            lblAreaPayload = new Label();
            numAreaPayload = new NumericUpDown();
            lblAreaApam = new Label();
            numAreaApam = new NumericUpDown();
            lblAirDensity = new Label();
            numAirDensity = new NumericUpDown();
            btnResetMassAero = new Button();
            grpMission = new GroupBox();
            chkToggleMission = new CheckBox();
            lblHoverDuration = new Label();
            numHoverDuration = new NumericUpDown();
            lblHoverAltitude = new Label();
            numHoverAltitude = new NumericUpDown();
            lblSeparationAlt = new Label();
            numSeparationAlt = new NumericUpDown();
            btnResetMission = new Button();
            grpPID = new GroupBox();
            chkTogglePID = new CheckBox();
            lblKp = new Label();
            numKp = new NumericUpDown();
            lblKi = new Label();
            numKi = new NumericUpDown();
            lblKd = new Label();
            numKd = new NumericUpDown();
            btnResetPID = new Button();
            grpNoise = new GroupBox();
            chkToggleNoise = new CheckBox();
            lblBaroBias = new Label();
            numBaroBias = new NumericUpDown();
            lblBaroNoise = new Label();
            numBaroNoise = new NumericUpDown();
            lblBaroErrPct = new Label();
            numBaroErrPct = new NumericUpDown();
            lblBaroSpikeStd = new Label();
            numBaroSpikeStd = new NumericUpDown();
            lblBaroSpikeFreq = new Label();
            numBaroSpikeFreq = new NumericUpDown();
            lblImuBias = new Label();
            numImuBias = new NumericUpDown();
            lblImuNoise = new Label();
            numImuNoise = new NumericUpDown();
            lblImuSpikeStd = new Label();
            numImuSpikeStd = new NumericUpDown();
            lblImuSpikeFreq = new Label();
            numImuSpikeFreq = new NumericUpDown();
            lblImuVib = new Label();
            numImuVib = new NumericUpDown();
            btnResetNoise = new Button();
            grpBucket = new GroupBox();
            chkToggleBucket = new CheckBox();
            lblFillRate = new Label();
            numFillRate = new NumericUpDown();
            lblLeakRate = new Label();
            numLeakRate = new NumericUpDown();
            lblBucketThresh = new Label();
            numBucketThresh = new NumericUpDown();
            btnResetBucket = new Button();
            btnRunPhysics = new Button();
            panelPlayer = new Panel();
            btnPlayPause = new Button();
            btnStepBack = new Button();
            btnStepFwd = new Button();
            trackTimeline = new TrackBar();
            lblCurrentTime = new Label();
            panelLiveDashboard = new Panel();
            lblDashState = new Label();
            lblDashSubState = new Label();
            lblDashPhysics = new Label();
            lblDashKinematics = new Label();
            lblDashActuators = new Label();
            plotPhysicsAltitude = new ScottPlot.WinForms.FormsPlot();
            panelPhysicsPlotsTable = new TableLayoutPanel();
            plotPhysicsVelocity = new ScottPlot.WinForms.FormsPlot();
            plotPhysicsAccel = new ScottPlot.WinForms.FormsPlot();
            panelDualCoreDashboard = new TableLayoutPanel();
            grpEkfKernelCore = new GroupBox();
            picEkfStackedBar = new PictureBox();
            lblEkfTrustDetails = new Label();
            grpLeakyBucketCore = new GroupBox();

            btnManualSeparate = new Button();

            btnManualParachute = new Button();

            btnManualHover = new Button();

            btnManualLanding = new Button();
            progBucketCore = new ProgressBar();
            lblBucketCoreStatus = new Label();
            lblBucketCoreFactors = new Label();
            panelBucketCommands = new FlowLayoutPanel();
            btnCmdSeparate = new Button();
            btnCmdDeployParachute = new Button();
            btnCmdHover = new Button();
            btnCmdResetBucket = new Button();
            tabPageCompare = new TabPage();
            mainLayout = new TableLayoutPanel();
            topControlPanel = new Panel();
            grpCustomSim = new GroupBox();
            lblErrorPercent = new Label();
            numErrorPercent = new NumericUpDown();
            chkUseFusion = new CheckBox();
            btnRunCustom = new Button();
            btnRunAllCompare = new Button();
            plotAltitude = new ScottPlot.WinForms.FormsPlot();
            plotVelocity = new ScottPlot.WinForms.FormsPlot();
            bottomPanel = new Panel();
            dgvMetrics = new DataGridView();
            colScenario = new DataGridViewTextBoxColumn();
            colScaleError = new DataGridViewTextBoxColumn();
            colFusion = new DataGridViewTextBoxColumn();
            colImpactVel = new DataGridViewTextBoxColumn();
            colLandingTime = new DataGridViewTextBoxColumn();
            colEvaluation = new DataGridViewTextBoxColumn();
            btnPanel = new Panel();
            btnExportPng = new Button();
            timerPlayback = new System.Windows.Forms.Timer(components);
            tabMain.SuspendLayout();
            tabPagePhysics.SuspendLayout();
            physicsLayout.SuspendLayout();
            panelPhysicsParams.SuspendLayout();
            grpMassAero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMassCarrier).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMassPayload).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAreaCarrier).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAreaPayload).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAreaApam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAirDensity).BeginInit();
            grpMission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHoverDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHoverAltitude).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSeparationAlt).BeginInit();
            grpPID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numKp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKd).BeginInit();
            grpNoise.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBaroBias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBaroNoise).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBaroErrPct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBaroSpikeStd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBaroSpikeFreq).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numImuBias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numImuNoise).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numImuSpikeStd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numImuSpikeFreq).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numImuVib).BeginInit();
            grpBucket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFillRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numLeakRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBucketThresh).BeginInit();
            panelPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackTimeline).BeginInit();
            panelLiveDashboard.SuspendLayout();
            panelPhysicsPlotsTable.SuspendLayout();
            panelDualCoreDashboard.SuspendLayout();
            grpEkfKernelCore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picEkfStackedBar).BeginInit();
            grpLeakyBucketCore.SuspendLayout();
            panelBucketCommands.SuspendLayout();
            tabPageCompare.SuspendLayout();
            mainLayout.SuspendLayout();
            topControlPanel.SuspendLayout();
            grpCustomSim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numErrorPercent).BeginInit();
            bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMetrics).BeginInit();
            btnPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Controls.Add(tabPagePhysics);
            tabMain.Dock = DockStyle.Fill;
            tabMain.Font = new Font("Segoe UI", 9.5F);
            tabMain.Location = new Point(0, 0);
            tabMain.Margin = new Padding(4, 5, 4, 5);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1971, 1410);
            tabMain.TabIndex = 0;
            // 
            // tabPagePhysics
            // 
            tabPagePhysics.Controls.Add(physicsLayout);
            tabPagePhysics.Location = new Point(4, 34);
            tabPagePhysics.Margin = new Padding(4, 5, 4, 5);
            tabPagePhysics.Name = "tabPagePhysics";
            tabPagePhysics.Padding = new Padding(4, 5, 4, 5);
            tabPagePhysics.Size = new Size(1963, 1372);
            tabPagePhysics.TabIndex = 1;
            tabPagePhysics.Text = "🎬 Dikey Fizik Motoru & Zaman Oynatıcı + Modüler Alt-Senaryolar";
            tabPagePhysics.UseVisualStyleBackColor = true;
            // 
            // physicsLayout
            // 
            physicsLayout.ColumnCount = 2;
            physicsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 471F));
            physicsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            physicsLayout.Controls.Add(panelPhysicsParams, 0, 0);
            physicsLayout.Controls.Add(panelPlayer, 1, 0);
            physicsLayout.Controls.Add(panelLiveDashboard, 1, 1);
            physicsLayout.Controls.Add(panelDualCoreDashboard, 1, 2);
            physicsLayout.Controls.Add(panelPhysicsPlotsTable, 1, 3);
            physicsLayout.Dock = DockStyle.Fill;
            physicsLayout.Location = new Point(4, 5);
            physicsLayout.Margin = new Padding(4, 5, 4, 5);
            physicsLayout.Name = "physicsLayout";
            physicsLayout.RowCount = 4;
            physicsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 83F));
            physicsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 183F));
            physicsLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 260F));
            physicsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            physicsLayout.Size = new Size(1955, 1362);
            physicsLayout.TabIndex = 0;
            // 
            // panelPhysicsParams
            // 
            panelPhysicsParams.AutoScroll = true;
            panelPhysicsParams.BackColor = Color.FromArgb(248, 250, 252);
            panelPhysicsParams.Controls.Add(grpMassAero);
            panelPhysicsParams.Controls.Add(grpMission);
            panelPhysicsParams.Controls.Add(grpPID);
            panelPhysicsParams.Controls.Add(grpNoise);
            panelPhysicsParams.Controls.Add(grpBucket);
            panelPhysicsParams.Controls.Add(btnRunPhysics);
            panelPhysicsParams.Dock = DockStyle.Fill;
            panelPhysicsParams.FlowDirection = FlowDirection.TopDown;
            panelPhysicsParams.Location = new Point(4, 5);
            panelPhysicsParams.Margin = new Padding(4, 5, 4, 5);
            panelPhysicsParams.Name = "panelPhysicsParams";
            panelPhysicsParams.Padding = new Padding(9, 10, 9, 10);
            physicsLayout.SetRowSpan(panelPhysicsParams, 4);
            panelPhysicsParams.Size = new Size(463, 1352);
            panelPhysicsParams.TabIndex = 0;
            panelPhysicsParams.WrapContents = false;
            // 
            // grpMassAero
            // 
            grpMassAero.Controls.Add(btnResetMassAero);
            grpMassAero.Controls.Add(chkToggleMassAero);
            grpMassAero.Controls.Add(lblMassCarrier);
            grpMassAero.Controls.Add(numMassCarrier);
            grpMassAero.Controls.Add(lblMassPayload);
            grpMassAero.Controls.Add(numMassPayload);
            grpMassAero.Controls.Add(lblAreaCarrier);
            grpMassAero.Controls.Add(numAreaCarrier);
            grpMassAero.Controls.Add(lblAreaPayload);
            grpMassAero.Controls.Add(numAreaPayload);
            grpMassAero.Controls.Add(lblAreaApam);
            grpMassAero.Controls.Add(numAreaApam);
            grpMassAero.Controls.Add(lblAirDensity);
            grpMassAero.Controls.Add(numAirDensity);
            grpMassAero.Location = new Point(13, 15);
            grpMassAero.Margin = new Padding(4, 5, 4, 5);
            grpMassAero.Name = "grpMassAero";
            grpMassAero.Padding = new Padding(4, 5, 4, 5);
            grpMassAero.Size = new Size(437, 325);
            grpMassAero.TabIndex = 0;
            grpMassAero.TabStop = false;
            grpMassAero.Text = "Kütle (kg) & Paraşüt Yüzey Alanları (m²)";
            // 
            // btnResetMassAero
            // 
            btnResetMassAero.Location = new Point(222, 0);
            btnResetMassAero.Name = "btnResetMassAero";
            btnResetMassAero.Size = new Size(82, 33);
            btnResetMassAero.TabIndex = 15;
            btnResetMassAero.Text = "↺ Sıfırla";
            btnResetMassAero.FlatStyle = FlatStyle.Flat;
            btnResetMassAero.BackColor = Color.FromArgb(60, 60, 60);
            btnResetMassAero.ForeColor = Color.Gold;
            btnResetMassAero.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnResetMassAero.Click += BtnResetMassAero_Click;
            // 
            // chkToggleMassAero
            // 
            chkToggleMassAero.Location = new Point(307, 0);
            chkToggleMassAero.Margin = new Padding(4, 5, 4, 5);
            chkToggleMassAero.Name = "chkToggleMassAero";
            chkToggleMassAero.Size = new Size(121, 33);
            chkToggleMassAero.TabIndex = 0;
            chkToggleMassAero.Text = "▼ Aç/Gizle";
            // 
            // lblMassCarrier
            // 
            lblMassCarrier.Location = new Point(17, 42);
            lblMassCarrier.Margin = new Padding(4, 0, 4, 0);
            lblMassCarrier.Name = "lblMassCarrier";
            lblMassCarrier.Size = new Size(143, 38);
            lblMassCarrier.TabIndex = 1;
            lblMassCarrier.Text = "Taşıyıcı Kütle (kg):";
            // 
            // numMassCarrier
            // 
            numMassCarrier.DecimalPlaces = 2;
            numMassCarrier.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numMassCarrier.Location = new Point(243, 38);
            numMassCarrier.Margin = new Padding(4, 5, 4, 5);
            numMassCarrier.Name = "numMassCarrier";
            numMassCarrier.Size = new Size(171, 33);
            numMassCarrier.TabIndex = 2;
            numMassCarrier.Value = new decimal(new int[] { 55, 0, 0, 131072 });
            // 
            // lblMassPayload
            // 
            lblMassPayload.Location = new Point(17, 87);
            lblMassPayload.Margin = new Padding(4, 0, 4, 0);
            lblMassPayload.Name = "lblMassPayload";

            lblMassPayload.Size = new Size(143, 38);
            lblMassPayload.TabIndex = 3;
            lblMassPayload.Text = "Görev Yükü Kütle (kg):";
            // 
            // numMassPayload
            // 
            numMassPayload.DecimalPlaces = 2;
            numMassPayload.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numMassPayload.Location = new Point(243, 83);
            numMassPayload.Margin = new Padding(4, 5, 4, 5);
            numMassPayload.Name = "numMassPayload";
            numMassPayload.Size = new Size(171, 33);
            numMassPayload.TabIndex = 4;
            numMassPayload.Value = new decimal(new int[] { 125, 0, 0, 131072 });
            // 
            // lblAreaCarrier
            // 
            lblAreaCarrier.Location = new Point(17, 132);
            lblAreaCarrier.Margin = new Padding(4, 0, 4, 0);
            lblAreaCarrier.Name = "lblAreaCarrier";
            lblAreaCarrier.Size = new Size(143, 38);
            lblAreaCarrier.TabIndex = 5;
            lblAreaCarrier.Text = "Ana Paraşüt Alanı (m²):";
            // 
            // numAreaCarrier
            // 
            numAreaCarrier.DecimalPlaces = 4;
            numAreaCarrier.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numAreaCarrier.Location = new Point(243, 128);
            numAreaCarrier.Margin = new Padding(4, 5, 4, 5);
            numAreaCarrier.Name = "numAreaCarrier";
            numAreaCarrier.Size = new Size(171, 33);
            numAreaCarrier.TabIndex = 6;
            numAreaCarrier.Value = new decimal(new int[] { 1256, 0, 0, 262144 });
            // 
            // lblAreaPayload
            // 
            lblAreaPayload.Location = new Point(17, 177);
            lblAreaPayload.Margin = new Padding(4, 0, 4, 0);
            lblAreaPayload.Name = "lblAreaPayload";
            lblAreaPayload.Size = new Size(143, 38);
            lblAreaPayload.TabIndex = 7;
            lblAreaPayload.Text = "Görev Yükü Alanı (m²):";
            // 
            // numAreaPayload
            // 
            numAreaPayload.DecimalPlaces = 4;
            numAreaPayload.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numAreaPayload.Location = new Point(243, 173);
            numAreaPayload.Margin = new Padding(4, 5, 4, 5);
            numAreaPayload.Name = "numAreaPayload";
            numAreaPayload.Size = new Size(171, 33);
            numAreaPayload.TabIndex = 8;
            numAreaPayload.Value = new decimal(new int[] { 804, 0, 0, 262144 });
            // 
            // lblAreaApam
            // 
            lblAreaApam.Location = new Point(17, 222);
            lblAreaApam.Margin = new Padding(4, 0, 4, 0);
            lblAreaApam.Name = "lblAreaApam";
            lblAreaApam.Size = new Size(143, 38);
            lblAreaApam.TabIndex = 9;
            lblAreaApam.Text = "APAM Paraşüt Alanı (m²):";
            // 
            // numAreaApam
            // 
            numAreaApam.DecimalPlaces = 4;
            numAreaApam.Increment = new decimal(new int[] { 2, 0, 0, 131072 });
            numAreaApam.Location = new Point(243, 218);
            numAreaApam.Margin = new Padding(4, 5, 4, 5);
            numAreaApam.Name = "numAreaApam";
            numAreaApam.Size = new Size(171, 33);
            numAreaApam.TabIndex = 10;
            numAreaApam.Value = new decimal(new int[] { 5026, 0, 0, 262144 });
            // 
            // lblAirDensity
            // 
            lblAirDensity.Location = new Point(17, 267);
            lblAirDensity.Margin = new Padding(4, 0, 4, 0);
            lblAirDensity.Name = "lblAirDensity";
            lblAirDensity.Size = new Size(143, 38);
            lblAirDensity.TabIndex = 11;
            lblAirDensity.Text = "Hava Yoğunluğu (kg/m³):";
            // 
            // numAirDensity
            // 
            numAirDensity.DecimalPlaces = 2;
            numAirDensity.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numAirDensity.Location = new Point(243, 263);
            numAirDensity.Margin = new Padding(4, 5, 4, 5);
            numAirDensity.Name = "numAirDensity";
            numAirDensity.Size = new Size(171, 33);
            numAirDensity.TabIndex = 12;
            numAirDensity.Value = new decimal(new int[] { 110, 0, 0, 131072 });
            // 
            // grpMission
            // 
            grpMission.Controls.Add(btnResetMission);
            grpMission.Controls.Add(chkToggleMission);
            grpMission.Controls.Add(lblHoverDuration);
            grpMission.Controls.Add(numHoverDuration);
            grpMission.Controls.Add(lblHoverAltitude);
            grpMission.Controls.Add(numHoverAltitude);
            grpMission.Controls.Add(lblSeparationAlt);
            grpMission.Controls.Add(numSeparationAlt);
            grpMission.Location = new Point(13, 350);
            grpMission.Margin = new Padding(4, 5, 4, 5);
            grpMission.Name = "grpMission";
            grpMission.Padding = new Padding(4, 5, 4, 5);
            grpMission.Size = new Size(437, 192);
            grpMission.TabIndex = 1;
            grpMission.TabStop = false;
            grpMission.Text = "Görev Süreleri & Hedef İrtifalar";
            // 
            // btnResetMission
            // 
            btnResetMission.Location = new Point(222, 0);
            btnResetMission.Name = "btnResetMission";
            btnResetMission.Size = new Size(82, 33);
            btnResetMission.TabIndex = 15;
            btnResetMission.Text = "↺ Sıfırla";
            btnResetMission.FlatStyle = FlatStyle.Flat;
            btnResetMission.BackColor = Color.FromArgb(60, 60, 60);
            btnResetMission.ForeColor = Color.Gold;
            btnResetMission.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnResetMission.Click += BtnResetMission_Click;
            // 
            // chkToggleMission
            // 
            chkToggleMission.Location = new Point(307, 0);
            chkToggleMission.Margin = new Padding(4, 5, 4, 5);
            chkToggleMission.Name = "chkToggleMission";
            chkToggleMission.Size = new Size(121, 33);
            chkToggleMission.TabIndex = 0;
            chkToggleMission.Text = "▼ Aç/Gizle";
            // 
            // lblHoverDuration
            // 
            lblHoverDuration.Location = new Point(17, 47);
            lblHoverDuration.Margin = new Padding(4, 0, 4, 0);
            lblHoverDuration.Name = "lblHoverDuration";
            lblHoverDuration.Size = new Size(143, 38);
            lblHoverDuration.TabIndex = 1;
            lblHoverDuration.Text = "S4b Hover Süresi (sn):";
            // 
            // numHoverDuration
            // 
            numHoverDuration.DecimalPlaces = 1;
            numHoverDuration.Location = new Point(243, 43);
            numHoverDuration.Margin = new Padding(4, 5, 4, 5);
            numHoverDuration.Name = "numHoverDuration";
            numHoverDuration.Size = new Size(171, 33);
            numHoverDuration.TabIndex = 2;
            numHoverDuration.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblHoverAltitude
            // 
            lblHoverAltitude.Location = new Point(17, 93);
            lblHoverAltitude.Margin = new Padding(4, 0, 4, 0);
            lblHoverAltitude.Name = "lblHoverAltitude";
            lblHoverAltitude.Size = new Size(143, 38);
            lblHoverAltitude.TabIndex = 3;
            lblHoverAltitude.Text = "S4b Hover İrtifası (m):";
            // 
            // numHoverAltitude
            // 
            numHoverAltitude.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numHoverAltitude.Location = new Point(243, 90);
            numHoverAltitude.Margin = new Padding(4, 5, 4, 5);
            numHoverAltitude.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numHoverAltitude.Name = "numHoverAltitude";
            numHoverAltitude.Size = new Size(171, 33);
            numHoverAltitude.TabIndex = 4;
            numHoverAltitude.Value = new decimal(new int[] { 200, 0, 0, 0 });
            // 
            // lblSeparationAlt
            // 
            lblSeparationAlt.Location = new Point(17, 140);
            lblSeparationAlt.Margin = new Padding(4, 0, 4, 0);
            lblSeparationAlt.Name = "lblSeparationAlt";
            lblSeparationAlt.Size = new Size(143, 38);
            lblSeparationAlt.TabIndex = 5;
            lblSeparationAlt.Text = "S3 Ayrılma İrtifası (m):";
            // 
            // numSeparationAlt
            // 
            numSeparationAlt.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numSeparationAlt.Location = new Point(243, 137);
            numSeparationAlt.Margin = new Padding(4, 5, 4, 5);
            numSeparationAlt.Maximum = new decimal(new int[] { 1800, 0, 0, 0 });
            numSeparationAlt.Name = "numSeparationAlt";
            numSeparationAlt.Size = new Size(171, 33);
            numSeparationAlt.TabIndex = 6;
            numSeparationAlt.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // grpPID
            // 
            grpPID.Controls.Add(btnResetPID);
            grpPID.Controls.Add(chkTogglePID);
            grpPID.Controls.Add(lblKp);
            grpPID.Controls.Add(numKp);
            grpPID.Controls.Add(lblKi);
            grpPID.Controls.Add(numKi);
            grpPID.Controls.Add(lblKd);
            grpPID.Controls.Add(numKd);
            grpPID.Location = new Point(13, 552);
            grpPID.Margin = new Padding(4, 5, 4, 5);
            grpPID.Name = "grpPID";
            grpPID.Padding = new Padding(4, 5, 4, 5);
            grpPID.Size = new Size(437, 192);
            grpPID.TabIndex = 2;
            grpPID.TabStop = false;
            grpPID.Text = "Dikey PID Kontrol Katsayıları";
            // 
            // btnResetPID
            // 
            btnResetPID.Location = new Point(222, 0);
            btnResetPID.Name = "btnResetPID";
            btnResetPID.Size = new Size(82, 33);
            btnResetPID.TabIndex = 15;
            btnResetPID.Text = "↺ Sıfırla";
            btnResetPID.FlatStyle = FlatStyle.Flat;
            btnResetPID.BackColor = Color.FromArgb(60, 60, 60);
            btnResetPID.ForeColor = Color.Gold;
            btnResetPID.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnResetPID.Click += BtnResetPID_Click;
            // 
            // chkTogglePID
            // 
            chkTogglePID.Location = new Point(307, 0);
            chkTogglePID.Margin = new Padding(4, 5, 4, 5);
            chkTogglePID.Name = "chkTogglePID";
            chkTogglePID.Size = new Size(121, 33);
            chkTogglePID.TabIndex = 0;
            chkTogglePID.Text = "▼ Aç/Gizle";
            // 
            // lblKp
            // 
            lblKp.Location = new Point(17, 47);
            lblKp.Margin = new Padding(4, 0, 4, 0);
            lblKp.Name = "lblKp";
            lblKp.Size = new Size(143, 38);
            lblKp.TabIndex = 1;
            lblKp.Text = "Kp (Orantısal):";
            // 
            // numKp
            // 
            numKp.DecimalPlaces = 2;
            numKp.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numKp.Location = new Point(243, 43);
            numKp.Margin = new Padding(4, 5, 4, 5);
            numKp.Name = "numKp";

            numKp.Size = new Size(171, 33);
            numKp.TabIndex = 2;
            numKp.Value = new decimal(new int[] { 35, 0, 0, 65536 });
            // 
            // lblKi
            // 
            lblKi.Location = new Point(17, 93);
            lblKi.Margin = new Padding(4, 0, 4, 0);
            lblKi.Name = "lblKi";
            lblKi.Size = new Size(143, 38);
            lblKi.TabIndex = 3;
            lblKi.Text = "Ki (İntegral):";
            // 
            // numKi
            // 
            numKi.DecimalPlaces = 2;
            numKi.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numKi.Location = new Point(243, 90);
            numKi.Margin = new Padding(4, 5, 4, 5);
            numKi.Name = "numKi";
            numKi.Size = new Size(171, 33);
            numKi.TabIndex = 4;
            numKi.Value = new decimal(new int[] { 4, 0, 0, 65536 });
            // 
            // lblKd
            // 
            lblKd.Location = new Point(17, 140);
            lblKd.Margin = new Padding(4, 0, 4, 0);
            lblKd.Name = "lblKd";
            lblKd.Size = new Size(143, 38);
            lblKd.TabIndex = 5;
            lblKd.Text = "Kd (Türevsel):";
            // 
            // numKd
            // 
            numKd.DecimalPlaces = 2;
            numKd.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numKd.Location = new Point(243, 137);
            numKd.Margin = new Padding(4, 5, 4, 5);
            numKd.Name = "numKd";
            numKd.Size = new Size(171, 33);
            numKd.TabIndex = 6;
            numKd.Value = new decimal(new int[] { 42, 0, 0, 65536 });
            // 
            // grpNoise
            // 
            grpNoise.Controls.Add(btnResetNoise);

            grpNoise.Controls.Add(chkToggleNoise);
            grpNoise.Controls.Add(lblBaroBias);
            grpNoise.Controls.Add(numBaroBias);
            grpNoise.Controls.Add(lblBaroNoise);
            grpNoise.Controls.Add(numBaroNoise);
            grpNoise.Controls.Add(lblBaroErrPct);
            grpNoise.Controls.Add(numBaroErrPct);
            grpNoise.Controls.Add(lblBaroSpikeStd);
            grpNoise.Controls.Add(numBaroSpikeStd);
            grpNoise.Controls.Add(lblBaroSpikeFreq);
            grpNoise.Controls.Add(numBaroSpikeFreq);
            grpNoise.Controls.Add(lblImuBias);
            grpNoise.Controls.Add(numImuBias);
            grpNoise.Controls.Add(lblImuNoise);
            grpNoise.Controls.Add(numImuNoise);
            grpNoise.Controls.Add(lblImuSpikeStd);
            grpNoise.Controls.Add(numImuSpikeStd);
            grpNoise.Controls.Add(lblImuSpikeFreq);
            grpNoise.Controls.Add(numImuSpikeFreq);
            grpNoise.Controls.Add(lblImuVib);
            grpNoise.Controls.Add(numImuVib);
            grpNoise.Location = new Point(13, 754);
            grpNoise.Margin = new Padding(4, 5, 4, 5);
            grpNoise.Name = "grpNoise";
            grpNoise.Padding = new Padding(4, 5, 4, 5);
            grpNoise.Size = new Size(437, 525);
            grpNoise.TabIndex = 3;
            grpNoise.TabStop = false;
            grpNoise.Text = "Sensör Gürültü ve Hata Parametreleri";
            // 
            // btnResetNoise
            // 
            btnResetNoise.Location = new Point(222, 0);
            btnResetNoise.Name = "btnResetNoise";
            btnResetNoise.Size = new Size(82, 33);
            btnResetNoise.TabIndex = 15;
            btnResetNoise.Text = "↺ Sıfırla";
            btnResetNoise.FlatStyle = FlatStyle.Flat;
            btnResetNoise.BackColor = Color.FromArgb(60, 60, 60);
            btnResetNoise.ForeColor = Color.Gold;
            btnResetNoise.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnResetNoise.Click += BtnResetNoise_Click;
            // 
            // chkToggleNoise
            // 
            chkToggleNoise.Location = new Point(307, 0);
            chkToggleNoise.Margin = new Padding(4, 5, 4, 5);
            chkToggleNoise.Name = "chkToggleNoise";
            chkToggleNoise.Size = new Size(121, 33);
            chkToggleNoise.TabIndex = 0;
            chkToggleNoise.Text = "▼ Aç/Gizle";
            // 
            // lblBaroBias
            // 
            lblBaroBias.Location = new Point(17, 47);
            lblBaroBias.Margin = new Padding(4, 0, 4, 0);
            lblBaroBias.Name = "lblBaroBias";
            lblBaroBias.Size = new Size(143, 38);
            lblBaroBias.TabIndex = 1;
            lblBaroBias.Text = "Baro Mutlak Bias (m):";
            // 
            // numBaroBias
            // 
            numBaroBias.DecimalPlaces = 2;
            numBaroBias.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numBaroBias.Location = new Point(243, 43);
            numBaroBias.Margin = new Padding(4, 5, 4, 5);
            numBaroBias.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numBaroBias.Name = "numBaroBias";
            numBaroBias.Size = new Size(171, 33);
            numBaroBias.TabIndex = 2;
            // 
            // lblBaroNoise
            // 
            lblBaroNoise.Location = new Point(17, 93);
            lblBaroNoise.Margin = new Padding(4, 0, 4, 0);
            lblBaroNoise.Name = "lblBaroNoise";
            lblBaroNoise.Size = new Size(143, 38);
            lblBaroNoise.TabIndex = 3;
            lblBaroNoise.Text = "Baro Termal σ (m):";
            // 
            // numBaroNoise
            // 
            numBaroNoise.DecimalPlaces = 1;
            numBaroNoise.Increment = new decimal(new int[] { 2, 0, 0, 65536 });
            numBaroNoise.Location = new Point(243, 90);
            numBaroNoise.Margin = new Padding(4, 5, 4, 5);
            numBaroNoise.Name = "numBaroNoise";
            numBaroNoise.Size = new Size(171, 33);
            numBaroNoise.TabIndex = 4;
            numBaroNoise.Value = new decimal(new int[] { 12, 0, 0, 65536 });
            // 
            // lblBaroErrPct
            // 
            lblBaroErrPct.Location = new Point(17, 140);
            lblBaroErrPct.Margin = new Padding(4, 0, 4, 0);
            lblBaroErrPct.Name = "lblBaroErrPct";
            lblBaroErrPct.Size = new Size(143, 38);
            lblBaroErrPct.TabIndex = 5;
            lblBaroErrPct.Text = "Baro Bağıl Hata (%):";
            // 
            // numBaroErrPct
            // 
            numBaroErrPct.Location = new Point(243, 137);
            numBaroErrPct.Margin = new Padding(4, 5, 4, 5);
            numBaroErrPct.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numBaroErrPct.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numBaroErrPct.Name = "numBaroErrPct";
            numBaroErrPct.Size = new Size(171, 33);
            numBaroErrPct.TabIndex = 6;
            numBaroErrPct.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // lblBaroSpikeStd
            // 
            lblBaroSpikeStd.Location = new Point(17, 187);
            lblBaroSpikeStd.Margin = new Padding(4, 0, 4, 0);
            lblBaroSpikeStd.Name = "lblBaroSpikeStd";
            lblBaroSpikeStd.Size = new Size(143, 38);
            lblBaroSpikeStd.TabIndex = 7;
            lblBaroSpikeStd.Text = "Baro Darbe σ (m):";
            // 
            // numBaroSpikeStd
            // 
            numBaroSpikeStd.DecimalPlaces = 1;
            numBaroSpikeStd.Location = new Point(243, 183);
            numBaroSpikeStd.Margin = new Padding(4, 5, 4, 5);
            numBaroSpikeStd.Name = "numBaroSpikeStd";
            numBaroSpikeStd.Size = new Size(171, 33);
            numBaroSpikeStd.TabIndex = 8;
            numBaroSpikeStd.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // lblBaroSpikeFreq
            // 
            lblBaroSpikeFreq.Location = new Point(17, 233);
            lblBaroSpikeFreq.Margin = new Padding(4, 0, 4, 0);
            lblBaroSpikeFreq.Name = "lblBaroSpikeFreq";
            lblBaroSpikeFreq.Size = new Size(143, 38);
            lblBaroSpikeFreq.TabIndex = 9;
            lblBaroSpikeFreq.Text = "Baro Darbe Sıklık (%):";
            // 
            // numBaroSpikeFreq
            // 
            numBaroSpikeFreq.DecimalPlaces = 1;
            numBaroSpikeFreq.Location = new Point(243, 230);
            numBaroSpikeFreq.Margin = new Padding(4, 5, 4, 5);
            numBaroSpikeFreq.Name = "numBaroSpikeFreq";
            numBaroSpikeFreq.Size = new Size(171, 33);
            numBaroSpikeFreq.TabIndex = 10;
            numBaroSpikeFreq.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblImuBias
            // 
            lblImuBias.Location = new Point(17, 280);
            lblImuBias.Margin = new Padding(4, 0, 4, 0);
            lblImuBias.Name = "lblImuBias";
            lblImuBias.Size = new Size(143, 38);
            lblImuBias.TabIndex = 11;
            lblImuBias.Text = "IMU Mutlak Bias (m/s²):";
            // 
            // numImuBias
            // 
            numImuBias.DecimalPlaces = 2;
            numImuBias.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numImuBias.Location = new Point(243, 277);
            numImuBias.Margin = new Padding(4, 5, 4, 5);
            numImuBias.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numImuBias.Minimum = new decimal(new int[] { 50, 0, 0, int.MinValue });
            numImuBias.Name = "numImuBias";
            numImuBias.Size = new Size(171, 33);
            numImuBias.TabIndex = 12;
            numImuBias.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // lblImuNoise
            // 
            lblImuNoise.Location = new Point(17, 327);
            lblImuNoise.Margin = new Padding(4, 0, 4, 0);
            lblImuNoise.Name = "lblImuNoise";
            lblImuNoise.Size = new Size(143, 38);
            lblImuNoise.TabIndex = 13;
            lblImuNoise.Text = "IMU Termal σ (m/s²):";
            // 
            // numImuNoise
            // 
            numImuNoise.DecimalPlaces = 2;
            numImuNoise.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numImuNoise.Location = new Point(243, 323);
            numImuNoise.Margin = new Padding(4, 5, 4, 5);
            numImuNoise.Name = "numImuNoise";
            numImuNoise.Size = new Size(171, 33);
            numImuNoise.TabIndex = 14;
            numImuNoise.Value = new decimal(new int[] { 12, 0, 0, 65536 });
            // 
            // lblImuSpikeStd
            // 
            lblImuSpikeStd.Location = new Point(17, 373);
            lblImuSpikeStd.Margin = new Padding(4, 0, 4, 0);
            lblImuSpikeStd.Name = "lblImuSpikeStd";
            lblImuSpikeStd.Size = new Size(143, 38);
            lblImuSpikeStd.TabIndex = 15;
            lblImuSpikeStd.Text = "IMU Darbe σ (m/s²):";
            // 
            // numImuSpikeStd
            // 
            numImuSpikeStd.DecimalPlaces = 2;
            numImuSpikeStd.Location = new Point(243, 370);
            numImuSpikeStd.Margin = new Padding(4, 5, 4, 5);
            numImuSpikeStd.Name = "numImuSpikeStd";
            numImuSpikeStd.Size = new Size(171, 33);
            numImuSpikeStd.TabIndex = 16;
            numImuSpikeStd.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // lblImuSpikeFreq
            // 
            lblImuSpikeFreq.Location = new Point(17, 420);
            lblImuSpikeFreq.Margin = new Padding(4, 0, 4, 0);
            lblImuSpikeFreq.Name = "lblImuSpikeFreq";
            lblImuSpikeFreq.Size = new Size(143, 38);
            lblImuSpikeFreq.TabIndex = 17;
            lblImuSpikeFreq.Text = "IMU Darbe Sıklık (%):";
            // 
            // numImuSpikeFreq
            // 
            numImuSpikeFreq.DecimalPlaces = 1;
            numImuSpikeFreq.Location = new Point(243, 417);
            numImuSpikeFreq.Margin = new Padding(4, 5, 4, 5);
            numImuSpikeFreq.Name = "numImuSpikeFreq";
            numImuSpikeFreq.Size = new Size(171, 33);
            numImuSpikeFreq.TabIndex = 18;
            numImuSpikeFreq.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblImuVib
            // 
            lblImuVib.Location = new Point(17, 467);
            lblImuVib.Margin = new Padding(4, 0, 4, 0);
            lblImuVib.Name = "lblImuVib";
            lblImuVib.Size = new Size(143, 38);
            lblImuVib.TabIndex = 19;
            lblImuVib.Text = "IMU Titreşim σ (m/s²):";
            // 
            // numImuVib
            // 
            numImuVib.DecimalPlaces = 2;
            numImuVib.Location = new Point(243, 463);
            numImuVib.Margin = new Padding(4, 5, 4, 5);
            numImuVib.Name = "numImuVib";
            numImuVib.Size = new Size(171, 33);
            numImuVib.TabIndex = 20;
            numImuVib.Value = new decimal(new int[] { 35, 0, 0, 65536 });
            // 
            // grpBucket
            // 
            grpBucket.Controls.Add(btnResetBucket);

            grpBucket.Controls.Add(chkToggleBucket);
            grpBucket.Controls.Add(lblFillRate);
            grpBucket.Controls.Add(numFillRate);
            grpBucket.Controls.Add(lblLeakRate);
            grpBucket.Controls.Add(numLeakRate);
            grpBucket.Controls.Add(lblBucketThresh);
            grpBucket.Controls.Add(numBucketThresh);
            grpBucket.Location = new Point(13, 1289);
            grpBucket.Margin = new Padding(4, 5, 4, 5);
            grpBucket.Name = "grpBucket";
            grpBucket.Padding = new Padding(4, 5, 4, 5);
            grpBucket.Size = new Size(437, 192);
            grpBucket.TabIndex = 4;
            grpBucket.TabStop = false;
            grpBucket.Text = "Sızdıran Kova (Leaky Bucket) Ayarları";
            // 
            // btnResetBucket
            // 
            btnResetBucket.Location = new Point(222, 0);
            btnResetBucket.Name = "btnResetBucket";
            btnResetBucket.Size = new Size(82, 33);
            btnResetBucket.TabIndex = 15;
            btnResetBucket.Text = "↺ Sıfırla";
            btnResetBucket.FlatStyle = FlatStyle.Flat;
            btnResetBucket.BackColor = Color.FromArgb(60, 60, 60);
            btnResetBucket.ForeColor = Color.Gold;
            btnResetBucket.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnResetBucket.Click += BtnResetBucket_Click;
            // 
            // chkToggleBucket
            // 
            chkToggleBucket.Location = new Point(307, 0);
            chkToggleBucket.Margin = new Padding(4, 5, 4, 5);
            chkToggleBucket.Name = "chkToggleBucket";
            chkToggleBucket.Size = new Size(121, 33);
            chkToggleBucket.TabIndex = 0;
            chkToggleBucket.Text = "▼ Aç/Gizle";
            // 
            // lblFillRate
            // 
            lblFillRate.Location = new Point(17, 47);
            lblFillRate.Margin = new Padding(4, 0, 4, 0);
            lblFillRate.Name = "lblFillRate";
            lblFillRate.Size = new Size(143, 38);
            lblFillRate.TabIndex = 1;
            lblFillRate.Text = "Dolum Hızı (R_fill):";
            // 
            // numFillRate
            // 
            numFillRate.DecimalPlaces = 1;
            numFillRate.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numFillRate.Location = new Point(243, 43);
            numFillRate.Margin = new Padding(4, 5, 4, 5);
            numFillRate.Name = "numFillRate";
            numFillRate.Size = new Size(171, 33);
            numFillRate.TabIndex = 2;
            numFillRate.Value = new decimal(new int[] { 25, 0, 0, 65536 });
            // 
            // lblLeakRate
            // 
            lblLeakRate.Location = new Point(17, 93);
            lblLeakRate.Margin = new Padding(4, 0, 4, 0);
            lblLeakRate.Name = "lblLeakRate";
            lblLeakRate.Size = new Size(143, 38);
            lblLeakRate.TabIndex = 3;
            lblLeakRate.Text = "Sızma Hızı (R_leak):";
            // 
            // numLeakRate
            // 
            numLeakRate.DecimalPlaces = 1;
            numLeakRate.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numLeakRate.Location = new Point(243, 90);
            numLeakRate.Margin = new Padding(4, 5, 4, 5);
            numLeakRate.Name = "numLeakRate";
            numLeakRate.Size = new Size(171, 33);
            numLeakRate.TabIndex = 4;
            numLeakRate.Value = new decimal(new int[] { 12, 0, 0, 65536 });
            // 
            // lblBucketThresh
            // 
            lblBucketThresh.Location = new Point(17, 140);
            lblBucketThresh.Margin = new Padding(4, 0, 4, 0);
            lblBucketThresh.Name = "lblBucketThresh";
            lblBucketThresh.Size = new Size(143, 38);
            lblBucketThresh.TabIndex = 5;
            lblBucketThresh.Text = "Mühür Eşiği (TT):";
            // 
            // numBucketThresh
            // 
            numBucketThresh.DecimalPlaces = 1;
            numBucketThresh.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            numBucketThresh.Location = new Point(243, 137);
            numBucketThresh.Margin = new Padding(4, 5, 4, 5);
            numBucketThresh.Name = "numBucketThresh";
            numBucketThresh.Size = new Size(171, 33);
            numBucketThresh.TabIndex = 6;
            numBucketThresh.Value = new decimal(new int[] { 40, 0, 0, 65536 });
            // 
            // btnRunPhysics
            // 
            btnRunPhysics.BackColor = Color.FromArgb(0, 120, 212);
            btnRunPhysics.FlatStyle = FlatStyle.Flat;
            btnRunPhysics.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRunPhysics.ForeColor = Color.White;
            btnRunPhysics.Location = new Point(20, 1506);
            btnRunPhysics.Margin = new Padding(11, 20, 11, 42);
            btnRunPhysics.Name = "btnRunPhysics";
            btnRunPhysics.Size = new Size(437, 70);
            btnRunPhysics.TabIndex = 5;
            btnRunPhysics.Text = "⚡ Fizik Simülasyonu Yeniden Hesapla";
            btnRunPhysics.UseVisualStyleBackColor = false;
            btnRunPhysics.Click += BtnRunPhysics_Click;
            // 
            // panelPlayer
            // 
            panelPlayer.BackColor = Color.FromArgb(235, 240, 248);
            panelPlayer.BorderStyle = BorderStyle.FixedSingle;
            panelPlayer.Controls.Add(btnPlayPause);
            panelPlayer.Controls.Add(btnStepBack);
            panelPlayer.Controls.Add(btnStepFwd);
            panelPlayer.Controls.Add(trackTimeline);
            panelPlayer.Controls.Add(lblCurrentTime);
            panelPlayer.Dock = DockStyle.Fill;
            panelPlayer.Location = new Point(475, 5);
            panelPlayer.Margin = new Padding(4, 5, 4, 5);
            panelPlayer.Name = "panelPlayer";
            panelPlayer.Size = new Size(1476, 73);
            panelPlayer.TabIndex = 5;
            // 
            // btnPlayPause
            // 
            btnPlayPause.BackColor = Color.FromArgb(0, 120, 212);
            btnPlayPause.FlatStyle = FlatStyle.Flat;
            btnPlayPause.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPlayPause.ForeColor = Color.White;
            btnPlayPause.Location = new Point(11, 10);
            btnPlayPause.Margin = new Padding(4, 5, 4, 5);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(150, 50);
            btnPlayPause.TabIndex = 0;
            btnPlayPause.Text = "▶ Oynat";
            btnPlayPause.UseVisualStyleBackColor = false;
            btnPlayPause.Click += BtnPlayPause_Click;
            // 
            // btnStepBack
            // 
            btnStepBack.BackColor = Color.White;
            btnStepBack.FlatStyle = FlatStyle.Flat;
            btnStepBack.Location = new Point(171, 10);
            btnStepBack.Margin = new Padding(4, 5, 4, 5);
            btnStepBack.Name = "btnStepBack";
            btnStepBack.Size = new Size(121, 50);
            btnStepBack.TabIndex = 1;
            btnStepBack.Text = "⏮ Geri Al";
            btnStepBack.UseVisualStyleBackColor = false;
            btnStepBack.Click += BtnStepBack_Click;
            // 
            // btnStepFwd
            // 
            btnStepFwd.BackColor = Color.White;
            btnStepFwd.FlatStyle = FlatStyle.Flat;
            btnStepFwd.Location = new Point(303, 10);
            btnStepFwd.Margin = new Padding(4, 5, 4, 5);
            btnStepFwd.Name = "btnStepFwd";
            btnStepFwd.Size = new Size(121, 50);
            btnStepFwd.TabIndex = 2;
            btnStepFwd.Text = "⏭ İleri Al";
            btnStepFwd.UseVisualStyleBackColor = false;
            btnStepFwd.Click += BtnStepFwd_Click;
            // 
            // trackTimeline
            // 
            trackTimeline.Location = new Point(436, 10);
            trackTimeline.Margin = new Padding(4, 5, 4, 5);
            trackTimeline.Name = "trackTimeline";
            trackTimeline.Size = new Size(743, 69);
            trackTimeline.TabIndex = 3;
            trackTimeline.TickStyle = TickStyle.None;
            trackTimeline.Scroll += TrackTimeline_Scroll;
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCurrentTime.ForeColor = Color.FromArgb(20, 40, 80);
            lblCurrentTime.Location = new Point(1193, 18);
            lblCurrentTime.Margin = new Padding(4, 0, 4, 0);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(264, 37);
            lblCurrentTime.TabIndex = 4;
            lblCurrentTime.Text = "Zaman: 0.00 / 0.00 s";
            // 
            // panelLiveDashboard
            // 
            panelLiveDashboard.BackColor = Color.FromArgb(20, 30, 45);
            panelLiveDashboard.BorderStyle = BorderStyle.FixedSingle;
            panelLiveDashboard.Controls.Add(lblDashState);
            panelLiveDashboard.Controls.Add(lblDashSubState);
            panelLiveDashboard.Controls.Add(lblDashPhysics);
            panelLiveDashboard.Controls.Add(lblDashKinematics);
            panelLiveDashboard.Controls.Add(lblDashActuators);
            panelLiveDashboard.Dock = DockStyle.Fill;
            panelLiveDashboard.Location = new Point(475, 88);
            panelLiveDashboard.Margin = new Padding(4, 5, 4, 5);
            panelLiveDashboard.Name = "panelLiveDashboard";
            panelLiveDashboard.Size = new Size(1476, 173);
            panelLiveDashboard.TabIndex = 6;
            // 
            // lblDashState
            // 
            lblDashState.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDashState.ForeColor = Color.FromArgb(0, 210, 255);
            lblDashState.Location = new Point(17, 13);
            lblDashState.Margin = new Padding(4, 0, 4, 0);
            lblDashState.Name = "lblDashState";
            lblDashState.Size = new Size(686, 40);
            lblDashState.TabIndex = 0;
            lblDashState.Text = "ANA HAL: S1: YÜKSELME";
            // 
            // lblDashSubState
            // 
            lblDashSubState.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDashSubState.ForeColor = Color.FromArgb(255, 215, 0);
            lblDashSubState.Location = new Point(17, 57);
            lblDashSubState.Margin = new Padding(4, 0, 4, 0);
            lblDashSubState.Name = "lblDashSubState";
            lblDashSubState.Size = new Size(1400, 37);
            lblDashSubState.TabIndex = 1;
            lblDashSubState.Text = "ALT SENARYO: Roket ile Tepe Noktasına (1800m) Tırmanış";
            // 
            // lblDashPhysics
            // 
            lblDashPhysics.Font = new Font("Segoe UI", 9F);
            lblDashPhysics.ForeColor = Color.WhiteSmoke;
            lblDashPhysics.Location = new Point(17, 97);
            lblDashPhysics.Margin = new Padding(4, 0, 4, 0);
            lblDashPhysics.Name = "lblDashPhysics";
            lblDashPhysics.Size = new Size(1400, 33);
            lblDashPhysics.TabIndex = 2;
            lblDashPhysics.Text = "FİZİK MODEL: Kütle = 1.80 kg | Paraşüt Alanı = 0.02 m² | Cd = 0.40 | Limit Hız = 0.0 m/s";
            // 
            // lblDashKinematics
            // 
            lblDashKinematics.Font = new Font("Segoe UI", 9F);
            lblDashKinematics.ForeColor = Color.LightGreen;
            lblDashKinematics.Location = new Point(17, 130);
            lblDashKinematics.Margin = new Padding(4, 0, 4, 0);
            lblDashKinematics.Name = "lblDashKinematics";
            lblDashKinematics.Size = new Size(700, 33);
            lblDashKinematics.TabIndex = 3;
            lblDashKinematics.Text = "KİNEMATİK: Gerçek İrtifa = 0.0 m | Kestirim = 0.0 m | Hız = 0.0 m/s";
            // 
            // lblDashActuators
            // 
            lblDashActuators.Font = new Font("Segoe UI", 9F);
            lblDashActuators.ForeColor = Color.LightPink;
            lblDashActuators.Location = new Point(729, 130);
            lblDashActuators.Margin = new Padding(4, 0, 4, 0);
            lblDashActuators.Name = "lblDashActuators";
            lblDashActuators.Size = new Size(700, 33);
            lblDashActuators.TabIndex = 4;
            lblDashActuators.Text = "KONTROL: Motor RPM = 0 | İtki = 0.0 N | Kova Havuz (ACC) = 0.00";
            // 
            // panelPhysicsPlotsTable
            // 
            panelPhysicsPlotsTable.ColumnCount = 2;
            panelPhysicsPlotsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelPhysicsPlotsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelPhysicsPlotsTable.Controls.Add(plotPhysicsAltitude, 0, 0);
            panelPhysicsPlotsTable.Controls.Add(plotPhysicsVelocity, 0, 1);
            panelPhysicsPlotsTable.Controls.Add(plotPhysicsAccel, 1, 1);
            panelPhysicsPlotsTable.Dock = DockStyle.Fill;
            panelPhysicsPlotsTable.Location = new Point(477, 533);
            panelPhysicsPlotsTable.Margin = new Padding(6, 7, 6, 7);
            panelPhysicsPlotsTable.Name = "panelPhysicsPlotsTable";
            panelPhysicsPlotsTable.RowCount = 2;
            panelPhysicsPlotsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelPhysicsPlotsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelPhysicsPlotsTable.Size = new Size(1472, 819);
            panelPhysicsPlotsTable.TabIndex = 1;
            panelPhysicsPlotsTable.SetColumnSpan(plotPhysicsAltitude, 2);
            // 
            // plotPhysicsAltitude
            // 
            plotPhysicsAltitude.DisplayScale = 1.5F;
            plotPhysicsAltitude.Dock = DockStyle.Fill;
            plotPhysicsAltitude.Location = new Point(0, 0);
            plotPhysicsAltitude.Margin = new Padding(4, 5, 4, 5);
            plotPhysicsAltitude.Name = "plotPhysicsAltitude";
            plotPhysicsAltitude.Size = new Size(490, 835);
            plotPhysicsAltitude.TabIndex = 0;
            // 
            // plotPhysicsVelocity
            // 
            plotPhysicsVelocity.DisplayScale = 1.5F;
            plotPhysicsVelocity.Dock = DockStyle.Fill;
            plotPhysicsVelocity.Location = new Point(490, 0);
            plotPhysicsVelocity.Margin = new Padding(4, 5, 4, 5);
            plotPhysicsVelocity.Name = "plotPhysicsVelocity";
            plotPhysicsVelocity.Size = new Size(490, 835);
            plotPhysicsVelocity.TabIndex = 1;
            // 
            // plotPhysicsAccel
            // 
            plotPhysicsAccel.DisplayScale = 1.5F;
            plotPhysicsAccel.Dock = DockStyle.Fill;
            plotPhysicsAccel.Location = new Point(980, 0);
            plotPhysicsAccel.Margin = new Padding(4, 5, 4, 5);
            plotPhysicsAccel.Name = "plotPhysicsAccel";
            plotPhysicsAccel.Size = new Size(492, 835);
            plotPhysicsAccel.TabIndex = 2;
            // 
            // panelDualCoreDashboard
            // 
            panelDualCoreDashboard.ColumnCount = 2;
            panelDualCoreDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            panelDualCoreDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            panelDualCoreDashboard.Controls.Add(grpEkfKernelCore, 0, 0);
            panelDualCoreDashboard.Controls.Add(grpLeakyBucketCore, 1, 0);
            panelDualCoreDashboard.Dock = DockStyle.Fill;
            panelDualCoreDashboard.Location = new Point(477, 273);
            panelDualCoreDashboard.Margin = new Padding(6, 7, 6, 7);
            panelDualCoreDashboard.Name = "panelDualCoreDashboard";
            panelDualCoreDashboard.RowCount = 1;
            panelDualCoreDashboard.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelDualCoreDashboard.Size = new Size(1472, 255);
            panelDualCoreDashboard.TabIndex = 2;
            // 
            // grpEkfKernelCore
            // 
            grpEkfKernelCore.Controls.Add(picEkfStackedBar);
            grpEkfKernelCore.Controls.Add(lblEkfTrustDetails);
            grpEkfKernelCore.Dock = DockStyle.Fill;
            grpEkfKernelCore.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpEkfKernelCore.ForeColor = Color.White;
            grpEkfKernelCore.Location = new Point(740, 7);
            grpEkfKernelCore.Margin = new Padding(4, 5, 4, 5);
            grpEkfKernelCore.Name = "grpEkfKernelCore";
            grpEkfKernelCore.Padding = new Padding(4, 5, 4, 5);
            grpEkfKernelCore.Size = new Size(723, 220);
            grpEkfKernelCore.TabIndex = 1;
            grpEkfKernelCore.TabStop = false;
            grpEkfKernelCore.Text = "\U0001f9e0 ADAPTİF KALMAN FİLTRESİ (CANLI SENSÖR GÜVEN DAĞILIMI)";
            // 
            // picEkfStackedBar
            // 
            picEkfStackedBar.Location = new Point(17, 40);
            picEkfStackedBar.Margin = new Padding(4, 5, 4, 5);
            picEkfStackedBar.Name = "picEkfStackedBar";
            picEkfStackedBar.Size = new Size(689, 43);
            picEkfStackedBar.TabIndex = 0;
            picEkfStackedBar.TabStop = false;
            picEkfStackedBar.Paint += PicEkfStackedBar_Paint;
            // 
            // lblEkfTrustDetails
            // 
            lblEkfTrustDetails.Font = new Font("Segoe UI", 9.6F, FontStyle.Bold);
            lblEkfTrustDetails.ForeColor = Color.LightSeaGreen;
            lblEkfTrustDetails.Location = new Point(17, 92);
            lblEkfTrustDetails.Margin = new Padding(4, 0, 4, 0);
            lblEkfTrustDetails.Name = "lblEkfTrustDetails";
            lblEkfTrustDetails.Size = new Size(689, 117);
            lblEkfTrustDetails.TabIndex = 1;
            lblEkfTrustDetails.Text = "🔵 Barometre: %52.0  |  \U0001f7e0 İvmeölçer (IMU): %33.0  |  \U0001f7e2 Fizik Model: %15.0";
            // 
            // tabPageCompare
            // 
            tabPageCompare.Controls.Add(mainLayout);
            tabPageCompare.Location = new Point(4, 26);
            tabPageCompare.Name = "tabPageCompare";
            tabPageCompare.Padding = new Padding(3);
            tabPageCompare.Size = new Size(1372, 850);
            tabPageCompare.TabIndex = 0;
            tabPageCompare.Text = "📊 4 Senaryo Karşılaştırması & Hızlı Analiz";
            tabPageCompare.UseVisualStyleBackColor = true;
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 2;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainLayout.Controls.Add(topControlPanel, 0, 0);
            mainLayout.Controls.Add(plotAltitude, 0, 1);
            mainLayout.Controls.Add(plotVelocity, 1, 1);
            mainLayout.Controls.Add(bottomPanel, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(3, 3);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            mainLayout.Size = new Size(1366, 844);
            mainLayout.TabIndex = 0;
            // 
            // topControlPanel
            // 
            topControlPanel.BackColor = Color.FromArgb(240, 244, 248);
            mainLayout.SetColumnSpan(topControlPanel, 2);
            topControlPanel.Controls.Add(grpCustomSim);
            topControlPanel.Controls.Add(btnRunAllCompare);
            topControlPanel.Dock = DockStyle.Fill;
            topControlPanel.Location = new Point(3, 3);
            topControlPanel.Name = "topControlPanel";
            topControlPanel.Size = new Size(1360, 64);
            topControlPanel.TabIndex = 0;
            // 
            // grpCustomSim
            // 
            grpCustomSim.Controls.Add(lblErrorPercent);
            grpCustomSim.Controls.Add(numErrorPercent);
            grpCustomSim.Controls.Add(chkUseFusion);
            grpCustomSim.Controls.Add(btnRunCustom);
            grpCustomSim.Location = new Point(10, 4);
            grpCustomSim.Name = "grpCustomSim";
            grpCustomSim.Size = new Size(640, 56);
            grpCustomSim.TabIndex = 0;
            grpCustomSim.TabStop = false;
            grpCustomSim.Text = "Etkileşimli Simülasyon Kontrolü";
            // 
            // lblErrorPercent
            // 
            lblErrorPercent.AutoSize = true;
            lblErrorPercent.Location = new Point(15, 25);
            lblErrorPercent.Name = "lblErrorPercent";
            lblErrorPercent.Size = new Size(206, 25);
            lblErrorPercent.TabIndex = 0;
            lblErrorPercent.Text = "Barometre Hata Payı (%):";
            // 
            // numErrorPercent
            // 
            numErrorPercent.Location = new Point(175, 23);
            numErrorPercent.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            numErrorPercent.Name = "numErrorPercent";
            numErrorPercent.Size = new Size(65, 31);
            numErrorPercent.TabIndex = 1;
            numErrorPercent.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // chkUseFusion
            // 
            chkUseFusion.AutoSize = true;
            chkUseFusion.Checked = true;
            chkUseFusion.CheckState = CheckState.Checked;
            chkUseFusion.Location = new Point(255, 24);
            chkUseFusion.Name = "chkUseFusion";
            chkUseFusion.Size = new Size(249, 29);
            chkUseFusion.TabIndex = 2;
            chkUseFusion.Text = "Sensör Füzyonu (EKF) Aktif";
            chkUseFusion.UseVisualStyleBackColor = true;
            // 
            // btnRunCustom
            // 
            btnRunCustom.BackColor = Color.FromArgb(16, 124, 65);
            btnRunCustom.FlatStyle = FlatStyle.Flat;
            btnRunCustom.ForeColor = Color.White;
            btnRunCustom.Location = new Point(450, 18);
            btnRunCustom.Name = "btnRunCustom";
            btnRunCustom.Size = new Size(175, 30);
            btnRunCustom.TabIndex = 3;
            btnRunCustom.Text = "🎯 Özel Senaryoyu Çiz";
            btnRunCustom.UseVisualStyleBackColor = false;
            btnRunCustom.Click += BtnRunCustom_Click;
            // 
            // btnRunAllCompare
            // 
            btnRunAllCompare.BackColor = Color.FromArgb(0, 120, 212);
            btnRunAllCompare.FlatStyle = FlatStyle.Flat;
            btnRunAllCompare.ForeColor = Color.White;
            btnRunAllCompare.Location = new Point(670, 20);
            btnRunAllCompare.Name = "btnRunAllCompare";
            btnRunAllCompare.Size = new Size(260, 32);
            btnRunAllCompare.TabIndex = 1;
            btnRunAllCompare.Text = "🚀 Yarışma 4 Senaryosunu Karşılaştır";
            btnRunAllCompare.UseVisualStyleBackColor = false;
            btnRunAllCompare.Click += BtnRunAllCompare_Click;
            // 
            // plotAltitude
            // 
            plotAltitude.DisplayScale = 1.5F;
            plotAltitude.Dock = DockStyle.Fill;
            plotAltitude.Location = new Point(4, 74);
            plotAltitude.Margin = new Padding(4);
            plotAltitude.Name = "plotAltitude";
            plotAltitude.Size = new Size(675, 456);
            plotAltitude.TabIndex = 1;
            // 
            // plotVelocity
            // 
            plotVelocity.DisplayScale = 1.5F;
            plotVelocity.Dock = DockStyle.Fill;
            plotVelocity.Location = new Point(687, 74);
            plotVelocity.Margin = new Padding(4);
            plotVelocity.Name = "plotVelocity";
            plotVelocity.Size = new Size(675, 456);
            plotVelocity.TabIndex = 2;
            // 
            // bottomPanel
            // 
            mainLayout.SetColumnSpan(bottomPanel, 2);
            bottomPanel.Controls.Add(dgvMetrics);
            bottomPanel.Controls.Add(btnPanel);
            bottomPanel.Dock = DockStyle.Fill;
            bottomPanel.Location = new Point(3, 537);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(1360, 304);
            bottomPanel.TabIndex = 3;
            // 
            // dgvMetrics
            // 
            dgvMetrics.AllowUserToAddRows = false;
            dgvMetrics.AllowUserToDeleteRows = false;
            dgvMetrics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMetrics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMetrics.Columns.AddRange(new DataGridViewColumn[] { colScenario, colScaleError, colFusion, colImpactVel, colLandingTime, colEvaluation });
            dgvMetrics.Dock = DockStyle.Fill;
            dgvMetrics.Location = new Point(0, 0);
            dgvMetrics.Name = "dgvMetrics";
            dgvMetrics.ReadOnly = true;
            dgvMetrics.RowHeadersVisible = false;
            dgvMetrics.RowHeadersWidth = 62;
            dgvMetrics.Size = new Size(1360, 258);
            dgvMetrics.TabIndex = 0;
            // 
            // colScenario
            // 
            colScenario.HeaderText = "Senaryo Adı";
            colScenario.MinimumWidth = 8;
            colScenario.Name = "colScenario";
            colScenario.ReadOnly = true;
            // 
            // colScaleError
            // 
            colScaleError.HeaderText = "Sensör Hata Oranı";
            colScaleError.MinimumWidth = 8;
            colScaleError.Name = "colScaleError";
            colScaleError.ReadOnly = true;
            // 
            // colFusion
            // 
            colFusion.HeaderText = "Füzyon Durumu";
            colFusion.MinimumWidth = 8;
            colFusion.Name = "colFusion";
            colFusion.ReadOnly = true;
            // 
            // colImpactVel
            // 
            colImpactVel.HeaderText = "Yere Çarpma Hızı (m/s)";
            colImpactVel.MinimumWidth = 8;
            colImpactVel.Name = "colImpactVel";
            colImpactVel.ReadOnly = true;
            // 
            // colLandingTime
            // 
            colLandingTime.HeaderText = "İniş Süresi (s)";
            colLandingTime.MinimumWidth = 8;
            colLandingTime.Name = "colLandingTime";
            colLandingTime.ReadOnly = true;
            // 
            // colEvaluation
            // 
            colEvaluation.HeaderText = "Risk Değerlendirmesi";
            colEvaluation.MinimumWidth = 8;
            colEvaluation.Name = "colEvaluation";
            colEvaluation.ReadOnly = true;
            // 
            // btnPanel
            // 
            btnPanel.Controls.Add(btnExportPng);
            btnPanel.Dock = DockStyle.Bottom;
            btnPanel.Location = new Point(0, 258);
            btnPanel.Name = "btnPanel";
            btnPanel.Size = new Size(1360, 46);
            btnPanel.TabIndex = 1;
            // 
            // btnExportPng
            // 
            btnExportPng.BackColor = Color.FromArgb(40, 40, 40);
            btnExportPng.FlatStyle = FlatStyle.Flat;
            btnExportPng.ForeColor = Color.White;
            btnExportPng.Location = new Point(10, 8);
            btnExportPng.Name = "btnExportPng";
            btnExportPng.Size = new Size(200, 32);
            btnExportPng.TabIndex = 0;
            btnExportPng.Text = "📷 PNG Olarak Kaydet";
            btnExportPng.UseVisualStyleBackColor = false;
            btnExportPng.Click += BtnExportPng_Click;
            // 
            // grpLeakyBucketCore
            // 
            grpLeakyBucketCore.Controls.Add(progBucketCore);
            grpLeakyBucketCore.Controls.Add(lblBucketCoreStatus);
            grpLeakyBucketCore.Controls.Add(lblBucketCoreFactors);
            grpLeakyBucketCore.Controls.Add(btnManualSeparate);
            grpLeakyBucketCore.Controls.Add(btnManualParachute);
            grpLeakyBucketCore.Controls.Add(btnManualHover);
            grpLeakyBucketCore.Controls.Add(btnManualLanding);
            grpLeakyBucketCore.Dock = DockStyle.Fill;
            grpLeakyBucketCore.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpLeakyBucketCore.ForeColor = Color.White;
            grpLeakyBucketCore.Location = new Point(814, 7);
            grpLeakyBucketCore.Margin = new Padding(4, 5, 4, 5);
            grpLeakyBucketCore.Name = "grpLeakyBucketCore";
            grpLeakyBucketCore.Padding = new Padding(4, 5, 4, 5);
            grpLeakyBucketCore.Size = new Size(654, 245);
            grpLeakyBucketCore.TabIndex = 2;
            grpLeakyBucketCore.TabStop = false;
            grpLeakyBucketCore.Text = "🔒 SIZDIRAN KOVA KARAR VE TETİKLEME ÇEKİRDEĞİ";
            // 
            // progBucketCore
            // 
            progBucketCore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progBucketCore.Location = new Point(16, 38);
            progBucketCore.Name = "progBucketCore";
            progBucketCore.Size = new Size(622, 26);
            progBucketCore.TabIndex = 0;
            // 
            // lblBucketCoreStatus
            // 
            lblBucketCoreStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBucketCoreStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBucketCoreStatus.ForeColor = Color.LightGreen;
            lblBucketCoreStatus.Location = new Point(16, 72);
            lblBucketCoreStatus.Name = "lblBucketCoreStatus";
            lblBucketCoreStatus.Size = new Size(622, 26);
            lblBucketCoreStatus.TabIndex = 1;
            lblBucketCoreStatus.Text = "\U0001f7e2 BEKLEMEDE (ACC = 0.00 / 4.50)";
            // 
            // lblBucketCoreFactors
            // 
            lblBucketCoreFactors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblBucketCoreFactors.Font = new Font("Segoe UI", 9.2F);
            lblBucketCoreFactors.ForeColor = Color.LemonChiffon;
            lblBucketCoreFactors.Location = new Point(16, 104);
            lblBucketCoreFactors.Name = "lblBucketCoreFactors";
            lblBucketCoreFactors.Size = new Size(622, 90);
            lblBucketCoreFactors.TabIndex = 2;
            lblBucketCoreFactors.Text = "Etkileyen Faktörler: İrtifa eşiği ve sızıntı hızı bekleniyor...";
            // 
            // btnManualSeparate
            // 
            btnManualSeparate.BackColor = Color.FromArgb(180, 50, 50);
            btnManualSeparate.FlatStyle = FlatStyle.Flat;
            btnManualSeparate.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnManualSeparate.ForeColor = Color.White;
            btnManualSeparate.Location = new Point(16, 198);
            btnManualSeparate.Name = "btnManualSeparate";
            btnManualSeparate.Size = new Size(146, 34);
            btnManualSeparate.TabIndex = 3;
            btnManualSeparate.Text = "🛸 Ayrıl (S3)";
            btnManualSeparate.UseVisualStyleBackColor = false;
            btnManualSeparate.Click += BtnManualSeparate_Click;
            // 
            // btnManualParachute
            // 
            btnManualParachute.BackColor = Color.FromArgb(190, 110, 0);
            btnManualParachute.FlatStyle = FlatStyle.Flat;
            btnManualParachute.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnManualParachute.ForeColor = Color.White;
            btnManualParachute.Location = new Point(170, 198);
            btnManualParachute.Name = "btnManualParachute";
            btnManualParachute.Size = new Size(150, 34);
            btnManualParachute.TabIndex = 4;
            btnManualParachute.Text = "🪂 Paraşüt Aç";
            btnManualParachute.UseVisualStyleBackColor = false;
            btnManualParachute.Click += BtnManualParachute_Click;
            // 
            // btnManualHover
            // 
            btnManualHover.BackColor = Color.FromArgb(0, 120, 212);
            btnManualHover.FlatStyle = FlatStyle.Flat;
            btnManualHover.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnManualHover.ForeColor = Color.White;
            btnManualHover.Location = new Point(328, 198);
            btnManualHover.Name = "btnManualHover";
            btnManualHover.Size = new Size(150, 34);
            btnManualHover.TabIndex = 5;
            btnManualHover.Text = "🚁 Hover Modu";
            btnManualHover.UseVisualStyleBackColor = false;
            btnManualHover.Click += BtnManualHover_Click;
            // 
            // btnManualLanding
            // 
            btnManualLanding.BackColor = Color.FromArgb(16, 124, 65);
            btnManualLanding.FlatStyle = FlatStyle.Flat;
            btnManualLanding.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnManualLanding.ForeColor = Color.White;
            btnManualLanding.Location = new Point(486, 198);
            btnManualLanding.Name = "btnManualLanding";
            btnManualLanding.Size = new Size(150, 34);
            btnManualLanding.TabIndex = 6;
            btnManualLanding.Text = "🛬 İniş Onayı";
            btnManualLanding.UseVisualStyleBackColor = false;
            btnManualLanding.Click += BtnManualLanding_Click;
            timerPlayback.Interval = 50;
            timerPlayback.Tick += TimerPlayback_Tick;
            // 
            // FormSensorAnalizi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1971, 1410);
            Controls.Add(tabMain);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1633, 1163);
            Name = "FormSensorAnalizi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TÜRKSAT Model Uydu 2026 - RASAT #801470 Uçuş ve Hatalı Tetikleme Analiz Platformu";
            tabMain.ResumeLayout(false);
            tabPagePhysics.ResumeLayout(false);
            physicsLayout.ResumeLayout(false);
            panelPhysicsParams.ResumeLayout(false);
            grpMassAero.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numMassCarrier).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMassPayload).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAreaCarrier).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAreaPayload).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAreaApam).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAirDensity).EndInit();
            grpMission.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numHoverDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHoverAltitude).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSeparationAlt).EndInit();
            grpPID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numKp).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKi).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKd).EndInit();
            grpNoise.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numBaroBias).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBaroNoise).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBaroErrPct).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBaroSpikeStd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBaroSpikeFreq).EndInit();
            ((System.ComponentModel.ISupportInitialize)numImuBias).EndInit();
            ((System.ComponentModel.ISupportInitialize)numImuNoise).EndInit();
            ((System.ComponentModel.ISupportInitialize)numImuSpikeStd).EndInit();
            ((System.ComponentModel.ISupportInitialize)numImuSpikeFreq).EndInit();
            ((System.ComponentModel.ISupportInitialize)numImuVib).EndInit();
            grpBucket.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numFillRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numLeakRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBucketThresh).EndInit();
            panelPlayer.ResumeLayout(false);
            panelPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackTimeline).EndInit();
            panelLiveDashboard.ResumeLayout(false);
            panelPhysicsPlotsTable.ResumeLayout(false);

            panelDualCoreDashboard.ResumeLayout(false);
            grpEkfKernelCore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picEkfStackedBar).EndInit();
            tabPageCompare.ResumeLayout(false);
            mainLayout.ResumeLayout(false);
            topControlPanel.ResumeLayout(false);
            grpCustomSim.ResumeLayout(false);
            grpCustomSim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numErrorPercent).EndInit();
            bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMetrics).EndInit();
            btnPanel.ResumeLayout(false);
            grpLeakyBucketCore.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.FlowLayoutPanel panelPhysicsParams;

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

        private System.Windows.Forms.CheckBox chkToggleMassAero;
        private System.Windows.Forms.CheckBox chkToggleMission;
        private System.Windows.Forms.CheckBox chkTogglePID;
        private System.Windows.Forms.CheckBox chkToggleNoise;
        private System.Windows.Forms.CheckBox chkToggleBucket;

        private System.Windows.Forms.GroupBox grpNoise;
        private System.Windows.Forms.Label lblBaroNoise;
        private System.Windows.Forms.NumericUpDown numBaroNoise;
        private System.Windows.Forms.Label lblBaroErrPct;
        private System.Windows.Forms.NumericUpDown numBaroErrPct;
        private System.Windows.Forms.Label lblBaroBias;
        private System.Windows.Forms.NumericUpDown numBaroBias;
        private System.Windows.Forms.Label lblBaroSpikeStd;
        private System.Windows.Forms.NumericUpDown numBaroSpikeStd;
        private System.Windows.Forms.Label lblBaroSpikeFreq;
        private System.Windows.Forms.NumericUpDown numBaroSpikeFreq;

        private System.Windows.Forms.Label lblImuNoise;
        private System.Windows.Forms.NumericUpDown numImuNoise;
        private System.Windows.Forms.Label lblImuBias;
        private System.Windows.Forms.NumericUpDown numImuBias;
        private System.Windows.Forms.Label lblImuSpikeStd;
        private System.Windows.Forms.NumericUpDown numImuSpikeStd;
        private System.Windows.Forms.Label lblImuSpikeFreq;
        private System.Windows.Forms.NumericUpDown numImuSpikeFreq;
        private System.Windows.Forms.Label lblImuVib;
        private System.Windows.Forms.NumericUpDown numImuVib;

        private System.Windows.Forms.GroupBox grpBucket;
        private System.Windows.Forms.Label lblFillRate;
        private System.Windows.Forms.NumericUpDown numFillRate;
        private System.Windows.Forms.Label lblLeakRate;
        private System.Windows.Forms.NumericUpDown numLeakRate;
        private System.Windows.Forms.Label lblBucketThresh;
        private System.Windows.Forms.NumericUpDown numBucketThresh;

        private System.Windows.Forms.Button btnRunPhysics;

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

        private System.Windows.Forms.Button btnManualSeparate;

        private System.Windows.Forms.Button btnManualParachute;

        private System.Windows.Forms.Button btnManualHover;

        private System.Windows.Forms.Button btnManualLanding;
        private System.Windows.Forms.ProgressBar progBucketCore;
        private System.Windows.Forms.Label lblBucketCoreStatus;
        private System.Windows.Forms.Label lblBucketCoreFactors;
        private System.Windows.Forms.GroupBox grpEkfKernelCore;
        private System.Windows.Forms.PictureBox picEkfStackedBar;
        private System.Windows.Forms.Label lblEkfTrustDetails;
        private System.Windows.Forms.Timer timerPlayback;
        private System.Windows.Forms.Button btnResetMassAero;
        private System.Windows.Forms.Button btnResetMission;
        private System.Windows.Forms.Button btnResetPID;
        private System.Windows.Forms.Button btnResetNoise;
        private System.Windows.Forms.Button btnResetBucket;
        private System.Windows.Forms.TableLayoutPanel panelPhysicsPlotsTable;
        private ScottPlot.WinForms.FormsPlot plotPhysicsVelocity;
        private ScottPlot.WinForms.FormsPlot plotPhysicsAccel;
        private System.Windows.Forms.FlowLayoutPanel panelBucketCommands;
        private System.Windows.Forms.Button btnCmdSeparate;
        private System.Windows.Forms.Button btnCmdDeployParachute;
        private System.Windows.Forms.Button btnCmdHover;
        private System.Windows.Forms.Button btnCmdResetBucket;
    }
}
