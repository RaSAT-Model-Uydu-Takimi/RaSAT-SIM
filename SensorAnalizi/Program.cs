using System;
using System.Windows.Forms;

namespace SensorAnalizi
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormSensorAnalizi());
        }
    }
}
