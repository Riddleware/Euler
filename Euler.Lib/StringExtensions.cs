using System.Collections.Generic;

namespace Euler.Lib
{
    public static class StringExtensions
    {
        public static string TruncL(this string s)
        {
            if (s.Length == 1)
                return "";
            return s.Substring(1);
        }

        public static string TruncR(this string s)
        {
            if (s.Length == 1)
                return "";
            return s.Substring(0, s.Length - 1);
        }

        public static bool IsPalindrome(this string p)
        {
            var buff = p.ToCharArray();

            int s = 0, e = buff.Length - 1;

            while (s <= e)
            {
                if (buff[s] != buff[e])
                    return false;
                s++;
                e--;
            }

            return true;
        }

        static public string Rotate(this string s)
        {
            if (s.Length == 1)
                return s;
            var res = s.Substring(1) + s[0];

            return res;
        }

        static public bool IsPanDigital(this string num, bool _1To9 = true)
        {
            if (_1To9 && num.Length != 9 || num.Contains("0"))
                return false;

            for (int i = 1; i <= num.Length; i++)
            {
                if (!num.Contains(i.ToString()))
                    return false;
            }

            return true;
        }

        public static bool AllUniqueChars(this string s)
        {
            Dictionary<char, char> d = new Dictionary<char, char>();
            foreach (char c in s)
            {
                if (d.ContainsKey(c))
                    return false;
                d.Add(c,c);
            }

            return true;
        }
    }
}
