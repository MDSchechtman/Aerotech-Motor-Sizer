using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Interfaces;
using Project;
using Motor;
using Environment;
using Load;


namespace Project.Test
{
    class ProjectTest : ITesting
    {
        public bool DoTest()
        {
            Project TestProject = new Project();
            //TestProject.Motor.Mass = 3.14;
            //Console.WriteLine(TestProject.Motor.Mass);

            return true;
        }
    }
}
