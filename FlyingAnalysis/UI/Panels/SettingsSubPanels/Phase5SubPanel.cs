using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    public partial class Phase5SubPanel : UserControl
    {
        public Phase5SubPanel()
        {
            InitializeComponent();

            this.Load += (s, e) => UpdateCriteriaTable();
            numGoodThreshold.ValueChanged += (s, e) => UpdateCriteriaTable();
            numNormalThreshold.ValueChanged += (s, e) => UpdateCriteriaTable();
        }

        private void UpdateCriteriaTable()
        {
            double goodVal = (double)numGoodThreshold.Value;
            double normalVal = (double)numNormalThreshold.Value;

            lblBadInfo.Text = $"KÖTÜ İniş: Hız > {normalVal:F1} m/s ise.";

            lblCriteriaTable.Text =
                $"┌────────────────────────┬──────────────────────────────────────────┐\r\n" +
                $"│ İNİŞ SERTLİK SINIFI    │ ŞART VE DEĞERLENDİRME KRİTERİ            │\r\n" +
                $"├────────────────────────┼──────────────────────────────────────────┤\r\n" +
                $"│ [✓] İYİ (PERFECT)      │ v_impact <= {goodVal:F1} m/s (Yumuşak ve Güvenli) │\r\n" +
                $"│ [!] NORMAL (ACCEPTABLE)│ {goodVal:F1} m/s < v_impact <= {normalVal:F1} m/s (Müsaade Ed.)│\r\n" +
                $"│ [X] KÖTÜ (HARD/CRASH)  │ v_impact > {normalVal:F1} m/s (Hasar Riski Yüksek!) │\r\n" +
                $"└────────────────────────┴──────────────────────────────────────────┘\r\n\r\n" +
                $"Not: İniş anındaki temas hızı (v_impact) kaydedilir ve bu sınıflama telemetriye işlenir.";
        }
    }
}
