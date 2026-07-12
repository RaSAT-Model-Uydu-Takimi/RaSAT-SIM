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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlUst = new System.Windows.Forms.Panel();
            this.btnDosyaSec = new System.Windows.Forms.Button();
            this.lblDosyaBilgi = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.cmbXEkseni = new System.Windows.Forms.ComboBox();
            this.btnCiz = new System.Windows.Forms.Button();
            this.btnTumu = new System.Windows.Forms.Button();
            this.btnPngKaydet = new System.Windows.Forms.Button();
            this.pnlAltStat = new System.Windows.Forms.Panel();
            this.lblIstatistik = new System.Windows.Forms.Label();
            this.splitAna = new System.Windows.Forms.SplitContainer();
            this.grpOzellikler = new System.Windows.Forms.GroupBox();
            this.clbOzellikler = new System.Windows.Forms.CheckedListBox();
            this.tabAna = new System.Windows.Forms.TabControl();
            this.tabGrafik = new System.Windows.Forms.TabPage();
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.tabTablo = new System.Windows.Forms.TabPage();
            this.dgvVeriler = new System.Windows.Forms.DataGridView();
            this.pnlUst.SuspendLayout();
            this.pnlAltStat.SuspendLayout();
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
            this.pnlUst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.pnlUst.Controls.Add(this.btnDosyaSec);
            this.pnlUst.Controls.Add(this.lblDosyaBilgi);
            this.pnlUst.Controls.Add(this.lblX);
            this.pnlUst.Controls.Add(this.cmbXEkseni);
            this.pnlUst.Controls.Add(this.btnCiz);
            this.pnlUst.Controls.Add(this.btnTumu);
            this.pnlUst.Controls.Add(this.btnPngKaydet);
            this.pnlUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUst.Location = new System.Drawing.Point(0, 0);
            this.pnlUst.Name = "pnlUst";
            this.pnlUst.Size = new System.Drawing.Size(1120, 68);
            this.pnlUst.TabIndex = 0;
            // 
            // btnDosyaSec
            // 
            this.btnDosyaSec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            this.btnDosyaSec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDosyaSec.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDosyaSec.ForeColor = System.Drawing.Color.White;
            this.btnDosyaSec.Location = new System.Drawing.Point(14, 16);
            this.btnDosyaSec.Name = "btnDosyaSec";
            this.btnDosyaSec.Size = new System.Drawing.Size(175, 36);
            this.btnDosyaSec.TabIndex = 0;
            this.btnDosyaSec.Text = "📁 CSV Dosyası Seç...";
            this.btnDosyaSec.UseVisualStyleBackColor = false;
            this.btnDosyaSec.Click += new System.EventHandler(this.btnDosyaSec_Click);
            // 
            // lblDosyaBilgi
            // 
            this.lblDosyaBilgi.AutoSize = true;
            this.lblDosyaBilgi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDosyaBilgi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblDosyaBilgi.Location = new System.Drawing.Point(200, 26);
            this.lblDosyaBilgi.Name = "lblDosyaBilgi";
            this.lblDosyaBilgi.Size = new System.Drawing.Size(225, 17);
            this.lblDosyaBilgi.TabIndex = 1;
            this.lblDosyaBilgi.Text = "Seçilen Dosya: Henüz yüklenmedi.";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.lblX.Location = new System.Drawing.Point(450, 26);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(61, 17);
            this.lblX.TabIndex = 2;
            this.lblX.Text = "X Ekseni:";
            // 
            // cmbXEkseni
            // 
            this.cmbXEkseni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.cmbXEkseni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXEkseni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbXEkseni.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbXEkseni.ForeColor = System.Drawing.Color.White;
            this.cmbXEkseni.FormattingEnabled = true;
            this.cmbXEkseni.Location = new System.Drawing.Point(515, 22);
            this.cmbXEkseni.Name = "cmbXEkseni";
            this.cmbXEkseni.Size = new System.Drawing.Size(155, 25);
            this.cmbXEkseni.TabIndex = 3;
            this.cmbXEkseni.SelectedIndexChanged += new System.EventHandler(this.cmbXEkseni_SelectedIndexChanged);
            // 
            // btnCiz
            // 
            this.btnCiz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCiz.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCiz.ForeColor = System.Drawing.Color.White;
            this.btnCiz.Location = new System.Drawing.Point(680, 16);
            this.btnCiz.Name = "btnCiz";
            this.btnCiz.Size = new System.Drawing.Size(155, 36);
            this.btnCiz.TabIndex = 4;
            this.btnCiz.Text = "📈 Grafiği Yenile";
            this.btnCiz.UseVisualStyleBackColor = false;
            this.btnCiz.Click += new System.EventHandler(this.btnCiz_Click);
            // 
            // btnTumu
            // 
            this.btnTumu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(95)))));
            this.btnTumu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTumu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTumu.ForeColor = System.Drawing.Color.White;
            this.btnTumu.Location = new System.Drawing.Point(843, 16);
            this.btnTumu.Name = "btnTumu";
            this.btnTumu.Size = new System.Drawing.Size(130, 36);
            this.btnTumu.TabIndex = 5;
            this.btnTumu.Text = "☑️ Tümünü Seç";
            this.btnTumu.UseVisualStyleBackColor = false;
            this.btnTumu.Click += new System.EventHandler(this.btnTumu_Click);
            // 
            // btnPngKaydet
            // 
            this.btnPngKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(92)))), ((int)(((byte)(231)))));
            this.btnPngKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPngKaydet.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPngKaydet.ForeColor = System.Drawing.Color.White;
            this.btnPngKaydet.Location = new System.Drawing.Point(980, 16);
            this.btnPngKaydet.Name = "btnPngKaydet";
            this.btnPngKaydet.Size = new System.Drawing.Size(125, 36);
            this.btnPngKaydet.TabIndex = 6;
            this.btnPngKaydet.Text = "💾 PNG Kaydet";
            this.btnPngKaydet.UseVisualStyleBackColor = false;
            this.btnPngKaydet.Click += new System.EventHandler(this.btnPngKaydet_Click);
            // 
            // pnlAltStat
            // 
            this.pnlAltStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.pnlAltStat.Controls.Add(this.lblIstatistik);
            this.pnlAltStat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAltStat.Location = new System.Drawing.Point(0, 580);
            this.pnlAltStat.Name = "pnlAltStat";
            this.pnlAltStat.Size = new System.Drawing.Size(1120, 32);
            this.pnlAltStat.TabIndex = 2;
            // 
            // lblIstatistik
            // 
            this.lblIstatistik.AutoSize = true;
            this.lblIstatistik.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIstatistik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.lblIstatistik.Location = new System.Drawing.Point(12, 8);
            this.lblIstatistik.Name = "lblIstatistik";
            this.lblIstatistik.Size = new System.Drawing.Size(345, 15);
            this.lblIstatistik.TabIndex = 0;
            this.lblIstatistik.Text = "📊 İstatistik Özet: Bir özellik seçildiğinde istatistikler gösterilir.";
            // 
            // splitAna
            // 
            this.splitAna.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.splitAna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitAna.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitAna.Location = new System.Drawing.Point(0, 68);
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
            this.splitAna.Size = new System.Drawing.Size(1120, 512);
            this.splitAna.SplitterDistance = 275;
            this.splitAna.TabIndex = 1;
            // 
            // grpOzellikler
            // 
            this.grpOzellikler.Controls.Add(this.clbOzellikler);
            this.grpOzellikler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOzellikler.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpOzellikler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.grpOzellikler.Location = new System.Drawing.Point(8, 8);
            this.grpOzellikler.Name = "grpOzellikler";
            this.grpOzellikler.Size = new System.Drawing.Size(259, 496);
            this.grpOzellikler.TabIndex = 0;
            this.grpOzellikler.TabStop = false;
            this.grpOzellikler.Text = "Çizilecek Özellikler (Y Ekseni)";
            // 
            // clbOzellikler
            // 
            this.clbOzellikler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(56)))));
            this.clbOzellikler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbOzellikler.CheckOnClick = true;
            this.clbOzellikler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbOzellikler.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clbOzellikler.ForeColor = System.Drawing.Color.White;
            this.clbOzellikler.FormattingEnabled = true;
            this.clbOzellikler.Location = new System.Drawing.Point(3, 20);
            this.clbOzellikler.Name = "clbOzellikler";
            this.clbOzellikler.Size = new System.Drawing.Size(253, 473);
            this.clbOzellikler.TabIndex = 0;
            this.clbOzellikler.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbOzellikler_ItemCheck);
            // 
            // tabAna
            // 
            this.tabAna.Controls.Add(this.tabGrafik);
            this.tabAna.Controls.Add(this.tabTablo);
            this.tabAna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAna.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabAna.Location = new System.Drawing.Point(8, 8);
            this.tabAna.Name = "tabAna";
            this.tabAna.SelectedIndex = 0;
            this.tabAna.Size = new System.Drawing.Size(829, 496);
            this.tabAna.TabIndex = 0;
            this.tabAna.SelectedIndexChanged += new System.EventHandler(this.tabAna_SelectedIndexChanged);
            // 
            // tabGrafik
            // 
            this.tabGrafik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.tabGrafik.Controls.Add(this.formsPlot1);
            this.tabGrafik.Location = new System.Drawing.Point(4, 26);
            this.tabGrafik.Name = "tabGrafik";
            this.tabGrafik.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrafik.Size = new System.Drawing.Size(821, 466);
            this.tabGrafik.TabIndex = 0;
            this.tabGrafik.Text = "📈 Grafik Görünümü (ScottPlot)";
            // 
            // formsPlot1
            // 
            this.formsPlot1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.formsPlot1.DisplayScale = 1F;
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(3, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(815, 460);
            this.formsPlot1.TabIndex = 0;
            // 
            // tabTablo
            // 
            this.tabTablo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.tabTablo.Controls.Add(this.dgvVeriler);
            this.tabTablo.Location = new System.Drawing.Point(4, 26);
            this.tabTablo.Name = "tabTablo";
            this.tabTablo.Padding = new System.Windows.Forms.Padding(3);
            this.tabTablo.Size = new System.Drawing.Size(821, 466);
            this.tabTablo.TabIndex = 1;
            this.tabTablo.Text = "📋 Tablo Görünümü (Tüm CSV Verileri)";
            // 
            // dgvVeriler
            // 
            this.dgvVeriler.AllowUserToAddRows = false;
            this.dgvVeriler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvVeriler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVeriler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.dgvVeriler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVeriler.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVeriler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVeriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(134)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVeriler.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVeriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVeriler.EnableHeadersVisualStyles = false;
            this.dgvVeriler.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(92)))));
            this.dgvVeriler.Location = new System.Drawing.Point(3, 3);
            this.dgvVeriler.Name = "dgvVeriler";
            this.dgvVeriler.ReadOnly = true;
            this.dgvVeriler.RowHeadersVisible = false;
            this.dgvVeriler.RowTemplate.Height = 26;
            this.dgvVeriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVeriler.Size = new System.Drawing.Size(815, 460);
            this.dgvVeriler.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1120, 612);
            this.Controls.Add(this.splitAna);
            this.Controls.Add(this.pnlAltStat);
            this.Controls.Add(this.pnlUst);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaSAT Veri Analizi ve ScottPlot Grafik Takip Sistemi — Dark Mode";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlUst.ResumeLayout(false);
            this.pnlUst.PerformLayout();
            this.pnlAltStat.ResumeLayout(false);
            this.pnlAltStat.PerformLayout();
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
        private System.Windows.Forms.Button btnPngKaydet;
        private System.Windows.Forms.Panel pnlAltStat;
        private System.Windows.Forms.Label lblIstatistik;
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
