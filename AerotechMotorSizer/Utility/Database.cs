using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Utility
{
    public class Database
    {
        private List<Motor> _motors;
        private List<Motor> _searchedMotors;
        private string _dbfilename = @"motordb";

        public Database()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Please select a motor database:";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _dbfilename = dialog.FileName;
            }

            string MotorName;
            double MotorForceConstant;
            double MotorMotorConstant;
            double MotorBackEMFConstant;
            double MotorResistance;
            double MotorPeakForce;
            double MotorPeakCurrent;
            double MotorContinuousForce_0psi;
            double MotorContinuousForce_10psi;
            double MotorContinuousForce_20psi;
            double MotorContinuousForce_40psi;
            double MotorContinuousCurrent_0psi;
            double MotorContinuousCurrent_10psi;
            double MotorContinuousCurrent_20psi;
            double MotorContinuousCurrent_40psi;
            double MotorCoilMass;
            double MotorCoilLength;
            double MotorThermalResistance_100CTEMP_0psi;
            double MotorThermalResistance_100CTEMP_10psi;
            double MotorThermalResistance_100CTEMP_20psi;
            double MotorThermalResistance_100CTEMP_40psi;
            double MotorThermalResistance_Catalog_0psi;
            double MotorThermalResistance_Catalog_20psi;
            double MotorThermalResistance_PercentDifference_0psi;
            double MotorThermalResistance_PercentDifference_20psi;

            Motor temp;
            _searchedMotors = new List<Motor>();
            _motors = new List<Motor>();
            const string sql = "select * from Motors;";
            var conn = new SQLiteConnection("Data Source=" + _dbfilename + ";Version=3;");
                conn.Open();
                DataSet ds = new DataSet();
                var da = new SQLiteDataAdapter(sql, conn);
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    MotorName = ds.Tables[0].Rows[i]["Motor"].ToString();
                    MotorForceConstant = Convert.ToDouble(ds.Tables[0].Rows[i]["ForceConstant"].ToString());
                    MotorMotorConstant = Convert.ToDouble(ds.Tables[0].Rows[i]["MotorConstant"].ToString());
                    MotorBackEMFConstant = Convert.ToDouble(ds.Tables[0].Rows[i]["BackEMFConstant"].ToString());
                    MotorResistance = Convert.ToDouble(ds.Tables[0].Rows[i]["Resistance"].ToString());
                    MotorPeakForce = Convert.ToDouble(ds.Tables[0].Rows[i]["PeakForce"].ToString());
                    MotorPeakCurrent = Convert.ToDouble(ds.Tables[0].Rows[i]["PeakCurrent"].ToString());
                    MotorContinuousForce_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_0psi"].ToString());
                    MotorContinuousForce_10psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_10psi"].ToString());
                    MotorContinuousForce_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_20psi"].ToString());
                    MotorContinuousForce_40psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_40psi"].ToString());
                    MotorContinuousCurrent_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_0psi"].ToString());
                    MotorContinuousCurrent_10psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_10psi"].ToString());
                    MotorContinuousCurrent_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_20psi"].ToString());
                    MotorContinuousCurrent_40psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_40psi"].ToString());
                    MotorCoilMass = Convert.ToDouble(ds.Tables[0].Rows[i]["CoilMass"].ToString());
                    MotorCoilLength = Convert.ToDouble(ds.Tables[0].Rows[i]["CoilLength"].ToString());
                    MotorThermalResistance_100CTEMP_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_0psi"].ToString());
                    MotorThermalResistance_100CTEMP_10psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_10psi"].ToString());
                    MotorThermalResistance_100CTEMP_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_20psi"].ToString());
                    MotorThermalResistance_100CTEMP_40psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_40psi"].ToString());
                    MotorThermalResistance_Catalog_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_Catalog_0psi"].ToString());
                    MotorThermalResistance_Catalog_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_Catalog_20psi"].ToString());
                    MotorThermalResistance_PercentDifference_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_PercentDifference_0psi"].ToString());
                    MotorThermalResistance_PercentDifference_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_PercentDifference_20psi"].ToString());
                    temp = new Motor(MotorName, MotorForceConstant, MotorMotorConstant, MotorBackEMFConstant, MotorResistance, MotorPeakForce, MotorPeakCurrent, MotorContinuousForce_0psi, MotorContinuousForce_10psi, MotorContinuousForce_20psi, MotorContinuousForce_40psi, MotorContinuousCurrent_0psi, MotorContinuousCurrent_10psi, MotorContinuousCurrent_20psi, MotorContinuousCurrent_40psi, MotorCoilMass, MotorCoilLength, MotorThermalResistance_100CTEMP_0psi, MotorThermalResistance_100CTEMP_10psi, MotorThermalResistance_100CTEMP_20psi, MotorThermalResistance_100CTEMP_40psi, MotorThermalResistance_Catalog_0psi, MotorThermalResistance_Catalog_20psi, MotorThermalResistance_PercentDifference_0psi, MotorThermalResistance_PercentDifference_20psi);
                    _searchedMotors.Add(temp);
                    _motors.Add(temp);
                }
        }
        public List<Motor> Get(String[,] MotorProperties)
        {
            string MotorName;
            double MotorForceConstant;
            double MotorMotorConstant;
            double MotorBackEMFConstant;
            double MotorResistance;
            double MotorPeakForce;
            double MotorPeakCurrent;
            double MotorContinuousForce_0psi;
            double MotorContinuousForce_10psi;
            double MotorContinuousForce_20psi;
            double MotorContinuousForce_40psi;
            double MotorContinuousCurrent_0psi;
            double MotorContinuousCurrent_10psi;
            double MotorContinuousCurrent_20psi;
            double MotorContinuousCurrent_40psi;
            double MotorCoilMass;
            double MotorCoilLength;
            double MotorThermalResistance_100CTEMP_0psi;
            double MotorThermalResistance_100CTEMP_10psi;
            double MotorThermalResistance_100CTEMP_20psi;
            double MotorThermalResistance_100CTEMP_40psi;
            double MotorThermalResistance_Catalog_0psi;
            double MotorThermalResistance_Catalog_20psi;
            double MotorThermalResistance_PercentDifference_0psi;
            double MotorThermalResistance_PercentDifference_20psi;
            Motor temp;
            _motors = new List<Motor>();
            String WhereSQL="";
            for (int i = 0; i <= MotorProperties.GetUpperBound(0); i++)
            {
                if (i == 0)
                {
                    WhereSQL += " WHERE " + MotorProperties[i, 0] + " " + MotorProperties[i, 1] + " " + MotorProperties[i, 2];
                }
                else
                {
                    WhereSQL += " AND " + MotorProperties[i, 0] + " " + MotorProperties[i, 1] + " " + MotorProperties[i, 2];
                }
            }
            
            string sql = "select * from _motors"+WhereSQL+";";
            Console.WriteLine(sql);
            var conn = new SQLiteConnection("Data Source=" + _dbfilename + ";Version=3;");
            conn.Open();
            DataSet ds = new DataSet();
            var da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                MotorName = ds.Tables[0].Rows[i]["Motor"].ToString();
                MotorForceConstant = Convert.ToDouble(ds.Tables[0].Rows[i]["ForceConstant"].ToString());
                MotorMotorConstant = Convert.ToDouble(ds.Tables[0].Rows[i]["MotorConstant"].ToString());
                MotorBackEMFConstant = Convert.ToDouble(ds.Tables[0].Rows[i]["BackEMFConstant"].ToString());
                MotorResistance = Convert.ToDouble(ds.Tables[0].Rows[i]["Resistance"].ToString());
                MotorPeakForce = Convert.ToDouble(ds.Tables[0].Rows[i]["PeakForce"].ToString());
                MotorPeakCurrent = Convert.ToDouble(ds.Tables[0].Rows[i]["PeakCurrent"].ToString());
                MotorContinuousForce_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_0psi"].ToString());
                MotorContinuousForce_10psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_10psi"].ToString());
                MotorContinuousForce_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_20psi"].ToString());
                MotorContinuousForce_40psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_40psi"].ToString());
                MotorContinuousCurrent_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_0psi"].ToString());
                MotorContinuousCurrent_10psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_10psi"].ToString());
                MotorContinuousCurrent_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_20psi"].ToString());
                MotorContinuousCurrent_40psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_40psi"].ToString());
                MotorCoilMass = Convert.ToDouble(ds.Tables[0].Rows[i]["CoilMass"].ToString());
                MotorCoilLength = Convert.ToDouble(ds.Tables[0].Rows[i]["CoilLength"].ToString());
                MotorThermalResistance_100CTEMP_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_0psi"].ToString());
                MotorThermalResistance_100CTEMP_10psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_10psi"].ToString());
                MotorThermalResistance_100CTEMP_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_20psi"].ToString());
                MotorThermalResistance_100CTEMP_40psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_40psi"].ToString());
                MotorThermalResistance_Catalog_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_Catalog_0psi"].ToString());
                MotorThermalResistance_Catalog_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_Catalog_20psi"].ToString());
                MotorThermalResistance_PercentDifference_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_PercentDifference_0psi"].ToString());
                MotorThermalResistance_PercentDifference_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_PercentDifference_20psi"].ToString());
                temp = new Motor(MotorName, MotorForceConstant, MotorMotorConstant, MotorBackEMFConstant, MotorResistance, MotorPeakForce, MotorPeakCurrent, MotorContinuousForce_0psi, MotorContinuousForce_10psi, MotorContinuousForce_20psi, MotorContinuousForce_40psi, MotorContinuousCurrent_0psi, MotorContinuousCurrent_10psi, MotorContinuousCurrent_20psi, MotorContinuousCurrent_40psi, MotorCoilMass, MotorCoilLength, MotorThermalResistance_100CTEMP_0psi, MotorThermalResistance_100CTEMP_10psi, MotorThermalResistance_100CTEMP_20psi, MotorThermalResistance_100CTEMP_40psi, MotorThermalResistance_Catalog_0psi, MotorThermalResistance_Catalog_20psi, MotorThermalResistance_PercentDifference_0psi, MotorThermalResistance_PercentDifference_20psi);
                _motors.Add(temp);
            }
            return _motors;
        }

        public List<Motor> motors
        {
            get { return _motors; }
            set { _motors = motors; }
        }

        public Boolean Import(String filename)
        {
            List<string[]> parsedData = new List<string[]>();

            try
            {
                using (StreamReader readFile = new StreamReader(filename))
                {
                    string line;
                    string[] row;

                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        parsedData.Add(row);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            for (int i = 0; i < parsedData.Count; i++)
            {
                string sql = "insert into _motors (Motor, ForceConstant, MotorConstant, BackEMFConstant, Resistance, PeakForce, PeakCurrent, ContinuousForce_0psi, ContinuousForce_10psi, ContinuousForce_20psi, ContinuousForce_40psi, ContinuousCurrent_0psi, ContinuousCurrent_10psi, ContinuousCurrent_20psi, ContinuousCurrent_40psi, CoilMass, CoilLength, ThermalResistance_100CTEMP_0psi, ThermalResistance_100CTEMP_10psi, ThermalResistance_100CTEMP_20psi, ThermalResistance_100CTEMP_40psi, ThermalResistance_Catalog_0psi, ThermalResistance_Catalog_20psi, ThermalResistance_PercentDifference_0psi, ThermalResistance_PercentDifference_20psi) values (";
                sql += "'" + parsedData[i][0] + "'" + ", " + parsedData[i][1] + ", " + parsedData[i][2] + ", " + parsedData[i][3] + ", " + parsedData[i][4] + ", " + parsedData[i][5] + ", " + parsedData[i][6] + ", " + parsedData[i][7] + ", " + parsedData[i][8] + ", " + parsedData[i][9] + ", " + parsedData[i][10] + ", " + parsedData[i][11] + ", " + parsedData[i][12] + ", " + parsedData[i][13] + ", " + parsedData[i][14] + ", " + parsedData[i][15] + ", " + parsedData[i][16] + ", " + parsedData[i][17] + ", " + parsedData[i][18] + ", " + parsedData[i][19] + ", " + parsedData[i][20] + ", " + parsedData[i][21] + ", " + parsedData[i][22] + ", " + parsedData[i][23] + ", " + parsedData[i][24]+");";
                var conn = new SQLiteConnection("Data Source=" + _dbfilename + ";Version=3;");
                conn.Open();
                SQLiteCommand sql_cmd = conn.CreateCommand();
                sql_cmd.CommandText = sql;
                sql_cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine(sql);
            }
            return true;
        }

        public Boolean Export(string filename)
        {
            TextWriter file = new StreamWriter(filename, false);
            {
                for (int i = 0; i < _motors.Count; i++) // Loop through List with for
                {
                    file.Write(_motors[i].Name);
                    file.Write(", "+_motors[i].ForceConstant);
                    file.Write(", "+_motors[i].MotorConstant);
                    file.Write(", "+_motors[i].BackEMFConstant);
                    file.Write(", "+_motors[i].Resistance);
                    file.Write(", " + _motors[i].PeakForce);
                    file.Write(", " + _motors[i].PeakCurrent);
                    file.Write(", " + _motors[i].ContinuousForce_0psi);
                    file.Write(", " + _motors[i].ContinuousForce_10psi);
                    file.Write(", " + _motors[i].ContinuousForce_20psi);
                    file.Write(", " + _motors[i].ContinuousForce_40psi);
                    file.Write(", " + _motors[i].ContinuousCurrent_0psi);
                    file.Write(", " + _motors[i].ContinuousCurrent_10psi);
                    file.Write(", " + _motors[i].ContinuousCurrent_20psi);
                    file.Write(", " + _motors[i].ContinuousCurrent_40psi);
                    file.Write(", " + _motors[i].CoilMass);
                    file.Write(", " + _motors[i].CoilLength);
                    file.Write(", " + _motors[i].ThermalResistance_100CTEMP_0psi);
                    file.Write(", " + _motors[i].ThermalResistance_100CTEMP_10psi);
                    file.Write(", " + _motors[i].ThermalResistance_100CTEMP_20psi);
                    file.Write(", " + _motors[i].ThermalResistance_100CTEMP_40psi);
                    file.Write(", " + _motors[i].ThermalResistance_Catalog_0psi);
                    file.Write(", " + _motors[i].ThermalResistance_Catalog_20psi);
                    file.Write(", " + _motors[i].ThermalResistance_PercentDifference_0psi);
                    file.WriteLine(", " + _motors[i].ThermalResistance_PercentDifference_20psi);
                }
                file.Close();
            }
            return true;
        }
    }
}
