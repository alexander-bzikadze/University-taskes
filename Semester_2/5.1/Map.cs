using System;
using System.Collections.Generic;

namespace Map
{
    /// Static class with one static method that returs list.
    public static class MapClass
    {
        /// Takes List<int> and Func<int, int> and returns list<int>, that is
        /// element[i] = f(list[i]) for any i.
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