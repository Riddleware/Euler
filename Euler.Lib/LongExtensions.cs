using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Lib
{
    public static class LongExtensions
    {
        public static List<long> GetPrimeList(this long l, long max)
        {
            var list = new List<long>();
            var p = l.GetNextPrime();
            while (p < max + 1)
            {
                list.Add(p);
                p = p.GetNextPrime();
            }

            return list;
        }

        public static bool IsTruncatablePrime(this long l)
        {
            var s = l.ToString();
            var temp = s;
            while (temp.Length > 0)
            {
                if (!long.Parse(temp).IsPrime())
                    return false;
                temp = temp.TruncL();
            }

            temp = s;
            while (temp.Length > 0)
            {
                if (!long.Parse(temp).IsPrime())
                    return false;
                temp = temp.TruncR();
            }
            Console.WriteLine(l);
            return true;
        }

        public static string ToBinaryString(this long l)
        {
            var s = "";
            while (l >= 1)
            {
                s = s.Insert(0, (l % 2).ToString());
                l /= 2;
            }
            return s;
        }

        public static long Factorial(this long l)
        {
            long res = 1, n = l;
            while (l > 0)
            {
                res *= l--;
            }
            return res;
        }

        public static bool IsPanDigital(this long n, bool _1To9 = true)
        {
            return n.ToString().IsPanDigital(_1To9);
        }

        public static long Millions(this long n)
        {
            return n / 1000000;
        }

        public static long Thousands(this long n)
        {
            var ret = n / 1000;
            if (ret >= 1000)
            {
                decimal nD = ret / 1000M;
                ret = (long)nD;
                ret = (long)((nD - ret) * 1000);
            }

            return ret;
        }

        public static long Hundreds(this long n)
        {
            var ret = n / 100;
            if (ret >= 10)
            {
                decimal nD = ret / 10M;
                ret = (long)nD;
                ret = (long)((nD - ret) * 10);
            }

            return ret;
        }
        
        public static int CollatzChainCount(this long n)
        {
            int ret = 0;

            if (n == 1)
                return 1;
            ret++;
            long res = n % 2 ==0?n/2:3*n+1;

            ret += res.CollatzChainCount();

            return ret;
        }

        public static int ToInt(this char c)
        {
            return c - 48;           
        }

        public static bool IsAbundant(this long n)
        {
            return GetProperDivisorSum(n) > n;
        }

        public static bool IsPerfect(this long n)
        {
            return GetProperDivisorSum(n) == n;
        }

        public static bool IsDeficient(this long n)
        {
            return GetProperDivisorSum(n) < n;
        }

        public static long GetDivisorSum(this long n)
        {
            long ret = 0;
            // Note that this loop runs till square root 
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    // If divisors are equal, print only one 
                    if (n / i == i)
                        ret += i;

                    else // Otherwise print both 
                        ret += i + n / i;
                }
            }

            return ret;
        }

        public static long GetProperDivisorSum(this long n)
        {
            return GetProperDivisors(n).Sum();
        }

        public static List<long> GetProperDivisors(this long n)
        {
            var d = GetDivisors(n);
            d.Remove(n);
            return d;
        }

        public static List<long> GetDivisors(this long n)
        {
            var ret = new List<long>();
            // Note that this loop runs till square root 
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    // If divisors are equal, print only one 
                    if (n / i == i)
                        ret.Add(i);

                    else // Otherwise print both 
                    {
                        ret.Add(i);
                        ret.Add (n / i);
                    }
                }
            }

            return ret;
        }

        public static long GetDivisorCount(this long l)
        {
            if (l == 1)
                return 1;

            long ret = 1, curNum = 0;
            int exp = 1;
            var pF = l.GetPrimeFactorisation();
            foreach (var f in pF)
            {
                if (f != curNum)
                {
                    ret *= exp;
                    curNum = f;
                    exp = 1;
                }

                exp++;
            }

            if (exp > 0)
                ret *= exp;
            return ret;
        }

        public static List<long> GetPrimeFactorisation(this long l)
        {
            if (l == 1)
                return new List<long>();

            var ret = new List<long>();
            long nP = 2;

            while (l % nP != 0)
            {
                nP = nP.GetNextPrime();
            }
            ret.Add(nP);

            var rem = l / nP;
            if (!rem.IsPrime())
                ret.AddRange((rem).GetPrimeFactorisation());
            else ret.Add(rem);

            return ret;
        }

        public static bool IsPalindrome(this long p)
        {       
            return p.ToString().IsPalindrome();
        }

        public static long Sq(this long l)
        {
            return l * l;
        }

        public static bool IsPrime(this long p)
        {
            if (p < 0)
                return false;

            if (p == 2 || p == 5)
                return true;
            if (p == 1 || p % 2 == 0 || p % 5 == 0)
                return false;

            long sP = (int) Math.Sqrt(p);

            for (long i = 3; i <= sP; i++)
            {
                if (p % i == 0)
                    return false;
            }

            return true;
        }

        public static long GetNextPrime(this long p)
        {
            for (long i = p + 1;; i++)
                if (i.IsPrime())
                    return i;
        }
      
    }
}

