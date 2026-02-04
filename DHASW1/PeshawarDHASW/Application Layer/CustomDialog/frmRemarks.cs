using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.CustomDialog
{
    public partial class frmRemarks : Telerik.WinControls.UI.RadForm
    {
        public string RemarksText { get; set; }
        public frmRemarks()
        {
            InitializeComponent();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMessage.Text))
            {
                MessageBox.Show("Please enter remarks.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.RemarksText = txtMessage.Text.Trim();
            this.Close();
        }

        private void frmRemarks_Load(object sender, EventArgs e)
        {
            txtMessage.Focus();
        }
    }
}
