using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab02
{
    class Task02_1
    {
        public double F(double x)
        {
            double y = 0;

            if (x < -7 || x > 11) { /*Console.WriteLine("Функция не определена при данном аргументе");*/ return double.NaN; }

            else
            {
                if (x <  -7)           y = 0;
                if (x >= -7 && x < -3) y = 3;
                if (x >= -3 && x <  3) y = -Math.Sqrt(9 - x * x) + 3;
                if (x >=  3 && x <  6) y = -2 * x + 9;
                if (x >=  6 && x < 11) y = x - 9;
                if (x >= 11)           y = 2;

                return y;
            }

        }

    }
}
