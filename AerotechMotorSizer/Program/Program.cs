using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Utility;
using Interfaces;

namespace Program
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());
        //}

        [STAThread]
        static void Main()
        {
            ParameterSetConverterDialog dialog = new ParameterSetConverterDialog();

            double a = dialog.ConvertertedSet.AccelerationTime;
            double b = dialog.ConvertertedSet.DeccelerationTime;
            double[] c = dialog.ConvertertedSet.Position;

            // Main program currently disabled
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
