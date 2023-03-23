using Euler.Lib;

namespace Euler.Solutions
{
    public class _20 : ISolution<int, long>
    {
        public long Run(int num)
        {
            BigInt r = new BigInt(100);
            for (int i = num - 1; i > 0; i--)
            {
                r *= i;
            }

            return r.SumOfDigits();
        }
    }
}