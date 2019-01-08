/*
 Составить описание класса для представления времени. Предусмотреть возможности установки времени и 
 изменения его отдельных полей (час, минута, секунда) с проверкой допустимости вводимых значений. 
 В случае недопустимых значений полей выбрасываются исключения. Создать методы изменения времени на заданное количество часов, минут и секунд.
 Написать программу, демонстрирующую все разработанные элементы класса.
 */

using System;

namespace Lab4
{
    class Lab4
    {
        class Time
        {
            DateTime time;

            public Time(int h, int m, int s)
            {
                if (!DateTime.TryParse(string.Format("{0}:{1}:{2}", h, m, s), out time)) throw new ArgumentException();
            }

            public void AddHour(int hour)
            {
                if (hour > 23 || hour < 0)
                    throw new HoursExcept();
                time = time.AddHours(hour);
            }

            public void AddMinutes(int minutes)
            {
                if (minutes > 59 || minutes < 0)
                    throw new MinutesExcept();
                time = time.AddMinutes(minutes);
            }

            public void AddSecond(int second)
            {
                if (second > 59 || second < 0)
                    throw new SecondsExcept();
                time = time.AddSeconds(second);
            }

            public void ShowInterface()
            {
                Console.WriteLine("1. Добавить часы");
                Console.WriteLine("2. Добавить минуты");
                Console.WriteLine("3. Добавить секунды");
            }

            public override string ToString()
            {
                return time.ToLongTimeString();
            }
        }

        class TimeExcepts : Exception
        {
            public override string Message
            {
                get
                {
                    return "Ошибка изменения значений времени.";
                }
            }
        }
        class HoursExcept : TimeExcepts
        {
            public override string Message
            {
                get
                {
                    return base.Message + " Вы ввели недопустимое значение для переменной Часы.";
                }
            }
        }
        class MinutesExcept : TimeExcepts
        {
            public override string Message
            {
                get
                {
                    return base.Message + " Вы ввели недопустимое значение для переменной Минуты.";
                }
            }
        }
        class SecondsExcept : TimeExcepts
        {
            public override string Message
            {
                get
                {
                    return base.Message + " Вы ввели недопустимое значение для переменной Секунды.";
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Установка начального времени\n");
            Console.Write("Введите часы: ");
            int tempHour = Convert.ToInt16(Console.ReadLine());
            Console.Write("Введите минуты: ");
            int tempMinut = Convert.ToInt16(Console.ReadLine());
            Console.Write("Введите секунды: ");
            int tempSecond = Convert.ToInt16(Console.ReadLine());
            Time t = new Time(tempHour, tempMinut, tempSecond);
           
            while (true)
            {
                Console.WriteLine("Текущее время " + t.ToString());
                t.ShowInterface();
                try
                {
                    Console.Write("Введите номер пункта меню ");
                    switch (Convert.ToInt16(Console.ReadLine()))
                    {
                        case 1:
                            Console.Write("Количество часов: ");
                            t.AddHour(Convert.ToInt16(Console.ReadLine()));
                            break;
                        case 2:
                            Console.Write("Количество минут: ");
                            t.AddMinutes(Convert.ToInt16(Console.ReadLine()));
                            break;
                        case 3:
                            Console.Write("Количество секунд: ");
                            t.AddSecond(Convert.ToInt16(Console.ReadLine()));
                            break;
                        default:
                            break;
                    }
                }
                catch (TimeExcepts e)
                {
                    Console.WriteLine(e.Message);
                }
            }                     
        }
    }
}
