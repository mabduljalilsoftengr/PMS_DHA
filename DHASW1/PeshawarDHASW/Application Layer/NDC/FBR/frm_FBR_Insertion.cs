using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.NDC.FBR
{
    public partial class frm_FBR_Insertion : Telerik.WinControls.UI.RadForm
    {
        private string CPRString_ { get; set; } = "";
        private bool buyerCheckFiler { get; set; } = false;
        private bool buyerCheckNonFiler { get; set; } = false;
        private bool sellerrCheckFiler { get; set; } = false;
        private bool sellerrCheckNonFiler { get; set; } = false;
        private bool plotdealerState { get; set; }
        private decimal txtTaxCAmountSeller { get; set; } = 0;
        private decimal txtTaxKAmountBuyer { get; set; } = 0;
        private decimal CalculatedTaxSeller { get; set; }
        private string CalculatedTaxSellerFBROwnerType { get; set; }
        private string FileOwnerType { get; set; }
        private decimal CalculatedTaxBuyer { get; set; }
        private string CalculatedTaxBuyerFBROwnerType { get; set; }
        public int NDCID { get; set; } = 0;
        private string FileNo { get; set; }
        private int NDCNo { get; set; }
        public frm_FBR_Insertion()
        {
            InitializeComponent();
        }
        public frm_FBR_Insertion(string getFileNo, int getNDCNo)
        {
            InitializeComponent();
            txtFile_No_.Text = getFileNo;
            FileNo = getFileNo;
            NDCNo = getNDCNo;
        }
        
        private void rdbFBR_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                grdCPRData.DataSource = null;
                if (rdbFBR.IsChecked)
                {
                    decimal smtpPort;
                    if (txtFile_No_.Text.ToUpper().Contains("/COM/"))
                    {
                        smtpPort = Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarla_Com"]);
                    }
                    else
                    {
                        smtpPort = Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarla"]);
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
                            if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "1 Kanal")
                            {
                                txtDealValue.Text = (smtpPort * 20).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "10 Marla")
                            {
                                txtDealValue.Text = (smtpPort * 10).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "8 Marla")
                            {
                                txtDealValue.Text = (smtpPort * 8).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "5 Marla")
                            {
                                txtDealValue.Text = (smtpPort * 5).ToString();
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "4 Marla")
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
        private void Select_CurrentOwner_Info_Against_FileNo_(string getstring)
        {
            // bool blvr = false;
            try
            {
                
                rdbFBR.CheckState = CheckState.Checked;
                rdbFBR_CheckStateChanged(null, null);

                #region Requested for Summary Report Name 

                SqlParameter[] prmt =
                {
                     new SqlParameter("@Task","Current_OwnerAgainstFile_For_Info"),
                     new SqlParameter("@FileNo",txtFile_No_.Text)
                };
               DataSet datset = cls_dl_NDC.NdcRetrival(prmt);

                if (datset.Tables.Count > 0)
                {
                    if (datset.Tables[1].Rows.Count > 0 && datset.Tables[0].Rows.Count > 0)
                    {
                        datset.Tables[0].Merge(datset.Tables[1]);
                    }
                }
                grdSeller_Buyer.DataSource = datset.Tables[0].DefaultView;

                /// Call the load button click event
                btnloadgrid_Click(null, null);
                #endregion

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Select_CurrentOwner_Info_Against_FileNo.", ex, "frmNDCCreate");
                frmobj.ShowDialog();
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

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdCPRData.RowCount > 0)
                {
                    #region FBR Insertion
                    //if (NDCID <= 0)
                    //{
                        buyerCheckFiler = false;
                        buyerCheckNonFiler = false;
                        sellerrCheckFiler = false;
                        sellerrCheckNonFiler = false;

                        decimal dealval = Convert.ToDecimal(txtDealValue.Text);

                        if (grdCPRData.RowCount > 0)
                        {
                            txtTaxCAmountSeller = 0;
                            txtTaxKAmountBuyer = 0;
                            #region Check FBR Data for Duplicate
                            SqlParameter[] parameter =
                            {
                            new SqlParameter("@Task", "CheckFBRDetail"),
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
                                        string ntn = row.Cells["NTN"].Value.ToString();
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
                                        string ntn = row.Cells["NTN"].Value.ToString();
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
                                        CalculatedTaxBuyer = (Convert.ToDecimal(dealval.ToString()) * 1) / 100;
                                        CalculatedTaxBuyerFBROwnerType = "Filer";
                                        if (Convert.ToDecimal(txtTaxKAmountBuyer) >= Math.Round(CalculatedTaxBuyer))
                                        {
                                            buyerCheckFiler = true;
                                        }
                                        else
                                        {
                                            buyerCheckFiler = false;

                                            MessageBox.Show("Buyer is not Valid to Purchase the File/Plot," + Environment.NewLine +
                                                        "Because Deal Value is : " + (dealval.ToString()) + Environment.NewLine
                                                        + " 1 % On deal value for Filer Buyer  is : " + Math.Round(CalculatedTaxBuyer) + Environment.NewLine +
                                                        "and you are Submit  :" + Math.Round(txtTaxKAmountBuyer), "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        }
                                        #endregion

                                        

                                    }
                                    //@@@@@@@@@@@@@@@@@@@@@@@@@   Buyer Part / Non-Filer @@@@@@@@@@@@@@@@@@@@@@@@@@@
                                    else if (sdt.Tables[0].Rows[0]["FBROwnerType"].ToString() == "Non-Filer")
                                    {
                                        #region New Code for Buyer -> Non-Filer
                                        CalculatedTaxBuyer = (Convert.ToDecimal(dealval.ToString()) * 2) / 100;
                                        CalculatedTaxBuyerFBROwnerType = "Non-Filer";
                                        if (Math.Round(Convert.ToDecimal(txtTaxKAmountBuyer)) >= Math.Round(CalculatedTaxBuyer))
                                        {
                                            buyerCheckNonFiler = true;
                                        }
                                        else
                                        {
                                            buyerCheckNonFiler = false;
                                            MessageBox.Show("Buyer is not Valid to Purchase the File/Plot," + Environment.NewLine +
                                                         "Because Deal Value is : " + Math.Round(dealval).ToString() + Environment.NewLine
                                                         + " 2 % On deal value for Non-Filer Buyer is : " + Math.Round(CalculatedTaxBuyer).ToString() + Environment.NewLine +
                                                         "and you are Submit :" + Math.Round(txtTaxKAmountBuyer), "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                        }
                                        #endregion
                                        
                                    }



                                    #endregion
                                    //@@@@@@@@@@@@@@@@@@@@@@@@@   Seller Part / Filer @@@@@@@@@@@@@@@@@@@@@@@@@@@
                                    #region %%%%%%%%%%%%%  FBR Tax Calculation For Seller (Tables[1] is return the Seller information)
                                    string st = "", prc = "";
                                    if (sdt.Tables[1].Rows[0]["FBROwnerType"].ToString() == "Filer")
                                    {
                                        CalculatedTaxSeller = (Convert.ToDecimal(dealval.ToString()) * 1) / 100;
                                        CalculatedTaxSellerFBROwnerType = "Filer";
                                        st = "1 % Tax is apply on Filer Seller, So :";
                                        prc = "1 % ";
                                    }
                                    else if (sdt.Tables[1].Rows[0]["FBROwnerType"].ToString() == "Non-Filer")
                                    {
                                        CalculatedTaxSeller = (Convert.ToDecimal(dealval.ToString()) * 2) / 100;
                                        CalculatedTaxSellerFBROwnerType = "Non-Filer";
                                        st = "2 % Tax is apply on Non-Filer Seller, So :";
                                        prc = "2 % ";
                                    }

                                    #region Skip FBR Tax on Seller
                                   
                                        if (Math.Round(Convert.ToDecimal(txtTaxCAmountSeller)) >= Math.Round(CalculatedTaxSeller))
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
                                        DataRow drfd = dtFBRD.NewRow();
                                        drfd["DealType"] = rdbFBR.IsChecked ? "FBR" : "Other";
                                        drfd["Deal_Amount"] = Math.Round(dealval).ToString();
                                        drfd["FileNo"] = txtFile_No_.Text;
                                        drfd["Status"] = "Active";
                                        drfd["Remarks"] = "These Taxes are paid against NDC.";
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

                                        
                                        foreach (GridViewRowInfo rowInfo in grdSeller_Buyer.Rows)
                                        {
                                            //bool bl = Convert.ToBoolean(rowInfo.Cells["SelectOwner"].Value);

                                            //if (bl == true)
                                            //{
                                            DataRow drfsb = dtFBRSB.NewRow();
                                            string typ = rowInfo.Cells["Type"].Value.ToString();
                                            if (typ == "Buyer")
                                            {
                                                drfsb["CNIC"] = rowInfo.Cells["CNIC"].Value.ToString();
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

                                               

                                            }
                                            else if (typ == "Seller")
                                            {
                                                drfsb["CNIC"] = rowInfo.Cells["CNIC"].Value.ToString();
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


                                                
                                            }
                                            dtFBRSB.Rows.Add(drfsb);
                                            

                                        }
                                        #endregion
                                        #region Buyer Seller CPR Detail

                                        #region DataTable_Column Creation
                                        DataTable_column NTN = new DataTable_column() { ColmnName = "NTN", type = typeof(string) };
                                        DataTable_column CPRTaxAmount = new DataTable_column() { ColmnName = "CPRTaxAmount", type = typeof(double) };
                                        DataTable_column CPRNo = new DataTable_column() { ColmnName = "CPRNo", type = typeof(string) };

                                        #endregion
                                        #region Insert DataTabl_Column in List, and Send to Helper to make DataTable
                                        List<DataTable_column> colmn = new List<DataTable_column>();
                                        colmn.Add(NTN);
                                        colmn.Add(CPRTaxAmount);
                                        colmn.Add(CPRNo);
                                        dtFBRSB_CPRDetail = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                                        #endregion
                                        #region Insertion in DataTable
                                        int rowcount = grdSeller_Buyer.Rows.Count;
                                        dtFBRSB_CPRDetail.Clear();
                                        foreach (GridViewRowInfo rowInfo in grdCPRData.Rows)
                                        {
                                            DataRow _row = dtFBRSB_CPRDetail.NewRow();// Create Row for Seller Data
                                            _row["NTN"] = rowInfo.Cells["NTN"].Value.ToString(); ;
                                            _row["CPRTaxAmount"] = Math.Round(Convert.ToDecimal(rowInfo.Cells["CPRAmount"].Value.ToString()));
                                            _row["CPRNo"] = rowInfo.Cells["CPRNo"].Value.ToString();
                                            dtFBRSB_CPRDetail.Rows.Add(_row);

                                        }
                                        #endregion

                                        #endregion
                                        #region FBR Detail Insertion
                                        if (dtFBRD.Rows.Count > 0 && dtFBRSB.Rows.Count > 0 && dtFBRD_CalculatedTax.Rows.Count > 0 && dtFBRSB_CPRDetail.Rows.Count > 0)
                                        {
                                            SqlParameter[] prtr =
                                            {
                                            new SqlParameter("@Task", "InsertFBRDetail"),
                                            new SqlParameter(){ ParameterName = "@tbl_FBRData",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRD},
                                            new SqlParameter(){ ParameterName = "@tbl_FBRD_CalculatedTax",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRD_CalculatedTax},
                                            new SqlParameter(){ ParameterName = "@tbl_FBR_Seller_Buyer",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRSB},
                                            new SqlParameter(){ ParameterName = "@tbl_FBRSB_CPRDetail",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRSB_CPRDetail}
                                            };
                                            int rslt = cls_dl_NDC.NdcNonQuery(prtr);
                                            if (rslt > 0)
                                            {
                                                MessageBox.Show("FBR Data is Valid and Saved Successfully.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                SqlParameter[] prmt =
                                                {
                                                    new SqlParameter("@Task","GetNDCAndUpdateFBRData"),
                                                    new SqlParameter("@FileNo",FileNo),
                                                    new SqlParameter("@NDCNo",NDCNo)
                                                };
                                                int rsl = cls_dl_NDC.NdcNonQuery(prmt);
                                                (ConfigurationManager.AppSettings["FBRValueCheck"]) = "Valid";
                                                this.Close();
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
                    //}
                    //else
                    //{
                    //    MessageBox.Show("FBR could not modify here, Please modify it in FBR Modify Page.");
                    //}
                    #endregion
                }
                else
                {
                    MessageBox.Show("There is no data in Grid.", "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.InnerException);
            }


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
        public string ExtractNumberFromString(string original)
        {
            return new string(original.Where(c => Char.IsDigit(c)).ToArray());
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

        private void btnloadgrid_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void BindColumnToFBRSellerBuyerCPRDetailGrid()
        {
            
            grdCPRData.DataSource = null;
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("NTN");
            dt.Columns.Add("Type");
            dt.Columns.Add("Name");
            dt.Columns.Add("CPRAmount");
            dt.Columns.Add("txtFiler_NonFiler");
            dt.Columns.Add("CPRNo");
            foreach (GridViewRowInfo row in grdSeller_Buyer.Rows)
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
                dt.Rows.Add(dtr);
                
            }
            grdCPRData.DataSource = dt.DefaultView;
        }

        private void frm_FBR_Insertion_Load(object sender, EventArgs e)
        {
            Select_CurrentOwner_Info_Against_FileNo_("");
        }
    }
}
