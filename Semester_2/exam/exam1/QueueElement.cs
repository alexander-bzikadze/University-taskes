using System;

namespace Queue
{
    /// Element of a Queue. Contains its int value and int priority.
    public class QueueElement
    {
        public QueueElement()
        {
            Value = 0;
            Priority = 0;
        }

        public QueueElement(int Value, int Priority)
        {
            this.Value = Value;
            this.Priority = Priority;
        }

        public int Value {get;}

        public int Priority {get;}
    }
}