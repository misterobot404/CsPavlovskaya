using System;

namespace Lab1
{
    class Lab1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите аргумент к функции (x):");

            double x = double.Parse(Console.ReadLine());

            Task01_1 t1 = new Task01_1();

            Console.WriteLine("Для аргумента x = {0} функции Z1 и Z2 равны:\n\nZ1(x) = {1}\n Z2(x) ={2}\n", x, t1.Z1(x), t1.Z2(x));
            Console.ReadLine();
        }
    }

    class Task01_1
    {
        public double Z1(double x)
        {
            return Math.Pow(Math.Cos(3.0 / 8.0 * Math.PI - x / 4.0), 2.0) -
                   Math.Pow(Math.Cos(11.0 / 8.0 * Math.PI + x / 4.0), 2.0); ;
        }
        public double Z2(double x)
        {
            return Math.Sqrt(2.0) * Math.Sin(x / 2.0) / 2; ;
        }

    }
}
