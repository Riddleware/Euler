using Euler.Lib;

namespace Euler.Solutions
{
    public class _09 : ISolution<bool, long>
    {
        public long Run(bool _ = true)
        {
            long ret = 0, a = 0, b, c;
            while (++a < 1000)
            {
                for (b = a + 1; b < 1000; b++)
                {
                    c = 1000 - (a + b);
                    if (Utils.IsPythTriplet(a, b, c))
                    {
                        return a * b * c;
                    }
                }
            }

            return ret;
        }
    }
}