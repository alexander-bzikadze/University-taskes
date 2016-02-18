using System;

namespace Spiral
{
    class Spiral
    {
        public static void Main()
        {
            int [,] matrix = new int[5, 5] 
            {{1,   2,   3,   4,  5},
              {6,   7,   8,   9,  10},
              {11, 12, 13, 14, 15},
              {16, 17, 18, 19, 20},
              {21, 22, 23, 24, 25}};
            PrintFromTheInside(matrix);
        }
        
        private static void PrintFromTheInside(int[,] matrix)
        {
            int center = matrix.GetLength(0) / 2;
            int i = center;
            int j = center;
            Console.Write(matrix[i, j]);
            Console.Write(' ');
            for (int step = 1; step <= matrix.GetLength(0) / 2; ++step)
            {
                ++i;
                ++j;
                while (j > center - step)
                {
                    --j;
                    Console.Write(matrix[i, j]);
                    Console.Write(' ');
                }
                while (i > center - step)
                {
                    --i;
                    Console.Write(matrix[i, j]);
                    Console.Write(' ');
                }
                while (j < center + step)
                {
                    ++j;
                    Console.Write(matrix[i, j]);
                    Console.Write(' ');
                }
                while (i < center + step)
                {
                    ++i;
                    Console.Write(matrix[i, j]);
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }
}