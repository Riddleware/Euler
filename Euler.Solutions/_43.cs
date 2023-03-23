using System.Collections.Generic;
using System.Linq;
using Euler.Lib;

namespace Euler.Solutions
{
    // The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.
    //
    // Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:
    //
    // d2d3d4=406 is divisible by 2
    // d3d4d5=063 is divisible by 3
    // d4d5d6=635 is divisible by 5
    // d5d6d7=357 is divisible by 7
    // d6d7d8=572 is divisible by 11
    // d7d8d9=728 is divisible by 13
    // d8d9d10=289 is divisible by 17
    // Find the sum of all 0 to 9 pandigital numbers with this property.
    public class _43 : ISolution<int, long>
    {
        // d4 - even
        // d5 div by 3
        // d6 div by 5
        // d7 div by 7
        // d8 div by 11
        // d9 div by 13
        // d10 div by 17
        private List<int> db2 = new ();
        private List<int> db3 = new ();
        private List<int> db5 = new ();
        private List<int> db7 = new ();
        private List<int> db11 = new ();
        private List<int> db13 = new ();
        private List<int> db17 = new ();

        public long Run(int _)
        {
            long res = 0;
            
            Init();

            List<string> curList = FilterList(db17.Select(d => ToString(d)).ToList(), db13);// new List<string>();
            curList = FilterList(curList, db11);
            curList = FilterList(curList, db7);
            curList = FilterList(curList, db5);
            curList = FilterList(curList, db3);
            curList = FilterList(curList, db2);

            foreach (var s in curList)
            {
                res += CompletePanDigital(s);
            }
            
            return res;
        }

        long CompletePanDigital(string s)
        {
            Dictionary<char, char> digits = new Dictionary<char, char>()
            {
                {'0', '0'}, {'1', '1'}, {'2', '2'}, {'3', '3'}, {'4', '4'},
                {'5', '5'}, {'6', '6'}, {'7', '7'}, {'8', '8'}, {'9', '9'},
            };

            foreach (var c in s)
            {
                digits.Remove(c);
            }

            if (digits.Keys.Count == 1)
            {
                s = s.Insert(0, digits.Keys.ToList()[0].ToString());
            }

            return long.Parse(s);
        }

        List<string> FilterList(List<string> fullList, List<int> db13)
        {
            List<string> curList = new List<string>();
            foreach (var d17 in fullList)
            {
                foreach (var d13 in db13.Select(d=>ToString(d)))
                {
                    if (d13[1] == d17[0] &&
                        d13[2] == d17[1] &&
                        $"{d13}{d17.Substring(2)}".AllUniqueChars())
                    {
                        curList.Add($"{d13}{d17.Substring(2)}");
                    }
                }
            }

            return curList;
        }

        string ToString(int i)
        {
            return i.ToString().PadLeft(3, '0');
        }

        void Init()
        {
            GetAllDivisible(db2, 2);
            GetAllDivisible(db3, 3);
            GetAllDivisible(db5, 5);
            GetAllDivisible(db7, 7);
            GetAllDivisible(db11, 11);
            GetAllDivisible(db13, 13);
            GetAllDivisible(db17, 17);
        }

        void GetAllDivisible(List<int> list, int div)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i%div==0)
                    list.Add(i);
            }
        }
    }
}