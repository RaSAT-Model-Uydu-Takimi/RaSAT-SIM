namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    partial class Phase1SubPanel
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
            this.grpRocketKinematics = new System.Windows.Forms.GroupBox();
            this.numRocketVelocity = new System.Windows.Forms.NumericUpDown();
            this.lblRocketVelocityLabel = new System.Windows.Forms.Label();
            this.numRocketDuration = new System.Windows.Forms.NumericUpDown();
            this.lblRocketDurationLabel = new System.Windows.Forms.Label();
            this.lblKinematicInfo = new System.Windows.Forms.Label();
            this.grpLeakyBucket = new System.Windows.Forms.GroupBox();
            this.numBucketCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblBucketCapacityLabel = new System.Windows.Forms.Label();
            this.lblFormulaInfo = new System.Windows.Forms.Label();
            this.grpConditionAltitude = new System.Windows.Forms.GroupBox();
            this.numAltThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblAltThresholdLabel = new System.Windows.Forms.Label();
            this.numAltFillCoeff = new System.Windows.Forms.NumericUpDown();
            this.lblAltFillLabel = new System.Windows.Forms.Label();
            this.numAltLeakCoeff = new System.Windows.Forms.NumericUpDown();
            this.lblAltLeakLabel = new System.Windows.Forms.Label();
            this.grpConditionVelocity = new System.Windows.Forms.GroupBox();
            this.numVelThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblVelThresholdLabel = new System.Windows.Forms.Label();
            this.numVelFillCoeff = new System.Windows.Forms.NumericUpDown();
            this.lblVelFillLabel = new System.Windows.Forms.Label();
            this.numVelLeakCoeff = new System.Windows.Forms.NumericUpDown();
            this.lblVelLeakLabel = new System.Windows.Forms.Label();
            this.grpRocketKinematics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRocketVelocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRocketDuration)).BeginInit();
            this.grpLeakyBucket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBucketCapacity)).BeginInit();
            this.grpConditionAltitude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAltThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltFillCoeff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltLeakCoeff)).BeginInit();
            this.grpConditionVelocity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVelThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVelFillCoeff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVelLeakCoeff)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "FAZ 1 PARAMETRELERİ: ROKETLE YÜKSELİŞ VE AYRILMA KARARI";
            // 
            // grpRocketKinematics
            // 
            this.grpRocketKinematics.Controls.Add(this.lblKinematicInfo);
            this.grpRocketKinematics.Controls.Add(this.lblRocketDurationLabel);
            this.grpRocketKinematics.Controls.Add(this.numRocketDuration);
            this.grpRocketKinematics.Controls.Add(this.lblRocketVelocityLabel);
            this.grpRocketKinematics.Controls.Add(this.numRocketVelocity);
            this.grpRocketKinematics.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRocketKinematics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpRocketKinematics.Location = new System.Drawing.Point(25, 70);
            this.grpRocketKinematics.Name = "grpRocketKinematics";
            this.grpRocketKinematics.Size = new System.Drawing.Size(870, 130);
            this.grpRocketKinematics.TabIndex = 1;
            this.grpRocketKinematics.TabStop = false;
            this.grpRocketKinematics.Text = "1. Kısım: Roket Kinematik Girdileri (Sürtünme Kapalı - Kinematik Kilit Modu)";
            // 
            // numRocketVelocity
            // 
            this.numRocketVelocity.DecimalPlaces = 2;
            this.numRocketVelocity.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRocketVelocity.Location = new System.Drawing.Point(20, 55);
            this.numRocketVelocity.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numRocketVelocity.Name = "numRocketVelocity";
            this.numRocketVelocity.Size = new System.Drawing.Size(160, 32);
            this.numRocketVelocity.TabIndex = 0;
            this.numRocketVelocity.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // lblRocketVelocityLabel
            // 
            this.lblRocketVelocityLabel.AutoSize = true;
            this.lblRocketVelocityLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRocketVelocityLabel.Location = new System.Drawing.Point(18, 30);
            this.lblRocketVelocityLabel.Name = "lblRocketVelocityLabel";
            this.lblRocketVelocityLabel.Size = new System.Drawing.Size(217, 21);
            this.lblRocketVelocityLabel.TabIndex = 1;
            this.lblRocketVelocityLabel.Text = "Roket Dikey Tırmanış Hızı [m/s]";
            // 
            // numRocketDuration
            // 
            this.numRocketDuration.DecimalPlaces = 2;
            this.numRocketDuration.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRocketDuration.Location = new System.Drawing.Point(280, 55);
            this.numRocketDuration.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            this.numRocketDuration.Name = "numRocketDuration";
            this.numRocketDuration.Size = new System.Drawing.Size(160, 32);
            this.numRocketDuration.TabIndex = 2;
            this.numRocketDuration.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // lblRocketDurationLabel
            // 
            this.lblRocketDurationLabel.AutoSize = true;
            this.lblRocketDurationLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRocketDurationLabel.Location = new System.Drawing.Point(278, 30);
            this.lblRocketDurationLabel.Name = "lblRocketDurationLabel";
            this.lblRocketDurationLabel.Size = new System.Drawing.Size(193, 21);
            this.lblRocketDurationLabel.TabIndex = 3;
            this.lblRocketDurationLabel.Text = "Bu Hızda Uçuş Süresi [saniye]";
            // 
            // lblKinematicInfo
            // 
            this.lblKinematicInfo.AutoSize = true;
            this.lblKinematicInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKinematicInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblKinematicInfo.Location = new System.Drawing.Point(18, 95);
            this.lblKinematicInfo.Name = "lblKinematicInfo";
            this.lblKinematicInfo.Size = new System.Drawing.Size(650, 20);
            this.lblKinematicInfo.TabIndex = 4;
            this.lblKinematicInfo.Text = "Not: Bu faz boyunca fizik motoru sabit hızla konum günceller. Süre dolduğunda ayrılma tetiklenir.";
            // 
            // grpLeakyBucket
            // 
            this.grpLeakyBucket.Controls.Add(this.grpConditionVelocity);
            this.grpLeakyBucket.Controls.Add(this.grpConditionAltitude);
            this.grpLeakyBucket.Controls.Add(this.lblFormulaInfo);
            this.grpLeakyBucket.Controls.Add(this.lblBucketCapacityLabel);
            this.grpLeakyBucket.Controls.Add(this.numBucketCapacity);
            this.grpLeakyBucket.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLeakyBucket.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpLeakyBucket.Location = new System.Drawing.Point(25, 215);
            this.grpLeakyBucket.Name = "grpLeakyBucket";
            this.grpLeakyBucket.Size = new System.Drawing.Size(870, 400);
            this.grpLeakyBucket.TabIndex = 2;
            this.grpLeakyBucket.TabStop = false;
            this.grpLeakyBucket.Text = "2. Kısım: Sızdıran Kova (Leaky Bucket) Algoritması - Faz 2\'ye Geçiş Kararı";
            // 
            // numBucketCapacity
            // 
            this.numBucketCapacity.DecimalPlaces = 1;
            this.numBucketCapacity.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBucketCapacity.Location = new System.Drawing.Point(20, 55);
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
            this.lblBucketCapacityLabel.Location = new System.Drawing.Point(18, 30);
            this.lblBucketCapacityLabel.Name = "lblBucketCapacityLabel";
            this.lblBucketCapacityLabel.Size = new System.Drawing.Size(202, 21);
            this.lblBucketCapacityLabel.TabIndex = 1;
            this.lblBucketCapacityLabel.Text = "Kova Büyüklüğü [Kapasite]";
            // 
            // lblFormulaInfo
            // 
            this.lblFormulaInfo.AutoSize = true;
            this.lblFormulaInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormulaInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblFormulaInfo.Location = new System.Drawing.Point(240, 58);
            this.lblFormulaInfo.Name = "lblFormulaInfo";
            this.lblFormulaInfo.Size = new System.Drawing.Size(460, 21);
            this.lblFormulaInfo.TabIndex = 2;
            this.lblFormulaInfo.Text = "Zamana Göre İntegral Formülü: Delta Kova = (Ölçülen - Eşik) * DeltaTime * DolumKatsayısı";

            // 
            // grpConditionAltitude
            // 
            this.grpConditionAltitude.Controls.Add(this.lblAltLeakLabel);
            this.grpConditionAltitude.Controls.Add(this.numAltLeakCoeff);
            this.grpConditionAltitude.Controls.Add(this.lblAltFillLabel);
            this.grpConditionAltitude.Controls.Add(this.numAltFillCoeff);
            this.grpConditionAltitude.Controls.Add(this.lblAltThresholdLabel);
            this.grpConditionAltitude.Controls.Add(this.numAltThreshold);
            this.grpConditionAltitude.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConditionAltitude.Location = new System.Drawing.Point(20, 105);
            this.grpConditionAltitude.Name = "grpConditionAltitude";
            this.grpConditionAltitude.Size = new System.Drawing.Size(830, 130);
            this.grpConditionAltitude.TabIndex = 3;
            this.grpConditionAltitude.TabStop = false;
            this.grpConditionAltitude.Text = "Koşul 1: İşlenmiş İrtifa Kontrolü (Hedef > İrtifa Eşiği)";
            // 
            // numAltThreshold
            // 
            this.numAltThreshold.DecimalPlaces = 1;
            this.numAltThreshold.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAltThreshold.Location = new System.Drawing.Point(20, 65);
            this.numAltThreshold.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numAltThreshold.Name = "numAltThreshold";
            this.numAltThreshold.Size = new System.Drawing.Size(160, 30);
            this.numAltThreshold.TabIndex = 0;
            this.numAltThreshold.Value = new decimal(new int[] { 1800, 0, 0, 0 });
            // 
            // lblAltThresholdLabel
            // 
            this.lblAltThresholdLabel.AutoSize = true;
            this.lblAltThresholdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltThresholdLabel.Location = new System.Drawing.Point(18, 40);
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
            this.numAltFillCoeff.Location = new System.Drawing.Point(230, 65);
            this.numAltFillCoeff.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numAltFillCoeff.Name = "numAltFillCoeff";
            this.numAltFillCoeff.Size = new System.Drawing.Size(160, 30);
            this.numAltFillCoeff.TabIndex = 2;
            this.numAltFillCoeff.Value = new decimal(new int[] { 5, 0, 0, 131072 });
            // 
            // lblAltFillLabel
            // 
            this.lblAltFillLabel.AutoSize = true;
            this.lblAltFillLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltFillLabel.Location = new System.Drawing.Point(228, 40);
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
            this.numAltLeakCoeff.Location = new System.Drawing.Point(440, 65);
            this.numAltLeakCoeff.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numAltLeakCoeff.Name = "numAltLeakCoeff";
            this.numAltLeakCoeff.Size = new System.Drawing.Size(160, 30);
            this.numAltLeakCoeff.TabIndex = 4;
            this.numAltLeakCoeff.Value = new decimal(new int[] { 2, 0, 0, 131072 });
            // 
            // lblAltLeakLabel
            // 
            this.lblAltLeakLabel.AutoSize = true;
            this.lblAltLeakLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltLeakLabel.Location = new System.Drawing.Point(438, 40);
            this.lblAltLeakLabel.Name = "lblAltLeakLabel";
            this.lblAltLeakLabel.Size = new System.Drawing.Size(186, 20);
            this.lblAltLeakLabel.TabIndex = 5;
            this.lblAltLeakLabel.Text = "Boşaltma Katsayısı [Leak]";
            // 
            // grpConditionVelocity
            // 
            this.grpConditionVelocity.Controls.Add(this.lblVelLeakLabel);
            this.grpConditionVelocity.Controls.Add(this.numVelLeakCoeff);
            this.grpConditionVelocity.Controls.Add(this.lblVelFillLabel);
            this.grpConditionVelocity.Controls.Add(this.numVelFillCoeff);
            this.grpConditionVelocity.Controls.Add(this.lblVelThresholdLabel);
            this.grpConditionVelocity.Controls.Add(this.numVelThreshold);
            this.grpConditionVelocity.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConditionVelocity.Location = new System.Drawing.Point(20, 250);
            this.grpConditionVelocity.Name = "grpConditionVelocity";
            this.grpConditionVelocity.Size = new System.Drawing.Size(830, 130);
            this.grpConditionVelocity.TabIndex = 4;
            this.grpConditionVelocity.TabStop = false;
            this.grpConditionVelocity.Text = "Koşul 2: İşlenmiş Dikey Hız Kontrolü (Hedef Hız < 0 m/s - Süzülüş Başlangıcı)";
            // 
            // numVelThreshold
            // 
            this.numVelThreshold.DecimalPlaces = 2;
            this.numVelThreshold.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numVelThreshold.Location = new System.Drawing.Point(20, 65);
            this.numVelThreshold.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numVelThreshold.Minimum = new decimal(new int[] { 100, 0, 0, -2147483648 });
            this.numVelThreshold.Name = "numVelThreshold";
            this.numVelThreshold.Size = new System.Drawing.Size(160, 30);
            this.numVelThreshold.TabIndex = 0;
            // 
            // lblVelThresholdLabel
            // 
            this.lblVelThresholdLabel.AutoSize = true;
            this.lblVelThresholdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVelThresholdLabel.Location = new System.Drawing.Point(18, 40);
            this.lblVelThresholdLabel.Name = "lblVelThresholdLabel";
            this.lblVelThresholdLabel.Size = new System.Drawing.Size(157, 20);
            this.lblVelThresholdLabel.TabIndex = 1;
            this.lblVelThresholdLabel.Text = "Hız Eşik Değeri [m/s]";
            // 
            // numVelFillCoeff
            // 
            this.numVelFillCoeff.DecimalPlaces = 4;
            this.numVelFillCoeff.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numVelFillCoeff.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            this.numVelFillCoeff.Location = new System.Drawing.Point(230, 65);
            this.numVelFillCoeff.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numVelFillCoeff.Name = "numVelFillCoeff";
            this.numVelFillCoeff.Size = new System.Drawing.Size(160, 30);
            this.numVelFillCoeff.TabIndex = 2;
            this.numVelFillCoeff.Value = new decimal(new int[] { 1, 0, 0, 65536 });
            // 
            // lblVelFillLabel
            // 
            this.lblVelFillLabel.AutoSize = true;
            this.lblVelFillLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVelFillLabel.Location = new System.Drawing.Point(228, 40);
            this.lblVelFillLabel.Name = "lblVelFillLabel";
            this.lblVelFillLabel.Size = new System.Drawing.Size(185, 20);
            this.lblVelFillLabel.TabIndex = 3;
            this.lblVelFillLabel.Text = "Doldurma Katsayısı [Fill]";
            // 
            // numVelLeakCoeff
            // 
            this.numVelLeakCoeff.DecimalPlaces = 4;
            this.numVelLeakCoeff.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numVelLeakCoeff.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            this.numVelLeakCoeff.Location = new System.Drawing.Point(440, 65);
            this.numVelLeakCoeff.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numVelLeakCoeff.Name = "numVelLeakCoeff";
            this.numVelLeakCoeff.Size = new System.Drawing.Size(160, 30);
            this.numVelLeakCoeff.TabIndex = 4;
            this.numVelLeakCoeff.Value = new decimal(new int[] { 5, 0, 0, 131072 });
            // 
            // lblVelLeakLabel
            // 
            this.lblVelLeakLabel.AutoSize = true;
            this.lblVelLeakLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVelLeakLabel.Location = new System.Drawing.Point(438, 40);
            this.lblVelLeakLabel.Name = "lblVelLeakLabel";
            this.lblVelLeakLabel.Size = new System.Drawing.Size(186, 20);
            this.lblVelLeakLabel.TabIndex = 5;
            this.lblVelLeakLabel.Text = "Boşaltma Katsayısı [Leak]";
            // 
            // Phase1SubPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.grpLeakyBucket);
            this.Controls.Add(this.grpRocketKinematics);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Phase1SubPanel";
            this.Size = new System.Drawing.Size(920, 640);
            this.grpRocketKinematics.ResumeLayout(false);
            this.grpRocketKinematics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRocketVelocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRocketDuration)).EndInit();
            this.grpLeakyBucket.ResumeLayout(false);
            this.grpLeakyBucket.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBucketCapacity)).EndInit();
            this.grpConditionAltitude.ResumeLayout(false);
            this.grpConditionAltitude.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAltThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltFillCoeff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltLeakCoeff)).EndInit();
            this.grpConditionVelocity.ResumeLayout(false);
            this.grpConditionVelocity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVelThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVelFillCoeff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVelLeakCoeff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpRocketKinematics;
        private System.Windows.Forms.NumericUpDown numRocketVelocity;
        private System.Windows.Forms.Label lblRocketVelocityLabel;
        private System.Windows.Forms.NumericUpDown numRocketDuration;
        private System.Windows.Forms.Label lblRocketDurationLabel;
        private System.Windows.Forms.Label lblKinematicInfo;
        private System.Windows.Forms.GroupBox grpLeakyBucket;
        private System.Windows.Forms.NumericUpDown numBucketCapacity;
        private System.Windows.Forms.Label lblBucketCapacityLabel;
        private System.Windows.Forms.Label lblFormulaInfo;
        private System.Windows.Forms.GroupBox grpConditionAltitude;
        private System.Windows.Forms.NumericUpDown numAltThreshold;
        private System.Windows.Forms.Label lblAltThresholdLabel;
        private System.Windows.Forms.NumericUpDown numAltFillCoeff;
        private System.Windows.Forms.Label lblAltFillLabel;
        private System.Windows.Forms.NumericUpDown numAltLeakCoeff;
        private System.Windows.Forms.Label lblAltLeakLabel;
        private System.Windows.Forms.GroupBox grpConditionVelocity;
        private System.Windows.Forms.NumericUpDown numVelThreshold;
        private System.Windows.Forms.Label lblVelThresholdLabel;
        private System.Windows.Forms.NumericUpDown numVelFillCoeff;
        private System.Windows.Forms.Label lblVelFillLabel;
        private System.Windows.Forms.NumericUpDown numVelLeakCoeff;
        private System.Windows.Forms.Label lblVelLeakLabel;
    }
}
