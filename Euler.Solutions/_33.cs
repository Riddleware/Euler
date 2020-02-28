
namespace Euler.Solutions
{
    public class _33
    {
        public static int Run()
        {
            int num = 1, denum = 1;
            for (int i = 11; i < 100; i++)
            {
                int t = i % 10;
                int s = t * 10 + 1;

                for (int d = s; d < s + 9; d++)
                {
                    if (i == d)
                        continue;

                    decimal d1 = (decimal) i / (decimal) d;
                    decimal d2 = (decimal) (i / 10) / (decimal) (d % 10);
                    if (d1 == d2)
                    {
                        num *= i / 10;
                        denum *= d % 10;
                    }
                }
            }

            while (num % 2 == 0 && denum % 2 == 0)
            {
                num /= 2;
                denum /= 2;
            }

            return denum;
        }
    }
}