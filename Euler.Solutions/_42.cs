using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Euler.Solutions
{
    public class _42
    {
        static List<string> ReadFile()
        {           
            List<string> ret = new List<string>();
            var l = File.ReadAllText("Data\\p042_words.txt").Split(',');
            foreach (var word in l)
                ret.Add(word.Replace("\"", ""));

            return ret;
        }

        static int SumWord(string word)
        {
            int res = 0;

            foreach (char l in word)
                res += l - 'A' + 1;

            return res;
        }
       
        static List<long> GetTriangulars(int count)
        {
            var t = new List<long>();
            for (double n = 1; n < count; n++)
            {
                t.Add((long)((n/2)*(n + 1)));
            }
           return t;
        }

        public static long Run()
        {
            long res = 0;            
            var t = GetTriangulars(20);

            foreach (var word in ReadFile())            
                if (t.Contains(SumWord(word)))
                    res++;

            return res;
        }
    }
}
