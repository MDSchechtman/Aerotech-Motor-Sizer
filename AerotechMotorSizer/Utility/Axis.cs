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
        private IRecord _record;

        /// <summary>
        /// An Axis defines the positions, accelerations, and velocities at descrete times.
        /// The axis is responsible for garunteeing consistency between its Path and Record times.
        /// </summary>
        public Axis()
        {
            _record = new Record();
        }

        public Axis(IPath path)
        {
            SetPath(path);
            _record = new Record();
        }

        public void SetPath(IPath path)
        {
            _path = path;
        }

        public double[] Position
        {
            get { return _path.Position; }
        }

        public double[] Velocity
        {
            get { return _record.Velocity; }
        }

        public double[] Acceleration
        {
            get { return _record.Acceleration; }
        }

        public double[] Time 
        {
            get { return _path.Time; }
        }

        public IPath Path
        {
            get { return _path; }
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
