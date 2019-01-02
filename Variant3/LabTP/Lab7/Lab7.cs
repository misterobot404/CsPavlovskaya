using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab7
{
    class Lab7
    {
        static void Main(string[] args)
        {
            FileStream fin;
            string s;
            try
            {
                fin = new FileStream("test.txt", FileMode.Open);
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.Message +
                "Не удается открыть файл.");
                return;
            }
            StreamReader fstr_in = new StreamReader(fin);

            var reg = new Regex(@"([1-9]{1}\d){1}");
            while ((s = fstr_in.ReadLine()) != null)
            {
                if (reg.IsMatch(s))
                    Console.WriteLine(s);
            }

            fstr_in.Close();
            Console.ReadLine();
        }
    }
}