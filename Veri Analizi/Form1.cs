using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // İlk açılışta grafiğe bilgilendirme başlığı at
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

                        // Tabloyu güncelle
                        dgvVeriler.DataSource = null;
                        dgvVeriler.DataSource = veriYonetici.VeriTablosu;

                        lblDosyaBilgi.Text = $"Seçilen Dosya: {Path.GetFileName(ofd.FileName)} ({veriYonetici.VeriTablosu.Rows.Count} satır, {veriYonetici.Basliklar.Count} kolon)";
                        lblDosyaBilgi.ForeColor = Color.DarkGreen;

                        programatikDegisim = true;

                        // X Ekseni listesini doldur
                        cmbXEkseni.Items.Clear();
                        cmbXEkseni.Items.Add("(Satır İndeksi)");
                        foreach (var sayisal in veriYonetici.SayisalBasliklar)
                        {
                            cmbXEkseni.Items.Add(sayisal);
                        }
                        cmbXEkseni.SelectedIndex = 0;

                        // Y Ekseni (Özellikler) CheckListBox doldur
                        clbOzellikler.Items.Clear();
                        foreach (var baslik in veriYonetici.SayisalBasliklar)
                        {
                            clbOzellikler.Items.Add(baslik, false);
                        }

                        // İlk birkaç kolon varsayılan olarak seçilsin
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
            {
                GrafigiCiz();
            }
        }

        private void clbOzellikler_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!programatikDegisim)
            {
                // ItemCheck olayı gerçekleştiğinde checked durumu henüz oturmamış olur,
                // o yüzden BeginInvoke ile bir sonraki döngüde çizdiriyoruz.
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

        private void GrafigiCiz()
        {
            if (veriYonetici.VeriTablosu.Rows.Count == 0) return;

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
                formsPlot1.Plot.Title("Lütfen sol panelden çizilecek en az bir özellik (Y ekseni) seçin");
                formsPlot1.Refresh();
                return;
            }

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
                scatter.MarkerSize = 0; // Çok veride markerları gizle (daha hızlı ve temiz)
            }

            formsPlot1.Plot.Title("RaSAT Sayısal Karşılaştırma Grafiği");
            formsPlot1.Plot.XLabel(xBaslik);
            formsPlot1.Plot.YLabel("Değerler");
            formsPlot1.Plot.ShowLegend();
            formsPlot1.Plot.Axes.AutoScale();
            formsPlot1.Refresh();
        }
    }
}
