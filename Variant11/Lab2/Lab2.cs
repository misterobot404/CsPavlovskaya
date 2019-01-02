using System;

namespace Lab2
{
    class Lab2
    {
        public static string shot(double x, double y, double R)
        {
            string flag = "не попадает";

            if (((Math.Pow(x, 2) + Math.Pow(y, 2) <= (R * R)) && (y <= x) && (x <= 0)) ||
               ((Math.Pow(x, 2) + Math.Pow(y, 2) <= (R * R)) && (y >= x) && (x >= 0))) flag = "попадает";

            return flag;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите радиус окружности (R): ");
                double R = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите координат точки попадания в область (х;у):");
                Console.Write("Введите X: ");
                double X = double.Parse(Console.ReadLine());
                Console.Write("Введите Y: ");
                double Y = double.Parse(Console.ReadLine());
                Console.WriteLine("Для координат ({0};{1}) точка в область {2}.", X, Y, shot(X, Y, R));
            }
        }
    }
}
