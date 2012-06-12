using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface IState
    {
        public double Position { get; set; }
        public double Velocity { get; set; }
        public double Time { get; set; }
        public double Temperature { get; set; }
        public double Acceleration { get; set; }
        public double Current { get; set; }
        public double Torque { get; set; }
    }
}
