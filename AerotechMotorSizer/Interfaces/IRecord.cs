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
        double[] Temperature { get; }
        double[] Acceleration { get; }
        double[] Current { get; }
        double[] Torque { get; }

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
