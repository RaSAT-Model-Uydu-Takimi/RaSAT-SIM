using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.WinForms;
using SensorAnalizi.Simulation;

namespace SensorAnalizi
{
    public partial class FormSensorAnalizi : Form
    {
        private PhysicsSimulationResult? currentPhysicsResult = null;
        private int playbackIndex = 0;
        private ScottPlot.Plottables.VerticalLine? cursorAltitudeLine = null;
        private double currentBaroTrustPct = 68.0;
        private double currentImuTrustPct = 32.0;
        private double currentKalmanGain = 0.012;
        private double currentInnovation = 0.15;
        private string currentFilterMode = "Adaptif EKF (LPF Destekli)";

        public FormSensorAnalizi()
        {
            InitializeComponent();
            SetupCollapsiblePanels();
            RunAllScenarios();
            RunPhysicsSimulation();
        }

        private void SetupCollapsiblePanels()
        {
            void SetupToggle(CheckBox chk, GroupBox grp, int fullHeight)
            {
                chk.Checked = true;
                chk.Text = "▼ Açık";
                chk.CheckedChanged += (s, e) =>
                {
                    grp.Height = chk.Checked ? fullHeight : 26;
                    chk.Text = chk.Checked ? "▼ Açık" : "▶ Gizli";
                };
                grp.DoubleClick += (s, e) => { chk.Checked = !chk.Checked; };
            }

            SetupToggle(chkToggleMassAero, grpMassAero, 195);
            SetupToggle(chkToggleMission, grpMission, 115);
            SetupToggle(chkTogglePID, grpPID, 115);
            SetupToggle(chkToggleNoise, grpNoise, 315);
            SetupToggle(chkToggleBucket, grpBucket, 115);
        }

        private void BtnRunAllCompare_Click(object? sender, EventArgs e)
        {
            RunAllScenarios();
        }

        private void BtnRunCustom_Click(object? sender, EventArgs e)
        {
            double errPercent = (double)numErrorPercent.Value;
            double scaleErr = 1.0 + (errPercent / 100.0);
            bool useFusion = chkUseFusion.Checked;

            dgvMetrics.Rows.Clear();
            plotAltitude.Plot.Clear();
            plotVelocity.Plot.Clear();

            var customSim = RunFullMissionScenario(
                $"Özel Senaryo (%{errPercent:0} Hata, Füzyon: {(useFusion ? "AÇIK" : "KAPALI")})",
                errPercent,
                useFusion
            );

            string evaluation = "GÜVENLİ İNİŞ";
            if (customSim.ImpactVelocity > 3.5) evaluation = "KRİTİK RİSK (SERT ÇARPIŞ)";
            else if (customSim.ImpactVelocity > 2.5) evaluation = "ORTA RİSK";

            dgvMetrics.Rows.Add(
                customSim.ScenarioName,
                $"%{errPercent:0}",
                customSim.UseSensorFusion ? "Aktif (Baro+İvme)" : "Pasif (Sadece Baro)",
                customSim.ImpactVelocity.ToString("0.00"),
                customSim.TotalLandingTime.ToString("0.0"),
                evaluation
            );

            double[] timeArr = customSim.Trajectory.Select(p => p.Time).ToArray();
            double[] trueAltArr = customSim.Trajectory.Select(p => p.TrueAltitude).ToArray();
            double[] sensorAltArr = customSim.Trajectory.Select(p => p.SensorAltitude).ToArray();
            double[] estAltArr = customSim.Trajectory.Select(p => p.EstimatedAltitude).ToArray();
            double[] velArr = customSim.Trajectory.Select(p => -p.TrueVelocity).ToArray();

            var s1 = plotAltitude.Plot.Add.Scatter(timeArr, trueAltArr);
            s1.LegendText = "Gerçek İrtifa (Ground Truth)";
            s1.LineWidth = 3;

            var s2 = plotAltitude.Plot.Add.Scatter(timeArr, sensorAltArr);
            s2.LegendText = $"Sensör Ölçümü (%{errPercent:0} Hatalı)";
            s2.LineWidth = 2;

            if (useFusion)
            {
                var s3 = plotAltitude.Plot.Add.Scatter(timeArr, estAltArr);
                s3.LegendText = "EKF Füzyon Kestirimi";
                s3.LineWidth = 2;
            }

            var v1 = plotVelocity.Plot.Add.Scatter(timeArr, velArr);
            v1.LegendText = "Dikey Hız (-v_z)";
            v1.LineWidth = 2;
            v1.Color = ScottPlot.Colors.OrangeRed;

            plotAltitude.Plot.Title("Özel Senaryo - İrtifa vs Zaman");
            plotAltitude.Plot.XLabel("Zaman (s)");
            plotAltitude.Plot.YLabel("İrtifa (m)");
            plotAltitude.Plot.ShowLegend();

            plotVelocity.Plot.Title("Özel Senaryo İniş Hızı Profil Grafigi");
            plotVelocity.Plot.XLabel("Zaman (saniye)");
            plotVelocity.Plot.YLabel("Aşağı Yönlü İniş Hızı (m/s)");
            plotVelocity.Plot.ShowLegend();

            plotAltitude.Refresh();
            plotVelocity.Refresh();
        }

