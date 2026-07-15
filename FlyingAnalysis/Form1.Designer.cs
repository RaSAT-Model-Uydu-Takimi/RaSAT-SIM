namespace FlyingAnalysis
{
    partial class Form1
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlMainTopNav = new System.Windows.Forms.Panel();
            this.btnNavAnalysis = new System.Windows.Forms.Button();
            this.btnNavSimulation = new System.Windows.Forms.Button();
            this.btnNavSettings = new System.Windows.Forms.Button();
            this.lblAppBrand = new System.Windows.Forms.Label();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlMainTopNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainTopNav
            // 
            this.pnlMainTopNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlMainTopNav.Controls.Add(this.btnNavAnalysis);
            this.pnlMainTopNav.Controls.Add(this.btnNavSimulation);
            this.pnlMainTopNav.Controls.Add(this.btnNavSettings);
            this.pnlMainTopNav.Controls.Add(this.lblAppBrand);
            this.pnlMainTopNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTopNav.Location = new System.Drawing.Point(0, 0);
            this.pnlMainTopNav.Name = "pnlMainTopNav";
            this.pnlMainTopNav.Size = new System.Drawing.Size(1400, 55);
            this.pnlMainTopNav.TabIndex = 0;
            // 
            // lblAppBrand
            // 
            this.lblAppBrand.AutoSize = true;
            this.lblAppBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblAppBrand.Location = new System.Drawing.Point(20, 12);
            this.lblAppBrand.Name = "lblAppBrand";
            this.lblAppBrand.Size = new System.Drawing.Size(395, 31);
            this.lblAppBrand.TabIndex = 0;
            this.lblAppBrand.Text = "RaSAT SIM — FLYING ANALYSIS SUITE";
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnNavSettings.FlatAppearance.BorderSize = 0;
            this.btnNavSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavSettings.ForeColor = System.Drawing.Color.White;
            this.btnNavSettings.Location = new System.Drawing.Point(450, 8);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Size = new System.Drawing.Size(260, 40);
            this.btnNavSettings.TabIndex = 1;
            this.btnNavSettings.Text = "PARAMETRE VE AYARLAR MERKEZİ";
            this.btnNavSettings.UseVisualStyleBackColor = false;
            // 
            // btnNavSimulation
            // 
            this.btnNavSimulation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnNavSimulation.FlatAppearance.BorderSize = 0;
            this.btnNavSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSimulation.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavSimulation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavSimulation.Location = new System.Drawing.Point(720, 8);
            this.btnNavSimulation.Name = "btnNavSimulation";
            this.btnNavSimulation.Size = new System.Drawing.Size(260, 40);
            this.btnNavSimulation.TabIndex = 2;
            this.btnNavSimulation.Text = "SİMÜLASYON VE UÇUŞ EKRANI";
            this.btnNavSimulation.UseVisualStyleBackColor = false;
            // 
            // btnNavAnalysis
            // 
            this.btnNavAnalysis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnNavAnalysis.FlatAppearance.BorderSize = 0;
            this.btnNavAnalysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAnalysis.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavAnalysis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnNavAnalysis.Location = new System.Drawing.Point(990, 8);
            this.btnNavAnalysis.Name = "btnNavAnalysis";
            this.btnNavAnalysis.Size = new System.Drawing.Size(260, 40);
            this.btnNavAnalysis.TabIndex = 3;
            this.btnNavAnalysis.Text = "SENSÖR VE VERİ ANALİZİ";
            this.btnNavAnalysis.UseVisualStyleBackColor = false;
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 55);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(1400, 795);
            this.pnlMainContainer.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 850);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.pnlMainTopNav);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlyingAnalysis — RaSAT SIM Model Uydu Simülasyon ve Analiz Platformu";
            this.pnlMainTopNav.ResumeLayout(false);
            this.pnlMainTopNav.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMainTopNav;
        private System.Windows.Forms.Label lblAppBrand;
        private System.Windows.Forms.Button btnNavSettings;
        private System.Windows.Forms.Button btnNavSimulation;
        private System.Windows.Forms.Button btnNavAnalysis;
        private System.Windows.Forms.Panel pnlMainContainer;
    }
}
