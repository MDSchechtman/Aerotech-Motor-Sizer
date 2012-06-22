using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ParameterSet
{
    public class ParameterSet
    {
        public ParameterSet()
        {
        }

        // Get the string name and double value from each key in the dictionary
        private bool getKey(Dictionary<string, double> p, int i, out string s, out double v)
        {
            int index = 0;
            foreach (KeyValuePair<string, double> k in p)
            {
                if (index == i)
                {
                    s = k.Key; v = k.Value;
                    return true;
                }
                i++;
            }
            s = string.Empty; v = 0;
            return false;
        }

        // Given a dictionary of parameters, find and invoke the proper conversion
        // method to get the necessary values for solving
        public void SetParameters(Dictionary<string, double> parameters)
        {
            string param0 = string.Empty;
            string param1 = string.Empty;
            string param2 = string.Empty;

            double value0 = 0;
            double value1 = 0;
            double value2 = 0;

            // Get the paramets, checking for errors
            bool zero = getKey(parameters, 0, out param0, out value0);
            bool one = getKey(parameters, 0, out param1, out value1);
            bool two = getKey(parameters, 0, out param2, out value2);

            if (!(zero && one && two))
                throw new Exception("Parameters could not be determined!");

            // Invoke the proper method based on the input parameters
            string invokeString = string.Format("{0}_{1}_{2}_converter", param0, param1, param2);
            MethodInfo info = typeof(ParameterSet).GetMethod(invokeString);
            info.Invoke(null, new object[] { value0, value1, value2 });
        }

        /* parameters:
            distanceOfTravel,   // Distance of travel
            totalTime,          // Total time of travel
            percentage,         // Percentage of time spent moving
            maxVelocity,        // Max velocity
            peakAcceleratiin,   // Peak acceleration
            accelDistance,      // Acceleration distance
            maxTravel,          // Max travel
            scanDistance        // Scan distance
         */
    }
}
