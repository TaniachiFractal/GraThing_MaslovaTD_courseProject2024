using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraThing_by_TaniachiFractal
{
    /// <summary>
    /// Contains preset functions and their corresponding strings
    /// </summary>
    class StandardFunctions
    {
        /// <summary>
        /// Cartesian and Polar functions
        /// </summary>
        static public Dictionary<string, Func<double, double>> Sf = new Dictionary<string, Func<double, double>>
        {
            { "y=sin(x)", Math.Sin },
            { "y=cos(x)", Math.Cos },
            { "y=log10(x)", Math.Log10 },
            { "y=tan(x)", Math.Tan },
            { "y=x^2", Pow2 },
            { "y=1/x", Hyperbola },
            { "y=|x|", Math.Abs },
            { "y=sqrt(x)", Math.Sqrt},
            { "y=x",  EqX },
            { "y=x^3", Pow3 },
            { "y=tan|x|", TanAbs}
        };

        /// <summary>
        /// Parametric functions 
        /// </summary>
        static public Dictionary<string, Func<double, (double, double)>> Sfp = new Dictionary<string, Func<double, (double, double)>>
        {
            { "x=t*t; y=t",SidewaysParabola },
            { "x=sin(t); y=cos(t)",Circle },
            { "x=sin(t); y=2cos(t)",Ellipse },
            { "x=tan(x); y=sin(x)",TanTSinT },
            { "x=sin(t); y=t",SidewaysSin}
        };

        static double Pow2(double x) { return x * x; }
        static double Pow3(double x) { return x * x * x; }
        static double Hyperbola(double x) { return 1 / x; }
        static double TanAbs(double x) { return Math.Tan(Math.Abs(x)); }
        static double EqX(double x) { return x; }
        static (double, double) SidewaysParabola(double t) { return (t * t, t); }
        static (double, double) Circle(double t) { return (Math.Sin(t), Math.Cos(t)); }
        static (double, double) Ellipse(double t) { return (Math.Sin(t), 2 * Math.Cos(t)); }
        static (double, double) TanTSinT(double t) { return (Math.Tan(t), Math.Sin(t)); }
        static (double, double) SidewaysSin(double t) { return (Math.Sin(t), t); }
    }
}
