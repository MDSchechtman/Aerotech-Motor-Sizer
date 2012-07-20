using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Interfaces;
using Simulation;

namespace Program
{
    public class ProjectList
    {
        private Form _mainForm;
        private TreeView _tree;
        private TreeNode _root;

        private Project _project;

        public ProjectList(MainForm mainForm)
        {
            _project = new Project();
            _mainForm = mainForm;
            _tree = new TreeView();

            Initialize();
            DoSetup();
        }

        public ProjectList(MainForm mainForm, Project project)
        {
            _project = project;
            _mainForm = mainForm;
            _tree = new TreeView();

            Initialize();
            DoSetup();
        }

        public TreeView Component
        {
            get { return _tree; }
        }

        private void Initialize()
        {
            _tree.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _tree.Dock = DockStyle.Fill;

            _project.Update += new Project.UpdateHandler(_project_Update);
        }

        private void DoSetup()
        {
            _tree.Nodes.Clear();

            TreeNode motor = new TreeNode("Motor");
            TreeNode input = new TreeNode("Input");
            TreeNode output = new TreeNode("Output");

            _root = new TreeNode(_project.Name);

            _root.Nodes.Add(motor);
            if (_project.Motor != null)
            {
                motor.Nodes.Add(_project.Motor.Inductance.ToString());
                motor.Nodes.Add(_project.Motor.KT.ToString());
                motor.Nodes.Add(_project.Motor.Mass.ToString());
                motor.Nodes.Add(_project.Motor.MaxTemp.ToString());
                motor.Nodes.Add(_project.Motor.MomentOfInertia.ToString());
                motor.Nodes.Add(_project.Motor.Resistance.ToString());
                motor.Nodes.Add(_project.Motor.ThermalResistance.ToString());
            }
            _root.Nodes.Add(input);
            if (_project.Converter != null)
            {
                IConverter converter = _project.Converter;
                if (converter.HasPosition)
                    input.Nodes.Add(string.Format("Array: [{0}]", _project.Converter.Position.Length));
                if (converter.HasVelocity)
                    input.Nodes.Add(string.Format("Array: [{0}]", _project.Converter.Velocity.Length));
                if (converter.HasAcceleration)
                    input.Nodes.Add(string.Format("Array: [{0}]", _project.Converter.Acceleration.Length));

                input.Nodes.Add(string.Format("Array: [{0}]", _project.Converter.Time.Length));

            }
            _root.Nodes.Add(output);

            _tree.Nodes.Add(_root);
            _root.ExpandAll();
        }

        void _project_Update(object sender, EventArgs args)
        {
            DoSetup();
        }
    }
}
