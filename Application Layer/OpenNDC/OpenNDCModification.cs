using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.NDC.NDC_CheckList;
using System.Globalization;
using PeshawarDHASW.Data_Layer.clsCaution;
using PeshawarDHASW.Data_Layer.clsChallanRece;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Application_Layer.Installment.InstReceive;
using PeshawarDHASW.Application_Layer.NDC.NDC_File_BuyerSellerInfo;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsStampDuty;
using System.Text.RegularExpressions;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Application_Layer.Chalan;
using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Report.Challan;
using PeshawarDHASW.Application_Layer.StampDuty;
using PeshawarDHASW.Application_Layer.NDC.Baskets;
using System.Configuration;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Application_Layer.Installment.Surcharge;
using PeshawarDHASW.Application_Layer.NDC;

namespace PeshawarDHASW.Application_Layer.OpenNDC
{
    public partial class OpenNDCModification : Telerik.WinControls.UI.RadForm
    {
        public OpenNDCModification()
        {
            InitializeComponent();
        }
        #region Global Variables 
        public int FileKeyID { get; set; }
        public int MSID { get; set; }

        //public DateTime dtpPaymntDate_ { get; set; }
        public string dtpPaymntDate_ { get; set; }
        public string txtDDNo_ { get; set; }
        public string txtSellerAmount_ { get; set; }
        public string txtDHAPChNo_ { get; set; }
        public string txtChalnAmount_ { get; set; }
        public string txtBank_ { get; set; }
        public string txtSelerAccNo_ { get; set; }
        public string txtPrcsrACCNo_ { get; set; }
        public int NDCID { get; set; } = 0;
        private int SB_ID { get; set; }
        private string CNCINo { get; set; }
        private string Present_Address { get; set; }
        private int stmdtID { get; set; }
        private int stmdtID_ { get; set; }
        private string urgentNDC_Check { get; set; }
        private string urgentTFR_Check { get; set; }
        private string OutStationCHarges_Check { get; set; }
        private string chkCorporate_Check_ { get; set; } = "No";
        private string urgentNDC_Check_ { get; set; }
        private string ReissueNDC_Check_ { get; set; }
        private string urgentTFR_Check_ { get; set; }
        private string TfrNormalHiba_Check { get; set; }
        private string OutStationCHarges_Check_ { get; set; }
        private string MembershipFormFeeSkipInclude_ { get; set; }
        private decimal CalculatedTaxSeller { get; set; }
        private string CalculatedTaxSellerFBROwnerType { get; set; }
        private string FileOwnerType { get; set; }
        private decimal CalculatedTaxBuyer { get; set; }
        private string CalculatedTaxBuyerFBROwnerType { get; set; }
        private bool buyerCheckFiler { get; set; } = false;
        private bool buyerCheckNonFiler { get; set; } = false;
        private bool sellerrCheckFiler { get; set; } = false;
        private bool sellerrCheckNonFiler { get; set; } = false;
        private bool plotdealerState { get; set; }
        private decimal txtTaxCAmountSeller { get; set; } = 0;
        private decimal txtTaxKAmountBuyer { get; set; } = 0;
        private string CPRString_ { get; set; } = "";
        private int roIndexCPRDetail { get; set; }
        private string reqstdby { get; set; } = "";
        private string FBRCheckAgainstFileNoNdc { get; set; } = "";
        private decimal UniquenmbrforSB { get; set; }
        private int UNF_ChallanID { get; set; }
        private string UNF_ChallanNo { get; set; }
        private int UTF_ChallanID { get; set; }
        private string UTF_ChallanNo { get; set; }
        private int UALF_ChallanID { get; set; }
        private string UALF_ChallanNo { get; set; }
        private string NDCRenewChallanStatus { get; set; }
        private string flsts { get; set; }
        private DataSet dstdst = new DataSet();
        private DataSet dstst = new DataSet();
        private DataSet datset = new DataSet();
        public bool groupdata { get; set; }
        private DataSet dst { get; set; }

        #endregion

        public OpenNDCModification(int NDCNo, bool ChangetoNormal)
        {
            try
            {
                NDCID = NDCNo;
                groupdata = ChangetoNormal;
                InitializeComponent();
                #region GridView Column
                GridViewCommandColumn BuyerSeller = new GridViewCommandColumn();
                BuyerSeller.Name = "BuyerSeller_Mod";
                BuyerSeller.UseDefaultText = true;
                BuyerSeller.FieldName = "BuyerSeller_Mod";
                BuyerSeller.DefaultText = "Modify";
                BuyerSeller.Width = 80;
                BuyerSeller.TextAlignment = ContentAlignment.MiddleCenter;
                BuyerSeller.HeaderText = "Data";
                grdSeller_Buyer.MasterTemplate.Columns.Add(BuyerSeller);
                ///////////////////////////////////////////////////////////////
                GridViewCommandColumn Buyer_Seller = new GridViewCommandColumn();
                Buyer_Seller.Name = "BuyerSeller_Add";
                Buyer_Seller.UseDefaultText = true;
                Buyer_Seller.FieldName = "BuyerSeller_Add";
                Buyer_Seller.DefaultText = "Add New";
                Buyer_Seller.Width = 80;
                Buyer_Seller.TextAlignment = ContentAlignment.MiddleCenter;
                Buyer_Seller.HeaderText = "Buyer";
                grdSeller_Buyer.MasterTemplate.Columns.Add(Buyer_Seller);
                #endregion


                //rgbFileNo.Enabled = false;
                grbSellerInfo.Enabled = false;
                btn_File_Verify.Enabled = false;
                //txtDHAPChNo_.Enabled = false;
                //btn_Vrfy_ChallanNo_.Enabled = false;
                // btnNDCCreate_.Text = "Create NDC";
                //tabControl1.SelectedTab.Text = "Modify NDC";


            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmNDCCreate.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }
        }

