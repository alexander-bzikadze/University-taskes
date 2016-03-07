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

    /// Signals of wrong input in Operation Constructor.
    [Serializable]
    public class WrongCharInputException : Exception
    {
        public WrongCharInputException() { }
        public WrongCharInputException(string message) : base(message) { }
        public WrongCharInputException(string message, Exception inner) : 
         
        base(message, inner) { }
         
        protected WrongCharInputException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
             : base(info, context) { }
    }
}