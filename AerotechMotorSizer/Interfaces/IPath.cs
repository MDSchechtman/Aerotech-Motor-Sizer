using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IPath
    {
        double[] Position { get; set; }
        double[] Velocity { get; }
        double[] Acceleration { get; }
        double[] Time { get; set; }

        void FromConverter(IConverter converter);
    }
}
