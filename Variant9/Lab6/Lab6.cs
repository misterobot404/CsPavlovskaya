/*
 Соседями элемента в матрице Aij назовем элементы Аkl ; i-1 ≤ k≤ i+1, j-1 ≤ l ≤ j+1,(k,l) ≠ (i,j). 
 Операция сглаживания матрицы дает новую матрицу того же размера, каждый элемент которой получается как среднее арифметическое имеющихся соседей соответствующего элемента исходной матрицы. 
 Построить результат сглаживания заданной вещественной матрицы размером 10 х 10. 
 В сглаженной матрице найти сумму модулей элементов, расположенных ниже главной диагонали.
 */
using System;

namespace Lab6
{
    class Lab6
    {
        static void Main(string[] args)
        {
            Random ranf = new Random();
            double[,] mas = new double[10, 10];

            Console.WriteLine("Исходная матрица");
            // заполнение массива случайными числами в пределах 10-100
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = ranf.Next(10, 100);
                    Console.Write(" {0}", mas[i, j]);
                }
                Console.WriteLine();
            }

            double[,] newmas = new double[mas.GetLength(0), mas.GetLength(1)];
            double sum = 0;


            //  создание нового массива "newmas", с исходного массива 
            //  "mas" путем "сглаживаниия"
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Новая матрица, созданная с исходного массива путём \"Сглаживания\"");
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (j == 0 || j == 9)
                        newmas[i, j] = mas[i, j];

                    else newmas[i, j] = (mas[i, j - 1] + mas[i, j + 1]) / 2;

                    Console.Write(" {0}", newmas[i, j]);
                }
                Console.WriteLine();
            }
            // поиск элементов под главной диагональю матрицы и
            // подсчета их суммы
            Console.WriteLine("--------------------------------");
            for (int i = 1; i < mas.GetLength(0); i++)
            {
                for (int j = 1; j < mas.GetLength(1); j++)
                {
                    if (i == j)
                        sum += Math.Abs(newmas[i, j - 1]);
                }
            }
            Console.WriteLine("Сумма модулей элементов, расположенных ниже главной диагонали в \"сглаженной\" матрице = {0}", sum);
            Console.ReadLine();
        }
    }
}
