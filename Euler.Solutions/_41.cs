using Euler.Lib;
using System;

namespace Euler.Solutions
{
    public static class _41
    {
        public static long GetPreviousPDPrime(this long p)
        {
            for (long i = p - 1; ; i--)
            {
                if (i.IsPanDigital(false) && i.IsPrime())
                    return i;
                if (i%100000==0)
                    Console.WriteLine(i);
            }
        }
        public static long Run()
        {
            //Note: Nine numbers cannot be done(1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 = 45 => always dividable by 3)
            //Note: Eight numbers cannot be done(1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 = 36 => always dividable by 3)

            long p = 7654322;
            return p.GetPreviousPDPrime();//7652413

        }
    }
}
