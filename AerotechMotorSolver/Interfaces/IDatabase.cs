using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface IDatabase
    {
        void Add(IMotor motor);
        bool Get(out IMotor motor, List<string> parameters);

        /// <summary>
        /// Imports a database from file
        /// </summary>
        /// <param name="file">The file to process</param>
        /// <returns>Returns true if successful, else false</returns>
        bool Import(string file);

        /// <summary>
        /// Exports a database to file
        /// </summary>
        /// <param name="file">The file to create</param>
        /// <returns>Returns true if successful, else false</returns>
        bool Export(string file);
    }
}
