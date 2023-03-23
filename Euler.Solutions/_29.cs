using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    public class _29 : ISolution<int, long>
    {
        public long Run(int max)
        {
            var arr = new List<double>();

            for (int a = 2; a <= max; a++)
            for (int b = 2; b <= max; b++)
                arr.Add(Math.Pow(a, b));

            return arr.Distinct().ToList().Count;
        }
    }
}