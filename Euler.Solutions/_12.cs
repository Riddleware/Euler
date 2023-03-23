using Euler.Lib;

namespace Euler.Solutions
{
    public class _12 : ISolution<bool, long>
    {
        public long Run(bool _ = true)
        {
            long ret = 0, cur = 0, tri = 0;
            while (++cur > 0)
            {
                tri += cur;
                if (tri.GetDivisorCount() > 500)
                    return tri;
            }

            return ret;
        }
    }
}