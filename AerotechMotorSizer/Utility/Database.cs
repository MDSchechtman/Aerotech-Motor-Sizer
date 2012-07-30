using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;


namespace Utility
{
    public class Database
    {
        private List<Motor> Motors;
        private List<Motor> SearchedMotors;
        private string dbfilename = @"C:\Users\Nathan\Documents\GitHub\Aerotech-Motor-Sizer\AerotechMotorSizer\motordb";
        
        
        /// <summary>
        /// Loads all motors from the database into the Motors List
        /// </summary>
        public Database()
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
            Motors = new List<Motor>();
            const string sql = "select * from Motors;";
            var conn = new SQLiteConnection("Data Source=" + dbfilename + ";Version=3;");
            conn.Open();
            DataSet ds = new DataSet();
            var da = new SQLiteDataAdapter(sql, conn);
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                MotorName = ds.Tables[0].Rows[i]["Motor"].ToString();
                MotorForceConstant = 0.0;
                MotorMotorConstant = 0.0;
                MotorBackEMFConstant = 0.0;
                MotorResistance = 0.0;
                MotorPeakForce = 0.0;
                MotorPeakCurrent = 0.0;
                MotorContinuousForce_0psi = 0.0;
                MotorContinuousForce_10psi = 0.0;
                MotorContinuousForce_20psi = 0.0;
                MotorContinuousForce_40psi = 0.0;
                MotorContinuousCurrent_0psi = 0.0;
                MotorContinuousCurrent_10psi = 0.0;
                MotorContinuousCurrent_20psi = 0.0;
                MotorContinuousCurrent_40psi = 0.0;
                MotorCoilMass = 0.0;
                MotorCoilLength = 0.0;
                MotorThermalResistance_100CTEMP_0psi = 0.0;
                MotorThermalResistance_100CTEMP_10psi = 0.0;
                MotorThermalResistance_100CTEMP_20psi = 0.0;
                MotorThermalResistance_100CTEMP_40psi = 0.0;
                MotorThermalResistance_Catalog_0psi = 0.0;
                MotorThermalResistance_Catalog_20psi = 0.0;
                MotorThermalResistance_PercentDifference_0psi = 0.0;
                MotorThermalResistance_PercentDifference_20psi = 0.0;
                MotorForceConstant = Convert.ToDouble(ds.Tables[0].Rows[i]["ForceConstant"].ToString());
                MotorMotorConstant = Convert.ToDouble(ds.Tables[0].Rows[i]["MotorConstant"].ToString());
                MotorBackEMFConstant = Convert.ToDouble(ds.Tables[0].Rows[i]["BackEMFConstant"].ToString());
                MotorResistance = Convert.ToDouble(ds.Tables[0].Rows[i]["Resistance"].ToString());
                MotorPeakForce = Convert.ToDouble(ds.Tables[0].Rows[i]["PeakForce"].ToString());
                if (ds.Tables[0].Rows[i]["PeakCurrent"].ToString().Length != 0)
                    MotorPeakCurrent = Convert.ToDouble(ds.Tables[0].Rows[i]["PeakCurrent"].ToString());
                MotorContinuousForce_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_0psi"].ToString());
                MotorContinuousForce_10psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_10psi"].ToString());
                MotorContinuousForce_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_20psi"].ToString());
                MotorContinuousForce_40psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousForce_40psi"].ToString());
                if (ds.Tables[0].Rows[i]["ContinuousCurrent_0psi"].ToString().Length != 0)
                    MotorContinuousCurrent_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_0psi"].ToString());
                if (ds.Tables[0].Rows[i]["ContinuousCurrent_10psi"].ToString().Length != 0)
                    MotorContinuousCurrent_10psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_10psi"].ToString());
                if (ds.Tables[0].Rows[i]["ContinuousCurrent_20psi"].ToString().Length != 0)
                    MotorContinuousCurrent_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_20psi"].ToString());
                if (ds.Tables[0].Rows[i]["ContinuousCurrent_40psi"].ToString().Length != 0)
                    MotorContinuousCurrent_40psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ContinuousCurrent_40psi"].ToString());
                MotorCoilMass = Convert.ToDouble(ds.Tables[0].Rows[i]["CoilMass"].ToString());
                MotorCoilLength = Convert.ToDouble(ds.Tables[0].Rows[i]["CoilLength"].ToString());
                if (ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_0psi"].ToString().Length != 0)
                    MotorThermalResistance_100CTEMP_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_0psi"].ToString());
                if (ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_10psi"].ToString().Length != 0)
                    MotorThermalResistance_100CTEMP_10psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_10psi"].ToString());
                if (ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_20psi"].ToString().Length != 0)
                    MotorThermalResistance_100CTEMP_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_20psi"].ToString());
                if (ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_40psi"].ToString().Length != 0)
                    MotorThermalResistance_100CTEMP_40psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_100CTEMP_40psi"].ToString());
                if (ds.Tables[0].Rows[i]["ThermalResistance_Catalog_0psi"].ToString().Length != 0)
                    MotorThermalResistance_Catalog_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_Catalog_0psi"].ToString());
                if (ds.Tables[0].Rows[i]["ThermalResistance_Catalog_20psi"].ToString().Length != 0)
                    MotorThermalResistance_Catalog_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_Catalog_20psi"].ToString());
                if (ds.Tables[0].Rows[i]["ThermalResistance_PercentDifference_0psi"].ToString().Length != 0)
                    MotorThermalResistance_PercentDifference_0psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_PercentDifference_0psi"].ToString());
                if (ds.Tables[0].Rows[i]["ThermalResistance_PercentDifference_20psi"].ToString().Length != 0)
                    MotorThermalResistance_PercentDifference_20psi = Convert.ToDouble(ds.Tables[0].Rows[i]["ThermalResistance_PercentDifference_20psi"].ToString());
                temp = new Motor(MotorName, MotorForceConstant, MotorMotorConstant, MotorBackEMFConstant, MotorResistance, MotorPeakForce, MotorPeakCurrent, MotorContinuousForce_0psi, MotorContinuousForce_10psi, MotorContinuousForce_20psi, MotorContinuousForce_40psi, MotorContinuousCurrent_0psi, MotorContinuousCurrent_10psi, MotorContinuousCurrent_20psi, MotorContinuousCurrent_40psi, MotorCoilMass, MotorCoilLength, MotorThermalResistance_100CTEMP_0psi, MotorThermalResistance_100CTEMP_10psi, MotorThermalResistance_100CTEMP_20psi, MotorThermalResistance_100CTEMP_40psi, MotorThermalResistance_Catalog_0psi, MotorThermalResistance_Catalog_20psi, MotorThermalResistance_PercentDifference_0psi, MotorThermalResistance_PercentDifference_20psi);
                Motors.Add(temp);
            }
        }

        /// <summary>
        /// Searches the database for certain motors and add them to the SearchedMotors List
        /// </summary>
        /// <param name="MotorProperties">A two dimensional array of size [x,2]. [x,0] is the name of the paramater as it is spelled in the database. [x,1] is the value you wish to search for that parameter</param>
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
            SearchedMotors = new List<Motor>();
            String WhereSQL = "";
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

            string sql = "select * from Motors" + WhereSQL + ";";
            Console.WriteLine(sql);
            var conn = new SQLiteConnection("Data Source=" + dbfilename + ";Version=3;");
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
                SearchedMotors.Add(temp);
            }
            return Motors;
        }
        public List<Motor> motors
        {
            get { return Motors; }
            set { Motors = value; }
        }

