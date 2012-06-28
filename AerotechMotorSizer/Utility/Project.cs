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

        //constructor
        public Project(Motor projectMotor)
        {
            _projectMotor = projectMotor;
        }

        //another constructor
        public Project()
        {
            Motor ProjectMotor = new Motor();
        }

        //get and set the project motor
        public Motor Motor
        {
            get
            {
                return _projectMotor;
            }
            set
            {
                _projectMotor = value;
            }
        }

    }
}
