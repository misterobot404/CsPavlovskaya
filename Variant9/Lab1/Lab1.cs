using System;

namespace Lab1
{
    class Lab1
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число A: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите число B: ");
            double b = Convert.ToDouble(Console.ReadLine());

            double z1 = Math.Pow(Math.Cos(a) - Math.Cos(b), 2) - Math.Pow(Math.Sin(a) - Math.Sin(b), 2);
            double z2 = -4 * Math.Pow(Math.Sin((a - b) / 2.0), 2) * Math.Cos(a + b);

            Console.WriteLine("z1 = " + z1);
            Console.WriteLine("z2 = " + z2);

            Console.Read();
        }
    }
}
