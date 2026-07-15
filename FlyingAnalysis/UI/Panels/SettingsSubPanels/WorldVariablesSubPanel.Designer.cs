namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    partial class WorldVariablesSubPanel
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
            this.lblPanelTitle = new System.Windows.Forms.Label();
            this.grpGravity = new System.Windows.Forms.GroupBox();
            this.numGravity = new System.Windows.Forms.NumericUpDown();
            this.lblGravityUnit = new System.Windows.Forms.Label();
            this.grpAirDensity = new System.Windows.Forms.GroupBox();
            this.numAirDensity = new System.Windows.Forms.NumericUpDown();
            this.lblDensityUnit = new System.Windows.Forms.Label();
            this.lblDensityInfo = new System.Windows.Forms.Label();
            this.grpTemperature = new System.Windows.Forms.GroupBox();
            this.numTempC = new System.Windows.Forms.NumericUpDown();
            this.lblTempUnit = new System.Windows.Forms.Label();
            this.grpLapseRate = new System.Windows.Forms.GroupBox();
            this.numLapseRate = new System.Windows.Forms.NumericUpDown();
            this.lblLapseUnit = new System.Windows.Forms.Label();
            this.lblLapseInfo = new System.Windows.Forms.Label();
            this.grpGravity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGravity)).BeginInit();
            this.grpAirDensity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAirDensity)).BeginInit();
            this.grpTemperature.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTempC)).BeginInit();
            this.grpLapseRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLapseRate)).BeginInit();
            this.SuspendLayout();

            // 
            // lblPanelTitle
            // 
            this.lblPanelTitle.AutoSize = true;
            this.lblPanelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblPanelTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPanelTitle.Name = "lblPanelTitle";
            this.lblPanelTitle.Size = new System.Drawing.Size(370, 30);
            this.lblPanelTitle.TabIndex = 0;
            this.lblPanelTitle.Text = "DÜNYA VE ÇEVRE DEĞİŞKENLERİ";
            // 
            // grpGravity
            // 
            this.grpGravity.Controls.Add(this.lblGravityUnit);
            this.grpGravity.Controls.Add(this.numGravity);
            this.grpGravity.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGravity.Location = new System.Drawing.Point(25, 75);
            this.grpGravity.Name = "grpGravity";
            this.grpGravity.Size = new System.Drawing.Size(420, 100);
            this.grpGravity.TabIndex = 1;
            this.grpGravity.TabStop = false;
            this.grpGravity.Text = "Yerçekimi İvmesi (g)";
            // 
            // numGravity
            // 
            this.numGravity.DecimalPlaces = 3;
            this.numGravity.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGravity.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            this.numGravity.Location = new System.Drawing.Point(20, 40);
            this.numGravity.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.numGravity.Name = "numGravity";
            this.numGravity.Size = new System.Drawing.Size(180, 32);
            this.numGravity.TabIndex = 0;
            this.numGravity.Value = new decimal(new int[] { 9810, 0, 0, 196608 });
            // 
            // lblGravityUnit
            // 
            this.lblGravityUnit.AutoSize = true;
            this.lblGravityUnit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGravityUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblGravityUnit.Location = new System.Drawing.Point(210, 44);
            this.lblGravityUnit.Name = "lblGravityUnit";
            this.lblGravityUnit.Size = new System.Drawing.Size(188, 23);
            this.lblGravityUnit.TabIndex = 1;
            this.lblGravityUnit.Text = "m/s² (Sabit Varsayılan)";
            // 
            // grpAirDensity
            // 
            this.grpAirDensity.Controls.Add(this.lblDensityInfo);
            this.grpAirDensity.Controls.Add(this.lblDensityUnit);
            this.grpAirDensity.Controls.Add(this.numAirDensity);
            this.grpAirDensity.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAirDensity.Location = new System.Drawing.Point(25, 195);
            this.grpAirDensity.Name = "grpAirDensity";
            this.grpAirDensity.Size = new System.Drawing.Size(420, 120);
            this.grpAirDensity.TabIndex = 2;
            this.grpAirDensity.TabStop = false;
            this.grpAirDensity.Text = "Hava Yoğunluğu (ρ)";
            // 
            // numAirDensity
            // 
            this.numAirDensity.DecimalPlaces = 3;
            this.numAirDensity.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAirDensity.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numAirDensity.Location = new System.Drawing.Point(20, 40);
            this.numAirDensity.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numAirDensity.Name = "numAirDensity";
            this.numAirDensity.Size = new System.Drawing.Size(180, 32);
            this.numAirDensity.TabIndex = 0;
            this.numAirDensity.Value = new decimal(new int[] { 1100, 0, 0, 196608 });
            // 
            // lblDensityUnit
            // 
            this.lblDensityUnit.AutoSize = true;
            this.lblDensityUnit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDensityUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDensityUnit.Location = new System.Drawing.Point(210, 44);
            this.lblDensityUnit.Name = "lblDensityUnit";
            this.lblDensityUnit.Size = new System.Drawing.Size(61, 23);
            this.lblDensityUnit.TabIndex = 1;
            this.lblDensityUnit.Text = "kg/m³";
            // 
            // lblDensityInfo
            // 
            this.lblDensityInfo.AutoSize = true;
            this.lblDensityInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDensityInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblDensityInfo.Location = new System.Drawing.Point(18, 80);
            this.lblDensityInfo.Name = "lblDensityInfo";
            this.lblDensityInfo.Size = new System.Drawing.Size(350, 20);
            this.lblDensityInfo.TabIndex = 2;
            this.lblDensityInfo.Text = "Aksaray rakımı (~900m) için 1.1 kg/m³ seçilmiştir.";
            // 
            // grpDragCoeff
            // 
            // grpTemperature
            // 
            this.grpTemperature.Controls.Add(this.lblTempUnit);
            this.grpTemperature.Controls.Add(this.numTempC);
            this.grpTemperature.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTemperature.Location = new System.Drawing.Point(475, 75);
            this.grpTemperature.Name = "grpTemperature";
            this.grpTemperature.Size = new System.Drawing.Size(420, 120);
            this.grpTemperature.TabIndex = 3;
            this.grpTemperature.TabStop = false;
            this.grpTemperature.Text = "Deniz Seviyesi Sıcaklığı (T0)";
            // 
            // numTempC
            // 
            this.numTempC.DecimalPlaces = 1;
            this.numTempC.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTempC.Location = new System.Drawing.Point(20, 40);
            this.numTempC.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.numTempC.Minimum = new decimal(new int[] { 40, 0, 0, -2147483648 });
            this.numTempC.Name = "numTempC";
            this.numTempC.Size = new System.Drawing.Size(180, 32);
            this.numTempC.TabIndex = 0;
            this.numTempC.Value = new decimal(new int[] { 150, 0, 0, 65536 });
            // 
            // lblTempUnit
            // 
            this.lblTempUnit.AutoSize = true;
            this.lblTempUnit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTempUnit.Location = new System.Drawing.Point(210, 44);
            this.lblTempUnit.Name = "lblTempUnit";
            this.lblTempUnit.Size = new System.Drawing.Size(158, 23);
            this.lblTempUnit.TabIndex = 1;
            this.lblTempUnit.Text = "°C (Standart: 15 °C)";
            // 
            // grpLapseRate
            // 
            this.grpLapseRate.Controls.Add(this.lblLapseInfo);
            this.grpLapseRate.Controls.Add(this.lblLapseUnit);
            this.grpLapseRate.Controls.Add(this.numLapseRate);
            this.grpLapseRate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLapseRate.Location = new System.Drawing.Point(475, 215);
            this.grpLapseRate.Name = "grpLapseRate";
            this.grpLapseRate.Size = new System.Drawing.Size(420, 120);
            this.grpLapseRate.TabIndex = 4;
            this.grpLapseRate.TabStop = false;
            this.grpLapseRate.Text = "Sıcaklık Düşüş Oranı (Lapse Rate - L)";
            // 
            // numLapseRate
            // 
            this.numLapseRate.DecimalPlaces = 2;
            this.numLapseRate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLapseRate.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numLapseRate.Location = new System.Drawing.Point(20, 40);
            this.numLapseRate.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.numLapseRate.Name = "numLapseRate";
            this.numLapseRate.Size = new System.Drawing.Size(180, 32);
            this.numLapseRate.TabIndex = 0;
            this.numLapseRate.Value = new decimal(new int[] { 65, 0, 0, 65536 });
            // 
            // lblLapseUnit
            // 
            this.lblLapseUnit.AutoSize = true;
            this.lblLapseUnit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapseUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblLapseUnit.Location = new System.Drawing.Point(210, 44);
            this.lblLapseUnit.Name = "lblLapseUnit";
            this.lblLapseUnit.Size = new System.Drawing.Size(176, 23);
            this.lblLapseUnit.TabIndex = 1;
            this.lblLapseUnit.Text = "°C/km (0.0065 °C/m)";
            // 
            // lblLapseInfo
            // 
            this.lblLapseInfo.AutoSize = true;
            this.lblLapseInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapseInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblLapseInfo.Location = new System.Drawing.Point(18, 80);
            this.lblLapseInfo.Name = "lblLapseInfo";
            this.lblLapseInfo.Size = new System.Drawing.Size(340, 20);
            this.lblLapseInfo.TabIndex = 2;
            this.lblLapseInfo.Text = "Standart Atmosfer (ISA) katsayısı: 6.5 °C/1000m";
            // 
            // WorldVariablesSubPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.grpLapseRate);
            this.Controls.Add(this.grpTemperature);
            this.Controls.Add(this.grpAirDensity);
            this.Controls.Add(this.grpGravity);
            this.Controls.Add(this.lblPanelTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WorldVariablesSubPanel";
            this.Size = new System.Drawing.Size(920, 640);
            this.grpGravity.ResumeLayout(false);
            this.grpGravity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGravity)).EndInit();
            this.grpAirDensity.ResumeLayout(false);
            this.grpAirDensity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAirDensity)).EndInit();
            this.grpTemperature.ResumeLayout(false);
            this.grpTemperature.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTempC)).EndInit();
            this.grpLapseRate.ResumeLayout(false);
            this.grpLapseRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLapseRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPanelTitle;
        private System.Windows.Forms.GroupBox grpGravity;
        private System.Windows.Forms.NumericUpDown numGravity;
        private System.Windows.Forms.Label lblGravityUnit;
        private System.Windows.Forms.GroupBox grpAirDensity;
        private System.Windows.Forms.NumericUpDown numAirDensity;
        private System.Windows.Forms.Label lblDensityUnit;
        private System.Windows.Forms.Label lblDensityInfo;
        private System.Windows.Forms.GroupBox grpTemperature;
        private System.Windows.Forms.NumericUpDown numTempC;
        private System.Windows.Forms.Label lblTempUnit;
        private System.Windows.Forms.GroupBox grpLapseRate;
        private System.Windows.Forms.NumericUpDown numLapseRate;
        private System.Windows.Forms.Label lblLapseUnit;
        private System.Windows.Forms.Label lblLapseInfo;
    }
}

