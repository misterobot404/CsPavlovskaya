using System;
using System.Collections.Generic;

namespace Lab11
{
    class Lab11
    {
        public class Str : IComparable<Str>
        {
            private int length;
            private string str;

            // конструктор без параметро
            public Str()
            {
            }

            // конструктор, принимающий в качестве параметра строковый литерал
            public Str(string str)
            {
                this.str = str;
                length = str.Length;
            }

            // конструктор, принимающий в качестве параметра символ;
            public Str(char ch)
            {
                str = Convert.ToString(ch);
                length = 1;
            }

            // Метод возвращающий длинну строки.
            public int getLength()
            {
                return length;
            }

            // Метод очищающий стоку.
            public void Clear()
            {
                str = "";
                length = 0;
            }

            public override string ToString()
            {
                return str; 
            }

            public int CompareTo(Str obj)
            {
                if (this.length > obj.length)
                    return 1;
                if (this.length < obj.length)
                    return -1;
                else
                    return 0;
            }
        }

        class ComplexNumber : Str
        {
            private int firstPart;
            private string separator = "i";
            private int secondPart;

            public ComplexNumber() : base()
            {
            }

            // конструктор, принимающий в качестве параметра строковый литерал
            public ComplexNumber(string str)
            {
                string[] words = str.Split(new char[] { separator[0] });
                firstPart = Convert.ToInt32(words[0]);
                secondPart = Convert.ToInt32(words[1]);
            }

            public ComplexNumber(int first, int second)
            {
                firstPart = first;
                secondPart = second;
            }

            public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
            {
                return new ComplexNumber(c1.firstPart + c2.firstPart, c1.secondPart + c2.secondPart);
            }

            public override string ToString()
            {
                return firstPart.ToString() + separator + secondPart.ToString();
            }
        }

        static void Main(string[] args)
        {
            ComplexNumber cmpxOne = new ComplexNumber(15, -30);
            ComplexNumber cmpxTwo = new ComplexNumber(-50, +40);         
            Console.WriteLine(cmpxOne.ToString());
            Console.WriteLine(cmpxTwo.ToString());
            Console.WriteLine((cmpxOne + cmpxTwo).ToString());

            Console.Write("Количество слов: ");
            int size = Convert.ToInt16(Console.ReadLine());
            List<Str> strList = new List<Str>(size);
            for (int i = 0; i < size; i++)
            {
                Console.Write("Введите " + (i+1) +" слово: ");
                strList.Add(new Str(Console.ReadLine()));
            }

            Console.WriteLine("Сортировка массива, используя интерфейс IComparable...");
            strList.Sort();

            foreach (var item in strList)
                Console.WriteLine(item.ToString());

            Console.ReadLine();
        }
    }
}
