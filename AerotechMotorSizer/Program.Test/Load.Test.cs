using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Interfaces;
using Load;

namespace Load.Test
{
    class LoadTest : ITesting
    {
        public bool DoTest()
        {
            Load TestLoad = new Load(1.01, 2.01);

            if (TestLoad.Mass != 1.01) return false;
            if (TestLoad.MomentOfInertia != 2.01) return false;

            return true;
        }
    }
}