        public List<Motor> motorResults
        {
            get { return SearchedMotors; }
            set { SearchedMotors = value; }
        }

        /// <summary>
        /// Imports motors from a csv file into the database
        /// </summary>
        /// <param name="filename">A path to the csv file</param>
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
                string sql = "insert into Motors (Motor, ForceConstant, MotorConstant, BackEMFConstant, Resistance, PeakForce, PeakCurrent, ContinuousForce_0psi, ContinuousForce_10psi, ContinuousForce_20psi, ContinuousForce_40psi, ContinuousCurrent_0psi, ContinuousCurrent_10psi, ContinuousCurrent_20psi, ContinuousCurrent_40psi, CoilMass, CoilLength, ThermalResistance_100CTEMP_0psi, ThermalResistance_100CTEMP_10psi, ThermalResistance_100CTEMP_20psi, ThermalResistance_100CTEMP_40psi, ThermalResistance_Catalog_0psi, ThermalResistance_Catalog_20psi, ThermalResistance_PercentDifference_0psi, ThermalResistance_PercentDifference_20psi) values (";
                sql += "'" + parsedData[i][0] + "'" + ", " + parsedData[i][1] + ", " + parsedData[i][2] + ", " + parsedData[i][3] + ", " + parsedData[i][4] + ", " + parsedData[i][5] + ", " + parsedData[i][6] + ", " + parsedData[i][7] + ", " + parsedData[i][8] + ", " + parsedData[i][9] + ", " + parsedData[i][10] + ", " + parsedData[i][11] + ", " + parsedData[i][12] + ", " + parsedData[i][13] + ", " + parsedData[i][14] + ", " + parsedData[i][15] + ", " + parsedData[i][16] + ", " + parsedData[i][17] + ", " + parsedData[i][18] + ", " + parsedData[i][19] + ", " + parsedData[i][20] + ", " + parsedData[i][21] + ", " + parsedData[i][22] + ", " + parsedData[i][23] + ", " + parsedData[i][24] + ");";
                var conn = new SQLiteConnection("Data Source=" + dbfilename + ";Version=3;");
                conn.Open();
                SQLiteCommand sql_cmd = conn.CreateCommand();
                sql_cmd.CommandText = sql;
                sql_cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine(sql);
            }
            return true;
        }

        /// <summary>
        /// Updates a selected motor in the database
        /// </summary>
        public Boolean Update(String Name, String newName, double PeakForce, double ContinuousForce_0psi, double ContinuousForce_10psi, double ContinuousForce_20psi, double ContinuousForce_40psi, double ForceConstant, double MotorConstant, double BackEMFConstant, double Resistance, double CoilMass, double CoilLength)
        {

                string sql = "update Motors SET Motor='"+newName+"', PeakForce="+PeakForce+", ContinuousForce_0psi="+ContinuousForce_0psi+", ContinuousForce_10psi="+ContinuousForce_10psi+", ContinuousForce_20psi="+ContinuousForce_20psi+", ContinuousForce_40psi="+ContinuousForce_40psi+", ForceConstant="+ForceConstant+", BackEMFConstant="+BackEMFConstant+", Resistance="+Resistance+", CoilMass="+CoilMass+", CoilLength="+CoilLength+", MotorConstant="+MotorConstant+" WHERE Motor='"+Name+"'";
                var conn = new SQLiteConnection("Data Source=" + dbfilename + ";Version=3;");
                conn.Open();
                SQLiteCommand sql_cmd = conn.CreateCommand();
                sql_cmd.CommandText = sql;
                sql_cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine(sql);
            return true;
        }

        /// <summary>
        /// Adds a motor to the database
        /// </summary>
        public Boolean Add(String newName, double PeakForce, double ContinuousForce_0psi, double ContinuousForce_10psi, double ContinuousForce_20psi, double ContinuousForce_40psi, double ForceConstant, double MotorConstant, double BackEMFConstant, double Resistance, double CoilMass, double CoilLength)
        {

            string sql = "insert into Motors (Motor, PeakForce, ContinuousForce_0psi, ContinuousForce_10psi, ContinuousForce_20psi, ContinuousForce_40psi, ForceConstant, BackEMFConstant, Resistance, CoilMass, CoilLength, MotorConstant) values ('" + newName + "', " + PeakForce + ", " + ContinuousForce_0psi + ", " + ContinuousForce_10psi + ", " + ContinuousForce_20psi + ", " + ContinuousForce_40psi + ", " + ForceConstant + ", " + BackEMFConstant + ", " + Resistance + ", " + CoilMass + ", " + CoilLength + ", " + MotorConstant + ")";
            var conn = new SQLiteConnection("Data Source=" + dbfilename + ";Version=3;");
            conn.Open();
            SQLiteCommand sql_cmd = conn.CreateCommand();
            sql_cmd.CommandText = sql;
            sql_cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine(sql);
            return true;
        }

        /// <summary>
        /// Deletes a motor from the database
        /// </summary>
        /// <param name="Name">The Name of the Motor to Delete</param>
        public Boolean Delete (String Name)
        {

            string sql = "delete from Motors WHERE Motor='" + Name + "'";
            var conn = new SQLiteConnection("Data Source=" + dbfilename + ";Version=3;");
            conn.Open();
            SQLiteCommand sql_cmd = conn.CreateCommand();
            sql_cmd.CommandText = sql;
            sql_cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine(sql);
            return true;
        }

        /// <summary>
        /// Export the motors from the database to a csv file
        /// </summary>
        /// <param name="initial">Path of the csv file</param>
        public Boolean Export(string filename)
        {
            TextWriter file = new StreamWriter(filename, false);
            {
                for (int i = 0; i < Motors.Count; i++) // Loop through List with for
                {
                    file.Write(Motors[i].Name);
                    file.Write(", " + Motors[i].ForceConstant);
                    file.Write(", " + Motors[i].MotorConstant);
                    file.Write(", " + Motors[i].BackEMFConstant);
                    file.Write(", " + Motors[i].Resistance);
                    file.Write(", " + Motors[i].PeakForce);
                    file.Write(", " + Motors[i].PeakCurrent);
                    file.Write(", " + Motors[i].ContinuousForce_0psi);
                    file.Write(", " + Motors[i].ContinuousForce_10psi);
                    file.Write(", " + Motors[i].ContinuousForce_20psi);
                    file.Write(", " + Motors[i].ContinuousForce_40psi);
                    file.Write(", " + Motors[i].ContinuousCurrent_0psi);
                    file.Write(", " + Motors[i].ContinuousCurrent_10psi);
                    file.Write(", " + Motors[i].ContinuousCurrent_20psi);
                    file.Write(", " + Motors[i].ContinuousCurrent_40psi);
                    file.Write(", " + Motors[i].CoilMass);
                    file.Write(", " + Motors[i].CoilLength);
                    file.Write(", " + Motors[i].ThermalResistance_100CTEMP_0psi);
                    file.Write(", " + Motors[i].ThermalResistance_100CTEMP_10psi);
                    file.Write(", " + Motors[i].ThermalResistance_100CTEMP_20psi);
                    file.Write(", " + Motors[i].ThermalResistance_100CTEMP_40psi);
                    file.Write(", " + Motors[i].ThermalResistance_Catalog_0psi);
                    file.Write(", " + Motors[i].ThermalResistance_Catalog_20psi);
                    file.Write(", " + Motors[i].ThermalResistance_PercentDifference_0psi);
                    file.WriteLine(", " + Motors[i].ThermalResistance_PercentDifference_20psi);
                }
                file.Close();
            }
            return true;
        }
    }
}
