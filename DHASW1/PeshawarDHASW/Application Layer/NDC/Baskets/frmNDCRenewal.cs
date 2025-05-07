using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Report.Challan;
using PeshawarDHASW.Application_Layer.Chalan;
using PeshawarDHASW.Application_Layer.NDC.FBR;
using System.Configuration;
using PeshawarDHASW.Data_Layer.clsFileMap;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmNDCRenewal : Telerik.WinControls.UI.RadForm
    {
        public frmNDCRenewal()
        {
            InitializeComponent();
        }

        private void frmNDCRenewal_Load(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","GetExpireCancelNDC")
                };
                DataSet dst = cls_dl_NDC.NdcRetrival(prm);
                grdExpireNDCData.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void grdExpireNDCData_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            { 
            if(grdExpireNDCData.RowCount > 0)
            {
                if(e.Column.Name == "btnGenerateRenChallan")
                {

                    // NDC Renewal Generation
                    string FileNo = e.Row.Cells["FilePlotNo"].Value.ToString();
                    int filemapkey = 0;
                        // Get FleMapKey
                        SqlParameter[] prmt =
                        {
                                new SqlParameter("@Task","GetFileMapKey"),
                                new SqlParameter("@FileNo",FileNo)
                            };
                        DataSet d_s = cls_dl_FileMap.Main_FileMap_Reader(prmt);
                        filemapkey = int.Parse(d_s.Tables[0].Rows[0]["FileMapKey"].ToString());
                        SqlParameter[] param_Renewal_Challan_Generation = {
                        new SqlParameter("@Task","NDCRenewalFeeChallanGeneration"),
                        new SqlParameter("@File_No",FileNo),
                        new SqlParameter("@FileMapKey",filemapkey),
                        new SqlParameter("@UserID",clsUser.ID)
                    };
                    DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_NDC_Challan", param_Renewal_Challan_Generation);
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
                    ///dst.Tables[0].DefaultView;
                }
                else if(e.Column.Name == "btnRenewNDC")
                {
                    try
                    {
                        #region Renewal of NDC
                        int NDCNo = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                        string FileNo = e.Row.Cells["FilePlotNo"].Value.ToString();
                        
                        //CheckFBRData(FileNo, NDCNo);
                        //frm_FBR_Modification frm = new frm_FBR_Modification(NDCNo, FileNo);
                        //frm.ShowDialog();

                        //if ((ConfigurationManager.AppSettings["FBRValueCheck"]).ToString() == "Valid")
                        //{
                            SqlParameter[] prm =
                            {
                              new SqlParameter("@Task","RenewNDC"),
                              new SqlParameter("@NDCNo",NDCNo),
                              new SqlParameter("@FileNo",FileNo),
                              new SqlParameter("@userID",Models.clsUser.ID)
                            };
                            DataSet dst = cls_dl_NDC.NdcRetrival(prm);
                            MessageBox.Show(dst.Tables[0].Rows[0]["Detail"].ToString());

                            frmNDCRenewal_Load(null, null);
                        //    ConfigurationManager.AppSettings["FBRValueCheck"] = "NotValid";
                        //}

                        //if (ConfigurationManager.AppSettings["FBRValueCheck"] == "PleaseEnterFBRDataFirst")
                        //{
                        //    frm_FBR_Insertion frmins = new frm_FBR_Insertion(FileNo, NDCNo);
                        //    frmins.ShowDialog();
                        //}
                        //if ((ConfigurationManager.AppSettings["FBRValueCheck"]).ToString() == "Valid")
                        //{
                        //    SqlParameter[] prm =
                        //    {
                        //    new SqlParameter("@Task","RenewNDC"),
                        //    new SqlParameter("@NDCNo",NDCNo),
                        //    new SqlParameter("@FileNo",FileNo),
                        //    new SqlParameter("@userID",Models.clsUser.ID)
                        //    };
                        //    DataSet dst = cls_dl_NDC.NdcRetrival(prm);
                        //    MessageBox.Show(dst.Tables[0].Rows[0]["Detail"].ToString());

                        //    frmNDCRenewal_Load(null, null);
                        //    ConfigurationManager.AppSettings["FBRValueCheck"] = "NotValid";
                        //}
                        #endregion
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

                MessageBox.Show(ex.Message);
        }
     }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmNDCRenewal_Load(null, null);
        }
        //private void CheckFBRData(string FileNo,int NDCNo)
        //{
        //    DataSet dst = GetDataForFBRDataChecking(FileNo, NDCNo);
        //    if (string.IsNullOrEmpty(CheckCPRDuplicate()))
        //    {
        //        #region Detail
        //        #region Find the Total Amount of Seller and Buyer

        //        foreach (GridViewRowInfo row in grdSeller_Buyer.Rows)
        //        {
                    
        //            string ntn = row.Cells["NTN"].Value.ToString();
        //            string type = row.Cells["Type"].Value.ToString();

        //            foreach (GridViewRowInfo row1 in grdCPRData.Rows)
        //            {
        //                string nt = row1.Cells["NTN"].Value.ToString();
        //                if (nt == ntn && type == "Seller")
        //                {
        //                    txtTaxCAmountSeller = Convert.ToDecimal(row1.Cells["CPRAmount"].Value.ToString()) + txtTaxCAmountSeller;
        //                }
        //                else if (nt == ntn && type == "Buyer")
        //                {
        //                    txtTaxKAmountBuyer = Convert.ToDecimal(row1.Cells["CPRAmount"].Value.ToString()) + txtTaxKAmountBuyer;
        //                }
        //            }
        //        }

        //        #endregion
        //        #region  Build the Seller and Buyer String For Filer and Non-Filer Status Checking

        //        string SellerString = "";
        //        string BuyerString = "";
        //        foreach (GridViewRowInfo row in grdSeller_Buyer.Rows)
        //        {
        //            //bool bl = Convert.ToBoolean(row.Cells["SelectOwner"].Value);
        //            //if (bl == true)
        //            //{
        //            string ntn = row.Cells["NTN"].Value.ToString();
        //            string type = row.Cells["Type"].Value.ToString();
        //            #region Buyer Part
        //            if (type == "Buyer")
        //            {
        //                //BuyerString = ExtractNumberFromString(cnic) + "," + BuyerString;
        //                BuyerString = ExtractNumberFromString(ntn) + "," + BuyerString;
        //            }
        //            #endregion
        //            #region Seller Part
        //            else if (type == "Seller")
        //            {
        //                //SellerString = ExtractNumberFromString(cnic) + "," + SellerString;
        //                SellerString = ExtractNumberFromString(ntn) + "," + SellerString;
        //            }
        //            #endregion

        //            //}
        //        }
        //        if (BuyerString == ",") { BuyerString = ""; }
        //        if (SellerString == ",") { SellerString = ""; }
        //        #endregion
        //        DataSet sdt = FBROwnerTypeChecking(BuyerString, SellerString);
        //        #region FBR Tax Calculation For Buyer (Tables[0] is return the Buyer information)
        //        string stb, prcb;
        //        //@@@@@@@@@@@@@@@@@@@@@@@@@   Buyer Part / Filer @@@@@@@@@@@@@@@@@@@@@@@@@@@
        //        if (sdt.Tables[0].Rows[0]["FBROwnerType"].ToString() == "Filer")
        //        {
        //            #region New Code for Buyer -> Filer
        //            CalculatedTaxBuyer = (Convert.ToDecimal(dealval.ToString()) * 1) / 100;
        //            CalculatedTaxBuyerFBROwnerType = "Filer";
        //            if (Convert.ToDecimal(txtTaxKAmountBuyer) >= Math.Round(CalculatedTaxBuyer))
        //            {
        //                buyerCheckFiler = true;
        //            }
        //            else
        //            {
        //                buyerCheckFiler = false;

        //                MessageBox.Show("Buyer is not Valid to Purchase the File/Plot," + Environment.NewLine +
        //                            "Because Deal Value is : " + (dealval.ToString()) + Environment.NewLine
        //                            + " 1 % On deal value for Filer Buyer  is : " + Math.Round(CalculatedTaxBuyer) + Environment.NewLine +
        //                            "and you are Submit  :" + Math.Round(txtTaxKAmountBuyer), "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //            }
        //            #endregion

                    

        //        }
        //        //@@@@@@@@@@@@@@@@@@@@@@@@@   Buyer Part / Non-Filer @@@@@@@@@@@@@@@@@@@@@@@@@@@
        //        else if (sdt.Tables[0].Rows[0]["FBROwnerType"].ToString() == "Non-Filer")
        //        {
        //            #region New Code for Buyer -> Non-Filer
        //            CalculatedTaxBuyer = (Convert.ToDecimal(dealval.ToString()) * 2) / 100;
        //            CalculatedTaxBuyerFBROwnerType = "Non-Filer";
        //            if (Math.Round(Convert.ToDecimal(txtTaxKAmountBuyer)) >= Math.Round(CalculatedTaxBuyer))
        //            {
        //                buyerCheckNonFiler = true;
        //            }
        //            else
        //            {
        //                buyerCheckNonFiler = false;
        //                MessageBox.Show("Buyer is not Valid to Purchase the File/Plot," + Environment.NewLine +
        //                             "Because Deal Value is : " + Math.Round(dealval).ToString() + Environment.NewLine
        //                             + " 2 % On deal value for Non-Filer Buyer is : " + Math.Round(CalculatedTaxBuyer).ToString() + Environment.NewLine +
        //                             "and you are Submit :" + Math.Round(txtTaxKAmountBuyer), "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //            }
        //            #endregion
                    
        //        }



        //        #endregion
        //        //@@@@@@@@@@@@@@@@@@@@@@@@@   Seller Part / Filer @@@@@@@@@@@@@@@@@@@@@@@@@@@
        //        #region %%%%%%%%%%%%%  FBR Tax Calculation For Seller (Tables[1] is return the Seller information)
        //        string st = "", prc = "";
        //        if (sdt.Tables[1].Rows[0]["FBROwnerType"].ToString() == "Filer")
        //        {
        //            CalculatedTaxSeller = (Convert.ToDecimal(dealval.ToString()) * 1) / 100;
        //            CalculatedTaxSellerFBROwnerType = "Filer";
        //            st = "1 % Tax is apply on Filer Seller, So :";
        //            prc = "1 % ";
        //        }
        //        else if (sdt.Tables[1].Rows[0]["FBROwnerType"].ToString() == "Non-Filer")
        //        {
        //            CalculatedTaxSeller = (Convert.ToDecimal(dealval.ToString()) * 2) / 100;
        //            CalculatedTaxSellerFBROwnerType = "Non-Filer";
        //            st = "2 % Tax is apply on Non-Filer Seller, So :";
        //            prc = "2 % ";
        //        }

        //        #region Skip FBR Tax on Seller
        //        if (chkFBRSellerSkip.CheckState == CheckState.Unchecked)
        //        {
        //            if (Math.Round(Convert.ToDecimal(txtTaxCAmountSeller)) >= Math.Round(CalculatedTaxSeller))
        //            {
        //                sellerrCheckFiler = true;
        //            }
        //            else
        //            {
        //                sellerrCheckFiler = false;
        //                MessageBox.Show("Seller is not valid to Sold the Plot,  " + st + Environment.NewLine +
        //                    "Because Deal Value is : " + Math.Round(dealval).ToString() + Environment.NewLine +
        //                    prc + "Tax Amount of " + Math.Round(dealval).ToString() + " is : " + Math.Round(CalculatedTaxSeller) + Environment.NewLine +
        //                    "Submitted Tax Amount is : " + Math.Round(txtTaxCAmountSeller) + Environment.NewLine +
        //                    "Which is less then the Calculated " + prc + " Tax Amount.", "Information !", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        //                //btnNDCCreate_.Enabled = false;
        //                txtTaxCAmountSeller = 0;
        //                txtTaxKAmountBuyer = 0;
        //            }
        //        }
        //        else
        //        {
        //            sellerrCheckFiler = true;
        //            sellerrCheckNonFiler = true;
        //            btnNDCCreate_.Enabled = true;
        //        }

        //        #endregion


        //        #endregion
        //        #region  FBR Data and Seller Buyer Table Fillings
        //        DataTable dtFBRD = new DataTable();
        //        DataTable dtFBRD_CalculatedTax = new DataTable();
        //        DataTable dtFBRSB = new DataTable();
        //        DataTable dtFBRSB_CPRDetail = new DataTable();
        //        if ((buyerCheckFiler == true || buyerCheckNonFiler == true) && (sellerrCheckFiler == true || sellerrCheckNonFiler == true))
        //        {
        //            #region FBR Data Insertion
        //            dtFBRD.Clear();
        //            dtFBRD.Columns.Add("DealType");
        //            dtFBRD.Columns.Add("Deal_Amount");
        //            dtFBRD.Columns.Add("FileNo");
        //            dtFBRD.Columns.Add("Status");
        //            dtFBRD.Columns.Add("Remarks");
        //            DataRow drfd = dtFBRD.NewRow();
        //            drfd["DealType"] = rdbFBR.IsChecked ? "FBR" : "Other";
        //            drfd["Deal_Amount"] = Math.Round(dealval).ToString();
        //            drfd["FileNo"] = txtFile_No_.Text;
        //            drfd["Status"] = "Active";
        //            drfd["Remarks"] = "These Taxes are paid against NDC.";
        //            dtFBRD.Rows.Add(drfd);
        //            #endregion
        //            #region FBR Calculated Tax on Deal Value
        //            dtFBRD_CalculatedTax.Clear();
        //            dtFBRD_CalculatedTax.Columns.Add("CalculatedTaxOnDealAmount");
        //            dtFBRD_CalculatedTax.Columns.Add("TaxPaid");
        //            dtFBRD_CalculatedTax.Columns.Add("FBROwnerType");
        //            dtFBRD_CalculatedTax.Columns.Add("FileOwnerType");
        //            DataRow dct = dtFBRD_CalculatedTax.NewRow();
        //            dct["CalculatedTaxOnDealAmount"] = Math.Round(CalculatedTaxBuyer);
        //            dct["TaxPaid"] = Math.Round(txtTaxKAmountBuyer);
        //            dct["FileOwnerType"] = "Buyer";
        //            dct["FBROwnerType"] = CalculatedTaxBuyerFBROwnerType;

        //            DataRow dct1 = dtFBRD_CalculatedTax.NewRow();
        //            dct1["CalculatedTaxOnDealAmount"] = Math.Round(CalculatedTaxSeller);
        //            dct1["TaxPaid"] = Math.Round(txtTaxCAmountSeller);
        //            dct1["FileOwnerType"] = "Seller";
        //            dct1["FBROwnerType"] = CalculatedTaxSellerFBROwnerType;

        //            dtFBRD_CalculatedTax.Rows.Add(dct);
        //            dtFBRD_CalculatedTax.Rows.Add(dct1);
        //            #endregion

        //            #region FBR Seller Buyer Table
        //            dtFBRSB.Clear();
        //            dtFBRSB.Columns.Add("CNIC");
        //            dtFBRSB.Columns.Add("Name");
        //            dtFBRSB.Columns.Add("FatherName");
        //            dtFBRSB.Columns.Add("NTN");
        //            dtFBRSB.Columns.Add("Type");
        //            dtFBRSB.Columns.Add("FBROwnerType");

        //            //dtFBRSB.Columns.Add("CPRNo");
        //            //dtFBRSB.Columns.Add("CPRTaxAmount");
        //            //dtFBRSB.Columns.Add("CalculatedTaxOnDealAmount");
        //            foreach (GridViewRowInfo rowInfo in grdSeller_Buyer.Rows)
        //            {
        //                //bool bl = Convert.ToBoolean(rowInfo.Cells["SelectOwner"].Value);

        //                //if (bl == true)
        //                //{
        //                DataRow drfsb = dtFBRSB.NewRow();
        //                string typ = rowInfo.Cells["Type"].Value.ToString();
        //                if (typ == "Buyer")
        //                {
        //                    drfsb["CNIC"] = rowInfo.Cells["CNIC"].Value.ToString();
        //                    drfsb["Name"] = rowInfo.Cells["Name"].Value.ToString();
        //                    drfsb["FatherName"] = rowInfo.Cells["Father"].Value.ToString();
        //                    drfsb["NTN"] = rowInfo.Cells["NTN"].Value.ToString();
        //                    drfsb["Type"] = typ;

        //                    #region Find Filer , Non-Filer
        //                    if (!string.IsNullOrEmpty(rowInfo.Cells["NTN"].Value.ToString()))
        //                    {
        //                        #region Filer , Non-Filer
        //                        SqlParameter[] prm1 =
        //                        {
        //                                             new SqlParameter("@Task","GetFBROwnerType"),
        //                                             new SqlParameter("@NTN",ExtractNumberFromString(rowInfo.Cells["NTN"].Value.ToString()))
        //                                            };
        //                        DataSet dst1 = cls_dl_NDC.NdcRetrival(prm1);
        //                        if (dst1.Tables.Count > 0)
        //                        {
        //                            if (dst1.Tables[0].Rows.Count > 0)
        //                            {
        //                                if (dst1.Tables[0].Rows[0]["Type"].ToString() == "Filer")
        //                                {
        //                                    drfsb["FBROwnerType"] = "Filer";
        //                                }
        //                            }
        //                            else
        //                            {
        //                                drfsb["FBROwnerType"] = "Non-Filer";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            drfsb["FBROwnerType"] = "Non-Filer";
        //                        }
        //                        #endregion
        //                    }
        //                    else
        //                    {
        //                        drfsb["FBROwnerType"] = "Non-Filer";
        //                    }

        //                    #endregion

        //                    //drfsb["CPRNo"] = txtWHTk_.Text;
        //                    //drfsb["CPRTaxAmount"] = txtwhtkAmount.Text;
        //                    //drfsb["CalculatedTaxOnDealAmount"] = CalculatedTaxBuyer;

        //                }
        //                else if (typ == "Seller")
        //                {
        //                    drfsb["CNIC"] = rowInfo.Cells["CNIC"].Value.ToString();
        //                    drfsb["Name"] = rowInfo.Cells["Name"].Value.ToString();
        //                    drfsb["FatherName"] = rowInfo.Cells["Father"].Value.ToString();
        //                    drfsb["NTN"] = rowInfo.Cells["NTN"].Value.ToString();
        //                    drfsb["Type"] = typ;

        //                    #region Find Filer , Non-Filer
        //                    if (!string.IsNullOrEmpty(rowInfo.Cells["NTN"].Value.ToString()))
        //                    {
        //                        #region Filer , Non-Filer
        //                        SqlParameter[] prm1 =
        //                        {
        //                                            new SqlParameter("@Task","GetFBROwnerType"),
        //                                            new SqlParameter("@NTN",ExtractNumberFromString(rowInfo.Cells["NTN"].Value.ToString()))
        //                                            };
        //                        DataSet dst1 = cls_dl_NDC.NdcRetrival(prm1);
        //                        if (dst1.Tables.Count > 0)
        //                        {
        //                            if (dst1.Tables[0].Rows.Count > 0)
        //                            {
        //                                if (dst1.Tables[0].Rows[0]["Type"].ToString() == "Filer")
        //                                {
        //                                    drfsb["FBROwnerType"] = "Filer";
        //                                }
        //                            }
        //                            else
        //                            {
        //                                drfsb["FBROwnerType"] = "Non-Filer";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            drfsb["FBROwnerType"] = "Non-Filer";
        //                        }
        //                        #endregion
        //                    }
        //                    else
        //                    {
        //                        drfsb["FBROwnerType"] = "Non-Filer";
        //                    }

        //                    #endregion


        //                    //drfsb["CPRNo"] = txtWHTc_.Text;
        //                    //drfsb["CPRTaxAmount"] = txtwhtcAmount.Text;
        //                    //drfsb["CalculatedTaxOnDealAmount"] = CalculatedTaxSeller;
        //                }
        //                dtFBRSB.Rows.Add(drfsb);
        //                //}

        //            }
        //            #endregion
        //            #region Buyer Seller CPR Detail

        //            #region DataTable_Column Creation
        //            DataTable_column NTN = new DataTable_column() { ColmnName = "NTN", type = typeof(string) };
        //            DataTable_column CPRTaxAmount = new DataTable_column() { ColmnName = "CPRTaxAmount", type = typeof(double) };
        //            DataTable_column CPRNo = new DataTable_column() { ColmnName = "CPRNo", type = typeof(string) };

        //            #endregion
        //            #region Insert DataTabl_Column in List, and Send to Helper to make DataTable
        //            List<DataTable_column> colmn = new List<DataTable_column>();
        //            colmn.Add(NTN);
        //            colmn.Add(CPRTaxAmount);
        //            colmn.Add(CPRNo);
        //            dtFBRSB_CPRDetail = clsPluginHelper.ColmnsCreateinDatatable(colmn);
        //            #endregion
        //            #region Insertion in DataTable
        //            int rowcount = grdSeller_Buyer.Rows.Count;
        //            dtFBRSB_CPRDetail.Clear();
        //            foreach (GridViewRowInfo rowInfo in grdCPRData.Rows)
        //            {
        //                DataRow _row = dtFBRSB_CPRDetail.NewRow();// Create Row for Seller Data
        //                _row["NTN"] = rowInfo.Cells["NTN"].Value.ToString(); ;
        //                _row["CPRTaxAmount"] = Math.Round(Convert.ToDecimal(rowInfo.Cells["CPRAmount"].Value.ToString()));
        //                _row["CPRNo"] = rowInfo.Cells["CPRNo"].Value.ToString();
        //                dtFBRSB_CPRDetail.Rows.Add(_row);

        //            }
        //            #endregion

        //            #endregion
        //            #region FBR Detail Insertion
        //            if (dtFBRD.Rows.Count > 0 && dtFBRSB.Rows.Count > 0 && dtFBRD_CalculatedTax.Rows.Count > 0 && dtFBRSB_CPRDetail.Rows.Count > 0)
        //            {
        //                SqlParameter[] prtr =
        //                {
        //                                    new SqlParameter("@Task", "InsertFBRDetail"),
        //                                    new SqlParameter(){ ParameterName = "@tbl_FBRData",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRD},
        //                                    new SqlParameter(){ ParameterName = "@tbl_FBRD_CalculatedTax",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRD_CalculatedTax},
        //                                    new SqlParameter(){ ParameterName = "@tbl_FBR_Seller_Buyer",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRSB},
        //                                    new SqlParameter(){ ParameterName = "@tbl_FBRSB_CPRDetail",SqlDbType = SqlDbType.Structured, SqlValue = dtFBRSB_CPRDetail}
        //                                    };
        //                int rslt = cls_dl_NDC.NdcNonQuery(prtr);
        //                if (rslt > 0)
        //                {
        //                    MessageBox.Show("FBR Data is Valid and Saved Successfully.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    chkFBRSellerSkip.CheckState = CheckState.Unchecked;
        //                }
        //            }
        //            else
        //            {
        //                // MessageBox.Show("Both the Seller and Buyer Information are Required.");
        //            }
        //            #endregion


        //            txtTaxCAmountSeller = 0;
        //            txtTaxKAmountBuyer = 0;
        //        }
        //        else
        //        {
        //            MessageBox.Show("FBR Data Not Saved.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //        #endregion
        //        #endregion
        //    }
        //    else
        //    {
        //        MessageBox.Show("The CPR No. " + CheckCPRDuplicate() + " are Duplicated.");
        //    }
        //}
        //private DataSet GetDataForFBRDataChecking(string FileNo,int NDCNo)
        //{
        //    SqlParameter[] prmt =
        //    {
        //        new SqlParameter("@Task","Get_FBR_Detail"),
        //        new SqlParameter("@FileNo",FileNo),
        //        new SqlParameter("@NDCNo",NDCNo)
        //    };
        //    return null;
        //}
        //private string CheckCPRDuplicate()
        //{
        //    CPRString_ = "";
        //    foreach (GridViewRowInfo rw in grdCPRData.Rows)
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
        //                 new SqlParameter("@FileNo",txtFile_No_.Text)
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
        //}
    }
}
