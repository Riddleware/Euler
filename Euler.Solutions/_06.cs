namespace Euler.Solutions
{
    public class _06 : ISolution<long, long>
    {
        public long Run(long x)
        {
            long sumSq = 0, sqSum = 0;

            for (var i = 1; i <= x; i++)
                sumSq += (i * i);

            for (var i = 1; i <= x; i++)
                sqSum += i;

            sqSum *= sqSum;

            return sqSum - sumSq;
        }
    }
}