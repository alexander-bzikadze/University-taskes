namespace ReferenceStack
{
    ///Contains int values, allows to push int values into itself,
    ///to remove last element, returning its value,
    ///to get last element's value.
    public class ReferenceStack
    {
        private ReferenceStackElement head = null;

        ///Gets int value and sets element with current value as head.
        public void Push(int value)
        {
            head = new ReferenceStackElement(value, head);
        }

        ///Deletes last element, returns its value. If stack is empty, throws exeption.
        public int Pop()
        {
            if (head == null)
            {
                throw new StackNullExeption("Trying to pop an empty stack.");
            }
            int result = head.GetValue();
            head = head.GetNext();
            return result;
        }
        ///Returns last element's value, throws exeption if empty.
        public int Top()
        {
            if (head == null)
            {
                throw new StackNullExeption("Trying to top an empty stack.");
            }
            return head.GetValue();
        }
    }
}