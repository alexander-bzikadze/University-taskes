using System;

namespace HashTable
{
    ///Contains integer values, adds them with "Add" method,
    ///"DeleteValue" deletes an element by value,
    ///"Search" searches for an element by value,
    ///"Print", finally, prints the whole HashTable. Amazing, isn't it?
    public class HashTable
    {
        private IHash hash;

        private static int hashConstant = 100;

        private List[] list;

        public HashTable(IHash hash)
        {
            this.hash = hash;
            list = new List[hashConstant];
            for (int i = 0; i < hashConstant; ++i)
            {
                list[i] = new List();
            }
        }

        public int HashFunction(int value)
        {
            return hash.Func(value, hashConstant);
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