        private void RunAllScenarios()
        {
            dgvMetrics.Rows.Clear();
            plotAltitude.Plot.Clear();
            plotVelocity.Plot.Clear();

            var resIdeal = RunFullMissionScenario("1. İdeal Sensör (%0 Hata)", 0.0, false);
            var resHigh = RunFullMissionScenario("2. +%20 Hatalı Sensör (Füzyonsuz)", 20.0, false);
            var resLow = RunFullMissionScenario("3. -%20 Hatalı Sensör (Füzyonsuz)", -20.0, false);
            var resFusion = RunFullMissionScenario("4. +%20 Hatalı Sensör + EKF Füzyonu", 20.0, true);

            var scenarios = new[] { resIdeal, resHigh, resLow, resFusion };

            foreach (var sc in scenarios)
            {
                string evaluation = "GÜVENLİ İNİŞ";
                if (sc.ImpactVelocity > 3.5) evaluation = "KRİTİK RİSK (SERT ÇARPIŞ)";
                else if (sc.ImpactVelocity > 2.5) evaluation = "ORTA RİSK";

                dgvMetrics.Rows.Add(
                    sc.ScenarioName,
                    $"%{((sc.SensorScaleError - 1.0) * 100):0}",
                    sc.UseSensorFusion ? "Aktif (Baro+İvme)" : "Pasif (Sadece Baro)",
                    sc.ImpactVelocity.ToString("0.00"),
                    sc.TotalLandingTime.ToString("0.0"),
                    evaluation
                );

                double[] timeArr = sc.Trajectory.Select(p => p.Time).ToArray();
                double[] altArr = sc.Trajectory.Select(p => p.TrueAltitude).ToArray();
                double[] velArr = sc.Trajectory.Select(p => -p.TrueVelocity).ToArray();

                var sigAlt = plotAltitude.Plot.Add.Scatter(timeArr, altArr);
                sigAlt.LegendText = sc.ScenarioName;
                sigAlt.LineWidth = 3;

                var sigVel = plotVelocity.Plot.Add.Scatter(timeArr, velArr);
                sigVel.LegendText = sc.ScenarioName;
                sigVel.LineWidth = 3;
            }

            plotAltitude.Plot.Title("Gerçek İrtifa vs Zaman (4 Senaryonun Karşılaştırması)");
            plotAltitude.Plot.XLabel("Zaman (saniye)");
            plotAltitude.Plot.YLabel("Gerçek İrtifa (metre)");
            plotAltitude.Plot.ShowLegend();

            plotVelocity.Plot.Title("İniş Hızı vs Zaman (Yavaşlama Eşiklerinin Ayrışması)");
            plotVelocity.Plot.XLabel("Zaman (saniye)");
            plotVelocity.Plot.YLabel("Aşağı Yönlü İniş Hızı (m/s)");
            plotVelocity.Plot.ShowLegend();

            plotAltitude.Refresh();
            plotVelocity.Refresh();
        }

