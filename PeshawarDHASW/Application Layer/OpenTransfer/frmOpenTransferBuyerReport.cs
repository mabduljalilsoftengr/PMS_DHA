using Bytescout.BarCode;
using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Report.Datasets.NDC_DataSet;
using PeshawarDHASW.Report.Datasets.Sample;
using PeshawarDHASW.Report.Datasets.TFR_Dataset;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    public partial class frmOpenTransferBuyerReport : Telerik.WinControls.UI.RadForm
    {
        public frmOpenTransferBuyerReport()
        {
            InitializeComponent();
        }

        public static DataTable TransferCheckListData { get; set; }
        public frmOpenTransferBuyerReport(string NDCNo, string FileNo, string FileID, string PreTransferID)
        {
            InitializeComponent();
            lblFileID.Text = FileID;
            lblPerTFRNo.Text = PreTransferID;
            lblNDCNo.Text = NDCNo;
            lblFileNo.Text = FileNo;
        }
        #region NDC Report Print
        private void btnNDCReport_Click(object sender, EventArgs e)
        {
            try
            {
                int NDCNo_ = int.Parse(lblNDCNo.Text);
                NDCGenerateReport(NDCNo_, "NDCReport");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void NDCGenerateReport(int NDCNo, string stringcheck)
        {
            // NDCNo = 13;
            try
            {
                if (stringcheck == "NDCReport")
                {
                    #region NDC Report
                    ReportDocument rptdoc = new ReportDocument();
                    SqlParameter[] parameter =
                    {
                    new SqlParameter("@Task","NDCReport"),
                    new SqlParameter("@NDCNo",NDCNo),
                    new SqlParameter("@string","")
                    };
                    DataSet ds = cls_dl_NDC.NdcRetrival(parameter);
                    NDC_DataSet NDC_ds = new NDC_DataSet();

                    DataTable dt = new DataTable();
                    dt.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);

                    ds.Tables[0].Columns.Add(new DataColumn("BarcodeImage", typeof(byte[])));
                    ds.Tables[0].Columns.Add(new DataColumn("QRcodeImage", typeof(byte[])));
                    #region Bar Code
                    //////////////  Bar code start //////////////////
                    // create barcode object
                    Barcode bc = new Barcode(SymbologyType.Code128);
                    bc.DrawCaption = false;
                    //bc.NarrowBarWidth = 1;
                    //bc.WideToNarrowRatio = 2;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        // set barcode object's Value property to a value of a field
                        // you want to be used for barcode creation
                        // we use 5 first symbols of product name
                        string str = dr["FilePlotNo"] + "," + dr["NDCNo"];
                        bc.Value = str; //(dr["Name"] as string).Substring(0, 5);

                        // retrieve generated image bytes
                        byte[] barcodeBytes = bc.GetImageBytesWMF();

                        // fill virtual field with generated image bytes
                        dr["BarcodeImage"] = barcodeBytes;
                    }
                    ////////////// Bar code End //////////////////
                    #endregion
                    #region QR Code
                    //////////////  Bar code start //////////////////
                    // create barcode object
                    Barcode qrc = new Barcode(SymbologyType.QRCode);
                    qrc.DrawCaption = false;
                    //bc.NarrowBarWidth = 1;
                    //bc.WideToNarrowRatio = 2;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        // set barcode object's Value property to a value of a field
                        // you want to be used for barcode creation
                        // we use 5 first symbols of product name
                        string str = dr["FilePlotNo"] + "," + dr["NDCNo"];
                        qrc.Value = str; //(dr["Name"] as string).Substring(0, 5);

                        // retrieve generated image bytes
                        byte[] qrcodeBytes = qrc.GetImageBytesWMF();

                        // fill virtual field with generated image bytes
                        dr["QRcodeImage"] = qrcodeBytes;
                    }
                    ////////////// Bar code End //////////////////
                    #endregion

                    //NDC_ds.EnforceConstraints = false;
                    NDC_ds.Tables[0].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);


                    string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\OpenTransfer\\Buyer_NDC_Report.rpt";
                    if (!string.IsNullOrEmpty(path))
                    {
                        rptdoc.Load(path);
                    }

                    //NDC_ds.EnforceConstraints = true;
                    rptdoc.SetDataSource(NDC_ds);
                    OpenTransferReportViewer.ReportSource = rptdoc;
                    OpenTransferReportViewer.Refresh();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on GenerateReport.", ex, "frmNDC_Report");
                frmobj.ShowDialog();
            }
        }

        #endregion

        #region TSlip Report
        private void btnTSlipReport_Click(object sender, EventArgs e)
        {
            try
            {
               
                int ndcno = int.Parse(lblNDCNo.Text);
                int tfrno = 0;
                string fileno = lblFileNo.Text;
                int purchasetypeID = 0;
                 SqlParameter[] prm =
                 {
                    new SqlParameter("@Task","GetNDCSellerBuyerTFR"),
                    new SqlParameter("@NDCNo",ndcno)
                 };
                 
                 DataSet dst = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure
                     , "App.OpenTransferBuyerReport", prm);
                 #region TFR Slips Report
                 ReportDocument rptdoc1 = new ReportDocument();
                 TFRChecklistDataSet tfrchkds_ = new TFRChecklistDataSet();
                 tfrchkds_.Tables["tblTFRSlips"].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
                 string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\OpenTransfer\\Buyer_TFRSlipsReport.rpt";
                 if (!string.IsNullOrEmpty(path1))
                 {
                     rptdoc1.Load(path1);
                 }
                 rptdoc1.SetDataSource(tfrchkds_);
                 OpenTransferReportViewer.ReportSource = rptdoc1;
                 OpenTransferReportViewer.Refresh();

                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Undertaking Report
        private void UndertakingReport()
        {
            int ndcno = int.Parse(lblNDCNo.Text);
            string fileno = lblFileNo.Text;
            string fileid = lblFileID.Text;
            string pertransferID = lblPerTFRNo.Text;

            SqlParameter[] prm =
            {
               new SqlParameter("@Task","GetNDCSellerBuyerTFR"),
               new SqlParameter("@NDCNo",ndcno)
            };
            DataSet dtbl = new DataSet();
            dtbl = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenTransferBuyerReport", prm);
            ReportDocument rptdoc1 = new ReportDocument();
            TFRChecklistDataSet tfrchkds_ = new TFRChecklistDataSet();
            tfrchkds_.Tables["tblTFRSlips"].Merge(dtbl.Tables[0], true, MissingSchemaAction.Ignore);
            string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\OpenTransfer\\Buyer_TFRSlipsReportQuestionare.rpt";
            if (!string.IsNullOrEmpty(path1))
            {
                rptdoc1.Load(path1);
            }
            rptdoc1.SetDataSource(tfrchkds_);
            OpenTransferReportViewer.ReportSource = rptdoc1;
            OpenTransferReportViewer.Refresh();
        }

        private void btnUndertaking_Click(object sender, EventArgs e)
        {
            UndertakingReport();
        }

        #endregion

        #region Transfer Report
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                int ndcno = int.Parse(lblNDCNo.Text);
                int tfrno = 0;
                string fileno = lblFileNo.Text;
                int purchasetypeID = 0;
                SqlParameter[] parameter = {
                        new SqlParameter("@Task","TransferSlipRelated"),
                        new SqlParameter("@NDCNo",ndcno)
                };
                DataSet TransferSlipRelatedDs = new DataSet();
                TransferSlipRelatedDs = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenTransferBuyerReport", parameter);
                if (TransferSlipRelatedDs.Tables.Count > 0)
                {
                    if (TransferSlipRelatedDs.Tables[0].Rows.Count > 0)
                    {
                        int.TryParse(TransferSlipRelatedDs.Tables[0].Rows[0]["PurchaseTypeID"].ToString(), out purchasetypeID);
                        int.TryParse(TransferSlipRelatedDs.Tables[0].Rows[0]["TransferNo"].ToString(), out tfrno);
                        fileno = TransferSlipRelatedDs.Tables[0].Rows[0]["FilePlotNo"].ToString();
                    }
                }

                SqlParameter[] parameter_report =
             {
                    new SqlParameter("@Task","Select_Report_Data"),
                    new SqlParameter("@FileNo",fileno),
                    new SqlParameter("@PurchaseTypeID",purchasetypeID),
                    new SqlParameter("@NDCNo",ndcno)
                };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenTransferBuyerReport", parameter_report);
                TransferReportDS dstfr = new TransferReportDS();
                //ds.EnforceConstraints = false;
                dstfr.EnforceConstraints = false;
                dstfr.Tables[0].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                //ds.EnforceConstraints = true;
                ReportDocument rd = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\OpenTransfer\\Buyer_TransferReport.rpt";
                rd.Load(path);
                //rd.SetDataSource((DataTable)dstfr.VW_TFR_Report);
                //ds.EnforceConstraints = true;
                //dstfr.EnforceConstraints = true;

                rd.SetDataSource(dstfr.Tables[0]);
                OpenTransferReportViewer.ReportSource = rd;
                OpenTransferReportViewer.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion

        #region Transfer Image
        private void btnTransferImage_Click(object sender, EventArgs e)
        {
            int ndcno = int.Parse(lblNDCNo.Text);
            int tfrno = 0;
            string fileno = lblFileNo.Text;
            int purchasetypeID = 0;
            SqlParameter[] parameter = {
                        new SqlParameter("@Task","TransferSlipRelated"),
                        new SqlParameter("@NDCNo",ndcno)
                };
            DataSet TransferSlipRelatedDs = new DataSet();
            TransferSlipRelatedDs = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenTransferBuyerReport", parameter);
            if (TransferSlipRelatedDs.Tables.Count > 0)
            {
                if (TransferSlipRelatedDs.Tables[0].Rows.Count > 0)
                {
                    int.TryParse(TransferSlipRelatedDs.Tables[0].Rows[0]["PurchaseTypeID"].ToString(), out purchasetypeID);
                    int.TryParse(TransferSlipRelatedDs.Tables[0].Rows[0]["TransferNo"].ToString(), out tfrno);
                    fileno = TransferSlipRelatedDs.Tables[0].Rows[0]["FilePlotNo"].ToString();
                }
            }
            SqlParameter[] parameter_report =
            {
                new SqlParameter("@Task", "Get_TFRReportImages"),
                new SqlParameter("@TransferNo", tfrno),
                new SqlParameter("@FileNo", fileno),
                new SqlParameter("@NDCNo", ndcno)
            };
            DataSet dst = new DataSet();
            dst = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenTransferBuyerReport", parameter_report);
            TransferReportImageDS dstfr = new TransferReportImageDS();
            //ds.EnforceConstraints = false;
            dstfr.EnforceConstraints = false;
            dstfr.Tables[0].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
            //ds.EnforceConstraints = true;
            ReportDocument rd = new ReportDocument();
            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\ReportFile\\TransferReportImage_rpt.rpt";
            rd.Load(path);
            //rd.SetDataSource((DataTable)dstfr.VW_TFR_Report);
            //ds.EnforceConstraints = true;
            //dstfr.EnforceConstraints = true;

            rd.SetDataSource(dstfr.Tables[0]);
            OpenTransferReportViewer.ReportSource = rd;
            OpenTransferReportViewer.Refresh();
        }
        #endregion


        private DataTable CheckListLoad()
        {
            DataSet dst1 = new DataSet();
            DataTable dt_chk = new DataTable();
            try
            {
                int ndcno = int.Parse(lblNDCNo.Text);
                
              
                SqlParameter[] prm =
                   {
                    new SqlParameter("@Task","Get_Info_For_Transfer"),
                    new SqlParameter("@NDCNo",ndcno)
                    };
                dst1 = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure
                            , "App.OpenTransferBuyerReport", prm);
                dt_chk = dst1.Tables[2];
                string BuyerName = dst1.Tables[1].Rows[0]["Name"].ToString();
                string DateOfTransfer =DateTime.Now.ToLongDateString();
                string FileNo = dst1.Tables[0].Rows[0]["FileNo"].ToString();
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
                                row["BuyerName"] = BuyerName;  
                                row["DateOfTransfer"] = DateOfTransfer;
                                row["FileNo"] = FileNo;
                                row["DateOfAllocation"] = "With in One Month.";
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
                                row["BuyerName"] = BuyerName;   // or set it to some other value
                                row["DateOfTransfer"] = DateOfTransfer;
                                row["FileNo"] = FileNo;
                                row["DateOfAllocation"] = "With in One Month."; 
                                row["UserName"] = Models.clsUser.Name;
                            }
                        }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return dt_chk;
        }

        #region Transfer CheckList Report
        private void btnTransfercheckList_Click(object sender, EventArgs e)
        {
            try
            {
                int ndcno = int.Parse(lblNDCNo.Text);
                int tfrno = 0;
                string fileno = lblFileNo.Text;


                DataTable CheckListDs = CheckListLoad();
                ReportDocument rptdoc = new ReportDocument();
                TFRChecklistDataSet tfrchkds = new TFRChecklistDataSet();
                tfrchkds.Tables["tblTFRChecklist"].Merge(CheckListDs, true, MissingSchemaAction.Ignore);
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\OpenTransfer\\Buyer_TFRChecklistReport.rpt";
                if (!string.IsNullOrEmpty(path))
                {
                    rptdoc.Load(path);
                }
                rptdoc.SetDataSource(tfrchkds);
                OpenTransferReportViewer.ReportSource = rptdoc;
                OpenTransferReportViewer.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }

        #endregion
    
        private void btnTransferAllocationslip_Click(object sender, EventArgs e)
        {
            try
            {

                int ndcno = int.Parse(lblNDCNo.Text);
                int tfrno = 0;
                string fileno = lblFileNo.Text;
                int purchasetypeID = 0;

                        SqlParameter[] prm =
                        {
                           new SqlParameter("@Task","GetNDCSellerBuyerTFR"),
                           new SqlParameter("@NDCNo",ndcno)
                        };
                        DataSet dst = new DataSet();
                        dst = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpenTransferBuyerReport", prm);
                        #region TFR Slips Report
                        ReportDocument rptdoc1 = new ReportDocument();
                        TFRChecklistDataSet tfrchkds_ = new TFRChecklistDataSet();
                        tfrchkds_.Tables["tblTFRSlips"].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
                        string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\OpenTransfer\\Buyer_TFRSlipsReport_OfficeCopy.rpt";
                        if (!string.IsNullOrEmpty(path1))
                        {
                            rptdoc1.Load(path1);
                        }
                        rptdoc1.SetDataSource(tfrchkds_);
                        OpenTransferReportViewer.ReportSource = rptdoc1;
                        OpenTransferReportViewer.Refresh();
                   

                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
