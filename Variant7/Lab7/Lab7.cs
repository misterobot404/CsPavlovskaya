/*
 Написать программу, которая считывает текст из файла и определяет, сколько в нем слов, состоящих из не более чем четырех букв.
 */
using System;
using System.IO;

namespace Lab7
{
    class Lab7
    {
        static void Main(string[] args)
        {
            int wordsCount = 0;
            StreamReader reader = new StreamReader("my.txt");
            string[] words = reader.ReadToEnd().Split(' ');
            for (int i = 0; i < words.Length; i++)
                if (words[i].Length < 5)
                    wordsCount++;
            Console.WriteLine("Количество слов не более 4 букв: " + wordsCount);
            Console.Read();
        }
    }
}
