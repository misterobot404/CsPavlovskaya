/*
 Описать структуру с именем TRAIN, содержащую следующие поля: 
- название пункта назначения; 
- номер поезда; 
- время отправления. 
Написать программу, выполняющую следующие действия: 
- ввод с клавиатуры данных в массив, состоящий из восьми элементов типа TRAIN 
(записи должны быть упорядочены по по названиям пунктов назначения); 
- вывод на экран информации о поездах, отправляющихся после введенного с клавиатуры времени 
(если таких поездов нет, вывести соответствующее сообщение).
 */
using System;
using System.Collections.Generic;

namespace Lab10
{
    public struct Train
    {
        string name;
        public int number;
        public string date;

        public Train(string name, int number, string date)
        {
            this.name = name;
            this.number = number;
            this.date = date;
        }

        public static int Compare(Train first, Train second)
        {
            return first.name.CompareTo(second.name);
        }

        public override string ToString()
        {
            return String.Format("Название пункта назначения " + this.name + " \nНомер поезда " + number + " \nВремя отправления " + date);
        }
    }

    class Lab10
    {
        static void Main()
        {
            List<Train> nL = new List<Train>();

            for (int i = 0; i < 2; i++)
            {
                Console.Write("Введите название пункта назначения: ");
                string tempName = Console.ReadLine();
                Console.Write("Введите номер поезда: ");
                int tempNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите время отправления: ");
                string tempTime = Console.ReadLine();
                nL.Add(new Train(tempName, tempNumber, tempTime));
            }

            foreach (Train c in nL)
            {
                Console.WriteLine(c.ToString());
            }

            Console.WriteLine("\nСортируем по пунктам назначения");
            nL.Sort(Train.Compare);

            foreach (Train c in nL)
            {
                Console.WriteLine(c.ToString());
            }


            Console.WriteLine("Вывод на экран информации о поездах, отправляющихся после введенного с клавиатуры времени");
            Console.Write("Введите время ");
            string time = Console.ReadLine();

            foreach (var item in nL)
            {
                var temp = time.CompareTo(item.date);
                if (temp < 0)
                    Console.WriteLine(item.ToString());
            }


            Console.ReadLine();
        }
    }
}
