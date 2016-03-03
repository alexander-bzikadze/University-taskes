using System;

namespace Calculator
{
    class ConsoleMain
    {
        public static void Main()
        {
            IStack stack;
            Console.WriteLine("Type:\n -2 to use Stack on references;\n -1 to use List as an Stack;\n -0 to use Stack on an Array.");
            ushort command = Convert.ToUInt16(Console.ReadLine());
            while (command > 2)
            {
                Console.WriteLine("Wrong input! Try again.");
                command = Convert.ToUInt16(Console.ReadLine());
            }
            if (command == 2)
            {
                stack = new ReferenceStack();
            }
            else if (command == 1)
            {
                stack = new List();
            }
            else
            {
                stack = new ArrayStack();
            }
            Calculator calc = new Calculator(stack);

            calc.Push(9);
            calc.Push(4);
            calc.Subtract();
            calc.Push(2);
            calc.Push(6);
            calc.Add();
            calc.Multiply();
            calc.Push(4);
            calc.Divide();
            Console.WriteLine("The result of classic expression is {0}.", calc.Result());
        }
    }
}