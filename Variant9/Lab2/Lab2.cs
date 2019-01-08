using System;

namespace Lab2
{
    class Lab2
    {
        class Task02_2
        {
            public string O(double x, double y, double r)
            {
                string flag = "не попадает";
                if (((y < 0) && (x < 0) && (x * x + y * y < r * r)) || (y > 0) && (x > 0) && (Math.Pow(x - 1, 2)  < y)) flag = "попадает";
                return flag;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Расположение точки");
            while (true)
            {
                Console.Write("Введите X: ");
                double x = double.Parse(Console.ReadLine());
                Console.Write("Введите Y: ");
                double y = double.Parse(Console.ReadLine());
                Console.Write("Введите радиус окружности (R):");
                double R = double.Parse(Console.ReadLine());
                Task02_2 obl = new Task02_2();
                Console.WriteLine("Точка {0}", obl.O(x, y, R));
            }
        }
    }
}
