using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Interfaces;

namespace ParameterSet
{
    public class ParameterSet
    {

        /* DO NOT EDIT - Parameters:
            distanceOfTravel,   // Distance of travel
            totalTime,          // Total time of travel
            percentage,         // Percentage of time spent moving
            maxVelocity,        // Max velocity
            peakAcceleratiin,   // Peak acceleration
            accelDistance,      // Acceleration distance
            maxTravel,          // Max travel
            scanDistance        // Scan distance
        */

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
                index++;
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
            bool one = getKey(parameters, 1, out param1, out value1);
            bool two = getKey(parameters, 2, out param2, out value2);

            if (!(zero && one && two))
                throw new Exception("Parameters could not be determined!");

            // Invoke the proper method based on the input parameters
            string invokeString = string.Format("{0}_{1}_{2}_converter", param0, param1, param2);
            MethodInfo info = typeof(ParameterSet).GetMethod(invokeString);
            double[] values =  new double[] { value0, value1, value2 };
            info.Invoke(this, new object[] { values });
        }

        public void distanceOfTravel_totalTime_percentage_converter(double[] values) 
        { 

        }

        public void distanceOfTravel_maxVelocity_percentage_converter(double[] values)
        {

        }

        public void distanceOfTravel_maxVelocity_totalTime_converter(double[] values)
        {

        }

        public void distanceOfTravel_maxVelocity_peakAcceleration_converter(double[] valuesn)
        {

        }

        public void accelDistance_maxVelocity_totalTravel_converter(double[] values)
        {

        }

        public void accelDistance_maxVelocity_totalTime_converter(double[] values)
        {

        }

        public void peakAcceleration_maxVelocity_maxTravel_converter(double[] values)
        {

        }

        public void peakAcceleration_maxVelocity_totalTime_converter(double[] values)
        {

        }

        public void peakAcceleration_maxVelocity_scanDistance_converter(double[] values)
        {

        }

        public void totalTravel_maxVelocity_scanDistance_converter(double[] values)
        {

        }

        public void totalTime_maxVelocity_scanDistance_converter(double[] values)
        {

        }

        // Unit test - Dummy method
        public string dummyValue;
        public double dummyValue0, dummyValue1, dummyValue2;
        public void distanceOfTravel_scanDistance_percentage_converter(double[] values)
        {
            dummyValue0 = values[0];
            dummyValue1 = values[1];
            dummyValue2 = values[2];

            dummyValue = "Dynamic invocation is neat!";
        }



    }
}
