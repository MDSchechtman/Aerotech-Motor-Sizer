using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IPath
    {
        double[] Position { get; set; }
        double[] Time { get; set; }
        bool AngleOfInclination { get; set; }
    }
}
