using System;

namespace ConsoleTravel
{
    /// Signals of a try to count Operation's value while 
    /// one of it children is null.
    [Serializable]
    public class WrongInputException : Exception
    {
        public WrongInputException() { }
        public WrongInputException(string message) : base(message) { }
        public WrongInputException(string message, Exception inner) : 
         
        base(message, inner) { }
         
        protected WrongInputException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
             : base(info, context) { }
    }
}