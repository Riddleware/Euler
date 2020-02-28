using Euler.Lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    public class _34
    {
        //Cache
        private static Dictionary<long, long> DigitFactorials = new Dictionary<long, long>();
        static long Fac(long l)
        {
            if (!DigitFactorials.ContainsKey(l))
            {                
                return l.Factorial();
            }
            else
            {
                return DigitFactorials[l];
            }
        }

        static bool IsSumOfDigitFactorials(long i)
        {
            long sum = 0;
            foreach (var digit in i.ToString())
            {
                sum += Fac(long.Parse(digit.ToString()));
            }

            return sum == i;
        }

        public static long Run()
        {
            long num;
            List<long> nums = new List<long>();
            for (long i = 3; i < 100000; i++)
            {
                if (IsSumOfDigitFactorials(i))
                {
                    Console.WriteLine(i);
                    nums.Add(i);
                }
            }

            return nums.Sum();
        }
    }
}
