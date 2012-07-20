using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Utility
{
    public class Motor : IMotor
    {
        private double MotorMass;
        private double MotorMaxTemp;
        private double MotorMomentOfInertia;
        private double MotorResistance;
        private double MotorInductance;
        private double MotorThermalResistance;
        private double MotorKT;

        private string _name;

        //constructor
        public Motor(double Mass, double MaxTemp, double MomentOfInertia, double Resistance, double Inductance, double ThermalResistance, double KT)
        {
            MotorMass = Mass;
            MotorMaxTemp = MaxTemp;
            MotorMomentOfInertia = MomentOfInertia;
            MotorResistance = Resistance;
            MotorInductance = Inductance;
            MotorThermalResistance = ThermalResistance;
            MotorKT = KT;

            _name = "New Motor";
        }

        //another constructor
        public Motor()
        {
        }

        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        //get and set the motor's mass
        public double Mass
        {
            get
            {
                return MotorMass;
            }
            set
            {
                MotorMass = value;
            }
        }

        //get and set the motor's max temperature
        public double MaxTemp
        {
            get 
            { 
                return MotorMaxTemp; 
            }
            set 
            { 
                MotorMaxTemp = value; 
            }
        }

        //get and set the motor's moment of inertia
        public double MomentOfInertia
        {
            get 
            { 
                return MotorMomentOfInertia; 
            }
            set 
            { 
                MotorMomentOfInertia = value; 
            }
        }

        //get and set the motor's resistance
        public double Resistance
        {
            get 
            { 
                return MotorResistance; 
            }
            set 
            { 
                MotorResistance = value; 
            }
        }

        //get and set the motor's inductance
        public double Inductance
        {
            get 
            { 
                return MotorInductance; 
            }
            set 
            { 
                MotorInductance = value; 
            }
        }

        //get and set the motor's thermal resistance
        public double ThermalResistance
        {
            get 
            { 
                return MotorThermalResistance; 
            }
            set 
            { 
                MotorThermalResistance = value; 
            }
        }

        //get and set the motor's kt
        public double KT
        {
            get 
            { 
                return MotorKT; 
            }
            set 
            { 
                MotorKT = value; 
            }
        }
        
    }
}
