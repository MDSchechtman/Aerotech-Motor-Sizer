using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using ParameterSet;

namespace ParameterSet.Test
{
    class Testing
    {
        static void Main(string[] args)
        {
            // Populate the dictionary
            Dictionary<string, double> p = new Dictionary<string, double>();
            p.Add("distanceOfTravel", -230);
            p.Add("scanDistance", -5324);
            p.Add("percentage", 999);

            // Set the parameters to the ParameterSet
            ParameterSet set = new ParameterSet(p);

            // Assertions
            Debug.Assert(string.Compare(set.dummyValue, "Dynamic invocation is neat!") == 0);
            Debug.Assert(set.dummyValue0 == -230);
            Debug.Assert(set.dummyValue1 == -5324);
            Debug.Assert(set.dummyValue2 == 999);
        }
    }
}
