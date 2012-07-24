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
            // Position type
            IConverter converter = new Utility.Converters.FunctionConverter("Sin(x)", 100, 1, 0);
            IPath path = new Path(converter);
            IRecord record = new Record(path);

            for (int i = 0; i < record.Time.Length; i++)
            {
                if ((int)record.Time[i] != i)
                    return false;
            }

            // Check some random values
            if (!Check(record.Position[10], -0.54402111088936977))
                return false;
            if (!Check(record.Position[50], -0.26237485370392877))
                return false;
            if (!Check(record.Position[90], 0.89399666360055785))
                return false;

            return true;
        }

        double tolerance = 0.0000000001;
        private bool Check(double a, double b)
        {
            return a - b < tolerance;
        }
    }
}
