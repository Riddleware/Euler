namespace Euler.Lib
{
    public class Utils
    {
        public static bool IsPythTriplet(long a, long b, long c)
        {
            return a * a + b * b == c * c;
        }
    }
}
