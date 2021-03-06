﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using NCalc;

using Interfaces;
using Utility;

namespace Program
{
    public class FunctionConverterScene
    {
        private TableLayoutPanel _panel;
        private TextBox _box1;
        private TextBox _box2;
        private TextBox _box3;
        private Label _message;
        private TextBox _box1step;
        private TextBox _box2step;
        private TextBox _box3step;
        private Label _messagestep;
        private TextBox _box1length;
        private TextBox _box2length;
        private TextBox _box3length;
        private Label _messagelength;
        private Button _ok;
        private ComboBox _box;
        private MainForm _mainForm;
        public event EventHandler OnClose;

        public FunctionConverterScene(MainForm mainForm)
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
            boxTitle.Text = "Select type of function:";
            boxTitle.Font = new Font("Tahoma", 10);
            boxTitle.Size = new Size(boxTitle.PreferredWidth, boxTitle.PreferredHeight);
            boxTitle.AutoSize = true;
            boxTitle.TextAlign = ContentAlignment.BottomRight;
            boxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            boxTitle.Margin = new Padding(0, 0, 0, 25);

            _box1 = new TextBox();
            _box1.Width = 200;
            _box1.Dock = DockStyle.Right;
            _box1.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            _box2 = new TextBox();
            _box2.Width = 200;
            _box2.Dock = DockStyle.Right;
            _box2.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            _box3 = new TextBox();
            _box3.Width = 200;
            _box3.Dock = DockStyle.Right;
            _box3.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            _box1step = new TextBox();
            _box1step.Width = 200;
            _box1step.Dock = DockStyle.Right;
            _box1step.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            _box2step = new TextBox();
            _box2step.Width = 200;
            _box2step.Dock = DockStyle.Right;
            _box2step.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            _box3step = new TextBox();
            _box3step.Width = 200;
            _box3step.Dock = DockStyle.Right;
            _box3step.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            _box1length = new TextBox();
            _box1length.Width = 200;
            _box1length.Dock = DockStyle.Right;
            _box1length.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            _box2length = new TextBox();
            _box2length.Width = 200;
            _box2length.Dock = DockStyle.Right;
            _box2length.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            _box3length = new TextBox();
            _box3length.Width = 200;
            _box3length.Dock = DockStyle.Right;
            _box3length.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            Label boxTitle1 = new Label();
            boxTitle1.Text = "Axis One:";
            boxTitle1.Font = new Font("Tahoma", 10);
            boxTitle1.Size = new Size(boxTitle1.PreferredWidth, boxTitle1.PreferredHeight);
            boxTitle1.AutoSize = true;
            boxTitle1.TextAlign = ContentAlignment.BottomRight;
            boxTitle1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            boxTitle1.Margin = new Padding(0, 0, 0, 25);

            Label boxTitle2 = new Label();
            boxTitle2.Text = "Axis Two:";
            boxTitle2.Font = new Font("Tahoma", 10);
            boxTitle2.Size = new Size(boxTitle2.PreferredWidth, boxTitle2.PreferredHeight);
            boxTitle2.AutoSize = true;
            boxTitle2.TextAlign = ContentAlignment.BottomRight;
            boxTitle2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            boxTitle2.Margin = new Padding(0, 0, 0, 25);

            Label boxTitle3 = new Label();
            boxTitle3.Text = "Axis Three:";
            boxTitle3.Font = new Font("Tahoma", 10);
            boxTitle3.Size = new Size(boxTitle3.PreferredWidth, boxTitle3.PreferredHeight);
            boxTitle3.AutoSize = true;
            boxTitle3.TextAlign = ContentAlignment.BottomRight;
            boxTitle3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            boxTitle3.Margin = new Padding(0, 0, 0, 25);

            _ok = new Button();
            _ok.Text = "OK";
            _ok.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _ok.Enabled = true;
            _ok.Click += new EventHandler(_ok_Click);

            _message = new Label();
            _message.Text = "                                                        Function";
            _message.Font = new Font("Tahoma", 10);
            _message.AutoSize = true;
            _message.TextAlign = ContentAlignment.BottomCenter;
            _message.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            _message.Margin = new Padding(0, 0, 0, 25);

            _messagestep = new Label();
            _messagestep.Text = "Time Step";
            _messagestep.Font = new Font("Tahoma", 10);
            _messagestep.AutoSize = true;
            _messagestep.TextAlign = ContentAlignment.BottomCenter;
            _messagestep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            _messagestep.Margin = new Padding(0, 0, 0, 25);

            _messagelength = new Label();
            _messagelength.Text = "Time Length";
            _messagelength.Font = new Font("Tahoma", 10);
            _messagelength.AutoSize = true;
            _messagelength.TextAlign = ContentAlignment.BottomCenter;
            _messagelength.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            _messagelength.Margin = new Padding(0, 0, 0, 25);

            _panel.Controls.Add(boxTitle, 1, 1);
            _panel.Controls.Add(_box, 2, 1);

            _panel.Controls.Add(boxTitle1, 0, 3);
            _panel.Controls.Add(_box1, 1, 3);
            _panel.Controls.Add(_box1step, 2, 3);
            _panel.Controls.Add(_box1length, 3, 3);
            _panel.SetColumnSpan(boxTitle1, 2);

