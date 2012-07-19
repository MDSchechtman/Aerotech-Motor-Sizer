using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Interfaces;

namespace Program
{
    public class NewProjectScene
    {
        private TableLayoutPanel _panel;
        private MainPanel _mainPanel;
        private MainForm _mainForm;

        public NewProjectScene(MainForm mainForm)
        {
            _mainForm = mainForm;
            _panel = new TableLayoutPanel();

            _mainForm.Project = new Project();

            Initialize();
            DoSetup();
        }

        public TableLayoutPanel Component
        {
            get { return _panel; }
        }

        private void Initialize()
        {
            _panel.Padding = new Padding(3);
            _panel.RowCount = 6;
            _panel.ColumnCount = 4;

            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.30F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.10F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.10F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.10F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.10F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.30F));

            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.15F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.35F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.35F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.15F));
            
            _panel.BorderStyle = BorderStyle.FixedSingle;
            _panel.Location = new Point(5, 25);
            _panel.Dock = DockStyle.Fill;

            _panel.BackColor = Color.LightSteelBlue;
        }

        private void DoSetup()
        {
            Label title = new Label();
            title.Text = "Click on a method of input:";
            title.Font = new Font("Tahoma", 24);
            title.Size = new Size(title.PreferredWidth, title.PreferredHeight);
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Dock = DockStyle.Top;
            title.Anchor = AnchorStyles.None;

            Label line1 = new Label();
            line1.Text = "Parameters";
            line1.Font = new Font("Tahoma", 16, FontStyle.Underline);
            line1.Size = new Size(line1.PreferredWidth, line1.PreferredHeight);
            line1.TextAlign = ContentAlignment.MiddleRight;
            line1.Dock = DockStyle.Right;
            line1.Anchor = AnchorStyles.None;

            Label line2 = new Label();
            line2.Text = "CSV File";
            line2.Font = new Font("Tahoma", 16, FontStyle.Underline);
            line2.Size = new Size(line2.PreferredWidth, line2.PreferredHeight);
            line2.TextAlign = ContentAlignment.MiddleRight;
            line2.Dock = DockStyle.Right;
            line2.Anchor = AnchorStyles.None;

            Label line3 = new Label();
            line3.Text = "Function";
            line3.Font = new Font("Tahoma", 16, FontStyle.Underline);
            line3.Size = new Size(line3.PreferredWidth, line3.PreferredHeight);
            line3.TextAlign = ContentAlignment.MiddleRight;
            line3.Dock = DockStyle.Right;
            line3.Anchor = AnchorStyles.None;

            Label text1 = new Label();
            text1.AutoSize = true;
            text1.Text = "Input parameters to define the load trajectory.";
            text1.Font = new Font("Tahoma", 12);
            text1.Size = new Size(text1.PreferredWidth, text1.PreferredHeight);
            text1.TextAlign = ContentAlignment.MiddleRight;
            text1.Dock = DockStyle.Right;
            text1.Anchor = AnchorStyles.Right;

            Label text2 = new Label();
            text2.AutoSize = true;
            text2.Text = "Select a CSV file containing a load trajectory.";
            text2.Font = new Font("Tahoma", 12);
            text2.Size = new Size(text2.PreferredWidth, text2.PreferredHeight);
            text2.TextAlign = ContentAlignment.MiddleRight;
            text2.Dock = DockStyle.Right;
            text2.Anchor = AnchorStyles.Right;

            Label text3 = new Label();
            text3.AutoSize = true;
            text3.Text = "Input a function defining a load trajectory.";
            text3.Font = new Font("Tahoma", 12);
            text3.Size = new Size(text3.PreferredWidth, text3.PreferredHeight);
            text3.TextAlign = ContentAlignment.MiddleRight;
            text3.Dock = DockStyle.Right;
            text3.Anchor = AnchorStyles.Right;

            line1.MouseEnter += new EventHandler(line1_MouseEnter);
            line1.MouseLeave += new EventHandler(line1_MouseLeave);
            line1.Click += new EventHandler(line1_Click);

            line2.MouseEnter += new EventHandler(line2_MouseEnter);
            line2.MouseLeave += new EventHandler(line2_MouseLeave);
            line2.Click += new EventHandler(line2_Click);

            line3.MouseEnter += new EventHandler(line3_MouseEnter);
            line3.MouseLeave += new EventHandler(line3_MouseLeave);
            line3.Click += new EventHandler(line3_Click);

            _panel.Controls.Add(title, 1, 1);
            _panel.SetColumnSpan(title, 2);

            _panel.Controls.Add(line1, 1, 2);
            _panel.Controls.Add(line2, 1, 3);
            _panel.Controls.Add(line3, 1, 4);

            _panel.Controls.Add(text1, 2, 2);
            _panel.Controls.Add(text2, 2, 3);
            _panel.Controls.Add(text3, 2, 4);



        }

        void line1_Click(object sender, EventArgs e)
        {
            ParameterInputScene scene = new ParameterInputScene(_mainForm);
            _mainForm.MainPanel.SetMiddle(scene.Component);
        }

        void line1_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Black;
        }

        void line1_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Blue;
        }

        void line2_Click(object sender, EventArgs e)
        {
            FileConverterScene scene = new FileConverterScene(_mainForm);
            _mainForm.MainPanel.SetMiddle(scene.Component);
        }

        void line2_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Black;
        }

        void line2_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Blue;
        }

        void line3_Click(object sender, EventArgs e)
        {
            FunctionConverterScene scene = new FunctionConverterScene(_mainForm);
            _mainForm.MainPanel.SetMiddle(scene.Component);
        }

        void line3_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Black;
        }

        void line3_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Blue;
        }
    }
}
