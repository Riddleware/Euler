using System;
using System.Collections.Generic;
using System.Text;

namespace Euler.Solutions
{
    public class Param
    {

    }

    public interface ISolution<in T, out TR>
    {
        TR Run(T param);
    }
}
