/*
В одномерном массиве, состоящем из n целых элементов, вычислить: 
1) номер максимального элемента массива; 
2) произведение элементов массива, расположенных между первым и вторым нулевыми элементами. 
Преобразовать массив таким образом, чтобы в первой его половине располагались элементы, стоявшие в нечетных позициях, а во второй половине - элементы, стоявшие в четных позициях.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5
{
    class Lab5
    {
        static void Main()
        {
            Console.Write("Введите количество элементов масива: ");
            int length = Convert.ToInt32(Console.ReadLine());
            List<double> array = new List<double>(length);
            for (int i = 0; i < length; i++)
            {
                Console.Write("Введите значение: ");
                array.Add(Convert.ToDouble(Console.ReadLine()));
            }
            Console.Write("Введенный массив: ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");

            int maxElIndex = 0;
            double maxEl = 0;
            for (int i = 0; i < array.Count; i++)
            {
                if (maxEl < array[i])
                {
                    maxEl = array[i];
                    maxElIndex = i;
                }
            }
            Console.WriteLine("Индекс максимального элемента: " + maxElIndex);

            int zeroCount = 0;
            double sum = 1;
            foreach (var item in array)
            {
                if (item == 0)
                    zeroCount++;

                if (zeroCount == 1)
                    if (item != 0)
                        sum *= item;
            }

            if (zeroCount>0)
                Console.WriteLine("Произведение элементов массива, расположенных между первым и вторым нулевыми элементами: " + sum);
            else
                Console.WriteLine("Нулей меньше двух");

            List<double> even = new List<double>();
            List<double> notEven = new List<double>();

            for (int i = 0; i < array.Count; i++)
            {
                if ((i % 2) == 0)
                {
                    even.Add(array[i]);
                }
                else
                {
                    notEven.Add(array[i]);
                }
            }

            array.Clear();

            for (int i = 0; i < notEven.Count; i++)
                array.Add(notEven[i]);
            for (int i = 0; i < even.Count; i++)
                array.Add(even[i]);

            Console.Write("Отсортированный массив (нечетные в первой половине, четные во второй): ");
            foreach (var item in array)
                Console.Write(item + " ");

            Console.Read();
        }
    }
}
