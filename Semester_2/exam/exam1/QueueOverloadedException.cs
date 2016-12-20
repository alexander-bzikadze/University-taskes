using System;

namespace Queue
{
    /// Sigmals that one tries to overload Queue.
    [Serializable]
    public class QueueOverloadedException : Exception
    {
        public QueueOverloadedException() { }
        public QueueOverloadedException(string message) : base(message) { }
        public QueueOverloadedException(string message, Exception inner) : 
         
        base(message, inner) { }
         
        protected QueueOverloadedException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
             : base(info, context) { }
    }
}