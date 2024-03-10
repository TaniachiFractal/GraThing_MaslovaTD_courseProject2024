using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace GraThing_by_TaniachiFractal
{
    /// <summary>
    /// The form that draws the graphs written in settings form
    /// </summary>
    public partial class GraphForm : Form
    {
        #region public

        /// <summary>
        /// The amount of graphs to be drawn
        /// </summary>
        public int GraphCount;
        /// <summary>
        /// The identificator of the current coordinate system
        /// </summary>
        public byte CoordSys_Id;
        /// <summary>
        /// The minimal and maximum value of t for parametric functions
        /// </summary>
        public double tMax, tMin;

        /// <summary>
        /// Boot every render method
        /// </summary>
        public void DrawAll()
        {
            UpdateBackground();
            DrawStrips();
            switch (CoordSys_Id)
            {
                case Cnst.CARTESIAN_ID:
                    DrawCartesianGraphs(); break;
                case Cnst.POLARfromR_ID:
                    DrawPolarGraphs_fromR(); break;
                case Cnst.POLARfromPHI_ID:
                    DrawPolarGraphs_fromPhi(); break;
                case Cnst.PARAM_ID:
                    DrawParametricGraphs(); break;
            }
        }

        /// <summary>
        /// Form constructor
        /// </summary>
        public GraphForm()
        {
            InitializeComponent();
        }

        #endregion

        #region data

        #region graphics

        /// <summary>
        /// Main drawing field
        /// </summary>
        Graphics canvas;

        /// <summary>
        /// Info on drawing various things on the form
        /// </summary>
        Pen AxisPen, StripPen;

        /// <summary>
        /// Graph pens
        /// </summary>
        Pen[] GraphPen = new Pen[10];

        /// <summary>
        /// Info on drawing various things on the form
        /// </summary>
        Brush Stripbrush;

        #endregion

        #region sizes

        /// <summary>
        /// Arrow dimens
        /// </summary>
        int arrowHeight, arrowWidth;
        /// <summary>
        /// Distance between 2 strips
        /// </summary>
        int gridSize;
        /// <summary>
        /// Length of 1 strip
        /// </summary>
        int stripSize;
        /// <summary>
        /// Font size of little integers
        /// </summary>
        int incrFntSz;
        /// <summary>
        /// Window dimens
        /// </summary>
        int winWidth, winHeight;
        /// <summary>
        /// The center point to draw from
        /// </summary>
        int horizMiddle, vertMiddle;

        #endregion   

        #region calc

        /// <summary>
        /// What is actually between 2 strips, 0-1 or 0-10 or 0-100, etc.
        /// </summary>
        double gridIncrement;
        /// <summary>
        /// The start and the end of the graph
        /// </summary>
        int currMaxX, currMinX;

        /// <summary>
        /// Step between calculating coords
        /// </summary>
        double step;

        /// <summary>
        /// The cartesian functions that are drawn currently
        /// </summary>
        List<Func<double, double>> GraphFunction_cartesian = new List<Func<double, double>>();
        /// <summary>
        /// The polar functions from R that are drawn currently
        /// </summary>
        List<Func<double, double>> GraphFunction_polarFromR = new List<Func<double, double>>();
        /// <summary>
        /// The polar functions from Phi that are drawn currently
        /// </summary>
        List<Func<double, double>> GraphFunction_polarFromPhi = new List<Func<double, double>>();
        /// <summary>
        /// The parametric functions that are drawn currently
        /// </summary>
        List<Func<double, (double, double)>> GraphFunction_parametric = new List<Func<double, (double, double)>>();

        #endregion

        #region misc

        /// <summary>
        /// Names of axis
        /// </summary>
        string HorizAxisName, VertAxisName;

        /// <summary>
        /// Previous state of the window
        /// </summary>
        FormWindowState oldWindowState;

        #endregion

        #endregion

        #region form events

        /// <summary>
        /// Redraw strips and graph after resizing
        /// </summary>
        private void GraphForm_ResizeEnd(object sender, EventArgs e)
        {
            ChangeGrid(0);
            DrawAll();
        }

        /// <summary>
        /// Kill app so there are no conflicts
        /// </summary>
        private void GraphForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Change scale upon rolling mouse wheel
        /// </summary>
        private void GraphForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ChangeGrid(e.Delta)) DrawAll();
        }

        /// <summary>
        /// Reset center
        /// </summary>
        private void GraphForm_MouseClick(object sender, MouseEventArgs e)
        {
            horizMiddle = e.X; vertMiddle = e.Y;
            DrawAll();
        }

        /// <summary>
        /// Load the form
        /// </summary>
        private void GraphForm_Load(object sender, EventArgs e)
        {
            InitVars();
        }

        /// <summary>
        /// Redraw axis
        /// </summary>
        private void GraphForm_Resize(object sender, EventArgs e)
        {
            ReInitVars();
            UpdateBackground();
            if (WindowState == FormWindowState.Maximized ||
                (WindowState == FormWindowState.Normal && oldWindowState != WindowState))
            {
                GraphForm_ResizeEnd(sender, e);
            }
            oldWindowState = WindowState;
        }


        #endregion

        #region init

        /// <summary>
        /// recalc variables
        /// </summary>
        private void ReInitVars()
        {
            canvas = this.CreateGraphics();

            winWidth = this.Width;
            winHeight = this.Height;

            arrowHeight = winWidth / 150; if (arrowHeight < 6) arrowHeight = 6;
            arrowWidth = arrowHeight / 2;
            horizMiddle = winWidth / 2 - Cnst.padding;
            vertMiddle = winHeight / 2 - Cnst.padding;

            incrFntSz = winWidth / 40 / 3; if (incrFntSz > 5) incrFntSz = 5;
            InitCartesianGraphs();
            InitParametricGraphs();
            InitPolarFromRGraphs();
        }
        /// <summary>
        /// Change the grid size and increment
        /// </summary>
        /// <returns>Whether to initiate redraw</returns>
        private bool ChangeGrid(int wheelDelta)
        {
            int direction = Sign(wheelDelta);
            double newGridSize, newGridIncrement = gridIncrement, newStep = step;
            #region newGridSize
            if (gridSize < 40)
                newGridSize = gridSize + direction * 10;
            else
                newGridSize = gridSize + direction * 20;

            newGridSize -= newGridSize % 10;

            if (newGridSize < 1) newGridSize = 1;
            if (newGridSize > winWidth / 2) newGridSize = winWidth / 2;
            #endregion
            if (gridSize == (int)newGridSize) return false;

            if (newGridSize <= 10)
            {
                newGridSize = 100;
                newGridIncrement *= 10;
            }
            else if (newGridSize >= 100)
            {
                newGridSize = 10;
                newGridIncrement /= 10;
            }

            newStep = newGridIncrement / 100;

            this.Text = "" + newStep;

            if (newGridIncrement > 0.00001)
            {
                step = newStep;
                gridIncrement = newGridIncrement;
                gridSize = (int)newGridSize;
            }
            else return false;

            return true;
        }

        /// <summary>
        /// Init variables
        /// </summary>
        private void InitVars()
        {
            /* For whatever reason, this is not present in designer.
             So I have to do it myself */
            this.MouseWheel += GraphForm_MouseWheel;

            canvas = this.CreateGraphics();

            winWidth = this.Width;
            winHeight = this.Height;

            arrowHeight = winWidth / 150; if (arrowHeight < 6) arrowHeight = 6;
            arrowWidth = arrowHeight / 2;
            horizMiddle = winWidth / 2 - Cnst.padding;
            vertMiddle = winHeight / 2 - Cnst.padding;

            incrFntSz = winWidth / 40 / 3; if (incrFntSz > 8) incrFntSz = 8;

            AxisPen = new Pen(Colors.AxisColor, 1);
            StripPen = new Pen(Colors.StripColor, 1);
            Stripbrush = new SolidBrush(Colors.StripColor);

            InitGraphPens();
            stripSize = 4;
            gridIncrement = 1;
            HorizAxisName = "x";
            VertAxisName = "y";
            gridSize = 30;
            step = 0.01;

            InitCartesianGraphs();
            InitParametricGraphs();
            InitPolarFromRGraphs();
            InitPolarFromPhiGraphs();
        }

        /// <summary>
        /// Initialize pens for all graphs
        /// </summary>
        private void InitGraphPens()
        {
            for (int i = 0; i < Cnst.MaxGraphCount; i++)
            {
                GraphPen[i] = new Pen(Colors.GraphColor[i], 1);
            }
        }

        /// <summary>
        /// Init current cartesian graphs functions
        /// </summary>
        private void InitCartesianGraphs()
        {
            GraphFunction_cartesian.Add(Math.Tan);
            GraphFunction_cartesian.Add(SinX);
            GraphFunction_cartesian.Add(Math.Log);

            GraphFunction_cartesian.Add(Hyperbola);
            GraphFunction_cartesian.Add(HalfCircle);
            GraphFunction_cartesian.Add(eqX);

            GraphFunction_cartesian.Add(Math.Tan);
            GraphFunction_cartesian.Add(Math.Cos);
            GraphFunction_cartesian.Add(Math.Round);

            GraphFunction_cartesian.Add(Math.Abs);
        }
        /// <summary>
        /// Init current polar graphs from R functions
        /// </summary>
        private void InitPolarFromRGraphs()
        {

            GraphFunction_polarFromR.Add(Xpow2);
            GraphFunction_polarFromR.Add(SinX);
            GraphFunction_polarFromR.Add(eq2);

            GraphFunction_polarFromR.Add(Hyperbola);
            GraphFunction_polarFromR.Add(HalfCircle);
            GraphFunction_polarFromR.Add(eqX);

            GraphFunction_polarFromR.Add(Math.Tan);
            GraphFunction_polarFromR.Add(Math.Cos);
            GraphFunction_polarFromR.Add(Math.Log);

            GraphFunction_polarFromR.Add(Math.Abs);
        }
        /// <summary>
        /// Init current polar graphs from Phi functions
        /// </summary>
        private void InitPolarFromPhiGraphs()
        {
            GraphFunction_polarFromPhi.Add(Xpow2);
            GraphFunction_polarFromPhi.Add(Cos);
            GraphFunction_polarFromPhi.Add(eq2);

            GraphFunction_polarFromPhi.Add(Hyperbola);
            GraphFunction_polarFromPhi.Add(HalfCircle);
            GraphFunction_polarFromPhi.Add(eqX);

            GraphFunction_polarFromPhi.Add(Math.Tan);
            GraphFunction_polarFromPhi.Add(Math.Cos);
            GraphFunction_polarFromPhi.Add(Math.Log);

            GraphFunction_polarFromPhi.Add(Math.Abs);
        }
        /// <summary>
        /// Init current parametric graphs functions
        /// </summary>
        private void InitParametricGraphs()
        {
            GraphFunction_parametric.Add(Tparam);
            GraphFunction_parametric.Add(Tparam);
            GraphFunction_parametric.Add(Ellipse);

            GraphFunction_parametric.Add(Tparam);
            GraphFunction_parametric.Add(CircleParam);
            GraphFunction_parametric.Add(Ellipse);

            GraphFunction_parametric.Add(Tparam);
            GraphFunction_parametric.Add(CircleParam);
            GraphFunction_parametric.Add(Ellipse);

            GraphFunction_parametric.Add(Tparam);
        }

        #endregion

        #region render

        /// <summary>
        /// Redraw all the secondary elements on the form except for strips (they take too much time to update)
        /// </summary>
        private void UpdateBackground()
        {
            canvas.Clear(BackColor);

            #region coords

            Point vertAxisEnd = new Point(horizMiddle, Cnst.padding),
                  vertAxisStart = new Point(horizMiddle, winHeight),
                  horizAxisEnd = new Point(winWidth - Cnst.padding * 3, vertMiddle),
                  horizAxisStart = new Point(0, vertMiddle),
                  center = new Point(horizMiddle, vertMiddle);

            #endregion

            #region Draw axis

            canvas.DrawLine(AxisPen, vertAxisStart, vertAxisEnd); // vertical
            canvas.DrawLine(AxisPen, horizAxisStart, horizAxisEnd); // horizontal

            #endregion

            #region Add axis arrows

            canvas.DrawLine(AxisPen, vertAxisEnd,
                new Point(horizMiddle - arrowWidth, Cnst.padding + arrowHeight)); //  ^
            canvas.DrawLine(AxisPen, vertAxisEnd,
                new Point(horizMiddle + arrowWidth, Cnst.padding + arrowHeight));

            canvas.DrawLine(AxisPen, horizAxisEnd,
                new Point(winWidth - Cnst.padding * 3 - arrowHeight, vertMiddle + arrowWidth)); // >
            canvas.DrawLine(AxisPen, horizAxisEnd,
                new Point(winWidth - Cnst.padding * 3 - arrowHeight, vertMiddle - arrowWidth));

            #endregion

            #region Add axis names

            // Horizontal
            canvas.DrawString(HorizAxisName, Font, Stripbrush, horizAxisEnd);
            // Vertical
            canvas.DrawString(" " + VertAxisName, Font, Stripbrush, vertAxisEnd);

            #endregion

            #region add increment value

            // 0
            canvas.DrawString("0", new Font(FontFamily.GenericSansSerif, incrFntSz), Stripbrush,
                new Point(horizMiddle - incrFntSz - 1, vertMiddle + 1));

            #endregion
        }

        /// <summary>
        /// Draw strips on the field
        /// </summary>
        private void DrawStrips()
        {
            #region draw strip and int methods

            // Draw 1 strip
            void DrawStrip(int distFromZero, bool vertical)
            {
                int halfStrip = stripSize / 2;
                if (vertical)
                {
                    canvas.DrawLine(StripPen, new Point(horizMiddle - halfStrip, vertMiddle + distFromZero),
                        new Point(horizMiddle + halfStrip, vertMiddle + distFromZero));
                }
                else
                {
                    canvas.DrawLine(StripPen, new Point(horizMiddle + distFromZero, vertMiddle - halfStrip),
                        new Point(horizMiddle + distFromZero, vertMiddle + halfStrip));
                }
            }

            // Draw 1 num
            void DrawGraphNum(double num, int distFromZero, bool vertical)
            {
                int halfStrip = stripSize / 2;

                Point drawStart;
                if (vertical)
                {
                    drawStart = new Point(horizMiddle - halfStrip + stripSize + halfStrip, vertMiddle + distFromZero - incrFntSz);
                }
                else
                {
                    drawStart = new Point(horizMiddle + distFromZero - incrFntSz, vertMiddle - halfStrip + stripSize);
                }

                canvas.DrawString(num.ToString(), new Font(FontFamily.GenericSansSerif, incrFntSz), Stripbrush,
                    drawStart);
            }

            // Draw both
            void DrawStripAndNum(double num, int distFromZero, bool vertical)
            {
                DrawStrip(distFromZero, vertical);
                DrawGraphNum(num, distFromZero, vertical);
            }

            #endregion

            #region draw cycles

            //  → >
            int currDistFromZero = gridSize;
            double i = gridIncrement;
            while (currDistFromZero < winWidth - Cnst.padding * 3 - arrowHeight - horizMiddle)
            {
                DrawStripAndNum(i, currDistFromZero, false); i += gridIncrement;
                currDistFromZero += gridSize;
            }
            currMaxX = (int)i; if (currMaxX < 1) { currMaxX = 1; }
            //  < ←
            i = -gridIncrement;
            currDistFromZero = -gridSize;
            while (currDistFromZero > -winWidth)
            {
                DrawStripAndNum(i, currDistFromZero, false); i -= gridIncrement;
                currDistFromZero -= gridSize;
            }
            currMinX = (int)i; if (currMinX > -1) { currMinX = -1; }
            //  ↓ \/
            i = -gridIncrement;
            currDistFromZero = gridSize;
            while (currDistFromZero < winHeight)
            {
                DrawStripAndNum(i, currDistFromZero, true); i -= gridIncrement;
                currDistFromZero += gridSize;
            }
            // ↑ /\
            i = gridIncrement;
            currDistFromZero = -gridSize;
            while (currDistFromZero > -winHeight)
            {
                DrawStripAndNum(i, currDistFromZero, true); i += gridIncrement;
                currDistFromZero -= gridSize;
            }

            #endregion
        }

        #region cartesian

        /// <summary>
        /// Draw a single line of a cartesian graph
        /// </summary>
        private void DrawCartesianGraphLine(Func<double, double> graphFunct, double startX, double endX, int graphNum)
        {
            double startY = graphFunct(startX);
            double endY = graphFunct(endX);

            Point start = DoubleToCoord(startX, startY);
            Point end = DoubleToCoord(endX, endY);

            if (startY * endY < 0)
            {
                double x0 = startX, x1 = endX;
                do
                {
                    double y0 = graphFunct(x0), y1 = graphFunct(x1),
                        xm = (x0 + x1) / 2, ym = graphFunct(xm);

                    if (y0 * ym < 0)
                        x1 = xm;
                    else if (ym * y1 < 0)
                        x0 = xm;

                } while (Math.Abs(x0 - x1) > Cnst.epsilon);

                double y = graphFunct((x0 + x1) / 2);

                if (Math.Abs(y) > 1.0e-8)
                {
                    Point p1 = new Point(start.X, 0);
                    Point p2 = new Point(end.X, 0);

                    if (startY > 0)
                    {
                        p1.Y = -32767;
                        p2.Y = 32768;
                    }
                    else
                    {
                        p1.Y = 32768;
                        p2.Y = -32767;
                    }

                    try
                    {
                        canvas.DrawLine(GraphPen[graphNum], start, p1);
                        canvas.DrawLine(GraphPen[graphNum], p2, end);
                    } catch { }

                    return;
                }
            }

            if (start != Cnst.undefined && end != Cnst.undefined)
            {
                try { canvas.DrawLine(GraphPen[graphNum], start, end); }
                catch { }
            }

        }

        /// <summary>
        /// Draw a cartesian graph
        /// </summary>
        private void DrawOneCartesianGraph(Func<double, double> graphFunct, int graphNum)
        {
            for (double i = currMinX * 2; i < currMaxX * 2; i += step)
            {
                DrawCartesianGraphLine(graphFunct, i, i + step, graphNum);
            }
        }

        /// <summary>
        /// Draw all cartesian graphs
        /// </summary>
        private void DrawCartesianGraphs()
        {
            for (int i = 0; i < GraphCount; i++)
            {
                DrawOneCartesianGraph(GraphFunction_cartesian[i], i);
            }
        }

        #endregion

        #region polar from R

        /// <summary>
        /// Draw a polar from R graph line
        /// </summary>
        private void DrawPolarFromRGraphLine(Func<double, double> graphFunct, double startR, double endR, int graphNum)
        {
            double startPhi = graphFunct(startR);
            double endPhi = graphFunct(endR);

            (double startX, double startY) = PolarToCartesian(startR, startPhi);
            (double endX, double endY) = PolarToCartesian(endR, endPhi);

            Point start = DoubleToCoord(startX, startY);
            Point end = DoubleToCoord(endX, endY);

            if (start != Cnst.undefined && end != Cnst.undefined)
            {
                try { canvas.DrawLine(GraphPen[graphNum], start, end); }
                catch { } // Draw line
            }
        }

        /// <summary>
        /// Draw a polar from R graph
        /// </summary>
        private void DrawOnePolarFromRGraph(Func<double, double> graphFunct, int graphNum)
        {
            if (step > 0.1) step = 0.1;
            for (double i = currMinX * 2; i < currMaxX * 2; i += step)
            {
                DrawPolarFromRGraphLine(graphFunct, i, i + step, graphNum);
            }
        }

        /// <summary>
        /// Draw all polar graphs from R
        /// </summary>
        private void DrawPolarGraphs_fromR()
        {
            for (int i = 0; i < GraphCount; i++)
            {
                DrawOnePolarFromRGraph(GraphFunction_polarFromR[i], i);
            }
        }

        #endregion

        #region polar from Phi

        /// <summary>
        /// Draw a polar from Phi graph line
        /// </summary>
        private void DrawPolarFromPhiGraphLine(Func<double, double> graphFunct, double startPhi, double endPhi, int graphNum)
        {
            double startR = graphFunct(startPhi);
            double endR = graphFunct(endPhi);

            (double startX, double startY) = PolarToCartesian(startR, startPhi);
            (double endX, double endY) = PolarToCartesian(endR, endPhi);

            Point start = DoubleToCoord(startX, startY);
            Point end = DoubleToCoord(endX, endY);

            if (start != Cnst.undefined && end != Cnst.undefined)
            {
                try { canvas.DrawLine(GraphPen[graphNum], start, end); }
                catch { } // Draw line
            }
        }

        /// <summary>
        /// Draw a polar from Phi graph
        /// </summary>
        private void DrawOnePolarFromPhiGraph(Func<double, double> graphFunct, int graphNum)
        {
            if (step > 0.1) step = 0.1;
            for (double i = currMinX * 2; i < currMaxX * 2; i += step)
            {
                DrawPolarFromPhiGraphLine(graphFunct, i, i + step, graphNum);
            }
        }

        /// <summary>
        /// Draw all polar graphs from Phi
        /// </summary>
        private void DrawPolarGraphs_fromPhi()
        {
            for (int i = 0; i < GraphCount; i++)
            {
                DrawOnePolarFromPhiGraph(GraphFunction_polarFromPhi[i], i);
            }
        }


        #endregion

        #region parametric

        /// <summary>
        /// Draw a single line of a param graph
        /// </summary>
        private void DrawParametricGraphLine(Func<double, (double, double)> graphFunct, double startT, double endT, int graphNum)
        {
            (double startX, double startY) = graphFunct(startT);
            (double endX, double endY) = graphFunct(endT);

            Point start = DoubleToCoord(startX, startY);
            Point end = DoubleToCoord(endX, endY);

            if (start != Cnst.undefined && end != Cnst.undefined)
            {
                try { canvas.DrawLine(GraphPen[graphNum], start, end); }
                catch { } // Draw line
            }
        }

        /// <summary>
        /// Draw a parametric graph
        /// </summary>
        private void DrawOneParametricGraph(Func<double, (double, double)> graphFunct, int graphNum)
        {
            for (double i = tMin; i < tMax; i += step)
            {
                DrawParametricGraphLine(graphFunct, i, i + step, graphNum);
            }
        }

        /// <summary>
        /// Draw all parametric graphs
        /// </summary>
        private void DrawParametricGraphs()
        {
            for (int i = 0; i < GraphCount; i++)
            {
                DrawOneParametricGraph(GraphFunction_parametric[i], i);
            }
        }

        #endregion

        #endregion

        #region calculating

        /// <returns>Actual screen coords based on calculated doubles</returns>
        Point DoubleToCoord(double x, double y)
        {
            double outX, outY;

            outX = x * gridSize / gridIncrement;
            outY = -y * gridSize / gridIncrement;
            outX += horizMiddle;
            outY += vertMiddle;


            if (Math.Abs(outX) > int.MaxValue - 1 || Math.Abs(outY) > int.MaxValue - 1)
            {
                return Cnst.undefined;
            }

            int finX = (int)outX;
            int finY = (int)outY;

            return new Point(finX, finY);
        }

        /// <summary>
        /// Convert polar coordinates to cartesian
        /// </summary>
        (double, double) PolarToCartesian(double R, double Phi)
        {
            return (R * Math.Sin(Phi), R * Math.Cos(Phi));
        }

        /// <summary>
        /// Distance between 2 points
        /// </summary>
        double Distance(Point point1, Point point2)
        {

            double output = Math.Sqrt(
                     (point1.X - point2.X) * (point1.X - point2.X)
                   +
                     (point1.Y - point2.Y) * (point1.Y - point2.Y)
                            );
            return output;

        }

        /// <returns>-1 if input less than 0, 1 if input more than 0, 0 if input=0</returns>
        int Sign(int input)
        {
            if (input > 0) return 1;
            if (input < 0) return -1;
            return 0;
        }

        #endregion

        #region functions to draw

        double cool(double x)
        {
            return Math.Sin(3 * x) + 40;
        }

        double log(double x)
        {
            return Math.Log(x, 4) * 10;
        }

        double Xpow2(double x)
        {
            return x * x;
        }

        double SinX(double x)
        {
            return 50 * Math.Sin(0.5 * x);
        }

        double Cos(double x)
        {
            return 2 * Math.Cos(x);
        }



        double eq2(double x)
        {
            return 2;
        }

        double Hyperbola(double x)
        {
            return 4 / x;
        }

        double HalfCircle(double x)
        {
            return Math.Sqrt(4 - x * x);
        }

        double eqX(double x)
        {
            return 2 * x;
        }

        (double, double) Tparam(double t)
        {
            return (t * t, t);
        }

        (double, double) CircleParam(double t)
        {
            return (Math.Sin(t), Math.Cos(t));
        }

        (double, double) Ellipse(double t)
        {
            return (Math.Sin(t), 2 * Math.Cos(t));
        }

        #endregion
    }
}