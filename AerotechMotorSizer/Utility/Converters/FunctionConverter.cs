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
        enum FileType
        {
            Position,
            Acceleration,
            Velocity
        }

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
                    Console.WriteLine("Error catched: " + a.Message);
                }
                SetProperties((FileType)type);
            }
        }

        private void SetProperties(FileType type)
        {
            switch (type)
            {
                case FileType.Acceleration:
                    _hasPosition = false;
                    _hasVelocity = false;
                    _hasAcceleration = true;
                    break;
                case FileType.Position:
                    _hasPosition = true;
                    _hasVelocity = false;
                    _hasAcceleration = false;
                    break;
                case FileType.Velocity:
                    _hasPosition = false;
                    _hasVelocity = true;
                    _hasAcceleration = false;
                    break;
            }
        }
    }
}
