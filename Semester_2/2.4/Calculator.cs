using System;

namespace Calculator
{
    ///Calculates value using IStack object given in constructor,
    ///"Push" addes new value to the Stack,
    ///can Add, Subtract, Multiply, Divide last two element on the stack,
    ///result returns the last element on the stack.
    public class Calculator
    {
        ///Creats Calculator object using one of the IStack's realizations
        public Calculator(IStack stack)
        {
            this.stack = stack;
        }

        private IStack stack;

        ///Pushes  input value to stack
        public void Push(int value)
        {
            stack.Push(value);
        }

        ///Takes two last elements fo the stack, adds them and pushes back
        public void Add()
        {
            int first = stack.Pop();
            int second = stack.Pop();
            stack.Push(second + first);
        }

       ///Takes two last elements fo the stack, subtractes them and pushes back
        public void Subtract()
        {
            int first = stack.Pop();
            int second = stack.Pop();
            stack.Push(second - first);
        }

       ///Takes two last elements fo the stack, multiplies them and pushes back
        public void Multiply()
        {
            int first = stack.Pop();
            int second = stack.Pop();
            stack.Push(second * first);
        }
       
       ///Takes two last elements fo the stack, divides them and pushes back 
        public void Divide()
        {
            int first = stack.Pop();
            int second = stack.Pop();
            stack.Push(second / first);
        }
        
       ///Returns last element on the stack
        public int Result()
        {
            return stack.Top();
        }
    }
}