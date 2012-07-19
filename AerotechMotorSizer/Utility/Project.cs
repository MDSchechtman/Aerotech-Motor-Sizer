using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Utility;
using Interfaces;

namespace Program
{
    public class UpdateEventArgs : EventArgs
    {
        public UpdateEventArgs() { }
    }

    public class Project
    {
        private string _Name;
        private IMotor _Motor;
        private ILoad _Load;
        private IAxis _Axis1;
        private IAxis _Axis2;
        private IAxis _Axis3;
        private SimulationEnv _Environment;
        private IConverter _converter;

        public delegate void UpdateHandler(object sender, UpdateEventArgs args);
        public event UpdateHandler Update;

        protected void OnUpdate(object sender, UpdateEventArgs args)
        {
            if (Update != null)
            {
                Update(this, args);
            }
        }

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
                return (_Name != null && _Name != string.Empty) ? _Name : "Unnamed Project";
            }
            set
            {
                _Name = value;
                OnUpdate(this, new UpdateEventArgs());
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
                OnUpdate(this, new UpdateEventArgs());
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
                OnUpdate(this, new UpdateEventArgs());
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
                OnUpdate(this, new UpdateEventArgs());
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
                OnUpdate(this, new UpdateEventArgs());
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
                OnUpdate(this, new UpdateEventArgs());
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
                OnUpdate(this, new UpdateEventArgs());
            }
        }

        public IConverter Converter
        {
            get
            {
                return _converter;
            }
            set
            {
                _converter = value;
                OnUpdate(this, new UpdateEventArgs());
            }
        }
    }
}
