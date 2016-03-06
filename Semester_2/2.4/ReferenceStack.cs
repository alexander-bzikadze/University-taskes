namespace Calculator
{
    ///Contains integer elements, "Push" adds them to the Stack,
    ///"Pop" deletes first element,
    ///"Top" returns value of the first element.
    public class ReferenceStack : IStack
    {
        ///Contains integer value and reference to the next ReferenceStackElement,
        ///"GetValue" returns int value,
        ///"GetNext" returns Reference to next element.
        class ReferenceStackElement
        {
            private int value = 0;
            private ReferenceStackElement next = null;

            public ReferenceStackElement(int value = 0, ReferenceStackElement next = null)
            {
                this.value = value;
                this.next = next;
            }

            ///Returns value.
            public int GetValue()
            {
                return value;
            }

            ///Returns next.
            public ReferenceStackElement GetNext()
            {
                return next;
            }
        }

        private ReferenceStackElement Last = null;

        ///Creates new element with a reference to current last and sets it last.
        public void Push(int value)
        {
            Last = new ReferenceStackElement(value, Last);
        }

        ///Sets next element from the Last Last, returns element of the former Last.
        public int Pop()
        {
            if (Last == null)
            {
                return 0;
            }
            int result = Last.GetValue();
            Last = Last.GetNext();
            return result;
        }

        ///Returns value of the Last.
        public int Top()
        {
            if (Last == null)
            {
                return 0;
            }
            return Last.GetValue();
        }
    }
}