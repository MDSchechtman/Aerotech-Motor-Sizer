﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program
{
    public class MainMenu
    {
        private MenuStrip _menuStrip;
        private Form _mainForm;

        public MainMenu(Form mainForm)
        {
            _mainForm = mainForm;
            _menuStrip = new MenuStrip();

            Initialize();
        }

        public MenuStrip Component
        {
            get { return _menuStrip; }
        }

        private void Initialize()
        {
            ToolStripMenuItem file = new ToolStripMenuItem();

            ToolStripMenuItem edit = new ToolStripMenuItem();
            ToolStripMenuItem view = new ToolStripMenuItem();
            ToolStripMenuItem help = new ToolStripMenuItem();


            _menuStrip.SuspendLayout();

            _menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { file, edit, view, help });
            _menuStrip.Location = new System.Drawing.Point(0, 0);
            _menuStrip.Size = new System.Drawing.Size(1420, 24);
            _menuStrip.TabIndex = 0;
            _menuStrip.Name = "_menuStrip";
            _menuStrip.Text = "Main Menu";

            ToolStripMenuItem file1 = new ToolStripMenuItem("New");
            ToolStripMenuItem file2 = new ToolStripMenuItem("Open");
            ToolStripMenuItem file3 = new ToolStripMenuItem("Save");
            ToolStripMenuItem file4 = new ToolStripMenuItem("Save As..");
            ToolStripMenuItem file5 = new ToolStripMenuItem("Exit");
            file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { file1, file2, file3, file4, file5});
            file.Name = "fileToolStripMenuItem";
            file.Text = "File";

            ToolStripMenuItem edit1 = new ToolStripMenuItem("One");
            ToolStripMenuItem edit2 = new ToolStripMenuItem("Two");
            ToolStripMenuItem edit3 = new ToolStripMenuItem("Three");
            ToolStripMenuItem edit4 = new ToolStripMenuItem("Four");
            ToolStripMenuItem edit5 = new ToolStripMenuItem("Five");
            edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { edit1, edit2, edit3, edit4, edit5 });
            edit.Name = "editToolStripMenuItem";
            edit.Text = "Edit";

            ToolStripMenuItem view1 = new ToolStripMenuItem("One");
            ToolStripMenuItem view2 = new ToolStripMenuItem("Two");
            ToolStripMenuItem view3 = new ToolStripMenuItem("Three");
            ToolStripMenuItem view4 = new ToolStripMenuItem("Four");
            ToolStripMenuItem view5 = new ToolStripMenuItem("Five");
            view.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { view1, view2, view3, view4, view5 });
            view.Name = "viewToolStripMenuItem";
            view.Text = "View";

            ToolStripMenuItem help1 = new ToolStripMenuItem("One");
            ToolStripMenuItem help2 = new ToolStripMenuItem("Two");
            ToolStripMenuItem help3 = new ToolStripMenuItem("Three");
            ToolStripMenuItem help4 = new ToolStripMenuItem("Four");
            ToolStripMenuItem help5 = new ToolStripMenuItem("Five");
            help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { help1, help2, help3, help4, help5 });
            help.Name = "helpToolStripMenuItem";
            help.Text = "Help";

            file5.Click += new EventHandler(file5_Click);
            file4.Click += new EventHandler(file4_Click);
            file3.Click += new EventHandler(file3_Click);
            file2.Click += new EventHandler(file2_Click);
            file1.Click += new EventHandler(file1_Click);

            _menuStrip.ResumeLayout(false);
            _menuStrip.PerformLayout();
        }

        void file1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void file2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void file3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void file4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void file5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
