using Euler.Lib;

namespace Euler.Solutions
{
    public class _35
    {      
        static bool IsCircularPrime(long p)
        {
            var s = p.ToString();
            if (s.Length>1 && 
                (s.Contains("2") || s.Contains("4") || s.Contains("5") || s.Contains("6") || s.Contains("8")))
                return false;

            for (int i = 0; i < s.Length-1; i++)
            {
                s = s.Rotate();
                if (!long.Parse(s).IsPrime())
                    return false;
            }

            return true;
        }

        public static int Run()
        {
            ///IsCircularPrime(197);

            long i = 2;
            int res = 0;
            while (i < 1000000)
            {
                if (IsCircularPrime(i))
                    res++;

                i = i.GetNextPrime();
            }

            return res;//55
        }
    }
}
