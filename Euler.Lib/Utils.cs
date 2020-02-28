using System.Collections.Generic;

namespace Euler.Lib
{
    public class Utils
    {
        public static bool IsPythTriplet(long a, long b, long c)
        {
            return a * a + b * b == c * c;
        }

        public static long GetLargestProduct(List<int> buf, int a)
        {
            long longest = 0;
            int tries = buf.Count + 1 - a;

            for (int t = 0; t < tries; t++)
            {
                var tot = GetProduct(buf, t, a);
                if (tot > longest)
                    longest = tot;
            }

            return longest;
        }

        public static long GetProduct(List<int> buf, int start, int a)
        {
            long sProd = 1;
            for (int ind = start; ind < start + a; ind++)
                sProd *= buf[ind];

            return sProd;
        }
    }
}
