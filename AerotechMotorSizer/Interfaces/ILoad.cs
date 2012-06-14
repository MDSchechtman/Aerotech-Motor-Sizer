using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface ILoad
    {
        double Mass { get; set; }

        double MaxTemperature { get; set; }

        double MomentOfInertia { get; set; }
    }
}
