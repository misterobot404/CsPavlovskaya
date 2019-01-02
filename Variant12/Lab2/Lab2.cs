using System;

namespace Lab2
{
    class Lab2
    {
        static bool IsHit(double r, double x, double y)
        {
            if (((((x >= -r) && (x <= 0)) && ((y >= 0) && (y <= r) && (Math.Sqrt(Math.Pow((x + r), 2) + Math.Pow((y - r), 2)) >= r))) | (((x >= 0) && (x <= r)) && ((y >= -r) && (y <= 0)))) && (Math.Sqrt(Math.Pow((x + r), 2) + Math.Pow((y - r), 2)) >= r))
            {
                return true;
            }
            else return false;         
        }


        static void Main()
        {
            Console.Write("Введите радиус: ");
            double r = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите X: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите Y: ");
            double y = Convert.ToDouble(Console.ReadLine());

            string ans = IsHit(r, x, y) ? "Попадает" : "Не попадает";
            Console.WriteLine(ans);
            Console.Read();
        }
    }
}
