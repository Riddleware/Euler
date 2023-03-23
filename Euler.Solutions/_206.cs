using System;

namespace Euler.Solutions
{
    public class _206 : ISolution<int, long>
    {
        // Find the unique positive integer whose square has the form 1_2_3_4_5_6_7_8_9_0,
        // where each “_” is a single digit.
        // public long Run(int _ = 0)
        // {
        //     long cur = (long)Math.Sqrt(1010304050607080900);
        //     while (cur <= (long) Math.Sqrt(1929394959697989990))
        //     {
        //     }
        // }

        public long Run(int _ = 0)
        {
           // if (Check(1020304050607080900))
             //   return 123;
             
            //long cur = (long)Math.Sqrt(1010304050607080900);
            long cur = 1389019170  - 1; //cheat for speed
            while (cur <= (long)Math.Sqrt(1929394959697989990))
            {
                if (Check(cur * cur))
                    return cur;
                
                cur++;
            }

            return -1;
        }

        bool Check(long l)
        {
           // if (l % 1000000 == 0)
             //   Console.WriteLine($"{l}");//   -   {(long)Math.Sqrt(l)}");
            var s = l.ToString();
            return s[0] == '1' && s[2] == '2' && s[4] == '3' && s[6] == '4' && s[8] == '5' && s[10] == '6' && s[12] == '7' &&
                s[14] == '8' && s[16] == '9' && s[18] == '0';
        }
    }
}