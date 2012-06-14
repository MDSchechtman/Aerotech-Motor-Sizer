using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface IPath
    {
        double[] Position { get; }

        double[] Time { get; }

        IParameterSet ParameterSet { get; set; }
        // internal SetPath();

        IFunction Function { get; set; }
        // internal SetPath();

        bool AngleOfInclination { get; set; }

        bool Import(string file);
    }
}
