﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraThing_by_TaniachiFractal
{
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
            { "y=sqrt(x)", Math.Sqrt}
        };

        /// <summary>
        /// Parametric functions 
        /// </summary>
        static public Dictionary<string, Func<double, (double, double)>> Sfp = new Dictionary<string, Func<double, (double, double)>>
        {
            { "x=t*t; y=t",SidewaysParabola },
            { "x=sin(t); y=cos(t)",Circle },
            { "x=sin(t); y=2cos(t)",Ellipse }
        };

        static double Pow2(double x) { return x * x; }
        static double Hyperbola(double x) { return 1 / x; }
        static (double, double) SidewaysParabola(double t) { return (t * t, t); }
        static (double, double) Circle(double t) { return (Math.Sin(t), Math.Cos(t)); }
        static (double, double) Ellipse(double t) { return (Math.Sin(t), 2 * Math.Cos(t)); }

    }
}