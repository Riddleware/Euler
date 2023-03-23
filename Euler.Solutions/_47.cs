using System;
using System.Linq;
using System.Threading;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _47 : ISolution<int, long>
    {
        // The first two consecutive numbers to have two distinct prime factors are:
        //
        // 14 = 2 × 7
        // 15 = 3 × 5
        //
        // The first three consecutive numbers to have three distinct prime factors are:
        //
        // 644 = 2² × 7 × 23
        // 645 = 3 × 5 × 43
        // 646 = 2 × 17 × 19.
        //
        // Find the first four consecutive integers to have four distinct prime factors each. What is the first of these numbers?
        public long Run(int x)
        {
            long res = 0;

            // starting close so don't have to rerun the whole thing again, could speed up by threading.
            long p = 134040;

            long count = 0;
            while (true)
            {
                var pf = p.GetPrimeFactorisation().Distinct();
                if (pf.Count() == 4)
                {
                    count++;
                    // Console.WriteLine($"{p}   {count}");
                }
                else
                {
                    count = 0;
                }

                if (count == 4)
                    return p - 3;
                p++;
            }

            return res;
        }

    }
}