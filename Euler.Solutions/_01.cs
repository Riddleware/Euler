namespace Euler.Solutions
{
    public class _01 : ISolution<long[], long>
    {
        public long Run(long[] args)
        {
            long s = args[0], e = args[1];
            long ret = 0;

            while (s <= e)
            {
                ret += (s % 3 == 0 || s % 5 == 0) ? s : 0;
                s++;
            }

            return ret;
        }
    }
}