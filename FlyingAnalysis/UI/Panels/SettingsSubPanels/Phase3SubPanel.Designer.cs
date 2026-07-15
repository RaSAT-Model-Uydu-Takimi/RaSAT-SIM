namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    partial class Phase3SubPanel
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
            this.grpSeparateTrigger = new System.Windows.Forms.GroupBox();
            this.lblSeparateMech = new System.Windows.Forms.Label();
            this.grpSeparationCheckLoop = new System.Windows.Forms.GroupBox();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.numThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblCheckFreq = new System.Windows.Forms.Label();
            this.numCheckFreq = new System.Windows.Forms.NumericUpDown();
            this.lblLoopInfo = new System.Windows.Forms.Label();
            this.grpSigmaDeploy = new System.Windows.Forms.GroupBox();
            this.lblSigmaArea = new System.Windows.Forms.Label();
            this.numSigmaArea = new System.Windows.Forms.NumericUpDown();
            this.lblLinearTransitionTime = new System.Windows.Forms.Label();
            this.numLinearTransitionTime = new System.Windows.Forms.NumericUpDown();
            this.lblLinearNote = new System.Windows.Forms.Label();
            this.grpForceDiagram = new System.Windows.Forms.GroupBox();
            this.lblForceHeader = new System.Windows.Forms.Label();
            this.lblForceDiagramVisual = new System.Windows.Forms.Label();
            this.lblTerminalVelCalc = new System.Windows.Forms.Label();
            this.grpSeparateTrigger.SuspendLayout();
            this.grpSeparationCheckLoop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckFreq)).BeginInit();
            this.grpSigmaDeploy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSigmaArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLinearTransitionTime)).BeginInit();
            this.grpForceDiagram.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(610, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "FAZ 3 PARAMETRELERİ: AYRILMA HALİ (S3 KOMUT BLOKLARI)";
            // 
            // grpSeparateTrigger
            // 
            this.grpSeparateTrigger.Controls.Add(this.lblSeparateMech);
            this.grpSeparateTrigger.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSeparateTrigger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpSeparateTrigger.Location = new System.Drawing.Point(25, 65);
            this.grpSeparateTrigger.Name = "grpSeparateTrigger";
            this.grpSeparateTrigger.Size = new System.Drawing.Size(870, 95);
            this.grpSeparateTrigger.TabIndex = 1;
            this.grpSeparateTrigger.TabStop = false;
            this.grpSeparateTrigger.Text = "Komut Bloğu 1: Taşıyıcı ile Görev Yükünü Ayır (Tetikleme Emri)";
            // 
            // lblSeparateMech
            // 
            this.lblSeparateMech.AutoSize = true;
            this.lblSeparateMech.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparateMech.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblSeparateMech.Location = new System.Drawing.Point(20, 40);
            this.lblSeparateMech.Name = "lblSeparateMech";
            this.lblSeparateMech.Size = new System.Drawing.Size(685, 21);
            this.lblSeparateMech.TabIndex = 0;
            this.lblSeparateMech.Text = "Durum: S2 halinden \"Separate\" tetikleyicisi geldi. Piroteknik/Mekanik ayırıcı komut bloğu çalıştırılır.";
            // 
            // grpSeparationCheckLoop
            // 
            this.grpSeparationCheckLoop.Controls.Add(this.lblLoopInfo);
            this.grpSeparationCheckLoop.Controls.Add(this.lblTimeout);
            this.grpSeparationCheckLoop.Controls.Add(this.numTimeout);
            this.grpSeparationCheckLoop.Controls.Add(this.lblThreshold);
            this.grpSeparationCheckLoop.Controls.Add(this.numThreshold);
            this.grpSeparationCheckLoop.Controls.Add(this.lblCheckFreq);
            this.grpSeparationCheckLoop.Controls.Add(this.numCheckFreq);
            this.grpSeparationCheckLoop.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSeparationCheckLoop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpSeparationCheckLoop.Location = new System.Drawing.Point(25, 180);
            this.grpSeparationCheckLoop.Name = "grpSeparationCheckLoop";
            this.grpSeparationCheckLoop.Size = new System.Drawing.Size(870, 180);
            this.grpSeparationCheckLoop.TabIndex = 2;
            this.grpSeparationCheckLoop.TabStop = false;
            this.grpSeparationCheckLoop.Text = "Şart Bloğu & Döngü (Loop): Ayrıldı Mı? (Separation Verification)";
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeout.Location = new System.Drawing.Point(20, 40);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(225, 21);
            this.lblTimeout.TabIndex = 0;
            this.lblTimeout.Text = "Maks. Sorgu Süresi [Timeout - s]:";
            // 
            // numTimeout
            // 
            this.numTimeout.DecimalPlaces = 1;
            this.numTimeout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTimeout.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numTimeout.Location = new System.Drawing.Point(20, 70);
            this.numTimeout.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.numTimeout.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.Size = new System.Drawing.Size(180, 32);
            this.numTimeout.TabIndex = 1;
            this.numTimeout.Value = new decimal(new int[] { 30, 0, 0, 65536 });
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThreshold.Location = new System.Drawing.Point(298, 40);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(242, 21);
            this.lblThreshold.TabIndex = 2;
            this.lblThreshold.Text = "Ayrılma Doğrulama Eşiği (Lidar cm):";
            // 
            // numThreshold
            // 
            this.numThreshold.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numThreshold.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            this.numThreshold.Location = new System.Drawing.Point(300, 70);
            this.numThreshold.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            this.numThreshold.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numThreshold.Name = "numThreshold";
            this.numThreshold.Size = new System.Drawing.Size(180, 32);
            this.numThreshold.TabIndex = 3;
            this.numThreshold.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // lblCheckFreq
            // 
            this.lblCheckFreq.AutoSize = true;
            this.lblCheckFreq.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckFreq.Location = new System.Drawing.Point(578, 40);
            this.lblCheckFreq.Name = "lblCheckFreq";
            this.lblCheckFreq.Size = new System.Drawing.Size(182, 21);
            this.lblCheckFreq.TabIndex = 4;
            this.lblCheckFreq.Text = "Döngü Sorgu Frekansı [Hz]:";
            // 
            // numCheckFreq
            // 
            this.numCheckFreq.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCheckFreq.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            this.numCheckFreq.Location = new System.Drawing.Point(580, 70);
            this.numCheckFreq.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numCheckFreq.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numCheckFreq.Name = "numCheckFreq";
            this.numCheckFreq.Size = new System.Drawing.Size(180, 32);
            this.numCheckFreq.TabIndex = 5;
            this.numCheckFreq.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // lblLoopInfo
            // 
            this.lblLoopInfo.AutoSize = true;
            this.lblLoopInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoopInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.lblLoopInfo.Location = new System.Drawing.Point(20, 125);
            this.lblLoopInfo.Name = "lblLoopInfo";
            this.lblLoopInfo.Size = new System.Drawing.Size(650, 20);
            this.lblLoopInfo.TabIndex = 6;
            this.lblLoopInfo.Text = "Not: Bu fazda sızdıran kova YOKTUR. \"Ayrıldı Mı?\" şart bloğu evet dönene kadar sorgu döngüsü çalışır.";
            // 
            // grpSigmaDeploy
            // 
            this.grpSigmaDeploy.Controls.Add(this.lblSigmaArea);
            this.grpSigmaDeploy.Controls.Add(this.numSigmaArea);
            this.grpSigmaDeploy.Controls.Add(this.lblLinearTransitionTime);
            this.grpSigmaDeploy.Controls.Add(this.numLinearTransitionTime);
            this.grpSigmaDeploy.Controls.Add(this.lblLinearNote);
            this.grpSigmaDeploy.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSigmaDeploy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpSigmaDeploy.Location = new System.Drawing.Point(25, 380);
            this.grpSigmaDeploy.Name = "grpSigmaDeploy";
            this.grpSigmaDeploy.Size = new System.Drawing.Size(870, 175);
            this.grpSigmaDeploy.TabIndex = 3;
            this.grpSigmaDeploy.TabStop = false;
            this.grpSigmaDeploy.Text = "Komut Bloğu 2: SİGMA Takımlarını Aç (Doğrusal Alan Geçişi)";
            // 
            // lblSigmaArea
            // 
            this.lblSigmaArea.AutoSize = true;
            this.lblSigmaArea.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSigmaArea.Location = new System.Drawing.Point(20, 40);
            this.lblSigmaArea.Name = "lblSigmaArea";
            this.lblSigmaArea.Size = new System.Drawing.Size(225, 21);
            this.lblSigmaArea.TabIndex = 0;
            this.lblSigmaArea.Text = "SİGMA Hedef Ref. Alan (A) [m²]:";
            // 
            // numSigmaArea
            // 
            this.numSigmaArea.DecimalPlaces = 4;
            this.numSigmaArea.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSigmaArea.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            this.numSigmaArea.Location = new System.Drawing.Point(20, 70);
            this.numSigmaArea.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numSigmaArea.Name = "numSigmaArea";
            this.numSigmaArea.Size = new System.Drawing.Size(180, 32);
            this.numSigmaArea.TabIndex = 1;
            this.numSigmaArea.Value = new decimal(new int[] { 1256, 0, 0, 262144 });
            // 
            // lblLinearTransitionTime
            // 
            this.lblLinearTransitionTime.AutoSize = true;
            this.lblLinearTransitionTime.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinearTransitionTime.Location = new System.Drawing.Point(298, 40);
            this.lblLinearTransitionTime.Name = "lblLinearTransitionTime";
            this.lblLinearTransitionTime.Size = new System.Drawing.Size(262, 21);
            this.lblLinearTransitionTime.TabIndex = 2;
            this.lblLinearTransitionTime.Text = "Doğrusal Geçiş Süresi (t_şişme) [sn]:";
            // 
            // numLinearTransitionTime
            // 
            this.numLinearTransitionTime.DecimalPlaces = 2;
            this.numLinearTransitionTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLinearTransitionTime.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numLinearTransitionTime.Location = new System.Drawing.Point(300, 70);
            this.numLinearTransitionTime.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numLinearTransitionTime.Name = "numLinearTransitionTime";
            this.numLinearTransitionTime.Size = new System.Drawing.Size(180, 32);
            this.numLinearTransitionTime.TabIndex = 3;
            this.numLinearTransitionTime.Value = new decimal(new int[] { 120, 0, 0, 131072 });
            // 
            // lblLinearNote
            // 
            this.lblLinearNote.AutoSize = true;
            this.lblLinearNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinearNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblLinearNote.Location = new System.Drawing.Point(20, 125);
            this.lblLinearNote.Name = "lblLinearNote";
            this.lblLinearNote.Size = new System.Drawing.Size(645, 20);
            this.lblLinearNote.TabIndex = 4;
            this.lblLinearNote.Text = "Kural: Yüzey alanı asla 0\'dan başlamaz. A_mevcut değerinden A_hedef değerine doğrusal olarak artar.";
            // 
            // grpForceDiagram
            // 
            this.grpForceDiagram.Controls.Add(this.lblTerminalVelCalc);
            this.grpForceDiagram.Controls.Add(this.lblForceDiagramVisual);
            this.grpForceDiagram.Controls.Add(this.lblForceHeader);
            this.grpForceDiagram.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpForceDiagram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpForceDiagram.Location = new System.Drawing.Point(910, 65);
            this.grpForceDiagram.Name = "grpForceDiagram";
            this.grpForceDiagram.Size = new System.Drawing.Size(350, 480);
            this.grpForceDiagram.TabIndex = 4;
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
            this.lblForceDiagramVisual.Size = new System.Drawing.Size(305, 230);
            this.lblForceDiagramVisual.TabIndex = 1;
            this.lblForceDiagramVisual.Text = "     ▲  Fd (Sürtünme Kuvveti)\r\n     │  = 11.77 Newton\r\n     │  (Limit Hızda Fg\'ye Eşit)\r\n┌────┴────┐\r\n│  GÖREV  │  (Ayrılma Halinde)\r\n│  YÜKÜ   │  A = 0.08 m²\r\n└────┬────┘  Cd = 1.3\r\n     │\r\n     ▼  Fg (Yerçekimi Kuvveti)\r\n        = 1.2 kg × 9.807 m/s²\r\n        = 11.77 Newton\r\n\r\n(Denge Noktası: F_net = 0 N)";
            // 
            // lblTerminalVelCalc
            // 
            this.lblTerminalVelCalc.AutoSize = true;
            this.lblTerminalVelCalc.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerminalVelCalc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTerminalVelCalc.Location = new System.Drawing.Point(15, 340);
            this.lblTerminalVelCalc.Name = "lblTerminalVelCalc";
            this.lblTerminalVelCalc.Size = new System.Drawing.Size(320, 120);
            this.lblTerminalVelCalc.TabIndex = 2;
            this.lblTerminalVelCalc.Text = "🚀 Teorik Limit Hız (v_limit):\r\n   = 13.60 m/s (~48.96 km/h)\r\n\r\nFormül:\r\nv = √( 2·m·g / (ρ·Cd·A) )\r\n= √( 2×1.2×9.807 / (1.225×1.3×0.08) )";
            // 
            // Phase3SubPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.grpForceDiagram);
            this.Controls.Add(this.grpSigmaDeploy);
            this.Controls.Add(this.grpSeparationCheckLoop);
            this.Controls.Add(this.grpSeparateTrigger);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Phase3SubPanel";
            this.Size = new System.Drawing.Size(1280, 650);
            this.grpSeparateTrigger.ResumeLayout(false);
            this.grpSeparateTrigger.PerformLayout();
            this.grpSeparationCheckLoop.ResumeLayout(false);
            this.grpSeparationCheckLoop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckFreq)).EndInit();
            this.grpSigmaDeploy.ResumeLayout(false);
            this.grpSigmaDeploy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSigmaArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLinearTransitionTime)).EndInit();
            this.grpForceDiagram.ResumeLayout(false);
            this.grpForceDiagram.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpSeparateTrigger;
        private System.Windows.Forms.Label lblSeparateMech;
        private System.Windows.Forms.GroupBox grpSeparationCheckLoop;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.NumericUpDown numThreshold;
        private System.Windows.Forms.Label lblCheckFreq;
        private System.Windows.Forms.NumericUpDown numCheckFreq;
        private System.Windows.Forms.Label lblLoopInfo;
        private System.Windows.Forms.GroupBox grpSigmaDeploy;
        private System.Windows.Forms.Label lblSigmaArea;
        private System.Windows.Forms.NumericUpDown numSigmaArea;
        private System.Windows.Forms.Label lblLinearTransitionTime;
        private System.Windows.Forms.NumericUpDown numLinearTransitionTime;
        private System.Windows.Forms.Label lblLinearNote;
        private System.Windows.Forms.GroupBox grpForceDiagram;
        private System.Windows.Forms.Label lblForceHeader;
        private System.Windows.Forms.Label lblForceDiagramVisual;
        private System.Windows.Forms.Label lblTerminalVelCalc;
    }
}

