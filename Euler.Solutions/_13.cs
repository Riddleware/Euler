using System.Collections.Generic;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _13 : ISolution<List<string>, string>
    {
        public string Run(List<string> numbers)
        {
            var m = new MatrixInt();

            foreach (var n in numbers)
                m.AddDigitString(n);

            return m.BigSum().Substring(0, 10);
        }
    }
}