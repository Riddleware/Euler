using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _59 : ISolution<bool, long>
    {
        public long Run(bool b = true)
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

            var x1 = (byte) (f1[0].A ^ ' ');
            var x2 = (byte) (f2[0].A ^ ' ');
            var x3 = (byte) (f3[0].A ^ ' ');

            return Combine();

            long Combine()
            {
                long ret = 0;
                var tx = new List<byte>();

                for (int i = 0; i < t1.Count; i++)
                {
                    tx.Add((byte) (t1[i] ^ x1));
                    tx.Add((byte) (t2[i] ^ x2));
                    tx.Add((byte) (t3[i] ^ x3));
                }

                foreach (var l in tx)
                {
                    ret += l;
                    Console.Write((char) l);
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
                        ret.Add(new Pair<byte, int> {A = bt, B = 1});
                    }
                    else
                        freq.B++;
                }

                return ret;
            }

            IEnumerable<byte> LoadBytes(char separator = ',')
            {
                var s = File.ReadAllText(Path.Combine("Data", "p059_cipher.txt"));
                var c = s.Split(separator).Select(byte.Parse).ToList();

                return c;
            }
        }
    }
}