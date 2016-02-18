using System;

namespace Fibonacci
{
    class Matrix
    {
        private int[,] mA; //matrixArray - in * this alias will be usefull

        public Matrix()
        {
            mA = new int[2, 2] {{1, 1}, {1, 0}};
        }

        public Matrix(int i1, int i2, int i3, int i4)
        {
            mA = new int[2, 2] {{i1, i2}, {i3, i4}};
        }

        public void print()
        {
            foreach(int el in mA)
            {
                Console.Write(el);
            }
            Console.WriteLine();
        }

        public int getFirst()
        {
            return mA[0, 0];
        }

        public static Matrix operator*(Matrix m1, Matrix m2)
        {
            return new Matrix(m1.mA[0, 0] * m2.mA[0, 0] + m1.mA[0, 1] * m2.mA[1, 0],
                                        m1.mA[0, 0] * m2.mA[0, 1] + m1.mA[0, 1] * m2.mA[1, 1],
                                        m1.mA[1, 0] * m2.mA[0, 0] + m1.mA[1, 1] * m2.mA[1, 0],
                                        m1.mA[1, 0] * m2.mA[0, 1] + m1.mA[1, 1] * m2.mA[1, 1]);
        }
    }
}