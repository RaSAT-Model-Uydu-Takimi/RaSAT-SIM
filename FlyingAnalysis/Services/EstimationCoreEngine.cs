using System;
using FlyingAnalysis.Models;
using FlyingAnalysis.Models.Timeline;

namespace FlyingAnalysis.Services
{
    public class EstimationCoreEngine
    {
        // Durum Vektörü X = [z, v, a]^T
        private double _z;
        private double _v;
        private double _a;

        // Kovaryans Matrisi P (3x3)
        private double _p00 = 10.0, _p01 = 0.0, _p02 = 0.0;
        private double _p10 = 0.0, _p11 = 10.0, _p12 = 0.0;
        private double _p20 = 0.0, _p21 = 0.0, _p22 = 10.0;

        private double _lastValidTemp = 15.0;
        private double _currentConfidence = 100.0;
        private bool _isInitialized = false;

        public void Reset(double initialAltitude, double initialTemperature = 15.0)
        {
            _z = Math.Max(0.0, initialAltitude);
            _v = 0.0;
            _a = 0.0;

            _p00 = 5.0;  _p01 = 0.0; _p02 = 0.0;
            _p10 = 0.0;  _p11 = 5.0; _p12 = 0.0;
            _p20 = 0.0;  _p21 = 0.0; _p22 = 5.0;

            _lastValidTemp = initialTemperature;
            _currentConfidence = 100.0;
            _isInitialized = true;
        }

