/*
 Описать класс, представляющий треугольник. Предусмотреть методы для создания объектов, вычисление площади,
 периметра и точки пересечения медиан. Описать свойства для получения состояния обьекта. 
 При невозможности построения треугольника выбрасывается исключение.
 */

using System;

namespace Lab4
{
    class Lab4
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            // Пробуем создать 10 треугольников
            for (int counter = 0; counter < 10; counter++)
            {
                Triangle triangle;
                try
                {
                    // Создание треугольника со случайными сторонами ( числа подобраны методом тыка )
                    triangle = new Triangle(random.Next(3, 10), random.Next(-1, 15), random.Next(3, 10));
                    // Выводим информацию о треугольнике
                    Console.WriteLine(triangle);
                    // Считаем и выводим его периметр 
                    // ( ToString("F") необходима для отображения только двух знаков после запятой )
                    Console.WriteLine("Периметр треугольника = " + triangle.calcPerimeter().ToString("F"));
                    // Считаем и выводим его площадь 
                    Console.WriteLine("Площадь треугольника = " + triangle.calcArea().ToString("F"));
                    // Печатаем пустую строку в качестве разделителя
                    Console.WriteLine();
                }
                catch (IsNotTriangleException exception)
                {
                    // Если возникла исключительная ситуация выводим сообщение о ней на консоль
                    Console.WriteLine("Исключение: " + exception);
                    // Печатаем пустую строку в качестве разделителя
                    Console.WriteLine();
                }
                catch (Exception exception)
                {
                    // Если напечаталась эта строка значит в программе косяк
                    Console.WriteLine("Неизвестное исключение: " + exception);
                    // Печатаем пустую строку в качестве разделителя
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}
