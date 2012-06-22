using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IRecord
    {
        List<double> Position { get; }
        List<double> Velocity { get; }
        List<double> Time { get; }
        List<double> Temperature { get; }
        List<double> Acceleration { get; }
        List<double> Current { get; }
        List<double> Torque { get; }

        void Add(double position, double velocity, double time, double temperature, 
                        double acceleration, double current, double torque);

        double GetMaxCurrent();
        double GetMaxTorque();
        double GetAverageCurrent();
        double GetAverageTorque();
        double GetMaxTemperature();
    }
}
