using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    public partial class frm_NewAckEntry : Telerik.WinControls.UI.RadForm
    {
        public frm_NewAckEntry()
        {
            InitializeComponent();
        }
        public int AckLockID { get; set; } = 0;
        public string PreciousRemarks { get; set; }
        public frm_NewAckEntry(int AckID)
        {
            AckLockID = AckID;
            InitializeComponent();
            gpSearchGroup.Enabled = false;
            loadLockData(AckID);
        }

        private void loadLockData(int AckLock_ID)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@Task","SingleRecordRetrive"),
                new SqlParameter("AckLockID",AckLock_ID),
                 };
                DataSet ds = new DataSet();
                ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_AcknowledgmentSetting", param);
                if (ds.Tables.Count > 0)
                {
                    txtFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                    txtPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                    txtMembershipNo.Text = ds.Tables[0].Rows[0]["MembershipNo"].ToString();
                    txtMemberName.Text = ds.Tables[0].Rows[0]["MemberName"].ToString();
                    txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    CHKMobileSMSLock.Checked = ds.Tables[0].Rows[0]["MobileSMSLock"].ToString() == "True" ? true : false;
                    txtEmail.Text = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    chkEmailLock.Checked = ds.Tables[0].Rows[0]["EmailAddressLock"].ToString() == "True" ? true : false;
                    txtPostLetter.Text = ds.Tables[0].Rows[0]["PostLetter"].ToString();
                    txtPostLetterLock.Checked = ds.Tables[0].Rows[0]["PostLetterLock"].ToString() == "True" ? true : false;
                    PreciousRemarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FileNo is Invalid or File No is not Exist. for Detail Contact to TFR Branch - - " + ex.Message); throw;
            }
        }

        private void btnFindFileNo_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@Task","FileChecking"),
                new SqlParameter("@FileNo",txtFileSearch.Text)
            };
                DataSet ds = new DataSet();
                ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_AcknowledgmentSetting", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        txtFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                        txtPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                        txtMembershipNo.Text = ds.Tables[0].Rows[0]["MembershipNo"].ToString();
                        txtMemberName.Text = ds.Tables[0].Rows[0]["MemberName"].ToString();
                        txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();

                        txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                        txtPostLetter.Text = ds.Tables[0].Rows[0]["PresentAddress"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("FileNo is Already Exist Please Modify the record. System can allow duplicate Entry.");
                    }
                }
                else
                {
                    MessageBox.Show("FileNo is Already Exist Please Modify the record. System can allow duplicate Entry.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FileNo is Invalid or File No is not Exist. for Detail Contact to TFR Branch - - " + ex.Message);
            }

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (! string.IsNullOrEmpty(txtFileNo.Text) )
                {
                    if (!string.IsNullOrEmpty(txtRemarks.Text))
                    {

                  
                    SqlParameter[] param = {
                    new SqlParameter("@Task","NewLockSetting"),
                    new SqlParameter("@AckLockID",AckLockID),
                    new SqlParameter("@FileNo",txtFileNo.Text),
                    new SqlParameter("@MembershipNo",txtMembershipNo.Text),
                    new SqlParameter("@MemberName",txtMemberName.Text),
                    new SqlParameter("@MobileNo",txtMobileNo.Text),
                    new SqlParameter("@MobileSMSLock",CHKMobileSMSLock.CheckState == CheckState.Checked?true:false),
                    new SqlParameter("@EmailAddress",txtEmail.Text),
                    new SqlParameter("@EmailAddressLock",chkEmailLock.CheckState == CheckState.Checked?true:false),
                    new SqlParameter("@PostLetter",txtPostLetter.Text),
                    new SqlParameter("@PostLetterLock",txtPostLetterLock.CheckState == CheckState.Checked? true: false),
                    new SqlParameter("@UserID",Models.clsUser.ID),
                    new SqlParameter("@Remarks",PreciousRemarks+" Remarks: ("+DateTime.Now.ToString("dd-MMM-yyyy")+")-:-"+txtRemarks.Text),
                    };
                     Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_AcknowledgmentSetting", param);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please Enter a valid Remarks are Required.");
                        txtRemarks.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter a valid FileNo in Search which Fill all Field are Required.");
                    txtFileSearch.Focus();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("All Field are Mendatory.  " + ex.Message);
            }
        }

        private void frm_NewAckEntry_Load(object sender, EventArgs e)
        {

        }
    }
}
