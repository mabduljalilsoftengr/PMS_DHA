using PeshawarDHASW.Application_Layer.Transfer;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Data_Layer.Owner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Application_Layer.Transfer.TransferReport;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmReadyForTransfer : Telerik.WinControls.UI.RadForm
    {
        public string FileNo { get; set; }
        public int NDCNo { get; set; }
        public string SellerMSNOString { get; set; } = "";
        public string BuyerMSNOString { get; set; } = "";
        public int PurchaseTypeID { get; set; }
        public DataSet dst1 { get; set; }
        private DataTable dt_chk { get; set; }

        public frmReadyForTransfer()
        {
            InitializeComponent();
        }

        private void frmTransferAppoinmtment_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            #region GroupBox Enable

            grb_Info.Enabled = false;

            #endregion

            LoadDataForBasket();
        }

        private void LoadDataForBasket()
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","ReadyForTransfer"),
                new SqlParameter("@ExpireDate", string.IsNullOrEmpty(dtpappdate.Text) ? DBNull.Value : (object)dtpappdate.Value.Date)
                };
                DataSet ds = cls_dl_TFRAppointment.TFRReader(prm);
                grdReady_For_Transfer.DataSource = ds.Tables[0].DefaultView;

                ConditionalFormattingObject obj = new ConditionalFormattingObject("MyCondition1", ConditionTypes.LessOrEqual,"2", "", true);
                obj.RowBackColor = Color.Red;
                obj.RowForeColor = Color.White;
                this.grdReady_For_Transfer.Columns["RemainingDaysForExpiry"].ConditionalFormattingObjectList.Add(obj);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDataForBasket.", ex, "frmReadyForTransfer");
                frmobj.ShowDialog();
            }

        }

        private void FillDataGrid(RadGridView grd, string qury)
        {
            grd.DataSource =
                SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, qury).Tables[0].DefaultView;
        }

        private DataTable BuyerGDInfor()
        {
            DataTable Buyer = new DataTable();
            try
            {
                DataTable_column FileMapID = new DataTable_column() { ColmnName = "FileMapID", type = typeof(int) };
                DataTable_column _MemberID = new DataTable_column() { ColmnName = "MemberID", type = typeof(int) };
                DataTable_column userID = new DataTable_column() { ColmnName = "userID", type = typeof(int) };
                DataTable_column RateofSale = new DataTable_column() { ColmnName = "RateofSale", type = typeof(string) };
                DataTable_column DateofPurchase = new DataTable_column() { ColmnName = "DateofPurchase", type = typeof(string) };
                DataTable_column Status = new DataTable_column() { ColmnName = "Status", type = typeof(string) };
                DataTable_column TransferTypeID = new DataTable_column() { ColmnName = "TransferTypeID", type = typeof(int) };
                DataTable_column DateofSell = new DataTable_column() { ColmnName = "DateofSell", type = typeof(string) };
                DataTable_column EntryStatus = new DataTable_column() { ColmnName = "EntryStatus", type = typeof(string) };
                List<DataTable_column> cols = new List<DataTable_column>();
                cols.Add(FileMapID);
                cols.Add(_MemberID);
                cols.Add(Status);
                cols.Add(TransferTypeID);
                cols.Add(userID);
                cols.Add(RateofSale);
                cols.Add(DateofPurchase);
                cols.Add(DateofSell);
                cols.Add(EntryStatus);
                Buyer = clsPluginHelper.ColmnsCreateinDatatable(cols);
                int count_Buyer = grdBuyerInfo.Rows.Count;
                int reslt = 0;
                for (int i = 0; i < count_Buyer; i++)
                {
                    //object str = grdBuyerInfo.Rows[i].Cells[8].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : grdBuyerInfo.Rows[i].Cells[8].Value.ToString();
                    #region ++++++++++++++++++++++  Creat "BuyerMSNOString(BuyersNameString)"  +++++++++++++++++++++++
                    //BuyerMSNOString = grdBuyerInfo.Rows[i].Cells["Name"].Value.ToString() + "," + BuyerMSNOString;
                    #endregion
                    PurchaseTypeID = int.Parse(grdBuyerInfo.Rows[i].Cells["TypeID"].Value.ToString());
                    DataRow row = Buyer.NewRow();
                    row["MemberID"] = dst1.Tables[1].Rows[i]["ID"].ToString(); // This is the Membership ID of Dummy Entered Membership 
                    // int MemberID = int.Parse(grdBuyerInfo.Rows[i].Cells[0].Value.ToString());
                    row["FileMapID"] = grdBuyerInfo.Rows[i].Cells["FileMapKey"].Value.ToString(); // This is the FileMapKey ID of Dummy Entered Membership 
                    //string filekey = grdBuyerInfo.Rows[i].Cells[6].Value.ToString();
                    row["TransferTypeID"] = int.Parse(grdBuyerInfo.Rows[i].Cells["TypeID"].Value.ToString()); // This is the Membership ID of Dummy Entered Membership 
                    row["DateofPurchase"] = DateTime.Now.ToString("dd/MM/yyyy");
                    row["RateofSale"] = 0;
                    row["userID"] = clsUser.ID;
                    row["EntryStatus"] = "New";
                    row["Status"] = "Pending";
                    row["DateofSell"] = clsPluginHelper.DbNullIfNullOrEmpty("");
                    Buyer.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BuyerGDInfor.", ex, "frmReadyForTransfer");
                frmobj.ShowDialog();
            }

            return Buyer;
        }
        private DataTable SellerGDInfor()
        {
            DataTable Seller = new DataTable();
            DataTable_column OwnerID = new DataTable_column() { ColmnName = "OwnerID", type = typeof(int) };
            DataTable_column RateofSale = new DataTable_column() { ColmnName = "RateofSale", type = typeof(string) };
            DataTable_column DateofSell = new DataTable_column() { ColmnName = "DateofSell", type = typeof(string) };
            DataTable_column userID = new DataTable_column() { ColmnName = "userID", type = typeof(int) }; //PurchaseTypeID
            DataTable_column PurchaseType_ID = new DataTable_column() { ColmnName = "PurchaseType_ID", type = typeof(int) };

            List<DataTable_column> cols = new List<DataTable_column>();
            cols.Add(OwnerID);
            cols.Add(userID);
            cols.Add(RateofSale);
            cols.Add(DateofSell);
            cols.Add(PurchaseType_ID);
            Seller = clsPluginHelper.ColmnsCreateinDatatable(cols);
            if (grdBuyerInfo.Rows.Count > 0)
            {
                SellerMSNOString = "";
                int count_Seller = grdSellerInfo.Rows.Count;
                int result = 0;
                for (int i = 0; i < count_Seller; i++)
                {
                    #region +++++++++++++++++++++++  Generate Sellers String  +++++++++++++++++++++++++++++++++++
                    SellerMSNOString = grdSellerInfo.Rows[i].Cells["Name"].Value.ToString() + " ( "+grdSellerInfo.Rows[i].Cells["MembershipNo"].Value.ToString() +" )"  + "," + SellerMSNOString;

                    //int id = grdBuyerInfo.Rows[i].Cells[3].Value;

                    if (i == 0)
                    {
                        PurchaseTypeID = int.Parse(grdBuyerInfo.Rows[i].Cells["PurchaseTypeID"].Value.ToString());
                    }
                    #endregion
                    string dateOfSale = DateTime.Now.ToString("dd/MM/yyyy");
                    int Owner_ID = int.Parse(grdSellerInfo.Rows[i].Cells["OwnerID"].Value.ToString());
                    object RateofSell = grdSellerInfo.Rows[i].Cells["RateofSale"].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("0") : grdSellerInfo.Rows[i].Cells["RateofSale"].Value.ToString();
                    // OwnerID  |  UserID         |  RateofSell | DateofSale
                    int typePurchaseID = PurchaseTypeID;
                    Seller.Rows.Add(Owner_ID, Models.clsUser.ID, RateofSell, dateOfSale, typePurchaseID);
                }
                return Seller;  //DataTable with Data  
            }
            else
            {
                return Seller; //Empty DataTable 
            }
        }
        private DataTable NDCExpire()
        {
            DataTable NDCSetting = new DataTable();
            try
            {
                DataTable_column _NDCNo = new DataTable_column() { ColmnName = "NDCNo", type = typeof(int) };
                DataTable_column NDCStatus = new DataTable_column() { ColmnName = "NDCStatus", type = typeof(string) };
                DataTable_column userID = new DataTable_column() { ColmnName = "userID", type = typeof(int) };
                List<DataTable_column> cols = new List<DataTable_column>();
                cols.Add(_NDCNo);
                cols.Add(NDCStatus);
                cols.Add(userID);
                NDCSetting = clsPluginHelper.ColmnsCreateinDatatable(cols);
                DataRow row = NDCSetting.NewRow();
                row["NDCNo"] = int.Parse(NDCNo.ToString());
                row["userID"] = clsUser.ID;
                row["NDCStatus"] = "Use_For_Transfer";
                NDCSetting.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on NDCExpire.", ex, "frmReadyForTransfer");
                frmobj.ShowDialog();
            }

            return NDCSetting;

        }
        private DataTable TFRAppointment()
        {
            DataTable TFRAppointmentDS = new DataTable();
            try
            {
                DataTable_column TFRAppoimtmentID = new DataTable_column() { ColmnName = "TFRAppoimtmentID", type = typeof(int) };
                DataTable_column ExpireDate = new DataTable_column() { ColmnName = "ExpireDate", type = typeof(string) };
                DataTable_column Status = new DataTable_column() { ColmnName = "Status", type = typeof(string) };
                DataTable_column userID = new DataTable_column() { ColmnName = "userID", type = typeof(int) };
                List<DataTable_column> cols = new List<DataTable_column>();
                cols.Add(TFRAppoimtmentID);
                cols.Add(ExpireDate);
                cols.Add(Status);
                cols.Add(userID);
                TFRAppointmentDS = clsPluginHelper.ColmnsCreateinDatatable(cols);
                DataRow row = TFRAppointmentDS.NewRow();
                row["TFRAppoimtmentID"] = TFRAppointmentNo;
                row["ExpireDate"] = DateTime.Now.ToString("MM/dd/yyyy");
                row["userID"] = clsUser.ID;
                row["Status"] = "Expire";
                TFRAppointmentDS.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on TFRAppointment.", ex, "frmReadyForTransfer");
                frmobj.ShowDialog();
            }

            return TFRAppointmentDS;

        }
        private DataTable TransferTracking()
        {
            BuyerMSNOString = "";
            int count_Buyer = grdBuyerInfo.Rows.Count;
            for (int i = 0; i < count_Buyer; i++)
            {
                //object str = grdBuyerInfo.Rows[i].Cells[8].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : grdBuyerInfo.Rows[i].Cells[8].Value.ToString();
                #region ++++++++++++++++++++++  Creat "BuyerMSNOString(BuyersNameString)"  +++++++++++++++++++++++
                BuyerMSNOString = grdBuyerInfo.Rows[i].Cells["Name"].Value.ToString() + "," + BuyerMSNOString;
                //PurchaseTypeID = int.Parse(grdBuyerInfo.Rows[i].Cells["TypeID"].Value.ToString());
                #endregion
            }
            DataTable tbl_TransferTracking = new DataTable();
            try
            {
                DataTable_column TFR_Status = new DataTable_column() { ColmnName = "TFR_Status", type = typeof(string) };
                DataTable_column SellerMS_String = new DataTable_column() { ColmnName = "SellerMS_String", type = typeof(string) };
                DataTable_column BuyerMS_String = new DataTable_column() { ColmnName = "BuyerMS_String", type = typeof(string) };
                DataTable_column NDCNo_col = new DataTable_column() { ColmnName = "NDCNo", type = typeof(int) };
                DataTable_column File_No = new DataTable_column() { ColmnName = "FileNo", type = typeof(string) };
                DataTable_column Purchase_TypeID = new DataTable_column() { ColmnName = "PurchaseTypeID", type = typeof(int) };
                DataTable_column TransferDate = new DataTable_column() { ColmnName = "TransferDate", type = typeof(DateTime) };
                DataTable_column AllocationDate = new DataTable_column() { ColmnName = "AllocationDate", type = typeof(string) };
                List<DataTable_column> cols = new List<DataTable_column>();
                cols.Add(TFR_Status);
                cols.Add(SellerMS_String);
                cols.Add(BuyerMS_String);
                cols.Add(NDCNo_col);
                cols.Add(File_No);
                cols.Add(Purchase_TypeID);
                cols.Add(TransferDate);
                cols.Add(AllocationDate);
                tbl_TransferTracking = clsPluginHelper.ColmnsCreateinDatatable(cols);
                DataRow row = tbl_TransferTracking.NewRow();
                row["TFR_Status"] = "Use_For_Transfer"; // ReadyForPicture
                row["SellerMS_String"] = SellerMSNOString.Remove(SellerMSNOString.Length - 1);
                row["BuyerMS_String"] = BuyerMSNOString.Remove(BuyerMSNOString.Length - 1);
                row["NDCNo"] = NDCNo;
                row["FileNo"] = FileNo;
                row["PurchaseTypeID"] = PurchaseTypeID;
                row["TransferDate"] = clsPluginHelper.DbNullIfNullOrEmpty("");
                if (dtpallocationdate.Value.Date >= DateTime.Now.Date)
                {
                    row["AllocationDate"] = dtpallocationdate.Value.Date.ToString();
                }
                else
                {
                    if (FileNo.ToUpper().Contains("OLO"))
                    {
                        row["AllocationDate"] = "With in One Month.";
                    }
                    else
                    {
                        row["AllocationDate"] = DBNull.Value;
                    }
                   
                }
               
                tbl_TransferTracking.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on TransferTracking.", ex, "frmReadyForTransfer");
                frmobj.ShowDialog();
            }

            return tbl_TransferTracking;

        }
        public int TFRAppointmentNo { get; set; }
        private void grdReady_For_Transfer_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                NDCNo = e.Row.Cells["NDCNo"].Value == null ? 0 : int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                FileNo = e.Row.Cells["FileNo"].Value == null ? "0" : e.Row.Cells["FileNo"].Value.ToString();
                TFRAppointmentNo = e.Row.Cells["TFRAppoimtmentID"].Value == null ? 0 : int.Parse(e.Row.Cells["TFRAppoimtmentID"].Value.ToString());
                int filekey = e.Row.Cells["FileMapKey"].Value == null ? 0 : int.Parse(e.Row.Cells["FileMapKey"].Value.ToString());
                if (e.Column.Name == "CreateTFR")
                {
                    #region New Members Against NDCNo
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","Get_Info_For_Transfer"),
                    new SqlParameter("@NDCNo",NDCNo)
                    };
                    dst1 = cls_dl_NDC.NdcRetrival(prm);
                    if (dst1.Tables[0].Rows.Count > 0)
                    {
                        lblFileNO.Text = dst1.Tables[0].Rows[0]["FileNo"].ToString();
                        lblPlotNo.Text = dst1.Tables[0].Rows[0]["PlotNo"].ToString();
                        lblSector.Text = dst1.Tables[0].Rows[0]["SectorName"].ToString();
                        lblPhase.Text = dst1.Tables[0].Rows[0]["PhaseName"].ToString();
                        lblPlotSIZE.Text = dst1.Tables[0].Rows[0]["MeasuredSqYard"].ToString();
                        lblTransferType.Text = dst1.Tables[0].Rows[0]["TransferTypeName"].ToString();
                        lblfile_no.Text = dst1.Tables[0].Rows[0]["FileNo"].ToString();
                        lblname.Text = "";
                        string nam = "";
                        foreach (DataRow DR in dst1.Tables[1].Rows)
                        {
                             nam = nam + "  " + DR["Name"].ToString();  
                        }
                        lblname.Text = nam;
                        lbldateoftransfer.Text = dst1.Tables[2].Rows[0]["CurrentDate"].ToString();
                        grdSellerInfo.DataSource = dst1.Tables[0].DefaultView;
                        grdBuyerInfo.DataSource = dst1.Tables[1].DefaultView;
                        grdTfrChecklist.DataSource = dst1.Tables[2].DefaultView;
                    }
                    #endregion
                    #region Current Owner Aganist FileNo(Against NDCNo)
                    //SqlParameter[] prmtr =
                    //{
                    //new SqlParameter("@Task","Select_Current_Owner_Detail"),
                    //new SqlParameter("@File_No",FileNo)
                    //};
                    //DataSet ds = new DataSet();
                    //ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(prmtr);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    //FileKey = int.Parse(ds.Tables[0].Rows[0]["FileMapKey"].ToString());
                    //    grdSellerInfo.DataSource = ds.Tables[0].DefaultView;
                    //}
                    #endregion
                }
                else if (e.Column.Name == "btnModifyAppDate")
                {
                    DateTime ndcexp = DateTime.Parse(e.Row.Cells["NDCExpireDate"].Value.ToString());
                    DateTime ndcissue = DateTime.Parse(e.Row.Cells["DateIssue"].Value.ToString());
                    DateTime apptmntdate = DateTime.Parse(e.Row.Cells["ExpireDate"].Value.ToString());
                    if (apptmntdate.Date >= ndcissue.Date && apptmntdate.Date <= ndcexp.Date)
                    {
                        int apptmntID = int.Parse(e.Row.Cells["TFRAppoimtmentID"].Value.ToString());
                        SqlParameter[] prmt =
                        {
                            new SqlParameter("@Task","UpdateAppDate"),
                            new SqlParameter("@ExpireDate",apptmntdate),
                            new SqlParameter("@TFRAppoimtmentID",apptmntID)
                        };
                        int rslt = cls_dl_TFRAppointment.AppointmentNonQuery(prmt);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Successful.");
                            LoadDataForBasket();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The Appointment Date must be Equall Or Greater then " + Environment.NewLine +
                                        "NDC Issue Date,NDC Issue Date,and Equall Or Less " + Environment.NewLine +
                                        "then the NDC Expire Date.", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdReady_For_Transfer_CellClick.", ex, "frmReadyForTransfer");
                frmobj.ShowDialog();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ,That the Transfer Information is Correct !", "Confirmation !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    //DataTable Buyer = BuyerGDInfor();
                    DataTable NDCSetting = NDCExpire();
                    DataTable TFRAppoinmentDt = TFRAppointment();
                    DataTable Seller = SellerGDInfor();
                    DataTable tbl_TransferTracking = TransferTracking();
                    SqlParameter[] parameter =
                    {
                     new SqlParameter("@Task","TransferSetting"),
                     new SqlParameter(){ ParameterName = "@NDCTable",SqlDbType = SqlDbType.Structured, SqlValue = NDCSetting},
                     new SqlParameter(){ ParameterName = "@TFRAppointment",SqlDbType = SqlDbType.Structured, SqlValue = TFRAppoinmentDt},
                     //new SqlParameter(){ ParameterName = "@BuyerOwnerTable",SqlDbType = SqlDbType.Structured, SqlValue = Buyer},
                     new SqlParameter(){ ParameterName = "@SellerOWnerTable",SqlDbType = SqlDbType.Structured, SqlValue = Seller},
                     new SqlParameter() { ParameterName = "@TransferTracking",SqlDbType = SqlDbType.Structured, SqlValue = tbl_TransferTracking }
                    };
                    int result = cls_dl_TFR.TranferSetting(parameter);
                    if (result > 0)
                    {
                        MessageBox.Show("Successfull");
                        Clear();
                        grb_Info.Enabled = false;
                        LoadDataForBasket();
                        //frmTakeImage obj = new frmTakeImage(FileNo, NDCNo, PurchaseTypeID, SellerMSNOString, BuyerMSNOString);
                        //obj.ShowDialog();
                        //MessageBox.Show(result.ToString()+"\t successfull");

                    }
                }
                catch (Exception ex)
                {
                    frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSave_Click.", ex, "frmReadyForTransfer");
                    frmobj.ShowDialog();
                }

            }
            //this.Hide();
        }
        private void Clear()
        {
            //lblDHA.Text = "";
            lblFileNO.Text = "";
            lblPhase.Text = "";
            lblPlotNo.Text = "";
            lblPlotSIZE.Text = "";
            lblSector.Text = "";
            lblTransferType.Text = "";
            grdSellerInfo.DataSource = null;
            grdBuyerInfo.DataSource = null;
            grdSellerInfo.Rows.Clear();
            grdBuyerInfo.Rows.Clear();
            grdTfrChecklist.DataSource = null;
            lblfile_no.Text = "#";
            lblname.Text = "#";
            lbldateoftransfer.Text = "#";
            if (!String.IsNullOrEmpty(dtpallocationdate.Value.ToString()))
            {
                dtpallocationdate.SetToNullValue();
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataForBasket();
        }

        private void chkClear_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkClear.CheckState == CheckState.Checked)
            {
                dtpappdate.SetToNullValue();
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                int recnt = grdTfrChecklist.Rows.Count;
                if(recnt > 0)
                {
                    #region
                    int inccnt = 0;
                    foreach (GridViewRowInfo row in grdTfrChecklist.Rows)
                    {
                        bool chk = Convert.ToBoolean(row.Cells["chkRecieved"].Value);
                        if (chk)
                        {
                            inccnt = inccnt + 1;
                            //string category = Convert.ToString(row.Cells[1].Value);
                            //string particular = Convert.ToString(row.Cells[2].Value);
                            //string detail = Convert.ToString(row.Cells[3].Value);
                            //string status = Convert.ToString(row.Cells[4].Value);
                        }
                    }
                    if (recnt == inccnt)
                    {
                        if (!dst1.Tables[2].Columns.Contains("BuyerName") &&
                            !dst1.Tables[2].Columns.Contains("DateOfTransfer") &&
                            !dst1.Tables[2].Columns.Contains("FileNo") &&
                            !dst1.Tables[2].Columns.Contains("DateOfAllocation") &&
                            !dst1.Tables[2].Columns.Contains("UserName")
                          )
                        {
                            dt_chk = dst1.Tables[2];
                            dt_chk.Columns.Add("BuyerName", typeof(System.String));
                            dt_chk.Columns.Add("DateOfTransfer", typeof(System.DateTime));
                            dt_chk.Columns.Add("FileNo", typeof(System.String));
                            dt_chk.Columns.Add("DateOfAllocation", typeof(System.String));
                            dt_chk.Columns.Add("UserName", typeof(System.String));

                            foreach (DataRow row in dt_chk.Rows)
                            {
                                //need to set value to NewColumn column
                                row["BuyerName"] = lblname.Text;   // or set it to some other value
                                row["DateOfTransfer"] = lbldateoftransfer.Text;
                                row["FileNo"] = lblfile_no.Text;

                                if ( !(lblfile_no.Text.ToUpper().Contains("OLO")) )
                                {
                                    if (dtpallocationdate.Value.Date >= DateTime.Now.Date)
                                    {
                                        row["DateOfAllocation"] = dtpallocationdate.Value.Date.ToString();
                                    }
                                    else
                                    {
                                        row["DateOfAllocation"] = "";
                                    }
                                }
                                else
                                {
                                    row["DateOfAllocation"] = "With in One Month.";
                                }
                               
                                
                                row["UserName"] = Models.clsUser.Name;
                            }
                        }
                        else
                        {
                            dt_chk.Columns.Remove("BuyerName");
                            dt_chk.Columns.Remove("DateOfTransfer");
                            dt_chk.Columns.Remove("FileNo");
                            dt_chk.Columns.Remove("DateOfAllocation");
                            dt_chk.Columns.Remove("UserName");


                            dt_chk = dst1.Tables[2];
                            dt_chk.Columns.Add("BuyerName", typeof(System.String));
                            dt_chk.Columns.Add("DateOfTransfer", typeof(System.DateTime));
                            dt_chk.Columns.Add("FileNo", typeof(System.String));
                            dt_chk.Columns.Add("DateOfAllocation", typeof(System.String));
                            dt_chk.Columns.Add("UserName", typeof(System.String));

                            foreach (DataRow row in dt_chk.Rows)
                            {
                                //need to set value to NewColumn column
                                row["BuyerName"] = lblname.Text;   // or set it to some other value
                                row["DateOfTransfer"] = lbldateoftransfer.Text;
                                row["FileNo"] = lblfile_no.Text;
                                if (dtpallocationdate.Value.Date >= DateTime.Now.Date)
                                {
                                    row["DateOfAllocation"] = dtpallocationdate.Value.Date.ToString();
                                }
                                else
                                {
                                    row["DateOfAllocation"] = "";
                                }
                                row["UserName"] = Models.clsUser.Name;
                            }
                        }

                        frm_Checklist_Report_Viewer frm = new frm_Checklist_Report_Viewer(dt_chk, "ChecklistReport");
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please verify all the documents.", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    #endregion
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnnexttotfr_Click(object sender, EventArgs e)
        {
            try
            {

                if(MessageBox.Show("Are you Print Checklist Report ?","Warning !",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int recnt = grdTfrChecklist.Rows.Count;
                    if (recnt > 0)
                    {
                        int inccnt = 0;
                        foreach (GridViewRowInfo row in grdTfrChecklist.Rows)
                        {
                            bool chk = Convert.ToBoolean(row.Cells["chkRecieved"].Value);
                            if (chk)
                            {
                                inccnt = inccnt + 1;
                                //string category = Convert.ToString(row.Cells[1].Value);
                                //string particular = Convert.ToString(row.Cells[2].Value);
                                //string detail = Convert.ToString(row.Cells[3].Value);
                                //string status = Convert.ToString(row.Cells[4].Value);
                            }
                        }
                        if (recnt == inccnt)
                        {
                            grb_Info.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Please verify all the documents.", "Stop!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                
               



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void chkcleartfr_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkcleartfr.CheckState == CheckState.Checked)
            {
                dtpallocationdate.SetToNullValue();
            }
        }
    }
}
