namespace ParsingTree
{
    /// An standart element for stack with Operation as a value type.
    /// Counter is used to measure the number of children of current value.
    public class ParsingStackElement
    {
        public ParsingStackElement(Operation value = null, ParsingStackElement next = null)
        {
            this.value = value;
            this.next = next;
        }

        private int count = 0;
        private Operation value;
        private ParsingStackElement next;

        public void IncreaseCount()
        {
            count++;
        }

        public int GetCount()
        {
            return count;
        }

        public Operation GetValue()
        {
            return value;
        }

        public ParsingStackElement GetNext()
        {
            return next;
        }
    }
}