using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraThing_by_TaniachiFractal
{
    /// <summary>
    /// Parses math functions
    /// </summary>
    class MathParser
    {
        public static Func<double,double> ParseMath(string input)
        {
            if (StandardFunctions.Sf.TryGetValue(input, out Func<double, double> output)) return output;
            else return eqX;

        }

        public static Func<double, (double, double)> ParseMath_Param(string input)
        {
            if (StandardFunctions.Sfp.TryGetValue(input, out Func<double, (double, double)> output)) return output;
            else return eqT;
       }

        static double eqX(double x) { return x; }
        static (double,double) eqT(double t) { return (t, t); }
    }
}
