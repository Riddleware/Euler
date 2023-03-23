using Euler.Lib;

namespace Euler.Solutions
{
    public class _04 : ISolution<long, long>
    {
        public long Run(long p = 0)
        {
            long ret = 0;

            for (long x = 100; x < 1000; x++)
            {
                for (long y = 100; y < 1000; y++)
                {
                    if ((x * y).IsPalindrome())
                        ret = (x * y) > ret ? (x * y) : ret;
                }
            }

            return ret;
        }
    }
}