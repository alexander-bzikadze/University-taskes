using System;
using System.Collections.Generic;

namespace Factorial
{
    ///class that coints factorial
    class Factorial
    {
        ///takes integer n from the console and prints n!
        static public void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(CountFactorial(n));
        }

        static private bool[] GetSieve(int n)
        {
            bool[] sieve = new bool[n + 1];
            for (int i = 2; i <= n; ++i)
            {
                if (!sieve[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        sieve[j] = true;
                    }
                }
            }
            return sieve;
        }

        static private List<Tuple<int, int>> Factorization(int n)
        {
            bool[] sieve = GetSieve(n);
            List<Tuple<int, int>> simpleWithItsExp = new List<Tuple<int, int>>();
            for (int i = 2; i <= n; ++i)
            {
                if (!sieve[i])
                {
                    int k = n / i;
                    int resultExp = 0;
                    while (k > 0)
                    {
                        resultExp += k;
                        k /= i;
                    }
                    simpleWithItsExp.Add(new Tuple<int, int>(i, resultExp));
                }
            }
            return simpleWithItsExp;
        }

        static private int Exponentiation(int a, int exp)
        {
            int result = 1;
            for (int i = exp; i > 0; i >>= 1)
            {
                if (i % 2 != 0)
                {
                    result *= a;
                }
                a *= a;
            }
            return result;
        }

        static private int CountFactorial(int n)
        {
            if (n < 0)
            {
                return 0;
            }
            if (n < 2)
            {
                return 1;
            }
            int result = 1;
            List<Tuple<int, int>> factorizationList = Factorization(n);
            for (int i = 0; i < factorizationList.Count; i++)
            {
                result *= Exponentiation(factorizationList[i].Item1, factorizationList[i].Item2);
            }
            return result;
        }
    }
}