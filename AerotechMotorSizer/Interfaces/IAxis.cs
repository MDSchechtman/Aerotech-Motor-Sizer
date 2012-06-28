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
        IPath Path { get; }
    }
}
