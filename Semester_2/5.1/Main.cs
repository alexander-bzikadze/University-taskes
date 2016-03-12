using System;
using System.Collections.Generic;
using Map;

namespace Map
{
    class CL
    {
        public static void Main()
        {
            List<int> list = Map.MapClass.Map(new List<int>() {1, 2, 3}, x => x * 2);
            foreach (int element in list)
            {
                Console.Write("{0} ", element);
            }
            Console.WriteLine();
        }
    }
}