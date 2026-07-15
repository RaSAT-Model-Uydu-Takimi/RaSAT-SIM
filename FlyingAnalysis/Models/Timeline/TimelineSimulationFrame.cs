namespace FlyingAnalysis.Models.Timeline
{
    public class TimelineSimulationFrame
    {
        public double Time { get; set; }

        // Konum (İrtifa [m])
        public double TruePosition { get; set; }
        public double RawBaroPosition { get; set; }
        public double CalibratedBaroPosition { get; set; }

        // Hız [m/s]
        public double TrueVelocity { get; set; }

        // İvme [m/s²]
        public double TrueAcceleration { get; set; }
        public double RawAcceleration { get; set; }
        public double CalibratedAcceleration { get; set; }

        // Çevre ve Kuvvetler
        public double Temperature { get; set; }
        public double AppliedExternalForceNewton { get; set; }
        public double GravityForceNewton { get; set; }
        public double DragForceNewton { get; set; }
        public double NetForceNewton { get; set; }

        // Durumlar
        public bool IsSensorCutoffActive { get; set; }
        public bool IsSpecialNoiseActive { get; set; }
    }
}
