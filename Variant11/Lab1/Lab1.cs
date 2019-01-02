using System;

namespace Lab
{
    class Lab1
    {
        public static double Z1(double a)
        {
            return (1 - 2 * Math.Pow(Math.Sin(a), 2)) /

                   (1 + (Math.Sin(2 * a)));

        }
        public static double Z2(double a)
        {
            return (1 - (Math.Tan(a))) /
                    (1 + (Math.Tan(a)));
        }

        static void Main(string[] args)
        {
            Console.Write("Введите A: ");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Для аргумента x = {0} Функции Z1 и Z2 равны: \n \n Z1(x) = {1} \n Z2(x) = {2} \n", a, Z1(a), Z2(a));
            Console.ReadLine();
        }
    }
}
