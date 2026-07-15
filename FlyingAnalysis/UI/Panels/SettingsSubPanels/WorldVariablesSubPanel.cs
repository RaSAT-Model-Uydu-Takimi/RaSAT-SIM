namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    public partial class WorldVariablesSubPanel : UserControl
    {
        public WorldVariablesSubPanel()
        {
            InitializeComponent();
        }

        public double Gravity => (double)numGravity.Value;
        public double AirDensity => (double)numAirDensity.Value;
        public double DragCoeff => (double)numDragCoeff.Value;
        public double SeaLevelTemperature => (double)numTempC.Value;
        public double LapseRate => (double)numLapseRate.Value;
    }
}