        private void OpenNDCModification_Load(object sender, EventArgs e)
        {
            try
            {

                btn_Buyer.Text = "Add" + Environment.NewLine + "New" + Environment.NewLine + "Buyer";
                radButton1.Text = "Check For Sale" + Environment.NewLine + "and Save Data";
                btnapplyfornewNDC.Text = "Apply For New NDC and " + Environment.NewLine + "Delete Old CPR Detail";
                txtPhase_.Text = "Phase-1";
                rdfull.IsChecked = true;
                rdbFBR.CheckState = CheckState.Checked;
                rdbNormal.IsChecked = true;
                grpDiscountSellerBuyer.Enabled = false;
                rdbFBR_CheckStateChanged(sender, e);
                grdFBR.Enabled = true;
                grdChallanPayment.Enabled = true;
                btn_Buyer.Enabled = true;
                InCaseOfUpdate();
                tabControl1.TabPages.Remove(tp_Single_SellerBuyer);
                BindColumnToGrid();
                if (NDCID == 0)
                {
                    if (rdbdealer.CheckState == CheckState.Checked)
                    {
                        BindDealerListWithDropDown();
                    }
                }

                if (NDCID == 0)
                {
                    this.grdSeller_Buyer.Columns.Move(7, 8);
                    //  grpBuyerInfo.Enabled = false;
                    //  grpCheckChallanNo.Enabled = false;
                    // rgbNdcInfo.Enabled = false;


                    dtpIssueDate_.Value = DateTime.Now;
                    dtpNDCExpire_.Value = DateTime.Now.AddDays(60);
                    //btnNDCCreate_.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmNDCCreate_Load.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }
        }

        private void Bind_Stamp_Duty_Ref(string cnic, string filno)
        {

            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select_Stamp_Duty_NotUse"),
                new SqlParameter("@CNIC",cnic),
                new SqlParameter("@FileNo",filno)
            };
            dst = cls_dl_StampDuty.StampDuty_Reader(prm);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    drpStmpRefNo_.Text = dst.Tables[0].Rows[0]["RefNo"].ToString();
                    txtStampDuty_.Text = dst.Tables[0].Rows[0]["Amount"].ToString();
                    stmdtID_ = Convert.ToInt32(dst.Tables[0].Rows[0]["StmpDuty_ID"].ToString());
                }
            }
        }
        private void BindColumnToFBRSellerBuyerCPRDetailGrid()
        {
            //if (grdCPRData.Columns.Count > 0)
            //{
            //       for (Int16 i = 0; i < grdCPRData.Columns.Count; i++)
            //        {
            //        grdCPRData.Columns.RemoveAt(i);

            //        }
            //}
            grdCPRData.DataSource = null;
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("NTN");
            dt.Columns.Add("Type");
            dt.Columns.Add("Name");
            dt.Columns.Add("CPRAmount");
            dt.Columns.Add("txtFiler_NonFiler");
            dt.Columns.Add("CPRNo");
            dt.Columns.Add("UniqIDSB");
            foreach (GridViewRowInfo row in grdSeller_Buyer.Rows)
            {
                //bool bl = Convert.ToBoolean(row.Cells["SelectOwner"].Value);
                //if (bl == true)
                //{
                if (row.Cells["Type"].Value.ToString() == "Seller")
                {
                    SqlParameter[] param = {
                        new SqlParameter("@Task","SellerCPRDetail"),
                        new SqlParameter("@NDCNo", NDCID),
                        new SqlParameter("@FileNo",txtFile_No_.Text)
                    };
                    DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDC_CPRData", param);
                    if (ds.Tables.Count >0)
                    {
                        if (ds.Tables[0].Rows.Count>0)
                        {
                            foreach (DataRow item in ds.Tables[0].Rows)
                            {
                                DataRow seller = dt.NewRow();
                                seller["NTN"] = item["NTN"].ToString();
                                seller["Type"] = item["Type"].ToString();
                                seller["Name"] = item["Name"].ToString();
                                seller["CPRAmount"] = item["CPRAmount"].ToString();
                                seller["txtFiler_NonFiler"] = item["txtFiler_NonFiler"].ToString(); ;
                                seller["CPRNo"] = item["CPRNo"].ToString(); ;
                                seller["UniqIDSB"] = Convert.ToDecimal(DateTime.Now.ToString("yyMMddHHmmssmmffffff"));
                                dt.Rows.Add(seller);
                            }
                        }
                        else
                        {
                            DataRow dtr = dt.NewRow();
                            dtr["NTN"] = row.Cells["NTN"].Value.ToString();
                            dtr["Type"] = row.Cells["Type"].Value.ToString();
                            dtr["Name"] = row.Cells["Name"].Value.ToString();
                            dtr["CPRAmount"] = 0;
                            if (!string.IsNullOrEmpty(row.Cells["NTN"].Value.ToString()))
                            {
                                #region Filer , Non-Filer
                                SqlParameter[] prm1 =
                                {
                                new SqlParameter("@Task","GetFBROwnerType"),
                               new SqlParameter("@NTN",ExtractNumberFromString(row.Cells["NTN"].Value.ToString()))
                            };
                                DataSet dst1 = cls_dl_NDC.NdcRetrival(prm1);
                                if (dst1.Tables.Count > 0)
                                {
                                    if (dst1.Tables[0].Rows.Count > 0)
                                    {
                                        if (dst1.Tables[0].Rows[0]["Type"].ToString() == "Filer")
                                        {
                                            dtr["txtFiler_NonFiler"] = "Filer";
                                        }

                                        if (dst1.Tables[0].Rows[0]["Type"].ToString() == "Late Filer")
                                        {
                                            dtr["txtFiler_NonFiler"] = "Late Filer";
                                        }
                                    }
                                    else
                                    {
                                        dtr["txtFiler_NonFiler"] = "Non-Filer";
                                    }
                                }
                                else
                                {
                                    dtr["txtFiler_NonFiler"] = "Non-Filer";
                                }
                                #endregion
                            }
                            else
                            {
                                dtr["txtFiler_NonFiler"] = "Non-Filer";
                            }
                            dtr["CPRNo"] = "NA";
                            dtr["UniqIDSB"] = row.Cells["UniqIDSB"].Value.ToString();  //Convert.ToDecimal(DateTime.Now.ToString("yyMMddHHmmssmmffffff")); 
                            dt.Rows.Add(dtr);
                        }
                    }
                   
                   
                }
                else
                {
                    DataRow dtr = dt.NewRow();
                    dtr["NTN"] = row.Cells["NTN"].Value.ToString();
                    dtr["Type"] = row.Cells["Type"].Value.ToString();
                    dtr["Name"] = row.Cells["Name"].Value.ToString();
                    dtr["CPRAmount"] = 0;
                    if (!string.IsNullOrEmpty(row.Cells["NTN"].Value.ToString()))
                    {
                        #region Filer , Non-Filer
                        SqlParameter[] prm1 =
                        {
                    new SqlParameter("@Task","GetFBROwnerType"),
                    new SqlParameter("@NTN",ExtractNumberFromString(row.Cells["NTN"].Value.ToString()))
                    };
                        DataSet dst1 = cls_dl_NDC.NdcRetrival(prm1);
                        if (dst1.Tables.Count > 0)
                        {
                            if (dst1.Tables[0].Rows.Count > 0)
                            {
                                if (dst1.Tables[0].Rows[0]["Type"].ToString() == "Filer")
                                {
                                    dtr["txtFiler_NonFiler"] = "Filer";
                                }

                                if (dst1.Tables[0].Rows[0]["Type"].ToString() == "Late Filer")
                                {
                                    dtr["txtFiler_NonFiler"] = "Late Filer";
                                }
                            }
                            else
                            {
                                dtr["txtFiler_NonFiler"] = "Non-Filer";
                            }
                        }
                        else
                        {
                            dtr["txtFiler_NonFiler"] = "Non-Filer";
                        }
                        #endregion
                    }
                    else
                    {
                        dtr["txtFiler_NonFiler"] = "Non-Filer";
                    }
                    dtr["CPRNo"] = "NA";
                    dtr["UniqIDSB"] = row.Cells["UniqIDSB"].Value.ToString();  //Convert.ToDecimal(DateTime.Now.ToString("yyMMddHHmmssmmffffff")); 
                    dt.Rows.Add(dtr);
                }
             
                //}
            }
            grdCPRData.DataSource = dt.DefaultView;


        }
        private void BindDealerListWithDropDown()
        {
            ///////////////////Start//// Remove All items from DropDown
            while (drpDealerList.Items.Count > 0)
                drpDealerList.Items.RemoveAt(0);
            drpDealerList.Text = "";
            //////////////////END////Remove All items from DropDown
            drpDealerList.DataSource = null;
            RadListDataItem dlrlst = new RadListDataItem();
            dlrlst.Value = 0;
            dlrlst.Text = "-- Select --";
            this.drpDealerList.Items.Add(dlrlst);
            SqlParameter[] param =
            {
               new SqlParameter("@Task", "Get_Dealer")
            };

            foreach (DataRow row in cls_dl_NDC.NdcRetrival(param).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ID"].ToString();
                dataItem.Text = row["BussinessTitle"].ToString();
                this.drpDealerList.Items.Add(dataItem);
            }
            drpDealerList.SelectedIndex = 0;

        }
        private void BindColumnToGrid()
        {
            try
            {
                GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn("Type");
                //set the column data source - the possible column values
                comboColumn.DataSource = new String[] { "Buyer" };
                //set the FieldName - the column will retrieve the value from "Phone" column in the data table
                comboColumn.FieldName = "Type";
                comboColumn.Name = "Type";
                comboColumn.HeaderText = "Type";
                comboColumn.Width = 50;
                //add the column to the grid
                comboColumn.ReadOnly = true;
                grdSeller_Buyer.Columns.Add(comboColumn);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindColumnToGrid.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }
        }
        private void InCaseOfUpdate()
        {
            try
            {
                #region In Case of Update
                if (NDCID == 0)
                {
                    //Do Somthing
                }
                else
                {
                    #region NDC Data Retrieving
                    //grdFBR.Enabled = false;
                    //grdChallanPayment.Enabled = false;
                    btn_Buyer.Enabled = true;
                    grdChallanPayment.Enabled = true;
                    drpStmpRefNo_.Enabled = true;
                    txtStampDuty_.Enabled = true;
                    btnrefres.Enabled = true;
                    //grpBInfo.Enabled = false;
                    SqlParameter[] prmtr =
                    {
                   //  new SqlParameter("@Task","NDCSearch"),
                     new SqlParameter("@NDCNo",NDCID),
                  //   new SqlParameter("@string","Str_Modify")
                     };

                    DataSet ds = new DataSet();
                    ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDC_LoadforModifcation", prmtr);
                   // ds = cls_dl_NDC.NdcRetrival(prmtr);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        #region Change NDCExpireDate Format and Disable TextBox of FileNo
                        // Change NDCExpireDate Format and Disable TextBox of FileNo
                        //string EexpdateNDC = ds.Tables[0].Rows[0]["NDCExpireDate"].ToString();
                        //DateTime ExpDateTimeNDC = DateTime.ParseExact(EexpdateNDC, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        tabControl1.SelectedTab = tp_Multiple_SellerBuyer;
                        if (tabControl1.TabPages.Contains(tp_Single_SellerBuyer))
                        {
                            tabControl1.TabPages.Remove(tp_Single_SellerBuyer);
                            tabControl1.SelectedTab.Text = "NDC Modification";

                        }
                        //tabControl1.TabPages.RemoveAt(0);
                        //////////////////////////////////////////////////////////////
                        #endregion
                        if (ds.Tables[0].Rows[0]["NDCType"].ToString() == "Normal")
                        { rdbNormal.CheckState = CheckState.Checked; }
                        else { rdbHiba.CheckState = CheckState.Checked; }


                        if (ds.Tables[0].Rows[0]["NDCTypeNormalUrgent"].ToString() == "Urgent") { chk_urgentNDC_.CheckState = CheckState.Checked; }
                        if (ds.Tables[0].Rows[0]["TFRType"].ToString() == "Urgent") { chk_UrgentTransfer_.CheckState = CheckState.Checked; }
                        if (ds.Tables[0].Rows[0]["OutStationCharges"].ToString() == "Yes") { chk_OutStationCharges_.CheckState = CheckState.Checked; }


                        // Check the Dealer Radio Button and Load the Dealers List in Dropdown
                        rdbdealer.CheckState = CheckState.Checked;
                        rdbdealer_CheckStateChanged(null, null);

                        int ind = drpDealerList.FindString(ds.Tables[0].Rows[0]["RequestedBy"].ToString());
                        if (ind > 0)
                        {
                            drpDealerList.SelectedIndex = ind;
                        }
                        else
                        {
                            drpDealerList.Text = ds.Tables[0].Rows[0]["RequestedBy"].ToString();
                        }



                        // Remove the Modify Column from Grid
                        grdSeller_Buyer.Columns.Remove("mdfy_dmy_buyer");


                        object s_b_ID = ds.Tables[0].Rows[0]["SBID"].ToString();
                        string str = s_b_ID.ToString();
                        SB_ID = string.IsNullOrEmpty(str) ? 0 : int.Parse(str);
                        dtpIssueDate_.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateIssue"].ToString());
                        txtDHAPChNo_ = ds.Tables[0].Rows[0]["DHAP_Challan_No"].ToString();
                        txtSellerAmount_ = ds.Tables[0].Rows[0]["Seller_Amount"].ToString();
                        txtSelerAccNo_ = ds.Tables[0].Rows[0]["Seller_Account_No"].ToString();
                        txtChalnAmount_ = ds.Tables[0].Rows[0]["Purchaser_Amount"].ToString();
                        txtPrcsrACCNo_ = ds.Tables[0].Rows[0]["Purchase_Account_No"].ToString();
                        txtDDNo_ = ds.Tables[0].Rows[0]["DDNoPOReceipt"].ToString();
                        txtBank_ = ds.Tables[0].Rows[0]["Bank"].ToString();
                        dtpPaymntDate_ = (ds.Tables[0].Rows[0]["Purcsr_Payment_Date"].ToString());
                        txtFile_No_.Text = ds.Tables[0].Rows[0]["FilePlotNo"].ToString();
                        txtSector_.Text = ds.Tables[0].Rows[0]["Sector"].ToString();
                        txtPhase_.Text = ds.Tables[0].Rows[0]["Phase"].ToString();
                        txtStampDuty_.Text = ds.Tables[0].Rows[0]["StampDuty"].ToString();
                        txtRemarks_.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                        dtpNDCExpire_.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["NDCExpireDate"].ToString());

                        //Select_CurrentOwner_Info_Against_FileNo_("");
                        decimal uqnmbr = 10;
                        ds.Tables[0].Columns.Add("UniqIDSB");
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr);
                            }
                            else if (i == 1)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 1;
                            }
                            else if (i == 2)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 2;
                            }
                            else if (i == 3)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 3;
                            }
                            else if (i == 4)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 4;
                            }
                            else if (i == 5)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 5;
                            }
                            else if (i == 6)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 6;
                            }
                            else if (i == 7)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 7;
                            }
                            else if (i == 8)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 8;
                            }
                            else if (i == 9)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 9;
                            }
                            else if (i == 10)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 10;
                            }
                            else if (i == 11)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 11;
                            }
                            else if (i == 12)
                            {
                                ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 12;
                            }
                            else if (i == 13)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 13;
                            }
                            else if (i == 14)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 14;
                            }
                            else if (i == 15)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 15;
                            }
                            else if (i == 16)
                            {
                                ds.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 16;
                            }

                        }

                        grdSeller_Buyer.DataSource = ds.Tables[0].DefaultView;


                        ddn.ReadOnly = false;
                        ddmnt.ReadOnly = false;
                        chno.ReadOnly = false;
                        chm.ReadOnly = false;

                        ddn.Text = txtDDNo_;
                        ddmnt.Text = txtSellerAmount_;
                        chno.Text = txtDHAPChNo_;
                        chm.Text = txtChalnAmount_;
                    }
                    #endregion

                }

                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on InCaseOfUpdate.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }

        }


        private bool PreventAgainApply_()
        {
            bool bl = false;
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","PreventAgainApply"),
                new SqlParameter("@FileNo",txtFile_No_.Text)
                };
                DataSet ds = cls_dl_NDC.NdcRetrival(prm);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("This FileNo is already Engage in Another NDC.", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnAddBuyer.Enabled = false;

                }
                else
                {
                    btnAddBuyer.Enabled = true;
                    bl = true;
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on PreventAgainApply.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }

            return bl;
        }
        private bool FileActiveNotBlock()
        {
            bool fanl = false;
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","FileActiveNotBlockStatus"),
                new SqlParameter("@FileNo",txtFile_No_.Text)
            };
            DataSet dst = cls_dl_NDC.NdcRetrival(prm);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    fanl = true;
                }
                else
                {
                    MessageBox.Show("This File No. is Cancel OR Block.");
                    fanl = false;
                }
            }
            else
            {
                MessageBox.Show("This File No. is Cancel OR Block.");
                fanl = false;
            }
            return fanl;
        }

        private void ReConsilation(string fileno)
        {
            SqlParameter[] prmt =
            {
              new SqlParameter("@Task","Rece_Plan_Adjust"),
              new SqlParameter("@FileNo",fileno)
            };
            int rsult = Data_Layer.Installment.cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prmt);
        }


        private DataTable Installment_Surcharge_Detail_For_Report_Table(double get_dueamount, double get_receamount, double get_remainInstAmount,
            double get_dueSurcharge, double get_recSurcharge, double get_waveoffSurcharge, double get_remainSurcharge, double tfrfee, double memebershipFee, double membershipFormFee, double utFee,
            double osCharges, double undcFee, double rindcfee, double get_TotalDueRemaining, double stampDuty, string fileno, string requested_by)
        {
            DataTable InstSurc_Tbl = new DataTable();
            try
            {
                #region DataTable_Column Creation  
                DataTable_column DueAmount = new DataTable_column() { ColmnName = "DueAmount", type = typeof(double) };
                DataTable_column ReceAmount = new DataTable_column() { ColmnName = "ReceAmount", type = typeof(double) };
                DataTable_column RemainingInstAmount = new DataTable_column() { ColmnName = "RemainingInstAmount", type = typeof(double) };
                DataTable_column DueSurcharge = new DataTable_column() { ColmnName = "DueSurcharge", type = typeof(double) };
                DataTable_column ReceSurcharge = new DataTable_column() { ColmnName = "ReceSurcharge", type = typeof(double) };
                //DataTable_column WaveOffSurcharge = new DataTable_column() { ColmnName = "WaveOffSurcharge", type = typeof(double) };
                DataTable_column RemaningSurcharge = new DataTable_column() { ColmnName = "RemaningSurcharge", type = typeof(double) };
                DataTable_column TransferFee = new DataTable_column() { ColmnName = "TransferFee", type = typeof(double) };

                DataTable_column MembershipFee = new DataTable_column() { ColmnName = "MembershipFee", type = typeof(double) };
                DataTable_column MembershipFormFee = new DataTable_column() { ColmnName = "MembershipFormFee", type = typeof(double) };



                DataTable_column UrgentTransferFee = new DataTable_column() { ColmnName = "UrgentTransferFee", type = typeof(double) };
                DataTable_column OutStationCharges = new DataTable_column() { ColmnName = "OutStationCharges", type = typeof(double) };
                DataTable_column UrgentNDCFee = new DataTable_column() { ColmnName = "UrgentNDCFee", type = typeof(double) };
                DataTable_column ReIssuedNDCFee = new DataTable_column() { ColmnName = "ReIssuedNDCFee", type = typeof(double) };
                DataTable_column TotalDueRemainig = new DataTable_column() { ColmnName = "TotalDueRemainig", type = typeof(double) };
                DataTable_column StampDutyFee = new DataTable_column() { ColmnName = "StampDutyFee", type = typeof(double) };
                DataTable_column FileNo = new DataTable_column() { ColmnName = "FileNo", type = typeof(string) };
                DataTable_column RequestedBy = new DataTable_column() { ColmnName = "RequestedBy", type = typeof(string) };

                #endregion
                #region Insert DataTabl_Column in List, and Send to Helper to make DataTable
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(DueAmount);
                colmn.Add(ReceAmount);
                colmn.Add(RemainingInstAmount);
                colmn.Add(DueSurcharge);
                colmn.Add(ReceSurcharge);
                //colmn.Add(WaveOffSurcharge);
                colmn.Add(RemaningSurcharge);
                colmn.Add(TransferFee);
                colmn.Add(MembershipFee);
                colmn.Add(MembershipFormFee);
                colmn.Add(UrgentTransferFee);
                colmn.Add(OutStationCharges);
                colmn.Add(UrgentNDCFee);
                colmn.Add(ReIssuedNDCFee);
                colmn.Add(TotalDueRemainig);
                colmn.Add(StampDutyFee);
                colmn.Add(FileNo);
                colmn.Add(RequestedBy);
                InstSurc_Tbl = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                #endregion
                #region Insertion in DataTable
                DataRow instsur_row = InstSurc_Tbl.NewRow();// Create Row for Seller Data
                instsur_row["DueAmount"] = get_dueamount;
                instsur_row["ReceAmount"] = get_receamount;
                instsur_row["RemainingInstAmount"] = get_remainInstAmount;
                instsur_row["DueSurcharge"] = get_dueSurcharge;
                instsur_row["ReceSurcharge"] = get_recSurcharge + get_waveoffSurcharge;
                //instsur_row["WaveOffSurcharge"] = get_waveoffSurcharge;
                instsur_row["RemaningSurcharge"] = get_remainSurcharge;
                instsur_row["TransferFee"] = tfrfee;
                instsur_row["MembershipFee"] = memebershipFee;
                instsur_row["MembershipFormFee"] = membershipFormFee;
                instsur_row["UrgentTransferFee"] = utFee;
                instsur_row["OutStationCharges"] = osCharges;
                instsur_row["UrgentNDCFee"] = undcFee;
                instsur_row["ReIssuedNDCFee"] = rindcfee;
                instsur_row["TotalDueRemainig"] = get_TotalDueRemaining;
                instsur_row["StampDutyFee"] = stampDuty;
                instsur_row["FileNo"] = fileno.ToUpper();
                instsur_row["RequestedBy"] = requested_by;
                InstSurc_Tbl.Rows.Add(instsur_row);
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on File_Seller_Buyer_Table.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }
            return InstSurc_Tbl;
        }


        private bool CheckCaution_()
        {
            bool bol = false;
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Check_Caution"),
                new SqlParameter("@FileNo",txtFile_No_.Text)
                };
                DataSet ds = cls_dl_Caution.Caution_Reader(prm);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //if (int.Parse(ds.Tables[0].Rows[0]["TotalCount"].ToString()) > 0)
                    //{
                    //Caution_Info_Prompt frm = new Caution_Info_Prompt(ds);
                    //frm.ShowDialog();
                    radButton1.Enabled = false;
                    btnNDCCreate_.Enabled = false;
                    btnAddBuyer.Enabled = false;
                    btnGenerateSellerChallan.Enabled = false;
                    btnGenerateStampDuty.Enabled = false;
                    btnGenerateBuyerChallan.Enabled = false;
                    btnGenerateSurchargeChallan.Enabled = false;
                    bol = false;
                    MessageBox.Show("This File No. is temporarily blocked.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    //}
                    //else
                    //{
                    //    btnAddBuyer.Enabled = true;
                    //    bol = true;
                    //}
                }
                else
                {
                    btnGenerateSellerChallan.Enabled = true;
                    btnGenerateStampDuty.Enabled = true;
                    btnGenerateBuyerChallan.Enabled = true;
                    btnGenerateSurchargeChallan.Enabled = true;
                    radButton1.Enabled = true;
                    btnNDCCreate_.Enabled = true;
                    btnAddBuyer.Enabled = true;
                    bol = true;
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on CheckCaution.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }
            return bol;
        }


        private void btn_File_Verify_Click(object sender, EventArgs e)
        {
            try
            {
                #region code
                ddn.Text = "";
                ddmnt.Text = "";
                chno.Text = "";
                chm.Text = "";
                txtPhase_.Text = "Phase-1";
                txtRemarks_.Text = "";

                //txtTFRFee_minus.Text = "0";
                //txtmbrfee_minus.Text = "0";
                //txtMbrFrmFee_minus.Text = "0";
                //txtStmDtyFee_minus.Text = "0";

                grdSeller_Buyer.DataSource = null;
                grdCPRData.DataSource = null;
                Cursor.Current = Cursors.WaitCursor;
                if (rdbPlotOwner.IsChecked)
                {
                    plotdealerState = true;
                }
                else if (rdbdealer.IsChecked)
                {
                    if (drpDealerList.SelectedIndex > 0)
                    {
                        plotdealerState = true;
                    }
                    else
                    {
                        plotdealerState = false;
                    }
                }
                if (txtFile_No_.Text != "" && (rdbNormal.IsChecked || rdbHiba.IsChecked || rdbLegalHeirCivil.IsChecked || rdbLegalHeirSvc.IsChecked) && plotdealerState)
                {

                    chkCorporate_Check_ = chkCorporate.Checked ? "Yes" : "No";
                    urgentNDC_Check_ = chk_urgentNDC_.Checked ? "Yes" : "No";
                    urgentTFR_Check_ = chk_UrgentTransfer_.Checked ? "Yes" : "No";
                    OutStationCHarges_Check_ = chk_OutStationCharges_.Checked ? "Yes" : "No";
                    // rdbHiba    rdbLegalHeirCivil   rdbLegalHeirSvc
                    if (rdbNormal.IsChecked) { TfrNormalHiba_Check = "Normal"; }
                    else if (rdbHiba.IsChecked) { TfrNormalHiba_Check = "Hiba"; }
                    else if (rdbLegalHeirCivil.IsChecked) { TfrNormalHiba_Check = "LegalHeirCivil"; }
                    else if (rdbLegalHeirSvc.IsChecked) { TfrNormalHiba_Check = "LegalHeirSvc"; }
                    // TfrNormalHiba_Check = rdbNormal.IsChecked ? "Normal" : "Hiba";
                    ReissueNDC_Check_ = chkNDCReissue.Checked ? "Yes" : "No";
                    MembershipFormFeeSkipInclude_ = chbMembershipFormFeeSkip.Checked ? "SkipMembershipFormFee" : "IncludeMembershipFormFee";

                    if (PreventAgainApply_() == true && CheckCaution_() == true && FileActiveNotBlock() == true)
                    {

                        SqlParameter[] pr =
                        {
                          new SqlParameter("@Task","FileStatus"),
                          new SqlParameter("@FileNo",txtFile_No_.Text)
                        };
                        DataSet ds = cls_dl_NDC.NdcRetrival(pr);
                        flsts = ds.Tables[0].Rows[0]["FileStatus"].ToString();//

                        if (flsts != "UnClear")
                        {
                            CheckFileNoForNDCRenewalApply();
                            ReConsilation(txtFile_No_.Text);
                            Select_CurrentOwner_Info_Against_FileNo_("");
                            GetPlotNoAgainst();
                        }
                        else
                        {
                            btnNDCCreate_.Enabled = false;
                            MessageBox.Show("Please clear File from TP & BC Branch");

                        }



                    }


                }
                else
                {
                    MessageBox.Show("Please select TFR Type, File No. and Dealer Name (If you select Dealer Radio button.)", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            #endregion
        }
        private void CheckFileNoForNDCRenewalApply()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","CheckFileNoForNDCRenewalChallanExistance"),
                new SqlParameter("@FileNo",txtFile_No_.Text)
            };
            DataSet std = cls_dl_NDC.NdcRetrival(prm);
            if (std.Tables.Count > 0)
            {
                if (std.Tables[0].Rows.Count > 0)
                {
                    NDCRenewChallanStatus = "ApplyForRenewalNDC";

                    txtRemarks_.Text = "Old NDCNo # " + std.Tables[0].Rows[0]["NDCNo"].ToString() + " has been Cancelled.";

                }
                else
                {
                    NDCRenewChallanStatus = "";
                }
            }
            else
            {
                NDCRenewChallanStatus = "";
            }
        }
        private void GetPlotNoAgainst()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetPlotNoAgainstFileNo"),
                new SqlParameter("@FileNo",txtFile_No_.Text)
            };
            DataSet std = cls_dl_NDC.NdcRetrival(prm);
            if (std.Tables.Count > 0)
            {
                if (std.Tables[0].Rows.Count > 0)
                {
                    txtSector_.Text = std.Tables[0].Rows[0]["Name"].ToString();
                }

            }
        }
        private void Select_CurrentOwner_Info_Against_FileNo_(string getstring)
        {
            // bool blvr = false;
            try
            {
                int mbcount = 0;
                if (rdbsngl.CheckState == CheckState.Checked)
                {
                    mbcount = 1;
                }
                else if (rdbDual.CheckState == CheckState.Checked)
                {
                    mbcount = 2;
                }
                else if (rdbTrple.CheckState == CheckState.Checked)
                {
                    mbcount = 3;
                }
                else if (rdbQuad.CheckState == CheckState.Checked)
                {
                    mbcount = 4;
                }
                rdbFBR.CheckState = CheckState.Checked;
                rdbFBR_CheckStateChanged(null, null);

                decimal tfrfee_minus = Convert.ToDecimal(txtTFRFee_minus.Text == "" ? "0" : txtTFRFee_minus.Text);
                decimal mbrfee_minus = Convert.ToDecimal(txtmbrfee_minus.Text == "" ? "0" : txtmbrfee_minus.Text);
                decimal mbrfrmfee_minus = Convert.ToDecimal(txtMbrFrmFee_minus.Text == "" ? "0" : txtMbrFrmFee_minus.Text);
                decimal stmdtyfee_minus = Convert.ToDecimal(txtStmDtyFee_minus.Text == "" ? "0" : txtStmDtyFee_minus.Text);

                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Select_CurrentOwner_Info_Against_FileNo_Multiple"),//Select_CurrentOwner_Info_Against_FileNo_Single
                new SqlParameter("@FileNo",txtFile_No_.Text),
                //new SqlParameter("@DateForSurchargeCalculation",dtp_dateOfSurchargeCalculation_.Value),
                new SqlParameter("@CorporateCheck",chkCorporate_Check_),
                new SqlParameter("@UrgentNDCFee",urgentNDC_Check_),
                new SqlParameter("@ReIssueNDCFee",ReissueNDC_Check_),
                new SqlParameter("@UrgentTFRFee",urgentTFR_Check_),
                new SqlParameter("@OutStationCharges",OutStationCHarges_Check_),
                new SqlParameter("@TfrNormalHiba_Check",TfrNormalHiba_Check),
                new SqlParameter("@SkipIncludeMembershipFormFee",MembershipFormFeeSkipInclude_),
                new SqlParameter("@TfrFee_Minus",tfrfee_minus),
                new SqlParameter("@MbrFee_Minus",mbrfee_minus),
                new SqlParameter("@MbrFrmFee_Minus",mbrfrmfee_minus),
                new SqlParameter("@StmDtyFee_Minus",stmdtyfee_minus),
                new SqlParameter("@MbCount",mbcount)
                };
                DataSet ds = cls_dl_NDC.NdcRetrival(prm);
                #region Requested for Summary Report Dealer Name 

                SqlParameter[] prmt =
                {
                     new SqlParameter("@Task","Current_OwnerAgainstFile_For_Info"),
                     new SqlParameter("@FileNo",txtFile_No_.Text)
                };
                datset = cls_dl_NDC.NdcRetrival(prmt);

                if (datset.Tables.Count > 0)
                {
                    if (datset.Tables[1].Rows.Count > 0 && datset.Tables[0].Rows.Count > 0)
                    {
                        datset.Tables[0].Merge(datset.Tables[1]);
                    }
                }



                if (rdbdealer.IsChecked)
                {
                    clsPluginHelper.RadDropDownSelectByText(drpDealerList, reqstdby);
                    reqstdby = drpDealerList.SelectedItem.ToString();
                }
                else
                {
                    reqstdby = datset.Tables[0].Rows[0]["Name"].ToString();
                }

                #endregion
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Columns.Count == 14) // If the Dues are Remaning
                    {
                        //////// Start /// Surcharge Waiver Automatic Apply in Approved Status
                        //int srpr = int.Parse(ds.Tables[1].Rows[0]["SurPer"].ToString());
                        //string flno = ds.Tables[1].Rows[0]["FileNo"].ToString();
                        //if (srpr > 0)
                        //{
                        //    if (MessageBox.Show("Are you want to process auto Surcharge Waiver ?","Attention !",MessageBoxButtons.YesNo,MessageBoxIcon.Information)== DialogResult.Yes)
                        //    {
                        //        frmNewSurchargeRequest frmobj = new frmNewSurchargeRequest(srpr, flno, "CallFromNDCCreateForm");
                        //        frmobj.ShowDialog();
                        //        btn_File_Verify_Click(null, null);
                        //    }
                        //} ////// End /// Surcharge Waiver Automatic Apply in Approved Status
                        //else if(srpr == 0)
                        //{
                        #region Calculation of Dues and Make Report
                        double receamount = double.Parse(ds.Tables[0].Rows[0]["PaidAmount"].ToString());
                        double dueamount = double.Parse(ds.Tables[0].Rows[0]["DueAmount"].ToString());
                        double recSurcharge = double.Parse(ds.Tables[0].Rows[0]["PaidSurcharge"].ToString());
                        double waveOffSurcharge = double.Parse(ds.Tables[0].Rows[0]["SurchargeWaveOff"].ToString());
                        double dueSurcharge = double.Parse(ds.Tables[0].Rows[0]["DueSurcharge"].ToString());
                        double remainInstAmount = double.Parse(ds.Tables[0].Rows[0]["RemainingInstAmount"].ToString());
                        double remainSurcharge = double.Parse(ds.Tables[0].Rows[0]["RemainingSurcharge"].ToString());
                        double tfrFee = double.Parse(ds.Tables[0].Rows[0]["TransferFee"].ToString());

                        double membershipFee = double.Parse(ds.Tables[0].Rows[0]["MembershipFee"].ToString());
                        double membershipFormFee = double.Parse(ds.Tables[0].Rows[0]["MembershipFormFee"].ToString());

                        double utfrFee = double.Parse(ds.Tables[0].Rows[0]["UrgentTransferFee"].ToString());
                        double osCharges = double.Parse(ds.Tables[0].Rows[0]["OutStationCharges"].ToString());
                        double undcFee = double.Parse(ds.Tables[0].Rows[0]["UrgentNDCFee"].ToString());
                        double rindcFee = 0.0; //double.Parse(ds.Tables[0].Rows[0]["ReIssueNDCFee"].ToString());
                        double stampDutyAmount = 0;

                        stampDutyAmount = StampFees();

                        double TotalDueRemaining = double.Parse(ds.Tables[0].Rows[0]["TotalDueRemaining"].ToString()) + stampDutyAmount;
                        #region commented code
                        //if (receamount !="" &&  dueamount != "" && RemainingAmount != "")
                        //{
                        //string remaning = Convert.ToString((Convert.ToDecimal(dueamount) - Convert.ToDecimal(receamount)));

                        //if (MessageBox.Show(
                        //      "Your Due Amount Till Current Date :" + dueamount + Environment.NewLine
                        //     + "Your Paid Amount Till Current Date :" + receamount + Environment.NewLine
                        //     + "Remaining Amount :" + remainInstAmount + Environment.NewLine
                        //     + "Due Surcharge =" + dueSurcharge + Environment.NewLine
                        //     + "Recieve Surcharge =" + recSurcharge + Environment.NewLine
                        //     + "Wave Off Surcharge =" + waveOffSurcharge + Environment.NewLine
                        //     + "Remaining Surcharge =" + remainSurcharge + Environment.NewLine
                        //     + "Transfer Fee(Paid by Buyer.) =" + tfrFee + Environment.NewLine
                        //     + "Urgent Transfer Fee =" + utfrFee + Environment.NewLine
                        //     + "Out Station Charges =" + osCharges + Environment.NewLine
                        //     + "Urgent NDC Fee =" + undcFee + Environment.NewLine
                        //     + "------------------------------------------------------------------" + Environment.NewLine
                        //     + "Total Remaining Amount =" + TotalDueRemaining + Environment.NewLine
                        //     + "Please Paid the Total Remaining Amount." + TotalDueRemaining + Environment.NewLine
                        //     + "Are you sure you want to Print the Detail ?"
                        //     , "Attention !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information
                        //     ) == DialogResult.Yes)
                        //  {
                        #endregion

                        #region If Dues are Remaining then Retrieve the Current Owner Data 

                        #region Generate Unique Number for Seller and Buyer
                        decimal uqnmbr = Convert.ToDecimal(datset.Tables[2].Rows[0]["UniqIDSB"].ToString());

                        /// get form FBR table for Buyer info and Append data row with the existing data set
                        datset.Tables[0].Columns.Add("UniqIDSB");
                        for (int i = 0; i < datset.Tables[0].Rows.Count; i++)
                        {
                            if (i == 0)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr);
                            }
                            else if (i == 1)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 1;
                            }
                            else if (i == 2)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 2;
                            }
                            else if (i == 3)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 3;
                            }
                            else if (i == 4)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 4;
                            }
                            else if (i == 5)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 5;
                            }
                            else if (i == 6)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 6;
                            }
                            else if (i == 7)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 7;
                            }
                            else if (i == 8)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 8;
                            }
                            else if (i == 9)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 9;
                            }
                            else if (i == 10)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 10;
                            }
                            else if (i == 11)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 11;
                            }
                            else if (i == 12)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 12;
                            }
                            else if (i == 13)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 13;
                            }
                            else if (i == 14)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 14;
                            }
                            else if (i == 15)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 15;
                            }
                            else if (i == 16)
                            {
                                datset.Tables[0].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 16;
                            }

                        }

                        #endregion
                        grdSeller_Buyer.DataSource = datset.Tables[0].DefaultView;

                        /// Call the load button click event
                        btnloadgrid_Click(null, null);

                        btnrefres_Click(null, null);
                        #endregion

                        DataTable dtb = new DataTable();
                        if (dtb.Rows.Count > 0)
                        {
                            dtb.Rows.Clear();
                        }

                        #region Account Statement of Finance Part Reading and Comparing
                        DataSet dts = AccountStatmentView();
                        int TotalAmountOfPlan = dts.Tables[0].AsEnumerable()
                                                   .Sum(r => r.Field<int>("PlanAdjustAmount"));
                        int TotalAmount = 0;
                        if (Convert.ToBoolean(dts.Tables[1].Rows[0]["PosessionAssign"].ToString()))
                        {
                            TotalAmount = TotalAmountOfPlan;
                        }
                        else
                        {
                            TotalAmount = dts.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                                   .Sum(r => r.Field<int>("PlanAdjustAmount"));
                        }

                        int TotalReceive = dts.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null)
                                                      .Sum(r => r.Field<int>("ReceAdjustAmount"));
                        int Surcharge = dts.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                                      .Sum(r => r.Field<int>("Surcharge"));
                        int TotalWaieOffSurcharge = dts.Tables[0].AsEnumerable().Where(r => r.Field<int?>("TotalWaiveOffSurcharge") != null)
                                                      .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));
                        double TotalSurchargePaid = Convert.ToDouble(dts.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString());

                        //// Installment Calculation
                        double DueRemaingAmount = TotalAmount - TotalReceive;
                        if (dueamount == TotalAmount) { } else { /*dueamount = TotalAmount;*/ MessageBox.Show("Invalid Installment Due Calculation.Contact with MIS Branch."); return; }
                        if (receamount == TotalReceive || receamount > TotalAmountOfPlan) { } else { /*receamount = TotalReceive;*/ MessageBox.Show("Invalid Installment Recieve Calculation.Contact with MIS Branch."); return; }
                        if (remainInstAmount == DueRemaingAmount || receamount > TotalAmountOfPlan) { } else { /*remainInstAmount = DueRemaingAmount;*/ MessageBox.Show("Invalid Total Remaining Installment Calculation.Contact with MIS Branch."); return; }
                        if (remainInstAmount < 0) { remainInstAmount = 0; }
                        //// Surcharge Calculation
                        double DueSurchAmount = Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge;
                        if (DueSurchAmount < 0) { DueSurchAmount = 0; }
                        if (dueSurcharge == Surcharge) { } else { /*dueSurcharge = Surcharge;*/ MessageBox.Show("Invalid Due Surcharge Calculation.Contact with MIS Branch."); return; }
                        if (recSurcharge == TotalSurchargePaid) { } else { /*recSurcharge = TotalSurchargePaid;*/ MessageBox.Show("Invalid Receive Surcharge Calculation.Contact with MIS Branch."); return; }
                        if (waveOffSurcharge == TotalWaieOffSurcharge) { } else { /*waveOffSurcharge = TotalWaieOffSurcharge;*/ MessageBox.Show("Invalid Waiveoff Surcharge Calculation.Contact with MIS Branch."); return; }
                        if (remainSurcharge == DueSurchAmount) { } else { /*remainSurcharge = DueSurchAmount;*/ MessageBox.Show("Invalid Total Remaining Surcharge Calculation.Contact with MIS Branch."); return; }

                        if (remainInstAmount < 0) { remainInstAmount = 0; }

                        #endregion
                        dtb = Installment_Surcharge_Detail_For_Report_Table(dueamount, receamount, remainInstAmount, dueSurcharge, recSurcharge, waveOffSurcharge, remainSurcharge, tfrFee, membershipFee, membershipFormFee, utfrFee, osCharges, undcFee, rindcFee, TotalDueRemaining, stampDutyAmount, txtFile_No_.Text, reqstdby);
                        dstst.Tables.Clear();
                        dstst.Merge(dtb);

                        if (string.IsNullOrEmpty(getstring))
                        {
                            frm_SurchargInstallmentInfoDetailReport_ForNDC frmdt = new frm_SurchargInstallmentInfoDetailReport_ForNDC(dstst);
                            frmdt.ShowDialog();
                            btnNDCCreate_.Enabled = false;
                        }


                        // }
                        #endregion
                        //}


                    }
                    else if (ds.Tables[0].Columns.Count != 14) // When the Dues are not Remaining and Pay Complete.
                    {

                        #region
                        if (ds.Tables[0].Rows.Count > 0) // When the Dues are not Remaining and Pay Complete.
                        {
                            #region Check the Current Owner , if Present then Get Info
                            if (ds.Tables[2].Rows.Count > 0) // Check For the Current Owner
                            {
                                if (int.Parse(ds.Tables[2].Rows[0]["OwnerCount"].ToString()) > 0) // If the Current Owner is Exist
                                {
                                    //grbChallanNo.Enabled = true;
                                    grpsbInfo.Enabled = true;
                                    grpBInfo.Enabled = true;
                                    FileKeyID = int.Parse(ds.Tables[0].Rows[0]["FileMapKey"].ToString());
                                    MSID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                                    dtpPaymntDate_ = (ds.Tables[0].Rows[0]["LastDD_Date"].ToString());
                                    txtDDNo_ = ds.Tables[0].Rows[0]["DDNo"].ToString();
                                    txtSellerAmount_ = ds.Tables[0].Rows[0]["Seller_Amount"].ToString();
                                    txtDHAPChNo_ = ds.Tables[0].Rows[0]["ChalanNo"].ToString();
                                    txtChalnAmount_ = ds.Tables[0].Rows[0]["ChallanAmount"].ToString();
                                    txtBank_ = ds.Tables[0].Rows[0]["ChallanBank"].ToString();
                                    txtSelerAccNo_ = ds.Tables[0].Rows[0]["InstNo"].ToString();
                                    txtPrcsrACCNo_ = ds.Tables[0].Rows[0]["Particular"].ToString();

                                    this.grdSeller_Buyer.Columns.Move(7, 8);

                                    #region Generate Unique Number for Seller and Buyer
                                    decimal uqnmbr = Convert.ToDecimal(ds.Tables[4].Rows[0]["UniqIDSB"].ToString());

                                    /// get form FBR table for Buyer info and Append data row with the existing data set
                                    ds.Tables[1].Columns.Add("UniqIDSB");
                                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                                    {
                                        if (i == 0)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr);
                                        }
                                        else if (i == 1)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 1;
                                        }
                                        else if (i == 2)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 2;
                                        }
                                        else if (i == 3)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 3;
                                        }
                                        else if (i == 4)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 4;
                                        }
                                        else if (i == 5)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 5;
                                        }
                                        else if (i == 6)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 6;
                                        }
                                        else if (i == 7)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 7;
                                        }
                                        else if (i == 8)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 8;
                                        }
                                        else if (i == 9)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 9;
                                        }
                                        else if (i == 10)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 10;
                                        }
                                        else if (i == 11)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 11;
                                        }
                                        else if (i == 12)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 12;
                                        }
                                        else if (i == 13)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 13;
                                        }
                                        else if (i == 14)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 14;
                                        }
                                        else if (i == 15)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 15;
                                        }
                                        else if (i == 16)
                                        {
                                            ds.Tables[1].Rows[i]["UniqIDSB"] = GetUniqueNumberForSellerBuyer(uqnmbr) + 16;
                                        }

                                    }

                                    #endregion

                                    grdSeller_Buyer.DataSource = ds.Tables[1].DefaultView;
                                    /// Call the load button click event
                                    btnloadgrid_Click(null, null);
                                    btnrefres_Click(null, null);
                                    btnNDCCreate_.Enabled = true;
                                    #region Data
                                    ddn.Text = txtDDNo_;
                                    ddmnt.Text = txtSellerAmount_;
                                    chno.Text = txtDHAPChNo_;
                                    chm.Text = txtChalnAmount_;
                                    #endregion

                                }
                                else
                                {
                                    MessageBox.Show("This File No. has no Owner , Please Create  the Owner for it. ");
                                }
                            }
                            else
                            {
                                MessageBox.Show("This File No. has no Owner , Please Create  the Owner for it. ");
                            }
                            #endregion

                            #region Stamp Duty + Surcharge 

                            #region Account Statement of Finance Part Reading and Comparing
                            DataSet dts = AccountStatmentView();

                            int TotalAmount = dts.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                                      .Sum(r => r.Field<int>("PlanAdjustAmount"));
                            int TotalReceive = dts.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null)
                                                          .Sum(r => r.Field<int>("ReceAdjustAmount"));



                            int Surcharge = dts.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                                          .Sum(r => r.Field<int>("Surcharge"));
                            int TotalWaieOffSurcharge = dts.Tables[0].AsEnumerable().Where(r => r.Field<int?>("TotalWaiveOffSurcharge") != null)
                                                          .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));
                            double TotalSurchargePaid = Convert.ToDouble(dts.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString());

                            //// Installment Calculation
                            double DueRemaingAmount = TotalAmount - TotalReceive;

                            //// Surcharge Calculation
                            double DueSurchAmount = Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge;


                            #endregion

                            double stampDutyAmount = StampFees();
                            if (stampDutyAmount == 0 && (DueSurchAmount == 0 || DueSurchAmount < 0) && (DueRemaingAmount == 0 || DueRemaingAmount < 0))
                            {
                                btnNDCCreate_.Enabled = true;
                            }
                            else
                            {

                                btnNDCCreate_.Enabled = false;
                                string strsrg = "";
                                if (DueSurchAmount > 0)
                                {
                                    strsrg = Environment.NewLine + "Remaining Surcharge is : " + Convert.ToString(DueSurchAmount);
                                }
                                string strstm = "";
                                if (stampDutyAmount > 0)
                                {
                                    strstm = "Stamp Duty is Not Submitted / Not-Verfied.";
                                }

                                string strinstalmnt = "";
                                if (DueRemaingAmount > 0)
                                {
                                    strinstalmnt = Environment.NewLine + "Remaining Installment Amount is : " + Convert.ToString(DueRemaingAmount);
                                }




                                if (DueSurchAmount > 0 && stampDutyAmount > 0 && DueRemaingAmount > 0)
                                {
                                    MessageBox.Show(strstm + strsrg + strinstalmnt, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                if (DueSurchAmount > 0 && stampDutyAmount == 0 && DueRemaingAmount == 0)
                                {
                                    MessageBox.Show(strsrg, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                if (DueSurchAmount == 0 && stampDutyAmount > 0 && DueRemaingAmount == 0)
                                {
                                    MessageBox.Show(strstm, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                if (DueSurchAmount == 0 && stampDutyAmount == 0 && DueRemaingAmount > 0)
                                {
                                    MessageBox.Show(strinstalmnt, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                if (DueSurchAmount > 0 && stampDutyAmount > 0 && DueRemaingAmount == 0)
                                {
                                    MessageBox.Show(strstm + strsrg, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                if (DueSurchAmount == 0 && stampDutyAmount > 0 && DueRemaingAmount > 0)
                                {
                                    MessageBox.Show(strstm + strinstalmnt, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                if (DueSurchAmount > 0 && stampDutyAmount == 0 && DueRemaingAmount > 0)
                                {
                                    MessageBox.Show(strsrg + strinstalmnt, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }



                            }
                            #endregion
                        }
                        else
                        {
                            MessageBox.Show("You does't Submit any Installment."
                                             + Environment.NewLine + " OR"
                                             + Environment.NewLine + "There is no Current Owner Against this File No.",
                                               "Attention !!!",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning);
                        }
                        #endregion

                        #region Urgent NDC,TFR,Allocation Charges Challan No and ChallanID's
                        if (ds.Tables[5].Rows.Count > 0)   // Urgent NDC
                        {
                            UNF_ChallanID = int.Parse(ds.Tables[5].Rows[0]["challanID"].ToString());
                            UNF_ChallanNo = ds.Tables[5].Rows[0]["ChalanNo"].ToString();
                        }

                        if (ds.Tables[6].Rows.Count > 0)   // Urgent TFR
                        {
                            UTF_ChallanID = int.Parse(ds.Tables[6].Rows[0]["challanID"].ToString());
                            UTF_ChallanNo = ds.Tables[6].Rows[0]["ChalanNo"].ToString();
                        }

                        if (ds.Tables[7].Rows.Count > 0) // Urgent Allocation
                        {
                            UALF_ChallanID = int.Parse(ds.Tables[7].Rows[0]["challanID"].ToString());
                            UALF_ChallanNo = ds.Tables[7].Rows[0]["ChalanNo"].ToString();
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("There is no record for this FileNo. Please check another.");
                    }




                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Select_CurrentOwner_Info_Against_FileNo.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }


        }
        private decimal GetUniqueNumberForSellerBuyer(decimal uqnmbr)
        {
            UniquenmbrforSB = Convert.ToDecimal(DateTime.Now.ToString("yyMMddHHmmssmmffffff"));
            //if (uqnmbr == 0)
            //{
            //    UniquenmbrforSB = Convert.ToDecimal(DateTime.Now.ToString("yyMMddHHmmssmmffffff"));
            //}
            //else if (uqnmbr > 0)
            //{
            //    UniquenmbrforSB = Convert.ToDecimal(DateTime.Now.ToString("yyMMddHHmmssmmffffff"));
            //    //string dbd = uqnmbr.ToString().Substring(0, 6);
            //    //string cd = DateTime.Now.ToString("yyMMdd");
            //    //if (dbd == cd)
            //    //{
            //    //    UniquenmbrforSB = Convert.ToDecimal(DateTime.Now.ToString("yyMMddHHmmssmmffffff"));
            //    //    //UniquenmbrforSB = Convert.ToDecimal(DateTime.Now.ToString("yyMMddHHmmssmmffffff"))
            //    //    //    +  Convert.ToDecimal(uqnmbr.ToString().Substring(20, uqnmbr.ToString().Length - 20))+1;   
            //    //}
            //    //else if (cd != dbd)
            //    //{
            //    //    UniquenmbrforSB = Convert.ToDecimal(DateTime.Now.ToString("yyMMddHHmmssmmffffff") );
            //    //}
            //}
            return UniquenmbrforSB;
        }

        private DataSet AccountStatmentView()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Account_Statement_Reading"),
                new SqlParameter("@FileNo",txtFile_No_.Text)
                //new SqlParameter("@userID",Models.clsUser.ID)
            };


            DataSet d_s_t = Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);
            return d_s_t;
        }

        private double StampFees()
        {
            #region Stamp Duty Calculation
            double stampDutyAmount = 0;
            decimal stmdtyfee_minus = Convert.ToDecimal(txtStmDtyFee_minus.Text == "" ? "0" : txtStmDtyFee_minus.Text);
            SqlParameter[] prm_ =
            {
                        new SqlParameter("@Task","Select_Stamp_Duty_NotUse_NDC"),
                        new SqlParameter("@FileNo",txtFile_No_.Text)
                        };
            DataSet dst_ = new DataSet();
            dst_ = cls_dl_StampDuty.StampDuty_Reader(prm_);
            if (dst_.Tables.Count > 0)
            {
                if (dst_.Tables[0].Rows.Count > 0)
                {
                    stampDutyAmount = 0;
                }
                else
                {
                    if (txtFile_No_.Text.ToUpper().Contains("A/RES/") || txtFile_No_.Text.ToUpper().Contains("OLO/A/RES/"))
                    {
                        stampDutyAmount = Convert.ToDouble(48000 - stmdtyfee_minus);

                    }
                    if (txtFile_No_.Text.ToUpper().Contains("B/RES/") || txtFile_No_.Text.ToUpper().Contains("OLO/B/RES/"))
                    {
                        stampDutyAmount = Convert.ToDouble(24000 - stmdtyfee_minus);

                    }
                    else if (txtFile_No_.Text.ToUpper().Contains("C/RES/") || txtFile_No_.Text.ToUpper().Contains("OLO/C/RES/") || txtFile_No_.Text.ToUpper().Contains("C/RES/APS"))
                    {
                        stampDutyAmount = Convert.ToDouble(12000 - stmdtyfee_minus);

                    }
                    else if (txtFile_No_.Text.ToUpper().Contains("E/RES/") || txtFile_No_.Text.ToUpper().Contains("OLO/E/RES/"))
                    {
                        stampDutyAmount = Convert.ToDouble(6000 - stmdtyfee_minus);

                    }
                    else if (txtFile_No_.Text.ToUpper().Contains("OLO/H/COM/"))
                    {
                        stampDutyAmount = Convert.ToDouble(8000 - stmdtyfee_minus);

                    }
                    else if (txtFile_No_.Text.ToUpper().Contains("D/RES/") || txtFile_No_.Text.ToUpper().Contains("OLO/D/RES/"))
                    {
                        stampDutyAmount = Convert.ToDouble(9600 - stmdtyfee_minus);
                    }
                    else if (txtFile_No_.Text.ToUpper().Contains("G/COM/"))
                    {
                        stampDutyAmount = Convert.ToDouble(16000 - stmdtyfee_minus);

                    }
                }

            }

            #endregion
            return stampDutyAmount;
        }

        private void btnView__Click(object sender, EventArgs e)
        {
            string chalanNo = txtDHAPChNo_;
            frmReceInstSearch frmobj = new frmReceInstSearch(chalanNo);
            frmobj.ShowDialog();
        }
        private void btnNDCCreate__Click(object sender, EventArgs e)
        {
            try
            {
                FBRFilerandNonFilerCheck(NDCID);
                btnrefres_Click(null, null);
                chkCorporate_Check_ = chkCorporate.Checked ? "Yes" : "No";
                urgentNDC_Check_ = chk_urgentNDC_.Checked ? "Yes" : "No";
                urgentTFR_Check_ = chk_UrgentTransfer_.Checked ? "Yes" : "No";
                OutStationCHarges_Check_ = chk_OutStationCharges_.Checked ? "Yes" : "No";
                // rdbHiba    rdbLegalHeirCivil   rdbLegalHeirSvc
                if (rdbNormal.IsChecked) { TfrNormalHiba_Check = "Normal"; }
                else if (rdbHiba.IsChecked) { TfrNormalHiba_Check = "Hiba"; }
                else if (rdbLegalHeirCivil.IsChecked) { TfrNormalHiba_Check = "LegalHeirCivil"; }
                else if (rdbLegalHeirSvc.IsChecked) { TfrNormalHiba_Check = "LegalHeirSvc"; }
                // TfrNormalHiba_Check = rdbNormal.IsChecked ? "Normal" : "Hiba";
                ReissueNDC_Check_ = chkNDCReissue.Checked ? "Yes" : "No";
                MembershipFormFeeSkipInclude_ = chbMembershipFormFeeSkip.Checked ? "SkipMembershipFormFee" : "IncludeMembershipFormFee";
                #region NDC Update

                dtpIssueDate_.Value = DateTime.Now;
                dtpNDCExpire_.Value = DateTime.Now.AddDays(60);

                if (txtStampDuty_.Text != "" && txtDDNo_ != "" && txtDHAPChNo_ != "" && (buyerCheckFiler == true || buyerCheckNonFiler == true) && (sellerrCheckFiler == true || sellerrCheckNonFiler == true))
                {
                    try
                    {
                        SqlParameter[] param =
                        {
                                new SqlParameter("@ndc_no",NDCID),
                                new SqlParameter("@FileNo",txtFile_No_.Text),
                                new SqlParameter(){ ParameterName = "@tbl_NDC",SqlDbType = SqlDbType.Structured, SqlValue = NDC_Table_()},
                                new SqlParameter() { ParameterName = "@tbl_File_Seller_Buyer", SqlDbType = SqlDbType.Structured, SqlValue = File_Seller_Buyer_Table_() },
                                 new SqlParameter("@UserName",clsUser.Name),
                                 new SqlParameter("@userID", clsUser.ID)
                            };
                        int result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDC_ConvertforTransfer", param);
                        if (result > 0)
                        {
                            this.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please Clear all the Dues and Checks.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnNDCCreate__Click.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }

        }
        private DataTable NDC_Table_()
        {
            DataTable NDCTbl = new DataTable();
            string ndcType = "";
            if (rdbHiba.IsChecked) { ndcType = "Hiba"; }
            else if (rdbNormal.IsChecked) { ndcType = "Normal"; }
            else if (rdbLegalHeirCivil.IsChecked) { ndcType = "LegalHeirCivil"; }
            else if (rdbLegalHeirSvc.IsChecked) { ndcType = "LegalHeirSvc"; }
            string ndcTypeNormalUrgent = chk_urgentNDC_.Checked ? "Urgent" : "Normal";
            string TfrType = chk_UrgentTransfer_.Checked ? "Urgent" : "Normal";
            string outstation = chk_OutStationCharges_.Checked ? "Yes" : "No";
            string mbrtype = "";
            if (rdbsngl.IsChecked) { mbrtype = "Single"; }
            else if (rdbDual.IsChecked) { mbrtype = "Dual"; }
            else if (rdbTrple.IsChecked) { mbrtype = "Triple"; }
            else if (rdbQuad.IsChecked) { mbrtype = "Quad"; }

            //bool corporate = false;
            //string MembershipType = "";
            //decimal TFRFee_Waive = 0;
            //decimal MbrFee_Waive = 0;
            //decimal MbrFeeForm_Waive = 0;
            //decimal StmDtyFee_Waive = 0;
            //decimal FBR_Fee_Waive = 0;
            //bool FBR_Skip_On_Seller = false;
            //decimal FBRTaxAmountSeller_Discount = 0;
            //decimal FBRTaxAmountBuyer_Discount = 0;

            try
            {
                #region DataTable_Column Creation

                DataTable_column NDC_No = new DataTable_column() { ColmnName = "NDC_No", type = typeof(int) };
                DataTable_column DateIssue = new DataTable_column() { ColmnName = "DateIssue", type = typeof(DateTime) };
                DataTable_column DHAP_Challan_No = new DataTable_column() { ColmnName = "DHAP_Challan_No", type = typeof(string) };
                DataTable_column Seller_Amount = new DataTable_column() { ColmnName = "Seller_Amount", type = typeof(float) };
                DataTable_column Seller_Account_No = new DataTable_column() { ColmnName = "Seller_Account_No", type = typeof(string) };
                DataTable_column Purchaser_Amount = new DataTable_column() { ColmnName = "Purchaser_Amount", type = typeof(float) };
                DataTable_column Purchase_Account_No = new DataTable_column() { ColmnName = "Purchase_Account_No", type = typeof(string) };
                DataTable_column DDNoPOReceipt = new DataTable_column() { ColmnName = "DDNoPOReceipt", type = typeof(string) };
                DataTable_column Bank = new DataTable_column() { ColmnName = "Bank", type = typeof(string) };
                DataTable_column Purcsr_Payment_Date = new DataTable_column() { ColmnName = "Purcsr_Payment_Date", type = typeof(DateTime) };
                DataTable_column FilePlotNo = new DataTable_column() { ColmnName = "FilePlotNo", type = typeof(string) };
                DataTable_column Street_LaneNo = new DataTable_column() { ColmnName = "Street_LaneNo", type = typeof(string) };
                DataTable_column Sector = new DataTable_column() { ColmnName = "Sector", type = typeof(string) };
                DataTable_column Phase = new DataTable_column() { ColmnName = "Phase", type = typeof(string) };
                DataTable_column NDCType = new DataTable_column() { ColmnName = "NDCType", type = typeof(string) };
                DataTable_column WHTax_us_236_C_Amount = new DataTable_column() { ColmnName = "WHTax_us_236_C_Amount", type = typeof(string) };
                DataTable_column StampDuty = new DataTable_column() { ColmnName = "StampDuty", type = typeof(string) };
                DataTable_column FileKey = new DataTable_column() { ColmnName = "FileKey", type = typeof(int) };
                DataTable_column userID = new DataTable_column() { ColmnName = "userID", type = typeof(int) };
                DataTable_column Remarks = new DataTable_column() { ColmnName = "Remarks", type = typeof(string) };
                DataTable_column StatusofNDC = new DataTable_column() { ColmnName = "StatusofNDC", type = typeof(string) };
                DataTable_column NDCExpireDate = new DataTable_column() { ColmnName = "NDCExpireDate", type = typeof(string) };
                DataTable_column stmpDutyID = new DataTable_column() { ColmnName = "stmpDutyID", type = typeof(int) };
                DataTable_column NDCTypeNormalUrgent = new DataTable_column() { ColmnName = "NDCTypeNormalUrgent", type = typeof(string) };
                DataTable_column RequestedBy = new DataTable_column() { ColmnName = "RequestedBy", type = typeof(string) };
                DataTable_column TFRType = new DataTable_column() { ColmnName = "TFRType", type = typeof(string) };
                DataTable_column OutStationCharges = new DataTable_column() { ColmnName = "OutStationCharges", type = typeof(string) };
                DataTable_column UNFChallanID = new DataTable_column() { ColmnName = "UNFChallanID", type = typeof(int) };
                DataTable_column UNFChallanNo = new DataTable_column() { ColmnName = "UNFChallanNo", type = typeof(string) };
                DataTable_column UTFChallanID = new DataTable_column() { ColmnName = "UTFChallanID", type = typeof(int) };
                DataTable_column UTFChallanNo = new DataTable_column() { ColmnName = "UTFChallanNo", type = typeof(string) };
                DataTable_column UALFChallanID = new DataTable_column() { ColmnName = "UALFChallanID", type = typeof(int) };
                DataTable_column UALFChallanNo = new DataTable_column() { ColmnName = "UALFChallanNo", type = typeof(string) };
                DataTable_column NDCCategory = new DataTable_column() { ColmnName = "NDCCategory", type = typeof(string) };

                DataTable_column Corporate = new DataTable_column() { ColmnName = "Corporate", type = typeof(bool) };
                DataTable_column MembershipType = new DataTable_column() { ColmnName = "MembershipType", type = typeof(string) };
                DataTable_column TFRFee_Waive = new DataTable_column() { ColmnName = "TFRFee_Waive", type = typeof(decimal) };
                DataTable_column MbrFee_Waive = new DataTable_column() { ColmnName = "MbrFee_Waive", type = typeof(decimal) };
                DataTable_column MbrFeeForm_Waive = new DataTable_column() { ColmnName = "MbrFeeForm_Waive", type = typeof(decimal) };
                DataTable_column StmDtyFee_Waive = new DataTable_column() { ColmnName = "StmDtyFee_Waive", type = typeof(decimal) };
                DataTable_column SkipMbrShipFormFee = new DataTable_column() { ColmnName = "SkipMbrShipFormFee", type = typeof(bool) };
                DataTable_column PlotHoldGreaterThen3Years = new DataTable_column() { ColmnName = "PlotHoldGreaterThen3Years", type = typeof(bool) };
                //DataTable_column FBR_Fee_Waive = new DataTable_column() { ColmnName = "FBR_Fee_Waive", type = typeof(decimal) };
                //DataTable_column FBR_Skip_On_Seller = new DataTable_column() { ColmnName = "FBR_Skip_On_Seller", type = typeof(bool) };
                //DataTable_column FBRTaxAmountSeller_Discount = new DataTable_column() { ColmnName = "FBRTaxAmountSeller_Discount", type = typeof(decimal) };
                //DataTable_column FBRTaxAmountBuyer_Discount = new DataTable_column() { ColmnName = "FBRTaxAmountBuyer_Discount", type = typeof(decimal) };



                #endregion
                #region Insert DataTabl_Column in List, and Send to Helper to make DataTable
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(NDC_No);
                colmn.Add(DateIssue);
                colmn.Add(DHAP_Challan_No);
                colmn.Add(Seller_Amount);
                colmn.Add(Seller_Account_No);
                colmn.Add(Purchaser_Amount);
                colmn.Add(Purchase_Account_No);
                colmn.Add(DDNoPOReceipt);
                colmn.Add(Bank);
                colmn.Add(Purcsr_Payment_Date);
                colmn.Add(FilePlotNo);
                colmn.Add(Street_LaneNo);
                colmn.Add(Sector);
                colmn.Add(Phase);
                colmn.Add(NDCType);
                colmn.Add(WHTax_us_236_C_Amount);
                colmn.Add(StampDuty);
                colmn.Add(FileKey);
                colmn.Add(userID);
                colmn.Add(Remarks);
                colmn.Add(StatusofNDC);
                colmn.Add(NDCExpireDate);
                colmn.Add(stmpDutyID);
                colmn.Add(NDCTypeNormalUrgent);
                colmn.Add(RequestedBy);
                colmn.Add(TFRType);
                colmn.Add(OutStationCharges);
                colmn.Add(UNFChallanID);
                colmn.Add(UNFChallanNo);
                colmn.Add(UTFChallanID);
                colmn.Add(UTFChallanNo);
                colmn.Add(UALFChallanID);
                colmn.Add(UALFChallanNo);
                colmn.Add(NDCCategory);

                colmn.Add(Corporate);
                colmn.Add(MembershipType);
                colmn.Add(TFRFee_Waive);
                colmn.Add(MbrFee_Waive);
                colmn.Add(MbrFeeForm_Waive);
                colmn.Add(StmDtyFee_Waive);

                colmn.Add(SkipMbrShipFormFee);
                colmn.Add(PlotHoldGreaterThen3Years);
                //colmn.Add(FBR_Fee_Waive);
                //colmn.Add(FBR_Skip_On_Seller);
                //colmn.Add(FBRTaxAmountSeller_Discount);
                //colmn.Add(FBRTaxAmountBuyer_Discount);


                NDCTbl = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                #endregion
                #region Insertion in DataTable
                DataRow row = NDCTbl.NewRow();
                row["NDC_No"] = NDCID == 0 ? 0 : NDCID;
                row["DateIssue"] = dtpIssueDate_.Value;
                row["DHAP_Challan_No"] = txtDHAPChNo_;
                row["Seller_Amount"] = (txtSellerAmount_ == "" ? "0" : txtSellerAmount_);
                row["Seller_Account_No"] = txtSelerAccNo_;
                row["Purchaser_Amount"] = txtChalnAmount_;
                row["Purchase_Account_No"] = "TFR Fee";//txtPrcsrACCNo_;
                row["DDNoPOReceipt"] = txtDDNo_;
                row["Bank"] = txtBank_;
                row["Purcsr_Payment_Date"] = dtpPaymntDate_ == "" ? DateTime.Now.ToString("yyyy-MM-dd") : dtpPaymntDate_;
                row["FilePlotNo"] = txtFile_No_.Text.ToUpper();
                row["Street_LaneNo"] = "";
                row["Sector"] = txtSector_.Text;
                row["Phase"] = txtPhase_.Text;
                row["NDCType"] = ndcType;   /// Here in variable name  "WHTax_us_236_K_Amount" we pass the NDC Type
                row["WHTax_us_236_C_Amount"] = "";
                row["StampDuty"] = txtStampDuty_.Text;
                row["FileKey"] = FileKeyID;
                row["userID"] = Models.clsUser.ID;
                row["Remarks"] = txtRemarks_.Text;
                row["StatusofNDC"] = "Incomplete";
                row["NDCExpireDate"] = dtpNDCExpire_.Value.ToString("yyyy-MM-dd");
                row["stmpDutyID"] = stmdtID_;
                row["NDCTypeNormalUrgent"] = ndcTypeNormalUrgent;
                row["RequestedBy"] = reqstdby;
                row["TFRType"] = TfrType;
                row["OutStationCharges"] = outstation;
                row["UNFChallanID"] = UNF_ChallanID;
                row["UNFChallanNo"] = UNF_ChallanNo;
                row["UTFChallanID"] = UTF_ChallanID;
                row["UTFChallanNo"] = UTF_ChallanNo;
                row["UALFChallanID"] = UALF_ChallanID;
                row["UALFChallanNo"] = UALF_ChallanNo;
                row["NDCCategory"] = "NormalNDC";

                row["Corporate"] = chkCorporate.Checked ? true : false;
                row["MembershipType"] = mbrtype;
                row["TFRFee_Waive"] = txtTFRFee_minus.Text;
                row["MbrFee_Waive"] = txtmbrfee_minus.Text;
                row["MbrFeeForm_Waive"] = txtMbrFrmFee_minus.Text;
                row["StmDtyFee_Waive"] = txtStmDtyFee_minus.Text;

                row["SkipMbrShipFormFee"] = chbMembershipFormFeeSkip.Checked ? true : false;
                row["PlotHoldGreaterThen3Years"] = chkSellerhavePlotmorethen3years.Checked ? true : false;
                //row["FBR_Fee_Waive"] = txtFBRFee_minus.Text;
                //row["FBR_Skip_On_Seller"] = chkFBRSellerSkip.Checked ? "Yes" : "No";
                //row["FBRTaxAmountSeller_Discount"] = txtsellerdiscount.Text;
                //row["FBRTaxAmountBuyer_Discount"] = txtbuyerdiscount.Text;


                NDCTbl.Rows.Add(row);
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on NDC_Table_.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }

            return NDCTbl;
        }
        private DataTable File_Seller_Buyer_Table_()
        {
            DataTable File_Seller_Buyer_Tbl = new DataTable();
            try
            {
                #region DataTable_Column Creation
                DataTable_column SBID = new DataTable_column() { ColmnName = "SBID", type = typeof(int) };
                DataTable_column MemberID = new DataTable_column() { ColmnName = "MemberID", type = typeof(int) };
                DataTable_column MSNo = new DataTable_column() { ColmnName = "MSNo", type = typeof(string) };
                DataTable_column Name = new DataTable_column() { ColmnName = "Name", type = typeof(string) };
                DataTable_column MobileNo = new DataTable_column() { ColmnName = "MobileNo", type = typeof(string) };
                DataTable_column Father_Husband_Name = new DataTable_column() { ColmnName = "Father_Husband_Name", type = typeof(string) };
                DataTable_column Address = new DataTable_column() { ColmnName = "Address", type = typeof(string) };
                DataTable_column CNIC = new DataTable_column() { ColmnName = "CNIC", type = typeof(string) };
                DataTable_column Type = new DataTable_column() { ColmnName = "Type", type = typeof(string) };
                DataTable_column NDCRnChallanStatus = new DataTable_column() { ColmnName = "NDCRnChallanStatus", type = typeof(string) };
                #endregion
                #region Insert DataTabl_Column in List, and Send to Helper to make DataTable
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(SBID);
                colmn.Add(MemberID);
                colmn.Add(MSNo);
                colmn.Add(Name);
                colmn.Add(MobileNo);
                colmn.Add(Father_Husband_Name);
                colmn.Add(Address);
                colmn.Add(CNIC);
                colmn.Add(Type);
                colmn.Add(NDCRnChallanStatus);
                File_Seller_Buyer_Tbl = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                #endregion
                ////if (NDCRenewChallanStatus == "ApplyForRenewalNDC")
                #region Insertion in DataTable
                int rowcount = grdSeller_Buyer.Rows.Count;
                for (int i = 0; i < rowcount; i++)
                {
                    DataRow seller_row = File_Seller_Buyer_Tbl.NewRow();// Create Row for Seller Data
                    seller_row["SBID"] = grdSeller_Buyer.Rows[i].Cells["SBID"].Value == null ? 0 : grdSeller_Buyer.Rows[i].Cells["SBID"].Value;
                    seller_row["MemberID"] = grdSeller_Buyer.Rows[i].Cells["ID"].Value == null ? 0 : grdSeller_Buyer.Rows[i].Cells["ID"].Value;
                    seller_row["MSNo"] = grdSeller_Buyer.Rows[i].Cells["MembershipNo"].Value == null ? "" : grdSeller_Buyer.Rows[i].Cells["MembershipNo"].Value;
                    seller_row["Name"] = grdSeller_Buyer.Rows[i].Cells["Name"].Value;
                    seller_row["MobileNo"] = grdSeller_Buyer.Rows[i].Cells["MobileNo"].Value;
                    seller_row["Father_Husband_Name"] = grdSeller_Buyer.Rows[i].Cells["Father"].Value;
                    seller_row["Address"] = grdSeller_Buyer.Rows[i].Cells["Address"].Value;
                    seller_row["CNIC"] = grdSeller_Buyer.Rows[i].Cells["CNIC"].Value;
                    seller_row["Type"] = grdSeller_Buyer.Rows[i].Cells["Type"].Value;
                    if (NDCRenewChallanStatus == "ApplyForRenewalNDC")
                    {
                        seller_row["NDCRnChallanStatus"] = "ApplyForRenewalNDC";
                    }
                    else
                    {
                        seller_row["NDCRnChallanStatus"] = "";
                    }
                    File_Seller_Buyer_Tbl.Rows.Add(seller_row);
                }
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on File_Seller_Buyer_Table_.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }

            return File_Seller_Buyer_Tbl;
        }
        private void grdSeller_Buyer_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "BuyerSeller_Mod")
                {
                    string type = grdSeller_Buyer.CurrentRow.Cells["Type"].Value.ToString();
                    //if (type == "Buyer")
                    //{
                    SB_ID = int.Parse(grdSeller_Buyer.CurrentRow.Cells["SBID"].Value.ToString());
                    frm_NDC_Modify_FileSellerBuyerInfo frmobj = new frm_NDC_Modify_FileSellerBuyerInfo(SB_ID);
                    frmobj.ShowDialog();
                    InCaseOfUpdate();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Sorry ! Here you can Only Change the Buyer Information.");
                    //}
                }
                if (e.Column.Name == "BuyerSeller_Add")
                {
                    string type = grdSeller_Buyer.CurrentRow.Cells["Type"].Value.ToString();
                    if (type == "Buyer")
                    {
                        frm_NDC_Modify_FileSellerBuyerInfo frmobj = new frm_NDC_Modify_FileSellerBuyerInfo(NDCID.ToString());
                        frmobj.ShowDialog();
                        InCaseOfUpdate();
                    }
                    else
                    {
                        MessageBox.Show("Sorry ! Here you can Only Add the Buyer Information.");
                    }
                }
                if (e.Column.Name == "mdfy_dmy_buyer")
                {
                    buyerCheckFiler = false;
                    buyerCheckNonFiler = false;
                    sellerrCheckFiler = false;
                    sellerrCheckNonFiler = false;
                    string type = e.Row.Cells["Type"].Value.ToString();
                    if (type == "Buyer")
                    {
                        string cnic = e.Row.Cells["CNIC"].Value.ToString();

                        SqlParameter[] prm =
                        {
                        new SqlParameter("@Task","CheckBuyerInStampDuty"),
                        new SqlParameter("@FileNo",txtFile_No_.Text),
                        new SqlParameter("@SBCNIC",cnic)
                        };
                        DataSet dst = new DataSet();
                        dst = cls_dl_NDC.NdcRetrival(prm);
                        if (dst.Tables.Count > 0)
                        {
                            if (dst.Tables[0].Rows.Count > 0 || dst.Tables[1].Rows.Count > 0)
                            {
                                MessageBox.Show("Please Correct this record in" + Environment.NewLine
                                    + "StampDuty / FBR Module also.", "Warning !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                frm_AddDummyBuyer frm = new frm_AddDummyBuyer(txtFile_No_.Text, cnic, "Modify");
                                frm.ShowDialog();
                                Select_CurrentOwner_Info_Against_FileNo_("Modify Dummy Buyer");
                            }
                            else
                            {
                                frm_AddDummyBuyer frm = new frm_AddDummyBuyer(txtFile_No_.Text, cnic, "Modify");
                                frm.ShowDialog();
                                Select_CurrentOwner_Info_Against_FileNo_("Modify Dummy Buyer");
                            }

                        }
                        else
                        {
                            frm_AddDummyBuyer frm = new frm_AddDummyBuyer(txtFile_No_.Text, cnic, "Modify");
                            frm.ShowDialog();
                            Select_CurrentOwner_Info_Against_FileNo_("Modify Dummy Buyer");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Updation in Seller record is not allowed here.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdSeller_Buyer_CellClick.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }

        }
        private void Clear()
        {
            txtFile_No_.Text = "";
            txtDDNo_ = "";
            txtSellerAmount_ = "";
            txtSelerAccNo_ = "";
            txtDHAPChNo_ = "";
            txtPrcsrACCNo_ = "";
            txtBank_ = "";
            txtChalnAmount_ = "";
            drpStmpRefNo_.Text = "";
            txtSector_.Text = "";
            txtRemarks_.Text = "";
            txtPhase_.Text = "";
            txtStampDuty_.Text = "";
            txtDealValue.Text = "";
            chk_urgentNDC_.CheckState = CheckState.Unchecked;
            chk_UrgentTransfer_.CheckState = CheckState.Unchecked;
            chk_OutStationCharges_.CheckState = CheckState.Unchecked;
            chbMembershipFormFeeSkip.CheckState = CheckState.Unchecked;
            chkSellerhavePlotmorethen3years.CheckState = CheckState.Unchecked;
            //if(rdbNormal.IsChecked)
            rdbNormal.CheckState = CheckState.Checked;
            grdSeller_Buyer.DataSource = null;
            grdCPRData.DataSource = null;
            ddn.Text = "#";
            ddmnt.Text = "#";
            chno.Text = "#";
            chm.Text = "#";
            rdbdealer.CheckState = CheckState.Unchecked;
            rdbPlotOwner.CheckState = CheckState.Checked;
            rdbPlotOwner_CheckStateChanged(null, null);
            btnReset_Click(null, null);
            chkenable.CheckState = CheckState.Unchecked;
            txtTFRFee_minus.Text = "0";
            txtmbrfee_minus.Text = "0";
            txtMbrFrmFee_minus.Text = "0";
            txtStmDtyFee_minus.Text = "0";
            txtFBRFee_minus.Text = "0";
            buyerCheckFiler = false;
            buyerCheckNonFiler = false;
            sellerrCheckFiler = false;
            sellerrCheckNonFiler = false;
            rdbHiba.CheckState = CheckState.Unchecked;
            rdbLegalHeirCivil.CheckState = CheckState.Unchecked;
            rdbLegalHeirSvc.CheckState = CheckState.Unchecked;
            chkNDCReissue.CheckState = CheckState.Unchecked;
            chkCorporate.CheckState = CheckState.Unchecked;
            UNF_ChallanID = 0;
            UNF_ChallanNo = "";
            UTF_ChallanID = 0;
            UTF_ChallanNo = "";
            UALF_ChallanID = 0;
            UALF_ChallanNo = "";

        }


        private void drpStmpRefNo__SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //if (drpStmpRefNo_.SelectedIndex > 0)
            //{
            //    string stmstr = drpStmpRefNo_.SelectedItem.ToString();
            //    var query = from r in dst.Tables[0].AsEnumerable()
            //                where r.Field<string>("RefNo") == stmstr
            //                let objectArray = new object[]
            //                {
            //                 r.Field<Decimal>("Amount"),
            //                 r.Field<int>("StmpDuty_ID")
            //                }
            //                select objectArray;

            //    foreach (var array in query)
            //    {
            //        txtStampDuty_.Text = array[0].ToString();
            //        stmdtID_ = int.Parse(array[1].ToString());
            //    }
            //}
            //else
            //{
            //    txtStampDuty_.Text = "";
            //}
        }
        private void grpBInfo_Click(object sender, EventArgs e)
        {

        }
        private void btn_Surcharge_Click(object sender, EventArgs e)
        {
            frmRecePayment frmobj = new frmRecePayment();
            frmobj.ShowDialog();
        }
        private void btn_StampDuty_Click(object sender, EventArgs e)
        {
            StampDuty.frmStampDuty_Create frmobj = new StampDuty.frmStampDuty_Create();
            frmobj.ShowDialog();
        }
        private void btn_Surchchalinst_Click(object sender, EventArgs e)
        {
            frmRecePayment frmo = new frmRecePayment();
            frmo.ShowDialog();
        }
        private void btnstampduty_Click(object sender, EventArgs e)
        {
            StampDuty.frmStampDuty_Create frmon = new StampDuty.frmStampDuty_Create();
            frmon.ShowDialog();
        }

        private void grdSeller_Buyer_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "CNIC")
                {
                    object typ = e.Row.Cells["Type"].Value.ToString() == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : e.Row.Cells["Type"].Value.ToString();

                    if (typ.ToString() == "Buyer")
                    {
                        string nic = e.Row.Cells["CNIC"].Value.ToString();
                        Bind_Stamp_Duty_Ref(nic, txtFile_No_.Text);
                    }
                }
                else if (e.Column.Name == "NTN")
                {
                    object ntn = e.Row.Cells["NTN"].Value.ToString() == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : e.Row.Cells["NTN"].Value.ToString();
                    if (!string.IsNullOrEmpty(ntn.ToString()))
                    {
                        object typ = e.Row.Cells["Type"].Value.ToString() == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : e.Row.Cells["Type"].Value.ToString();
                        if (typ.ToString() == "Seller")
                        {
                            string mbspNO = e.Row.Cells["MembershipNo"].Value.ToString();
                            string NTNNumber = e.Row.Cells["NTN"].Value.ToString();
                            SqlParameter[] prmtr =
                            {
                            new SqlParameter("@Task","GetNTNNumber"),
                            new SqlParameter("@MembershipNo",mbspNO),
                            new SqlParameter("@NTN",NTNNumber)
                        };
                            DataSet dst = cls_dl_Membership.Membership_PersonalInfo_Retrive(prmtr);
                            if (dst.Tables[0].Rows[0]["NTNMessage"].ToString() == "NTN Already Exist.")
                            {

                            }
                            else
                            {
                                MessageBox.Show(dst.Tables[0].Rows[0]["NTNMessage"].ToString());
                                btnloadgrid_Click(sender, e);
                            }
                        }
                        else if (typ.ToString() == "Buyer")
                        {
                            MessageBox.Show("Please Update Buyer record in Buyer Partion.");
                        }
                    }



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.InnerException);
            }


        }



        private void btn_ChallanCreate_Click(object sender, EventArgs e)
        {
            frmCreateChallan frm = new frmCreateChallan();
            frm.ShowDialog();
        }



        private void txtWHTc__Leave(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","check_WHTC_CPRNo"),
                new SqlParameter("@WHTax_us_236_C_Amount",""),
                new SqlParameter("@FileNo",txtFile_No_.Text)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_NDC.NdcRetrival(prm);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    //btnNDCCreate_.Enabled = false;
                    //txtWHTk_.Enabled = false;
                    MessageBox.Show("CPR No." + "" + " is used against File No." + txtFile_No_.Text + ",Please try another.");

                }
                else
                {
                    //txtWHTk_.Enabled = true;
                    //btnNDCCreate_.Enabled = true;
                }
            }
            else
            {
                //txtWHTk_.Enabled = true;
                //btnNDCCreate_.Enabled = true;
            }
        }

        private void txtWHTk__Leave(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","check_WHTK_CPRNo"),
                new SqlParameter("@WHTax_us_236_K_Amount",""),
                new SqlParameter("@FileNo",txtFile_No_.Text)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_NDC.NdcRetrival(prm);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    //btnNDCCreate_.Enabled = false;
                    MessageBox.Show("CPR No." + "" + " is used against File No." + txtFile_No_.Text + ",Please try another.");
                    //txtWHTk_.Text = "";
                }
                else
                {
                    //btnNDCCreate_.Enabled = true;
                }
            }
            else
            {
                //btnNDCCreate_.Enabled = true;
            }
        }

        private void btnFindFBR_Click(object sender, EventArgs e)
        {

        }
        private DataSet FBROwnerTypeChecking(string buyerstring, string sellerstring)
        {
            string type = "";
            SqlParameter[] prm =
               {
                new SqlParameter("@Task","FBR_Owner_Type_Checking"),
                new SqlParameter("@BuyerString",buyerstring),
                new SqlParameter("@SellerString",sellerstring)
                };
            DataSet dst = new DataSet();
            dst = cls_dl_NDC.NdcRetrival(prm);
            return dst;
        }

        private void rdbFBR_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                string snm = "";
                decimal smtpPort = 0;
                grdCPRData.DataSource = null;
                if (rdbFBR.IsChecked)
                {
                    SqlParameter[] pr =
                    {
                        new SqlParameter("@Task","FindSector"),
                        new SqlParameter("@FileNo",txtFile_No_.Text)
                    };
                    DataSet d_s_t = cls_dl_NDC.NdcRetrival(pr);
                    if (d_s_t.Tables.Count > 0)
                    {
                        if (d_s_t.Tables[0].Rows.Count > 0)
                        {
                            snm = d_s_t.Tables[0].Rows[0]["Sector"].ToString();
                        }
                    }



                    if (txtFile_No_.Text.ToUpper().Contains("/COM/"))
                    {
                        if (snm == "ABC")
                        {
                            smtpPort = Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarla_ComABC"]);
                        }
                        else if (snm == "Other")
                        {
                            smtpPort = Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarla_ComOther"]);
                        }

                    }
                    else
                    {
                        if (snm == "ABC")
                        {
                            smtpPort = Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarlaABC"]);
                        }
                        else if (snm == "Other")
                        {
                            smtpPort = Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarlaOther"]);
                        }
                    }



                    SqlParameter[] prtr =
                    {
                    new SqlParameter("@Task","CheckFileCategory"),
                    new SqlParameter("@FileNo",txtFile_No_.Text)
                    };
                    DataSet dts = cls_dl_NDC.NdcRetrival(prtr);
                    if (dts.Tables.Count > 0)
                    {
                        if (dts.Tables[0].Rows.Count > 0)
                        {
                            if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "4 Kanal" || dts.Tables[0].Rows[0]["PlotSize"].ToString() == "4 Kanal Com")
                            {
                                txtDealValue.Text = (smtpPort * 80).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "2 Kanal" || dts.Tables[0].Rows[0]["PlotSize"].ToString() == "2 Kanal Com")
                            {
                                txtDealValue.Text = (smtpPort * 40).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "1 Kanal" || dts.Tables[0].Rows[0]["PlotSize"].ToString() == "1 Kanal Com")
                            {
                                txtDealValue.Text = (smtpPort * 20).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "12 Marla" || dts.Tables[0].Rows[0]["PlotSize"].ToString() == "12 Marla Com")
                            {
                                txtDealValue.Text = (smtpPort * 12).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "16 Marla" || dts.Tables[0].Rows[0]["PlotSize"].ToString() == "16 Marla Com")
                            {
                                txtDealValue.Text = (smtpPort * 16).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "10 Marla" || dts.Tables[0].Rows[0]["PlotSize"].ToString() == "10 Marla Com")
                            {
                                txtDealValue.Text = (smtpPort * 10).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "8 Marla" || dts.Tables[0].Rows[0]["PlotSize"].ToString() == "8 Marla Com")
                            {
                                txtDealValue.Text = (smtpPort * 8).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "5 Marla" || dts.Tables[0].Rows[0]["PlotSize"].ToString() == "5 Marla Com")
                            {
                                txtDealValue.Text = (smtpPort * 5).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "4 Marla" || dts.Tables[0].Rows[0]["PlotSize"].ToString() == "4 Marla Com")
                            {
                                txtDealValue.Text = (smtpPort * 4).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else
                            {
                                MessageBox.Show("Un-Known File Category.");
                            }
                        }
                    }



                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FBROther_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                grdCPRData.DataSource = null;
                if (FBROther.IsChecked)
                {
                    txtDealValue.Text = "";
                    txtDealValue.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void grdSeller_Buyer_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            //if (e.Column.Name == "SelectOwner")
            //{
            //    string ControlAssignID = e.Row.Cells["ControlAssignID"].Value.ToString();
            //    bool status = (bool)e.Value;
            //    int ContorlAssingID = 0;
            //    bool M = int.TryParse(ControlAssignID, out ContorlAssingID);
            //    if (M != false)
            //    {
            //        SqlParameter[] parameter = {
            //                new SqlParameter("@Task", "UpdateControlAssignment"),
            //                new SqlParameter("@ControlAssignID",ContorlAssingID),
            //                new SqlParameter("@Status",status)
            //            };
            //        int result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_control", parameter);
            //    }
            //}
        }

        private void btnCheckSalePurchase_Click(object sender, EventArgs e)
        {
            //   #region
            //   SqlParameter[] parameter = {
            //   new SqlParameter("@Task", "CheckFBRDetail"),
            //   new SqlParameter("@FileNo",txtFile_No_.Text)
            //   };
            //   DataSet ds = cls_dl_NDC.NdcRetrival(parameter);
            //   if(ds.Tables.Count > 0)
            //   {
            //       if(ds.Tables[0].Rows.Count > 0)
            //       {
            //           buyerCheckFiler = true;
            //           buyerCheckNonFiler = true;
            //           sellerrCheckFiler = true;
            //           sellerrCheckNonFiler = true;
            //           MessageBox.Show("CPR Data is already Exist against this File No.");
            //           string dlt = ds.Tables[0].Rows[0]["DealType"].ToString();
            //           if (dlt == "FBR")
            //           {
            //               rdbFBR.CheckState = CheckState.Checked;
            //           }
            //           else
            //           {
            //               FBROther.CheckState = CheckState.Checked;
            //           }
            //           txtDealValue.Text = ds.Tables[0].Rows[0]["Deal_Amount"].ToString();

            //           for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //           {
            //               if (ds.Tables[0].Rows[i]["Type"].ToString() == "Seller")
            //               {
            //                   txtWHTc_.Text = ds.Tables[0].Rows[i]["CPRNo"].ToString();
            //                   txtwhtcAmount.Text = ds.Tables[0].Rows[i]["CPRTaxAmount"].ToString();
            //                   dtpwhtcDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"].ToString());
            //               }
            //               else
            //               {
            //                   txtWHTk_.Text = ds.Tables[0].Rows[i]["CPRNo"].ToString();
            //                   txtwhtkAmount.Text = ds.Tables[0].Rows[i]["CPRTaxAmount"].ToString();
            //                   dtpwhtkDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"].ToString());
            //               }
            //           }



            //       }
            //       else
            //       {
            //           #region 
            //           DataTable dtFBRD = new DataTable();
            //           DataTable dtFBRSB = new DataTable();
            //           foreach (GridViewRowInfo row in grdSeller_Buyer.Rows)
            //           {
            //               bool bl = Convert.ToBoolean(row.Cells["SelectOwner"].Value);
            //               if (bl == true)
            //               {
            //                   string cnic = row.Cells["CNIC"].Value.ToString();
            //                   string type = row.Cells["Type"].Value.ToString();

            //                   #region Buyer Part
            //                   if (type == "Buyer")
            //                   {
            //                       string fbrOwnerType = FBROwnerTypeChecking(cnic);
            //                       //lblFilerNonFiler.Text = fbrOwnerType;
            //                       if (fbrOwnerType == "Filer")
            //                       {
            //                           if (double.Parse(txtDealValue.Text) > 4000000.00)
            //                           {
            //                               CalculatedTaxBuyer = (Convert.ToUInt32(txtDealValue.Text) * 2) / 100;
            //                               buyerCheckFiler = true;
            //                           }
            //                           else
            //                           {
            //                               CalculatedTaxBuyer = 0;
            //                               buyerCheckFiler = true;
            //                           }
            //                       }
            //                       else //if (fbrOwnerType == "Non-Filer")
            //                       {
            //                           if (double.Parse(txtDealValue.Text) > 5000000.00)
            //                           {
            //                               MessageBox.Show("Buyer is not Valid to Purchase the File/Plot,"+ Environment.NewLine +
            //                                               "Because Non-Filer Purchaser is not allowed to Purchase a Plot,"+ Environment.NewLine +
            //                                               "having Deal value Greater then Rs.5000000.00","Information !",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            //                               btnNDCCreate_.Enabled = false;
            //                               buyerCheckNonFiler = false;
            //                           }
            //                           else if (double.Parse(txtDealValue.Text) > 4000000.00 && double.Parse(txtDealValue.Text) < 5000000.00)
            //                           {
            //                               CalculatedTaxBuyer = (Convert.ToUInt32(txtDealValue.Text) * 4) / 100;
            //                               buyerCheckNonFiler = true;
            //                           }
            //                           else if (double.Parse(txtDealValue.Text) < 4000000.00)
            //                           {
            //                               buyerCheckNonFiler = true;
            //                               CalculatedTaxBuyer = 0;
            //                           }
            //                       }

            //                   }
            //                   #endregion
            //                   #region Seller Part
            //                   else if (type == "Seller")
            //                   {
            //                       string st = "";
            //                       string prc = "";
            //                       string fbrOwnerType = FBROwnerTypeChecking(cnic);
            //                       //lblFilerNonFiler.Text = fbrOwnerType;
            //                       if (fbrOwnerType == "Filer")
            //                       {
            //                           CalculatedTaxSeller = (Convert.ToUInt32(txtDealValue.Text) * 1) / 100;
            //                           st = "1 % Tax is apply on Filer Seller, So :";
            //                           prc = "1 % ";
            //                           //sellerrCheckFiler = true;
            //                       }
            //                       else // if (fbrOwnerType == "Non-Filer")
            //                       {
            //                           CalculatedTaxSeller = (Convert.ToUInt32(txtDealValue.Text) * 2) / 100;
            //                           st = "2 % Tax is apply on Non-Filer Seller, So :";
            //                           prc = "2 % ";
            //                           //sellerrCheckNonFiler = true;
            //                       }

            //                       if (Convert.ToDouble(txtwhtcAmount.Text) >= CalculatedTaxSeller)
            //                       {
            //                           sellerrCheckFiler = true;
            //                       }
            //                       else
            //                       {

            //                           MessageBox.Show("Seller is not valid to Sold the Plot, Because "+ st + Environment.NewLine +
            //                               "Deal Value is : " + txtDealValue.Text + Environment.NewLine +
            //                               prc+"Tax Amount of "+ txtDealValue.Text+" is : " + CalculatedTaxSeller + Environment.NewLine +
            //                               "Submitted Tax Amount is : "+ txtwhtcAmount.Text + Environment.NewLine +
            //                               "Which is less then the Calculated "+ prc + " Tax Amount.","Information !",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            //                           btnNDCCreate_.Enabled = false;
            //                       }

            //                   }
            //                   #endregion

            //               }
            //           }
            //           #region  FBR Data and Seller Buyer Table Fillings
            //           if ((buyerCheckFiler == true || buyerCheckNonFiler == true) && (sellerrCheckFiler == true || sellerrCheckNonFiler == true))
            //           {
            //               //FBR Data Insertion
            //               dtFBRD.Clear();
            //               dtFBRD.Columns.Add("DealType");
            //               dtFBRD.Columns.Add("Deal_Amount");
            //               dtFBRD.Columns.Add("FileNo");
            //               dtFBRD.Columns.Add("Status");
            //               dtFBRD.Columns.Add("Remarks");
            //               DataRow drfd = dtFBRD.NewRow();
            //               drfd["DealType"] = rdbFBR.IsChecked ? "FBR" : "Other";
            //               drfd["Deal_Amount"] = txtDealValue.Text;
            //               drfd["FileNo"] = txtFile_No_.Text;
            //               drfd["Status"] = "Active";
            //               drfd["Remarks"] = "These Taxes are paid against NDC.";
            //               dtFBRD.Rows.Add(drfd);


            //               // FBR Seller Buyer Table
            //               dtFBRSB.Clear();
            //               dtFBRSB.Columns.Add("CNIC");
            //               dtFBRSB.Columns.Add("Name");
            //               dtFBRSB.Columns.Add("FatherName");
            //               dtFBRSB.Columns.Add("Type");
            //               dtFBRSB.Columns.Add("CPRNo");
            //               dtFBRSB.Columns.Add("CPRTaxAmount");
            //               dtFBRSB.Columns.Add("CalculatedTaxOnDealAmount");
            //               foreach (GridViewRowInfo rowInfo in grdSeller_Buyer.Rows)
            //               {
            //                   bool bl = Convert.ToBoolean(rowInfo.Cells["SelectOwner"].Value);

            //                   if (bl == true)
            //                   {
            //                       DataRow drfsb = dtFBRSB.NewRow();
            //                       string typ = rowInfo.Cells["Type"].Value.ToString();
            //                       if (typ == "Buyer")
            //                       {
            //                           drfsb["CNIC"] = rowInfo.Cells["CNIC"].Value.ToString();
            //                           drfsb["Name"] = rowInfo.Cells["Name"].Value.ToString();
            //                           drfsb["FatherName"] = rowInfo.Cells["Father"].Value.ToString();
            //                           drfsb["Type"] = typ;
            //                           drfsb["CPRNo"] = txtWHTk_.Text;
            //                           drfsb["CPRTaxAmount"] = txtwhtkAmount.Text;
            //                           drfsb["CalculatedTaxOnDealAmount"] = CalculatedTaxBuyer;

            //                       }
            //                       else if (typ == "Seller")
            //                       {
            //                           drfsb["CNIC"] = rowInfo.Cells["CNIC"].Value.ToString();
            //                           drfsb["Name"] = rowInfo.Cells["Name"].Value.ToString();
            //                           drfsb["FatherName"] = rowInfo.Cells["Father"].Value.ToString();
            //                           drfsb["Type"] = typ;
            //                           drfsb["CPRNo"] = txtWHTc_.Text;
            //                           drfsb["CPRTaxAmount"] = txtwhtcAmount.Text;
            //                           drfsb["CalculatedTaxOnDealAmount"] = CalculatedTaxSeller;
            //                       }
            //                       dtFBRSB.Rows.Add(drfsb);
            //                   }

            //               }
            //           }
            //           #endregion
            //           #region FBR Detail Insertion
            //           if (dtFBRD.Rows.Count > 0 && dtFBRSB.Rows.Count > 0)
            //           {
            //               SqlParameter[] prtr =
            //               {
            //                   new SqlParameter("@Task", "InsertFBRDetail"),
            //                   new SqlParameter(){ ParameterName = "@tbl_FBRData",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRD},
            //                   new SqlParameter(){ ParameterName = "@tbl_FBR_Seller_Buyer",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRSB}
            //              };
            //               int rslt = cls_dl_NDC.NdcNonQuery(prtr);
            //               if(rslt > 0)
            //               {
            //                   MessageBox.Show("FBR Data is Valid and Saved Successfully.");
            //               }
            //           }
            //           else
            //           {
            //              // MessageBox.Show("Both the Seller and Buyer Information are Required.");
            //           }
            //           #endregion
            //           #endregion
            //       }
            //   }

            //#endregion

        }

        private void btnGenerateSellerChallan_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdSeller_Buyer.RowCount > 0)
                {

                    string UrgentNDCCharges = chk_urgentNDC_.CheckState == CheckState.Checked ? "1" : "0";
                    string UrgentTFRCharges = chk_UrgentTransfer_.CheckState == CheckState.Checked ? "1" : "0";
                    string OutStationAllocationTFR = chk_OutStationCharges_.CheckState == CheckState.Checked ? "1" : "0";
                    string Sellcheck = rdSellerOST.CheckState == CheckState.Checked ? "1" : "0";
                    string Buyercheck = rdBuyerOST.CheckState == CheckState.Checked ? "1" : "0";

                    SqlParameter[] param = {
                                        new SqlParameter("@Task","GenerateChallanforSeller"),
                                        new SqlParameter("@File_No",txtFile_No_.Text),
                                        new SqlParameter("@UserID",clsUser.ID),
                                        new SqlParameter("@NDCUrgentFee",UrgentNDCCharges),
                                        new SqlParameter("@UrgentTFRFee",UrgentTFRCharges),
                                        new SqlParameter("@OutStationTFRFee",OutStationAllocationTFR),
                                        new SqlParameter("@OUTSTFee_Seller",Sellcheck),
                                        new SqlParameter("@OUTSTFee_Buyer",Buyercheck)

                    };
                    DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_NDC_Challan", param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string ChallanID = ds.Tables[0].Rows[0]["ChallanID"].ToString();
                            DataSet ChallanDataset = new DataSet();
                            SqlParameter[] prm3 =
                            {
                            new SqlParameter("@Task","GetChallReportDetail"),
                            new SqlParameter("@ChallanID",ChallanID)
                           };

                            ChallanDataset = cls_dl_Challan.Challan_Reader(prm3);
                            ChallanDataset _ds = new ChallanDataset();

                            _ds.Tables["tblChallan"].Merge(ChallanDataset.Tables[0], true, MissingSchemaAction.Ignore);
                            _ds.Tables["tblChallanDetail"].Merge(ChallanDataset.Tables[1], true, MissingSchemaAction.Ignore);
                            ChallanDataset = null;
                            frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                            obj.ShowDialog();
                        }
                    }
                    else
                    {
                        // throw new Exception();

                        MessageBox.Show("Seller & Buyer Information is missing. Kindly fill the Table OR Check the Remaing Due Amount .");
                    }

                }
                else
                {
                    MessageBox.Show("Seller & Buyer Information is missing. Kindly fill the Table.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //btnGenerateSellerChallan.Enabled = false;
                ////btnGenerateSellerChallan.Text = "Challan is Generated";
                //btnGenerateSellerChallan.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
        /// <summary>
        /// Stamp Duty Generation Process
        /// Stamp Duty Table Seller Buyer Get First all Information
        /// Count Buyer | Seller in Grid for Count of Single | Multi Stamp Duty
        /// Generate Ref No for Stamp Duty and Also Get Amount According to Plot Size
        /// After All These Step Pass Datatables in Sqlparameter to Database and Save the Data.
        /// </summary>
        /// <param name="File_NO"></param>
        /// <param name="Type_S_M"></param>
        /// <returns></returns>
        #region Stamp Duty Generation Process
        private DataTable StampDuty_Table(string File_NO, string Type_S_M)
        {
            DataTable StampDutyTable = new DataTable();
            try
            {
                #region DataTable_Column Creation
                DataTable_column RefNo = new DataTable_column() { ColmnName = "RefNo", type = typeof(string) };
                DataTable_column Type = new DataTable_column() { ColmnName = "Type", type = typeof(string) };
                DataTable_column Amount = new DataTable_column() { ColmnName = "Amount", type = typeof(Decimal) };
                DataTable_column Amount_In_Words = new DataTable_column() { ColmnName = "Amount_In_Words", type = typeof(string) };
                DataTable_column Remarks = new DataTable_column() { ColmnName = "Remarks", type = typeof(string) };
                DataTable_column Status = new DataTable_column() { ColmnName = "Status", type = typeof(string) };
                DataTable_column GUI = new DataTable_column() { ColmnName = "GUI", type = typeof(string) };
                DataTable_column GenerationDate = new DataTable_column() { ColmnName = "GenerationDate", type = typeof(DateTime) };
                DataTable_column DepositeDate = new DataTable_column() { ColmnName = "DepositeDate", type = typeof(DateTime) };
                DataTable_column Stm_State = new DataTable_column() { ColmnName = "Stm_State", type = typeof(string) };
                DataTable_column userID = new DataTable_column() { ColmnName = "userID", type = typeof(int) };
                DataTable_column FileNo = new DataTable_column() { ColmnName = "FileNo", type = typeof(string) };
                #endregion
                #region Insert DataTabl_Column in List, and Send to Helper to make DataTable
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(RefNo);
                colmn.Add(Type);
                colmn.Add(Amount);
                colmn.Add(Amount_In_Words);
                colmn.Add(Remarks);
                colmn.Add(Status);
                colmn.Add(GUI);
                colmn.Add(GenerationDate);
                colmn.Add(DepositeDate);
                colmn.Add(Stm_State);
                colmn.Add(userID);
                colmn.Add(FileNo);
                StampDutyTable = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                #endregion
                #region Insertion in DataTable
                DataRow row = StampDutyTable.NewRow();
                row["RefNo"] = "";
                row["Type"] = Type_S_M;
                row["Amount"] = 0;
                row["Amount_In_Words"] = "";
                row["Remarks"] = "";
                row["Status"] = "Pending";
                row["GUI"] = "";
                row["GenerationDate"] = DateTime.Now;
                row["DepositeDate"] = DateTime.Now;
                row["Stm_State"] = "Active";
                row["userID"] = PeshawarDHASW.Models.clsUser.ID;
                row["FileNo"] = File_NO.ToUpper();
                StampDutyTable.Rows.Add(row);
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on StampDuty_Table.", ex, "frmStampDuty_Create");
                frmobj.ShowDialog();
            }

            return StampDutyTable;
        }
        private DataTable StampDuty_Table_SellerBuyer()
        {
            DataTable StampDutyTable_SellerBuyer = new DataTable();
            try
            {
                #region DataTable_Column Creation
                DataTable_column Type = new DataTable_column() { ColmnName = "Type", type = typeof(string) };
                DataTable_column Name = new DataTable_column() { ColmnName = "Name", type = typeof(string) };
                DataTable_column CNIC = new DataTable_column() { ColmnName = "CNIC", type = typeof(string) };
                DataTable_column MembershipNo = new DataTable_column() { ColmnName = "MembershipNo", type = typeof(string) };
                #endregion
                #region Insert DataTabl_Column in List, and Send to Helper to make DataTable
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(Type);
                colmn.Add(Name);
                colmn.Add(CNIC);
                colmn.Add(MembershipNo);
                StampDutyTable_SellerBuyer = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                #endregion
                #region Insertion in DataTable
                int rowcount = grdSeller_Buyer.RowCount;
                for (int dr = 0; dr < rowcount; dr++)
                {
                    DataRow row = StampDutyTable_SellerBuyer.NewRow();
                    row["Name"] = grdSeller_Buyer.Rows[dr].Cells["Name"].Value.ToString();
                    row["CNIC"] = grdSeller_Buyer.Rows[dr].Cells["CNIC"].Value == null ? grdSeller_Buyer.Rows[dr].Cells["NTN"].Value.ToString() : grdSeller_Buyer.Rows[dr].Cells["CNIC"].Value.ToString();
                    row["MembershipNo"] = grdSeller_Buyer.Rows[dr].Cells["MembershipNo"].Value.ToString();
                    row["Type"] = grdSeller_Buyer.Rows[dr].Cells["Type"].Value.ToString();
                    StampDutyTable_SellerBuyer.Rows.Add(row);
                }
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on StampDuty_Table_SellerBuyer.", ex, "frmStampDuty_Create");
                frmobj.ShowDialog();
            }

            return StampDutyTable_SellerBuyer;
        }

        private void StampDutyCalcuation(string FileNo, DataTable dt)
        {
            SqlParameter[] prm =
                        {
                         new SqlParameter("@Task","File_Info_StampDuty_ReferenceNo_GUI"),
                         new SqlParameter("@FileNo",FileNo)
                        };
            DataSet dst = new DataSet();
            dst = cls_dl_StampDuty.StampDuty_Reader(prm);
            if (dst.Tables.Count > 0)
            {
                // string PlotSize  = dst.Tables[0].Rows[0]["PlotSize"].ToString();
                dt.Rows[0]["RefNo"] = dst.Tables[1].Rows[0]["ReferenceNo"].ToString();
                // string RefNo = dst.Tables[1].Rows[0]["ReferenceNo"].ToString();
                if (FileNo.ToUpper().Contains("A/RES/") || FileNo.ToUpper().Contains("OLO/A/RES/"))
                {
                    dt.Rows[0]["Amount"] = int.Parse("48000") - int.Parse(txtStmDtyFee_minus.Text);
                    dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("48000") - int.Parse(txtStmDtyFee_minus.Text), false);
                }
                else if (FileNo.ToUpper().Contains("B/RES/") || FileNo.ToUpper().Contains("OLO/B/RES/"))
                {
                    dt.Rows[0]["Amount"] = int.Parse("24000") - int.Parse(txtStmDtyFee_minus.Text);
                    dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("24000") - int.Parse(txtStmDtyFee_minus.Text), false);
                }
                else if (FileNo.ToUpper().Contains("C/RES/") || FileNo.ToUpper().Contains("OLO/C/RES/") || FileNo.ToUpper().Contains("C/RES/APS"))
                {
                    dt.Rows[0]["Amount"] = int.Parse("12000") - int.Parse(txtStmDtyFee_minus.Text);
                    dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("12000") - int.Parse(txtStmDtyFee_minus.Text), false);
                }
                else if (FileNo.ToUpper().Contains("E/RES/") || FileNo.ToUpper().Contains("OLO/E/RES/"))
                {
                    dt.Rows[0]["Amount"] = int.Parse("6000") - int.Parse(txtStmDtyFee_minus.Text);
                    dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("6000") - int.Parse(txtStmDtyFee_minus.Text), false);
                }
                else if (FileNo.ToUpper().Contains("D/RES/") || FileNo.ToUpper().Contains("OLO/D/RES/"))
                {
                    dt.Rows[0]["Amount"] = int.Parse("9600") - int.Parse(txtStmDtyFee_minus.Text);
                    dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("9600") - int.Parse(txtStmDtyFee_minus.Text), false);
                }
                else if (FileNo.ToUpper().Contains("H/COM/") || FileNo.ToUpper().Contains("OLO/H/COM/"))
                {
                    dt.Rows[0]["Amount"] = int.Parse("8000") - int.Parse(txtStmDtyFee_minus.Text);
                    dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("8000") - int.Parse(txtStmDtyFee_minus.Text), false);
                }
                else if (FileNo.ToUpper().Contains("G/COM/") || FileNo.ToUpper().Contains("OLO/G/COM/"))
                {
                    dt.Rows[0]["Amount"] = int.Parse("16000") - int.Parse(txtStmDtyFee_minus.Text);
                    dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("16000") - int.Parse(txtStmDtyFee_minus.Text), false);
                }
            }
            else
            {
                MessageBox.Show("There is no Data Found.");
            }
        }
        //private void StampDutyCalcuation(string FileNo, DataTable dt)
        //{
        //    SqlParameter[] prm =
        //                {
        //                 new SqlParameter("@Task","File_Info_StampDuty_ReferenceNo_GUI"),
        //                 new SqlParameter("@FileNo",FileNo)
        //                };
        //    DataSet dst = new DataSet();
        //    dst = cls_dl_StampDuty.StampDuty_Reader(prm);
        //    if (dst.Tables.Count > 0)
        //    {
        //        // string PlotSize  = dst.Tables[0].Rows[0]["PlotSize"].ToString();
        //        dt.Rows[0]["RefNo"] = dst.Tables[1].Rows[0]["ReferenceNo"].ToString();
        //        // string RefNo = dst.Tables[1].Rows[0]["ReferenceNo"].ToString();
        //        if (FileNo.ToUpper().Contains("A/RES/") || FileNo.ToUpper().Contains("OLO/A/RES/"))
        //        {
        //            dt.Rows[0]["Amount"] = int.Parse("24000") - int.Parse(txtStmDtyFee_minus.Text);
        //            dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("24000") - int.Parse(txtStmDtyFee_minus.Text), false);
        //        }
        //        else if (FileNo.ToUpper().Contains("B/RES/") || FileNo.ToUpper().Contains("OLO/B/RES/"))
        //        {
        //            dt.Rows[0]["Amount"] = int.Parse("12000") - int.Parse(txtStmDtyFee_minus.Text);
        //            dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("12000") - int.Parse(txtStmDtyFee_minus.Text), false);
        //        }
        //        else if (FileNo.ToUpper().Contains("C/RES/") || FileNo.ToUpper().Contains("OLO/C/RES/") || FileNo.ToUpper().Contains("C/RES/APS"))
        //        {
        //            dt.Rows[0]["Amount"] = int.Parse("6000") - int.Parse(txtStmDtyFee_minus.Text);
        //            dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("6000") - int.Parse(txtStmDtyFee_minus.Text), false);
        //        }
        //        else if (FileNo.ToUpper().Contains("E/RES/") || FileNo.ToUpper().Contains("OLO/E/RES/"))
        //        {
        //            dt.Rows[0]["Amount"] = int.Parse("3000") - int.Parse(txtStmDtyFee_minus.Text);
        //            dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("3000") - int.Parse(txtStmDtyFee_minus.Text), false);
        //        }
        //        else if (FileNo.ToUpper().Contains("D/RES/") || FileNo.ToUpper().Contains("OLO/D/RES/"))
        //        {
        //            dt.Rows[0]["Amount"] = int.Parse("4800") - int.Parse(txtStmDtyFee_minus.Text);
        //            dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("4800") - int.Parse(txtStmDtyFee_minus.Text), false);
        //        }
        //        else if (FileNo.ToUpper().Contains("H/COM/") || FileNo.ToUpper().Contains("OLO/H/COM/") )
        //        {
        //            dt.Rows[0]["Amount"] = int.Parse("4800") - int.Parse(txtStmDtyFee_minus.Text);
        //            dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("4800") - int.Parse(txtStmDtyFee_minus.Text), false);
        //        }
        //        else if (FileNo.ToUpper().Contains("G/COM/") || FileNo.ToUpper().Contains("OLO/G/COM/"))
        //        {
        //            dt.Rows[0]["Amount"] = int.Parse("9600") - int.Parse(txtStmDtyFee_minus.Text);
        //            dt.Rows[0]["Amount_In_Words"] = clsPluginHelper.Convert_Number_To_Text(int.Parse("9600") - int.Parse(txtStmDtyFee_minus.Text), false);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("There is no Data Found.");
        //    }
        //}
        #endregion

        private void btnGenerateStampDuty_Click(object sender, EventArgs e)
        {
            try
            {
                //    SqlParameter[] prmtr1 =
                //    {
                //        new SqlParameter("@Task","CheckStampDutyDuplicate"),
                //        new SqlParameter("@FileNo",txtFile_No_.Text)
                //    };
                //    DataSet dst2 = cls_dl_StampDuty.StampDuty_Reader(prmtr1);
                //    if (dst2.Tables[0].Rows.Count > 0)
                //    {
                //        MessageBox.Show("Pending Stamp Duty is already exist against this File No.", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
                //    else
                //    {
                //        #region
                //        string CNIC = "";
                //        string slrbyrType = "";
                //        if (grdSeller_Buyer.RowCount > 0)
                //        {
                //            foreach (GridViewRowInfo rw in grdSeller_Buyer.Rows)
                //            {
                //                slrbyrType = rw.Cells["Type"].Value.ToString() + "," + slrbyrType;
                //            }
                //            if (slrbyrType.Contains("Buyer"))
                //            {
                //                #region Stamp Duty Generation
                //                //if (MessageBox.Show("Are you pay in Cash then press Yes.", "Are you Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                //                //{
                //                DataTable StampDutySellerandBuyer = StampDuty_Table_SellerBuyer();
                //                int Buyer = StampDutySellerandBuyer.AsEnumerable().Count(row => row.Field<string>("Type") == "Buyer");
                //                int Seller = StampDutySellerandBuyer.AsEnumerable().Count(row => row.Field<string>("Type") == "Seller");
                //                string Type_S_M;
                //                Type_S_M = (Buyer > 1 | Seller > 1) ? Type_S_M = "Mulitple" : "Single";
                //                DataTable StampData = StampDuty_Table(txtFile_No_.Text, Type_S_M);
                //                StampDutyCalcuation(txtFile_No_.Text, StampData);
                //                SqlParameter[] parmtr =
                //                {
                //                 new SqlParameter("@Task","Insert_StampDuty_SellerBuyer"),
                //                 new SqlParameter(){ ParameterName = "@tbl_Stamp_Duty_Data",SqlDbType = SqlDbType.Structured, SqlValue = StampData},
                //                 new SqlParameter(){ ParameterName = "@tbl_Stamp_Duty_Data_Seller_Buyer",SqlDbType = SqlDbType.Structured, SqlValue = StampDutySellerandBuyer}
                //                };

                //                DataSet rslt = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.Usp_tbl_StampDuty", parmtr);
                //                if (rslt.Tables.Count > 0)
                //                {
                //                    string StampdutyID = rslt.Tables[0].Rows[0]["StampDutyID"].ToString();
                //                    if (!string.IsNullOrEmpty(StampdutyID))
                //                    {
                //                        SqlParameter[] prm =
                //                        {
                //                     new SqlParameter("@Task","Retrive_Stamp_Duty_Data_For_Report"),
                //                     new SqlParameter("@StmpDuty_ID",StampdutyID)
                //                    };
                //                        DataSet dst = new DataSet();
                //                        dst = cls_dl_StampDuty.StampDuty_Reader(prm);
                //                        //DataTable stmdty = dst.Tables[0].Rows[0]["userName"].ToString();
                //                        #region
                //                        string username = dst.Tables[0].Rows[0]["userName"].ToString();
                //                        #endregion
                //                        dst.Tables[0].Columns.Add(new DataColumn("UserName", typeof(string)));
                //                        foreach (DataRow dr in dst.Tables[0].Rows)
                //                        {
                //                            dr["UserName"] = username;
                //                        }
                //                        if (dst.Tables.Count > 0)
                //                        {
                //                            frmStampDuty_Report_Viewer frmobj = new frmStampDuty_Report_Viewer(dst);
                //                            frmobj.ShowDialog();
                //                        }
                //                    }
                //                }
                //                //}
                //                #endregion
                //            }
                //            else
                //            {
                //                MessageBox.Show("There is no purchaser record found in table.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            }
                //        }
                //        else
                //        {
                //            MessageBox.Show("Seller & Buyer Information is missing. Kindly fill the Table.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        }

                //        // btnstampduty.Enabled = false;
                //        //// btnstampduty.Text = "Stamp Duty is Generated";
                //        // btnstampduty.ForeColor = Color.DarkGreen;
                //        #endregion
                //    }


                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                //Code for Stamp Duty challan starts from here
                SqlParameter[] prmGOD =
                            {
                                new SqlParameter("@Task","GetOwnerDetailsForStampDuty"),
                                new SqlParameter("@FileNo",txtFile_No_.Text.Trim()),
                            };


                DataSet dsGOD = cls_dl_Challan.Challan_Reader(prmGOD);
                decimal psize = 0;
                string plotSizeId = string.Empty;
                string plotSize = dsGOD.Tables[0].Rows[0]["PlotSize"].ToString();
                string sector = dsGOD.Tables[0].Rows[0]["FileSector"].ToString();
                switch (plotSize)
                {
                    case "1 Kanal":
                        plotSizeId = "1";
                        psize = 20;
                        break;
                    case "8 Marla":
                        plotSizeId = "2";
                        psize = 8;
                        break;
                    case "5 Marla":
                        plotSizeId = "3";
                        psize = 5;
                        break;
                    case "4 Marla":
                        plotSizeId = "4";
                        psize = 4;
                        break;
                    case "2 Kanal":
                        plotSizeId = "5";
                        psize = 40;
                        break;
                    case "10 Marla":
                        plotSizeId = "6";
                        psize = 10;
                        break;
                    case "8 Marla Com":
                        plotSizeId = "7";
                        psize = 8;
                        break;
                    case "4 Marla Com":
                        plotSizeId = "8";
                        psize = 4;
                        break;
                    case "1 Kanal Com":
                        plotSizeId = "11";
                        psize = 20;
                        break;
                    case "16 Marla Com":
                        plotSizeId = "12";
                        psize = 16;
                        break;
                    case "12 Marla Com":
                        plotSizeId = "13";
                        psize = 12;
                        break;
                    case "4 Kanal Com":
                        plotSizeId = "14";
                        psize = 80;
                        break;
                    case "4 Kanal":
                        plotSizeId = "15";
                        psize = 80;
                        break;
                    case "8 Kanal Com":
                        plotSizeId = "16";
                        psize = 160;
                        break;
                    case "5 Marla Com":
                        plotSizeId = "17";
                        psize = 5;
                        break;
                    case "10 Marla Com":
                        plotSizeId = "18";
                        psize = 10;
                        break;
                }



                SqlParameter[] prmFillChallan =
                {
                new SqlParameter("@Task","fillChallanHeaderDetail"),
                new SqlParameter("@FileMapKey", 2),
                new SqlParameter("@PlotSizeID", plotSizeId)
                };

                DataSet fillChallanHeaderDetailds = cls_dl_Challan.Challan_Reader(prmFillChallan);

                //Get Max Challan No
                string txtChallanNo = string.Empty;
                SqlParameter[] prm1 =
                {
                new SqlParameter("@Task","GetMaxChallanNo"),
            };
                DataSet ds1 = cls_dl_Challan.Challan_Reader(prm1);
                if (ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        txtChallanNo = ds1.Tables[0].Rows[0][0].ToString();
                    }
                }



                //if (string.IsNullOrEmpty(lblChallanNo.Text.Trim()))
                {
                    //object sumObject;
                    //sumObject = Convert.ToInt32(fillChallanHeaderDetailds.Tables[0].Rows[4]["Amount"].ToString());
                    //double Amt;
                    //bool isOk = double.TryParse(sumObject.ToString(), out Amt);
                    //if (isOk == false)
                    //{
                    //    MessageBox.Show("Cannot create challan for Zero amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    //cmbChallanType.ShowDropDown();
                    //    return;
                    //}

                    //int TotalAmount = Convert.ToInt32(fillChallanHeaderDetailds.Tables[0].Rows[3]["Amount"].ToString().Trim().Split('.').First()); 
                    decimal TotalAmount = 00;
                    decimal FBRvalueperMarla = 0;
                    decimal percentageValue = 0.02m;
                    if (txtFile_No_.Text.ToUpper().Contains("/COM/"))
                    {
                        if (string.IsNullOrEmpty(sector))
                        {
                            FBRvalueperMarla = (Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarla_ComOther"]) * percentageValue); //FBR Per Marla Value is 1250000


                            TotalAmount = psize * FBRvalueperMarla;
                        }
                        else
                        {
                            if (sector == "ABC")
                            {
                                FBRvalueperMarla = (Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarla_ComABC"]) * percentageValue); //FBR Per Marla Value is 2500000

                                TotalAmount = psize * FBRvalueperMarla;

                            }
                            else
                            {
                                FBRvalueperMarla = (Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarla_ComOther"]) * percentageValue); //FBR Per Marla Value is  1250000
                                TotalAmount = psize * FBRvalueperMarla;
                            }
                        }

                    }
                    else
                    {
                        if (string.IsNullOrEmpty(sector))
                        {
                            FBRvalueperMarla = (Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarlaOther"]) * percentageValue); //FBR Per Marla Value is 300000


                            TotalAmount = psize * FBRvalueperMarla;
                        }
                        else
                        {
                            if (sector == "ABC")
                            {
                                FBRvalueperMarla = (Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarlaABC"]) * percentageValue); //FBR Per Marla Value 500000 

                                TotalAmount = psize * FBRvalueperMarla;

                            }
                            else
                            {
                                FBRvalueperMarla = (Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarlaOther"]) * percentageValue); //FBR Per Marla Value 300000
                                TotalAmount = psize * FBRvalueperMarla;
                            }
                        }
                    }

                    //bool res = int.TryParse(sumObject.ToString(), out TotalAmount);
                    //if (TotalAmount == 0)
                    //{
                    //    MessageBox.Show("Cannot create challan for Zero amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    //cmbChallanType.ShowDropDown();
                    //    return;
                    //}

                    string amount_in_word = Helper.clsPluginHelper.Convert_Number_To_Text(Convert.ToInt32(TotalAmount), false);
                    SqlParameter param_out_ID = new SqlParameter()
                    {
                        ParameterName = "@ChallanIDOutput",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    int ChallanIDOut = 0;
                    {
                        //SqlParameter[] prm1 =
                        //{
                        //   new SqlParameter("@Task","GetChallanNoInfo"),
                        //   new SqlParameter("@ChalanNo",txtChallanNo.Text.Trim()),
                        //};
                        //DataSet ds1 = cls_dl_Challan.Challan_Reader(prm1);
                        //if (ds1.Tables.Count > 0 && string.IsNullOrEmpty(lblChalanID.Text))
                        //{
                        //    if (ds1.Tables[0].Rows.Count > 0)
                        //    {
                        //        MessageBox.Show("Challan No. already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        txtChallanNo.Focus();
                        //        return;
                        //    }
                        //}
                        if (TotalAmount > 0)
                        {
                            // Insert / Update Record of Challan

                            string Task = "SaveChallan";
                            string buyerName = grdSeller_Buyer.Rows[1].Cells["Name"].Value.ToString();

                            string fileMapKey = dsGOD.Tables[0].Rows[0]["FileMapKey"].ToString();
                            string membershipID = dsGOD.Tables[0].Rows[0]["MembershipID"].ToString();
                            string cnic = grdSeller_Buyer.Rows[1].Cells["NTN"].Value.ToString();

                            SqlParameter[] prm =
                            {
                        new SqlParameter("@Task", Task),
                        new SqlParameter("@ChallanID", null),
                        new SqlParameter("@FileMapKey", fileMapKey),
                        new SqlParameter("@MemberID", membershipID),
                        new SqlParameter("@Name", buyerName),
                        new SqlParameter("@ChalanNo", /*txtChallanNo.Text.Trim()*/ txtChallanNo),
                        new SqlParameter("@ClearDate", DateTime.Now.Date),
                        new SqlParameter("@BankAccount", "0040100581377"),
                        new SqlParameter("@BankName", "Askari Bank Limited"),
                        new SqlParameter("@TotalAmount", TotalAmount),
                        new SqlParameter("@AmountInWord", amount_in_word),
                        new SqlParameter("@UserID", Models.clsUser.ID),
                        new SqlParameter("@ChallanType", "Other"),
                        new SqlParameter("@Status", null),
                        new SqlParameter("@RefNo", ""),
                        new SqlParameter("@CNIC",cnic),
                        new SqlParameter("@Description", ""),
                        new SqlParameter("@PropertyDealerID", null),

                        param_out_ID
                    };

                            SqlCommand result = cls_dl_Challan.ChallanExecuteNonQuery(prm);

                            if (result.Parameters.Count != 0)
                            {
                                ChallanIDOut = int.Parse(result.Parameters["@ChallanIDOutput"].Value.ToString());
                                //Insertion Of NextOfKin
                                if (ChallanIDOut != 0)
                                {

                                    string ChallanType = null;
                                    ChallanType = "Other";

                                    SqlParameter[] prm2 =
                                    {
                                    new SqlParameter("@Task","SaveChallanDetail"),
                                    new SqlParameter("@ChallanID", ChallanIDOut),
                                    new SqlParameter("@ParticularID", 13),
                                    new SqlParameter("@ParticularAmount", TotalAmount),
                                    new SqlParameter("@UserID", Models.clsUser.ID),
                                    new SqlParameter("@SerialNo", 1),
                                    new SqlParameter("@Particular","Stamp Duty"),
                                    new SqlParameter("@ChallanType",ChallanType )
                                    //ChallanType
                                };
                                    try
                                    {
                                        int resulte = cls_dl_Challan.Challan_ExecuteNonQuery(prm2);
                                        if (resulte > 0)
                                        {
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }


                                    DataSet ds = new DataSet();
                                    SqlParameter[] prm3 =
                                    {
                                new SqlParameter("@Task","GetChallReportDetail"),
                                new SqlParameter("@ChallanID",ChallanIDOut)
                            };

                                    ds = cls_dl_Challan.Challan_Reader(prm3);
                                    ChallanDataset _ds = new ChallanDataset();

                                    _ds.Tables["tblChallan"].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                                    _ds.Tables["tblChallanDetail"].Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                                    ds = null;
                                    frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                                    obj.ShowDialog();
                                    //this.Close();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Total Amount of Challan is Zero Challan Cannot be Generate.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerateBuyerChallan_Click(object sender, EventArgs e)
        {
            try
            {
                int mbcount = 0;
                if (rdbsngl.CheckState == CheckState.Checked)
                {
                    mbcount = 1;
                }
                else if (rdbDual.CheckState == CheckState.Checked)
                {
                    mbcount = 2;
                }
                else if (rdbTrple.CheckState == CheckState.Checked)
                {
                    mbcount = 3;
                }
                else if (rdbQuad.CheckState == CheckState.Checked)
                {
                    mbcount = 4;
                }
                string slrbyrType = "";
                if (grdSeller_Buyer.RowCount > 0)
                {
                    foreach (GridViewRowInfo rw in grdSeller_Buyer.Rows)
                    {
                        slrbyrType = rw.Cells["Type"].Value.ToString() + "," + slrbyrType;
                    }
                    if (slrbyrType.Contains("Buyer"))
                    {
                        #region Generate Challan
                        string FileNo = txtFile_No_.Text;
                        string BuyerName = "";
                        string CNIC = "";
                        int rowcount = grdSeller_Buyer.Rows.Count;
                        for (int i = 0; i < rowcount; i++)
                        {
                            string type = grdSeller_Buyer.Rows[i].Cells["Type"].Value.ToString();
                            MembershipFormFeeSkipInclude_ = chbMembershipFormFeeSkip.Checked ? "SkipMembershipFormFee" : "IncludeMembershipFormFee";

                            if (type == "Buyer")
                            {
                                BuyerName = grdSeller_Buyer.Rows[i].Cells["Name"].Value.ToString() + ",";
                                CNIC = grdSeller_Buyer.Rows[i].Cells["CNIC"].Value == null ? grdSeller_Buyer.Rows[i].Cells["NTN"].Value.ToString() : grdSeller_Buyer.Rows[i].Cells["CNIC"].Value.ToString() + ",";
                            }
                        }
                        string NDCTye = rdbHiba.IsChecked ? "HibaTFRFeeRES" : "NormalTFRFeeRES";
                        string UrgentNDCCharges = chk_urgentNDC_.CheckState == CheckState.Checked ? "1" : "0";
                        string UrgentTFRCharges = chk_UrgentTransfer_.CheckState == CheckState.Checked ? "1" : "0";
                        string OutStationAllocationTFR = chk_OutStationCharges_.CheckState == CheckState.Checked ? "1" : "0";
                        string Sellcheck = rdSellerOST.CheckState == CheckState.Checked ? "1" : "0";
                        string Buyercheck = rdBuyerOST.CheckState == CheckState.Checked ? "1" : "0";

                        decimal tfrfee_minus = Convert.ToDecimal(txtTFRFee_minus.Text == "" ? "0" : txtTFRFee_minus.Text);
                        decimal mbrfee_minus = Convert.ToDecimal(txtmbrfee_minus.Text == "" ? "0" : txtmbrfee_minus.Text);
                        decimal mbrfrmfee_minus = Convert.ToDecimal(txtMbrFrmFee_minus.Text == "" ? "0" : txtMbrFrmFee_minus.Text);


                        SqlParameter[] param = {
                                        new SqlParameter("@Task","BuyerChallanAutomation"),
                                        new SqlParameter("@File_No",txtFile_No_.Text),
                                        new SqlParameter("@NameofBuyer",BuyerName),
                                        new SqlParameter("@CNICofBuyer",CNIC),
                                        new SqlParameter("@TFRType",NDCTye),
                                        new SqlParameter("@SkipIncludeMembershipFormFee",MembershipFormFeeSkipInclude_),
                                        new SqlParameter("@NDCUrgentFee",UrgentNDCCharges),
                                        new SqlParameter("@UrgentTFRFee",UrgentTFRCharges),
                                        new SqlParameter("@OutStationTFRFee",OutStationAllocationTFR),
                                        new SqlParameter("@OUTSTFee_Seller",Sellcheck),
                                        new SqlParameter("@OUTSTFee_Buyer",Buyercheck),
                                        new SqlParameter("@UserID",clsUser.ID),
                                        new SqlParameter("@TfrFee_Minus",tfrfee_minus),
                                        new SqlParameter("@MbrFee_Minus",mbrfee_minus),
                                        new SqlParameter("@MbrFrmFee_Minus",mbrfrmfee_minus),
                                        new SqlParameter("@MbCount",mbcount),
                                        new SqlParameter("@CorporateCheck",chkCorporate_Check_)
                        };
                        DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_NDC_Challan", param);
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string ChallanID = ds.Tables[0].Rows[0]["ChallanID"].ToString();
                                DataSet ChallanDataset = new DataSet();
                                SqlParameter[] prm3 =
                                {
                            new SqlParameter("@Task","GetChallReportDetail"),
                            new SqlParameter("@ChallanID",ChallanID)
                           };

                                ChallanDataset = cls_dl_Challan.Challan_Reader(prm3);
                                ChallanDataset _ds = new ChallanDataset();

                                _ds.Tables["tblChallan"].Merge(ChallanDataset.Tables[0], true, MissingSchemaAction.Ignore);
                                _ds.Tables["tblChallanDetail"].Merge(ChallanDataset.Tables[1], true, MissingSchemaAction.Ignore);
                                ChallanDataset = null;
                                frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                                obj.ShowDialog();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Seller & Buyer Information is missing. Kindly fill the Table.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("There is no purchaser record found in table.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Seller & Buyer Information is missing. Kindly fill the Table.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // btnGenerateBuyerChallan.Enabled = false;
                //// btnGenerateBuyerChallan.Text = "Challan is Generated";
                // btnGenerateBuyerChallan.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnrefres_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRowInfo rowInfo in grdSeller_Buyer.Rows)
                {
                    string typ = rowInfo.Cells["Type"].Value.ToString();
                    if (typ == "Buyer")
                    {
                        string nic = rowInfo.Cells["CNIC"].Value == null ? rowInfo.Cells["NTN"].Value.ToString() : rowInfo.Cells["CNIC"].Value.ToString();
                        Bind_Stamp_Duty_Ref(nic, txtFile_No_.Text);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkEnabled.Checked == true)
            //{
            //    if (txtStampDuty_.Text != "" && txtDDNo_ != "" && txtDHAPChNo_ != "" && (buyerCheckFiler == true || buyerCheckNonFiler == true) && (sellerrCheckFiler == true || sellerrCheckNonFiler == true))
            //    {
            //        btnNDCCreate_.Enabled = true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Please Clear all the Dues and Checks.");
            //    }
            //}
        }

        private void chkChallanButtonEnabled_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnloadgrid_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] Param = {
                        new SqlParameter("@Task","FBRDataLoading"),
                        new SqlParameter("@NDCNo",NDCID)
                    };
                DataSet fbrcprsavedata = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDC_FBRDataLoad", Param);
                if (fbrcprsavedata.Tables.Count > 0)
                {
                    if (fbrcprsavedata.Tables[0].Rows.Count > 0)
                    {
                        string DealType = fbrcprsavedata.Tables[0].Rows[0]["DealType"].ToString();
                        string Deal_Amount = fbrcprsavedata.Tables[0].Rows[0]["Deal_Amount"].ToString();
                        txtDealValue.Text = Deal_Amount;
                        if (DealType == "FBR")
                        {
                            rdbFBR.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            FBROther.CheckState = CheckState.Checked;
                        }

                        grdCPRData.DataSource = fbrcprsavedata.Tables[0].DefaultView;
                    }
                    else
                    {

                        if (NDCID == 0)
                        {
                            if (!string.IsNullOrEmpty(txtDealValue.Text))
                            {
                                BindColumnToFBRSellerBuyerCPRDetailGrid();
                            }
                            else
                            {
                                MessageBox.Show("Please Enter the Deal Value First.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {


                            MessageBox.Show("FBR could not modify here, Please modify it in FBR Modify Page.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FBRFilerandNonFilerCheck(long NDCID)
        {
            buyerCheckFiler = false;
            buyerCheckNonFiler = false;
            sellerrCheckFiler = false;
            sellerrCheckNonFiler = false;
            SqlParameter[] Param = {
                        new SqlParameter("@Task","FBRDataLoading"),
                        new SqlParameter("@NDCNo",NDCID)
                    };
            DataSet fbrcprsavedata = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDC_FBRDataLoad", Param);
            if (fbrcprsavedata.Tables.Count > 0)
            {
                string DealType = fbrcprsavedata.Tables[0].Rows[0]["DealType"].ToString();
                string Deal_Amount = fbrcprsavedata.Tables[0].Rows[0]["Deal_Amount"].ToString();
                txtDealValue.Text = Deal_Amount;

                foreach (DataRow item in fbrcprsavedata.Tables[0].Rows)
                {
                    if (item["Type"].ToString() == "Buyer" && item["txtFiler_NonFiler"].ToString() == "Filer")
                    {
                        sellerrCheckFiler = true;
                        sellerrCheckNonFiler = false;
                    }
                    else
                    {
                        sellerrCheckFiler = false;
                        sellerrCheckNonFiler = true;
                    }
                    if (item["Type"].ToString() == "Seller" && item["txtFiler_NonFiler"].ToString() == "Filer")
                    {
                        buyerCheckFiler = true;
                        buyerCheckNonFiler = false;
                    }
                    else
                    {
                        buyerCheckFiler = false;
                        buyerCheckNonFiler = true;
                    }

                }
                if (DealType == "FBR")
                {
                    rdbFBR.CheckState = CheckState.Checked;
                }
                else
                {
                    FBROther.CheckState = CheckState.Checked;
                }

                grdCPRData.DataSource = fbrcprsavedata.Tables[0].DefaultView;
            }
            else
            {
                MessageBox.Show("Please Fill FBR Data Before Converting NDC from OpenNDC to Normal NDC.");
            }
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                buyerCheckFiler = false;
                buyerCheckNonFiler = false;
                sellerrCheckFiler = false;
                sellerrCheckNonFiler = false;
                SqlParameter[] Param = {
                        new SqlParameter("@Task","FBRDataLoading"),
                        new SqlParameter("@NDCNo",NDCID)
                    };
                DataSet fbrcprsavedata = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDC_FBRDataLoad", Param);
                if (fbrcprsavedata.Tables.Count>0)
                {
                    if (fbrcprsavedata.Tables[0].Rows.Count > 0)
                    {
                        string DealType = fbrcprsavedata.Tables[0].Rows[0]["DealType"].ToString();
                        string Deal_Amount = fbrcprsavedata.Tables[0].Rows[0]["Deal_Amount"].ToString();
                        txtDealValue.Text = Deal_Amount;

                        foreach (DataRow item in fbrcprsavedata.Tables[0].Rows)
                        {
                            if (item["Type"].ToString() == "Buyer" && item["txtFiler_NonFiler"].ToString() == "Filer")
                            {
                                sellerrCheckFiler = true;
                                sellerrCheckNonFiler = false;
                            }
                            else
                            {
                                sellerrCheckFiler = false;
                                sellerrCheckNonFiler = true;
                            }
                            if (item["Type"].ToString() == "Seller" && item["txtFiler_NonFiler"].ToString() == "Filer")
                            {
                                buyerCheckFiler = true;
                                buyerCheckNonFiler = false;
                            }
                            else
                            {
                                buyerCheckFiler = false;
                                buyerCheckNonFiler = true;
                            }

                        }
                        if (DealType == "FBR")
                        {
                            rdbFBR.CheckState = CheckState.Checked;
                        }
                        else
                        {
                            FBROther.CheckState = CheckState.Checked;
                        }

                        grdCPRData.DataSource = fbrcprsavedata.Tables[0].DefaultView;
                    }
                    else
                    {
                        if (grdCPRData.RowCount > 0 || txtDealValue.Text == "")
                        {
                            #region FBR Insertion


                            buyerCheckFiler = false;
                            buyerCheckNonFiler = false;
                            sellerrCheckFiler = false;
                            sellerrCheckNonFiler = false;

                            decimal dealval = Convert.ToDecimal(txtDealValue.Text) - Convert.ToDecimal(txtFBRFee_minus.Text == "" ? "0" : txtFBRFee_minus.Text);

                            if (grdCPRData.RowCount > 0)
                            {
                                txtTaxCAmountSeller = 0;
                                txtTaxKAmountBuyer = 0;
                                #region Check FBR Data for Duplicate
                                SqlParameter[] parameter =
                                {
                            new SqlParameter("@Task", "CheckFBRDetailForDuplicate"),
                            new SqlParameter("@FileNo",txtFile_No_.Text)
                            };
                                DataSet ds = cls_dl_NDC.NdcRetrival(parameter);

                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    buyerCheckFiler = true;
                                    buyerCheckNonFiler = true;
                                    sellerrCheckFiler = true;
                                    sellerrCheckNonFiler = true;
                                    MessageBox.Show("CPR Data is already Exist against this File No.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    string dlt = ds.Tables[0].Rows[0]["DealType"].ToString();
                                    if (dlt == "FBR")
                                    {
                                        rdbFBR.CheckState = CheckState.Checked;
                                    }
                                    else
                                    {
                                        FBROther.CheckState = CheckState.Checked;
                                    }
                                    txtDealValue.Text = Math.Round(Convert.ToDecimal(ds.Tables[0].Rows[0]["Deal_Amount"]), 2).ToString();
                                    grdCPRData.DataSource = ds.Tables[0].DefaultView;

                                }
                                #endregion
                                else
                                {
                                    if (string.IsNullOrEmpty(CheckCPRDuplicate()))
                                    {
                                        #region Detail
                                        #region Find the Total Amount of Seller and Buyer

                                        foreach (GridViewRowInfo row in grdSeller_Buyer.Rows)
                                        {
                                            //bool bl = Convert.ToBoolean(row.Cells["SelectOwner"].Value);
                                            //if (bl == true)
                                            //{
                                            string ntn = row.Cells["NTN"].Value.ToString();  // "16202-7177043-9"; //
                                            string type = row.Cells["Type"].Value.ToString();

                                            foreach (GridViewRowInfo row1 in grdCPRData.Rows)
                                            {
                                                string nt = row1.Cells["NTN"].Value.ToString();
                                                if (nt == ntn && type == "Seller")
                                                {
                                                    txtTaxCAmountSeller = Convert.ToDecimal(row1.Cells["CPRAmount"].Value.ToString()) + txtTaxCAmountSeller;
                                                }
                                                else if (nt == ntn && type == "Buyer")
                                                {
                                                    txtTaxKAmountBuyer = Convert.ToDecimal(row1.Cells["CPRAmount"].Value.ToString()) + txtTaxKAmountBuyer;
                                                }
                                            }
                                            // }
                                        }

                                        #endregion
                                        #region  Build the Seller and Buyer String For Filer and Non-Filer Status Checking

                                        string SellerString = "";
                                        string BuyerString = "";
                                        foreach (GridViewRowInfo row in grdSeller_Buyer.Rows)
                                        {
                                            //bool bl = Convert.ToBoolean(row.Cells["SelectOwner"].Value);
                                            //if (bl == true)
                                            //{
                                            string ntn = row.Cells["NTN"].Value.ToString(); // "16202-7177043-9"; //
                                            string type = row.Cells["Type"].Value.ToString();
                                            #region Buyer Part
                                            if (type == "Buyer")
                                            {
                                                //BuyerString = ExtractNumberFromString(cnic) + "," + BuyerString;
                                                BuyerString = ExtractNumberFromString(ntn) + "," + BuyerString;
                                            }
                                            #endregion
                                            #region Seller Part
                                            else if (type == "Seller")
                                            {
                                                //SellerString = ExtractNumberFromString(cnic) + "," + SellerString;
                                                SellerString = ExtractNumberFromString(ntn) + "," + SellerString;
                                            }
                                            #endregion

                                            //}
                                        }
                                        if (BuyerString == ",") { BuyerString = ""; }
                                        if (SellerString == ",") { SellerString = ""; }
                                        #endregion
                                        DataSet sdt = FBROwnerTypeChecking(BuyerString, SellerString);
                                        #region FBR Tax Calculation For Buyer (Tables[0] is return the Buyer information)
                                        string stb, prcb;
                                        //@@@@@@@@@@@@@@@@@@@@@@@@@   Buyer Part / Filer @@@@@@@@@@@@@@@@@@@@@@@@@@@
                                        if (sdt.Tables[0].Rows[0]["FBROwnerType"].ToString() == "Filer")
                                        {
                                            #region New Code for Buyer -> Filer
                                            CalculatedTaxBuyer = (Convert.ToDecimal(dealval.ToString()) * 3) / 100;
                                            CalculatedTaxBuyerFBROwnerType = "Filer";
                                            if (Convert.ToDecimal(txtTaxKAmountBuyer) + Convert.ToDecimal(txtbuyerdiscount.Text) >= Math.Round(CalculatedTaxBuyer))
                                            {
                                                buyerCheckFiler = true;
                                            }
                                            else
                                            {
                                                buyerCheckFiler = false;

                                                MessageBox.Show("Buyer is not Valid to Purchase the File/Plot," + Environment.NewLine +
                                                            "Because Deal Value is : " + (dealval.ToString()) + Environment.NewLine
                                                            + " 3 % On deal value for Filer Buyer  is : " + Math.Round(CalculatedTaxBuyer) + Environment.NewLine +
                                                            "and you are Submit  :" + Math.Round(txtTaxKAmountBuyer), "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            }
                                            #endregion

                                            #region   Old Code for Buyer -> Filer
                                            //if (Math.Round(decimal.Parse(dealval.ToString())) >= 4000000)
                                            //{
                                            //    CalculatedTaxBuyer = (Convert.ToDecimal(dealval.ToString()) * 2) / 100;
                                            //    CalculatedTaxBuyerFBROwnerType = "Filer";
                                            //    if (Convert.ToDecimal(txtTaxKAmountBuyer) >= Math.Round(CalculatedTaxBuyer))
                                            //    {
                                            //        buyerCheckFiler = true;
                                            //    }
                                            //    else
                                            //    {
                                            //        buyerCheckFiler = false;

                                            //        MessageBox.Show("Buyer is not Valid to Purchase the File/Plot," + Environment.NewLine +
                                            //                    "Because Deal Value is : " + (dealval.ToString()) + Environment.NewLine
                                            //                    + " 2 % On deal value for Filer Buyer  is : " + Math.Round(CalculatedTaxBuyer) + Environment.NewLine +
                                            //                    "and you are Submit  :" + Math.Round(txtTaxKAmountBuyer), "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            //    }


                                            //}
                                            //else
                                            //{
                                            //    ///@@@@@@@ There will be no Tax on Buyer
                                            //    CalculatedTaxBuyer = 0;
                                            //    CalculatedTaxBuyerFBROwnerType = "Filer";
                                            //    buyerCheckFiler = true;
                                            //}
                                            #endregion

                                        }
                                        //@@@@@@@@@@@@@@@@@@@@@@@@@   Buyer Part / Non-Filer @@@@@@@@@@@@@@@@@@@@@@@@@@@
                                        else if (sdt.Tables[0].Rows[0]["FBROwnerType"].ToString() == "Non-Filer")
                                        {
                                            #region New Code for Buyer -> Non-Filer
                                            CalculatedTaxBuyer = (Convert.ToDecimal(dealval.ToString()) * Convert.ToDecimal(10.5)) / 100;
                                            CalculatedTaxBuyerFBROwnerType = "Non-Filer";
                                            if (Math.Round(Convert.ToDecimal(txtTaxKAmountBuyer) + Convert.ToDecimal(txtbuyerdiscount.Text)) >= Math.Round(CalculatedTaxBuyer))
                                            {
                                                buyerCheckNonFiler = true;
                                            }
                                            else
                                            {
                                                buyerCheckNonFiler = false;
                                                MessageBox.Show("Buyer is not Valid to Purchase the File/Plot," + Environment.NewLine +
                                                             "Because Deal Value is : " + Math.Round(dealval).ToString() + Environment.NewLine
                                                             + " 10.5 % On deal value for Non-Filer Buyer is : " + Math.Round(CalculatedTaxBuyer).ToString() + Environment.NewLine +
                                                             "and you are Submit :" + Math.Round(txtTaxKAmountBuyer), "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            }
                                            #endregion
                                            #region Old Code for Buyer -> Non-Filer
                                            //if (Math.Round(decimal.Parse(dealval.ToString())) >= 5000000)
                                            //{
                                            //    MessageBox.Show("Buyer is not Valid to Purchase the File/Plot," + Environment.NewLine +
                                            //                    "Because Non-Filer Purchaser is not allowed to Purchase a Plot" + Environment.NewLine +
                                            //                    "having Deal value is equall OR Greater then Rs.5000000.00", "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            //    //btnNDCCreate_.Enabled = false;
                                            //    buyerCheckNonFiler = false;


                                            //}
                                            //else if (Math.Round(decimal.Parse(dealval.ToString())) <= 4000000)
                                            //{
                                            //    buyerCheckNonFiler = true;
                                            //    CalculatedTaxBuyerFBROwnerType = "Non-Filer";
                                            //    CalculatedTaxBuyer = 0;
                                            //}
                                            //else if (Math.Round(decimal.Parse(dealval.ToString())) > 4000000 && Math.Round(decimal.Parse(dealval.ToString())) < 5000000)
                                            //{
                                            //    CalculatedTaxBuyer = (Convert.ToDecimal(dealval.ToString()) * 4) / 100;
                                            //    CalculatedTaxBuyerFBROwnerType = "Non-Filer";
                                            //    if (Math.Round(Convert.ToDecimal(txtTaxKAmountBuyer)) >= Math.Round(CalculatedTaxBuyer))
                                            //    {
                                            //        buyerCheckNonFiler = true;
                                            //    }
                                            //    else
                                            //    {
                                            //        buyerCheckNonFiler = false;
                                            //        MessageBox.Show("Buyer is not Valid to Purchase the File/Plot," + Environment.NewLine +
                                            //                     "Because Deal Value is : " + Math.Round(dealval).ToString() + Environment.NewLine
                                            //                     + " 4 % On deal value for Non-Filer Buyer is : " + CalculatedTaxBuyer + Environment.NewLine +
                                            //                     "and you are Submit :" + Math.Round(txtTaxKAmountBuyer), "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            //    }
                                            //}
                                            #endregion
                                        }



                                        #endregion
                                        //@@@@@@@@@@@@@@@@@@@@@@@@@   Seller Part / Filer @@@@@@@@@@@@@@@@@@@@@@@@@@@
                                        #region %%%%%%%%%%%%%  FBR Tax Calculation For Seller (Tables[1] is return the Seller information)
                                        string st = "", prc = "";
                                        if (sdt.Tables[1].Rows[0]["FBROwnerType"].ToString() == "Filer")
                                        {
                                            CalculatedTaxSeller = (Convert.ToDecimal(dealval.ToString()) * 3) / 100;
                                            CalculatedTaxSellerFBROwnerType = "Filer";
                                            st = "3 % Tax is apply on Filer Seller, So :";
                                            prc = "3 % ";
                                        }
                                        else if (sdt.Tables[1].Rows[0]["FBROwnerType"].ToString() == "Non-Filer")
                                        {
                                            CalculatedTaxSeller = (Convert.ToDecimal(dealval.ToString()) * 6) / 100;
                                            CalculatedTaxSellerFBROwnerType = "Non-Filer";
                                            st = "6 % Tax is apply on Non-Filer Seller, So :";
                                            prc = "6 % ";
                                        }

                                        #region Skip FBR Tax on Seller
                                        if (chkFBRSellerSkip.CheckState == CheckState.Unchecked)
                                        {
                                            if (Math.Round(Convert.ToDecimal(txtTaxCAmountSeller) + Convert.ToDecimal(txtsellerdiscount.Text)) >= Math.Round(CalculatedTaxSeller))
                                            {
                                                sellerrCheckFiler = true;
                                            }
                                            else
                                            {
                                                sellerrCheckFiler = false;
                                                MessageBox.Show("Seller is not valid to Sold the Plot,  " + st + Environment.NewLine +
                                                    "Because Deal Value is : " + Math.Round(dealval).ToString() + Environment.NewLine +
                                                    prc + "Tax Amount of " + Math.Round(dealval).ToString() + " is : " + Math.Round(CalculatedTaxSeller) + Environment.NewLine +
                                                    "Submitted Tax Amount is : " + Math.Round(txtTaxCAmountSeller) + Environment.NewLine +
                                                    "Which is less then the Calculated " + prc + " Tax Amount.", "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                                //btnNDCCreate_.Enabled = false;
                                                txtTaxCAmountSeller = 0;
                                                txtTaxKAmountBuyer = 0;
                                            }
                                        }
                                        else
                                        {
                                            sellerrCheckFiler = true;
                                            sellerrCheckNonFiler = true;
                                            btnNDCCreate_.Enabled = true;
                                        }

                                        #endregion


                                        #endregion
                                        #region  FBR Data and Seller Buyer Table Fillings
                                        DataTable dtFBRD = new DataTable();
                                        DataTable dtFBRD_CalculatedTax = new DataTable();
                                        DataTable dtFBRSB = new DataTable();
                                        DataTable dtFBRSB_CPRDetail = new DataTable();
                                        if ((buyerCheckFiler == true || buyerCheckNonFiler == true) && (sellerrCheckFiler == true || sellerrCheckNonFiler == true))
                                        {
                                            #region FBR Data Insertion
                                            dtFBRD.Clear();
                                            dtFBRD.Columns.Add("DealType");
                                            dtFBRD.Columns.Add("Deal_Amount");
                                            dtFBRD.Columns.Add("FileNo");
                                            dtFBRD.Columns.Add("Status");
                                            dtFBRD.Columns.Add("Remarks");
                                            dtFBRD.Columns.Add("UserID");
                                            DataRow drfd = dtFBRD.NewRow();
                                            drfd["DealType"] = rdbFBR.IsChecked ? "FBR" : "Other";
                                            drfd["Deal_Amount"] = Math.Round(dealval).ToString();
                                            drfd["FileNo"] = txtFile_No_.Text;
                                            drfd["Status"] = "Active";
                                            drfd["Remarks"] = "These Taxes are paid against NDC.";
                                            drfd["UserID"] = Models.clsUser.ID;
                                            dtFBRD.Rows.Add(drfd);
                                            #endregion
                                            #region FBR Calculated Tax on Deal Value
                                            dtFBRD_CalculatedTax.Clear();
                                            dtFBRD_CalculatedTax.Columns.Add("CalculatedTaxOnDealAmount");
                                            dtFBRD_CalculatedTax.Columns.Add("TaxPaid");
                                            dtFBRD_CalculatedTax.Columns.Add("FBROwnerType");
                                            dtFBRD_CalculatedTax.Columns.Add("FileOwnerType");
                                            DataRow dct = dtFBRD_CalculatedTax.NewRow();
                                            dct["CalculatedTaxOnDealAmount"] = Math.Round(CalculatedTaxBuyer);
                                            dct["TaxPaid"] = Math.Round(txtTaxKAmountBuyer);
                                            dct["FileOwnerType"] = "Buyer";
                                            dct["FBROwnerType"] = CalculatedTaxBuyerFBROwnerType;

                                            DataRow dct1 = dtFBRD_CalculatedTax.NewRow();
                                            dct1["CalculatedTaxOnDealAmount"] = Math.Round(CalculatedTaxSeller);
                                            dct1["TaxPaid"] = Math.Round(txtTaxCAmountSeller);
                                            dct1["FileOwnerType"] = "Seller";
                                            dct1["FBROwnerType"] = CalculatedTaxSellerFBROwnerType;

                                            dtFBRD_CalculatedTax.Rows.Add(dct);
                                            dtFBRD_CalculatedTax.Rows.Add(dct1);
                                            #endregion

                                            #region FBR Seller Buyer Table
                                            dtFBRSB.Clear();
                                            dtFBRSB.Columns.Add("CNIC");
                                            dtFBRSB.Columns.Add("Name");
                                            dtFBRSB.Columns.Add("FatherName");
                                            dtFBRSB.Columns.Add("NTN");
                                            dtFBRSB.Columns.Add("Type");
                                            dtFBRSB.Columns.Add("FBROwnerType");
                                            dtFBRSB.Columns.Add("UniqIDSB");

                                            //dtFBRSB.Columns.Add("CPRNo");
                                            //dtFBRSB.Columns.Add("CPRTaxAmount");
                                            //dtFBRSB.Columns.Add("CalculatedTaxOnDealAmount");
                                            foreach (GridViewRowInfo rowInfo in grdSeller_Buyer.Rows)
                                            {
                                                //bool bl = Convert.ToBoolean(rowInfo.Cells["SelectOwner"].Value);

                                                //if (bl == true)
                                                //{
                                                DataRow drfsb = dtFBRSB.NewRow();
                                                string typ = rowInfo.Cells["Type"].Value.ToString();
                                                if (typ == "Buyer")
                                                {
                                                    drfsb["CNIC"] = rowInfo.Cells["CNIC"].Value == null ? rowInfo.Cells["NTN"].Value.ToString() : rowInfo.Cells["CNIC"].Value.ToString();
                                                    drfsb["Name"] = rowInfo.Cells["Name"].Value.ToString();
                                                    drfsb["FatherName"] = rowInfo.Cells["Father"].Value.ToString();
                                                    drfsb["NTN"] = rowInfo.Cells["NTN"].Value.ToString();
                                                    drfsb["Type"] = typ;
                                                    #region Find Filer , Non-Filer
                                                    if (!string.IsNullOrEmpty(rowInfo.Cells["NTN"].Value.ToString()))
                                                    {
                                                        #region Filer , Non-Filer
                                                        SqlParameter[] prm1 =
                                                        {
                                                     new SqlParameter("@Task","GetFBROwnerType"),
                                                     new SqlParameter("@NTN",ExtractNumberFromString(rowInfo.Cells["NTN"].Value.ToString()))
                                                    };
                                                        DataSet dst1 = cls_dl_NDC.NdcRetrival(prm1);
                                                        if (dst1.Tables.Count > 0)
                                                        {
                                                            if (dst1.Tables[0].Rows.Count > 0)
                                                            {
                                                                if (dst1.Tables[0].Rows[0]["Type"].ToString() == "Filer")
                                                                {
                                                                    drfsb["FBROwnerType"] = "Filer";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                drfsb["FBROwnerType"] = "Non-Filer";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            drfsb["FBROwnerType"] = "Non-Filer";
                                                        }
                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        drfsb["FBROwnerType"] = "Non-Filer";
                                                    }

                                                    #endregion
                                                    drfsb["UniqIDSB"] = drfsb["UniqIDSB"] = rowInfo.Cells["UniqIDSB"].Value == null ? (GetUniqueNumberForSellerBuyer(10) + 1).ToString() : rowInfo.Cells["UniqIDSB"].Value.ToString();
                                                    //drfsb["CPRNo"] = txtWHTk_.Text;
                                                    //drfsb["CPRTaxAmount"] = txtwhtkAmount.Text;
                                                    //drfsb["CalculatedTaxOnDealAmount"] = CalculatedTaxBuyer;

                                                }
                                                else if (typ == "Seller")
                                                {
                                                    drfsb["CNIC"] = rowInfo.Cells["CNIC"].Value == null ? rowInfo.Cells["NTN"].Value.ToString() : rowInfo.Cells["CNIC"].Value.ToString();
                                                    drfsb["Name"] = rowInfo.Cells["Name"].Value.ToString();
                                                    drfsb["FatherName"] = rowInfo.Cells["Father"].Value.ToString();
                                                    drfsb["NTN"] = rowInfo.Cells["NTN"].Value.ToString();
                                                    drfsb["Type"] = typ;

                                                    #region Find Filer , Non-Filer
                                                    if (!string.IsNullOrEmpty(rowInfo.Cells["NTN"].Value.ToString()))
                                                    {
                                                        #region Filer , Non-Filer
                                                        SqlParameter[] prm1 =
                                                        {
                                                    new SqlParameter("@Task","GetFBROwnerType"),
                                                    new SqlParameter("@NTN",ExtractNumberFromString(rowInfo.Cells["NTN"].Value.ToString()))
                                                    };
                                                        DataSet dst1 = cls_dl_NDC.NdcRetrival(prm1);
                                                        if (dst1.Tables.Count > 0)
                                                        {
                                                            if (dst1.Tables[0].Rows.Count > 0)
                                                            {
                                                                if (dst1.Tables[0].Rows[0]["Type"].ToString() == "Filer")
                                                                {
                                                                    drfsb["FBROwnerType"] = "Filer";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                drfsb["FBROwnerType"] = "Non-Filer";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            drfsb["FBROwnerType"] = "Non-Filer";
                                                        }
                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        drfsb["FBROwnerType"] = "Non-Filer";
                                                    }

                                                    #endregion
                                                    drfsb["UniqIDSB"] = rowInfo.Cells["UniqIDSB"].Value == null ? (GetUniqueNumberForSellerBuyer(10) + 1).ToString() : rowInfo.Cells["UniqIDSB"].Value.ToString();

                                                    //drfsb["CPRNo"] = txtWHTc_.Text;
                                                    //drfsb["CPRTaxAmount"] = txtwhtcAmount.Text;
                                                    //drfsb["CalculatedTaxOnDealAmount"] = CalculatedTaxSeller;
                                                }
                                                dtFBRSB.Rows.Add(drfsb);
                                                //}

                                            }
                                            #endregion
                                            #region Buyer Seller CPR Detail

                                            #region DataTable_Column Creation
                                            DataTable_column NTN = new DataTable_column() { ColmnName = "NTN", type = typeof(string) };
                                            DataTable_column CPRTaxAmount = new DataTable_column() { ColmnName = "CPRTaxAmount", type = typeof(double) };
                                            DataTable_column CPRNo = new DataTable_column() { ColmnName = "CPRNo", type = typeof(string) };
                                            DataTable_column TypeSB = new DataTable_column() { ColmnName = "TypeSB", type = typeof(string) };
                                            DataTable_column SerNo = new DataTable_column() { ColmnName = "SerNo", type = typeof(int) };
                                            DataTable_column UniqIDSB = new DataTable_column() { ColmnName = "UniqIDSB", type = typeof(string) };
                                            #endregion
                                            #region Insert DataTabl_Column in List, and Send to Helper to make DataTable
                                            List<DataTable_column> colmn = new List<DataTable_column>();
                                            colmn.Add(NTN);
                                            colmn.Add(CPRTaxAmount);
                                            colmn.Add(CPRNo);
                                            colmn.Add(TypeSB);
                                            colmn.Add(SerNo);
                                            colmn.Add(UniqIDSB);
                                            dtFBRSB_CPRDetail = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                                            #endregion
                                            #region Insertion in DataTable
                                            int rowcount = grdSeller_Buyer.Rows.Count;
                                            dtFBRSB_CPRDetail.Clear();
                                            int srno = 1;
                                            foreach (GridViewRowInfo rowInfo in grdCPRData.Rows)
                                            {
                                                DataRow _row = dtFBRSB_CPRDetail.NewRow();// Create Row for Seller Data
                                                _row["NTN"] = rowInfo.Cells["NTN"].Value.ToString(); ;
                                                _row["CPRTaxAmount"] = Math.Round(Convert.ToDecimal(rowInfo.Cells["CPRAmount"].Value.ToString()));
                                                _row["CPRNo"] = rowInfo.Cells["CPRNo"].Value.ToString();
                                                _row["TypeSB"] = rowInfo.Cells["Type"].Value.ToString();
                                                _row["SerNo"] = srno;
                                                _row["UniqIDSB"] = rowInfo.Cells["UniqIDSB"].Value.ToString();
                                                dtFBRSB_CPRDetail.Rows.Add(_row);
                                                srno = srno + 1;
                                            }
                                            #endregion

                                            #endregion
                                            #region FBR Detail Insertion
                                            if (dtFBRD.Rows.Count > 0 && dtFBRSB.Rows.Count > 0 && dtFBRD_CalculatedTax.Rows.Count > 0 && dtFBRSB_CPRDetail.Rows.Count > 0)
                                            {
                                                SqlParameter[] prtr =
                                                {
                                            new SqlParameter("@NDCNo", NDCID),
                                            new SqlParameter(){ ParameterName = "@tbl_FBRData",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRD},
                                            new SqlParameter(){ ParameterName = "@tbl_FBRD_CalculatedTax",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRD_CalculatedTax},
                                            new SqlParameter(){ ParameterName = "@tbl_FBR_Seller_Buyer",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRSB},
                                            new SqlParameter(){ ParameterName = "@tbl_FBRSB_CPRDetail",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRSB_CPRDetail}
                                            };
                                                int result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDC_FBRDataSave", prtr);

                                                if (result > 0)
                                                {
                                                    MessageBox.Show("FBR Data is Valid and Saved Successfully.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    chkFBRSellerSkip.CheckState = CheckState.Unchecked;
                                                    txtsellerdiscount.Text = "0";
                                                    txtbuyerdiscount.Text = "0";
                                                }
                                            }
                                            else
                                            {
                                                // MessageBox.Show("Both the Seller and Buyer Information are Required.");
                                            }
                                            #endregion


                                            txtTaxCAmountSeller = 0;
                                            txtTaxKAmountBuyer = 0;
                                        }
                                        else
                                        {
                                            MessageBox.Show("FBR Data Not Saved.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        #endregion
                                        #endregion
                                    }
                                    else
                                    {
                                        MessageBox.Show("The CPR No. " + CheckCPRDuplicate() + " are Duplicated.");
                                    }

                                }

                            }
                            else
                            {
                                btnloadgrid_Click(sender, e);
                                MessageBox.Show("Please Enter the FBR Taxes And CPR Numbers.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            #endregion
                        }
                        else
                        {
                            MessageBox.Show("There is no data in Grid.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.InnerException);
            }


        }

        public string ExtractNumberFromString(string original)
        {
            return new string(original.Where(c => Char.IsDigit(c)).ToArray());
        }
        private string CheckCPRDuplicate()
        {
            CPRString_ = "";
            foreach (GridViewRowInfo rw in grdCPRData.Rows)
            {
                string cprno = rw.Cells["CPRNo"].Value.ToString();
                if (!string.IsNullOrEmpty(cprno))
                {
                    if (cprno == "NA")
                    {

                    }
                    else
                    {
                        #region CPR Checking
                        SqlParameter[] prm =
                        {
                         new SqlParameter("@Task","check_CPRNo"),
                         new SqlParameter("@CPRNo",cprno),
                         new SqlParameter("@FileNo",txtFile_No_.Text)
                        };
                        DataSet dst_ = cls_dl_NDC.NdcRetrival(prm);
                        if (dst_.Tables[0].Rows.Count == 0)
                        {
                            // CPRString_ = "";

                        }
                        else if (dst_.Tables[0].Rows.Count > 0)
                        {
                            buyerCheckFiler = false;
                            buyerCheckNonFiler = false;
                            sellerrCheckFiler = false;
                            sellerrCheckNonFiler = false;
                            CPRString_ = dst_.Tables[0].Rows[0]["CPRNo"].ToString() + "," + CPRString_;

                            //"This CPR." + dst_.Tables[0].Rows[0]["CPRNo"].ToString() + "is used against :" + Environment.NewLine +
                            //                " File No." + txtFile_No_.Text + "Owner Name : " + dst_.Tables[0].Rows[0]["Name"].ToString() + Environment.NewLine +
                            //                " CNIC : " + dst_.Tables[0].Rows[0]["CNIC"].ToString() + " Type: " + dst_.Tables[0].Rows[0]["Type"].ToString() + Environment.NewLine +
                            //                " on " + dst_.Tables[0].Rows[0]["Date"].ToString() + Environment.NewLine +
                            //                "So before saving, Please Correct the CPR's No.";
                        }
                        #endregion
                    }

                }
                else
                {
                    MessageBox.Show("Please Enter CPR No.");
                }
            }
            return CPRString_;
        }

        private void grdCPRData_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            //    string typ = "";
            //    if (e.Column.Name == "CPRNo")
            //    {
            //        //e.Row.Cells[""].Value;
            //        int a = e.RowIndex;
            //        string cprno = this.grdCPRData.CurrentCell.Value.ToString();
            //        string SlrByr = this.grdCPRData.CurrentCell.Value.ToString();
            //        //SqlParameter[] prm =
            //        //{
            //        //    new SqlParameter("@Task",""),
            //        //    new SqlParameter("",cprno),
            //        //    new SqlParameter("",txtFile_No_.Text)
            //        //};
            //        //foreach (GridViewRowInfo row in grdSeller_Buyer.Rows)
            //        //{
            //        //    if (cprno == row.Cells["CPRNo"].Value.ToString())
            //        //    {
            //        //        typ = row.Cells["Type"].Value.ToString();
            //        //    }
            //        //}
            //        grdSeller_Buyer.Rows[roIndexCPRDetail].Cells["Type"].Value = typ;
            //    }
            //    if (grdCPRData.RowCount > 0)
            //    {
            //        if (e.Column.Name == "CNIC")
            //        {
            //            int a = e.RowIndex;
            //        }

            //    }
        }

        private void grdCPRData_CellClick(object sender, GridViewCellEventArgs e)
        {

        }

        private string PercentageSurcharge()
        {
            if (rd25per.CheckState == CheckState.Checked)
            {
                return "0.25";
            }
            else if (rd50per.CheckState == CheckState.Checked)
            {
                return "0.50";
            }
            else if (rd75per.CheckState == CheckState.Checked)
            {
                return "0.75";
            }
            else
            {
                return "1";
            }
        }

        private void btnGenerateSurchargeChallan_Click(object sender, EventArgs e)
        {
            if (grdSeller_Buyer.RowCount > 0)
            {
                #region Surcharge Generation
                try
                {

                    #region Account Statement of Finance Part Reading and Comparing
                    DataSet dts = AccountStatmentView();
                    int Surcharge = dts.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                                  .Sum(r => r.Field<int>("Surcharge"));
                    int TotalWaieOffSurcharge = dts.Tables[0].AsEnumerable().Where(r => r.Field<int?>("TotalWaiveOffSurcharge") != null)
                                                  .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));
                    double TotalSurchargePaid = Convert.ToDouble(dts.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString());


                    //// Surcharge Calculation
                    double DueSurchAmount = Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge;
                    #endregion
                    if (DueSurchAmount > 0)
                    {
                        SqlParameter[] param = {
                                        new SqlParameter("@Task","SurchargeChallanGenerateonbaseofPercentage"),
                                        new SqlParameter("@File_No",txtFile_No_.Text),
                                        new SqlParameter("@UserID",clsUser.ID),
                                        new SqlParameter("@PERCENTSurcharge",PercentageSurcharge()),
                                        new SqlParameter("@DueSurchAmount_AccStmnt",DueSurchAmount)
                                       };
                        DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_NDC_Challan", param);
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string ChallanID = ds.Tables[0].Rows[0]["ChallanID"].ToString();
                                if (ChallanID != "0")
                                {
                                    DataSet ChallanDataset = new DataSet();
                                    SqlParameter[] prm3 =
                                    {
                                    new SqlParameter("@Task","GetChallReportDetail"),
                                    new SqlParameter("@ChallanID",ChallanID)
                                    };

                                    ChallanDataset = cls_dl_Challan.Challan_Reader(prm3);
                                    ChallanDataset _ds = new ChallanDataset();

                                    _ds.Tables["tblChallan"].Merge(ChallanDataset.Tables[0], true, MissingSchemaAction.Ignore);
                                    _ds.Tables["tblChallanDetail"].Merge(ChallanDataset.Tables[1], true, MissingSchemaAction.Ignore);
                                    ChallanDataset = null;


                                    frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                                    obj.ShowDialog();
                                }
                                else
                                {
                                    RadMessageBox.Show("There is no Due Surcharge on this File No" + txtFile_No_.Text + " Upto " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine
                                        + "For Confirmation of Surcharge amount check Account Statement." + Environment.NewLine
                                        + "-------------------------- OR ---------------------------" + Environment.NewLine
                                        + "Invalid Due Surcharge Calculation.Contact with MIS Branch."
                                        );
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Total Surcharge upto Current date is : " + DueSurchAmount.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something intercepting the Process\n" + ex.Message);
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Seller & Buyer Information is missing. Kindly fill the Table.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdCPRData_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "CNIC")
                {
                    string cnc = e.Row.Cells["CNIC"].Value.ToString();
                    foreach (GridViewRowInfo rw in grdSeller_Buyer.Rows)
                    {
                        string CNIC = rw.Cells["CNIC"].Value.ToString();
                        string type = rw.Cells["Type"].Value.ToString();
                        string name = rw.Cells["Name"].Value.ToString();
                        if (cnc == CNIC)
                        {
                            e.Row.Cells["Type"].Value = type;
                            e.Row.Cells["Name"].Value = name;
                        }
                    }
                    //MessageBox.Show(cnc);
                }

                if (e.Column.Name == "CPRAmount")
                {
                    string tpe = e.Row.Cells["Type"].Value.ToString();
                    string ntn = e.Row.Cells["NTN"].Value.ToString();
                    if (!(string.IsNullOrEmpty(tpe)) && !(string.IsNullOrEmpty(ntn)))
                    {
                        foreach (GridViewRowInfo rw in grdSeller_Buyer.Rows)
                        {
                            string CNIC = rw.Cells["CNIC"].Value.ToString();
                            string type = rw.Cells["Type"].Value.ToString();
                            if (ntn == CNIC && tpe == type)
                            {
                                e.Row.Cells["UniqIDSB"].Value = rw.Cells["UniqIDSB"].Value.ToString(); ;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void grdSeller_Buyer_CellValueChanged_1(object sender, GridViewCellEventArgs e)
        {
            try
            {

                if (e.Column.Name == "Name")
                {
                    if (e.RowIndex < 0)
                    {
                        //string slr = string.IsNullOrEmpty(e.Row.Cells["Type"].Value.ToString()) ? "" : e.Row.Cells["Type"].Value.ToString();
                        //if (slr != "Seller")
                        //{
                        string type = "Buyer";
                        e.Row.Cells["Type"].Value = type;
                        //}
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Buyer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFile_No_.Text))
                {
                    buyerCheckFiler = false;
                    buyerCheckNonFiler = false;
                    sellerrCheckFiler = false;
                    sellerrCheckNonFiler = false;
                    frm_AddDummyBuyer frm = new frm_AddDummyBuyer(txtFile_No_.Text, true, "Save");
                    frm.ShowDialog();
                    grdSeller_Buyer.DataSource = null;
                    Select_CurrentOwner_Info_Against_FileNo_("Add New Dummy Buyer");
                }
                else
                {
                    MessageBox.Show("Please Enter Valid File No.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chk_OutStationCharges__Click(object sender, EventArgs e)
        {

        }

        private void chk_OutStationCharges_1_CheckStateChanging(object sender, CheckStateChangingEventArgs args)
        {
            // MessageBox.Show("Check"+args.NewValue.ToString()+" Old"+ args.OldValue.ToString());
            if (args.NewValue == CheckState.Checked)
            {
                gpOUTSTATFee.Visible = true;
            }
            if (args.NewValue == CheckState.Unchecked | args.NewValue == CheckState.Indeterminate)
            {
                gpOUTSTATFee.Visible = false;
            }
        }

        private void chkSellerhavePlotmorethen3years_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSellerhavePlotmorethen3years.CheckState == CheckState.Checked)
            {
                buyerCheckFiler = true;
                buyerCheckNonFiler = true;
                sellerrCheckFiler = true;
                sellerrCheckNonFiler = true;
                rdbFBR.CheckState = CheckState.Unchecked;
                FBROther.CheckState = CheckState.Unchecked;
                txtDealValue.Text = "";
                grdCPRData.DataSource = null;
                grdFBR.Enabled = false;
                btnNDCCreate_.Enabled = true;
            }
            else
            {
                buyerCheckFiler = false;
                buyerCheckNonFiler = false;
                sellerrCheckFiler = false;
                sellerrCheckNonFiler = false;
                rdbFBR.CheckState = CheckState.Checked;
                rdbFBR_CheckStateChanged(sender, e);
                btnloadgrid_Click(sender, e);
                grdFBR.Enabled = true;

            }
        }

        private void rdbdealer_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdbdealer.CheckState == CheckState.Checked)
            {
                BindDealerListWithDropDown();
                drpDealerList.Enabled = true;
            }
            else
            {
                while (drpDealerList.Items.Count > 0)
                    drpDealerList.Items.RemoveAt(0);
                drpDealerList.Text = "";
                drpDealerList.Enabled = false;

            }
        }

        private void rdbPlotOwner_CheckStateChanged(object sender, EventArgs e)
        {
            if (rdbPlotOwner.CheckState == CheckState.Checked)
            {

                while (drpDealerList.Items.Count > 0)
                    drpDealerList.Items.RemoveAt(0);
                drpDealerList.Text = "";
                drpDealerList.Enabled = false;
            }
        }

        private void txtFBRFee_minus_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtFBRFee_minus.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtFBRFee_minus.Text = txtFBRFee_minus.Text.Remove(txtFBRFee_minus.Text.Length - 1);
            }
        }

        private void txtTFRFee_minus_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTFRFee_minus.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtTFRFee_minus.Text = txtTFRFee_minus.Text.Remove(txtTFRFee_minus.Text.Length - 1);
            }
        }

        private void txtmbrfee_minus_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtmbrfee_minus.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtmbrfee_minus.Text = txtmbrfee_minus.Text.Remove(txtmbrfee_minus.Text.Length - 1);
            }
        }

        private void txtMbrFrmFee_minus_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtMbrFrmFee_minus.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtMbrFrmFee_minus.Text = txtMbrFrmFee_minus.Text.Remove(txtMbrFrmFee_minus.Text.Length - 1);
            }
        }

        private void txtStmDtyFee_minus_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtStmDtyFee_minus.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtStmDtyFee_minus.Text = txtStmDtyFee_minus.Text.Remove(txtStmDtyFee_minus.Text.Length - 1);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTFRFee_minus.Text = "0";
            txtmbrfee_minus.Text = "0";
            txtMbrFrmFee_minus.Text = "0";
            txtStmDtyFee_minus.Text = "0";
        }

        private void chkenable_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkenable.CheckState == CheckState.Checked)
            {
                grpFeesinParts.Enabled = true;
            }
            else
            {
                grpFeesinParts.Enabled = false;
            }
        }

        private void chkfbrenable_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkfbrenable.CheckState == CheckState.Checked)
            {
                grpfbrenbl.Enabled = true;
            }
            else
            {
                grpfbrenbl.Enabled = false;
            }
        }

        private void btnfbrreset_Click(object sender, EventArgs e)
        {
            txtFBRFee_minus.Text = "0";
        }

        private void chkFBRSellerSkip_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFBRSellerSkip.CheckState == CheckState.Checked)
            {
                sellerrCheckFiler = true;
                sellerrCheckNonFiler = true;
                btnNDCCreate_.Enabled = true;
            }
            else
            {
                sellerrCheckFiler = false;
                sellerrCheckNonFiler = false;
            }
        }

        private void btnapplyfornewNDC_Click(object sender, EventArgs e)
        {
            try
            {

                if (NDCRenewChallanStatus == "ApplyForRenewalNDC")
                {
                    #region Renew Code
                    if (MessageBox.Show("Are you sure to delete old FBR Tax detail.", "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlParameter[] parameter =
                        {
                    new SqlParameter("@Task", "CheckFBRDetailForDuplicate"),
                    new SqlParameter("@FileNo",txtFile_No_.Text)
                    };
                        DataSet ds = cls_dl_NDC.NdcRetrival(parameter);
                        int fbrid = int.Parse(ds.Tables[0].Rows[0]["FBRID"].ToString());
                        SqlParameter[] prm =
                        {
                    new SqlParameter("@Task","DeleteFBRDetail"),
                    new SqlParameter("@FBRID",fbrid)
                    };
                        int rslt = cls_dl_NDC.NdcNonQuery(prm);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Deleted Successfully.");
                            btnloadgrid_Click(sender, e);
                        }
                    }
                    #endregion
                }
                else
                {
                    MessageBox.Show("There is no Rnewal Challan Detected.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkDiscountSellerBuyer_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkDiscountSellerBuyer.Checked)
            {
                grpDiscountSellerBuyer.Enabled = true;
            }
            else
            {
                grpDiscountSellerBuyer.Enabled = false;
            }
        }

        private void chkSellerhavePlotmorethen3yearsLglHr_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnverificationfee_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdSeller_Buyer.RowCount > 0)
                {

                    string UrgentNDCCharges = chk_urgentNDC_.CheckState == CheckState.Checked ? "1" : "0";
                    string UrgentTFRCharges = chk_UrgentTransfer_.CheckState == CheckState.Checked ? "1" : "0";
                    string OutStationAllocationTFR = chk_OutStationCharges_.CheckState == CheckState.Checked ? "1" : "0";
                    string Sellcheck = rdSellerOST.CheckState == CheckState.Checked ? "1" : "0";
                    string Buyercheck = rdBuyerOST.CheckState == CheckState.Checked ? "1" : "0";

                    SqlParameter[] param = {
                                        new SqlParameter("@Task","GenerateVerificationChallanforSeller"),
                                        new SqlParameter("@File_No",txtFile_No_.Text),
                                        new SqlParameter("@UserID",clsUser.ID)
                                        //new SqlParameter("@NDCUrgentFee",UrgentNDCCharges),
                                        //new SqlParameter("@UrgentTFRFee",UrgentTFRCharges),
                                        //new SqlParameter("@OutStationTFRFee",OutStationAllocationTFR),
                                        //new SqlParameter("@OUTSTFee_Seller",Sellcheck),
                                        //new SqlParameter("@OUTSTFee_Buyer",Buyercheck)

                    };
                    DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_NDC_Challan", param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string ChallanID = ds.Tables[0].Rows[0]["ChallanID"].ToString();
                            DataSet ChallanDataset = new DataSet();
                            SqlParameter[] prm3 =
                            {
                            new SqlParameter("@Task","GetChallReportDetail"),
                            new SqlParameter("@ChallanID",ChallanID)
                           };

                            ChallanDataset = cls_dl_Challan.Challan_Reader(prm3);
                            ChallanDataset _ds = new ChallanDataset();

                            _ds.Tables["tblChallan"].Merge(ChallanDataset.Tables[0], true, MissingSchemaAction.Ignore);
                            _ds.Tables["tblChallanDetail"].Merge(ChallanDataset.Tables[1], true, MissingSchemaAction.Ignore);
                            ChallanDataset = null;
                            frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                            obj.ShowDialog();
                        }
                    }
                    else
                    {
                        // throw new Exception();

                        MessageBox.Show("Seller & Buyer Information is missing. Kindly fill the Table OR Check the Remaing Due Amount .");
                    }

                }
                else
                {
                    MessageBox.Show("Seller & Buyer Information is missing. Kindly fill the Table.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //btnGenerateSellerChallan.Enabled = false;
                ////btnGenerateSellerChallan.Text = "Challan is Generated";
                //btnGenerateSellerChallan.ForeColor = Color.DarkGreen;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void txtFile_No__KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
           // {
           //     btn_File_Verify_Click(null, null);
           // }
        }

        private void grdCPRData_Click(object sender, EventArgs e)
        {

        }

        private void rdbLegalHeirSvc_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }

        private void txtRemarks__TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddSellertoFBR_Click(object sender, EventArgs e)
        {
            SqlParameter[] Param = {
                        new SqlParameter("@Task","FBRDataLoading"),
                        new SqlParameter("@NDCNo",NDCID)
                    };
            DataSet fbrcprsavedata = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDC_FBRDataLoad", Param);
            if (fbrcprsavedata.Tables.Count > 0)
            {

                if (fbrcprsavedata.Tables[0].Rows.Count > 0)
                {
                    string DealType = fbrcprsavedata.Tables[0].Rows[0]["DealType"].ToString();
                    string Deal_Amount = fbrcprsavedata.Tables[0].Rows[0]["Deal_Amount"].ToString();
                    txtDealValue.Text = Deal_Amount;

                    foreach (DataRow item in fbrcprsavedata.Tables[0].Rows)
                    {
                        if (item["Type"].ToString() == "Buyer" && item["txtFiler_NonFiler"].ToString() == "Filer")
                        {
                            sellerrCheckFiler = true;
                            sellerrCheckNonFiler = false;
                        }
                        else
                        {
                            sellerrCheckFiler = false;
                            sellerrCheckNonFiler = true;
                        }
                        if (item["Type"].ToString() == "Seller" && item["txtFiler_NonFiler"].ToString() == "Filer")
                        {
                            buyerCheckFiler = true;
                            buyerCheckNonFiler = false;
                        }
                        else
                        {
                            buyerCheckFiler = false;
                            buyerCheckNonFiler = true;
                        }

                    }
                    if (DealType == "FBR")
                    {
                        rdbFBR.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        FBROther.CheckState = CheckState.Checked;
                    }

                    grdCPRData.DataSource = fbrcprsavedata.Tables[0].DefaultView;
                }
                else
                {
                    BindColumnToFBRSellerBuyerCPRDetailGrid();
                }
            }
        }
    }
}
