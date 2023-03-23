using System.Collections.Generic;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _23 : ISolution<bool, long>
    {
        public long Run(bool _ = true)
        {
            long ret = 0;
            List<long> abList = new List<long>();
            for (long i = 0; i < 24; i++)
            {
                ret += i;
                if (i >= 12 && i.IsAbundant())
                    abList.Add(i);
            }

            for (long i = 24; i <= 28123; i++)
            {
                if (!IsSumOfTwo(i))
                    ret += i;
                if (i.IsAbundant())
                    abList.Add(i);
            }

            return ret;

            bool IsSumOfTwo(long l)
            {
                for (int x = 0; x < abList.Count; x++)
                {
                    if (abList.Contains(l - abList[x]))
                        return true;
                }

                return false;
            }
        }
    }
}