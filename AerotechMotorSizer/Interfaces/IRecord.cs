using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

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

        double GetMaxCurrent();
        double GetMaxTorque();
        double GetAverageCurrent();
        double GetAverageTorque();
        double GetMaxTemperature();
    }
}
