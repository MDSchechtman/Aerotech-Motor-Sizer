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

        /// <summary>
        /// Creates a new instance of the axis class
        /// </summary>
        public Axis() { }

        /// <summary>
        /// Creates a new instance of the axis class
        /// </summary>
        /// <param name="path">That path to use</param>
        public Axis(IPath path)
        {
            _path = path;

            SetPath(path); 
        }

        /// <summary>
        /// Constructs an empty axis
        /// </summary>
        /// <returns></returns>
        public static Axis Invalid()
        {
            return new Axis(new Path(new Utility.Converters.FunctionConverter("x", 1, 1, 1)));
        }

        /// <summary>
        /// Creates a new instance of the axis class
        /// </summary>
        /// <param name="converter">The converter to use</param>
        public Axis(IConverter converter)
        {
            _path = new Path(converter);
            _converter = converter;

            SetPath(_path);
        }

        /// <summary>
        /// Create a new instance of the axis class with the path being created from the converter
        /// </summary>
        /// <param name="path">This parameter is ignored</param>
        /// <param name="converter">The converter to use</param>
        public Axis(IPath path, IConverter converter)
        {
            _path = path;
            _converter = converter;
            _path = new Path(converter);

            SetPath(new Path(converter));
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
