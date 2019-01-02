using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab03
{
    class Program
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

             Console.WriteLine("{0}\n", obl.Two (X, Y, R));

            }
                      
        }
    }
}
