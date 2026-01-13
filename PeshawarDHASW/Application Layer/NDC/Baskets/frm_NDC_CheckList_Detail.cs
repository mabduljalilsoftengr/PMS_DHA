using PeshawarDHASW.Data_Layer.clsNDCChecklist;
using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frm_NDC_CheckList_Detail : Telerik.WinControls.UI.RadForm
    {
        public int NDCID { get; set; }// Ready For Verification
        public int ButtonVisibility { get; set; } //Printed And Not-Signed
        public bool AllButtonsVisibilty { get; set; } = true;
        public bool GroupBoxStatus_False { get; set; }
        public frm_NDC_CheckList_Detail()
        {
            InitializeComponent();
        }
        public frm_NDC_CheckList_Detail(int get_NDCNo, bool get_grpStatus, int get_ButtonVisibility,bool get_AllButtonVisibilty)
        {
            NDCID = get_NDCNo;
            GroupBoxStatus_False = get_grpStatus;
            ButtonVisibility = get_ButtonVisibility;
            AllButtonsVisibilty = get_AllButtonVisibilty;
            InitializeComponent();
        }
        public frm_NDC_CheckList_Detail(int get_NDCNo, bool grp_False)
        {
            InitializeComponent();
            NDCID = get_NDCNo;
            if (grp_False == false)
            {
                grdChecklist.ReadOnly = true;
            }
        }

        private void frm_NDC_CheckList_Detail_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            #region Enable Disable the Buttons
            if (AllButtonsVisibilty == false)
            {
                btnBack.Visible = false;
                btnForward.Visible = false;
            }
            else
            { if (ButtonVisibility == 0)
                {
                    btnBack.Visible = true;
                    btnForward.Visible = true;
                }
                else
                {
                    btnBack.Visible = false;
                    btnForward.Visible = false;
                }
               
            }

            
            #endregion
            #region Ready For Verification
            LoadNDCData();
            LoadCheckList();
            #endregion
        }
        #region Ready For Verification
        private void LoadNDCData()
        {
            try
            {
                if (NDCID == 0)
                {
                    //Do Somthing
                }
                else
                {
                    grp_NDC.Enabled = GroupBoxStatus_False;
                    SqlParameter[] prmtr =
                     {
                    new SqlParameter("@Task","NDCSearch"),
                    new SqlParameter("@NDCNo",NDCID),
                    new SqlParameter("@string","")
                };

                    DataSet ds = new DataSet();
                    ds = cls_dl_NDC.NdcRetrival(prmtr);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // ds.Tables[0].Rows[0]["MemberID"].ToString();
                        //txtMembershipNo.Text = ds.Tables[0].Rows[0]["MSNo"].ToString();
                        dtpIssueDate.Text = ds.Tables[0].Rows[0]["DateIssue"].ToString();
                        //ds.Tables[0].Rows[0]["Status"].ToString();
                        txtDHAPChNo.Text = ds.Tables[0].Rows[0]["DHAP_Challan_No"].ToString();
                        txtChalnAmount.Text = ds.Tables[0].Rows[0]["Seller_Amount"].ToString();
                        txtSelerAccNo.Text = ds.Tables[0].Rows[0]["Seller_Account_No"].ToString();
                        //txtSellerName.Text = ds.Tables[0].Rows[0]["Name_Seller"].ToString();
                        //txtSelrFatherName.Text = ds.Tables[0].Rows[0]["Seller_Father_Husband"].ToString();
                        //txtprcsrName.Text = ds.Tables[0].Rows[0]["Purchaser_Name"].ToString();
                        //txtPrcsrFatrName.Text = ds.Tables[0].Rows[0]["Purchaser_Father_Husband"].ToString();
                        txtPurchaserAmount.Text = ds.Tables[0].Rows[0]["Purchaser_Amount"].ToString();
                        txtPrcsrACCNo.Text = ds.Tables[0].Rows[0]["Purchase_Account_No"].ToString();
                        txtDDNo.Text = ds.Tables[0].Rows[0]["DDNoPOReceipt"].ToString();
                        txtBank.Text = ds.Tables[0].Rows[0]["Bank"].ToString();
                        dtpPaymntDate.Text = ds.Tables[0].Rows[0]["Purcsr_Payment_Date"].ToString();
                        txtFileNo.Text = ds.Tables[0].Rows[0]["FilePlotNo"].ToString();
                        txtStreetNo.Text = ds.Tables[0].Rows[0]["Street_LaneNo"].ToString();
                        txtSector.Text = ds.Tables[0].Rows[0]["Sector"].ToString();
                        txtPhase.Text = ds.Tables[0].Rows[0]["Phase"].ToString();
                        txtWHTk.Text = ds.Tables[0].Rows[0]["CPR_No_WHTax_us_236_K"].ToString();
                        txtWHTc.Text = ds.Tables[0].Rows[0]["CPR_No_WHTax_us_236_C"].ToString();
                        txtStampDuty.Text = ds.Tables[0].Rows[0]["StampDuty"].ToString();
                        // ds.Tables[0].Rows[0]["FileKey"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                        // ds.Tables[0].Rows[0]["StatusofNDC"].ToString();
                        dtpNDCExpire.Value = DateTime.ParseExact(ds.Tables[0].Rows[0]["NDCExpireDate"].ToString(), "dd/MM/yyyy", null);
                        grdSellerBuyer.DataSource = ds.Tables[0].DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadNDCData.", ex, "frm_NDC_CheckList_Detail");
                frmobj.ShowDialog();
            }
           
        }
        private void LoadCheckList()
        {
            try
            {
                #region Then Retrieve
                SqlParameter[] pr_m =
                 {
                  new SqlParameter("@Task","select"),
                  new SqlParameter("@NDCNo",NDCID)
                };
                DataSet dst = new DataSet();
                dst = cls_dl_NDCChecklist.NDCCheckListReader(pr_m);
                grdChecklist.DataSource = dst.Tables[0].DefaultView;

                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadCheckList.", ex, "frm_NDC_CheckList_Detail");
                frmobj.ShowDialog();
            }
           
        }
        #endregion
        #region Ready For Verification
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                frmGoBackRemarks frm = new frmGoBackRemarks();
                frm.ShowDialog();
                string rmksGoBack = clsNDC.goBackRemarks; 
                SqlParameter[] prmt =
                {
                new SqlParameter("@Task","Update_NDC_Status"),
                new SqlParameter("@StatusofNDC","Incomplete"),
                new SqlParameter("@NDCNo",NDCID),
                new SqlParameter("@GoBack_Remarks",rmksGoBack)
                };
                int rslt = 0;
                rslt = cls_dl_NDC.NdcNonQuery(prmt);
                if (rslt > 0)
                {
                    MessageBox.Show("Successfull.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBack_Click.", ex, "frm_NDC_CheckList_Detail");
                frmobj.ShowDialog();
            }
           
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prmt =
                          {
                new SqlParameter("@Task","Update_NDC_Status"),
                new SqlParameter("@StatusofNDC","ReadyForPrint"),
                new SqlParameter("@NDCNo",NDCID)
            };
                int rslt = 0;
                rslt = cls_dl_NDC.NdcNonQuery(prmt);
                if (rslt > 0)
                {
                    MessageBox.Show("Successfull.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnForward_Click.", ex, "frm_NDC_CheckList_Detail");
                frmobj.ShowDialog();
            }
           
        }
        #endregion

    }
}
