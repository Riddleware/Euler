using System;
using System.Collections.Generic;
using System.Linq;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _21 : ISolution<long, long>
    {
        public long Run(long n)
        {
            var amigos = new List<long>();

            List<Tuple<long, long>> a = new List<Tuple<long, long>>();
            for (long x = 2; x < n; x++)
            {
                if (amigos.Contains(x))
                    continue;

                var i = x.GetProperDivisorSum();
                if (x != i)
                {
                    if (i.GetProperDivisorSum() == x)
                    {
                        amigos.Add(i);
                        amigos.Add(x);
                    }
                }
            }

            return amigos.Sum();
        }
    }
}