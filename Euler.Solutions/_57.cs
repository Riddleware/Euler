using System.Numerics;

namespace Euler.Solutions
{
    public class _57 : ISolution<int, long>
    {
        void DoThing(int n)
        {
            // a(n+1)= 2*b(n)+a(n)
            // b(n+1)= b(n) + a(n)
        }

        public long Run(int _ = 0)
        {
            BigInteger den = 1;
            BigInteger num = 1;
            
            int count = 0;

            for (int i = 0; i < 1000; i++)
            {
                num = num + 2 * den;

                den = num - den;

                if (num.ToString().Length > den.ToString().Length)
                    count += 1;
            }

            return count;
        }
    }
}