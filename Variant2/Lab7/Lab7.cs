/*
Написать программу, которая считывает текст из файла и выводит на экран только предложения, 
содержащие введенное с клавиатуры слово.
*/
using System;
using System.IO;

namespace Lab7
{
    class Lab7
    {
        static void Main(string[] args)
        {
            Console.Write("Файл: ");
            string text = File.ReadAllText(Console.ReadLine());
            string[] sentences = text.Split('.', '?', '!');

            Console.Write("Искомое слово: ");
            string word = Console.ReadLine();

            foreach (string sent in sentences)
                if (sent.Contains(word))
                    Console.WriteLine(sent);

            Console.ReadLine();
        }
    }
}
