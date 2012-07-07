using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program
{
    public class MainForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private MainPanel _panel;
        public static System.Drawing.Size initialSize = new System.Drawing.Size(1440, 768);

        public MainForm()
        {
            InitializeComponents();
        }

        public MainPanel MainPanel
        {
            get { return _panel; }
        }

        private void InitializeComponents()
        {
            MainMenu menu = new MainMenu(this);
            MainPanel panel = new MainPanel(this);
            ProfileList list = new ProfileList(this);
            NewProjectScene scene = new NewProjectScene(this); 

            ///////
            list.Component.Nodes.Add(new TreeNode("Item"));
            list.Component.Nodes.Add(new TreeNode("Item"));
            list.Component.Nodes.Add(new TreeNode("Item"));


            this.SuspendLayout();

            // Setup Controls
            panel.SetLeft(list.Component);
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
