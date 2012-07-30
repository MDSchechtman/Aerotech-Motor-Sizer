using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

using Interfaces;
using Utility;

namespace Program
{
    public class Project
    {
        private string _Name;
        private Motor _Motor;
        private Load _Load;
        private Axis _Axis1;
        private Axis _Axis2;
        private Axis _Axis3;
        private Utility.SimulationEnv _Environment;

        public delegate void UpdateHandler(object sender, EventArgs args);
        public event UpdateHandler Update;

        private ParameterInputScene _ParameterInputScene;
        private FileConverterScene _FileConverterScene;
        private FunctionConverterScene _FunctionConverterScene;
        private ChooseMotorScene _ChooseMotorScene;
        private NewProjectScene _NewProjectScene;
        private ProfileScene _ProfileScene;
        private SequenceScene _SequenceScene;
        private OutputScene _WarningScene;

        [XmlIgnoreAttribute]
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

        [XmlIgnoreAttribute]
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

        [XmlIgnoreAttribute]
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

        [XmlIgnoreAttribute]
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

        [XmlIgnoreAttribute]
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

        [XmlIgnoreAttribute]
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

        [XmlIgnoreAttribute]
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

        [XmlIgnoreAttribute]
        public OutputScene Warn
        {
            get
            {
                return _WarningScene;
            }
            set
            {
                _WarningScene = value;
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
            _Motor = (Motor) motor;
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
        public Motor Motor
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

        public Load Load
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

        public Axis Axis1
        {
            get
            {
                return (_Axis1 == null) ? new Axis() : _Axis1;
            }
            set
            {
                _Axis1 = value;
                OnUpdate(this, new EventArgs());
            }
        }

        public Axis Axis2
        {
            get
            {
                return (_Axis2 == null) ? new Axis() : _Axis2;
            }
            set
            {
                _Axis2 = value;
                OnUpdate(this, new EventArgs());
            }
        }

        public Axis Axis3
        {
            get
            {
                return (_Axis3 == null) ? new Axis() : _Axis3;
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

        public static bool SaveProject(Project o, string filename)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Project));
            StreamWriter file = new StreamWriter(filename);
            writer.Serialize(file, o);
            file.Close();
            return true;
        }

        public static Project LoadProject(string filename)
        {
            XmlSerializer reader = new XmlSerializer(typeof(Project));
            StreamReader file = new StreamReader(filename);
            Project o = new Project();
            o = (Project) reader.Deserialize(file);

            return o;
        }
    }
}
