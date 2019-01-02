/*
 В одномерном массиве состоящим из n вещественных элементов, вычислить:
 - номер максимального по модулю элемента массива
 - сумму элементов массива, расположенных после первого положительного элемента
 Преобразовать массив таким образом, чтобы сначала распололгались все элементы, 
 целая часть которых лежит в интервале [a,b], а потом - все остальные.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5
{
    class Lab5
    {
        static void Main(string[] args)
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
            double sumElAfterOne = 0;
            for (int i = 0, startSum = 0; i < array.Count; i++)
            {
                if (maxEl < array[i])
                {
                    maxEl = array[i];
                    maxElIndex = i;
                }

                if (startSum == 1)
                    sumElAfterOne += array[i];

                if (array[i] > 0)
                    startSum = 1;
            }
            Console.WriteLine("Индекс максимального элемента: " + maxElIndex);
            Console.WriteLine("Cумма элементов массива, расположенных после первого положительного элемента: " + sumElAfterOne);

            Console.Write("Введите A: ");
            int A = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите B: ");
            int B = Convert.ToInt32(Console.ReadLine());

            List<double> fromAtoB = new List<double>();
            List<double> outAtoB = new List<double>();

            for (int i = 0; i < array.Count; i++)
            {
                if ((int)array[i]>= A && (int)array[i] <= B)
                {
                    fromAtoB.Add(array[i]);
                }
                else
                {
                    outAtoB.Add(array[i]);
                }
            }

            array.Clear();

            for (int i = 0; i < fromAtoB.Count; i++)
                array.Add(fromAtoB[i]);
            for (int i = 0; i < outAtoB.Count; i++)
                array.Add(outAtoB[i]);

            Console.Write("Отсортированный массив: ");
            foreach (var item in array)
                Console.Write(item + " ");

            Console.Read();
        }
    }
}
