using System;
using System.Collections.Generic;

namespace Filter
{
    /// A static class with one static method that returns list as a result.
    public static class FilterClass
    {
        /// Takes List<int> and Func<int, bool> and returns
        /// a list of elements, that returned true from the Func.
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