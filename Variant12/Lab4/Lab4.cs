/* 
Описать класс, представляющий круг.Предусмотреть методы для создания объектов,
вычисления площади круга, длины окружности и проверки попадания заданной
точки внутрь круга.Описать свойства для получения состояния объекта.
Написать программу, демонстрирующую все разработанные элементы класса.
*/

using System;

namespace Lab4
{
    public static class Lab4
    {
        private static void Main()
        {
            Circle circle = new Circle(1, new Point(0, 0));
            Console.WriteLine(circle);
            Console.WriteLine("Проверка на принадлежность точки (0.1,0.1) кругу.");
            Console.WriteLine(circle.IsInside(new Point(0.1, 0.1)));
            Console.WriteLine("Площадь.");
            Console.WriteLine(circle.Square);
            Console.WriteLine("Длина окружности.");
            Console.WriteLine(circle.Circuit);
            Console.ReadKey();
        }
    }

    public class Circle
    {
        /// <summary>
        /// Радиус.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Положение центра.
        /// </summary>
        public Point Center { get; set; }

        public Circle(double radius, Point center)
        {
            Radius = radius;
            Center = center;
        }

        /// <summary>
        /// Площадь круга.
        /// </summary>
        public double Square
        {
            get { return Math.PI * Radius * Radius; }
        }

        /// <summary>
        /// Длина окружности.
        /// </summary>
        public double Circuit
        {
            get { return Math.PI * 2 * Radius; }
        }

        /// <summary>
        /// Проверка на принадлежность точки кругу.
        /// </summary>
        public bool IsInside(Point point)
        {
            Point vector = new Point(point.X - Center.X, point.Y - Center.Y);
            double distance = vector.X * vector.X + vector.Y * vector.Y;
            return distance <= Radius * Radius;
        }

        public override string ToString()
        {
            return String.Format("Radius: {0}; Center: {1};", Radius, Center);
        }
    }

    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; private set; }
        public double Y { get; private set; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
    }
}
