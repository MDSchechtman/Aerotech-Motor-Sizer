using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;
using Utility;

namespace Program.Test
{
    public class Sanity : ITesting
    {
        public bool DoTest()
        {
            // Load
            Load TestLoad = new Load(1.01, 2.01);
            if (TestLoad.Mass != 1.01) return false;
            if (TestLoad.MomentOfInertia != 2.01) return false;

            // Motor 
            //Motor TestMotor = new Motor(1.01, 2.01, 3.01, 4.01, 5.01, 6.01, 7.01);
            //if (TestMotor.Mass != 1.01) return false;
            //if (TestMotor.MaxTemp != 2.01) return false;
            //if (TestMotor.MomentOfInertia != 3.01) return false;
            //if (TestMotor.Resistance != 4.01) return false;
            //if (TestMotor.Inductance != 5.01) return false;
            //if (TestMotor.ThermalResistance != 6.01) return false;
            //if (TestMotor.KT != 7.01) return false;

            // SimulationEnv
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
