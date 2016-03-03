namespace Calculator
{
    ///Interface with virtual "Push", "Pop" and "Top" methods.
    interface IStack
    {
        ///adds inputted value to the Stack.
        void Push(int value);

        ///deletes last element and return its value.
        int Pop();

        ///return last element's value.
        int Top();
    }
}