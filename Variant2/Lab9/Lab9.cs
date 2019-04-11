/*
Создать абстрактный класс Vehicle (транспортное средство). 
На его основе реализовать классы Plane (самолет), Саг (автомобиль) и Ship (корабль). 
Классы должны иметь возможность задавать и получать координаты и параметры средств передвижения (цена, скорость, год выпуска и т. п.) с помощью свойств.
Для самолета должна быть определена высота, для самолета и корабля — количество пассажиров, для корабля — порт приписки. 
Динамические характеристики задать с помощью методов.
 */

using System;

namespace Vehicle
{
    class Lab9
    {
        static void Main()
        {

            Console.WriteLine("Создание машины");
            Console.Write("Стоимость: ");          
            var car = new Car { Price = Convert.ToDouble(Console.ReadLine())};
            Console.WriteLine("Координаты X и Y (через Enter)");
            double carX = Convert.ToDouble(Console.ReadLine());
            double carY = Convert.ToDouble(Console.ReadLine());
            car.Coordinate(carX, carY);

            Console.WriteLine();
            Console.WriteLine("Характеристики машины");
            Console.WriteLine("Стоимость машины {0}:", car.Price.ToString());
            Console.WriteLine("Координаты машины X:{0},Y: {1}", car.CoordinateX.ToString(), car.CoordinateY.ToString());
            Console.WriteLine();


            Console.WriteLine("Создание самолета");
            Console.Write("Стоимость: ");
            var plane = new Plane { Price = Convert.ToDouble(Console.ReadLine()) };
            Console.WriteLine("Координаты X и Y (через Enter)");
            double planeX = Convert.ToDouble(Console.ReadLine());
            double planeY = Convert.ToDouble(Console.ReadLine());
            plane.Coordinate(planeX, planeY);
            Console.Write("Высота самолёта: ");
            plane.Height = Convert.ToDouble(Console.ReadLine());
            Console.Write("Количество пассажиров: ");
            plane.NumberOfPassengers = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Характеристики самолета");
            Console.WriteLine("Стоимость самолета {0}:", plane.Price.ToString());
            Console.WriteLine("Координаты самолета X:{0},Y: {1}", plane.CoordinateX.ToString(), plane.CoordinateY.ToString());
            Console.WriteLine("Высота самолёта: {0}", plane.Height.ToString());
            Console.WriteLine("Количество пассажиров: {0}", plane.NumberOfPassengers.ToString());


            Console.WriteLine("Создание корабля");
            Console.Write("Стоимость: ");
            var ship = new Ship { Price = Convert.ToDouble(Console.ReadLine()) };
            Console.WriteLine("Координаты X и Y (через Enter)");
            double shipX = Convert.ToDouble(Console.ReadLine());
            double shipY = Convert.ToDouble(Console.ReadLine());
            ship.Coordinate(shipX, shipY);
            Console.Write("Количество пассажиров: ");
            ship.NumberOfPassengers = Convert.ToDouble(Console.ReadLine());
            Console.Write("Порт: ");
            ship.DestinationPort = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Характеристики корабля");
            Console.WriteLine("Стоимость корабля {0}:", ship.Price.ToString());
            Console.WriteLine("Координаты корабля X:{0},Y: {1}", ship.CoordinateX.ToString(), ship.CoordinateY.ToString());
            Console.WriteLine("Количество пассажиров: {0}", ship.NumberOfPassengers.ToString());
            Console.WriteLine("Порт: {0}", ship.DestinationPort);


            Console.Read();
        }
    }
    internal class Vehicle
    {
        private double coordinateX, coordinateY;
        private double price, speed, year_of_construction;

        /* можно также применять автосвойства(тогда не нужны написанные выше поля ):
         public double CoordinateX { get; set; }
        */
        public double CoordinateX
        {
            get { return coordinateX; }
            set { coordinateX = value; }
        }

        public double CoordinateY
        {
            get { return coordinateY; }
            set { coordinateY = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public double Year_of_construction
        {
            get { return year_of_construction; }
            set { year_of_construction = value; }
        }


        //Метод для динамически меняющихся свойств
        public void Coordinate(double CoordinateX, double CoordinateY)
        {
            this.CoordinateX = CoordinateX;
            this.coordinateY = CoordinateY;
        }

        //Метод для динамически меняющихся свойств
        public void SpeedMethod(double Speed)
        {
            this.Speed = Speed;
        }
    }

    class Plane : Vehicle
    {
        public double Height { get; set; }
        public double NumberOfPassengers { get; set; }
    }

    class Ship : Vehicle
    {
        public double NumberOfPassengers { get; set; }
        public string DestinationPort { get; set; }
    }

    class Car : Vehicle
    {

    }
}
