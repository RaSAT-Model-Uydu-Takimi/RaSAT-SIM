using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Veri_Analizi
{
    public partial class Form1 : Form
    {
        private CsvVeriYonetici veriYonetici = new CsvVeriYonetici();
        private bool programatikDegisim = false;

        public Form1()
        {
            InitializeComponent();
            TabloIcinDoubleBufferingAc(dgvVeriler);
        }

        private static void TabloIcinDoubleBufferingAc(DataGridView dgv)
        {
            try
            {
                Type dgvType = dgv.GetType();
                PropertyInfo? pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi?.SetValue(dgv, true, null);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formsPlot1.Plot.Title("RaSAT Veri Analizi — Lütfen Bir CSV Dosyası Yükleyin");
            formsPlot1.Plot.XLabel("X Ekseni");
            formsPlot1.Plot.YLabel("Değerler");
            formsPlot1.Refresh();
        }

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Analiz İçin CSV Kayıt Dosyası Seçin";
                ofd.Filter = "CSV Dosyaları (*.csv)|*.csv|Tüm Dosyalar (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        veriYonetici.CsvYukle(ofd.FileName);

                        // Tabloyu güvenli ve hızlı şekilde doldur
                        dgvVeriler.SuspendLayout();
                        dgvVeriler.DataSource = null;
                        dgvVeriler.DataSource = veriYonetici.VeriTablosu;
                        dgvVeriler.ResumeLayout();

                        lblDosyaBilgi.Text = $"Seçilen Dosya: {Path.GetFileName(ofd.FileName)} ({veriYonetici.VeriTablosu.Rows.Count} satır, {veriYonetici.Basliklar.Count} kolon)";
                        lblDosyaBilgi.ForeColor = Color.DarkGreen;

                        programatikDegisim = true;

                        cmbXEkseni.Items.Clear();
                        cmbXEkseni.Items.Add("(Satır İndeksi)");
                        foreach (var sayisal in veriYonetici.SayisalBasliklar)
                        {
                            cmbXEkseni.Items.Add(sayisal);
                        }
                        cmbXEkseni.SelectedIndex = 0;

                        clbOzellikler.Items.Clear();
                        foreach (var baslik in veriYonetici.SayisalBasliklar)
                        {
                            clbOzellikler.Items.Add(baslik, false);
                        }

                        int varsayilanSecim = Math.Min(3, clbOzellikler.Items.Count);
                        for (int i = 0; i < varsayilanSecim; i++)
                        {
                            clbOzellikler.SetItemChecked(i, true);
                        }

                        programatikDegisim = false;
                        GrafigiCiz();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("CSV dosyası yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cmbXEkseni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!programatikDegisim)
                GrafigiCiz();
        }

        private void clbOzellikler_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!programatikDegisim)
            {
                BeginInvoke(new Action(GrafigiCiz));
            }
        }

        private void btnCiz_Click(object sender, EventArgs e)
        {
            GrafigiCiz();
        }

        private void btnTumu_Click(object sender, EventArgs e)
        {
            if (clbOzellikler.Items.Count == 0) return;

            bool suAnkiTumuSecili = clbOzellikler.CheckedItems.Count == clbOzellikler.Items.Count;
            bool yeniDurum = !suAnkiTumuSecili;

            programatikDegisim = true;
            for (int i = 0; i < clbOzellikler.Items.Count; i++)
            {
                clbOzellikler.SetItemChecked(i, yeniDurum);
            }
            programatikDegisim = false;

            GrafigiCiz();
        }

        private void btnPngKaydet_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Grafiği PNG Olarak Kaydet";
                sfd.Filter = "PNG Resmi (*.png)|*.png";
                sfd.FileName = $"RaSAT_Grafik_{DateTime.Now:yyyyMMdd_HHmmss}.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        formsPlot1.Plot.SavePng(sfd.FileName, 1600, 900);
                        MessageBox.Show("Grafik yüksek çözünürlüklü PNG olarak kaydedildi:\n" + sfd.FileName, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("PNG kaydedilirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tabAna_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sekmeler arası geçişlerde sıfır boyut veya görünürlük sorununa karşı güvenli yenileme
            if (tabAna.SelectedTab == tabGrafik && formsPlot1 != null && !formsPlot1.IsDisposed)
            {
                if (formsPlot1.Width > 0 && formsPlot1.Height > 0)
                {
                    try { formsPlot1.Refresh(); } catch { }
                }
            }
        }

        private void GrafigiCiz()
        {
            if (veriYonetici.VeriTablosu.Rows.Count == 0) return;
            if (formsPlot1 == null || formsPlot1.IsDisposed) return;

            formsPlot1.Plot.Clear();

            int satirSayisi = veriYonetici.VeriTablosu.Rows.Count;
            double[] xVerileri;
            string xBaslik = cmbXEkseni.SelectedItem?.ToString() ?? "(Satır İndeksi)";

            if (xBaslik == "(Satır İndeksi)" || string.IsNullOrEmpty(xBaslik))
            {
                xVerileri = new double[satirSayisi];
                for (int i = 0; i < satirSayisi; i++) xVerileri[i] = i;
            }
            else
            {
                xVerileri = veriYonetici.KolonVerileriniGetir(xBaslik);
            }

            int secilenSayisi = clbOzellikler.CheckedItems.Count;
            if (secilenSayisi == 0)
            {
                formsPlot1.Plot.Title("Lütfen sol panelden çizilecek en az bir özellik seçin");
                try { if (formsPlot1.Width > 0 && formsPlot1.Height > 0) formsPlot1.Refresh(); } catch { }
                lblIstatistik.Text = "📊 İstatistik Özet: Seçim yapılmadı.";
                return;
            }

            double genelMin = double.MaxValue;
            double genelMax = double.MinValue;
            double toplam = 0;
            int veriAdedi = 0;

            foreach (var item in clbOzellikler.CheckedItems)
            {
                string kolonAdi = item.ToString() ?? "";
                double[] yVerileri = veriYonetici.KolonVerileriniGetir(kolonAdi);

                int minLen = Math.Min(xVerileri.Length, yVerileri.Length);
                if (minLen == 0) continue;

                if (xVerileri.Length != minLen)
                    xVerileri = xVerileri.Take(minLen).ToArray();
                if (yVerileri.Length != minLen)
                    yVerileri = yVerileri.Take(minLen).ToArray();

                var scatter = formsPlot1.Plot.Add.Scatter(xVerileri, yVerileri);
                scatter.LegendText = kolonAdi;
                scatter.LineWidth = 2;
                scatter.MarkerSize = minLen < 100 ? 5 : 0;

                foreach (var val in yVerileri)
                {
                    if (val < genelMin) genelMin = val;
                    if (val > genelMax) genelMax = val;
                    toplam += val;
                    veriAdedi++;
                }
            }

            formsPlot1.Plot.Title("RaSAT Telemetri & Fizik Karşılaştırma Grafiği");
            formsPlot1.Plot.XLabel(xBaslik);
            formsPlot1.Plot.YLabel("Değerler");
            formsPlot1.Plot.ShowLegend();
            formsPlot1.Plot.Axes.AutoScale();

            if (veriAdedi > 0)
            {
                double ortalama = toplam / veriAdedi;
                lblIstatistik.Text = $"📊 İstatistik Özet — Seçilen Kolon Sayısı: {secilenSayisi} | Min: {genelMin:F2} | Maks: {genelMax:F2} | Ortalama: {ortalama:F2}";
            }

            try
            {
                if (formsPlot1.Width > 0 && formsPlot1.Height > 0)
                {
                    formsPlot1.Refresh();
                }
            }
            catch { }
        }
    }
}
