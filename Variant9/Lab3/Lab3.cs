using System;

namespace Lab3
{
    class Lab3
    {
        public static double One(double x)
        {
            double y = 0;
            if (x < -9 || x > 7) { return double.NaN; }
            else
            {
                if (x >= -9 && x <= -7) y = 0;
                if (x > -7 && x < -3) y = (-4 * x -28)/-4;
                if (x >= -3 && x <= -2) y = 4;
                if (x > -2 && x <= 2) y = x * x; 
                if (x > 2 && x < 4) y = (4 * x - 16) /-2;
                if (x >= 4 && x <= 7) y = 0;
                return y;
            }
        }
        static void Main()
        {
            Console.WriteLine("Введите X начальное (xn), X конечное (xk) и шаг dx:\n");

            double xn = double.Parse(Console.ReadLine());
            double xk = double.Parse(Console.ReadLine());
            double dx = double.Parse(Console.ReadLine());

            Console.WriteLine("          Таблица Значений Функции");
            Console.WriteLine("\n_____________________________________________\n");
            Console.WriteLine("|         x           |          f(x)        |" +
                              "\n_____________________________________________\n");

            double x = xn;
            while (x <= xk)
            {
                Console.WriteLine("        {0}             {1}      ", x, One(x));
                x += dx;
            }
            Console.WriteLine("\n______________________________________________");
            Console.ReadLine();
        }
    }

    class Task3
    {
        Task3()
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
                    if ((x % 2) == 0)
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
