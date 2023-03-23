using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Euler.Lib
{
    public class Utils
    {
        public static bool IsPalindrome<T>(T p)
        {
            return p.ToString().IsPalindrome();
        }

        public static string Reverse<T>(T p)
        {
            var s = p.ToString();
            var r = string.Empty;

            foreach (var c in s)
                r = r.Insert(0, c.ToString());

            return r;
        }

        public static bool IsPythTriplet(long a, long b, long c)
        {
            return a * a + b * b == c * c;
        }

        public static long GetLargestProduct(List<int> buf, int a)
        {
            long longest = 0;
            int tries = buf.Count + 1 - a;

            for (int t = 0; t < tries; t++)
            {
                var tot = GetProduct(buf, t, a);
                if (tot > longest)
                    longest = tot;
            }

            return longest;
        }

        public static long GetProduct(List<int> buf, int start, int a)
        {
            long sProd = 1;
            for (int ind = start; ind < start + a; ind++)
                sProd *= buf[ind];

            return sProd;
        }
        
        public static List<long> GetTriangulars(int count, int start = 1)
        {
            var t = new List<long>();
            for (double n = start; n < count; n++)
            {
                //t.Add((long) ((n / 2) * (n + 1)));
                t.Add(Triangular(n));
            }

            return t;
        }
        
        static public long Triangular(double n)
        {
            return (long) ((n / 2) * (n + 1));
        }
        
        public static long Pentagonal(long l)
        {
            return l * ((3 * l) - 1) / 2;
        }
        
        public static bool IsHexagonal(long N)
        {
            float val = 8 * N + 1;
            float x = 1 + (float)Math.Sqrt(val);
 
            // Calculate the value for n
            float n = (x) / 4;
 
            // Check if n - floor(n)
            // is equal to 0
            return (n - (long) n) == 0;
        }
        
        public static bool IsPentagonal(long N)
        {
            // Get positive root of
            // equation P(n) = N.
            double n = (1 + Math.Sqrt(24 * N + 1)) / 6;
 
            // Check if n is an integral
            // value of not. To get the
            // floor of n, type cast to int.
            return (n - (long)n) == 0;
        }
        
        public static List<long> GetPentagonals(int count, int start = 1)
        {
            var t = new List<long>();
            for (int n = start; n < count; n++)
            {
                t.Add(Pentagonal(n));
            }

            return t;
        }
    }
}
