using System;
using System.Runtime.InteropServices;

namespace Sayısıal_Similasyon.Communication
{
    // ========================================================================
    // 1. VERİ YAPILARI (STRUCTS) - 16 Byte İletim Paketi & 52 Byte Alım Paketi
    // ========================================================================

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Iletim_Paketi_t
    {
        public ushort header;           // 2 Bayt (0xAA55)
        public uint index;              // 4 Bayt
        public ushort mi1;              // 2 Bayt (0..1000)
        public ushort mi2;              // 2 Bayt (0..1000)
        public ushort mi3;              // 2 Bayt (0..1000)
        public ushort mi4;              // 2 Bayt (0..1000)
        public byte durum_bayraklari;   // 1 Bayt (Bitmask Bayrakları)
        public byte checksum;           // 1 Bayt (XOR Checksum)
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Alim_Paketi_t
    {
        public ushort header;         // 2 Bayt (0xAA55)
        public uint index;            // 4 Bayt

        public short acc_x;           // 2 Bayt
        public short acc_y;           // 2 Bayt
        public short acc_z;           // 2 Bayt

        public short gyro_x;          // 2 Bayt
        public short gyro_y;          // 2 Bayt
        public short gyro_z;          // 2 Bayt

        public short mag_x;           // 2 Bayt
        public short mag_y;           // 2 Bayt
        public short mag_z;           // 2 Bayt

        public uint basinc;           // 4 Bayt (Pa)
        public short sicaklik;        // 2 Bayt (0.01 C)

        public int gps_lat;           // 4 Bayt (10E7 deg)
        public int gps_lon;           // 4 Bayt (10E7 deg)
        public int gps_alt;           // 4 Bayt (mm)
        public short gps_vel;         // 2 Bayt (cm/s)

        public ushort bat_v;          // 2 Bayt (mV)
        public int bat_a;             // 4 Bayt (mA)
        public byte rezerve;          // 1 Bayt (Alarm durumunda 0xF0)
        public byte checksum;         // 1 Bayt (XOR Checksum)
    }

    public enum Paket_Durum_t
    {
        PAKET_HATA = 0,   // Hiçbir şey gelmedi / port kapalı
        PAKET_TAM = 1,    // 16 byte eksiksiz geldi
        PAKET_EKSIK = 2   // Timeout oldu ama bir miktar veri geldi
    }

    public static class PaketSabitleri
    {
        public const ushort PAKET_HEADER = 0xAA55;
        public const byte PAKET_NACK = 0xF0;
        public const byte BAYRAK_SGM = 0x01; // Kanat açma bayrağı
    }
}
