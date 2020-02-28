using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Euler.GUI
{
    public interface ISolutionPanel
    {
        // GroupBox Panel { get; set; }

        void Load(Form parent, Func<Form, GroupBox, bool> f);

        void Solve(Func<GroupBox, bool> f);
    }
}