using System;

namespace UniqueList
{
    ///Contains integer values, adds them with O(1),
    ///deletes, searches by value and prints with O(n). 
    public class ArrayList
    {
        protected BasicArrayList list = new BasicArrayList();

        ///Adds new element to the list
        virtual public void Add(int value)
        {
            list.Add(value);
        }

        ///Deletes element with chosen value
        virtual public void DeleteElement(int value)
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