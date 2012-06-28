using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface IConverter
    {
        double[] Position { get; }
        double[] Time  {get; }
    }
}
