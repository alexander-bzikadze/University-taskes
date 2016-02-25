using System;

namespace HashTable
{
    class HashTable
    {
        private static int hashConstant = 100;

        private List[] list;

        public HashTable()
        {
            list = new List[hashConstant];
            for (int i = 0; i < hashConstant; ++i)
            {
                list[i] = new List();
            }
        }

        private int HashFunction(int value)
        {
            return (value % hashConstant);
        }

        public void Add(int value)
        {
            list[HashFunction(value)].Add(value);
        }

        public void DeleteElement(int value)
        {
            list[HashFunction(value)].DeleteElement(value);
        }

        public bool Search(int value)
        {
            return list[HashFunction(value)].Search(value);
        }

        public void Print()
        {
            for (int i = 0; i < hashConstant; ++i)
            {
                list[i].Print();
            }
        }
    }
}