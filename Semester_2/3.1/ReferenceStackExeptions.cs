using System;

namespace ReferenceStack
{
    [Serializable]
    public class StackNullExeption : Exception
    {
        public StackNullExeption() { }
        public StackNullExeption(string message) : base(message) { }
        public StackNullExeption(string message, Exception inner) : 
        
        base(message, inner) { }
        
        protected StackNullExeption(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}