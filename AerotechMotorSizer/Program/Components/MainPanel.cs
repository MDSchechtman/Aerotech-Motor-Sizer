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
        private TableLayoutPanel _panel;

        public MainPanel(Form mainForm)
        {
            _mainForm = mainForm;
            _panel = new TableLayoutPanel();

            Initialize();
        }

        public TableLayoutPanel Component
        {
            get { return _panel; }
        }

        public void Add(Control c, int row, int col)
        {
            _panel.Controls.Add(c, col, row);
        }

        private void Initialize()
        {
            _panel.Padding = new Padding(3);
            _panel.RowCount = 1;
            _panel.ColumnCount = 3;
            _panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            _panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            for (int i = 0; i < _panel.ColumnCount; i++)
            {
                ColumnStyle style = new ColumnStyle(SizeType.Percent);
                if (i == 0)
                    style.Width = 0.10F;
                else if (i == 1)
                    style.Width = 0.70F;
                else
                    style.Width = 0.20F;

                _panel.ColumnStyles.Add(style);
            }
            
            
            _panel.BorderStyle = BorderStyle.FixedSingle;
            _panel.Location = new System.Drawing.Point(5, 25);
            _panel.Dock = DockStyle.Fill;
        }
    }
}
