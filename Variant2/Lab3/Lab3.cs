using System;

namespace Lab3
{
    class Lab3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1.\n Введите начальное х(xn), конечное х(xk) и шаг dx:\n");

            double xn = double.Parse(Console.ReadLine());
            double xk = double.Parse(Console.ReadLine());
            double dx = double.Parse(Console.ReadLine());

            Task03_1 func = new Task03_1();

            Console.WriteLine("          Таблица Значений Функции");
            Console.WriteLine("\n______________________________________________");
            Console.WriteLine("|         x          |          f(x)          |" +
                              "\n______________________________________________");

            double x = xn;
            while (x <= xk)
            {
                Console.WriteLine("        {0}             {1}      ", x, func.One(x));
                x += dx;
            }

            Console.WriteLine("\n______________________________________________");

            ///Задание 2
            Console.WriteLine("\n\nЗадание 2.\n Введите координаты (x;y), ограничивающие область попадания:\n");

            double X = double.Parse(Console.ReadLine());
            double Y = double.Parse(Console.ReadLine());

            Console.WriteLine("\n Введите радиус окружности (R):\n");

            double R = double.Parse(Console.ReadLine());

            Task03_2 obl = new Task03_2();

            Console.WriteLine("\n Введите координаты точки попадания в область (х;у):\n");

            for (int q = 0; q < 1; q++)
            {

                Console.WriteLine("{0}\n", obl.Two(X, Y, R));

            }
        }
    }
    class Task03_1
    {
        public double One(double x)
        {
            double y = 0;

            if (x < -7 || x > 11) { return double.NaN; }

            else
            {


                if (x < -7) y = 0;
                if (x >= -7 && x < -3) y = 3;
                if (x >= -3 && x < 3) y = -Math.Sqrt(9 - x * x) + 3;
                if (x >= 3 && x < 6) y = -2 * x + 9;
                if (x >= 6 && x < 11) y = x - 9;
                if (x >= 11) y = 2;

                return y;
            }
        }
    }
    class Task03_2
    {
        public string Two(double x, double y, double R)
        {
            string flag = "Не попадает";

            if ((((x + R) * (x + R) + (y - R) * (y - R)) <= (R * R))

            || ((x >= -1) && (x <= 2 * R) && (y >= -R) && (y <= 0))) flag = "Попадает";

            return flag;
        }
    }
}
