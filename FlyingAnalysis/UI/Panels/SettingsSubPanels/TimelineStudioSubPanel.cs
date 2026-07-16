using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.WinForms;
using Color = System.Drawing.Color;
using FlyingAnalysis.Models;
using FlyingAnalysis.Models.Timeline;
using FlyingAnalysis.Services;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    public partial class TimelineStudioSubPanel : UserControl
    {
        private readonly TimelineSimulationEngine _engine = new TimelineSimulationEngine();
        private List<TimelineSimulationFrame> _simulationFrames = new List<TimelineSimulationFrame>();
        private List<TimelineEventItem> _events = new List<TimelineEventItem>();

        private ScottPlot.Plottables.VerticalLine? _vlinePos;
        private ScottPlot.Plottables.VerticalLine? _vlineVel;
        private ScottPlot.Plottables.VerticalLine? _vlineAcc;

        private double _simulationDuration = 30.0;
        private bool _isPlaying = false;

        public TimelineStudioSubPanel()
        {
            InitializeComponent();
            SetupInitialEventsAndCharts();
            SetupEventHandlers();
        }

        private void SetupInitialEventsAndCharts()
        {
            cmbPhysicsFreqHz.SelectedIndex = 3; // 100 Hz varsayılan
            cmbEventType.SelectedIndex = 0;     // Dış Kuvvet

            // Örnek başlangıç olayları (0 metreden kalkış için roket itkisi ve şok)
            _events.Add(new TimelineEventItem("Roket İtkisi (Kalkış)", TimelineEventType.Force, 1.0, 8.0, 35.0, 35.0, Color.FromArgb(245, 158, 11)));
            _events.Add(new TimelineEventItem("Ayrılma Şoku", TimelineEventType.SpecialConditionNoise, 8.2, 9.5, 8.0, 3.0, Color.FromArgb(139, 92, 246)));

            timelineControl.SetEvents(_events);

            // ScottPlot Tuval Ayarları
            SetupChartStyle(plotPosition, "1. KONUM - ZAMAN GRAFİĞİ (İrtifa vs Zaman)", "Zaman [s]", "İrtifa [m]");
            SetupChartStyle(plotVelocity, "2. HIZ - ZAMAN GRAFİĞİ", "Zaman [s]", "Hız [m/s]");
            SetupChartStyle(plotAcceleration, "3. İVME - ZAMAN GRAFİĞİ", "Zaman [s]", "İvme [m/s²]");

            // İlk simülasyonu çalıştır
            RunAndRefreshSimulation();
        }

        private void SetupChartStyle(FormsPlot plot, string title, string xLabel, string yLabel)
        {
            plot.Plot.Title(title);
            plot.Plot.XLabel(xLabel);
            plot.Plot.YLabel(yLabel);
            plot.Refresh();
        }

        private void SetupEventHandlers()
        {
            btnRunSimulation.Click += (s, e) => RunAndRefreshSimulation();

            btnPlay.Click += (s, e) =>
            {
                _isPlaying = true;
                timerPlayback.Start();
            };

            btnPause.Click += (s, e) =>
            {
                _isPlaying = false;
                timerPlayback.Stop();
            };

            btnReset.Click += (s, e) =>
            {
                _isPlaying = false;
                timerPlayback.Stop();
                timelineControl.CurrentPlayheadTime = 0.0;
                OnPlayheadChanged(0.0);
            };

            timerPlayback.Tick += (s, e) =>
            {
                if (!_isPlaying) return;
                double nextTime = timelineControl.CurrentPlayheadTime + 0.04; // 25 FPS
                if (nextTime > _simulationDuration)
                {
                    nextTime = 0.0; // Başa sar
                }
                timelineControl.CurrentPlayheadTime = nextTime;
                OnPlayheadChanged(nextTime);
            };

            timelineControl.PlayheadTimeChanged += (s, time) =>
            {
                OnPlayheadChanged(time);
            };

            btnAddEvent.Click += BtnAddEvent_Click;
            btnDeleteSelectedEvent.Click += (s, e) =>
            {
                timelineControl.DeleteSelectedEvent();
            };
            btnClearEvents.Click += (s, e) =>
            {
                _events.Clear();
                timelineControl.SetEvents(_events);
                RunAndRefreshSimulation();
            };

            timelineControl.EventsModified += (s, e) =>
            {
                RunAndRefreshSimulation();
            };

            btnOpenChartSettings.Click += (s, e) =>
            {
                using var dlg = new Form
                {
                    Text = "🎨 Grafik Katman, Renk ve Sıralama Ayarları",
                    Size = new Size(500, 520),
                    StartPosition = FormStartPosition.CenterParent,
                    BackColor = Color.FromArgb(30, 41, 59),
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };
                var panel = new ChartLayerSettingsSubPanel { Dock = DockStyle.Fill };
                dlg.Controls.Add(panel);
                dlg.ShowDialog();
            };

            GlobalSimulationConfig.OnChartStylingChanged += () =>
            {
                UpdateChartOrderLayout();
                PlotAllCharts();
                OnPlayheadChanged(timelineControl.CurrentPlayheadTime);
            };

            cmbEventType.SelectedIndexChanged += (s, e) =>
            {
                bool isForceOrNoise = cmbEventType.SelectedIndex == 0 || cmbEventType.SelectedIndex == 2;
                lblStartVal.Visible = isForceOrNoise;
                numStartVal.Visible = isForceOrNoise;
                lblEndVal.Visible = isForceOrNoise;
                numEndVal.Visible = isForceOrNoise;

                if (cmbEventType.SelectedIndex == 0)
                {
                    lblStartVal.Text = "Baş [N]:";
                    lblEndVal.Text = "Bit [N]:";
                }
                else if (cmbEventType.SelectedIndex == 2)
                {
                    lblStartVal.Text = "Baş [±σ]:";
                    lblEndVal.Text = "Bit [±σ]:";
                }
            };

            // Görünüm Modları Butonları
            btnViewProportional.Click += (s, e) => SetViewMode(ViewMode.Proportional);
            btnViewPosOnly.Click += (s, e) => SetViewMode(ViewMode.PosOnly);
            btnViewVelOnly.Click += (s, e) => SetViewMode(ViewMode.VelOnly);
            btnViewAccOnly.Click += (s, e) => SetViewMode(ViewMode.AccOnly);
        }

        private enum ViewMode { Proportional, PosOnly, VelOnly, AccOnly }

        private void SetViewMode(ViewMode mode)
        {
            tlpMainCharts.SuspendLayout();
            tlpBottomRow.SuspendLayout();

            if (!tlpMainCharts.Controls.Contains(tlpBottomRow))
            {
                tlpMainCharts.Controls.Remove(plotPosition);
                tlpMainCharts.Controls.Remove(plotVelocity);
                tlpMainCharts.Controls.Remove(plotAcceleration);
                tlpMainCharts.Controls.Remove(grpSuccessConsole);
                tlpMainCharts.Controls.Remove(grpLiveForceDiagram);

                tlpMainCharts.RowCount = 2;
                while (tlpMainCharts.RowStyles.Count < 2) tlpMainCharts.RowStyles.Add(new RowStyle());
                tlpMainCharts.Controls.Add(plotPosition, 0, 0);
                tlpMainCharts.Controls.Add(tlpBottomRow, 0, 1);
                tlpBottomRow.Controls.Add(grpSuccessConsole, 0, 0);
                tlpBottomRow.Controls.Add(plotVelocity, 1, 0);
                tlpBottomRow.Controls.Add(plotAcceleration, 2, 0);
                tlpBottomRow.Controls.Add(grpLiveForceDiagram, 3, 0);
            }

            switch (mode)
            {
                case ViewMode.Proportional:
                    tlpMainCharts.RowStyles[0] = new RowStyle(SizeType.Percent, 65f);
                    tlpMainCharts.RowStyles[1] = new RowStyle(SizeType.Percent, 35f);
                    plotPosition.Visible = true;
                    tlpBottomRow.Visible = true;
                    grpSuccessConsole.Visible = true;
                    plotVelocity.Visible = true;
                    plotAcceleration.Visible = true;
                    grpLiveForceDiagram.Visible = true;
                    break;
                case ViewMode.PosOnly:
                    tlpMainCharts.RowStyles[0] = new RowStyle(SizeType.Percent, 100f);
                    tlpMainCharts.RowStyles[1] = new RowStyle(SizeType.Percent, 0f);
                    plotPosition.Visible = true;
                    tlpBottomRow.Visible = false;
                    break;
                case ViewMode.VelOnly:
                    tlpMainCharts.RowStyles[0] = new RowStyle(SizeType.Percent, 0f);
                    tlpMainCharts.RowStyles[1] = new RowStyle(SizeType.Percent, 100f);
                    plotPosition.Visible = false;
                    tlpBottomRow.Visible = true;
                    while (tlpBottomRow.ColumnStyles.Count < 4) tlpBottomRow.ColumnStyles.Add(new ColumnStyle());
                    tlpBottomRow.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 0f);
                    tlpBottomRow.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 100f);
                    tlpBottomRow.ColumnStyles[2] = new ColumnStyle(SizeType.Percent, 0f);
                    tlpBottomRow.ColumnStyles[3] = new ColumnStyle(SizeType.Percent, 0f);
                    grpSuccessConsole.Visible = false;
                    plotVelocity.Visible = true;
                    plotAcceleration.Visible = false;
                    grpLiveForceDiagram.Visible = false;
                    break;
                case ViewMode.AccOnly:
                    tlpMainCharts.RowStyles[0] = new RowStyle(SizeType.Percent, 0f);
                    tlpMainCharts.RowStyles[1] = new RowStyle(SizeType.Percent, 100f);
                    plotPosition.Visible = false;
                    tlpBottomRow.Visible = true;
                    while (tlpBottomRow.ColumnStyles.Count < 4) tlpBottomRow.ColumnStyles.Add(new ColumnStyle());
                    tlpBottomRow.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 0f);
                    tlpBottomRow.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 0f);
                    tlpBottomRow.ColumnStyles[2] = new ColumnStyle(SizeType.Percent, 100f);
                    tlpBottomRow.ColumnStyles[3] = new ColumnStyle(SizeType.Percent, 0f);
                    grpSuccessConsole.Visible = false;
                    plotVelocity.Visible = false;
                    plotAcceleration.Visible = true;
                    grpLiveForceDiagram.Visible = false;
                    break;
            }
            if (mode == ViewMode.Proportional)
            {
                while (tlpBottomRow.ColumnStyles.Count < 4) tlpBottomRow.ColumnStyles.Add(new ColumnStyle());
                tlpBottomRow.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 25f);
                tlpBottomRow.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 25f);
                tlpBottomRow.ColumnStyles[2] = new ColumnStyle(SizeType.Percent, 25f);
                tlpBottomRow.ColumnStyles[3] = new ColumnStyle(SizeType.Percent, 25f);
            }

            tlpBottomRow.ResumeLayout();
            tlpMainCharts.ResumeLayout();
        }

        private void UpdateSuccessConsole()
        {
            if (_simulationFrames == null || _simulationFrames.Count == 0) return;

            // --- İRTİFA METRİKLERİ ---
            double rmseHamPos = Math.Sqrt(_simulationFrames.Average(f => Math.Pow(f.RawBaroPosition - f.TruePosition, 2)));
            double biasHamPos = Math.Abs(_simulationFrames.Average(f => f.RawBaroPosition - f.TruePosition));
            double stdHamPos = Math.Sqrt(_simulationFrames.Average(f => Math.Pow((f.RawBaroPosition - f.TruePosition) - (_simulationFrames.Average(x => x.RawBaroPosition - x.TruePosition)), 2)));

            double rmseCalPos = Math.Sqrt(_simulationFrames.Average(f => Math.Pow(f.CalibratedBaroPosition - f.TruePosition, 2)));
            double biasCalPos = Math.Abs(_simulationFrames.Average(f => f.CalibratedBaroPosition - f.TruePosition));
            double stdCalPos = Math.Sqrt(_simulationFrames.Average(f => Math.Pow((f.CalibratedBaroPosition - f.TruePosition) - (_simulationFrames.Average(x => x.CalibratedBaroPosition - x.TruePosition)), 2)));

            double rmseEkfPos = Math.Sqrt(_simulationFrames.Average(f => Math.Pow(f.EstimatedPosition - f.TruePosition, 2)));
            double biasEkfPos = Math.Abs(_simulationFrames.Average(f => f.EstimatedPosition - f.TruePosition));
            double stdEkfPos = Math.Sqrt(_simulationFrames.Average(f => Math.Pow((f.EstimatedPosition - f.TruePosition) - (_simulationFrames.Average(x => x.EstimatedPosition - x.TruePosition)), 2)));

            double posTruenessRatio = (biasHamPos > 1e-6) ? (1.0 - (biasCalPos / biasHamPos)) * 100.0 : 100.0;
            double posPrecisionRatio = (stdHamPos > 1e-6) ? (1.0 - (stdEkfPos / stdHamPos)) * 100.0 : 100.0;
            double posRmseRatio = (rmseHamPos > 1e-6) ? (1.0 - (rmseEkfPos / rmseHamPos)) * 100.0 : 100.0;

            // --- İVME METRİKLERİ ---
            double rmseHamAcc = Math.Sqrt(_simulationFrames.Average(f => Math.Pow(f.RawAcceleration - f.TrueAcceleration, 2)));
            double biasHamAcc = Math.Abs(_simulationFrames.Average(f => f.RawAcceleration - f.TrueAcceleration));
            double stdHamAcc = Math.Sqrt(_simulationFrames.Average(f => Math.Pow((f.RawAcceleration - f.TrueAcceleration) - (_simulationFrames.Average(x => x.RawAcceleration - x.TrueAcceleration)), 2)));

            double rmseCalAcc = Math.Sqrt(_simulationFrames.Average(f => Math.Pow(f.CalibratedAcceleration - f.TrueAcceleration, 2)));
            double biasCalAcc = Math.Abs(_simulationFrames.Average(f => f.CalibratedAcceleration - f.TrueAcceleration));
            double stdCalAcc = Math.Sqrt(_simulationFrames.Average(f => Math.Pow((f.CalibratedAcceleration - f.TrueAcceleration) - (_simulationFrames.Average(x => x.CalibratedAcceleration - x.TrueAcceleration)), 2)));

            double rmseEkfAcc = Math.Sqrt(_simulationFrames.Average(f => Math.Pow(f.EstimatedAcceleration - f.TrueAcceleration, 2)));
            double biasEkfAcc = Math.Abs(_simulationFrames.Average(f => f.EstimatedAcceleration - f.TrueAcceleration));
            double stdEkfAcc = Math.Sqrt(_simulationFrames.Average(f => Math.Pow((f.EstimatedAcceleration - f.TrueAcceleration) - (_simulationFrames.Average(x => x.EstimatedAcceleration - x.TrueAcceleration)), 2)));

            double accTruenessRatio = (biasHamAcc > 1e-6) ? (1.0 - (biasCalAcc / biasHamAcc)) * 100.0 : 100.0;
            double accPrecisionRatio = (stdHamAcc > 1e-6) ? (1.0 - (stdEkfAcc / stdHamAcc)) * 100.0 : 100.0;
            double accRmseRatio = (rmseHamAcc > 1e-6) ? (1.0 - (rmseEkfAcc / rmseHamAcc)) * 100.0 : 100.0;

            string ascii =
                $" === METROLOJİK HATA & GÜRÜLTÜ ANALİZİ ===\r\n" +
                $" [ İRTİFA (Baro -> Kalibre -> EKF) ]\r\n" +
                $" Ham RMSE    : {rmseHamPos:F2} m (Bias: {biasHamPos:F2}, σ: ±{stdHamPos:F2})\r\n" +
                $" Kalibre RMSE: {rmseCalPos:F2} m | Doğruluk İyileşmesi: %{Math.Max(0, posTruenessRatio):F1}\r\n" +
                $" EKF RMSE    : {rmseEkfPos:F2} m | Kesinlik Süzme    : %{Math.Max(0, posPrecisionRatio):F1}\r\n" +
                $" -> TOPLAM İRTİFA BAŞARISI (RMSE) : %{Math.Max(0, posRmseRatio):F1}\r\n" +
                $"--------------------------------------------\r\n" +
                $" [ İVME (IMU -> Kalibre -> EKF) ]\r\n" +
                $" Ham RMSE    : {rmseHamAcc:F2} m/s² (Bias: {biasHamAcc:F2}, σ: ±{stdHamAcc:F2})\r\n" +
                $" Kalibre RMSE: {rmseCalAcc:F2} m/s²| Doğruluk İyileşmesi: %{Math.Max(0, accTruenessRatio):F1}\r\n" +
                $" EKF RMSE    : {rmseEkfAcc:F2} m/s²| Kesinlik Süzme    : %{Math.Max(0, accPrecisionRatio):F1}\r\n" +
                $" -> TOPLAM İVME BAŞARISI (RMSE)   : %{Math.Max(0, accRmseRatio):F1}";

            lblSuccessConsole.Text = ascii;
        }

        private void UpdateChartOrderLayout()
        {
            // Kullanıcının talebi üzerine: Sayfa düzenini bozan grafik satır kaydırma özelliği tamamen kaldırıldı.
            // tlpMainCharts ve tlpBottomRow yerleşimi sabit korunuyor.
        }

        private void BtnAddEvent_Click(object? sender, EventArgs e)
        {
            string label = string.IsNullOrWhiteSpace(txtEventLabel.Text) ? "Olay" : txtEventLabel.Text.Trim();
            double start = (double)numStartTime.Value;
            double end = (double)numEndTime.Value;
            if (end < start) end = start + 1.0;

            TimelineEventType type = TimelineEventType.Force;
            Color color = Color.FromArgb(245, 158, 11); // Sarı

            if (cmbEventType.SelectedIndex == 1)
            {
                type = TimelineEventType.SensorCutoff;
                color = Color.FromArgb(239, 68, 68); // Kırmızı
            }
            else if (cmbEventType.SelectedIndex == 2)
            {
                type = TimelineEventType.SpecialConditionNoise;
                color = Color.FromArgb(139, 92, 246); // Mor
            }

            double sVal = (double)numStartVal.Value;
            double eVal = (double)numEndVal.Value;

            _events.Add(new TimelineEventItem(label, type, start, end, sVal, eVal, color));
            timelineControl.SetEvents(_events);
            RunAndRefreshSimulation();
        }

        private void RunAndRefreshSimulation()
        {
            double freqHz = 100.0;
            string? selStr = cmbPhysicsFreqHz.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selStr))
            {
                if (selStr.Contains("10 Hz")) freqHz = 10.0;
                else if (selStr.Contains("20 Hz")) freqHz = 20.0;
                else if (selStr.Contains("50 Hz")) freqHz = 50.0;
                else if (selStr.Contains("100 Hz")) freqHz = 100.0;
                else if (selStr.Contains("200 Hz")) freqHz = 200.0;
                else if (selStr.Contains("500 Hz")) freqHz = 500.0;
            }

            double initAlt = 0.0; // 0 m (Yerden Başlama) irtifası
            _simulationFrames = _engine.RunSimulation(_simulationDuration, freqHz, initAlt, _events);

            PlotAllCharts();
            OnPlayheadChanged(timelineControl.CurrentPlayheadTime);
        }

        private static ScottPlot.Color ToSpColor(System.Drawing.Color c) => new ScottPlot.Color(c.R, c.G, c.B, c.A);

        private void PlotAllCharts()
        {
            if (_simulationFrames.Count == 0) return;

            var profile = GlobalSimulationConfig.ChartProfile;
            double[] xs = _simulationFrames.Select(f => f.Time).ToArray();

            // 1. Konum Grafiği
            plotPosition.Plot.Clear();
            double[] posTrue = _simulationFrames.Select(f => f.TruePosition).ToArray();
            double[] posRaw = _simulationFrames.Select(f => f.RawBaroPosition).ToArray();
            double[] posCal = _simulationFrames.Select(f => f.CalibratedBaroPosition).ToArray();
            double[] posEst = _simulationFrames.Select(f => f.EstimatedPosition).ToArray();

            var posLayers = new List<(int Order, Action DrawAction)>();
            if (profile.PosTrue.Show)
            {
                posLayers.Add((profile.PosTrue.DrawOrder, () => {
                    var sPosTrue = plotPosition.Plot.Add.Scatter(xs, posTrue);
                    sPosTrue.LegendText = "Gerçek İrtifa";
                    sPosTrue.Color = ToSpColor(profile.PosTrue.Color);
                    sPosTrue.LineWidth = profile.PosTrue.LineWidth;
                    sPosTrue.MarkerSize = 0f;
                }));
            }
            if (profile.PosRaw.Show)
            {
                posLayers.Add((profile.PosRaw.DrawOrder, () => {
                    var sPosRaw = plotPosition.Plot.Add.Scatter(xs, posRaw);
                    sPosRaw.LegendText = "Ham Barometre";
                    sPosRaw.Color = ToSpColor(profile.PosRaw.Color);
                    sPosRaw.LineWidth = profile.PosRaw.LineWidth;
                    sPosRaw.MarkerSize = 2f;
                }));
            }
            if (profile.PosCal.Show)
            {
                posLayers.Add((profile.PosCal.DrawOrder, () => {
                    var sPosCal = plotPosition.Plot.Add.Scatter(xs, posCal);
                    sPosCal.LegendText = "Kalibre Barometre";
                    sPosCal.Color = ToSpColor(profile.PosCal.Color);
                    sPosCal.LineWidth = profile.PosCal.LineWidth;
                    sPosCal.MarkerSize = 0f;
                }));
            }
            if (profile.PosEst.Show)
            {
                posLayers.Add((profile.PosEst.DrawOrder, () => {
                    var sPosEst = plotPosition.Plot.Add.Scatter(xs, posEst);
                    sPosEst.LegendText = "Kalman Kestirim";
                    sPosEst.Color = ToSpColor(profile.PosEst.Color);
                    sPosEst.LineWidth = profile.PosEst.LineWidth;
                    sPosEst.MarkerSize = 0f;
                }));
            }
            foreach (var item in posLayers.OrderBy(x => x.Order)) item.DrawAction();

            _vlinePos = plotPosition.Plot.Add.VerticalLine(timelineControl.CurrentPlayheadTime);
            _vlinePos.Color = ScottPlot.Colors.Red;
            _vlinePos.LineWidth = 2f;

            plotPosition.Plot.ShowLegend();
            plotPosition.Refresh();

            // 2. Hız Grafiği
            plotVelocity.Plot.Clear();
            var velLayers = new List<(int Order, Action DrawAction)>();
            if (profile.VelTrue.Show)
            {
                velLayers.Add((profile.VelTrue.DrawOrder, () => {
                    double[] velTrue = _simulationFrames.Select(f => f.TrueVelocity).ToArray();
                    var sVelTrue = plotVelocity.Plot.Add.Scatter(xs, velTrue);
                    sVelTrue.LegendText = "Gerçek Hız";
                    sVelTrue.Color = ToSpColor(profile.VelTrue.Color);
                    sVelTrue.LineWidth = profile.VelTrue.LineWidth;
                    sVelTrue.MarkerSize = 0f;
                }));
            }
            if (profile.VelEst.Show)
            {
                velLayers.Add((profile.VelEst.DrawOrder, () => {
                    double[] velEst = _simulationFrames.Select(f => f.EstimatedVelocity).ToArray();
                    var sVelEst = plotVelocity.Plot.Add.Scatter(xs, velEst);
                    sVelEst.LegendText = "Kalman Kestirim Hız";
                    sVelEst.Color = ToSpColor(profile.VelEst.Color);
                    sVelEst.LineWidth = profile.VelEst.LineWidth;
                    sVelEst.MarkerSize = 0f;
                }));
            }
            foreach (var item in velLayers.OrderBy(x => x.Order)) item.DrawAction();

            _vlineVel = plotVelocity.Plot.Add.VerticalLine(timelineControl.CurrentPlayheadTime);
            _vlineVel.Color = ScottPlot.Colors.Red;
            _vlineVel.LineWidth = 2f;

            plotVelocity.Plot.ShowLegend();
            plotVelocity.Refresh();

            // 3. İvme Grafiği
            plotAcceleration.Plot.Clear();
            double[] accTrue = _simulationFrames.Select(f => f.TrueAcceleration).ToArray();
            double[] accRaw = _simulationFrames.Select(f => f.RawAcceleration).ToArray();
            double[] accCal = _simulationFrames.Select(f => f.CalibratedAcceleration).ToArray();
            double[] accEst = _simulationFrames.Select(f => f.EstimatedAcceleration).ToArray();

            var accLayers = new List<(int Order, Action DrawAction)>();
            if (profile.AccTrue.Show)
            {
                accLayers.Add((profile.AccTrue.DrawOrder, () => {
                    var sAccTrue = plotAcceleration.Plot.Add.Scatter(xs, accTrue);
                    sAccTrue.LegendText = "Gerçek İvme";
                    sAccTrue.Color = ToSpColor(profile.AccTrue.Color);
                    sAccTrue.LineWidth = profile.AccTrue.LineWidth;
                    sAccTrue.MarkerSize = 0f;
                }));
            }
            if (profile.AccRaw.Show)
            {
                accLayers.Add((profile.AccRaw.DrawOrder, () => {
                    var sAccRaw = plotAcceleration.Plot.Add.Scatter(xs, accRaw);
                    sAccRaw.LegendText = "Ham İvme";
                    sAccRaw.Color = ToSpColor(profile.AccRaw.Color);
                    sAccRaw.LineWidth = profile.AccRaw.LineWidth;
                    sAccRaw.MarkerSize = 1.5f;
                }));
            }
            if (profile.AccCal.Show)
            {
                accLayers.Add((profile.AccCal.DrawOrder, () => {
                    var sAccCal = plotAcceleration.Plot.Add.Scatter(xs, accCal);
                    sAccCal.LegendText = "Kalibre İvme";
                    sAccCal.Color = ToSpColor(profile.AccCal.Color);
                    sAccCal.LineWidth = profile.AccCal.LineWidth;
                    sAccCal.MarkerSize = 0f;
                }));
            }
            if (profile.AccEst.Show)
            {
                accLayers.Add((profile.AccEst.DrawOrder, () => {
                    var sAccEst = plotAcceleration.Plot.Add.Scatter(xs, accEst);
                    sAccEst.LegendText = "Kalman Kestirim İvme";
                    sAccEst.Color = ToSpColor(profile.AccEst.Color);
                    sAccEst.LineWidth = profile.AccEst.LineWidth;
                    sAccEst.MarkerSize = 0f;
                }));
            }
            foreach (var item in accLayers.OrderBy(x => x.Order)) item.DrawAction();

            _vlineAcc = plotAcceleration.Plot.Add.VerticalLine(timelineControl.CurrentPlayheadTime);
            _vlineAcc.Color = ScottPlot.Colors.Red;
            _vlineAcc.LineWidth = 2f;

            plotAcceleration.Plot.ShowLegend();
            plotAcceleration.Refresh();

            UpdateSuccessConsole();
        }

        private void OnPlayheadChanged(double time)
        {
            if (_vlinePos != null) _vlinePos.X = time;
            if (_vlineVel != null) _vlineVel.X = time;
            if (_vlineAcc != null) _vlineAcc.X = time;

            plotPosition.Refresh();
            plotVelocity.Refresh();
            plotAcceleration.Refresh();

            var frame = _simulationFrames.OrderBy(f => Math.Abs(f.Time - time)).FirstOrDefault();
            if (frame != null)
            {
                lblTimeDisplay.Text = $"⏱️ Zaman: {frame.Time:F2} s / {_simulationDuration:F1} s";
                lblAltitudeDisplay.Text = $"🚀 İrtifa: {frame.TruePosition:F1} m";
                lblTemperatureDisplay.Text = $"🌡️ Sıcaklık: {frame.Temperature:+0.0;-0.0;0.0} °C";

                // 1. Genel Güven Katsayısı Gösterimi
                double conf = frame.ConfidenceScore;
                string confEmoji = conf >= 80.0 ? "🟢" : conf >= 50.0 ? "🟡" : conf >= 20.0 ? "🟠" : "🔴";
                lblConfidenceDisplay.Text = $"{confEmoji} Genel EKF: %{conf:F1}";
                prgConfidence.Value = Math.Max(0, Math.Min(100, (int)conf));
                prgConfidence.ForeColor = conf >= 80 ? Color.FromArgb(16, 185, 129) : conf >= 50 ? Color.FromArgb(250, 204, 21) : conf >= 20 ? Color.FromArgb(249, 115, 22) : Color.FromArgb(239, 68, 68);

                // 2. Barometre + Sıcaklık Zinciri Güveni
                double baroConf = frame.BaroConfidenceScore;
                string baroEmoji = baroConf >= 80.0 ? "🔵" : baroConf >= 50.0 ? "🟡" : baroConf >= 20.0 ? "🟠" : "🔴";
                lblBaroConfDisplay.Text = $"{baroEmoji} Baro+Sıcaklık: %{baroConf:F1}";
                prgBaroConf.Value = Math.Max(0, Math.Min(100, (int)baroConf));
                prgBaroConf.ForeColor = baroConf >= 80 ? Color.FromArgb(56, 189, 248) : baroConf >= 50 ? Color.FromArgb(250, 204, 21) : baroConf >= 20 ? Color.FromArgb(249, 115, 22) : Color.FromArgb(239, 68, 68);

                // 3. İvmeölçer (IMU) Güveni
                double accConf = frame.AccConfidenceScore;
                string accEmoji = accConf >= 80.0 ? "⚡" : accConf >= 50.0 ? "🟡" : accConf >= 20.0 ? "🟠" : "🔴";
                lblAccConfDisplay.Text = $"{accEmoji} İvmeölçer: %{accConf:F1}";
                prgAccConf.Value = Math.Max(0, Math.Min(100, (int)accConf));
                prgAccConf.ForeColor = accConf >= 80 ? Color.FromArgb(250, 204, 21) : accConf >= 50 ? Color.FromArgb(249, 115, 22) : Color.FromArgb(239, 68, 68);

                UpdateLiveForceDiagram(frame);
            }
        }

        private void UpdateLiveForceDiagram(TimelineSimulationFrame frame)
        {
            double fg = frame.GravityForceNewton;
            double fd = frame.DragForceNewton;
            double fext = frame.AppliedExternalForceNewton;
            double fnet = frame.NetForceNewton;
            double acc = frame.TrueAcceleration;

            string dragArrow = fd >= 0 ? "▲" : "▼";
            string extArrow = fext >= 0 ? "▲" : "▼";
            if (Math.Abs(fext) < 0.01) extArrow = "─";

            double payloadKg = GlobalSimulationConfig.PayloadMassKg;
            double areaM2 = GlobalSimulationConfig.WingOpenedArea;

            string ascii =
                $"     {dragArrow} F_d (Hava Sürtünmesi @ A={areaM2:F4}m²) = {fd:+0.00;-0.00;0.00} N\r\n" +
                $"     {extArrow} F_dış (Timeline Aktör Kuvveti)        = {fext:+0.00;-0.00;0.00} N\r\n" +
                $"┌────┴─────────────────────────────────────────────┐\r\n" +
                $"│  GÖREV YÜKÜ (FAZ 4): {payloadKg:F2} kg (Açık Kanat)     │\r\n" +
                $"└────┬─────────────────────────────────────────────┘\r\n" +
                $"     ▼ F_g (Yerçekimi Kuvveti)                 = {fg:+0.00;-0.00;0.00} N\r\n" +
                $"------------------------------------------------------\r\n" +
                $"  NET BİLEŞKE: {fnet:+0.00;-0.00;0.00} N | İVME: {acc:+0.00;-0.00;0.00} m/s²";

            lblLiveForceAscii.Text = ascii;
        }
    }
}
