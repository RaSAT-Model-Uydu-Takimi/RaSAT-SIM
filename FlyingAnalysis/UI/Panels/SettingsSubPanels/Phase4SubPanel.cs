using System;
using System.Windows.Forms;
using FlyingAnalysis.Models;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    public partial class Phase4SubPanel : UserControl
    {
        public Phase4SubPanel()
        {
            InitializeComponent();

            this.Load += (s, e) => UpdateDynamicSummary();
            this.VisibleChanged += (s, e) => { if (this.Visible) UpdateDynamicSummary(); };

            numTargetVel4_1.ValueChanged += (s, e) => UpdateDynamicSummary();
            if (numTargetVel4_2 != null) numTargetVel4_2.ValueChanged += (s, e) => UpdateDynamicSummary();
            if (numTargetVel4_3 != null) numTargetVel4_3.ValueChanged += (s, e) => UpdateDynamicSummary();
            if (numTargetVel4_4 != null) numTargetVel4_4.ValueChanged += (s, e) => UpdateDynamicSummary();
        }

        private void UpdateDynamicSummary()
        {
            double massKg = GlobalSimulationConfig.PayloadMassKg;
            double area = GlobalSimulationConfig.WingOpenedArea;
            double cd = GlobalSimulationConfig.BodyCd;
            double g = GlobalSimulationConfig.Gravity;
            double rho = GlobalSimulationConfig.AirDensity;

            double vTarget = (double)numTargetVel4_1.Value;
            if (vTarget < 0) vTarget = 0.0;

            double fg = massKg * g;
            double fd = 0.5 * rho * (vTarget * vTarget) * cd * area;
            double fThrust = fg - fd;
            if (fThrust < 0) fThrust = 0.0; // Sürtünme yerçekiminden büyükse itki sıfırlanır

            double tReqGram = (fThrust / g) * 1000.0;
            double tMaxGram = GlobalSimulationConfig.CalculatePropellerMaxThrustGram();
            if (tMaxGram <= 0) tMaxGram = 4780.0;
            double throttlePercent = Math.Min(100.0, (tReqGram / tMaxGram) * 100.0);

            lblForceHeader.Text = $"▼ Fg (Yerçekimi) = {fg:F2} N\r\n▲ F_itki + Fd = {fg:F2} N (@ {vTarget:F1} m/s Sabit İniş)";

            lblForceDiagramVisual.Text =
                $"     ▲  F_itki (BLDC Motor) = {fThrust:F2} N ({tReqGram:F0} g | %{throttlePercent:F1} GAZ)\r\n" +
                $"     ▲  Fd (Sürtünme @ {vTarget:F1} m/s) = {fd:F2} Newton\r\n" +
                $"     │  (Toplam Yukarı Kuvvet F_itki + Fd = Fg)\r\n" +
                $"┌────┴────┐\r\n" +
                $"│  GÖREV  │  (Faz 4: Kanatlar Açık Aktif İniş)\r\n" +
                $"│  YÜKÜ   │  A = {area:F4} m², Cd = {cd:F2}\r\n" +
                $"└────┬────┘  Hedef Sabit Hız v_hedef = {vTarget:F2} m/s\r\n" +
                $"     │\r\n" +
                $"     ▼  Fg (Yerçekimi Kuvveti)\r\n" +
                $"        = {massKg:F2} kg × {g:F3} m/s² = {fg:F2} Newton\r\n\r\n" +
                $"(Sabit İniş Denge Noktası: F_net = 0 N)";

            lblTerminalVelCalc.Text =
                $"🚀 Sabit Hız İtki Analizi (v = {vTarget:F2} m/s):\r\n" +
                $"• Yerçekimi (Fg): {fg:F2} N ({massKg * 1000:F0} g)\r\n" +
                $"• Sürtünme (Fd): {fd:F2} N\r\n" +
                $"• Gereken İtki: {fThrust:F2} N ({tReqGram:F0} g)\r\n" +
                $"• Motor Yük Oranı (% Gaz): %{throttlePercent:F1}\r\n" +
                $"  (Maksimum Kapasite: {tMaxGram:F0} g)";
        }
    }
}
