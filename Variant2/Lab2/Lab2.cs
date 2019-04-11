using System;

namespace Lab2
{
    class Lab2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1.\n Введите аргумент к функции (x):");

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            Task02_1 func = new Task02_1();


            Console.WriteLine("\n Для аргумента х = {0} функция f равна: f(x) = {1}\n\nЗадание 2.\n Введите координаты (a;b), ограничивающие область попадания:\n", x, func.F(x));

            Console.WriteLine("\n Введите радиус окружности (R):\n");

            double R = double.Parse(Console.ReadLine());

            Console.WriteLine("\n Введите координаты точки попадания в область (х;у):\n");         


            Task02_2 obl = new Task02_2();

            Console.WriteLine("\n Для координат {0} и {2} точка в область {1}", x,obl.O(x, y, R),y);
            Console.ReadLine();
        }
    }

    class Task02_1
    {
        public double F(double x)
        {
            double y = 0;

            if (x < -7 || x > 11) { /*Console.WriteLine("Функция не определена при данном аргументе");*/ return double.NaN; }

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

    class Task02_2
    {

        public string O(double x, double y, double R)
        {
            string flag = "не попадает";

            if ((((x + R) * (x + R) + (y - R) * (y - R)) <= (R * R)) || ((x >= -1) && (x <= 2 * R) && (y >= -R) && (y <= 0))) flag = "попадает";

            return flag;
        }

    }
}