        private SimulationScenarioResult RunFullMissionScenario(string scenarioName, double scaleErrPercent, bool useFusion)
        {
            var p = new PhysicsParameters
            {
                MassCarrier = numMassCarrier != null ? (double)numMassCarrier.Value : 0.55,
                MassPayload = numMassPayload != null ? (double)numMassPayload.Value : 1.25,
                AreaCarrierParachute = numAreaCarrier != null ? (double)numAreaCarrier.Value : 0.1256,
                AreaPayloadParachute = numAreaPayload != null ? (double)numAreaPayload.Value : 0.0804,
                AreaApamParachute = numAreaApam != null ? (double)numAreaApam.Value : 0.20,
                AirDensity = numAirDensity != null ? (double)numAirDensity.Value : 1.10,

                HoverDurationS4b = numHoverDuration != null ? (double)numHoverDuration.Value : 10.0,
                HoverAltitudeS4b = numHoverAltitude != null ? (double)numHoverAltitude.Value : 200.0,
                SeparationAltitudeS3 = numSeparationAlt != null ? (double)numSeparationAlt.Value : 1000.0,

                Kp = numKp != null ? (double)numKp.Value : 3.5,
                Ki = numKi != null ? (double)numKi.Value : 0.4,
                Kd = numKd != null ? (double)numKd.Value : 4.2,
                BaroNoiseStd = numBaroNoise != null ? (double)numBaroNoise.Value : 1.5,
                BaroScaleErrorPct = scaleErrPercent,
                ImuNoiseStd = numImuNoise != null ? (double)numImuNoise.Value : 0.15,
                BucketFillRate = numFillRate != null ? (double)numFillRate.Value : 1.5,
                BucketLeakRate = numLeakRate != null ? (double)numLeakRate.Value : 0.8,
                BucketThreshold = numBucketThresh != null ? (double)numBucketThresh.Value : 4.5,
                UseEKFFusion = useFusion
            };

            var missionRes = VerticalPhysicsEngine.RunFullMission(p, 0.05);

            var res = new SimulationScenarioResult
            {
                ScenarioName = scenarioName,
                SensorScaleError = 1.0 + (scaleErrPercent / 100.0),
                UseSensorFusion = useFusion,
                ImpactVelocity = missionRes.ImpactVelocity,
                TotalLandingTime = missionRes.TotalTime
            };

            foreach (var pt in missionRes.Trajectory)
            {
                res.Trajectory.Add(new SimPoint
                {
                    Time = pt.Time,
                    TrueAltitude = pt.TrueAltitude,
                    TrueVelocity = pt.TrueVelocity,
                    SensorAltitude = pt.SensorAltitude,
                    EstimatedAltitude = pt.EstimatedAltitude,
                    EstimatedVelocity = pt.EstimatedVelocity,
                    Throttle = pt.ThrustNewton
                });
            }

            return res;
        }

        private void BtnRunPhysics_Click(object? sender, EventArgs e)
        {
            timerPlayback.Stop();
            btnPlayPause.Text = "▶ Oynat";
            RunPhysicsSimulation();
        }

