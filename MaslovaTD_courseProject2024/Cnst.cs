using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraThing_by_TaniachiFractal
{
    /// <summary>
    /// Constants for the program
    /// </summary>
    static internal class Cnst
    {
        /// <summary>
        /// Distance between elements
        /// </summary>
        public const int padding = 10;

        /// <summary>
        /// The point that is returnded when the function result is undefined
        /// </summary>
        public static readonly Point undefined = new Point(int.MinValue, int.MinValue);

        /// <summary>
        /// The max amount of graphs
        /// </summary>
        public const int MaxGraphCount = 10;

        /// <summary>
        /// Identificators of coordinate systems
        /// </summary>
        public const byte CARTESIAN_ID = 0, PARAM_ID = 1, POLARfromR_ID = 2, POLARfromPHI_ID = 3;

    }
}
