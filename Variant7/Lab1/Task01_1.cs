using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01
{
    class Task01_1
    {
        public double Z1(double x) 
        {
            return Math.Pow(Math.Cos(3.0 / 8.0 * Math.PI - x / 4.0), 2.0)-
                   Math.Pow(Math.Cos(11.0 / 8.0 * Math.PI + x / 4.0), 2.0);;
        }
        public double Z2(double x)
        {
             return Math.Sqrt(2.0) * Math.Sin(x / 2.0)/2;;
        }

    }
}