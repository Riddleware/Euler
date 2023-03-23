using System;
using System.Collections.Generic;
using System.Linq;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _808 : ISolution<int,long>
    {
        // Both 169 and 961 are the square of a prime. 169 is the reverse of 961.
        //
        // We call a number a reversible prime square if:
        //
        // It is not a palindrome, and
        //     It is the square of a prime, and
        //     Its reverse is also the square of a prime.
        // 169 and 961 are not palindromes, so both are reversible prime squares.
        //
        // Find the sum of the first 50 reversible prime squares.

        public long Run(int _ = 0)
        {
            List<long> revP = new();
            long cur = 11;

            while (revP.Count != 50)
            {
                cur = cur.GetNextPrime();
                long sq = cur * cur;
                if (!sq.IsPalindrome())
                {
                    var rSq = long.Parse(Utils.Reverse<long>(sq));
                    var sqRrsq = Math.Sqrt(rSq);
                    
                    if(sqRrsq % 1 == 0 && ((long)sqRrsq).IsPrime())
                    {
                        Console.WriteLine($"{revP.Count} -  {cur}  -  {sq}   -   {rSq}");
                        revP.Add(sq);
                    }
                }
            }

            return revP.Sum();
        }
    }
}