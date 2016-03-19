using System;
using System.Collections.Generic;

namespace Fold
{
    /// A static class that contains one static method that returnes int
    /// that is gotten by changing input value into result appling elements
    /// of the taken list to taken func.
    public static class FoldClass
    {
        /// Takes List<int>, int and Func<int, int, int>, 
        /// then applies taken func to all elements step by step, 
        /// meaning taken int changes into output
        /// depending on taken list.
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