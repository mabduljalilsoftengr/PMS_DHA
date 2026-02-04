using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Report.Datasets.Sample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Report.Simple_Layer
{
    public partial class frmTransferReport : Telerik.WinControls.UI.RadForm
    {
        public string FileNo { get; set; }
        public int NDC_No_ { get; set; }
        public int PurchaseTypeID { get; set; }
        public int TransferNo { get; set; }
        public int TFRAppointmentID { get; set; }
        public int FileMapKey { get; set; }
        public int TypeOfPurchaseID { get; set; }
        public string ChallanNo { get; set; }
        private DataSet dataSet { get; set; }
        public frmTransferReport()
        {
            InitializeComponent();
        }
        public frmTransferReport(string get_FileNo, int get_NDCNo, int get_PurchaseID, int get_TransferNo)
        {
            InitializeComponent();
            FileNo = get_FileNo;
            NDC_No_ = get_NDCNo;
            PurchaseTypeID = get_PurchaseID;
            TransferNo = get_TransferNo;
        }
        private void frmTransferReport_Load(object sender, EventArgs e)
        {
            try
            {
                //crystalReportViewer1.ShowPrintButton = false;
                //crystalReportViewer1.ShowExportButton = false;
                LoadReportData();
                //Verification(NDC_No_.ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + ex.InnerException.ToString());
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
                    #region  Total Data Retreiving
                    SqlParameter[] parameters =
                   {
                    new SqlParameter("@Task","TFRVerification"),
                    new SqlParameter("@NDCNO",NDC_no)
                   };
                    dataSet = cls_dl_TFRVerification.TFRVerification_Reader(parameters);

                    #region TFR Appointment
                    if (dataSet.Tables[0].Rows.Count != 0)
                    {
                        TFRAppointmentID = int.Parse(dataSet.Tables[0].Rows[0]["TFRAppoimtmentID"].ToString());
                        //lblTFRAppointment.Text = dataSet.Tables[0].Rows[0]["TFRAppoimtmentID"].ToString();
                        //lblTFRAppIssuDate.Text = DateTime.Parse(dataSet.Tables[0].Rows[0]["IssueDate"].ToString()).ToString("dd/MM/yyyy");
                        //lblTFRAppExpDate.Text = DateTime.Parse(dataSet.Tables[0].Rows[0]["ExpireDate"].ToString()).ToString("dd/MM/yyyy");
                    }
                    #endregion

                    #region Transfer Fee
                    if (dataSet.Tables[1].Rows.Count != 0)
                    {
                        ChallanNo = dataSet.Tables[1].Rows[0]["ChallanNo"].ToString();
                        //lblchallIan_ReceDate.Text = DateTime.Parse(dataSet.Tables[1].Rows[0]["DateofRece"].ToString()).ToString("dd/MM/yyyy");
                        string DateofExpire = dataSet.Tables[1].Rows[0]["DateofExpire"].ToString();
                        //lblchallIan_ReceExpDate.Text = DateofExpire != "" ? DateTime.Parse(DateofExpire).ToString("dd/MM/yyyy") : "";
                    }
                    #endregion

                    #region NDC
                    if (dataSet.Tables[2].Rows.Count != 0)
                    {
                        //lblNDCNo.Text = dataSet.Tables[2].Rows[0]["NDCNo"].ToString();
                        //lblNDCIssueDate.Text = DateTime.Parse(dataSet.Tables[2].Rows[0]["DateIssue"].ToString()).ToString("dd/MM/yyyy");
                        string DateofExpire = dataSet.Tables[2].Rows[0]["NDCExpireDate"].ToString();
                        //lblNDCExpDate.Text = DateofExpire;
                        //DateofExpire != "" ? DateTime.Parse(DateofExpire).ToString("dd/MM/yyyy") : "";
                    }
                    #endregion

                    #region Type of Purchase
                    if (dataSet.Tables[3].Rows.Count != 0)
                    {
                        TypeOfPurchaseID = int.Parse(dataSet.Tables[3].Rows[0]["TypePurchaseID"].ToString());
                        //lblTypeOfTransfer.Text = dataSet.Tables[3].Rows[0]["TypeofPurchase"].ToString();
                    }
                    #endregion

                    #region Current Owner
                    if (dataSet.Tables[4].Rows.Count != 0)
                    {
                        //grdSellerInfo.DataSource = dataSet.Tables[4].DefaultView;
                    }
                    #endregion

                    #region New Owner
                    if (dataSet.Tables[5].Rows.Count != 0)
                    {
                        //grdBuyerInfo.DataSource = dataSet.Tables[5].DefaultView;
                    }
                    #endregion

                    #region Image
                    if (dataSet.Tables[6].Rows.Count != 0)
                    {
                        //imgTFRImage.Image = ImageRetrive(dataSet.Tables[6], "Image");
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
        private void LoadReportData()
        {
            try
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","Select_Report_Data"),
                    new SqlParameter("@FileNo",FileNo),
                    new SqlParameter("@PurchaseTypeID",PurchaseTypeID),
                    new SqlParameter("@NDCNo",NDC_No_)
                };
                DataSet ds = cls_dl_TFRHistory.TFRReport_Reader(prm);
                TransferReportDS dstfr = new TransferReportDS();
                //ds.EnforceConstraints = false;
                dstfr.EnforceConstraints = false;
                dstfr.Tables[0].Merge(ds.Tables[0],true, MissingSchemaAction.Ignore);
                //ds.EnforceConstraints = true;
                ReportDocument rd = new ReportDocument();
                string path = Application.StartupPath + "\\Report\\ReportFile\\TransferReport.rpt";
                rd.Load(path);
                //rd.SetDataSource((DataTable)dstfr.VW_TFR_Report);
                //ds.EnforceConstraints = true;
                //dstfr.EnforceConstraints = true;
                
                rd.SetDataSource(dstfr.Tables[0]);
                crystalReportViewer1.ReportSource = rd;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Print_Click(object sender, EventArgs e)
        {

        }
        private bool Updation_Of_All_NDC_RelatedData()
        {
            bool blvr = false;
            //DataTable ChallanRece = ChallanRecieve();
            DataTable File = FileMap();
            //DataTable OwnerCurrentToTransferee = Owner_Current_To_Transferee();
            //DataTable OwnerPendingToCurrent = Owner_Pending_To_Current();
            DataTable tbl_TFRTracking = Transfer_Tracking();
            DataTable tbl_Transfer_History_Image = Transfer_History_Image();
            //DataTable tbl_stmp_duty_state_to_expire = Stamp_Duty_State_Change_To_Expire();
            SqlParameter[] parmtr =
            {
                      new SqlParameter("@Task","Update"),
                      new SqlParameter("@TFRAppoID",TFRAppointmentID),
                      //new SqlParameter(){ ParameterName = "@tbl_ChallanRecieve",SqlDbType = SqlDbType.Structured, SqlValue = ChallanRece},
                      new SqlParameter(){ ParameterName = "@tbl_FileMap",SqlDbType = SqlDbType.Structured, SqlValue = File},
                      //new SqlParameter(){ ParameterName = "@tbl_OwnerCurrenToTransferee",SqlDbType = SqlDbType.Structured, SqlValue = OwnerCurrentToTransferee},
                      //new SqlParameter(){ ParameterName = "@tbl_OwnerPendingToCurrent",SqlDbType = SqlDbType.Structured, SqlValue = OwnerPendingToCurrent},
                      new SqlParameter(){ ParameterName = "@tbl_TransferTracking",SqlDbType = SqlDbType.Structured, SqlValue = tbl_TFRTracking},
                      new SqlParameter() { ParameterName = "@tbl_TransferHistoryImage",SqlDbType = SqlDbType.Structured,SqlValue = tbl_Transfer_History_Image },  //()
                      //new SqlParameter() { ParameterName = "@tbl_stm_duty_state_update",SqlDbType = SqlDbType.Structured,SqlValue =  tbl_stmp_duty_state_to_expire}
            };
            int result = 0;
            result = cls_dl_TFRVerification.TFRVerification_NonQuery(parmtr);
            if (result > 0)
            {
                MessageBox.Show("Transfer Completed Successfully.");
                Helper.clsMostUseVars.Drctr_Secret_Code = false;
                this.Close();
                //LoadReportData();
                //Clear();
                blvr = true;
            }
            else
            {
                blvr = false;
            }
            return blvr;
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
                row["ChallanNO"] = ChallanNo;
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
                row["TFRTypeID"] = PurchaseTypeID;
                row["NDCNo"] = NDC_No_;
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
                int CurrentOwnersCount = dataSet.Tables[4].Rows.Count;
                for (int i = 0; i < CurrentOwnersCount; i++)
                {
                    DataRow row = tbl_Owner_.NewRow();
                    int OwnerID = int.Parse(dataSet.Tables[4].Rows[i]["OwnerID"].ToString());
                    row["Owner_ID"] = OwnerID;
                    row["Owner_Status_old"] = "Current";
                    row["Owner_Status_new"] = "Transferee";
                    row["NDCNo"] = NDC_No_;
                    tbl_Owner_.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Owner_Current_To_Transferee.", ex, "frmTransferVerification");
                frmobj.ShowDialog();
            }

            return tbl_Owner_;
        }
        //private DataTable Owner_Pending_To_Current()
        //{
        //    DataTable _tbl_Owner_ = new DataTable();
        //    try
        //    {
        //        DataTable_column Owner_ID = new DataTable_column() { ColmnName = "Owner_ID", type = typeof(int) };
        //        DataTable_column Owner_Status_old = new DataTable_column() { ColmnName = "Owner_Status_old", type = typeof(string) };
        //        DataTable_column Owner_Status_new = new DataTable_column() { ColmnName = "Owner_Status_new", type = typeof(string) };
        //        DataTable_column NDCNo = new DataTable_column() { ColmnName = "NDCNo", type = typeof(int) };
        //        List<DataTable_column> colmn = new List<DataTable_column>();
        //        colmn.Add(Owner_ID);
        //        colmn.Add(Owner_Status_old);
        //        colmn.Add(Owner_Status_new);
        //        colmn.Add(NDCNo);
        //        _tbl_Owner_ = clsPluginHelper.ColmnsCreateinDatatable(colmn);

        //        int PendingOwnersCount = grdBuyerInfo.Rows.Count;
        //        for (int i = 0; i < PendingOwnersCount; i++)
        //        {
        //            DataRow row = _tbl_Owner_.NewRow();
        //            int OwnerID = int.Parse(grdBuyerInfo.Rows[i].Cells[0].Value.ToString());
        //            row["Owner_ID"] = OwnerID;
        //            row["Owner_Status_old"] = "Pending";
        //            row["Owner_Status_new"] = "Current";
        //            row["NDCNo"] = NDCNo;
        //            _tbl_Owner_.Rows.Add(row);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on _tbl_Owner_.", ex, "frmTransferVerification");
        //        frmobj.ShowDialog();
        //    }
        //    return _tbl_Owner_;
        //}
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
                row["TFRNo"] = TransferNo;
                row["TFRTrackingStatus"] = "TFRLetterImageUplloadCompleted";
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
                row["TFRNo_col"] = TransferNo;
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

        private bool printing()
        {
            bool blvrl = false;
            try
            {
                //show Print Dialog
                PrintDialog printDialog = new PrintDialog();
                DialogResult dr = printDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ReportDocument crReportDocument = (ReportDocument)crystalReportViewer1.ReportSource;
                    System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
                    //Get the Copy times
                    int nCopy = printDocument1.PrinterSettings.Copies;
                    //Get the number of Start Page
                    int sPage = printDocument1.PrinterSettings.FromPage;
                    //Get the number of End Page
                    int ePage = printDocument1.PrinterSettings.ToPage;
                    crReportDocument.PrintOptions.PrinterName = printDocument1.PrinterSettings.PrinterName;
                    //Start the printing process.  Provide details of the print job
                    DialogResult rdr = MessageBox.Show("Are you Sure", "Printing the Transfer Report.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rdr == DialogResult.Yes)
                    {
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);
                        blvrl = true;
                    }
                    else
                    {
                        MessageBox.Show("There is no Data for Print.");
                        blvrl = false;
                    }
                    //Form_Printerd = true;
                }
            }
            catch (Exception ex)
            {
                blvrl = false;
                MessageBox.Show(ex.Message);
            }
            return blvrl;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //LoadReportData();
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            Updation_Of_All_NDC_RelatedData();
        }
    }
}
