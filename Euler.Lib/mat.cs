using System;
using System.Collections.Generic;

namespace Euler.Lib
{
    class mat : List<List<long>>
    {
        public void init(int s = 21)
        {
            for (int x = 0; x < s; x++)
            {
                var l = new List<long>();
                for (int y = 0; y < s; y++)
                {
                    l.Add((y == s - 1) || (x == s - 1) ? 1 : 0);

                }

                Add(l);
            }

        }

        public void print(int s = 21)
        {
            for (int x = 0; x < s; x++)
            {

                for (int y = 0; y < s; y++)
                {
                    Console.Write(this[x][y]);
                    Console.Write(" ");
                }

                Console.WriteLine("");

            }

            Console.WriteLine("--------------------");

        }

        public void go()
        {
            for (int i = 19; i >= 0; i--)
            {
                for (int y = 19; y >= 0; y--)
                {
                    this[i][y] = this[i][y + 1] + this[i + 1][y];
                }
            }

            print();
        }
    }
}
