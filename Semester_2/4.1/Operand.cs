using System;

namespace ParsingTree
{
    ///Operand class. Contains integer value and and its return method.
    public class Operand
    {
        protected int value;

        public Operand(int value = 0)
        {
            this.value = value;
        }

        virtual public int Result()
        {
            return value;
        }

        virtual public void Print()
        {
            Console.Write(" {0}", value);
        }
    }
}