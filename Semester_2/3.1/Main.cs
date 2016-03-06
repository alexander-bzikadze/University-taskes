using System;
using ReferenceStack;

public class ConsoleMain
{
    public static void Main()
    {
        ReferenceStack.ReferenceStack stack =
            new ReferenceStack.ReferenceStack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Top());
        Console.WriteLine(stack.Top());
        stack.Pop();
        stack.Pop();
        try
        {
            stack.Pop();
        }
        catch (StackNullExeption e)
        {
            Console.WriteLine("It's alive, it's alive! {0}", e.Message);
        }
    }
}