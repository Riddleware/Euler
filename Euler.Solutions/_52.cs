using Euler.Lib;

namespace Euler.Solutions
{
    public class _52 : ISolution<int, long>
    {
        // It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits,
        // but in a different order.

        // Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.

        public long Run(int _ = 0)
        {
            long l = 1;
            while (true)
            {
                if (l.SameDigitsAs(l * 2) 
                    && l.SameDigitsAs(l * 3)
                    && l.SameDigitsAs(l * 4)
                    && l.SameDigitsAs(l * 5)
                    && l.SameDigitsAs(l * 6))
                {
                    return l;
                }

                l++;
            }
        }
    }
}