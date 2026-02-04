using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmByBackMainForm : Telerik.WinControls.UI.RadForm
    {
        public frmByBackMainForm()
        {
            InitializeComponent();
        }

        private void btnByBackFileWise_Click(object sender, EventArgs e)
        {
            frmByBackFileWiseEntry frm = new frmByBackFileWiseEntry();
            frm.ShowDialog();
        }

        private void btnRegisterNewLandProvider_Click(object sender, EventArgs e)
        {
            frmRegisterNewLandProvider frm = new frmRegisterNewLandProvider();
            frm.ShowDialog();
        }

        private void btnByBackRawLand_Click(object sender, EventArgs e)
        {
            frmQuotaAddofAll_And_ByBackRawLandWise frm = new frmQuotaAddofAll_And_ByBackRawLandWise();
            frm.ShowDialog();
        }

        private void btnlandproviderquotadetail_Click(object sender, EventArgs e)
        {
            frmLandProviderQuoaDetail frm = new frmLandProviderQuoaDetail();
            frm.ShowDialog();
        }

        private void btnfinalapproval_Click(object sender, EventArgs e)
        {
            frmByBackFinalApproval frm = new frmByBackFinalApproval();
            frm.ShowDialog();
        }

        private void frmByBackMainForm_Load(object sender, EventArgs e)
        {
            if(Models.clsUser.ID != 3)
            {
                btnByBackRawLand.Enabled = false;
                btnRegisterNewLandProvider.Enabled = false;
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmBuyBackReportForm frm = new frmBuyBackReportForm();
            frm.ShowDialog();
        }

        private void btnFileCancel_Click(object sender, EventArgs e)
        {
            frmFileCancellationApply frm = new frmFileCancellationApply();
            frm.ShowDialog();
        }
    }
}
