using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        private double[] _value;
        private double[] _time;

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
            get { return _value; }
        }

        public double[] Velocity
        {
            get { return _value; }
        }

        public double[] Acceleration
        {
            get { return _value; }
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
            Velocity,
            Acceleration
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
            int size = Convert.ToInt32(length / interval) + 1;

            //_time = new List<double>();
            //_value = new List<double>();
            _time = new double[size];
            _value = new double[size];

            for (int i = 0; i < size; i++)
            {
                _time[i] = (i * interval);
                String TempString = function.Replace("x", System.Convert.ToString(_time[i]));
                Expression e = new Expression(TempString);
                try
                {
                    object result = e.Evaluate();
                    _value[i] = (Convert.ToDouble(result));
                }
                catch(Exception a)
                {
                    MessageBox.Show("Error caught: " + a.Message);
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
