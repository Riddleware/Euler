using System.Collections.Generic;

namespace Euler.Solutions
{
    public class _22 : ISolution<List<string>, long>
    {
        public long Run(List<string> s)
        {
            long ret = 0;
            s.Sort();
            int pos = 1;
            foreach (var name in s)
            {
                ret += GetLetterSum(name) * pos++;
            }

            return ret;

            int GetLetterSum(string word)
            {
                int sum = 0;
                foreach (char c in word)
                {
                    sum += c - 64;
                }

                return sum;
            }
        }
    }
}