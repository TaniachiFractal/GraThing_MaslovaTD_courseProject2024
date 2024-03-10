using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GraThing_by_TaniachiFractal
{
    public partial class SettingsForm : Form
    {
        #region data

        /// <summary>
        /// The main graph form
        /// </summary>
        GraphForm graphForm;

        /// <summary>
        /// Text boxes for function input
        /// </summary>
        List<LabeledTextBox> functionTB = new List<LabeledTextBox>();

        #endregion

        #region form events

        /// <summary>
        /// Form constructor
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Update the graph form based on input data
        /// </summary>
        private void BtDraw_Click(object sender, EventArgs e)
        {
            graphForm.Show();
            UpdateGraphCount();
            Update_tMaxMin();
            UpdateCoordSysId();
            graphForm.DrawAll();
        }

        /// <summary>
        /// Load the settings form
        /// </summary>
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            InitVars();
            DrawFunctionTextBox(graphForm.GraphCount - 1);
            btDraw.Left = this.Width - btDraw.Width - 30;
        }

        /// <summary>
        /// Change the currTbCou of textboxes and graph count on the graph form
        /// </summary>
        private void GraphCountNUD_ValueChanged(object sender, EventArgs e)
        {
            int oldGraphCount = graphForm.GraphCount;
            UpdateGraphCount();
            Update_tMaxMin();
            if (oldGraphCount > graphForm.GraphCount)
            {
                RemoveFunctionTextBox(oldGraphCount);
            }
            else if (oldGraphCount < graphForm.GraphCount)
            {
                DrawFunctionTextBox(graphForm.GraphCount - 1);
            }
            UpdateWindowDimens(graphForm.GraphCount);
        }

        /// <summary>
        /// Change visibility of tMax and tMin textboxes
        /// </summary>
        private void RbParam_CheckedChanged(object sender, EventArgs e)
        {
            paramMaxMin_panel.Visible = rbParam.Checked;
            if (rbParam.Checked)
            {
                this.Width = paramMaxMin_panel.Right + 10;
            }
            else
            {
                this.Width = coordSys_panel.Right + 30;
            }
            btDraw.Left = this.Width - btDraw.Width-30;
        }

        /// <summary>
        /// Check input of tmax and tmin input
        /// </summary>
        private void TMaxTMin_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) ||
                char.IsControl(e.KeyChar) ||
                e.KeyChar == ',' || e.KeyChar == '-') return;
            e.Handled = true;
        }

        #endregion

        #region init

        /// <summary>
        /// Update the coordinate system id based on radiobuttons
        /// </summary>
        private void UpdateCoordSysId()
        {
            if (rbCartesian.Checked) graphForm.CoordSys_Id = Cnst.CARTESIAN_ID;
            else if (rbPolarFromR.Checked) graphForm.CoordSys_Id = Cnst.POLARfromR_ID;
            else if (rbPolarFromPhi.Checked) graphForm.CoordSys_Id = Cnst.POLARfromPHI_ID;
            else if (rbParam.Checked) graphForm.CoordSys_Id = Cnst.PARAM_ID;
        }

        /// <summary>
        /// Update graph count in the second form
        /// </summary>
        private void UpdateGraphCount()
        {
            graphForm.GraphCount = (int)GraphCountNUD.Value;
        }

        /// <summary>
        /// Update tmax and tmin in the second form
        /// </summary>
        private void Update_tMaxMin()
        {
            if (tbTmin.Text == string.Empty) graphForm.tMin = 0;
            else graphForm.tMin = double.Parse(tbTmin.Text);

            if (tbTmax.Text == string.Empty) graphForm.tMax = 0;
            else graphForm.tMax = double.Parse(tbTmax.Text);
        }

        /// <summary>
        /// Initialize variables
        /// </summary>
        private void InitVars()
        {
            graphForm = new GraphForm();
            this.Width = coordSys_panel.Right + 30;
            InitFunctionTextBoxList();
            UpdateGraphCount();
            UpdateWindowDimens(graphForm.GraphCount);
        }

        /// <summary>
        /// Init the list of tb
        /// </summary>
        private void InitFunctionTextBoxList()
        {
            for (int i = 0; i < Cnst.MaxGraphCount; i++)
            {
                functionTB.Add(new LabeledTextBox(i));
            }
        }

        #endregion

        #region render

        /// <summary>
        /// Add 1 text box to the controls
        /// </summary>
        private void DrawFunctionTextBox(int currTbCou)
        {
            this.Controls.Add(functionTB[currTbCou].tb);
            this.Controls.Add(functionTB[currTbCou].lb);
        }
        /// <summary>
        /// Remove 1 text box from the controls
        /// </summary>
        private void RemoveFunctionTextBox(int currTbCou)
        {
            this.Controls.Remove(functionTB[currTbCou - 1].tb);
            this.Controls.Remove(functionTB[currTbCou - 1].lb);
        }
        /// <summary>
        /// Change window dimens based on elements
        /// </summary>
        private void UpdateWindowDimens(int currTbCou)
        {
            this.Height = functionTB[currTbCou-1].tb.Bottom + 55;
            btDraw.Top = functionTB[currTbCou-1].tb.Bottom - btDraw.Height;
        }


        #endregion  
    }
}
