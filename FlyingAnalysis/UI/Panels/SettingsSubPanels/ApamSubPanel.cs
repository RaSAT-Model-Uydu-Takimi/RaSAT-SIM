using System;
using System.Drawing;
using System.Windows.Forms;
using FlyingAnalysis.Models;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    public partial class ApamSubPanel : UserControl
    {
        private bool _isSyncing = false;

        public ApamSubPanel()
        {
            InitializeComponent();

            this.Load += (s, e) => LoadAndSync();
            this.VisibleChanged += (s, e) => { if (this.Visible) LoadAndSync(); };

            numApamArea.ValueChanged += OnApamAreaChanged;
        }

        private void LoadAndSync()
        {
            _isSyncing = true;
            try
            {
                if ((decimal)GlobalSimulationConfig.ApamParachuteArea >= numApamArea.Minimum &&
                    (decimal)GlobalSimulationConfig.ApamParachuteArea <= numApamArea.Maximum)
                {
                    numApamArea.Value = (decimal)GlobalSimulationConfig.ApamParachuteArea;
                }
            }
            finally
            {
                _isSyncing = false;
            }
            UpdateDynamicSummary();
        }

        private void OnApamAreaChanged(object? sender, EventArgs e)
        {
            if (_isSyncing) return;
            GlobalSimulationConfig.ApamParachuteArea = (double)numApamArea.Value;
            UpdateDynamicSummary();
        }

        private void UpdateDynamicSummary()
        {
            double massKg = GlobalSimulationConfig.PayloadMassKg;
            double area = GlobalSimulationConfig.ApamParachuteArea;
            double cd = GlobalSimulationConfig.ApamParachuteCd;
            double g = GlobalSimulationConfig.Gravity;
            double rho = GlobalSimulationConfig.AirDensity;

            double fg = massKg * g;
            double vLimit = GlobalSimulationConfig.CalculateTerminalVelocity(massKg, area, cd);

            lblForceHeader.Text = $"▼ Fg (Yerçekimi Kuvveti) = {fg:F2} N\r\n▲ Fd (Hava Sürtünmesi) = {fg:F2} N";

            lblForceDiagramVisual.Text =
                $"     ▲  Fd (Sürtünme Kuvveti)\r\n" +
                $"     │  = {fg:F2} Newton\r\n" +
                $"     │  (Limit Hızda Fg'ye Eşit)\r\n" +
                $"┌────┴────┐\r\n" +
                $"│  GÖREV  │  (APAM Açık Halde)\r\n" +
                $"│  YÜKÜ   │  A = {area:F4} m²\r\n" +
                $"└────┬────┘  Cd = {cd:F2}\r\n" +
                $"     │\r\n" +
                $"     ▼  Fg (Yerçekimi Kuvveti)\r\n" +
                $"        = {massKg:F2} kg × {g:F3} m/s²\r\n" +
                $"        = {fg:F2} Newton\r\n\r\n" +
                $"(Denge Noktası: F_net = 0 N)";

            lblTerminalVelCalc.Text =
                $"🚀 Teorik Limit Hız (v_limit):\r\n" +
                $"   = {vLimit:F2} m/s (~{vLimit * 3.6:F2} km/h)\r\n\r\n" +
                $"Formül:\r\n" +
                $"v = √( 2·m·g / (ρ·Cd·A) )\r\n" +
                $"= √( 2×{massKg:F2}×{g:F3} / ({rho:F3}×{cd:F2}×{area:F4}) )";
        }
    }
}
