using System;

namespace ParsingTree
{
    /// Successor of Operand. Has to children Operands and char fields.
    /// Can get and return its value and print itself.
    public abstract class Operation : IParsingTreeVertex
    {
        protected IParsingTreeVertex left = null;
        protected IParsingTreeVertex right = null;

        ///Sets Left Child.
        public void SetLeft(IParsingTreeVertex left)
        {
            this.left = left;
        }

        ///Sets Right Child.
        public void SetRight(IParsingTreeVertex right)
        {
            this.right = right;
        }

        protected void throwExceptionIfChildrenNull()
        {
            if (left == null || right == null)
            {
                throw new OperationNullException();
            }
        }

        /// Abstract method of getting Result.
        abstract public int Result();

        /// Abstract method of printing itself.
        abstract public void Print();
    }
}