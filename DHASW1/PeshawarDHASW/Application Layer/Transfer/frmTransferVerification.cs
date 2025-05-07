using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.NDC.Baskets;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Image = System.Drawing.Image;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Transfer
{
    public partial class frmTransferVerification : Telerik.WinControls.UI.RadForm
    {
        public int NDCNo { get; set; }
        public int TFRNo { get; set; }
        private int TFRAppointmentID { get; set; }
        public int TypeOfPurchaseID { get; set; }
        public int FileMapKey { get; set; }
        public frmTransferVerification(int get_ndcno,int get_TFR_No,bool get_tatus)
        {
            InitializeComponent();
            NDCNo = get_ndcno;
            TFRNo = get_TFR_No;
            if (get_tatus == false)
            {
                txtNDCNo.Enabled = get_tatus;
            }
            
        }
        public frmTransferVerification()
        {
            InitializeComponent();
        }

        private void frmTransferVerification_Load(object sender, EventArgs e)
        {
            grdGoToBack.Enabled = false;
            txtNDCNo.Text = NDCNo.ToString();
            string ndc = NDCNo.ToString();
            Verification(ndc);
            LoadDataForBasket();
        }
        private void LoadDataForBasket()
        {
            try
            {
                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text,
                               "Select * from tbl_Basket_Queries Where Status Like 'ON'");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["Task_Name"].ToString() == "ReadyForGoBack")
                    {
                        FillDataGrid(grdGoToBack, row["Query"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadDataForBasket.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
           
        }
        private void FillDataGrid(RadGridView grd, string qury)
        {
            try
            {
                SqlParameter[] prm =
                           {
                new SqlParameter("@NDCNo",NDCNo)
            };
                grd.DataSource =
                    SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.Text, qury, prm).Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FillDataGrid.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
           
        }
        private void Verification(string NDC_no)
        {
            try
            {
                #region Check that NDC is already verified or not 
                SqlParameter[] parameter =
                {
                new SqlParameter("@Task","CheckNDCNo_For_Verification"),
                new SqlParameter("@NDCNO",NDC_no)
                };
                DataSet ds_tt = cls_dl_TFRVerification.TFRVerification_Reader(parameter);
                if (ds_tt.Tables[0].Rows[0]["StatusofNDC"].ToString() != "Verified")
                {
                    #region  OnLeave Action
                    SqlParameter[] parameters =
                   {
                    new SqlParameter("@Task","TFRVerification"),
                    new SqlParameter("@NDCNO",NDC_no)
                   };
                    DataSet dataSet = new DataSet();
                    dataSet = cls_dl_TFRVerification.TFRVerification_Reader(parameters);

                    #region TFR Appointment
                    if (dataSet.Tables[0].Rows.Count != 0)
                    {
                        TFRAppointmentID = int.Parse(dataSet.Tables[0].Rows[0]["TFRAppoimtmentID"].ToString());
                        lblTFRAppointment.Text = dataSet.Tables[0].Rows[0]["TFRAppoimtmentID"].ToString();
                        lblTFRAppIssuDate.Text = DateTime.Parse(dataSet.Tables[0].Rows[0]["IssueDate"].ToString()).ToString("dd/MM/yyyy");
                        lblTFRAppExpDate.Text = DateTime.Parse(dataSet.Tables[0].Rows[0]["ExpireDate"].ToString()).ToString("dd/MM/yyyy");
                    }
                    #endregion

                    #region Transfer Fee
                    if (dataSet.Tables[1].Rows.Count != 0)
                    {
                        lblchallanno.Text = dataSet.Tables[1].Rows[0]["ChallanNo"].ToString();
                        lblchallIan_ReceDate.Text = DateTime.Parse(dataSet.Tables[1].Rows[0]["DateofRece"].ToString()).ToString("dd/MM/yyyy");
                        string DateofExpire = dataSet.Tables[1].Rows[0]["DateofExpire"].ToString();
                        lblchallIan_ReceExpDate.Text = DateofExpire != "" ? DateTime.Parse(DateofExpire).ToString("dd/MM/yyyy") : "";
                    }
                    #endregion

                    #region NDC
                    if (dataSet.Tables[2].Rows.Count != 0)
                    {
                        lblNDCNo.Text = dataSet.Tables[2].Rows[0]["NDCNo"].ToString();
                        lblNDCIssueDate.Text = DateTime.Parse(dataSet.Tables[2].Rows[0]["DateIssue"].ToString()).ToString("dd/MM/yyyy");
                        string DateofExpire = dataSet.Tables[2].Rows[0]["NDCExpireDate"].ToString();
                        lblNDCExpDate.Text = DateofExpire;
                        //DateofExpire != "" ? DateTime.Parse(DateofExpire).ToString("dd/MM/yyyy") : "";
                    }
                    #endregion

                    #region Type of Purchase
                    if (dataSet.Tables[3].Rows.Count != 0)
                    {
                        TypeOfPurchaseID = int.Parse(dataSet.Tables[3].Rows[0]["TypePurchaseID"].ToString());
                        lblTypeOfTransfer.Text = dataSet.Tables[3].Rows[0]["TypeofPurchase"].ToString();
                    }
                    #endregion

                    #region Current Owner
                    if (dataSet.Tables[4].Rows.Count != 0)
                    {
                        grdSellerInfo.DataSource = dataSet.Tables[4].DefaultView;
                    }
                    #endregion

                    #region New Owner
                    if (dataSet.Tables[5].Rows.Count != 0)
                    {
                        grdBuyerInfo.DataSource = dataSet.Tables[5].DefaultView;
                    }
                    #endregion

                    #region Image
                    if (dataSet.Tables[6].Rows.Count != 0)
                    {
                        imgTFRImage.Image = ImageRetrive(dataSet.Tables[6], "Image");
                    }
                    #endregion
                    #region File Information
                    if (dataSet.Tables[7].Rows.Count != 0)
                    {
                        FileMapKey = int.Parse(dataSet.Tables[7].Rows[0]["FileMapKey"].ToString());
                    }
                    #endregion
                    #endregion
                }
                else
                {
                    MessageBox.Show("This NDC is already Verified.");
                }

                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Verification.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
            
        }
        private Image ImageRetrive(DataTable table,string fieldName)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                // Transfer everything to the Image property of the picture box....
                //Challan_Image_ID = int.Parse(dsImage.Tables[0].Rows[imageindex]["ID"].ToString());
                byte[] imgData = (byte[])table.Rows[0][fieldName];
                ms = new MemoryStream(imgData);
                ms.Position = 0;

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ImageRetrive.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
            return Image.FromStream(ms);
        }
    

        private void Clearfunction()
        {
            lblchallIan_ReceDate.Text = "";
            lblchallIan_ReceExpDate.Text = "";
            lblNDCIssueDate.Text = "";
            lblNDCExpDate.Text = "";
            lblTFRAppIssuDate.Text = "";
            lblTFRAppExpDate.Text = "";
            lblTypeOfTransfer.Text = "";
        }
        #region DataTables ChallanRecieve/ File / Owner (Current , OLD)
        private DataTable ChallanRecieve()
        {
            DataTable Challa_Recieve = new DataTable();
            try
            {
                DataTable_column ExpireDate = new DataTable_column() { ColmnName = "ExpireDate", type = typeof(DateTime) };
                DataTable_column Status = new DataTable_column() { ColmnName = "Status", type = typeof(string) };
                DataTable_column ChallanNO = new DataTable_column() { ColmnName = "ChallanNO", type = typeof(string) };
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(ExpireDate);
                colmn.Add(Status);
                colmn.Add(ChallanNO);
                Challa_Recieve = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                DataRow row = Challa_Recieve.NewRow();
                row["ExpireDate"] = DateTime.Now;
                row["Status"] = "Expire";
                row["ChallanNO"] = lblchallanno.Text;
                Challa_Recieve.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ChallanRecieve.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
            return Challa_Recieve;
        }
        private DataTable FileMap()
        {
            DataTable tbl_FileMap = new DataTable();
            try
            {
                DataTable_column TFRTypeID = new DataTable_column() { ColmnName = "TFRTypeID", type = typeof(int) };
                DataTable_column NDCNo = new DataTable_column() { ColmnName = "NDCNo", type = typeof(int) };
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(TFRTypeID);
                colmn.Add(NDCNo);
                tbl_FileMap = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                DataRow row = tbl_FileMap.NewRow();
                row["TFRTypeID"] = TypeOfPurchaseID;
                row["NDCNo"] = txtNDCNo.Text;
                tbl_FileMap.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on FileMap.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
            return tbl_FileMap;
        }
        private DataTable Owner_Current_To_Transferee()
        {
            DataTable tbl_Owner_ = new DataTable();
            try
            {
                DataTable_column Owner_ID = new DataTable_column() { ColmnName = "Owner_ID", type = typeof(int) };
                DataTable_column Owner_Status_old = new DataTable_column() { ColmnName = "Owner_Status_old", type = typeof(string) };
                DataTable_column Owner_Status_new = new DataTable_column() { ColmnName = "Owner_Status_new", type = typeof(string) };
                DataTable_column NDCNo = new DataTable_column() { ColmnName = "NDCNo", type = typeof(int) };
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(Owner_ID);
                colmn.Add(Owner_Status_old);
                colmn.Add(Owner_Status_new);
                colmn.Add(NDCNo);
                tbl_Owner_ = clsPluginHelper.ColmnsCreateinDatatable(colmn);

                ///////////
                int CurrentOwnersCount = grdSellerInfo.Rows.Count;
                for (int i = 0; i < CurrentOwnersCount; i++)
                {
                    DataRow row = tbl_Owner_.NewRow();
                    int OwnerID = int.Parse(grdSellerInfo.Rows[i].Cells[0].Value.ToString());
                    row["Owner_ID"] = OwnerID;
                    row["Owner_Status_old"] = "Current";
                    row["Owner_Status_new"] = "Transferee";
                    row["NDCNo"] = txtNDCNo.Text;
                    tbl_Owner_.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Owner_Current_To_Transferee.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
          
            return tbl_Owner_ ;
        }
        private DataTable Owner_Pending_To_Current()
        {
            DataTable _tbl_Owner_ = new DataTable();
            try
            {
                DataTable_column Owner_ID = new DataTable_column() { ColmnName = "Owner_ID", type = typeof(int) };
                DataTable_column Owner_Status_old = new DataTable_column() { ColmnName = "Owner_Status_old", type = typeof(string) };
                DataTable_column Owner_Status_new = new DataTable_column() { ColmnName = "Owner_Status_new", type = typeof(string) };
                DataTable_column NDCNo = new DataTable_column() { ColmnName = "NDCNo", type = typeof(int) };
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(Owner_ID);
                colmn.Add(Owner_Status_old);
                colmn.Add(Owner_Status_new);
                colmn.Add(NDCNo);
                _tbl_Owner_ = clsPluginHelper.ColmnsCreateinDatatable(colmn);

                int PendingOwnersCount = grdBuyerInfo.Rows.Count;
                for (int i = 0; i < PendingOwnersCount; i++)
                {
                    DataRow row = _tbl_Owner_.NewRow();
                    int OwnerID = int.Parse(grdBuyerInfo.Rows[i].Cells[0].Value.ToString());
                    row["Owner_ID"] = OwnerID;
                    row["Owner_Status_old"] = "Pending";
                    row["Owner_Status_new"] = "Current";
                    row["NDCNo"] = txtNDCNo.Text;
                    _tbl_Owner_.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on _tbl_Owner_.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
            return _tbl_Owner_ ;
        }
        #endregion
        private DataTable Transfer_Tracking()
        {
            DataTable tbl_TFR_Tracking = new DataTable();
            try
            {
                DataTable_column TFRNocol = new DataTable_column() { ColmnName = "TFRNo", type = typeof(int) };
                DataTable_column TFRTrackingStatus = new DataTable_column() { ColmnName = "TFRTrackingStatus", type = typeof(string) };
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(TFRNocol);
                colmn.Add(TFRTrackingStatus);
                tbl_TFR_Tracking = clsPluginHelper.ColmnsCreateinDatatable(colmn);

                DataRow row = tbl_TFR_Tracking.NewRow();
                row["TFRNo"] = TFRNo;
                row["TFRTrackingStatus"] = "ReadyForTFRLetterImageUpload";
                tbl_TFR_Tracking.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Transfer_Tracking.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
       
                return tbl_TFR_Tracking;
        }
        private DataTable Transfer_History_Image()
        {
            DataTable tbl_TFR_History_Image = new DataTable();
            try
            {
                DataTable_column TFRHistoryImage_Status = new DataTable_column() { ColmnName = "TFRHistoryImage_Status", type = typeof(string) };
                DataTable_column TFRNo_col = new DataTable_column() { ColmnName = "TFRNo_col", type = typeof(int) };
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(TFRHistoryImage_Status);
                colmn.Add(TFRNo_col);
                tbl_TFR_History_Image = clsPluginHelper.ColmnsCreateinDatatable(colmn);

                DataRow row = tbl_TFR_History_Image.NewRow();
                row["TFRHistoryImage_Status"] = "Verified";
                row["TFRNo_col"] = TFRNo;
                tbl_TFR_History_Image.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Transfer_History_Image.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }

            return tbl_TFR_History_Image;
        }

        private DataTable Stamp_Duty_State_Change_To_Expire()
        {
            DataTable Stamp_Duty_state = new DataTable();
            try
            {
                DataTable_column file_key = new DataTable_column() { ColmnName = "file_key", type = typeof(string) };
                List<DataTable_column> colmn = new List<DataTable_column>();
                colmn.Add(file_key);
                Stamp_Duty_state = clsPluginHelper.ColmnsCreateinDatatable(colmn);
                DataRow row = Stamp_Duty_state.NewRow();
                row["file_key"] = FileMapKey;
                Stamp_Duty_state.Rows.Add(row);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Stamp_Duty_State_Change_To_Expire.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
            return Stamp_Duty_state;
        }
        private void btnVerification_Click(object sender, EventArgs e)
        {
            frm_Secret_Code obj = new frm_Secret_Code();
            obj.ShowDialog();
            if(Helper.clsMostUseVars.Drctr_Secret_Code == true)
            {
                try
                {
                    DataTable ChallanRece = ChallanRecieve();
                    DataTable File = FileMap();
                    DataTable OwnerCurrentToTransferee = Owner_Current_To_Transferee();
                    DataTable OwnerPendingToCurrent = Owner_Pending_To_Current();
                    DataTable tbl_TFRTracking = Transfer_Tracking();
                    DataTable tbl_Transfer_History_Image = Transfer_History_Image();
                    DataTable tbl_stmp_duty_state_to_expire = Stamp_Duty_State_Change_To_Expire();
                    SqlParameter[] parmtr =
                    {
                      new SqlParameter("@Task","Update"),
                      new SqlParameter("@TFRAppoID",TFRAppointmentID),
                      new SqlParameter(){ ParameterName = "@tbl_ChallanRecieve",SqlDbType = SqlDbType.Structured, SqlValue = ChallanRece},
                      new SqlParameter(){ ParameterName = "@tbl_FileMap",SqlDbType = SqlDbType.Structured, SqlValue = File},
                      new SqlParameter(){ ParameterName = "@tbl_OwnerCurrenToTransferee",SqlDbType = SqlDbType.Structured, SqlValue = OwnerCurrentToTransferee},
                      new SqlParameter(){ ParameterName = "@tbl_OwnerPendingToCurrent",SqlDbType = SqlDbType.Structured, SqlValue = OwnerPendingToCurrent},
                      new SqlParameter(){ ParameterName = "@tbl_TransferTracking",SqlDbType = SqlDbType.Structured, SqlValue = tbl_TFRTracking},
                      new SqlParameter() { ParameterName = "@tbl_TransferHistoryImage",SqlDbType = SqlDbType.Structured,SqlValue = tbl_Transfer_History_Image },  //()
                      new SqlParameter() { ParameterName = "@tbl_stm_duty_state_update",SqlDbType = SqlDbType.Structured,SqlValue =  tbl_stmp_duty_state_to_expire}
                    };
                    int result = 0;
                    result = cls_dl_TFRVerification.TFRVerification_NonQuery(parmtr);
                    if (result > 0)
                    {
                        MessageBox.Show("Verification Successfully Completed.");
                        Helper.clsMostUseVars.Drctr_Secret_Code = false;
                        LoadDataForBasket();
                        Clear();
                    }
                }
                catch (Exception ex)
                {
                    frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnVerification_Click.", ex, "frmTransferVerification");
                    frmobj.ShowDialog();

                }
                #region Update The Data
      
            }
            else
            {
                MessageBox.Show("First Enter Your Secret Code.");
            }
            #endregion

        }

        private void txtNDCNo_Leave(object sender, EventArgs e)
        {
            try
            {
                #region Check that NDC is already verified or not 
                SqlParameter[] parameter =
               {
                new SqlParameter("@Task","CheckNDCNo_For_Verification"),
                new SqlParameter("@NDCNO",txtNDCNo.Text)
            };
                DataSet ds_tt = cls_dl_TFRVerification.TFRVerification_Reader(parameter);
                if (ds_tt.Tables[0].Rows[0]["StatusofNDC"].ToString() != "Verified")
                {
                    #region  OnLeave Action
                    SqlParameter[] parameters =
                   {
                new SqlParameter("@Task","TFRVerification"),
                new SqlParameter("@NDCNO",txtNDCNo.Text)
            };
                    DataSet dataSet = new DataSet();
                    dataSet = cls_dl_TFRVerification.TFRVerification_Reader(parameters);

                    #region TFR Appointment
                    if (dataSet.Tables[0].Rows.Count != 0)
                    {
                        TFRAppointmentID = int.Parse(dataSet.Tables[0].Rows[0]["TFRAppoimtmentID"].ToString());
                        lblTFRAppointment.Text = dataSet.Tables[0].Rows[0]["TFRAppoimtmentID"].ToString();
                        lblTFRAppIssuDate.Text = DateTime.Parse(dataSet.Tables[0].Rows[0]["IssueDate"].ToString()).ToString("dd/MM/yyyy");
                        lblTFRAppExpDate.Text = DateTime.Parse(dataSet.Tables[0].Rows[0]["ExpireDate"].ToString()).ToString("dd/MM/yyyy");
                    }
                    #endregion

                    #region Transfer Fee
                    if (dataSet.Tables[1].Rows.Count != 0)
                    {
                        lblchallanno.Text = dataSet.Tables[1].Rows[0]["ChallanNo"].ToString();
                        lblchallIan_ReceDate.Text = DateTime.Parse(dataSet.Tables[1].Rows[0]["DateofRece"].ToString()).ToString("dd/MM/yyyy");
                        string DateofExpire = dataSet.Tables[1].Rows[0]["DateofExpire"].ToString();
                        lblchallIan_ReceExpDate.Text = DateofExpire != "" ? DateTime.Parse(DateofExpire).ToString("dd/MM/yyyy") : "";
                    }
                    #endregion

                    #region NDC
                    if (dataSet.Tables[2].Rows.Count != 0)
                    {
                        lblNDCNo.Text = dataSet.Tables[2].Rows[0]["NDCNo"].ToString();
                        lblNDCIssueDate.Text = DateTime.Parse(dataSet.Tables[2].Rows[0]["DateIssue"].ToString()).ToString("dd/MM/yyyy");
                        string DateofExpire = dataSet.Tables[2].Rows[0]["NDCExpireDate"].ToString();
                        lblNDCExpDate.Text = DateofExpire != "" ? DateTime.Parse(DateofExpire).ToString("dd/MM/yyyy") : "";
                    }
                    #endregion

                    #region Type of Purchase
                    if (dataSet.Tables[3].Rows.Count != 0)
                    {
                        TypeOfPurchaseID = int.Parse(dataSet.Tables[3].Rows[0]["TypePurchaseID"].ToString());
                        lblTypeOfTransfer.Text = dataSet.Tables[3].Rows[0]["TypeofPurchase"].ToString();
                    }
                    #endregion

                    #region Current Owner
                    if (dataSet.Tables[4].Rows.Count != 0)
                    {
                        grdSellerInfo.DataSource = dataSet.Tables[4].DefaultView;
                    }
                    #endregion

                    #region New Owner
                    if (dataSet.Tables[5].Rows.Count != 0)
                    {
                        grdBuyerInfo.DataSource = dataSet.Tables[5].DefaultView;
                    }
                    #endregion

                    #region Image
                    if (dataSet.Tables[6].Rows.Count != 0)
                    {
                        imgTFRImage.Image = ImageRetrive(dataSet.Tables[6], "Image");
                    }
                    #endregion
                    #region File Information
                    if (dataSet.Tables[7].Rows.Count != 0)
                    {
                        FileMapKey = int.Parse(dataSet.Tables[7].Rows[0]["FileMapKey"].ToString());
                    }
                    #endregion
                    #endregion
                }
                else
                {
                    MessageBox.Show("This NDC is already Verified.");
                }

                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on txtNDCNo_Leave.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
            
          
        }

        private void grdGoToBack_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdGoToBack.CurrentCell.RowIndex;
                int ndcno = int.Parse(grdGoToBack.Rows[rowindex].Cells[0].Value.ToString());
                string fileNo = grdGoToBack.Rows[rowindex].Cells[1].Value.ToString();
                int TransferNo = int.Parse(grdGoToBack.Rows[rowindex].Cells[2].Value.ToString());

                if (e.Column.Name == "GoToReport")
                {
                    #region Update TransferTracking Status to "ReadyForReport"
                    SqlParameter[] prmt_r =
                    {
                        new SqlParameter("@Task","Update_TransferTracking_Status"),
                        new SqlParameter("@TFR_Status","ReadyForReport"),
                        new SqlParameter("@TransferNo",TransferNo)
                    };
                    int rslt = cls_dl_TransferTracking.TransferTracking_NonQuery(prmt_r);
                    #endregion
                }
                else if (e.Column.Name == "BackToPicture")
                {
                    #region Update the Previous Image of Group Photo of Transfer Sellers and Buyers
                    //SqlParameter[] _prmtr =
                    //{
                    //    new SqlParameter("@Task",""),
                    //    new SqlParameter("@TFR_Status","ReadyForPicture"),
                    //    new SqlParameter("@TransferNo",TransferNo)
                    //};
                    //int rslt_ = cls_dl_TransferTracking.TransferTracking_NonQuery(_prmtr);
                    #endregion
                    #region Update TransferTracking Status to "ReadyForPicture"
                    SqlParameter[] prmt_r =
                    {
                        new SqlParameter("@Task","Update_TransferTracking_Status"),
                        new SqlParameter("@TFR_Status","ReadyForPicture"),
                        new SqlParameter("@TransferNo",TransferNo)
                    };
                    int rslt = cls_dl_TransferTracking.TransferTracking_NonQuery(prmt_r);
                    #endregion
                }
                else if (e.Column.Name == "BackToTransfer")
                {
                    frmTransferTracking_Remarks frm = new frmTransferTracking_Remarks(ndcno, fileNo, TransferNo);
                    frm.ShowDialog();
                    LoadDataForBasket();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdGoToBack_CellClick.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }
          
           
        }

        private void btnEnabledGrid_Click(object sender, EventArgs e)
        {
            try
            {
                frm_Secret_Code obj = new frm_Secret_Code();
                obj.ShowDialog();
                if (Helper.clsMostUseVars.Drctr_Secret_Code == true)
                {
                    grdGoToBack.Enabled = true;
                }
                else
                {
                    MessageBox.Show("First Enter Your Secret Code.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnEnabledGrid_Click.", ex, "frmTransferVerification");
                frmobj.ShowDialog(); 
            }
           
        }

        private void Clear()
        {
            btnEnabledGrid.Enabled = false;
            btnVerification.Enabled = false;
            grdBuyerInfo.DataSource = null;
            grdSellerInfo.DataSource = null;
        }
    }
}
