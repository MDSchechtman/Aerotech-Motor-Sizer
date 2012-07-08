using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Utility;

namespace Program
{
    public class Project
    {
        private Motor _projectMotor;
        private String _name;

        // Default constructor
        public Project()
        {
            _name = "Unnamed Project";
            Motor ProjectMotor = new Motor();
        }

        public Project(Motor projectMotor)
        {
            _name = "Unnamed Project";
            _projectMotor = projectMotor;
        }

        public Project(Motor projectMotor, String name)
        {
            _name = name;
            _projectMotor = projectMotor;
        }

        // Project Motor
        public Motor Motor
        {
            get  { return _projectMotor; }
            set { _projectMotor = value; }
        }

        // Project Name
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
