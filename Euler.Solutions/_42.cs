using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _42
    {
        static List<string> ReadFile()
        {           
            List<string> ret = new List<string>();
            var l = File.ReadAllText(Path.Combine("Data", "p042_words.txt")).Split(',');
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

        public static long Run()
        {
            long res = 0;            
            var t = Utils.GetTriangulars(20);

            foreach (var word in ReadFile())            
                if (t.Contains(SumWord(word)))
                    res++;

            return res;
        }
    }
}
