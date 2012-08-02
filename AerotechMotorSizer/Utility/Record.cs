using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Interfaces;

namespace Utility
{
    public class Record : IRecord
    {
        public double[] _position;
        public double[] _velocity;
        public double[] _time;
        public double[] _temperature;
        public double[] _acceleration;
        public double[] _current;
        public double[] _torque;


        /// <summary>
        /// Construct an instance of the record (for serialization)
        /// </summary>
        public Record() { }

        public Record(IPath path)
        {
            _time = path.Time;
            _position = path.Position;
            _velocity = path.Velocity;
            _acceleration = path.Acceleration;
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

        public double[] Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public double[] Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        public double[] Acceleration
        {
            get { return _acceleration; }
            set { _acceleration = value; }
        }

        public double[] Current
        {
            get { return _current; }
            set { _current = value; }
        }

        public double[] Torque
        {
            get { return _torque; }
            set { _torque = value; }
        }

        public double RMScurrent { get; set; }
        public double MAXcurrent { get; set; }
        public double RMSforce { get; set; }
        public double MAXforce { get; set; }
        public double TemperatureRise { get; set; }

        /// <summary>
        /// Write the record to a file
        /// </summary>
        /// <param name="filename">The filename to write to</param>
        public void Write(string filename)
        {
            TextWriter file = new StreamWriter(filename, false);
            {
                file.WriteLine("Max Force," + RMSforce);
                file.WriteLine("RMS Force," + MAXforce);
                file.WriteLine("Max Current," + MAXcurrent);
                file.WriteLine("RMS Current," + RMScurrent);
                file.WriteLine("Max Temp. Rise," + TemperatureRise);

                file.WriteLine("Time,Position,Velocity,Acceleration,Torque,Current,Temperature");
                for (int i = 0; i < _time.Length; i++)
                {
                    string s = string.Format("{0},{1},{2},{3},{4},{5},{6}", _time[i],
                                                                           _position[i],
                                                                           _velocity[i],
                                                                           _acceleration[i],
                                                                           _torque[i],
                                                                           _current[i],
                                                                           _temperature[i]);
                    file.WriteLine(s);
                }
            }

            file.Close();
        }
    }
}
