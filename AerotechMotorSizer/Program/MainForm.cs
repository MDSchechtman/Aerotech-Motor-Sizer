using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Interfaces;

namespace Program
{
    public class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private MainPanel _panel;
        private ProjectList _projectList;
        private Project _project;
        public static System.Drawing.Size initialSize = new System.Drawing.Size(1400, 700);

        public MainForm()
        {
            InitializeComponents();
        }

        public static void Alert(string alert)
        {
            MessageBox.Show(alert);
        }

        public MainPanel MainPanel
        {
            get { return _panel; }
        }

        public Project Project
        {
            get { return _project; }
            set 
            {
                _project = value;
                // Projectlist subscribes to Project.Update
                _projectList = new ProjectList(this, _project);
            }
        }

        public ProjectList ProjectList
        {
            get { return _projectList; }
        }


        public void LoadNewProjectScene(bool modal)
        {
            Popup p = new Popup(this);
            NewProjectScene scene = new NewProjectScene(this, p, true);
            if (modal)
                p.Show(scene.Component);
            else
                _panel.SetMiddle(scene.Component);
        }

        public void LoadOutputScene()
        {
            OutputScene scene = new OutputScene(this);
            _panel.SetMiddle(scene.Component);
        }

        private void InitializeComponents()
        {
            Project = new Project();
            //_projectList = new ProjectList(this, Project);

            MainMenu menu = new MainMenu(this);
            MainPanel panel = new MainPanel(this);

            this.SuspendLayout();

            // Setup Controls
            panel.SetLeft(_projectList.Component);
            panel.SetRight(Project.ChooseMotor.Component);
            panel.SetRightBottom(Project.Warn.Component);

            // Add controls
            this.Controls.Add(panel.Component);
            this.Controls.Add(menu.Component);

            this.MainMenuStrip = menu.Component;
            this.Padding = new Padding(1);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = initialSize;
            this.Name = "MainForm";
            this.Text = "Aerotech Motor Sizer";

            this.ResumeLayout(false);
            this.PerformLayout();

            _panel = panel;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
