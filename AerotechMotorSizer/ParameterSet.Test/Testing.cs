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
            // Create a new parameter set
            ParameterSet set = new ParameterSet();

            // Populate the dictionary
            Dictionary<string, double> p = new Dictionary<string, double>();
            p.Add("distanceOfTravel", -230);
            p.Add("scanDistance", -5324);
            p.Add("percentage", 999);

            // Set the parameters to the ParameterSet
            set.SetParameters(p);

            // Assertions
            Debug.Assert(string.Compare(set.dummyValue, "Dynamic invocation is neat!") == 0);
            Debug.Assert(set.dummyValue0 == -230);
            Debug.Assert(set.dummyValue1 == -5324);
            Debug.Assert(set.dummyValue2 == 999);

            Console.WriteLine("ParameterSet.Test: All tests passed!");
            Console.ReadLine();
        }
    }
}
