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
        private Label _peakForceLabel;
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
        private TextBox _peakForce;
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
        private ComboBox _peakForceUnits;
        private ComboBox _totalRMSForceUnits;

        private Label _peakCurrentUnits;
        private Label _continuousCurrentUnits;
        private Label _minBusVoltageUnits;

        private ComboBox _finalCoilTemperatureUnits;
        private ComboBox _totalRMSForceForEntireSequenceUnits;

        private Button _solve;

        private double _RMSforce;
        private double _loadMass;

        private Project _project;
        private Solver _solver;

        private string _profileNameString;

        public double RMSForce
        {
            get { return _RMSforce; }
            set
            {
                _RMSforce = value;
                _totalRMSForce.Text = Math.Round(_RMSforce, 1).ToString(); // _RMSforce.ToString();
            }
        }

        public string Name
        {
            get { return _profileNameLabel.Text; }
            set { _profileNameLabel.Text = value; }
        }

        public ProfileScene(MainForm mainForm)
        {
            _mainForm = mainForm;
            _panel = new TableLayoutPanel();
            _project = mainForm.Project;
            _solver = new Solver();

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
            _peakForceLabel = addLabel("Peak Force");
            _totalRMSForceLabel = addLabel("RMS Force");
            _peakCurrentLabel = addLabel("Peak Current");
            _continuousCurrentLabel = addLabel("RMS Current");
            _minBusVoltageLabel = addLabel("Min Bus Voltage");
            _finalCoilTemperatureLabel = addLabel("Final Coil Temp.");
            _totalRMSForceForEntireSequenceLabel = addLabel("Total RMS Force for Entire Sequence");
            _commentsLabel = addLabel("Comments");

            _profileName = addTextBox(false);
            _lengthOfTravel = addTextBox(true);
            _massOfLoad = addTextBox(false);
            _accelerationTime = addTextBox(true);
            _traverseTime = addTextBox(true);
            _decelerationTime = addTextBox(true);
            _dwellTime = addTextBox(true);
            _inclineAngle = addTextBox(false);
            _thrustForce = addTextBox(false);
            _maxStaticFriction = addTextBox(true);
            _dynamicFriction = addTextBox(true);
            _ambientTemperature = addTextBox(true);
            _mechanicalEfficiency = addTextBox(true);
            _cooling = addTextBox(true);
            _totalMoveTime = addTextBox(true);
            //_dutyCycle = addTextBox(false);
            _dutyCycle = addTextBox(true);
            _maxLinearSpeed = addTextBox(true);
            _peakAcceleration = addTextBox(true);
            _peakAccelerationForce = addTextBox(true);
            _peakTraverseForce = addTextBox(true);
            _peaDecelerationForce = addTextBox(true);
            _peakDwellForce = addTextBox(true);
            _peakForce = addTextBox(true);
            _totalRMSForce = addTextBox(true);
            _peakCurrent = addTextBox(true);
            _continuousCurrent = addTextBox(true);
            _minBusVoltage = addTextBox(true);
            _finalCoilTemperature = addTextBox(true);
            _totalRMSForceForEntireSequence = addTextBox(true);
            _comments = addTextBox(false);
            _comments.Multiline = true;

            _profileName.Name = "_profileName";
            _profileName.Text = "Profile 1";
            _profileNameString = _profileName.Text;
            _profileName.TextAlign = HorizontalAlignment.Left;

            _project.Load = new Load(0.25, 0);

            _massOfLoad.Name = "_massOfLoad";
            _inclineAngle.Name = "_inclineAngle";
            _thrustForce.Name = "_thrustForce";

            _massOfLoad.Text = "0.25";
            _inclineAngle.Text = "0";
            _thrustForce.Text = "0";
            _maxStaticFriction.Text = _project.Environment.StaticFriction.ToString();
            _dynamicFriction.Text = _project.Environment.DynamicFriction.ToString();
            _ambientTemperature.Text = _project.Environment.AmbientTemp.ToString();
            _mechanicalEfficiency.Text = _project.Environment.MechEfficiency.ToString();
            _cooling.Text = _project.Environment.Cooling;

            _accelerationType = new ComboBox();
            _accelerationType.Items.Add(string.Format("Constant"));
            _accelerationType.Items.Add(string.Format("Triangular"));
            _accelerationType.Items.Add(string.Format("Sinusoidal"));
            _accelerationType.Width = 200;
            _accelerationType.Dock = DockStyle.Right;
            _accelerationType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _accelerationType.DropDownStyle = ComboBoxStyle.DropDownList;
            _accelerationType.SelectedItem = _accelerationType.Items[0];

            _lengthOfTravelUnits = fillComboBox("length", 0);
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

            _totalMoveTimeUnits = fillComboBox("time", 0);
            _dutyCycleUnits = fillComboBox("percent", 1);
            _maxLinearSpeedUnits = fillComboBox("velocity", 0);
            _peakAccelerationUnits = fillComboBox("acceleration", 0);
            _peakAccelerationForceUnits = fillComboBox("force", 0);
            _peakTraverseForceUnits = fillComboBox("force", 0);
            _peaDecelerationForceUnits = fillComboBox("force", 0);
            _peakDwellForceUnits = fillComboBox("force", 0);
            _peakForceUnits = fillComboBox("force", 0);
            _totalRMSForceUnits = fillComboBox("force", 0);

            _peakCurrentUnits = addLabel("A");
            _continuousCurrentUnits = addLabel("A");
            _minBusVoltageUnits = addLabel("V");

            _finalCoilTemperatureUnits = fillComboBox("temperature", 0);
            _totalRMSForceForEntireSequenceUnits = fillComboBox("force", 0);

            _solve = new Button();
            _solve.Text = "Solve";
            _solve.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            _solve.Click += new EventHandler(_solve_Click);
            _solve.Padding = new Padding(10);
            _solve.Font = new Font("Tahoma", 14, FontStyle.Bold);
            _solve.Dock = DockStyle.Fill;

            _panel.Controls.Add(_profileNameLabel, 0, 0);
            _panel.SetColumnSpan(_profileNameLabel, 2);
            _panel.Controls.Add(_accelerationTypeLabel, 0, 1);

            _panel.Controls.Add(_solve, 2, 1);
            _panel.SetColumnSpan(_solve, 2);
            _panel.SetRowSpan(_solve, 2);

            _panel.Controls.Add(_inputs, 0, 3);
            _panel.Controls.Add(_lengthOfTravelLabel, 0, 4);
            _panel.Controls.Add(_massOfLoadLabel, 0, 5);

            //_panel.Controls.Add(_accelerationTimeLabel, 0, 6);
            //_panel.Controls.Add(_traverseTimeLabel, 0, 7);
            //_panel.Controls.Add(_decelerationTimeLabel, 0, 8);
            //_panel.Controls.Add(_dwellTimeLabel, 0, 9);

            _panel.Controls.Add(_inclineAngleLabel, 0, 6);
            _panel.Controls.Add(_thrustForceLabel, 0, 7);
            _panel.Controls.Add(_maxStaticFrictionLabel, 0, 8);
            _panel.Controls.Add(_dynamicFrictionLabel, 0, 9);
            _panel.Controls.Add(_ambientTemperatureLabel, 0, 10);
            _panel.Controls.Add(_mechanicalEfficiencyLabel, 0, 11);
            _panel.Controls.Add(_coolingLabel, 0, 12);
            _panel.Controls.Add(_commentsLabel, 0, 14);

            _panel.Controls.Add(_outputs, 3, 3);
            _panel.Controls.Add(_totalMoveTimeLabel, 3, 4);
            _panel.Controls.Add(_dutyCycleLabel, 3, 5);
            _panel.Controls.Add(_maxLinearSpeedLabel, 3, 6);
            _panel.Controls.Add(_peakAccelerationLabel, 3, 7);

            //_panel.Controls.Add(_peakAccelerationForceLabel, 3, 8);
            //_panel.Controls.Add(_peakTraverseForceLabel, 3, 9);
            //_panel.Controls.Add(_peaDecelerationForceLabel, 3, 10);
            //_panel.Controls.Add(_peakDwellForceLabel, 3, 11);

            _panel.Controls.Add(_peakForceLabel, 3, 8);
            _panel.Controls.Add(_totalRMSForceLabel, 3, 9);
            _panel.Controls.Add(_peakCurrentLabel, 3, 10);
            _panel.Controls.Add(_continuousCurrentLabel, 3, 11);
            //_panel.Controls.Add(_minBusVoltageLabel, 3, 11);
            _panel.Controls.Add(_finalCoilTemperatureLabel, 3, 12);
            _panel.Controls.Add(_totalRMSForceForEntireSequenceLabel, 2, 13);
            _panel.SetColumnSpan(_totalRMSForceForEntireSequenceLabel, 2);

            _panel.Controls.Add(_profileName, 2, 0);
            _panel.SetColumnSpan(_profileName, 4);
            _panel.Controls.Add(_lengthOfTravel, 1, 4);
            _panel.Controls.Add(_massOfLoad, 1, 5);

            //_panel.Controls.Add(_accelerationTime, 1, 6);
            //_panel.Controls.Add(_traverseTime, 1, 7);
            //_panel.Controls.Add(_decelerationTime, 1, 8);
            //_panel.Controls.Add(_dwellTime, 1, 9);

            _panel.Controls.Add(_inclineAngle, 1, 6);
            _panel.Controls.Add(_thrustForce, 1, 7);
            _panel.Controls.Add(_maxStaticFriction, 1, 8);
            _panel.Controls.Add(_dynamicFriction, 1, 9);
            _panel.Controls.Add(_ambientTemperature, 1, 10);
            _panel.Controls.Add(_mechanicalEfficiency, 1, 11);
            _panel.Controls.Add(_cooling, 1, 12);
            _panel.Controls.Add(_comments, 1, 14);
            _panel.SetRowSpan(_comments, 6);
            _panel.SetColumnSpan(_comments, 5);

            _panel.Controls.Add(_totalMoveTime, 4, 4);
            _panel.Controls.Add(_dutyCycle, 4, 5);
            _panel.Controls.Add(_maxLinearSpeed, 4, 6);
            _panel.Controls.Add(_peakAcceleration, 4, 7);

            //_panel.Controls.Add(_peakAccelerationForce, 4, 8);
            //_panel.Controls.Add(_peakTraverseForce, 4, 9);
            //_panel.Controls.Add(_peaDecelerationForce, 4, 10);
            //_panel.Controls.Add(_peakDwellForce, 4, 11);

            _panel.Controls.Add(_peakForce, 4, 8);
            _panel.Controls.Add(_totalRMSForce, 4, 9);
            _panel.Controls.Add(_peakCurrent, 4, 10);
            _panel.Controls.Add(_continuousCurrent, 4, 11);
            //_panel.Controls.Add(_minBusVoltage, 4, 11);
            _panel.Controls.Add(_finalCoilTemperature, 4, 12);
            _panel.Controls.Add(_totalRMSForceForEntireSequence, 4, 13);

            _panel.Controls.Add(_accelerationType, 1, 1);
            _panel.SetColumnSpan(_accelerationType, 1);

            _panel.Controls.Add(_lengthOfTravelUnits, 2, 4);
            _panel.Controls.Add(_massOfLoadUnits, 2, 5);

            //_panel.Controls.Add(_accelerationTimeUnits, 2, 6);
            //_panel.Controls.Add(_traverseTimeUnits, 2, 7);
            //_panel.Controls.Add(_decelerationTimeUnits, 2, 8);
            //_panel.Controls.Add(_dwellTimeUnits, 2, 9);

            _panel.Controls.Add(_inclineAngleUnits, 2, 6);
            _panel.Controls.Add(_thrustForceUnits, 2, 7);
            _panel.Controls.Add(_maxStaticFrictionUnits, 2, 8);
            _panel.Controls.Add(_dynamicFrictionUnits, 2, 9);
            _panel.Controls.Add(_ambientTemperatureUnits, 2, 10);
            _panel.Controls.Add(_mechanicalEfficiencyUnits, 2, 11);
            _panel.Controls.Add(_totalMoveTimeUnits, 5, 4);
            _panel.Controls.Add(_dutyCycleUnits, 5, 5);
            _panel.Controls.Add(_maxLinearSpeedUnits, 5, 6);
            _panel.Controls.Add(_peakAccelerationUnits, 5, 7);

            //_panel.Controls.Add(_peakAccelerationForceUnits, 5, 8);
            //_panel.Controls.Add(_peakTraverseForceUnits, 5, 9);
            //_panel.Controls.Add(_peaDecelerationForceUnits, 5, 10);
            //_panel.Controls.Add(_peakDwellForceUnits, 5, 11);

            _panel.Controls.Add(_peakDwellForceUnits, 5, 8);
            _panel.Controls.Add(_totalRMSForceUnits, 5, 9);
            _panel.Controls.Add(_peakCurrentUnits, 5, 10);
            _panel.Controls.Add(_continuousCurrentUnits, 5, 11);
            //_panel.Controls.Add(_minBusVoltageUnits, 5, 11);
            _panel.Controls.Add(_finalCoilTemperatureUnits, 5, 12);
            _panel.Controls.Add(_totalRMSForceForEntireSequenceUnits, 5, 13);
        }

        public void UpdateEnvironment()
        {
            _maxStaticFriction.Text = _project.Environment.StaticFriction.ToString();
            _dynamicFriction.Text = _project.Environment.DynamicFriction.ToString();
            _ambientTemperature.Text = _project.Environment.AmbientTemp.ToString();
            _mechanicalEfficiency.Text = _project.Environment.MechEfficiency.ToString();
            _cooling.Text = _project.Environment.Cooling;

            Solve();
        }

        public void Solve()
        {
            if (_project.Axis1 != null && _project.Motor != null && _project.Load != null)
            {
                _solver.Start(_project.Axis1.Record, _project.Motor, _project.Load, _project.Axis1.Path, _project.Environment);

                _dutyCycle.Text = "100";

                _totalMoveTime.Text = _project.Axis1.Record.Time.Max().ToString("0.####");
                _lengthOfTravel.Text = _project.Axis1.Record.Position.Max().ToString("0.####");
                _maxLinearSpeed.Text = _project.Axis1.Record.Velocity.Max().ToString("0.####");
                _peakAcceleration.Text = _project.Axis1.Record.Acceleration.Max().ToString("0.####");

                _peakForce.Text = _project.Axis1.Record.MAXforce.ToString("0.####");
                _totalRMSForce.Text = _project.Axis1.Record.RMSforce.ToString("0.####");
                _peakCurrent.Text = _project.Axis1.Record.MAXcurrent.ToString("0.####");
                _continuousCurrent.Text = _project.Axis1.Record.RMScurrent.ToString("0.####");
                _finalCoilTemperature.Text = (_project.Environment.AmbientTemp + _project.Axis1.Record.TemperatureRise).ToString("0.####");

                _totalRMSForceForEntireSequence.Text = _project.Axis1.Record.RMSforce.ToString("0.####");

                _project.Sequence.UpdateSolution();

                _project.Warn.Warnings = "";

                string warnings = "";

                if (_project.Axis1.Record.MAXforce > _project.Motor.PeakForce)
                    warnings += "Peak force exceeds motor rating\r\n";
                if(_project.Axis1.Record.MAXcurrent > _project.Motor.PeakCurrent)
                    warnings += "Peak current exceeds motor rating\r\n";
                if(_project.Axis1.Record.RMSforce > _project.Motor.ContinuousForce)
                    warnings += "Continuous force exceeds motor rating\r\n";
                if(_project.Axis1.Record.RMScurrent > _project.Motor.ContinuousCurrent)
                    warnings += "Continuous current exceeds motor rating\r\n";

                _project.Warn.Warnings = warnings;
            }
        }

        void _TextChanged(object sender, EventArgs e)
        {
            string name = (sender as TextBox).Name;
            string text = (sender as TextBox).Text;
            double value;
            if (Double.TryParse(text, out value))
            {
                if (name.Equals("_massOfLoad"))
                    _project.Load.Mass = value;
                else if (name.Equals("_inclineAngle") && _project.Axis1 != null)
                    _project.Axis1.AngleOfInclination = value;
                else if (name.Equals("_thrustForce") && _project.Environment != null)
                    _project.Environment.ThrustForce = value;

                Solve();
            }
            else
            {
                if (name.Equals("_massOfLoad"))
                    (sender as TextBox).Text = _project.Load.Mass.ToString();
                else if (name.Equals("_inclineAngle") && _project.Axis1 != null)
                    (sender as TextBox).Text = _project.Axis1.AngleOfInclination.ToString();
                else if (name.Equals("_thrustForce") && _project.Environment != null)
                    (sender as TextBox).Text = _project.Environment.ThrustForce.ToString();
                else if (name.Equals("_profileName") && _project.Profile != null)
                    _mainForm.ProjectList.RenameProfile(text);
            }
        }

        void _solve_Click(object sender, EventArgs e)
        {
            List<Motor> myMotors = _project.ChooseMotor.Motors;

            //myMotors.Sort(delegate(Motor t1, Motor t2) { return (t1.PeakForce.CompareTo(t2.PeakForce)); });
            myMotors.Sort(delegate(Motor t1, Motor t2) { return (t1.ContinuousForce.CompareTo(t2.ContinuousForce)); });

            int i;
            for (i = 0; i < myMotors.Count; i++ )
            {
                _solver.Start(_project.Axis1.Record, myMotors[i], _project.Load, _project.Axis1.Path, _project.Environment);

                if (_project.Axis1.Record.MAXforce < myMotors[i].PeakForce && _project.Axis1.Record.MAXcurrent < myMotors[i].PeakCurrent && _project.Axis1.Record.RMSforce < myMotors[i].ContinuousForce && _project.Axis1.Record.RMScurrent < myMotors[i].ContinuousCurrent)
                //if (_project.Axis1.Record.RMSforce < myMotors[i].ContinuousForce)
                {
                    _dutyCycle.Text = "100";

                    _totalMoveTime.Text = _project.Axis1.Record.Time.Max().ToString("0.####");
                    _lengthOfTravel.Text = _project.Axis1.Record.Position.Max().ToString("0.####");
                    _maxLinearSpeed.Text = _project.Axis1.Record.Velocity.Max().ToString("0.####");
                    _peakAcceleration.Text = _project.Axis1.Record.Acceleration.Max().ToString("0.####");

                    _peakForce.Text = _project.Axis1.Record.MAXforce.ToString("0.####");
                    _totalRMSForce.Text = _project.Axis1.Record.RMSforce.ToString("0.####");
                    _peakCurrent.Text = _project.Axis1.Record.MAXcurrent.ToString("0.####");
                    _continuousCurrent.Text = _project.Axis1.Record.RMScurrent.ToString("0.####");
                    _finalCoilTemperature.Text = (_project.Environment.AmbientTemp + _project.Axis1.Record.TemperatureRise).ToString("0.####");

                    _totalRMSForceForEntireSequence.Text = _project.Axis1.Record.RMSforce.ToString("0.####");

                    _project.Sequence.UpdateSolution();

                    _project.ChooseMotor.Motor = myMotors[i];

                    break;
                }
            }
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

        private TextBox addTextBox(bool readOnly)
        {
            TextBox box = new TextBox();
            box.Dock = DockStyle.Fill;
            box.ReadOnly = readOnly;
            box.TextAlign = HorizontalAlignment.Right;
            box.Leave += new EventHandler(_TextChanged);

            return box;
        }
    }
}
