using System;

namespace Fibonacci
{
    class Matrix
    {
        private int[,] mA; //matrixArray - in * this alias will be usefull

        ///creats standart matrix 2*2
        public Matrix()
        {
            mA = new int[2, 2] {{1, 1}, {1, 0}};
        }

        ///takes four integers and creats matrix of them
        public Matrix(int i1, int i2, int i3, int i4)
        {
            mA = new int[2, 2] {{i1, i2}, {i3, i4}};
        }

        ///prints Matrix as its impossible to do from outside of the class
        public void Print()
        {
            foreach(int el in mA)
            {
                Console.Write(el);
            }
            Console.WriteLine();
        }

        ///returns first element of Matrix
        public int GetFirst()
        {
            return mA[0, 0];
        }

        ///standart multiplation for matrix 2*2
        public static Matrix operator*(Matrix m1, Matrix m2)
        {
            return new Matrix(m1.mA[0, 0] * m2.mA[0, 0] + m1.mA[0, 1] * m2.mA[1, 0],
                                        m1.mA[0, 0] * m2.mA[0, 1] + m1.mA[0, 1] * m2.mA[1, 1],
                                        m1.mA[1, 0] * m2.mA[0, 0] + m1.mA[1, 1] * m2.mA[1, 0],
                                        m1.mA[1, 0] * m2.mA[0, 1] + m1.mA[1, 1] * m2.mA[1, 1]);
        }
    }
}