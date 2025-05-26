using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class frmReviewForFinalApproval : Telerik.WinControls.UI.RadForm
    {
        public frmReviewForFinalApproval()
        {
            InitializeComponent();
        }
        public frmReviewForFinalApproval(int ApplicationID, string appstatus)
        {
            InitializeComponent();
            Application_ID = ApplicationID;
            ApplictnSts = appstatus;
        }
        private string txtSMSType { get; set; }
        private string txtMessage { get; set; }
        private string Successsmssendingstatus { get; set; } = "";
        private string Failedsmssendingstatus { get; set; } = "";
        private string mbNo { get; set; }
        public int Application_ID { get; set; }
        private DataSet ds { get; set; }
        private DataSet dsrpt { get; set; }
        private string ApplictnSts { get; set; }

        private void frmReviewForFinalApproval_Load(object sender, EventArgs e)
        {
            try
            {
                string storproc = "";
                storproc = "Launching.p_Gettbl_ApplicationInfo_FinalApproval";
               


                SqlParameter[] param = { new SqlParameter("@ApplicationID", Application_ID) };
                ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, storproc, param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //foreach (DataRow item in ds.Tables[0].Rows[0])
                        //{
                        //Application Info
                        lblFormNo.Text = ds.Tables[0].Rows[0]["FormNo"].ToString();
                        ApplicationCategory.Text = ds.Tables[0].Rows[0]["Catergory"].ToString();

                        PlotSize.SelectedIndex = PlotSize.FindString(ds.Tables[0].Rows[0]["PlotSize"].ToString());
                        BankName.SelectedIndex = BankName.FindString(ds.Tables[0].Rows[0]["BankName"].ToString());
                        //PlotSize.Text = ds.Tables[0].Rows[0]["PlotSize"].ToString();
                        ApplicantName.Text = ds.Tables[0].Rows[0]["ApplicantName"].ToString();
                        ApplicantGender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                        ApplicantFather.Text = ds.Tables[0].Rows[0]["FatherSODOWO"].ToString();
                        ApplicantCNIC.Text = ds.Tables[0].Rows[0]["CNIC_NICOP"].ToString();
                        ApplicantPassport.Text = ds.Tables[0].Rows[0]["PassportNo"].ToString();
                        ApplicantDOB.DateTimePickerElement.Value = DateTime.Parse(ds.Tables[0].Rows[0]["DoB"].ToString());
                        txtPANo.Text = ds.Tables[0].Rows[0]["PANo"].ToString();
                        txtRank.Text = ds.Tables[0].Rows[0]["ArmRank"].ToString();
                        dtpdateofretd.DateTimePickerElement.Value = !string.IsNullOrWhiteSpace(ds.Tables[0].Rows[0]["DateRetd"].ToString()) ? DateTime.Parse(ds.Tables[0].Rows[0]["DateRetd"].ToString()) : DateTime.Now;
                        ApplicantPresentAddress.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
                        //ApplicantPermanentAddress.Text = ds.Tables[0].Rows[0]["PermanentAddress"].ToString();
                        //ApplicantCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                        cbProvince.Text = ds.Tables[0].Rows[0]["Province"].ToString();
                        ApplicantDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                        ApplicantCountry.Text = ds.Tables[0].Rows[0]["Country"].ToString();
                        ApplicantEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                        ApplicantMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        // Bank Slip Info
                        DepositSlipNo.Text = ds.Tables[0].Rows[0]["DepositSlipNo"].ToString();
                        BankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                        Branch.Text = ds.Tables[0].Rows[0]["BranchCode"].ToString();
                        DepositAmount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                        //ApplicantConnectionType.Text = ds.Tables[0].Rows[0]["ConnectionType"].ToString();
                        // Nok info
                        NOKApplicantName.Text = ds.Tables[0].Rows[0]["NOKName"].ToString();
                        NOKApplicantFather.Text = ds.Tables[0].Rows[0]["NOKSODOWO"].ToString();
                        NOKCNIC.Text = ds.Tables[0].Rows[0]["CNICorNICOP"].ToString();
                        NOKMobileNo.Text = ds.Tables[0].Rows[0]["NOKMobile"].ToString();
                        //NOKDoB.DateTimePickerElement.Value = DateTime.Parse(item["NOKDob"].ToString());
                        txtFormHistory.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Form"].ToString()))
                        { ckform.CheckState = CheckState.Checked; }
                        else { ckform.CheckState = CheckState.Unchecked; }
                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["CNICCopy"].ToString()))
                        { chkCNIC.CheckState = CheckState.Checked; }
                        else { chkCNIC.CheckState = CheckState.Unchecked; }
                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["PassportCopy"].ToString())) { chkPassport.CheckState = CheckState.Checked; }
                        else { chkPassport.CheckState = CheckState.Unchecked; }
                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["NicopCopy"].ToString())) { chkNICOP.CheckState = CheckState.Checked; }
                        else { chkNICOP.CheckState = CheckState.Unchecked; }
                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["DischargeBookOrRetirementOrder"].ToString())) { chkDischargeorRetirement.CheckState = CheckState.Checked; }
                        else { chkDischargeorRetirement.CheckState = CheckState.Unchecked; }
                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["EligibilityCertificateForCat2Army"].ToString())) { chkEligibilityCriteria.CheckState = CheckState.Checked; }
                        else { chkEligibilityCriteria.CheckState = CheckState.Unchecked; }
                        //ckform.Enabled = false; chkCNIC.Enabled = false; chkPassport.Enabled = false;
                        //chkNICOP.Enabled = false; chkDischargeorRetirement.Enabled = false; chkEligibilityCriteria.Enabled = false;
                        //if (Convert.ToBoolean(item["CategoryForArmyOffcr"].ToString())) { chkEligibilityCriteria.CheckState = CheckState.Checked; }
                        //else { chkEligibilityCriteria.CheckState = CheckState.Unchecked; }

                        if (ds.Tables[0].Rows[0]["Catergory"].ToString() == "Retired Army Officers 10%")
                        {
                            grpEligibilityCriteria.Enabled = true;

                            if (ds.Tables[0].Rows[0]["CategoryForArmyOffcr"].ToString() == "Category 1")
                            {
                                rdbCate1.CheckState = CheckState.Checked;
                            }
                            else if (ds.Tables[0].Rows[0]["CategoryForArmyOffcr"].ToString() == "Category 2")
                            {
                                rdbCate2.CheckState = CheckState.Checked;
                            }
                        }
                        else
                        {
                            grpEligibilityCriteria.Enabled = false;
                        }

                        lblTRXID.Text = ds.Tables[1].Rows[0]["BankTRXID"].ToString();
                        lbldepositslipno.Text = ds.Tables[1].Rows[0]["DepositSlipNo"].ToString();
                        lblplotsize.Text = ds.Tables[1].Rows[0]["PlotSize"].ToString();
                        lblbankname.Text = ds.Tables[1].Rows[0]["BankName"].ToString();
                        lblbranchcode.Text = ds.Tables[1].Rows[0]["BranchCode"].ToString();
                        lblcategory.Text = ds.Tables[1].Rows[0]["Category"].ToString();
                        lblappname.Text = ds.Tables[1].Rows[0]["ApplicantName"].ToString();
                        lblcnicnicop.Text = ds.Tables[1].Rows[0]["CNIC_NICOP"].ToString();
                        lblmobileno.Text = ds.Tables[1].Rows[0]["MobileNo"].ToString();
                        lblamount.Text = ds.Tables[1].Rows[0]["Amount"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //string cnic1 = (Regex.Replace(lblcnicnicop.Text, "[@,-]", string.Empty));
                //string cnic2 = (Regex.Replace(ApplicantCNIC.Text, "[@,-]", string.Empty));
                //if (cnic1 == cnic2)
                //{
                //    MessageBox.Show("Test1");
                //}
                //if (Regex.Replace(lblplotsize.Text.ToLower(), @"\s+", string.Empty) == Regex.Replace(PlotSize.Text.ToLower(), @"\s+", string.Empty))
                //{
                //    MessageBox.Show("Test2");
                //}


                //if (Regex.Replace(lblamount.Text, "[@,-]", string.Empty) == Regex.Replace(DepositAmount.Text, "[@,-]", string.Empty))
                //{
                //    MessageBox.Show("Test3");
                //}

                // Regex.Replace(ApplicantCNIC.Text, "[@,-]", string.Empty) 
                if ( (Regex.Replace(lblcnicnicop.Text, "[@,-]", string.Empty)) == (Regex.Replace(ApplicantCNIC.Text, "[@,-]", string.Empty)) 
                    && Regex.Replace(lblplotsize.Text.ToLower(), @"\s+", string.Empty) == Regex.Replace(PlotSize.Text.ToLower(), @"\s+", string.Empty) 
                    && lblamount.Text == DepositAmount.Text)
              {
                if (MessageBox.Show("Are You Sure , That Report is Printed and All the Application Data , Its Payment Record is Correct," +
                                "And Wants that go to Ballot ?", "Are You Sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    ConfigurationManager.AppSettings["ApplicationFinalScrutiny"] = "Valid";
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Confirm that CNIC,PlotSize and Amount are matched.");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ApplicationCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ApplicationCategory.SelectedItem.ToString() == "General Public 85%")
            {
                grpEligibilityCriteria.Enabled = false;
                rdbCate1.CheckState = CheckState.Unchecked;
                rdbCate2.CheckState = CheckState.Unchecked;

                ckform.Enabled = true;
                chkCNIC.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
                chkEligibilityCriteria.Enabled = false;
                chkPassport.Enabled = false;
                chkNICOP.Enabled = false;

            }
            else if (ApplicationCategory.SelectedItem.ToString() == "Retired Army Officers 10%")
            {
                ckform.Enabled = true;
                chkCNIC.Enabled = true;
                chkDischargeorRetirement.Enabled = true;
                chkPassport.Enabled = false;
                chkNICOP.Enabled = false;
                chkEligibilityCriteria.Enabled = true;
                grpEligibilityCriteria.Enabled = true;
                rdbCate1.CheckState = CheckState.Checked;
            }
            else if (ApplicationCategory.SelectedItem.ToString() == "Overseas Pakistanis 5%")
            {
                ckform.Enabled = true;
                chkCNIC.Enabled = true;
                chkPassport.Enabled = true;
                chkNICOP.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
                chkEligibilityCriteria.Enabled = false;
                grpEligibilityCriteria.Enabled = false;

                rdbCate1.CheckState = CheckState.Unchecked;
                rdbCate2.CheckState = CheckState.Unchecked;
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@ApplicationID", Application_ID) };
                dsrpt = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure,
                                                "Launching.p_Gettbl_ApplicationInfo_FinalApproval", param);

                frmApplicantForm_Report frm = new frmApplicantForm_Report(dsrpt);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
