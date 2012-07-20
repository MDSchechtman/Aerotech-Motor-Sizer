using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IMotor
    {
        double Mass { get; set; }
        double MaxTemp { get; set; }
        double MomentOfInertia { get; set; }
        double Resistance { get; set; }
        double Inductance { get; set; }
        double ThermalResistance { get; set; }
        double KT { get; set; }

        string Name { get; set; }
    }
}
