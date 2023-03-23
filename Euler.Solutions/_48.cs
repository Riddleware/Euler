using System;

namespace Euler.Solutions
{
    public class _48 : ISolution<int, string>
    {
        // The series, 1n1 + 2n2 + 3n3 + ... + 10n10 = 10405071317.
        //
        // Find the last ten digits of the series, 1n1 + 2n2 + 3n3 + ... + 1000n1000.

        public string Run(int _ = 0)
        {
            double res = 0;

            for (int i = 1; i <= 1000; i++)
            {
                long pow = i;
                
                for (long x = 0; x < i - 1; x++)
                {
                    pow *= i;
                    var strPow = pow.ToString();
                    if (strPow.Length > 10)
                    {
                        strPow = strPow[^10..];
                        
                        pow = long.Parse(strPow);
                    }
                }

                res += pow;
            }

            return res.ToString()[^10..].PadLeft(10, '0');
        }
    }
}