using System;
using System.Numerics;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _53 : ISolution<int, long>
    {

        BigInteger CombinatronicFormula(BigInteger n, BigInteger r)
        {
            return (n.Factorial() / (r.Factorial() * (n - r).Factorial()));
        }

        public long Run(int _ = 0)
        {
            long res = 0;// CombinatronicFormula(23, 10);
            //return res;
            for (int n = 23; n <= 100; n++)
            {
                for (int r = 0; r <= n; r++)
                {
                    if (CombinatronicFormula(n, r) > 1000000)
                        res++;
                }
            }

            return res;
        }
    }
}