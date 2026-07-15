using System;
using System.Windows.Forms;
using FlyingAnalysis.Models;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    public partial class SensorEstimationSubPanel : UserControl
    {
        public SensorEstimationSubPanel()
        {
            InitializeComponent();
            LoadFromConfig();
            SetupEventHandlers();
        }

        private void LoadFromConfig()
        {
            numQBase.Value = ClampDecimal(GlobalSimulationConfig.EstProcessNoiseQBase, numQBase.Minimum, numQBase.Maximum);
            numRBaro.Value = ClampDecimal(GlobalSimulationConfig.EstBaroNoiseRBase, numRBaro.Minimum, numRBaro.Maximum);
            numRAcc.Value = ClampDecimal(GlobalSimulationConfig.EstAccNoiseRBase, numRAcc.Minimum, numRAcc.Maximum);

            numBaroPenalty.Value = ClampDecimal(GlobalSimulationConfig.EstBaroCutoffPenalty, numBaroPenalty.Minimum, numBaroPenalty.Maximum);
            numAccPenalty.Value = ClampDecimal(GlobalSimulationConfig.EstAccCutoffPenalty, numAccPenalty.Minimum, numAccPenalty.Maximum);
            numTempPenalty.Value = ClampDecimal(GlobalSimulationConfig.EstTempCutoffPenalty, numTempPenalty.Minimum, numTempPenalty.Maximum);
            numCoastDecay.Value = ClampDecimal(GlobalSimulationConfig.EstCoastDecayRatePerSec, numCoastDecay.Minimum, numCoastDecay.Maximum);
        }

        private void SetupEventHandlers()
        {
            numQBase.ValueChanged += (s, e) => GlobalSimulationConfig.EstProcessNoiseQBase = (double)numQBase.Value;
            numRBaro.ValueChanged += (s, e) => GlobalSimulationConfig.EstBaroNoiseRBase = (double)numRBaro.Value;
            numRAcc.ValueChanged += (s, e) => GlobalSimulationConfig.EstAccNoiseRBase = (double)numRAcc.Value;

            numBaroPenalty.ValueChanged += (s, e) => GlobalSimulationConfig.EstBaroCutoffPenalty = (double)numBaroPenalty.Value;
            numAccPenalty.ValueChanged += (s, e) => GlobalSimulationConfig.EstAccCutoffPenalty = (double)numAccPenalty.Value;
            numTempPenalty.ValueChanged += (s, e) => GlobalSimulationConfig.EstTempCutoffPenalty = (double)numTempPenalty.Value;
            numCoastDecay.ValueChanged += (s, e) => GlobalSimulationConfig.EstCoastDecayRatePerSec = (double)numCoastDecay.Value;
        }

        private static decimal ClampDecimal(double value, decimal min, decimal max)
        {
            decimal v = (decimal)value;
            if (v < min) return min;
            if (v > max) return max;
            return v;
        }
    }
}
