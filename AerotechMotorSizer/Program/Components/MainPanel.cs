using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program
{
    public class MainPanel
    {
        private Form _mainForm;
        private SplitContainer _first;
        private SplitContainer _second;

        public MainPanel(Form mainForm)
        {
            _mainForm = mainForm;
            _first = new SplitContainer();
            _second = new SplitContainer();

            Initialize();
        }

        public SplitContainer Component
        {
            get { return _first; }
        }

        public void SetLeft(Control c)
        {
            _first.Panel1.Controls.Clear();
            _first.Panel1.Controls.Add(c);
        }

        public void SetMiddle(Control c)
        {
            _second.Panel1.Controls.Clear();
            _second.Panel1.Controls.Add(c);
        }

        public void SetRight(Control c)
        {
            _second.Panel2.Controls.Clear();
            _second.Panel2.Controls.Add(c);
        }

        private void Initialize()
        {
            _first.Padding = new Padding(3);
            _second.Padding = new Padding(3);           
            
            _first.BorderStyle = BorderStyle.FixedSingle;
            _first.Location = new System.Drawing.Point(5, 25);
            _first.Dock = DockStyle.Fill;
            _first.Panel1MinSize = 125;
            _first.FixedPanel = FixedPanel.Panel1;

            _second.BorderStyle = BorderStyle.FixedSingle;
            _second.Dock = DockStyle.Fill;
            _second.Panel2MinSize = 125;
            _second.FixedPanel = FixedPanel.Panel2;

            _first.Panel2.Controls.Add(_second);
        }
    }
}