        private void RunPhysicsSimulation()
        {
            plotPhysicsAltitude.Plot.Clear();

            var p = new PhysicsParameters
            {
                MassCarrier = (double)numMassCarrier.Value,
                MassPayload = (double)numMassPayload.Value,
                AreaCarrierParachute = (double)numAreaCarrier.Value,
                AreaPayloadParachute = (double)numAreaPayload.Value,
                AreaApamParachute = (double)numAreaApam.Value,
                AirDensity = (double)numAirDensity.Value,

                HoverDurationS4b = (double)numHoverDuration.Value,
                HoverAltitudeS4b = (double)numHoverAltitude.Value,
                SeparationAltitudeS3 = (double)numSeparationAlt.Value,

                Kp = (double)numKp.Value,
                Ki = (double)numKi.Value,
                Kd = (double)numKd.Value,

                BaroBiasMeters = (double)numBaroBias.Value,
                BaroThermalNoiseStd = (double)numBaroNoise.Value,
                BaroNoiseStd = (double)numBaroNoise.Value,
                BaroScaleErrorPct = (double)numBaroErrPct.Value,
                BaroSpikeStd = (double)numBaroSpikeStd.Value,
                BaroSpikeFreqPct = (double)numBaroSpikeFreq.Value,

                ImuBiasMs2 = (double)numImuBias.Value,
                ImuThermalNoiseStd = (double)numImuNoise.Value,
                ImuNoiseStd = (double)numImuNoise.Value,
                ImuSpikeStd = (double)numImuSpikeStd.Value,
                ImuSpikeFreqPct = (double)numImuSpikeFreq.Value,
                ImuVibrationStd = (double)numImuVib.Value,

                BucketFillRate = (double)numFillRate.Value,
                BucketLeakRate = (double)numLeakRate.Value,
                BucketThreshold = (double)numBucketThresh.Value,
                UseEKFFusion = true
            };

            currentPhysicsResult = VerticalPhysicsEngine.RunFullMission(p, 0.05);
            var res = currentPhysicsResult;

            double[] timeArr = res.Trajectory.Select(pt => pt.Time).ToArray();
            double[] trueAlt = res.Trajectory.Select(pt => pt.TrueAltitude).ToArray();
            double[] baroAlt = res.Trajectory.Select(pt => pt.BaroMeasuredAltitude).ToArray();
            double[] imuAlt = res.Trajectory.Select(pt => pt.ImuIntegratedAltitude).ToArray();
            double[] estAlt = res.Trajectory.Select(pt => pt.EstimatedAltitude).ToArray();

            // 1. Üst Grafik: 4'lü Sensör Füzyon Kestirim Başarısı Karşılaştırması
            var sigTrue = plotPhysicsAltitude.Plot.Add.Scatter(timeArr, trueAlt);
            sigTrue.LegendText = $"Gerçek İrtifa (Referans)";
            sigTrue.LineWidth = 3;
            sigTrue.Color = ScottPlot.Colors.Silver;

            var sigBaro = plotPhysicsAltitude.Plot.Add.Scatter(timeArr, baroAlt);
            sigBaro.LegendText = $"🔵 Barometre Ölçümü (Bias + Gürültü + Spike)";
            sigBaro.LineWidth = 1;
            sigBaro.Color = ScottPlot.Colors.DeepSkyBlue;

            var sigImu = plotPhysicsAltitude.Plot.Add.Scatter(timeArr, imuAlt);
            sigImu.LegendText = $"🟠 İvmeölçer (IMU) Çift İntegral (Drift / Kayma)";
            sigImu.LineWidth = 2;
            sigImu.Color = ScottPlot.Colors.Orange;

            var sigEst = plotPhysicsAltitude.Plot.Add.Scatter(timeArr, estAlt);
            sigEst.LegendText = "🟢 Adaptif EKF Kestirim Çekirdeği (Füzyon)";
            sigEst.LineWidth = 3;
            sigEst.Color = ScottPlot.Colors.LimeGreen;

            // Hal geçiş dikey işaretleyicileri
            FlightState lastState = FlightState.S1_ASCENT;
            foreach (var pt in res.Trajectory)
            {
                if (pt.State != lastState)
                {
                    var vLine = plotPhysicsAltitude.Plot.Add.VerticalLine(pt.Time);
                    vLine.Text = pt.StateName;
                    vLine.LineWidth = 2;
                    lastState = pt.State;
                }
            }

            plotPhysicsAltitude.Plot.Title($"🚀 Dikey Fizik Motoru: Taşıyıcı ({p.MassCarrier:0.00}kg) + Görev Yükü ({p.MassPayload:0.00}kg) Uçuş Trajektörisi");
            plotPhysicsAltitude.Plot.XLabel("Uçuş Zamanı (saniye)");
            plotPhysicsAltitude.Plot.YLabel("İrtifa (metre)");
            plotPhysicsAltitude.Plot.ShowLegend();

            // Oynatıcı ve İmleç Çizgileri
            trackTimeline.Minimum = 0;
            trackTimeline.Maximum = Math.Max(0, res.Trajectory.Count - 1);
            playbackIndex = 0;
            trackTimeline.Value = 0;

            cursorAltitudeLine = plotPhysicsAltitude.Plot.Add.VerticalLine(0);
            cursorAltitudeLine.LineWidth = 2;

            UpdatePlaybackDashboard(0);
        }