            _panel.Controls.Add(boxTitle2, 0, 4);
            _panel.Controls.Add(_box2, 1, 4);
            _panel.Controls.Add(_box2step, 2, 4);
            _panel.Controls.Add(_box2length, 4, 4);
            _panel.SetColumnSpan(boxTitle2, 2);

            _panel.Controls.Add(boxTitle3, 0, 5);
            _panel.Controls.Add(_box3, 1, 5);
            _panel.Controls.Add(_box3step, 2, 5);
            _panel.Controls.Add(_box3length, 3, 5);
            _panel.SetColumnSpan(boxTitle3, 2);

            _panel.Controls.Add(_message, 1, 2);
            _panel.Controls.Add(_messagestep, 2, 2);
            _panel.Controls.Add(_messagelength, 3, 2);
            _panel.Controls.Add(_ok, 2, 6);
            _panel.SetColumnSpan(_message, 2);

        }

        private void _ok_Click(object sender, EventArgs e)
        {
            int type = 0;
            int skip = 0;

            if (_box.SelectedItem == null)
            {
                MessageBox.Show("Please select a Function Type");
                return;
            }

            if (string.Compare(_box.SelectedItem.ToString(), "Position vs. Time") == 0)
                type = 0;
            else if (string.Compare(_box.SelectedItem.ToString(), "Velocity vs. Time") == 0)
                type = 1;
            else if (string.Compare(_box.SelectedItem.ToString(), "Acceleration vs. Time") == 0)
                type = 2;
            else
            {
                MessageBox.Show("Please Select a Function Type");
                skip = 1;
            }

            Expression ex = new Expression(_box1.Text.Replace("x", "1"));
            try
            {
                ex.Evaluate();

                double timeStep;
                double totalTime;

                if (Double.TryParse(_box1step.Text, out timeStep))
                {
                    if (Double.TryParse(_box1length.Text, out totalTime))
                    {
                        IConverter converter = new Utility.Converters.FunctionConverter(_box1.Text.ToString(), totalTime, timeStep, type);
                        _mainForm.Project.Axis1 = new Axis(converter);

                        _mainForm.MainPanel.SetMiddle(_mainForm.Project.Profile.Component);
                        _mainForm.MainPanel.SetRight(_mainForm.Project.ChooseMotor.Component);

                        _mainForm.Project.Profile.Solve();

                        if (this.OnClose != null)
                            this.OnClose(this, EventArgs.Empty);

                        _mainForm.MainPanel.SetMiddle(_mainForm.Project.Profile.Component);
                    }
                    else
                    {
                        MessageBox.Show("Invalid time length");
                        skip = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid time step");
                    skip = 1;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Error caught: " + a.Message);
                Console.WriteLine("Error caught: " + a.Message);
                skip = 1;
            }
            if (skip != 1 && !_box2.Text.Equals(""))
            {
                Expression ex2 = new Expression(_box2.Text.Replace("x", "1"));
                try
                {
                    ex2.Evaluate();

                    double timeStep;
                    double totalTime;

                    if (Double.TryParse(_box2step.Text, out timeStep))
                    {
                        if (Double.TryParse(_box2length.Text, out totalTime))
                        {
                            IConverter converter = new Utility.Converters.FunctionConverter(_box2.Text.ToString(), totalTime, timeStep, type);
                            _mainForm.Project.Axis2 = new Axis(converter);

                            _mainForm.MainPanel.SetMiddle(_mainForm.Project.Profile.Component);
                            _mainForm.MainPanel.SetRight(_mainForm.Project.ChooseMotor.Component);

                            _mainForm.Project.Profile.Solve();

                            if (this.OnClose != null)
                                this.OnClose(this, EventArgs.Empty);

                            _mainForm.MainPanel.SetMiddle(_mainForm.Project.Profile.Component);
                        }
                        else
                        {
                            MessageBox.Show("Invalid time length");
                            skip = 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid time step");
                        skip = 1;
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show("Error caught: " + a.Message);
                    Console.WriteLine("Error caught: " + a.Message);
                    skip = 1;
                }
            }

            if (skip != 1 && !_box3.Text.Equals(""))
            {
                Expression ex3 = new Expression(_box3.Text.Replace("x", "1"));
                try
                {
                    ex3.Evaluate();

                    double timeStep;
                    double totalTime;

                    if (Double.TryParse(_box3step.Text, out timeStep))
                    {
                        if (Double.TryParse(_box3length.Text, out totalTime))
                        {
                            IConverter converter = new Utility.Converters.FunctionConverter(_box3.Text.ToString(), totalTime, timeStep, type);
                            _mainForm.Project.Axis3 = new Axis(converter);

                            _mainForm.MainPanel.SetMiddle(_mainForm.Project.Profile.Component);
                            _mainForm.MainPanel.SetRight(_mainForm.Project.ChooseMotor.Component);

                            _mainForm.Project.Profile.Solve();

                            if (this.OnClose != null)
                                this.OnClose(this, EventArgs.Empty);

                            _mainForm.MainPanel.SetMiddle(_mainForm.Project.Profile.Component);
                        }
                        else
                            MessageBox.Show("Invalid time length");
                    }
                    else
                        MessageBox.Show("Invalid time step");
                }
                catch (Exception a)
                {
                    MessageBox.Show("Error caught: " + a.Message);
                    Console.WriteLine("Error caught: " + a.Message);
                }
            }
        }
    }
}
