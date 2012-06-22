using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface IParameterSet
    {
        double[] Axis1_Position { get; }
        double[] Axis2_Position { get; }
        double[] Axis3_Position { get; }

        double Axis1_AccelerationTime { get; }
        double Axis1_TraverseTime { get; }
        double Axis1_DeccelerationTime { get; }
        double Axis1_DwelTime { get; }

        double Axis2_AccelerationTime { get; }
        double Axis2_TraverseTime { get; }
        double Axis2_DeccelerationTime { get; }
        double Axis2_DwelTime { get; }

        double Axis3_AccelerationTime { get; }
        double Axis3_TraverseTime { get; }
        double Axis3_DeccelerationTime { get; }
        double Axis3_DwelTime { get; }

        double[] Time { get; }


        // Distance of travel
        // Total time of travel
        // Percentage of time spent moving
        // Max velocity
        // Peak acceleration
        // Acceleration distance
        // Max travel
        // Scan distance
        void SetParameters(Dictionary<string, double> parameters);
    }
}
