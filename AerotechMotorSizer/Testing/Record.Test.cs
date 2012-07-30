using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Interfaces;
using Utility;

namespace Testing
{
    class RecordTest : ITesting
    {
        public bool DoTest()
        {
            Dictionary<string, double> myParams = new Dictionary<string, double>();
            myParams.Add("distanceOfTravel", 1000);
            myParams.Add("totalTime", 100);
            myParams.Add("percentage", 0.5);
            myParams.Add("timeStep", 0.1);

            IConverter converter = new Utility.Converters.ParameterSetConverter(myParams, "Linear");
            IPath P = new Path(converter);
            IRecord record = new Utility.Record(P);
            Random r = new Random(66642);
            
            //for (int i = 1; i < 100; i++)
            //{
            //    double time = i;
            //    double position = r.Next((int) record.Position[i - 1] - 5, (int) record.Position[i - 1] + 5);
            //    double velocity = r.Next((int) record.Position[i - 1] - 5, (int) record.Position[i - 1] + 5);
            //    double temperature = r.Next(0, 10);
            //    double acceleration = r.Next(0, 10);
            //    double current = r.Next(0, 10);
            //    double torque = r.Next(0, 10);
            //}

            //record.Write(string.Format(@"{0}/RecordTest.txt", System.IO.Directory.GetCurrentDirectory()));
            return false;
        }
    }
}
