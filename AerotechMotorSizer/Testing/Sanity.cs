using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;
using Utility;

namespace Program.Test
{
    public class Sanity : ITesting
    {
        public bool DoTest()
        {
            Dictionary<string, double> dictionary = new Dictionary<string,double>();
            dictionary.Add("distanceOfTravel", 1000);
            dictionary.Add("totalTime", 5000);
            dictionary.Add("percentage", 0.80);

            IConverter converter = new ParameterSetConverter(dictionary);
            IPath path = new Path(converter);
            IAxis axis = new Axis(path);

            return true;
        }
    }
}
