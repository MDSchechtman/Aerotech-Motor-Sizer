using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Environment;

namespace Environment.Test
{
    class EnvironmentTest
    {
        static void Main(string[] args)
        {
            Environment TestEnvironment = new Environment(1.01, 2.01, 3.01, 4.01, 5.01, 6.01);
            Console.WriteLine(TestEnvironment.Friction);
            Console.WriteLine(TestEnvironment.PreLoadForce);
            Console.WriteLine(TestEnvironment.ThrustForce);
            Console.WriteLine(TestEnvironment.AmbientTemp);
            Console.WriteLine(TestEnvironment.MechEfficiency);
            Console.WriteLine(TestEnvironment.Cooling);
            while (true)
            {
            }
        }
    }
}
