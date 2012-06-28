using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IAxis
    {
        double[] Position { get; }
        double[] Velocity { get; }
        double[] Acceleration { get; }
        double[] Time { get; }

        double AngleOfInclination { get; set; }
        
        IPath Path { get; }
        IRecord Record { get; }
    }
}
