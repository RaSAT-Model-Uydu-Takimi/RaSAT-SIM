namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    partial class SatellitePhysicsSubPanel
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
            lblTitle = new Label();
            grpMasses = new GroupBox();
            lblTotalMassDisplay = new Label();
            lblCarrierLabel = new Label();
            numCarrierMass = new NumericUpDown();
            lblPayloadLabel = new Label();
            numPayloadMass = new NumericUpDown();
            grpParachutes = new GroupBox();
            lblApamAreaLabel = new Label();
            numApamArea = new NumericUpDown();
            lblMainAreaLabel = new Label();
            numMainParachuteArea = new NumericUpDown();
            grpMotors = new GroupBox();
            lblThrustCoeffLabel = new Label();
            numThrustCoeff = new NumericUpDown();
            lblMotorModel = new Label();
            grpWingAerodynamics = new GroupBox();
            lblWingClosedLabel = new Label();
            numWingClosedArea = new NumericUpDown();
            lblWingOpenedLabel = new Label();
            numWingOpenedArea = new NumericUpDown();
            lblBodyCdLabel = new Label();
            numBodyCd = new NumericUpDown();
            grpMasses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCarrierMass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPayloadMass).BeginInit();
            grpParachutes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numApamArea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMainParachuteArea).BeginInit();
            grpMotors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numThrustCoeff).BeginInit();
            grpWingAerodynamics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numWingClosedArea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWingOpenedArea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBodyCd).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(557, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "UYDUNUN FİZİKSEL VE PARAŞÜT ÖZELLİKLERİ";
            // 
            // grpMasses
            // 
            grpMasses.Controls.Add(lblTotalMassDisplay);
            grpMasses.Controls.Add(lblCarrierLabel);
            grpMasses.Controls.Add(numCarrierMass);
            grpMasses.Controls.Add(lblPayloadLabel);
            grpMasses.Controls.Add(numPayloadMass);
            grpMasses.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpMasses.Location = new Point(25, 65);
            grpMasses.Name = "grpMasses";
            grpMasses.Size = new Size(870, 160);
            grpMasses.TabIndex = 1;
            grpMasses.TabStop = false;
            grpMasses.Text = "Kütle Parametreleri [Gram / Kilogram]";
            // 
            // lblTotalMassDisplay
            // 
            lblTotalMassDisplay.AutoSize = true;
            lblTotalMassDisplay.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalMassDisplay.ForeColor = Color.FromArgb(16, 185, 129);
            lblTotalMassDisplay.Location = new Point(540, 58);
            lblTotalMassDisplay.Name = "lblTotalMassDisplay";
            lblTotalMassDisplay.Size = new Size(307, 30);
            lblTotalMassDisplay.TabIndex = 4;
            lblTotalMassDisplay.Text = "Toplam Kütle: 1800 g (1.80 kg)";
            // 
            // lblCarrierLabel
            // 
            lblCarrierLabel.AutoSize = true;
            lblCarrierLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCarrierLabel.Location = new Point(270, 35);
            lblCarrierLabel.Name = "lblCarrierLabel";
            lblCarrierLabel.Size = new Size(291, 25);
            lblCarrierLabel.TabIndex = 3;
            lblCarrierLabel.Text = "Taşıyıcı Gövde Kütlesi (m_carrier):";
            // 
            // numCarrierMass
            // 
            numCarrierMass.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numCarrierMass.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numCarrierMass.Location = new Point(270, 65);
            numCarrierMass.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numCarrierMass.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numCarrierMass.Name = "numCarrierMass";
            numCarrierMass.Size = new Size(200, 37);
            numCarrierMass.TabIndex = 2;
            numCarrierMass.Value = new decimal(new int[] { 1200, 0, 0, 0 });
            // 
            // lblPayloadLabel
            // 
            lblPayloadLabel.AutoSize = true;
            lblPayloadLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPayloadLabel.Location = new Point(18, 35);
            lblPayloadLabel.Name = "lblPayloadLabel";
            lblPayloadLabel.Size = new Size(282, 25);
            lblPayloadLabel.TabIndex = 1;
            lblPayloadLabel.Text = "Görev Yükü Kütlesi (m_payload):";
            // 
            // numPayloadMass
            // 
            numPayloadMass.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numPayloadMass.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numPayloadMass.Location = new Point(20, 65);
            numPayloadMass.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numPayloadMass.Minimum = new decimal(new int[] { 50, 0, 0, 0 });
            numPayloadMass.Name = "numPayloadMass";
            numPayloadMass.Size = new Size(200, 37);
            numPayloadMass.TabIndex = 0;
            numPayloadMass.Value = new decimal(new int[] { 600, 0, 0, 0 });
            // 
            // grpParachutes
            // 
            grpParachutes.Controls.Add(lblApamAreaLabel);
            grpParachutes.Controls.Add(numApamArea);
            grpParachutes.Controls.Add(lblMainAreaLabel);
            grpParachutes.Controls.Add(numMainParachuteArea);
            grpParachutes.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpParachutes.Location = new Point(25, 394);
            grpParachutes.Name = "grpParachutes";
            grpParachutes.Size = new Size(870, 150);
            grpParachutes.TabIndex = 2;
            grpParachutes.TabStop = false;
            grpParachutes.Text = "Paraşüt Referans Yüzey Alanları (A) [m²]";
            // 
            // lblApamAreaLabel
            // 
            lblApamAreaLabel.AutoSize = true;
            lblApamAreaLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApamAreaLabel.Location = new Point(438, 35);
            lblApamAreaLabel.Name = "lblApamAreaLabel";
            lblApamAreaLabel.Size = new Size(366, 25);
            lblApamAreaLabel.TabIndex = 3;
            lblApamAreaLabel.Text = "APAM Paraşütü (D_apam=80cm) Ref. Alan:";
            // 
            // numApamArea
            // 
            numApamArea.DecimalPlaces = 4;
            numApamArea.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numApamArea.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numApamArea.Location = new Point(440, 65);
            numApamArea.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numApamArea.Name = "numApamArea";
            numApamArea.Size = new Size(180, 37);
            numApamArea.TabIndex = 2;
            numApamArea.Value = new decimal(new int[] { 5026, 0, 0, 262144 });
            // 
            // lblMainAreaLabel
            // 
            lblMainAreaLabel.AutoSize = true;
            lblMainAreaLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMainAreaLabel.Location = new Point(18, 35);
            lblMainAreaLabel.Name = "lblMainAreaLabel";
            lblMainAreaLabel.Size = new Size(363, 25);
            lblMainAreaLabel.TabIndex = 1;
            lblMainAreaLabel.Text = "Ana Paraşüt (D_ana=40cm) Referans Alan:";
            // 
            // numMainParachuteArea
            // 
            numMainParachuteArea.DecimalPlaces = 4;
            numMainParachuteArea.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numMainParachuteArea.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numMainParachuteArea.Location = new Point(20, 65);
            numMainParachuteArea.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numMainParachuteArea.Name = "numMainParachuteArea";
            numMainParachuteArea.Size = new Size(180, 37);
            numMainParachuteArea.TabIndex = 0;
            numMainParachuteArea.Value = new decimal(new int[] { 1256, 0, 0, 262144 });
            // 
            // grpMotors
            // 
            grpMotors.Controls.Add(lblThrustCoeffLabel);
            grpMotors.Controls.Add(numThrustCoeff);
            grpMotors.Controls.Add(lblMotorModel);
            grpMotors.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpMotors.Location = new Point(25, 231);
            grpMotors.Name = "grpMotors";
            grpMotors.Size = new Size(870, 130);
            grpMotors.TabIndex = 3;
            grpMotors.TabStop = false;
            grpMotors.Text = "Aktif İtki Sistemi (EMAX ECO II 2306 - 4 Motor / 5\" Pervane)";
            // 
            // lblThrustCoeffLabel
            // 
            lblThrustCoeffLabel.AutoSize = true;
            lblThrustCoeffLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThrustCoeffLabel.Location = new Point(230, 84);
            lblThrustCoeffLabel.Name = "lblThrustCoeffLabel";
            lblThrustCoeffLabel.Size = new Size(384, 25);
            lblThrustCoeffLabel.TabIndex = 2;
            lblThrustCoeffLabel.Text = "İtki Katsayısı (k): 1.5e-08 N/RPM² (Datasheet)";
            // 
            // numThrustCoeff
            // 
            numThrustCoeff.DecimalPlaces = 10;
            numThrustCoeff.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numThrustCoeff.Increment = new decimal(new int[] { 1, 0, 0, 589824 });
            numThrustCoeff.Location = new Point(20, 80);
            numThrustCoeff.Maximum = new decimal(new int[] { 1, 0, 0, 327680 });
            numThrustCoeff.Name = "numThrustCoeff";
            numThrustCoeff.Size = new Size(200, 34);
            numThrustCoeff.TabIndex = 1;
            numThrustCoeff.Value = new decimal(new int[] { 15, 0, 0, 589824 });
            // 
            // lblMotorModel
            // 
            lblMotorModel.AutoSize = true;
            lblMotorModel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMotorModel.ForeColor = Color.FromArgb(51, 65, 85);
            lblMotorModel.Location = new Point(18, 40);
            lblMotorModel.Name = "lblMotorModel";
            lblMotorModel.Size = new Size(534, 25);
            lblMotorModel.TabIndex = 0;
            lblMotorModel.Text = "Konfigürasyon: 4 x EMAX ECO II 2306 + 5 İnç 2-Bıçaklı Pervane";
            // 
            // grpWingAerodynamics
            // 
            grpWingAerodynamics.Controls.Add(lblWingClosedLabel);
            grpWingAerodynamics.Controls.Add(numWingClosedArea);
            grpWingAerodynamics.Controls.Add(lblWingOpenedLabel);
            grpWingAerodynamics.Controls.Add(numWingOpenedArea);
            grpWingAerodynamics.Controls.Add(lblBodyCdLabel);
            grpWingAerodynamics.Controls.Add(numBodyCd);
            grpWingAerodynamics.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpWingAerodynamics.Location = new Point(25, 550);
            grpWingAerodynamics.Name = "grpWingAerodynamics";
            grpWingAerodynamics.Size = new Size(870, 130);
            grpWingAerodynamics.TabIndex = 4;
            grpWingAerodynamics.TabStop = false;
            grpWingAerodynamics.Text = "Kanat ve Gövde Aerodinamik Sürtünme Alanları (Havada Süzülme)";
            // 
            // lblWingClosedLabel
            // 
            lblWingClosedLabel.AutoSize = true;
            lblWingClosedLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWingClosedLabel.Location = new Point(18, 35);
            lblWingClosedLabel.Name = "lblWingClosedLabel";
            lblWingClosedLabel.Size = new Size(286, 25);
            lblWingClosedLabel.TabIndex = 0;
            lblWingClosedLabel.Text = "Kanat Kapalı Ref. Alan (A_kapalı):";
            // 
            // numWingClosedArea
            // 
            numWingClosedArea.DecimalPlaces = 4;
            numWingClosedArea.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numWingClosedArea.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numWingClosedArea.Location = new Point(20, 65);
            numWingClosedArea.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numWingClosedArea.Name = "numWingClosedArea";
            numWingClosedArea.Size = new Size(180, 37);
            numWingClosedArea.TabIndex = 1;
            numWingClosedArea.Value = new decimal(new int[] { 150, 0, 0, 262144 });
            // 
            // lblWingOpenedLabel
            // 
            lblWingOpenedLabel.AutoSize = true;
            lblWingOpenedLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWingOpenedLabel.Location = new Point(298, 35);
            lblWingOpenedLabel.Name = "lblWingOpenedLabel";
            lblWingOpenedLabel.Size = new Size(252, 25);
            lblWingOpenedLabel.TabIndex = 2;
            lblWingOpenedLabel.Text = "Kanat Açık Ref. Alan (A_açık):";
            // 
            // numWingOpenedArea
            // 
            numWingOpenedArea.DecimalPlaces = 4;
            numWingOpenedArea.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numWingOpenedArea.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numWingOpenedArea.Location = new Point(300, 65);
            numWingOpenedArea.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            numWingOpenedArea.Name = "numWingOpenedArea";
            numWingOpenedArea.Size = new Size(180, 37);
            numWingOpenedArea.TabIndex = 3;
            numWingOpenedArea.Value = new decimal(new int[] { 450, 0, 0, 262144 });
            // 
            // lblBodyCdLabel
            // 
            lblBodyCdLabel.AutoSize = true;
            lblBodyCdLabel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBodyCdLabel.Location = new Point(578, 35);
            lblBodyCdLabel.Name = "lblBodyCdLabel";
            lblBodyCdLabel.Size = new Size(280, 25);
            lblBodyCdLabel.TabIndex = 4;
            lblBodyCdLabel.Text = "Gövde Sürüklenme Katsayısı Cd:";
            // 
            // numBodyCd
            // 
            numBodyCd.DecimalPlaces = 2;
            numBodyCd.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numBodyCd.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            numBodyCd.Location = new Point(580, 65);
            numBodyCd.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numBodyCd.Name = "numBodyCd";
            numBodyCd.Size = new Size(180, 37);
            numBodyCd.TabIndex = 5;
            numBodyCd.Value = new decimal(new int[] { 80, 0, 0, 131072 });
            // 
            // SatellitePhysicsSubPanel
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(241, 245, 249);
            Controls.Add(grpWingAerodynamics);
            Controls.Add(grpMotors);
            Controls.Add(grpParachutes);
            Controls.Add(grpMasses);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "SatellitePhysicsSubPanel";
            Size = new Size(920, 720);
            grpMasses.ResumeLayout(false);
            grpMasses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCarrierMass).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPayloadMass).EndInit();
            grpParachutes.ResumeLayout(false);
            grpParachutes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numApamArea).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMainParachuteArea).EndInit();
            grpMotors.ResumeLayout(false);
            grpMotors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numThrustCoeff).EndInit();
            grpWingAerodynamics.ResumeLayout(false);
            grpWingAerodynamics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numWingClosedArea).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWingOpenedArea).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBodyCd).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpMasses;
        private System.Windows.Forms.Label lblCarrierLabel;
        private System.Windows.Forms.NumericUpDown numCarrierMass;
        private System.Windows.Forms.Label lblPayloadLabel;
        private System.Windows.Forms.NumericUpDown numPayloadMass;
        private System.Windows.Forms.Label lblTotalMassDisplay;
        private System.Windows.Forms.GroupBox grpParachutes;
        private System.Windows.Forms.Label lblApamAreaLabel;
        private System.Windows.Forms.NumericUpDown numApamArea;
        private System.Windows.Forms.Label lblMainAreaLabel;
        private System.Windows.Forms.NumericUpDown numMainParachuteArea;
        private System.Windows.Forms.GroupBox grpMotors;
        private System.Windows.Forms.Label lblThrustCoeffLabel;
        private System.Windows.Forms.NumericUpDown numThrustCoeff;
        private System.Windows.Forms.Label lblMotorModel;
        private System.Windows.Forms.GroupBox grpWingAerodynamics;
        private System.Windows.Forms.Label lblWingClosedLabel;
        private System.Windows.Forms.NumericUpDown numWingClosedArea;
        private System.Windows.Forms.Label lblWingOpenedLabel;
        private System.Windows.Forms.NumericUpDown numWingOpenedArea;
        private System.Windows.Forms.Label lblBodyCdLabel;
        private System.Windows.Forms.NumericUpDown numBodyCd;
    }
}
