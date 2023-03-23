using System.Collections.Generic;

namespace Euler.Solutions
{
    public class _92 : ISolution<int, long>
    {
        // A number chain is created by continuously adding the square of the digits in a number to form a new
        // number until it has been seen before.
        //
        //     For example,
        //
        //     44 → 32 → 13 → 10 → 1 → 1
        //     85 → 89 → 145 → 42 → 20 → 4 → 16 → 37 → 58 → 89
        //
        // Therefore any chain that arrives at 1 or 89 will become stuck in an endless loop. What is most amazing
        // is that EVERY starting number will eventually arrive at 1 or 89.
        //
        // How many starting numbers below ten million will arrive at 89?
        private Dictionary<long, int> dic = new();
        public long Run(int n = 10000000)
        {
            long _1s = 0;
            long _89s = 0;
            for (int i = 1; i < n; i++)
            {
                // Attempt to speed up, but a bit pointless
                if (dic.ContainsKey(n))
                {
                    _89s++;
                    continue;
                }

                long num = i;
                while (true)
                {
                    num = GetNext(num);
                    if (num == 1)
                    {
                        _1s++;
                        break;
                    }
                    if (num == 89)
                    {
                        _89s++;
                        dic.TryAdd(num, 1);
                        break;
                    }
                }
            }

            return _89s;
        }

        long GetNext(long n)
        {
            long r = 0;
            foreach (var c in n.ToString())
            {
                // 0=48
                int d = c - 48;
                r += d * d;
            }

            return r;
        }
    }
}