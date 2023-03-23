using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.Lib;


namespace Euler.Solutions
{
    public class _58 : ISolution<int, long>
    {
        // Starting with 1 and spiralling anticlockwise in the following way, a square spiral with side length 7 is formed.
        // 65                60          57  91           
        //    37' 36  35  34  33  32  31'                   28                     26   
        //    38  17' 16  15  14  13' 30                        20               18
        //    39  18  5'  4   3'  12  29                           12         10
        //    40  19  6   1   2   11  28                               4   2
        // 70 41  20  7'  8   9   10  27                               6   8  
        //    42  21  22  23  24  25  26                           14        16
        //    43' 44  45  46  47  48  49 50                     22              24 
        // 73                            81                 30                     32
        // It is interesting to note that the odd squares lie along the bottom right diagonal, but what is more
        // interesting is that 8 out of the 13 numbers lying along both diagonals are prime; that is, a ratio of 8/13 ≈ 62%.
        //
        // If one complete new layer is wrapped around the spiral above, a square spiral with side length 9 will
        // be formed. If this process is continued, what is the side length of the square spiral for which the
        // ratio of primes along both diagonals first falls below 10%?
        
        private long nw = 5, ne = 3, sw = 7, se = 9;
        private long totPrimes = 3;

        void CountPrimes(long l)
        {
            if (l.IsPrime())
                totPrimes++;
        }

        bool Check(long iter)
        {
            CountPrimes(nw);
            CountPrimes(ne);
            CountPrimes(sw);
            CountPrimes(se);
            double pct = (double)totPrimes / (double)(iter * 4 + 1) * 100.0;
            // Console.WriteLine(pct);
            return pct < 10.0;
        }

        public long Run(int _ = 0)
        {
            long iter = 1;

            do
            {
                nw += 8 * iter + 4;
                ne += 8 * iter + 2;
                sw += 8 * iter + 6;
                se += 8 * iter++ + 8;
            } while (!Check(iter));
            
            return iter * 2 + 1;
        }
    }
}