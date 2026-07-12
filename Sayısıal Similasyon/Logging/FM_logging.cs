using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Sayısıal_Similasyon.Communication;

namespace Sayısıal_Similasyon.Logging
{
    public class FM_logging
    {
        private BlockingCollection<LogTasiyici>? _logKuyrugu;
        private Task? _logTask;
        private CancellationTokenSource? _logCts;

        public struct LogTasiyici
        {
            public string ZamanGelen;
            public string ZamanGiden;
            public Iletim_Paketi_t GelenPaket;
            public Alim_Paketi_t GidenPaket;
        }

        public void LoglamayiBaslat()
        {
            _logKuyrugu = new BlockingCollection<LogTasiyici>();
            _logCts = new CancellationTokenSource();

            string zamanDamgasi = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string dosyaGelen = $"Gelen_Veriler_{zamanDamgasi}.csv";
            string dosyaGiden = $"Giden_Veriler_{zamanDamgasi}.csv";
            string dosyaBirlesik = $"Birlesik_Veriler_{zamanDamgasi}.csv";

            File.WriteAllText(dosyaGelen, "Saat,Header,Index,MI1,MI2,MI3,MI4,DurumBayraklari,Checksum\n");
            File.WriteAllText(dosyaGiden, "Saat,Header,Index,AccX,AccY,AccZ,GyroX,GyroY,GyroZ,MagX,MagY,MagZ,Basinc,Sicaklik,GpsLat,GpsLon,GpsAlt,GpsVel,BatV,BatA,Rezerve,Checksum\n");

            string birlesikBaslik = "Giden Saat,Giden Header,Giden Index,AccX,AccY,AccZ,GyroX,GyroY,GyroZ,MagX,MagY,MagZ,Basinc,Sicaklik,GpsLat,GpsLon,GpsAlt,GpsVel,BatV,BatA,Rezerve,Giden Checksum," +
                                    "Gelen Saat,Gelen Header,Gelen Index,MI1,MI2,MI3,MI4,DurumBayraklari,Gelen Checksum\n";
            File.WriteAllText(dosyaBirlesik, birlesikBaslik);

            _logTask = Task.Run(() => LogYaziciTask(dosyaGelen, dosyaGiden, dosyaBirlesik, _logCts.Token));
        }

        public void KuyrugaLogEkle(Alim_Paketi_t giden, string zamanGiden, Iletim_Paketi_t gelen, string zamanGelen)
        {
            if (_logKuyrugu != null && !_logKuyrugu.IsAddingCompleted)
            {
                _logKuyrugu.Add(new LogTasiyici
                {
                    GidenPaket = giden,
                    ZamanGiden = zamanGiden,
                    GelenPaket = gelen,
                    ZamanGelen = zamanGelen
                });
            }
        }

        private void LogYaziciTask(string pathGelen, string pathGiden, string pathBirlesik, CancellationToken token)
        {
            using (StreamWriter swGelen = new StreamWriter(pathGelen, true))
            using (StreamWriter swGiden = new StreamWriter(pathGiden, true))
            using (StreamWriter swBirlesik = new StreamWriter(pathBirlesik, true))
            {
                try
                {
                    if (_logKuyrugu == null) return;
                    foreach (var log in _logKuyrugu.GetConsumingEnumerable(token))
                    {
                        var gln = log.GelenPaket;
                        var gdn = log.GidenPaket;

                        string satirGelen = $"{log.ZamanGelen},{gln.header},{gln.index},{gln.mi1},{gln.mi2},{gln.mi3},{gln.mi4},{gln.durum_bayraklari},{gln.checksum}";
                        string satirGiden = $"{log.ZamanGiden},{gdn.header},{gdn.index},{gdn.acc_x},{gdn.acc_y},{gdn.acc_z},{gdn.gyro_x},{gdn.gyro_y},{gdn.gyro_z},{gdn.mag_x},{gdn.mag_y},{gdn.mag_z},{gdn.basinc},{gdn.sicaklik},{gdn.gps_lat},{gdn.gps_lon},{gdn.gps_alt},{gdn.gps_vel},{gdn.bat_v},{gdn.bat_a},{gdn.rezerve},{gdn.checksum}";

                        swGelen.WriteLine(satirGelen);
                        swGiden.WriteLine(satirGiden);
                        swBirlesik.WriteLine($"{satirGiden},{satirGelen}");
                    }
                }
                catch (OperationCanceledException)
                {
                }
            }
        }

        public void LoglamayiDurdur()
        {
            if (_logKuyrugu != null && !_logKuyrugu.IsAddingCompleted)
            {
                _logKuyrugu.CompleteAdding();
                _logTask?.Wait(2000);
                _logCts?.Cancel();
                _logKuyrugu.Dispose();
            }
        }
    }
}
