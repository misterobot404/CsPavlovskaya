/*
В одномерном массиве , состоящем из n вещественных элементов вычислить
1)	сумму положительных элементов массива
2)	произведение элементов массива , расположенных между максимальным по модулю и минимальным по модулю элементами.
Упорядочить элементы массива по убыванию.
 */

using System;

namespace Lab5
{
    class Lab5
    {
        static void Main(string[] args)
        {
            Console.Write("Количество элементов массива: ");
            int arraySize = Convert.ToInt32(Console.ReadLine());

            double[] array = new double[arraySize];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Значение {0} элемента: ", i+1);
                array[i] = Convert.ToDouble(Console.ReadLine()); ;
            }

            Console.Write("Введенный массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" " + array[i]);
            }
            Console.WriteLine();

            ///
            double tempSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0) tempSum += array[i];
            }
            Console.WriteLine("Cумма положительных элементов массива: {0}", tempSum);

            ///
            double result = array[0];
            int maxind = 0, minind = 0;
            double max = array[0], min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) > Math.Abs(max))
                {
                    max = array[i];
                    maxind = i;
                }
                if (Math.Abs(array[i]) < Math.Abs(min))
                {
                    min = array[i];
                    minind = i;
                }
            }
            if (maxind > minind)
            {
                for (int i = minind; i < maxind; i++)
                    result *= array[i];
            }
            else
            {
                for (int i = maxind; i < minind; i++)
                    result *= array[i];
            }
            Console.WriteLine("Произведение элементов массива , расположенных между максимальным по модулю и минимальным по модулю элементами: {0}", result);

            Console.ReadLine();
        }
    }
}
