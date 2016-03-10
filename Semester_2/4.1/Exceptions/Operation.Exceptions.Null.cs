using System;

namespace ParsingTree
{
    /// Signals of a try to count Operation's value while 
    /// one of it children is null.
    [Serializable]
    public class OperationNullException : Exception
    {
        public OperationNullException() { }
        public OperationNullException(string message) : base(message) { }
        public OperationNullException(string message, Exception inner) : 
         
        base(message, inner) { }
         
        protected OperationNullException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
             : base(info, context) { }
    }
}