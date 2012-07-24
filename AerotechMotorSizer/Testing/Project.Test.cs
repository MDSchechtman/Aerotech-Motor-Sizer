using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;
using Utility;
using Program;

namespace Testing
{
    class ProjectTest : ITesting
    {
        public bool DoTest()
        {
            Project project = new Project();
            project.Axis1 = new Axis(new Utility.Converters.FunctionConverter("Sin(x)", 100, 1, 0));

            return true;
        }

    }
}
