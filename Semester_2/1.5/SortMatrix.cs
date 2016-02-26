using System;

namespace SortMatrix
{
    class SortMatrix
    {
       static public void Main()
        {
            Console.WriteLine("Hi there!");
            int[][] matrix = new int[3][];
            matrix[0] = new int[] {25, 3, 1, 10, 2};
            matrix[1] = new int[] {15, 2, 10, 2, 4};
            matrix[2] = new int[] {1, 5, 7, 15, 2};
            SortArray(ref matrix);
            foreach(int[] array in matrix)
            {
                foreach(int el in array)
                {
                    Console.Write(el);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        static private void Swap<T>(ref T valueFirst, ref T valueSecond)
        {
            T temp = valueFirst;
            valueFirst = valueSecond;
            valueSecond = temp;
        }
        static private void SortArray(ref int[][] matrix)
        {
            for (int i = 1; i < matrix[0].Length; ++i)
            {
                int j = i;
                while (j > 0 && matrix[0][j] < matrix[0][j - 1])
                {
                    foreach(int[] array in matrix)
                    {
                        Swap<int>(ref array[j], ref array[j - 1]);
                    }
                    --j;
                }
            }
        }
    }
}