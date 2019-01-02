using System;

namespace Lab10
{
    class Program
    {
        const int NUMBER_OF_FLIGHTS = 2;

        public static void Main(string[] args)
        {
            Aeroflot[] Flights = new Program.Aeroflot[NUMBER_OF_FLIGHTS];

            GetValues(Flights);
            Array.Sort(Flights);
        
            Console.WriteLine("Все самолеты");
            for (int i = 0; i < Flights.Length; i++)            
                    Console.WriteLine(Flights[i].Destination + " " + Flights[i].PlaneModel + " " + Flights[i].Number);
            Console.WriteLine();


            int matches = 0;
            Console.WriteLine("Поиск самолетов");
            Console.Write("Введите пунк назначения: ");
            string DestinationToCompare = Console.ReadLine();

            for (int i = 0; i < Flights.Length; i++)
                if (Flights[i].Destination == DestinationToCompare)
                {
                    Console.WriteLine(Flights[i].Destination + " " + Flights[i].PlaneModel + " " + Flights[i].Number);
                    matches += 1;
                }

            if (matches == 0)
                Console.WriteLine("Самолеты не найдены...");

            Console.ReadLine();
        }

        public struct Aeroflot : IComparable
        {
            public string Destination;
            public int Number;
            public string PlaneModel;

            public int CompareTo(object obj)
            {
                Aeroflot arr = (Aeroflot)obj;
                return this.Number.CompareTo(arr.Number);
            }
        }

        static void GetValues(Aeroflot[] Flights)
        {
            for (int i = 0; i < NUMBER_OF_FLIGHTS; i++)
            {
                Aeroflot flight = new Aeroflot();

                Console.WriteLine("Ввод данных о " + (i + 1) + " самолете");
                Console.Write("Введите пункт назначения: ");
                flight.Destination = Console.ReadLine();
                Console.Write("Номер рейса: ");
                flight.Number = Convert.ToInt32(Console.ReadLine());
                Console.Write("Тип самолете: ");
                flight.PlaneModel = Console.ReadLine();

                Flights[i] = flight;
                Console.WriteLine();
            }
        }
    }
}

//https://social.msdn.microsoft.com/Forums/ru-RU/2d1efa85-11cc-4a28-8264-e72822bcc47f/1057108610881090108010881086107410821072?forum=programminglanguageru