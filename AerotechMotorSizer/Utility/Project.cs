using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Utility;
using Interfaces;

namespace Program
{
    public class Project
    {
        private string _Name;
        private IMotor _Motor;
        private ILoad _Load;
        private IAxis _Axis1;
        private IAxis _Axis2;
        private IAxis _Axis3;
        private SimulationEnv _Environment;

        //constructor
        public Project(IMotor motor)
        {
            _Motor = motor;
        }

        //another constructor
        public Project()
        {
            Motor ProjectMotor = new Motor();
        }

        //get and set the project name
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        //get and set the project motor
        public IMotor Motor
        {
            get
            {
                return _Motor;
            }
            set
            {
                _Motor = value;
            }
        }

        public ILoad Load
        {
            get
            {
                return _Load;
            }
            set
            {
                _Load = value;
            }
        }

        public IAxis Axis1
        {
            get
            {
                return _Axis1;
            }
            set
            {
                _Axis1 = value;
            }
        }

        public IAxis Axis2
        {
            get
            {
                return _Axis2;
            }
            set
            {
                _Axis2 = value;
            }
        }

        public IAxis Axis3
        {
            get
            {
                return _Axis3;
            }
            set
            {
                _Axis3 = value;
            }
        }

        public SimulationEnv Environment
        {
            get
            {
                return _Environment;
            }
            set
            {
                _Environment = value;
            }
        }
    }
}
