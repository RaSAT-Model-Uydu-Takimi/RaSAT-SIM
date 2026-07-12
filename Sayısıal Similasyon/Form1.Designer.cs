namespace Sayısıal_Similasyon
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grpBaglanti = new System.Windows.Forms.GroupBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.lblBaud = new System.Windows.Forms.Label();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.btnDurdur = new System.Windows.Forms.Button();
            this.lblDurum = new System.Windows.Forms.Label();
            this.grpMotorlar = new System.Windows.Forms.GroupBox();
            this.lblMI1 = new System.Windows.Forms.Label();
            this.prgMI1 = new System.Windows.Forms.ProgressBar();
            this.lblMI2 = new System.Windows.Forms.Label();
            this.prgMI2 = new System.Windows.Forms.ProgressBar();
            this.lblMI3 = new System.Windows.Forms.Label();
            this.prgMI3 = new System.Windows.Forms.ProgressBar();
            this.lblMI4 = new System.Windows.Forms.Label();
            this.prgMI4 = new System.Windows.Forms.ProgressBar();
            this.grpTelemetri = new System.Windows.Forms.GroupBox();
            this.lblGidenIndex = new System.Windows.Forms.Label();
            this.lblGelenIndex = new System.Windows.Forms.Label();
            this.lblIrtifa = new System.Windows.Forms.Label();
            this.lblHiz = new System.Windows.Forms.Label();
            this.lblEuler = new System.Windows.Forms.Label();
            this.lblKanat = new System.Windows.Forms.Label();
            this.lblBatarya = new System.Windows.Forms.Label();
            this.timerUI = new System.Windows.Forms.Timer(this.components);
            this.grpBaglanti.SuspendLayout();
            this.grpMotorlar.SuspendLayout();
            this.grpTelemetri.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBaglanti
            // 
            this.grpBaglanti.Controls.Add(this.lblPort);
            this.grpBaglanti.Controls.Add(this.cmbPort);
            this.grpBaglanti.Controls.Add(this.lblBaud);
            this.grpBaglanti.Controls.Add(this.cmbBaud);
            this.grpBaglanti.Controls.Add(this.btnBaslat);
            this.grpBaglanti.Controls.Add(this.btnDurdur);
            this.grpBaglanti.Controls.Add(this.lblDurum);
            this.grpBaglanti.Location = new System.Drawing.Point(16, 16);
            this.grpBaglanti.Name = "grpBaglanti";
            this.grpBaglanti.Size = new System.Drawing.Size(680, 80);
            this.grpBaglanti.TabIndex = 0;
            this.grpBaglanti.TabStop = false;
            this.grpBaglanti.Text = "Haberleşme ve Seri Port Ayarları";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(16, 32);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(32, 15);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Port:";
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(54, 28);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(95, 23);
            this.cmbPort.TabIndex = 1;
            // 
            // lblBaud
            // 
            this.lblBaud.AutoSize = true;
            this.lblBaud.Location = new System.Drawing.Point(165, 32);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(37, 15);
            this.lblBaud.TabIndex = 2;
            this.lblBaud.Text = "Baud:";
            // 
            // cmbBaud
            // 
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Items.AddRange(new object[] {
            "115200",
            "460800",
            "921600"});
            this.cmbBaud.Location = new System.Drawing.Point(208, 28);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(95, 23);
            this.cmbBaud.TabIndex = 3;
            // 
            // btnBaslat
            // 
            this.btnBaslat.Location = new System.Drawing.Point(325, 26);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(105, 28);
            this.btnBaslat.TabIndex = 4;
            this.btnBaslat.Text = "Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // btnDurdur
            // 
            this.btnDurdur.Enabled = false;
            this.btnDurdur.Location = new System.Drawing.Point(440, 26);
            this.btnDurdur.Name = "btnDurdur";
            this.btnDurdur.Size = new System.Drawing.Size(105, 28);
            this.btnDurdur.TabIndex = 5;
            this.btnDurdur.Text = "Durdur";
            this.btnDurdur.UseVisualStyleBackColor = true;
            this.btnDurdur.Click += new System.EventHandler(this.btnDurdur_Click);
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDurum.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDurum.Location = new System.Drawing.Point(560, 32);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(89, 15);
            this.lblDurum.TabIndex = 6;
            this.lblDurum.Text = "DURUM: BEKLE";
            // 
            // grpMotorlar
            // 
            this.grpMotorlar.Controls.Add(this.lblMI1);
            this.grpMotorlar.Controls.Add(this.prgMI1);
            this.grpMotorlar.Controls.Add(this.lblMI2);
            this.grpMotorlar.Controls.Add(this.prgMI2);
            this.grpMotorlar.Controls.Add(this.lblMI3);
            this.grpMotorlar.Controls.Add(this.prgMI3);
            this.grpMotorlar.Controls.Add(this.lblMI4);
            this.grpMotorlar.Controls.Add(this.prgMI4);
            this.grpMotorlar.Location = new System.Drawing.Point(16, 110);
            this.grpMotorlar.Name = "grpMotorlar";
            this.grpMotorlar.Size = new System.Drawing.Size(330, 260);
            this.grpMotorlar.TabIndex = 1;
            this.grpMotorlar.TabStop = false;
            this.grpMotorlar.Text = "Canlı Motor Çıktıları (STM32 Komutları)";
            // 
            // lblMI1
            // 
            this.lblMI1.AutoSize = true;
            this.lblMI1.Location = new System.Drawing.Point(16, 35);
            this.lblMI1.Name = "lblMI1";
            this.lblMI1.Size = new System.Drawing.Size(105, 15);
            this.lblMI1.TabIndex = 0;
            this.lblMI1.Text = "MI1 (ÖnSol): 0";
            // 
            // prgMI1
            // 
            this.prgMI1.Location = new System.Drawing.Point(16, 55);
            this.prgMI1.Maximum = 1000;
            this.prgMI1.Name = "prgMI1";
            this.prgMI1.Size = new System.Drawing.Size(295, 20);
            this.prgMI1.TabIndex = 1;
            // 
            // lblMI2
            // 
            this.lblMI2.AutoSize = true;
            this.lblMI2.Location = new System.Drawing.Point(16, 90);
            this.lblMI2.Name = "lblMI2";
            this.lblMI2.Size = new System.Drawing.Size(108, 15);
            this.lblMI2.TabIndex = 2;
            this.lblMI2.Text = "MI2 (ÖnSağ): 0";
            // 
            // prgMI2
            // 
            this.prgMI2.Location = new System.Drawing.Point(16, 110);
            this.prgMI2.Maximum = 1000;
            this.prgMI2.Name = "prgMI2";
            this.prgMI2.Size = new System.Drawing.Size(295, 20);
            this.prgMI2.TabIndex = 3;
            // 
            // lblMI3
            // 
            this.lblMI3.AutoSize = true;
            this.lblMI3.Location = new System.Drawing.Point(16, 145);
            this.lblMI3.Name = "lblMI3";
            this.lblMI3.Size = new System.Drawing.Size(113, 15);
            this.lblMI3.TabIndex = 4;
            this.lblMI3.Text = "MI3 (ArkaSol): 0";
            // 
            // prgMI3
            // 
            this.prgMI3.Location = new System.Drawing.Point(16, 165);
            this.prgMI3.Maximum = 1000;
            this.prgMI3.Name = "prgMI3";
            this.prgMI3.Size = new System.Drawing.Size(295, 20);
            this.prgMI3.TabIndex = 5;
            // 
            // lblMI4
            // 
            this.lblMI4.AutoSize = true;
            this.lblMI4.Location = new System.Drawing.Point(16, 200);
            this.lblMI4.Name = "lblMI4";
            this.lblMI4.Size = new System.Drawing.Size(116, 15);
            this.lblMI4.TabIndex = 6;
            this.lblMI4.Text = "MI4 (ArkaSağ): 0";
            // 
            // prgMI4
            // 
            this.prgMI4.Location = new System.Drawing.Point(16, 220);
            this.prgMI4.Maximum = 1000;
            this.prgMI4.Name = "prgMI4";
            this.prgMI4.Size = new System.Drawing.Size(295, 20);
            this.prgMI4.TabIndex = 7;
            // 
            // grpTelemetri
            // 
            this.grpTelemetri.Controls.Add(this.lblGidenIndex);
            this.grpTelemetri.Controls.Add(this.lblGelenIndex);
            this.grpTelemetri.Controls.Add(this.lblIrtifa);
            this.grpTelemetri.Controls.Add(this.lblHiz);
            this.grpTelemetri.Controls.Add(this.lblEuler);
            this.grpTelemetri.Controls.Add(this.lblKanat);
            this.grpTelemetri.Controls.Add(this.lblBatarya);
            this.grpTelemetri.Location = new System.Drawing.Point(365, 110);
            this.grpTelemetri.Name = "grpTelemetri";
            this.grpTelemetri.Size = new System.Drawing.Size(331, 260);
            this.grpTelemetri.TabIndex = 2;
            this.grpTelemetri.TabStop = false;
            this.grpTelemetri.Text = "Fizik ve Telemetri Durumu";
            // 
            // lblGidenIndex
            // 
            this.lblGidenIndex.AutoSize = true;
            this.lblGidenIndex.Location = new System.Drawing.Point(20, 35);
            this.lblGidenIndex.Name = "lblGidenIndex";
            this.lblGidenIndex.Size = new System.Drawing.Size(83, 15);
            this.lblGidenIndex.TabIndex = 0;
            this.lblGidenIndex.Text = "Giden Index: 0";
            // 
            // lblGelenIndex
            // 
            this.lblGelenIndex.AutoSize = true;
            this.lblGelenIndex.Location = new System.Drawing.Point(175, 35);
            this.lblGelenIndex.Name = "lblGelenIndex";
            this.lblGelenIndex.Size = new System.Drawing.Size(82, 15);
            this.lblGelenIndex.TabIndex = 1;
            this.lblGelenIndex.Text = "Gelen Index: 0";
            // 
            // lblIrtifa
            // 
            this.lblIrtifa.AutoSize = true;
            this.lblIrtifa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIrtifa.Location = new System.Drawing.Point(20, 70);
            this.lblIrtifa.Name = "lblIrtifa";
            this.lblIrtifa.Size = new System.Drawing.Size(127, 19);
            this.lblIrtifa.TabIndex = 2;
            this.lblIrtifa.Text = "İrtifa (Y): 400.0 m";
            // 
            // lblHiz
            // 
            this.lblHiz.AutoSize = true;
            this.lblHiz.Location = new System.Drawing.Point(20, 105);
            this.lblHiz.Name = "lblHiz";
            this.lblHiz.Size = new System.Drawing.Size(124, 15);
            this.lblHiz.TabIndex = 3;
            this.lblHiz.Text = "Düşey Hız: 0.00 m/s";
            // 
            // lblEuler
            // 
            this.lblEuler.AutoSize = true;
            this.lblEuler.Location = new System.Drawing.Point(20, 140);
            this.lblEuler.Name = "lblEuler";
            this.lblEuler.Size = new System.Drawing.Size(155, 15);
            this.lblEuler.TabIndex = 4;
            this.lblEuler.Text = "Pitch: 0.0 | Roll: 0.0 | Yaw: 0.0";
            // 
            // lblKanat
            // 
            this.lblKanat.AutoSize = true;
            this.lblKanat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKanat.Location = new System.Drawing.Point(20, 175);
            this.lblKanat.Name = "lblKanat";
            this.lblKanat.Size = new System.Drawing.Size(147, 15);
            this.lblKanat.TabIndex = 5;
            this.lblKanat.Text = "Kanat Durumu: KAPALI";
            // 
            // lblBatarya
            // 
            this.lblBatarya.AutoSize = true;
            this.lblBatarya.Location = new System.Drawing.Point(20, 210);
            this.lblBatarya.Name = "lblBatarya";
            this.lblBatarya.Size = new System.Drawing.Size(143, 15);
            this.lblBatarya.TabIndex = 6;
            this.lblBatarya.Text = "Batarya: 11.10 V | 0.00 A";
            // 
            // timerUI
            // 
            this.timerUI.Interval = 50;
            this.timerUI.Tick += new System.EventHandler(this.timerUI_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 390);
            this.Controls.Add(this.grpTelemetri);
            this.Controls.Add(this.grpMotorlar);
            this.Controls.Add(this.grpBaglanti);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RASAT Sayısal Simülasyon (Senkron Haberleşme & 6-DOF Fizik)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpBaglanti.ResumeLayout(false);
            this.grpBaglanti.PerformLayout();
            this.grpMotorlar.ResumeLayout(false);
            this.grpMotorlar.PerformLayout();
            this.grpTelemetri.ResumeLayout(false);
            this.grpTelemetri.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBaglanti;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label lblBaud;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Button btnDurdur;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.GroupBox grpMotorlar;
        private System.Windows.Forms.Label lblMI1;
        private System.Windows.Forms.ProgressBar prgMI1;
        private System.Windows.Forms.Label lblMI2;
        private System.Windows.Forms.ProgressBar prgMI2;
        private System.Windows.Forms.Label lblMI3;
        private System.Windows.Forms.ProgressBar prgMI3;
        private System.Windows.Forms.Label lblMI4;
        private System.Windows.Forms.ProgressBar prgMI4;
        private System.Windows.Forms.GroupBox grpTelemetri;
        private System.Windows.Forms.Label lblGidenIndex;
        private System.Windows.Forms.Label lblGelenIndex;
        private System.Windows.Forms.Label lblIrtifa;
        private System.Windows.Forms.Label lblHiz;
        private System.Windows.Forms.Label lblEuler;
        private System.Windows.Forms.Label lblKanat;
        private System.Windows.Forms.Label lblBatarya;
        private System.Windows.Forms.Timer timerUI;
    }
}
