using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FlyingAnalysis.Models.Timeline;

namespace FlyingAnalysis.UI.Controls
{
    public class AfterEffectsTimelineControl : UserControl
    {
        private double _totalDurationSeconds = 30.0;
        private double _currentPlayheadTime = 0.0;
        private bool _isScrubbing = false;

        // Olay Sürükleme ve Seçim Durumları
        public TimelineEventItem? SelectedEvent { get; private set; }
        private bool _isDraggingEvent = false;
        private int _dragStartX = 0;
        private double _dragEventStartTime = 0.0;
        private double _dragEventEndTime = 0.0;

        public List<TimelineEventItem> TimelineEvents { get; private set; } = new List<TimelineEventItem>();

        public event EventHandler<double>? PlayheadTimeChanged;
        public event EventHandler<TimelineEventItem?>? EventSelected;
        public event EventHandler? EventsModified;

        public double TotalDurationSeconds
        {
            get => _totalDurationSeconds;
            set
            {
                if (value < 5.0) value = 5.0;
                _totalDurationSeconds = value;
                Invalidate();
            }
        }

        public double CurrentPlayheadTime
        {
            get => _currentPlayheadTime;
            set
            {
                if (value < 0.0) value = 0.0;
                if (value > _totalDurationSeconds) value = _totalDurationSeconds;
                _currentPlayheadTime = value;
                Invalidate();
            }
        }

        private float LeftMargin => 140f;
        private float RightMargin => 30f;
        private float TopRulerHeight => 40f;

        public AfterEffectsTimelineControl()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(30, 41, 59); // Slate-800
            this.MinimumSize = new Size(500, 130);
            this.Cursor = Cursors.Hand;
        }

        public void SetEvents(List<TimelineEventItem> events)
        {
            TimelineEvents = events ?? new List<TimelineEventItem>();
            SelectedEvent = null;
            Invalidate();
        }

