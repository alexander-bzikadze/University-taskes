using System;

namespace Fibonacci
{
    class Fibonacci
    {
        static public void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Exponentiation(new Matrix(), n).getFirst());
        }
        static private Matrix Exponentiation(Matrix a, int exp)
        {
            Matrix result = new Matrix();
            for (int i = exp; i > 0; i >>= 1)
            {
                if (i % 2 != 0)
                {
                    result = result * a;
                }
                a = a * a;
            }
            return result;
        }
    }
    class Matrix
    {
        private int[,] MA; //MatrixArray - in * this alias will be usefull

        public Matrix()
        {
            MA = new int[2, 2] {{1, 1}, {1, 0}};
        }

        public Matrix(int i1, int i2, int i3, int i4)
        {
            MA = new int[2, 2] {{i1, i2}, {i3, i4}};
        }

        public void print()
        {
            foreach(int el in MA)
            {
                Console.Write(el);
            }
            Console.WriteLine();
        }

        public int getFirst()
        {
            return MA[0,0];
        }

        public static Matrix operator*(Matrix m1, Matrix m2)
        {
            return new Matrix(m1.MA[0,0] * m2.MA[0,0] + m1.MA[0,1] * m2.MA[1,0],
                                        m1.MA[0,0] * m2.MA[0,1] + m1.MA[0,1] * m2.MA[1,1],
                                        m1.MA[1,0] * m2.MA[0,0] + m1.MA[1,1] * m2.MA[1,0],
                                        m1.MA[1,0] * m2.MA[0,1] + m1.MA[1,1] * m2.MA[1,1]);
        }
    }
}