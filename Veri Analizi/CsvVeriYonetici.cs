using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Veri_Analizi
{
    public class CsvVeriYonetici
    {
        public DataTable VeriTablosu { get; private set; } = new DataTable();
        public List<string> Basliklar { get; private set; } = new List<string>();
        public List<string> SayisalBasliklar { get; private set; } = new List<string>();

        public void CsvYukle(string dosyaYolu)
        {
            VeriTablosu = new DataTable();
            Basliklar.Clear();
            SayisalBasliklar.Clear();

            if (!File.Exists(dosyaYolu))
                throw new FileNotFoundException("CSV dosyası bulunamadı:", dosyaYolu);

            string[] satirlar = File.ReadAllLines(dosyaYolu);
            if (satirlar.Length == 0)
                throw new InvalidOperationException("CSV dosyası boş!");

            // İlk satır başlıklar
            string[] rawHeaders = satirlar[0].Split(',');
            for (int i = 0; i < rawHeaders.Length; i++)
            {
                string baslik = rawHeaders[i].Trim();
                if (string.IsNullOrEmpty(baslik))
                    baslik = $"Kolon_{i + 1}";

                // Aynı isimde kolon varsa numara ekle
                string uniqueBaslik = baslik;
                int count = 1;
                while (VeriTablosu.Columns.Contains(uniqueBaslik))
                {
                    uniqueBaslik = $"{baslik}_{count++}";
                }

                VeriTablosu.Columns.Add(uniqueBaslik, typeof(string));
                Basliklar.Add(uniqueBaslik);
            }

            // Satırları yükle
            for (int i = 1; i < satirlar.Length; i++)
            {
                string satir = satirlar[i];
                if (string.IsNullOrWhiteSpace(satir)) continue;

                string[] hucreler = satir.Split(',');
                DataRow row = VeriTablosu.NewRow();
                for (int j = 0; j < Math.Min(hucreler.Length, Basliklar.Count); j++)
                {
                    row[j] = hucreler[j].Trim();
                }
                VeriTablosu.Rows.Add(row);
            }

            // Sayısal (çizilebilir) kolonları tespit et
            foreach (string baslik in Basliklar)
            {
                if (KolonSayisalMi(baslik))
                {
                    SayisalBasliklar.Add(baslik);
                }
            }
        }

        private bool KolonSayisalMi(string baslik)
        {
            if (VeriTablosu.Rows.Count == 0) return false;

            int kontrolSayisi = Math.Min(15, VeriTablosu.Rows.Count);
            int basariliSayisal = 0;

            for (int i = 0; i < kontrolSayisi; i++)
            {
                string? valStr = VeriTablosu.Rows[i][baslik]?.ToString();
                if (string.IsNullOrWhiteSpace(valStr)) continue;

                if (double.TryParse(valStr, NumberStyles.Any, CultureInfo.InvariantCulture, out _) ||
                    double.TryParse(valStr, NumberStyles.Any, new CultureInfo("tr-TR"), out _))
                {
                    basariliSayisal++;
                }
            }

            return basariliSayisal > 0;
        }

        public double[] KolonVerileriniGetir(string baslik)
        {
            List<double> veriler = new List<double>();

            foreach (DataRow row in VeriTablosu.Rows)
            {
                string? valStr = row[baslik]?.ToString();
                if (double.TryParse(valStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double val) ||
                    double.TryParse(valStr, NumberStyles.Any, new CultureInfo("tr-TR"), out val))
                {
                    veriler.Add(val);
                }
                else
                {
                    veriler.Add(0.0);
                }
            }

            return veriler.ToArray();
        }
    }
}
