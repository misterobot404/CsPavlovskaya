/*
 Написать программу, которая считывает текст из файла 
 и выводит на экран только предложения, начинающиеся с тире, 
 перед которым могут находиться только пробельные символы.
 */

using System;
using System.IO;

namespace Lab7
{
    class Lab7
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllText("text.txt").Split('.','!','?');
            foreach (string item in text)
                if(item.Trim()[0] == '-')
                    Console.WriteLine(item.Trim());
            Console.Read();
        }
    }
}

