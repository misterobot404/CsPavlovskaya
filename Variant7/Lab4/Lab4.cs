/*
 Составить описание класса прямоугольника со сторонами, параллельными осям координат. 
 Предусмотреть возможность перемещения прямоугольника на плоскости, изменение размеров, 
 построение наименьшего прямоугольника, содержащего 2 заданных прямоугольника и прямоугольника, 
 являющегося общей частью (пересечением) 2-х прямоугольников.
 */

using System;

namespace Lab4
{
    public class Rectangle
    {
        public Rectangle(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        private int _x, _y, _width, _height;

        public void Relocation(int x, int y)
        {
            _x += x;
            _y += y;
        }
        public void Minimal(int x, int y, int width, int height)
        {
            int minimalRectX, minimalRectY, minimalWidth, minimalHeight;

            if (_x < x )
                minimalRectX = _x;
            else
                minimalRectX = x;

            if (_y < y)
                minimalRectY = _y;
            else
                minimalRectY = y;

            if ((Math.Abs(_x) + _width) > (Math.Abs(x) + width))
                minimalWidth = Math.Abs(_x) + _width;
            else
                minimalWidth = Math.Abs(x) + width;

            if ((Math.Abs(_y) + _height) > (Math.Abs(y) + height))
                minimalHeight = Math.Abs(_y) + _height;
            else
                minimalHeight = Math.Abs(y) + height;

            Console.Write(
                "Минимальный прямоугольник\n " +
                "X: {0}\n" +
                "Y: {1}\n" +
                "Ширина: {2}\n" +
                "Высота: {3}\n",
                minimalRectX, minimalRectY, minimalWidth, minimalHeight);
        }
        public void Сross(int x, int y, int width, int height)
        {
            double x1 = _x, x2 = _x + _width,
                y1 = _y + _height, y2 = _y,
                x3 = x, x4 = x + width, 
                y3 = y + height, y4 = y, 
                x_min = _x, x_max = _x, 
                y_min = _y, y_max = _y, 
                x1_sred = 0, x2_sred = 0, 
                y1_sred = 0, y2_sred = 0;
            double[] A = { x1, x2, x3, x4 }, B = { y1, y2, y3, y4 };

            for (int i = 0; i < 4; i++)
            {
                if (x_max < A[i])
                {
                    x_max = A[i];
                }
                if (y_max < B[i])
                {
                    y_max = B[i];
                }
                if (x_min > A[i])
                {
                    x_min = A[i];
                }
                if (y_min > B[i])
                {
                    y_min = B[i];
                }
            }


            for (int i = 0; i < 4; i++)
            {
                if ((A[i] != x_max) && (A[i] != x_min))
                {
                    x1_sred = A[i];
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if ((A[i] != x_max) && (A[i] != x_min) && (A[i] != x1_sred))
                {
                    x2_sred = A[i];
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if ((B[i] != y_max) && (B[i] != y_min))
                {
                    y1_sred = B[i];
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if ((B[i] != y_max) && (B[i] != y_min) && (B[i] != y1_sred))
                {
                    y2_sred = B[i];
                    break;
                }
            }
            Console.Write(
                "Прямоугольник на пересечении\n " +
                "X: {0}\n" +
                "Y: {1}\n" +
                "Ширина: {2}\n" +
                "Высота: {3}\n",
                x2_sred, y2_sred, x1_sred, y1_sred);
        }

        public void Resize(int width, int height)
        {
            _width += width;
            _height += height;
        }
        public void ShowLocationInfo()
        {
            Console.Write(
                "X: {0}\n" +
                "Y: {1}\n " +
                "Ширина: {2}\n" +
                "Высота: {3}\n", 
                _x, _y, _width, _height);
        }

    }
   
    class Lab4
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Строим прямоугольник в декартовой системе координат (x и y) по высоте и ширине");           
            Console.Write("Введите X: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите Y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину: ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите высоту: ");
            int height = Convert.ToInt32(Console.ReadLine());
            Rectangle rect1 = new Rectangle(x, y, width, height);
                             
            do
            {
                Console.Write("\n");
                Console.Write("Варианты команд:\n" +
                "1.Перемещение по плоскости\n" +
                "2.Изменение размеров\n" +
                "3.Показать данные о прямоугольнике\n" +
                "4.Минимальный прямоугольник содержащий 2 заданных\n" +
                "5.Прямоугольник получившийся на пересечении 2\n" +
                "6.Выход\n");
                Console.Write("Введите номер пункта меню: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        {
                            Console.Write("На сколько по X: ");
                            int tempX = Convert.ToInt32(Console.ReadLine());
                            Console.Write("На сколько по Y: ");
                            int tempY = Convert.ToInt32(Console.ReadLine());
                            rect1.Relocation(tempX, tempY);
                        }
                        break;
                    case 2:
                        {
                            Console.Write("Изменить ширину на ");
                            int tempWidth = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Измнить высоту на ");
                            int tempHeight = Convert.ToInt32(Console.ReadLine());
                            rect1.Resize(tempWidth, tempHeight);
                        }
                        break;
                    case 3:
                        rect1.ShowLocationInfo();
                        break;
                    case 4:
                        {
                            Console.WriteLine("Данные о 1ом прямоугольнике");
                            rect1.ShowLocationInfo();
                            Console.WriteLine("Введите данные о 2ом прямоугольнике");
                            Console.Write("Введите X: ");
                            int tempX = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите Y: ");
                            int tempY = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите ширину: ");
                            int tempWidth = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите высоту: ");
                            int tempHeight = Convert.ToInt32(Console.ReadLine());
                            rect1.Minimal(tempX, tempY, tempWidth, tempHeight);
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("Данные о 1ом прямоугольнике");
                            rect1.ShowLocationInfo();
                            Console.WriteLine("Введите данные о 2ом прямоугольнике");
                            Console.Write("Введите X: ");
                            int tempX = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите Y: ");
                            int tempY = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите ширину: ");
                            int tempWidth = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите высоту: ");
                            int tempHeight = Convert.ToInt32(Console.ReadLine());
                            rect1.Сross(tempX, tempY, tempWidth, tempHeight);
                        }
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Не, ну это не серьёзно, вводи!");
                        break;
                }
            } while (true);
        }
    }
}
