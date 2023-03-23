using Euler.Lib;

namespace Euler.Solutions
{
    public class _14 : ISolution<bool, long>
    {
        public long Run(bool _ = true)
        {
            long ret = 0;
            long highest = 0;
            long temp = 0;
            for (long num = 1; num < 1000000; num++)
            {
                temp = num.CollatzChainCount();

                if (temp > highest)
                {
                    highest = temp;
                    ret = num;
                }
            }

            return ret;
        }
    }
}