using System;

namespace ParsingTree
{
    /// Signals of wrong input in ParsingTreeConstructor.
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

    /// Signals of fail of ParsingTreeConstruction.
    [Serializable]
    public class ConstructorFailException : Exception
    {
        public ConstructorFailException() { }
        public ConstructorFailException(string message) : base(message) { }
        public ConstructorFailException(string message, Exception inner) : 
        
        base(message, inner) { }
        
        protected ConstructorFailException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}