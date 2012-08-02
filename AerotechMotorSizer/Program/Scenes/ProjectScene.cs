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
    public class ProjectScene
    {
        private MainForm _mainForm;
        private TableLayoutPanel _panel;


        private Label _label1;
        private Label _label2;
        private Label _label3;
        private Label _label4;
        private Label _label5;



        private TextBox _textBox1;
        private TextBox _textBox2;
        private TextBox _textBox3;
        private TextBox _textBox4;
        private TextBox _textBox5;
        private DataGridView dataGridView;


        public event EventHandler OnClose;

        public ProjectScene(MainForm mainForm)
        {
            _mainForm = mainForm;

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
            _panel.RowCount = 10;
            _panel.ColumnCount = 5;

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
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.25F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.125F));

            _label1 = new Label();
            _label2 = new Label();
            _label3 = new Label();
            _label4 = new Label();
            _label5 = new Label();



            Padding p = new Padding(0, 5, 0, 0);
            _label1.Margin = p;
            _label2.Margin = p;
            _label3.Margin = p;
            _label4.Margin = p;
            _label5.Margin = p;


            _label1.TextAlign = ContentAlignment.TopRight;
            _label2.TextAlign = ContentAlignment.TopRight;
            _label3.TextAlign = ContentAlignment.TopRight;
            _label4.TextAlign = ContentAlignment.TopRight;
            _label5.TextAlign = ContentAlignment.TopRight;


            _label1.Dock = DockStyle.Right;
            _label2.Dock = DockStyle.Right;
            _label3.Dock = DockStyle.Right;
            _label4.Dock = DockStyle.Right;
            _label5.Dock = DockStyle.Right;


            _textBox1 = new TextBox();
            _textBox2 = new TextBox();
            _textBox3 = new TextBox();
            _textBox4 = new TextBox();
            _textBox5 = new TextBox();



            _textBox1.Dock = DockStyle.Left;
            _textBox2.Dock = DockStyle.Left;
            _textBox3.Dock = DockStyle.Left;
            _textBox4.Dock = DockStyle.Left;
            _textBox5.Dock = DockStyle.Left;

            _textBox1.Text = _mainForm.Project.Name;

            _textBox1.Width = 500;
            _textBox2.Width = 500;
            _textBox3.Width = 500;
            _textBox4.Width = 500;
            _textBox5.Width = 500;
            _textBox5.Multiline = true;

            _label1.Text = "Project Name";
            _label2.Text = "Customer";
            _label3.Text = "Application";
            _label4.Text = "Sales Engineer";
            _label5.Text = "Comments";


            Button button = new Button();
            button.Text = "Update Information";
            button.Click += new EventHandler(button_Click);
            button.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            dataGridView = new DataGridView();
            dataGridView.ColumnCount = 2;
            dataGridView.Columns[0].Name = "Name";
            dataGridView.Columns[1].Name = "Value";
            dataGridView.Width = 500;
            dataGridView.Height = 700;

            string[] row = new string[] { "Customer", "" };
            dataGridView.Rows.Add(row);
            row = new string[] { "Application", "" };
            dataGridView.Rows.Add(row);
            row = new string[] { "Sale Engineer", "" };
            dataGridView.Rows.Add(row);

            _panel.Controls.Add(_label1, 1, 1);



            _panel.Controls.Add(_textBox1, 2, 1);
            _panel.Controls.Add(dataGridView, 2, 2);
            _panel.SetColumnSpan(dataGridView, 3);
            _panel.SetRowSpan(dataGridView, 6);




            _panel.Controls.Add(button, 2, 8);
        }

        private void button_Click(object sender, EventArgs e)
        {
            _mainForm.Project.Name = _textBox1.Text;

            Dictionary<String, String> temp = new Dictionary<String, String>();

            foreach (DataGridViewRow dgvr in dataGridView.Rows)
            {
                if (dgvr.Cells["Name"].Value != null)
                {
                    temp.Add(Convert.ToString(dgvr.Cells["Name"].Value), Convert.ToString(dgvr.Cells["Value"].Value));
                }
            }
            _mainForm.Project.ProjectValues = temp;
        }
    }
}
