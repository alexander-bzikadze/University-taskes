namespace Stack
{
    class Stack
    {

        private static int N = 100;

        private int[] list = new int[N];

        private int end = -1;

        ///Pushes back current value
        public void Push(int value)
        {
            list[++end] = value;
        }

        ///Deletes first element and returns its value
        public int Pop()
        {
            int value = 0;
            if (end != -1)
            {
                value = list[end];
                end--;
            }
            return value;
        }

        ///Returns value of the first element
        public int Top()
        {
            int value = 0;
            if (end != -1)
            {
                value = list[end];
            }
            return value;
        }
    }
}