        public void Step(TimelineSimulationFrame frame, double dt)
        {
            if (!_isInitialized)
            {
                Reset(frame.TruePosition, frame.Temperature);
            }

            if (dt <= 0) dt = 0.01;

            // 1. Hedefli Kesinti ve Gürültü Bayraklarını Çözümle
            bool baroCutoff = frame.IsBaroCutoffActive || frame.IsSensorCutoffActive;
            bool accCutoff = frame.IsAccCutoffActive || frame.IsSensorCutoffActive;
            bool tempCutoff = frame.IsTempCutoffActive || frame.IsSensorCutoffActive;
            bool extraNoise = frame.IsSpecialNoiseActive;

            // Barometre verisi NaN veya kapalıysa
            if (double.IsNaN(frame.CalibratedBaroPosition)) baroCutoff = true;
            if (double.IsNaN(frame.CalibratedAcceleration)) accCutoff = true;
            if (double.IsNaN(frame.Temperature)) tempCutoff = true;

            // 2. Sıcaklık Yedekleme Modeli (Temperature Fallback)
            double tempUsed = frame.Temperature;
            double tempPenalty = 1.0;
            if (tempCutoff)
            {
                // Standart Atmosfer / Son Geçerli Sıcaklık
                tempUsed = _lastValidTemp;
                tempPenalty = 1.15; // Baro R matrisini hafifçe artır
            }
            else
            {
                _lastValidTemp = frame.Temperature;
            }

            // 3. Tahmin Adımı (Time Update)
            // F = [ 1  dt  0.5*dt^2 ]
            //     [ 0   1     dt    ]
            //     [ 0   0      1    ]
            double zPred = _z + _v * dt + 0.5 * _a * dt * dt;
            double vPred = _v + _a * dt;
            double aPred = _a;

            // Süreç Gürültüsü Q (Sistem Dinamiği / Rüzgar / Türbülans)
            double qBase = GlobalSimulationConfig.EstProcessNoiseQBase;
            double q00 = qBase * (dt * dt * dt * dt) / 4.0;
            double q11 = qBase * (dt * dt);
            double q22 = qBase;

            // P_pred = F * P * F^T + Q
            double fp00 = _p00 + dt * _p10 + 0.5 * dt * dt * _p20;
            double fp01 = _p01 + dt * _p11 + 0.5 * dt * dt * _p21;
            double fp02 = _p02 + dt * _p12 + 0.5 * dt * dt * _p22;

            double fp10 = _p10 + dt * _p20;
            double fp11 = _p11 + dt * _p21;
            double fp12 = _p12 + dt * _p22;

            double fp20 = _p20;
            double fp21 = _p21;
            double fp22 = _p22;

            // (FP) · F^T  — F^T[j][k] = F[k][j]
            // nextP[i][j] = sum_k FP[i][k] * F[j][k]
            double nextP00 = fp00 + dt * fp01 + 0.5 * dt * dt * fp02 + q00;
            double nextP01 = fp01 + dt * fp02;
            double nextP02 = fp02;

            double nextP10 = fp10 + dt * fp11 + 0.5 * dt * dt * fp12;
            double nextP11 = fp11 + dt * fp12 + q11;
            double nextP12 = fp12;

            double nextP20 = fp20 + dt * fp21 + 0.5 * dt * dt * fp22;
            double nextP21 = fp21 + dt * fp22;
            double nextP22 = fp22 + q22;

            _z = zPred;
            _v = vPred;
            _a = aPred;
            _p00 = nextP00; _p01 = nextP01; _p02 = nextP02;
            _p10 = nextP10; _p11 = nextP11; _p12 = nextP12;
            _p20 = nextP20; _p21 = nextP21; _p22 = nextP22;

            // 4. Barometre Ölçüm Güncellemesi (H_baro = [1, 0, 0])
            if (!baroCutoff)
            {
                double rBaro = GlobalSimulationConfig.EstBaroNoiseRBase * tempPenalty;
                if (extraNoise) rBaro *= 3.0; // Gürültü şokunda R büyüt

                double y = frame.CalibratedBaroPosition - _z;
                double S = _p00 + rBaro;
                if (S > 1e-9)
                {
                    double k0 = _p00 / S;
                    double k1 = _p10 / S;
                    double k2 = _p20 / S;

                    _z += k0 * y;
                    _v += k1 * y;
                    _a += k2 * y;

                    double newP00 = (1.0 - k0) * _p00;
                    double newP01 = (1.0 - k0) * _p01;
                    double newP02 = (1.0 - k0) * _p02;

                    double newP10 = _p10 - k1 * _p00;
                    double newP11 = _p11 - k1 * _p01;
                    double newP12 = _p12 - k1 * _p02;

                    double newP20 = _p20 - k2 * _p00;
                    double newP21 = _p21 - k2 * _p01;
                    double newP22 = _p22 - k2 * _p02;

                    _p00 = newP00; _p01 = newP01; _p02 = newP02;
                    _p10 = newP10; _p11 = newP11; _p12 = newP12;
                    _p20 = newP20; _p21 = newP21; _p22 = newP22;
                }
            }

            // 5. İvmeölçer Ölçüm Güncellemesi (H_acc = [0, 0, 1])
            if (!accCutoff)
            {
                double rAcc = GlobalSimulationConfig.EstAccNoiseRBase;
                if (extraNoise) rAcc *= 3.0;

                double yAcc = frame.CalibratedAcceleration - _a;
                double SAcc = _p22 + rAcc;
                if (SAcc > 1e-9)
                {
                    double k0 = _p02 / SAcc;
                    double k1 = _p12 / SAcc;
                    double k2 = _p22 / SAcc;

                    _z += k0 * yAcc;
                    _v += k1 * yAcc;
                    _a += k2 * yAcc;

                    double newP00 = _p00 - k0 * _p20;
                    double newP01 = _p01 - k0 * _p21;
                    double newP02 = _p02 - k0 * _p22;

                    double newP10 = _p10 - k1 * _p20;
                    double newP11 = _p11 - k1 * _p21;
                    double newP12 = _p12 - k1 * _p22;

                    double newP20 = (1.0 - k2) * _p20;
                    double newP21 = (1.0 - k2) * _p21;
                    double newP22 = (1.0 - k2) * _p22;

                    _p00 = newP00; _p01 = newP01; _p02 = newP02;
                    _p10 = newP10; _p11 = newP11; _p12 = newP12;
                    _p20 = newP20; _p21 = newP21; _p22 = newP22;
                }
            }

            // Yerde durma koruması
            if (_z <= 0.0 && _v < 0.0)
            {
                _z = 0.0;
                _v = 0.0;
                if (_a < 0.0) _a = 0.0;
            }

            // 6. Dinamik Güven Katsayısı (Confidence % 0..100) Hesaplaması
            double conf = 100.0;

            if (baroCutoff)
            {
                conf -= GlobalSimulationConfig.EstBaroCutoffPenalty;
                // Kör uçuşta zamanla sürüklenmeden dolayı saniyelik ek erime
                _currentConfidence -= GlobalSimulationConfig.EstCoastDecayRatePerSec * dt;
            }
            else
            {
                // Barometre çalışıyorsa güven yavaşça toparlanır
                if (_currentConfidence < 100.0)
                {
                    _currentConfidence += 10.0 * dt;
                    if (_currentConfidence > 100.0) _currentConfidence = 100.0;
                }
            }

            if (accCutoff) conf -= GlobalSimulationConfig.EstAccCutoffPenalty;
            if (tempCutoff) conf -= GlobalSimulationConfig.EstTempCutoffPenalty;
            if (extraNoise) conf -= 18.0;

            conf = Math.Min(conf, _currentConfidence);
            if (conf < 0.0) conf = 0.0;
            if (conf > 100.0) conf = 100.0;

            // Sonuçları frame içine yaz
            frame.EstimatedPosition = Math.Round(_z, 4);
            frame.EstimatedVelocity = Math.Round(_v, 4);
            frame.EstimatedAcceleration = Math.Round(_a, 4);
            frame.ConfidenceScore = Math.Round(conf, 1);
        }
    }
}
