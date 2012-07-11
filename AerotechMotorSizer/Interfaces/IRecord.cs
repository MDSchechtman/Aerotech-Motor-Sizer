using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IRecord
    {
        double[] Position { get; }
        double[] Velocity { get; }
        double[] Time { get; }
        double[] Acceleration { get; }
        double RMScurrent { get; set; }
        double MAXcurrent { get; set; }
        double RMSforce { get; set; }
        double MAXforce { get; set; }
        double TemperatureRise { get; set; }

        void Add(double position, double velocity, double time, double temperature, 
                 double acceleration, double current, double torque);

        void Write(string file);

        double GetMaxCurrent();
        double GetMaxTorque();
        double GetAverageCurrent();
        double GetAverageTorque();
        double GetMaxTemperatureRise();
    }
}
