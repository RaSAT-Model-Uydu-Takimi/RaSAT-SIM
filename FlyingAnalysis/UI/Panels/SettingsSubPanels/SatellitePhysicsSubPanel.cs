using System;
using System.Windows.Forms;
using FlyingAnalysis.Models;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    public partial class SatellitePhysicsSubPanel : UserControl
    {
        private bool _isSyncing = false;

        public SatellitePhysicsSubPanel()
        {
            InitializeComponent();

            this.Load += (s, e) => LoadFromGlobalConfig();
            this.VisibleChanged += (s, e) => { if (this.Visible) LoadFromGlobalConfig(); };

            numCarrierMass.ValueChanged += OnMassOrPhysicsChanged;
            numPayloadMass.ValueChanged += OnMassOrPhysicsChanged;

            numCarrierArea.ValueChanged += OnMassOrPhysicsChanged;
            numCarrierCd.ValueChanged += OnMassOrPhysicsChanged;
            numMainParachuteArea.ValueChanged += OnMassOrPhysicsChanged;
            numMainParachuteCd.ValueChanged += OnMassOrPhysicsChanged;
            numWingClosedArea.ValueChanged += OnMassOrPhysicsChanged;
            numWingOpenedArea.ValueChanged += OnMassOrPhysicsChanged;
            numBodyCd.ValueChanged += OnMassOrPhysicsChanged;

            numPhase1Duration.ValueChanged += OnMassOrPhysicsChanged;
            numPhase2ToPhase3Delay.ValueChanged += OnMassOrPhysicsChanged;
            numPhase3ToPhase4DeployTime.ValueChanged += OnMassOrPhysicsChanged;
            numPhase4ToApamDelay.ValueChanged += OnMassOrPhysicsChanged;

            numApamArea.ValueChanged += OnMassOrPhysicsChanged;
            numApamCd.ValueChanged += OnMassOrPhysicsChanged;

            numMaxThrustGram.ValueChanged += OnMassOrPhysicsChanged;

            // İtki Yöntemi ve Pervane Formül Değişiklik Olayları
            rdoMethodDirect.CheckedChanged += OnThrustMethodOrPropellerChanged;
            rdoMethodPropeller.CheckedChanged += OnThrustMethodOrPropellerChanged;
            numMotorCount.ValueChanged += OnThrustMethodOrPropellerChanged;
            numPropellerCt.ValueChanged += OnThrustMethodOrPropellerChanged;
            numMotorMaxRps.ValueChanged += OnThrustMethodOrPropellerChanged;
            numPropDiameter.ValueChanged += OnThrustMethodOrPropellerChanged;
        }

        private void LoadFromGlobalConfig()
        {
            if (_isSyncing) return;
            _isSyncing = true;

            numCarrierMass.Value = (decimal)GlobalSimulationConfig.CarrierMassGram;
            numPayloadMass.Value = (decimal)GlobalSimulationConfig.PayloadMassGram;

            numCarrierArea.Value = (decimal)GlobalSimulationConfig.CarrierCrossSectionArea;
            numCarrierCd.Value = (decimal)GlobalSimulationConfig.CarrierCd;
            numMainParachuteArea.Value = (decimal)GlobalSimulationConfig.MainParachuteArea;
            numMainParachuteCd.Value = (decimal)GlobalSimulationConfig.MainParachuteCd;
            numWingClosedArea.Value = (decimal)GlobalSimulationConfig.WingClosedArea;
            numWingOpenedArea.Value = (decimal)GlobalSimulationConfig.WingOpenedArea;
            numBodyCd.Value = (decimal)GlobalSimulationConfig.BodyCd;

            numPhase1Duration.Value = (decimal)GlobalSimulationConfig.Phase1Duration;
            numPhase2ToPhase3Delay.Value = (decimal)GlobalSimulationConfig.Phase2ToPhase3Delay;
            numPhase3ToPhase4DeployTime.Value = (decimal)GlobalSimulationConfig.Phase3ToPhase4DeployTime;
            numPhase4ToApamDelay.Value = (decimal)GlobalSimulationConfig.Phase4ToApamDelay;

            numApamArea.Value = (decimal)GlobalSimulationConfig.ApamParachuteArea;
            numApamCd.Value = (decimal)GlobalSimulationConfig.ApamParachuteCd;

            if (!GlobalSimulationConfig.IsPropellerMethodEnabled)
            {
                if ((decimal)GlobalSimulationConfig.MaxThrustGram >= numMaxThrustGram.Minimum &&
                    (decimal)GlobalSimulationConfig.MaxThrustGram <= numMaxThrustGram.Maximum)
                {
                    numMaxThrustGram.Value = (decimal)GlobalSimulationConfig.MaxThrustGram;
                }
            }

            // İtki Seçimi ve Pervane Parametreleri Sync
            rdoMethodPropeller.Checked = GlobalSimulationConfig.IsPropellerMethodEnabled;
            rdoMethodDirect.Checked = !GlobalSimulationConfig.IsPropellerMethodEnabled;

            numMotorCount.Value = GlobalSimulationConfig.MotorCount;
            if ((decimal)GlobalSimulationConfig.PropellerCt >= numPropellerCt.Minimum &&
                (decimal)GlobalSimulationConfig.PropellerCt <= numPropellerCt.Maximum)
            {
                numPropellerCt.Value = (decimal)GlobalSimulationConfig.PropellerCt;
            }
            if ((decimal)GlobalSimulationConfig.MotorMaxRps >= numMotorMaxRps.Minimum &&
                (decimal)GlobalSimulationConfig.MotorMaxRps <= numMotorMaxRps.Maximum)
            {
                numMotorMaxRps.Value = (decimal)GlobalSimulationConfig.MotorMaxRps;
            }
            if ((decimal)GlobalSimulationConfig.PropellerDiameterMeter >= numPropDiameter.Minimum &&
                (decimal)GlobalSimulationConfig.PropellerDiameterMeter <= numPropDiameter.Maximum)
            {
                numPropDiameter.Value = (decimal)GlobalSimulationConfig.PropellerDiameterMeter;
            }

            _isSyncing = false;
            SyncMethodUiStatesAndPropellerMath();
            UpdateTotalMassDisplayAndDiagram();
        }

        private void OnMassOrPhysicsChanged(object? sender, EventArgs e)
        {
            if (_isSyncing) return;

            GlobalSimulationConfig.CarrierMassGram = (double)numCarrierMass.Value;
            GlobalSimulationConfig.PayloadMassGram = (double)numPayloadMass.Value;

            GlobalSimulationConfig.CarrierCrossSectionArea = (double)numCarrierArea.Value;
            GlobalSimulationConfig.CarrierCd = (double)numCarrierCd.Value;
            GlobalSimulationConfig.MainParachuteArea = (double)numMainParachuteArea.Value;
            GlobalSimulationConfig.MainParachuteCd = (double)numMainParachuteCd.Value;
            GlobalSimulationConfig.WingClosedArea = (double)numWingClosedArea.Value;
            GlobalSimulationConfig.WingOpenedArea = (double)numWingOpenedArea.Value;
            GlobalSimulationConfig.BodyCd = (double)numBodyCd.Value;

            GlobalSimulationConfig.Phase1Duration = (double)numPhase1Duration.Value;
            GlobalSimulationConfig.Phase2ToPhase3Delay = (double)numPhase2ToPhase3Delay.Value;
            GlobalSimulationConfig.Phase3ToPhase4DeployTime = (double)numPhase3ToPhase4DeployTime.Value;
            GlobalSimulationConfig.Phase4ToApamDelay = (double)numPhase4ToApamDelay.Value;

            GlobalSimulationConfig.ApamParachuteArea = (double)numApamArea.Value;
            GlobalSimulationConfig.ApamParachuteCd = (double)numApamCd.Value;

            if (rdoMethodDirect.Checked)
            {
                GlobalSimulationConfig.MaxThrustGram = (double)numMaxThrustGram.Value;
            }

            UpdateTotalMassDisplayAndDiagram();
        }

        private void OnThrustMethodOrPropellerChanged(object? sender, EventArgs e)
        {
            if (_isSyncing) return;

            GlobalSimulationConfig.IsPropellerMethodEnabled = rdoMethodPropeller.Checked;
            GlobalSimulationConfig.MotorCount = (int)numMotorCount.Value;
            GlobalSimulationConfig.PropellerCt = (double)numPropellerCt.Value;
            GlobalSimulationConfig.MotorMaxRps = (double)numMotorMaxRps.Value;
            GlobalSimulationConfig.PropellerDiameterMeter = (double)numPropDiameter.Value;

            SyncMethodUiStatesAndPropellerMath();
            UpdateTotalMassDisplayAndDiagram();
        }

        private void SyncMethodUiStatesAndPropellerMath()
        {
            bool isProp = rdoMethodPropeller.Checked;

            // Seçenek B seçildiyse Seçenek A'nın kutusu soluklaşsın ve pasif olsun ama İÇİNDEKİ SAYI DEĞİŞMESİN
            numMaxThrustGram.Enabled = !isProp;
            numMotorCount.Enabled = isProp;
            numPropellerCt.Enabled = isProp;
            numMotorMaxRps.Enabled = isProp;
            numPropDiameter.Enabled = isProp;

            double calculatedGram = GlobalSimulationConfig.CalculatePropellerMaxThrustGram();
            double calculatedNewton = (calculatedGram / 1000.0) * GlobalSimulationConfig.Gravity;

            lblPropellerCalcResult.Text = $"💡 Formül T_max:\r\n= {calculatedGram:F0} gram ({calculatedNewton:F2} N)";

            if (isProp)
            {
                // Seçenek B seçiliyse simülasyon formül sonucunu kullanır (Kutudaki sayı değişmez, sadece pasiftir)
                GlobalSimulationConfig.MaxThrustGram = calculatedGram;
            }
            else
            {
                // Seçenek A seçiliyse simülasyon kutudaki sayıyı kullanır
                GlobalSimulationConfig.MaxThrustGram = (double)numMaxThrustGram.Value;
            }
        }

        private void UpdateTotalMassDisplayAndDiagram()
        {
            lblTotalMassDisplay.Text = $"Toplam Kütle: {GlobalSimulationConfig.TotalMassGram:F0} g ({GlobalSimulationConfig.TotalMassKg:F2} kg)";

            double payloadGram = GlobalSimulationConfig.PayloadMassGram;
            double payloadKg = GlobalSimulationConfig.PayloadMassKg;
            double maxThrustGram = GlobalSimulationConfig.MaxThrustGram;
            double g = GlobalSimulationConfig.Gravity;

            double fgNewtons = payloadKg * g;
            double fMaxNewtons = (maxThrustGram / 1000.0) * g;

            double twr = payloadGram > 0 ? maxThrustGram / payloadGram : 0.0;
            double hoverPercent = maxThrustGram > 0 ? (payloadGram / maxThrustGram) * 100.0 : 0.0;
            double pidMargin = 100.0 - hoverPercent;
            if (pidMargin < 0) pidMargin = 0.0;

            lblForceHeader.Text = $"▼ Fg (Yerçekimi Ağırlığı) = {payloadGram:F0} g ({fgNewtons:F2} N) | ▲ F_max (Maks İtki) = {maxThrustGram:F0} g ({fMaxNewtons:F2} N) | TWR = {twr:F2} : 1";

            lblHoverAndMargin.Text =
                $"█ HAVADA ASILI KALMA (HOVER) ORANI: %{hoverPercent:F1} (Sadece yerçekimini dengelemek için harcanır)\r\n" +
                $"█ PID MANEVRA VE DÜZELTME PAYI    : %{pidMargin:F1} (Rüzgar, ani irtifa düzeltmesi ve manevra payı)";

            lblForceDiagramVisual.Text =
                $"     ▲  F_max (Maksimum İtki Kapasitesi)\r\n" +
                $"     │  = {maxThrustGram:F0} gram (~{fMaxNewtons:F2} N)\r\n" +
                $"┌────┴────┐\r\n" +
                $"│  GÖREV  │  Görev Yükü Kütlesi: {payloadGram:F0} gram\r\n" +
                $"│  YÜKÜ   │  Hover Oranı: %{hoverPercent:F1} | PID Marjı: %{pidMargin:F1}\r\n" +
                $"└────┬────┘\r\n" +
                $"     │\r\n" +
                $"     ▼  Fg (Yerçekimi Ağırlığı)\r\n" +
                $"        = {payloadGram:F0} gram (~{fgNewtons:F2} N)";
        }
    }
}
