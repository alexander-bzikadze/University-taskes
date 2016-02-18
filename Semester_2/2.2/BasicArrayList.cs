using  System.Collections.Generic;

namespace List
{
    class BasicArrayList
    {
        private List<int> list = new List<int>();

        private int iterator;

        ///Pushes back current value
        public void Add(int value)
        {
            list.Add(value);
        }

        ///Searches for value and deletes it, if found
        public void DeleteElement(int value)
        {
            list.Remove(value);
        }

        ///Sets iterator 0
        public void SetIteratorFirst()
        {
            iterator = 0;
        }

        ///Increments iterator
        public void MoveIteratorForward()
        {
            iterator++;
        }

        ///Returns result of comparison of iterator to array size
        public bool IsIteratorNull()
        {
            return iterator == list.Count;
        }

        ///Returns value, which iterator points on
        public int GetIteratorValue()
        {
            if (!IsIteratorNull())
            {
                return list[iterator];
            }
            else
            {
                return 0;
            }
        }
    }
}