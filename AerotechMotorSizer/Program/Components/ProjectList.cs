using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Interfaces;

namespace Program
{
    public class ProjectList
    {
        private MainForm _mainForm;
        private TreeView _tree;

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

            // Subscribe to update event
            project.Update += new Project.UpdateHandler(project_Update);

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
            _projects = new List<Project>();

            // Subscribe to update event
            project.Update += new Project.UpdateHandler(project_Update);

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

            foreach (Project p in _projects)
            {
                TreeNode root = new TreeNode(p.Name);

                TreeNode motor = new TreeNode("Motor");
                root.Nodes.Add(motor);
                if (p.Motor != null)
                {
                    motor.Nodes.Add(p.Motor.Name.ToString());
                    //motor.Nodes.Add(p.Motor.Inductance.ToString());
                    motor.Nodes.Add(p.Motor.MotorConstant.ToString());
                    //motor.Nodes.Add(p.Motor.Mass.ToString());
                    //motor.Nodes.Add(p.Motor.MaxTemp.ToString());
                    //motor.Nodes.Add(p.Motor.MomentOfInertia.ToString());
                    motor.Nodes.Add(p.Motor.Resistance.ToString());
                    motor.Nodes.Add(p.Motor.ThermalResistance_Catalog_20psi.ToString());
                }

                TreeNode input = new TreeNode("Input");
                root.Nodes.Add(input);
                if (p.Converter1 != null)
                {
                    IConverter converter = p.Converter1;
                    if (converter.HasPosition)
                        input.Nodes.Add(string.Format("Array: [{0}]", p.Converter1.Position.Length));
                    if (converter.HasVelocity)
                        input.Nodes.Add(string.Format("Array: [{0}]", p.Converter1.Velocity.Length));
                    if (converter.HasAcceleration)
                        input.Nodes.Add(string.Format("Array: [{0}]", p.Converter1.Acceleration.Length));

                    input.Nodes.Add(string.Format("Array: [{0}]", p.Converter1.Time.Length));

                }

                TreeNode output = new TreeNode("Output");
                root.Nodes.Add(output);

                TreeNode profileNode = new TreeNode("Profile X");
                TreeNode sequenceNode = new TreeNode("Sequence X");
                sequenceNode.Nodes.Add(profileNode);
                root.Nodes.Add(sequenceNode);

                _tree.AfterSelect += new TreeViewEventHandler(_tree_AfterSelect);
                _tree.Nodes.Add(root);
                root.ExpandAll();
            }
        }

        void project_Update(object sender, EventArgs args)
        {
            DoSetup();
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
