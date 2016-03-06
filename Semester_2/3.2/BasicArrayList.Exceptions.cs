using System;

namespace HashTable
{
    ///Signals if one tried to get value from the null reference while working with List.
    [Serializable]
    public class ListNullExeption : Exception
    {
        public ListNullExeption() { }
        public ListNullExeption(string message) : base(message) { }
        public ListNullExeption(string message, Exception inner) : 
        
        base(message, inner) { }
        
        protected ListNullExeption(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}