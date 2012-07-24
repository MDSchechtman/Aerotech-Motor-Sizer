using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Utility
{
    public class Motor : IMotor
    {
        private string _motorName;
        private double _motorForceConstant;
        private double _motorMotorConstant;
        private double _motorBackEMFConstant;
        private double _motorResistance;
        private double _motorPeakForce;
        private double _motorPeakCurrent;
        private double _motorContinuousForce;
        private double _motorContinuousForce_0psi;
        private double _motorContinuousForce_10psi;
        private double _motorContinuousForce_20psi;
        private double _motorContinuousForce_40psi;
        private double _motorContinuousCurrent;
        private double _motorContinuousCurrent_0psi;
        private double _motorContinuousCurrent_10psi;
        private double _motorContinuousCurrent_20psi;
        private double _motorContinuousCurrent_40psi;
        private double _motorCoilMass;
        private double _motorCoilLength;
        private double _motorThermalResistance;
        private double _motorThermalResistance_100CTEMP_0psi;
        private double _motorThermalResistance_100CTEMP_10psi;
        private double _motorThermalResistance_100CTEMP_20psi;
        private double _motorThermalResistance_100CTEMP_40psi;
        private double _motorThermalResistance_Catalog_0psi;
        private double _motorThermalResistance_Catalog_20psi;
        private double _motorThermalResistance_PercentDifference_0psi;
        private double _motorThermalResistance_PercentDifference_20psi;

        /// <summary>
        /// Constructs a new instance of the Motor class
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="ForceConstant"></param>
        /// <param name="_motorConstant"></param>
        /// <param name="BackEMFConstant"></param>
        /// <param name="Resistance"></param>
        /// <param name="PeakForce"></param>
        /// <param name="PeakCurrent"></param>
        /// <param name="ContinuousForce_0psi"></param>
        /// <param name="ContinuousForce_10psi"></param>
        /// <param name="ContinuousForce_20psi"></param>
        /// <param name="ContinuousForce_40psi"></param>
        /// <param name="ContinuousCurrent_0psi"></param>
        /// <param name="ContinuousCurrent_10psi"></param>
        /// <param name="ContinuousCurrent_20psi"></param>
        /// <param name="ContinuousCurrent_40psi"></param>
        /// <param name="CoilMass"></param>
        /// <param name="CoilLength"></param>
        /// <param name="ThermalResistance_100CTEMP_0psi"></param>
        /// <param name="ThermalResistance_100CTEMP_10psi"></param>
        /// <param name="ThermalResistance_100CTEMP_20psi"></param>
        /// <param name="ThermalResistance_100CTEMP_40psi"></param>
        /// <param name="ThermalResistance_Catalog_0psi"></param>
        /// <param name="ThermalResistance_Catalog_20psi"></param>
        /// <param name="ThermalResistance_PercentDifference_0psi"></param>
        /// <param name="ThermalResistance_PercentDifference_20psi"></param>
        public Motor(string Name, double ForceConstant, double _motorConstant, double BackEMFConstant, double Resistance, 
                     double PeakForce, double PeakCurrent, double ContinuousForce_0psi, double ContinuousForce_10psi, 
                     double ContinuousForce_20psi, double ContinuousForce_40psi, double ContinuousCurrent_0psi, 
                     double ContinuousCurrent_10psi, double ContinuousCurrent_20psi, double ContinuousCurrent_40psi, 
                     double CoilMass, double CoilLength, double ThermalResistance_100CTEMP_0psi, double ThermalResistance_100CTEMP_10psi, 
                     double ThermalResistance_100CTEMP_20psi, double ThermalResistance_100CTEMP_40psi, double ThermalResistance_Catalog_0psi, 
                     double ThermalResistance_Catalog_20psi, double ThermalResistance_PercentDifference_0psi, double ThermalResistance_PercentDifference_20psi)
        {
            _motorName = Name;
            _motorForceConstant = ForceConstant;
            _motorMotorConstant = _motorConstant;
            _motorBackEMFConstant = BackEMFConstant;
            _motorResistance = Resistance;
            _motorPeakForce = PeakForce;
            _motorPeakCurrent = PeakCurrent;
            _motorContinuousForce_0psi = ContinuousForce_0psi;
            _motorContinuousForce_10psi = ContinuousForce_10psi;
            _motorContinuousForce_20psi = ContinuousForce_20psi;
            _motorContinuousForce_40psi = ContinuousForce_40psi;
            _motorContinuousCurrent_0psi = ContinuousCurrent_0psi;
            _motorContinuousCurrent_10psi = ContinuousCurrent_10psi;
            _motorContinuousCurrent_20psi = ContinuousCurrent_20psi;
            _motorContinuousCurrent_40psi = ContinuousCurrent_40psi;
            _motorCoilMass = CoilMass;
            _motorCoilLength = CoilLength;
            _motorThermalResistance_100CTEMP_0psi = ThermalResistance_100CTEMP_0psi;
            _motorThermalResistance_100CTEMP_10psi = ThermalResistance_100CTEMP_10psi;
            _motorThermalResistance_100CTEMP_20psi = ThermalResistance_100CTEMP_20psi;
            _motorThermalResistance_100CTEMP_40psi = ThermalResistance_100CTEMP_40psi;
            _motorThermalResistance_Catalog_0psi = ThermalResistance_Catalog_0psi;
            _motorThermalResistance_Catalog_20psi = ThermalResistance_Catalog_20psi;
            _motorThermalResistance_PercentDifference_0psi = ThermalResistance_PercentDifference_0psi;
            _motorThermalResistance_PercentDifference_20psi = ThermalResistance_PercentDifference_20psi;

            _motorContinuousForce = ContinuousForce_0psi;
            _motorContinuousCurrent = ContinuousCurrent_0psi;
            _motorThermalResistance = ThermalResistance_100CTEMP_0psi;
        }

        /// <summary>
        /// Constructs a new instance of the Motor class
        /// </summary>
        /// <param name="Mass"></param>
        /// <param name="MaxTemp"></param>
        /// <param name="MomentOfInertia"></param>
        /// <param name="Resistance"></param>
        /// <param name="Inductance"></param>
        /// <param name="ThermalResistance"></param>
        /// <param name="KT"></param>
        public Motor(double Mass, double MaxTemp, double MomentOfInertia, double Resistance, double Inductance, double ThermalResistance, double KT)
        {
            //////////
            // TODO //
            //////////
        }

        public double Mass
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double MaxTemp
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double MomentOfInertia
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double Inductance
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double KT
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get { return _motorName; }
            set { _motorName = value; }
        }

        public double ForceConstant
        {
            get { return _motorForceConstant; }
            set { _motorForceConstant = value; }
        }

        public double MotorConstant
        {
            get { return _motorMotorConstant; }
            set { _motorMotorConstant = value; }
        }

        public double BackEMFConstant
        {
            get { return _motorBackEMFConstant; }
            set { _motorBackEMFConstant = value; }
        }

        public double Resistance
        {
            get { return _motorResistance; }
            set { _motorResistance = value; }
        }

        public double PeakForce
        {
            get { return _motorPeakForce; }
            set { _motorPeakForce = value; }
        }

        public double PeakCurrent
        {
            get { return _motorPeakCurrent; }
            set { _motorPeakCurrent = value; }
        }

        public double ContinuousForce_0psi
        {
            get { return _motorContinuousForce_0psi; }
            set { _motorContinuousForce_0psi = value; }
        }

        public double ContinuousForce_10psi
        {
            get { return _motorContinuousForce_10psi; }
            set { _motorContinuousForce_10psi = value; }
        }

        public double ContinuousForce_20psi
        {
            get { return _motorContinuousForce_0psi; }
            set { _motorContinuousForce_20psi = value; }
        }

        public double ContinuousForce_40psi
        {
            get { return _motorContinuousForce_40psi; }
            set { _motorContinuousForce_40psi = value; }
        }

        public double ContinuousCurrent_0psi
        {
            get { return _motorContinuousCurrent_0psi; }
            set { _motorContinuousCurrent_0psi = value; }
        }

        public double ContinuousCurrent_10psi
        {
            get { return _motorContinuousCurrent_10psi; }
            set { _motorContinuousCurrent_10psi = value; }
        }

        public double ContinuousCurrent_20psi
        {
            get { return _motorContinuousCurrent_20psi; }
            set { _motorContinuousCurrent_20psi = value; }
        }

        public double ContinuousCurrent_40psi
        {
            get { return _motorContinuousCurrent_40psi; }
            set { _motorContinuousCurrent_40psi = value; }
        }

        public double CoilMass
        {
            get { return _motorCoilMass; }
            set { _motorCoilMass = value; }
        }

        public double CoilLength
        {
            get { return _motorCoilLength; }
            set { _motorCoilLength = value; }
        }

        public double ThermalResistance_100CTEMP_0psi
        {
            get { return _motorThermalResistance_100CTEMP_0psi; }
            set { _motorThermalResistance_100CTEMP_0psi = value; }
        }

        public double ThermalResistance_100CTEMP_10psi
        {
            get { return _motorThermalResistance_100CTEMP_10psi; }
            set { _motorThermalResistance_100CTEMP_10psi = value; }
        }

        public double ThermalResistance_100CTEMP_20psi
        {
            get { return _motorThermalResistance_100CTEMP_20psi; }
            set { _motorThermalResistance_100CTEMP_20psi = value; }
        }

        public double ThermalResistance_100CTEMP_40psi
        {
            get { return _motorThermalResistance_100CTEMP_40psi; }
            set { _motorThermalResistance_100CTEMP_40psi = value; }
        }

        public double ThermalResistance_Catalog_0psi
        {
            get { return _motorThermalResistance_Catalog_0psi; }
            set { _motorThermalResistance_Catalog_0psi = value; }
        }

        public double ThermalResistance_Catalog_20psi
        {
            get { return _motorThermalResistance_Catalog_20psi; }
            set { _motorThermalResistance_Catalog_20psi = value; }
        }

        public double ThermalResistance_PercentDifference_0psi
        {
            get { return _motorThermalResistance_PercentDifference_0psi; }
            set { _motorThermalResistance_PercentDifference_0psi = value; }
        }

        public double ThermalResistance_PercentDifference_20psi
        {
            get { return _motorThermalResistance_PercentDifference_20psi; }
            set { _motorThermalResistance_PercentDifference_20psi = value; }
        }

        public double ContinuousForce
        {
            get { return _motorContinuousForce; }
        }

        public double ContinuousCurrent
        {
            get { return _motorContinuousCurrent; }
        }

        public double ThermalResistance
        {
            get { return _motorThermalResistance; }
        }

        public bool SetCooling(string cooling)
        {
            if (cooling.Equals("No Cooling"))
            {
                _motorContinuousForce = _motorContinuousForce_0psi;
                _motorContinuousCurrent = _motorContinuousCurrent_0psi;
                _motorThermalResistance = _motorThermalResistance_100CTEMP_0psi;
                return true;
            }
            else if (cooling.Equals("10 PSI"))
            {
                _motorContinuousForce = _motorContinuousForce_10psi;
                _motorContinuousCurrent = _motorContinuousCurrent_10psi;
                _motorThermalResistance = _motorThermalResistance_100CTEMP_10psi;
                return true;
            }
            else if (cooling.Equals("20 PSI"))
            {
                _motorContinuousForce = _motorContinuousForce_20psi;
                _motorContinuousCurrent = _motorContinuousCurrent_20psi;
                _motorThermalResistance = _motorThermalResistance_100CTEMP_20psi;
                return true;
            }
            else if (cooling.Equals("40 PSI"))
            {
                _motorContinuousForce = _motorContinuousForce_40psi;
                _motorContinuousCurrent = _motorContinuousCurrent_40psi;
                _motorThermalResistance = _motorThermalResistance_100CTEMP_40psi;
                return true;
            }

            return false;
        }

        public string ToString()
        {
            return this.Name;
        }
    }
}
