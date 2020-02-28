using Euler.Lib;

namespace Euler.Solutions
{
    public class _36
    {      
        public static long Run()
        {
            long res = 0;
            for (long l = 0; l < 1000000; l++)
            {
                if (l.IsPalindrome() && l.ToBinaryString().IsPalindrome())
                {
                    res += l;
                }
            }
            return res;
        }
    }
}
