using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    partial class SensorEstimationSubPanel
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpKalmanParams;
        private System.Windows.Forms.Label lblQBase;
        private System.Windows.Forms.NumericUpDown numQBase;
        private System.Windows.Forms.Label lblRBaro;
        private System.Windows.Forms.NumericUpDown numRBaro;
        private System.Windows.Forms.Label lblRAcc;
        private System.Windows.Forms.NumericUpDown numRAcc;

        private System.Windows.Forms.GroupBox grpConfPenalties;
        private System.Windows.Forms.Label lblBaroPenalty;
        private System.Windows.Forms.NumericUpDown numBaroPenalty;
        private System.Windows.Forms.Label lblAccPenalty;
        private System.Windows.Forms.NumericUpDown numAccPenalty;
        private System.Windows.Forms.Label lblTempPenalty;
        private System.Windows.Forms.NumericUpDown numTempPenalty;
        private System.Windows.Forms.Label lblCoastDecay;
        private System.Windows.Forms.NumericUpDown numCoastDecay;

        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblInfoText;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.grpKalmanParams = new System.Windows.Forms.GroupBox();
            this.lblQBase = new System.Windows.Forms.Label();
            this.numQBase = new System.Windows.Forms.NumericUpDown();
            this.lblRBaro = new System.Windows.Forms.Label();
            this.numRBaro = new System.Windows.Forms.NumericUpDown();
            this.lblRAcc = new System.Windows.Forms.Label();
            this.numRAcc = new System.Windows.Forms.NumericUpDown();

            this.grpConfPenalties = new System.Windows.Forms.GroupBox();
            this.lblBaroPenalty = new System.Windows.Forms.Label();
            this.numBaroPenalty = new System.Windows.Forms.NumericUpDown();
            this.lblAccPenalty = new System.Windows.Forms.Label();
            this.numAccPenalty = new System.Windows.Forms.NumericUpDown();
            this.lblTempPenalty = new System.Windows.Forms.Label();
            this.numTempPenalty = new System.Windows.Forms.NumericUpDown();
            this.lblCoastDecay = new System.Windows.Forms.Label();
            this.numCoastDecay = new System.Windows.Forms.NumericUpDown();

            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblInfoText = new System.Windows.Forms.Label();

            this.grpKalmanParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRBaro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRAcc)).BeginInit();
            this.grpConfPenalties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBaroPenalty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccPenalty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempPenalty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoastDecay)).BeginInit();
            this.grpInfo.SuspendLayout();
            this.SuspendLayout();

            // grpKalmanParams
            this.grpKalmanParams.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpKalmanParams.Controls.Add(this.numRAcc);
            this.grpKalmanParams.Controls.Add(this.lblRAcc);
            this.grpKalmanParams.Controls.Add(this.numRBaro);
            this.grpKalmanParams.Controls.Add(this.lblRBaro);
            this.grpKalmanParams.Controls.Add(this.numQBase);
            this.grpKalmanParams.Controls.Add(this.lblQBase);
            this.grpKalmanParams.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpKalmanParams.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpKalmanParams.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.grpKalmanParams.Location = new System.Drawing.Point(0, 0);
            this.grpKalmanParams.Name = "grpKalmanParams";
            this.grpKalmanParams.Padding = new System.Windows.Forms.Padding(10);
            this.grpKalmanParams.Size = new System.Drawing.Size(500, 140);
            this.grpKalmanParams.Text = "⚙️ Kalman Filtresi Gürültü Kovaryansları (Q, R)";

            // lblQBase
            this.lblQBase.Location = new System.Drawing.Point(15, 32);
            this.lblQBase.Size = new System.Drawing.Size(200, 25);
            this.lblQBase.Text = "Q (Süreç Gürültüsü):";
            this.lblQBase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQBase.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            // numQBase
            this.numQBase.Location = new System.Drawing.Point(220, 30);
            this.numQBase.Size = new System.Drawing.Size(100, 25);
            this.numQBase.DecimalPlaces = 4;
            this.numQBase.Increment = 0.01m;
            this.numQBase.Minimum = 0.0001m;
            this.numQBase.Maximum = 100m;
            this.numQBase.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.numQBase.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);

            // lblRBaro
            this.lblRBaro.Location = new System.Drawing.Point(15, 66);
            this.lblRBaro.Size = new System.Drawing.Size(200, 25);
            this.lblRBaro.Text = "R Barometre (Ölçüm σ²):";
            this.lblRBaro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRBaro.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            // numRBaro
            this.numRBaro.Location = new System.Drawing.Point(220, 64);
            this.numRBaro.Size = new System.Drawing.Size(100, 25);
            this.numRBaro.DecimalPlaces = 4;
            this.numRBaro.Increment = 0.01m;
            this.numRBaro.Minimum = 0.0001m;
            this.numRBaro.Maximum = 1000m;
            this.numRBaro.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.numRBaro.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);

            // lblRAcc
            this.lblRAcc.Location = new System.Drawing.Point(15, 100);
            this.lblRAcc.Size = new System.Drawing.Size(200, 25);
            this.lblRAcc.Text = "R İvmeölçer (Ölçüm σ²):";
            this.lblRAcc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRAcc.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            // numRAcc
            this.numRAcc.Location = new System.Drawing.Point(220, 98);
            this.numRAcc.Size = new System.Drawing.Size(100, 25);
            this.numRAcc.DecimalPlaces = 4;
            this.numRAcc.Increment = 0.01m;
            this.numRAcc.Minimum = 0.0001m;
            this.numRAcc.Maximum = 1000m;
            this.numRAcc.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.numRAcc.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);

            // grpConfPenalties
            this.grpConfPenalties.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpConfPenalties.Controls.Add(this.numCoastDecay);
            this.grpConfPenalties.Controls.Add(this.lblCoastDecay);
            this.grpConfPenalties.Controls.Add(this.numTempPenalty);
            this.grpConfPenalties.Controls.Add(this.lblTempPenalty);
            this.grpConfPenalties.Controls.Add(this.numAccPenalty);
            this.grpConfPenalties.Controls.Add(this.lblAccPenalty);
            this.grpConfPenalties.Controls.Add(this.numBaroPenalty);
            this.grpConfPenalties.Controls.Add(this.lblBaroPenalty);
            this.grpConfPenalties.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConfPenalties.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpConfPenalties.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.grpConfPenalties.Location = new System.Drawing.Point(0, 140);
            this.grpConfPenalties.Name = "grpConfPenalties";
            this.grpConfPenalties.Padding = new System.Windows.Forms.Padding(10);
            this.grpConfPenalties.Size = new System.Drawing.Size(500, 170);
            this.grpConfPenalties.Text = "📊 Güven Katsayısı Ceza Parametreleri (%)";

            // lblBaroPenalty
            this.lblBaroPenalty.Location = new System.Drawing.Point(15, 32);
            this.lblBaroPenalty.Size = new System.Drawing.Size(220, 25);
            this.lblBaroPenalty.Text = "Barometre Kesinti Cezası (%):";
            this.lblBaroPenalty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBaroPenalty.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            // numBaroPenalty
            this.numBaroPenalty.Location = new System.Drawing.Point(240, 30);
            this.numBaroPenalty.Size = new System.Drawing.Size(80, 25);
            this.numBaroPenalty.DecimalPlaces = 1;
            this.numBaroPenalty.Increment = 1m;
            this.numBaroPenalty.Minimum = 0m;
            this.numBaroPenalty.Maximum = 100m;
            this.numBaroPenalty.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.numBaroPenalty.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);

            // lblAccPenalty
            this.lblAccPenalty.Location = new System.Drawing.Point(15, 66);
            this.lblAccPenalty.Size = new System.Drawing.Size(220, 25);
            this.lblAccPenalty.Text = "İvmeölçer Kesinti Cezası (%):";
            this.lblAccPenalty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAccPenalty.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            // numAccPenalty
            this.numAccPenalty.Location = new System.Drawing.Point(240, 64);
            this.numAccPenalty.Size = new System.Drawing.Size(80, 25);
            this.numAccPenalty.DecimalPlaces = 1;
            this.numAccPenalty.Increment = 1m;
            this.numAccPenalty.Minimum = 0m;
            this.numAccPenalty.Maximum = 100m;
            this.numAccPenalty.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.numAccPenalty.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);

            // lblTempPenalty
            this.lblTempPenalty.Location = new System.Drawing.Point(15, 100);
            this.lblTempPenalty.Size = new System.Drawing.Size(220, 25);
            this.lblTempPenalty.Text = "Sıcaklık Sensörü Cezası (%):";
            this.lblTempPenalty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTempPenalty.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            // numTempPenalty
            this.numTempPenalty.Location = new System.Drawing.Point(240, 98);
            this.numTempPenalty.Size = new System.Drawing.Size(80, 25);
            this.numTempPenalty.DecimalPlaces = 1;
            this.numTempPenalty.Increment = 0.5m;
            this.numTempPenalty.Minimum = 0m;
            this.numTempPenalty.Maximum = 100m;
            this.numTempPenalty.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.numTempPenalty.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);

            // lblCoastDecay
            this.lblCoastDecay.Location = new System.Drawing.Point(15, 134);
            this.lblCoastDecay.Size = new System.Drawing.Size(220, 25);
            this.lblCoastDecay.Text = "Kör Uçuş Erime Hızı (%/s):";
            this.lblCoastDecay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCoastDecay.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            // numCoastDecay
            this.numCoastDecay.Location = new System.Drawing.Point(240, 132);
            this.numCoastDecay.Size = new System.Drawing.Size(80, 25);
            this.numCoastDecay.DecimalPlaces = 1;
            this.numCoastDecay.Increment = 0.5m;
            this.numCoastDecay.Minimum = 0m;
            this.numCoastDecay.Maximum = 50m;
            this.numCoastDecay.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.numCoastDecay.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);

            // grpInfo
            this.grpInfo.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.grpInfo.Controls.Add(this.lblInfoText);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.grpInfo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.grpInfo.Location = new System.Drawing.Point(0, 310);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(10);
            this.grpInfo.Size = new System.Drawing.Size(500, 120);
            this.grpInfo.Text = "ℹ️ Kestirim Çekirdeği Hakkında";

            // lblInfoText
            this.lblInfoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfoText.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblInfoText.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblInfoText.Text = "Gelişmiş Kalman Filtresi (EKF), kalibre edilmiş barometre ve ivmeölçer\r\n" +
                "verilerini kaynaştırarak (Sensor Fusion) tahmini konum, hız ve ivme\r\n" +
                "üretir. Sensör kesintilerinde güven katsayısı düşer ve sistem\r\n" +
                "yedekleme modlarına (Dead Reckoning, Sıcaklık Fallback) geçer.\r\n\r\n" +
                "İleri modüller (UKF, Complementary Filter vb.) buraya eklenebilir.";

            //
            // SensorEstimationSubPanel
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.grpConfPenalties);
            this.Controls.Add(this.grpKalmanParams);
            this.Name = "SensorEstimationSubPanel";
            this.Size = new System.Drawing.Size(500, 450);

            this.grpKalmanParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numQBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRBaro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRAcc)).EndInit();
            this.grpConfPenalties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBaroPenalty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccPenalty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempPenalty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoastDecay)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
