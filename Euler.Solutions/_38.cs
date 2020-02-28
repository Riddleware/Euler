using Euler.Lib;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    public class _38
    {
        public static long Run()
        {
            List<long> pans = new List<long>();
            long cur = 0;
            while (cur ++ <= 10000)
            {
                string pan = "";
                for (int i = 1; pan.Length < 10 && !pan.Contains("0"); i++)
                {
                    pan += (cur * i).ToString();
                    
                    if (i>1 && pan.IsPanDigital())
                    {
                        pans.Add(long.Parse(pan));
                        break;
                    }
                }
            }

            return pans.Max();//932718654
        }
    }
}
