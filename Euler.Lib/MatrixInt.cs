using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Lib
{
    public class MatrixInt : List<List<int>>
    {
        public MatrixInt() : base()
        {
        }

        public MatrixInt(int size, int defVal = 0)
        {
            for (int x = 0; x < size; x++)
            {
                var row = new List<int>();
                for (int y = 0; y < size; y++)
                    row.Add(defVal);
                Add(row);
            }
        }

        public string BigSum()
        {
            var resList = new List<int>();

            int colTot = 0;
            for (var col = this[0].Count - 1; col >= 0; col--)
            {                
                for (int row = 0; row < this.Count; row ++)
                {
                    colTot += this[row][col];
                }
                var tnc = SplitTotAndCarry(colTot);

                resList.Insert(0, tnc.Item2);
                colTot = tnc.Item1;
            }

            string ret = colTot.ToString();
            foreach (var v in resList)
                ret += v;

            return ret;
        }

        public Tuple<int, int> SplitTotAndCarry(int t)
        {
            var sT = t.ToString();
            return new Tuple<int, int> ( int.Parse(sT.Substring(0, sT.Length - 1)), int.Parse(sT.Substring(sT.Length - 1, 1)));
        }

        public void AddDigitString(string bigNumber)
        {
            Add(bigNumber.ToCharArray().Select(c=>c.ToInt()).ToList());
        }

        long GetMaxRow(List<int> r, int e)
        {
            long ret = 0;
            for (int i = 0; i < r.Count - e; i++)
            {
                long t = 1;
                for (int s = i; s < i+e; s++)
                    t *= r[s];

                ret = t > ret ? t : ret;
            }

            return ret;
        }

        public long GetMaxHoriz(int e)
        {
            long ret = 0;
            foreach(var r in this)
            {
                var t = GetMaxRow(r, e);
                ret = t > ret ? t : ret;
            }
            return ret;
        }
        
        public long GetMaxVert(int e)
        {
            long ret = 0;
            for (int i=0;i<Count;i++)
            {
                var t = GetMaxRow(ColToRow(0), e);
                ret = t > ret ? t : ret;
            }
            return ret;
        }

        List<int> ColToRow(int i)
        {
            var ret = new List<int>();
            foreach (var r in this)
            {
                ret.Add(r[i]);
            }
            return ret;
        }

        public long GetMaxDiagLeft(int e)
        {
            long ret = 0;
            for(int r=0; r<Count-e;r++)
            for (int i = e; i < this[0].Count; i++)
            {
                var t = GetMaxRow(DiagLeftToRow(r, i,e), e);
                ret = t > ret ? t : ret;
            }
            return ret;
        }

        List<int> DiagLeftToRow(int r, int c, int e)
        {
            var ret = new List<int>();
            
            for (;e>=0;c--)
            {
                ret.Add(this[r++][c]);
                e--;
            }
            return ret;
        }

        List<int> DiagRightToRow(int r, int c, int e)
        {
            var ret = new List<int>();

            for (; e >= 0; c++)
            {
                ret.Add(this[r++][c]);
                e--;
            }
            return ret;
        }

        public long GetMaxDiagRight(int e)
        {
            long ret = 0;
            for (int r = 0; r < Count - e; r++)
            for (int i = 0; i < this[0].Count-e; i++)
            {
                var t = GetMaxRow(DiagRightToRow(r, i, e), e);
                ret = t > ret ? t : ret;
            }
            return ret;
        }
    }
}
