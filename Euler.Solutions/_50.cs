using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _50
    {
        public static long Run()
        {
            var res = 0;
            long p = 1;
            var primeCache = p.GetPrimeList(1000000);
            var found = new List<Tuple<long, int>>();
            var maxP = primeCache[primeCache.Count - 1];
            for (int i = 0; i< 4/*primeCache.Count-1*/; i++)
            {
                long temp = 0;
                int y = i;
                int c = 0;
                while (temp < primeCache[primeCache.Count-1])
                {
                    if (y > primeCache.Count - 1) break;

                    temp += primeCache[y++];
                    if (temp > maxP) break;
                    c++;
                    if (c > 1 && primeCache.Contains(temp))
                        found.Add(new Tuple<long, int>(temp, c));
                }
            }

            found = found.OrderBy(f => f.Item2).ToList();
            return found[found.Count-1].Item1;
        }
    }
}
