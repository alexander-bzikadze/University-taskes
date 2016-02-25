namespace Calculator
{
    interface IStack
    {
        void Push(int value);

        int Pop();

        int Top();
    }
}