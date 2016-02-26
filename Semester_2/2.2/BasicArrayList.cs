using  System;

namespace List
{
    ///Contains integer values, can get more of them with the "Add" method,
    ///uses Iterator to point a needed element,
    ///deletes selected with iterator element with "DeleteElement" method.
    class BasicArrayList
    {
        private static int N = 100;

        private int[] list = new int[N];

        private int iterator = -1;
        private int begin = -1;
        private int end = -1;

        ///Pushes back current value
        public void Add(int value)
        {
            list[++end] = value;
            if (begin == -1)
            {
                begin = 0;
            }
        }

        ///Searches for value and deletes it, if found
        public void DeleteElement()
        {
            for (int i = iterator; i < end; ++i)
            {
                list[i] = list[i + 1];
            }
            if (end > -1)
            {
                end--;
                if (end == -1)
                {
                    begin = -1;
                }
            }
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
            return iterator == end + 1;
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