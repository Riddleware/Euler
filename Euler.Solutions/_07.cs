using Euler.Lib;

namespace Euler.Solutions
{
    public class _07 : ISolution<long, long>
    {
        public long Run(long x)
        {
            long ret = 1;
            for (int i = 0; i < x; i++)
                ret = ret.GetNextPrime();
            return ret;
        }
    }
}