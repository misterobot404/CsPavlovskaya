using System;

namespace Lab3
{
    class Lab3
    {
        static void Main()
        {
            double eps, x, xlim, dx;
            do
            {
                Console.WriteLine("Введите X0 : |X0| < 1");
            } while (!Double.TryParse(Console.ReadLine(), out x) || Math.Abs(x) >= 1);
            do
            {
                Console.WriteLine("Введите X : X0 < X < 1");
            } while (!Double.TryParse(Console.ReadLine(), out xlim) || xlim <= x);
            do
            {
                Console.WriteLine("Введите dx");
            } while (!Double.TryParse(Console.ReadLine(), out dx) || dx > Math.Abs(1 - x));
            do
            {
                Console.WriteLine("Введите 0 < eps < 1");
            } while (!Double.TryParse(Console.ReadLine(), out eps) || eps >= 1 || eps <= 0);
            for (; x < xlim; x += dx)
            {
                double a = x;
                double s = 0;
                int n = 1;
                int iter = 0;
                for (; Math.Abs(Math.Atan(x) - s) > eps && iter < 1000; n++, iter++)
                {
                    if((x % 2) == 0)
                    {
                        s = s - a;
                    }
                    else
                    {
                        s = s + a;
                    }                  
                    a = (2 * n + 1) / (2 * n + 1);
                }
                if (s == 0) s = x;
                if (iter > 1000)
                {
                    Console.WriteLine("x = " + x + " ряд расходится (>1000 итераций)");
                    break;
                }

                Console.WriteLine("x = {0:f} сумма {1} вычислена с точностью {2} за {3} итераци" + ((n % 10 == 1 && n / 10 != 1) ? "ю" : (n % 10 > 1 && n % 10 < 5 && n / 10 != 1) ? "и" : "й"), x, s, eps, n);
            }
            Console.ReadKey();
        }
    }
}
