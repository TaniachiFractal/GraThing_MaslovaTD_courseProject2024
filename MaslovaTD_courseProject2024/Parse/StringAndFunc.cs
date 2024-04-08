using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraThing_by_TaniachiFractal
{
    /// <summary>
    /// Contains functions with corresponding strings
    /// </summary>
    class StringAndFunc
    {
        string str;
        Func<double, double> fun;
        public StringAndFunc(string str_, Func<double, double> fun_)
        {
            str = str_; fun = fun_;
        }
    }
}
