using System;

namespace Lab3
{
    class Lab3
    {
        public static int Fact(Int32 n)
        {
            int res = 1;
            if (n <= 1) res = 1;

            else
            {
                for (int i = n; i > 1; i--)
                    res *= i;
            }
            return res;
        }

        static void Main(string[] args)
        {
            Console.Clear();
            int c = 0;
            double y = 0;
            double x1 = 0;
            double x2 = 0;
            double dx = 0;
            double e = 0;
            double d = 0;
            int f = 1;
            int l = 0;
            bool u = true;
            double bufy = 0;
            bool o = true;
            while (o)
            {
                try
                {
                    o = false;
                    Console.Write("Введите х начальное ");
                    x1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите х конечное ");
                    x2 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите шаг ");
                    dx = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите точность ");
                    e = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    o = true;
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода");
                }
            }
            Console.WriteLine("Таблица значений");
            Console.WriteLine("---------------------------");
            Console.WriteLine("   x   |      y      |   k   ");
            Console.WriteLine("---------------------------");

            c = 0;
            l = 1;
            y = 0;
            d = 0;
            f = 1;
            u = true;

            for (int i = 1; x1 <= x2; i++)
            {
                for (int n = 0; u; n++)
                {
                    f = Fact(n);
                    bufy = (l * (Math.Pow(x1, 2 * n))) / f;
                    y = y + bufy;
                    if (Math.Abs(bufy) < e) u = false;
                    d = bufy;
                    c++;
                    //f = f * c;
                    l = l * -1;
                    y = Math.Round(y, 5);
                }

                Console.Write("|{0,5} ", x1);
                Console.Write("|{0,13}|", y);
                Console.WriteLine(" {0,3}", c);

                x1 = x1 + dx;
            }
            Console.ReadLine();
        }
    }
}