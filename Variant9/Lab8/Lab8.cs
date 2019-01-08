/*
 Описать класс, реализующий тип данных «вещественная матрица» и работу с ними. Класс должен релизовать следующие операции над матрицами:
- сложение, вычитание;
- комбинированные операции присваивания (+=, -= );
- операции сравнения на равенство / неравенство;
- операции вычисления обратной и транспонированной матрицы;
- доступ к элементу по индексам.
Написать программу, демонстрирующую все разработанные элементы класса.
 */
using System;

namespace Lab8
{
    class Lab8
    {
        public class Matrix
        {
            double[,] matrix;
            int Row = 0, Col = 0;

            //матрица N x M
            public Matrix(int row, int col)
            {
                matrix = new double[row, col];
                Row = row; Col = col;
            }

            //копия матрицы
            public Matrix(Matrix prMatrix)
            {
                this.matrix = new double[prMatrix.matrix.GetLength(0), prMatrix.matrix.GetLength(1)];
                Row = prMatrix.matrix.GetLength(0); Col = prMatrix.matrix.GetLength(1);
                for (int i = 0; i < Row; i++)
                    for (int j = 0; j < Col; j++)
                    {
                        matrix[i, j] = prMatrix.matrix[i, j];                       
                    }
            }

            //квадратная матрица
            public Matrix(int N)
            {
                matrix = new double[N, N];
                Row = Col = N;
            }

            //перегрузка индексатора, чтобы обратится к 
            //элементу матрицы как к элементу двумерного массива
            public double this[int i, int j]
            {
                get { return matrix[i, j]; }
                set { matrix[i, j] = value; }
            }

            //перегружаем сложение матриц
            public static Matrix operator +(Matrix first, Matrix second)
            {
                Matrix mat = new Matrix(first.Row, first.Col);
                for (int i = 0; i < first.Row; i++)
                    for (int j = 0; j < first.Col; j++)
                        mat[i, j] = first[i, j] + second[i, j];
                return mat;
            }

            //перегружаем вычитание матриц
            public static Matrix operator -(Matrix first, Matrix second)
            {
                Matrix mat = new Matrix(first.Row, first.Col);
                for (int i = 0; i < first.Row; i++)
                    for (int j = 0; j < first.Col; j++)
                        mat[i, j] = first[i, j] - second[i, j];
                return mat;
            }

