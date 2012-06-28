using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;
using Utility;

namespace Program.Test
{
    public class Converters
    {
        public bool DoTest()
        {
            // Test the ParameterSetConverter
            {
                // Populate the dictionary
                Dictionary<string, double> p = new Dictionary<string, double>();
                p.Add("distanceOfTravel", 10);
                p.Add("totalTime", 20);
                p.Add("percentage", 0.50);

                // Set the parameters to the ParameterSet
                ParameterSetConverter set = new ParameterSetConverter(p);

                // Tests
                if (set.AccelerationTime != 5) return false;
                if (set.DeccelerationTime != 5) return false;
                if (set.TraverseTime != 10) return false;
            }

            // Test the FunctionConverter
            {
            }

            // Test the FileConverter
            {
            }

            return true;
        }
    }
}
