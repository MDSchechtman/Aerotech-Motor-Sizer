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
            IRecord record = new Utility.Record();
            Random r = new Random(66642);

            record.Add(0, 0, 0, 0, 0, 0, 0);
            for (int i = 1; i < 100; i++)
            {
                double time = i;
                double position = r.Next((int) record.Position[i - 1] - 5, (int) record.Position[i - 1] + 5);
                double velocity = r.Next((int) record.Position[i - 1] - 5, (int) record.Position[i - 1] + 5);
                double temperature = r.Next(0, 10);
                double acceleration = r.Next(0, 10);
                double current = r.Next(0, 10);
                double torque = r.Next(0, 10);

                record.Add(position, velocity, time, temperature, acceleration, current, torque);
            }

            record.Write(string.Format(@"{0}/RecordTest.txt", System.IO.Directory.GetCurrentDirectory()));
            return true;
        }
    }
}
