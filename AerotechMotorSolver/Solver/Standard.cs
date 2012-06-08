using System;
using System.Collections.Generic;
using System.Text;

namespace MotorSolver
{
    public class Standard
    {
        // Global (class) variables prefaced
        // with "_", first character lowercase,
        // then camel case
        private int _global;
        private float _globalTwo;

        // Use keywords for int,float,etc
        // and objects for strings
        public String _pubString;

        // Constructor - capitalized
        public Standard()
        {
        }

        // methods - camelCase
        public void simpleMethod()
        {
        }

        // If over 100 characters, wrap signature to next lne
        private int thisIsALongNameForAMethod(int one, int two, int three, int four, long five,
                                              long six, long seven)
        {
            return _global;
        }

        // capital
        public int Global
        {
            get { return _global; }
            set { _global = value; }
        }

        // camelCase
        public float GlobalTwo
        {
            get
            {
                if (_globalTwo > 0)
                    return _globalTwo;
                return 0;
            }
        }
    }
}
