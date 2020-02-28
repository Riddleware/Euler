using Euler.Lib;

namespace Euler.Solutions
{
    public class _37
    {     
        public static long Run()
        {
            long i = ((long)7).GetNextPrime();
            long res = 0, count =0;
            while (count < 11)
            {
                if (i.IsTruncatablePrime())
                {
                    count++;
                    res+=i;
                }

                i = i.GetNextPrime();
            }

            return res;//748317
        }
    }
}
