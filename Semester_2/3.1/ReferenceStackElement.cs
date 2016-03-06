namespace ReferenceStack
{
    public class ReferenceStackElement
    {
        public ReferenceStackElement(int value = 0, ReferenceStackElement next = null)
        {
            this.value = value;
            this.next = next;
        }

        private int value;
        private ReferenceStackElement next;

        // public int Value { get; };
        // public ReferenceStackElement Next { get; };

        public int GetValue()
        {
            return value;
        }

        public ReferenceStackElement GetNext()
        {
            return next;
        }
    }
}