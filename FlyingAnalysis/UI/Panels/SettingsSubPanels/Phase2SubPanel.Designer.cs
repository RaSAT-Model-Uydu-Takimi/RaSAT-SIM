namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    partial class Phase2SubPanel
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpGlidingPhysics = new System.Windows.Forms.GroupBox();
            this.lblMassInfo = new System.Windows.Forms.Label();
            this.lblAreaInfo = new System.Windows.Forms.Label();
            this.lblTerminalVelocity = new System.Windows.Forms.Label();
            this.grpSigmaLeakyBucket = new System.Windows.Forms.GroupBox();
            this.numBucketCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblBucketCapacityLabel = new System.Windows.Forms.Label();
            this.grpConditionTime = new System.Windows.Forms.GroupBox();
            this.numTimeThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblTimeThresholdLabel = new System.Windows.Forms.Label();
            this.numTimeFillCoeff = new System.Windows.Forms.NumericUpDown();
            this.lblTimeFillLabel = new System.Windows.Forms.Label();
            this.numTimeLeakCoeff = new System.Windows.Forms.NumericUpDown();
            this.lblTimeLeakLabel = new System.Windows.Forms.Label();
            this.grpConditionAlt = new System.Windows.Forms.GroupBox();
            this.numAltThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblAltThresholdLabel = new System.Windows.Forms.Label();
            this.numAltFillCoeff = new System.Windows.Forms.NumericUpDown();
            this.lblAltFillLabel = new System.Windows.Forms.Label();
            this.numAltLeakCoeff = new System.Windows.Forms.NumericUpDown();
            this.lblAltLeakLabel = new System.Windows.Forms.Label();
            this.grpTelecommand = new System.Windows.Forms.GroupBox();
            this.lblTelecommandInfo = new System.Windows.Forms.Label();
            this.grpTransitionLag = new System.Windows.Forms.GroupBox();
            this.numInflationLag = new System.Windows.Forms.NumericUpDown();
            this.lblInflationLagLabel = new System.Windows.Forms.Label();
            this.lblLagExplanation = new System.Windows.Forms.Label();
            this.grpForceDiagram = new System.Windows.Forms.GroupBox();
            this.lblForceHeader = new System.Windows.Forms.Label();
            this.lblForceDiagramVisual = new System.Windows.Forms.Label();
            this.lblTerminalVelCalc = new System.Windows.Forms.Label();
            this.grpGlidingPhysics.SuspendLayout();
            this.grpSigmaLeakyBucket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBucketCapacity)).BeginInit();
            this.grpConditionTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeFillCoeff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeLeakCoeff)).BeginInit();
            this.grpConditionAlt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAltThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltFillCoeff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltLeakCoeff)).BeginInit();
            this.grpTelecommand.SuspendLayout();
            this.grpTransitionLag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInflationLag)).BeginInit();
            this.grpForceDiagram.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(640, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "FAZ 2 PARAMETRELERİ: ANA PARAŞÜTLÜ SÜZÜLÜŞ VE SİGMA AYRILMA";
            // 
            // grpGlidingPhysics
            // 
            this.grpGlidingPhysics.Controls.Add(this.lblTerminalVelocity);
            this.grpGlidingPhysics.Controls.Add(this.lblAreaInfo);
            this.grpGlidingPhysics.Controls.Add(this.lblMassInfo);
            this.grpGlidingPhysics.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGlidingPhysics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpGlidingPhysics.Location = new System.Drawing.Point(25, 55);
            this.grpGlidingPhysics.Name = "grpGlidingPhysics";
            this.grpGlidingPhysics.Size = new System.Drawing.Size(870, 110);
            this.grpGlidingPhysics.TabIndex = 1;
            this.grpGlidingPhysics.TabStop = false;
            this.grpGlidingPhysics.Text = "1. Kısım: Paraşütlü Süzülüş Fizik Özeti (Sürtünme Aktif - Fg = Fd Denge Noktası)";
            // 
            // lblMassInfo
            // 
            this.lblMassInfo.AutoSize = true;
            this.lblMassInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMassInfo.Location = new System.Drawing.Point(20, 35);
            this.lblMassInfo.Name = "lblMassInfo";
            this.lblMassInfo.Size = new System.Drawing.Size(370, 21);
            this.lblMassInfo.TabIndex = 0;
            this.lblMassInfo.Text = "Aktif Kütle: 1800 gram (Taşıyıcı + Görev Yükü Toplamı)";
            // 
            // lblAreaInfo
            // 
            this.lblAreaInfo.AutoSize = true;
            this.lblAreaInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaInfo.Location = new System.Drawing.Point(20, 65);
            this.lblAreaInfo.Name = "lblAreaInfo";
            this.lblAreaInfo.Size = new System.Drawing.Size(415, 21);
            this.lblAreaInfo.TabIndex = 1;
            this.lblAreaInfo.Text = "Aktif Referans Alan: Ana Paraşüt (A_ana = 0.1256 m², Cd = 1.5)";
            // 
            // lblTerminalVelocity
            // 
            this.lblTerminalVelocity.AutoSize = true;
            this.lblTerminalVelocity.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminalVelocity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTerminalVelocity.Location = new System.Drawing.Point(480, 50);
            this.lblTerminalVelocity.Name = "lblTerminalVelocity";
            this.lblTerminalVelocity.Size = new System.Drawing.Size(340, 25);
            this.lblTerminalVelocity.TabIndex = 2;
            this.lblTerminalVelocity.Text = "Beklenen Limit Hız (v1): ~13.05 m/s";
            // 
            // grpSigmaLeakyBucket
            // 
            this.grpSigmaLeakyBucket.Controls.Add(this.grpTransitionLag);
            this.grpSigmaLeakyBucket.Controls.Add(this.grpTelecommand);
            this.grpSigmaLeakyBucket.Controls.Add(this.grpConditionAlt);
            this.grpSigmaLeakyBucket.Controls.Add(this.grpConditionTime);
            this.grpSigmaLeakyBucket.Controls.Add(this.lblBucketCapacityLabel);
            this.grpSigmaLeakyBucket.Controls.Add(this.numBucketCapacity);
            this.grpSigmaLeakyBucket.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSigmaLeakyBucket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpSigmaLeakyBucket.Location = new System.Drawing.Point(25, 175);
            this.grpSigmaLeakyBucket.Name = "grpSigmaLeakyBucket";
            this.grpSigmaLeakyBucket.Size = new System.Drawing.Size(870, 450);
            this.grpSigmaLeakyBucket.TabIndex = 2;
            this.grpSigmaLeakyBucket.TabStop = false;
            this.grpSigmaLeakyBucket.Text = "2. Kısım: Taşıyıcı Ayrılma Kararı (Faz 3\'e Geçiş Sızdıran Kova ve Telekomut)";
            // 
            // numBucketCapacity
            // 
            this.numBucketCapacity.DecimalPlaces = 1;
            this.numBucketCapacity.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBucketCapacity.Location = new System.Drawing.Point(20, 45);
            this.numBucketCapacity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numBucketCapacity.Name = "numBucketCapacity";
            this.numBucketCapacity.Size = new System.Drawing.Size(160, 32);
            this.numBucketCapacity.TabIndex = 0;
            this.numBucketCapacity.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblBucketCapacityLabel
            // 
            this.lblBucketCapacityLabel.AutoSize = true;
            this.lblBucketCapacityLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBucketCapacityLabel.Location = new System.Drawing.Point(18, 24);
            this.lblBucketCapacityLabel.Name = "lblBucketCapacityLabel";
            this.lblBucketCapacityLabel.Size = new System.Drawing.Size(202, 21);
            this.lblBucketCapacityLabel.TabIndex = 1;
            this.lblBucketCapacityLabel.Text = "Kova Büyüklüğü [Kapasite]";
            // 
            // grpConditionTime
            // 
            this.grpConditionTime.Controls.Add(this.lblTimeLeakLabel);
            this.grpConditionTime.Controls.Add(this.numTimeLeakCoeff);
            this.grpConditionTime.Controls.Add(this.lblTimeFillLabel);
            this.grpConditionTime.Controls.Add(this.numTimeFillCoeff);
            this.grpConditionTime.Controls.Add(this.lblTimeThresholdLabel);
            this.grpConditionTime.Controls.Add(this.numTimeThreshold);
            this.grpConditionTime.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConditionTime.Location = new System.Drawing.Point(20, 85);
            this.grpConditionTime.Name = "grpConditionTime";
            this.grpConditionTime.Size = new System.Drawing.Size(830, 105);
            this.grpConditionTime.TabIndex = 2;
            this.grpConditionTime.TabStop = false;
            this.grpConditionTime.Text = "Koşul 1: Pasif İniş Başlangıcından Gelen Süre Kontrolü";
            // 
            // numTimeThreshold
            // 
            this.numTimeThreshold.DecimalPlaces = 1;
            this.numTimeThreshold.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTimeThreshold.Location = new System.Drawing.Point(20, 55);
            this.numTimeThreshold.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            this.numTimeThreshold.Name = "numTimeThreshold";
            this.numTimeThreshold.Size = new System.Drawing.Size(160, 30);
            this.numTimeThreshold.TabIndex = 0;
            this.numTimeThreshold.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // lblTimeThresholdLabel
            // 
            this.lblTimeThresholdLabel.AutoSize = true;
            this.lblTimeThresholdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeThresholdLabel.Location = new System.Drawing.Point(18, 30);
            this.lblTimeThresholdLabel.Name = "lblTimeThresholdLabel";
            this.lblTimeThresholdLabel.Size = new System.Drawing.Size(166, 20);
            this.lblTimeThresholdLabel.TabIndex = 1;
            this.lblTimeThresholdLabel.Text = "Hedef Bekleme [saniye]";
            // 
            // numTimeFillCoeff
            // 
            this.numTimeFillCoeff.DecimalPlaces = 4;
            this.numTimeFillCoeff.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTimeFillCoeff.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            this.numTimeFillCoeff.Location = new System.Drawing.Point(230, 55);
            this.numTimeFillCoeff.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numTimeFillCoeff.Name = "numTimeFillCoeff";
            this.numTimeFillCoeff.Size = new System.Drawing.Size(160, 30);
            this.numTimeFillCoeff.TabIndex = 2;
            this.numTimeFillCoeff.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblTimeFillLabel
            // 
            this.lblTimeFillLabel.AutoSize = true;
            this.lblTimeFillLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeFillLabel.Location = new System.Drawing.Point(228, 30);
            this.lblTimeFillLabel.Name = "lblTimeFillLabel";
            this.lblTimeFillLabel.Size = new System.Drawing.Size(185, 20);
            this.lblTimeFillLabel.TabIndex = 3;
            this.lblTimeFillLabel.Text = "Doldurma Katsayısı [Fill]";
            // 
            // numTimeLeakCoeff
            // 
            this.numTimeLeakCoeff.DecimalPlaces = 4;
            this.numTimeLeakCoeff.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTimeLeakCoeff.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            this.numTimeLeakCoeff.Location = new System.Drawing.Point(440, 55);
            this.numTimeLeakCoeff.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numTimeLeakCoeff.Name = "numTimeLeakCoeff";
            this.numTimeLeakCoeff.Size = new System.Drawing.Size(160, 30);
            this.numTimeLeakCoeff.TabIndex = 4;
            this.numTimeLeakCoeff.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // lblTimeLeakLabel
            // 
            this.lblTimeLeakLabel.AutoSize = true;
            this.lblTimeLeakLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeakLabel.Location = new System.Drawing.Point(438, 30);
            this.lblTimeLeakLabel.Name = "lblTimeLeakLabel";
            this.lblTimeLeakLabel.Size = new System.Drawing.Size(186, 20);
            this.lblTimeLeakLabel.TabIndex = 5;
            this.lblTimeLeakLabel.Text = "Boşaltma Katsayısı [Leak]";
            // 
            // grpConditionAlt
            // 
            this.grpConditionAlt.Controls.Add(this.lblAltLeakLabel);
            this.grpConditionAlt.Controls.Add(this.numAltLeakCoeff);
            this.grpConditionAlt.Controls.Add(this.lblAltFillLabel);
            this.grpConditionAlt.Controls.Add(this.numAltFillCoeff);
            this.grpConditionAlt.Controls.Add(this.lblAltThresholdLabel);
            this.grpConditionAlt.Controls.Add(this.numAltThreshold);
            this.grpConditionAlt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConditionAlt.Location = new System.Drawing.Point(20, 198);
            this.grpConditionAlt.Name = "grpConditionAlt";
            this.grpConditionAlt.Size = new System.Drawing.Size(830, 105);
            this.grpConditionAlt.TabIndex = 3;
            this.grpConditionAlt.TabStop = false;
            this.grpConditionAlt.Text = "Koşul 2: Hedef İrtifa Eşiği (Örn: 400m Altına İniş Kontrolü)";
            // 
            // numAltThreshold
            // 
            this.numAltThreshold.DecimalPlaces = 1;
            this.numAltThreshold.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAltThreshold.Location = new System.Drawing.Point(20, 55);
            this.numAltThreshold.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            this.numAltThreshold.Name = "numAltThreshold";
            this.numAltThreshold.Size = new System.Drawing.Size(160, 30);
            this.numAltThreshold.TabIndex = 0;
            this.numAltThreshold.Value = new decimal(new int[] { 400, 0, 0, 0 });
            // 
            // lblAltThresholdLabel
            // 
            this.lblAltThresholdLabel.AutoSize = true;
            this.lblAltThresholdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltThresholdLabel.Location = new System.Drawing.Point(18, 30);
            this.lblAltThresholdLabel.Name = "lblAltThresholdLabel";
            this.lblAltThresholdLabel.Size = new System.Drawing.Size(155, 20);
            this.lblAltThresholdLabel.TabIndex = 1;
            this.lblAltThresholdLabel.Text = "İrtifa Eşik Değeri [m]";
            // 
            // numAltFillCoeff
            // 
            this.numAltFillCoeff.DecimalPlaces = 4;
            this.numAltFillCoeff.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAltFillCoeff.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            this.numAltFillCoeff.Location = new System.Drawing.Point(230, 55);
            this.numAltFillCoeff.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numAltFillCoeff.Name = "numAltFillCoeff";
            this.numAltFillCoeff.Size = new System.Drawing.Size(160, 30);
            this.numAltFillCoeff.TabIndex = 2;
            this.numAltFillCoeff.Value = new decimal(new int[] { 8, 0, 0, 131072 });
            // 
            // lblAltFillLabel
            // 
            this.lblAltFillLabel.AutoSize = true;
            this.lblAltFillLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltFillLabel.Location = new System.Drawing.Point(228, 30);
            this.lblAltFillLabel.Name = "lblAltFillLabel";
            this.lblAltFillLabel.Size = new System.Drawing.Size(185, 20);
            this.lblAltFillLabel.TabIndex = 3;
            this.lblAltFillLabel.Text = "Doldurma Katsayısı [Fill]";
            // 
            // numAltLeakCoeff
            // 
            this.numAltLeakCoeff.DecimalPlaces = 4;
            this.numAltLeakCoeff.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAltLeakCoeff.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            this.numAltLeakCoeff.Location = new System.Drawing.Point(440, 55);
            this.numAltLeakCoeff.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numAltLeakCoeff.Name = "numAltLeakCoeff";
            this.numAltLeakCoeff.Size = new System.Drawing.Size(160, 30);
            this.numAltLeakCoeff.TabIndex = 4;
            this.numAltLeakCoeff.Value = new decimal(new int[] { 3, 0, 0, 131072 });
            // 
            // lblAltLeakLabel
            // 
            this.lblAltLeakLabel.AutoSize = true;
            this.lblAltLeakLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltLeakLabel.Location = new System.Drawing.Point(438, 30);
            this.lblAltLeakLabel.Name = "lblAltLeakLabel";
            this.lblAltLeakLabel.Size = new System.Drawing.Size(186, 20);
            this.lblAltLeakLabel.TabIndex = 5;
            this.lblAltLeakLabel.Text = "Boşaltma Katsayısı [Leak]";
            // 
            // grpTelecommand
            // 
            this.grpTelecommand.Controls.Add(this.lblTelecommandInfo);
            this.grpTelecommand.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTelecommand.Location = new System.Drawing.Point(20, 310);
            this.grpTelecommand.Name = "grpTelecommand";
            this.grpTelecommand.Size = new System.Drawing.Size(400, 125);
            this.grpTelecommand.TabIndex = 4;
            this.grpTelecommand.TabStop = false;
            this.grpTelecommand.Text = "Koşul 3: Yer İstasyonu Ayrılma Emri";
            // 
            // lblTelecommandInfo
            // 
            this.lblTelecommandInfo.AutoSize = true;
            this.lblTelecommandInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelecommandInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.lblTelecommandInfo.Location = new System.Drawing.Point(15, 30);
            this.lblTelecommandInfo.Name = "lblTelecommandInfo";
            this.lblTelecommandInfo.Size = new System.Drawing.Size(365, 60);
            this.lblTelecommandInfo.TabIndex = 0;
            this.lblTelecommandInfo.Text = "Öncelik Tetikleyicisi (Priority Override):\r\nYer istasyonundan \"SEPARATE\" emri gelirse, kova\r\nanında %100 dolar ve SİGMA ayrılması tetiklenir.";
            // 
            // grpTransitionLag
            // 
            this.grpTransitionLag.Controls.Add(this.lblLagExplanation);
            this.grpTransitionLag.Controls.Add(this.lblInflationLagLabel);
            this.grpTransitionLag.Controls.Add(this.numInflationLag);
            this.grpTransitionLag.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTransitionLag.Location = new System.Drawing.Point(435, 310);
            this.grpTransitionLag.Name = "grpTransitionLag";
            this.grpTransitionLag.Size = new System.Drawing.Size(415, 125);
            this.grpTransitionLag.TabIndex = 5;
            this.grpTransitionLag.TabStop = false;
            this.grpTransitionLag.Text = "Ara Faz Gecikmesi (Paraşüt Şişme Rötarı)";
            // 
            // numInflationLag
            // 
            this.numInflationLag.DecimalPlaces = 2;
            this.numInflationLag.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numInflationLag.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numInflationLag.Location = new System.Drawing.Point(20, 50);
            this.numInflationLag.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numInflationLag.Name = "numInflationLag";
            this.numInflationLag.Size = new System.Drawing.Size(140, 30);
            this.numInflationLag.TabIndex = 0;
            this.numInflationLag.Value = new decimal(new int[] { 15, 0, 0, 65536 });
            // 
            // lblInflationLagLabel
            // 
            this.lblInflationLagLabel.AutoSize = true;
            this.lblInflationLagLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInflationLagLabel.Location = new System.Drawing.Point(18, 25);
            this.lblInflationLagLabel.Name = "lblInflationLagLabel";
            this.lblInflationLagLabel.Size = new System.Drawing.Size(183, 20);
            this.lblInflationLagLabel.TabIndex = 1;
            this.lblInflationLagLabel.Text = "Şişme Rötar Süresi [saniye]";
            // 
            // lblLagExplanation
            // 
            this.lblLagExplanation.AutoSize = true;
            this.lblLagExplanation.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLagExplanation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblLagExplanation.Location = new System.Drawing.Point(18, 85);
            this.lblLagExplanation.Name = "lblLagExplanation";
            this.lblLagExplanation.Size = new System.Drawing.Size(380, 20);
            this.lblLagExplanation.TabIndex = 2;
            this.lblLagExplanation.Text = "Not: Yüzey alanı mevcut alandan hedefe doğrusal artar.";
            // 
            // grpForceDiagram
            // 
            this.grpForceDiagram.Controls.Add(this.lblTerminalVelCalc);
            this.grpForceDiagram.Controls.Add(this.lblForceDiagramVisual);
            this.grpForceDiagram.Controls.Add(this.lblForceHeader);
            this.grpForceDiagram.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpForceDiagram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpForceDiagram.Location = new System.Drawing.Point(910, 55);
            this.grpForceDiagram.Name = "grpForceDiagram";
            this.grpForceDiagram.Size = new System.Drawing.Size(350, 570);
            this.grpForceDiagram.TabIndex = 3;
            this.grpForceDiagram.TabStop = false;
            this.grpForceDiagram.Text = "📊 Kuvvet Vektör Diyagramı & Limit Hız";
            // 
            // lblForceHeader
            // 
            this.lblForceHeader.AutoSize = true;
            this.lblForceHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblForceHeader.Location = new System.Drawing.Point(15, 35);
            this.lblForceHeader.Name = "lblForceHeader";
            this.lblForceHeader.Size = new System.Drawing.Size(315, 42);
            this.lblForceHeader.TabIndex = 0;
            this.lblForceHeader.Text = "▼ Fg (Yerçekimi Kuvveti) = 17.65 N\r\n▲ Fd (Hava Sürtünmesi) = 17.65 N";
            // 
            // lblForceDiagramVisual
            // 
            this.lblForceDiagramVisual.AutoSize = true;
            this.lblForceDiagramVisual.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForceDiagramVisual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblForceDiagramVisual.Location = new System.Drawing.Point(20, 100);
            this.lblForceDiagramVisual.Name = "lblForceDiagramVisual";
            this.lblForceDiagramVisual.Size = new System.Drawing.Size(305, 260);
            this.lblForceDiagramVisual.TabIndex = 1;
            this.lblForceDiagramVisual.Text = "     ▲  Fd (Sürtünme Kuvveti)\r\n     │  = 17.65 Newton\r\n     │  (Limit Hızda Fg\'ye Eşit)\r\n┌────┴────┐\r\n│  UYDU   │  (Ana Paraşüt Açık)\r\n│ MODÜLÜ  │  A = 0.1256 m²\r\n└────┬────┘  Cd = 1.5\r\n     │\r\n     │\r\n     ▼  Fg (Yerçekimi Kuvveti)\r\n        = 1.8 kg × 9.807 m/s²\r\n        = 17.65 Newton\r\n\r\n(Denge Noktası: F_net = 0 N)";
            // 
            // lblTerminalVelCalc
            // 
            this.lblTerminalVelCalc.AutoSize = true;
            this.lblTerminalVelCalc.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminalVelCalc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTerminalVelCalc.Location = new System.Drawing.Point(15, 390);
            this.lblTerminalVelCalc.Name = "lblTerminalVelCalc";
            this.lblTerminalVelCalc.Size = new System.Drawing.Size(320, 140);
            this.lblTerminalVelCalc.TabIndex = 2;
            this.lblTerminalVelCalc.Text = "🚀 Teorik Limit Hız (v_limit):\r\n   = 13.05 m/s (~46.98 km/h)\r\n\r\nFormül:\r\nv = √( 2·m·g / (ρ·Cd·A) )\r\n= √( 2×1.8×9.807 / (1.225×1.5×0.1256) )";
            // 
            // Phase2SubPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.grpForceDiagram);
            this.Controls.Add(this.grpSigmaLeakyBucket);
            this.Controls.Add(this.grpGlidingPhysics);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Phase2SubPanel";
            this.Size = new System.Drawing.Size(1280, 650);
            this.grpGlidingPhysics.ResumeLayout(false);
            this.grpGlidingPhysics.PerformLayout();
            this.grpSigmaLeakyBucket.ResumeLayout(false);
            this.grpSigmaLeakyBucket.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBucketCapacity)).EndInit();
            this.grpConditionTime.ResumeLayout(false);
            this.grpConditionTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeFillCoeff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeLeakCoeff)).EndInit();
            this.grpConditionAlt.ResumeLayout(false);
            this.grpConditionAlt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAltThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltFillCoeff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltLeakCoeff)).EndInit();
            this.grpTelecommand.ResumeLayout(false);
            this.grpTelecommand.PerformLayout();
            this.grpTransitionLag.ResumeLayout(false);
            this.grpTransitionLag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInflationLag)).EndInit();
            this.grpForceDiagram.ResumeLayout(false);
            this.grpForceDiagram.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpGlidingPhysics;
        private System.Windows.Forms.Label lblMassInfo;
        private System.Windows.Forms.Label lblAreaInfo;
        private System.Windows.Forms.Label lblTerminalVelocity;
        private System.Windows.Forms.GroupBox grpSigmaLeakyBucket;
        private System.Windows.Forms.NumericUpDown numBucketCapacity;
        private System.Windows.Forms.Label lblBucketCapacityLabel;
        private System.Windows.Forms.GroupBox grpConditionTime;
        private System.Windows.Forms.NumericUpDown numTimeThreshold;
        private System.Windows.Forms.Label lblTimeThresholdLabel;
        private System.Windows.Forms.NumericUpDown numTimeFillCoeff;
        private System.Windows.Forms.Label lblTimeFillLabel;
        private System.Windows.Forms.NumericUpDown numTimeLeakCoeff;
        private System.Windows.Forms.Label lblTimeLeakLabel;
        private System.Windows.Forms.GroupBox grpConditionAlt;
        private System.Windows.Forms.NumericUpDown numAltThreshold;
        private System.Windows.Forms.Label lblAltThresholdLabel;
        private System.Windows.Forms.NumericUpDown numAltFillCoeff;
        private System.Windows.Forms.Label lblAltFillLabel;
        private System.Windows.Forms.NumericUpDown numAltLeakCoeff;
        private System.Windows.Forms.Label lblAltLeakLabel;
        private System.Windows.Forms.GroupBox grpTelecommand;
        private System.Windows.Forms.Label lblTelecommandInfo;
        private System.Windows.Forms.GroupBox grpTransitionLag;
        private System.Windows.Forms.NumericUpDown numInflationLag;
        private System.Windows.Forms.Label lblInflationLagLabel;
        private System.Windows.Forms.Label lblLagExplanation;
        private System.Windows.Forms.GroupBox grpForceDiagram;
        private System.Windows.Forms.Label lblForceHeader;
        private System.Windows.Forms.Label lblForceDiagramVisual;
        private System.Windows.Forms.Label lblTerminalVelCalc;
    }
}

