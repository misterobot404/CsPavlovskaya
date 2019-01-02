using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab02
{
    class Task02_2
    {

        public string O(double x, double y,   double R) 
        {
            string flag = "не попадает";
           
            if ((((x + R) * (x + R) + (y - R) * (y - R)) <= (R * R)) || ((x >= -1) && (x <= 2 * R) && (y >= -R) && (y <= 0))) flag = "попадает";

            return flag;
        }

    }
}
