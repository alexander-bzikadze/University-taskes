using System;

namespace ParsingTree
{
    /// Signals of a try to divide by zero.
    [Serializable]
    public class DivideByZeroException : Exception
    {
        public DivideByZeroException() { }
        public DivideByZeroException(string message) : base(message) { }
        public DivideByZeroException(string message, Exception inner) : 
         
        base(message, inner) { }
         
        protected DivideByZeroException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
             : base(info, context) { }
    }
}