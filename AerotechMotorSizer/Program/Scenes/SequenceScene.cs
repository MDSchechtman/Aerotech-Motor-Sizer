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
    public class SequenceScene
    {
        private TableLayoutPanel _panel;
        private string _fileName;
        private MainForm _mainForm;

        private Dictionary<string, string[]> _unitLists;

        private Label _sequenceNameLabel;
        private Label _inputs;
        private Label _outputs;
        private Label _maxStaticFrictionLabel;
        private Label _dynamicFrictionLabel;
        private Label _ambientTemperatureLabel;
        private Label _mechanicalEfficiencyLabel;
        private Label _coolingLabel;
        private Label _stackedAxisDescription;
        private Label _stackedAxisLabel;
        private Label _stackedMassLabel;

        private Label _totalSeqTimeLabel;
        private Label _maxLinearSpeedLabel;
        private Label _peakAccelerationLabel;
        private Label _totalRMSForceLabel;
        private Label _peakCurrentLabel;
        private Label _continuousCurrentLabel;
        private Label _minBusVoltageLabel;
        private Label _finalCoilTemperatureLabel;
        private Label _commentsLabel;

        private TextBox _sequenceName;
        private TextBox _maxStaticFriction;
        private TextBox _dynamicFriction;
        private TextBox _ambientTemperature;
        private TextBox _mechanicalEfficiency;
        private TextBox _stackedMass;

        private TextBox _totalSeqTime;
        private TextBox _maxLinearSpeed;
        private TextBox _peakAcceleration;
        private TextBox _totalRMSForce;
        private TextBox _peakCurrent;
        private TextBox _continuousCurrent;
        private TextBox _minBusVoltage;
        private TextBox _finalCoilTemperature;
        private TextBox _comments;

        private ComboBox _maxStaticFrictionUnits;
        private ComboBox _dynamicFrictionUnits;
        private ComboBox _ambientTemperatureUnits;
        private ComboBox _mechanicalEfficiencyUnits;
        private ComboBox _cooling;
        private ComboBox _stackedAxis;
        private ComboBox _stackedMassUnits;

        private ComboBox _totalSeqTimeUnits;
        private ComboBox _maxLinearSpeedUnits;
        private ComboBox _peakAccelerationUnits;
        private ComboBox _totalRMSForceUnits;

        private Label _peakCurrentUnits;
        private Label _continuousCurrentUnits;
        private Label _minBusVoltageUnits;

        private ComboBox _finalCoilTemperatureUnits;

        public SequenceScene(MainForm mainForm)
        {
            _mainForm = mainForm;
            _panel = new TableLayoutPanel();

            Initialize();
        }

        public string Name
        {
            get { return _sequenceNameLabel.Text; }
            set { _sequenceNameLabel.Text = value; }
        }

        public TableLayoutPanel Component
        {
            get { return _panel; }
        }

        private void Initialize()
        {
            _panel = new TableLayoutPanel();
            _panel.Dock = DockStyle.Fill;
            _panel.RowCount = 20;
            _panel.ColumnCount = 6;

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

            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0F / 6.0F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0F / 6.0F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0F / 6.0F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0F / 6.0F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0F / 6.0F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0F / 6.0F));

            _unitLists = new Dictionary<string, string[]>();
            _unitLists.Add("length", new string[] { "m", "mm", "cm", "in", "ft" });
            _unitLists.Add("mass", new string[] { "kg", "g", "lb" });
            _unitLists.Add("time", new string[] { "s", "ms", "min" });
            _unitLists.Add("angle", new string[] { "rad", "deg", "rev" });
            _unitLists.Add("percent", new string[] { "fraction", "%" });
            _unitLists.Add("force", new string[] { "N", "lb" });
            _unitLists.Add("friction", new string[] { "N/(m/s)", "lb/(m/s)" });
            _unitLists.Add("velocity", new string[] { "m/s", "mm/s", "m/min", "in/s", "in/min" });
            _unitLists.Add("acceleration", new string[] { "m/s^2", "mm/s^2", "m/min^2", "in/s^2", "in/min^2", "g" });
            _unitLists.Add("temperature", new string[] { "\x00B0C", "\x00B0F", "K" });
            _unitLists.Add("cooling", new string[] { "No Cooling", "10 PSI", "20 PSI", "40 PSI", "Vacuum" });
            _unitLists.Add("none", new string[] { "None" });

            _sequenceNameLabel = addLabel("Linear Movement Sequence");
            _sequenceNameLabel.Font = new Font("Tahoma", 14, FontStyle.Bold);
            _inputs = addLabel("Inputs");
            _inputs.Font = new Font("Tahoma", 10, FontStyle.Bold);
            _outputs = addLabel("Outputs");
            _outputs.Font = new Font("Tahoma", 10, FontStyle.Bold);
            _maxStaticFrictionLabel = addLabel("Max Static Friction");
            _dynamicFrictionLabel = addLabel("Dynamic Friction");
            _ambientTemperatureLabel = addLabel("Ambient Temp.");
            _mechanicalEfficiencyLabel = addLabel("Mech. Efficiency");
            _coolingLabel = addLabel("Cooling");
            _stackedAxisDescription = addLabel("If an axis is stacked on top of this one:");
            _stackedAxisLabel = addLabel("Stacked Axis");
            _stackedMassLabel = addLabel("Stacked Mass");

            _totalSeqTimeLabel = addLabel("Total Seq. Time");
            _maxLinearSpeedLabel = addLabel("Max Linear Speed");
            _peakAccelerationLabel = addLabel("Peak Acceleration");
            _totalRMSForceLabel = addLabel("Total RMS Force");
            _peakCurrentLabel = addLabel("Peak Current");
            _continuousCurrentLabel = addLabel("Continuous Current");
            _minBusVoltageLabel = addLabel("Min Bus Voltage");
            _finalCoilTemperatureLabel = addLabel("Final Coil Temp.");
            _commentsLabel = addLabel("Comments");



            _sequenceName = new TextBox();
            _maxStaticFriction = new TextBox();
            _dynamicFriction = new TextBox();
            _ambientTemperature = new TextBox();
            _mechanicalEfficiency = new TextBox();
            _stackedMass = new TextBox();

            _totalSeqTime = new TextBox();
            _maxLinearSpeed = new TextBox();
            _peakAcceleration = new TextBox();
            _totalRMSForce = new TextBox();
            _peakCurrent = new TextBox();
            _continuousCurrent = new TextBox();
            _minBusVoltage = new TextBox();
            _finalCoilTemperature = new TextBox();
            _comments = new TextBox();
            _comments.Multiline = true;

            _sequenceName.Dock = DockStyle.Fill;
            _sequenceName.Text = "Sequence 1";
            _maxStaticFriction.Dock = DockStyle.Fill;
            _dynamicFriction.Dock = DockStyle.Fill;
            _ambientTemperature.Dock = DockStyle.Fill;
            _mechanicalEfficiency.Dock = DockStyle.Fill;
            _stackedMass.Dock = DockStyle.Fill;

            _totalSeqTime.Dock = DockStyle.Fill;
            _maxLinearSpeed.Dock = DockStyle.Fill;
            _peakAcceleration.Dock = DockStyle.Fill;
            _totalRMSForce.Dock = DockStyle.Fill;
            _peakCurrent.Dock = DockStyle.Fill;
            _continuousCurrent.Dock = DockStyle.Fill;
            _minBusVoltage.Dock = DockStyle.Fill;
            _finalCoilTemperature.Dock = DockStyle.Fill;
            _comments.Dock = DockStyle.Fill;

            _maxStaticFriction.Enabled = true;
            _dynamicFriction.Enabled = true;
            _ambientTemperature.Enabled = true;
            _mechanicalEfficiency.Enabled = true;
            _stackedMass.Enabled = false;

            _totalSeqTime.Enabled = false;
            _maxLinearSpeed.Enabled = false;
            _peakAcceleration.Enabled = false;
            _totalRMSForce.Enabled = false;
            _peakCurrent.Enabled = false;
            _continuousCurrent.Enabled = false;
            _minBusVoltage.Enabled = false;
            _finalCoilTemperature.Enabled = false;
            _comments.Enabled = true;

            _maxStaticFrictionUnits = fillComboBox("force", 0);
            _dynamicFrictionUnits = fillComboBox("friction", 0);
            _ambientTemperatureUnits = fillComboBox("temperature", 0);
            _mechanicalEfficiencyUnits = fillComboBox("percent", 0);
            _cooling = fillComboBox("cooling", 0);
            _stackedAxis = fillComboBox("none", 0);
            _stackedMassUnits = fillComboBox("mass", 0);

            _totalSeqTimeUnits = fillComboBox("time", 1);
            _maxLinearSpeedUnits = fillComboBox("velocity", 0);
            _peakAccelerationUnits = fillComboBox("acceleration", 0);
            _totalRMSForceUnits = fillComboBox("force", 0);

            _peakCurrentUnits = addLabel("A");
            _continuousCurrentUnits = addLabel("A");
            _minBusVoltageUnits = addLabel("V");

            _finalCoilTemperatureUnits = fillComboBox("temperature", 0);

            _panel.Controls.Add(_sequenceNameLabel, 0, 0);
            _panel.SetColumnSpan(_sequenceNameLabel, 2);
            _panel.Controls.Add(_inputs, 0, 2);
            _panel.Controls.Add(_maxStaticFrictionLabel, 0, 3);
            _panel.Controls.Add(_dynamicFrictionLabel, 0, 4);
            _panel.Controls.Add(_ambientTemperatureLabel, 0, 5);
            _panel.Controls.Add(_mechanicalEfficiencyLabel, 0, 6);
            _panel.Controls.Add(_coolingLabel, 0, 7);
            _panel.Controls.Add(_stackedAxisDescription, 0, 8);
            _panel.SetColumnSpan(_stackedAxisDescription, 3);
            _panel.Controls.Add(_stackedAxisLabel, 0, 9);
            _panel.Controls.Add(_stackedMassLabel, 0, 10);
            _panel.Controls.Add(_commentsLabel, 0, 11);

            _panel.Controls.Add(_outputs, 3, 2);
            _panel.Controls.Add(_totalSeqTimeLabel, 3, 3);
            _panel.Controls.Add(_maxLinearSpeedLabel, 3, 4);
            _panel.Controls.Add(_peakAccelerationLabel, 3, 5);
            _panel.Controls.Add(_totalRMSForceLabel, 3, 6);
            _panel.Controls.Add(_peakCurrentLabel, 3, 7);
            _panel.Controls.Add(_continuousCurrentLabel, 3, 8);
            _panel.Controls.Add(_minBusVoltageLabel, 3, 9);
            _panel.Controls.Add(_finalCoilTemperatureLabel, 3, 10);

            _panel.Controls.Add(_sequenceName, 2, 0);
            _panel.SetColumnSpan(_sequenceName, 4);
            _panel.Controls.Add(_maxStaticFriction, 1, 3);
            _panel.Controls.Add(_dynamicFriction, 1, 4);
            _panel.Controls.Add(_ambientTemperature, 1, 5);
            _panel.Controls.Add(_mechanicalEfficiency, 1, 6);
            _panel.Controls.Add(_cooling, 1, 7);
            _panel.SetColumnSpan(_cooling, 2);
            _panel.Controls.Add(_stackedAxis, 1, 9);
            _panel.SetColumnSpan(_stackedAxis, 2);
            _panel.Controls.Add(_stackedMass, 1, 10);
            _panel.Controls.Add(_comments, 1, 11);
            _panel.SetRowSpan(_comments, 9);
            _panel.SetColumnSpan(_comments, 5);

            _panel.Controls.Add(_totalSeqTime, 4, 3);
            _panel.Controls.Add(_maxLinearSpeed, 4, 4);
            _panel.Controls.Add(_peakAcceleration, 4, 5);
            _panel.Controls.Add(_totalRMSForce, 4, 6);
            _panel.Controls.Add(_peakCurrent, 4, 7);
            _panel.Controls.Add(_continuousCurrent, 4, 8);
            _panel.Controls.Add(_minBusVoltage, 4, 9);
            _panel.Controls.Add(_finalCoilTemperature, 4, 10);

            _panel.Controls.Add(_maxStaticFrictionUnits, 2, 3);
            _panel.Controls.Add(_dynamicFrictionUnits, 2, 4);
            _panel.Controls.Add(_ambientTemperatureUnits, 2, 5);
            _panel.Controls.Add(_mechanicalEfficiencyUnits, 2, 6);
            _panel.Controls.Add(_stackedMassUnits, 2, 10);

            _panel.Controls.Add(_totalSeqTimeUnits, 5, 3);
            _panel.Controls.Add(_maxLinearSpeedUnits, 5, 4);
            _panel.Controls.Add(_peakAccelerationUnits, 5, 5);
            _panel.Controls.Add(_totalRMSForceUnits, 5, 6);
            _panel.Controls.Add(_peakCurrentUnits, 5, 7);
            _panel.Controls.Add(_continuousCurrentUnits, 5, 8);
            _panel.Controls.Add(_minBusVoltageUnits, 5, 9);
            _panel.Controls.Add(_finalCoilTemperatureUnits, 5, 10);
        }

        private ComboBox fillComboBox(string units, int selectedItem)
        {
            ComboBox box = new ComboBox();
            string[] unitList = _unitLists[units];
            for (int i = 0; i < unitList.Length; i++)
                box.Items.Add(string.Format(unitList[i]));
            box.Width = 20000;
            box.Dock = DockStyle.Right;
            box.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            box.DropDownStyle = ComboBoxStyle.DropDownList;
            box.SelectedItem = box.Items[selectedItem];

            return box;
        }

        private Label addLabel(string text)
        {
            Label myLabel = new Label();
            myLabel.Text = text;
            myLabel.Font = new Font("Tahoma", 10);
            myLabel.Size = new Size(myLabel.PreferredWidth, myLabel.PreferredHeight);
            myLabel.AutoSize = true;
            myLabel.TextAlign = ContentAlignment.BottomLeft;
            myLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            myLabel.Margin = new Padding(0, 0, 0, 0);

            return myLabel;
        }
    }
}
