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
        private List<double> _position;
        private List<double> _velocity;
        private List<double> _time;
        private List<double> _temperature;
        private List<double> _acceleration;
        private List<double> _current;
        private List<double> _torque;

        public Record()
        {
            _position = new List<double>();
            _velocity = new List<double>();
            _time = new List<double>();
            _temperature = new List<double>();
            _acceleration = new List<double>();
            _current = new List<double>();
            _torque = new List<double>();
        }

        public double[] Position
        {
            get { return _position.ToArray(); }
        }

        public double[] Velocity
        {
            get { return _velocity.ToArray(); }
        }

        public double[] Time
        {
            get { return _time.ToArray(); }
        }

        public double[] Temperature
        {
            get { return _temperature.ToArray(); }
        }

        public double[] Acceleration
        {
            get { return _acceleration.ToArray(); }
        }

        public double[] Current
        {
            get { return _current.ToArray(); }
        }

        public double[] Torque
        {
            get { return _torque.ToArray(); }
        }

        public void Add(double position, double velocity, double time, double temperature,
                        double acceleration, double current, double torque)
        {
            _position.Add(position);
            _velocity.Add(velocity);
            _time.Add(time);
            _temperature.Add(temperature);
            _acceleration.Add(acceleration);
            _current.Add(current);
            _torque.Add(torque);
        }

        public double GetMaxCurrent()
        {
            return _current.Max();
        }

        public double GetMaxTorque()
        {
            return _torque.Max();
        }

        public double GetAverageCurrent()
        {
            return _current.Sum() / _current.Count();
        }

        public double GetAverageTorque()
        {
            return _torque.Sum() / _torque.Count();
        }

        public double GetMaxTemperatureRise()
        {
            return _temperature.Sum() / _temperature.Count();
        }

        public void Write(string filename)
        {
            TextWriter file = new StreamWriter(filename, false);
            {
                file.WriteLine("Max Torque," + GetMaxTorque());
                file.WriteLine("RMS Torque," + GetAverageTorque());
                file.WriteLine("Max Current," + GetMaxCurrent());
                file.WriteLine("RMS Current," + GetAverageCurrent());
                file.WriteLine("Max Temp. Rise," + GetMaxTemperatureRise());

                file.WriteLine("Time,Position,Velocity,Acceleration,Torque,Current,Temperature");
                for (int i = 0; i < _time.Count; i++)
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
