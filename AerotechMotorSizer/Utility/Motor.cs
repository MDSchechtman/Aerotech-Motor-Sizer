﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;

namespace Utility
{
    public class Motor
    {
        private string MotorName;
        private double MotorForceConstant;
        private double MotorMotorConstant;
        private double MotorBackEMFConstant;
        private double MotorResistance;
        private double MotorPeakForce;
        private double MotorPeakCurrent;
        private double MotorContinuousForce_0psi;
        private double MotorContinuousForce_10psi;
        private double MotorContinuousForce_20psi;
        private double MotorContinuousForce_40psi;
        private double MotorContinuousCurrent_0psi;
        private double MotorContinuousCurrent_10psi;
        private double MotorContinuousCurrent_20psi;
        private double MotorContinuousCurrent_40psi;
        private double MotorCoilMass;
        private double MotorCoilLength;
        private double MotorThermalResistance_100CTEMP_0psi;
        private double MotorThermalResistance_100CTEMP_10psi;
        private double MotorThermalResistance_100CTEMP_20psi;
        private double MotorThermalResistance_100CTEMP_40psi;
        private double MotorThermalResistance_Catalog_0psi;
        private double MotorThermalResistance_Catalog_20psi;
        private double MotorThermalResistance_PercentDifference_0psi;
        private double MotorThermalResistance_PercentDifference_20psi;


        //constructor
        public Motor(string Name, double ForceConstant, double MotorConstant, double BackEMFConstant, double Resistance, double PeakForce, double PeakCurrent, double ContinuousForce_0psi, double ContinuousForce_10psi, double ContinuousForce_20psi, double ContinuousForce_40psi, double ContinuousCurrent_0psi, double ContinuousCurrent_10psi, double ContinuousCurrent_20psi, double ContinuousCurrent_40psi, double CoilMass, double CoilLength, double ThermalResistance_100CTEMP_0psi, double ThermalResistance_100CTEMP_10psi, double ThermalResistance_100CTEMP_20psi, double ThermalResistance_100CTEMP_40psi, double ThermalResistance_Catalog_0psi, double ThermalResistance_Catalog_20psi, double ThermalResistance_PercentDifference_0psi, double ThermalResistance_PercentDifference_20psi)
        {
            MotorName = Name;
            MotorForceConstant = ForceConstant;
            MotorMotorConstant = MotorConstant;
            MotorBackEMFConstant = BackEMFConstant;
            MotorResistance = Resistance;
            MotorPeakForce = PeakForce;
            MotorPeakCurrent = PeakCurrent;
            MotorContinuousForce_0psi = ContinuousForce_0psi;
            MotorContinuousForce_10psi = ContinuousForce_10psi;
            MotorContinuousForce_20psi = ContinuousForce_20psi;
            MotorContinuousForce_40psi = ContinuousForce_40psi;
            MotorContinuousCurrent_0psi = ContinuousCurrent_0psi;
            MotorContinuousCurrent_10psi = ContinuousCurrent_10psi;
            MotorContinuousCurrent_20psi = ContinuousCurrent_20psi;
            MotorContinuousCurrent_40psi = ContinuousCurrent_40psi;
            MotorCoilMass = CoilMass;
            MotorCoilLength = CoilLength;
            MotorThermalResistance_100CTEMP_0psi = ThermalResistance_100CTEMP_0psi;
            MotorThermalResistance_100CTEMP_10psi = ThermalResistance_100CTEMP_10psi;
            MotorThermalResistance_100CTEMP_20psi = ThermalResistance_100CTEMP_20psi;
            MotorThermalResistance_100CTEMP_40psi = ThermalResistance_100CTEMP_40psi;
            MotorThermalResistance_Catalog_0psi = ThermalResistance_Catalog_0psi;
            MotorThermalResistance_Catalog_20psi = ThermalResistance_Catalog_20psi;
            MotorThermalResistance_PercentDifference_0psi = ThermalResistance_PercentDifference_0psi;
            MotorThermalResistance_PercentDifference_20psi = ThermalResistance_PercentDifference_20psi;
        }

        //another constructor
        public Motor()
        {
        }

        public string Name
        {
            get { return MotorName; }
            set { MotorName = Name; }
        }

        public double ForceConstant
        {
            get { return MotorForceConstant; }
            set { MotorForceConstant = ForceConstant; }
        }

