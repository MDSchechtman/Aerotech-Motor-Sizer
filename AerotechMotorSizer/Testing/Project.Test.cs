using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces;
using Utility;
using Program;
using Simulation;

namespace Testing
{
    class ProjectTest : ITesting
    {
        public bool DoTest()
        {
            Project p = new Project();
            p.Update += new Project.UpdateHandler(p_Update);
            p.Name = "New Name";

            while (string.Compare(p.Name, "Success") != 0) { }

            return true;
        }

        void p_Update(object sender, EventArgs args)
        {
            (sender as Project).Update -= p_Update;
            (sender as Project).Name = "Success";
        }
    }
}
