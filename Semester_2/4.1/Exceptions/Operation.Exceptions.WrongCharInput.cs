using System;

namespace ParsingTree
{

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