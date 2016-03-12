using System;
using System.Collections.Generic;

namespace Map
{
    public static class MapClass
    {
        static public List<int> Map(List<int> list, Func<int, int> f)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                list[i] = f(list[i]);
            }
            return list;
        }
    }
}