using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _46
    {
        public static long Run()
        {
            long res = 0;

            for (res = 1;; res += 2)
            {
                var d = res.GetProperDivisors();
                if (d.Count > 1)
                {
                    long p = 1;
                    bool found = false;
                    long sq = 0;
                    while (p < res && !found)
                    {
                        p = p.GetNextPrime();
                        long temp = p;
                        sq = 0;
                        while (temp < res)
                        {
                            sq++;
                            temp = p + 2 * (sq * sq);
                            if (temp == res)
                            {
                                found = true;
                                continue;
                            }
                        }
                        
                    }
                    Console.WriteLine($"{res} =  {p} + 2 x {sq}sq");
                    
                    if (!found)
                        return res;
                }
            }

            return res;
        }
    }
}
