using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Utility.Converters
{
    public class FileConverter : IConverter
    {
        public bool HasPosition
        {
            get { throw new NotImplementedException(); }
        }

        public bool HasVelocity
        {
            get { throw new NotImplementedException(); }
        }

        public bool HasAcceleration
        {
            get { throw new NotImplementedException(); }
        }

        public double[] Position
        {
            get { throw new NotImplementedException(); }
        }

        public double[] Velocity
        {
            get { throw new NotImplementedException(); }
        }

        public double[] Acceleration
        {
            get { throw new NotImplementedException(); }
        }

        public double[] Time
        {
            get { throw new NotImplementedException(); }
        }
    }
}
