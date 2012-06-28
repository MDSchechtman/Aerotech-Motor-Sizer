using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Utility
{
    public class Path : IPath
    {
        private double[] _position;
        private double[] _velocity;
        private double[] _acceleration;
        private double[] _time;
        private bool _angleOfInclination;

        public Path()
        {
        }

        public Path(IConverter converter)
        {
            FromConverter(converter);
        }

        public void FromConverter(IConverter converter)
        {
            _position = converter.Position;
            _time = converter.Time;
        }

        public double[] Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public double[] Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public double[] Acceleration
        {
            get { return _acceleration; }
            set { _acceleration = value; }
        }

        public double[] Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public bool AngleOfInclination
        {
            get { return _angleOfInclination; }
            set { _angleOfInclination = value; }
        }
    }
}
