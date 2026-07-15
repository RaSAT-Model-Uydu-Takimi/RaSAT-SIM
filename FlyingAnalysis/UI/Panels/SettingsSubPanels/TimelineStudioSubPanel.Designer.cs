using System;
using System.Drawing;
using System.Windows.Forms;
using ScottPlot;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    partial class TimelineStudioSubPanel
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeaderControls;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRunSimulation;
        private System.Windows.Forms.Label lblTimeDisplay;
        private System.Windows.Forms.Label lblAltitudeDisplay;
        private System.Windows.Forms.Label lblTemperatureDisplay;
        private System.Windows.Forms.ComboBox cmbPhysicsFreqHz;
        private System.Windows.Forms.Label lblFreqTitle;

        private System.Windows.Forms.GroupBox grpAddEvent;
        private System.Windows.Forms.ComboBox cmbEventType;
        private System.Windows.Forms.Label lblEventType;
        private System.Windows.Forms.TextBox txtEventLabel;
        private System.Windows.Forms.Label lblEventLabel;
        private System.Windows.Forms.NumericUpDown numStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.NumericUpDown numEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.NumericUpDown numStartVal;
        private System.Windows.Forms.Label lblStartVal;
        private System.Windows.Forms.NumericUpDown numEndVal;
        private System.Windows.Forms.Label lblEndVal;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnClearEvents;
        private System.Windows.Forms.Button btnDeleteSelectedEvent;
        private System.Windows.Forms.Button btnOpenChartSettings;

        private Controls.AfterEffectsTimelineControl timelineControl;

        private System.Windows.Forms.Panel pnlViewModeButtons;
        private System.Windows.Forms.Button btnViewProportional;
        private System.Windows.Forms.Button btnViewPosOnly;
        private System.Windows.Forms.Button btnViewVelOnly;
        private System.Windows.Forms.Button btnViewAccOnly;

        private System.Windows.Forms.TableLayoutPanel tlpMainCharts;
        private ScottPlot.WinForms.FormsPlot plotPosition;
        private System.Windows.Forms.TableLayoutPanel tlpBottomRow;
        private ScottPlot.WinForms.FormsPlot plotVelocity;
        private ScottPlot.WinForms.FormsPlot plotAcceleration;
        private System.Windows.Forms.GroupBox grpLiveForceDiagram;
        private System.Windows.Forms.Label lblLiveForceAscii;

        private System.Windows.Forms.Label lblConfidenceDisplay;
        private System.Windows.Forms.ProgressBar prgConfidence;

        private System.Windows.Forms.Timer timerPlayback;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.timerPlayback = new System.Windows.Forms.Timer(components);

            this.pnlHeaderControls = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRunSimulation = new System.Windows.Forms.Button();
            this.lblTimeDisplay = new System.Windows.Forms.Label();
            this.lblAltitudeDisplay = new System.Windows.Forms.Label();
            this.lblTemperatureDisplay = new System.Windows.Forms.Label();
            this.lblFreqTitle = new System.Windows.Forms.Label();
            this.cmbPhysicsFreqHz = new System.Windows.Forms.ComboBox();

            this.grpAddEvent = new System.Windows.Forms.GroupBox();
            this.lblEventType = new System.Windows.Forms.Label();
            this.cmbEventType = new System.Windows.Forms.ComboBox();
            this.lblEventLabel = new System.Windows.Forms.Label();
            this.txtEventLabel = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.numStartTime = new System.Windows.Forms.NumericUpDown();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.numEndTime = new System.Windows.Forms.NumericUpDown();
            this.lblStartVal = new System.Windows.Forms.Label();
            this.numStartVal = new System.Windows.Forms.NumericUpDown();
            this.lblEndVal = new System.Windows.Forms.Label();
            this.numEndVal = new System.Windows.Forms.NumericUpDown();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnClearEvents = new System.Windows.Forms.Button();
            this.btnDeleteSelectedEvent = new System.Windows.Forms.Button();
            this.btnOpenChartSettings = new System.Windows.Forms.Button();

            this.timelineControl = new FlyingAnalysis.UI.Controls.AfterEffectsTimelineControl();

            this.pnlViewModeButtons = new System.Windows.Forms.Panel();
            this.btnViewProportional = new System.Windows.Forms.Button();
            this.btnViewPosOnly = new System.Windows.Forms.Button();
            this.btnViewVelOnly = new System.Windows.Forms.Button();
            this.btnViewAccOnly = new System.Windows.Forms.Button();

            this.tlpMainCharts = new System.Windows.Forms.TableLayoutPanel();
            this.plotPosition = new ScottPlot.WinForms.FormsPlot();
            this.tlpBottomRow = new System.Windows.Forms.TableLayoutPanel();
            this.plotVelocity = new ScottPlot.WinForms.FormsPlot();
            this.plotAcceleration = new ScottPlot.WinForms.FormsPlot();
            this.grpLiveForceDiagram = new System.Windows.Forms.GroupBox();
            this.lblLiveForceAscii = new System.Windows.Forms.Label();
            this.lblConfidenceDisplay = new System.Windows.Forms.Label();
            this.prgConfidence = new System.Windows.Forms.ProgressBar();

            this.pnlHeaderControls.SuspendLayout();
            this.grpAddEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEndVal)).BeginInit();
            this.pnlViewModeButtons.SuspendLayout();
            this.tlpMainCharts.SuspendLayout();
            this.tlpBottomRow.SuspendLayout();
            this.grpLiveForceDiagram.SuspendLayout();
            this.SuspendLayout();

            // 
            // timerPlayback
            // 
            this.timerPlayback.Interval = 40; // 25 FPS görsel güncelleme

            // 
            // pnlHeaderControls
            // 
            this.pnlHeaderControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeaderControls.Controls.Add(this.prgConfidence);
            this.pnlHeaderControls.Controls.Add(this.lblConfidenceDisplay);
            this.pnlHeaderControls.Controls.Add(this.btnRunSimulation);
            this.pnlHeaderControls.Controls.Add(this.cmbPhysicsFreqHz);
            this.pnlHeaderControls.Controls.Add(this.lblFreqTitle);
            this.pnlHeaderControls.Controls.Add(this.lblTemperatureDisplay);
            this.pnlHeaderControls.Controls.Add(this.lblAltitudeDisplay);
            this.pnlHeaderControls.Controls.Add(this.lblTimeDisplay);
            this.pnlHeaderControls.Controls.Add(this.btnReset);
            this.pnlHeaderControls.Controls.Add(this.btnPause);
            this.pnlHeaderControls.Controls.Add(this.btnPlay);
            this.pnlHeaderControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderControls.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderControls.Name = "pnlHeaderControls";
            this.pnlHeaderControls.Size = new System.Drawing.Size(1200, 56);
            this.pnlHeaderControls.TabIndex = 0;

            // btnPlay
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Location = new System.Drawing.Point(12, 10);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(86, 36);
            this.btnPlay.Text = "▶ Oynat";
            this.btnPlay.UseVisualStyleBackColor = false;

            // btnPause
            this.btnPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.Location = new System.Drawing.Point(104, 10);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(86, 36);
            this.btnPause.Text = "⏸ Durdur";
            this.btnPause.UseVisualStyleBackColor = false;

            // btnReset
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(196, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(86, 36);
            this.btnReset.Text = "⏹ Sıfırla";
            this.btnReset.UseVisualStyleBackColor = false;

            // lblTimeDisplay
            this.lblTimeDisplay.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lblTimeDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.lblTimeDisplay.Location = new System.Drawing.Point(292, 16);
            this.lblTimeDisplay.Name = "lblTimeDisplay";
            this.lblTimeDisplay.Size = new System.Drawing.Size(160, 24);
            this.lblTimeDisplay.Text = "⏱️ Zaman: 0.00 s";

            // lblAltitudeDisplay
            this.lblAltitudeDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblAltitudeDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.lblAltitudeDisplay.Location = new System.Drawing.Point(455, 17);
            this.lblAltitudeDisplay.Name = "lblAltitudeDisplay";
            this.lblAltitudeDisplay.Size = new System.Drawing.Size(145, 24);
            this.lblAltitudeDisplay.Text = "🚀 İrtifa: 0.0 m";

            // lblTemperatureDisplay
            this.lblTemperatureDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTemperatureDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.lblTemperatureDisplay.Location = new System.Drawing.Point(605, 17);
            this.lblTemperatureDisplay.Name = "lblTemperatureDisplay";
            this.lblTemperatureDisplay.Size = new System.Drawing.Size(220, 24);
            this.lblTemperatureDisplay.Text = "🌡️ Sıcaklık: +15.0 °C";

            // lblFreqTitle
            this.lblFreqTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFreqTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblFreqTitle.Location = new System.Drawing.Point(830, 18);
            this.lblFreqTitle.Name = "lblFreqTitle";
            this.lblFreqTitle.Size = new System.Drawing.Size(85, 20);
            this.lblFreqTitle.Text = "Fizik Frekansı:";

            // cmbPhysicsFreqHz
            this.cmbPhysicsFreqHz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhysicsFreqHz.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.cmbPhysicsFreqHz.Items.AddRange(new object[] {
            "10 Hz (0.10s)",
            "20 Hz (0.05s)",
            "50 Hz (0.02s)",
            "100 Hz (0.01s)",
            "200 Hz (0.005s)",
            "500 Hz (0.002s)"});
            this.cmbPhysicsFreqHz.Location = new System.Drawing.Point(920, 14);
            this.cmbPhysicsFreqHz.Name = "cmbPhysicsFreqHz";
            this.cmbPhysicsFreqHz.Size = new System.Drawing.Size(125, 25);

            // btnRunSimulation
            this.btnRunSimulation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnRunSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunSimulation.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRunSimulation.ForeColor = System.Drawing.Color.White;
            this.btnRunSimulation.Location = new System.Drawing.Point(1055, 10);
            this.btnRunSimulation.Name = "btnRunSimulation";
            this.btnRunSimulation.Size = new System.Drawing.Size(130, 36);
            this.btnRunSimulation.Text = "⚙️ Simülasyon Çalıştır";
            this.btnRunSimulation.UseVisualStyleBackColor = false;

            // 
            // grpAddEvent
            // 
            this.grpAddEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpAddEvent.Controls.Add(this.btnClearEvents);
            this.grpAddEvent.Controls.Add(this.btnDeleteSelectedEvent);
            this.grpAddEvent.Controls.Add(this.btnAddEvent);
            this.grpAddEvent.Controls.Add(this.numEndVal);
            this.grpAddEvent.Controls.Add(this.lblEndVal);
            this.grpAddEvent.Controls.Add(this.numStartVal);
            this.grpAddEvent.Controls.Add(this.lblStartVal);
            this.grpAddEvent.Controls.Add(this.numEndTime);
            this.grpAddEvent.Controls.Add(this.lblEndTime);
            this.grpAddEvent.Controls.Add(this.numStartTime);
            this.grpAddEvent.Controls.Add(this.lblStartTime);
            this.grpAddEvent.Controls.Add(this.txtEventLabel);
            this.grpAddEvent.Controls.Add(this.lblEventLabel);
            this.grpAddEvent.Controls.Add(this.cmbEventType);
            this.grpAddEvent.Controls.Add(this.lblEventType);
            this.grpAddEvent.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAddEvent.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.grpAddEvent.ForeColor = System.Drawing.Color.White;
            this.grpAddEvent.Location = new System.Drawing.Point(0, 56);
            this.grpAddEvent.Name = "grpAddEvent";
            this.grpAddEvent.Size = new System.Drawing.Size(1200, 58);
            this.grpAddEvent.TabIndex = 1;
            this.grpAddEvent.Text = "Timeline'a Çoklu Olay Ekle";

            // lblEventType
            this.lblEventType.AutoSize = true;
            this.lblEventType.Location = new System.Drawing.Point(10, 26);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Size = new System.Drawing.Size(61, 15);
            this.lblEventType.Text = "Olay Türü:";

            // cmbEventType
            this.cmbEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventType.Items.AddRange(new object[] {
            "1. Dış Kuvvet Uygula [Newton]",
            "2. Sensörü Kapat (Cutoff - NaN)",
            "3. Özel Durum Gürültüsü [±σ Şok]"});
            this.cmbEventType.Location = new System.Drawing.Point(75, 23);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(210, 23);

            // lblEventLabel
            this.lblEventLabel.AutoSize = true;
            this.lblEventLabel.Location = new System.Drawing.Point(295, 26);
            this.lblEventLabel.Name = "lblEventLabel";
            this.lblEventLabel.Size = new System.Drawing.Size(34, 15);
            this.lblEventLabel.Text = "İsim:";

            // txtEventLabel
            this.txtEventLabel.Location = new System.Drawing.Point(333, 23);
            this.txtEventLabel.Name = "txtEventLabel";
            this.txtEventLabel.Size = new System.Drawing.Size(110, 23);
            this.txtEventLabel.Text = "Rüzgar Darbesi";

            // lblStartTime
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(450, 26);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(46, 15);
            this.lblStartTime.Text = "Baş [s]:";

            // numStartTime
            this.numStartTime.DecimalPlaces = 1;
            this.numStartTime.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numStartTime.Location = new System.Drawing.Point(500, 23);
            this.numStartTime.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            this.numStartTime.Name = "numStartTime";
            this.numStartTime.Size = new System.Drawing.Size(60, 23);
            this.numStartTime.Value = new decimal(new int[] { 5, 0, 0, 0 });

            // lblEndTime
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(565, 26);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(41, 15);
            this.lblEndTime.Text = "Bit [s]:";

            // numEndTime
            this.numEndTime.DecimalPlaces = 1;
            this.numEndTime.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numEndTime.Location = new System.Drawing.Point(610, 23);
            this.numEndTime.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            this.numEndTime.Name = "numEndTime";
            this.numEndTime.Size = new System.Drawing.Size(60, 23);
            this.numEndTime.Value = new decimal(new int[] { 7, 0, 0, 0 });

            // lblStartVal
            this.lblStartVal.AutoSize = true;
            this.lblStartVal.Location = new System.Drawing.Point(675, 26);
            this.lblStartVal.Name = "lblStartVal";
            this.lblStartVal.Size = new System.Drawing.Size(61, 15);
            this.lblStartVal.Text = "Baş.Değer:";

            // numStartVal
            this.numStartVal.DecimalPlaces = 1;
            this.numStartVal.Location = new System.Drawing.Point(740, 23);
            this.numStartVal.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numStartVal.Minimum = new decimal(new int[] { 500, 0, 0, -2147483648 });
            this.numStartVal.Name = "numStartVal";
            this.numStartVal.Size = new System.Drawing.Size(65, 23);
            this.numStartVal.Value = new decimal(new int[] { 75, 0, 0, 65536 });

            // lblEndVal
            this.lblEndVal.AutoSize = true;
            this.lblEndVal.Location = new System.Drawing.Point(810, 26);
            this.lblEndVal.Name = "lblEndVal";
            this.lblEndVal.Size = new System.Drawing.Size(56, 15);
            this.lblEndVal.Text = "Bit.Değer:";

            // numEndVal
            this.numEndVal.DecimalPlaces = 1;
            this.numEndVal.Location = new System.Drawing.Point(870, 23);
            this.numEndVal.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numEndVal.Minimum = new decimal(new int[] { 500, 0, 0, -2147483648 });
            this.numEndVal.Name = "numEndVal";
            this.numEndVal.Size = new System.Drawing.Size(65, 23);
            this.numEndVal.Value = new decimal(new int[] { 75, 0, 0, 65536 });

            // btnAddEvent
            this.btnAddEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnAddEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEvent.Location = new System.Drawing.Point(945, 21);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(110, 27);
            this.btnAddEvent.Text = "+ Olay Ekle";
            this.btnAddEvent.UseVisualStyleBackColor = false;

            // btnClearEvents
            this.btnClearEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnClearEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearEvents.Location = new System.Drawing.Point(1095, 21);
            this.btnClearEvents.Name = "btnClearEvents";
            this.btnClearEvents.Size = new System.Drawing.Size(95, 27);
            this.btnClearEvents.Text = "🗑️ Tümü";
            this.btnClearEvents.UseVisualStyleBackColor = false;

            // btnDeleteSelectedEvent
            this.btnDeleteSelectedEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDeleteSelectedEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSelectedEvent.Location = new System.Drawing.Point(985, 21);
            this.btnDeleteSelectedEvent.Name = "btnDeleteSelectedEvent";
            this.btnDeleteSelectedEvent.Size = new System.Drawing.Size(105, 27);
            this.btnDeleteSelectedEvent.Text = "🗑️ Seçiliyi Sil";
            this.btnDeleteSelectedEvent.UseVisualStyleBackColor = false;

            // 
            // timelineControl
            // 
            this.timelineControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.timelineControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.timelineControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.timelineControl.Location = new System.Drawing.Point(0, 114);
            this.timelineControl.Name = "timelineControl";
            this.timelineControl.Size = new System.Drawing.Size(1200, 130);
            this.timelineControl.TabIndex = 2;

            // 
            // pnlViewModeButtons
            // 
            this.pnlViewModeButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.pnlViewModeButtons.Controls.Add(this.btnOpenChartSettings);
            this.pnlViewModeButtons.Controls.Add(this.btnViewAccOnly);
            this.pnlViewModeButtons.Controls.Add(this.btnViewVelOnly);
            this.pnlViewModeButtons.Controls.Add(this.btnViewPosOnly);
            this.pnlViewModeButtons.Controls.Add(this.btnViewProportional);
            this.pnlViewModeButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlViewModeButtons.Location = new System.Drawing.Point(0, 244);
            this.pnlViewModeButtons.Name = "pnlViewModeButtons";
            this.pnlViewModeButtons.Size = new System.Drawing.Size(1200, 36);
            this.pnlViewModeButtons.TabIndex = 3;

            // btnViewProportional
            this.btnViewProportional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
            this.btnViewProportional.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewProportional.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewProportional.ForeColor = System.Drawing.Color.White;
            this.btnViewProportional.Location = new System.Drawing.Point(12, 4);
            this.btnViewProportional.Name = "btnViewProportional";
            this.btnViewProportional.Size = new System.Drawing.Size(260, 28);
            this.btnViewProportional.Text = "📊 Orantılı (Konum 2x, Alt Satır Yan Yana)";
            this.btnViewProportional.UseVisualStyleBackColor = false;

            // btnViewPosOnly
            this.btnViewPosOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnViewPosOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPosOnly.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewPosOnly.ForeColor = System.Drawing.Color.White;
            this.btnViewPosOnly.Location = new System.Drawing.Point(278, 4);
            this.btnViewPosOnly.Name = "btnViewPosOnly";
            this.btnViewPosOnly.Size = new System.Drawing.Size(180, 28);
            this.btnViewPosOnly.Text = "📈 Konum Tam Ekran";
            this.btnViewPosOnly.UseVisualStyleBackColor = false;

            // btnViewVelOnly
            this.btnViewVelOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnViewVelOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewVelOnly.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewVelOnly.ForeColor = System.Drawing.Color.White;
            this.btnViewVelOnly.Location = new System.Drawing.Point(464, 4);
            this.btnViewVelOnly.Name = "btnViewVelOnly";
            this.btnViewVelOnly.Size = new System.Drawing.Size(180, 28);
            this.btnViewVelOnly.Text = "⚡ Hız Tam Ekran";
            this.btnViewVelOnly.UseVisualStyleBackColor = false;

            // btnViewAccOnly
            this.btnViewAccOnly.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnViewAccOnly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAccOnly.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewAccOnly.ForeColor = System.Drawing.Color.White;
            this.btnViewAccOnly.Location = new System.Drawing.Point(650, 4);
            this.btnViewAccOnly.Name = "btnViewAccOnly";
            this.btnViewAccOnly.Size = new System.Drawing.Size(180, 28);
            this.btnViewAccOnly.Text = "🚀 İvme Tam Ekran";
            this.btnViewAccOnly.UseVisualStyleBackColor = false;

            // btnOpenChartSettings
            this.btnOpenChartSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(85)))), ((int)(((byte)(247)))));
            this.btnOpenChartSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenChartSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenChartSettings.ForeColor = System.Drawing.Color.White;
            this.btnOpenChartSettings.Location = new System.Drawing.Point(836, 4);
            this.btnOpenChartSettings.Name = "btnOpenChartSettings";
            this.btnOpenChartSettings.Size = new System.Drawing.Size(250, 28);
            this.btnOpenChartSettings.Text = "🎨 Grafik Katman & Sıralama Ayarları";
            this.btnOpenChartSettings.UseVisualStyleBackColor = false;

            // 
            // tlpMainCharts
            // 
            this.tlpMainCharts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.tlpMainCharts.ColumnCount = 1;
            this.tlpMainCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainCharts.Controls.Add(this.plotPosition, 0, 0);
            this.tlpMainCharts.Controls.Add(this.tlpBottomRow, 0, 1);
            this.tlpMainCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainCharts.Location = new System.Drawing.Point(0, 280);
            this.tlpMainCharts.Name = "tlpMainCharts";
            this.tlpMainCharts.RowCount = 2;
            this.tlpMainCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMainCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMainCharts.Size = new System.Drawing.Size(1200, 420);
            this.tlpMainCharts.TabIndex = 4;

            // plotPosition
            this.plotPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotPosition.Location = new System.Drawing.Point(3, 3);
            this.plotPosition.Name = "plotPosition";
            this.plotPosition.Size = new System.Drawing.Size(1194, 246);
            this.plotPosition.TabIndex = 0;

            // tlpBottomRow
            this.tlpBottomRow.ColumnCount = 3;
            this.tlpBottomRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpBottomRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpBottomRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpBottomRow.Controls.Add(this.plotVelocity, 0, 0);
            this.tlpBottomRow.Controls.Add(this.plotAcceleration, 1, 0);
            this.tlpBottomRow.Controls.Add(this.grpLiveForceDiagram, 2, 0);
            this.tlpBottomRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottomRow.Location = new System.Drawing.Point(3, 255);
            this.tlpBottomRow.Name = "tlpBottomRow";
            this.tlpBottomRow.RowCount = 1;
            this.tlpBottomRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottomRow.Size = new System.Drawing.Size(1194, 162);
            this.tlpBottomRow.TabIndex = 1;

            // plotVelocity
            this.plotVelocity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotVelocity.Location = new System.Drawing.Point(3, 3);
            this.plotVelocity.Name = "plotVelocity";
            this.plotVelocity.Size = new System.Drawing.Size(391, 156);
            this.plotVelocity.TabIndex = 0;

            // plotAcceleration
            this.plotAcceleration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotAcceleration.Location = new System.Drawing.Point(400, 3);
            this.plotAcceleration.Name = "plotAcceleration";
            this.plotAcceleration.Size = new System.Drawing.Size(391, 156);
            this.plotAcceleration.TabIndex = 1;

            // grpLiveForceDiagram
            this.grpLiveForceDiagram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.grpLiveForceDiagram.Controls.Add(this.lblLiveForceAscii);
            this.grpLiveForceDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLiveForceDiagram.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.grpLiveForceDiagram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.grpLiveForceDiagram.Location = new System.Drawing.Point(797, 3);
            this.grpLiveForceDiagram.Name = "grpLiveForceDiagram";
            this.grpLiveForceDiagram.Size = new System.Drawing.Size(394, 156);
            this.grpLiveForceDiagram.TabIndex = 2;
            this.grpLiveForceDiagram.Text = "⚡ Canlı Kuvvet Vektör Diyagramı";

            // lblLiveForceAscii
            this.lblLiveForceAscii.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLiveForceAscii.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLiveForceAscii.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblLiveForceAscii.Location = new System.Drawing.Point(3, 19);
            this.lblLiveForceAscii.Name = "lblLiveForceAscii";
            this.lblLiveForceAscii.Padding = new System.Windows.Forms.Padding(4);
            this.lblLiveForceAscii.Size = new System.Drawing.Size(388, 134);
            this.lblLiveForceAscii.Text = "     ▲ F_d (Hava Sürtünmesi @ A=0.0450m²) = +0.00 N\r\n     ▲ F_dış (Timeline Aktör Kuvveti)        = +0.00 N\r\n┌────┴─────────────────────────────────────────────┐\r\n│  GÖREV YÜKÜ (FAZ 4): 1.25 kg (Açık Kanat)     │\r\n└────┬─────────────────────────────────────────────┘\r\n     ▼ F_g (Yerçekimi Kuvveti)                 = -12.26 N\r\n------------------------------------------------------\r\n  NET BİLEŞKE: -12.26 N | İVME: -9.81 m/s²";

            // lblConfidenceDisplay
            this.lblConfidenceDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblConfidenceDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblConfidenceDisplay.Location = new System.Drawing.Point(835, 5);
            this.lblConfidenceDisplay.Name = "lblConfidenceDisplay";
            this.lblConfidenceDisplay.Size = new System.Drawing.Size(180, 24);
            this.lblConfidenceDisplay.Text = "🟢 Güven: %100.0";

            // prgConfidence
            this.prgConfidence.Location = new System.Drawing.Point(835, 32);
            this.prgConfidence.Name = "prgConfidence";
            this.prgConfidence.Size = new System.Drawing.Size(180, 14);
            this.prgConfidence.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prgConfidence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.prgConfidence.Minimum = 0;
            this.prgConfidence.Maximum = 100;
            this.prgConfidence.Value = 100;

            // 
            // TimelineStudioSubPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMainCharts);
            this.Controls.Add(this.pnlViewModeButtons);
            this.Controls.Add(this.timelineControl);
            this.Controls.Add(this.grpAddEvent);
            this.Controls.Add(this.pnlHeaderControls);
            this.Name = "TimelineStudioSubPanel";
            this.Size = new System.Drawing.Size(1200, 700);

            this.pnlHeaderControls.ResumeLayout(false);
            this.grpAddEvent.ResumeLayout(false);
            this.grpAddEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEndVal)).EndInit();
            this.pnlViewModeButtons.ResumeLayout(false);
            this.tlpMainCharts.ResumeLayout(false);
            this.tlpBottomRow.ResumeLayout(false);
            this.grpLiveForceDiagram.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
