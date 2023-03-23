using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    public class _79 : ISolution<bool, string>
    {
        public string Run(bool b = true)
        {
            var ret = ""; //73162890
            var p = new List<int>
            {
                319,
                680,
                180,
                690,
                129,
                620,
                762,
                689,
                762,
                318,
                368,
                710,
                720,
                710,
                629,
                168,
                160,
                689,
                716,
                731,
                736,
                729,
                316,
                729,
                729,
                710,
                769,
                290,
                719,
                680,
                318,
                389,
                162,
                289,
                162,
                718,
                729,
                319,
                790,
                680,
                890,
                362,
                319,
                760,
                316,
                729,
                380,
                319,
                728,
                716
            };

            p = p.Distinct().ToList();
            p.Sort();
            var s = p.Select(item => item.ToString());

            foreach (var c in s)
                for (int x = 0; x < c.Length; x++)
                    if (!ret.Contains(c[x]))
                        ret += c[x];
                    else if (x < c.Length - 1 && ret.Contains(c[x + 1]) && ret.IndexOf(c[x]) > ret.IndexOf(c[x + 1]))
                        Move(ret.IndexOf(c[x]), ret.IndexOf(c[x + 1]));

            return ret;

            void Move(int x, int y)
            {
                var temp = ret[x];
                ret = ret.Remove(x, 1);
                ret = ret.Insert(y, temp.ToString());
            }
        }
    }
}