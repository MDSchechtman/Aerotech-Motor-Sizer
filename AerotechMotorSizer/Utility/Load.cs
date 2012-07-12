using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Utility
{
    public class Load : ILoad
    {
        private double _Mass;
        private double _MomentOfInertia;
        private double _MaxTemperature;

        //constructor
        public Load(double Mass, double MomentOfInertia)
        {
            _Mass = Mass;
            _MomentOfInertia = MomentOfInertia;
        }

        //another constructor
        public Load()
        {
        }

        //get and set the mass
        public double Mass
        {
            get
            {
                return _Mass;
            }
            set
            {
                _Mass = value;
            }
        }

        //get and set the moment of inertia
        public double MomentOfInertia
        {
            get
            {
                return _MomentOfInertia;
            }
            set
            {
                _MomentOfInertia = value;
            }
        }

        //get and set the max temperature
        public double MaxTemperature
        {
            get
            {
                return _MaxTemperature;
            }
            set
            {
                _MaxTemperature = value;
            }
        }
    }
}
