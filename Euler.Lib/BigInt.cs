using System.Collections.Generic;
using System.Linq;

namespace Euler.Lib
{
    public class BigInt
    {
        List<int> aNumber = new List<int>();

        public BigInt(long n)
        {
            aNumber = n.ToString().ToCharArray().Select(x => x-48).ToList();
        }

        public BigInt(BigInt n)
        {
            aNumber = n.ToString().ToCharArray().Select(x => x - 48).ToList();
        }

        public override string ToString()
        {
            var s = "";

            foreach (var i in aNumber)
                s += i;

            return s;
        }

        public static BigInt operator*(BigInt a, int n)
        {
            BigInt ret = new BigInt(a);

            int carry = 0;
            for (int x = ret.Len - 1; x >= 0; x--)
            {
                var s = ret[x] * n + carry;
                ret[x] = s % 10;
                carry = s / 10;

                if (x == 0 && carry > 0)
                {
                    var sRep = carry.ToString();
                    for (int rem = sRep.Length - 1; rem >= 0; rem--)
                        ret.aNumber.Insert(0, int.Parse(sRep[rem].ToString()));
                }
            }

            return ret;
        }

        public int Len => aNumber.Count;

        public static BigInt operator +(BigInt me, BigInt n)
        {
            BigInt b;
            BigInt ret;
            if (me.Len >= n.Len)
            {
                ret= new BigInt(me); b = n;
            }
            else
            {
                ret = new BigInt(n); b = me;
            }

            
            int carry = 0;
            int aIndex = ret.Len - 1;
            for (int x = b.Len - 1; x >= 0; x--)
            {
                var s = ret[aIndex] + b[x] + carry;

                ret[aIndex] = s % 10;
                carry = s / 10;

                if (x == 0 && carry > 0)
                {
                    if (ret.Len > b.Len)
                        ret[aIndex - 1] += carry;
                    else
                    {
                        ret.aNumber.Insert(0, carry);
                    }
                }

                aIndex--;
            }

            return ret;
        }

        public int this[int i]
        {
            get => aNumber[i];
            set => aNumber[i] = value;
        }

        public long SumOfDigits()
        {
            return aNumber.Sum();
        }
    }
}