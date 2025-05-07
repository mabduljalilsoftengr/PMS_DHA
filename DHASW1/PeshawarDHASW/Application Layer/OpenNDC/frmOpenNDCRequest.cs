using PeshawarDHASW.Application_Layer.Chalan;
using PeshawarDHASW.Report.Challan;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.NDC.Baskets;
using PeshawarDHASW.Application_Layer.NDC.NDC_File_BuyerSellerInfo;
using PeshawarDHASW.Data_Layer.clsCaution;
using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using PeshawarDHASW.Application_Layer.NDC;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Text.RegularExpressions;

namespace PeshawarDHASW.Application_Layer.OpenNDC
{
    public partial class frmOpenNDCRequest : Telerik.WinControls.UI.RadForm
    {
        #region Variables List
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
        private string chkCorporate_Check_ { get; set; }
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
        private DataSet dstdst = new DataSet();
        private DataSet dstst = new DataSet();
        private DataSet datset = new DataSet();
        private bool dealerFlag { get; set; }

        public int FileMapKey { get; set; }
        public string FileNo { get; set; }
        public int DealerID { get; set; }
        public string DealerName { get; set; }
        public int PreTransferDealId { get; set; }
        public OpenNDC_Buyer Buyer { get; set; }
        #endregion

        public frmOpenNDCRequest()
        {
            InitializeComponent();
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
            // drpStmpRefNo_.Text = "";
            txtSector_.Text = "";
            txtRemarks_.Text = "";
            txtPhase_.Text = "";
            //txtStampDuty_.Text = "";
            //txtDealValue.Text = "";
            //chk_urgentNDC_.CheckState = CheckState.Unchecked;
            //chk_UrgentTransfer_.CheckState = CheckState.Unchecked;
            //chk_OutStationCharges_.CheckState = CheckState.Unchecked;
            //chbMembershipFormFeeSkip.CheckState = CheckState.Unchecked;
            //chkSellerhavePlotmorethen3years.CheckState = CheckState.Unchecked;
            //if(rdbNormal.IsChecked)
            // rdbNormal.CheckState = CheckState.Checked;
            grdSeller_Buyer.DataSource = null;
            //  grdCPRData.DataSource = null;
            ddn.Text = "#";
            ddmnt.Text = "#";
            chno.Text = "#";
            chm.Text = "#";

            //btnReset_Click(null, null);
            //chkenable.CheckState = CheckState.Unchecked;
            //txtTFRFee_minus.Text = "0";
            //txtmbrfee_minus.Text = "0";
            //txtMbrFrmFee_minus.Text = "0";
            //txtStmDtyFee_minus.Text = "0";
            //txtFBRFee_minus.Text = "0";
            buyerCheckFiler = false;
            buyerCheckNonFiler = false;
            sellerrCheckFiler = false;
            sellerrCheckNonFiler = false;
            //rdbHiba.CheckState = CheckState.Unchecked;
            //rdbLegalHeirCivil.CheckState = CheckState.Unchecked;
            //rdbLegalHeirSvc.CheckState = CheckState.Unchecked;
            //chkNDCReissue.CheckState = CheckState.Unchecked;
            //chkCorporate.CheckState = CheckState.Unchecked;
            UNF_ChallanID = 0;
            UNF_ChallanNo = "";
            UTF_ChallanID = 0;
            UTF_ChallanNo = "";
            UALF_ChallanID = 0;
            UALF_ChallanNo = "";

        }
        public frmOpenNDCRequest(int _PreTransferDealId, int _FileMapKey, string _FileNo, int _DealerID, string _DealerName, bool _dealerFlag, OpenNDC_Buyer _buyerinfo)
        {
            InitializeComponent();
            FileMapKey = _FileMapKey;
            FileNo = _FileNo;
            DealerID = _DealerID;
            DealerName = _DealerName;
            dealerFlag = _dealerFlag;
            txtFile_No_.Text = FileNo;
            txtDealerName.Text = _DealerName;
            PreTransferDealId = _PreTransferDealId;
            reqstdby = _DealerName;
            Buyer = _buyerinfo;
            if (MessageBox.Show("Are you sure add Buyer (Dealer Owner Information) to Open NDC ", "Please Confirm Dealer as Buyer for OpenNDC", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                BuyerAddingtoNDC(_buyerinfo);
            }
            btn_File_Verify_Click(null, null);
        }

        private void BuyerAddingtoNDC(OpenNDC_Buyer buyerinfo)
        {
            try
            {

                SqlParameter[] prm =
                   {
                      new SqlParameter("@Task","InsertDummyBuyer"),
                      new SqlParameter("@Name",buyerinfo.BuyerName),
                      new SqlParameter("@F_H_W_Name",buyerinfo.FatherName),
                      new SqlParameter("@SB_Address",buyerinfo.Address),
                      new SqlParameter("@SBCNIC",buyerinfo.NTN),
                      new SqlParameter("@NTN",buyerinfo.NTN),
                      new SqlParameter("@FileNo",buyerinfo.FileNo),
                      new SqlParameter("@MobileNo",buyerinfo.MobileNo),
                      new SqlParameter("@Status","Active"),
                      new SqlParameter("@Type","Buyer"),
                      new SqlParameter("@UserID",Models.clsUser.ID)
                    };
                int rslt = cls_dl_NDC.NdcNonQuery(prm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Buyer Adding to OpenNDC  " + ex.Message);
            }
        }

        private void btn_File_Verify_Click(object sender, EventArgs e)
        {
            if (txtFile_No_.Text != "" && dealerFlag)
            {

                //   MembershipFormFeeSkipInclude_ = chbMembershipFormFeeSkip.Checked ? "SkipMembershipFormFee" : "IncludeMembershipFormFee";

                if (PreventAgainApply_() == true && CheckCaution_() == true && FileActiveNotBlock() == true)
                {
                    CheckFileNoForNDCRenewalApply();
                    ReConsilation(txtFile_No_.Text);
                    Select_CurrentOwner_Info_Against_FileNo_("");
                    GetPlotNoAgainst();
                    BindColumnToFBRSellerBuyerCPRDetailGrid();
                }



            }
            else
            {
                MessageBox.Show("File No. and Dealer Name (If you select Dealer Radio button.)", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    btn_Buyer.Enabled = false;

                }
                else
                {
                    btn_Buyer.Enabled = true;
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
                    btnNDCCreate_.Enabled = false;
                    btn_Buyer.Enabled = false;

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
                    btnNDCCreate_.Enabled = true;
                    btn_Buyer.Enabled = true;
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
        private void ReConsilation(string fileno)
        {
            SqlParameter[] prmt =
            {
              new SqlParameter("@Task","Rece_Plan_Adjust"),
              new SqlParameter("@FileNo",fileno)
            };
            int rsult = Data_Layer.Installment.cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prmt);
        }
        private void Select_CurrentOwner_Info_Against_FileNo_(string getstring)
        {
            // bool blvr = false;
            try
            {
                int mbcount = 0;


                decimal tfrfee_minus = 0;// Convert.ToDecimal(txtTFRFee_minus.Text == "" ? "0" : txtTFRFee_minus.Text);//Ignore
                decimal mbrfee_minus = 0;// Convert.ToDecimal(txtmbrfee_minus.Text == "" ? "0" : txtmbrfee_minus.Text);//Ignore
                decimal mbrfrmfee_minus = 0;// Convert.ToDecimal(txtMbrFrmFee_minus.Text == "" ? "0" : txtMbrFrmFee_minus.Text);//Ignore
                decimal stmdtyfee_minus = 0;// Convert.ToDecimal(txtStmDtyFee_minus.Text == "" ? "0" : txtStmDtyFee_minus.Text);//Ignore

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



                if (dealerFlag == true)
                {
                    reqstdby = txtDealerName.ToString();
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

                        stampDutyAmount = 0;// StampFees(); Ignore

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
                        //   btnloadgrid_Click(null, null);

                        //   btnrefres_Click(null, null);
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
                        dtb = Installment_Surcharge_Detail_For_Report_Table(dueamount, receamount,
                            remainInstAmount, dueSurcharge, recSurcharge, waveOffSurcharge,
                            remainSurcharge, tfrFee, membershipFee, membershipFormFee, utfrFee,
                            osCharges, undcFee, rindcFee, TotalDueRemaining, stampDutyAmount, txtFile_No_.Text, reqstdby);
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
                                    //   grpBInfo.Enabled = true;
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
                                    //    btnloadgrid_Click(null, null);
                                    // btnrefres_Click(null, null);
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
                            //TradeOff Ignore StampDuty
                            double stampDutyAmount = 0;
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

        private decimal GetUniqueNumberForSellerBuyer(decimal uqnmbr)
        {
            UniquenmbrforSB = Convert.ToDecimal(DateTime.Now.ToString("yyMMddHHmmssmmffffff"));
            return UniquenmbrforSB;
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
                    btn_Buyer.Enabled = false;
                    //grdChallanPayment.Enabled = false;
                    //drpStmpRefNo_.Enabled = false;
                    //txtStampDuty_.Enabled = false;
                    //btnrefres.Enabled = false;
                    //grpBInfo.Enabled = false;
                    SqlParameter[] prmtr =
                    {
                     new SqlParameter("@Task","NDCSearch"),
                     new SqlParameter("@NDCNo",NDCID),
                     new SqlParameter("@string","Str_Modify")
                     };

                    DataSet ds = new DataSet();
                    ds = cls_dl_NDC.NdcRetrival(prmtr);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        #region Change NDCExpireDate Format and Disable TextBox of FileNo
                        // Change NDCExpireDate Format and Disable TextBox of FileNo
                        //string EexpdateNDC = ds.Tables[0].Rows[0]["NDCExpireDate"].ToString();
                        //DateTime ExpDateTimeNDC = DateTime.ParseExact(EexpdateNDC, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        this.Text = "TradeOff Modify";

                        //tabControl1.TabPages.RemoveAt(0);
                        //////////////////////////////////////////////////////////////
                        #endregion
                        // if (ds.Tables[0].Rows[0]["NDCType"].ToString() == "Normal") { rdbNormal.CheckState = CheckState.Checked; }
                        //else { rdbHiba.CheckState = CheckState.Checked; }


                        //if (ds.Tables[0].Rows[0]["NDCTypeNormalUrgent"].ToString() == "Urgent") { chk_urgentNDC_.CheckState = CheckState.Checked; }
                        // if (ds.Tables[0].Rows[0]["TFRType"].ToString() == "Urgent") { chk_UrgentTransfer_.CheckState = CheckState.Checked; }
                        // if (ds.Tables[0].Rows[0]["OutStationCharges"].ToString() == "Yes") { chk_OutStationCharges_.CheckState = CheckState.Checked; }


                        // Check the Dealer Radio Button and Load the Dealers List in Dropdown
                        //rdbdealer.CheckState = CheckState.Checked;
                        //rdbdealer_CheckStateChanged(null, null);

                        //int ind = drpDealerList.FindString(ds.Tables[0].Rows[0]["RequestedBy"].ToString());
                        //if (ind > 0)
                        //{
                        //    drpDealerList.SelectedIndex = ind;
                        //}
                        //else
                        //{
                        //    drpDealerList.Text = ds.Tables[0].Rows[0]["RequestedBy"].ToString();
                        //}


                        // Bind the Selected Value of database with Dropdown
                        //string str_ = ds.Tables[0].Rows[0]["RequestedBy"].ToString();
                        //foreach (RadListDataItem item in drpDealerList.Items)
                        //{
                        //    string strv = item.Value.ToString();
                        //    if (strv == str_)
                        //    {
                        //        item.Selected = true;
                        //    }
                        //}

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
                        // txtStampDuty_.Text = ds.Tables[0].Rows[0]["StampDuty"].ToString();
                        txtRemarks_.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                        dtpNDCExpire_.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["NDCExpireDate"].ToString());
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

        private void btnGenerateSellerChallan_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdSeller_Buyer.RowCount > 0)
                {

                    string UrgentNDCCharges = "0";
                    string UrgentTFRCharges = "0";
                    string OutStationAllocationTFR = "0";
                    string Sellcheck = "0";
                    string Buyercheck = "0";

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

        private string PercentageSurcharge()
        {
            //if (rd25per.CheckState == CheckState.Checked)
            //{
            //    return "0.25";
            //}else
            if (rd50per.CheckState == CheckState.Checked)
            {
                return "0.50";
            }
            //else if (rd75per.CheckState == CheckState.Checked)
            //{
            //    return "0.75";
            //}
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

        private void frmOpenNDCRequest_Load(object sender, EventArgs e)
        {
            dtpIssueDate_.MinDate = DateTime.UtcNow;
            dtpIssueDate_.Value = DateTime.UtcNow;
            dtpNDCExpire_.MinDate = DateTime.UtcNow;
            dtpNDCExpire_.Value = DateTime.UtcNow.AddDays(60);
        }


        private void btnNDCCreate__Click(object sender, EventArgs e)
        {
            try
            {
                if (chkFBRSkip.CheckState == CheckState.Checked)
                {

                }
                else
                {
                    bool Verification = FBR_Data_Check();
                    if (Verification == false)
                    {
                        return;
                    }
                }

                #region
                if (NDCID == 0)
                {
                    dtpIssueDate_.Value = DateTime.Now;
                    dtpNDCExpire_.Value = DateTime.Now.AddDays(30);

                    if (
                        txtDDNo_ != "" && txtDHAPChNo_ != ""
                        //   && (buyerCheckFiler == true || buyerCheckNonFiler == true) 
                        //   && (sellerrCheckFiler == true || sellerrCheckNonFiler == true)
                        )
                    {
                        try
                        {
                            if (NDCRenewChallanStatus == "ApplyForRenewalNDC")
                            {
                                if (string.IsNullOrEmpty(txtRemarks_.Text))
                                {
                                    MessageBox.Show("Please Enter Old NDC No. with detail in Remarks Textbox.");
                                    return;
                                }
                            }
                            #region DataTable Insertion
                            SqlParameter[] parmtr =
                            {
                            new SqlParameter("@Task","insert"),
                            new SqlParameter(){ ParameterName = "@tbl_NDC",SqlDbType = SqlDbType.Structured, SqlValue = NDC_Table_()},
                            new SqlParameter(){ ParameterName = "@tbl_File_Seller_Buyer",SqlDbType = SqlDbType.Structured, SqlValue = File_Seller_Buyer_Table_()}
                            };
                            int rslt = 0;
                            rslt = cls_dl_NDC.NdcNonQuery(parmtr);
                            if (rslt > 0)
                            {
                                OpenNDCStatusUpdate(PreTransferDealId);
                                FBR_Save_CPR(PreTransferDealId);
                                MessageBox.Show("NDC Created Successfully, and Forwarded to the Concerned authority for further processing.Thank you", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Clear();
                                this.Close();
                                btnNDCCreate_.Enabled = false;
                            }
                            #endregion
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

                }
                else
                {
                    #region DataTable Updation
                    //SqlParameter[] parmtr =
                    //{
                    // new SqlParameter("@Task","update"),
                    // new SqlParameter(){ ParameterName = "@tbl_NDC",SqlDbType = SqlDbType.Structured, SqlValue = NDC_Table_()},
                    // new SqlParameter(){ ParameterName = "@tbl_File_Seller_Buyer",SqlDbType = SqlDbType.Structured, SqlValue = File_Seller_Buyer_Table_()}
                    // };
                    string ndcType = "Normal";              // rdbHiba.IsChecked ? "Hiba" : "Normal";
                    string ndcTypeNormalUrgent = "Normal";  //chk_urgentNDC_.Checked ? "Urgent" : "Normal";
                    string TfrType = "Normal";              //chk_UrgentTransfer_.Checked ? "Urgent" : "Normal";
                    string outstation = "No";               //chk_OutStationCharges_.Checked ? "Yes" : "No";
                    reqstdby = DealerName;

                    SqlParameter[] parmtr =
                    {
                     new SqlParameter("@Task","Update_NDC"),
                     new SqlParameter("@NDCType",ndcType),
                     new SqlParameter("@NDCTypeNormalUrgent",ndcTypeNormalUrgent),
                     new SqlParameter("@TfrType",TfrType),
                     new SqlParameter("@OutStation",outstation),
                     new SqlParameter("@DDNoPOReceipt",ddn.Text),
                     new SqlParameter("@Seller_Amount",ddmnt.Text),
                     new SqlParameter("@DHAP_Challan_No",chno.Text),
                     new SqlParameter("@Purchaser_Amount",chm.Text),
                     new SqlParameter("@RequestedBy",reqstdby),
                     new SqlParameter("@NDCNo",NDCID),
                     new SqlParameter("@Remarks",txtRemarks_.Text)
                     };
                    int rslt = 0;
                    rslt = cls_dl_NDC.NdcNonQuery(parmtr);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Updation is Successful.");
                        Clear();
                        this.Close();
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnNDCCreate__Click.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
            }
        }
        private void OpenNDCStatusUpdate(int ID)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","UpdateStatusofOpenNDC"),
                    new SqlParameter("@ID",ID),
                    new SqlParameter("@TransferStatus","NDC_Created"),
                    new SqlParameter("@FileNo",txtFile_No_.Text),
                    new SqlParameter("@DealDate",DateTime.UtcNow),
                };
                SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PreTransferRequest", param);
            }
            catch (Exception ex)
            {

            }
        }
        private DataTable NDC_Table_()
        {
            DataTable NDCTbl = new DataTable();
            string ndcType = "";
            ndcType = "Normal";

            string ndcTypeNormalUrgent = "Normal";
            string TfrType = "Normal";
            string outstation = "No";

            //int UNFChallanID = UNF_ChallanID;
            //string UNFChallanNo = UNF_ChallanNo;
            //int UTFChallanID = UTF_ChallanID;
            //string UTFChallanNo = UTF_ChallanNo;
            //int UALFChallanID = UALF_ChallanID;
            //string UALFChallanNo = UALF_ChallanNo;

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
                row["StampDuty"] = "0";// txtStampDuty_.Text;
                row["FileKey"] = FileKeyID;
                row["userID"] = Models.clsUser.ID;
                row["Remarks"] = txtRemarks_.Text;
                row["StatusofNDC"] = "Incomplete";
                row["NDCExpireDate"] = dtpNDCExpire_.Value.ToString("dd/MM/yyyy");
                row["stmpDutyID"] = stmdtID_;
                row["NDCTypeNormalUrgent"] = ndcTypeNormalUrgent;
                row["RequestedBy"] = DealerName;
                row["TFRType"] = TfrType;
                row["OutStationCharges"] = outstation;
                row["UNFChallanID"] = UNF_ChallanID;
                row["UNFChallanNo"] = UNF_ChallanNo;
                row["UTFChallanID"] = UTF_ChallanID;
                row["UTFChallanNo"] = UTF_ChallanNo;
                row["UALFChallanID"] = UALF_ChallanID;
                row["UALFChallanNo"] = UALF_ChallanNo;
                row["NDCCategory"] = "OpenNDC";

                row["Corporate"] = false;
                row["MembershipType"] = "";
                row["TFRFee_Waive"] = 0;
                row["MbrFee_Waive"] = 0;
                row["MbrFeeForm_Waive"] = 0;
                row["StmDtyFee_Waive"] = 0;
                row["SkipMbrShipFormFee"] = false;
                row["PlotHoldGreaterThen3Years"] = false;
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
            ///
            dt.Columns.Add("FileNo");
            dt.Columns.Add("MembershipNo");
            ////
            dt.Columns.Add("UniqIDSB");
            foreach (GridViewRowInfo row in grdSeller_Buyer.Rows)
            {
                //bool bl = Convert.ToBoolean(row.Cells["SelectOwner"].Value);
                //if (bl == true)
                //{
                if (row.Cells["Type"].Value.ToString() == "Seller")
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
                    dtr["FileNo"] = txtFile_No_.Text;
                    dtr["MembershipNo"] = row.Cells["MembershipNo"].Value.ToString();
                    dtr["UniqIDSB"] = row.Cells["UniqIDSB"].Value.ToString();  //Convert.ToDecimal(DateTime.Now.ToString("yyMMddHHmmssmmffffff")); 
                    dt.Rows.Add(dtr);
                }
                //}
            }
            grdCPRData.DataSource = dt.DefaultView;


        }
        public string ExtractNumberFromString(string original)
        {
            return new string(original.Where(c => Char.IsDigit(c)).ToArray());
        }

        private void btnSaveCPRData_Click(object sender, EventArgs e)
        {

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

        private void grdCPRData_CellValidated(object sender, CellValidatedEventArgs e)
        {
            if (e.Column.Name == "CPRNo")
            {
                string CPRNo = e.Row.Cells["CPRNo"].Value.ToString();
                Match m = Regex.Match(CPRNo, @"IT-[0-9]{8}-[0-9]{4}-[0-9]{0,9}");
                if (m.Success == false)
                {
                    MessageBox.Show("CPR No Format [IT-20220101-0101-000000] Format is not Match.");
                    btnNDCCreate_.Enabled = false;
                    return;
                }
                else
                {
                    SqlParameter[] param = {
                        new SqlParameter("@Task","CPRDuplicateCheckwithOpenNDC"),
                        new SqlParameter("@CPRNo",CPRNo)
                    };
                    DataSet ds = new DataSet();
                    ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDC_CPRData", param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string Message = "Attention CPR No is Used" +
                                "CPR No :" + ds.Tables[0].Rows[0]["CPRNo"].ToString() + "\n"
                                + "Name :" + ds.Tables[0].Rows[0]["Name"].ToString() + "\n"
                                + "CNIC :" + ds.Tables[0].Rows[0]["CNIC"].ToString() + "\n"
                                + "Date :" + ds.Tables[0].Rows[0]["Date"].ToString() + "\n"
                                ;
                            MessageBox.Show(Message);
                            e.Row.Cells["CPRNo"].Value = "Invalid CPR";
                            btnNDCCreate_.Enabled = false;
                        }
                        else
                        {
                            btnNDCCreate_.Enabled = true;
                        }
                    }

                    //duplicate verification

                }
                //CheckCPRDuplicate();
            }
            if (e.Column.Name == "CPRAmount")
            {
                decimal TaxAmount = 0;
                bool taxAmountParse = decimal.TryParse(e.Row.Cells["CPRAmount"].Value.ToString(), out TaxAmount);
                if (taxAmountParse == false || TaxAmount == 0)
                {
                    MessageBox.Show("Tax Amount is Invalid.");
                    btnNDCCreate_.Enabled = false;
                }
                else
                {
                    btnNDCCreate_.Enabled = true;
                }
            }
        }

        private bool FBR_Data_Check()
        {
            bool VerifiedCPRFlag = false;
            bool VerifiedTaxAmountFlag = false;
            foreach (GridViewRowInfo row in grdCPRData.Rows)
            {
                string CPRNo = row.Cells["CPRNo"].Value.ToString();
                Match m = Regex.Match(CPRNo, @"IT-[0-9]{8}-[0-9]{4}-[0-9]{0,9}");
                if (m.Success == false)
                {
                    MessageBox.Show("CPR No Format [IT-20220101-0101-000000] Format is not Match.");
                    VerifiedCPRFlag = false;
                }
                else
                {
                    VerifiedCPRFlag = true;
                }

                decimal TaxAmount = 0;
                bool taxAmountParse = decimal.TryParse(row.Cells["CPRAmount"].Value.ToString(), out TaxAmount);
                if (taxAmountParse == false || TaxAmount == 0)
                {
                    MessageBox.Show("Tax Amount is Invalid.");
                    VerifiedTaxAmountFlag = false;
                }
                else
                {
                    VerifiedTaxAmountFlag = true;
                }
            }
            return (VerifiedCPRFlag == true && VerifiedTaxAmountFlag == true ? true : false);
        }
        private void FBR_Save_CPR(int PerTransferID)
        {
            try
            {
                if (chkFBRSkip.CheckState == CheckState.Checked)
                {

                }
                else
                {
                    bool Verification = FBR_Data_Check();
                    if (Verification == true)
                    {
                        foreach (GridViewRowInfo row in grdCPRData.Rows)
                        {
                            SqlParameter[] param = {
                                new SqlParameter("@Task","OpenNDC_SaveCPR"),
                                new SqlParameter("@FileNo",row.Cells["FileNo"].Value.ToString()),
                                new SqlParameter("@PerTransferID",PerTransferID),
                                new SqlParameter("@MembershipNo",row.Cells["MembershipNo"].Value.ToString()),
                                new SqlParameter("@MemberName",row.Cells["Name"].Value.ToString()),
                                new SqlParameter("@CNIC",row.Cells["NTN"].Value.ToString()),
                                new SqlParameter("@FBRType",row.Cells["txtFiler_NonFiler"].Value.ToString()),
                                new SqlParameter("@MemberType",row.Cells["Type"].Value.ToString()),
                                new SqlParameter("@CPRNo",row.Cells["CPRNo"].Value.ToString()),
                                new SqlParameter("@TaxAmount",row.Cells["CPRAmount"].Value.ToString()),
                          };

                            SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenNDC_CPRData", param);
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
