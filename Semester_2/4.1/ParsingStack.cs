using System;

namespace ParsingTree
{
    /// Contains Operation values, allows to push values into itself,
    /// to remove last element, returning its value,
    /// to get last element's value.
    public class ParsingStack
    {
        private ParsingStackElement head = null;

        /// Gets value and sets element with current value as head.
        public void Push(Operation value)
        {
            head = new ParsingStackElement(value, head);
        }

        /// Deletes last element, returns its value. If stack is empty, throws exception.
        public ParsingStackElement Pop()
        {
            if (head == null)
            {
                throw new StackNullExeption("Trying to pop an empty stack.");
            }
            ParsingStackElement result = head;
            head = head.GetNext();
            return result;
        }
        /// Returns last element itself, throws exception if empty.
        public ParsingStackElement Top()
        {
            if (head == null)
            {
                throw new StackNullExeption("Trying to top an empty stack.");
            }
            return head;
        }
    }
}