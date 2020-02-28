using System.Collections.Generic;

namespace Euler.Lib
{
    public static class ListExtensions
    {
        public static int FindIndexOfLargestPair(this List<int> l)
        {
            int largest = 0;
            int ret = 0;
            for (int idx = 0; idx < l.Count - 1; idx++)
            {
                var t = l[idx] + l[idx + 1];
                if (t > largest)
                {
                    largest = t;
                    ret = idx;
                }
            }
            return ret;
        }
    }
}
