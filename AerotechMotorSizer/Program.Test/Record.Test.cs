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
            IRecord NewRecord = new Utility.Record();
            //for (int i = 0; i < 40; i++)
            //{
            //    NewRecord.Add(3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14);
            //    NewRecord.Add(2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13);
            //    NewRecord.Add(1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01);
            //}

            //NewRecord.AxisOneMaxForce = 3.14;
            //NewRecord.AxisTwoRMSForce = 3.145634;
            //NewRecord.WriteToFile();

            //if (NewRecord.AxisThreeAcceleration[0] != 3.14) return false;

            return true;
        }
    }
}
