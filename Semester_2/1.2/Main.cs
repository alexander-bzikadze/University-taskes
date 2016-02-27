using System;

namespace Fibonacci
{
    class Fibonacci
    {
        static public void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Exponentiation(new Matrix(), n).GetFirst());
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
}