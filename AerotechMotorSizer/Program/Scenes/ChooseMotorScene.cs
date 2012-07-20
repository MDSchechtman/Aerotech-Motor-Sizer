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
    public class ChooseMotorScene
    {
        private TableLayoutPanel _panel;
        private string _fileName;
        private MainForm _mainForm;

        private Dictionary<string, string[]> _unitLists;

        private Label _stageLabel;
        private Label _motorLabel;
        private Label _peakForceLabel;
        private Label _continuousForceLabel;
        private Label _forceConstantLabel;
        private Label _motorConstantLabel;
        private Label _backEMFLabel;
        private Label _hotCoilResistanceLabel;
        private Label _thermalResistanceLabel;
        private Label _coilMassLabel;
        private Label _coilLengthLabel;
        private Label _movingMassLabel;
        private Label _totalStageMassLabel;

        private TextBox _stage;
        private TextBox _motor;
        private TextBox _peakForce;
        private TextBox _continuousForce;
        private TextBox _forceConstant;
        private TextBox _motorConstant;
        private TextBox _backEMF;
        private TextBox _hotCoilResistance;
        private TextBox _thermalResistance;
        private TextBox _coilMass;
        private TextBox _coilLength;
        private TextBox _movingMass;
        private TextBox _totalStageMass;

        private ComboBox _stageUnits;
        private ComboBox _motorUnits;
        private ComboBox _peakForceUnits;
        private ComboBox _continuousForceUnits;
        private ComboBox _forceConstantUnits;
        private ComboBox _motorConstantUnits;
        private ComboBox _backEMFUnits;

        private Label _hotCoilResistanceUnits;
        private Label _thermalResistanceUnits;

        private ComboBox _coilMassUnits;
        private ComboBox _coilLengthUnits;
        private ComboBox _movingMassUnits;
        private ComboBox _totalStageMassUnits;

        public ChooseMotorScene(MainForm mainForm)
        {
            _mainForm = mainForm;
            _panel = new TableLayoutPanel();

            Initialize();
        }

        public string Name
        {
            get { return _motorUnits.SelectedText; }
        }

        public TableLayoutPanel Component
        {
            get { return _panel; }
        }

        private void Initialize()
        {
            _panel = new TableLayoutPanel();
            _panel.Dock = DockStyle.Fill;
            _panel.RowCount = 13;
            _panel.ColumnCount = 3;

            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
            _panel.RowStyles.Add(new RowStyle(SizeType.Percent, 1.0F / 13.0F));
           
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0F / 3.0F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0F / 3.0F));
            _panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.0F / 3.0F));

            _unitLists = new Dictionary<string, string[]>();
            _unitLists.Add("length", new string[] { "m", "mm", "cm", "in", "ft" });
            _unitLists.Add("mass", new string[] { "kg", "g", "lb" });
            _unitLists.Add("time", new string[] { "s", "ms", "min" });
            _unitLists.Add("angle", new string[] { "rad", "deg", "rev" });
            _unitLists.Add("percent", new string[] { "fraction", "%" });
            _unitLists.Add("force", new string[] { "N", "lb" });
            _unitLists.Add("force constant", new string[] { "N/ A(peak)", "lb/ A(peak)" });
            _unitLists.Add("motor constant", new string[] { "N/ \x221AW", "lb/ \x221AW" });
            _unitLists.Add("emf", new string[] { "V/(m/s)", "V/(in/s)" });
            _unitLists.Add("velocity", new string[] { "m/s", "mm/s", "m/min", "in/s", "in/min" });
            _unitLists.Add("acceleration", new string[] { "m/s^2", "mm/s^2", "m/min^2", "in/s^2", "in/min^2", "g" });
            _unitLists.Add("temperature", new string[] { "\x00B0C", "\x00B0F", "K" });

            _stageLabel = addLabel("Stage");
            _motorLabel = addLabel("Motor");
            _peakForceLabel = addLabel("Peak Force");
            _continuousForceLabel = addLabel("Continuous Force");
            _forceConstantLabel = addLabel("Force Constant");
            _motorConstantLabel = addLabel("Motor Constant");
            _backEMFLabel = addLabel("Back EMF");
            _hotCoilResistanceLabel = addLabel("Hot Coil Resistance");
            _thermalResistanceLabel = addLabel("Thermal Resistance");
            _coilMassLabel = addLabel("Coil Mass");
            _coilLengthLabel = addLabel("Coil Length");
            _movingMassLabel = addLabel("Moving Mass");
            _totalStageMassLabel = addLabel("Total Stage Mass");

            _stage = new TextBox();
            _motor = new TextBox();
            _peakForce = new TextBox();
            _continuousForce = new TextBox();
            _forceConstant = new TextBox();
            _motorConstant = new TextBox();
            _backEMF = new TextBox();
            _hotCoilResistance = new TextBox();
            _thermalResistance = new TextBox();
            _coilMass = new TextBox();
            _coilLength = new TextBox();
            _movingMass = new TextBox();
            _totalStageMass = new TextBox();

            _stage.Dock = DockStyle.Fill;
            _motor.Dock = DockStyle.Fill;
            _peakForce.Dock = DockStyle.Fill;
            _continuousForce.Dock = DockStyle.Fill;
            _forceConstant.Dock = DockStyle.Fill;
            _motorConstant.Dock = DockStyle.Fill;
            _backEMF.Dock = DockStyle.Fill;
            _hotCoilResistance.Dock = DockStyle.Fill;
            _thermalResistance.Dock = DockStyle.Fill;
            _coilMass.Dock = DockStyle.Fill;
            _coilLength.Dock = DockStyle.Fill;
            _movingMass.Dock = DockStyle.Fill;
            _totalStageMass.Dock = DockStyle.Fill;

            _stage.Enabled = false;
            _motor.Enabled = false;
            _peakForce.Enabled = false;
            _continuousForce.Enabled = false;
            _forceConstant.Enabled = false;
            _motorConstant.Enabled = false;
            _backEMF.Enabled = false;
            _hotCoilResistance.Enabled = false;
            _thermalResistance.Enabled = false;
            _coilMass.Enabled = false;
            _coilLength.Enabled = false;
            _movingMass.Enabled = false;
            _totalStageMass.Enabled = false;

            _stageUnits = fillComboBox("force", 0);
            _motorUnits = fillComboBox("force", 0);
            _peakForceUnits = fillComboBox("force", 0);
            _continuousForceUnits = fillComboBox("force", 0);
            _forceConstantUnits = fillComboBox("force constant", 0);
            _motorConstantUnits = fillComboBox("motor constant", 0);
            _backEMFUnits = fillComboBox("emf", 0);

            _hotCoilResistanceUnits = addLabel("\x03A9");
            _thermalResistanceUnits = addLabel("\x00B0C/W");

            _coilMassUnits = fillComboBox("mass", 0);
            _coilLengthUnits = fillComboBox("length", 1);
            _movingMassUnits = fillComboBox("mass", 0);
            _totalStageMassUnits = fillComboBox("mass", 0);

            _panel.Controls.Add(_stageLabel, 0, 0);
            _panel.Controls.Add(_motorLabel, 0, 1);
            _panel.Controls.Add(_peakForceLabel, 0, 2);
            _panel.Controls.Add(_continuousForceLabel, 0, 3);
            _panel.Controls.Add(_forceConstantLabel, 0, 4);
            _panel.Controls.Add(_motorConstantLabel, 0, 5);
            _panel.Controls.Add(_backEMFLabel, 0, 6);
            _panel.Controls.Add(_hotCoilResistanceLabel, 0, 7);
            _panel.Controls.Add(_thermalResistanceLabel, 0, 8);
            _panel.Controls.Add(_coilMassLabel, 0, 9);
            _panel.Controls.Add(_coilLengthLabel, 0, 10);
            _panel.Controls.Add(_movingMassLabel, 0, 11);
            _panel.Controls.Add(_totalStageMassLabel, 0, 12);


            //_panel.Controls.Add(_stage, 1, 0);
            //_panel.Controls.Add(_motor, 1, 1);
            _panel.Controls.Add(_peakForce, 1, 2);
            _panel.Controls.Add(_continuousForce, 1, 3);
            _panel.Controls.Add(_forceConstant, 1, 4);
            _panel.Controls.Add(_motorConstant, 1, 5);
            _panel.Controls.Add(_backEMF, 1, 6);
            _panel.Controls.Add(_hotCoilResistance, 1, 7);
            _panel.Controls.Add(_thermalResistance, 1, 8);
            _panel.Controls.Add(_coilMass, 1, 9);
            _panel.Controls.Add(_coilLength, 1, 10);
            _panel.Controls.Add(_movingMass, 1, 11);
            _panel.Controls.Add(_totalStageMass, 1, 12);

            _panel.Controls.Add(_stageUnits, 1, 0);
            _panel.SetColumnSpan(_stageUnits, 2);
            _panel.Controls.Add(_motorUnits, 1, 1);
            _panel.SetColumnSpan(_motorUnits, 2);
            _panel.Controls.Add(_peakForceUnits, 2, 2);
            _panel.Controls.Add(_continuousForceUnits, 2, 3);
            _panel.Controls.Add(_forceConstantUnits, 2, 4);
            _panel.Controls.Add(_motorConstantUnits, 2, 5);
            _panel.Controls.Add(_backEMFUnits, 2, 6);
            _panel.Controls.Add(_hotCoilResistanceUnits, 2, 7);
            _panel.Controls.Add(_thermalResistanceUnits, 2, 8);
            _panel.Controls.Add(_coilMassUnits, 2, 9);
            _panel.Controls.Add(_coilLengthUnits, 2, 10);
            _panel.Controls.Add(_movingMassUnits, 2, 11);
            _panel.Controls.Add(_totalStageMassUnits, 2, 12);
        }

        private ComboBox fillComboBox(string units, int selectedItem)
        {
            ComboBox box = new ComboBox();
            string[] unitList = _unitLists[units];
            for (int i = 0; i < unitList.Length; i++)
                box.Items.Add(string.Format(unitList[i]));
            box.Width = 2000;
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
