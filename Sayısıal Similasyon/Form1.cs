using System;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sayısıal_Similasyon.Communication;
using Sayısıal_Similasyon.Logging;
using Sayısıal_Similasyon.Physics;

namespace Sayısıal_Similasyon
{
    public partial class Form1 : Form
    {
        private FM_haberlesme? haberlesme;
        private FM_sistem? fizikMotoru;
        private FM_logging? logging;

        private CancellationTokenSource? cts;
        private Task? motorTask;
        private bool isRunning = false;

        private Iletim_Paketi_t gelenPaket;
        private Alim_Paketi_t gidenPaket = new Alim_Paketi_t();
        private readonly object _paketKilidi = new object();
        private bool uiguncelle = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] portlar = SerialPort.GetPortNames();
            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(portlar);
            if (cmbPort.Items.Count > 0)
            {
                cmbPort.SelectedIndex = 0;
            }
            else
            {
                cmbPort.Items.Add("COM1");
                cmbPort.SelectedIndex = 0;
            }

            cmbBaud.SelectedItem = "921600";
            if (cmbBaud.SelectedIndex == -1) cmbBaud.SelectedIndex = 2; // 921600 varsayılan

            fizikMotoru = new FM_sistem();
            logging = new FM_logging();
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            if (isRunning) return;

            string port = cmbPort.SelectedItem?.ToString() ?? "COM1";
            int baud = int.TryParse(cmbBaud.SelectedItem?.ToString(), out int b) ? b : 921600;

            haberlesme = new FM_haberlesme(port, baud);

            try
            {
                haberlesme.PortAc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seri Port açılamadı:\n" + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Thread.Sleep(100);
            cts = new CancellationTokenSource();
            isRunning = true;

            btnBaslat.Enabled = false;
            btnDurdur.Enabled = true;
            cmbPort.Enabled = false;
            cmbBaud.Enabled = false;

            lblDurum.Text = "DURUM: ÇALIŞIYOR";
            lblDurum.ForeColor = Color.DarkGreen;

            logging?.LoglamayiBaslat();
            timerUI.Enabled = true;

            motorTask = Task.Factory.StartNew(() => AnaFizikDongusu(cts.Token),
                                              cts.Token,
                                              TaskCreationOptions.LongRunning,
                                              TaskScheduler.Default);
        }

        private void AnaFizikDongusu(CancellationToken token)
        {
            if (haberlesme == null || fizikMotoru == null || logging == null) return;

            Iletim_Paketi_t gelenPaketbuff;
            Alim_Paketi_t gidenPaketbuff = new Alim_Paketi_t();
            byte[] rawBuffer;

            // İlk açılış paketi (Başlangıç senkronizasyonu)
            fizikMotoru.Index_Artir();
            gidenPaketbuff = FM_sistem.BAS_PAKETI;
            fizikMotoru.Alim_Paketini_Olustur(ref gidenPaketbuff);
            haberlesme.Gonder(gidenPaketbuff);

            lock (_paketKilidi)
            {
                gidenPaket = gidenPaketbuff;
                uiguncelle = true;
            }

            string zamanGiden = DateTime.Now.ToString("HH:mm:ss.fff");

            while (!token.IsCancellationRequested)
            {
                Paket_Durum_t sonuc = haberlesme.Iletim_Paketini_Al(out gelenPaketbuff, out rawBuffer);
                string zamanGelen = DateTime.Now.ToString("HH:mm:ss.fff");

                logging.KuyrugaLogEkle(gidenPaketbuff, zamanGiden, gelenPaketbuff, zamanGelen);

                if (sonuc == Paket_Durum_t.PAKET_EKSIK)
                {
                    haberlesme.Gonder(FM_sistem.ALARM_PAKETI);
                    continue;
                }
                else if (sonuc == Paket_Durum_t.PAKET_HATA)
                {
                    Thread.Sleep(10);
                    continue;
                }
                else if (haberlesme.Bozuk_Paket_Mi(gelenPaketbuff, rawBuffer))
                {
                    haberlesme.Gonder(FM_sistem.ALARM_PAKETI);
                    continue;
                }
                else if (haberlesme.Alarm_Paketi_Mi(gelenPaketbuff))
                {
                    fizikMotoru.En_Son_Paketi_Bir_Daha_Olustur(ref gidenPaketbuff);
                    haberlesme.Gonder(gidenPaketbuff);
                    continue;
                }

                // Normal fizik işleme (dt ~ 0.0025 s)
                fizikMotoru.Index_Artir();
                fizikMotoru.Fizigi_Calistir(0.0025f, ref gelenPaketbuff, ref gidenPaketbuff);
                fizikMotoru.Alim_Paketini_Olustur(ref gidenPaketbuff);

                haberlesme.Gonder(gidenPaketbuff);
                zamanGiden = DateTime.Now.ToString("HH:mm:ss.fff");

                lock (_paketKilidi)
                {
                    gelenPaket = gelenPaketbuff;
                    gidenPaket = gidenPaketbuff;
                    uiguncelle = true;
                }
            }
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            Durdur();
        }

