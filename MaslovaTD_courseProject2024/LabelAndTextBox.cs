using System.Windows.Forms;
namespace GraThing_by_TaniachiFractal
{
    /// <summary>
    /// A textbox for inputing a function with a function number label next to it
    /// <para>Like this:</para>
    /// <para>
    /// [_______] F1
    /// </para>
    /// </summary>
    internal class LabeledTextBox
    {
        /// <summary>
        /// The index of it
        /// </summary>
        readonly int number;

        /// <summary>
        /// The textbox of it
        /// </summary>
        public TextBox tb;
        /// <summary>
        /// The label of it
        /// </summary>
        public Label lb;
        /// <summary>
        /// The tb text
        /// </summary>
        public string Text { get => tb.Text; }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="i"></param>
        public LabeledTextBox(int i)
        {
            number = i;

            tb = new TextBox(); lb = new Label();

            tb.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            tb.Location = new System.Drawing.Point(12, 155 + i * 46);
            tb.Name = "tbF" + i;
            tb.Size = new System.Drawing.Size(247, 40);

            lb.AutoSize = true;
            lb.Location = new System.Drawing.Point(267, 164 + i * 46);
            lb.Name = "lbF" + i;
            lb.Size = new System.Drawing.Size(28, 25);
            lb.Text = "F" + (i + 1);
            lb.ForeColor = Colors.GraphColor[i];
        }
    }
}
