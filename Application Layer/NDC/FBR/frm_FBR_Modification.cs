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
    public partial class frm_FBR_Modification : Telerik.WinControls.UI.RadForm
    {
        private bool sellerrCheckFiler { get; set; } = false;
        private bool sellerrCheckNonFiler { get; set; } = false;
        private bool buyerCheckFiler { get; set; } = false;
        private bool buyerCheckNonFiler { get; set; } = false;
        private decimal txtTaxCAmountSeller { get; set; } = 0;
        private decimal txtTaxKAmountBuyer { get; set; } = 0;    
        private decimal CalculatedTaxSeller { get; set; }
        private string CalculatedTaxSellerFBROwnerType { get; set; }
        private string FileOwnerType { get; set; }
        private decimal CalculatedTaxBuyer { get; set; }
        private string CalculatedTaxBuyerFBROwnerType { get; set; }
        private string CPRString_ { get; set; } = "";
        private DataSet dst_ { get; set; }
        private int NDCNo { get; set; }
        private string FileNo { get; set; }
        public frm_FBR_Modification()
        {
            InitializeComponent();
        }
        public frm_FBR_Modification(int getNDCNo, string getFileNo)
        {
            InitializeComponent();
            NDCNo = getNDCNo;
            FileNo = getFileNo;
            txtFileNo.Text = getFileNo;
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            #region FBR Data Retrieving
            sellerrCheckFiler = false;
            sellerrCheckNonFiler = false;
            buyerCheckFiler = false;
            buyerCheckNonFiler = false;
            SqlParameter[] prm =
            {
                    new SqlParameter("@Task","Get_FBR_Detail"),
                    new SqlParameter("@FileNo",FileNo),
                    new SqlParameter("@NDCNo",NDCNo)
                    };
            dst_ = cls_dl_NDC.NdcRetrival(prm);
            if (dst_.Tables.Count > 0)
            {
                if (dst_.Tables[0].Rows.Count > 0)
                {
                    string dltp = dst_.Tables[0].Rows[0]["DealType"].ToString();
                    int lblFBRID = int.Parse(dst_.Tables[0].Rows[0]["FBRID"].ToString());
                    if (dltp == "FBR") { rdbFBR.CheckState = CheckState.Checked; } else { FBROther.CheckState = CheckState.Checked; }
                    txtDealValue.Text = dst_.Tables[0].Rows[0]["Deal_Amount"].ToString();
                    //txtRemarks.Text = dst.Tables[0].Rows[0]["Remarks"].ToString();
                    grdCPRData.DataSource = dst_.Tables[3].DefaultView;
                    //grdSellerBuyerDetail.DataSource = dst.Tables[2].DefaultView;
                    //grdCPRDetail.DataSource = dst.Tables[3].DefaultView;
                }
                else
                {
                    txtDealValue.Text = null;
                    //txtRemarks.Text = null;
                    rdbFBR.CheckState = CheckState.Unchecked;
                    FBROther.CheckState = CheckState.Unchecked;
                    grdCPRData.DataSource = null;
                    MessageBox.Show("There is no FBR Record in Database against this File No. "+Environment.NewLine+
                                    "and NDCNo , So please First Enter FBR Detail.");




                    this.Close();
                    ConfigurationManager.AppSettings["FBRValueCheck"] = "PleaseEnterFBRDataFirst";
                }
            }
            //else
            //{
            //    txtDealValue.Text = null;
            //    //txtRemarks.Text = null;
            //    rdbFBR.CheckState = CheckState.Unchecked;
            //    FBROther.CheckState = CheckState.Unchecked;
            //    grdCPRData.DataSource = null;
            //    MessageBox.Show("You are not valid to Update FBR Data OR There is no FBR Record in Database.");

            //}
            #endregion
        }

        private void btnCheckandSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdCPRData.RowCount > 0)
                {
                    txtTaxCAmountSeller = 0;
                    txtTaxKAmountBuyer = 0;
                    #region Check FBR Data for Duplicate
                
                        if(1==1)
                        {
                        #region Detail
                        #region Find the Total Amount of Seller and Buyer

                        string SellerString = "";
                        string BuyerString = "";
                        foreach (GridViewRowInfo row1 in grdCPRData.Rows)
                        {
                           string type = row1.Cells["Type"].Value.ToString();
                           string ntn = row1.Cells["NTN"].Value.ToString();
                           if ( type == "Seller")
                           {
                               txtTaxCAmountSeller = Convert.ToDecimal(row1.Cells["CPRTaxAmount"].Value.ToString()) + txtTaxCAmountSeller;
                               SellerString = ExtractNumberFromString(ntn) + "," + SellerString;
                           }
                           else if (type == "Buyer")
                           {
                               txtTaxKAmountBuyer = Convert.ToDecimal(row1.Cells["CPRTaxAmount"].Value.ToString()) + txtTaxKAmountBuyer;
                               BuyerString = ExtractNumberFromString(ntn) + "," + BuyerString;
                           }
                        }
                           
                        #endregion
                        #region  Build the Seller and Buyer String For Filer and Non-Filer Status Checking
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
                            CalculatedTaxBuyer = (Convert.ToDecimal(txtDealValue.Text) * 1) / 100;
                            CalculatedTaxBuyerFBROwnerType = "Filer";
                            if (Convert.ToDecimal(txtTaxKAmountBuyer) >= Math.Round(CalculatedTaxBuyer))
                            {
                                buyerCheckFiler = true;
                            }
                            else
                            {
                                buyerCheckFiler = false;

                                MessageBox.Show("Buyer is not Valid to Purchase the File/Plot," + Environment.NewLine +
                                            "Because Deal Value is : " + (txtDealValue.Text) + Environment.NewLine
                                            + " 1 % On deal value for Filer Buyer  is : " + Math.Round(CalculatedTaxBuyer) + Environment.NewLine +
                                            "and you are Submit  :" + Math.Round(txtTaxKAmountBuyer), "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            }
                            #endregion
                            

                        }
                        //@@@@@@@@@@@@@@@@@@@@@@@@@   Buyer Part / Non-Filer @@@@@@@@@@@@@@@@@@@@@@@@@@@
                        else if (sdt.Tables[0].Rows[0]["FBROwnerType"].ToString() == "Non-Filer")
                        {
                            #region New Code for Buyer -> Non-Filer
                            CalculatedTaxBuyer = (Convert.ToDecimal(txtDealValue.Text) * 2) / 100;
                            CalculatedTaxBuyerFBROwnerType = "Non-Filer";
                            if (Math.Round(Convert.ToDecimal(txtTaxKAmountBuyer)) >= Math.Round(CalculatedTaxBuyer))
                            {
                                buyerCheckNonFiler = true;
                            }
                            else
                            {
                                buyerCheckNonFiler = false;
                                MessageBox.Show("Buyer is not Valid to Purchase the File/Plot," + Environment.NewLine +
                                             "Because Deal Value is : " + Math.Round(Convert.ToDecimal(txtDealValue.Text)) + Environment.NewLine
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
                            CalculatedTaxSeller = (Convert.ToDecimal(txtDealValue.Text) * 1) / 100;
                            CalculatedTaxSellerFBROwnerType = "Filer";
                            st = "1 % Tax is apply on Filer Seller, So :";
                            prc = "1 % ";
                        }
                        else if (sdt.Tables[1].Rows[0]["FBROwnerType"].ToString() == "Non-Filer")
                        {
                            CalculatedTaxSeller = (Convert.ToDecimal(txtDealValue.Text) * 2) / 100;
                            CalculatedTaxSellerFBROwnerType = "Non-Filer";
                            st = "2 % Tax is apply on Non-Filer Seller, So :";
                            prc = "2 % ";
                        }

                        #region
                            if (Math.Round(Convert.ToDecimal(txtTaxCAmountSeller)) >= Math.Round(CalculatedTaxSeller))
                            {
                                sellerrCheckFiler = true;
                            }
                            else
                            {
                                sellerrCheckFiler = false;
                                MessageBox.Show("Seller is not valid to Sold the Plot,  " + st + Environment.NewLine +
                                    "Because Deal Value is : " + Math.Round(Convert.ToDecimal(txtDealValue.Text)) + Environment.NewLine +
                                    prc + "Tax Amount of " + Math.Round(Convert.ToDecimal(txtDealValue.Text)) + " is : " + Math.Round(CalculatedTaxSeller) + Environment.NewLine +
                                    "Submitted Tax Amount is : " + Math.Round(txtTaxCAmountSeller) + Environment.NewLine +
                                    "Which is less then the Calculated " + prc + " Tax Amount.", "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                              
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
                            //dtFBRD.Clear();
                            //dtFBRD.Columns.Add("FBRID");
                            //dtFBRD.Columns.Add("DealType");
                            //dtFBRD.Columns.Add("Deal_Amount");
                            //dtFBRD.Columns.Add("FileNo");
                            //dtFBRD.Columns.Add("Status");
                            //dtFBRD.Columns.Add("Remarks");
                            //DataRow drfd = dtFBRD.NewRow();
                            //drfd["FBRID"] = int.Parse(dst_.Tables[0].Rows[0]["FBRID"].ToString());
                            //drfd["DealType"] = rdbFBR.IsChecked ? "FBR" : "Other";
                            //drfd["Deal_Amount"] = txtDealValue.Text;
                            //drfd["FileNo"] = txtFileNo.Text;
                            //drfd["Status"] = dst_.Tables[0].Rows[0]["Status"].ToString();
                            //drfd["Remarks"] = dst_.Tables[0].Rows[0]["Remarks"].ToString();
                            //dtFBRD.Rows.Add(drfd);
                            //#endregion
                            //#region FBR Calculated Tax on Deal Value
                            //dtFBRD_CalculatedTax.Clear();
                            //dtFBRD_CalculatedTax.Columns.Add("FBRIDT");
                            //dtFBRD_CalculatedTax.Columns.Add("CalculatedTaxOnDealAmount");
                            //dtFBRD_CalculatedTax.Columns.Add("TaxPaid");
                            //dtFBRD_CalculatedTax.Columns.Add("FBROwnerType");
                            //dtFBRD_CalculatedTax.Columns.Add("FileOwnerType");
                            //DataRow dct = dtFBRD_CalculatedTax.NewRow();
                            //dct["FBRIDT"] =int.Parse(dst_.Tables[0].Rows[0]["FBRID"].ToString());
                            //dct["CalculatedTaxOnDealAmount"] = CalculatedTaxBuyer;
                            //dct["TaxPaid"] = txtTaxKAmountBuyer;
                            //dct["FileOwnerType"] = "Buyer";
                            //dct["FBROwnerType"] = CalculatedTaxBuyerFBROwnerType;

                            //DataRow dct1 = dtFBRD_CalculatedTax.NewRow();
                            //dct1["FBRIDT"] = int.Parse(dst_.Tables[0].Rows[0]["FBRID"].ToString());
                            //dct1["CalculatedTaxOnDealAmount"] = CalculatedTaxSeller;
                            //dct1["TaxPaid"] = txtTaxCAmountSeller;
                            //dct1["FileOwnerType"] = "Seller";
                            //dct1["FBROwnerType"] = CalculatedTaxSellerFBROwnerType;

                            //dtFBRD_CalculatedTax.Rows.Add(dct);
                            //dtFBRD_CalculatedTax.Rows.Add(dct1);
                            //#endregion
                            //#region FBR Seller Buyer Table
                            //dtFBRSB.Clear();
                            //dtFBRSB.Columns.Add("FBRSBID");
                            //dtFBRSB.Columns.Add("CNIC");
                            //dtFBRSB.Columns.Add("Name");
                            //dtFBRSB.Columns.Add("FatherName");
                            //dtFBRSB.Columns.Add("NTN");
                            //dtFBRSB.Columns.Add("Type");
                            //dtFBRSB.Columns.Add("FBROwnerType");

                            //foreach (GridViewRowInfo rowInfo in grdCPRData.Rows)
                            //{
                            //    DataRow drfsb = dtFBRSB.NewRow();
                            //    string typ = rowInfo.Cells["Type"].Value.ToString();
                            //    if (typ == "Buyer")
                            //    {
                            //        drfsb["FBRSBID"] = rowInfo.Cells["FBRSBID"].Value.ToString();
                            //        drfsb["CNIC"] = rowInfo.Cells["CNIC"].Value == null ? "" : rowInfo.Cells["CNIC"].Value.ToString();
                            //        drfsb["Name"] = rowInfo.Cells["Name"].Value.ToString();
                            //        drfsb["FatherName"] = rowInfo.Cells["Father"].Value.ToString();
                            //        drfsb["NTN"] = rowInfo.Cells["NTN"].Value.ToString();
                            //        drfsb["Type"] = typ;

                            //        #region Find Filer , Non-Filer
                            //        if (!string.IsNullOrEmpty(rowInfo.Cells["NTN"].Value.ToString()))
                            //        {
                            //            #region Filer , Non-Filer
                            //            SqlParameter[] prm1 =
                            //            {
                            //                new SqlParameter("@Task","GetFBROwnerType"),
                            //                new SqlParameter("@NTN",ExtractNumberFromString(rowInfo.Cells["NTN"].Value.ToString()))
                            //                };
                            //            DataSet dst1 = cls_dl_NDC.NdcRetrival(prm1);
                            //            if (dst1.Tables.Count > 0)
                            //            {
                            //                if (dst1.Tables[0].Rows.Count > 0)
                            //                {
                            //                    if (dst1.Tables[0].Rows[0]["Type"].ToString() == "Filer")
                            //                    {
                            //                        drfsb["FBROwnerType"] = "Filer";
                            //                    }
                            //                }
                            //                else
                            //                {
                            //                    drfsb["FBROwnerType"] = "Non-Filer";
                            //                }
                            //            }
                            //            else
                            //            {
                            //                drfsb["FBROwnerType"] = "Non-Filer";
                            //            }
                            //            #endregion
                            //        }
                            //        else
                            //        {
                            //            drfsb["FBROwnerType"] = "Non-Filer";
                            //        }

                            //        #endregion

                            //        //drfsb["CPRNo"] = txtWHTk_.Text;
                            //        //drfsb["CPRTaxAmount"] = txtwhtkAmount.Text;
                            //        //drfsb["CalculatedTaxOnDealAmount"] = CalculatedTaxBuyer;

                            //    }
                            //    else if (typ == "Seller")
                            //    {
                            //        drfsb["FBRSBID"] = rowInfo.Cells["FBRSBID"].Value.ToString();
                            //        drfsb["CNIC"] = rowInfo.Cells["CNIC"].Value == null ? "" : rowInfo.Cells["CNIC"].Value.ToString();
                            //        drfsb["Name"] = rowInfo.Cells["Name"].Value.ToString();
                            //        drfsb["FatherName"] = rowInfo.Cells["Father"].Value.ToString();
                            //        drfsb["NTN"] = rowInfo.Cells["NTN"].Value.ToString();
                            //        drfsb["Type"] = typ;

                            //        #region Find Filer , Non-Filer
                            //        if (!string.IsNullOrEmpty(rowInfo.Cells["NTN"].Value.ToString()))
                            //        {
                            //            #region Filer , Non-Filer
                            //            SqlParameter[] prm1 =
                            //            {
                            //                new SqlParameter("@Task","GetFBROwnerType"),
                            //                new SqlParameter("@NTN",ExtractNumberFromString(rowInfo.Cells["NTN"].Value.ToString()))
                            //                };
                            //            DataSet dst1 = cls_dl_NDC.NdcRetrival(prm1);
                            //            if (dst1.Tables.Count > 0)
                            //            {
                            //                if (dst1.Tables[0].Rows.Count > 0)
                            //                {
                            //                    if (dst1.Tables[0].Rows[0]["Type"].ToString() == "Filer")
                            //                    {
                            //                        drfsb["FBROwnerType"] = "Filer";
                            //                    }
                            //                }
                            //                else
                            //                {
                            //                    drfsb["FBROwnerType"] = "Non-Filer";
                            //                }
                            //            }
                            //            else
                            //            {
                            //                drfsb["FBROwnerType"] = "Non-Filer";
                            //            }
                            //            #endregion
                            //        }
                            //        else
                            //        {
                            //            drfsb["FBROwnerType"] = "Non-Filer";
                            //        }

                            //        #endregion


                            //        //drfsb["CPRNo"] = txtWHTc_.Text;
                            //        //drfsb["CPRTaxAmount"] = txtwhtcAmount.Text;
                            //        //drfsb["CalculatedTaxOnDealAmount"] = CalculatedTaxSeller;
                            //    }
                            //    dtFBRSB.Rows.Add(drfsb);
                            //    //}

                            //}
                            //#endregion
                            //#region Buyer Seller CPR Detail

                            //#region DataTable_Column Creation
                            //DataTable_column FBRSBCPRID = new DataTable_column() { ColmnName = "FBRSBCPRID", type = typeof(int) };
                            //DataTable_column NTN = new DataTable_column() { ColmnName = "NTN", type = typeof(string) };
                            //DataTable_column CPRTaxAmount = new DataTable_column() { ColmnName = "CPRTaxAmount", type = typeof(double) };
                            //DataTable_column CPRNo = new DataTable_column() { ColmnName = "CPRNo", type = typeof(string) };

                            //#endregion
                            //#region Insert DataTabl_Column in List, and Send to Helper to make DataTable
                            //List<DataTable_column> colmn = new List<DataTable_column>();
                            //colmn.Add(FBRSBCPRID);
                            //colmn.Add(NTN);
                            //colmn.Add(CPRTaxAmount);
                            //colmn.Add(CPRNo);
                            //dtFBRSB_CPRDetail = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                            //#endregion
                            //#region Insertion in DataTable
                            //int rowcount = grdCPRData.Rows.Count;
                            //dtFBRSB_CPRDetail.Clear();
                            //foreach (GridViewRowInfo rowInfo in grdCPRData.Rows)
                            //{
                            //    DataRow _row = dtFBRSB_CPRDetail.NewRow();
                            //    _row["FBRSBCPRID"] = rowInfo.Cells["FBRSBCPRID"].Value.ToString();
                            //    _row["NTN"] = rowInfo.Cells["NTN"].Value.ToString(); 
                            //    _row["CPRTaxAmount"] = rowInfo.Cells["CPRTaxAmount"].Value.ToString();
                            //    _row["CPRNo"] = rowInfo.Cells["CPRNo"].Value.ToString();
                            //    dtFBRSB_CPRDetail.Rows.Add(_row);
                            //}
                            //#endregion
                            #endregion
                            #region FBR Detail Insertion
                            //if (dtFBRD.Rows.Count > 0 && dtFBRSB.Rows.Count > 0 && dtFBRD_CalculatedTax.Rows.Count > 0 && dtFBRSB_CPRDetail.Rows.Count > 0)
                            //{
                            //    SqlParameter[] prtr =
                            //    {
                            //        new SqlParameter("@Task", "UpdateFBRDetail"),
                            //        new SqlParameter(){ ParameterName = "@tbl_FBRData_Update",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRD},
                            //        new SqlParameter(){ ParameterName = "@tbl_FBRD_CalculatedTax_Update",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRD_CalculatedTax},
                            //        new SqlParameter(){ ParameterName = "@tbl_FBR_Seller_Buyer_Update",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRSB},
                            //        new SqlParameter(){ ParameterName = "@tbl_FBRSB_CPRDetail_Update",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRSB_CPRDetail}
                            //        };
                            //    int rslt = cls_dl_NDC.NdcNonQuery(prtr);
                            //    if (rslt > 0)
                            //    {
                            //        MessageBox.Show("FBR Data is Valid and Update Successfully.");
                            //    }
                            //}
                            //else
                            //{
                            //    // MessageBox.Show("Both the Seller and Buyer Information are Required.");
                            //}
                            #endregion

                            //string fbrval = (ConfigurationManager.AppSettings["FBRValueCheck"]).ToString();
                            ConfigurationManager.AppSettings["FBRValueCheck"] = "Valid";

                            decimal paidselleramount = txtTaxCAmountSeller;
                            decimal calselleramount = CalculatedTaxSeller;

                            decimal paidbuyeramount = txtTaxKAmountBuyer;
                            decimal calbuyeramount = CalculatedTaxBuyer;
                            
                            foreach (GridViewRowInfo row1 in grdCPRData.Rows)
                            {
                                string type = row1.Cells["Type"].Value.ToString();
                                string ntn = row1.Cells["NTN"].Value.ToString();
                                int FBRID = int.Parse(row1.Cells["FBRID"].Value.ToString());
                                if(type == "Buyer")
                                {
                                    string fbrtype = sdt.Tables[0].Rows[0]["FBROwnerType"].ToString();
                                    UpdateFBRTaxCalculatedAmounts( calbuyeramount, paidbuyeramount, "Buyer", fbrtype, FBRID);
                                }
                                else if(type == "Seller")
                                {
                                    string fbrtype = sdt.Tables[1].Rows[0]["FBROwnerType"].ToString();
                                    UpdateFBRTaxCalculatedAmounts(calselleramount, paidselleramount, "Seller", fbrtype, FBRID);
                                }

                            }




                            this.Close();


                        }
                        #endregion
                        #endregion
                    }
                    else
                        {
                            MessageBox.Show("The CPR No. " + CheckCPRDuplicate() + " are Duplicated.");
                        }

                    //}
                    #endregion
                }
                else
                {
                    //btnloadgrid_Click(sender, e);

                    MessageBox.Show("Please Enter the FBR Taxes And CPR Numbers.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //    CPRString_ = "";
            //    foreach (GridViewRowInfo rw in grdCPRDetail.Rows)
            //    {
            //        string cprno = rw.Cells["CPRNo"].Value.ToString();
            //        if (!string.IsNullOrEmpty(cprno))
            //        {
            //            if (cprno == "NA")
            //            {

            //            }
            //            else
            //            {
            //                #region CPR Checking
            //                SqlParameter[] prm =
            //                {
            //                 new SqlParameter("@Task","check_CPRNo"),
            //                 new SqlParameter("@CPRNo",cprno),
            //                 new SqlParameter("@FileNo",txtFileNo.Text)
            //                };
            //                DataSet dst_ = cls_dl_NDC.NdcRetrival(prm);
            //                if (dst_.Tables[0].Rows.Count == 0)
            //                {
            //                    // CPRString_ = "";

            //                }
            //                else if (dst_.Tables[0].Rows.Count > 0)
            //                {
            //                    buyerCheckFiler = false;
            //                    buyerCheckNonFiler = false;
            //                    sellerrCheckFiler = false;
            //                    sellerrCheckNonFiler = false;
            //                    CPRString_ = dst_.Tables[0].Rows[0]["CPRNo"].ToString() + "," + CPRString_;

            //                    //"This CPR." + dst_.Tables[0].Rows[0]["CPRNo"].ToString() + "is used against :" + Environment.NewLine +
            //                    //                " File No." + txtFile_No_.Text + "Owner Name : " + dst_.Tables[0].Rows[0]["Name"].ToString() + Environment.NewLine +
            //                    //                " CNIC : " + dst_.Tables[0].Rows[0]["CNIC"].ToString() + " Type: " + dst_.Tables[0].Rows[0]["Type"].ToString() + Environment.NewLine +
            //                    //                " on " + dst_.Tables[0].Rows[0]["Date"].ToString() + Environment.NewLine +
            //                    //                "So before saving, Please Correct the CPR's No.";
            //                }
            //                #endregion
            //            }

            //        }
            //        else
            //        {
            //            MessageBox.Show("Please Enter CPR No.");
            //        }
            //    }
            //    return CPRString_;
            return null;
        }
        private void UpdateFBRTaxCalculatedAmounts(decimal calamount, decimal paidamount,string str_sellerbuyer, string fbrtype,int FBRID)
        {
            SqlParameter[] prmt =
            {
              new SqlParameter("@Task","UpdateCalFBRTaxAmount"),
              new SqlParameter("@CalculatedTaxOnDealAmount",calamount),
              new SqlParameter("@TaxPaid",paidamount),
              new SqlParameter("@FileOwnerType",str_sellerbuyer),
              new SqlParameter("@FBROwnerType",fbrtype),
              new SqlParameter("@FBRID",FBRID)
            };
            int rslt = cls_dl_NDC.NdcNonQuery(prmt);
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


                //grdCPRData.DataSource = null;
                if (rdbFBR.IsChecked)
                {
                    decimal smtpPort = Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarla"]);

                    SqlParameter[] prtr =
                    {
                    new SqlParameter("@Task","CheckFileCategory"),
                    new SqlParameter("@FileNo",txtFileNo.Text)
                    };
                    DataSet dts = cls_dl_NDC.NdcRetrival(prtr);
                    if (dts.Tables.Count > 0)
                    {
                        if (dts.Tables[0].Rows.Count > 0)
                        {
                            if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "1 Kanal")
                            {
                                txtDealValue.Text = Convert.ToString(smtpPort * 20);
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "10 Marla")
                            {
                                txtDealValue.Text = Convert.ToString(smtpPort * 10);
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "8 Marla")
                            {
                                txtDealValue.Text = Convert.ToString(smtpPort * 8);
                                txtDealValue.ReadOnly = true;
                            }
                            else if (dts.Tables[0].Rows[0]["PlotSize"].ToString() == "5 Marla")
                            {
                                txtDealValue.Text = Convert.ToString(smtpPort * 5);
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

        private void rdbOther_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                //grdCPRData.DataSource = null;
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

        private void frm_FBR_Modification_Load(object sender, EventArgs e)
        {
            btnFind_Click(sender,e);
        }

        private void grdCPRData_CellClick(object sender, GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btnUpdateCPRData")
            {
                if (MessageBox.Show("Are you sure you want to Update CPR record","Attention !!!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int FBRSBCPRID = int.Parse(e.Row.Cells["FBRSBCPRID"].Value.ToString());
                    int FBRID = int.Parse(e.Row.Cells["FBRID"].Value.ToString());
                    string type = e.Row.Cells["Type"].Value.ToString();
                    decimal cprtaxamount = Convert.ToDecimal(e.Row.Cells["CPRTaxAmount"].Value.ToString());
                    string cprnumber = e.Row.Cells["CPRNo"].Value.ToString();
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","UpdateCPRData"),
                        new SqlParameter("@CPRNo",cprnumber),
                        new SqlParameter("@CPRTaxAmount",cprtaxamount),
                        new SqlParameter("@FBRSBCPRID",FBRSBCPRID)
                    };
                    int rslt = cls_dl_NDC.NdcNonQuery(prm);
                    if(rslt > 0)
                        MessageBox.Show("Updation Success.","OK",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                btnFind_Click(sender, e);
            }
            else if(e.Column.Name == "btnInsertCPRData")
            {
                if (MessageBox.Show("Are you sure you want to Insert CPR record", "Attention !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    #region CPR Detail One Time Entry
                    decimal cprtaxamount = Convert.ToDecimal(e.Row.Cells["CPRTaxAmount"].Value.ToString());
                    string cprnumber = e.Row.Cells["CPRNo"].Value.ToString();
                    string ntn = e.Row.Cells["NTN"].Value.ToString();
                    string FBRSBID = e.Row.Cells["FBRSBID"].Value.ToString();
                    #endregion
                    
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","InsertCPRData"),
                        new SqlParameter("@CPRNo",cprnumber),
                        new SqlParameter("@CPRTaxAmount",cprtaxamount),
                        new SqlParameter("@NTN",ntn),
                        new SqlParameter("@FBRSBID",FBRSBID)
                    };
                    int rslt = cls_dl_NDC.NdcNonQuery(prm);
                    if (rslt > 0)
                        MessageBox.Show("Insertion Success.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btnFind_Click(sender, e);
            }
        }
    }
}
