using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project
{
    public class Project
    {
        private Motor.Motor ProjectMotor;

        //constructor
        public Project(Motor.Motor newMotor)
        {
            ProjectMotor = newMotor;
        }

        //another constructor
        public Project()
        {
            Motor.Motor ProjectMotor = new Motor.Motor();
        }

        //get and set the project motor
        public Motor.Motor Motor
        {
            get
            {
                return ProjectMotor;
            }
            set
            {
                ProjectMotor = value;
            }
        }

    }
}
