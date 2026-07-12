namespace Veri_Analizi
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
            this.pnlUst = new System.Windows.Forms.Panel();
            this.btnDosyaSec = new System.Windows.Forms.Button();
            this.lblDosyaBilgi = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.cmbXEkseni = new System.Windows.Forms.ComboBox();
            this.btnCiz = new System.Windows.Forms.Button();
            this.btnTumu = new System.Windows.Forms.Button();
            this.splitAna = new System.Windows.Forms.SplitContainer();
            this.grpOzellikler = new System.Windows.Forms.GroupBox();
            this.clbOzellikler = new System.Windows.Forms.CheckedListBox();
            this.tabAna = new System.Windows.Forms.TabControl();
            this.tabGrafik = new System.Windows.Forms.TabPage();
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.tabTablo = new System.Windows.Forms.TabPage();
            this.dgvVeriler = new System.Windows.Forms.DataGridView();
            this.pnlUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitAna)).BeginInit();
            this.splitAna.Panel1.SuspendLayout();
            this.splitAna.Panel2.SuspendLayout();
            this.splitAna.SuspendLayout();
            this.grpOzellikler.SuspendLayout();
            this.tabAna.SuspendLayout();
            this.tabGrafik.SuspendLayout();
            this.tabTablo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriler)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUst
            // 
            this.pnlUst.Controls.Add(this.btnDosyaSec);
            this.pnlUst.Controls.Add(this.lblDosyaBilgi);
            this.pnlUst.Controls.Add(this.lblX);
            this.pnlUst.Controls.Add(this.cmbXEkseni);
            this.pnlUst.Controls.Add(this.btnCiz);
            this.pnlUst.Controls.Add(this.btnTumu);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(1050, 65);
            this.pnlUst.TabIndex = 0;
            // 
            // btnDosyaSec
            // 
            this.btnDosyaSec.Location = new System.Drawing.Point(12, 16);
            this.btnDosyaSec.Name = "btnDosyaSec";
            this.btnDosyaSec.Size = new System.Drawing.Size(160, 32);
            this.btnDosyaSec.TabIndex = 0;
            this.btnDosyaSec.Text = "📁 CSV Kayıt Dosyası Seç...";
            this.btnDosyaSec.UseVisualStyleBackColor = true;
            this.btnDosyaSec.Click += new System.EventHandler(this.btnDosyaSec_Click);
            // 
            // lblDosyaBilgi
            // 
            this.lblDosyaBilgi.AutoSize = true;
            this.lblDosyaBilgi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDosyaBilgi.Location = new System.Drawing.Point(185, 25);
            this.lblDosyaBilgi.Name = "lblDosyaBilgi";
            this.lblDosyaBilgi.Size = new System.Drawing.Size(215, 15);
            this.lblDosyaBilgi.TabIndex = 1;
            this.lblDosyaBilgi.Text = "Seçilen Dosya: Henüz dosya yüklenmedi.";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(440, 25);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(54, 15);
            this.lblX.TabIndex = 2;
            this.lblX.Text = "X Ekseni:";
            // 
            // cmbXEkseni
            // 
            this.cmbXEkseni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXEkseni.FormattingEnabled = true;
            this.cmbXEkseni.Location = new System.Drawing.Point(500, 21);
            this.cmbXEkseni.Name = "cmbXEkseni";
            this.cmbXEkseni.Size = new System.Drawing.Size(160, 23);
            this.cmbXEkseni.TabIndex = 3;
            this.cmbXEkseni.SelectedIndexChanged += new System.EventHandler(this.cmbXEkseni_SelectedIndexChanged);
            // 
            // btnCiz
            // 
            this.btnCiz.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCiz.Location = new System.Drawing.Point(675, 16);
            this.btnCiz.Name = "btnCiz";
            this.btnCiz.Size = new System.Drawing.Size(180, 32);
            this.btnCiz.TabIndex = 4;
            this.btnCiz.Text = "📈 Seçilen Özellikleri Çiz";
            this.btnCiz.UseVisualStyleBackColor = true;
            this.btnCiz.Click += new System.EventHandler(this.btnCiz_Click);
            // 
            // btnTumu
            // 
            this.btnTumu.Location = new System.Drawing.Point(865, 16);
            this.btnTumu.Name = "btnTumu";
            this.btnTumu.Size = new System.Drawing.Size(165, 32);
            this.btnTumu.TabIndex = 5;
            this.btnTumu.Text = "☑️ Tümünü Seç / Temizle";
            this.btnTumu.UseVisualStyleBackColor = true;
            this.btnTumu.Click += new System.EventHandler(this.btnTumu_Click);
            // 
            // splitAna
            // 
            this.splitAna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitAna.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitAna.Location = new System.Drawing.Point(0, 65);
            this.splitAna.Name = "splitAna";
            // 
            // splitAna.Panel1
            // 
            this.splitAna.Panel1.Controls.Add(this.grpOzellikler);
            this.splitAna.Panel1.Padding = new System.Windows.Forms.Padding(8);
            // 
            // splitAna.Panel2
            // 
            this.splitAna.Panel2.Controls.Add(this.tabAna);
            this.splitAna.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splitAna.Size = new System.Drawing.Size(1050, 535);
            this.splitAna.SplitterDistance = 270;
            this.splitAna.TabIndex = 1;
            // 
            // grpOzellikler
            // 
            this.grpOzellikler.Controls.Add(this.clbOzellikler);
            this.grpOzellikler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOzellikler.Location = new System.Drawing.Point(8, 8);
            this.grpOzellikler.Name = "grpOzellikler";
            this.grpOzellikler.Size = new System.Drawing.Size(254, 519);
            this.grpOzellikler.TabIndex = 0;
            this.grpOzellikler.TabStop = false;
            this.grpOzellikler.Text = "Çizilecek Özellikler (Y Ekseni)";
            // 
            // clbOzellikler
            // 
            this.clbOzellikler.CheckOnClick = true;
            this.clbOzellikler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbOzellikler.FormattingEnabled = true;
            this.clbOzellikler.Location = new System.Drawing.Point(3, 19);
            this.clbOzellikler.Name = "clbOzellikler";
            this.clbOzellikler.Size = new System.Drawing.Size(248, 497);
            this.clbOzellikler.TabIndex = 0;
            this.clbOzellikler.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbOzellikler_ItemCheck);
            // 
            // tabAna
            // 
            this.tabAna.Controls.Add(this.tabGrafik);
            this.tabAna.Controls.Add(this.tabTablo);
            this.tabAna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAna.Location = new System.Drawing.Point(8, 8);
            this.tabAna.Name = "tabAna";
            this.tabAna.SelectedIndex = 0;
            this.tabAna.Size = new System.Drawing.Size(760, 519);
            this.tabAna.TabIndex = 0;
            // 
            // tabGrafik
            // 
            this.tabGrafik.Controls.Add(this.formsPlot1);
            this.tabGrafik.Location = new System.Drawing.Point(4, 24);
            this.tabGrafik.Name = "tabGrafik";
            this.tabGrafik.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrafik.Size = new System.Drawing.Size(752, 491);
            this.tabGrafik.TabIndex = 0;
            this.tabGrafik.Text = "📈 Grafik Görünümü (ScottPlot)";
            this.tabGrafik.UseVisualStyleBackColor = true;
            // 
            // formsPlot1
            // 
            this.formsPlot1.DisplayScale = 1F;
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(3, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(746, 485);
            this.formsPlot1.TabIndex = 0;
            // 
            // tabTablo
            // 
            this.tabTablo.Controls.Add(this.dgvVeriler);
            this.tabTablo.Location = new System.Drawing.Point(4, 24);
            this.tabTablo.Name = "tabTablo";
            this.tabTablo.Padding = new System.Windows.Forms.Padding(3);
            this.tabTablo.Size = new System.Drawing.Size(752, 491);
            this.tabTablo.TabIndex = 1;
            this.tabTablo.Text = "📋 Tablo Görünümü (Tüm CSV Verileri)";
            this.tabTablo.UseVisualStyleBackColor = true;
            // 
            // dgvVeriler
            // 
            this.dgvVeriler.AllowUserToAddRows = false;
            this.dgvVeriler.AllowUserToDeleteRows = false;
            this.dgvVeriler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVeriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVeriler.Location = new System.Drawing.Point(3, 3);
            this.dgvVeriler.Name = "dgvVeriler";
            this.dgvVeriler.ReadOnly = true;
            this.dgvVeriler.RowHeadersWidth = 30;
            this.dgvVeriler.Size = new System.Drawing.Size(746, 485);
            this.dgvVeriler.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.splitAna);
            this.Controls.Add(this.pnlUst);
            this.MinimumSize = new System.Drawing.Size(850, 450);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaSAT Veri Analiz ve ScottPlot Grafik Takip Sistemi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlUst.ResumeLayout(false);
            this.pnlUst.PerformLayout();
            this.splitAna.Panel1.ResumeLayout(false);
            this.splitAna.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitAna)).EndInit();
            this.splitAna.ResumeLayout(false);
            this.grpOzellikler.ResumeLayout(false);
            this.tabAna.ResumeLayout(false);
            this.tabGrafik.ResumeLayout(false);
            this.tabTablo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUst;
        private System.Windows.Forms.Button btnDosyaSec;
        private System.Windows.Forms.Label lblDosyaBilgi;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.ComboBox cmbXEkseni;
        private System.Windows.Forms.Button btnCiz;
        private System.Windows.Forms.Button btnTumu;
        private System.Windows.Forms.SplitContainer splitAna;
        private System.Windows.Forms.GroupBox grpOzellikler;
        private System.Windows.Forms.CheckedListBox clbOzellikler;
        private System.Windows.Forms.TabControl tabAna;
        private System.Windows.Forms.TabPage tabGrafik;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private System.Windows.Forms.TabPage tabTablo;
        private System.Windows.Forms.DataGridView dgvVeriler;
    }
}
