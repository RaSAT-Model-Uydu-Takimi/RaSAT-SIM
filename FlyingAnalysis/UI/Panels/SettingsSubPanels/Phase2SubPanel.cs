using System;
using System.Windows.Forms;
using FlyingAnalysis.Models;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    public partial class Phase2SubPanel : UserControl
    {
        public Phase2SubPanel()
        {
            InitializeComponent();

            this.Load += (s, e) => UpdateDynamicSummary();
            this.VisibleChanged += (s, e) => { if (this.Visible) UpdateDynamicSummary(); };
        }

        private void UpdateDynamicSummary()
        {
            double massKg = GlobalSimulationConfig.TotalMassKg;
            double massGram = GlobalSimulationConfig.TotalMassGram;
            double area = GlobalSimulationConfig.MainParachuteArea;
            double cd = GlobalSimulationConfig.MainParachuteCd;
            double g = GlobalSimulationConfig.Gravity;
            double rho = GlobalSimulationConfig.AirDensity;

            double fg = massKg * g;
            double vLimit = GlobalSimulationConfig.CalculateTerminalVelocity(massKg, area, cd);

            lblMassInfo.Text = $"Aktif Kütle: {massGram:F0} gram (Taşıyıcı + Görev Yükü Toplamı)";
            lblAreaInfo.Text = $"Aktif Referans Alan: Ana Paraşüt (A_ana = {area:F4} m², Cd = {cd:F2})";
            lblTerminalVelocity.Text = $"Beklenen Limit Hız (v1): ~{vLimit:F2} m/s";

            lblForceHeader.Text = $"▼ Fg (Yerçekimi Kuvveti) = {fg:F2} N\r\n▲ Fd (Hava Sürtünmesi) = {fg:F2} N";

            lblForceDiagramVisual.Text =
                $"     ▲  Fd (Sürtünme Kuvveti)\r\n" +
                $"     │  = {fg:F2} Newton\r\n" +
                $"     │  (Limit Hızda Fg'ye Eşit)\r\n" +
                $"┌────┴────┐\r\n" +
                $"│  UYDU   │  (Ana Paraşüt Açık)\r\n" +
                $"│ MODÜLÜ  │  A = {area:F4} m²\r\n" +
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
