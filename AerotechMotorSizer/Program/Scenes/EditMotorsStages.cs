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
    public class EditMotorsStages
    {
        private MainForm _mainForm;
        private Dictionary<string, double> _dictionary;
        private TableLayoutPanel _panel;
        private ListView _view;

        private int isupdate = 0;

        private String _parameter1;
        private String _parameter2;
        private String _parameter3;

        private Label _label1;
        private Label _label2;
        private Label _label3;
        private Label _label4;
        private Label _label5;
        private Label _label6;
        private Label _label7;
        private Label _label8;
        private Label _label9;
        private Label _label10;
        private Label _label11;
        private Label _label12;
        private Label _label13;

        private Label _label1units;
        private Label _label2units;
        private Label _label3units;
        private Label _label4units;
        private Label _label5units;
        private Label _label6units;
        private Label _label7units;
        private Label _label8units;
        private Label _label9units;
        private Label _label10units;
        private Label _label11units;
        private Label _label12units;
        private Label _label13units;


        private TextBox _textBox1;
        private TextBox _textBox2;
        private TextBox _textBox3;
        private TextBox _textBox4;
        private TextBox _textBox5;
        private TextBox _textBox6;
        private TextBox _textBox7;
        private TextBox _textBox8;
        private TextBox _textBox9;
        private TextBox _textBox10;
        private TextBox _textBox11;
        private TextBox _textBox12;
        private TextBox _textBox13;

        private Database db;
        private String CurrentMotor;
        public event EventHandler OnClose;

        public EditMotorsStages(MainForm mainForm)
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
            _panel.RowCount = 20;
            _panel.ColumnCount = 5;

            _panel.MaximumSize = new System.Drawing.Size(1000, 1000);

            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 0.05F));


            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.125F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.25F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.25F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.125F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.25F));

            _label1 = new Label();
            _label2 = new Label();
            _label3 = new Label();
            _label4 = new Label();
            _label5 = new Label();
            _label6 = new Label();
            _label7 = new Label();
            _label8 = new Label();
            _label9 = new Label();
            _label10 = new Label();
            _label11 = new Label();
            _label12 = new Label();
            _label13 = new Label();

            _label1units = new Label();
            _label2units = new Label();
            _label3units = new Label();
            _label4units = new Label();
            _label5units = new Label();
            _label6units = new Label();
            _label7units = new Label();
            _label8units = new Label();
            _label9units = new Label();
            _label10units = new Label();
            _label11units = new Label();
            _label12units = new Label();
            _label13units = new Label();



            Padding p = new Padding(0, 5, 0, 0);
            _label1.Margin = p;
            _label2.Margin = p;
            _label3.Margin = p;
            _label4.Margin = p;
            _label5.Margin = p;
            _label6.Margin = p;
            _label7.Margin = p;
            _label8.Margin = p;
            _label9.Margin = p;
            _label10.Margin = p;
            _label11.Margin = p;
            _label12.Margin = p;
            _label13.Margin = p;


            _label1.TextAlign = ContentAlignment.TopRight;
            _label2.TextAlign = ContentAlignment.TopRight;
            _label3.TextAlign = ContentAlignment.TopRight;
            _label4.TextAlign = ContentAlignment.TopRight;
            _label5.TextAlign = ContentAlignment.TopRight;
            _label6.TextAlign = ContentAlignment.TopRight;
            _label7.TextAlign = ContentAlignment.TopRight;
            _label8.TextAlign = ContentAlignment.TopRight;
            _label9.TextAlign = ContentAlignment.TopRight;
            _label10.TextAlign = ContentAlignment.TopRight;
            _label11.TextAlign = ContentAlignment.TopRight;
            _label12.TextAlign = ContentAlignment.TopRight;
            _label13.TextAlign = ContentAlignment.TopRight;

            _label1units.TextAlign = ContentAlignment.TopLeft;
            _label2units.TextAlign = ContentAlignment.TopLeft;
            _label3units.TextAlign = ContentAlignment.TopLeft;
            _label4units.TextAlign = ContentAlignment.TopLeft;
            _label5units.TextAlign = ContentAlignment.TopLeft;
            _label6units.TextAlign = ContentAlignment.TopLeft;
            _label7units.TextAlign = ContentAlignment.TopLeft;
            _label8units.TextAlign = ContentAlignment.TopLeft;
            _label9units.TextAlign = ContentAlignment.TopLeft;
            _label10units.TextAlign = ContentAlignment.TopLeft;
            _label11units.TextAlign = ContentAlignment.TopLeft;
            _label12units.TextAlign = ContentAlignment.TopLeft;
            _label13units.TextAlign = ContentAlignment.TopLeft;


            _label1.Dock = DockStyle.Right;
            _label2.Dock = DockStyle.Right;
            _label3.Dock = DockStyle.Right;
            _label4.Dock = DockStyle.Right;
            _label5.Dock = DockStyle.Right;
            _label6.Dock = DockStyle.Right;
            _label7.Dock = DockStyle.Right;
            _label8.Dock = DockStyle.Right;
            _label9.Dock = DockStyle.Right;
            _label10.Dock = DockStyle.Right;
            _label11.Dock = DockStyle.Right;
            _label12.Dock = DockStyle.Right;
            _label13.Dock = DockStyle.Right;


            _textBox1 = new TextBox();
            _textBox2 = new TextBox();
            _textBox3 = new TextBox();
            _textBox4 = new TextBox();
            _textBox5 = new TextBox();
            _textBox6 = new TextBox();
            _textBox7 = new TextBox();
            _textBox8 = new TextBox();
            _textBox9 = new TextBox();
            _textBox10 = new TextBox();
            _textBox11 = new TextBox();
            _textBox12 = new TextBox();
            _textBox13 = new TextBox();



            _textBox1.Dock = DockStyle.Left;
            _textBox2.Dock = DockStyle.Left;
            _textBox3.Dock = DockStyle.Left;
            _textBox4.Dock = DockStyle.Left;
            _textBox5.Dock = DockStyle.Left;
            _textBox6.Dock = DockStyle.Left;
            _textBox7.Dock = DockStyle.Left;
            _textBox8.Dock = DockStyle.Left;
            _textBox9.Dock = DockStyle.Left;
            _textBox10.Dock = DockStyle.Left;
            _textBox11.Dock = DockStyle.Left;
            _textBox12.Dock = DockStyle.Left;
            _textBox13.Dock = DockStyle.Left;

            _label1.Text = "Name";
            _label2.Text = "Peak Force";
            _label3.Text = "Continuous Force No cooling";
            _label4.Text = "Continuous Force 0psi";
            _label5.Text = "Continuous Force 10psi";
            _label6.Text = "Continuous Force 20psi";
            _label7.Text = "Continuous Force 40psi";
            _label8.Text = "Force Constant";
            _label9.Text = "Motor Constant";
            _label10.Text = "Back EMF";
            _label11.Text = "Coil Resistance";
            _label12.Text = "Coil Mass";
            _label13.Text = "Coil Length";

            _label1units.Text = "";
            _label2units.Text = "N";
            _label3units.Text = "";
            _label4units.Text = "N";
            _label5units.Text = "N";
            _label6units.Text = "N";
            _label7units.Text = "N";
            _label8units.Text = "N/A(peak)";
            _label9units.Text = "N/√W";
            _label10units.Text = "V/(m/s)";
            _label11units.Text = "Ω";
            _label12units.Text = "kg";
            _label13units.Text = "mm";

            Label title = new Label();
            title.Text = "Select an item from the list on the left, input the values for each parameter, and click OK to proceed.";
            title.Font = new Font("Tahoma", 10);
            title.Size = new Size(title.PreferredWidth, title.PreferredHeight);
            title.AutoSize = true;
            title.TextAlign = ContentAlignment.BottomCenter;
            title.Dock = DockStyle.Bottom;
            title.Anchor = AnchorStyles.Bottom;
            title.Margin = new Padding(0, 0, 0, 25);

            Button button = new Button();
            button.Text = "Edit";
            button.Click += new EventHandler(button_Click);
            button.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            Button button2 = new Button();
            button2.Text = "Delete";
            button2.Click += new EventHandler(button2_Click);
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            _panel.Controls.Add(_view, 1, 3);
            _panel.SetRowSpan(_view, 18);

            _panel.Controls.Add(_label1, 2, 3);
            _panel.Controls.Add(_label2, 2, 4);
            _panel.Controls.Add(_label4, 2, 5);
            _panel.Controls.Add(_label5, 2, 6);
            _panel.Controls.Add(_label6, 2, 7);
            _panel.Controls.Add(_label7, 2, 8);
            _panel.Controls.Add(_label8, 2, 9);
            _panel.Controls.Add(_label9, 2, 10);
            _panel.Controls.Add(_label10, 2, 11);
            _panel.Controls.Add(_label11, 2, 12);
            _panel.Controls.Add(_label12, 2, 13);
            _panel.Controls.Add(_label13, 2, 14);

            _panel.Controls.Add(_label1units, 4, 3);
            _panel.Controls.Add(_label2units, 4, 4);
            _panel.Controls.Add(_label4units, 4, 5);
            _panel.Controls.Add(_label5units, 4, 6);
            _panel.Controls.Add(_label6units, 4, 7);
            _panel.Controls.Add(_label7units, 4, 8);
            _panel.Controls.Add(_label8units, 4, 9);
            _panel.Controls.Add(_label9units, 4, 10);
            _panel.Controls.Add(_label10units, 4, 11);
            _panel.Controls.Add(_label11units, 4, 12);
            _panel.Controls.Add(_label12units, 4, 13);
            _panel.Controls.Add(_label13units, 4, 14);

            _panel.Controls.Add(_textBox1, 3, 3);
            _panel.Controls.Add(_textBox2, 3, 4);
            _panel.Controls.Add(_textBox4, 3, 5);
            _panel.Controls.Add(_textBox5, 3, 6);
            _panel.Controls.Add(_textBox6, 3, 7);
            _panel.Controls.Add(_textBox7, 3, 8);
            _panel.Controls.Add(_textBox8, 3, 9);
            _panel.Controls.Add(_textBox9, 3, 10);
            _panel.Controls.Add(_textBox10, 3, 11);
            _panel.Controls.Add(_textBox11, 3, 12);
            _panel.Controls.Add(_textBox12, 3, 13);
            _panel.Controls.Add(_textBox13, 3, 14);

            _panel.Controls.Add(title, 1, 1);
            _panel.SetColumnSpan(title, 2);
            _panel.SetRowSpan(title, 2);
            _panel.Controls.Add(button, 3, 16);
            _panel.Controls.Add(button2, 4, 16);
        }

        private void DoSetup()
        {
            Database tempdb = new Database();

            _view.Columns.Add("Motors");
            _view.Columns[0].Width = 300;
            _view.View = View.Details;
            _view.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            for (int i = 0; i < tempdb.motors.Count; i++) // Loop through List with for
            {
                _view.Items.Add(new ListViewItem(tempdb.motors[i].Name, i));
                if ((tempdb.motors.Count - i) == 1)
                {
                    _view.Items.Add(new ListViewItem("Add New", i + 1));
                }
            }


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
            if (text == "Add New")
            {
                _textBox1.Text = "New Motor";
                _textBox2.Text = System.Convert.ToString(0.0);
                _textBox3.Text = System.Convert.ToString(0.0);
                _textBox4.Text = System.Convert.ToString(0.0);
                _textBox5.Text = System.Convert.ToString(0.0);
                _textBox6.Text = System.Convert.ToString(0.0);
                _textBox7.Text = System.Convert.ToString(0.0);
                _textBox8.Text = System.Convert.ToString(0.0);
                _textBox9.Text = System.Convert.ToString(0.0);
                _textBox10.Text = System.Convert.ToString(0.0);
                _textBox11.Text = System.Convert.ToString(0.0);
                _textBox12.Text = System.Convert.ToString(0.0);
                _textBox13.Text = System.Convert.ToString(0.0);
                db = new Database();
                isupdate = 0;
            }
            else
            {
                isupdate = 1;
                db = new Database();
                CurrentMotor = text;
                for (int i = 0; i < db.motors.Count; i++) // Loop through List with for
                {
                    if (db.motors[i].Name == text)
                    {
                        _textBox1.Text = db.motors[i].Name;
                        _textBox2.Text = System.Convert.ToString(db.motors[i].PeakForce);
                        _textBox3.Text = System.Convert.ToString(db.motors[i].ContinuousForce_0psi);
                        _textBox4.Text = System.Convert.ToString(db.motors[i].ContinuousForce_0psi);
                        _textBox5.Text = System.Convert.ToString(db.motors[i].ContinuousForce_10psi);
                        _textBox6.Text = System.Convert.ToString(db.motors[i].ContinuousForce_20psi);
                        _textBox7.Text = System.Convert.ToString(db.motors[i].ContinuousForce_40psi);
                        _textBox8.Text = System.Convert.ToString(db.motors[i].ForceConstant);
                        _textBox9.Text = System.Convert.ToString(db.motors[i].MotorConstant);
                        _textBox10.Text = System.Convert.ToString(db.motors[i].BackEMFConstant);
                        _textBox11.Text = System.Convert.ToString(db.motors[i].Resistance);
                        _textBox12.Text = System.Convert.ToString(db.motors[i].CoilMass);
                        _textBox13.Text = System.Convert.ToString(db.motors[i].CoilLength);
                    }
                }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine(CurrentMotor);
            db.Delete(CurrentMotor);
            for (int i = 0; i < _view.Items.Count; i++)
            {
                if (_view.Items[i].Selected)
                {
                    _view.Items[i].Remove();
                    i--;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (isupdate == 0)
            {
                db.Add(_textBox1.Text, System.Convert.ToDouble(_textBox2.Text), System.Convert.ToDouble(_textBox4.Text), System.Convert.ToDouble(_textBox5.Text), System.Convert.ToDouble(_textBox6.Text), System.Convert.ToDouble(_textBox7.Text), System.Convert.ToDouble(_textBox8.Text), System.Convert.ToDouble(_textBox9.Text), System.Convert.ToDouble(_textBox10.Text), System.Convert.ToDouble(_textBox11.Text), System.Convert.ToDouble(_textBox12.Text), System.Convert.ToDouble(_textBox13.Text));
                _view.Items.Add(new ListViewItem("Add New"));
            }
            else if (isupdate == 1)
                db.Update(CurrentMotor, _textBox1.Text, System.Convert.ToDouble(_textBox2.Text), System.Convert.ToDouble(_textBox4.Text), System.Convert.ToDouble(_textBox5.Text), System.Convert.ToDouble(_textBox6.Text), System.Convert.ToDouble(_textBox7.Text), System.Convert.ToDouble(_textBox8.Text), System.Convert.ToDouble(_textBox9.Text), System.Convert.ToDouble(_textBox10.Text), System.Convert.ToDouble(_textBox11.Text), System.Convert.ToDouble(_textBox12.Text), System.Convert.ToDouble(_textBox13.Text));

            ListView.SelectedIndexCollection indexes = _view.SelectedIndices;
            CurrentMotor = _textBox1.Text;
            int theIndex = 0;
            foreach (int index in indexes)
            {
                theIndex = index;
                break;
            }
            _view.Items[theIndex].Text = _textBox1.Text;
            isupdate = 1;
        }
    }
}
