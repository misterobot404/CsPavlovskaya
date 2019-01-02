using System;

namespace Lab10
{
    class Program
    {
        const int NUMBER_OF_WORKER = 2;

        public static void Main(string[] args)
        {
            Worker[] worker = new Program.Worker[NUMBER_OF_WORKER];

            GetValues(worker);
            Array.Sort(worker);

            Console.WriteLine("Все работники");
            for (int i = 0; i < worker.Length; i++)
                Console.WriteLine(worker[i].Name + " " + worker[i].YearArrival + " " + worker[i].Post);
            Console.WriteLine();

            int matches = 0;
            Console.WriteLine("Поиск работников");
            Console.Write("Введите стаж: ");
            int DestinationToCompare = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < worker.Length; i++)
            {
                if (2018 - worker[i].YearArrival > DestinationToCompare)
                    Console.WriteLine(worker[i].Name + " " + worker[i].YearArrival + " " + worker[i].Post);
                matches += 1;
            }

            if (matches == 0)
                Console.WriteLine("Работники не найдены...");

            Console.ReadLine();
        }

        public struct Worker : IComparable
        {
            public string Name;
            public string Post;
            public int YearArrival;

            public int CompareTo(object obj)
            {
                Worker arr = (Worker)obj;
                return this.Name.CompareTo(arr.Name);
            }
        }

        static void GetValues(Worker[] Workers)
        {
            for (int i = 0; i < NUMBER_OF_WORKER; i++)
            {
                Worker worker = new Worker();

                Console.WriteLine("Ввод данных о " + (i + 1) + " сотруднике");
                Console.Write("Введите имя: ");
                worker.Name = Console.ReadLine();
                Console.Write("Должность: ");
                worker.Post = Console.ReadLine();
                Console.Write("Год поступления на работу: ");
                worker.YearArrival = Convert.ToInt32(Console.ReadLine());

                Workers[i] = worker;
                Console.WriteLine();
            }
        }
    }
}

