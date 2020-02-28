using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Euler.GUI
{
    public class SolutionPanel : ISolutionPanel
    {
        GroupBox Panel { get; set; } = new GroupBox();
        //Dictionary<string, object> 

        public void Load(Form parent, Func<Form, GroupBox, bool> f)
        {
            f(parent, Panel);
        }

        public void Solve(Func<GroupBox, bool> s)
        {
            s(Panel);
        }
    }
}
