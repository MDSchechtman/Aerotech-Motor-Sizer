using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Interfaces;

namespace ParameterSet
{
    public class ParameterSet : IParameterSet
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

        /// <summary>
        /// Create a new ParameterSet
        /// </summary>
        /// <param name="parameters">The dictionary of parameters to convert</param>
        public ParameterSet(Dictionary<string, double> parameters) 
        {
            if (parameters.Count == 0)
                throw new Exception("Invalid paramter count!");
            else
                this.SetParameters(parameters);
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
        private void SetParameters(Dictionary<string, double> parameters)
        {
            string param0 = string.Empty;
            string param1 = string.Empty;
            string param2 = string.Empty;

            double value0 = 0;
            double value1 = 0;
            double value2 = 0;

            // Get the parameters, checking for errors
            bool zero = getKey(parameters, 0, out param0, out value0);
            bool one = getKey(parameters, 1, out param1, out value1);
            bool two = getKey(parameters, 2, out param2, out value2);

            if (!(zero && one && two))
                throw new Exception("Parameters could not be determined!");

            // Invoke the proper method based on the input parameters
            string invokeString = string.Format("{0}_{1}_{2}_converter", param0, param1, param2);
            MethodInfo info = typeof(ParameterSet).GetMethod(invokeString, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance);
            double[] values = new double[] { value0, value1, value2 };
            info.Invoke(this, new object[] { values });
        }

        #region Private variables

        // Axis 1
        double m_axis1_DistanceOfTravel;
        double m_axis1_AccelerationTime;
        double m_axis1_TraverseTime;
        double m_axis1_DecelerationTime;
        double m_axis1_DwellTime;

        #endregion

        #region Public Properties

        // Axis 1
        public double[] Axis1_Position 
        {
            get { return new double[] { 0D }; } 
        }

        public double Axis1_AccelerationTime
        {
            get { return 0D; }
        }

        public double Axis1_TraverseTime
        {
            get { return 0D; }
        }

        public double Axis1_DeccelerationTime
        {
            get { return 0D; }
        }

        public double Axis1_DwelTime
        {
            get { return 0D; }
        }

        // Axis 2
        public double[] Axis2_Position
        {
            get { return new double[] { 0D }; }
        }

        public double Axis2_AccelerationTime
        {
            get { return 0D; }
        }

        public double Axis2_TraverseTime
        {
            get { return 0D; }
        }

        public double Axis2_DeccelerationTime
        {
            get { return 0D; }
        }

        public double Axis2_DwelTime
        {
            get { return 0D; }
        }


        // Axis 3
        public double[] Axis3_Position
        {
            get { return new double[] { 0D }; }
        }

        public double Axis3_AccelerationTime
        {
            get { return 0D; }
        }

        public double Axis3_TraverseTime
        {
            get { return 0D; }
        }

        public double Axis3_DeccelerationTime
        {
            get { return 0D; }
        }

        public double Axis3_DwelTime
        {
            get { return 0D; }
        }


        // Time
        public double[] Time
        {
            get { return new double[] { 0D }; }
        }

        #endregion //Public Properties

        #region Converters

        private void distanceOfTravel_totalTime_percentage_converter(double[] values) 
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values. Three values required).");

            double distanceOfTravel;
            double totalTime;
            double percentage;

            if (values[0] >= 0)
                distanceOfTravel = values[0];
            else
                throw new Exception("Invalid distance of travel. Must be a positive number");

            if (values[1] >= 0)
                totalTime = values[1];
            else
                throw new Exception("Invalid total time. Must be a positive number");

            if (values[2] >= 0 && values[2] <= 1)
                percentage = values[2];
            else if (values[2] >= 0 && values[2] <= 100)
                percentage = values[2];
            else
                throw new Exception("Invalid percentage. Must be a value between 0 and 1 or 0 and 100.");

