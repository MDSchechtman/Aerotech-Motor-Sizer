using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Interfaces;

namespace Utility.Converters
{
    public class ParameterSetConverter : IConverter
    {

        #region IConverter Implementation

        // Input parameters are only allowed to define
        // postion vs. time paths
        public bool HasPosition
        {
            get { return _position != null; }
        }

        // Not valid for this converter
        public bool HasVelocity
        {
            get { return _velocity != null; }
        }

        // Not valid for this converter
        public bool HasAcceleration
        {
            get { return _acceleration != null; }
        }

        public double[] Position
        {
            get { return _position; }
        }

        public double[] Velocity
        {
            get { return _velocity; }
        }

        public double[] Acceleration
        {
            get { return _acceleration; }
        }

        public double[] Time
        {
            get { return _time; }
        }
        #endregion // IConverter Implementation

        #region Internal Implementation

        private double[] _acceleration;
        private double[] _velocity;
        private double[] _position;
        private double[] _time;
        private double _distanceOfTravel;
        private double _accelerationTime;
        private double _traverseTime;
        private double _decelerationTime;
        private double _dwellTime;
        private double _timeStep;

        /// <summary>
        /// Creates a new instance of the ParameterSetConverter class
        /// </summary>
        /// <param name="parameters">The dictionary of parameters to convert</param>
        public ParameterSetConverter(Dictionary<string, double> parameters) 
        {
            if (parameters.Count == 0)
                throw new Exception("Invalid paramter count!");
            else
                this.SetParameters(parameters);
        }

        // Get the string name and double value from each key in the dictionary
        private bool GetKey(Dictionary<string, double> p, int i, out string s, out double v)
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
            string timeStepStr = string.Empty;

            double value0 = 0;
            double value1 = 0;
            double value2 = 0;
            double timeStep = 0;

            // Get the parameters, checking for errors
            bool zeroValid = GetKey(parameters, 0, out param0, out value0);
            bool oneValid = GetKey(parameters, 1, out param1, out value1);
            bool twoValid = GetKey(parameters, 2, out param2, out value2);
            bool timeValid = GetKey(parameters, 3, out timeStepStr, out timeStep);

            if (!(zeroValid && oneValid && twoValid && timeValid))
                throw new Exception("Parameters could not be determined!");

            _timeStep = timeStep;

            // Invoke the proper method based on the input parameters
            string invokeString = string.Format("{0}_{1}_{2}_converter", param0, param1, param2);
            MethodInfo info = typeof(ParameterSetConverter).GetMethod(invokeString, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance);
            double[] values = new double[] { value0, value1, value2 };
            info.Invoke(this, new object[] { values });

            FillArrays();
        }

        private void FillArrays()
        {
            _dwellTime = 0; // for now

            double totalTime = _accelerationTime + _traverseTime + _decelerationTime;
            double accelAndTraverseTime = _accelerationTime + _traverseTime;

            double maxAcceleration = 2 * _distanceOfTravel / (Math.Pow(_accelerationTime, 2) + 2 * _accelerationTime * _traverseTime + _accelerationTime * _decelerationTime);
            double maxDeceleration = -2 * _distanceOfTravel / (_accelerationTime * _decelerationTime + 2 * _traverseTime * _decelerationTime + Math.Pow(_decelerationTime, 2));

            int timeSteps = (int) Math.Ceiling((totalTime + _dwellTime) / _timeStep) + 1;
            int stopAccel = (int) Math.Round(_accelerationTime / _timeStep) + 1;
            int startDecel = (int) Math.Round(accelAndTraverseTime / _timeStep) + 1;

            _time = new double[timeSteps];
            _position = new double[timeSteps];
            _velocity = new double[timeSteps];
            _acceleration = new double[timeSteps];

            for (int i = 0; i < stopAccel; i++)
            {
                _acceleration[i] = maxAcceleration;
                _time[i] = i * _timeStep;
            }

            for (int i = stopAccel; i < startDecel; i++)
            {
                _acceleration[i] = 0;
                _time[i] = i * _timeStep;
            }

            for (int i = startDecel; i < timeSteps; i++)
            {
                _acceleration[i] = maxDeceleration;
                _time[i] = i * _timeStep;
            }

            for (int i = 1; i < timeSteps; i++)
            {
                _velocity[i] = (_time[i] - _time[i - 1]) * _acceleration[i] + _velocity[i - 1];
                _position[i] = (_time[i] - _time[i - 1]) * _velocity[i] + _position[i - 1];
            }
        }

        // DO NOT EDIT FUNCTION NAMES BELOW //
        // DO NOT EDIT FUNCTION NAMES BELOW //
        // DO NOT EDIT FUNCTION NAMES BELOW //
        
        private void distanceOfTravel_accelerationTime_traverseTime_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double distanceOfTravel = values[0];
            double accelerationTime = values[1];
            double traverseTime = values[2];

