using System;
using System.Runtime.InteropServices;
using Sayısıal_Similasyon.Communication;

namespace Sayısıal_Similasyon.Physics
{
    public class FM_sistem
    {
        public uint aktifIndex;
        public Alim_Paketi_t sonUretilenPaket;

        // --- FİZİK DEĞİŞKENLERİ ---
        public float PosX { get; private set; } = 0.0f;
        public float PosY { get; private set; } = 400.0f; // 400m irtifa
        public float PosZ { get; private set; } = 0.0f;

        public float VelX { get; private set; } = 0.0f;
        public float VelY { get; private set; } = 0.0f;
        public float VelZ { get; private set; } = 0.0f;

        public float PitchDeg { get; private set; } = 0.0f;
        public float RollDeg { get; private set; } = 0.0f;
        public float YawDeg { get; private set; } = 0.0f;

        public float AngVelX { get; private set; } = 0.0f;
        public float AngVelY { get; private set; } = 0.0f;
        public float AngVelZ { get; private set; } = 0.0f;

        public float[] MotorPowers { get; private set; } = new float[4];
        public bool AreWingsOpen { get; private set; } = false;

        // Sabit parametreler
        public float MassKg { get; set; } = 2.5f;
        public float Gravity { get; set; } = 9.80665f;
        public float AirDensity { get; set; } = 1.225f;
        public float DragCoefficient { get; set; } = 0.8f;
        public float CrossSectionArea { get; set; } = 0.1256f;
        public float KMotor { get; set; } = 1.5e-8f;
        public float MaxRpm { get; set; } = 28428.0f;
        public float ArmDistance { get; set; } = 0.07388f;
        public float Cq { get; set; } = 1.0e-9f;

        public static readonly Alim_Paketi_t ALARM_PAKETI = new Alim_Paketi_t
        {
            header = PaketSabitleri.PAKET_HEADER,
            index = 0,
            rezerve = PaketSabitleri.PAKET_NACK,
            checksum = 0x0F
        };

        public static readonly Alim_Paketi_t BAS_PAKETI = new Alim_Paketi_t
        {
            header = PaketSabitleri.PAKET_HEADER,
            index = 1,
            rezerve = 0,
            checksum = 0xFE
        };

        public FM_sistem()
        {
            aktifIndex = 0;
            sonUretilenPaket = new Alim_Paketi_t();
            sonUretilenPaket.header = PaketSabitleri.PAKET_HEADER;
            sonUretilenPaket.rezerve = 0x00;
        }

        public void Index_Artir()
        {
            aktifIndex++;
        }

        public void Davranisi_Uygula(Iletim_Paketi_t paket)
        {
            MotorPowers[0] = Math.Clamp(paket.mi1 / 1000.0f, 0.0f, 1.0f);
            MotorPowers[1] = Math.Clamp(paket.mi2 / 1000.0f, 0.0f, 1.0f);
            MotorPowers[2] = Math.Clamp(paket.mi3 / 1000.0f, 0.0f, 1.0f);
            MotorPowers[3] = Math.Clamp(paket.mi4 / 1000.0f, 0.0f, 1.0f);

            AreWingsOpen = (paket.durum_bayraklari & PaketSabitleri.BAYRAK_SGM) != 0;
        }

        public void Fizigi_Calistir(float dt, ref Iletim_Paketi_t gelen_paket, ref Alim_Paketi_t giden_paket)
        {
            if (dt <= 0.0001f) dt = 0.0025f;

            Davranisi_Uygula(gelen_paket);

            float[] thrusts = new float[4];
            float totalThrust = 0.0f;
            for (int i = 0; i < 4; i++)
            {
                float rpm = MotorPowers[i] * MaxRpm;
                thrusts[i] = KMotor * (rpm * rpm);
                totalThrust += thrusts[i];
            }

            // Kuvvet hesabı (Z ekseni aşağı / yukarı basit Newton-Euler)
            float forceY = -MassKg * Gravity + totalThrust;
            float speed = (float)Math.Sqrt(VelX * VelX + VelY * VelY + VelZ * VelZ);
            if (speed > 0.001f)
            {
                forceY -= 0.5f * AirDensity * DragCoefficient * CrossSectionArea * speed * VelY;
            }

            float accelY = forceY / MassKg;
            VelY += accelY * dt;
            PosY += VelY * dt;

            if (PosY < 0.0f)
            {
                PosY = 0.0f;
                VelY = 0.0f;
            }

            // X-Konfigürasyon Tork hesabı
            float dEff = ArmDistance * 0.70710678f;
            float torqueX = dEff * ((thrusts[0] + thrusts[1]) - (thrusts[2] + thrusts[3]));
            float torqueZ = dEff * ((thrusts[1] + thrusts[3]) - (thrusts[0] + thrusts[2]));
            float torqueY = Cq * (
                -(float)Math.Pow(MotorPowers[0] * MaxRpm, 2) +
                 (float)Math.Pow(MotorPowers[1] * MaxRpm, 2) +
                 (float)Math.Pow(MotorPowers[2] * MaxRpm, 2) -
                 (float)Math.Pow(MotorPowers[3] * MaxRpm, 2)
            );

            float inertiaX = AreWingsOpen ? 0.01800f : 0.01016f;
            float inertiaY = AreWingsOpen ? 0.00500f : 0.00342f;
            float inertiaZ = AreWingsOpen ? 0.01800f : 0.01016f;

            AngVelX += (torqueX / inertiaX) * dt;
            AngVelY += (torqueY / inertiaY) * dt;
            AngVelZ += (torqueZ / inertiaZ) * dt;

            AngVelX *= 0.98f;
            AngVelY *= 0.98f;
            AngVelZ *= 0.98f;

            PitchDeg += AngVelX * dt * (180.0f / (float)Math.PI);
            YawDeg   += AngVelY * dt * (180.0f / (float)Math.PI);
            RollDeg  += AngVelZ * dt * (180.0f / (float)Math.PI);

            // Sensör verilerini Alım Paketine yaz
            giden_paket.acc_x = 0;
            giden_paket.acc_y = (short)(accelY * 100);
            giden_paket.acc_z = (short)(Gravity * 100);

            giden_paket.gyro_x = (short)(AngVelX * 100);
            giden_paket.gyro_y = (short)(AngVelY * 100);
            giden_paket.gyro_z = (short)(AngVelZ * 100);

            // Barometre
            giden_paket.basinc = (uint)Math.Max(0, 101325 - PosY * 12);
            giden_paket.sicaklik = 2500; // 25.00 C

            // GPS
            giden_paket.gps_lat = 399250000;
            giden_paket.gps_lon = 328360000;
            giden_paket.gps_alt = (int)(PosY * 1000);
            giden_paket.gps_vel = (short)(VelY * 100);

            // Batarya
            giden_paket.bat_v = 11100; // 11.1V
            giden_paket.bat_a = (int)(totalThrust * 500);
        }

        public void Alim_Paketini_Olustur(ref Alim_Paketi_t giden_paket)
        {
            giden_paket.index = aktifIndex;
            giden_paket.header = PaketSabitleri.PAKET_HEADER;

            byte[] paketBytes = FM_haberlesme.StructToBytes(giden_paket);
            int paketBoyutu = Marshal.SizeOf<Alim_Paketi_t>();
            giden_paket.checksum = FM_haberlesme.Checksum_Hesapla(paketBytes, paketBoyutu - 1);

            sonUretilenPaket = giden_paket;
        }

        public void En_Son_Paketi_Bir_Daha_Olustur(ref Alim_Paketi_t giden_paket)
        {
            giden_paket = sonUretilenPaket;
        }
    }
}
