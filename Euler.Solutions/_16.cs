using Euler.Lib;

namespace Euler.Solutions
{
    public class _16 : ISolution<long, long>
    {
        public long Run(long pow)
        {
            BigInt r = new BigInt(2);
            for (int i = 1; i < pow; i++)
            {
                r *= 2;
            }

            return r.SumOfDigits();
        }
    }
}