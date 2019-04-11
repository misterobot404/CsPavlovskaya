/*
Описать класс для работы с одномерным массивом строк фиксированной длинны. 
Обеспечить следующие возможности:
- Задание произвольных целых границ индексов при создании объекта
- Обращение к отдельной строке массива по индексу с контролем выхода за пределы массива
- Выполнение операций поэлементного сцепления двух массивов с образованием нового массива
- Выполнение операций слияния двух массивов с исключением повторяющихся элементов
- Вывод на экран элемента массива по заданному индексу и всего массива
 */
using System;

namespace Lab8
{
    class Lab8
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 50);
            Random random = new Random();

            Console.WriteLine("Создание первого массива с границами индексов c -2 до 3");
            MyArray arr = new MyArray(-2, 3);
            for (int i = arr.FirstIndex; i < arr.LastElemPos; i++)
            {
                arr[i] = random.Next(-5, 5).ToString();
            }
            Console.WriteLine("Все элементы первого массива");
            for (int i = arr.FirstIndex; i < arr.LastElemPos; i++)
            {
                Console.WriteLine("индекс  {0}: значение: {1}", i.ToString(), arr[i]);
            }

            Console.WriteLine();

            Console.WriteLine("Создание второго массива с границами индексов c 1 до 5");
            MyArray arr2 = new MyArray(1, 5);
            for (int i = arr2.FirstIndex; i < arr2.LastElemPos; i++)
            {
                arr2[i] = random.Next(-5, 5).ToString();
            }
            Console.WriteLine("Все элементы второго массива");
            for (int i = arr2.FirstIndex; i < arr2.LastElemPos; i++)
            {
                Console.WriteLine("индекс  {0}: значение: {1}", i.ToString(), arr2[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Элемент первого массива с индексом -1  - {0}", arr[-1]);
            Console.WriteLine("Элемент первого массива с индексом 10  - {0}", arr[-10]);
            Console.WriteLine();

            MyArray concatArr = MyArray.Concat(arr, arr2);
            Console.WriteLine("Объединенный массив");
            for (int i = concatArr.FirstIndex; i < concatArr.LastElemPos; i++)
            {
                Console.WriteLine("индекс  {0}: значение: {1}", i.ToString(), concatArr[i]);
            }
            Console.WriteLine();

            MyArray MergeArr = MyArray.Merge(arr, arr2);
            Console.WriteLine("объединенный массив с исключением повторяющихся элементов из другого массива");
            for (int i = MergeArr.FirstIndex; i < MergeArr.LastElemPos; i++)
            {
                Console.WriteLine("индекс  {0}: значение: {1}", i.ToString(), MergeArr[i]);
            }

            Console.ReadLine();
        }
    }

    // создаем наш класс - контейнер для стрингов, реализуем Icloneable,
    //чтобы не портить исходные массивы при объединении 
    public class MyArray : ICloneable
    {
        private int firstIndex, lastIndex;
        string[] arr; //объявляем внутренний служебный массив 

        public MyArray(int firstIndex, int lastIndex) // конструктор, вызывается при созданнии объекта
        {

            if (firstIndex >= lastIndex)
                throw new ArgumentException("первый индекс должен быть меньше последнего");
            this.firstIndex = firstIndex; // инициализируем границы нашего контейнера
            this.lastIndex = lastIndex;
            arr = new string[lastIndex - firstIndex + 1]; // инициализируем внутренний массив
        }

        public int FirstIndex // свойство, возвращающее индекс первого элемент нашего контейнера
        {
            get { return firstIndex; }
        }
        public int LastElemPos // свойство, возвращающее индекс последнего элемент нашего контейнера
        {
            get { return arr.Length + firstIndex; }
        }
        public string this[int pos] // для того, чтобы обращаться к нашему контейнеру синтаксисом MyArr[i], создаем индексатор
        {
            get
            {
                try
                {
                    if (pos < firstIndex || pos > lastIndex) // проверяем границы массива, если вышли - генерируем исключение
                        throw new ArgumentOutOfRangeException("Вышли за границы массива :(");
                    else
                        return arr[pos - firstIndex];
                }
                catch (ArgumentOutOfRangeException)
                {
                    return "ArgumentOutOfRangeException";
                }
            }
            set
            {
                if (pos < firstIndex || pos > lastIndex) // проверяем границы массива, если вышли - генерируем исключение
                    throw new ArgumentOutOfRangeException("Вышли за границы массива :(");
                else
                    arr[pos - firstIndex] = value;
            }
        }
        public object Clone() // реализуем клонирование
        {
            MyArray copy = new MyArray(this.firstIndex, this.lastIndex);
            for (int i = 0; i < copy.arr.Length; i++)
            {
                copy.arr[i] = this.arr[i];
            }
            return copy;
        }
        public static MyArray Concat(MyArray arr1, MyArray arr2) //объединяем массивы
        {
            //клонируем входящие массивы, чтобы не портить данные
            MyArray temp1 = (MyArray)arr1.Clone();
            MyArray temp2 = (MyArray)arr2.Clone();

            int temp = temp1.arr.Length;
            Array.Resize(ref temp1.arr, temp1.arr.Length + temp2.arr.Length);
            temp1.lastIndex += temp2.arr.Length;
            temp2.arr.CopyTo(temp1.arr, temp);
            return temp1;
        }
        public static MyArray Merge(MyArray pArr1, MyArray pArr2)
        {
            MyArray arr1 = (MyArray)pArr1.Clone();
            MyArray arr2 = (MyArray)pArr2.Clone();

            int sizeForAdd = arr2.arr.Length;
            for (int i = 0; i < arr1.arr.Length; i++)
            {
                for (int j = 0; j < arr2.arr.Length; j++)
                {
                    if (arr1.arr[i] == arr2.arr[j]) // если нашли совпадения, повторяющемуся эл-ту присваиваем null
                    {
                        arr2.arr[j] = null;
                        sizeForAdd--;
                    }
                }
            }

            int temp = arr1.arr.Length;
            Array.Resize(ref arr1.arr, arr1.arr.Length + sizeForAdd);

            for (int i = 0; i < arr2.arr.Length; i++)
            {
                if (arr2.arr[i] != null)
                {
                    arr1.arr[temp] = arr2.arr[i];
                    temp++;
                }
            }

            arr1.lastIndex += sizeForAdd;
            return arr1;

        }
    }
}
