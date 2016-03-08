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

    [Serializable]
    public class ListOverloadException : Exception
    {
        public ListOverloadException() { }
        public ListOverloadException(string message) : base(message) { }
        public ListOverloadException(string message, Exception inner) : 
        
        base(message, inner) { }
        
        protected ListOverloadException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class UniqueListAddExisting : Exception
    {
        public UniqueListAddExisting() { }
        public UniqueListAddExisting(string message) : base(message) { }
        public UniqueListAddExisting(string message, Exception inner) : 
        
        base(message, inner) { }
        
        protected UniqueListAddExisting(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class UniqueListDeleteStrange : Exception
    {
        public UniqueListDeleteStrange() { }
        public UniqueListDeleteStrange(string message) : base(message) { }
        public UniqueListDeleteStrange(string message, Exception inner) : 
        
        base(message, inner) { }
        
        protected UniqueListDeleteStrange(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}