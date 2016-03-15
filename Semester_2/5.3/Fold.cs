using System;
using System.Collections.Generic;

namespace Fold
{
    /// A static class that contains one static method that returnes int.
    public static class FoldClass
    {
        /// Takes List<int>, int and Func<int, int, int> and returns int.
        static public int Fold(List<int> list, int first, 
Func<int, int, int> f)
        {
            int result = first;
            for (int i = 0; i < list.Count; ++i)
            {
                result = f(result, list[i]);
            }
            return result;
        }
    }
}