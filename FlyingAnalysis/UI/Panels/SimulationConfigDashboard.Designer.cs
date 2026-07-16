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
            pnlTopHeader = new Panel();
            lblHeaderTitle = new Label();
            pnlSidebarMenu = new Panel();
            btnTab8_Contingency = new Button();
            btnTab7_Landing = new Button();
            btnTab6_ControlledDescent = new Button();
            btnTab5_BrakePhase = new Button();
            btnTab4_Separation = new Button();
            btnTab3_Ascent = new Button();
            btnTab2_SatellitePhysics = new Button();
            btnTab1_WorldVariables = new Button();
            pnlSubContentContainer = new Panel();
            pnlBottomStatusBar = new Panel();
            lblActiveTabStatus = new Label();
            pnlTopHeader.SuspendLayout();
            pnlSidebarMenu.SuspendLayout();
            pnlBottomStatusBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTopHeader
            // 
            pnlTopHeader.BackColor = Color.FromArgb(24, 34, 48);
            pnlTopHeader.Controls.Add(lblHeaderTitle);
            pnlTopHeader.Dock = DockStyle.Top;
            pnlTopHeader.Location = new Point(0, 0);
            pnlTopHeader.Name = "pnlTopHeader";
            pnlTopHeader.Size = new Size(1200, 60);
            pnlTopHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 15);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(700, 38);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "AYARLAR VE SİMÜLASYON PARAMETRELERİ MERKEZİ";
            // 
            // pnlSidebarMenu
            // 
            pnlSidebarMenu.BackColor = Color.FromArgb(30, 41, 59);
            pnlSidebarMenu.Controls.Add(btnTab8_Contingency);
            pnlSidebarMenu.Controls.Add(btnTab7_Landing);
            pnlSidebarMenu.Controls.Add(btnTab6_ControlledDescent);
            pnlSidebarMenu.Controls.Add(btnTab5_BrakePhase);
            pnlSidebarMenu.Controls.Add(btnTab4_Separation);
            pnlSidebarMenu.Controls.Add(btnTab3_Ascent);
            pnlSidebarMenu.Controls.Add(btnTab2_SatellitePhysics);
            pnlSidebarMenu.Controls.Add(btnTab1_WorldVariables);
            pnlSidebarMenu.Dock = DockStyle.Left;
            pnlSidebarMenu.Location = new Point(0, 60);
            pnlSidebarMenu.Name = "pnlSidebarMenu";
            pnlSidebarMenu.Size = new Size(280, 690);
            pnlSidebarMenu.TabIndex = 1;
            // 
            // btnTab8_Contingency
            // 
            btnTab8_Contingency.Dock = DockStyle.Top;
            btnTab8_Contingency.FlatAppearance.BorderSize = 0;
            btnTab8_Contingency.FlatStyle = FlatStyle.Flat;
            btnTab8_Contingency.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTab8_Contingency.ForeColor = Color.FromArgb(203, 213, 225);
            btnTab8_Contingency.ImageAlign = ContentAlignment.MiddleLeft;
            btnTab8_Contingency.Location = new Point(0, 385);
            btnTab8_Contingency.Name = "btnTab8_Contingency";
            btnTab8_Contingency.Padding = new Padding(15, 0, 0, 0);
            btnTab8_Contingency.Size = new Size(280, 55);
            btnTab8_Contingency.TabIndex = 7;
            btnTab8_Contingency.Text = "8. Faz 5: Yere İniş & Sertlik Kriterleri";
            btnTab8_Contingency.TextAlign = ContentAlignment.MiddleLeft;
            btnTab8_Contingency.UseVisualStyleBackColor = true;
            // 
            // btnTab7_Landing
            // 
            btnTab7_Landing.Dock = DockStyle.Top;
            btnTab7_Landing.FlatAppearance.BorderSize = 0;
            btnTab7_Landing.FlatStyle = FlatStyle.Flat;
            btnTab7_Landing.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTab7_Landing.ForeColor = Color.FromArgb(203, 213, 225);
            btnTab7_Landing.ImageAlign = ContentAlignment.MiddleLeft;
            btnTab7_Landing.Location = new Point(0, 330);
            btnTab7_Landing.Name = "btnTab7_Landing";
            btnTab7_Landing.Padding = new Padding(15, 0, 0, 0);
            btnTab7_Landing.Size = new Size(280, 55);
            btnTab7_Landing.TabIndex = 6;
            btnTab7_Landing.Text = "7. APAM Acil Paraşüt & Koruma";
            btnTab7_Landing.TextAlign = ContentAlignment.MiddleLeft;
            btnTab7_Landing.UseVisualStyleBackColor = true;
            // 
            // btnTab6_ControlledDescent
            // 
            btnTab6_ControlledDescent.Dock = DockStyle.Top;
            btnTab6_ControlledDescent.FlatAppearance.BorderSize = 0;
            btnTab6_ControlledDescent.FlatStyle = FlatStyle.Flat;
            btnTab6_ControlledDescent.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTab6_ControlledDescent.ForeColor = Color.FromArgb(203, 213, 225);
            btnTab6_ControlledDescent.ImageAlign = ContentAlignment.MiddleLeft;
            btnTab6_ControlledDescent.Location = new Point(0, 275);
            btnTab6_ControlledDescent.Name = "btnTab6_ControlledDescent";
            btnTab6_ControlledDescent.Padding = new Padding(15, 0, 0, 0);
            btnTab6_ControlledDescent.Size = new Size(280, 55);
            btnTab6_ControlledDescent.TabIndex = 5;
            btnTab6_ControlledDescent.Text = "6. Faz 4: Aktif İniş (4 Alt Faz & PID)";
            btnTab6_ControlledDescent.TextAlign = ContentAlignment.MiddleLeft;
            btnTab6_ControlledDescent.UseVisualStyleBackColor = true;
            // 
            // btnTab5_BrakePhase
            // 
            btnTab5_BrakePhase.Dock = DockStyle.Top;
            btnTab5_BrakePhase.FlatAppearance.BorderSize = 0;
            btnTab5_BrakePhase.FlatStyle = FlatStyle.Flat;
            btnTab5_BrakePhase.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTab5_BrakePhase.ForeColor = Color.FromArgb(203, 213, 225);
            btnTab5_BrakePhase.ImageAlign = ContentAlignment.MiddleLeft;
            btnTab5_BrakePhase.Location = new Point(0, 220);
            btnTab5_BrakePhase.Name = "btnTab5_BrakePhase";
            btnTab5_BrakePhase.Padding = new Padding(15, 0, 0, 0);
            btnTab5_BrakePhase.Size = new Size(280, 55);
            btnTab5_BrakePhase.TabIndex = 4;
            btnTab5_BrakePhase.Text = "5. Faz 3: Ayrılma Hali (S3 Blokları)";
            btnTab5_BrakePhase.TextAlign = ContentAlignment.MiddleLeft;
            btnTab5_BrakePhase.UseVisualStyleBackColor = true;
            // 
            // btnTab4_Separation
            // 
            btnTab4_Separation.Dock = DockStyle.Top;
            btnTab4_Separation.FlatAppearance.BorderSize = 0;
            btnTab4_Separation.FlatStyle = FlatStyle.Flat;
            btnTab4_Separation.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTab4_Separation.ForeColor = Color.FromArgb(203, 213, 225);
            btnTab4_Separation.ImageAlign = ContentAlignment.MiddleLeft;
            btnTab4_Separation.Location = new Point(0, 165);
            btnTab4_Separation.Name = "btnTab4_Separation";
            btnTab4_Separation.Padding = new Padding(15, 0, 0, 0);
            btnTab4_Separation.Size = new Size(280, 55);
            btnTab4_Separation.TabIndex = 3;
            btnTab4_Separation.Text = "4. Faz 2: Paraşütlü Süzülüş & SİGMA";
            btnTab4_Separation.TextAlign = ContentAlignment.MiddleLeft;
            btnTab4_Separation.UseVisualStyleBackColor = true;
            // 
            // btnTab3_Ascent
            // 
            btnTab3_Ascent.Dock = DockStyle.Top;
            btnTab3_Ascent.FlatAppearance.BorderSize = 0;
            btnTab3_Ascent.FlatStyle = FlatStyle.Flat;
            btnTab3_Ascent.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTab3_Ascent.ForeColor = Color.FromArgb(203, 213, 225);
            btnTab3_Ascent.ImageAlign = ContentAlignment.MiddleLeft;
            btnTab3_Ascent.Location = new Point(0, 110);
            btnTab3_Ascent.Name = "btnTab3_Ascent";
            btnTab3_Ascent.Padding = new Padding(15, 0, 0, 0);
            btnTab3_Ascent.Size = new Size(280, 55);
            btnTab3_Ascent.TabIndex = 2;
            btnTab3_Ascent.Text = "3. Faz 1: Roketle Yükseliş & Ayrılma";
            btnTab3_Ascent.TextAlign = ContentAlignment.MiddleLeft;
            btnTab3_Ascent.UseVisualStyleBackColor = true;
            // 
            // btnTab2_SatellitePhysics
            // 
            btnTab2_SatellitePhysics.Dock = DockStyle.Top;
            btnTab2_SatellitePhysics.FlatAppearance.BorderSize = 0;
            btnTab2_SatellitePhysics.FlatStyle = FlatStyle.Flat;
            btnTab2_SatellitePhysics.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTab2_SatellitePhysics.ForeColor = Color.FromArgb(203, 213, 225);
            btnTab2_SatellitePhysics.ImageAlign = ContentAlignment.MiddleLeft;
            btnTab2_SatellitePhysics.Location = new Point(0, 55);
            btnTab2_SatellitePhysics.Name = "btnTab2_SatellitePhysics";
            btnTab2_SatellitePhysics.Padding = new Padding(15, 0, 0, 0);
            btnTab2_SatellitePhysics.Size = new Size(280, 55);
            btnTab2_SatellitePhysics.TabIndex = 1;
            btnTab2_SatellitePhysics.Text = "2. Uydunun Fiziksel Özellikleri";
            btnTab2_SatellitePhysics.TextAlign = ContentAlignment.MiddleLeft;
            btnTab2_SatellitePhysics.UseVisualStyleBackColor = true;
            // 
            // btnTab1_WorldVariables
            // 
            btnTab1_WorldVariables.Dock = DockStyle.Top;
            btnTab1_WorldVariables.FlatAppearance.BorderSize = 0;
            btnTab1_WorldVariables.FlatStyle = FlatStyle.Flat;
            btnTab1_WorldVariables.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTab1_WorldVariables.ForeColor = Color.White;
            btnTab1_WorldVariables.ImageAlign = ContentAlignment.MiddleLeft;
            btnTab1_WorldVariables.Location = new Point(0, 0);
            btnTab1_WorldVariables.Name = "btnTab1_WorldVariables";
            btnTab1_WorldVariables.Padding = new Padding(15, 0, 0, 0);
            btnTab1_WorldVariables.Size = new Size(280, 55);
            btnTab1_WorldVariables.TabIndex = 0;
            btnTab1_WorldVariables.Text = "1. Dünya ve Çevre Değişkenleri";
            btnTab1_WorldVariables.TextAlign = ContentAlignment.MiddleLeft;
            btnTab1_WorldVariables.UseVisualStyleBackColor = true;
            // 
            // pnlSubContentContainer
            // 
            pnlSubContentContainer.BackColor = Color.FromArgb(241, 245, 249);
            pnlSubContentContainer.Dock = DockStyle.Fill;
            pnlSubContentContainer.Location = new Point(280, 60);
            pnlSubContentContainer.Name = "pnlSubContentContainer";
            pnlSubContentContainer.Size = new Size(920, 640);
            pnlSubContentContainer.TabIndex = 2;
            // 
            // pnlBottomStatusBar
            // 
            pnlBottomStatusBar.BackColor = Color.FromArgb(226, 232, 240);
            pnlBottomStatusBar.Controls.Add(lblActiveTabStatus);
            pnlBottomStatusBar.Dock = DockStyle.Bottom;
            pnlBottomStatusBar.Location = new Point(280, 700);
            pnlBottomStatusBar.Name = "pnlBottomStatusBar";
            pnlBottomStatusBar.Size = new Size(920, 50);
            pnlBottomStatusBar.TabIndex = 3;
            // 
            // lblActiveTabStatus
            // 
            lblActiveTabStatus.AutoSize = true;
            lblActiveTabStatus.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblActiveTabStatus.ForeColor = Color.FromArgb(51, 65, 85);
            lblActiveTabStatus.Location = new Point(20, 15);
            lblActiveTabStatus.Name = "lblActiveTabStatus";
            lblActiveTabStatus.Size = new Size(408, 25);
            lblActiveTabStatus.TabIndex = 0;
            lblActiveTabStatus.Text = "DURUM: 8 Ayar panelinden 1.si görüntüleniyor.";
            // 
            // SimulationConfigDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlSubContentContainer);
            Controls.Add(pnlBottomStatusBar);
            Controls.Add(pnlSidebarMenu);
            Controls.Add(pnlTopHeader);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "SimulationConfigDashboard";
            Size = new Size(1200, 750);
            pnlTopHeader.ResumeLayout(false);
            pnlTopHeader.PerformLayout();
            pnlSidebarMenu.ResumeLayout(false);
            pnlBottomStatusBar.ResumeLayout(false);
            pnlBottomStatusBar.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlSidebarMenu;
        private System.Windows.Forms.Button btnTab1_WorldVariables;
        private System.Windows.Forms.Button btnTab2_SatellitePhysics;
        private System.Windows.Forms.Button btnTab3_Ascent;
        private System.Windows.Forms.Button btnTab4_Separation;
        private System.Windows.Forms.Button btnTab5_BrakePhase;
        private System.Windows.Forms.Button btnTab6_ControlledDescent;
        private System.Windows.Forms.Button btnTab7_Landing;
        private System.Windows.Forms.Button btnTab8_Contingency;
        private System.Windows.Forms.Panel pnlSubContentContainer;

        private System.Windows.Forms.Panel pnlBottomStatusBar;
        private System.Windows.Forms.Label lblActiveTabStatus;
    }
}
