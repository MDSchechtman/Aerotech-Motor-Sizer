using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface ILoad
    {
        public double Mass { get; set; }

        public double MaxTemperature { get; set; }

        public double MomentOfInertia { get; set; }
    }
}
