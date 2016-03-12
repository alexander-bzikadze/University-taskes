using System;

namespace ParsingTree
{
    /// Successor of Operation.
    public class OperationSubtract : Operation
    {
        /// Subtracts childrens results and returns it.
        override public int Result()
        {
            throwExceptionIfChildrenNull();
            return left.Result() - right.Result();
        }

        /// Prints itself and its children.
        override public void Print()
        {
            throwExceptionIfChildrenNull();
            Console.WriteLine(" -");
            left.Print();
            right.Print();
        }
    }
}