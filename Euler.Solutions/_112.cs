using System;

namespace Euler.Solutions
{
    public class _112 : ISolution<long, long>
    {
        // Working from left-to-right if no digit is exceeded by the digit to its left it is called an increasing number; for example, 134468.
        //
        // Similarly if no digit is exceeded by the digit to its right it is called a decreasing number; for example, 66420.
        //
        // We shall call a positive integer that is neither increasing nor decreasing a "bouncy" number; for example, 155349.
        //
        // Clearly there cannot be any bouncy numbers below one-hundred, but just over half of the numbers below
        // one-thousand (525) are bouncy. In fact, the least number for which the proportion of bouncy numbers first
        // reaches 50% is 538.
        //
        // Surprisingly, bouncy numbers become more and more common and by the time we reach 21780 the proportion of b
        // ouncy numbers is equal to 90%.
        //
        // Find the least number for which the proportion of bouncy numbers is exactly 99%.
        public long Run(long _ = 0)
        {
            long res = 0;

            long countB = 0;
            long tot = 1;
            while (true)
            {
                //IsIncm(123456);
                if (!IsDecm(tot) && !IsIncm(tot))
                    countB++;

                var pct = (double) countB / (double) tot * 100.00;
                if (pct == 99)
                {
                    Console.WriteLine($"{tot} -- {countB}  -- {pct}");
                    return tot;
                }

                if (pct == 90)
                    Console.WriteLine($"{tot} -- {countB}  -- {pct}");
                
                tot++;
            }
            
            return res;
        }

        bool IsIncm(long n)
        {
            long div = 10;
            long prev = 10;
            while (n > div)
            {
                var t = (n % div) / (div/10);
                if (t >= prev)
                    return false;
                div *= 10;
                prev = t;
            }

            return true;
        }
        
        bool IsDecm(long n)
        {
            long div = 10;
            long prev = 0;
            while (n > div)
            {
                var t = (n % div) / (div/10);
                if (t <= prev)
                    return false;
                div *= 10;
                prev = t;
            }

            return true;
        }

        bool IsInc(long n)
        {
            char prev = (char)0;
            foreach (var c in n.ToString())
            {
                if (!(c >= prev))
                {
                    return false;
                }

                prev = c;
            }

            return true;
        }

        bool IsDec(long n)
        {
            char prev = (char)60;
            foreach (var c in n.ToString())
            {
                if (!(c <= prev))
                {
                    return false;
                }

                prev = c;
            }

            return true;
        }
    }
}