using System;
using System.Drawing;
using System.Windows.Forms;

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
            this.lblTitle = new System.Windows.Forms.Label();

            // 1. Kütle
            this.grpMasses = new System.Windows.Forms.GroupBox();
            this.lblCarrierLabel = new System.Windows.Forms.Label();
            this.numCarrierMass = new System.Windows.Forms.NumericUpDown();
            this.lblPayloadLabel = new System.Windows.Forms.Label();
            this.numPayloadMass = new System.Windows.Forms.NumericUpDown();
            this.lblTotalMassDisplay = new System.Windows.Forms.Label();

            // 2. Faz Bazlı Kesit Alanları ve Cd
            this.grpPhaseAreas = new System.Windows.Forms.GroupBox();

            // Faz 1
            this.lblPhase1Header = new System.Windows.Forms.Label();
            this.lblCarrierAreaLabel = new System.Windows.Forms.Label();
            this.numCarrierArea = new System.Windows.Forms.NumericUpDown();
            this.lblCarrierCdLabel = new System.Windows.Forms.Label();
            this.numCarrierCd = new System.Windows.Forms.NumericUpDown();

            // Faz 2
            this.lblPhase2Header = new System.Windows.Forms.Label();
            this.lblMainAreaLabel = new System.Windows.Forms.Label();
            this.numMainParachuteArea = new System.Windows.Forms.NumericUpDown();
            this.lblMainCdLabel = new System.Windows.Forms.Label();
            this.numMainParachuteCd = new System.Windows.Forms.NumericUpDown();

            // Faz 3
            this.lblPhase3Header = new System.Windows.Forms.Label();
            this.lblWingClosedLabel = new System.Windows.Forms.Label();
            this.numWingClosedArea = new System.Windows.Forms.NumericUpDown();

            // Faz 4
            this.lblPhase4Header = new System.Windows.Forms.Label();
            this.lblWingOpenedLabel = new System.Windows.Forms.Label();
            this.numWingOpenedArea = new System.Windows.Forms.NumericUpDown();
            this.lblBodyCdLabel = new System.Windows.Forms.Label();
            this.numBodyCd = new System.Windows.Forms.NumericUpDown();

            // 3. Faz Geçiş Süreleri
            this.grpTimings = new System.Windows.Forms.GroupBox();
            this.lblPhase1Duration = new System.Windows.Forms.Label();
            this.numPhase1Duration = new System.Windows.Forms.NumericUpDown();
            this.lblPhase2To3Delay = new System.Windows.Forms.Label();
            this.numPhase2ToPhase3Delay = new System.Windows.Forms.NumericUpDown();
            this.lblPhase3To4Deploy = new System.Windows.Forms.Label();
            this.numPhase3ToPhase4DeployTime = new System.Windows.Forms.NumericUpDown();
            this.lblPhase4ToApamDelay = new System.Windows.Forms.Label();
            this.numPhase4ToApamDelay = new System.Windows.Forms.NumericUpDown();

            // 4. Faz 4 -> APAM
            this.grpApam = new System.Windows.Forms.GroupBox();
            this.lblApamAreaLabel = new System.Windows.Forms.Label();
            this.numApamArea = new System.Windows.Forms.NumericUpDown();
            this.lblApamCdLabel = new System.Windows.Forms.Label();
            this.numApamCd = new System.Windows.Forms.NumericUpDown();
            this.lblApamInfo = new System.Windows.Forms.Label();

            // 5. İtki (İki Yöntemli)
            this.grpMotors = new System.Windows.Forms.GroupBox();
            this.rdoMethodDirect = new System.Windows.Forms.RadioButton();
            this.lblMaxThrustLabel = new System.Windows.Forms.Label();
            this.numMaxThrustGram = new System.Windows.Forms.NumericUpDown();
            this.lblDirectNote = new System.Windows.Forms.Label();
            this.rdoMethodPropeller = new System.Windows.Forms.RadioButton();
            this.lblMotorCount = new System.Windows.Forms.Label();
            this.numMotorCount = new System.Windows.Forms.NumericUpDown();
            this.lblPropellerCt = new System.Windows.Forms.Label();
            this.numPropellerCt = new System.Windows.Forms.NumericUpDown();
            this.lblMotorMaxRps = new System.Windows.Forms.Label();
            this.numMotorMaxRps = new System.Windows.Forms.NumericUpDown();
            this.lblPropDiameter = new System.Windows.Forms.Label();
            this.numPropDiameter = new System.Windows.Forms.NumericUpDown();
            this.lblPropellerCalcResult = new System.Windows.Forms.Label();

            // 6. Statik Kuvvet Diyagramı
            this.grpForceDiagram = new System.Windows.Forms.GroupBox();
            this.lblForceHeader = new System.Windows.Forms.Label();
            this.lblHoverAndMargin = new System.Windows.Forms.Label();
            this.lblForceDiagramVisual = new System.Windows.Forms.Label();

            this.grpMasses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCarrierMass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPayloadMass)).BeginInit();
            this.grpPhaseAreas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCarrierArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCarrierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMainParachuteArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMainParachuteCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWingClosedArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWingOpenedArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBodyCd)).BeginInit();
            this.grpTimings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPhase1Duration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhase2ToPhase3Delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhase3ToPhase4DeployTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhase4ToApamDelay)).BeginInit();
            this.grpApam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numApamArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numApamCd)).BeginInit();
            this.grpMotors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxThrustGram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMotorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPropellerCt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMotorMaxRps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPropDiameter)).BeginInit();
            this.grpForceDiagram.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(650, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "UYDU FİZİKSEL ÖZELLİKLERİ, FAZ KESİT ALANLARI VE İTKİ YÖNTEMLERİ";

            // 
            // grpMasses
            // 
            this.grpMasses.Controls.Add(this.lblCarrierLabel);
            this.grpMasses.Controls.Add(this.numCarrierMass);
            this.grpMasses.Controls.Add(this.lblPayloadLabel);
            this.grpMasses.Controls.Add(this.numPayloadMass);
            this.grpMasses.Controls.Add(this.lblTotalMassDisplay);
            this.grpMasses.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMasses.Location = new System.Drawing.Point(25, 60);
            this.grpMasses.Name = "grpMasses";
            this.grpMasses.Size = new System.Drawing.Size(1230, 100);
            this.grpMasses.TabIndex = 1;
            this.grpMasses.TabStop = false;
            this.grpMasses.Text = "1. Uydu Kütle Özellikleri [Gram]";

            // lblCarrierLabel
            this.lblCarrierLabel.AutoSize = true;
            this.lblCarrierLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrierLabel.Location = new System.Drawing.Point(20, 35);
            this.lblCarrierLabel.Name = "lblCarrierLabel";
            this.lblCarrierLabel.Size = new System.Drawing.Size(190, 20);
            this.lblCarrierLabel.Text = "Taşıyıcı Kütlesi (Carrier) [g]:";

            // numCarrierMass
            this.numCarrierMass.DecimalPlaces = 1;
            this.numCarrierMass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCarrierMass.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            this.numCarrierMass.Location = new System.Drawing.Point(22, 60);
            this.numCarrierMass.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numCarrierMass.Name = "numCarrierMass";
            this.numCarrierMass.Size = new System.Drawing.Size(150, 30);
            this.numCarrierMass.TabIndex = 1;
            this.numCarrierMass.Value = new decimal(new int[] { 550, 0, 0, 0 });

            // lblPayloadLabel
            this.lblPayloadLabel.AutoSize = true;
            this.lblPayloadLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayloadLabel.Location = new System.Drawing.Point(240, 35);
            this.lblPayloadLabel.Name = "lblPayloadLabel";
            this.lblPayloadLabel.Size = new System.Drawing.Size(195, 20);
            this.lblPayloadLabel.Text = "Görev Yükü (Payload) [g]:";

            // numPayloadMass
            this.numPayloadMass.DecimalPlaces = 1;
            this.numPayloadMass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPayloadMass.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            this.numPayloadMass.Location = new System.Drawing.Point(242, 60);
            this.numPayloadMass.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            this.numPayloadMass.Name = "numPayloadMass";
            this.numPayloadMass.Size = new System.Drawing.Size(150, 30);
            this.numPayloadMass.TabIndex = 2;
            this.numPayloadMass.Value = new decimal(new int[] { 1250, 0, 0, 0 });

            // lblTotalMassDisplay
            this.lblTotalMassDisplay.AutoSize = true;
            this.lblTotalMassDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMassDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTotalMassDisplay.Location = new System.Drawing.Point(460, 62);
            this.lblTotalMassDisplay.Name = "lblTotalMassDisplay";
            this.lblTotalMassDisplay.Size = new System.Drawing.Size(420, 25);
            this.lblTotalMassDisplay.TabIndex = 3;
            this.lblTotalMassDisplay.Text = "TOPLAM KÜTLE (Taşıyıcı + Görev Yükü): 1800 g (1.80 kg)";

            // 
            // grpPhaseAreas
            // 
            this.grpPhaseAreas.Controls.Add(this.lblPhase1Header);
            this.grpPhaseAreas.Controls.Add(this.lblCarrierAreaLabel);
            this.grpPhaseAreas.Controls.Add(this.numCarrierArea);
            this.grpPhaseAreas.Controls.Add(this.lblCarrierCdLabel);
            this.grpPhaseAreas.Controls.Add(this.numCarrierCd);
            this.grpPhaseAreas.Controls.Add(this.lblPhase2Header);
            this.grpPhaseAreas.Controls.Add(this.lblMainAreaLabel);
            this.grpPhaseAreas.Controls.Add(this.numMainParachuteArea);
            this.grpPhaseAreas.Controls.Add(this.lblMainCdLabel);
            this.grpPhaseAreas.Controls.Add(this.numMainParachuteCd);
            this.grpPhaseAreas.Controls.Add(this.lblPhase3Header);
            this.grpPhaseAreas.Controls.Add(this.lblWingClosedLabel);
            this.grpPhaseAreas.Controls.Add(this.numWingClosedArea);
            this.grpPhaseAreas.Controls.Add(this.lblPhase4Header);
            this.grpPhaseAreas.Controls.Add(this.lblWingOpenedLabel);
            this.grpPhaseAreas.Controls.Add(this.numWingOpenedArea);
            this.grpPhaseAreas.Controls.Add(this.lblBodyCdLabel);
            this.grpPhaseAreas.Controls.Add(this.numBodyCd);
            this.grpPhaseAreas.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPhaseAreas.Location = new System.Drawing.Point(25, 175);
            this.grpPhaseAreas.Name = "grpPhaseAreas";
            this.grpPhaseAreas.Size = new System.Drawing.Size(1230, 270);
            this.grpPhaseAreas.TabIndex = 2;
            this.grpPhaseAreas.TabStop = false;
            this.grpPhaseAreas.Text = "2. 4 Ana Fazın Referans Kesit Alanları ve Aerodinamik Sürüklenme Katsayıları [m² & Cd]";

            // lblPhase1Header
            this.lblPhase1Header.AutoSize = true;
            this.lblPhase1Header.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase1Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.lblPhase1Header.Location = new System.Drawing.Point(20, 35);
            this.lblPhase1Header.Name = "lblPhase1Header";
            this.lblPhase1Header.Size = new System.Drawing.Size(260, 21);
            this.lblPhase1Header.Text = "--- FAZ 1 (ROKETLE YÜKSELİŞ) ---";

            // lblCarrierAreaLabel
            this.lblCarrierAreaLabel.AutoSize = true;
            this.lblCarrierAreaLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrierAreaLabel.Location = new System.Drawing.Point(20, 65);
            this.lblCarrierAreaLabel.Name = "lblCarrierAreaLabel";
            this.lblCarrierAreaLabel.Size = new System.Drawing.Size(160, 20);
            this.lblCarrierAreaLabel.Text = "Taşıyıcı Kesit Alanı [m²]:";

            // numCarrierArea
            this.numCarrierArea.DecimalPlaces = 4;
            this.numCarrierArea.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCarrierArea.Increment = new decimal(new int[] { 5, 0, 0, 262144 });
            this.numCarrierArea.Location = new System.Drawing.Point(22, 90);
            this.numCarrierArea.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numCarrierArea.Name = "numCarrierArea";
            this.numCarrierArea.Size = new System.Drawing.Size(140, 30);
            this.numCarrierArea.TabIndex = 1;
            this.numCarrierArea.Value = new decimal(new int[] { 314, 0, 0, 262144 });

            // lblCarrierCdLabel
            this.lblCarrierCdLabel.AutoSize = true;
            this.lblCarrierCdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarrierCdLabel.Location = new System.Drawing.Point(180, 65);
            this.lblCarrierCdLabel.Name = "lblCarrierCdLabel";
            this.lblCarrierCdLabel.Size = new System.Drawing.Size(95, 20);
            this.lblCarrierCdLabel.Text = "Taşıyıcı C_d:";

            // numCarrierCd
            this.numCarrierCd.DecimalPlaces = 2;
            this.numCarrierCd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCarrierCd.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numCarrierCd.Location = new System.Drawing.Point(182, 90);
            this.numCarrierCd.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numCarrierCd.Name = "numCarrierCd";
            this.numCarrierCd.Size = new System.Drawing.Size(110, 30);
            this.numCarrierCd.TabIndex = 2;
            this.numCarrierCd.Value = new decimal(new int[] { 45, 0, 0, 131072 });

            // lblPhase2Header
            this.lblPhase2Header.AutoSize = true;
            this.lblPhase2Header.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase2Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.lblPhase2Header.Location = new System.Drawing.Point(340, 35);
            this.lblPhase2Header.Name = "lblPhase2Header";
            this.lblPhase2Header.Size = new System.Drawing.Size(265, 21);
            this.lblPhase2Header.Text = "--- FAZ 2 (ANA PARAŞÜT SÜZÜLÜŞ) ---";

            // lblMainAreaLabel
            this.lblMainAreaLabel.AutoSize = true;
            this.lblMainAreaLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainAreaLabel.Location = new System.Drawing.Point(340, 65);
            this.lblMainAreaLabel.Name = "lblMainAreaLabel";
            this.lblMainAreaLabel.Size = new System.Drawing.Size(175, 20);
            this.lblMainAreaLabel.Text = "Ana Paraşüt Alanı [m²]:";

            // numMainParachuteArea
            this.numMainParachuteArea.DecimalPlaces = 4;
            this.numMainParachuteArea.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMainParachuteArea.Increment = new decimal(new int[] { 5, 0, 0, 196608 });
            this.numMainParachuteArea.Location = new System.Drawing.Point(342, 90);
            this.numMainParachuteArea.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.numMainParachuteArea.Name = "numMainParachuteArea";
            this.numMainParachuteArea.Size = new System.Drawing.Size(150, 30);
            this.numMainParachuteArea.TabIndex = 3;
            this.numMainParachuteArea.Value = new decimal(new int[] { 1256, 0, 0, 196608 });

            // lblMainCdLabel
            this.lblMainCdLabel.AutoSize = true;
            this.lblMainCdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainCdLabel.Location = new System.Drawing.Point(510, 65);
            this.lblMainCdLabel.Name = "lblMainCdLabel";
            this.lblMainCdLabel.Size = new System.Drawing.Size(110, 20);
            this.lblMainCdLabel.Text = "Ana Paraşüt C_d:";

            // numMainParachuteCd
            this.numMainParachuteCd.DecimalPlaces = 2;
            this.numMainParachuteCd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMainParachuteCd.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numMainParachuteCd.Location = new System.Drawing.Point(512, 90);
            this.numMainParachuteCd.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numMainParachuteCd.Name = "numMainParachuteCd";
            this.numMainParachuteCd.Size = new System.Drawing.Size(110, 30);
            this.numMainParachuteCd.TabIndex = 4;
            this.numMainParachuteCd.Value = new decimal(new int[] { 150, 0, 0, 131072 });

            // lblPhase3Header
            this.lblPhase3Header.AutoSize = true;
            this.lblPhase3Header.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase3Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(40)))), ((int)(((byte)(217)))));
            this.lblPhase3Header.Location = new System.Drawing.Point(20, 145);
            this.lblPhase3Header.Name = "lblPhase3Header";
            this.lblPhase3Header.Size = new System.Drawing.Size(310, 21);
            this.lblPhase3Header.Text = "--- FAZ 3 (AYRILMA & KANATLAR KAPALI) ---";

            // lblWingClosedLabel
            this.lblWingClosedLabel.AutoSize = true;
            this.lblWingClosedLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWingClosedLabel.Location = new System.Drawing.Point(20, 175);
            this.lblWingClosedLabel.Name = "lblWingClosedLabel";
            this.lblWingClosedLabel.Size = new System.Drawing.Size(185, 20);
            this.lblWingClosedLabel.Text = "Kapalı Kanat Alanı [m²]:";

            // numWingClosedArea
            this.numWingClosedArea.DecimalPlaces = 4;
            this.numWingClosedArea.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWingClosedArea.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            this.numWingClosedArea.Location = new System.Drawing.Point(22, 200);
            this.numWingClosedArea.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numWingClosedArea.Name = "numWingClosedArea";
            this.numWingClosedArea.Size = new System.Drawing.Size(150, 30);
            this.numWingClosedArea.TabIndex = 5;
            this.numWingClosedArea.Value = new decimal(new int[] { 150, 0, 0, 262144 });

            // lblPhase4Header
            this.lblPhase4Header.AutoSize = true;
            this.lblPhase4Header.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase4Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(120)))), ((int)(((byte)(87)))));
            this.lblPhase4Header.Location = new System.Drawing.Point(340, 145);
            this.lblPhase4Header.Name = "lblPhase4Header";
            this.lblPhase4Header.Size = new System.Drawing.Size(295, 21);
            this.lblPhase4Header.Text = "--- FAZ 4 (KANATLAR AÇIK AKTİF İNİŞ) ---";

            // lblWingOpenedLabel
            this.lblWingOpenedLabel.AutoSize = true;
            this.lblWingOpenedLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWingOpenedLabel.Location = new System.Drawing.Point(340, 175);
            this.lblWingOpenedLabel.Name = "lblWingOpenedLabel";
            this.lblWingOpenedLabel.Size = new System.Drawing.Size(180, 20);
            this.lblWingOpenedLabel.Text = "Açık Kanat Alanı [m²]:";

            // numWingOpenedArea
            this.numWingOpenedArea.DecimalPlaces = 4;
            this.numWingOpenedArea.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWingOpenedArea.Increment = new decimal(new int[] { 5, 0, 0, 196608 });
            this.numWingOpenedArea.Location = new System.Drawing.Point(342, 200);
            this.numWingOpenedArea.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numWingOpenedArea.Name = "numWingOpenedArea";
            this.numWingOpenedArea.Size = new System.Drawing.Size(150, 30);
            this.numWingOpenedArea.TabIndex = 6;
            this.numWingOpenedArea.Value = new decimal(new int[] { 450, 0, 0, 262144 });

            // lblBodyCdLabel
            this.lblBodyCdLabel.AutoSize = true;
            this.lblBodyCdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBodyCdLabel.Location = new System.Drawing.Point(510, 175);
            this.lblBodyCdLabel.Name = "lblBodyCdLabel";
            this.lblBodyCdLabel.Size = new System.Drawing.Size(190, 20);
            this.lblBodyCdLabel.Text = "Ortak Gövde C_d (F3 & F4):";

            // numBodyCd
            this.numBodyCd.DecimalPlaces = 2;
            this.numBodyCd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBodyCd.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numBodyCd.Location = new System.Drawing.Point(512, 200);
            this.numBodyCd.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numBodyCd.Name = "numBodyCd";
            this.numBodyCd.Size = new System.Drawing.Size(120, 30);
            this.numBodyCd.TabIndex = 7;
            this.numBodyCd.Value = new decimal(new int[] { 80, 0, 0, 131072 });

            // 
            // grpTimings
            // 
            this.grpTimings.Controls.Add(this.lblPhase1Duration);
            this.grpTimings.Controls.Add(this.numPhase1Duration);
            this.grpTimings.Controls.Add(this.lblPhase2To3Delay);
            this.grpTimings.Controls.Add(this.numPhase2ToPhase3Delay);
            this.grpTimings.Controls.Add(this.lblPhase3To4Deploy);
            this.grpTimings.Controls.Add(this.numPhase3ToPhase4DeployTime);
            this.grpTimings.Controls.Add(this.lblPhase4ToApamDelay);
            this.grpTimings.Controls.Add(this.numPhase4ToApamDelay);
            this.grpTimings.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTimings.Location = new System.Drawing.Point(25, 460);
            this.grpTimings.Name = "grpTimings";
            this.grpTimings.Size = new System.Drawing.Size(1230, 115);
            this.grpTimings.TabIndex = 3;
            this.grpTimings.TabStop = false;
            this.grpTimings.Text = "3. Faz Geçiş Gecikmeleri ve Mekanizma Açılma Süreleri [Saniye]";

            // lblPhase1Duration
            this.lblPhase1Duration.AutoSize = true;
            this.lblPhase1Duration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase1Duration.Location = new System.Drawing.Point(20, 35);
            this.lblPhase1Duration.Name = "lblPhase1Duration";
            this.lblPhase1Duration.Size = new System.Drawing.Size(185, 20);
            this.lblPhase1Duration.Text = "Roketle Yükseliş Süresi [s]:";

            // numPhase1Duration
            this.numPhase1Duration.DecimalPlaces = 1;
            this.numPhase1Duration.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPhase1Duration.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numPhase1Duration.Location = new System.Drawing.Point(22, 60);
            this.numPhase1Duration.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            this.numPhase1Duration.Name = "numPhase1Duration";
            this.numPhase1Duration.Size = new System.Drawing.Size(140, 30);
            this.numPhase1Duration.TabIndex = 1;
            this.numPhase1Duration.Value = new decimal(new int[] { 160, 0, 0, 65536 });

            // lblPhase2To3Delay
            this.lblPhase2To3Delay.AutoSize = true;
            this.lblPhase2To3Delay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase2To3Delay.Location = new System.Drawing.Point(230, 35);
            this.lblPhase2To3Delay.Name = "lblPhase2To3Delay";
            this.lblPhase2To3Delay.Size = new System.Drawing.Size(205, 20);
            this.lblPhase2To3Delay.Text = "Faz 2->3 Ayrılma Gecikmesi [s]:";

            // numPhase2ToPhase3Delay
            this.numPhase2ToPhase3Delay.DecimalPlaces = 1;
            this.numPhase2ToPhase3Delay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPhase2ToPhase3Delay.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numPhase2ToPhase3Delay.Location = new System.Drawing.Point(232, 60);
            this.numPhase2ToPhase3Delay.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.numPhase2ToPhase3Delay.Name = "numPhase2ToPhase3Delay";
            this.numPhase2ToPhase3Delay.Size = new System.Drawing.Size(140, 30);
            this.numPhase2ToPhase3Delay.TabIndex = 2;
            this.numPhase2ToPhase3Delay.Value = new decimal(new int[] { 20, 0, 0, 65536 });

            // lblPhase3To4Deploy
            this.lblPhase3To4Deploy.AutoSize = true;
            this.lblPhase3To4Deploy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase3To4Deploy.Location = new System.Drawing.Point(460, 35);
            this.lblPhase3To4Deploy.Name = "lblPhase3To4Deploy";
            this.lblPhase3To4Deploy.Size = new System.Drawing.Size(205, 20);
            this.lblPhase3To4Deploy.Text = "Faz 3->4 Kanat Açılma Sür. [s]:";

            // numPhase3ToPhase4DeployTime
            this.numPhase3ToPhase4DeployTime.DecimalPlaces = 1;
            this.numPhase3ToPhase4DeployTime.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPhase3ToPhase4DeployTime.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numPhase3ToPhase4DeployTime.Location = new System.Drawing.Point(462, 60);
            this.numPhase3ToPhase4DeployTime.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.numPhase3ToPhase4DeployTime.Name = "numPhase3ToPhase4DeployTime";
            this.numPhase3ToPhase4DeployTime.Size = new System.Drawing.Size(140, 30);
            this.numPhase3ToPhase4DeployTime.TabIndex = 3;
            this.numPhase3ToPhase4DeployTime.Value = new decimal(new int[] { 15, 0, 0, 65536 });

            // lblPhase4ToApamDelay
            this.lblPhase4ToApamDelay.AutoSize = true;
            this.lblPhase4ToApamDelay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase4ToApamDelay.Location = new System.Drawing.Point(690, 35);
            this.lblPhase4ToApamDelay.Name = "lblPhase4ToApamDelay";
            this.lblPhase4ToApamDelay.Size = new System.Drawing.Size(210, 20);
            this.lblPhase4ToApamDelay.Text = "Faz 4->APAM Algılama Gecik. [s]:";

            // numPhase4ToApamDelay
            this.numPhase4ToApamDelay.DecimalPlaces = 1;
            this.numPhase4ToApamDelay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPhase4ToApamDelay.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numPhase4ToApamDelay.Location = new System.Drawing.Point(692, 60);
            this.numPhase4ToApamDelay.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.numPhase4ToApamDelay.Name = "numPhase4ToApamDelay";
            this.numPhase4ToApamDelay.Size = new System.Drawing.Size(140, 30);
            this.numPhase4ToApamDelay.TabIndex = 4;
            this.numPhase4ToApamDelay.Value = new decimal(new int[] { 15, 0, 0, 65536 });

            // 
            // grpApam
            // 
            this.grpApam.Controls.Add(this.lblApamAreaLabel);
            this.grpApam.Controls.Add(this.numApamArea);
            this.grpApam.Controls.Add(this.lblApamCdLabel);
            this.grpApam.Controls.Add(this.numApamCd);
            this.grpApam.Controls.Add(this.lblApamInfo);
            this.grpApam.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpApam.Location = new System.Drawing.Point(25, 590);
            this.grpApam.Name = "grpApam";
            this.grpApam.Size = new System.Drawing.Size(1230, 110);
            this.grpApam.TabIndex = 4;
            this.grpApam.TabStop = false;
            this.grpApam.Text = "4. Acil Durum Koruma (APAM - Sadece Faz 4 -> APAM Tetiklemesinde Aktif)";

            // lblApamAreaLabel
            this.lblApamAreaLabel.AutoSize = true;
            this.lblApamAreaLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApamAreaLabel.Location = new System.Drawing.Point(20, 35);
            this.lblApamAreaLabel.Name = "lblApamAreaLabel";
            this.lblApamAreaLabel.Size = new System.Drawing.Size(165, 20);
            this.lblApamAreaLabel.Text = "APAM Kesit Alanı [m²]:";

            // numApamArea
            this.numApamArea.DecimalPlaces = 4;
            this.numApamArea.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numApamArea.Increment = new decimal(new int[] { 5, 0, 0, 196608 });
            this.numApamArea.Location = new System.Drawing.Point(22, 60);
            this.numApamArea.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numApamArea.Name = "numApamArea";
            this.numApamArea.Size = new System.Drawing.Size(160, 30);
            this.numApamArea.TabIndex = 1;
            this.numApamArea.Value = new decimal(new int[] { 450, 0, 0, 262144 });

            // lblApamCdLabel
            this.lblApamCdLabel.AutoSize = true;
            this.lblApamCdLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApamCdLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblApamCdLabel.Location = new System.Drawing.Point(210, 35);
            this.lblApamCdLabel.Name = "lblApamCdLabel";
            this.lblApamCdLabel.Size = new System.Drawing.Size(80, 20);
            this.lblApamCdLabel.Text = "APAM C_d:";

            // numApamCd
            this.numApamCd.DecimalPlaces = 2;
            this.numApamCd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numApamCd.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numApamCd.Location = new System.Drawing.Point(212, 60);
            this.numApamCd.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numApamCd.Name = "numApamCd";
            this.numApamCd.Size = new System.Drawing.Size(120, 30);
            this.numApamCd.TabIndex = 2;
            this.numApamCd.Value = new decimal(new int[] { 160, 0, 0, 131072 });

            // lblApamInfo
            this.lblApamInfo.AutoSize = true;
            this.lblApamInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApamInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblApamInfo.Location = new System.Drawing.Point(360, 65);
            this.lblApamInfo.Name = "lblApamInfo";
            this.lblApamInfo.Size = new System.Drawing.Size(340, 20);
            this.lblApamInfo.Text = "(APAM sadece Faz 4 esnasında yüksek hızla tetiklenir)";

            // 
            // grpMotors (5. İtki Sistemi İki Yöntemli)
            // 
            this.grpMotors.Controls.Add(this.rdoMethodDirect);
            this.grpMotors.Controls.Add(this.lblMaxThrustLabel);
            this.grpMotors.Controls.Add(this.numMaxThrustGram);
            this.grpMotors.Controls.Add(this.lblDirectNote);
            this.grpMotors.Controls.Add(this.rdoMethodPropeller);
            this.grpMotors.Controls.Add(this.lblMotorCount);
            this.grpMotors.Controls.Add(this.numMotorCount);
            this.grpMotors.Controls.Add(this.lblPropellerCt);
            this.grpMotors.Controls.Add(this.numPropellerCt);
            this.grpMotors.Controls.Add(this.lblMotorMaxRps);
            this.grpMotors.Controls.Add(this.numMotorMaxRps);
            this.grpMotors.Controls.Add(this.lblPropDiameter);
            this.grpMotors.Controls.Add(this.numPropDiameter);
            this.grpMotors.Controls.Add(this.lblPropellerCalcResult);
            this.grpMotors.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMotors.Location = new System.Drawing.Point(25, 715);
            this.grpMotors.Name = "grpMotors";
            this.grpMotors.Size = new System.Drawing.Size(1230, 165);
            this.grpMotors.TabIndex = 5;
            this.grpMotors.TabStop = false;
            this.grpMotors.Text = "5. İtki Sistemi ve Maksimum İtki Belirleme Yöntemi (Emax Eco 2306 2400KV & HQ 5x4x3 Pervane Varsayılanları)";

            // rdoMethodDirect
            this.rdoMethodDirect.AutoSize = true;
            this.rdoMethodDirect.Checked = true;
            this.rdoMethodDirect.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMethodDirect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.rdoMethodDirect.Location = new System.Drawing.Point(20, 30);
            this.rdoMethodDirect.Name = "rdoMethodDirect";
            this.rdoMethodDirect.Size = new System.Drawing.Size(375, 27);
            this.rdoMethodDirect.TabIndex = 0;
            this.rdoMethodDirect.TabStop = true;
            this.rdoMethodDirect.Text = "Seçenek A: Doğrudan Toplam İtki Girişi (Katalog)";

            // lblMaxThrustLabel
            this.lblMaxThrustLabel.AutoSize = true;
            this.lblMaxThrustLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxThrustLabel.Location = new System.Drawing.Point(35, 65);
            this.lblMaxThrustLabel.Name = "lblMaxThrustLabel";
            this.lblMaxThrustLabel.Size = new System.Drawing.Size(155, 20);
            this.lblMaxThrustLabel.Text = "Maks. Toplam İtki [g]:";

            // numMaxThrustGram
            this.numMaxThrustGram.DecimalPlaces = 1;
            this.numMaxThrustGram.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMaxThrustGram.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            this.numMaxThrustGram.Location = new System.Drawing.Point(35, 90);
            this.numMaxThrustGram.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numMaxThrustGram.Name = "numMaxThrustGram";
            this.numMaxThrustGram.Size = new System.Drawing.Size(160, 30);
            this.numMaxThrustGram.TabIndex = 1;
            this.numMaxThrustGram.Value = new decimal(new int[] { 4780, 0, 0, 0 });

            // lblDirectNote
            this.lblDirectNote.AutoSize = true;
            this.lblDirectNote.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirectNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDirectNote.Location = new System.Drawing.Point(210, 93);
            this.lblDirectNote.Name = "lblDirectNote";
            this.lblDirectNote.Size = new System.Drawing.Size(220, 20);
            this.lblDirectNote.Text = "(Emax 2306 & HQ 5x4x3 verisi)";

            // rdoMethodPropeller
            this.rdoMethodPropeller.AutoSize = true;
            this.rdoMethodPropeller.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMethodPropeller.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(120)))), ((int)(((byte)(87)))));
            this.rdoMethodPropeller.Location = new System.Drawing.Point(450, 30);
            this.rdoMethodPropeller.Name = "rdoMethodPropeller";
            this.rdoMethodPropeller.Size = new System.Drawing.Size(510, 27);
            this.rdoMethodPropeller.TabIndex = 3;
            this.rdoMethodPropeller.Text = "Seçenek B: Pervane Aerodinamik Formülü (T = N · C_T · ρ · n² · D⁴)";

            // lblMotorCount
            this.lblMotorCount.AutoSize = true;
            this.lblMotorCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotorCount.Location = new System.Drawing.Point(470, 65);
            this.lblMotorCount.Name = "lblMotorCount";
            this.lblMotorCount.Size = new System.Drawing.Size(95, 20);
            this.lblMotorCount.Text = "Motor Sayısı:";

            // numMotorCount
            this.numMotorCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMotorCount.Location = new System.Drawing.Point(470, 90);
            this.numMotorCount.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            this.numMotorCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numMotorCount.Name = "numMotorCount";
            this.numMotorCount.Size = new System.Drawing.Size(95, 30);
            this.numMotorCount.TabIndex = 4;
            this.numMotorCount.Value = new decimal(new int[] { 4, 0, 0, 0 });

            // lblPropellerCt
            this.lblPropellerCt.AutoSize = true;
            this.lblPropellerCt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropellerCt.Location = new System.Drawing.Point(580, 65);
            this.lblPropellerCt.Name = "lblPropellerCt";
            this.lblPropellerCt.Size = new System.Drawing.Size(85, 20);
            this.lblPropellerCt.Text = "Pervane Ct:";

            // numPropellerCt
            this.numPropellerCt.DecimalPlaces = 4;
            this.numPropellerCt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPropellerCt.Increment = new decimal(new int[] { 5, 0, 0, 196608 });
            this.numPropellerCt.Location = new System.Drawing.Point(580, 90);
            this.numPropellerCt.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numPropellerCt.Name = "numPropellerCt";
            this.numPropellerCt.Size = new System.Drawing.Size(105, 30);
            this.numPropellerCt.TabIndex = 5;
            this.numPropellerCt.Value = new decimal(new int[] { 1415, 0, 0, 262144 });

            // lblMotorMaxRps
            this.lblMotorMaxRps.AutoSize = true;
            this.lblMotorMaxRps.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotorMaxRps.Location = new System.Drawing.Point(700, 65);
            this.lblMotorMaxRps.Name = "lblMotorMaxRps";
            this.lblMotorMaxRps.Size = new System.Drawing.Size(115, 20);
            this.lblMotorMaxRps.Text = "Maks Devir [rps]:";

            // numMotorMaxRps
            this.numMotorMaxRps.DecimalPlaces = 1;
            this.numMotorMaxRps.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMotorMaxRps.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            this.numMotorMaxRps.Location = new System.Drawing.Point(700, 90);
            this.numMotorMaxRps.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.numMotorMaxRps.Name = "numMotorMaxRps";
            this.numMotorMaxRps.Size = new System.Drawing.Size(115, 30);
            this.numMotorMaxRps.TabIndex = 6;
            this.numMotorMaxRps.Value = new decimal(new int[] { 519, 0, 0, 0 });

            // lblPropDiameter
            this.lblPropDiameter.AutoSize = true;
            this.lblPropDiameter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropDiameter.Location = new System.Drawing.Point(830, 65);
            this.lblPropDiameter.Name = "lblPropDiameter";
            this.lblPropDiameter.Size = new System.Drawing.Size(115, 20);
            this.lblPropDiameter.Text = "Pervane Çapı [m]:";

            // numPropDiameter
            this.numPropDiameter.DecimalPlaces = 4;
            this.numPropDiameter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPropDiameter.Increment = new decimal(new int[] { 5, 0, 0, 196608 });
            this.numPropDiameter.Location = new System.Drawing.Point(830, 90);
            this.numPropDiameter.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            this.numPropDiameter.Name = "numPropDiameter";
            this.numPropDiameter.Size = new System.Drawing.Size(120, 30);
            this.numPropDiameter.TabIndex = 7;
            this.numPropDiameter.Value = new decimal(new int[] { 1270, 0, 0, 262144 });

            // lblPropellerCalcResult
            this.lblPropellerCalcResult.AutoSize = true;
            this.lblPropellerCalcResult.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropellerCalcResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblPropellerCalcResult.Location = new System.Drawing.Point(970, 75);
            this.lblPropellerCalcResult.Name = "lblPropellerCalcResult";
            this.lblPropellerCalcResult.Size = new System.Drawing.Size(240, 50);
            this.lblPropellerCalcResult.TabIndex = 8;
            this.lblPropellerCalcResult.Text = "💡 Formül T_max:\r\n= 4780 gram (46.88 N)";

            // 
            // grpForceDiagram
            // 
            this.grpForceDiagram.Controls.Add(this.lblForceHeader);
            this.grpForceDiagram.Controls.Add(this.lblHoverAndMargin);
            this.grpForceDiagram.Controls.Add(this.lblForceDiagramVisual);
            this.grpForceDiagram.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpForceDiagram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.grpForceDiagram.Location = new System.Drawing.Point(25, 895);
            this.grpForceDiagram.Name = "grpForceDiagram";
            this.grpForceDiagram.Size = new System.Drawing.Size(1230, 360);
            this.grpForceDiagram.TabIndex = 6;
            this.grpForceDiagram.TabStop = false;
            this.grpForceDiagram.Text = "6. Statik İtki, Hover (Asılı Kalma) Oranı ve PID Manevra Payı Diyagramı (Hız = 0 m/s)";

            // lblForceHeader
            this.lblForceHeader.AutoSize = true;
            this.lblForceHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.lblForceHeader.Location = new System.Drawing.Point(20, 35);
            this.lblForceHeader.Name = "lblForceHeader";
            this.lblForceHeader.Size = new System.Drawing.Size(600, 25);
            this.lblForceHeader.TabIndex = 0;
            this.lblForceHeader.Text = "▼ Fg (Yerçekimi Ağırlığı) = 1250 g | ▲ F_max (Maks İtki) = 4780 g";

            // lblHoverAndMargin
            this.lblHoverAndMargin.AutoSize = true;
            this.lblHoverAndMargin.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoverAndMargin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblHoverAndMargin.Location = new System.Drawing.Point(20, 70);
            this.lblHoverAndMargin.Name = "lblHoverAndMargin";
            this.lblHoverAndMargin.Size = new System.Drawing.Size(800, 46);
            this.lblHoverAndMargin.TabIndex = 1;
            this.lblHoverAndMargin.Text = "█ HAVADA ASILI KALMA (HOVER) ORANI: %26.2 (Sadece yerçekimini dengelemek için harcanır)\r\n█ PID MANEVRA VE DÜZELTME PAYI    : %73.8 (Rüzgar, ani frenleme ve stabilizasyon için marj)";

            // lblForceDiagramVisual
            this.lblForceDiagramVisual.AutoSize = true;
            this.lblForceDiagramVisual.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForceDiagramVisual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblForceDiagramVisual.Location = new System.Drawing.Point(30, 130);
            this.lblForceDiagramVisual.Name = "lblForceDiagramVisual";
            this.lblForceDiagramVisual.Size = new System.Drawing.Size(500, 200);
            this.lblForceDiagramVisual.TabIndex = 2;
            this.lblForceDiagramVisual.Text = "     ▲  F_max (Maksimum İtki Kapasitesi)\r\n     │  = 4 Motor × 1195 g = 4780 gram (46.88 N)\r\n┌────┴────┐\r\n│  GÖREV  │  Görev Yükü Kütlesi: 1250 gram\r\n│  YÜKÜ   │  Hover Oranı: %26.2 | PID Marjı: %73.8\r\n└────┬────┘\r\n     │\r\n     ▼  Fg (Yerçekimi Ağırlığı)\r\n        = 1250 gram (12.26 N)";

            // 
            // SatellitePhysicsSubPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.grpForceDiagram);
            this.Controls.Add(this.grpMotors);
            this.Controls.Add(this.grpApam);
            this.Controls.Add(this.grpTimings);
            this.Controls.Add(this.grpPhaseAreas);
            this.Controls.Add(this.grpMasses);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SatellitePhysicsSubPanel";
            this.Size = new System.Drawing.Size(1280, 1280);
            this.grpMasses.ResumeLayout(false);
            this.grpMasses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCarrierMass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPayloadMass)).EndInit();
            this.grpPhaseAreas.ResumeLayout(false);
            this.grpPhaseAreas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCarrierArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCarrierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMainParachuteArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMainParachuteCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWingClosedArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWingOpenedArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBodyCd)).EndInit();
            this.grpTimings.ResumeLayout(false);
            this.grpTimings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPhase1Duration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhase2ToPhase3Delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhase3ToPhase4DeployTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhase4ToApamDelay)).EndInit();
            this.grpApam.ResumeLayout(false);
            this.grpApam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numApamArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numApamCd)).EndInit();
            this.grpMotors.ResumeLayout(false);
            this.grpMotors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxThrustGram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMotorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPropellerCt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMotorMaxRps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPropDiameter)).EndInit();
            this.grpForceDiagram.ResumeLayout(false);
            this.grpForceDiagram.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpMasses;
        private System.Windows.Forms.Label lblCarrierLabel;
        private System.Windows.Forms.NumericUpDown numCarrierMass;
        private System.Windows.Forms.Label lblPayloadLabel;
        private System.Windows.Forms.NumericUpDown numPayloadMass;
        private System.Windows.Forms.Label lblTotalMassDisplay;

        private System.Windows.Forms.GroupBox grpPhaseAreas;
        private System.Windows.Forms.Label lblPhase1Header;
        private System.Windows.Forms.Label lblCarrierAreaLabel;
        private System.Windows.Forms.NumericUpDown numCarrierArea;
        private System.Windows.Forms.Label lblCarrierCdLabel;
        private System.Windows.Forms.NumericUpDown numCarrierCd;

        private System.Windows.Forms.Label lblPhase2Header;
        private System.Windows.Forms.Label lblMainAreaLabel;
        private System.Windows.Forms.NumericUpDown numMainParachuteArea;
        private System.Windows.Forms.Label lblMainCdLabel;
        private System.Windows.Forms.NumericUpDown numMainParachuteCd;

        private System.Windows.Forms.Label lblPhase3Header;
        private System.Windows.Forms.Label lblWingClosedLabel;
        private System.Windows.Forms.NumericUpDown numWingClosedArea;

        private System.Windows.Forms.Label lblPhase4Header;
        private System.Windows.Forms.Label lblWingOpenedLabel;
        private System.Windows.Forms.NumericUpDown numWingOpenedArea;
        private System.Windows.Forms.Label lblBodyCdLabel;
        private System.Windows.Forms.NumericUpDown numBodyCd;

        private System.Windows.Forms.GroupBox grpTimings;
        private System.Windows.Forms.Label lblPhase1Duration;
        private System.Windows.Forms.NumericUpDown numPhase1Duration;
        private System.Windows.Forms.Label lblPhase2To3Delay;
        private System.Windows.Forms.NumericUpDown numPhase2ToPhase3Delay;
        private System.Windows.Forms.Label lblPhase3To4Deploy;
        private System.Windows.Forms.NumericUpDown numPhase3ToPhase4DeployTime;
        private System.Windows.Forms.Label lblPhase4ToApamDelay;
        private System.Windows.Forms.NumericUpDown numPhase4ToApamDelay;

        private System.Windows.Forms.GroupBox grpApam;
        private System.Windows.Forms.Label lblApamAreaLabel;
        private System.Windows.Forms.NumericUpDown numApamArea;
        private System.Windows.Forms.Label lblApamCdLabel;
        private System.Windows.Forms.NumericUpDown numApamCd;
        private System.Windows.Forms.Label lblApamInfo;

        private System.Windows.Forms.GroupBox grpMotors;
        private System.Windows.Forms.RadioButton rdoMethodDirect;
        private System.Windows.Forms.Label lblMaxThrustLabel;
        private System.Windows.Forms.NumericUpDown numMaxThrustGram;
        private System.Windows.Forms.Label lblDirectNote;
        private System.Windows.Forms.RadioButton rdoMethodPropeller;
        private System.Windows.Forms.Label lblMotorCount;
        private System.Windows.Forms.NumericUpDown numMotorCount;
        private System.Windows.Forms.Label lblPropellerCt;
        private System.Windows.Forms.NumericUpDown numPropellerCt;
        private System.Windows.Forms.Label lblMotorMaxRps;
        private System.Windows.Forms.NumericUpDown numMotorMaxRps;
        private System.Windows.Forms.Label lblPropDiameter;
        private System.Windows.Forms.NumericUpDown numPropDiameter;
        private System.Windows.Forms.Label lblPropellerCalcResult;

        private System.Windows.Forms.GroupBox grpForceDiagram;
        private System.Windows.Forms.Label lblForceHeader;
        private System.Windows.Forms.Label lblHoverAndMargin;
        private System.Windows.Forms.Label lblForceDiagramVisual;
    }
}
