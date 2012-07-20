using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Interfaces;
using Utility;

namespace Program
{
    public class FileConverterScene
    {
        private TableLayoutPanel _panel;
        private ComboBox _box;
        private Label _message;
        private Button _ok;
        private string _fileName;
        private MainForm _mainForm;

        public event EventHandler OnClose;

        public FileConverterScene(MainForm mainForm)
        {
            _mainForm = mainForm;
            _panel = new TableLayoutPanel();

            Initialize();
        }

        public TableLayoutPanel Component
        {
            get { return _panel; }
        }

        private void Initialize()
        {
            _panel = new TableLayoutPanel();
            _panel.Dock = DockStyle.Fill;
            _panel.RowCount = 7;
            _panel.ColumnCount = 6;

            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.125F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F / 3F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F / 3F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F / 3F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.125F));

            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.125F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.1875F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.1875F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.1875F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.1875F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.125F));

            _box = new ComboBox();
            _box.Items.Add(string.Format("Position vs. Time"));
            _box.Items.Add(string.Format("Velocity vs. Time"));
            _box.Items.Add(string.Format("Acceleration vs. Time"));
            _box.Width = 200;
            _box.Dock = DockStyle.Right;
            _box.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            Label boxTitle = new Label();
            boxTitle.Text = "Select type of data in the file:";
            boxTitle.Font = new Font("Tahoma", 10);
            boxTitle.Size = new Size(boxTitle.PreferredWidth, boxTitle.PreferredHeight);
            boxTitle.AutoSize = true;
            boxTitle.TextAlign = ContentAlignment.BottomRight;
            boxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            boxTitle.Margin = new Padding(0, 0, 0, 25);

            Button button = new Button();
            button.Text = "Open..";
            button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button.Click += new EventHandler(button_Click);

            Label buttonTitle = new Label();
            buttonTitle.Text = "Select a file:";
            buttonTitle.Font = new Font("Tahoma", 10);
            buttonTitle.Size = new Size(buttonTitle.PreferredWidth, buttonTitle.PreferredHeight);
            buttonTitle.AutoSize = true;
            buttonTitle.TextAlign = ContentAlignment.BottomRight;
            buttonTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonTitle.Margin = new Padding(0, 0, 0, 25);

            _ok = new Button();
            _ok.Text = "OK";
            _ok.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _ok.Enabled = false;
            _ok.Click += new EventHandler(_ok_Click);

            _message = new Label();
            _message.Text = "No file selected";
            _message.Font = new Font("Tahoma", 10);
            _message.AutoSize = true;
            _message.TextAlign = ContentAlignment.BottomRight;
            _message.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _message.Margin = new Padding(0, 0, 0, 25);

            _panel.Controls.Add(boxTitle, 1, 2);
            _panel.Controls.Add(_box, 2, 2);

            _panel.Controls.Add(buttonTitle, 1, 3);
            _panel.Controls.Add(button, 2, 3);

            _panel.Controls.Add(_message, 3, 2);
            _panel.Controls.Add(_ok, 4, 3);
            _panel.SetColumnSpan(_message, 2);

        }

        private void button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _fileName = dialog.FileName;

                _message.Text = string.Format("You have selected the file:\n{0}", _fileName);
                _message.Size = new Size(_message.PreferredWidth, _message.PreferredHeight);

                _ok.Enabled = true;
            }
        }

        private void _ok_Click(object sender, EventArgs e)
        {
            if (_fileName == null)
                MessageBox.Show("No file selected!");
            else if (_box.SelectedItem == null)
                MessageBox.Show("No data type selected!");
            else
            {
                int type = 0;
                if (string.Compare(_box.SelectedItem.ToString(), "Position vs. Time") == 0)
                    type = 0;
                else if (string.Compare(_box.SelectedItem.ToString(), "Velocity vs. Time") == 0)
                    type = 1;
                else if (string.Compare(_box.SelectedItem.ToString(), "Acceleration vs. Time") == 0)
                    type = 2;

                _mainForm.Project.Converter = new Utility.Converters.FileConverter(_fileName, type);

                if (this.OnClose != null)
                    this.OnClose(this, EventArgs.Empty);
            }
        }
    }
}
