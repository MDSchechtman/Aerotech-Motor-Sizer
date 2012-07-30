using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IMotor
    {
        //double Mass { get; set; }
        //double MaxTemp { get; set; }
        //double MomentOfInertia { get; set; }
        //double Resistance { get; set; }
        //double Inductance { get; set; }
        //double ThermalResistance { get; set; }
        //double KT { get; set; }

        string Name { get; set; }

        double ForceConstant { get; set; }
        double MotorConstant { get; set; }
        double BackEMFConstant { get; set; }
        double Resistance { get; set; }
        double PeakForce { get; set; }
        double PeakCurrent { get; set; }
        double ContinuousForce_0psi { get; set; }
        double ContinuousForce_10psi { get; set; }
        double ContinuousForce_20psi { get; set; }
        double ContinuousForce_40psi { get; set; }
        double ContinuousCurrent_0psi { get; set; }
        double ContinuousCurrent_10psi { get; set; }
        double ContinuousCurrent_20psi { get; set; }
        double ContinuousCurrent_40psi { get; set; }
        double CoilMass { get; set; }
        double CoilLength { get; set; }
        double ThermalResistance_100CTEMP_0psi { get; set; }
        double ThermalResistance_100CTEMP_10psi { get; set; }
        double ThermalResistance_100CTEMP_20psi { get; set; }
        double ThermalResistance_100CTEMP_40psi { get; set; }
        double ThermalResistance_Catalog_0psi { get; set; }
        double ThermalResistance_Catalog_20psi { get; set; }
        double ThermalResistance_PercentDifference_0psi { get; set; }
        double ThermalResistance_PercentDifference_20psi { get; set; }

        double ContinuousForce { get; }
        double ContinuousCurrent { get; }
        double ThermalResistance { get; }

        bool SetCooling(string cooling);

        string ToString();
    }
}
