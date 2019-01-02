/*
Для заданной матрицы размером 8 на 8 найти такие k, что k-я строка матрицы совпадает с k-м столбцом. 
Найти сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент.
 */
using System;

namespace Lab6
{
    class Lab6
    {
        static void Main(string[] args)
        {
            int n = 8, m = 8;
            int[,] mas = new int[n, m];

            Random ran = new Random();

            // Инициализируем данный массив
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mas[i, j] = ran.Next(-1, 3);                    
                }
            }

            for (int i = 0; i < n; i++)
            {
                mas[i, 4] = 0;
            }

            for (int j = 0; j < m; j++)
            {
                mas[4, j] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}\t", mas[i, j]);
                }
                Console.WriteLine();
            }

            bool equal = false;

            for (int i = 0; i < n; ++i)
            {
                equal = true;

                for (int j = 0; j < n; ++j)
                {
                    if (mas[i, j] != mas[j, i])
                    {
                        equal = false;
                        break;
                    }
                }

                if (equal)
                {
                    Console.WriteLine("k = {0}", i);
                }
            }

            for (int i = 0; i < n; ++i)
            {
                int sum = 0;
                bool negative = false;

                for (int j = 0; j < n; ++j)
                {
                    sum += mas[i, j];

                    if (mas[i, j] < 0) negative = true;
                }

                if (negative)
                {
                    Console.WriteLine("stroka " + i + ": summa = " + sum);
                }
            }
            Console.Read();
        }
    }
}