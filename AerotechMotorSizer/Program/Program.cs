using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using ParameterSet;
using Interfaces;

namespace Program
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ParameterSetDialog dialog = new ParameterSetDialog();

            IParameterSet parameterSet = dialog.ParameterSet;

            // Main program currently disabled
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
