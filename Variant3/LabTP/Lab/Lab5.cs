using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class Lab5
    {
        static int ReadlnInteger(string s)
        {
            Console.Write(s);
            return int.Parse(Console.ReadLine());
        }

        static void Main()
        {
            Console.Write("N = "); int n = int.Parse(Console.ReadLine());
            int[] a = Enumerable.Range(0, n).Select((v, i) => ReadlnInteger($"{i + 1} элемент: ")).ToArray();
            Console.WriteLine($"Массив: {String.Join(" ", a)}");
            Console.WriteLine("Произведение: " + a.Where((v, i) => i % 2 != 0).Aggregate(1, (x, v) => x * v));
            int nul1 = -1, nul2 = -1;
            for (int i = 0; i < a.Length; i++) if (a[i] == 0) { nul1 = i; break; }
            for (int i = a.Length - 1; i >= 0; i--) if (a[i] == 0 && i != nul1) { nul2 = i; break; }
            Console.WriteLine(nul1 == -1 || nul2 == -1 ? "Нулевой элемент один или таковые отсутствуют!"
                : $"Сумма: {a.Where((v, i) => i > nul1 && i < nul2).Sum()}");
            for (int i = 0; i < a.Length - 1; i++)
                for (int j = i; j < a.Length; j++)
                    if (a[i] < 0 && a[j] >= 0) { int x = a[i]; a[i] = a[j]; a[j] = x; }
            Console.WriteLine($"Преобразованный массив: {String.Join(" ", a)}");
            Console.ReadLine();
        }
    }
}