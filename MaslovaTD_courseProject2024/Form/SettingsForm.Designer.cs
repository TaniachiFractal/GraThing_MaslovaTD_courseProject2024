namespace GraThing_by_TaniachiFractal
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btDraw = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GraphCountNUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.coordSys_panel = new System.Windows.Forms.Panel();
            this.rbPolarFromPhi = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbParam = new System.Windows.Forms.RadioButton();
            this.rbPolarFromR = new System.Windows.Forms.RadioButton();
            this.rbCartesian = new System.Windows.Forms.RadioButton();
            this.tbTmin = new System.Windows.Forms.TextBox();
            this.tbTmax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.paramMaxMin_panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphCountNUD)).BeginInit();
            this.coordSys_panel.SuspendLayout();
            this.paramMaxMin_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(82, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "GraThing \r\n\r\n";
            // 
            // btDraw
            // 
            this.btDraw.BackColor = System.Drawing.Color.DimGray;
            this.btDraw.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btDraw.Location = new System.Drawing.Point(306, 145);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(137, 57);
            this.btDraw.TabIndex = 7;
            this.btDraw.Text = "Построить графики";
            this.btDraw.UseVisualStyleBackColor = false;
            this.btDraw.Click += new System.EventHandler(this.BtDraw_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(83, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Графический калькулятор";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GraThing_by_TaniachiFractal.Properties.Resources.GraThing;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // GraphCountNUD
            // 
            this.GraphCountNUD.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GraphCountNUD.Location = new System.Drawing.Point(12, 97);
            this.GraphCountNUD.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.GraphCountNUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GraphCountNUD.Name = "GraphCountNUD";
            this.GraphCountNUD.ReadOnly = true;
            this.GraphCountNUD.Size = new System.Drawing.Size(64, 40);
            this.GraphCountNUD.TabIndex = 10;
            this.GraphCountNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GraphCountNUD.ValueChanged += new System.EventHandler(this.GraphCountNUD_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Количество графиков";
            // 
            // coordSys_panel
            // 
            this.coordSys_panel.Controls.Add(this.rbPolarFromPhi);
            this.coordSys_panel.Controls.Add(this.label4);
            this.coordSys_panel.Controls.Add(this.rbParam);
            this.coordSys_panel.Controls.Add(this.rbPolarFromR);
            this.coordSys_panel.Controls.Add(this.rbCartesian);
            this.coordSys_panel.Location = new System.Drawing.Point(284, 9);
            this.coordSys_panel.Name = "coordSys_panel";
            this.coordSys_panel.Size = new System.Drawing.Size(172, 128);
            this.coordSys_panel.TabIndex = 12;
            // 
            // rbPolarFromPhi
            // 
            this.rbPolarFromPhi.AutoSize = true;
            this.rbPolarFromPhi.Location = new System.Drawing.Point(7, 70);
            this.rbPolarFromPhi.Name = "rbPolarFromPhi";
            this.rbPolarFromPhi.Size = new System.Drawing.Size(152, 29);
            this.rbPolarFromPhi.TabIndex = 14;
            this.rbPolarFromPhi.Text = "Полярная от φ";
            this.rbPolarFromPhi.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "C-ма координат";
            // 
            // rbParam
            // 
            this.rbParam.AutoSize = true;
            this.rbParam.Location = new System.Drawing.Point(7, 95);
            this.rbParam.Name = "rbParam";
            this.rbParam.Size = new System.Drawing.Size(146, 29);
            this.rbParam.TabIndex = 2;
            this.rbParam.Text = "Парам. Ф-ции";
            this.rbParam.UseVisualStyleBackColor = true;
            this.rbParam.CheckedChanged += new System.EventHandler(this.RbParam_CheckedChanged);
            // 
            // rbPolarFromR
            // 
            this.rbPolarFromR.AutoSize = true;
            this.rbPolarFromR.Location = new System.Drawing.Point(7, 45);
            this.rbPolarFromR.Name = "rbPolarFromR";
            this.rbPolarFromR.Size = new System.Drawing.Size(147, 29);
            this.rbPolarFromR.TabIndex = 1;
            this.rbPolarFromR.Text = "Полярная от r";
            this.rbPolarFromR.UseVisualStyleBackColor = true;
            // 
            // rbCartesian
            // 
            this.rbCartesian.AutoSize = true;
            this.rbCartesian.Checked = true;
            this.rbCartesian.Location = new System.Drawing.Point(7, 21);
            this.rbCartesian.Name = "rbCartesian";
            this.rbCartesian.Size = new System.Drawing.Size(158, 29);
            this.rbCartesian.TabIndex = 0;
            this.rbCartesian.TabStop = true;
            this.rbCartesian.Text = "Прямоугольная";
            this.rbCartesian.UseVisualStyleBackColor = true;
            // 
            // tbTmin
            // 
            this.tbTmin.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTmin.Location = new System.Drawing.Point(3, 3);
            this.tbTmin.Name = "tbTmin";
            this.tbTmin.Size = new System.Drawing.Size(48, 27);
            this.tbTmin.TabIndex = 13;
            this.tbTmin.Text = "-10";
            this.tbTmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TMaxTMin_tb_KeyPress);
            // 
            // tbTmax
            // 
            this.tbTmax.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTmax.Location = new System.Drawing.Point(3, 33);
            this.tbTmax.Name = "tbTmax";
            this.tbTmax.Size = new System.Drawing.Size(48, 27);
            this.tbTmax.TabIndex = 14;
            this.tbTmax.Text = "10";
            this.tbTmax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TMaxTMin_tb_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(51, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "T max";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(51, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "T min";
            // 
            // paramMaxMin_panel
            // 
            this.paramMaxMin_panel.Controls.Add(this.tbTmax);
            this.paramMaxMin_panel.Controls.Add(this.label6);
            this.paramMaxMin_panel.Controls.Add(this.label3);
            this.paramMaxMin_panel.Controls.Add(this.tbTmin);
            this.paramMaxMin_panel.Location = new System.Drawing.Point(455, 48);
            this.paramMaxMin_panel.Name = "paramMaxMin_panel";
            this.paramMaxMin_panel.Size = new System.Drawing.Size(136, 63);
            this.paramMaxMin_panel.TabIndex = 17;
            this.paramMaxMin_panel.Visible = false;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(553, 238);
            this.Controls.Add(this.paramMaxMin_panel);
            this.Controls.Add(this.coordSys_panel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GraphCountNUD);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btDraw);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "GraThing - настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphCountNUD)).EndInit();
            this.coordSys_panel.ResumeLayout(false);
            this.coordSys_panel.PerformLayout();
            this.paramMaxMin_panel.ResumeLayout(false);
            this.paramMaxMin_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDraw;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown GraphCountNUD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel coordSys_panel;
        private System.Windows.Forms.RadioButton rbParam;
        private System.Windows.Forms.RadioButton rbPolarFromR;
        private System.Windows.Forms.RadioButton rbCartesian;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTmin;
        private System.Windows.Forms.TextBox tbTmax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel paramMaxMin_panel;
        private System.Windows.Forms.RadioButton rbPolarFromPhi;
    }
}