namespace Euler.Solutions
{
    public class _28 : ISolution<bool, long>
    {
        public long Run(bool b = true)
        {
            long ret = 1;
            for (var c = 2; c < 10; c += 2)
                ret += TotalUp(c);
            return ret;

            long TotalUp(long seed)
            {
                long r = 0;
                long lastNum = 1;
                for (int i = 0; i < 500; i++)
                {
                    var t = lastNum + (8 * i) + seed;
                    r += t;
                    lastNum = t;
                }

                return r;
            }
        }
    }
}