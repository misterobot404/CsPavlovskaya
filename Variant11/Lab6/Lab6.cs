/*
Коэффициенты системы линейных уравнений заданы в виде прямоугольной матрицы. 
С помощью допустимых преобразований привести систему к треугольному виду.
Найти количество строк, среднее арифметическое элементов которых меньше заданной величины.
*/

using System;

namespace Lab6
{
    class Lab6
    {
        static void ToTriangle(double[,] matrix)
        {
            double n = matrix.GetLength(0);
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                {
                    double koef = matrix[j, i] / matrix[i, i];
                    for (int k = i; k < n; k++)
                        matrix[j, k] -= matrix[i, k] * koef;
                }
        }
        static void Print(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                    Console.Write("{0:0.0}\t", matrix[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int n = 3;
            double[,] matrix = new double[n, n];

            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                    matrix[i, j] = random.Next(1, 9);

            Print(matrix);
            Console.WriteLine("Задача: найти количество строк, среднее арифметическое элементов которых меньше заданной величины");
            Console.Write("Введите среднее арифметическое: ");
            double avrArfmt = Convert.ToDouble(Console.ReadLine());
            int countLine = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double sum = 0;               
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[i,j];
                }
                if ((sum / matrix.GetLength(0)) < avrArfmt) countLine++;
            }
            Console.WriteLine("Количество строк, удовлетворяющие условию: " + countLine);

            Console.WriteLine("Преобразуем матрицу к треугольному виду...");
            ToTriangle(matrix);
            Print(matrix);
            Console.ReadKey();
        }
    }
}
