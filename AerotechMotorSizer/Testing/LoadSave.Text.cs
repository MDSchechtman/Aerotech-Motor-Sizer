using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;
using Utility;
using Program;

namespace Testing
{
    class LoadSaveTest : ITesting
    {
        public bool DoTest()
        {
            string file = string.Concat(System.IO.Directory.GetCurrentDirectory(), @"\LoadSaveTest.xml");

            IConverter converter = new Utility.Converters.FunctionConverter("Sin(x)", 100, 1, 0);
            Project save = new Project();

            save.Axis1 = new Axis(converter);
            save.Axis2 = new Axis(converter);
            save.Axis3 = new Axis(converter);

            if (Project.SaveProject(save, file))
            {
                Project load = Project.LoadProject(file);

                if (load == null)
                    return false;
            }
            else
                return false;

            return true;
        }

    }
}