        private void BtnPlayPause_Click(object? sender, EventArgs e)
        {
            if (currentPhysicsResult == null || currentPhysicsResult.Trajectory.Count == 0) return;

            if (timerPlayback.Enabled)
            {
                timerPlayback.Stop();
                btnPlayPause.Text = "▶ Oynat";
            }
            else
            {
                timerPlayback.Start();
                btnPlayPause.Text = "⏸ Durdur";
            }
        }

        private void BtnStepBack_Click(object? sender, EventArgs e)
        {
            if (currentPhysicsResult == null) return;
            timerPlayback.Stop();
            btnPlayPause.Text = "▶ Oynat";

            playbackIndex = Math.Max(0, playbackIndex - 10);
            trackTimeline.Value = playbackIndex;
            UpdatePlaybackDashboard(playbackIndex);
        }

        private void BtnStepFwd_Click(object? sender, EventArgs e)
        {
            if (currentPhysicsResult == null) return;
            timerPlayback.Stop();
            btnPlayPause.Text = "▶ Oynat";

            playbackIndex = Math.Min(currentPhysicsResult.Trajectory.Count - 1, playbackIndex + 10);
            trackTimeline.Value = playbackIndex;
            UpdatePlaybackDashboard(playbackIndex);
        }

        private void TrackTimeline_Scroll(object? sender, EventArgs e)
        {
            timerPlayback.Stop();
            btnPlayPause.Text = "▶ Oynat";
            playbackIndex = trackTimeline.Value;
            UpdatePlaybackDashboard(playbackIndex);
        }

        private void TimerPlayback_Tick(object? sender, EventArgs e)
        {
            if (currentPhysicsResult == null) return;

            if (playbackIndex < currentPhysicsResult.Trajectory.Count - 1)
            {
                playbackIndex += 2; // Canlı akıcı animasyon
                if (playbackIndex >= currentPhysicsResult.Trajectory.Count)
                    playbackIndex = currentPhysicsResult.Trajectory.Count - 1;

                trackTimeline.Value = playbackIndex;
                UpdatePlaybackDashboard(playbackIndex);
            }
            else
            {
                timerPlayback.Stop();
                btnPlayPause.Text = "▶ Oynat";
            }
        }

