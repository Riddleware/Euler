using System;
using System.Collections.Generic;

namespace Euler.Solutions
{
    public class _15 : ISolution<long, long>
    {
        public long Run(long gridSize = 20)
        {
            long ret = 0;

            List<long> prev = new List<long>();
            for (int r = 0; r <= gridSize; r++)
            {
                prev.Add(1);
            }

            List<long> res = null;
            for (int r = 0; r < gridSize; r++)
            {
                res = new List<long>();
                for (int c = 0; c <= gridSize; c++)
                    if (c == 0)
                        res.Add(1);
                    else
                        res.Add(res[c - 1] + prev[c]);

                prev = res;
            }

            return prev[prev.Count - 1];

            void printList()
            {
                foreach (var i in prev)
                    Console.Write($"{i} ");

                Console.WriteLine("");
            }
        }
    }
}