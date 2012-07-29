using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Program
{
    public class OutputScene
    {
        private TableLayoutPanel _panel;
        private MainForm _mainForm;
        private TextBox _warnings;
        private Project _project;

        public OutputScene(MainForm mainForm)
        {
            _mainForm = mainForm;
            _panel = new TableLayoutPanel();
            _project = mainForm.Project;

            Initialize();
        }

        public TableLayoutPanel Component
        {
            get { return _panel; }
        }

        public string Warnings
        {
            get { return _warnings.Text; }
            set { _warnings.Text = value; }
        }

        private void Initialize()
        {
            _panel.Dock = DockStyle.Fill;
            _panel.RowCount = 1;
            _panel.ColumnCount = 1;
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0F));

            _warnings = new TextBox();
            _warnings.Text = "";
            _warnings.Dock = DockStyle.Fill;
            _warnings.ReadOnly = true;
            _warnings.Font = new Font("Tahoma", 10, FontStyle.Bold);
            _warnings.TextAlign = HorizontalAlignment.Left;
            _warnings.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            _warnings.Margin = new Padding(0, 0, 0, 0);
            _warnings.ForeColor = Color.Red;
            _warnings.WordWrap = true;
            _warnings.Size = new Size(10000, 10000);
            _warnings.Multiline = true;
            _warnings.BackColor = _warnings.BackColor;

            _panel.Controls.Add(_warnings, 0, 0);
        }

        private void DoSetup()
        {
        }
    }
}
