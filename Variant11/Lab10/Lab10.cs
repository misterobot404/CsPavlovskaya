/*
 Описать структуру с именем MARSH, содержащую следующие поля: 
 - название начального пункта маршрута; 
 - название конечного пункта маршрута; 
 - номер маршрута. 
 Написать программу, выполняющую следующие действия: 
 - ввод с клавиатуры данных в массив, состоящий из восьми элементов типа MARSH 
 (записи должны быть упорядочены по номерам маршрутов); 
 - вывод на экран информации о маршруте, номер которого введен с клавиатуры 
 (если таких маршрутов нет, вывести соответствующее сообщение).
 */

using System;

namespace Lab10
{
    struct MARSH
    {
        public string nachalniy_punkt_marshryta;
        public string konechniy_punkt_marshryta;
        public int nomer_marshryta;
        public override string ToString()
        {
            return (string.Format(@"
                                    Начальный пункт назначения: {0}
                                    Конечный пункт назначения: {1}
                                    Номер маршрута: {2}", nachalniy_punkt_marshryta, konechniy_punkt_marshryta, nomer_marshryta));
        }
    }

        class Lab10
    {
        static void Main(string[] args)
        {
            int n = 5;
            MARSH[] mas = new MARSH[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Начальный пункт маршрута: ");
                mas[i].nachalniy_punkt_marshryta = Convert.ToString(Console.ReadLine());
                Console.Write("Конечный пункт маршрута: ");
                mas[i].konechniy_punkt_marshryta = Convert.ToString(Console.ReadLine());
                Console.Write("Номер маршрута: ");
                mas[i].nomer_marshryta = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");

            }

            Console.WriteLine("Сортировка по номерам маршрутов...");
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (mas[i].nomer_marshryta > mas[j].nomer_marshryta)
                    {
                        MARSH x = mas[i];
                        mas[i] = mas[j];
                        mas[j] = x;
                    }
                }
            }

            Console.WriteLine("Информация в базе:");
            Console.WriteLine();
            for (int i = 0; i < n; i++)
                Console.WriteLine(mas[i]);

            Console.WriteLine("Введите номер маршрута для вывода информации: ");
            int fam = Convert.ToInt32(Console.ReadLine());
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (mas[i].nomer_marshryta == fam)
                {
                    Console.WriteLine(mas[i]);
                    k++;
                }
            }

            if (k == 0) Console.WriteLine("Таких маршрутов нет!");
            Console.ReadKey();
        }
    }
}
