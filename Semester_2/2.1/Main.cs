using System;

namespace Stack
{
    class ConsoleMain
    {
        public static void Main()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            Console.WriteLine(stack.Top());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine("Hi there!");
        }
    }
}