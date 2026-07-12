using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;

namespace Sayısıal_Similasyon.Communication
{
    public class FM_haberlesme
    {
        private SerialPort _seriPort;

        public FM_haberlesme(string portAdi, int baudRate)
        {
            _seriPort = new SerialPort(portAdi, baudRate, Parity.None, 8, StopBits.One);
            _seriPort.ReadTimeout = 50;
            _seriPort.WriteTimeout = 50;
        }

        public bool IsOpen => _seriPort != null && _seriPort.IsOpen;

        public void PortAc()
        {
            if (!_seriPort.IsOpen)
                _seriPort.Open();
        }

        public void PortKapat()
        {
            if (_seriPort != null && _seriPort.IsOpen)
                _seriPort.Close();
        }

        public Paket_Durum_t Iletim_Paketini_Al(out Iletim_Paketi_t alinanPaket, out byte[] rawBuffer)
        {
            alinanPaket = default(Iletim_Paketi_t);
            int paketBoyutu = Marshal.SizeOf<Iletim_Paketi_t>();
            rawBuffer = new byte[paketBoyutu];

            int okunanToplam = 0;

            // 1. AŞAMA: İlk bayt gelene kadar bekle
            while (_seriPort.BytesToRead == 0)
            {
                Thread.Yield();
            }

            // 2. AŞAMA: Zaman aşımı kontrolü (100 ms kuralı)
            Stopwatch sw = Stopwatch.StartNew();

            while (okunanToplam < paketBoyutu)
            {
                if (_seriPort.BytesToRead > 0)
                {
                    okunanToplam += _seriPort.Read(rawBuffer, okunanToplam, paketBoyutu - okunanToplam);
                }

                if (sw.ElapsedMilliseconds > 100)
                {
                    return Paket_Durum_t.PAKET_EKSIK;
                }
            }

            alinanPaket = BytesToStruct<Iletim_Paketi_t>(rawBuffer);
            return Paket_Durum_t.PAKET_TAM;
        }

        public bool Bozuk_Paket_Mi(Iletim_Paketi_t paket, byte[] rawBuffer)
        {
            if (paket.header != PaketSabitleri.PAKET_HEADER)
                return true;

            byte hesaplananChk = Checksum_Hesapla(rawBuffer, rawBuffer.Length - 1);
            if (hesaplananChk != paket.checksum)
                return true;

            return false;
        }

        public bool Alarm_Paketi_Mi(Iletim_Paketi_t paket)
        {
            return paket.durum_bayraklari == PaketSabitleri.PAKET_NACK;
        }

        public void Gonder(Alim_Paketi_t gonderilecekPaket)
        {
            if (!_seriPort.IsOpen) return;

            byte[] buffer = StructToBytes(gonderilecekPaket);
            _seriPort.Write(buffer, 0, buffer.Length);
        }

        public static byte Checksum_Hesapla(byte[] veri, int uzunluk)
        {
            byte chk = 0;
            for (int i = 0; i < uzunluk; i++)
            {
                chk ^= veri[i];
            }
            return chk;
        }

        public static byte[] StructToBytes<T>(T str) where T : struct
        {
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(str, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            return arr;
        }

        public static T BytesToStruct<T>(byte[] arr) where T : struct
        {
            T str = default(T);
            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.Copy(arr, 0, ptr, size);
                object? obj = Marshal.PtrToStructure(ptr, typeof(T));
                if (obj != null) str = (T)obj;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            return str;
        }
    }
}
