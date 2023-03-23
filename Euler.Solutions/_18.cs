using System.Collections.Generic;

namespace Euler.Solutions
{
    public class _18 : ISolution<List<List<int>>, long>
    {
        public long Run(List<List<int>> a)
        {
            for (int i = a.Count - 1; i >= 0; i--)
            {
                for (int li = 0; li < a[i].Count - 1; li++)
                {
                    int nextRow = i - 1;

                    if (i == 1)
                    {
                        a[nextRow][0] += a[i][0] > a[i][1] ? a[i][0] : a[i][1];
                        break;
                    }

                    a[nextRow][li] += a[i][li] > a[i][li + 1] ? a[i][li] : a[i][li + 1];
                }
            }

            return a[0][0];
        }
    }
}