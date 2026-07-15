namespace FlyingAnalysis.UI.Panels
{
    partial class SimulationConfigDashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnLoadDefaults = new System.Windows.Forms.Button();
            this.pnlSidebarMenu = new System.Windows.Forms.Panel();
            this.btnTab8_Contingency = new System.Windows.Forms.Button();
            this.btnTab7_Landing = new System.Windows.Forms.Button();
            this.btnTab6_ControlledDescent = new System.Windows.Forms.Button();
            this.btnTab5_BrakePhase = new System.Windows.Forms.Button();
            this.btnTab4_Separation = new System.Windows.Forms.Button();
            this.btnTab3_Ascent = new System.Windows.Forms.Button();
            this.btnTab2_SatellitePhysics = new System.Windows.Forms.Button();
            this.btnTab1_WorldVariables = new System.Windows.Forms.Button();
            this.btnTab9_SensorCalibration = new System.Windows.Forms.Button();

            this.pnlSubContentContainer = new System.Windows.Forms.Panel();
            this.pnlBottomStatusBar = new System.Windows.Forms.Panel();
            this.lblActiveTabStatus = new System.Windows.Forms.Label();
            this.btnApplyAndSave = new System.Windows.Forms.Button();
            this.pnlTopHeader.SuspendLayout();
            this.pnlSidebarMenu.SuspendLayout();
            this.pnlBottomStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.pnlTopHeader.Controls.Add(this.btnLoadDefaults);
            this.pnlTopHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(1200, 60);
            this.pnlTopHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(512, 32);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "AYARLAR VE SİMÜLASYON PARAMETRELERİ MERKEZİ";
            // 
            // btnLoadDefaults
            // 
            this.btnLoadDefaults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadDefaults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnLoadDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDefaults.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDefaults.ForeColor = System.Drawing.Color.White;
            this.btnLoadDefaults.Location = new System.Drawing.Point(970, 12);
            this.btnLoadDefaults.Name = "btnLoadDefaults";
            this.btnLoadDefaults.Size = new System.Drawing.Size(210, 36);
            this.btnLoadDefaults.TabIndex = 1;
            this.btnLoadDefaults.Text = "Aksaray Varsayılanları Yükle";
            this.btnLoadDefaults.UseVisualStyleBackColor = false;
            // 
            // pnlSidebarMenu
            // 
            this.pnlSidebarMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlSidebarMenu.Controls.Add(this.btnTab9_SensorCalibration);
            this.pnlSidebarMenu.Controls.Add(this.btnTab8_Contingency);

            this.pnlSidebarMenu.Controls.Add(this.btnTab7_Landing);
            this.pnlSidebarMenu.Controls.Add(this.btnTab6_ControlledDescent);
            this.pnlSidebarMenu.Controls.Add(this.btnTab5_BrakePhase);
            this.pnlSidebarMenu.Controls.Add(this.btnTab4_Separation);
            this.pnlSidebarMenu.Controls.Add(this.btnTab3_Ascent);
            this.pnlSidebarMenu.Controls.Add(this.btnTab2_SatellitePhysics);
            this.pnlSidebarMenu.Controls.Add(this.btnTab1_WorldVariables);
            this.pnlSidebarMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebarMenu.Location = new System.Drawing.Point(0, 60);
            this.pnlSidebarMenu.Name = "pnlSidebarMenu";
            this.pnlSidebarMenu.Size = new System.Drawing.Size(280, 690);
            this.pnlSidebarMenu.TabIndex = 1;
            // 
            // btnTab1_WorldVariables
            // 
            this.btnTab1_WorldVariables.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTab1_WorldVariables.FlatAppearance.BorderSize = 0;
            this.btnTab1_WorldVariables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab1_WorldVariables.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTab1_WorldVariables.ForeColor = System.Drawing.Color.White;
            this.btnTab1_WorldVariables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab1_WorldVariables.Location = new System.Drawing.Point(0, 0);
            this.btnTab1_WorldVariables.Name = "btnTab1_WorldVariables";
            this.btnTab1_WorldVariables.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTab1_WorldVariables.Size = new System.Drawing.Size(280, 55);
            this.btnTab1_WorldVariables.TabIndex = 0;
            this.btnTab1_WorldVariables.Text = "1. Dünya ve Çevre Değişkenleri";
            this.btnTab1_WorldVariables.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab1_WorldVariables.UseVisualStyleBackColor = true;
            // 
            // btnTab2_SatellitePhysics
            // 
            this.btnTab2_SatellitePhysics.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTab2_SatellitePhysics.FlatAppearance.BorderSize = 0;
            this.btnTab2_SatellitePhysics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab2_SatellitePhysics.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTab2_SatellitePhysics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTab2_SatellitePhysics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab2_SatellitePhysics.Location = new System.Drawing.Point(0, 55);
            this.btnTab2_SatellitePhysics.Name = "btnTab2_SatellitePhysics";
            this.btnTab2_SatellitePhysics.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTab2_SatellitePhysics.Size = new System.Drawing.Size(280, 55);
            this.btnTab2_SatellitePhysics.TabIndex = 1;
            this.btnTab2_SatellitePhysics.Text = "2. Uydunun Fiziksel Özellikleri";
            this.btnTab2_SatellitePhysics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab2_SatellitePhysics.UseVisualStyleBackColor = true;
            // 
            // btnTab3_Ascent
            // 
            this.btnTab3_Ascent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTab3_Ascent.FlatAppearance.BorderSize = 0;
            this.btnTab3_Ascent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab3_Ascent.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTab3_Ascent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTab3_Ascent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab3_Ascent.Location = new System.Drawing.Point(0, 110);
            this.btnTab3_Ascent.Name = "btnTab3_Ascent";
            this.btnTab3_Ascent.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTab3_Ascent.Size = new System.Drawing.Size(280, 55);
            this.btnTab3_Ascent.TabIndex = 2;
            this.btnTab3_Ascent.Text = "3. Faz 1: Roketle Yükseliş & Ayrılma";
            this.btnTab3_Ascent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab3_Ascent.UseVisualStyleBackColor = true;
            // 
            // btnTab4_Separation
            // 
            this.btnTab4_Separation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTab4_Separation.FlatAppearance.BorderSize = 0;
            this.btnTab4_Separation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab4_Separation.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTab4_Separation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTab4_Separation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab4_Separation.Location = new System.Drawing.Point(0, 165);
            this.btnTab4_Separation.Name = "btnTab4_Separation";
            this.btnTab4_Separation.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTab4_Separation.Size = new System.Drawing.Size(280, 55);
            this.btnTab4_Separation.TabIndex = 3;
            this.btnTab4_Separation.Text = "4. Faz 2: Paraşütlü Süzülüş & SİGMA";
            this.btnTab4_Separation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab4_Separation.UseVisualStyleBackColor = true;
            // 
            // btnTab5_BrakePhase
            // 
            this.btnTab5_BrakePhase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTab5_BrakePhase.FlatAppearance.BorderSize = 0;
            this.btnTab5_BrakePhase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab5_BrakePhase.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTab5_BrakePhase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTab5_BrakePhase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab5_BrakePhase.Location = new System.Drawing.Point(0, 220);
            this.btnTab5_BrakePhase.Name = "btnTab5_BrakePhase";
            this.btnTab5_BrakePhase.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTab5_BrakePhase.Size = new System.Drawing.Size(280, 55);
            this.btnTab5_BrakePhase.TabIndex = 4;
            this.btnTab5_BrakePhase.Text = "5. Faz 3: Ayrılma Hali (S3 Blokları)";
            this.btnTab5_BrakePhase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab5_BrakePhase.UseVisualStyleBackColor = true;
            // 
            // btnTab6_ControlledDescent
            // 
            this.btnTab6_ControlledDescent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTab6_ControlledDescent.FlatAppearance.BorderSize = 0;
            this.btnTab6_ControlledDescent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab6_ControlledDescent.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTab6_ControlledDescent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTab6_ControlledDescent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab6_ControlledDescent.Location = new System.Drawing.Point(0, 275);
            this.btnTab6_ControlledDescent.Name = "btnTab6_ControlledDescent";
            this.btnTab6_ControlledDescent.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTab6_ControlledDescent.Size = new System.Drawing.Size(280, 55);
            this.btnTab6_ControlledDescent.TabIndex = 5;
            this.btnTab6_ControlledDescent.Text = "6. Faz 4: Aktif İniş (4 Alt Faz & PID)";
            this.btnTab6_ControlledDescent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab6_ControlledDescent.UseVisualStyleBackColor = true;
            // 
            // btnTab7_Landing
            // 
            this.btnTab7_Landing.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTab7_Landing.FlatAppearance.BorderSize = 0;
            this.btnTab7_Landing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab7_Landing.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTab7_Landing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTab7_Landing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab7_Landing.Location = new System.Drawing.Point(0, 330);
            this.btnTab7_Landing.Name = "btnTab7_Landing";
            this.btnTab7_Landing.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTab7_Landing.Size = new System.Drawing.Size(280, 55);
            this.btnTab7_Landing.TabIndex = 6;
            this.btnTab7_Landing.Text = "7. APAM Acil Paraşüt & Koruma";
            this.btnTab7_Landing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab7_Landing.UseVisualStyleBackColor = true;
            // 
            // btnTab8_Contingency
            // 
            this.btnTab8_Contingency.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTab8_Contingency.FlatAppearance.BorderSize = 0;
            this.btnTab8_Contingency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab8_Contingency.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTab8_Contingency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTab8_Contingency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab8_Contingency.Location = new System.Drawing.Point(0, 385);
            this.btnTab8_Contingency.Name = "btnTab8_Contingency";
            this.btnTab8_Contingency.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTab8_Contingency.Size = new System.Drawing.Size(280, 55);
            this.btnTab8_Contingency.TabIndex = 7;
            this.btnTab8_Contingency.Text = "8. Faz 5: Yere İniş & Sertlik Kriterleri";

            this.btnTab8_Contingency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab8_Contingency.UseVisualStyleBackColor = true;
            // 
            // btnTab9_SensorCalibration
            // 
            this.btnTab9_SensorCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTab9_SensorCalibration.FlatAppearance.BorderSize = 0;
            this.btnTab9_SensorCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab9_SensorCalibration.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTab9_SensorCalibration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTab9_SensorCalibration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab9_SensorCalibration.Location = new System.Drawing.Point(0, 440);
            this.btnTab9_SensorCalibration.Name = "btnTab9_SensorCalibration";
            this.btnTab9_SensorCalibration.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnTab9_SensorCalibration.Size = new System.Drawing.Size(280, 55);
            this.btnTab9_SensorCalibration.TabIndex = 8;
            this.btnTab9_SensorCalibration.Text = "9. Sensör Hata & Kalibrasyon Modeli";
            this.btnTab9_SensorCalibration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTab9_SensorCalibration.UseVisualStyleBackColor = true;
            // 
            // pnlSubContentContainer

            // 
            this.pnlSubContentContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlSubContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubContentContainer.Location = new System.Drawing.Point(280, 60);
            this.pnlSubContentContainer.Name = "pnlSubContentContainer";
            this.pnlSubContentContainer.Size = new System.Drawing.Size(920, 640);
            this.pnlSubContentContainer.TabIndex = 2;
            // 
            // pnlBottomStatusBar
            // 
            this.pnlBottomStatusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlBottomStatusBar.Controls.Add(this.btnApplyAndSave);
            this.pnlBottomStatusBar.Controls.Add(this.lblActiveTabStatus);
            this.pnlBottomStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomStatusBar.Location = new System.Drawing.Point(280, 700);
            this.pnlBottomStatusBar.Name = "pnlBottomStatusBar";
            this.pnlBottomStatusBar.Size = new System.Drawing.Size(920, 50);
            this.pnlBottomStatusBar.TabIndex = 3;
            // 
            // lblActiveTabStatus
            // 
            this.lblActiveTabStatus.AutoSize = true;
            this.lblActiveTabStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveTabStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblActiveTabStatus.Location = new System.Drawing.Point(20, 15);
            this.lblActiveTabStatus.Name = "lblActiveTabStatus";
            this.lblActiveTabStatus.Size = new System.Drawing.Size(342, 21);
            this.lblActiveTabStatus.TabIndex = 0;
            this.lblActiveTabStatus.Text = "DURUM: 8 Ayar panelinden 1.si görüntüleniyor.";
            // 
            // btnApplyAndSave
            // 
            this.btnApplyAndSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyAndSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnApplyAndSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyAndSave.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyAndSave.ForeColor = System.Drawing.Color.White;
            this.btnApplyAndSave.Location = new System.Drawing.Point(730, 8);
            this.btnApplyAndSave.Name = "btnApplyAndSave";
            this.btnApplyAndSave.Size = new System.Drawing.Size(170, 34);
            this.btnApplyAndSave.TabIndex = 1;
            this.btnApplyAndSave.Text = "KAYDET VE UYGULA";
            this.btnApplyAndSave.UseVisualStyleBackColor = false;
            // 
            // SimulationConfigDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSubContentContainer);
            this.Controls.Add(this.pnlBottomStatusBar);
            this.Controls.Add(this.pnlSidebarMenu);
            this.Controls.Add(this.pnlTopHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SimulationConfigDashboard";
            this.Size = new System.Drawing.Size(1200, 750);
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlSidebarMenu.ResumeLayout(false);
            this.pnlBottomStatusBar.ResumeLayout(false);
            this.pnlBottomStatusBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Button btnLoadDefaults;
        private System.Windows.Forms.Panel pnlSidebarMenu;
        private System.Windows.Forms.Button btnTab1_WorldVariables;
        private System.Windows.Forms.Button btnTab2_SatellitePhysics;
        private System.Windows.Forms.Button btnTab3_Ascent;
        private System.Windows.Forms.Button btnTab4_Separation;
        private System.Windows.Forms.Button btnTab5_BrakePhase;
        private System.Windows.Forms.Button btnTab6_ControlledDescent;
        private System.Windows.Forms.Button btnTab7_Landing;
        private System.Windows.Forms.Button btnTab8_Contingency;
        private System.Windows.Forms.Button btnTab9_SensorCalibration;
        private System.Windows.Forms.Panel pnlSubContentContainer;

        private System.Windows.Forms.Panel pnlBottomStatusBar;
        private System.Windows.Forms.Label lblActiveTabStatus;
        private System.Windows.Forms.Button btnApplyAndSave;
    }
}
