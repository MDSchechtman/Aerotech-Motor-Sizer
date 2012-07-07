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
        private TreeView _tree;

        public ProfileList(MainForm mainForm)
        {
            _mainForm = mainForm;
            _tree = new TreeView();

            Initialize();
        }

        public TreeView Component
        {
            get { return _tree; }
        }

        private void Initialize()
        {
            _tree.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _tree.Dock = DockStyle.Fill;
        }
    }
}
