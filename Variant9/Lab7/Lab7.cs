/*
 Написать программу, которая считывает текст из файла и выводит на экран только предложения, состоящие из заданного количества.
 */

using System;
using System.IO;

namespace Lab7
{
    class Lab7
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к файлу (перетащите файл в консоль для автоматического определения пути): ");       
            string[] text = File.ReadAllText(Console.ReadLine()).Split('.', '?', '!');
            Console.Write("Количество слов: ");
            int Count = int.Parse(Console.ReadLine());
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = text[i].Trim();
                string[] words = text[i].Split(' ');
                if (words.Length == Count)
                    Console.WriteLine(text[i]);
            }
            Console.ReadKey(true);
        }
    }
}
