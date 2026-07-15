using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FlyingAnalysis.Models;

namespace FlyingAnalysis.UI.Panels.SettingsSubPanels
{
    public partial class ChartLayerSettingsSubPanel : UserControl
    {
        private bool _isUpdatingUi = false;
        private TableLayoutPanel _mainLayout = null!;
        private readonly List<(ChartLayerInfo Layer, CheckBox Chk, Button BtnColor, NumericUpDown NumWidth, NumericUpDown NumOrder)> _layerControls = new();

        public ChartLayerSettingsSubPanel()
        {
            InitializeComponent();
            BuildDynamicUI();

            this.Load += (s, e) => SyncFromProfile();
            this.VisibleChanged += (s, e) => { if (this.Visible) SyncFromProfile(); };
        }

        private void BuildDynamicUI()
        {
            this.Controls.Clear();
            _layerControls.Clear();

            _mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 5,
                Padding = new Padding(10)
            };

            _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            _mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));

            int row = 0;

            void AddHeader(string title)
            {
                _mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
                Label lbl = new Label
                {
                    Text = title,
                    Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(250, 204, 21), // Sarı
                    AutoSize = true,
                    Anchor = AnchorStyles.Left | AnchorStyles.Bottom
                };
                _mainLayout.Controls.Add(lbl, 0, row);
                _mainLayout.SetColumnSpan(lbl, 5);
                row++;

                _mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
                _mainLayout.Controls.Add(new Label { Text = "Veri Katmanı", Font = new Font("Segoe UI", 8.5F, FontStyle.Italic), ForeColor = Color.LightGray, AutoSize = true, Anchor = AnchorStyles.Left }, 0, row);
                _mainLayout.Controls.Add(new Label { Text = "Görünür", Font = new Font("Segoe UI", 8.5F, FontStyle.Italic), ForeColor = Color.LightGray, AutoSize = true, Anchor = AnchorStyles.Left }, 1, row);
                _mainLayout.Controls.Add(new Label { Text = "Renk", Font = new Font("Segoe UI", 8.5F, FontStyle.Italic), ForeColor = Color.LightGray, AutoSize = true, Anchor = AnchorStyles.Left }, 2, row);
                _mainLayout.Controls.Add(new Label { Text = "Kalınlık", Font = new Font("Segoe UI", 8.5F, FontStyle.Italic), ForeColor = Color.LightGray, AutoSize = true, Anchor = AnchorStyles.Left }, 3, row);
                _mainLayout.Controls.Add(new Label { Text = "Sıra (Z-Order)", Font = new Font("Segoe UI", 8.5F, FontStyle.Italic), ForeColor = Color.LightGray, AutoSize = true, Anchor = AnchorStyles.Left }, 4, row);
                row++;
            }

            void AddLayerRow(string label, ChartLayerInfo layer)
            {
                _mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));

                Label lblName = new Label { Text = label, AutoSize = true, Anchor = AnchorStyles.Left };
                CheckBox chkVis = new CheckBox { Checked = layer.Show, Anchor = AnchorStyles.Left };
                
                Button btnColor = new Button
                {
                    Text = "🎨",
                    BackColor = layer.Color,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Height = 28,
                    Width = 60
                };

                NumericUpDown numWidth = new NumericUpDown
                {
                    DecimalPlaces = 1,
                    Minimum = (decimal)0.5,
                    Maximum = (decimal)15.0,
                    Increment = (decimal)0.5,
                    Value = (decimal)Math.Clamp(layer.LineWidth, 0.5f, 15.0f),
                    Width = 65
                };

                NumericUpDown numOrder = new NumericUpDown
                {
                    Minimum = 1,
                    Maximum = 20,
                    Value = Math.Clamp(layer.DrawOrder, 1, 20),
                    Width = 60
                };

                btnColor.Click += (s, e) =>
                {
                    using var cd = new ColorDialog { Color = btnColor.BackColor };
                    if (cd.ShowDialog() == DialogResult.OK)
                    {
                        btnColor.BackColor = cd.Color;
                        ApplyAndNotify();
                    }
                };

                chkVis.CheckedChanged += (s, e) => ApplyAndNotify();
                numWidth.ValueChanged += (s, e) => ApplyAndNotify();
                numOrder.ValueChanged += (s, e) => ApplyAndNotify();

                _mainLayout.Controls.Add(lblName, 0, row);
                _mainLayout.Controls.Add(chkVis, 1, row);
                _mainLayout.Controls.Add(btnColor, 2, row);
                _mainLayout.Controls.Add(numWidth, 3, row);
                _mainLayout.Controls.Add(numOrder, 4, row);

                _layerControls.Add((layer, chkVis, btnColor, numWidth, numOrder));
                row++;
            }

            var p = GlobalSimulationConfig.ChartProfile;

            AddHeader("📍 Konum Zaman Grafiği Katmanları");
            AddLayerRow("Gerçek Referans Konum (True)", p.PosTrue);
            AddLayerRow("Ham Barometre Konumu (Raw)", p.PosRaw);
            AddLayerRow("Kalibre Barometre Konumu (Cal)", p.PosCal);
            AddLayerRow("Kalman Kestirim Konumu (Est EKF)", p.PosEst);

            AddHeader("⚡ Hız Zaman Grafiği Katmanları");
            AddLayerRow("Gerçek Hız (True)", p.VelTrue);
            AddLayerRow("Kalman Kestirim Hızı (Est EKF)", p.VelEst);

            AddHeader("🚀 İvme Zaman Grafiği Katmanları");
            AddLayerRow("Gerçek İvme (True)", p.AccTrue);
            AddLayerRow("Ham İvmeölçer Verisi (Raw)", p.AccRaw);
            AddLayerRow("Kalibre İvmeölçer Verisi (Cal)", p.AccCal);
            AddLayerRow("Kalman Kestirim İvmesi (Est EKF)", p.AccEst);

            AddHeader("📊 Sensör Analiz & Zaman Serisi (Sayfa 2) Katmanları");
            AddLayerRow("Sensör Referans Verisi (True)", p.SensorTsTrue);
            AddLayerRow("Sensör Ham Ölçümü (Raw)", p.SensorTsRaw);
            AddLayerRow("Sensör Kalibre Ölçümü (Cal)", p.SensorTsCal);

            AddHeader("📈 Sensör Dağılım & Çan Eğrisi (Sayfa 2) Katmanları");
            AddLayerRow("Dağılım Referans Hattı (True)", p.SensorDistTrueLine);
            AddLayerRow("Dağılım Ham Histogram / Eğri (Raw)", p.SensorDistRaw);
            AddLayerRow("Dağılım Kalibre Histogram / Eğri (Cal)", p.SensorDistCal);

            this.Controls.Add(_mainLayout);
        }

        private void SyncFromProfile()
        {
            _isUpdatingUi = true;
            foreach (var item in _layerControls)
            {
                item.Chk.Checked = item.Layer.Show;
                item.BtnColor.BackColor = item.Layer.Color;
                item.NumWidth.Value = (decimal)Math.Clamp(item.Layer.LineWidth, 0.5f, 15.0f);
                item.NumOrder.Value = Math.Clamp(item.Layer.DrawOrder, 1, 20);
            }
            _isUpdatingUi = false;
        }

        private void ApplyAndNotify()
        {
            if (_isUpdatingUi) return;

            foreach (var item in _layerControls)
            {
                item.Layer.Show = item.Chk.Checked;
                item.Layer.Color = item.BtnColor.BackColor;
                item.Layer.LineWidth = (float)item.NumWidth.Value;
                item.Layer.DrawOrder = (int)item.NumOrder.Value;
            }

            GlobalSimulationConfig.NotifyChartStylingChanged();
        }
    }
}
