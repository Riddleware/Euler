using Euler.Lib;

namespace Euler.Solutions
{
    public class _03 : ISolution<long[], long>
    {
        public long Run(long[] args)
        {
            long n = args[0];

            if (n.IsPrime())
                return n;

            long ret = 0, p = 2;
            while (p < n / p)
            {
                p = p.GetNextPrime();
                if (n % p == 0)
                    ret = p;
            }

            return ret;
        }
    }
}