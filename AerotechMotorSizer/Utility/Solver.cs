using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Interfaces;

namespace MotorSolver
{
    public class Solver : ISolver
    {
        private IRecord myRecord;
        private IMotor myMotor;
        private ILoad myLoad;
        private IPath myPath;
        private string projectDirectory;

        /// <summary>
        /// Start a simulation
        /// </summary>
        /// <param name="initial">The initial state</param>
        /// <param name="motor">The motor object</param>
        /// <param name="load">The load</param>
        /// <param name="path">The path</param>
        public bool Start(IRecord initial, IMotor motor, ILoad load, IPath path)
        {
            myRecord = initial;
            myMotor = motor;
            myLoad = load;
            myPath = path;

            int count = myRecord.Time.Length;

            if (myRecord.Time == null || (myRecord.Position == null && myRecord.Velocity == null && myRecord.Acceleration == null))
                return false;

            if (myRecord.Acceleration == null)
                myRecord.Acceleration = new double[count];

            if (myRecord.Velocity == null)
                myRecord.Velocity = new double[count];

            if (myRecord.Position == null)
                myRecord.Position = new double[count];

            myRecord.RMSforce = Math.Pow(myLoad.Mass * myRecord.Acceleration[0], 2);

            if (myRecord.Acceleration != null)
            {
                for (int i = 1; i < count; i++)
                   myRecord.RMSforce += Math.Pow(myLoad.Mass * myRecord.Acceleration[i], 2);
            }
            else if (myRecord.Velocity != null)
            {
                for (int i = 1; i < count; i++)
                {
                    myRecord.Acceleration[i] = (myRecord.Velocity[i] - myRecord.Velocity[i - 1]) / (myRecord.Time[i] - myRecord.Time[i - 1]);
                    myRecord.RMSforce += Math.Pow(myLoad.Mass * myRecord.Acceleration[i], 2);
                }
            }
            else
            {
                for (int i = 1; i < count; i++)
                {
                    myRecord.Velocity[i] = (myRecord.Position[i] - myRecord.Position[i - 1]) / (myRecord.Time[i] - myRecord.Time[i - 1]);
                    myRecord.Acceleration[i] = (myRecord.Velocity[i] - myRecord.Velocity[i - 1]) / (myRecord.Time[i] - myRecord.Time[i - 1]);
                    myRecord.RMSforce += Math.Pow(myLoad.Mass * myRecord.Acceleration[i], 2);
                }
            }

            myRecord.RMSforce = Math.Sqrt(myRecord.RMSforce / count);
            myRecord.MAXforce = myLoad.Mass * myRecord.Acceleration.Max();
            myRecord.RMScurrent = myMotor.KT * myRecord.RMSforce;
            myRecord.MAXcurrent = myMotor.KT * myRecord.MAXforce;
            myRecord.TemperatureRise = Math.Pow(myRecord.RMSforce / myMotor.KT, 2) * myMotor.ThermalResistance;

            Write();

            return true;
        }

        public bool Stop()
        {
            return false;
        }

        public bool Write()
        {
            if (myRecord == null)
                return false;

            projectDirectory = "C:\\Users\\John\\Desktop";
            StreamWriter outfile = new StreamWriter(projectDirectory + "\\output.txt");

            outfile.WriteLine("Project Name");
            outfile.WriteLine("Motor Name");
            outfile.WriteLine("Load");
            outfile.WriteLine("Mass:               " + myLoad.Mass);
            outfile.WriteLine("Moment of Intertia: " + myLoad.MomentOfInertia);
            outfile.WriteLine("Max Temperature: " + myLoad.MaxTemperature);
            outfile.WriteLine("\nAxis Name");
            outfile.WriteLine("t\tx\tv\ta");

            for (int i = 0; i < myRecord.Time.Length; i++)
            {
                outfile.WriteLine(myRecord.Time[i] + "\t" + myRecord.Position[i] + "\t" + myRecord.Velocity[i] + "\t" + myRecord.Acceleration[i]);
            }

            outfile.Close();

            return true;
        }
    }
}