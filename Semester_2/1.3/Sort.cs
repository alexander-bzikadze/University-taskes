using System;

namespace Sort
{
    class Sort
    {
        static public void Main()
        {
            Console.WriteLine("Hi there!");
            int[] array = new int[8] {1, 4, 6, 7, 2, 5, 8, 10};
            SortArray(ref array);
            foreach(int el in array)
            {
                Console.Write(el);
            }
            Console.WriteLine();
        }
        static private void Swap<T>(ref T valueFirst, ref T valueSecond)
        {
            T temp = valueFirst;
            valueFirst = valueSecond;
            valueSecond = temp;
        }
        static private void SortArray(ref int[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                int j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    Swap<int>(ref array[j], ref array[j - 1]);
                    --j;
                }
            }
        }
    }
}