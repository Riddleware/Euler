using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Solutions
{
    public class _96
    {
        public class Cell
        {
            private Grid _Grid;
            public int X { get; set; }
            public int Y { get; set; }
            public int Value { get; set; }

            public List<int> poss= new List<int>();
            protected List<Cell> Row;
            protected List<Cell> Col;
            protected List<Cell> Box;

            public Cell(Grid p, Cell c)
            {
                _Grid = p;
                X = c.X;
                Y = c.Y;
                Value = c.Value;

                poss = new List<int>();
                poss.AddRange(c.poss);                
            }

            public bool Check()
            {
                bool valid = true;

                for (int i = 1; i < 10; i++)
                {
                    if (Row.Find(c => c.Value == i) == null
                        || Col.Find(c => c.Value == i) == null
                        || Box.Find(c => c.Value == i) == null
                        )
                        return false;
                }

                return valid;
            }

            public Cell(Grid grid, int x, int y, int value)
            {
                _Grid = grid;
                X = x;
                Y = y;
                Value = value;

                if (value == 0)
                {
                    poss = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                }
            }

            public bool Solve()
            {
                if (Row == null)
                {
                    Row = _Grid.GetRow(X, Y);
                    Col = _Grid.GetCol(X, Y);
                    Box = _Grid.GetBox(X, Y);
                }

                bool somethingChanged = false;
                if (Value != 0)
                    return false;                

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
                    {
                        Value = poss[0];
                        somethingChanged = true;
                    }
                }

                if (Value == 0)
                {
                    for (int p = 0; p < poss.Count; p++)
                    {
                        bool canHave = false;

                        foreach (var c in Row.Where(z => z != this))
                            if (c.CanHave(poss[p]))
                            {
                                canHave = true;
                                break;
                            }
                        if (canHave)
                        {
                            canHave = false;
                            foreach (var c in Col.Where(z => z != this))
                                if (c.CanHave(poss[p]))
                                {
                                    canHave = true;
                                    break;
                                }
                        }
                        if (canHave)
                        {
                            canHave = false;
                            foreach (var c in Box.Where(z => z != this))                            
                                if (c.CanHave(poss[p]))
                                {
                                    canHave = true;
                                    break;
                                }
                        }
                        if (!canHave)
                        {
                            Value = poss[p];
                            somethingChanged = true;
                            break;
                        }
                    }
                }

                return somethingChanged;
            }

            bool CanHave(int i)
            {
                if (Row == null)
                {
                    Row = _Grid.GetRow(X, Y);
                    Col = _Grid.GetCol(X, Y);
                    Box = _Grid.GetBox(X, Y);
                }

                if (Value != 0)
                    return false;

                if (Row.Find(t => t.Value == i) != null
                    || Col.Find(t => t.Value == i) != null
                    || Box.Find(t => t.Value == i) != null)                
                    return false;

                return true;
            }
        }

        public class Grid : List<List<Cell>>
        {
            public Grid(Grid c)
            {
                foreach (var row in c)
                {
                    var r = new List<Cell>();
                    foreach (var cell in row)
                        r.Add(new Cell(this, cell));
                    Add(r);
                }
            }

            public Grid() : base() { }

            protected void Equals(Grid c)
            {
                foreach (var row in c)
                    foreach (var cell in row)
                        this[cell.X][cell.Y] = cell;
            }

            public Grid(List<int> nums) : base()
            {
                for (int i = 0; i < 81; i++)
                {
                    if (i % 9 == 0)
                        Add(new List<Cell>());

                    this[i / 9].Add(new Cell(this, i / 9, i % 9, nums[i]));
                }
            }

            public bool Check()
            {
                foreach (var row in this)                
                    foreach (var cell in row)
                        if (!cell.Check())
                            return false;

                return true;
            }

            public List<Cell> GetRow(int x, int y)
            {
                return this[x];
            }

            public List<Cell> GetCol(int x, int y)
            {
                var col = new List<Cell>();
                foreach (var row in this)
                    col.Add(row[y]);
                
                return col;
            }

            public List<Cell> GetBox(int x, int y)
            {
                var box = new List<Cell>();
                var xMod = x % 3;
                
                GetColBox(x - xMod);
                GetColBox(x - xMod + 1);
                GetColBox(x - xMod + 2);                        

                return box;

                void GetColBox(int lineNum)
                {
                    var yMod = y % 3;
                    
                    box.Add(this[lineNum][y - yMod]);
                    box.Add(this[lineNum][y - yMod + 1]);
                    box.Add(this[lineNum][y - yMod + 2]);                            
                }
            }

            public bool SolveSimple()
            {
                bool somethingChanged = false;
                do
                {
                    somethingChanged = false;
                    foreach (var row in this)
                        foreach (var cell in row)
                        {
                            if (cell.Solve())
                                somethingChanged = true;
                        }
                } while (!Solved() && somethingChanged);

                return somethingChanged;               
            }

            bool SolveWithGuesswork()
            {
                var emptyCells = new List<Cell>();
                foreach (var row in this)
                {
                    emptyCells.AddRange(row.FindAll(r => r.Value == 0));
                }

                foreach (var cell in emptyCells)
                    foreach (var pos in cell.poss)
                    {
                        var copy = new Grid(this);
                        copy[cell.X][cell.Y].Value = pos;
                        if (copy.SolveSimple() && copy.Check())
                        {
                            this.Equals(copy);
                            return true;
                        }
                    }

                return false;
            }

            public bool Solve()
            {
                return SolveSimple() || SolveWithGuesswork();
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
        }

        public static List<int> Run(List<int> l)
        {
            throw new NotImplementedException();
        }

        public static long Run()
        {

           /*var l = new List<int>
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
            return 0;*/

         //  var l = new List<int>
         //  {
         //       0,0,1,0,0,7,0,9,0,
         //       5,9,0,0,8,0,0,0,1,
         //       0,3,0,0,0,0,0,8,0,
         //       0,0,0,0,0,5,8,0,0,
         //       0,5,0,0,6,0,0,2,0,
         //       0,0,4,1,0,0,0,0,0,
         //       0,8,0,0,0,0,0,3,0,
         //       1,0,0,0,2,0,0,7,9,
         //       0,2,0,7,0,0,4,0,0
         //  };
         // 
         //  Grid g = new Grid(l);
         //   g.Solve();
         //  // if (!g.Check())
         //       g.Print();
         //   return 0;

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
            
            long res = 0;
            foreach (var grid in Grids)
            {           
                grid.Solve();     
                
                res += long.Parse($"{grid[0][0].Value}{grid[0][1].Value}{grid[0][2].Value}"); 

            }

            return res;//24702
        }
    }
}
