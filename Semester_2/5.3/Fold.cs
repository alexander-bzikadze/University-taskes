using System;
using System.Collections.Generic;

namespace Fold
{
    public static class FoldClass
    {
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