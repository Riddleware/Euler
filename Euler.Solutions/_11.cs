using System;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _11 : ISolution<Tuple<MatrixInt, int>, long>
    {
        public long Run(Tuple<MatrixInt, int> paramz)
        {
            var m = paramz.Item1;
            var e = paramz.Item2;
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
    }
}