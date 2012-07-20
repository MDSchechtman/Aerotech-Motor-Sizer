using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program
{
    public class ProjectList
    {
        private MainForm _mainForm;
        private TreeView _tree;
        private TreeNode _root;

        private List<Project> _projects;
        private Dictionary<string, TableLayoutPanel> _panels;
        private Dictionary<string, TableLayoutPanel> _motorPanels;

        public ProjectList(MainForm mainForm)
        {
            _projects = new List<Project>();
            _panels = new Dictionary<string, TableLayoutPanel>();
            _motorPanels = new Dictionary<string, TableLayoutPanel>();

            Project project = new Project();
            project.Name = "Project 1";
            project.ParameterInput = new ParameterInputScene(_mainForm);
            project.NewProject = new NewProjectScene(_mainForm);
            project.Profile = new ProfileScene(_mainForm);
            project.Profile.Name = "Profile 1";
            project.Sequence = new SequenceScene(_mainForm);
            project.Sequence.Name = "Sequence 1";
            project.ChooseMotor = new ChooseMotorScene(_mainForm);

            _panels.Add(project.Name, project.NewProject.Component);
            _panels.Add(project.Profile.Name, project.Profile.Component);
            _panels.Add(project.Sequence.Name, project.Sequence.Component);

            _motorPanels.Add(project.Profile.Name, project.ChooseMotor.Component);

            _projects.Add(project);
            _mainForm = mainForm;
            _tree = new TreeView();

            Initialize();
            DoSetup();
        }

        public ProjectList(MainForm mainForm, Project project)
        {
            _projects.Add(project);
            _mainForm = mainForm;
            _tree = new TreeView();

            Initialize();
            DoSetup();
        }

        public void Add(Project project)
        {
            _projects.Add(project);
            DoSetup();
        }

        public void Add(string name)
        {
            Project project = new Project();
            project.Name = name;
            _projects.Add(project);
            DoSetup();
        }

        public Project Get(string name)
        {
            for (int i = 0; i < _projects.Count; i++)
            {
                if (_projects[i].Name.Equals(name))
                    return _projects[i];
            }

            return null;
        }
            /*
        {
            get { return _project.; }
            set 
            { 
                _project = value;
                DoSetup();
            }
        }*/

        public TreeView Component
        {
            get { return _tree; }
        }

        private void Initialize()
        {
            _tree.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _tree.Dock = DockStyle.Fill;
        }

        private void DoSetup()
        {
            _tree.Nodes.Clear();

            TreeNode motor = new TreeNode("Motor");
            TreeNode input = new TreeNode("Input");
            TreeNode output = new TreeNode("Output");

            //_project.Name = "Project 1";
            _root = new TreeNode(_projects[0].Name);

            _root.Nodes.Add(motor);
            if (_projects[0].Motor != null)
            {
                motor.Nodes.Add(_projects[0].Motor.Inductance.ToString());
                motor.Nodes.Add(_projects[0].Motor.KT.ToString());
                motor.Nodes.Add(_projects[0].Motor.Mass.ToString());
                motor.Nodes.Add(_projects[0].Motor.MaxTemp.ToString());
                motor.Nodes.Add(_projects[0].Motor.MomentOfInertia.ToString());
                motor.Nodes.Add(_projects[0].Motor.Resistance.ToString());
                motor.Nodes.Add(_projects[0].Motor.ThermalResistance.ToString());
            }
            _root.Nodes.Add(input);
            _root.Nodes.Add(output);

            TreeNode profileNode = new TreeNode("Profile 1");
            TreeNode sequenceNode = new TreeNode("Sequence 1");
            sequenceNode.Nodes.Add(profileNode);
            _root.Nodes.Add(sequenceNode);

            _tree.AfterSelect += new TreeViewEventHandler(_tree_AfterSelect);
            _tree.Nodes.Add(_root);
            _root.ExpandAll();
        }

        void _tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_panels.Keys.Contains(e.Node.Text))
                _mainForm.MainPanel.SetMiddle(_panels[e.Node.Text]);

            if (_motorPanels.Keys.Contains(e.Node.Text))
                _mainForm.MainPanel.SetRight(_motorPanels[e.Node.Text]);
            else
                _mainForm.MainPanel.SetRight(new TableLayoutPanel());
        }
    }
}
