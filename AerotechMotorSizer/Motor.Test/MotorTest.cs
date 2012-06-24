using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Motor;

namespace Motor.Test
{
    class MotorTest
    {
        static void Main(string[] args)
        {
            Motor TestMotor = new Motor(1.01,2.01,3.01,4.01,5.01,6.01,7.01);
            Console.WriteLine(TestMotor.Mass);
            Console.WriteLine(TestMotor.MaxTemp);
            Console.WriteLine(TestMotor.MomentOfInertia);
            Console.WriteLine(TestMotor.Resistance);
            Console.WriteLine(TestMotor.Inductance);
            Console.WriteLine(TestMotor.ThermalResistance);
            Console.WriteLine(TestMotor.KT);
            while (true)
            {
            }
        }
    }
}
