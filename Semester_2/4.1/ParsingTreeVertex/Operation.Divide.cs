using System;

namespace ParsingTree
{
    /// Successor of Operation.
    public class OperationDivide : Operation
    {
        /// Divides childrens results and returns it.
        /// If right child is Null, throws exception.
        override public int Result()
        {
            throwExceptionIfChildrenNull();
            int rightResult = right.Result();
            if (rightResult == 0)
            {
                throw new DivideByZeroException();
            }
            return left.Result() / right.Result();
        }

        /// Prints itself and its children.
        override public void Print()
        {
            throwExceptionIfChildrenNull();
            Console.WriteLine(" /");
            left.Print();
            right.Print();
        }
    }
}