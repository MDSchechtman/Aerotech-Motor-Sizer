using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Interfaces;
using Simulation;

namespace Program
{
    public class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private MainPanel _panel;
        private NewProjectScene _newProjectScene;
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

        private void LoadOutputScene()
        {
            OutputScene scene = new OutputScene(this);
            _panel.SetMiddle(scene.Component);
        }

        private void InitializeComponents()
        {
            Project = new Project();

            MainMenu menu = new MainMenu(this);
            MainPanel panel = new MainPanel(this);
            _newProjectScene = new NewProjectScene(this); 

            this.SuspendLayout();

            // Setup Controls
            panel.SetLeft(_projectList.Component);
            panel.SetMiddle(_newProjectScene.Component);

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
