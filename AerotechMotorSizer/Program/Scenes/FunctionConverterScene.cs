using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program
{
    public class FunctionConverterScene
    {
        private TableLayoutPanel _panel;
        private MainForm _mainForm;

        public event EventHandler OnClose;

        public FunctionConverterScene(MainForm mainForm)
        {
            _mainForm = mainForm;
            _panel = new TableLayoutPanel();
        }

        public TableLayoutPanel Component
        {
            get { return _panel; }
        }

        private void Initialize()
        {
        }

        private void DoSetup()
        {
        }
    }
}
