using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Record;

namespace Record.Test
{
    class RecordTest
    {
        static void Main(string[] args)
        {
            Record NewRecord = new Record();
            for (int i = 0; i < 40; i++)
            {
                NewRecord.AddState(3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14, 3.14);
                NewRecord.AddState(2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13, 2.13);
                NewRecord.AddState(1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01, 1.01);
            }
            NewRecord.AxisOneMaxForce = 3.14;
            NewRecord.AxisTwoRMSForce = 3.145634;
            Console.WriteLine(NewRecord.AxisThreeAcceleration[0]);
           NewRecord.WriteToFile();
            //Console.WriteLine(newRecord.AxisOneMaxForce);
            while (true)
            {

            }
        }
    }
}
