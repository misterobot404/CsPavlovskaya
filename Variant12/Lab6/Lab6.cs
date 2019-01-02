/*
 Уплотнить заданную матрицу, удаляя из неё столбцы, заполненные нулями.
 Найти номер первой из строк, содержащих хотя бы один положительный элемент.
 */

using System;
using System.Collections.Generic;

namespace Lab6
{
    class Lab6
    {
        static void Main(string[] args)
        {
            int[,] mas = {
                            {-3,-5,0,-8,-1,0},
                             {2,1,0,-9,-5,0},
                             {0,0,0,0,0,0},
                             {7,8,0,-3,3,0},
                             {0,0,0,0,0,0},
                             {9,1,0,-9,-5,0},
                             {0,0,0,0,0,0},
                        };
            // получаем кол-во строк 
            int length1 = mas.GetLength(0);
            // получаем кол-во столбцов 
            int length2 = mas.GetLength(1);
            //объявляем коллекции для хранения нулевых строк и столбцов
            List<int> ls1 = new List<int>();
            List<int> ls2 = new List<int>();

            Console.WriteLine("======Исходная матрица=========");
            // выводим матрицу на консоль и находим нулевые строки
            for (int i = 0; i < length1; ++i)
            {
                bool b = false;
                for (int j = 0; j < length2; ++j)
                {
                    if (mas[i, j] >= 0)
                        Console.Write("  " + mas[i, j]);
                    else Console.Write(" " + mas[i, j]);
                    if (mas[i, j] != 0) b = true;
                }
                if (!b) ls1.Add(i);
                Console.WriteLine();
            }
            //  находим нулевые столбцы
            for (int i = 0; i < length2; ++i)
            {
                bool b = false;
                for (int j = 0; j < length1; ++j)
                {

                    if (mas[j, i] != 0) b = true;
                }
                if (!b) ls2.Add(i);

            }
            //  Удаляем нулевые строки и столбцы и находим номер первой из строк (начиная с нуля),
            // содержащих хотя бы один положительный элемент
            bool B = false; int? Istr = null;
            Console.WriteLine("======Удаляем нулевые строки и столбцы=========");
            for (int i = 0; i < length1; ++i)
            {
                if (!ls1.Contains(i))
                {
                    for (int j = 0; j < length2; ++j)
                    {
                        if (!ls2.Contains(j))
                        {
                            if (mas[i, j] >= 0)
                            {
                                if (!B)
                                {
                                    Istr = i;
                                    B = true;
                                }
                                Console.Write("  " + mas[i, j]);
                            }
                            else Console.Write(" " + mas[i, j]);
                        }

                    }

                }
                if (!ls1.Contains(i))
                    Console.WriteLine();
            }
            Console.WriteLine("Hомер первой из строк (начиная с нуля), содержащих хотя бы один положительный элемент -> {0}", Istr);
            Console.ReadKey();
        }
    }
}
