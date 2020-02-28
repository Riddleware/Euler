using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _49
    {
        static bool CheckSequence(List<long> perm, out string res)
        {
            perm.Sort();
            List<long> dist = new List<long>();
            for (int i=perm.Count - 1; i > 0 ;i--)
                for (int y=i-1 ; y>=0; y--)
                    dist.Add(perm[i] - perm[y]);

          //  long cur = 0;
          // // int c = 0;
          //  foreach (var l in dist)
          //  {
          //      if (l == cur)
          //      {
          //          //c++;
          //          //if (c == 2) 
          //          return true;
          //      }
          //      //else c = 0;
          //  }

            var gp = dist.GroupBy(d => d).ToList().FindAll(d => d.Count() >1);
            res = "";
            foreach (var g in gp)
            {
                for (int i = 0; i<perm.Count; i++)
                {
                    if (perm.Contains(perm[i] + g.Key) && perm.Contains(perm[i] + 2 * g.Key))
                    {
                        res = $"{perm[i]}{perm[i] + g.Key}{perm[i] + 2* g.Key}";
                        return true;
                    }
                }

                var dosumthing = true;
            }

            return false;//gp.Count>0;// != null;
        }

        public static string Run()
        {
            var res = "";
            long p = 1488;
            var primeCache = p.GetPrimeList(10000);

            foreach (var prime in primeCache)
            {
                List<long> perm = GetPermutations(prime);

                perm = perm.FindAll(x => primeCache.Contains(x));

                if (perm.Count > 2 && CheckSequence(perm, out string r))
                {
                    return r;
                }
            }

            return res;
        }

        static List<long> GetPermutations(long l)
        {
            var list = new List<long>();
            var a = l.ToString().ToCharArray().ToList();

            do
            {
                list.Add(l);    
                Inc();
                l = long.Parse(ToString());
            } while (!list.Contains(l));
            

            return list;

            void Inc()
            {
                for (int i = a.Count - 1; i > 0; i--)
                {
                    if (a[i] > a[i - 1])
                    {
                        Swap(MinIdx(i, a[i - 1]), i - 1);
                        SortFrom(i);
                        break;
                    }
                }
            }

            void SortFrom(int i)
            {
                var tail = a.GetRange(i, a.Count - i);
                tail.Sort();
                a.RemoveRange(i, a.Count - i);
                a.AddRange(tail);
            }

            int MinIdx(int i, int smol)
            {
                int ret = i;
                int big = a[i];
                for (; i < a.Count; i++)
                    if (a[i] < big && a[i] > smol)
                        ret = i;

                return ret;
            }

            void Swap(int x, int y)
            {
                var t = a[x];
                a[x] = a[y];
                a[y] = t;
            }

            string ToString()
            {
                var ret = "";
                foreach (var ch in a)
                    ret += ch;

                return ret;
            }
        }
    }
}
