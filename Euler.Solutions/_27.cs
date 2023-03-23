using Euler.Lib;

namespace Euler.Solutions
{
    public class _27 : ISolution<bool, long>
    {
        public long Run(bool _ = true)
        {
            MostPrimes p = new MostPrimes {NumPrimes = 0};

            long n = 0, a = -999, b = -1000;
            long MaxA = 999, MaxB = 1000;
            for (a = 0 - MaxA; a <= MaxA; a++)
            for (b = 0 - MaxB; b <= MaxB; b++)
            {
                n = 0;
                while (((n * n) + a * n + b).IsPrime())
                    n++;

                if (n - 1 > p.NumPrimes)
                {
                    p.NumPrimes = n - 1;
                    p.a = a;
                    p.b = b;
                }
            }

            return p.a * p.b;
        }

        class MostPrimes
        {
            public long NumPrimes { get; set; }
            public long a { get; set; }
            public long b { get; set; }
        }
    }
}