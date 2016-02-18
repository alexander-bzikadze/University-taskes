using System.Collections.Generic;

namespace Stack
{
    class Stack
    {
        private List<int> list = new List<int>();

        ///adds an integer to the stack
        public void Push(int a)
        {
            list.Add(a);
        }

        ///returns last element of the stack
        public int Top()
        {
            if (list.Count == 0)
            {
                return 0;
            }
            return list[list.Count - 1];
        }

        ///removes last element from the stack and returns its value
        public int Pop()
        {
            if (list.Count == 0)
            {
                return 0;
            }
            int result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return result;
        }
    }
}