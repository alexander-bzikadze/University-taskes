using System;

namespace HashTable
{
    class List
    {
        private BasicArrayList list = new BasicArrayList();

        ///Adds new element to the list
        public void Add(int value)
        {
            list.Add(value);
        }

        ///Deletes element with chosen value
        public void DeleteElement(int value)
        {
            list.SetIteratorFirst();
            while (!list.IsIteratorNull() && list.GetIteratorValue() != value)
            {
                list.MoveIteratorForward();
            }
            if (!list.IsIteratorNull())
            {
                list.DeleteElement();
            }
        }

        ///Deletes first element and returns its value
        public int Pop()
        {
            list.SetIteratorFirst();
            int value = list.GetIteratorValue();
            list.DeleteElement();
            return value;
        }

        ///Returns value of the first element
        public int Top()
        {
            list.SetIteratorFirst();
            return list.GetIteratorValue();
        }

        ///Prints the whole list
        public void Print()
        {
            list.SetIteratorFirst();
            while (!list.IsIteratorNull())
            {
                Console.Write(list.GetIteratorValue());
                Console.Write(' ');
                list.MoveIteratorForward();
            }
            Console.WriteLine();
            list.SetIteratorFirst();
        }

        ///Returns boolean value after searching for an element
        public bool Search(int value)
        {
            list.SetIteratorFirst();
            while (!list.IsIteratorNull())
            {
                if (list.GetIteratorValue() == value)
                {
                    list.SetIteratorFirst();
                    return true;
                }
                list.MoveIteratorForward();
            }
            list.SetIteratorFirst();
            return false;
        }
    }
}