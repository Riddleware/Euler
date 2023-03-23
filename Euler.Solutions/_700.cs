using System;
using System.Numerics;

namespace Euler.Solutions
{
    public class _700 : ISolution<long,BigInteger>
    {
        // Not Solved, needs Maffs.
        // Leonhard Euler was born on 15 April 1707.
        //
        // Consider the sequence 1504170715041707n mod 4503599627370517.
        //                          8912517754604
        //     An element of this sequence is defined to be an Eulercoin if it is strictly smaller than all previously found Eulercoins.
        //
        //     For example, the first term is 1504170715041707 which is the first Eulercoin.
        //     The second term is 3008341430083414 which is greater than 1504170715041707 so is not an Eulercoin.
        //     However, the third term is 8912517754604 which is small enough to be a new Eulercoin.
        //
        //     The sum of the first 2 Eulercoins is therefore 1513083232796311.
        //
        // Find the sum of all Eulercoins.
        private BigInteger f = 1504170715041707;
        private BigInteger m = 4503599627370517;
        
        BigInteger Coin(BigInteger n) => (f * n) % m;

        public BigInteger Run(long _ = 0)
        {
            BigInteger res = f;
            BigInteger smallestFound = f;
            for (BigInteger i = 2; i < 10000000000; i++)
            {//                           9692417347      
                var c = Coin(i);
                if (c < smallestFound)
                {
                    res += c;

                    var diff = smallestFound - c;
                    if (diff == 409165)
                    {
                        while (c >= 409165)
                        {
                            c -= 409165;
                            res += c;
                        }

                        return res;
                    }

                    BigInteger pctDiff = (diff / smallestFound) * 100;
                    Console.WriteLine($"{i} - {c}  - {res}  --  {diff}  --- {pctDiff}");
                      
                    smallestFound = c;   
                }
            }
            Console.WriteLine("Done");
            return res;
        }
    }
}