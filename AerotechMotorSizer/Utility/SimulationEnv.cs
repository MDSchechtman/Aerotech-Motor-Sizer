using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Utility
{
    public class SimulationEnv
    {
        private double EnvironmentFriction;
        private double EnvironmentPreLoadForce;
        private double EnvironmentThrustForce;
        private double EnvironmentAmbientTemp;
        private double EnvironmentMechEfficiency;
        private double EnvironmentCooling;

        //constructor
        public SimulationEnv(double Friction, double PreLoadForce, double ThrustForce, double AmbientTemp, double MechEfficiency, double Cooling)
        {
            EnvironmentFriction = Friction;
            EnvironmentPreLoadForce = PreLoadForce;
            EnvironmentThrustForce = ThrustForce;
            EnvironmentAmbientTemp = AmbientTemp;
            EnvironmentMechEfficiency = MechEfficiency;
            EnvironmentCooling = Cooling;
        }

        //another constructor
        public SimulationEnv()
        {
        }

        //get and set the environment friction
        public double Friction
        {
            get
            {
                return EnvironmentFriction;
            }
            set
            {
                EnvironmentFriction = value;
            }
        }

        //get and set the environment pre load force
        public double PreLoadForce
        {
            get
            {
                return EnvironmentPreLoadForce;
            }
            set
            {
                EnvironmentPreLoadForce = value;
            }
        }

        //get and set the environment thrust force
        public double ThrustForce
        {
            get
            {
                return EnvironmentThrustForce;
            }
            set
            {
                EnvironmentThrustForce = value;
            }
        }

        //get and set the environment ambient temperature
        public double AmbientTemp
        {
            get
            {
                return EnvironmentAmbientTemp;
            }
            set
            {
                EnvironmentAmbientTemp = value;
            }
        }

        //get and set the environment mechanical efficiency
        public double MechEfficiency
        {
            get
            {
                return EnvironmentMechEfficiency;
            }
            set
            {
                EnvironmentMechEfficiency = value;
            }
        }

        //get and set the environment cooling
        public double Cooling
        {
            get
            {
                return EnvironmentCooling;
            }
            set
            {
                EnvironmentCooling = value;
            }
        }

    }
}
