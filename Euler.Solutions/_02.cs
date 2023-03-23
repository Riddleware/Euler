namespace Euler.Solutions
{
    public class _02 : ISolution<long[], long>
    {
        public long Run(long[] args)
        {
            long e = args[0];

            long ret = 0, prev1 = 1, prev2 = 1, cur = 0;

            while (cur <= e)
            {
                cur = prev1 + prev2;
                ret += (cur % 2 == 0) ? cur : 0;
                prev1 = prev2;
                prev2 = cur;
            }

            return ret;
        }
    }
}