            // перегрузка сравнения матриц
            public static bool operator ==(Matrix first, Matrix second)
            {
                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < second.Col; j++)
                    {
                        if (first[i, j] != second[i, j])
                            return false;
                    }
                }
                return true;
            }
            public static bool operator !=(Matrix first, Matrix second)
            {
                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < second.Col; j++)
                    {
                        if (first[i, j] != first[i, j])
                            return true;
                    }
                }
                return false;
            }

            //умножение на число
            public static Matrix operator *(Matrix m, int t)
            {
                Matrix mat = new Matrix(m.Row, m.Col);
                for (int i = 0; i < m.Row; i++)
                    for (int j = 0; j < m.Col; j++)
                        mat[i, j] = m[i, j] * t;
                return mat;
            }

            //распечатать матрицу
            public void PrintMatrix()
            {
                for (int i = 0; i < this.Row; i++)
                {
                    for (int j = 0; j < this.Col; j++)
                        Console.Write("{0}  ", this[i, j]);
                    Console.Write("\n");
                }

            }

            //произведение матриц
            public static Matrix operator *(Matrix first, Matrix second)
            {
                Matrix matr = new Matrix(first.Row, first.Col);
                for (int i = 0; i < first.Row; i++)
                {
                    for (int j = 0; j < second.Col; j++)
                    {
                        double sum = 0;
                        for (int r = 0; r < first.Col; r++)
                            sum += first[i, r] * second[r, j];
                        matr[i, j] = sum;
                    }
                }
                return matr;
            }

            //возведение в степень
            public static Matrix operator ^(Matrix first, int pow)
            {
                Matrix matr = new Matrix(first.Row, first.Col);
                matr = first;
                for (int z = 1; z < pow; z++)
                {
                    Matrix bufer = new Matrix(first.Row, first.Col);
                    for (int i = 0; i < first.Row; i++)
                    {
                        for (int j = 0; j < first.Row; j++)
                        {
                            double sum = 0;
                            for (int r = 0; r < first.Row; r++)
                                sum += matr[i, r] * first[r, j];
                            bufer[i, j] = sum;
                        }
                    }
                    matr = bufer;
                }
                return matr;
            }
            // транспонирование матрицы
            public void Transp()
            {
                double tmp;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        tmp = matrix[i, j];
                        matrix[i, j] = matrix[j, i];
                        matrix[j, i] = tmp;
                    }
                }
            }

            // вычисление обратной матрицы
            public static Matrix Inverse(Matrix mA, uint round = 0)
            {
                Matrix tempMatrix = new Matrix(mA); //Делаем копию исходной матрицы
                double determinant = DetRec(mA.matrix); //Находим детерминант

                if (determinant == 0) return tempMatrix; //Если определитель == 0 - матрица вырожденная

                for (int i = 0; i < mA.matrix.GetLength(0); i++)
                {
                    for (int t = 0; t < mA.matrix.GetLength(1); t++)
                    {
                        Matrix tmp = Exclude(mA, i, t);  //получаем матрицу без строки i и столбца t
                                                        //(1 / determinant) * Determinant(tmp) - формула поределения элемента обратной матрицы
                        tempMatrix.matrix[t, i] = round == 0 ? (1 / determinant) * Math.Pow(-1, i + t) * DetRec(mA.matrix) : Math.Round(((1 / determinant) * Math.Pow(-1, i + t) * DetRec(mA.matrix)), (int)round, MidpointRounding.ToEven);
                    }
                }
                return tempMatrix;
            }

            private static Matrix Exclude(Matrix mA, int row, int col)
            {
                Matrix temp = new Matrix(mA.Row - 1, mA.Col - 1);

                bool setMinusRow = false;
                bool setMinusCol = false;
                for (int i = 0; i < temp.matrix.GetLength(0); i++)
                {
                    if (i == row)
                    {
                        setMinusRow = true;
                        continue;
                    }
                    for (int j = 0; j < temp.matrix.GetLength(1); j++)
                    {
                        if (j == col)
                        {
                            setMinusCol = true;
                            continue;
                        }
                        
                        if (setMinusCol == true && setMinusRow == true)
                        {
                            temp.matrix[i, j] = mA.matrix[i, j];
                        }
                        else if (setMinusCol == false && setMinusRow == true)
                        {
                            temp.matrix[i, j] = mA.matrix[i, j];
                        }
                        else if (setMinusCol == true && setMinusRow == false)
                        {
                            temp.matrix[i,j] = mA.matrix[i, j];
                        } else temp.matrix[i, j] = mA.matrix[i, j];
                    }
                }
                return mA;
            }

            private static double DetRec(double[,] matrix)
            {
                if (matrix.Length == 4)
                {
                    return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
                }
                double sign = 1, result = 0;
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    double[,] minor = GetMinor(matrix, i);
                    result += sign * matrix[0, i] * DetRec(minor);
                    sign = -sign;
                }
                return result;
            }

            private static double[,] GetMinor(double[,] matrix, int n)
            {
                double[,] result = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0, col = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j == n)
                            continue;
                        result[i - 1, col] = matrix[i, j];
                        col++;
                    }
                }
                return result;
            }
        }

        static void Main(string[] args)
        {
            //размерность
            int N = 3;
            //степень
            int pow = 3;

            Random rand = new Random();
            Matrix first = new Matrix(N);
            Matrix second = new Matrix(N);

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    first[i, j] = rand.Next(1, 4);
                    second[i, j] = rand.Next(1, 4);
                }

            Console.WriteLine("Первая матрица:");
            first.PrintMatrix();
            Console.WriteLine("\nВторая матрица:");
            second.PrintMatrix();
            Console.WriteLine("\nСумма матриц:");
            (first + second).PrintMatrix();
            Console.WriteLine("\nРазница матриц:");
            (first - second).PrintMatrix();
            Console.WriteLine("\nКомбинированная операция присваивания второй матрице к первой");
            second += first;
            Console.WriteLine("Первая матрица:");
            first.PrintMatrix();
            Console.WriteLine("\nВторая матрица:");
            second.PrintMatrix();
            Console.WriteLine("\nСравнение матриц:");
            if (first == second)
            {
                Console.WriteLine("Матрицы равны");
            }
            else Console.WriteLine("Матрицы не равны");
            Console.WriteLine("\nПолучение элемента первой матрицы по индексу [1][1]:");
            Console.WriteLine(first[1, 1]);
            Console.WriteLine("\nТранспонирование второй матрицы:");
            second.Transp();
            second.PrintMatrix();
            Console.WriteLine("\nНахождение обратной матрицы из второй матрицы:");
            second = Matrix.Inverse(second);
            second.PrintMatrix();
            Console.ReadKey();
        }
    }
}
