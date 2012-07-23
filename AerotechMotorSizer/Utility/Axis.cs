using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Utility
{
    public class Axis : IAxis
    {
        private IPath _path;
        private IConverter _converter;
        private IRecord _record;
        private double _angleOfInclination;


        public Axis() { }

        /// <summary>
        /// An Axis contains the positions, accelerations, and velocities at descrete times
        /// which are used for solving.
        /// The axis is responsible for garunteeing consistency between its Path and Record times.
        /// </summary>
        public Axis(IPath path)
        {
            SetPath(path); 
        }

        public void SetPath(IPath path)
        {
            _path = path;
            _record = new Record(path);
        }

        public IConverter Converter
        {
            get
            {
                return _converter;
            }
            set
            {
                _converter = value;
            }
        }

        public double[] Position
        {
            get { return _path.Position; }
        }

        public double[] Velocity
        {
            get { return _path.Velocity; }
        }

        public double[] Acceleration
        {
            get { return _path.Acceleration; }
        }

        public double[] Time 
        {
            get { return _path.Time; }
        }

        public double AngleOfInclination
        {
            get { return _angleOfInclination; }
            set { _angleOfInclination = value; }
        }

        public IPath Path
        {
            get { return _path; }
        }

        public IRecord Record
        {
            get { return _record; }
        }

        private bool Check()
        {
            for (int i = 0; i < _path.Time.Length; i++)
            {
                if (_path.Time[i] != _record.Time[i])
                    return false;
            }
            return true;
        }
    }
}
