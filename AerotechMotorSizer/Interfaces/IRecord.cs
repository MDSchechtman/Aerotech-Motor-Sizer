using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IRecord
    {
        double[] Position { get; set; }
        double[] Velocity { get; set; }
        double[] Acceleration { get; set; }
        double[] Time { get; set; }

        double RMScurrent { get; set; }
        double MAXcurrent { get; set; }
        double RMSforce { get; set; }
        double MAXforce { get; set; }
        double TemperatureRise { get; set; }

        void Write(string file);
    }
}
