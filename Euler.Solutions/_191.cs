using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    public class _191 : ISolution<int, string>
    {
        public string Run(int days)
        {
            
            return "";
        }

        int CountRepeatAbsences(int days)
        {
            int ret = 0;

            /*
            4
            AAAA
            AAAX
            XAAA
            5
            AAAAA
            AAAXX
            XAAAX
            XXAAA
            10
            XXXXXXXXXX
            AAAAAAAAAA
            
            AAAXXXXXXX  + 7     
            XAAAXXXXXX  + 6
            XXAAAXXXXX  + 5
            XXXAAAXXXX  + 4
            XXXXAAAXXX  + 3
            XXXXXAAAXX  + 2 
            XXXXXXAAAX  + 1
            XXXXXXXAAA  + 0 
            
            AAAXXXXAAA  
            */
            ret = days - 2;// Exactly 3 exactly once
            for (int i=days - 3; i > 0; i--) // AAA > 3 exactly once
            {
                ret += i;
            }
            return ret;
        }

        public string RunBruteForceWillNeverEnd(int days)
        {
            // O  A  L
            // 0  1  2  
            // 001  002  010  011  012  020  021  022  100 

            string curr = String.Empty;
            string upper = String.Empty;
            for (int d = 0; d < days; d++)
            {
                curr += 'O';
                upper += 'L';
            }
            List<string> poss = new() {curr};
            List<string> priz = new() {curr};
            int c = 1;
            int tot = 1;
            do
            {
                curr = Add(curr);
                tot++;
                // poss.Add(curr);
                if (IsPrize(curr))
                {
                    c++;
                    //priz.Add(curr);
                    if (c%100000 == 0)
                        Console.WriteLine(curr);
                }
            } while (curr != upper);

            return $"{tot} - {c}";//priz.Count;
        }

        bool IsPrize(string curr)
        {
            if (curr.Contains("AAA") || curr.Count(c => c == 'L') > 1)
                return false;
            return true;
        }

        string Add(string currS)
        {
            var curr = currS.ToCharArray();
            for (int i = curr.Length - 1; i >= 0; i--)
            {
                if (curr[i] == 'O')
                {
                    curr[i] = 'A';
                    break;
                }
                else if (curr[i] == 'A')
                {
                    curr[i] = 'L';
                    break;
                }
                else // == 2
                    curr[i] = 'O';
            }

            return string.Concat(curr);
        }
    }
}