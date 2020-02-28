using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Euler.Solutions;

namespace Euler.GUI
{
    public partial class Form1 : Form
    {
        private ISolutionPanel pnl;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 600;
            Height = 500;
            //ddProblems.Items.Add(96);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Load_96();
            //foreach (var ctl in Controls)
            //{
            //    ddProblems.SelectedItem.ToString();
            //  }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            Solve_96();
        }

        void Load_96()
        {
           // GroupBox g = new GroupBox();
            pnl = new SolutionPanel();
            pnl.Load(this, l_96);
        }

        void Solve_96()
        {
            pnl.Solve(s_96);
        }

        bool s_96(GroupBox g)
        {
            var l = new List<int>();

            for (int i = 0; i < 81; i++)
            {
                var n = g.Controls.Find($"n_{i}", true);
                l.Add((int)((NumericUpDown)n[0]).Value);
            }

            l = _96.Run(l);

            int idx = 0;
            foreach (var n in l)
            {
                var box = ((NumericUpDown)g.Controls.Find($"n_{idx}", true)?[0]);
                box.Value = n;
                idx++;
            }

            return true;
        }

        bool l_96(Form p, GroupBox g)
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

            g.Text = "Sol 96";
            g.Width = p.Width - 40;
            g.Left = 10;
            g.Height = p.Height - 150;
            g.Top = 10;

            p.Controls.Add(g);
            
            var curTop = 45;
            int curLeft;
            int idx = 0;
            for (int y = 0; y < 9; y++)
            {
                curLeft = 35;

                for (int i = 0; i < 9; i++)
                {
                    NumericUpDown n = new NumericUpDown();
                    n.Maximum = 9;
                    n.Value = l[idx];
                    n.Name = $"n_{idx++}";
                    ddProblems.Items.Add(n.Name);
                    n.Width = 30;
                    //n.Height = 48;
                    n.Left = curLeft;
                    n.Top = curTop;

                    curLeft += (i+1)%3 == 0 ? 50 : 35;
                    g.Controls.Add(n);
                }

                curTop += (y + 1) % 3 == 0 ? 35 : 25; ;
            }

            return true;
        }

      
    }
}
