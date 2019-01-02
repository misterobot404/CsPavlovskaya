/*
 Описать класс «записная книжка». Предусмотреть возможность работы с произвольным числом записей, поиска записи по какому-либо признаку 
 (например, по фамилии, дате рождения или номеру телефона), добавления и удаления записей, сортировки по фамилии и доступа к записи по номеру.
 Написать программу, демонстрирующую разработаные элементы класса.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab8
{
    class Lab8
    {
        public class Record
        {
            public int id;
            public string Name;
            public string Surname;
            public string Birthday;
            public string PhoneNumber;

            public Record(int id, string Name, string Surname, string Birthday, string PhoneNumber)
            {
                this.id = id;
                this.Name = Name;
                this.Surname = Surname;
                this.Birthday = Birthday;
                this.PhoneNumber = PhoneNumber;
            }
        }

        public class Notebook
        {
            private List<Record> notebookRecords;
            public List<Record> NotebookRecords
            {
                get { return notebookRecords; }
                set { notebookRecords = value; }
            }

            public Notebook()
            {
                notebookRecords = new List<Record>();
            }

            public List<Record> SearchRecords(string Name, string Surname, string Birthday, string PhoneNumber)
            {
                List<Record> ret = new List<Record>();
                foreach (Record rec in notebookRecords)
                    if (rec.Name == Name || rec.Surname == Surname || rec.Birthday == Birthday || rec.PhoneNumber == PhoneNumber)
                        ret.Add(rec);
                return ret;
            }
            public List<Record> SearchRecords(int id)
            {
                List<Record> ret = new List<Record>();
                foreach (Record rec in notebookRecords)
                    if (rec.id == id)
                        ret.Add(rec);
                return ret;
            }
            public void SearchRecords(string Surname)
            {
                foreach (Record rec in notebookRecords)
                    if (rec.Surname == Surname)
                        Console.WriteLine("{0} {1} {2} {3} {4}", rec.id, rec.Name, rec.Surname, rec.Birthday, rec.PhoneNumber);
            }

            public void AddRecord(int id, string Name, string Surname, string Birthday, string PhoneNumber)
            {
                Record rec = new Record(id, Name, Surname, Birthday, PhoneNumber);
                notebookRecords.Add(rec);
            }

            public void DeleteRecords(int id)
            {
                List<Record> records = SearchRecords(id);
                foreach (Record rec in records)
                    notebookRecords.Remove(rec);
            }

            private static int CompareSurname(Record first, Record second)
            {
                return first.Surname.CompareTo(second.Surname);
            }

            public void SortBySurname()
            {
                notebookRecords.Sort(CompareSurname);
            }

            public void PrintfInfoByNotebook()
            {
                foreach (var item in notebookRecords)
                {
                    Console.Write(item.id + "\t");                  
                    Console.Write(item.Name + "\t");
                    Console.Write(item.Surname + "\t");
                    Console.Write(item.Birthday + "\t");
                    Console.Write(item.PhoneNumber + "\n");
                }
            }
        }

        static void Main(string[] args)
        {
            Notebook notebook = new Notebook();
            while (true)
            {
                Console.WriteLine("***ЗАПИСНАЯ КНИГА***");
                Console.WriteLine("1. Добавить запись");
                Console.WriteLine("2. Удалить запись");
                Console.WriteLine("3. Поиск записей");
                Console.WriteLine("4. Сортировку по фамилии");
                Console.WriteLine("5. Содержание записной книги");
                Console.WriteLine("6. Выход");
                Console.Write(">");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        {
                            Console.WriteLine("*Добавление записи*");
                            Console.Write("Введите номер записи: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Введите фамилию: ");
                            string surname = Console.ReadLine();
                            Console.Write("Введите дату рождения: ");
                            string birthday = Console.ReadLine();
                            Console.Write("Введите номер телефона: ");
                            string phoneNumber = Console.ReadLine();
                            notebook.AddRecord(id, name, surname, birthday, phoneNumber);
                        }
                        break;
                    case 2:
                        {
                            Console.Write("Введите номер удаляемой записи: ");
                            notebook.DeleteRecords(Convert.ToInt32(Console.ReadLine()));
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Введите фамилию");
                            notebook.SearchRecords(Console.ReadLine());
                        }
                        break;
                    case 4:
                        notebook.SortBySurname();
                        break;
                    case 5:
                        notebook.PrintfInfoByNotebook();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Вводи правильно!");
                        break;
                }
            }
            
        }
    }
}
