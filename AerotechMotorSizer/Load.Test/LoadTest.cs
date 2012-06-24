using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Load;

namespace Load.Test
{
    class LoadTest
    {
        static void Main(string[] args)
        {
            Load TestLoad = new Load(1.01, 2.01);
            Console.WriteLine(TestLoad.Mass);
            Console.WriteLine(TestLoad.MomentOfInertia);
            while (true)
            {
            }
        }
    }
}
