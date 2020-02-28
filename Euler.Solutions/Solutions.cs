using Euler.Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Euler.Solutions
{
    public class Pair<T1, T2>
    {
        public T1 A { get; set; }
        public T2 B { get; set; }
    }
    public class Solution
    {
        public static string _79()
        {
            var ret = "";//73162890
            var p = new List<int> {
            319,680,180,690,129,620,762,689,762,318,368,710,720,710,629,168,160,689,716,
            731,736,729,316,729,729,710,769,290,719,680,318,389,162,289,162,718,729,319,
            790,680,890,362,319,760,316,729,380,319,728,716 };

            p = p.Distinct().ToList(); p.Sort();
            var s = p.Select(item => item.ToString());

            foreach (var c in s)
                for (int x = 0; x < c.Length; x++)
                    if (!ret.Contains(c[x]))
                        ret += c[x];
                    else if (x < c.Length - 1 && ret.Contains(c[x + 1]) && ret.IndexOf(c[x]) > ret.IndexOf(c[x + 1]))
                        Move(ret.IndexOf(c[x]), ret.IndexOf(c[x + 1]));

            return ret;

            void Move(int x, int y)
            {
                var temp = ret[x];
                ret = ret.Remove(x, 1);
                ret = ret.Insert(y, temp.ToString());
            }
        }

        public static long _59()
        {
            var all = LoadBytes().ToList();
            var t1 = new List<byte>();
            var t2 = new List<byte>();
            var t3 = new List<byte>();

            for (var idx = 0; idx < all.Count; idx += 3)
            {
                t1.Add(all[idx]);
                t2.Add(all[idx + 1]);
                t3.Add(all[idx + 2]);
            }

            var f1 = GetFrequencies(t1).OrderByDescending(p => p.B).ToList();
            var f2 = GetFrequencies(t2).OrderByDescending(p => p.B).ToList();
            var f3 = GetFrequencies(t3).OrderByDescending(p => p.B).ToList();

            var x1 = (byte)(f1[0].A ^ ' ');
            var x2 = (byte)(f2[0].A ^ ' ');
            var x3 = (byte)(f3[0].A ^ ' ');

            return Combine();

            long Combine()
            {
                long ret = 0;
                var tx = new List<byte>();

                for (int i = 0; i < t1.Count; i++)
                {
                    tx.Add((byte)(t1[i] ^ x1));
                    tx.Add((byte)(t2[i] ^ x2));
                    tx.Add((byte)(t3[i] ^ x3));
                }

                foreach (var l in tx)
                {
                    ret += l;
                    Console.Write((char)l);
                }

                return ret;
            }

            List<Pair<byte, int>> GetFrequencies(List<byte> t)
            {
                var ret = new List<Pair<byte, int>>();
                foreach (var bt in t)
                {
                    var freq = ret.Find(r => r.A == bt);
                    if (freq == null)
                    {
                        ret.Add(new Pair<byte, int> { A = bt, B = 1 });
                    }
                    else
                        freq.B++;
                }

                return ret;
            }

            IEnumerable<byte> LoadBytes(char separator = ',')
            {
                var s = File.ReadAllText("Data\\p059_cipher.txt");
                var c = s.Split(separator).Select(byte.Parse).ToList();

                return c;
            }
        }
               
        public static long _30()
        {
            //using array to see what the numbers are
            var arr = new List<long>();

            for (int i = 2; i < 1000000; i++)
            {
                long sum = 0;
                foreach (var c in i.ToString())
                {
                    sum += (long)Math.Pow(double.Parse(c.ToString()), 5);
                }
                if (sum == i)
                    arr.Add(i);
            }
            return arr.Sum();
        }

        public static long _29(int max)
        {            
            var arr = new List<double>();

            for (int a = 2; a <= max; a++)
                for (int b = 2; b <= max; b++)
                    arr.Add(Math.Pow(a, b));

            return arr.Distinct().ToList().Count;
        }

        public static long _28()
        {
            long ret = 1;
            for (var c = 2; c < 10; c += 2)
                ret += TotalUp(c);             
            return ret;

            long TotalUp(long seed)
            {
                long r = 0;
                long lastNum = 1;
                for (int i = 0; i < 500; i++)
                {
                    var t = lastNum + (8 * i) + seed;
                    r += t;
                    lastNum = t; 
                }

                return r;
            }
        }

        public static long _27()
        {            
            MostPrimes p = new MostPrimes { NumPrimes = 0 };
            
            long n = 0, a = -999, b = -1000;
            long MaxA = 999, MaxB = 1000;
            for (a = 0 - MaxA; a <= MaxA; a++)
                for (b = 0 - MaxB; b <= MaxB; b++)
                {
                    n = 0;
                    while (((n * n) + a * n + b).IsPrime()) 
                        n++;                    

                    if (n - 1 > p.NumPrimes)
                    {
                        p.NumPrimes = n - 1;
                        p.a = a;
                        p.b = b;
                    }
                }
            
            return p.a * p.b;
        }

        class MostPrimes
        {
            public long NumPrimes { get; set; }
            public long  a { get; set; }
            public long b { get; set; }
        }

        public static long _26(int maxD)
        {
            long ret = 0;
            int maxMods = 0;
                                       //d++ also works, slower
            for (long d = 2; d < maxD; d = d.GetNextPrime())
            {
                int i = 1;
                List<int> mods = new List<int> { i };

                while (true)
                {
                    while (i / d == 0)
                        i *= 10;

                    int newMod = (int)(i % d);

                    if (newMod == 0)
                    {
                        mods.Clear();
                        break;
                    }
                    if (mods.Contains(newMod))
                    {
                        if (newMod != mods[0])
                            mods.RemoveAt(0);
                        break;
                    }

                    mods.Add(newMod);
                    i = newMod;
                }
                if (mods.Count > maxMods)
                {
                    maxMods = mods.Count;
                    ret = d;
                }
               // if (d%(1000) == 0)
                    Console.WriteLine($"{d}\t:\t{mods.Count}");
            }

            return ret;
        }

        public static long _25(int n)
        {
            long ret = 2;
            BigInt prev1 =new BigInt(1), prev2 = new BigInt(1);
            BigInt cur = new BigInt(0);
            
            while (cur.Len < n)
            {
                cur = prev1 + prev2;
                prev1 = prev2;
                prev2 = cur;

                ret++;
            }
            //Console.WriteLine($"F({ret}) = {cur}");
            return ret;
        }

        public static string _24(int iterations = 1000000)
        {
            var a = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

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

        public static long _23()
        {
            long ret = 0;
            List<long> abList = new List<long>();
            for (long i = 0; i < 24; i++)
            {
                ret += i;
                if (i >= 12 && i.IsAbundant())
                    abList.Add(i);
            }

            for (long i = 24; i <= 28123; i++)
            {
                if (!IsSumOfTwo(i))
                    ret += i;
                if (i.IsAbundant())
                    abList.Add(i);
            }

            return ret;

            bool IsSumOfTwo(long l)
            {
                for (int x = 0; x < abList.Count; x++)
                {
                    if (abList.Contains(l - abList[x]))
                        return true;
                }

                return false;
            }
        }

        public static long _22(List<string> s)
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

        public static long _21(long n)
        {
            var amigos = new List<long>();

            List<Tuple<long, long>> a = new List<Tuple<long, long>>();
            for (long x = 2; x < n; x++)
            {
                if (amigos.Contains(x))
                    continue;

                var i = x.GetProperDivisorSum();
                if (x!=i)
                {
                    if (i.GetProperDivisorSum() == x)
                    {
                        amigos.Add(i);
                        amigos.Add(x);
                    }
                }                   
            }
                        
            return amigos.Sum();
        }

        public static long _20(int num)
        {            
            BigInt r = new BigInt(100);
            for (int i = num-1; i >0; i--)
            {
               r *= i;
            }

            return r.SumOfDigits();
        }

        public static long _19()
        {
            //TODO : this without cheating
            long ret = 0;
            var s = DateTime.Parse("1901-01-01");
            while (s.Year < 2001)
            {
                if (s.DayOfWeek == DayOfWeek.Sunday)
                    ret++;

                s = s.AddMonths(1);                
            }

            return ret;
        }

        public static long _18_67(List<List<int>> a)
        {
            for (int i = a.Count - 1; i >= 0; i--)
            {
                for (int li = 0; li < a[i].Count - 1; li++)
                {
                    int nextRow = i - 1;

                    if (i == 1)
                    {
                        a[nextRow][0] += a[i][0] > a[i][1] ? a[i][0] : a[i][1];
                        break;
                    }                                        

                    a[nextRow][li] += a[i][li] > a[i][li + 1] ? a[i][li] : a[i][li + 1];
                }
            }

            return a[0][0];
        }

        public static long _17(int countTo)
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

        public static long _16(int pow)
        {
            BigInt r = new BigInt(2);
            for (int i = 1; i < pow; i++)
            {
                r *= 2;
            }

            return r.SumOfDigits();
        }

        public static long _15(int gridSize = 20)
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
                    else res.Add(res[c-1]+prev[c]);

                prev = res;
            }

            return prev[prev.Count-1];

            void printList()
            {
                foreach (var i in prev)
                    Console.Write($"{i} ");

                Console.WriteLine("");
            }
        }

        public static long _14()
        {
            long ret = 0;
            long highest = 0;
            long temp = 0;
            for (long num = 1; num < 1000000; num++)
            {
                temp = num.CollatzChainCount();
                
                if (temp > highest)
                {
                    highest = temp;
                    ret = num;
                }
            }
            
            return ret;
        }

        public static string _13(List<string> numbers)
        {
            var m = new MatrixInt();

            foreach (var n in numbers)
                m.AddDigitString(n);

            return m.BigSum().Substring(0, 10);
        }

        public static long _12()
        {
            long ret = 0, cur = 0, tri = 0;
            while (++cur > 0)
            {
                tri += cur;
                if (tri.GetDivisorCount() > 500)
                    return tri;
            }

            return ret;
        }

        public static long _11(MatrixInt m, int e)
        {
            long ret = 0;
            var t = m.GetMaxHoriz(e);
            ret = t > ret ? t : ret;
            t = m.GetMaxVert(e);
            ret = t > ret ? t : ret;
            t = m.GetMaxDiagLeft(e);
            ret = t > ret ? t : ret;
            t = m.GetMaxDiagRight(e);
            ret = t > ret ? t : ret;
            return ret;
        }

        public static long _10()
        {
            long ret = 0;
            long Prime = 2;
            while (Prime < 2000000)
            {
                ret += Prime;
                Prime = Prime.GetNextPrime();
            }

            return ret;
        }

        public static long _9()
        {
            long ret = 0, a = 0, b, c;
            while (++a < 1000)
            {
                for (b = a + 1; b < 1000; b++)
                {
                    c = 1000 - (a + b);
                    if (Utils.IsPythTriplet(a, b, c))
                    {
                        return a * b * c;
                    }
                }
            }

            return ret;
        }

        public static long _8(char[] buff, int a)
        {
            //simple version here. Improved efficiency later
            return GetLargestProduct(buff.ToList().Select(c=>c.ToInt()).ToList());

            /*//This more efficient?
            long ret = 0;
            int s = 0, e = 0;
            
            List<List<int>> buffers = new List<List<int>>();

            List<int> cur = new List<int>();
            buffers.Add(cur);
            for (int i = s; i < buff.Length; i++)
            {
                if (buff[i].ToInt() == 0)
                {
                    cur = new List<int>();
                    buffers.Add(cur);
                }
                else
                {
                    cur.Add(buff[i].ToInt());
                }
            }
            
            buffers = buffers.FindAll(b => b.Count >= a);
            foreach (var b in buffers)
            {
                long l = GetLargestProduct(b);
                if (l > ret)
                    ret = l;
            }

            return ret;*/

            long GetLargestProduct(List<int> buf)
            {
                long longest = 0;
                int tries = buf.Count + 1 - a;

                for (int t = 0; t < tries; t++)
                {
                    var tot = GetProduct(buf, t);
                    if (tot > longest)
                        longest = tot;
                }

                return longest;
            }
            long GetProduct(List<int> buf, int start)
            {
                long sProd = 1;
                for (int ind = start; ind < start + a; ind++)
                    sProd *= buf[ind];

               // Console.WriteLine(sProd);
                return sProd;
            }
        }

        public static long _7(long x)
        {
            long ret = 1;
            for (int i = 0; i < x; i++)
                ret = ret.GetNextPrime();
            return ret;
        }

        public static long _6(long x)
        {
            long sumSq = 0, sqSum = 0;

            for (var i = 1; i <= x; i++)
                sumSq += (i * i);

            for (var i = 1; i <= x; i++)
                sqSum += i;

            sqSum *= sqSum;

            return sqSum - sumSq;
        }

        public static long _5(long x)
        {
            long ret = x;
            bool found = false;
            while (!found)
            {
                ret++;

                found = true;
                for (long i = x; i >= 2; i--)
                {
                    if (ret % i != 0)
                    {
                        found = false;
                        break;
                    }
                }
            }

            return ret;
        }

        public static long _4()
        {
            long ret = 0;

            for (long x = 100; x < 1000; x++)
            {
                for (long y = 100; y < 1000; y++)
                {
                    if ((x * y).IsPalindrome())
                        ret = (x * y) > ret ? (x * y) : ret;
                }
            }

            return ret;
        }

        public static long _3(long[] args)
        {
            long n = args[0];

            if (n.IsPrime())
                return n;

            long ret = 0, p = 2;
            while (p < n / p)
            {
                p = p.GetNextPrime();
                if (n % p == 0)
                    ret = p;
            }

            return ret;
        }

        public static long _2(long[] args)
        {
            long e = args[0];

            long ret = 0, prev1 = 1, prev2 = 1, cur = 0;

            while (cur <= e)
            {
                cur = prev1 + prev2;
                ret += (cur % 2 == 0) ? cur : 0;
                prev1 = prev2;
                prev2 = cur;
            }

            return ret;
        }

        public static long _1(long[] args)
        {
            long s = args[0], e = args[1];
            long ret = 0;

            while (s <= e)
            {
                ret += (s % 3 == 0 || s % 5 == 0) ? s : 0;
                s++;
            }

            return ret;
        }
    }
}
