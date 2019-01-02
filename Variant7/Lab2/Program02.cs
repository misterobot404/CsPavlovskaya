using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine ("Задание 1.\n Введите аргумент к функции (x):");

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            Task02_1 func = new Task02_1();
           
           
            Console.WriteLine("\n Для аргумента х = {0} функция f равна: f(x) = {1}\n\nЗадание 2.\n Введите координаты (a;b), ограничивающие область попадания:\n", x, func.F(x));
          
            Console.WriteLine("\n Введите радиус окружности (R):\n");

            double R = double.Parse(Console.ReadLine());

            Console.WriteLine("\n Введите координаты точки попадания в область (х;у):\n");


          
            Task02_2 obl = new Task02_2();

            Console.WriteLine("\n Для координат ({0};{2}) точка в область {1}.", obl.O ( x, y, R));
        }
    }
}
