using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface IRecord
    {
        public List<double> Position { get; }
        public List<double> Velocity { get; }
        public List<double> Time { get; }
        public List<double> Temperature { get; }
        public List<double> Acceleration { get; }
        public List<double> Current { get; }
        public List<double> Torque { get; }

        public void Add(double position, double velocity, double time, double temperature, 
                        double acceleration, double current, double torque);

        public double GetMaxCurrent();
        public double GetMaxTorque();
        public double GetAverageCurrent();
        public double GetAverageTorque();
        public double GetMaxTemperature();
    }
}
