using System;
using System.Windows.Forms;
using FlyingAnalysis.Models;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    public partial class WorldVariablesSubPanel : UserControl
    {
        public WorldVariablesSubPanel()
        {
            InitializeComponent();

            this.Load += (s, e) => {
                numGravity.Value = (decimal)GlobalSimulationConfig.Gravity;
                numAirDensity.Value = (decimal)GlobalSimulationConfig.AirDensity;
                numTempC.Value = (decimal)GlobalSimulationConfig.SeaLevelTemperature;
                numLapseRate.Value = (decimal)GlobalSimulationConfig.LapseRate;
            };

            numGravity.ValueChanged += (s, e) => GlobalSimulationConfig.Gravity = (double)numGravity.Value;
            numAirDensity.ValueChanged += (s, e) => GlobalSimulationConfig.AirDensity = (double)numAirDensity.Value;
            numTempC.ValueChanged += (s, e) => GlobalSimulationConfig.SeaLevelTemperature = (double)numTempC.Value;
            numLapseRate.ValueChanged += (s, e) => GlobalSimulationConfig.LapseRate = (double)numLapseRate.Value;
        }

        public double Gravity => (double)numGravity.Value;
        public double AirDensity => (double)numAirDensity.Value;
        public double SeaLevelTemperature => (double)numTempC.Value;
        public double LapseRate => (double)numLapseRate.Value;
    }
}

