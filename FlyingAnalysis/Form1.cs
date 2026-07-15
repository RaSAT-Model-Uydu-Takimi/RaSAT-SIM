using System;
using System.Drawing;
using System.Windows.Forms;
using FlyingAnalysis.UI.Panels;
using FlyingAnalysis.UI.Panels.SettingsSubPanels;

namespace FlyingAnalysis
{
    public partial class Form1 : Form
    {
        private UserControl? _currentMainView = null;

        public Form1()
        {
            InitializeComponent();

            btnNavSettings.Text = "PARAMETRE VE AYARLAR";
            btnNavSimulation.Text = "TIMELINE & UÇUŞ SİMÜLASYONU";
            btnNavAnalysis.Text = "SENSÖR KALİBRASYON ANALİZİ";

            // Üst navigasyon butonlarına tıklama olayları
            btnNavSettings.Click += (s, e) => LoadMainView(new SimulationConfigDashboard(), btnNavSettings);
            btnNavSimulation.Click += (s, e) => LoadMainView(new TimelineStudioSubPanel(), btnNavSimulation);
            btnNavAnalysis.Click += (s, e) => LoadMainView(new SensorSettingsSubPanel(), btnNavAnalysis);

            // Form açıldığında varsayılan olarak Ayarlar ve Simülasyon Konfigürasyonu panelini yükle
            this.Load += (s, e) => {
                LoadMainView(new SimulationConfigDashboard(), btnNavSettings);
            };
        }

        private void LoadMainView(UserControl view, Button activeNavButton)
        {
            if (_currentMainView != null)
            {
                pnlMainContainer.Controls.Remove(_currentMainView);
                _currentMainView.Dispose();
            }

            _currentMainView = view;
            view.Dock = DockStyle.Fill;
            pnlMainContainer.Controls.Add(view);

            HighlightNavButton(activeNavButton);
        }

        private void ShowPlaceholderView(string message, Button activeNavButton)
        {
            if (_currentMainView != null)
            {
                pnlMainContainer.Controls.Remove(_currentMainView);
                _currentMainView.Dispose();
                _currentMainView = null;
            }

            Panel placeholderPanel = new Panel();
            placeholderPanel.Dock = DockStyle.Fill;
            placeholderPanel.BackColor = Color.FromArgb(248, 250, 252);

            Label lblInfo = new Label();
            lblInfo.Text = message;
            lblInfo.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblInfo.ForeColor = Color.FromArgb(71, 85, 105);
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(50, 50);

            placeholderPanel.Controls.Add(lblInfo);
            pnlMainContainer.Controls.Add(placeholderPanel);

            HighlightNavButton(activeNavButton);
        }

        private void HighlightNavButton(Button activeButton)
        {
            btnNavSettings.BackColor = Color.FromArgb(15, 23, 42);
            btnNavSimulation.BackColor = Color.FromArgb(15, 23, 42);
            btnNavAnalysis.BackColor = Color.FromArgb(15, 23, 42);

            btnNavSettings.ForeColor = Color.FromArgb(203, 213, 225);
            btnNavSimulation.ForeColor = Color.FromArgb(203, 213, 225);
            btnNavAnalysis.ForeColor = Color.FromArgb(203, 213, 225);

            activeButton.BackColor = Color.FromArgb(37, 99, 235);
            activeButton.ForeColor = Color.White;
        }
    }
}
