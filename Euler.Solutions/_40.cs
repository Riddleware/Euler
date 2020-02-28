using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Euler.Solutions
{
    public class _40
    {
        //the pos of a num in a string as described in the problem
        static long Pos(long x)
        {
            int initPos = 0;
            int tens = 10;

            if (x < tens)
                return x;

            int inc = 1;

            do
            {
                initPos += (tens - tens / 10) * inc++;
                tens *= 10;
                if (x < tens)
                    return initPos + (x - tens / 10) * inc + 1;
            } while (true);
        }

        static long RevPos(long pos)
        {
            if (pos < 10)
                return pos;

            var i = 10;
            var c = 10 + 90 * 2;

            if (pos < c) //less than 100
                return (pos - i) / 2 + 10;

            var inc = 2;
            var tens = 10;
            while (true)
            {
                i += 9 * tens * inc++;
                tens *= 10;
                c += 9 * tens * inc;
                if (pos < c)
                    return (pos - i) / inc + tens;
            }
        }

        public static long Run()
        {
            long res = 1;
            for (int i = 10; i < 10000000; i *= 10)
            {
                var num = RevPos(i);
                var offset = i - Pos(num);

                string n = num.ToString();
                var number = int.Parse(n[(int) offset].ToString());
                res *= number;
            }


            return res;//210
        }
    }
}
