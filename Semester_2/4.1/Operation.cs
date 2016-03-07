using System;

namespace ParsingTree
{
    /// Successor of Operand. Has to children Operands and char fields.
    /// Can get and return its value using children and char fields.
    public class Operation : Operand
    {
        protected char operation;

        /// Requirs an arithmetic sign to build itself. If not given, throws Exception.
        public Operation(char operation)
        {
            if (operation != '+' &&
                operation != '-' &&
                operation != '*' &&
                operation != '/')
            {
                throw new WrongCharInputException();
            }
            this.operation = operation;
        }

        protected Operand left = null;
        protected Operand right = null;

        ///Sets Left Child.
        public void SetLeft(Operand left)
        {
            this.left = left;
        }

        ///Sets Right Child.
        public void SetRight(Operand right)
        {
            this.right = right;
        }

        /// Counts its value and returns it.
        /// If there is a try to divide by zero throws exception.
        override public int Result()
        {
            if (left == null || right == null)
            {
                throw new OperationNullException();
            }
            int result = 0;
            switch(operation)
            {
                case '+':
                {
                   result = right.Result() + left.Result();
                   break;
                }
                case '-':
                {
                    result = left.Result() - right.Result();
                    break;
                }
                case '*':
                {
                    result = right.Result() * left.Result();
                    break;
                }
                case '/':
                {
                    int rightResult = right.Result();
                    if (rightResult == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    result = left.Result() / rightResult;
                    break;
                }
            }
            value = result;
            return result;
        }
    }
}