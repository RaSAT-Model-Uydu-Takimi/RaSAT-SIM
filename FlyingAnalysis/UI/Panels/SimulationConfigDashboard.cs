using System;
using System.Windows.Forms;
using FlyingAnalysis.UI.Panels.SettingsSubPanels;

namespace FlyingAnalysis.UI.Panels
{
    public partial class SimulationConfigDashboard : UserControl
    {
        private UserControl? _currentActivePanel = null;


        public SimulationConfigDashboard()
        {
            InitializeComponent();

            // Sekme butonlarına olayları bağla
            btnTab1_WorldVariables.Click += (s, e) => LoadSubPanel(new WorldVariablesSubPanel(), "DURUM: 1. Dünya ve Çevre Değişkenleri Paneli Aktif.");
            btnTab2_SatellitePhysics.Click += (s, e) => LoadSubPanel(new SatellitePhysicsSubPanel(), "DURUM: 2. Uydunun Fiziksel ve Paraşüt Özellikleri Paneli Aktif.");
            btnTab3_Ascent.Click += (s, e) => LoadSubPanel(new Phase1SubPanel(), "DURUM: 3. Faz 1 (Roketle Yükseliş & Sızdıran Kova) Paneli Aktif.");
            btnTab4_Separation.Click += (s, e) => LoadSubPanel(new Phase2SubPanel(), "DURUM: 4. Faz 2 (Ana Paraşütlü Süzülüş & SİGMA Ayrılma) Paneli Aktif.");
            btnTab5_BrakePhase.Click += (s, e) => LoadSubPanel(new Phase3SubPanel(), "DURUM: 5. Faz 3 (Ayrılma Hali - S3 Blokları & Doğrusal Geçiş) Paneli Aktif.");
            btnTab6_ControlledDescent.Click += (s, e) => LoadSubPanel(new Phase4SubPanel(), "DURUM: 6. Faz 4 (Aktif İniş - 4 Alt Fazlı Kademeli PID & APAM) Paneli Aktif.");
            btnTab7_Landing.Click += (s, e) => LoadSubPanel(new ApamSubPanel(), "DURUM: 7. APAM (Acil Durum Paraşütü, Sızdıran Kova & Limit Hız) Paneli Aktif.");
            btnTab8_Contingency.Click += (s, e) => LoadSubPanel(new Phase5SubPanel(), "DURUM: 8. Faz 5 (Yere İniş Doğrulaması & İniş Sertliği Kriterleri) Paneli Aktif.");
            btnTab9_SensorCalibration.Click += (s, e) => LoadSubPanel(new SensorSettingsSubPanel(), "DURUM: 9. Sensör Hata Enjeksiyonu & Kalibrasyon Modeli Paneli Aktif.");




            // Varsayılan olarak 1. paneli aç
            this.Load += (s, e) => {
                if (_currentActivePanel == null)
                {
                    LoadSubPanel(new WorldVariablesSubPanel(), "DURUM: 1. Dünya ve Çevre Değişkenleri Paneli Aktif.");
                }
            };
        }

        private void LoadSubPanel(UserControl subPanel, string statusMessage)
        {
            if (_currentActivePanel != null)
            {
                pnlSubContentContainer.Controls.Remove(_currentActivePanel);
                _currentActivePanel.Dispose();
            }

            _currentActivePanel = subPanel;
            subPanel.Dock = DockStyle.Fill;
            pnlSubContentContainer.Controls.Add(subPanel);
            lblActiveTabStatus.Text = statusMessage;
        }
    }
}

