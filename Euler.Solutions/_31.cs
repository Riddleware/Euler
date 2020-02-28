namespace Euler.Solutions
{
    public class _31
    {
        //public static int count = 0;
       // public static int req = 200;

        class Denom
        {
            private Denom d;

            public Denom(int val, Denom pD, int q = 0)
            {
                d = pD;
                Value = val;
            }

            public int Value { get; set; }

            public int Comb(int r)
            {
                //count++;
                int result = 0;
                if (r < Value)
                {
                    result += d.Comb(r);
                }
                //else
                {
                    result += 1;
                }

                int c = r / Value;

                while (c > 0)
                {
                    c--;

                    if (d != null)
                        result += d.Comb(r - c * Value);
                }
                
                return result;
            }
        }
        //TODO Make this work properly!!!
        static int Recur()
        {
            Denom den = new Denom(200, new Denom(100, new Denom(50, new Denom(20,
                new Denom(10, new Denom(5, new Denom(2,  new Denom(1, null))))))));
            Denom den2 = new Denom(50, new Denom(20,
                new Denom(10, null)));
            int retVal = den.Comb(200);
            retVal += den2.Comb(200) + 1;
            //Console.WriteLine(count);
            return retVal;
        }

        static int[] coins = { 200, 100, 50, 20, 10, 5, 2, 1 };

        static int findposs(int money, int maxcoin)
        {
            int sum = 0;
            if (maxcoin == 7) return 1;
            for (int i = maxcoin; i < coins.Length; i++)
            {
                if (money - coins[i] == 0) sum += 1;
                if (money - coins[i] > 0) sum += findposs(money - coins[i], i);
            }

            return sum;
        }

        static int ex31b(int m)
        {
            int count = 0;
            int a, b, c, d, e, f, g;
            for (a = m; a >= 0; a -= 200)
            for (b = a; b >= 0; b -= 100)
            for (c = b; c >= 0; c -= 50)
            for (d = c; d >= 0; d -= 20)
            for (e = d; e >= 0; e -= 10)
            for (f = e; f >= 0; f -= 5)
            for (g = f; g >= 0; g -= 2)
                count++;
            return count;
        }

        public static int Run()
        {
            int ret = 0;

            return findposs(200,0);
            return Recur();
            return ex31b(200);
        }
    }
}
