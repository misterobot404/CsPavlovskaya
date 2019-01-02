/*
 Написать программу, которая считывает текст из файла 
 и выводит на экран только строки, не содержащие двухзначных чисел.
 */
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab7
{
    class Lab7
    {
        static void Main(string[] args)
        {

            Console.Write("Текстовый файл (путь): ");
            string path = Console.ReadLine();
            StreamReader sr = new StreamReader("txt.txt");
            string txt = sr.ReadToEnd();
            string[] masText = txt.Split('\n');

            Regex r = new Regex("[0-9]{2,}");
            foreach (var item in masText)
            {
               if (!(r.IsMatch(item))) Console.WriteLine(item);
            }       
            Console.ReadLine();
        }
    }
}
