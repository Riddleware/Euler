using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    public class _39
    {
        class IntTri
        {
            public int A { get; set; }
            public int T { get; set; }
            public int H { get; set; }

            public bool IsValid { get; private set; }

            public int P => A + T + H;
            public IntTri(int a, int t)
            {
                double h = Math.Sqrt(a * a + t * t);

                IsValid = (h % (int) h == 0);
                if (IsValid)
                {
                    A = a;
                    T = t;
                    H = (int) h;
                }
            }
        }

        public static long Run()
        {
            List<IntTri> intTris = new List<IntTri>();

            for (int a = 1; a < 1000; a++)
            {
                for (int t = 1; t < 1000; t++)
                {
                    try
                    {
                        IntTri tr= new IntTri(a,t);
                        if (tr.IsValid &&
                            intTris.Find(x=>x.A==a && x.T==t || x.A==t&&x.T==a)==null)
                            intTris.Add(tr);
                    }
                    catch {}
                }
            }
           
            return intTris.FindAll(i => i.P <= 1000)//840
                .GroupBy(r => r.P)
                .OrderByDescending(c => c.Count())
                .ToList()[0].Key;
        }
    }
}
