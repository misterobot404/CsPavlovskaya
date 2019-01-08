/*
 В одномерном массиве, состоящем из n элементов, вычислить:
 - максимальный по модулю элемент массива;
 - сумму элементов массива, расположенных между первым и вторым положительными элементами.
 Преобразовать массив таким образом, чтобы элементы, равные нулю, располагались после всех остальных
 */

using System;

namespace Lab5
{
    class Lab5
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            int n = Convert.ToInt16(Console.ReadLine());
            int[] array = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(0, 10) - rand.Next(0, 10);
                Console.Write(array[i].ToString() + " ");
            }
            Console.WriteLine();
            int max = Math.Abs(array[0]), sum = 0;
            bool one = false, two = false;
            for (int i = 0; i < n; i++)
            {
                if (max < Math.Abs(array[i]))
                    max = Math.Abs(array[i]);
                if (one && !two)
                    sum += array[i];
                if (array[i] > 0 && !two && !one)
                    one = true;
                else if (array[i] > 0 && one && !two)
                {
                    sum -= array[i];
                    two = true;
                }
            }
            Console.WriteLine("Максимальный по модулю элемент массива: " + max);
            Console.WriteLine("Сумма элементов массива, расположенных между первым и вторым положительными элементами: " + sum);

            Console.WriteLine("Преобразование массива таким образом, чтобы элементы, равные нулю, располагались после всех остальных...");

            for (int i = array.Length-1; i > 0; i--)
            {               
                for (int j = i; j > 0; j--)
                {
                    if (array[j] == 0)
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        break;
                    }
                }
            }

            Console.Write("Отсортированный массив: ");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");

            Console.ReadKey();
        }
    }
}
