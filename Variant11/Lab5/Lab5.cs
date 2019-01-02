/*
В одномерном массиве, состоящем из n вещественных элементов, вычислить:
 - номер минимального по модулю элемента массива;
 - сумму модулей элементов массива, расположенных после первого отрицательного элемента.
 Сжать массив, удалив из него все элементы, величина которых находится в интервале [a,b]. 
 Освободившийся в конце массива элементы заполнить нулями.
 */
using System;

namespace Lab5
{
    class Lab5
    {
        static void Main(string[] args)
        {
            Console.Write("Размер массива: ");
            int masLenght = Convert.ToInt16(Console.ReadLine());

            Random random = new Random();             
            double[] array = new double[masLenght];

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Введите " + (i + 1) + " элемент: ");
                array[i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.Write("Массив: ");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.Write("\n");

            int indexMinAbs = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if(Math.Abs(array[indexMinAbs]) > Math.Abs(array[i]))
                    indexMinAbs = i;
            }
            Console.WriteLine("Номер минимального по модулю элемента массива: " + indexMinAbs);

            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        sum += Math.Abs(array[j]);
                    }
                    Console.WriteLine("Сумма модулей элементов массива после первого отрицательного: " + sum);
                    break;
                }
            }

            Console.Write("A: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("B: ");
            double b = Convert.ToDouble(Console.ReadLine());

            int iy = 0, ji = iy;
            for (; iy < array.Length; iy++)
            {
                if (array[iy] < a || array[iy] > b)
                    array[iy - ji] = array[iy];
                else
                    ji++;
            }
            for (iy = array.Length - ji; iy < array.Length; iy++)
                array[iy] = 0;

            Console.Write("Массив: ");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.ReadKey();
        }
    }
}
