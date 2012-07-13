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
        public static System.Drawing.Size initialSize = new System.Drawing.Size(1440, 768);

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

        public ProjectList ProjectList
        {
            get { return _projectList; }
        }

        public void DoSolver(IConverter converter)
        {
            // ISolver solver = new Solver();
        }

        private void LoadOutputScene()
        {
            OutputScene scene = new OutputScene(this);
            _panel.SetMiddle(scene.Component);
        }

        private void InitializeComponents()
        {
            _projectList = new ProjectList(this);

            MainMenu menu = new MainMenu(this);
            MainPanel panel = new MainPanel(this);
            NewProjectScene scene = new NewProjectScene(this); 

            this.SuspendLayout();

            // Setup Controls
            panel.SetLeft(_projectList.Component);
            panel.SetMiddle(scene.Component);

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
