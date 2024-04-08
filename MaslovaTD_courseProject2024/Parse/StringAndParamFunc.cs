using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraThing_by_TaniachiFractal
{
    /// <summary>
    /// Contains parametric functions with corresponding strings
    /// </summary>
    class StringAndParamFunc
    {
        string str;
        Func<double, (double, double)> fun;
        public StringAndParamFunc(string str_, Func<double, (double, double)> fun_)
        {
            str = str_; fun = fun_;
        }
    }
}
