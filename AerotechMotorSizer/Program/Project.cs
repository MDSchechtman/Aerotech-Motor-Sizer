using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        private Utility.SimulationEnv _Environment;
        private IConverter _converter;

        public delegate void UpdateHandler(object sender, EventArgs args);
        public event UpdateHandler Update;

        private ParameterInputScene _ParameterInputScene;
        private FileConverterScene _FileConverterScene;
        private FunctionConverterScene _FunctionConverterScene;
        private ChooseMotorScene _ChooseMotorScene;
        private NewProjectScene _NewProjectScene;
        private ProfileScene _ProfileScene;
        private SequenceScene _SequenceScene;

        //get and set the 
        public ParameterInputScene ParameterInput
        {
            get
            {
                return _ParameterInputScene;
            }
            set
            {
                _ParameterInputScene = value;
                //OnUpdate(this, new EventArgs());
            }
        }

        //get and set the 
        public FileConverterScene FileConverter
        {
            get
            {
                return _FileConverterScene;
            }
            set
            {
                _FileConverterScene = value;
                //OnUpdate(this, new EventArgs());
            }
        }

        //get and set the 
        public FunctionConverterScene FunctionConverter
        {
            get
            {
                return _FunctionConverterScene;
            }
            set
            {
                _FunctionConverterScene = value;
                //OnUpdate(this, new EventArgs());
            }
        }

        //get and set the 
        public ChooseMotorScene ChooseMotor
        {
            get
            {
                return _ChooseMotorScene;
            }
            set
            {
                _ChooseMotorScene = value;
                //OnUpdate(this, new EventArgs());
            }
        }

        //get and set the 
        public NewProjectScene NewProject
        {
            get
            {
                return _NewProjectScene;
            }
            set
            {
                _NewProjectScene = value;
                //OnUpdate(this, new EventArgs());
            }
        }

        //get and set the 
        public ProfileScene Profile
        {
            get
            {
                return _ProfileScene;
            }
            set
            {
                _ProfileScene = value;
                //OnUpdate(this, new EventArgs());
            }
        }

        //get and set the 
        public SequenceScene Sequence
        {
            get
            {
                return _SequenceScene;
            }
            set
            {
                _SequenceScene = value;
                //OnUpdate(this, new EventArgs());
            }
        }

        protected void OnUpdate(object sender, EventArgs args)
        {
            if (Update != null)
            {
                Update(this, args);
            }
        }

        //defualt constructor
        public Project() { }

        //constructor
        public Project(IMotor motor)
        {
            _Motor = motor;
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
                OnUpdate(this, new EventArgs());
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
                OnUpdate(this, new EventArgs());
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
                OnUpdate(this, new EventArgs());
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
                OnUpdate(this, new EventArgs());
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
                OnUpdate(this, new EventArgs());
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
                OnUpdate(this, new EventArgs());
            }
        }

        public Utility.SimulationEnv Environment
        {
            get
            {
                return _Environment;
            }
            set
            {
                _Environment = value;
                OnUpdate(this, new EventArgs());
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
                OnUpdate(this, new EventArgs());
            }
        }
    }
}