        public void DeleteSelectedEvent()
        {
            if (SelectedEvent != null && TimelineEvents.Contains(SelectedEvent))
            {
                TimelineEvents.Remove(SelectedEvent);
                SelectedEvent = null;
                EventSelected?.Invoke(this, null);
                EventsModified?.Invoke(this, EventArgs.Empty);
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                float trackWidth = this.Width - LeftMargin - RightMargin;
                if (trackWidth > 10f && e.Y > TopRulerHeight)
                {
                    float pixelsPerSec = (float)(trackWidth / _totalDurationSeconds);
                    float rowTop = TopRulerHeight + 8f;
                    float rowHeight = 22f;
                    float rowGap = 4f;

                    // Tıklanan olayı kontrol et
                    for (int i = TimelineEvents.Count - 1; i >= 0; i--)
                    {
                        var ev = TimelineEvents[i];
                        float blockY = rowTop + i * (rowHeight + rowGap);
                        float startX = LeftMargin + (float)(ev.StartTime * pixelsPerSec);
                        float endX = LeftMargin + (float)(ev.EndTime * pixelsPerSec);
                        float blockW = Math.Max(4f, endX - startX);

                        var rect = new RectangleF(startX, blockY, blockW, rowHeight);
                        if (rect.Contains(e.Location))
                        {
                            SelectedEvent = ev;
                            EventSelected?.Invoke(this, SelectedEvent);
                            _isDraggingEvent = true;
                            _dragStartX = e.X;
                            _dragEventStartTime = ev.StartTime;
                            _dragEventEndTime = ev.EndTime;
                            Invalidate();
                            return;
                        }
                    }
                }

                // Bir olaya tıklanmadıysa veya cetvele tıklandıysa: playhead sar / seçimi iptal et
                SelectedEvent = null;
                EventSelected?.Invoke(this, null);
                _isScrubbing = true;
                UpdatePlayheadFromMouse(e.X);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_isDraggingEvent && SelectedEvent != null)
            {
                float trackWidth = this.Width - LeftMargin - RightMargin;
                if (trackWidth > 10f)
                {
                    float pixelsPerSec = (float)(trackWidth / _totalDurationSeconds);
                    double deltaSec = (e.X - _dragStartX) / (double)pixelsPerSec;
                    double duration = _dragEventEndTime - _dragEventStartTime;

                    double newStart = Math.Max(0.0, _dragEventStartTime + deltaSec);
                    if (newStart + duration > _totalDurationSeconds)
                        newStart = _totalDurationSeconds - duration;

                    SelectedEvent.StartTime = Math.Round(newStart, 2);
                    SelectedEvent.EndTime = Math.Round(newStart + duration, 2);
                    Invalidate();
                }
            }
            else if (_isScrubbing)
            {
                UpdatePlayheadFromMouse(e.X);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                if (_isDraggingEvent)
                {
                    _isDraggingEvent = false;
                    EventsModified?.Invoke(this, EventArgs.Empty);
                }
                _isScrubbing = false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Delete || keyData == Keys.Back)
            {
                if (SelectedEvent != null)
                {
                    DeleteSelectedEvent();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UpdatePlayheadFromMouse(int mouseX)
        {
            float trackWidth = this.Width - LeftMargin - RightMargin;
            if (trackWidth <= 10f) return;

            float relX = mouseX - LeftMargin;
            double ratio = relX / trackWidth;
            if (ratio < 0.0) ratio = 0.0;
            if (ratio > 1.0) ratio = 1.0;

            double newTime = ratio * _totalDurationSeconds;
            _currentPlayheadTime = Math.Round(newTime, 2);
            PlayheadTimeChanged?.Invoke(this, _currentPlayheadTime);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float trackWidth = this.Width - LeftMargin - RightMargin;
            if (trackWidth <= 10f) return;

            float pixelsPerSec = (float)(trackWidth / _totalDurationSeconds);

            // 1. Sol Başlık ve Arka Plan Gridi
            using (var bgBrush = new SolidBrush(Color.FromArgb(15, 23, 42))) // Slate-900
            {
                g.FillRectangle(bgBrush, LeftMargin, 0, trackWidth, this.Height);
            }

            using (var titleFont = new Font("Segoe UI Semibold", 9f, FontStyle.Bold))
            using (var textBrush = new SolidBrush(Color.FromArgb(203, 213, 225)))
            {
                g.DrawString("🎬 TIMELINE KATMANLARI", titleFont, textBrush, 10, 10);
            }

            // 2. Zaman Cetveli (Ruler)
            using (var rulerBg = new SolidBrush(Color.FromArgb(51, 65, 85)))
            {
                g.FillRectangle(rulerBg, LeftMargin, 0, trackWidth, TopRulerHeight);
            }

            using (var tickPen = new Pen(Color.FromArgb(148, 163, 184), 1f))
            using (var fontSmall = new Font("Segoe UI", 8f))
            using (var brushSmall = new SolidBrush(Color.FromArgb(226, 232, 240)))
            {
                int totalSecs = (int)Math.Ceiling(_totalDurationSeconds);
                for (int s = 0; s <= totalSecs; s++)
                {
                    float x = LeftMargin + s * pixelsPerSec;
                    if (x > LeftMargin + trackWidth) break;

                    bool isMajor = (s % 5 == 0) || (s == 0) || (s == totalSecs);
                    float tickHeight = isMajor ? 14f : 6f;
                    g.DrawLine(tickPen, x, TopRulerHeight - tickHeight, x, TopRulerHeight);

                    if (isMajor)
                    {
                        string str = $"{s}s";
                        var sz = g.MeasureString(str, fontSmall);
                        g.DrawString(str, fontSmall, brushSmall, x - sz.Width / 2f, 4f);
                    }
                }
            }

            // 3. Olay Katman Bloklarını Çiz
            float rowTop = TopRulerHeight + 8f;
            float rowHeight = 22f;
            float rowGap = 4f;

            using (var fontBlock = new Font("Segoe UI Semibold", 8f))
            using (var brushText = new SolidBrush(Color.White))
            using (var borderPen = new Pen(Color.FromArgb(255, 255, 255), 1f))
            {
                for (int i = 0; i < TimelineEvents.Count; i++)
                {
                    var ev = TimelineEvents[i];
                    float blockY = rowTop + i * (rowHeight + rowGap);
                    if (blockY + rowHeight > this.Height - 10f) break;

                    // Sol Etiket
                    using (var lblBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
                    {
                        string typeHeader = ev.EventType == TimelineEventType.Force ? "[Kuvvet]" :
                                            ev.EventType == TimelineEventType.SensorCutoff ? "[Kesinti]" : "[Gürültü]";
                        g.DrawString($"{typeHeader} {ev.Label}", fontBlock, lblBrush, 8, blockY + 3f);
                    }

                    float startX = LeftMargin + (float)(ev.StartTime * pixelsPerSec);
                    float endX = LeftMargin + (float)(ev.EndTime * pixelsPerSec);
                    float blockW = endX - startX;
                    if (blockW < 4f) blockW = 4f;

                    using (var blockBrush = new SolidBrush(Color.FromArgb(200, ev.BlockColor)))
                    {
                        g.FillRectangle(blockBrush, startX, blockY, blockW, rowHeight);
                        if (ev == SelectedEvent)
                        {
                            using (var selectedPen = new Pen(Color.FromArgb(250, 204, 21), 2.5f))
                            {
                                g.DrawRectangle(selectedPen, startX, blockY, blockW, rowHeight);
                            }
                        }
                        else
                        {
                            g.DrawRectangle(borderPen, startX, blockY, blockW, rowHeight);
                        }
                    }

                    string infoStr = ev.EventType == TimelineEventType.Force ? $"{ev.StartValue:+0.0;-0.0;0}N -> {ev.EndValue:+0.0;-0.0;0}N" :
                                     ev.EventType == TimelineEventType.SensorCutoff ? "SENSÖR KAPALI (NaN)" :
                                     $"±{ev.StartValue:F1}σ Şok";
                    if (ev == SelectedEvent) infoStr = "⚡ [SEÇİLİ] " + infoStr;
                    g.DrawString(infoStr, fontBlock, brushText, startX + 6f, blockY + 3f);
                }
            }

            // 4. Kırmızı Playhead İmleci
            float playheadX = LeftMargin + (float)(_currentPlayheadTime * pixelsPerSec);
            using (var playheadPen = new Pen(Color.FromArgb(239, 68, 68), 2f)) // Red-500
            using (var badgeBrush = new SolidBrush(Color.FromArgb(239, 68, 68)))
            using (var badgeTextBrush = new SolidBrush(Color.White))
            using (var badgeFont = new Font("Segoe UI Semibold", 8f, FontStyle.Bold))
            {
                g.DrawLine(playheadPen, playheadX, 0, playheadX, this.Height);

                // Üst Ok İşareti ▼ ve Saat Kutucuğu
                PointF[] arrowPts = new PointF[]
                {
                    new PointF(playheadX - 6f, TopRulerHeight - 8f),
                    new PointF(playheadX + 6f, TopRulerHeight - 8f),
                    new PointF(playheadX, TopRulerHeight + 2f)
                };
                g.FillPolygon(badgeBrush, arrowPts);

                string timeStr = $"{_currentPlayheadTime:F2}s";
                var tSz = g.MeasureString(timeStr, badgeFont);
                float badgeW = tSz.Width + 8f;
                float badgeX = playheadX - badgeW / 2f;
                if (badgeX < LeftMargin) badgeX = LeftMargin;
                if (badgeX + badgeW > LeftMargin + trackWidth) badgeX = LeftMargin + trackWidth - badgeW;

                g.FillRectangle(badgeBrush, badgeX, TopRulerHeight + 3f, badgeW, 16f);
                g.DrawString(timeStr, badgeFont, badgeTextBrush, badgeX + 4f, TopRulerHeight + 3f);
            }
        }
    }
}
