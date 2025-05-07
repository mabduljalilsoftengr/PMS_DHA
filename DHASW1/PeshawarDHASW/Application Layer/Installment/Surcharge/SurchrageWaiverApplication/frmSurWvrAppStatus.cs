using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge.SurchrageWaiverApplication
{
    public partial class frmSurWvrAppStatus : Telerik.WinControls.UI.RadForm
    {
        public frmSurWvrAppStatus()
        {
            InitializeComponent();
        }
        public string SectorCExt { get; set; }
        public frmSurWvrAppStatus(string SectorCExtFlag)
        {
            InitializeComponent();
            SectorCExt = SectorCExtFlag;
            if (!string.IsNullOrWhiteSpace(SectorCExtFlag))
            {
                rdSectorCExtNotApproved.CheckState = CheckState.Checked;
            }
        }
        private string CheckBoxvalue { get; set; } = "";
        private void btnOk_Click(object sender, EventArgs e)
        {

          
            if (chkApproved.CheckState  == CheckState.Checked)
            {
                CheckBoxvalue = chkApproved.Text;
            }
            if (chknotapproved.CheckState == CheckState.Checked)
            {
                CheckBoxvalue = chknotapproved.Text;
            }
            if (chkSectorABCNotApproved.CheckState == CheckState.Checked)
            {
                CheckBoxvalue = chkSectorABCNotApproved.Text;
            }
            if (chkAfterClearanceofAllDues.CheckState == CheckState.Checked)
            {
                CheckBoxvalue = chkAfterClearanceofAllDues.Text;
            }
            if (chkAlreadyWaivedOff.CheckState == CheckState.Checked)
            {
                CheckBoxvalue = chkAlreadyWaivedOff.Text;
            }
            if (rdSectorCExtNotApproved.CheckState == CheckState.Checked)
            {
                CheckBoxvalue = rdSectorCExtNotApproved.Text;
            }
            if (ckAfterClearnceofAllDueUnBalloted.CheckState == CheckState.Checked)
            {
                CheckBoxvalue = ckAfterClearnceofAllDueUnBalloted.Text;
            }

            if (string.IsNullOrEmpty(CheckBoxvalue.Trim()))
            {
                MessageBox.Show("Please Checked Status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int WaviePer = 0;
            if (chkApproved.CheckState == CheckState.Checked)
            {
                
               if(int.TryParse(txtWaivedoffPer.Text,out WaviePer) ==  false)
                {
                    MessageBox.Show("Mandatory Field is Invalid Wavie Off Percentage");
                    txtWaivedoffPer.Focus();
                    return;
                }
                if (WaviePer ==0)
                {
                    MessageBox.Show("Mandatory Field is Invalid Wavie Off Percentage");
                    txtWaivedoffPer.Focus();
                    return;
                }
            }
            if (string.IsNullOrEmpty(txtRemarks.Text.Trim()))
            {
                MessageBox.Show("Please enter Remarks.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRemarks.Focus();
                return;
            }
            ConfigurationManager.AppSettings["SurWvrApp"] = CheckBoxvalue;
            ConfigurationManager.AppSettings["SurWvrAppRemarks"] = txtRemarks.Text;
            ConfigurationManager.AppSettings["SurWvrAppWaivedoffPer"] = WaviePer.ToString();
            ConfigurationManager.AppSettings["SurWvrAppPrint"]   = chkAgreementforPrint.CheckState == CheckState.Checked?"Pending":"Hold";

            //if (chkApproved.Checked)
            //{
            //    CheckBoxvalue = chkApproved.Text;
            //    ConfigurationManager.AppSettings["SurWvrApp"] = chkApproved.Text;
            //    ConfigurationManager.AppSettings["SurWvrAppRemarks"] = txtRemarks.Text;
            //}
            //if (chknotapproved.Checked)
            //{
            //    CheckBoxvalue = chknotapproved.Text;
            //    ConfigurationManager.AppSettings["SurWvrApp"] = chknotapproved.Text;
            //    ConfigurationManager.AppSettings["SurWvrAppRemarks"] = txtRemarks.Text;
            //}
            this.Close();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void frmSurWvrAppStatus_Load(object sender, EventArgs e)
        {

        }
    }
}
