using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program
{
    public class ProfileList
    {
        private Form _mainForm;
        private ListView _list;

        public ProfileList(MainForm mainForm)
        {
            _mainForm = mainForm;
            _list = new ListView();

            Initialize();
        }

        public ListView Component
        {
            get { return _list; }
        }

        private void Initialize()
        {
            _list.Dock = DockStyle.Fill;
            _list.Size = new System.Drawing.Size(MainForm.initialSize.Width / 6, MainForm.initialSize.Height - 50);
            _list.Items.Add(new ListViewItem("TEST"));
        }
    }
}
