﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Interfaces;
using Utility;

namespace Program
{
    public class ParameterSetConverterDialog
    {
        private Dictionary<string, double> _dictionary;

        private Form _dialog;
        private TableLayoutPanel _panel;

        public ParameterSetConverterDialog()
        {
            _dictionary = new Dictionary<string, double>();

            BuildDialog();
            _dialog.ShowDialog();
        }

        // Populate the dialog
        private void BuildDialog()
        {
            _dialog = new Form();
            _dialog.Size = new System.Drawing.Size(690, 335);

            _panel = new TableLayoutPanel();
            _panel.Size = new System.Drawing.Size(690, 335);
            _panel.RowCount = 12;
            _panel.ColumnCount = 6;

            for (int i = 0; i < 10; i++)
            {
                Label l1, l2, l3;
                TextBox t1, t2, t3;

                l1 = new Label();
                l2 = new Label();
                l3 = new Label();
                t1 = new TextBox();
                t2 = new TextBox();
                t3 = new TextBox();

                switch (i)
                {
                    case 0: // distanceOfTravel totalTime percentage 
                        l1.Text = "distanceOfTravel";
                        l2.Text = "totalTime";
                        l3.Text = "percentage";
                        break;
                    case 1: // distanceOfTravel maxVelocity percentage 
                        l1.Text = "distanceOfTravel";
                        l2.Text = "maxVelocity";
                        l3.Text = "percentage";
                        break;
                    case 2: // distanceOfTravel maxVelocity totalTime 
                        l1.Text = "distanceOfTravel";
                        l2.Text = "maxVelocity";
                        l3.Text = "totalTime";
                        break;
                    case 3: // distanceOfTravel maxVelocity peakAcceleration 
                        l1.Text = "distanceOfTravel";
                        l2.Text = "maxVelocity";
                        l3.Text = "peakAcceleration";
                        break;
                    case 4: // accelDistance maxVelocity totalTravel 
                        l1.Text = "accelDistance";
                        l2.Text = "maxVelocity";
                        l3.Text = "totalTravel";
                        break;
                    case 5: // accelDistance maxVelocity totalTime 
                        l1.Text = "accelDistance";
                        l2.Text = "maxVelocity";
                        l3.Text = "totalTime";
                        break;
                    case 6: // acceleration maxVelocity maxTravel 
                        l1.Text = "acceleration";
                        l2.Text = "maxVelocity";
                        l3.Text = "maxTravel";
                        break;
                    case 7: // peakAcceleration maxVelocity totalTime 
                        l1.Text = "peakAcceleration";
                        l2.Text = "maxVelocity";
                        l3.Text = "totalTime";
                        break;
                    case 8: // peakAcceleration maxVelocity scanDistance 
                        l1.Text = "peakAcceleration";
                        l2.Text = "maxVelocity";
                        l3.Text = "scanDistance";
                        break;
                    case 9: // totalTravel maxVelocity scanDistance 
                        l1.Text = "totalTravel";
                        l2.Text = "maxVelocity";
                        l3.Text = "scanDistance";
                        break;
                    case 10: // totalTime maxVelocity scanDistance 
                        l1.Text = "totalTime";
                        l2.Text = "maxVelocity";
                        l3.Text = "scanDistance";
                        break;
                }

                _panel.Controls.Add(l1, 0, i);
                _panel.Controls.Add(t1, 1, i);

                _panel.Controls.Add(l2, 2, i);
                _panel.Controls.Add(t2, 3, i);

                _panel.Controls.Add(l3, 4, i);
                _panel.Controls.Add(t3, 5, i);
            }


            Button ok = new Button();
            ok.Text = "OK";
            ok.Click += new EventHandler(ok_Click);
            _panel.Controls.Add(ok, 5, 11);

            _dialog.Controls.Add(_panel);
        }

        // TODO: Robust error handling.  For now this is a proof of concept
        void ok_Click(object sender, EventArgs e)
        {
            _dialog.Close();

            foreach (Control c in _panel.Controls)
            {
                if (c is TextBox && c.Text != string.Empty)
                {
                    int i = _panel.Controls.IndexOf(c);
                    Label l = _panel.Controls[i - 1] as Label;

                    _dictionary.Add(l.Text, Double.Parse(c.Text));
                }
            }
        }

        public Dictionary<string, double> Parameters
        {
            get { return _dictionary; }
        }
    }
}