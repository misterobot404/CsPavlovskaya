/*
 Описать базовый класс Строка.
 Обязательные поля класса:
 - поле для хранения символов строки;
 - значение типа word для хранения длины строки в байтах.
 Реализовать обязательные методы следующегшо назначения:
 - конструктор без параметров;
 - конструктор,принимающий в качестве параметра символ;
 - конструктор,принимающий в качестве параметра строковый литерал;
 - метод получения длины строки;
 - метод очистки строки (сделать строку пустой);

 Описать производный от класса Строка класс Битовая_Строка.
 Строки данного класса могут содержать только символы '0' или '1'.
 Если в составе инициализирующей строки будут встречены любые символы,
 отличные от допустимых,класс Битовая_строка принимает нулевое значение.
 Содержимое данных строк рассматривается как двоичное число.
 Отрицательные числа хранятся в дополнительном коде.

 Для класса Битовая_строка описать след.методы:
 - конструктор,принимающий в качестве параметра строковый литерал;
 - деструктор;
 - изменение знака на противоположный (перевод числа в дополнительный код);
 - присваивание;
 - вычисление арифметической суммы строк;
 - проверка на равенство;
 В случае необходимости более коротка битовая строка расширяется влево знаковым разрядом.
 */

using System;

namespace Lab9
{
    class Lab9
    {
        private class String
        {
            private int _length;
            private string _str;

            // конструктор без параметров
            public String()
            {
            }

            // конструктор, принимающий в качестве параметра строковый литерал
            public String(string str)
            {
                _str = str;
                _length = str.Length;
            }

            // конструктор, принимающий в качестве параметра символ;
            public String(char ch)
            {
                _str = Convert.ToString(ch);
                _length = 1;
            }

            // Метод возвращающий длинну строки.
            public int GetLength()
            {
                return _length;
            }

            // Метод очищающий стоку.
            public void Clear()
            {
                _str = "";
                _length = 0;
            }

            public override string ToString()
            {
                return _str;
            }
        }

        private class BitString : String
        {
            public bool znak;
            private string _str;
            private int _length;

            // конструктор, принимающий в качестве параметра строковый литерал
            public BitString(string str)
            {                         
                    _str = str;
                    _length = str.Length;
            }
            // деструктор
            ~BitString()
            {
            }

            public override string ToString()
            {
                return _str;
            }

            public static BitString operator +(BitString m1, BitString m2)
            {
                BitString str = new BitString("0000000000000000000");
                char[] a = str._str.ToCharArray();
                for (int i = m1._str.Length - 1; i >= 0; i--)
                    a[i] = Convert.ToString(Convert.ToInt32(Convert.ToString(m1._str[i])) + Convert.ToInt32(Convert.ToString(m2._str[i])))[0];
                for (int i = m1._str.Length - 1; i > 0; i--)
                {

                    if (a[i] == '2')
                    {
                        a[i - 1] = Convert.ToString(Convert.ToInt32(Convert.ToString(a[i - 1])) + 1)[0];
                        a[i] = '0';
                    }
                    if (a[i] == '3')
                    {
                        a[i - 1] = Convert.ToString(Convert.ToInt32(Convert.ToString(a[i - 1])) + 1)[0];
                        a[i] = '1';
                    }


                }
                string g = "";
                for (int i = 0; i < a.Length; i++)
                    g += a[i];
                str._str = g;
                return str;
            }
            public static bool operator ==(BitString m1, BitString m2)
            {
                bool x;
                if (m1._str == m2._str)
                    x = true;
                else x = false;
                return x;
            }
            public static bool operator !=(BitString m1, BitString m2)
            {
                bool x;
                if (m1._str != m2._str)
                    x = true;
                else x = false;
                return x;
            }
            public static BitString Dop_kod(BitString m1)
            {
                char[] a = m1._str.ToCharArray();
                if (m1.znak == false)
                {
                    for (int i = a.Length - 1; i >= 0; i--)
                    {
                        if (a[i] == '0')
                            a[i] = '1';
                        else
                            a[i] = '0';
                    }
                    a[0] = Convert.ToChar(Convert.ToInt32(a[a.Length - 1]) + 1);
                    for (int i = a.Length - 1; i >= 0; i--)
                    {
                        if (a[i] == '2')
                        {
                            a[i - 1] = Convert.ToChar(Convert.ToInt32(a[i]) + 1);
                            a[i] = '0';
                        }
                        if (a[i] == '3')
                        {
                            a[i - 1] = Convert.ToChar(Convert.ToInt32(a[i]) + 1);
                            a[i] = '1';
                        }
                    }


                    m1.znak = true;
                }
                string g = "";
                for (int i = 0; i < a.Length; i++)
                    g += a[i];
                m1._str = g;
                return m1;
            }
            public static BitString Prisvaivanie(string str)
            {
                BitString m1 = new BitString(str);
                return m1;
            }
        }

        static void Main(string[] args)
        {
            BitString m1, m2, m3;
            m1 = BitString.Prisvaivanie("0000000000000110001");
            Console.WriteLine("Битовая строка 1: " + m1.ToString());
            m2 = BitString.Prisvaivanie("0000000000000011001");
            Console.WriteLine("Битовая строка 2: " + m2.ToString());

            Console.Write("\n");
            if (m2 == m1)
                Console.WriteLine("Строки 1 и 2 равны");
            else
                Console.WriteLine("Строки 1 и 2 не равны");

            Console.Write("\n");
            Console.WriteLine("Строка 1 меняет знак на противоположный...");
            m1 = BitString.Dop_kod(m1);
            Console.WriteLine("Строкa 1: " + m1.ToString());

            Console.Write("\n");
            m3 = m1 + m2;
            Console.WriteLine("Складываем 1 и 2 битовые стоки... Ответ: " + m3.ToString());
       
            Console.ReadLine();
        }
    }
}
