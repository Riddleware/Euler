using System;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _17 : ISolution<long, long>
    {
        public long Run(long countTo)
        {
            long ret = 0;
            for (int c = 1; c <= countTo; c++)
            {
                var count = NumWordCount.Count(c);
                var word = NumWordCount.GetAsWord(c);
                if (count != word.Length)
                    Console.ForegroundColor = ConsoleColor.Red;

                //Console.WriteLine($"{c}   -  {count} -   {word}");
                ret += NumWordCount.Count(c);
            }

            return ret;
        }
    }
}