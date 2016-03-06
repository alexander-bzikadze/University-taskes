using System;
using HashTable;

namespace CM
{
    class ConsoleMain
    {
        static public void Main()
        {
            IHash hash;
            HashTable.HashTable hashTable;
            Console.WriteLine("Type:\n -0 to use first function,\n -1 to use second function.");
            ushort command = Convert.ToUInt16(Console.ReadLine());
            while (command > 1)
            {
                Console.WriteLine("Wrong input! Try again.");
                command = Convert.ToUInt16(Console.ReadLine());
            }
            if (command == 1)
            {
                hash = new Hash2();
            }
            else
            {
                hash = new Hash1();
            }
            hashTable = new HashTable.HashTable(hash);
            hashTable.Add(1);
            for (int i = 0; i < 1000; ++i)
            {
                hashTable.Add(51 * i);
            }
            Console.WriteLine(hashTable.Search(33));
            Console.WriteLine(hashTable.Search(102));
            hashTable.DeleteElement(51);
            hashTable.DeleteElement(0);
            Console.WriteLine(hashTable.Search(0));
            // hash.Print();
        }
    }
}