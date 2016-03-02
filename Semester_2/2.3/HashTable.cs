using System;

namespace HashTable
{
    ///Contains integer values, adds them with "Add" method,
    ///"DeleteValue" deletes an element by value,
    ///"Search" searches for an element by value,
    ///"Print", finally, prints the whole HashTable. Amazing, isn't it?
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

        private static int HashFunction(int value)
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