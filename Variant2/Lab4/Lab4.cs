/*
Описать класс, реализующий шестнадцатеричный счетчик, 
который может увеличивать или уменьшать свое значение на единицу в заданном диапазоне. 
Предусмотреть инициализацию счетчика значениями по умолчанию и произвольными значениями. 
Счетчик имеет два метода: увеличения и уменьшения, — и свойство,позволяющее получить его текущее состояние. 
При выходе за границы диапазона выбрасываются исключения.
Написать программу, демонстрирующую все разработанные элементы класса.
 */

using System;

namespace Lab4
{
    class Lab4
    {
        static void Main(string[] args)
        {
            try
            {
                Counter cn = new Counter();
                while (true)
                {
                    Console.Clear();
                    cn.ShowBorder();
                    cn.ShowCount();
                    Console.WriteLine("1. Установить значение");
                    Console.WriteLine("2. Увеличить значение счетчика");
                    Console.WriteLine("3. Уменьшить значение счетчика");
                    Console.WriteLine("4. Установить диапазон");
                    Console.Write("> ");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            {
                                Console.Write("Введите значение: ");
                                cn = new Counter(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                        case 2:
                            {
                                cn.CountUp();
                                break;
                            }
                        case 3:
                            {
                                cn.CountDown();
                                break;
                            }
                        case 4:
                            {
                                Console.Write("Введите минимальное значение: ");
                                int minValue = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите максимальное значение: ");
                                int maxValue = Convert.ToInt32(Console.ReadLine());

                                Counter.SetBorder(minValue, maxValue);
                                break;
                            }
                    }                  
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ИСКЛЮЧЕНИЕ!!! COUNTER OVERFLOW");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}

public class Counter
{
    public Counter()
    {
        count = 250;
    }
    public Counter(int count)
    {
        if (count > BottomBorder && count <= TopBorder)
            this.count = count;

        else throw new ArgumentException();
    }

    private int count;
    public static int BottomBorder = 0, TopBorder = 100;

    public static void SetBorder(int i, int y)
    {
        if (i >= 0 && y > 1)
        {
            BottomBorder = i;
            TopBorder = y;
        }
        else
        {
            BottomBorder = 0;
            TopBorder = 100;
        }
    }
   
    private int Count
    {
        get { return count; }
    }

    public void CountDown()
    {
        if (count > BottomBorder)
        {
            count--;
        }
        else throw new ArgumentException();
    }
    public void CountUp()
    {
        if (count < TopBorder)
        {
            count++;
        }
        else throw new ArgumentException();
    }
    public void ShowCount()
    {
        Console.WriteLine("Текущее значение счетчика (шестнадцатеричное значение): " + Convert.ToString(Count, 16));
    }
    public void ShowBorder()
    {
        Console.WriteLine("Текущий диапазон: {0} - {1}", BottomBorder, TopBorder);
    }
}
