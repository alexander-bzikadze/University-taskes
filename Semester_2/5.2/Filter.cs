using System;
using System.Collections.Generic;

namespace Filter
{
    public static class FilterClass
    {
        static public List<int> Filter(List<int> list, Func<int, bool> f)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < list.Count; ++i)
            {
                if (f(list[i]))
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }
    }
}