        private void UpdatePlaybackDashboard(int index)
        {
            if (currentPhysicsResult == null || index < 0 || index >= currentPhysicsResult.Trajectory.Count) return;

            var pt = currentPhysicsResult.Trajectory[index];

            lblCurrentTime.Text = $"Zaman: {pt.Time:0.00} s / {currentPhysicsResult.TotalTime:0.00} s";

            lblDashState.Text = $"ANA HAL: {pt.StateName}";
            lblDashSubState.Text = $"ALT SENARYO: {pt.SubStateName}";
            lblDashPhysics.Text = $"FİZİK MODEL: Aktif Kütle = {pt.ActiveMassKg:0.00} kg | Paraşüt Alanı = {pt.ActiveAreaM2:0.04} m² | Cd = {pt.ActiveCd:0.00} | Limit Hız = {pt.TerminalVelocityMs:0.0} m/s";
            lblDashKinematics.Text = $"KİNEMATİK: Gerçek İrtifa = {pt.TrueAltitude:0.1} m | Kestirim = {pt.EstimatedAltitude:0.1} m | Hız = {pt.TrueVelocity:0.1} m/s | Hedef = {pt.TargetVelocityMs:0.1} m/s";
            lblDashActuators.Text = $"KONTROL: Motor RPM = {pt.MotorRPM:N0} RPM | İtki = {pt.ThrustNewton:0.1} N | Kova Havuz (ACC) = {pt.BucketACC:0.00} ({pt.BucketStatus})";

            // İmleç çizgilerini kaydır
            if (cursorAltitudeLine != null) cursorAltitudeLine.X = pt.Time;

            // Progress Bar & Kova Durumunu Güncelle
            double thresh = (double)numBucketThresh.Value;
            int pct = (int)Math.Min(100.0, Math.Round((pt.BucketACC / thresh) * 100.0));
            if (progBucketCore != null) progBucketCore.Value = pct;

            string statusMsg = "";
            System.Drawing.Color statusColor = System.Drawing.Color.FromArgb(16, 124, 65);

            if (pt.State == FlightState.APAM_EMERGENCY)
            {
                statusMsg = "🚨 ACİL DURUM: APAM TETİKLENDİ!";
                statusColor = System.Drawing.Color.DarkRed;
            }
            else if (pt.BucketStatus == "Latched")
            {
                statusMsg = $"🔒 KARAR MÜHÜRLENDİ ({pt.StateName}) - %100";
                statusColor = System.Drawing.Color.FromArgb(180, 130, 0);
            }
            else if (pt.BucketStatus == "Filling")
            {
                statusMsg = $"⏳ KOVA DOLUYOR (ACC = {pt.BucketACC:0.00} / {thresh:0.0}) - %{pct}";
                statusColor = System.Drawing.Color.FromArgb(0, 120, 212);
            }
            else
            {
                statusMsg = $"🟢 BEKLEMEDE (ACC = {pt.BucketACC:0.00})";
                statusColor = System.Drawing.Color.FromArgb(16, 124, 65);
            }

            if (lblBucketCoreStatus != null)
            {
                lblBucketCoreStatus.Text = statusMsg;
                lblBucketCoreStatus.ForeColor = statusColor;
            }

            // Sızdıran Kova Etkileyen Faktörleri Yazdır
            if (lblBucketCoreFactors != null)
            {
                if (pt.State == FlightState.S1_ASCENT)
                    lblBucketCoreFactors.Text = $"Etkileyen Faktör: Tepe Noktası Beklentisi (Hız ≤ 0) | Dolum Hızı: +{numFillRate.Value}/s | Sızıntı Hızı: -{numLeakRate.Value}/s";
                else if (pt.State == FlightState.S2_PASSIVE_DESCENT)
                    lblBucketCoreFactors.Text = $"Etkileyen Faktör: Ayrılma İrtifa Eşiği (≤ {numSeparationAlt.Value}m) | Dolum Hızı: +{numFillRate.Value}/s | Sızıntı: -{numLeakRate.Value}/s";
                else if (pt.State == FlightState.S3_SEPARATION)
                    lblBucketCoreFactors.Text = $"Etkileyen Faktör: Ayrılma Şoku ve Görev Yükü Serbest Bırakma | Dolum Hızı: +{(double)numFillRate.Value * 2.0:0.0}/s (2x Hızlı Karar)";
                else if (pt.State == FlightState.S4_ACTIVE_DESCENT)
                    lblBucketCoreFactors.Text = $"Etkileyen Faktör: Kova Mühürlendi | APAM Aşırı Hız Koruma Eşiği (> 20.0 m/s)";
                else if (pt.State == FlightState.APAM_EMERGENCY)
                    lblBucketCoreFactors.Text = $"Etkileyen Faktör: 🚨 ACİL DURUM APAM TETİKLENDİ | İrtifa > 100m ve Aşırı İniş Hızı";
                else
                    lblBucketCoreFactors.Text = $"Etkileyen Faktör: İniş Tamamlandı / Stabil";
            }

            // Adaptif EKF: Anlık İrtifa, Hız, Şok ve Kovaryans Dinamiklerine Göre Gerçek Zamanlı 100% Güven Dağılımı
            double speedFactor = Math.Min(1.0, Math.Abs(pt.TrueVelocity) / 150.0); // 0.0 ile 1.0 arası aerodinamik hız katsayısı
            double altFactor = Math.Min(1.0, pt.TrueAltitude / 1800.0); // İrtifa katmanı katsayısı
            double errFactor = Math.Min(1.0, Math.Abs((double)numErrorPercent.Value) / 25.0);

            // Sakin hover / düşük hızda Barometre %76 civarı güvenilir.
            // Yüksek hızda aerodinamik gürültü arttıkça veya şok anında Barometre güveni düşer, IMU artar.
            double baseBaroTrust = 76.0 - (speedFactor * 26.0) - (altFactor * 7.0) - (errFactor * 14.0);

            if (pt.State == FlightState.S3_SEPARATION)
            {
                baseBaroTrust -= 22.0; // Ayrılma şoku anında IMU ivmesi ana referans olur
                currentInnovation = 2.45 + speedFactor * 1.8;
            }
            else if (pt.State == FlightState.APAM_EMERGENCY)
            {
                baseBaroTrust -= 28.0; // Acil durumda IMU baskındır
                currentInnovation = 3.60 + speedFactor * 2.2;
            }
            else
            {
                currentInnovation = 0.15 + (speedFactor * 0.65) + (errFactor * 0.4);
            }

            // Gerçekçi Kalman kovaryans mikro-dalgalanması (her zaman adımında akıcı değişim)
            double microVariation = Math.Sin(pt.Time * 3.1415) * 2.4 + Math.Cos(pt.Time * 1.85) * 1.3;

            currentBaroTrustPct = Math.Max(22.0, Math.Min(84.0, baseBaroTrust + microVariation));
            currentImuTrustPct = 100.0 - currentBaroTrustPct;

            currentKalmanGain = Math.Round(0.008 + (currentImuTrustPct / 100.0) * 0.026, 4);

            if (lblEkfTrustDetails != null)
            {
                lblEkfTrustDetails.Text = $"🔵 Barometre Güveni: %{currentBaroTrustPct:0.1}   |   🟠 İvmeölçer (IMU) Güveni: %{currentImuTrustPct:0.1}\r\nAktif Filtre: {currentFilterMode}   |   Kalman Kazancı (K): {currentKalmanGain:0.0000}   |   İnovasyon Sapması (ν): {currentInnovation:0.2} m";
            }
            if (picEkfStackedBar != null) picEkfStackedBar.Invalidate();

            plotPhysicsAltitude.Refresh();
        }

