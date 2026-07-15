namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    partial class Phase5SubPanel
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
            this.grpGroundCheck = new System.Windows.Forms.GroupBox();
            this.lblGroundTime = new System.Windows.Forms.Label();
            this.numGroundTime = new System.Windows.Forms.NumericUpDown();
            this.lblLidarTolerans = new System.Windows.Forms.Label();
            this.numLidarTolerans = new System.Windows.Forms.NumericUpDown();
            this.lblGroundNote = new System.Windows.Forms.Label();
            this.grpImpactCriteria = new System.Windows.Forms.GroupBox();
            this.lblGoodThreshold = new System.Windows.Forms.Label();
            this.numGoodThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblNormalThreshold = new System.Windows.Forms.Label();
            this.numNormalThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblBadInfo = new System.Windows.Forms.Label();
            this.lblCriteriaTable = new System.Windows.Forms.Label();
            this.grpGroundCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGroundTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLidarTolerans)).BeginInit();
            this.grpImpactCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoodThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNormalThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(680, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "8. FAZ 5 PARAMETRELERİ: YERE İNİŞ, DOĞRULAMA & SERTLİK KRİTERLERİ";
            // 
            // grpGroundCheck
            // 
            this.grpGroundCheck.Controls.Add(this.lblGroundNote);
            this.grpGroundCheck.Controls.Add(this.lblGroundTime);
            this.grpGroundCheck.Controls.Add(this.numGroundTime);
            this.grpGroundCheck.Controls.Add(this.lblLidarTolerans);
            this.grpGroundCheck.Controls.Add(this.numLidarTolerans);
            this.grpGroundCheck.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGroundCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpGroundCheck.Location = new System.Drawing.Point(25, 55);
            this.grpGroundCheck.Name = "grpGroundCheck";
            this.grpGroundCheck.Size = new System.Drawing.Size(870, 160);
            this.grpGroundCheck.TabIndex = 1;
            this.grpGroundCheck.TabStop = false;
            this.grpGroundCheck.Text = "Yere Temas Doğrulama & Yerde Kalma Süresi (Stabilizasyon)";
            // 
            // lblGroundTime
            // 
            this.lblGroundTime.AutoSize = true;
            this.lblGroundTime.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroundTime.Location = new System.Drawing.Point(20, 40);
            this.lblGroundTime.Name = "lblGroundTime";
            this.lblGroundTime.Size = new System.Drawing.Size(220, 21);
            this.lblGroundTime.TabIndex = 0;
            this.lblGroundTime.Text = "Yerde Kalma Doğrulama Süresi (s):";
            // 
            // numGroundTime
            // 
            this.numGroundTime.DecimalPlaces = 1;
            this.numGroundTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGroundTime.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numGroundTime.Location = new System.Drawing.Point(20, 70);
            this.numGroundTime.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.numGroundTime.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numGroundTime.Name = "numGroundTime";
            this.numGroundTime.Size = new System.Drawing.Size(220, 32);
            this.numGroundTime.TabIndex = 1;
            this.numGroundTime.Value = new decimal(new int[] { 30, 0, 0, 65536 });
            // 
            // lblLidarTolerans
            // 
            this.lblLidarTolerans.AutoSize = true;
            this.lblLidarTolerans.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLidarTolerans.Location = new System.Drawing.Point(280, 40);
            this.lblLidarTolerans.Name = "lblLidarTolerans";
            this.lblLidarTolerans.Size = new System.Drawing.Size(210, 21);
            this.lblLidarTolerans.TabIndex = 2;
            this.lblLidarTolerans.Text = "İrtifa Sıfır Toleransı (Lidar - cm):";
            // 
            // numLidarTolerans
            // 
            this.numLidarTolerans.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLidarTolerans.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            this.numLidarTolerans.Location = new System.Drawing.Point(280, 70);
            this.numLidarTolerans.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numLidarTolerans.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numLidarTolerans.Name = "numLidarTolerans";
            this.numLidarTolerans.Size = new System.Drawing.Size(210, 32);
            this.numLidarTolerans.TabIndex = 3;
            this.numLidarTolerans.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lblGroundNote
            // 
            this.lblGroundNote.AutoSize = true;
            this.lblGroundNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroundNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblGroundNote.Location = new System.Drawing.Point(20, 115);
            this.lblGroundNote.Name = "lblGroundNote";
            this.lblGroundNote.Size = new System.Drawing.Size(710, 20);
            this.lblGroundNote.TabIndex = 4;
            this.lblGroundNote.Text = "Açıklama: İrtifa <= Tolerans şartı kesintisiz olarak belirlenen süre boyunca sağlandığında iniş kesinleşir.";
            // 
            // grpImpactCriteria
            // 
            this.grpImpactCriteria.Controls.Add(this.lblCriteriaTable);
            this.grpImpactCriteria.Controls.Add(this.lblGoodThreshold);
            this.grpImpactCriteria.Controls.Add(this.numGoodThreshold);
            this.grpImpactCriteria.Controls.Add(this.lblNormalThreshold);
            this.grpImpactCriteria.Controls.Add(this.numNormalThreshold);
            this.grpImpactCriteria.Controls.Add(this.lblBadInfo);
            this.grpImpactCriteria.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpImpactCriteria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpImpactCriteria.Location = new System.Drawing.Point(25, 235);
            this.grpImpactCriteria.Name = "grpImpactCriteria";
            this.grpImpactCriteria.Size = new System.Drawing.Size(870, 320);
            this.grpImpactCriteria.TabIndex = 2;
            this.grpImpactCriteria.TabStop = false;
            this.grpImpactCriteria.Text = "İniş Sertliği Değerlendirme Kriterleri (Impact Velocity Classification)";
            // 
            // lblGoodThreshold
            // 
            this.lblGoodThreshold.AutoSize = true;
            this.lblGoodThreshold.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoodThreshold.Location = new System.Drawing.Point(20, 40);
            this.lblGoodThreshold.Name = "lblGoodThreshold";
            this.lblGoodThreshold.Size = new System.Drawing.Size(225, 21);
            this.lblGoodThreshold.TabIndex = 0;
            this.lblGoodThreshold.Text = "İYİ İniş Maksimum Hız Eşiği (m/s):";
            // 
            // numGoodThreshold
            // 
            this.numGoodThreshold.DecimalPlaces = 1;
            this.numGoodThreshold.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGoodThreshold.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numGoodThreshold.Location = new System.Drawing.Point(20, 70);
            this.numGoodThreshold.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numGoodThreshold.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numGoodThreshold.Name = "numGoodThreshold";
            this.numGoodThreshold.Size = new System.Drawing.Size(225, 32);
            this.numGoodThreshold.TabIndex = 1;
            this.numGoodThreshold.Value = new decimal(new int[] { 25, 0, 0, 65536 });
            // 
            // lblNormalThreshold
            // 
            this.lblNormalThreshold.AutoSize = true;
            this.lblNormalThreshold.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNormalThreshold.Location = new System.Drawing.Point(280, 40);
            this.lblNormalThreshold.Name = "lblNormalThreshold";
            this.lblNormalThreshold.Size = new System.Drawing.Size(255, 21);
            this.lblNormalThreshold.TabIndex = 2;
            this.lblNormalThreshold.Text = "NORMAL İniş Maksimum Eşiği (m/s):";
            // 
            // numNormalThreshold
            // 
            this.numNormalThreshold.DecimalPlaces = 1;
            this.numNormalThreshold.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numNormalThreshold.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numNormalThreshold.Location = new System.Drawing.Point(280, 70);
            this.numNormalThreshold.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.numNormalThreshold.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numNormalThreshold.Name = "numNormalThreshold";
            this.numNormalThreshold.Size = new System.Drawing.Size(255, 32);
            this.numNormalThreshold.TabIndex = 3;
            this.numNormalThreshold.Value = new decimal(new int[] { 45, 0, 0, 65536 });
            // 
            // lblBadInfo
            // 
            this.lblBadInfo.AutoSize = true;
            this.lblBadInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBadInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblBadInfo.Location = new System.Drawing.Point(565, 75);
            this.lblBadInfo.Name = "lblBadInfo";
            this.lblBadInfo.Size = new System.Drawing.Size(280, 21);
            this.lblBadInfo.TabIndex = 4;
            this.lblBadInfo.Text = "KÖTÜ İniş: Hız > NORMAL Eşiği ise.";
            // 
            // lblCriteriaTable
            // 
            this.lblCriteriaTable.AutoSize = true;
            this.lblCriteriaTable.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriteriaTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblCriteriaTable.Location = new System.Drawing.Point(20, 130);
            this.lblCriteriaTable.Name = "lblCriteriaTable";
            this.lblCriteriaTable.Size = new System.Drawing.Size(730, 160);
            this.lblCriteriaTable.TabIndex = 5;
            this.lblCriteriaTable.Text = "┌────────────────────────┬──────────────────────────────────────────┐\r\n│ İNİŞ SERTLİK SINIFI    │ ŞART VE DEĞERLENDİRME KRİTERİ            │\r\n├────────────────────────┼──────────────────────────────────────────┤\r\n│ [✓] İYİ (PERFECT)      │ v_impact <= 2.5 m/s (Yumuşak ve Güvenli) │\r\n│ [!] NORMAL (ACCEPTABLE)│ 2.5 m/s < v_impact <= 4.5 m/s (Müsaade Ed.)│\r\n│ [X] KÖTÜ (HARD/CRASH)  │ v_impact > 4.5 m/s (Hasar Riski Yüksek!) │\r\n└────────────────────────┴──────────────────────────────────────────┘\r\n\r\nNot: İniş anındaki temas hızı (v_impact) kaydedilir ve bu sınıflama telemetriye işlenir.";
            // 
            // Phase5SubPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.grpImpactCriteria);
            this.Controls.Add(this.grpGroundCheck);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Phase5SubPanel";
            this.Size = new System.Drawing.Size(1280, 650);
            this.grpGroundCheck.ResumeLayout(false);
            this.grpGroundCheck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGroundTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLidarTolerans)).EndInit();
            this.grpImpactCriteria.ResumeLayout(false);
            this.grpImpactCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoodThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNormalThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpGroundCheck;
        private System.Windows.Forms.Label lblGroundTime;
        private System.Windows.Forms.NumericUpDown numGroundTime;
        private System.Windows.Forms.Label lblLidarTolerans;
        private System.Windows.Forms.NumericUpDown numLidarTolerans;
        private System.Windows.Forms.Label lblGroundNote;
        private System.Windows.Forms.GroupBox grpImpactCriteria;
        private System.Windows.Forms.Label lblGoodThreshold;
        private System.Windows.Forms.NumericUpDown numGoodThreshold;
        private System.Windows.Forms.Label lblNormalThreshold;
        private System.Windows.Forms.NumericUpDown numNormalThreshold;
        private System.Windows.Forms.Label lblBadInfo;
        private System.Windows.Forms.Label lblCriteriaTable;
    }
}
