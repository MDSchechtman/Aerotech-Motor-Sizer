using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Utility
{
    public class SimulationEnv
    {
        private double EnvironmentStaticFriction;
        private double EnvironmentDynamicFriction;
        private double EnvironmentPreLoadForce;
        private double EnvironmentThrustForce;
        private double EnvironmentAmbientTemp;
        private double EnvironmentMechEfficiency;
        private string EnvironmentCooling;

        //constructor
        public SimulationEnv(double StaticFriction, double DynamicFriction, double PreLoadForce, double ThrustForce, double AmbientTemp, double MechEfficiency, string Cooling)
        {
            EnvironmentStaticFriction = StaticFriction;
            EnvironmentDynamicFriction = DynamicFriction;
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

        //get and set the environment static friction
        public double StaticFriction
        {
            get
            {
                return EnvironmentStaticFriction;
            }
            set
            {
                EnvironmentStaticFriction = value;
            }
        }

        //get and set the environment dynamic friction
        public double DynamicFriction
        {
            get
            {
                return EnvironmentDynamicFriction;
            }
            set
            {
                EnvironmentDynamicFriction = value;
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
        public string Cooling
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
