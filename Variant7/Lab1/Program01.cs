using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите аргумент к функции (x):");

            double x = double.Parse(Console.ReadLine());

            Task01_1 t1 = new Task01_1();

            Console.WriteLine("Для аргумента x = {0} функции Z1 и Z2 равны:\n\nZ1(x) = {1}\n Z2(x) ={2}\n", x, t1.Z1(x), t1.Z2(x));
        }
    }
}