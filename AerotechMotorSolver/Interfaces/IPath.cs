using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface IPath
    {
        public double[] Position { get; }

        public double[] Time { get; }

        public IParameterSet ParameterSet { get; set; }
        // internal SetPath();

        public IFunction Function { get; set; }
        // internal SetPath();

        public bool AngleOfInclination { get; set; }

        bool Import(string file);
    }
}