        public double MotorConstant
        {
            get { return MotorMotorConstant; }
            set { MotorMotorConstant = MotorConstant; }
        }

        public double BackEMFConstant
        {
            get { return MotorBackEMFConstant; }
            set { MotorBackEMFConstant = BackEMFConstant; }
        }

        public double Resistance
        {
            get { return MotorResistance; }
            set { MotorResistance = Resistance; }
        }

        public double PeakForce
        {
            get { return MotorPeakForce; }
            set { MotorPeakForce = PeakForce; }
        }

        public double PeakCurrent
        {
            get { return MotorPeakCurrent; }
            set { MotorPeakCurrent = PeakCurrent; }
        }

        public double ContinuousForce_0psi
        {
            get { return MotorContinuousForce_0psi; }
            set { MotorContinuousForce_0psi = ContinuousForce_0psi; }
        }

        public double ContinuousForce_10psi
        {
            get { return MotorContinuousForce_10psi; }
            set { MotorContinuousForce_10psi = ContinuousForce_10psi; }
        }

        public double ContinuousForce_20psi
        {
            get { return MotorContinuousForce_0psi; }
            set { MotorContinuousForce_20psi = ContinuousForce_20psi; }
        }

        public double ContinuousForce_40psi
        {
            get { return MotorContinuousForce_40psi; }
            set { MotorContinuousForce_40psi = ContinuousForce_40psi; }
        }

        public double ContinuousCurrent_0psi
        {
            get { return MotorContinuousCurrent_0psi; }
            set { MotorContinuousCurrent_0psi = ContinuousCurrent_0psi; }
        }

        public double ContinuousCurrent_10psi
        {
            get { return MotorContinuousCurrent_10psi; }
            set { MotorContinuousCurrent_10psi = ContinuousCurrent_10psi; }
        }

        public double ContinuousCurrent_20psi
        {
            get { return MotorContinuousCurrent_20psi; }
            set { MotorContinuousCurrent_20psi = ContinuousCurrent_20psi; }
        }

        public double ContinuousCurrent_40psi
        {
            get { return MotorContinuousCurrent_40psi; }
            set { MotorContinuousCurrent_40psi = ContinuousCurrent_40psi; }
        }

        public double CoilMass
        {
            get { return MotorCoilMass; }
            set { MotorCoilMass = CoilMass; }
        }

        public double CoilLength
        {
            get { return MotorCoilLength; }
            set { MotorCoilLength = CoilLength; }
        }

        public double ThermalResistance_100CTEMP_0psi
        {
            get { return MotorThermalResistance_100CTEMP_0psi; }
            set { MotorThermalResistance_100CTEMP_0psi = ThermalResistance_100CTEMP_0psi; }
        }

        public double ThermalResistance_100CTEMP_10psi
        {
            get { return MotorThermalResistance_100CTEMP_10psi; }
            set { MotorThermalResistance_100CTEMP_10psi = ThermalResistance_100CTEMP_10psi; }
        }

        public double ThermalResistance_100CTEMP_20psi
        {
            get { return MotorThermalResistance_100CTEMP_20psi; }
            set { MotorThermalResistance_100CTEMP_20psi = ThermalResistance_100CTEMP_20psi; }
        }

        public double ThermalResistance_100CTEMP_40psi
        {
            get { return MotorThermalResistance_100CTEMP_40psi; }
            set { MotorThermalResistance_100CTEMP_40psi = ThermalResistance_100CTEMP_40psi; }
        }

        public double ThermalResistance_Catalog_0psi
        {
            get { return MotorThermalResistance_Catalog_0psi; }
            set { MotorThermalResistance_Catalog_0psi = ThermalResistance_Catalog_0psi; }
        }

        public double ThermalResistance_Catalog_20psi
        {
            get { return MotorThermalResistance_Catalog_20psi; }
            set { MotorThermalResistance_Catalog_20psi = ThermalResistance_Catalog_20psi; }
        }

        public double ThermalResistance_PercentDifference_0psi
        {
            get { return MotorThermalResistance_PercentDifference_0psi; }
            set { MotorThermalResistance_PercentDifference_0psi = ThermalResistance_PercentDifference_0psi; }
        }

        public double ThermalResistance_PercentDifference_20psi
        {
            get { return MotorThermalResistance_PercentDifference_20psi; }
            set { MotorThermalResistance_PercentDifference_20psi = ThermalResistance_PercentDifference_20psi; }
        }




    }
}
