using System;

namespace Lab9
{
    class Lab9
    {
        static void Main(string[] args)
        {
            ComplexNumber cmpxOne = new ComplexNumber(15, -30);
            ComplexNumber cmpxTwo = new ComplexNumber(-50, +40);
            Console.WriteLine(cmpxOne.ToString());
            Console.WriteLine(cmpxTwo.ToString());
            Console.WriteLine((cmpxOne + cmpxTwo).ToString());
            Console.ReadLine();
        }
    }

    /*
    Описать базовый класс Строка.
    Обязательные поля класса:
    •   поле для хранения символов строки;
    •   значение типа word для хранения длины строки в байтах.

    Реализовать обязательные методы следующего назначения:
    •   конструктор без параметров;
    •   конструктор, принимающий в качестве параметра строковый литерал;
    •   конструктор, принимающий в качестве параметра символ;
    •   метод получения длины строки;
    •   метод очистки строки (сделать строку пустой).
     */

    public class Str
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
    }

    /*
     Описать производный от Строка класс Комплексное_число. 
     Строки данного класса состоят из двух полей, разделенных символом i. 
     Первое поле задает значение действительной части числа, второе значение мнимой. 
     Каждое из полей может содержать только символы десятичных цифр и символы - и +, задающие знак числа.
     Символы - или + могут находиться только в первой позиции числа, причем символ + может отсутствовать, в этом случае число считается положительным.
     Если в составе инициализирующей строки будут встречены любые символы, отличные от допустимых, класс Комплексное_число принимает нулевое значение. 

     Пример строк:
     33i12
     -7i100
     +5i - 21

    Для класса Комплексное_число определить следующие методы:
    •   проверка на равенство;
    •   сложение чисел;
    •   умножение чисел.
     */
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
            return new ComplexNumber ( c1.firstPart + c2.firstPart, c1.secondPart + c2.secondPart);
        }

        public override string ToString()
        {
            return firstPart.ToString() + separator + secondPart.ToString();
        }
    }

}
