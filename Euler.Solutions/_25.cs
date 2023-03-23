using Euler.Lib;

namespace Euler.Solutions
{
    public class _25 : ISolution<int, long>
    {
        public long Run(int n)
        {
            long ret = 2;
            BigInt prev1 = new BigInt(1), prev2 = new BigInt(1);
            BigInt cur = new BigInt(0);

            while (cur.Len < n)
            {
                cur = prev1 + prev2;
                prev1 = prev2;
                prev2 = cur;

                ret++;
            }

            //Console.WriteLine($"F({ret}) = {cur}");
            return ret;
        }
    }
}