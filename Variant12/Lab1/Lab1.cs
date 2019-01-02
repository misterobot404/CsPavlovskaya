using System;

namespace Lab1
{
    class Lab1
    {
        static void Main(string[] args)
        {
            Console.Write("Введите a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            double Z1 = Math.Sin(4.0 * a) / (1 + Math.Cos(4.0 * a)) * (Math.Cos(2.0 * a) / (1.0 + Math.Cos(2.0 * a)));
            double Z2 = 1.0 / Math.Tan(3.0 / 2.0 * Math.PI - a);
            //double Z3 = Math.Cos(3.0 / 2.0 * Math.PI - a) / Math.Sin(3.0 / 2.0 * Math.PI - a);
            Console.Write("Z1 = {0}\nZ2 = {1}", Z1, Z2);
            Console.Read();
        }
    }
}