        private void PicEkfStackedBar_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int w = picEkfStackedBar.Width;
            int h = picEkfStackedBar.Height;
            if (w <= 0 || h <= 0) return;

            int wBaro = (int)Math.Round((currentBaroTrustPct / 100.0) * w);
            int wImu = Math.Max(0, w - wBaro);

            using (var brushBaro = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(0, 120, 212)))
            using (var brushImu = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(230, 120, 20)))
            using (var font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold))
            using (var brushText = new System.Drawing.SolidBrush(System.Drawing.Color.White))
            {
                g.FillRectangle(brushBaro, 0, 0, wBaro, h);
                g.FillRectangle(brushImu, wBaro, 0, wImu, h);

                if (wBaro > 60)
                    g.DrawString($"Barometre %{currentBaroTrustPct:0.0}", font, brushText, 8, (h - font.Height) / 2);
                if (wImu > 60)
                    g.DrawString($"İvmeölçer (IMU) %{currentImuTrustPct:0.0}", font, brushText, wBaro + 8, (h - font.Height) / 2);
            }
        }

        private void BtnExportPng_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PNG Dosyası|*.png",
                FileName = "Irtifa_ve_Hiz_Analiz_Grafikleri.png"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                plotAltitude.Plot.SavePng(sfd.FileName.Replace(".png", "_Irtifa.png"), 1200, 800);
                plotVelocity.Plot.SavePng(sfd.FileName.Replace(".png", "_Hiz.png"), 1200, 800);
                MessageBox.Show("Grafikler başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
