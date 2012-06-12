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

        public bool AngleOfInclination { get; set; }

        bool Import(string file);

        bool SetPath(List<string> parameters);
    }
}
