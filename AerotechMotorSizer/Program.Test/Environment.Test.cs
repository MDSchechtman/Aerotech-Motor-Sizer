using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Interfaces;
using Environment;

namespace Environment.Test
{
    class EnvironmentTest : ITesting
    {
        public bool DoTest()
        {
            Environment TestEnvironment = new Environment(1.01, 2.01, 3.01, 4.01, 5.01, 6.01);

            if (TestEnvironment.Friction != 1.01) return false;
            if (TestEnvironment.PreLoadForce != 2.01) return false;
            if (TestEnvironment.ThrustForce != 3.01) return false;
            if (TestEnvironment.AmbientTemp != 4.01) return false;
            if (TestEnvironment.MechEfficiency != 5.01) return false;
            if (TestEnvironment.Cooling != 6.01) return false;

            return true;
        }
    }
}
