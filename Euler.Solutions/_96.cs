using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Euler.Solutions
{
    public class _96
    {
        public class Cell
        {
            private Grid _Grid;
            private int X { get; set; }
            private int Y { get; set; }
            public int Value { get; set; }

            private List<int> poss;
            private List<Cell> Row;
            private List<Cell> Col;
            private List<Cell> Box;

            public Cell(Grid grid, int x, int y, int value)
            {
                _Grid = grid;
                X = x;
                Y = y;
                Value = value;

                if (value == 0)
                {
                    poss = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
                }
            }

            public void FirstPass()
            {
                if (this.Value!=0)
                    return;

                if (this.Row == null)
                {
                    Row = _Grid.GetRow(X, Y);
                    Col = _Grid.GetCol(X, Y);
                    Box = _Grid.GetBox(X, Y);
                }

                for (int i = 1; i < 10; i++)
                {
                    if (poss.Contains(i))
                    {
                        var c = Row.Find(t => t.Value == i);
                        if (c != null)
                            poss.Remove(i);
                        else
                        {
                            c = Col.Find(t => t.Value == i);
                            if (c != null)
                                poss.Remove(i);
                            else
                            {
                                c = Box.Find(t => t.Value == i);
                                if (c != null)
                                    poss.Remove(i);
                            }
                        }
                    }

                    if (poss.Count == 1)
                        Value = poss[0];
                    else
                    {
                        for (int p = 0; p < poss.Count; p++)
                        {
                            foreach (var c in Row.Where(z => z != this))
                            {

                            }
                        }
                    }
                }
            }
        }

        public class Grid : List<List<Cell>>
        {
            public Grid(List<int> nums) : base()
            {
                for (int i = 0; i < 81; i++)
                {
                    if (i % 9 == 0)
                    {
                        this.Add(new List<Cell>());
                    }

                    this[i/9].Add(new Cell(this, i / 9, i % 9, nums[i]));
                }

              //  Solve();
            }

            public List<Cell> GetRow(int x, int y)
            {
                return this[x];
            }

            public List<Cell> GetCol(int x, int y)
            {
                var col=new List<Cell>();
                foreach (var row in this)
                {
                    col.Add(row[y]);
                }
                return col;
            }

            public List<Cell> GetBox(int x, int y)
            {
                var box = new List<Cell>();
                switch (x % 3)
                {
                    case 0:
                        GetColBox(x);
                        GetColBox(x + 1);
                        GetColBox(x + 2);
                        break;
                    case 1:
                        GetColBox(x - 1);
                        GetColBox(x);
                        GetColBox(x + 1);
                        break;
                    case 2:
                        GetColBox(x - 2);
                        GetColBox(x - 1);
                        GetColBox(x);
                        break;
                }

                return box;

                void GetColBox(int lineNum)
                {
                    switch (y % 3)
                    {
                        case 0:
                            box.Add(this[lineNum][y]);
                            box.Add(this[lineNum][y + 1]);
                            box.Add(this[lineNum][y + 2]);
                            break;
                        case 1:
                            box.Add(this[lineNum][y - 1]);
                            box.Add(this[lineNum][y]);
                            box.Add(this[lineNum][y + 1]);
                            break;
                        case 2:
                            box.Add(this[lineNum][y - 2]);
                            box.Add(this[lineNum][y - 1]);
                            box.Add(this[lineNum][y]);
                            break;
                    }
                }
            }

            public void Solve()
            {
                while (!Solved())
                {
                    foreach (var row in this)
                        foreach (var col in row)
                            col.FirstPass();
                }
            }

            bool Solved()
            {
                foreach (var row in this)
                    foreach (var col in row)
                        if (col.Value == 0)
                            return false;

                return true;
            }

            public void Print()
            {
                foreach (var row in this)
                {
                    string r = "";
                    foreach (var col in row)
                    {
                        r += $"{col.Value} ";
                    }

                    Console.WriteLine(r);
                }
            }

            public List<int> Flatten()
            {
                var ret = new List<int>();
                foreach (var row in this)
                {
                    foreach (var col in row)
                    {
                        ret.Add(col.Value);
                    }
                }

                return ret;
            }
        }

        public static List<int> Run(List<int> l)
        {
            Grid g = new Grid(l);
            g.Solve();
            g.Print();
            return g.Flatten();
        }

        public static long Run()
        {
           var l = new List<int>
           {
               2,0,0,0,8,0,3,0,0  ,
               0,6,0,0,7,0,0,8,4  ,
               0,3,0,5,0,0,2,0,9  ,
               0,0,0,1,0,5,4,0,8  ,
               0,0,0,0,0,0,0,0,0  ,
               4,0,2,7,0,6,0,0,0  ,
               3,0,1,0,0,7,0,4,0  ,
               7,2,0,0,4,0,0,6,0  ,
               0,0,4,0,1,0,0,0,3
           };
          
           Grid g = new Grid(l);
            g.Solve();
           g.Print();
            return 0;
            var lines = System.IO.File.ReadAllLines("Data\\p096_sudoku.txt");
            List<Grid> Grids = new List<Grid>();
            List<int> ns = null;// = new List<int>();
            foreach (var line in lines)
            {
                if (line.StartsWith("G"))
                {
                    if (ns != null)
                        Grids.Add(new Grid(ns));

                    ns = new List<int>();
                }
                else if (ns != null)
                {
                    ns.AddRange(line.ToCharArray().ToList().Select(c=>int.Parse(c.ToString())));
                }
            }

            Grids.Add(new Grid(ns));

            foreach (var grid in Grids)
            {
                grid.Solve();
            }

            return 0;
        }
    }
}
