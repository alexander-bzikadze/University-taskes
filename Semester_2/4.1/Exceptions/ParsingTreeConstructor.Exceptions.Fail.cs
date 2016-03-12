using System;

namespace ParsingTree
{
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