            _distanceOfTravel = distanceOfTravel;
            _accelerationTime = accelerationTime;
            _traverseTime = traverseTime;
            _decelerationTime = _accelerationTime;
        }

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

            _distanceOfTravel = distanceOfTravel;
            _accelerationTime = .5 * percentage * totalTime;
            _traverseTime = (1 - percentage) * totalTime;
            _decelerationTime = _accelerationTime;
        }

        private void distanceOfTravel_maxVelocity_percentage_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double distanceOfTravel = values[0];
            double maxVelocity = values[1];
            double percentage = values[2];

            _distanceOfTravel = distanceOfTravel;
            _accelerationTime = percentage * distanceOfTravel / maxVelocity;
            _traverseTime = 2 * (1 - percentage) * _accelerationTime / percentage;
            _decelerationTime = _accelerationTime;
        }

        private void distanceOfTravel_maxVelocity_totalTime_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double distanceOfTravel = values[0];
            double maxVelocity = values[1];
            double totalTime = values[2];

            _distanceOfTravel = distanceOfTravel;
            _accelerationTime = totalTime - distanceOfTravel / maxVelocity;
            _traverseTime = totalTime - 2 * _accelerationTime;
            _decelerationTime = _accelerationTime;
        }

        private void distanceOfTravel_maxVelocity_peakAcceleration_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double distanceOfTravel = values[0];
            double maxVelocity = values[1];
            double peakAcceleration = values[2];

            _distanceOfTravel = distanceOfTravel;
            _accelerationTime = maxVelocity / peakAcceleration;
            if (maxVelocity * _accelerationTime > distanceOfTravel)
                _accelerationTime = Math.Sqrt(distanceOfTravel / peakAcceleration);
            _traverseTime = distanceOfTravel - peakAcceleration * _accelerationTime * _accelerationTime;
            _decelerationTime = _accelerationTime;
        }

        private void accelDistance_maxVelocity_totalTravel_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double accelDistance = values[0];
            double maxVelocity = values[1];
            double totalTravel = values[2];

            _distanceOfTravel = totalTravel;
            _accelerationTime = 2 * accelDistance / maxVelocity;
            _traverseTime = (totalTravel - 2 * accelDistance) / maxVelocity;
            _decelerationTime = _accelerationTime;
        }

        private void accelDistance_maxVelocity_totalTime_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double accelDistance = values[0];
            double maxVelocity = values[1];
            double totalTime = values[2];

            _accelerationTime = 2 * accelDistance / maxVelocity;
            _traverseTime = totalTime - 2 * _accelerationTime;
            _decelerationTime = _accelerationTime;
            _distanceOfTravel = maxVelocity * (_accelerationTime + _traverseTime);
        }

        private void peakAcceleration_maxVelocity_maxTravel_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double peakAcceleration = values[0];
            double maxVelocity = values[1];
            double maxTravel = values[2];

            _distanceOfTravel = maxTravel;
            _accelerationTime = maxVelocity / peakAcceleration;
            if (maxVelocity * _accelerationTime > maxTravel)
                _accelerationTime = Math.Sqrt(maxTravel / peakAcceleration);
            _traverseTime = maxTravel - peakAcceleration * _accelerationTime * _accelerationTime;
            _decelerationTime = _accelerationTime;
        }

        private void peakAcceleration_maxVelocity_totalTime_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double peakAcceleration = values[0];
            double maxVelocity = values[1];
            double totalTime = values[2];

            _accelerationTime = maxVelocity / peakAcceleration;
            if (_accelerationTime * 2 > totalTime)
                _accelerationTime = totalTime / 2;
            _traverseTime = (totalTime - 2 * _accelerationTime) / maxVelocity;
            _decelerationTime = _accelerationTime;
            _distanceOfTravel = peakAcceleration * _accelerationTime * (_accelerationTime + _traverseTime);
        }

        private void peakAcceleration_maxVelocity_scanDistance_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double peakAcceleration = values[0];
            double maxVelocity = values[1];
            double scanDistance = values[2];

            _accelerationTime = maxVelocity / peakAcceleration;
            _traverseTime = scanDistance / maxVelocity;
            _decelerationTime = _accelerationTime;
            _distanceOfTravel = maxVelocity * _accelerationTime + scanDistance;
        }

        private void totalTravel_maxVelocity_scanDistance_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double totalTravel = values[0];
            double maxVelocity = values[1];
            double scanDistance = values[2];

            _distanceOfTravel = totalTravel;
            _accelerationTime = (totalTravel - scanDistance) / maxVelocity;
            _traverseTime = scanDistance / maxVelocity;
            _decelerationTime = _accelerationTime;
        }

        private void totalTime_maxVelocity_scanDistance_converter(double[] values)
        {
            if (values.Length != 3)
                throw new Exception("Invalid number of values (three required).");

            double totalTime = values[0];
            double maxVelocity = values[1];
            double scanDistance = values[2];

            _traverseTime = scanDistance / maxVelocity;
            _accelerationTime = (totalTime - _traverseTime) / 2;
            _decelerationTime = _accelerationTime;
            _distanceOfTravel = scanDistance + maxVelocity * _accelerationTime;
        }

        #endregion // Internal Implemenetation
    }
}
