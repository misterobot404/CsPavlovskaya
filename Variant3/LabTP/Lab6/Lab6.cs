using System;

namespace Lab6
{
    class Lab6
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,] a = new int[5, 10];
            for (int i = 0; i < 5; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    a[i, j] = rnd.Next(-1, 5);
                    Console.Write("{0,4}", a[i, j]);
                }
                Console.WriteLine();
            }
            Console.Write("Кол-во столбов с нулями:");
            int k = 0;
            for (int j = 0; j < 10; ++j)
            {
                bool f = false;
                for (int i = 0; i < 5; ++i)
                    if (a[i, j] == 0) f = true;
                if (f) ++k;
            }
            Console.WriteLine(" {0}", k);

            int maxSeriesLen = 1;
            int maxSeriesIdx = 0;
            for (int i = 0; i < 5; ++i)
            {
                int q = 1;
                int t = 0;
                for (int j = 1; j < 9; ++j)
                {
                    if (a[i, j] == a[i, j + 1]) ++t;

                    if (t > q) q = t;
                    else t = 1;

                    if (q > maxSeriesLen)
                    {
                        maxSeriesIdx = i;
                        maxSeriesLen = q;
                    }

                }

            }
            if (maxSeriesLen == 1) Console.WriteLine("нет строк с сериями одинаковых элементов");
            else
                Console.WriteLine("Номер строки с самой длинной серией одинаковых элементов: {0}", maxSeriesIdx);
            Console.WriteLine("Количество идущих подряд одинаковых элементов: {0}", maxSeriesLen);

            Console.ReadLine();
        }
    }
}
