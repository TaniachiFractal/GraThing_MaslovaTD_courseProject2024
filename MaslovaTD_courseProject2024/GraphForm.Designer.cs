namespace GraThing_by_TaniachiFractal
{
    partial class GraphForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphForm));
            this.SuspendLayout();
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(612, 604);
            this.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MinimumSize = new System.Drawing.Size(292, 377);
            this.Name = "GraphForm";
            this.Text = "GraThing - график функции";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphForm_FormClosing);
            this.Load += new System.EventHandler(this.GraphForm_Load);
            this.ResizeEnd += new System.EventHandler(this.GraphForm_ResizeEnd);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GraphForm_MouseClick);
            this.Resize += new System.EventHandler(this.GraphForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}