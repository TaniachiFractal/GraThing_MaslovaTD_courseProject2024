using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraThing_by_TaniachiFractal
{
    /// <summary>
    /// Colors of various things on the form
    /// </summary>
    internal class Colors
    {
        /// <summary>
        /// Other colors
        /// </summary>
        public static readonly Color AxisColor = Color.White,
                              StripColor = Color.Silver;

        /// <summary>
        /// Colors of graphs
        /// </summary>
        public static readonly Color[] GraphColor = {
            Color.FromArgb(255,142,142),
            Color.FromArgb(165,251,89),
            Color.FromArgb(95,145,145),

            Color.FromArgb(242,77,77),
            Color.FromArgb(98,202,4),
            Color.FromArgb(18,173,224),

            Color.OrangeRed,
            Color.Orange,
            Color.Yellow,

            Color.FromArgb(189,162,225)
        };
                                
    }
}
