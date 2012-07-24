using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Interfaces;

namespace Utility.Converters
{
    public class FileConverter : IConverter
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

        enum FileType
        {
            Position,
            Acceleration,
            Velocity
        }

        /// <summary>
        /// Constucts a new instance of the FileConverter class. This assumes CSV formate delimeted by { , | ; space }
        /// </summary>
        /// <param name="filename">The file to read</param>
        /// <param name="type">The type of data in the file</param>
        public FileConverter(string filename, int type)
        {
            _time = new List<double>();
            _value = new List<double>();

            SetProperties((FileType) type);
            ReadFromFile(filename);
        }


        private void ReadFromFile(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // We only take the first two elements
                string[] row = line.Split(new char[] { ',', '|', ';', ' ' });

                // Ignore invalid entries
                double time;
                double value;
                if (Double.TryParse(row[0], out time))
                {
                    if (Double.TryParse(row[1], out value))
                    {
                        _time.Add(time);
                        _value.Add(value);
                    }
                }
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

        #endregion // Internal Implementation
    }
}
