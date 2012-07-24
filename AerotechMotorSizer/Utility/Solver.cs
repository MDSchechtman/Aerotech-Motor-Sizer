﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Interfaces;

namespace MotorSolver
{
    public class Solver : ISolver
    {
        private IRecord _record;
        private IMotor _motor;
        private ILoad _load;
        private IPath _path;
        private string _projectDirectory;

        /// <summary>
        /// Start a simulation
        /// </summary>
        /// <param name="initial">The initial state</param>
        /// <param name="motor">The motor object</param>
        /// <param name="load">The load</param>
        /// <param name="path">The path</param>
        public bool Start(IRecord initial, IMotor motor, ILoad load, IPath path)
        {
            _record = initial;
            _motor = motor;
            _load = load;
            _path = path;

            int count = _record.Time.Length;

            if (_record.Time == null || (_record.Position == null && _record.Velocity == null && _record.Acceleration == null))
                return false;

            if (_record.Acceleration == null)
                _record.Acceleration = new double[count];

            if (_record.Velocity == null)
                _record.Velocity = new double[count];

            if (_record.Position == null)
                _record.Position = new double[count];

            _record.RMSforce = Math.Pow(_load.Mass * _record.Acceleration[0], 2);

            if (_record.Acceleration != null)
            {
                for (int i = 1; i < count; i++)
                   _record.RMSforce += Math.Pow(_load.Mass * _record.Acceleration[i], 2);
            }
            else if (_record.Velocity != null)
            {
                for (int i = 1; i < count; i++)
                {
                    _record.Acceleration[i] = (_record.Velocity[i] - _record.Velocity[i - 1]) / (_record.Time[i] - _record.Time[i - 1]);
                    _record.RMSforce += Math.Pow(_load.Mass * _record.Acceleration[i], 2);
                }
            }
            else
            {
                for (int i = 1; i < count; i++)
                {
                    _record.Velocity[i] = (_record.Position[i] - _record.Position[i - 1]) / (_record.Time[i] - _record.Time[i - 1]);
                    _record.Acceleration[i] = (_record.Velocity[i] - _record.Velocity[i - 1]) / (_record.Time[i] - _record.Time[i - 1]);
                    _record.RMSforce += Math.Pow(_load.Mass * _record.Acceleration[i], 2);
                }
            }

            _record.RMSforce = Math.Sqrt(_record.RMSforce / count);
            _record.MAXforce = _load.Mass * _record.Acceleration.Max();
            _record.RMScurrent = _motor.MotorConstant * _record.RMSforce;
            _record.MAXcurrent = _motor.MotorConstant * _record.MAXforce;
            _record.TemperatureRise = Math.Pow(_record.RMSforce / _motor.MotorConstant, 2) * _motor.ThermalResistance_100CTEMP_0psi;

            Write();

            return true;
        }

        public bool Write()
        {
            if (_record == null)
                return false;

            _projectDirectory = Directory.GetCurrentDirectory();
            StreamWriter outfile = new StreamWriter(_projectDirectory + @"\output.txt");

            outfile.WriteLine("Project Name");
            outfile.WriteLine("Motor Name");
            outfile.WriteLine("Load");
            outfile.WriteLine("Mass:               " + _load.Mass);
            outfile.WriteLine("Moment of Intertia: " + _load.MomentOfInertia);
            outfile.WriteLine("Max Temperature:    " + _load.MaxTemperature);
            outfile.WriteLine("\nAxis Name");
            outfile.WriteLine("t\tx\tv\ta");

            for (int i = 0; i < _record.Time.Length; i++)
                outfile.WriteLine(_record.Time[i] + "\t" + _record.Position[i] + "\t" + _record.Velocity[i] + "\t" + _record.Acceleration[i]);

            outfile.Close();

            return true;
        }
    }
}