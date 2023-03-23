using System;

namespace Euler.Solutions
{
    public class _19 : ISolution<bool, long>
    {
        public long Run(bool _ = true)
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
    }
}