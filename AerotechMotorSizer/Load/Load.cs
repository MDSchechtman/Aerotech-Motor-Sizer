using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Load
{
    public class Load
    {
        private double LoadMass;
        private double LoadMomentOfInertia;

        //constructor
        public Load(double Mass, double MomentOfInertia)
        {
            LoadMass = Mass;
            LoadMomentOfInertia = MomentOfInertia;
        }

        //another constructor
        public Load()
        {
        }

        //get and set the load mass
        public double Mass
        {
            get
            {
                return LoadMass;
            }
            set
            {
                LoadMass = value;
            }
        }

        //get and set the environment load moment of inertia
        public double MomentOfInertia
        {
            get
            {
                return LoadMomentOfInertia;
            }
            set
            {
                LoadMomentOfInertia = value;
            }
        }
    }
}
