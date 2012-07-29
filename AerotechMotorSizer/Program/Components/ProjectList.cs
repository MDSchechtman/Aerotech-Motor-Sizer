using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Interfaces;
using Utility;

namespace Program
{
    public class ProjectList
    {
        private MainForm _mainForm;
        private TreeView _tree;

        private Project _project;
        private Dictionary<string, TableLayoutPanel> _panels;

        public ProjectList(MainForm mainForm)
        {
            _mainForm = mainForm;
            _project = new Project();
            _project.Name = "Project 1";

            _project.Environment = new SimulationEnv();
            _project.Environment.StaticFriction = 0;
            _project.Environment.DynamicFriction = 0;
            _project.Environment.AmbientTemp = 20;
            _project.Environment.MechEfficiency = 95;
            _project.Environment.ThrustForce = 0;
            _project.Environment.Cooling = "No Cooling";
            
            _mainForm.Project = _project;

            _project.ParameterInput = new ParameterInputScene(_mainForm);
            _project.FileConverter = new FileConverterScene(_mainForm);
            _project.FunctionConverter = new FunctionConverterScene(_mainForm);
            _project.NewProject = new NewProjectScene(_mainForm);
            _project.Profile = new ProfileScene(_mainForm);
            _project.Profile.Name = "Profile 1";
            _project.Sequence = new SequenceScene(_mainForm);
            _project.Sequence.Name = "Sequence 1";
            _project.ChooseMotor = new ChooseMotorScene(_mainForm);
            _project.Warn = new OutputScene(_mainForm);

            _panels = new Dictionary<string, TableLayoutPanel>();
            _panels.Add(_project.Name, _project.NewProject.Component);
            _panels.Add(_project.Profile.Name, _project.Profile.Component);
            _panels.Add(_project.Sequence.Name, _project.Sequence.Component);
            
            // Subscribe to update event
            _project.Update += new Project.UpdateHandler(project_Update);

            _tree = new TreeView();

            Initialize();
            DoSetup();
        }

        public Project Project
        {
            get { return _project; }
            set
            {
                _project = value;
                DoSetup();
            }
        }

        public ProjectList(MainForm mainForm, Project project)
        {
            _mainForm = mainForm;
            _project = project;
            _project.Name = "Project 1";

            _project.Environment = new SimulationEnv();
            _project.Environment.StaticFriction = 0;
            _project.Environment.DynamicFriction = 0;
            _project.Environment.AmbientTemp = 20;
            _project.Environment.MechEfficiency = 95;
            _project.Environment.ThrustForce = 0;
            _project.Environment.Cooling = "No Cooling";

            _project.ParameterInput = new ParameterInputScene(_mainForm);
            _project.FileConverter = new FileConverterScene(_mainForm);
            _project.FunctionConverter = new FunctionConverterScene(_mainForm);
            _project.NewProject = new NewProjectScene(_mainForm);
            _project.Profile = new ProfileScene(_mainForm);
            _project.Profile.Name = "Profile 1";
            _project.Sequence = new SequenceScene(_mainForm);
            _project.Sequence.Name = "Sequence 1";
            
            _project.ChooseMotor = new ChooseMotorScene(_mainForm);
            _project.Warn = new OutputScene(_mainForm);

            _panels = new Dictionary<string, TableLayoutPanel>();
            _panels.Add(_project.Name, _project.NewProject.Component);
            _panels.Add(_project.Profile.Name, _project.Profile.Component);
            _panels.Add(_project.Sequence.Name, _project.Sequence.Component);

            // Subscribe to update event
            project.Update += new Project.UpdateHandler(project_Update);

            _tree = new TreeView();

            Initialize();
            DoSetup();
        }

        public TreeView Component
        {
            get { return _tree; }
        }

        public void RenameProfile(string newName)
        {
            string old = _project.Profile.Name;
            _project.Profile.Name = newName;

            TableLayoutPanel t;
            if (_panels.TryGetValue(old, out t))
            {
                _panels.Remove(old);
                _panels.Add(newName, t);
            }

            DoSetup();
        }

        private void Initialize()
        {
            _tree.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _tree.Dock = DockStyle.Fill;
        }

        private void DoSetup()
        {
            _tree.Nodes.Clear();

            TreeNode root = new TreeNode(_project.Name);

            TreeNode profileNode = new TreeNode(_project.Profile.Name);
            TreeNode sequenceNode = new TreeNode(_project.Sequence.Name);
            sequenceNode.Nodes.Add(profileNode);
            root.Nodes.Add(sequenceNode);

            _tree.AfterSelect += new TreeViewEventHandler(_tree_AfterSelect);
            _tree.Nodes.Add(root);
            root.ExpandAll();
        }

        void project_Update(object sender, EventArgs args)
        {
            DoSetup();
        }

        void _tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_panels.Keys.Contains(e.Node.Text))
                _mainForm.MainPanel.SetMiddle(_panels[e.Node.Text]);
        }
    }
}
