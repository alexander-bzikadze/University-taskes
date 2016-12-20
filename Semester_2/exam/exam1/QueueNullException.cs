using System;

namespace Queue
{
    /// Sigmals that one tries to dequeue an empty Queue.
    [Serializable]
    public class QueueNullException : Exception
    {
        public QueueNullException() { }
        public QueueNullException(string message) : base(message) { }
        public QueueNullException(string message, Exception inner) : 
         
        base(message, inner) { }
         
        protected QueueNullException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
             : base(info, context) { }
    }
}