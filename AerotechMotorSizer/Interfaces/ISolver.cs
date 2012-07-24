using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    public interface ISolver
    {
        /// <summary>
        /// Start a simulation
        /// </summary>
        /// <param name="initial">The initial state</param>
        /// <param name="motor">The motor object</param>
        /// <param name="load">The load</param>
        /// <param name="path">The path</param>
        bool Start(IRecord initial, IMotor motor, ILoad load, IPath path);

        /// <summary>
        /// Writes information pertaining to the solver to file
        /// </summary>
        /// <returns></returns>
        bool Write();
    }
}
