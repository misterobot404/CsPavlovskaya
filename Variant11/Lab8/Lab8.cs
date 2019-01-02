/*
 Описать класс, реализующий тип данных "вещественная матрица" и работу с ними. 
 Класс должен релизовать следующие операции над матрицами:
 - методы, реализующие проверку типа матрицы 
 (квадратная, диагональная, нулевая, единичная, симметричная, 
 верхняя труегольная, нижняя труегольная);
 - операции сравнения на равенство / неравенство;
 - доступ к элементу по индексам.
Написать программу, демонстрирующую все разработанные элементы класса.
 */
using System;

namespace Lab8
{
    class Lab8
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк матрицы");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов матрицы");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Заполните матрицу");
            DoubleMatrix matrix = new DoubleMatrix(n, m);
            Random random = new Random();
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)  
                    matrix[i, j] = random.Next(-10,10);
            }
            Console.WriteLine("Матрица :");
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            matrix.Method(); //нулевая или не нулевая

            if (matrix.Method1() == false) // проверка на семмитричность
            {
                Console.WriteLine("Матрица не симметричная");
            }
            else Console.WriteLine("Матрица симметричная");

            matrix.Method2();  // Проверка квадратная

            if (matrix.Method3())  // проверка на единичность
            {
                Console.WriteLine("Матрица единичная");
            }
            else Console.WriteLine("Матрица не единичная");

            if (matrix.Method4() == true)   //Проверка на диагональность
            {
                Console.WriteLine("Матрица диагональная");
            }
            else Console.WriteLine("Матрица не диагональная");

            if (matrix.Method5())
            {
                Console.WriteLine("Матрица верхняя треугольная ");
            }
            else Console.WriteLine("Матрица не верхняя треугольная ");

            if (matrix.Method6())
            {
                Console.WriteLine("Матрица нижняя треугольная ");
            }
            else Console.WriteLine("Матрица не нижняя треугольная ");

            Console.WriteLine("Получим элемент по индексу [0,0]: " + matrix[0, 0]); //доступ к элементу по индексам
            Console.ReadKey();
        }
    }
    class DoubleMatrix
    {
        private double[,] matrix;
        public int rows, cols;
        private int Length;
        int r = 0;
        bool a = true, t = false;

        public DoubleMatrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new double[this.rows, this.cols];
            Length = rows * cols;
        }
        public double this[int index1, int index2]
        {
            get { return matrix[index1, index2]; }
            set { matrix[index1, index2] = value; }
        }
        public void Method() //нулевая или не нулевая
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    { r = r + 1; }
                }
            }
            if (r == cols * rows)
            { Console.WriteLine("Матрица нулевая"); }
            else { Console.WriteLine("Матрица не нулевая"); }
        }
        public bool Method1() // проверка на семмитричность
        {
            if (cols == rows)
            {
                for (int i = 0; i < matrix.GetLength(0); ++i)
                {
                    for (int j = 0; j < matrix.GetLength(1); ++j)
                        if (matrix[i, j] != matrix[j, i])
                        {
                            a = false;
                            break;
                        }
                    if (!a) break;
                }
                return a;
            }
            else return false;
        }

        public void Method2() // Проверка квадратная
        {
            if (rows == cols)
            {
                Console.WriteLine("Матрица квадратная");
            }
            else Console.WriteLine("Матрица не квадратная");
        }
        public bool Method3() // проверка на единичность
        {
            if (rows == cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (i == j && matrix[i, j] != 1)
                        {
                            return false;
                        }
                        else if (i != j && matrix[i, j] != 0)
                        { return false; }
                    }
                }
                return true;
            }
            return false;
        }
        public bool Method4() //Проверка на диагональность
        {
            if (rows == cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (i != j)
                        {
                            if (matrix[i, j] == 0)
                            {
                                t = true;
                            }
                            else t = false;
                            break;
                        }
                    }
                }
            }
            return t;
        }

        public bool Method5()
        {
            if (rows == cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j] != 0 && i > j)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
        public bool Method6()
        {
            if (rows == cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j] != 0 && i < j)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}
