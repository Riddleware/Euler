using Euler.Lib;

namespace Euler.Solutions
{
    public class _10 : ISolution<bool, long>
    {
        public long Run(bool _ = true)
        {
            long ret = 0;
            long prime = 2;
            while (prime < 2000000)
            {
                ret += prime;
                prime = prime.GetNextPrime();
            }

            return ret;
        }
    }
}