using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    interface IState
    {
        public enum State
        {
            Stopped,
            Running
        }

        public State GetState();
    }
}
