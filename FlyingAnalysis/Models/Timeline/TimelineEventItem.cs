using System.Drawing;

namespace FlyingAnalysis.Models.Timeline
{
    public enum TimelineEventType
    {
        Force,                 // 1. Dış Kuvvet Uygula [Newton] (Rüzgar, İtki, Darbe vb.)
        SensorCutoff,          // 2. Sensörü Kapat / Veri Kesintisi (Blackout - NaN/0)
        SpecialConditionNoise  // 3. Özel Durum Gürültüsü [±σ Şok] (Eski adı: Ayrılma/Faz Gürültüsü)
    }

    public enum TargetSensorType
    {
        All,           // Tüm Sensörler (Barometre, İvmeölçer, Sıcaklık)
        Accelerometer, // Sadece İvmeölçer
        Barometer,     // Sadece Barometre
        Temperature    // Sadece Sıcaklık Sensörü
    }

    public class TimelineEventItem
    {
        public string Label { get; set; } = string.Empty;
        public TimelineEventType EventType { get; set; }
        public TargetSensorType TargetSensor { get; set; } = TargetSensorType.All;
        public double StartTime { get; set; }
        public double EndTime { get; set; }
        public double StartValue { get; set; }  // Kuvvet için [Newton], Gürültü için [±σ]
        public double EndValue { get; set; }    // Kuvvet için [Newton], Gürültü için [±σ]
        public Color BlockColor { get; set; }

        public TimelineEventItem()
        {
        }

        public TimelineEventItem(string label, TimelineEventType eventType, double startTime, double endTime, double startVal, double endVal, Color color)
        {
            Label = label;
            EventType = eventType;
            StartTime = startTime;
            EndTime = endTime;
            StartValue = startVal;
            EndValue = endVal;
            BlockColor = color;
        }

        public double GetInterpolatedValue(double currentTime)
        {
            if (currentTime < StartTime || currentTime > EndTime)
                return 0.0;

            if (EndTime <= StartTime)
                return StartValue;

            double tRatio = (currentTime - StartTime) / (EndTime - StartTime);
            return StartValue + tRatio * (EndValue - StartValue);
        }
    }
}
