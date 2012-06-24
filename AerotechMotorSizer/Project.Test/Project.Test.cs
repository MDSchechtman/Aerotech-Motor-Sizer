using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Project;
using Motor;
using Environment;
using Load;


namespace Project.Test
{
    class ProjectTest
    {
        static void Main(string[] args)
        {
            Project TestProject = new Project();
            TestProject.Motor.Mass = 3.14;
            Console.WriteLine(TestProject.Motor.Mass);
            while (true)
            {
            }
        }
    }
}
