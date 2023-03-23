using System;
using System.Collections.Generic;

namespace Euler.Solutions
{
    public class _24 : ISolution<int, string>
    {
        public string Run(int iterations = 1000000)
        {
            var a = new List<char> {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            for (int o = 0; o < iterations - 1; o++)
                Inc();

            return ToString();

            void Inc()
            {
                for (int i = a.Count - 1; i >= 0; i--)
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

            void Out()
            {
                Console.WriteLine(ToString());
            }
        }
    }
}