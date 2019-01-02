using System;

namespace Lab4
{
    class Triangle
    {
        // Конструктор
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            // Проверка все ли стороны положительны
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            {
                throw new IsNotTriangleException("Треугольник со стороной <= 0 не может быть создан");
            }

            // Проверка являются ли все стороны меньше суммы двух других
            if (firstSide + secondSide <= thirdSide
                || firstSide + thirdSide <= secondSide
                || secondSide + thirdSide <= firstSide)
            {
                throw new IsNotTriangleException("Одна или более сторон больше чем две другие");
            }

            // Занесение значений длин сторон в переменные класса
            this._FirstSide = firstSide;
            this._SecondSide = secondSide;
            this._ThirdSide = thirdSide;
        }

        // Длины сторон 
        private double _FirstSide;
        private double _SecondSide;
        private double _ThirdSide;

        // Вычисление периметра
        public double calcPerimeter()
        {
            return _FirstSide + _SecondSide + _ThirdSide;
        }

        // Вычисление площади
        public double calcArea()
        {
            // Вычисление по формуле Герона
            double result = 0.25 * Math.Sqrt((_FirstSide + _SecondSide + _ThirdSide)
                    * (_FirstSide + _SecondSide - _ThirdSide)
                    * (_FirstSide + _ThirdSide - _SecondSide)
                    * (_SecondSide + _ThirdSide - _FirstSide));

            return result;
        }

        // Нахождение точки пересечения медиан
        public void calcMediansIntersectionPoint(out double x, out double y)
        {
            x = 0;
            y = 0;
        }

        // Преобразование объекта в строку ( Этот метод неявно вызывается при выводе объекта на консоль )
        override public String ToString()
        {
            String triangleInfo = "Треугольник со сторонами " + _FirstSide
                + ", " + _SecondSide + " и " + _ThirdSide;

            return triangleInfo;
        }
    }
}

class IsNotTriangleException : Exception
{
    public IsNotTriangleException(String message)
    {
        _Message = message;
    }

    private String _Message;

    public override string ToString()
    {
        return _Message;
    }
}
