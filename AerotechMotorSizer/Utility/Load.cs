using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Utility
{
    public class Load : ILoad
    {
        private double _mass;
        private double _momentOfInertia;
        private double _maxTemperature;

        /// <summary>
        /// Construct an instance of the Load Class
        /// </summary>
        /// <param name="Mass">The mass of the load</param>
        /// <param name="MomentOfInertia">The load's moment of inertia</param>
        public Load(double mass, double momentOfInertia)
        {
            _mass = mass;
            _momentOfInertia = momentOfInertia;
        }

        /// <summary>
        /// Construct an instance of the Load Class
        /// </summary>
        /// <param name="Mass"></param>
        /// <param name="MomentOfInertia"></param>
        public Load()
        {
        }

        //get and set the mass
        public double Mass
        {
            get
            {
                return _mass;
            }
            set
            {
                _mass = value;
            }
        }

        //get and set the moment of inertia
        public double MomentOfInertia
        {
            get
            {
                return _momentOfInertia;
            }
            set
            {
                _momentOfInertia = value;
            }
        }

        //get and set the max temperature
        public double MaxTemperature
        {
            get
            {
                return _maxTemperature;
            }
            set
            {
                _maxTemperature = value;
            }
        }
    }
}
