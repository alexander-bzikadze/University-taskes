using System;

namespace List
{
    class ConsoleMain
    {
        static public void Main()
        {
            List list = new List();
            for (int i = 0; i < 10; ++i)
            {
                list.Add(i);
            }
            list.DeleteElement(8);
            list.DeleteElement(9);
            list.DeleteElement(11);
            list.DeleteElement(1);
            list.DeleteElement(3);
            list.Pop();
            Console.WriteLine(list.Top());
            list.Print();
            Console.WriteLine(list.Search(5));
            Console.WriteLine(list.Search(11));
        }
    }
}