            m_axis1_DistanceOfTravel = distanceOfTravel;
            m_axis1_AccelerationTime = .5 * percentage * totalTime;
            m_axis1_TraverseTime = (1 - percentage) * totalTime;
            m_axis1_DecelerationTime = m_axis1_AccelerationTime;
        }

        private void distanceOfTravel_maxVelocity_percentage_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double distanceOfTravel = values[0];
            double maxVelocity = values[1];
            double percentage = values[2];

            m_axis1_DistanceOfTravel = distanceOfTravel;
            m_axis1_AccelerationTime = percentage * distanceOfTravel / maxVelocity;
            m_axis1_TraverseTime = 2 * (1 - percentage) * m_axis1_AccelerationTime / percentage;
            m_axis1_DecelerationTime = m_axis1_AccelerationTime;
        }

        private void distanceOfTravel_maxVelocity_totalTime_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double distanceOfTravel = values[0];
            double maxVelocity = values[1];
            double totalTime = values[2];

            m_axis1_DistanceOfTravel = distanceOfTravel;
            m_axis1_AccelerationTime = totalTime - distanceOfTravel / maxVelocity;
            m_axis1_TraverseTime = totalTime - 2 * m_axis1_AccelerationTime;
            m_axis1_DecelerationTime = m_axis1_AccelerationTime;
        }

        private void distanceOfTravel_maxVelocity_peakAcceleration_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double distanceOfTravel = values[0];
            double maxVelocity = values[1];
            double peakAcceleration = values[2];

            m_axis1_DistanceOfTravel = distanceOfTravel;
            m_axis1_AccelerationTime = maxVelocity / peakAcceleration;
            if (maxVelocity * m_axis1_AccelerationTime > distanceOfTravel)
                m_axis1_AccelerationTime = Math.Sqrt(distanceOfTravel / peakAcceleration);
            m_axis1_TraverseTime = distanceOfTravel - peakAcceleration * m_axis1_AccelerationTime * m_axis1_AccelerationTime;
            m_axis1_DecelerationTime = m_axis1_AccelerationTime;
        }

        private void accelDistance_maxVelocity_totalTravel_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double accelDistance = values[0];
            double maxVelocity = values[1];
            double totalTravel = values[2];

            m_axis1_DistanceOfTravel = totalTravel;
            m_axis1_AccelerationTime = 2 * accelDistance / maxVelocity;
            m_axis1_TraverseTime = (totalTravel - 2 * accelDistance) / maxVelocity;
            m_axis1_DecelerationTime = m_axis1_AccelerationTime;
        }

        private void accelDistance_maxVelocity_totalTime_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double accelDistance = values[0];
            double maxVelocity = values[1];
            double totalTime = values[2];

            m_axis1_AccelerationTime = 2 * accelDistance / maxVelocity;
            m_axis1_TraverseTime = totalTime - 2 * m_axis1_AccelerationTime;
            m_axis1_DecelerationTime = m_axis1_AccelerationTime;
            m_axis1_DistanceOfTravel = maxVelocity * (m_axis1_AccelerationTime + m_axis1_TraverseTime);
        }

        private void peakAcceleration_maxVelocity_maxTravel_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double peakAcceleration = values[0];
            double maxVelocity = values[1];
            double maxTravel = values[2];

            m_axis1_DistanceOfTravel = maxTravel;
            m_axis1_AccelerationTime = maxVelocity / peakAcceleration;
            if (maxVelocity * m_axis1_AccelerationTime > maxTravel)
                m_axis1_AccelerationTime = Math.Sqrt(maxTravel / peakAcceleration);
            m_axis1_TraverseTime = maxTravel - peakAcceleration * m_axis1_AccelerationTime * m_axis1_AccelerationTime;
            m_axis1_DecelerationTime = m_axis1_AccelerationTime;
        }

        private void peakAcceleration_maxVelocity_totalTime_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double peakAcceleration = values[0];
            double maxVelocity = values[1];
            double totalTime = values[2];

            m_axis1_AccelerationTime = maxVelocity / peakAcceleration;
            if (m_axis1_AccelerationTime * 2 > totalTime)
                m_axis1_AccelerationTime = totalTime / 2;
            m_axis1_TraverseTime = (totalTime - 2 * m_axis1_AccelerationTime) / maxVelocity;
            m_axis1_DecelerationTime = m_axis1_AccelerationTime;
            m_axis1_DistanceOfTravel = peakAcceleration * m_axis1_AccelerationTime * (m_axis1_AccelerationTime + m_axis1_TraverseTime);
        }

        private void peakAcceleration_maxVelocity_scanDistance_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double peakAcceleration = values[0];
            double maxVelocity = values[1];
            double scanDistance = values[2];

            m_axis1_AccelerationTime = maxVelocity / peakAcceleration;
            m_axis1_TraverseTime = scanDistance / maxVelocity;
            m_axis1_DecelerationTime = m_axis1_AccelerationTime;
            m_axis1_DistanceOfTravel = maxVelocity * m_axis1_AccelerationTime + scanDistance;
        }

        private void totalTravel_maxVelocity_scanDistance_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double totalTravel = values[0];
            double maxVelocity = values[1];
            double scanDistance = values[2];

            m_axis1_DistanceOfTravel = totalTravel;
            m_axis1_AccelerationTime = (totalTravel - scanDistance) / maxVelocity;
            m_axis1_TraverseTime = scanDistance / maxVelocity;
            m_axis1_DecelerationTime = m_axis1_AccelerationTime;
        }

        private void totalTime_maxVelocity_scanDistance_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double totalTime = values[0];
            double maxVelocity = values[1];
            double scanDistance = values[2];

            m_axis1_TraverseTime = scanDistance / maxVelocity;
            m_axis1_AccelerationTime = (totalTime - m_axis1_TraverseTime) / 2;
            m_axis1_DecelerationTime = m_axis1_AccelerationTime;
            m_axis1_DistanceOfTravel = scanDistance + maxVelocity * m_axis1_AccelerationTime;
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

        #endregion // Converters



    }
}
