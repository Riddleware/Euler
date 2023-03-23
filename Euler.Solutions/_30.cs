using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    public class _30 : ISolution<bool, long>
    {
        public long Run(bool b = true)
        {
            //using array to see what the numbers are
            var arr = new List<long>();

            for (int i = 2; i < 1000000; i++)
            {
                long sum = 0;
                foreach (var c in i.ToString())
                {
                    sum += (long) Math.Pow(double.Parse(c.ToString()), 5);
                }

                if (sum == i)
                    arr.Add(i);
            }

            return arr.Sum();
        }
    }
}