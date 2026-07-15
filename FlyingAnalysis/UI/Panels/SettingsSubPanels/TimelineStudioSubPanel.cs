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
            btnClearEvents.Click += (s, e) =>
            {
                _events.Clear();
                timelineControl.SetEvents(_events);
                RunAndRefreshSimulation();
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
            switch (mode)
            {
                case ViewMode.Proportional:
                    tlpMainCharts.RowStyles[0] = new RowStyle(SizeType.Percent, 65f);
                    tlpMainCharts.RowStyles[1] = new RowStyle(SizeType.Percent, 35f);
                    plotPosition.Visible = true;
                    tlpBottomRow.Visible = true;
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
                    tlpBottomRow.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 100f);
                    tlpBottomRow.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 0f);
                    tlpBottomRow.ColumnStyles[2] = new ColumnStyle(SizeType.Percent, 0f);
                    plotVelocity.Visible = true;
                    plotAcceleration.Visible = false;
                    grpLiveForceDiagram.Visible = false;
                    break;
                case ViewMode.AccOnly:
                    tlpMainCharts.RowStyles[0] = new RowStyle(SizeType.Percent, 0f);
                    tlpMainCharts.RowStyles[1] = new RowStyle(SizeType.Percent, 100f);
                    plotPosition.Visible = false;
                    tlpBottomRow.Visible = true;
                    tlpBottomRow.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 0f);
                    tlpBottomRow.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 100f);
                    tlpBottomRow.ColumnStyles[2] = new ColumnStyle(SizeType.Percent, 0f);
                    plotVelocity.Visible = false;
                    plotAcceleration.Visible = true;
                    grpLiveForceDiagram.Visible = false;
                    break;
            }
            if (mode == ViewMode.Proportional)
            {
                tlpBottomRow.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 33.33f);
                tlpBottomRow.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 33.33f);
                tlpBottomRow.ColumnStyles[2] = new ColumnStyle(SizeType.Percent, 33.34f);
            }
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

        private void PlotAllCharts()
        {
            if (_simulationFrames.Count == 0) return;

            double[] xs = _simulationFrames.Select(f => f.Time).ToArray();

            // 1. Konum Grafiği
            plotPosition.Plot.Clear();
            double[] posTrue = _simulationFrames.Select(f => f.TruePosition).ToArray();
            double[] posRaw = _simulationFrames.Select(f => f.RawBaroPosition).ToArray();
            double[] posCal = _simulationFrames.Select(f => f.CalibratedBaroPosition).ToArray();

            var sPosTrue = plotPosition.Plot.Add.Scatter(xs, posTrue);
            sPosTrue.LegendText = "Gerçek İrtifa";
            sPosTrue.Color = ScottPlot.Colors.Gold;
            sPosTrue.LineWidth = 3f;
            sPosTrue.MarkerSize = 0f;

            var sPosRaw = plotPosition.Plot.Add.Scatter(xs, posRaw);
            sPosRaw.LegendText = "Ham Barometre";
            sPosRaw.Color = ScottPlot.Colors.OrangeRed;
            sPosRaw.LineWidth = 1f;
            sPosRaw.MarkerSize = 2f;

            var sPosCal = plotPosition.Plot.Add.Scatter(xs, posCal);
            sPosCal.LegendText = "Kalibre Barometre";
            sPosCal.Color = ScottPlot.Colors.LimeGreen;
            sPosCal.LineWidth = 2f;
            sPosCal.MarkerSize = 0f;

            _vlinePos = plotPosition.Plot.Add.VerticalLine(timelineControl.CurrentPlayheadTime);
            _vlinePos.Color = ScottPlot.Colors.Red;
            _vlinePos.LineWidth = 2f;

            plotPosition.Plot.ShowLegend();
            plotPosition.Refresh();

            // 2. Hız Grafiği
            plotVelocity.Plot.Clear();
            double[] velTrue = _simulationFrames.Select(f => f.TrueVelocity).ToArray();
            var sVelTrue = plotVelocity.Plot.Add.Scatter(xs, velTrue);
            sVelTrue.LegendText = "Gerçek Hız";
            sVelTrue.Color = ScottPlot.Colors.SkyBlue;
            sVelTrue.LineWidth = 2.5f;
            sVelTrue.MarkerSize = 0f;

            _vlineVel = plotVelocity.Plot.Add.VerticalLine(timelineControl.CurrentPlayheadTime);
            _vlineVel.Color = ScottPlot.Colors.Red;
            _vlineVel.LineWidth = 2f;

            plotVelocity.Plot.ShowLegend();
            plotVelocity.Refresh();

            // 3. İvme Grafiği
            plotAcceleration.Plot.Clear();
            double[] accRaw = _simulationFrames.Select(f => f.RawAcceleration).ToArray();
            double[] accCal = _simulationFrames.Select(f => f.CalibratedAcceleration).ToArray();

            var sAccRaw = plotAcceleration.Plot.Add.Scatter(xs, accRaw);
            sAccRaw.LegendText = "Ham İvme";
            sAccRaw.Color = ScottPlot.Colors.OrangeRed;
            sAccRaw.LineWidth = 1f;
            sAccRaw.MarkerSize = 1.5f;

            var sAccCal = plotAcceleration.Plot.Add.Scatter(xs, accCal);
            sAccCal.LegendText = "Kalibre İvme";
            sAccCal.Color = ScottPlot.Colors.LimeGreen;
            sAccCal.LineWidth = 2f;
            sAccCal.MarkerSize = 0f;

            _vlineAcc = plotAcceleration.Plot.Add.VerticalLine(timelineControl.CurrentPlayheadTime);
            _vlineAcc.Color = ScottPlot.Colors.Red;
            _vlineAcc.LineWidth = 2f;

            plotAcceleration.Plot.ShowLegend();
            plotAcceleration.Refresh();
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

            string ascii =
                $"     {dragArrow} F_d (Hava Sürtünmesi) = {fd:+0.00;-0.00;0.00} N\r\n" +
                $"     {extArrow} F_dış (Timeline)      = {fext:+0.00;-0.00;0.00} N\r\n" +
                $"┌────┴─────────────────────────────┐\r\n" +
                $"│  UYDU KÜTLESİ: {GlobalSimulationConfig.TotalMassKg:F2} kg       │\r\n" +
                $"└────┬─────────────────────────────┘\r\n" +
                $"     ▼ F_g (Yerçekimi)       = {fg:+0.00;-0.00;0.00} N\r\n" +
                $"--------------------------------------\r\n" +
                $"  NET BİLEŞKE: {fnet:+0.00;-0.00;0.00} N | İVME: {acc:+0.00;-0.00;0.00} m/s²";

            lblLiveForceAscii.Text = ascii;
        }
    }
}
