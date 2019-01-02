using System;

namespace Lab3
{
    class Task03_1
    {
        public double One(double x)
        {
            double y = 0;
            if (x < -3 || x > 5) { return double.NaN; }
            else
            {
                if (x < -3) y = 0;
                if (x >= -3 && x < -2) y = -x - 2;
                if (x >= -2 && x < -1) y = +Math.Sqrt(1 - Math.Pow(x, 2 + 1));
                if (x >= -1 && x < 1) y = 1;
                if (x >= 1 && x < 2) y = 3 - 2;
                if (x >= 2 && x < 5) y = -1;
                if (x >= 5) y = 0;

                return y;
            }
        }

        class Lab3
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Введите X начальное (xn), X конечное (xk) и шаг dx:\n");

                double xn = double.Parse(Console.ReadLine());
                double xk = double.Parse(Console.ReadLine());
                double dx = double.Parse(Console.ReadLine());

                Task03_1 func = new Task03_1();

                Console.WriteLine("          Таблица Значений Функции");
                Console.WriteLine("\n_____________________________________________\n");
                Console.WriteLine("|         x           |          f(x)        |" +
                                  "\n_____________________________________________\n");

                double x = xn;
                while (x <= xk)
                {
                    Console.WriteLine("        {0}             {1}      ", x, func.One(x));
                    x += dx;
                }
                Console.WriteLine("\n______________________________________________");
                Console.ReadLine();
            }
        }
    }
}