        private void Durdur()
        {
            if (!isRunning) return;

            timerUI.Enabled = false;
            isRunning = false;
            cts?.Cancel();
            logging?.LoglamayiDurdur();

            Thread.Sleep(150);
            haberlesme?.PortKapat();

            btnBaslat.Enabled = true;
            btnDurdur.Enabled = false;
            cmbPort.Enabled = true;
            cmbBaud.Enabled = true;

            lblDurum.Text = "DURUM: DURDURULDU";
            lblDurum.ForeColor = Color.DarkRed;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Durdur();
        }

        private void timerUI_Tick(object sender, EventArgs e)
        {
            Iletim_Paketi_t yerelGelen;
            Alim_Paketi_t yerelGiden;
            bool guncelleMi;

            lock (_paketKilidi)
            {
                yerelGelen = gelenPaket;
                yerelGiden = gidenPaket;
                guncelleMi = uiguncelle;
                uiguncelle = false;
            }

            if (guncelleMi && fizikMotoru != null)
            {
                lblGelenIndex.Text = "Gelen Index: " + yerelGelen.index;
                lblGidenIndex.Text = "Giden Index: " + yerelGiden.index;

                lblMI1.Text = $"MI1 (ÖnSol): {yerelGelen.mi1}";
                prgMI1.Value = Math.Min(1000, (int)yerelGelen.mi1);

                lblMI2.Text = $"MI2 (ÖnSağ): {yerelGelen.mi2}";
                prgMI2.Value = Math.Min(1000, (int)yerelGelen.mi2);

                lblMI3.Text = $"MI3 (ArkaSol): {yerelGelen.mi3}";
                prgMI3.Value = Math.Min(1000, (int)yerelGelen.mi3);

                lblMI4.Text = $"MI4 (ArkaSağ): {yerelGelen.mi4}";
                prgMI4.Value = Math.Min(1000, (int)yerelGelen.mi4);

                lblIrtifa.Text = $"İrtifa (Y): {fizikMotoru.PosY:F1} m";
                lblHiz.Text = $"Düşey Hız: {fizikMotoru.VelY:F2} m/s";
                lblEuler.Text = $"Pitch: {fizikMotoru.PitchDeg:F1}° | Roll: {fizikMotoru.RollDeg:F1}° | Yaw: {fizikMotoru.YawDeg:F1}°";

                lblKanat.Text = fizikMotoru.AreWingsOpen
                    ? "Kanat Durumu: AÇIK (SGM Aktif)"
                    : "Kanat Durumu: KAPALI";
                lblKanat.ForeColor = fizikMotoru.AreWingsOpen ? Color.DarkGreen : Color.DarkBlue;

                float batVolts = yerelGiden.bat_v / 1000.0f;
                float batAmps = yerelGiden.bat_a / 1000.0f;
                lblBatarya.Text = $"Batarya: {batVolts:F2} V | {batAmps:F2} A";
            }
        }
    }
}
