using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Interfaces;

namespace Program
{
    // Creates a popup window 
    public class Popup : Form
    {
        private MainForm _mainForm;

        public Popup(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        public void Show(Control c)
        {
            this.Controls.Add(c);
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Size = c.PreferredSize;
            this.ShowDialog(_mainForm);
        }
    }
}
