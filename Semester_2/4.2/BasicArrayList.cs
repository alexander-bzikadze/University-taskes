namespace UniqueList
{
    ///Contains integer values, adds them with O(1),
    ///deletes iterated element with O(n), has iterator to travel across the List.
    public class BasicArrayList
    {
        private static int N = 100;

        private int[] list = new int[N];

        private int iterator = 0;
        private int begin = -1;
        private int end = -1;

        ///Pushes back current value
        public void Add(int value)
        {
            if (end == N - 1)
            {
                throw new ListNullException("List is overloaded.");
            }
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
            if (iterator > end)
            {
                throw new ListNullException("Trying to get out of iterator range.");
            }
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
                throw new ListNullException("Get a properer iterator.");
            }
        }
    }
}