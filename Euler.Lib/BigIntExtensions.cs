using System.Numerics;

namespace Euler.Lib
{
    public static class BigIntExtensions
    {
        public static BigInteger Factorial(this BigInteger l)
        {
            BigInteger res = 1, n = l;
            while (l > 0)
            {
                res *= l--;
            }

            return res;
        }

        public static BigInteger DigitSum(this BigInteger i)
        {
            var s = i.ToString();
            BigInteger res = 0;
            foreach (var c in s)
            {
                res += int.Parse(c.ToString());
            }

            return res;
        }

        public static BigInteger Pow(this BigInteger l, int e)
        {
            var r = l;
            while (--e > 0)
                r *= l;

            return r;
        }
    }
}