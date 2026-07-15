namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    partial class ApamSubPanel
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
            this.grpApamTrigger = new System.Windows.Forms.GroupBox();
            this.lblSpeedThreshold = new System.Windows.Forms.Label();
            this.numSpeedThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblBucketCapacity = new System.Windows.Forms.Label();
            this.numBucketCapacity = new System.Windows.Forms.NumericUpDown();
            this.lblFillRate = new System.Windows.Forms.Label();
            this.numFillRate = new System.Windows.Forms.NumericUpDown();
            this.lblLeakRate = new System.Windows.Forms.Label();
            this.numLeakRate = new System.Windows.Forms.NumericUpDown();
            this.lblTriggerInfo = new System.Windows.Forms.Label();
            this.grpApamDeploy = new System.Windows.Forms.GroupBox();
            this.lblApamArea = new System.Windows.Forms.Label();
            this.numApamArea = new System.Windows.Forms.NumericUpDown();
            this.lblInflationLag = new System.Windows.Forms.Label();
            this.numInflationLag = new System.Windows.Forms.NumericUpDown();
            this.lblDeployNote = new System.Windows.Forms.Label();
            this.grpForceDiagram = new System.Windows.Forms.GroupBox();
            this.lblForceHeader = new System.Windows.Forms.Label();
            this.lblForceDiagramVisual = new System.Windows.Forms.Label();
            this.lblTerminalVelCalc = new System.Windows.Forms.Label();
            this.grpApamTrigger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBucketCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFillRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeakRate)).BeginInit();
            this.grpApamDeploy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numApamArea)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(690, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "7. APAM PARAMETRELERİ: ACİL DURUM PARAŞÜT VE KORUMA BLOKLARI";
            // 
            // grpApamTrigger
            // 
            this.grpApamTrigger.Controls.Add(this.lblTriggerInfo);
            this.grpApamTrigger.Controls.Add(this.lblSpeedThreshold);
            this.grpApamTrigger.Controls.Add(this.numSpeedThreshold);
            this.grpApamTrigger.Controls.Add(this.lblBucketCapacity);
            this.grpApamTrigger.Controls.Add(this.numBucketCapacity);
            this.grpApamTrigger.Controls.Add(this.lblFillRate);
            this.grpApamTrigger.Controls.Add(this.numFillRate);
            this.grpApamTrigger.Controls.Add(this.lblLeakRate);
            this.grpApamTrigger.Controls.Add(this.numLeakRate);
            this.grpApamTrigger.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpApamTrigger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpApamTrigger.Location = new System.Drawing.Point(25, 55);
            this.grpApamTrigger.Name = "grpApamTrigger";
            this.grpApamTrigger.Size = new System.Drawing.Size(870, 190);
            this.grpApamTrigger.TabIndex = 1;
            this.grpApamTrigger.TabStop = false;
            this.grpApamTrigger.Text = "APAM Tetikleme Şartları & Sızdıran Kova Doğrulaması (Leaky Bucket)";
            // 
            // lblTriggerInfo
            // 
            this.lblTriggerInfo.AutoSize = true;
            this.lblTriggerInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTriggerInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblTriggerInfo.Location = new System.Drawing.Point(20, 30);
            this.lblTriggerInfo.Name = "lblTriggerInfo";
            this.lblTriggerInfo.Size = new System.Drawing.Size(780, 20);
            this.lblTriggerInfo.TabIndex = 0;
            this.lblTriggerInfo.Text = "Not: Faz 4 (veya herhangi bir faz) sırasında düşüş hızı eşiği aşarsa sızdıran kova dolar. Dolunca APAM açılır ve iniş yavaşlar.";
            // 
            // lblSpeedThreshold
            // 
            this.lblSpeedThreshold.AutoSize = true;
            this.lblSpeedThreshold.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeedThreshold.Location = new System.Drawing.Point(20, 70);
            this.lblSpeedThreshold.Name = "lblSpeedThreshold";
            this.lblSpeedThreshold.Size = new System.Drawing.Size(195, 21);
            this.lblSpeedThreshold.TabIndex = 1;
            this.lblSpeedThreshold.Text = "Tetikleme Hız Eşiği (m/s):";
            // 
            // numSpeedThreshold
            // 
            this.numSpeedThreshold.DecimalPlaces = 1;
            this.numSpeedThreshold.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSpeedThreshold.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numSpeedThreshold.Location = new System.Drawing.Point(20, 95);
            this.numSpeedThreshold.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numSpeedThreshold.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numSpeedThreshold.Name = "numSpeedThreshold";
            this.numSpeedThreshold.Size = new System.Drawing.Size(180, 32);
            this.numSpeedThreshold.TabIndex = 2;
            this.numSpeedThreshold.Value = new decimal(new int[] { 160, 0, 0, 65536 });
            // 
            // lblBucketCapacity
            // 
            this.lblBucketCapacity.AutoSize = true;
            this.lblBucketCapacity.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBucketCapacity.Location = new System.Drawing.Point(230, 70);
            this.lblBucketCapacity.Name = "lblBucketCapacity";
            this.lblBucketCapacity.Size = new System.Drawing.Size(185, 21);
            this.lblBucketCapacity.TabIndex = 3;
            this.lblBucketCapacity.Text = "Kova Kapasitesi (Süre - s):";
            // 
            // numBucketCapacity
            // 
            this.numBucketCapacity.DecimalPlaces = 1;
            this.numBucketCapacity.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBucketCapacity.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numBucketCapacity.Location = new System.Drawing.Point(230, 95);
            this.numBucketCapacity.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numBucketCapacity.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numBucketCapacity.Name = "numBucketCapacity";
            this.numBucketCapacity.Size = new System.Drawing.Size(180, 32);
            this.numBucketCapacity.TabIndex = 4;
            this.numBucketCapacity.Value = new decimal(new int[] { 20, 0, 0, 65536 });
            // 
            // lblFillRate
            // 
            this.lblFillRate.AutoSize = true;
            this.lblFillRate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFillRate.Location = new System.Drawing.Point(440, 70);
            this.lblFillRate.Name = "lblFillRate";
            this.lblFillRate.Size = new System.Drawing.Size(180, 21);
            this.lblFillRate.TabIndex = 5;
            this.lblFillRate.Text = "Dolum Katsayısı (Fill/sn):";
            // 
            // numFillRate
            // 
            this.numFillRate.DecimalPlaces = 1;
            this.numFillRate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFillRate.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numFillRate.Location = new System.Drawing.Point(440, 95);
            this.numFillRate.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numFillRate.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numFillRate.Name = "numFillRate";
            this.numFillRate.Size = new System.Drawing.Size(180, 32);
            this.numFillRate.TabIndex = 6;
            this.numFillRate.Value = new decimal(new int[] { 10, 0, 0, 65536 });
            // 
            // lblLeakRate
            // 
            this.lblLeakRate.AutoSize = true;
            this.lblLeakRate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeakRate.Location = new System.Drawing.Point(650, 70);
            this.lblLeakRate.Name = "lblLeakRate";
            this.lblLeakRate.Size = new System.Drawing.Size(185, 21);
            this.lblLeakRate.TabIndex = 7;
            this.lblLeakRate.Text = "Sızıntı Katsayısı (Leak/sn):";
            // 
            // numLeakRate
            // 
            this.numLeakRate.DecimalPlaces = 1;
            this.numLeakRate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLeakRate.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numLeakRate.Location = new System.Drawing.Point(650, 95);
            this.numLeakRate.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numLeakRate.Name = "numLeakRate";
            this.numLeakRate.Size = new System.Drawing.Size(180, 32);
            this.numLeakRate.TabIndex = 8;
            this.numLeakRate.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            // 
            // grpApamDeploy
            // 
            this.grpApamDeploy.Controls.Add(this.lblApamArea);
            this.grpApamDeploy.Controls.Add(this.numApamArea);
            this.grpApamDeploy.Controls.Add(this.lblInflationLag);
            this.grpApamDeploy.Controls.Add(this.numInflationLag);
            this.grpApamDeploy.Controls.Add(this.lblDeployNote);
            this.grpApamDeploy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpApamDeploy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpApamDeploy.Location = new System.Drawing.Point(25, 265);
            this.grpApamDeploy.Name = "grpApamDeploy";
            this.grpApamDeploy.Size = new System.Drawing.Size(870, 160);
            this.grpApamDeploy.TabIndex = 2;
            this.grpApamDeploy.TabStop = false;
            this.grpApamDeploy.Text = "APAM Yüzey Alanı & Kademeli Açılma Mekaniği";
            // 
            // lblApamArea
            // 
            this.lblApamArea.AutoSize = true;
            this.lblApamArea.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApamArea.Location = new System.Drawing.Point(20, 40);
            this.lblApamArea.Name = "lblApamArea";
            this.lblApamArea.Size = new System.Drawing.Size(240, 21);
            this.lblApamArea.TabIndex = 0;
            this.lblApamArea.Text = "APAM Hedef Yüzey Alanı [A - m²]:";
            // 
            // numApamArea
            // 
            this.numApamArea.DecimalPlaces = 4;
            this.numApamArea.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numApamArea.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numApamArea.Location = new System.Drawing.Point(20, 70);
            this.numApamArea.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numApamArea.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            this.numApamArea.Name = "numApamArea";
            this.numApamArea.Size = new System.Drawing.Size(240, 32);
            this.numApamArea.TabIndex = 1;
            this.numApamArea.Value = new decimal(new int[] { 4500, 0, 0, 262144 });
            // 
            // lblInflationLag
            // 
            this.lblInflationLag.AutoSize = true;
            this.lblInflationLag.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInflationLag.Location = new System.Drawing.Point(300, 40);
            this.lblInflationLag.Name = "lblInflationLag";
            this.lblInflationLag.Size = new System.Drawing.Size(245, 21);
            this.lblInflationLag.TabIndex = 2;
            this.lblInflationLag.Text = "Doğrusal Açılma Süresi [Lag - ms]:";
            // 
            // numInflationLag
            // 
            this.numInflationLag.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numInflationLag.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            this.numInflationLag.Location = new System.Drawing.Point(300, 70);
            this.numInflationLag.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numInflationLag.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numInflationLag.Name = "numInflationLag";
            this.numInflationLag.Size = new System.Drawing.Size(240, 32);
            this.numInflationLag.TabIndex = 3;
            this.numInflationLag.Value = new decimal(new int[] { 1500, 0, 0, 0 });
            // 
            // lblDeployNote
            // 
            this.lblDeployNote.AutoSize = true;
            this.lblDeployNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeployNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblDeployNote.Location = new System.Drawing.Point(20, 120);
            this.lblDeployNote.Name = "lblDeployNote";
            this.lblDeployNote.Size = new System.Drawing.Size(695, 20);
            this.lblDeployNote.TabIndex = 4;
            this.lblDeployNote.Text = "Kural: APAM açıldığında yüzey alanı asla sıfırdan başlamaz. A_mevcut değerinden A_apam hedefine doğrusal artar.";
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
            this.grpForceDiagram.Size = new System.Drawing.Size(350, 565);
            this.grpForceDiagram.TabIndex = 3;
            this.grpForceDiagram.TabStop = false;
            this.grpForceDiagram.Text = "📊 APAM Kuvvet Vektör & Limit Hız";
            // 
            // lblForceHeader
            // 
            this.lblForceHeader.AutoSize = true;
            this.lblForceHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblForceHeader.Location = new System.Drawing.Point(15, 35);
            this.lblForceHeader.Name = "lblForceHeader";
            this.lblForceHeader.Size = new System.Drawing.Size(310, 42);
            this.lblForceHeader.TabIndex = 0;
            this.lblForceHeader.Text = "▼ Fg (Yerçekimi Kuvveti) = 11.77 N\r\n▲ Fd (Hava Sürtünmesi) = 11.77 N";
            // 
            // lblForceDiagramVisual
            // 
            this.lblForceDiagramVisual.AutoSize = true;
            this.lblForceDiagramVisual.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForceDiagramVisual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblForceDiagramVisual.Location = new System.Drawing.Point(20, 95);
            this.lblForceDiagramVisual.Name = "lblForceDiagramVisual";
            this.lblForceDiagramVisual.Size = new System.Drawing.Size(305, 250);
            this.lblForceDiagramVisual.TabIndex = 1;
            this.lblForceDiagramVisual.Text = "     ▲  Fd (Sürtünme Kuvveti)\r\n     │  = 11.77 Newton\r\n     │  (Limit Hızda Fg\'ye Eşit)\r\n┌────┴────┐\r\n│  GÖREV  │  (Acil Paraşüt APAM)\r\n│  YÜKÜ   │  A = 0.45 m²\r\n└────┬────┘  Cd = 1.6\r\n     │\r\n     ▼  Fg (Yerçekimi Kuvveti)\r\n        = 1.2 kg × 9.807 m/s²\r\n        = 11.77 Newton\r\n\r\n(Denge Noktası: F_net = 0 N)";
            // 
            // lblTerminalVelCalc
            // 
            this.lblTerminalVelCalc.AutoSize = true;
            this.lblTerminalVelCalc.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminalVelCalc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTerminalVelCalc.Location = new System.Drawing.Point(15, 370);
            this.lblTerminalVelCalc.Name = "lblTerminalVelCalc";
            this.lblTerminalVelCalc.Size = new System.Drawing.Size(320, 130);
            this.lblTerminalVelCalc.TabIndex = 2;
            this.lblTerminalVelCalc.Text = "🚀 Teorik Limit Hız (v_limit):\r\n   = 6.52 m/s (~23.47 km/h)\r\n\r\nFormül:\r\nv = √( 2·m·g / (ρ·Cd·A_apam) )\r\n= √( 2×1.2×9.807 / (1.225×1.6×0.45) )";
            // 
            // ApamSubPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.grpForceDiagram);
            this.Controls.Add(this.grpApamDeploy);
            this.Controls.Add(this.grpApamTrigger);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ApamSubPanel";
            this.Size = new System.Drawing.Size(1280, 650);
            this.grpApamTrigger.ResumeLayout(false);
            this.grpApamTrigger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBucketCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFillRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLeakRate)).EndInit();
            this.grpApamDeploy.ResumeLayout(false);
            this.grpApamDeploy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numApamArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInflationLag)).EndInit();
            this.grpForceDiagram.ResumeLayout(false);
            this.grpForceDiagram.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpApamTrigger;
        private System.Windows.Forms.Label lblTriggerInfo;
        private System.Windows.Forms.Label lblSpeedThreshold;
        private System.Windows.Forms.NumericUpDown numSpeedThreshold;
        private System.Windows.Forms.Label lblBucketCapacity;
        private System.Windows.Forms.NumericUpDown numBucketCapacity;
        private System.Windows.Forms.Label lblFillRate;
        private System.Windows.Forms.NumericUpDown numFillRate;
        private System.Windows.Forms.Label lblLeakRate;
        private System.Windows.Forms.NumericUpDown numLeakRate;
        private System.Windows.Forms.GroupBox grpApamDeploy;
        private System.Windows.Forms.Label lblApamArea;
        private System.Windows.Forms.NumericUpDown numApamArea;
        private System.Windows.Forms.Label lblInflationLag;
        private System.Windows.Forms.NumericUpDown numInflationLag;
        private System.Windows.Forms.Label lblDeployNote;
        private System.Windows.Forms.GroupBox grpForceDiagram;
        private System.Windows.Forms.Label lblForceHeader;
        private System.Windows.Forms.Label lblForceDiagramVisual;
        private System.Windows.Forms.Label lblTerminalVelCalc;
    }
}
