using Euler.Lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    public class _32
    {
        static bool IsPanDigitalDiv(long num, List<long> divs)
        {
            var div2 = num / divs[0];
            bool ret = $"{divs[0]}{div2}{num}".IsPanDigital();

            divs.RemoveAt(0);
            divs.Remove(div2);

            return ret;
        }

        static bool IsPanDigitalProduct(long x, long y)
        {
            return $"{x}{y}{x * y}".IsPanDigital();
        }        

        public static long Run()
        {
            var PanProducts = new List<long>();
          
            long cDiv = 0;
            for (long i = 1; i < 10000; i++)
            {
                var Divs = i.GetProperDivisors();
                while (Divs.Count > 0)
                {
                    cDiv = Divs[0];
                    if (IsPanDigitalDiv(i, Divs))
                    {
                        string s = $"{i / cDiv}{cDiv}{i}";
                        if (!PanProducts.Contains(i))
                            PanProducts.Add(i);
                        Console.WriteLine(s);
                    }
                }
            }
           
            return PanProducts.Sum(p=>p);//45222
        }
    }
}
