using System;

namespace HashTable
{
    class ConsoleMain
    {
        static public void Main()
        {
            HashTable hash = new HashTable();
            hash.Add(1);
            for (int i = 0; i < 1000; ++i)
            {
                hash.Add(51 * i);
            }
            Console.WriteLine(hash.Search(33));
            Console.WriteLine(hash.Search(102));
            hash.DeleteElement(51);
            hash.DeleteElement(0);
            Console.WriteLine(hash.Search(0));
            hash.Print();
        }
    }
}