using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NCalc;
using Interfaces;

namespace Utility.Converters
{
    public class FunctionConverter : IConverter
    {
        #region IConverter Implementation

        private bool _hasPosition;
        private bool _hasVelocity;
        private bool _hasAcceleration;

        private List<double> _value;
        private List<double> _time;

        public bool HasPosition
        {
            get { return _hasPosition; }
        }

        public bool HasVelocity
        {
            get { return _hasVelocity; }
        }

        public bool HasAcceleration
        {
            get { return _hasAcceleration; }
        }

        public double[] Position
        {
            get { return _value.ToArray(); }
        }

        public double[] Velocity
        {
            get { return _value.ToArray(); }
        }

        public double[] Acceleration
        {
            get { return _value.ToArray(); }
        }

        public double[] Time
        {
            get { return _time.ToArray(); }
        }

        #endregion // IConverter Implementation

        #region Internal Implementation

        enum FunctionType
        {
            Position,
            Acceleration,
            Velocity
        }

        /// <summary>
        /// Creates a new instance of the FunctionConverterClass
        /// </summary>
        /// <param name="function">The function as a string</param>
        /// <param name="length"></param>
        /// <param name="interval"></param>
        /// <param name="type">The type of data the function represents</param>
        public FunctionConverter(String function, double length, double interval, int type)
        {
            int size = Convert.ToInt32(length / interval);

            _time = new List<double>();
            _value = new List<double>();

            for (int i = 0; i < size; i++)
            {
                _time.Add(i * interval);
                String TempString = function.Replace("x", System.Convert.ToString(_time[i]));
                Expression e = new Expression(TempString);
                try
                {
                    object result = e.Evaluate();
                    _value.Add(Convert.ToDouble(result));
                }
                catch(EvaluationException a)
                {
                    Console.WriteLine("Error caught: " + a.Message);
                }
            }

            SetProperties((FunctionType)type);
        }

        private void SetProperties(FunctionType type)
        {
            switch (type)
            {
                case FunctionType.Acceleration:
                    _hasPosition = false;
                    _hasVelocity = false;
                    _hasAcceleration = true;
                    break;
                case FunctionType.Position:
                    _hasPosition = true;
                    _hasVelocity = false;
                    _hasAcceleration = false;
                    break;
                case FunctionType.Velocity:
                    _hasPosition = false;
                    _hasVelocity = true;
                    _hasAcceleration = false;
                    break;
            }
        }

        #endregion // Internal Implementation
    }
}
