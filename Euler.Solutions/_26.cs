using System;
using System.Collections.Generic;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _26 : ISolution<int, long>
    {
        public long Run(int maxD)
        {
            long ret = 0;
            int maxMods = 0;
            //d++ also works, slower
            for (long d = 2; d < maxD; d = d.GetNextPrime())
            {
                int i = 1;
                List<int> mods = new List<int> {i};

                while (true)
                {
                    while (i / d == 0)
                        i *= 10;

                    int newMod = (int) (i % d);

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
    }
}