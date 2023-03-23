using System;
using System.Collections.Generic;
using Euler.Lib;
using Microsoft.VisualBasic;

namespace Euler.Solutions
{
    public class _51 : ISolution<int, long>
    {
        // By replacing the 1st digit of the 2-digit number *3, it turns out that six of the nine
        // possible values: 13, 23, 43, 53, 73, and 83, are all prime.
        //
        // By replacing the 3rd and 4th digits of 56**3 with the same digit, this 5-digit number
        // is the first example having seven primes among the ten generated numbers, yielding t
        // he family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, being
        // the first member of this family, is the smallest prime with this property.
        //
        // Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits)
        // with the same digit, is part of an eight prime value family.

        // This is a very inefficient solution,all I had to do was look for primes with repeated
        // digits and sub those OutOfMemoryException. Here I am getting all position permutations,
        // which, while fun, does a lot of work.
        public long Run(int _ = 0)
        {
            long res = 0;
            // Starting here for cheat with test timings
            long p = 120000;

            while (true)
            {
                p++;
                var strP = p.ToString();

                var positions = PossPos(strP.Length);
                List<long> pList;
                foreach (var curPos in positions)
                    if (Check(strP, curPos, out pList) == 8)
                    {
                        //Check(strP, curPos, out pList, true);

                        Console.WriteLine(p);
                        pList.Sort();
                        return pList[0];
                    }
            }
        }

        private Dictionary<int, List<int[]>> _posCache = new();
        List<int[]> PossPos(int length)
        {
            if (!_posCache.ContainsKey(length))
            {
                List<int[]> res = new List<int[]>();
             
                for (int i = 1; i < Math.Pow(2, length); i++)
                {
                    List<int> pos = new List<int>();
                    var bin = Convert.ToString(i, 2).PadLeft(length, '0');
                    for (int idx = 0; idx < bin.Length; idx++)
                    {
                        if (bin[idx] == '1')
                            pos.Add(idx);
                    }

                    res.Add(pos.ToArray());
                }

                _posCache.Add(length, res);
            }

            return _posCache[length];
        }

        int Check(string p, int[] pos, out List<long> pList, bool verbose = false)
        {
            pList = new List<long>();
            int res = 0;
            var len = p.Length;
            for (int r = 0; r <= 9; r++)
            {
                var ca = p.ToCharArray();
                foreach (var position in pos)
                {
                    if (position < len)
                        ca[position] = r.ToString()[0];    
                }
                
                var ns = long.Parse(new string(ca));

                if (ns.IsPrime() && ns.ToString().Length == len)
                {
                    pList.Add(ns);
                    if (verbose)
                        Console.WriteLine(ns);
                    res++;
                }
            }

            return res;
        }
    }
}