/*
Описать структуру с именем Note, содержащую следующие поля:
 - фамилия и имя;
 - домер телефона;
 - дата рождения (массив из трёх чисел).
Написать программу, которая выполняет следующие действия:
 - ввод с клавиатуры данных в массив, состоящий из восьми элементов типа Note 
   (записи должны быть упорядочены по дате рождения);
 - вывод на экран информации о человеке, номер телефона которого введена с клавиатуры
   (если такого нет, вывести соответствующее сообщение).
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Lab10
    {
        struct Node
        {
            public string name;
            public string phoneNumber;
            public int[] dateOfBirth;

            public override string ToString()
            {
                return name + " " + phoneNumber + " " + dateOfBirth[0] + "." + dateOfBirth[1] + "." + dateOfBirth[2];
            }

            public static int CompareBirthdays(Node first, Node second)
            {
                if (first.dateOfBirth[2] == second.dateOfBirth[2])
                {
                    if (first.dateOfBirth[1] == second.dateOfBirth[1])
                    {                        
                        return first.dateOfBirth[0].CompareTo(second.dateOfBirth[0]);
                    }
                    else return first.dateOfBirth[1].CompareTo(second.dateOfBirth[1]);
                }
                else return first.dateOfBirth[2].CompareTo(second.dateOfBirth[2]);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите количество записей: ");
            int count = Convert.ToInt32(Console.ReadLine());
            List<Node> book = new List<Node>(count);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Запись номер {0}: ", i+1);
                Node node = new Node();

                Console.Write("Введите имя: ");
                node.name = Console.ReadLine();
                Console.Write("Введите номер телефона: ");
                node.phoneNumber = Console.ReadLine();
                Console.Write("Введите дату рождения (ДД.ММ.ГГ): ");
                string[] date = Console.ReadLine().Split('.');

                node.dateOfBirth = new int[3];
                node.dateOfBirth[0] = Convert.ToInt32(date[0]);
                node.dateOfBirth[1] = Convert.ToInt32(date[1]);
                node.dateOfBirth[2] = Convert.ToInt32(date[2]);

                book.Add(node);
            }

            book.Sort(Node.CompareBirthdays);

            Console.WriteLine("Содержимое книги:");
            foreach (Node item in book)
                Console.WriteLine(item.ToString());

            Console.Write("Введите номер человека, которого хотите найти: ");
            string searchNumber = Console.ReadLine();

            foreach (Node item in book)
            {
                if(item.phoneNumber == searchNumber)
                    Console.WriteLine(item.ToString());
            }
                
            Console.Read();
        }
    }
}
