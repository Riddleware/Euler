using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime;

namespace Euler.Solutions
{
    public class _719 : ISolution<long,long>
    {
        // Number Splitting
        public long Run(long _ = 1000000000000)
        {
            long res = 0;

            for (long i = 2; i <= Math.Sqrt(_); i++)
            {
                if (Check(i, i*i))
                {
                    res += i * i;
                    // Console.WriteLine(i*i);
                }
            }

            return res;
        }

        bool Check(long n, long m)
        {
            if (m < n)
                return false;
            if (n == m)
                return true;

            long t = 10;
            while (t < m)
            {
                var q = Math.DivRem(m, t, out long r);
                if (r < n && Check(n - r, q))
                    return true;
                t *= 10;
            }

            return false;
        }
    }
}