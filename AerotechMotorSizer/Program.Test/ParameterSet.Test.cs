using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Interfaces;
using ParameterSet;

namespace ParameterSet.Test
{
    class ParameterSetTest : ITesting
    {
        public bool DoTest()
        {
            // Populate the dictionary
            Dictionary<string, double> p = new Dictionary<string, double>();
            p.Add("distanceOfTravel", -230);
            p.Add("scanDistance", -5324);
            p.Add("percentage", 999);

            // Set the parameters to the ParameterSet
            ParameterSet set = new ParameterSet(p);

            // Assertions
            if (string.Compare(set.dummyValue, "Dynamic invocation is neat!") != 0) return false;
            if (set.dummyValue0 != -230) return false;
            if (set.dummyValue1 != -5324) return false;
            if (set.dummyValue2 != 999) return false;

            return true;
        }
    }
}
