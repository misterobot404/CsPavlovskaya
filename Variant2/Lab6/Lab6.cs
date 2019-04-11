/*
Дана целочисленная прямоугольная матрица. 
Определить количество столбцов, не содержащих ни одного нулевого элемента.
Характеристикой строки целочисленной матрицы назовём сумму её положительных четных элементов. 
Переставляя строки заданной матрицы, расположить их в соотвествии с ростом характеристик.
 */
using System;

namespace Lab6
{
    class Lab6
    {
        static void Main()
        {
            Console.WriteLine("Создание прямоугольного массива");
            Console.Write("Количество строк: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Количество столбцов: ");
            int columns = int.Parse(Console.ReadLine());
            Console.Clear();

            int[,] matrix = new int[rows, columns];
            Random random = new Random();

            Console.WriteLine("Исходная матрица: ");
            int[] sum = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                sum[i] = 0;
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                    Console.Write("{0, 5}", matrix[i, j]);
                    if (matrix[i, j] > 0 && matrix[i, j] % 2 == 0)
                        sum[i] += matrix[i, j];
                }
                Console.WriteLine(" Сумма положительных четных: {0}", sum[i]);
            }
            Console.WriteLine();

            int count = 0;
            for (int i = 0; i < columns; i++)
            {
                try
                {
                    for (int j = 0; j < rows; j++)
                    {
                        if (matrix[j, i] == 0)
                            throw new ArgumentException();
                    }
                    count++;
                }
                catch (ArgumentException) { }                           
            }
            Console.WriteLine("Количество столбцов, не содержащих ни одного нулевого элемента: {0}", count);
            Console.WriteLine();

            for (int i = 0; i < sum.Length - 1; i++)
            {
                for (int j = i + 1; j < sum.Length; j++)
                    if (sum[i] > sum[j])
                    {
                        int b = sum[i];
                        sum[i] = sum[j];
                        sum[j] = b;
                        for (int m = 0; m < columns; m++)
                        {
                            b = matrix[i, m];
                            matrix[i, m] = matrix[j, m];
                            matrix[j, m] = b;
                        }
                    }
            }

            Console.WriteLine("Новая матрица: ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    Console.Write("{0, 5}", matrix[i, j]);
                Console.WriteLine(" Sum: {0}", sum[i]);
            }

            Console.ReadLine();
        }
    }
}
