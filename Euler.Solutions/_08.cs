using System.Linq;
using Euler.Lib;

namespace Euler.Solutions
{
    public class _08 : ISolution<char[], long>
    {
        public long Run(char[] buff)
        {
            //simple version here. Improved efficiency later
            return Utils.GetLargestProduct(buff.ToList().Select(c => c.ToInt()).ToList(), 13);

            /*//This more efficient?
            long ret = 0;
            int s = 0, e = 0;
        
            List<List<int>> buffers = new List<List<int>>();
        
            List<int> cur = new List<int>();
            buffers.Add(cur);
            for (int i = s; i < buff.Length; i++)
            {
                if (buff[i].ToInt() == 0)
                {
                    cur = new List<int>();
                    buffers.Add(cur);
                }
                else
                {
                    cur.Add(buff[i].ToInt());
                }
            }
        
            buffers = buffers.FindAll(b => b.Count >= a);
            foreach (var b in buffers)
            {
                long l = GetLargestProduct(b);
                if (l > ret)
                    ret = l;
            }
        
            return ret;*/
        }
    }
}