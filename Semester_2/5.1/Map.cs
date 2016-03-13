using System;
using System.Collections.Generic;

namespace Map
{
    public static class MapClass
    {
        static public List<int> Map(List<int> list, Func<int, int> f)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < list.Count; ++i)
            {
                result.Add(f(list[i]));
            }
            return result;
        }
    }
}