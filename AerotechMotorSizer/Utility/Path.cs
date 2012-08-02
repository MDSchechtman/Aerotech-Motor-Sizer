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

        /// <summary>
        /// Construct an instance of path (for serialization)
        /// </summary>
        public Path() { }

        /// <summary>
        /// Creates a new instance of Path
        /// </summary>
        /// <param name="converter">The converter to use to construct the path</param>
        public Path(IConverter converter)
        {
            FromConverter(converter);
        }

        /// <summary>
        /// Creates a path from the given converter
        /// </summary>
        /// <param name="converter"></param>
        public void FromConverter(IConverter converter)
        {
            if (converter.HasAcceleration)
                _acceleration = converter.Acceleration;
            if (converter.HasVelocity)
                _velocity = converter.Velocity;
            if (converter.HasPosition)
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
