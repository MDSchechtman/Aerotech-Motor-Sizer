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
    public class ProfileScene
    {
        private TableLayoutPanel _panel;
        private ComboBox _box;
        private Label _message;
        private Button _ok;
        private string _fileName;
        private MainForm _mainForm;

        private Dictionary<string, string[]> _unitLists;

        private Label _profileNameLabel;
        private Label _accelerationTypeLabel;
        private Label _inputs;
        private Label _outputs;
        private Label _lengthOfTravelLabel;
        private Label _massOfLoadLabel;
        private Label _accelerationTimeLabel;
        private Label _traverseTimeLabel;
        private Label _decelerationTimeLabel;
        private Label _dwellTimeLabel;
        private Label _inclineAngleLabel;
        private Label _thrustForceLabel;
        private Label _maxStaticFrictionLabel;
        private Label _dynamicFrictionLabel;
        private Label _ambientTemperatureLabel;
        private Label _mechanicalEfficiencyLabel;
        private Label _coolingLabel;
        private Label _totalMoveTimeLabel;
        private Label _dutyCycleLabel;
        private Label _maxLinearSpeedLabel;
        private Label _peakAccelerationLabel;
        private Label _peakAccelerationForceLabel;
        private Label _peakTraverseForceLabel;
        private Label _peaDecelerationForceLabel;
        private Label _peakDwellForceLabel;
        private Label _totalRMSForceLabel;
        private Label _peakCurrentLabel;
        private Label _continuousCurrentLabel;
        private Label _minBusVoltageLabel;
        private Label _finalCoilTemperatureLabel;
        private Label _totalRMSForceForEntireSequenceLabel;
        private Label _commentsLabel;

        private TextBox _profileName;
        private TextBox _lengthOfTravel;
        private TextBox _massOfLoad;
        private TextBox _accelerationTime;
        private TextBox _traverseTime;
        private TextBox _decelerationTime;
        private TextBox _dwellTime;
        private TextBox _inclineAngle;
        private TextBox _thrustForce;
        private TextBox _maxStaticFriction;
        private TextBox _dynamicFriction;
        private TextBox _ambientTemperature;
        private TextBox _mechanicalEfficiency;
        private TextBox _cooling;
        private TextBox _totalMoveTime;
        private TextBox _dutyCycle;
        private TextBox _maxLinearSpeed;
        private TextBox _peakAcceleration;
        private TextBox _peakAccelerationForce;
        private TextBox _peakTraverseForce;
        private TextBox _peaDecelerationForce;
        private TextBox _peakDwellForce;
        private TextBox _totalRMSForce;
        private TextBox _peakCurrent;
        private TextBox _continuousCurrent;
        private TextBox _minBusVoltage;
        private TextBox _finalCoilTemperature;
        private TextBox _totalRMSForceForEntireSequence;
        private TextBox _comments;

        private ComboBox _accelerationType;

        private ComboBox _lengthOfTravelUnits;
        private ComboBox _massOfLoadUnits;
        private ComboBox _accelerationTimeUnits;
        private ComboBox _traverseTimeUnits;
        private ComboBox _decelerationTimeUnits;
        private ComboBox _dwellTimeUnits;
        private ComboBox _inclineAngleUnits;
        private ComboBox _thrustForceUnits;

        private Label _maxStaticFrictionUnits;
        private Label _dynamicFrictionUnits;
        private Label _ambientTemperatureUnits;
        private Label _mechanicalEfficiencyUnits;

        private ComboBox _totalMoveTimeUnits;
        private ComboBox _dutyCycleUnits;
        private ComboBox _maxLinearSpeedUnits;
        private ComboBox _peakAccelerationUnits;
        private ComboBox _peakAccelerationForceUnits;
        private ComboBox _peakTraverseForceUnits;
        private ComboBox _peaDecelerationForceUnits;
        private ComboBox _peakDwellForceUnits;
        private ComboBox _totalRMSForceUnits;

        private Label _peakCurrentUnits;
        private Label _continuousCurrentUnits;
        private Label _minBusVoltageUnits;

        private ComboBox _finalCoilTemperatureUnits;
        private ComboBox _totalRMSForceForEntireSequenceUnits;

        public ProfileScene(MainForm mainForm)
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
            _unitLists.Add("velocity", new string[] { "m/s", "mm/s", "m/min", "in/s", "in/min" });
            _unitLists.Add("acceleration", new string[] { "m/s^2", "mm/s^2", "m/min^2", "in/s^2", "in/min^2", "g" });
            _unitLists.Add("temperature", new string[] { "\x00B0C", "\x00B0F", "K" });

            _profileNameLabel = addLabel("Linear Movement Profile");
            _profileNameLabel.Font = new Font("Tahoma", 14, FontStyle.Bold);
            _accelerationTypeLabel = addLabel("Acceleration Type");
            _inputs = addLabel("Inputs");
            _inputs.Font = new Font("Tahoma", 10, FontStyle.Bold);
            _outputs = addLabel("Outputs");
            _outputs.Font = new Font("Tahoma", 10, FontStyle.Bold);
            _lengthOfTravelLabel = addLabel("Length of Travel");
            _massOfLoadLabel = addLabel("Mass of Load");
            _accelerationTimeLabel = addLabel("Accel. Time");
            _traverseTimeLabel = addLabel("Traverse Time");
            _decelerationTimeLabel = addLabel("Decel. Time");
            _dwellTimeLabel = addLabel("Dwell Time");
            _inclineAngleLabel = addLabel("Incline Angle");
            _thrustForceLabel = addLabel("Thrust Force");
            _maxStaticFrictionLabel = addLabel("Max Static Friction");
            _dynamicFrictionLabel = addLabel("Dynamic Friction");
            _ambientTemperatureLabel = addLabel("Ambient Temp.");
            _mechanicalEfficiencyLabel = addLabel("Mech. Efficiency");
            _coolingLabel = addLabel("Cooling");
            _totalMoveTimeLabel = addLabel("Total Move Time");
            _dutyCycleLabel = addLabel("Duty Cycle");
            _maxLinearSpeedLabel = addLabel("Max Linear Speed");
            _peakAccelerationLabel = addLabel("Peak Acceleration");
            _peakAccelerationForceLabel = addLabel("Peak Accel. Force");
            _peakTraverseForceLabel = addLabel("Peak Trav. Force");
            _peaDecelerationForceLabel = addLabel("Peak Decel. Force");
            _peakDwellForceLabel = addLabel("Peak Dwell Force");
            _totalRMSForceLabel = addLabel("Total RMS Force");
            _peakCurrentLabel = addLabel("Peak Current");
            _continuousCurrentLabel = addLabel("Continuous Current");
            _minBusVoltageLabel = addLabel("Min Bus Voltage");
            _finalCoilTemperatureLabel = addLabel("Final Coil Temp.");
            _totalRMSForceForEntireSequenceLabel = addLabel("Total RMS Force for Entire Sequence");
            _commentsLabel = addLabel("Comments");

            _profileName = new TextBox();
            _lengthOfTravel = new TextBox();
            _massOfLoad = new TextBox();
            _accelerationTime = new TextBox();
            _traverseTime = new TextBox();
            _decelerationTime = new TextBox();
            _dwellTime = new TextBox();
            _inclineAngle = new TextBox();
            _thrustForce = new TextBox();
            _maxStaticFriction = new TextBox();
            _dynamicFriction = new TextBox();
            _ambientTemperature = new TextBox();
            _mechanicalEfficiency = new TextBox();
            _cooling = new TextBox();
            _totalMoveTime = new TextBox();
            _dutyCycle = new TextBox();
            _maxLinearSpeed = new TextBox();
            _peakAcceleration = new TextBox();
            _peakAccelerationForce = new TextBox();
            _peakTraverseForce = new TextBox();
            _peaDecelerationForce = new TextBox();
            _peakDwellForce = new TextBox();
            _totalRMSForce = new TextBox();
            _peakCurrent = new TextBox();
            _continuousCurrent = new TextBox();
            _minBusVoltage = new TextBox();
            _finalCoilTemperature = new TextBox();
            _totalRMSForceForEntireSequence = new TextBox();
            _comments = new TextBox();
            _comments.Multiline = true;

            _profileName.Dock = DockStyle.Fill;
            _profileName.Text = "Profile 1";
            _lengthOfTravel.Dock = DockStyle.Left;
            _massOfLoad.Dock = DockStyle.Left;
            _accelerationTime.Dock = DockStyle.Left;
            _traverseTime.Dock = DockStyle.Left;
            _decelerationTime.Dock = DockStyle.Left;
            _dwellTime.Dock = DockStyle.Left;
            _inclineAngle.Dock = DockStyle.Left;
            _thrustForce.Dock = DockStyle.Left;
            _maxStaticFriction.Dock = DockStyle.Left;
            _dynamicFriction.Dock = DockStyle.Left;
            _ambientTemperature.Dock = DockStyle.Left;
            _mechanicalEfficiency.Dock = DockStyle.Left;
            _cooling.Dock = DockStyle.Left;
            _totalMoveTime.Dock = DockStyle.Left;
            _dutyCycle.Dock = DockStyle.Left;
            _maxLinearSpeed.Dock = DockStyle.Left;
            _peakAcceleration.Dock = DockStyle.Left;
            _peakAccelerationForce.Dock = DockStyle.Left;
            _peakTraverseForce.Dock = DockStyle.Left;
            _peaDecelerationForce.Dock = DockStyle.Left;
            _peakDwellForce.Dock = DockStyle.Left;
            _totalRMSForce.Dock = DockStyle.Left;
            _peakCurrent.Dock = DockStyle.Left;
            _continuousCurrent.Dock = DockStyle.Left;
            _minBusVoltage.Dock = DockStyle.Left;
            _finalCoilTemperature.Dock = DockStyle.Left;
            _totalRMSForceForEntireSequence.Dock = DockStyle.Left;
            _comments.Dock = DockStyle.Fill;

            _maxStaticFriction.Enabled = false;
            _dynamicFriction.Enabled = false;
            _ambientTemperature.Enabled = false;
            _mechanicalEfficiency.Enabled = false;
            _cooling.Enabled = false;
            _totalMoveTime.Enabled = false;
            _dutyCycle.Enabled = false;
            _maxLinearSpeed.Enabled = false;
            _peakAcceleration.Enabled = false;
            _peakAccelerationForce.Enabled = false;
            _peakTraverseForce.Enabled = false;
            _peaDecelerationForce.Enabled = false;
            _peakDwellForce.Enabled = false;
            _totalRMSForce.Enabled = false;
            _peakCurrent.Enabled = false;
            _continuousCurrent.Enabled = false;
            _minBusVoltage.Enabled = false;
            _finalCoilTemperature.Enabled = false;
            _totalRMSForceForEntireSequence.Enabled = false;

            _accelerationType = new ComboBox();
            _accelerationType.Items.Add(string.Format("Constant"));
            _accelerationType.Items.Add(string.Format("Triangular"));
            _accelerationType.Items.Add(string.Format("Sinusoidal"));
            _accelerationType.Width = 200;
            _accelerationType.Dock = DockStyle.Right;
            _accelerationType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _accelerationType.DropDownStyle = ComboBoxStyle.DropDownList;
            _accelerationType.SelectedItem = _accelerationType.Items[0];

            _lengthOfTravelUnits = fillComboBox("length", 1);
            _massOfLoadUnits = fillComboBox("mass", 0);
            _accelerationTimeUnits = fillComboBox("time", 1);
            _traverseTimeUnits = fillComboBox("time", 1);
            _decelerationTimeUnits = fillComboBox("time", 1);
            _dwellTimeUnits = fillComboBox("time", 1);
            _inclineAngleUnits = fillComboBox("angle", 1);
            _thrustForceUnits = fillComboBox("force", 0);

            _maxStaticFrictionUnits = addLabel("N");
            _dynamicFrictionUnits = addLabel("N/(m/s)");
            _ambientTemperatureUnits = addLabel("\x00B0C");
            _mechanicalEfficiencyUnits = addLabel("%");

            _totalMoveTimeUnits = fillComboBox("time", 1);
            _dutyCycleUnits = fillComboBox("percent", 1);
            _maxLinearSpeedUnits = fillComboBox("velocity", 0);
            _peakAccelerationUnits = fillComboBox("acceleration", 0);
            _peakAccelerationForceUnits = fillComboBox("force", 0);
            _peakTraverseForceUnits = fillComboBox("force", 0);
            _peaDecelerationForceUnits = fillComboBox("force", 0);
            _peakDwellForceUnits = fillComboBox("force", 0);
            _totalRMSForceUnits = fillComboBox("force", 0);

            _peakCurrentUnits = addLabel("A");
            _continuousCurrentUnits = addLabel("A");
            _minBusVoltageUnits = addLabel("V");

            _finalCoilTemperatureUnits = fillComboBox("temperature", 0);
            _totalRMSForceForEntireSequenceUnits = fillComboBox("force", 0);

            /*
            Button button = new Button();
            button.Text = "Open..";
            button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button.Click += new EventHandler(button_Click);

            _ok = new Button();
            _ok.Text = "OK";
            _ok.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _ok.Enabled = false;
            _ok.Click += new EventHandler(_ok_Click);
            */

            _panel.Controls.Add(_profileNameLabel, 0, 0);
            _panel.SetColumnSpan(_profileNameLabel, 2);
            _panel.Controls.Add(_accelerationTypeLabel, 0, 1);
            _panel.Controls.Add(_inputs, 0, 3);
            _panel.Controls.Add(_lengthOfTravelLabel, 0, 4);
            _panel.Controls.Add(_massOfLoadLabel, 0, 5);
            _panel.Controls.Add(_accelerationTimeLabel, 0, 6);
            _panel.Controls.Add(_traverseTimeLabel, 0, 7);
            _panel.Controls.Add(_decelerationTimeLabel, 0, 8);
            _panel.Controls.Add(_dwellTimeLabel, 0, 9);
            _panel.Controls.Add(_inclineAngleLabel, 0, 10);
            _panel.Controls.Add(_thrustForceLabel, 0, 11);
            _panel.Controls.Add(_maxStaticFrictionLabel, 0, 12);
            _panel.Controls.Add(_dynamicFrictionLabel, 0, 13);
            _panel.Controls.Add(_ambientTemperatureLabel, 0, 14);
            _panel.Controls.Add(_mechanicalEfficiencyLabel, 0, 15);
            _panel.Controls.Add(_coolingLabel, 0, 16);
            _panel.Controls.Add(_commentsLabel, 0, 18);

            _panel.Controls.Add(_outputs, 3, 3);
            _panel.Controls.Add(_totalMoveTimeLabel, 3, 4);
            _panel.Controls.Add(_dutyCycleLabel, 3, 5);
            _panel.Controls.Add(_maxLinearSpeedLabel, 3, 6);
            _panel.Controls.Add(_peakAccelerationLabel, 3, 7);
            _panel.Controls.Add(_peakAccelerationForceLabel, 3, 8);
            _panel.Controls.Add(_peakTraverseForceLabel, 3, 9);
            _panel.Controls.Add(_peaDecelerationForceLabel, 3, 10);
            _panel.Controls.Add(_peakDwellForceLabel, 3, 11);
            _panel.Controls.Add(_totalRMSForceLabel, 3, 12);
            _panel.Controls.Add(_peakCurrentLabel, 3, 13);
            _panel.Controls.Add(_continuousCurrentLabel, 3, 14);
            _panel.Controls.Add(_minBusVoltageLabel, 3, 15);
            _panel.Controls.Add(_finalCoilTemperatureLabel, 3, 16);
            _panel.Controls.Add(_totalRMSForceForEntireSequenceLabel, 2, 17);
            _panel.SetColumnSpan(_totalRMSForceForEntireSequenceLabel, 2);

            _panel.Controls.Add(_profileName, 2, 0);
            _panel.SetColumnSpan(_profileName, 4);
            _panel.Controls.Add(_lengthOfTravel, 1, 4);
            _panel.Controls.Add(_massOfLoad, 1, 5);
            _panel.Controls.Add(_accelerationTime, 1, 6);
            _panel.Controls.Add(_traverseTime, 1, 7);
            _panel.Controls.Add(_decelerationTime, 1, 8);
            _panel.Controls.Add(_dwellTime, 1, 9);
            _panel.Controls.Add(_inclineAngle, 1, 10);
            _panel.Controls.Add(_thrustForce, 1, 11);
            _panel.Controls.Add(_maxStaticFriction, 1, 12);
            _panel.Controls.Add(_dynamicFriction, 1, 13);
            _panel.Controls.Add(_ambientTemperature, 1, 14);
            _panel.Controls.Add(_mechanicalEfficiency, 1, 15);
            _panel.Controls.Add(_cooling, 1, 16);
            _panel.Controls.Add(_comments, 1, 18);
            _panel.SetRowSpan(_comments, 2);
            _panel.SetColumnSpan(_comments, 5);

            _panel.Controls.Add(_totalMoveTime, 4, 4);
            _panel.Controls.Add(_dutyCycle, 4, 5);
            _panel.Controls.Add(_maxLinearSpeed, 4, 6);
            _panel.Controls.Add(_peakAcceleration, 4, 7);
            _panel.Controls.Add(_peakAccelerationForce, 4, 8);
            _panel.Controls.Add(_peakTraverseForce, 4, 9);
            _panel.Controls.Add(_peaDecelerationForce, 4, 10);
            _panel.Controls.Add(_peakDwellForce, 4, 11);
            _panel.Controls.Add(_totalRMSForce, 4, 12);
            _panel.Controls.Add(_peakCurrent, 4, 13);
            _panel.Controls.Add(_continuousCurrent, 4, 14);
            _panel.Controls.Add(_minBusVoltage, 4, 15);
            _panel.Controls.Add(_finalCoilTemperature, 4, 16);
            _panel.Controls.Add(_totalRMSForceForEntireSequence, 4, 17);

            _panel.Controls.Add(_accelerationType, 1, 1);
            _panel.SetColumnSpan(_accelerationType, 1);

            _panel.Controls.Add(_lengthOfTravelUnits, 2, 4);
            _panel.Controls.Add(_massOfLoadUnits, 2, 5);
            _panel.Controls.Add(_accelerationTimeUnits, 2, 6);
            _panel.Controls.Add(_traverseTimeUnits, 2, 7);
            _panel.Controls.Add(_decelerationTimeUnits, 2, 8);
            _panel.Controls.Add(_dwellTimeUnits, 2, 9);
            _panel.Controls.Add(_inclineAngleUnits, 2, 10);
            _panel.Controls.Add(_thrustForceUnits, 2, 11);
            _panel.Controls.Add(_maxStaticFrictionUnits, 2, 12);
            _panel.Controls.Add(_dynamicFrictionUnits, 2, 13);
            _panel.Controls.Add(_ambientTemperatureUnits, 2, 14);
            _panel.Controls.Add(_mechanicalEfficiencyUnits, 2, 15);
            _panel.Controls.Add(_totalMoveTimeUnits, 5, 4);
            _panel.Controls.Add(_dutyCycleUnits, 5, 5);
            _panel.Controls.Add(_maxLinearSpeedUnits, 5, 6);
            _panel.Controls.Add(_peakAccelerationUnits, 5, 7);
            _panel.Controls.Add(_peakAccelerationForceUnits, 5, 8);
            _panel.Controls.Add(_peakTraverseForceUnits, 5, 9);
            _panel.Controls.Add(_peaDecelerationForceUnits, 5, 10);
            _panel.Controls.Add(_peakDwellForceUnits, 5, 11);
            _panel.Controls.Add(_totalRMSForceUnits, 5, 12);
            _panel.Controls.Add(_peakCurrentUnits, 5, 13);
            _panel.Controls.Add(_continuousCurrentUnits, 5, 14);
            _panel.Controls.Add(_minBusVoltageUnits, 5, 15);
            _panel.Controls.Add(_finalCoilTemperatureUnits, 5, 16);
            _panel.Controls.Add(_totalRMSForceForEntireSequenceUnits, 5, 17);
        }

        private ComboBox fillComboBox(string units, int selectedItem)
        {
            ComboBox box = new ComboBox();
            string[] unitList = _unitLists[units];
            for (int i = 0; i < unitList.Length; i++)
                box.Items.Add(string.Format(unitList[i]));
            box.Width = 200;
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
