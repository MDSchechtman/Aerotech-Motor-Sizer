using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Utility
{
    public class SimulationEnv
    {
        private double _environmentStaticFriction;
        private double _environmentDynamicFriction;
        private double _environmentPreLoadForce;
        private double _environmentThrustForce;
        private double _environmentAmbientTemp;
        private double _environmentMechEfficiency;
        private string _environmentCooling;

        /// <summary>
        /// Creates an instance of the Simulation Environment
        /// </summary>
        public SimulationEnv()
        {
        }

        /// <summary>
        /// Creates an instance of the Simulation Environment
        /// </summary>
        /// <param name="StaticFriction"></param>
        /// <param name="DynamicFriction"></param>
        /// <param name="PreLoadForce"></param>
        /// <param name="ThrustForce"></param>
        /// <param name="AmbientTemp"></param>
        /// <param name="MechEfficiency"></param>
        /// <param name="Cooling"></param>
        public SimulationEnv(double StaticFriction, double DynamicFriction, double PreLoadForce, double ThrustForce, double AmbientTemp, double MechEfficiency, string Cooling)
        {
            _environmentStaticFriction = StaticFriction;
            _environmentDynamicFriction = DynamicFriction;
            _environmentPreLoadForce = PreLoadForce;
            _environmentThrustForce = ThrustForce;
            _environmentAmbientTemp = AmbientTemp;
            _environmentMechEfficiency = MechEfficiency;
            _environmentCooling = Cooling;
        }

        /// <summary>
        /// Gets or sets the Static Friction
        /// </summary>
        public double StaticFriction
        {
            get
            {
                return _environmentStaticFriction;
            }
            set
            {
                _environmentStaticFriction = value;
            }
        }

        /// <summary>
        /// Gets or sets the Dynamic Friction
        /// </summary>
        public double DynamicFriction
        {
            get
            {
                return _environmentDynamicFriction;
            }
            set
            {
                _environmentDynamicFriction = value;
            }
        }

        /// <summary>
        /// Gets or sets the Pre Load Force
        /// </summary>
        public double PreLoadForce
        {
            get
            {
                return _environmentPreLoadForce;
            }
            set
            {
                _environmentPreLoadForce = value;
            }
        }

        /// <summary>
        /// Gets or sets the Thrust Force
        /// </summary>
        public double ThrustForce
        {
            get
            {
                return _environmentThrustForce;
            }
            set
            {
                _environmentThrustForce = value;
            }
        }

        /// <summary>
        /// Gets or sets the Ambient Temperature
        /// </summary>
        public double AmbientTemp
        {
            get
            {
                return _environmentAmbientTemp;
            }
            set
            {
                _environmentAmbientTemp = value;
            }
        }

        /// <summary>
        /// Gets or sets the Mechanical Efficiency
        /// </summary>
        public double MechEfficiency
        {
            get
            {
                return _environmentMechEfficiency;
            }
            set
            {
                _environmentMechEfficiency = value;
            }
        }

        /// <summary>
        /// Gets or sets the environment Cooling
        /// </summary>
        public string Cooling
        {
            get
            {
                return _environmentCooling;
            }
            set
            {
                _environmentCooling = value;
            }
        }

    }
}
