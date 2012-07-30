using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IConverter
    {
        bool HasPosition { get; }
        bool HasVelocity { get; }
        bool HasAcceleration { get; }
        double[] Position { get; }
        double[] Velocity { get; }
        double[] Acceleration { get; }
        double[] Time  {get; }
        String accelerationType { get; set; }
    }
}
