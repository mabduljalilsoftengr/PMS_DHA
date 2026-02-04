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
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmPrintNotSigned_NDCCheckListDetail : Telerik.WinControls.UI.RadForm
    {
        public int NDCID { get; set; }// Ready For Verification
        public bool AllButtonsVisibilty { get; set; } 
        public bool GroupBoxStatus_False { get; set; }
        
        public frmPrintNotSigned_NDCCheckListDetail()     
        {
            InitializeComponent();
        }
        public frmPrintNotSigned_NDCCheckListDetail(int get_NDCNo, bool get_grpStatus, bool get_AllButtonVisibilty)
        {
            InitializeComponent();
            NDCID = get_NDCNo;
            GroupBoxStatus_False = get_grpStatus;
            AllButtonsVisibilty = get_AllButtonVisibilty;
            #region Button Visibility
            if (AllButtonsVisibilty == true)
            {
                btn_Back.Enabled = true;
                btn_Forward.Enabled = true;
            }
            else
            {
                //btn_Back.Enabled = false;
                //btn_Forward.Enabled = false;
            }
            #endregion
            if (GroupBoxStatus_False == false)
            {
                grp_NDC.Enabled = false;
                this.grdChecklist.ReadOnly = true;
            }


        }

        private void btn_Forward_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure ?","Attention !",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlParameter[] prmt =
                    {
                    new SqlParameter("@Task","Update_NDC_Status_VerificatioDate"),
                    new SqlParameter("@StatusofNDC","Verified"),
                    new SqlParameter("@NDCNo",NDCID),
                    new SqlParameter("@userID",Models.clsUser.ID)
                    };
                    int rslt = 0;
                    rslt = cls_dl_NDC.NdcNonQuery(prmt);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Successfull.");
                        this.Close();
                    }
                }
                
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btn_Forward_Click.", ex, "frmPrintNotSigned_NDCCheckListDetail");
                frmobj.ShowDialog();
            }
           
        }


        private void btn_Back_Click(object sender, EventArgs e)
        {
            try
            {
                frmGoBackRemarks frm = new frmGoBackRemarks();
                frm.ShowDialog();

                string rmksGoBack = clsNDC.goBackRemarks;
                if (!string.IsNullOrEmpty(rmksGoBack))
                {
                     SqlParameter[] prmt =
                     {
                     new SqlParameter("@Task","Update_NDC_Status"),
                     new SqlParameter("@StatusofNDC","ReadyForPrint"),
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
                else { MessageBox.Show("Please Enter back remarks.");}
             

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btn_Back_Click.", ex, "frmPrintNotSigned_NDCCheckListDetail");
                frmobj.ShowDialog();
            }
           
        }

        private void frmPrintNotSigned_NDCCheckListDetail_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            #region Ready For Verification
            LoadNDCData();
            LoadCheckList();
            #endregion
        }
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

                    SqlParameter[] prmtr =
                    {
                    new SqlParameter("@Task","GetNDCDataForVerification"),
                    new SqlParameter("@NDCNo",NDCID)
                    };

                    DataSet ds = new DataSet();
                    ds = cls_dl_NDC.NdcRetrival(prmtr);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //ds.Tables[0].Rows[0]["MemberID"].ToString();
                        //txtMembershipNo.Text = ds.Tables[0].Rows[0]["MSNo"].ToString();
                        dtpIssueDate.Text = ds.Tables[0].Rows[0]["DateIssue"].ToString();
                        //ds.Tables[0].Rows[0]["Status"].ToString();
                        txtDHAPChNo.Text = ds.Tables[0].Rows[0]["DHAP_Challan_No"].ToString();
                        #region challan amount
                        string challanamount = ds.Tables[0].Rows[0]["Seller_Amount"].ToString();
                        decimal clnamnt;
                        decimal.TryParse(challanamount, out clnamnt);
                        txtChalnAmount.Text = "Rs."+clnamnt.ToString("0.##");
                        #endregion
                        txtSelerAccNo.Text = ds.Tables[0].Rows[0]["Seller_Account_No"].ToString();
                        //txtSellerName.Text = ds.Tables[0].Rows[0]["Name_Seller"].ToString();
                        //txtSelrFatherName.Text = ds.Tables[0].Rows[0]["Seller_Father_Husband"].ToString();
                        //txtprcsrName.Text = ds.Tables[0].Rows[0]["Purchaser_Name"].ToString();
                        //txtPrcsrFatrName.Text = ds.Tables[0].Rows[0]["Purchaser_Father_Husband"].ToString();
                        #region purchaser amount
                        string pramnt =  ds.Tables[0].Rows[0]["Purchaser_Amount"].ToString();
                        decimal pamnt;
                        decimal.TryParse(pramnt, out pamnt);
                        txtPurchaserAmount.Text = "Rs." + pamnt.ToString("0.##");
                        #endregion
                        txtPrcsrACCNo.Text = ds.Tables[0].Rows[0]["Purchase_Account_No"].ToString();
                        txtDDNo.Text = ds.Tables[0].Rows[0]["DDNoPOReceipt"].ToString();
                        txtBank.Text = ds.Tables[0].Rows[0]["Bank"].ToString();
                        dtpPaymntDate.Text = ds.Tables[0].Rows[0]["Purcsr_Payment_Date"].ToString();
                        txtFileNo.Text = ds.Tables[0].Rows[0]["FilePlotNo"].ToString();
                        txtStreetNo.Text = ds.Tables[0].Rows[0]["Street_LaneNo"].ToString();
                        txtPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                        txtPhase.Text = ds.Tables[0].Rows[0]["Phase"].ToString();
                        //txtWHTk.Text = ds.Tables[0].Rows[0]["CPR_No_WHTax_us_236_K"].ToString();
                        //txtWHTc.Text = ds.Tables[0].Rows[0]["CPR_No_WHTax_us_236_C"].ToString();
                        #region stamp duty format
                        string stampduty = ds.Tables[0].Rows[0]["StampDuty"].ToString();
                        decimal stmamnt;
                        decimal.TryParse(stampduty, out stmamnt);
                        txtStampDuty.Text = "Rs."+stmamnt.ToString("0.##");
                        #endregion
                        // ds.Tables[0].Rows[0]["FileKey"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                        // ds.Tables[0].Rows[0]["StatusofNDC"].ToString();
                        dtpNDCExpire.Text = ds.Tables[0].Rows[0]["NDCExpireDate"].ToString();
                        grdSellerBuyer.DataSource = ds.Tables[0].DefaultView;
                        grdFBRSellerBuyerData.DataSource = ds.Tables[1].DefaultView;
                        try
                        {
                            if (grdFBRSellerBuyerData.RowCount > 0)
                            {
                                foreach (var item in grdFBRSellerBuyerData.Rows)
                                {
                                    Match m = Regex.Match(item.Cells["CPRNo"].Value.ToString(), @"IT-[0-9]{8}-[0-9]{4}-[0-9]{0,9}");
                                    if (item.Cells["CPRNo"].Value.ToString() == "NA")
                                    {
                                        btn_Forward.Enabled = true;
                                    }
                                    else if (m.Success)
                                    {
                                        btn_Forward.Enabled = true;
                                    }
                                    else
                                    {
                                        btn_Forward.Enabled = false;
                                        break;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadNDCData.", ex, "frmPrintNotSigned_NDCCheckListDetail");
                frmobj.ShowDialog();
            }
            
        }
        private void LoadCheckList()
        {
            try
            {
                #region Then Retrieve
                // grpCheckList.Enabled = GroupBoxStatus_False;
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadCheckList.", ex, "frmPrintNotSigned_NDCCheckListDetail");
                frmobj.ShowDialog();
            }
           
        }

        private void MasterTemplate_CellClick(object sender, GridViewCellEventArgs e)
        {
           
        }
    }
}
