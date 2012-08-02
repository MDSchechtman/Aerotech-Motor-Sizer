using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using Interfaces;

namespace Utility
{
    public class Axis : IAxis
    {
        private IPath _path;
        private IConverter _converter;
        private IRecord _record;
        private double _angleOfInclination;
        private bool _valid;

        /// <summary>
        /// Creates a new instance of the axis class
        /// </summary>
        public Axis()
        {
            _valid = false;
        }

        /// <summary>
        /// Creates a new instance of the axis class
        /// </summary>
        /// <param name="path">That path to use</param>
        public Axis(IPath path)
        {
            _valid = true;
            _path = path;

            SetPath(path);
        }

        /// <summary>
        /// Creates a new instance of the axis class
        /// </summary>
        /// <param name="converter">The converter to use</param>
        public Axis(IConverter converter)
        {
            _valid = true;
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
            _valid = true;
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

        public bool Valid
        {
            get { return _valid; }
            set { _valid = value; }
        }

        [XmlIgnoreAttribute]
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

        [XmlIgnoreAttribute]
        public IPath Path
        {
            get { return _path; }
        }

        [XmlIgnoreAttribute]
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

        public Path XmlSerializablePath
        {
            get { return (Path)_path; }
            set { _path = value; }
        }

        public Record XmlSerializableRecord
        {
            get { return (Record)_record; }
            set { _record = value; }
        }
    }
}
