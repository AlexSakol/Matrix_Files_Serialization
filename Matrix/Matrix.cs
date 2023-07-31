using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array2x2
{
    internal class Matrix
    {
        int[,] array = { { 0, 0 }, { 0, 0 } };

        public Matrix()
        {
        }

        public Matrix(int[,] array)
        {
            Array = array;
        }

        public int[,] Array
        {
            get => array;
            set
            {
                if (value == null) array = new int[,] { { 0, 0 }, { 0, 0 } };
                else
                {
                    if ((value.GetUpperBound(0) + 1) >= 2 && (value.Length / (value.GetUpperBound(0) + 1)) >= 2)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                array[i, j] = value[i, j];
                            }
                        }
                    }
                    if ((value.GetUpperBound(0) + 1) < 2 || (value.Length / (value.GetUpperBound(0) + 1)) < 2)
                    {
                        for (int i = 0; i < value.GetUpperBound(0) + 1; i++)
                        {
                            for (int j = 0; j < value.Length / (value.GetUpperBound(0) + 1); j++)
                            {
                                array[i, j] = value[i, j];
                            }
                        }
                    }
                }
            }
        }

        public int this[int i, int j]
        {
            get => array[i, j];
            set => array[i, j] = value;
        }

        public static int Det(Matrix m1) => m1[0, 0] * m1[1, 1] - m1[0, 1] * m1[1, 0];

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix m3 = new();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    m3[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return m3;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix m3 = new();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    m3[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return m3;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            var m3 = new Matrix();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int n = 0; n < 2; n++)
                    {
                        m3[i, j] += m1[i, n] * m2[n, j];
                    }
                }
            }
            return m3;
        }

        public static Matrix operator ++(Matrix m1)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    m1[i, j] += 1;
                }
            }
            return m1;
        }

        public static Matrix operator --(Matrix m1)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    m1[i, j] -= 1;
                }
            }
            return m1;
        }

        public static Matrix operator *(Matrix m1, int a)
        {
            Matrix m2 = m1;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    m2[i, j] = m1[i, j] * a;
                }
            }
            return m2;
        }

        public static Matrix operator /(Matrix m1, int a)
        {
            Matrix m2 = m1;
            if (a != 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        m2[i, j] = m1[i, j] / a;
                    }
                }
            }
            else
            {
                throw new Exception("Деление на 0");
            }
            return m2;
        }
        //If Det == 0 matrix == false
        public static bool operator true(Matrix m1) => Det(m1) != 0;
        public static bool operator false(Matrix m1) => Det(m1) == 0;

        public static explicit operator int(Matrix m1) => Det(m1);

        public static explicit operator Matrix(int a) => new Matrix(new int[,] { { a, 0, }, { 0, a } });

        public static bool operator !=(Matrix m1, Matrix m2)
        {
            bool a = false;
            bool[,] flags = { { false, false }, { false, false } };
            int counter = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (m1[i, j] != m2[i, j]) flags[i, j] = true;
                    if (flags[i, j] == true) counter++;
                }
            }
            if (counter == 4) a = true;
            return a;
        }
        public static bool operator ==(Matrix m1, Matrix m2)
        {
            bool a = false;
            bool[,] flags = { { false, false }, { false, false } };
            int counter = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (m1[i, j] == m2[i, j]) flags[i, j] = true;
                    if (flags[i, j] == true) counter++;
                }
            }
            if (counter == 4) a = true;
            return a;
        }

        public override string? ToString()
        {
            string str = "";
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    str += $"\t{array[i, j]}\t";
                }
                str += "\n";
            }
            return str;
        }
    }

}

