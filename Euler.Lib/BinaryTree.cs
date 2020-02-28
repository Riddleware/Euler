using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler.Lib
{
    public class Node : object
    {
        public Node Left { get; set; }
        public Node Right { get; set; }

        protected int _value;
        public int Value
        {
            get
            {
                if (Left == null && Right == null)
                    return _value;

                return GetNodes().Distinct().ToList().Sum(n => n._value);
            }
            set { _value = value; }
        }

        public List<int> GetPath(string path)
        {
            var ret = new List<int>();

            ret.Add(_value);

            if (Right != null && Left != null)
            {
                ret.AddRange(path[0] == '0' ? Left.GetPath(path.Substring(1)) : Right.GetPath(path.Substring(1)));
            }
            return ret;
        }

        public List<int> GetLargestPath()
        {
            var ret = new List<int>();

            ret.Add(_value);

            if (Right != null && Left != null)
            {
                ret.AddRange(Left.Value >= Right.Value ? Left.GetLargestPath() : Right.GetLargestPath());
            }
            return ret;
        }

        public List<Node> GetNodes()
        {
            var ret = new List<Node>();

            ret.Add(this);
            if (Right != null && Left != null)
            {
                ret.AddRange(Left.GetNodes());
                ret.AddRange(Right.GetNodes());
            }

            return ret;
        }

        public Node(int value)
        {
            _value = value;
        }

        public void Init(List<Node> a)
        {
            if (a.Count > 1)
            {
                AddLeft(a);
                AddRight(a);
            }
        }

        protected void AddLeft(List<Node> a)
        {
            List<Node> l = new List<Node>();
            int x = 1;

            for (int i = 1; i < a.Count; i++)
            {
                for (int z = 0; z < x; z++)
                {
                    l.Add(a[i + z]);
                }
                i += x;
                x++;
            }

            Left = l[0];
            Left.Init(l);
        }

        protected void AddRight(List<Node> a)
        {
            List<Node> l = new List<Node>();
            int x = 1;

            for (int i = 2; i < a.Count; i++)
            {
                for (int z = 0; z < x; z++)
                {
                    l.Add(a[i + z]);
                }
                i += x;
                x++;
            }

            Right = l[0];
            Right.Init(l);
        }

        public void Print()
        {
            Console.WriteLine(Value);
            if (Left != null) Left.Print();
            if (Right != null) Right.Print();
        }
    }


    /*  var Nodes = new List<Node>();
            foreach (var q in a)
            {
                Nodes.Add(new Node(q));
            }

            //var tot = 0;
            //var depth = 0;
            //var i = 1;
            //while (tot != a.Count)
            //{
            //    tot += depth++;
            //}
            //depth--;
            Node Root = Nodes[0];//new Node(Nodes);//, depth);
            Root.Init(Nodes);

            //var n = Root.GetNodes();
            //var v = Root.Value;

            List<int> path = Root.GetLargestPath();
            int Largest = 0;

            WritePath(true);
                        
  //          for (int pi = 16384; pi >= 0; pi--)
  //          {
  //              string s = Convert.ToString(pi, 2);
  //              while (s.Length < 15)
  //                  s += s.Insert(0, "0");
  //
  //              path = Root.GetPath(s);
  //              WritePath();
  //          }
  //
  //          WritePath(true);
  //          Console.WriteLine(Largest);
            //    n = n.Distinct().ToList();
            //    Root.Print();
            //14 = 105
            //15 = 120
            Console.ReadKey();
            void WritePath(bool alwaysOut = false)
            {
                var biggest = path.Sum();
                if (biggest > Largest)
                    Largest = biggest;

                if (biggest == 1074 || alwaysOut)
                {
                    foreach (var p in path)
                    {
                        Console.Write($"{p} -> ");
                    }
                    Console.WriteLine(biggest);
                }
            }*/
}
