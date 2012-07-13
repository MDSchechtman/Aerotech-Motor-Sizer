﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;
using Utility;

namespace Program.Test
{
    public class Converters
    {
        public bool DoTest()
        {
            // Test the ParameterSetConverter
            {
                // Populate the dictionary
                Dictionary<string, double> p = new Dictionary<string, double>();
                p.Add("distanceOfTravel", 10);
                p.Add("totalTime", 20);
                p.Add("percentage", 0.50);

                // Set the parameters to the ParameterSet
                Utility.Converters.ParameterSetConverter set = new Utility.Converters.ParameterSetConverter(p, 0.1);
            }

            // Test the FunctionConverter
            {
            }

            // Test the FileConverter
            {
            }

            return true;
        }
    }
}
