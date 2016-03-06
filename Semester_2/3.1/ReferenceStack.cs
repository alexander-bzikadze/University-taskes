namespace ReferenceStack
{
    public class ReferenceStack
    {
        private ReferenceStackElement head = null;

        public void Push(int value)
        {
            head = new ReferenceStackElement(value, head);
        }

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