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
        public static System.Drawing.Size initialSize = new System.Drawing.Size(1440, 768);

        public MainForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            MainMenu menu = new MainMenu(this);
            MainPanel panel = new MainPanel(this);
            ProfileList list = new ProfileList(this);
            ProfileList list2 = new ProfileList(this);

            this.SuspendLayout();

            // Setup Controls
            panel.Add(list.Component, 0, 0);
            list.Component.Anchor = AnchorStyles.Top;
            list.Component.Dock = DockStyle.Top;
            panel.Add(list2.Component, 0, 1);
            list2.Component.Anchor = AnchorStyles.Top;
            list2.Component.Dock = DockStyle.Top;

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
