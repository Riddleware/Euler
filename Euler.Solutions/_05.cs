namespace Euler.Solutions
{
    public class _05 : ISolution<long, long>
    {
        public long Run(long x)
        {
            long ret = x;
            bool found = false;
            while (!found)
            {
                ret++;

                found = true;
                for (long i = x; i >= 2; i--)
                {
                    if (ret % i != 0)
                    {
                        found = false;
                        break;
                    }
                }
            }

            return ret;
        }
    }
}