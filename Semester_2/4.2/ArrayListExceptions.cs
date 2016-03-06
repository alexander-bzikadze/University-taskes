using System;

namespace UniqueList
{
    ///Signals if one tried to get value from the null reference while working with List.
    [Serializable]
    public class ListNullException : Exception
    {
        public ListNullException() { }
        public ListNullException(string message) : base(message) { }
        public ListNullException(string message, Exception inner) : 
        
        base(message, inner) { }
        
        protected ListNullException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}