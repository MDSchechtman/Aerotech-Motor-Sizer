﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Interfaces;
using Utility;

namespace Program
{
    public class ParameterInputScene
    {
        private MainForm _mainForm;
        private Dictionary<string, double> _dictionary;
        private TableLayoutPanel _panel;
        private ListView _view;
        private ComboBox _boxAccel;
        private ComboBox _box;
        private Label _boxTitle;

        private String _parameter1;
        private String _parameter2;
        private String _parameter3;

        private Label _label1;
        private Label _label2;
        private Label _label3;
        private Label _label4;

        private TextBox _textBox1;
        private TextBox _textBox2;
        private TextBox _textBox3;
        private TextBox _textBox4;

        public event EventHandler OnClose;

        public ParameterInputScene(MainForm mainForm)
        {
            _mainForm = mainForm;
            _dictionary = new Dictionary<string, double>();

            Initialize();
            DoSetup();
        }

        public TableLayoutPanel Component
        {
            get { return _panel; }
        }

        private void Initialize()
        {
            _view = new ListView();
            _view.Dock = DockStyle.Fill;

            _panel = new TableLayoutPanel();
            _panel.Dock = DockStyle.Fill;
            _panel.RowCount = 7;
            _panel.ColumnCount = 5;

            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.125F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F / 4F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F / 4F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F / 4F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F / 4F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.25F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.125F));

            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.125F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.25F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5F / 3F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5F / 3F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.5F / 3F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.125F));

            _boxAccel = new ComboBox();
            _boxAccel.Items.Add(string.Format("Constant"));
            _boxAccel.Items.Add(string.Format("Triangular"));
            _boxAccel.Items.Add(string.Format("Sinusoidal"));
            _boxAccel.Width = 200;
            _boxAccel.Dock = DockStyle.Right;
            _boxAccel.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            _boxTitle = new Label();
            _boxTitle.Text = "Acceleration Type";
            _boxTitle.Font = new Font("Tahoma", 10);
            _boxTitle.Size = new Size(_boxTitle.PreferredWidth, _boxTitle.PreferredHeight);
            _boxTitle.AutoSize = true;
            _boxTitle.TextAlign = ContentAlignment.BottomRight;
            _boxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _boxTitle.Margin = new Padding(0, 0, 0, 25);

            _label1 = new Label();
            _label2 = new Label();
            _label3 = new Label();
            _label4 = new Label();

            _label1.Enabled = false;
            _label2.Enabled = false;
            _label3.Enabled = false;
            _label4.Enabled = false;

            Padding p = new Padding(0, 5, 0, 0);
            _label1.Margin = p;
            _label2.Margin = p;
            _label3.Margin = p;
            _label4.Margin = p;

            _label1.TextAlign = ContentAlignment.TopRight;
            _label2.TextAlign = ContentAlignment.TopRight;
            _label3.TextAlign = ContentAlignment.TopRight;
            _label4.TextAlign = ContentAlignment.TopRight;

            _label1.Dock = DockStyle.Right;
            _label2.Dock = DockStyle.Right;
            _label3.Dock = DockStyle.Right;
            _label4.Dock = DockStyle.Right;

            _textBox1 = new TextBox();
            _textBox2 = new TextBox();
            _textBox3 = new TextBox();
            _textBox4 = new TextBox();

            _textBox1.Enabled = false;
            _textBox2.Enabled = false;
            _textBox3.Enabled = false;
            _textBox4.Enabled = false;


            _textBox1.Dock = DockStyle.Left;
            _textBox2.Dock = DockStyle.Left;
            _textBox3.Dock = DockStyle.Left;
            _textBox4.Dock = DockStyle.Left;

            _label1.Text = "Parameter 1";
            _label2.Text = "Parameter 2";
            _label3.Text = "Parameter 3";
            _label4.Text = "Time Step";

            Label boxTitle = new Label();
            boxTitle.Text = "Creating axis:";
            boxTitle.Font = new Font("Tahoma", 10);
            boxTitle.Size = new Size(boxTitle.PreferredWidth, boxTitle.PreferredHeight);
            boxTitle.AutoSize = true;
            boxTitle.TextAlign = ContentAlignment.BottomRight;
            boxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            boxTitle.Dock = DockStyle.Fill;
            boxTitle.Margin = new Padding(0, 0, 0, 25);

            _box = new ComboBox();
            _box.Items.Add(string.Format("Axis 1"));
            _box.Items.Add(string.Format("Axis 2"));
            _box.Items.Add(string.Format("Axis 3"));
            _box.Width = 200;
            _box.Dock = DockStyle.Right;
            _box.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            Label title = new Label();
            title.Text = "Select an item from the list on the left, input the values for each parameter, and click \"Create Axis\" to create that axis";
            title.Font = new Font("Tahoma", 10);
            title.Size = new Size(title.PreferredWidth, title.PreferredHeight);
            title.AutoSize = true;
            title.TextAlign = ContentAlignment.BottomCenter;
            title.Dock = DockStyle.Bottom;
            title.Anchor = AnchorStyles.Bottom;
            title.Margin = new Padding(0, 0, 0, 25);

            Button button = new Button();
            button.Text = "Create Axis";
            button.Click += new EventHandler(button_Click);
            button.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            Button finish = new Button();
            finish.Text = "Finish Creating Axes";
            finish.Click += new EventHandler(finish_Click);
            finish.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            _panel.Controls.Add(_view, 0, 1);
            _panel.SetColumnSpan(_view, 2);
            _panel.SetRowSpan(_view, 6);

            _panel.Controls.Add(_label1, 2, 2);
            _panel.Controls.Add(_label2, 2, 3);
            _panel.Controls.Add(_label3, 2, 4);
            _panel.Controls.Add(_label4, 2, 5);

            _panel.Controls.Add(_textBox1, 3, 2);
            _panel.Controls.Add(_textBox2, 3, 3);
            _panel.Controls.Add(_textBox3, 3, 4);
            _panel.Controls.Add(_textBox4, 3, 5);

            _panel.Controls.Add(boxTitle, 4, 2);
            _panel.Controls.Add(_box, 4, 3);

            _panel.Controls.Add(_boxTitle, 4, 4);
            _panel.Controls.Add(_boxAccel, 4, 5);

            _panel.Controls.Add(title, 2, 1);
            _panel.SetColumnSpan(title, 2);

            _panel.Controls.Add(button, 3, 6);
            _panel.Controls.Add(finish, 4, 6);
        }

        private void DoSetup()
        {
            _view.Columns.Add("Parameters");
            _view.Columns[0].Width = 300;
            _view.View = View.Details;
            _view.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            _view.Items.Add(new ListViewItem("Distance Of Travel, Total Time, Percentage", 0));
            _view.Items.Add(new ListViewItem("Distance Of Travel, Max Velocity, Percentage", 1));
            _view.Items.Add(new ListViewItem("Distance Of Travel, Max Velocity, Total Time", 2));
            _view.Items.Add(new ListViewItem("Distance Of Travel, Max Velocity, Peak Acceleration", 3));
            _view.Items.Add(new ListViewItem("Acceleration Distance, Max Velocity, Total Travel", 4));
            _view.Items.Add(new ListViewItem("Acceleration Distance, Max Velocity, Total Time", 5));
            _view.Items.Add(new ListViewItem("Acceleration Distance, Max Velocity, Max Travel", 6));
            _view.Items.Add(new ListViewItem("Peak Acceleration, Max Velocity, Total Time", 7));
            _view.Items.Add(new ListViewItem("Peak Acceleration, Max Velocity, Scan Distance", 8));
            _view.Items.Add(new ListViewItem("Total Travel, Max Velocity, Scan Distance", 9));
            _view.Items.Add(new ListViewItem("Total Time, Max Velocity, Scan Distance", 10));
            _view.Items.Add(new ListViewItem("Distance Of Travel, Acceleration Time, Traverse Time", 11));

            _view.Click += new EventHandler(_view_Click);
        }

        private void Enable()
        {
            _label1.Enabled = true;
            _label2.Enabled = true;
            _label3.Enabled = true;
            _label4.Enabled = true;

            _textBox1.Enabled = true;
            _textBox2.Enabled = true;
            _textBox3.Enabled = true;
            _textBox4.Enabled = true;
        }

        private void SetLabels(int index, string text)
        {

            string[] labels = text.Split(',');
            _label1.Text = labels[0].Trim();
            _label2.Text = labels[1].Trim();
            _label3.Text = labels[2].Trim();

            switch (index)
            {
                case 0: // distanceOfTravel totalTime percentage 
                    _parameter1 = string.Format("distanceOfTravel");
                    _parameter2 = string.Format("totalTime");
                    _parameter3 = string.Format("percentage");
                    break;
                case 1: // distanceOfTravel maxVelocity percentage 
                    _parameter1 = string.Format("distanceOfTravel");
                    _parameter2 = string.Format("maxVelocity");
                    _parameter3 = string.Format("percentage");
                    break;
                case 2: // distanceOfTravel maxVelocity totalTime 
                    _parameter1 = string.Format("distanceOfTravel");
                    _parameter2 = string.Format("maxVelocity");
                    _parameter3 = string.Format("totalTime");
                    break;
                case 3: // distanceOfTravel maxVelocity peakAcceleration 
                    _parameter1 = string.Format("distanceOfTravel");
                    _parameter2 = string.Format("maxVelocity");
                    _parameter3 = string.Format("peakAcceleration");
                    break;
                case 4: // accelDistance maxVelocity totalTravel 
                    _parameter1 = string.Format("accelDistance");
                    _parameter2 = string.Format("maxVelocity");
                    _parameter3 = string.Format("totalTravel");
                    break;
                case 5: // accelDistance maxVelocity totalTime 
                    _parameter1 = string.Format("accelDistance");
                    _parameter2 = string.Format("maxVelocity");
                    _parameter3 = string.Format("totalTime");
                    break;
                case 6: // acceleration maxVelocity maxTravel 
                    _parameter1 = string.Format("acceleration");
                    _parameter2 = string.Format("maxVelocity");
                    _parameter3 = string.Format("maxTravel");
                    break;
                case 7: // peakAcceleration maxVelocity totalTime 
                    _parameter1 = string.Format("peakAcceleration");
                    _parameter2 = string.Format("maxVelocity");
                    _parameter3 = string.Format("totalTime");
                    break;
                case 8: // peakAcceleration maxVelocity scanDistance 
                    _parameter1 = string.Format("peakAcceleration");
                    _parameter2 = string.Format("maxVelocity");
                    _parameter3 = string.Format("scanDistance");
                    break;
                case 9: // totalTravel maxVelocity scanDistance 
                    _parameter1 = string.Format("totalTravel");
                    _parameter2 = string.Format("maxVelocity");
                    _parameter3 = string.Format("scanDistance");
                    break;
                case 10: // totalTime maxVelocity scanDistance 
                    _parameter1 = string.Format("totalTime");
                    _parameter2 = string.Format("maxVelocity");
                    _parameter3 = string.Format("scanDistance");
                    break;
                case 11: // totalTime maxVelocity scanDistance 
                    _parameter1 = string.Format("distanceOfTravel");
                    _parameter2 = string.Format("accelerationTime");
                    _parameter3 = string.Format("traverseTime");
                    break;
            }
        }

        private void _view_Click(object sender, EventArgs e)
        {
            // Using ImageIndex for identity
            ListView view = sender as ListView;
            ListViewItem item = view.SelectedItems[0];

            SetLabels(item.ImageIndex, item.Text);
            Enable();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (_box.SelectedItem == null)
                MessageBox.Show("No axis selected!");
            else
            {
                double value1 = 0D;
                double value2 = 0D;
                double value3 = 0D;
                double value4 = 0D;

                try
                {
                    value1 = Double.Parse(_textBox1.Text);
                    value2 = Double.Parse(_textBox2.Text);
                    value3 = Double.Parse(_textBox3.Text);
                    value4 = Double.Parse(_textBox4.Text);
                }
                catch (System.FormatException exception)
                {
                    MessageBox.Show(string.Format("Error: {0} Please correct the value and try again.", exception.Message));
                    return;
                }

                _dictionary = new Dictionary<string, double>();
                _dictionary.Add(_parameter1, value1);
                _dictionary.Add(_parameter2, value2);
                _dictionary.Add(_parameter3, value3);
                _dictionary.Add("timeStep", value4);

                IConverter converter = new Utility.Converters.ParameterSetConverter(_dictionary, _boxAccel.Text);

                if (string.Compare(_box.SelectedItem.ToString(), "Axis 1") == 0)
                    _mainForm.Project.Axis1 = new Axis(converter);
                else if (string.Compare(_box.SelectedItem.ToString(), "Axis 2") == 0)
                    _mainForm.Project.Axis2 = new Axis(converter);
                else if (string.Compare(_box.SelectedItem.ToString(), "Axis 3") == 0)
                    _mainForm.Project.Axis3 = new Axis(converter);
            }
        }

        private void finish_Click(object sender, EventArgs e)
        {
            _mainForm.MainPanel.SetMiddle(_mainForm.Project.Profile.Component);
            _mainForm.MainPanel.SetRight(_mainForm.Project.ChooseMotor.Component);

            _mainForm.Project.Profile.Solve();

            if (this.OnClose != null)
                this.OnClose(this, EventArgs.Empty);

            _mainForm.MainPanel.SetMiddle(_mainForm.Project.Profile.Component);
        }
    }
}
