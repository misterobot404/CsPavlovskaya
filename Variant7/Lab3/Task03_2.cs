using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab03
{
    class Task03_2
    {
        public string Two(double x, double y, double R)
        {
            string flag = "Не попадает";

            if ((((x + R) * (x + R) + (y - R)*(y - R)) <= (R * R)) 

            || ((x >= -1) && (x <= 2 * R) && (y >= -R) && (y <= 0))) flag = "Попадает";

            return flag;
        }
    }
}
