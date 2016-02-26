namespace Calculator
{
    ///Interface with virtual "Push", "Pop" and "Top" methods.
    interface IStack
    {
        void Push(int value);

        int Pop();

        int Top();
    }
}