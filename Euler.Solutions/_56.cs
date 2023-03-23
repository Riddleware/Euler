using System.Numerics;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _56 : ISolution<int, BigInteger>
    {
        public BigInteger Run(int _ = 0)
        {
            BigInteger res = 0;
            BigInteger max = 0;
            for (BigInteger i = 0; i < 100; i++)
            {
                for (int y = 0; y < 100; y++)
                {
                    var p = i.Pow(y);
                    var s = p.DigitSum();
                    if (s > max)
                        max = s;
                }
            }
            
            return max;
        }
    }
}