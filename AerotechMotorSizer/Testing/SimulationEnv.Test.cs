using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Interfaces;
using Utility;

namespace Testing
{
    class SimulationEnvTest : ITesting
    {
        public bool DoTest()
        {
            SimulationEnv TestEnvironment = new SimulationEnv(0.01, 1.01, 2.01, 3.01, 4.01, 5.01, "6.01");

            if (TestEnvironment.StaticFriction != 0.01) return false;
            if (TestEnvironment.DynamicFriction != 1.01) return false;
            if (TestEnvironment.PreLoadForce != 2.01) return false;
            if (TestEnvironment.ThrustForce != 3.01) return false;
            if (TestEnvironment.AmbientTemp != 4.01) return false;
            if (TestEnvironment.MechEfficiency != 5.01) return false;
            if (!TestEnvironment.Cooling.Equals("6.01")) return false;

            return true;
        }
    }
}
