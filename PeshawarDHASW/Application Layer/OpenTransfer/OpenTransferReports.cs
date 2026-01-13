using Bytescout.BarCode;
using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.NDC.Baskets;
using PeshawarDHASW.Application_Layer.Transfer.TransferReport;
using PeshawarDHASW.Data_Layer.clsTFR;
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
    public partial class OpenTransferReports : Telerik.WinControls.UI.RadForm
    {
        public OpenTransferReports()
        {
            InitializeComponent();
        }
        public static DataTable TransferCheckListData { get; set; }
        public OpenTransferReports(string NDCNo,string FileNo,string FileID, string PreTransferID)
        {
            InitializeComponent();
            lblFileID.Text = FileID;
            lblPerTFRNo.Text = PreTransferID;
            lblNDCNo.Text = NDCNo;
            lblFileNo.Text = FileNo;
        }

        private void OpenTransferReports_Load(object sender, EventArgs e)
        {

        }

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

        private void NDCGenerateReport(int NDCNo,string stringcheck)
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
                     new SqlParameter("@OpneTransferSellerNDC","sellerNDC"),
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


                    string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\NDC_Report.rpt";
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

        private void TSlipPrint()
        {
            int ndcno = int.Parse(lblNDCNo.Text);
            string fileno = lblFileNo.Text;
            string fileid = lblFileID.Text;
            string pertransferID = lblPerTFRNo.Text;

            SqlParameter[] prm =
            {
                    new SqlParameter("@Task","GetTSlipReport"),
                    new SqlParameter("@NDCNo",ndcno),
                    new SqlParameter("@PerTransferID",pertransferID),
                    new SqlParameter("@FileNo",fileno),
                    new SqlParameter("@FileID",fileid)
                };
            DataSet dst = new DataSet();
            dst = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpentransferReport", prm);
            try
            {
                #region TFR Slips Report
                ReportDocument rptdoc = new ReportDocument();
                TFRChecklistDataSet tfrchkds = new TFRChecklistDataSet();
                tfrchkds.Tables["tblTFRSlips"].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\TFRSlipsReport.rpt";
                if (!string.IsNullOrEmpty(path))
                {
                    rptdoc.Load(path);
                }
                rptdoc.SetDataSource(tfrchkds);
                OpenTransferReportViewer.ReportSource = rptdoc;
                OpenTransferReportViewer.Refresh();
               
                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //frm_Checklist_Report_Viewer frmq = new frm_Checklist_Report_Viewer(dst.Tables[0], "QuestionareReport");
            //frmq.ShowDialog();
            //frmTransferReport frmtfrrpt = new frmTransferReport(fileno, ndcno, purchasetypeID, tfrno);
            //frmtfrrpt.ShowDialog();
        }

       
        private void btnTSlipReport_Click(object sender, EventArgs e)
        {
            TSlipPrint();
        }
        private void TFRSlipReportOffice()
        {
            try
            {
                int ndcno = int.Parse(lblNDCNo.Text);
                string fileno = lblFileNo.Text;
                string fileid = lblFileID.Text;
                string pertransferID = lblPerTFRNo.Text;

                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","GetTSlipReport"),
                    new SqlParameter("@NDCNo",ndcno),
                    new SqlParameter("@PerTransferID",pertransferID),
                    new SqlParameter("@FileNo",fileno),
                    new SqlParameter("@FileID",fileid)
                };
                DataSet dtbl = new DataSet();
                dtbl = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpentransferReport", prm);
                #region TFR Slips Report office copy
                ReportDocument rptdoc1 = new ReportDocument();
                TFRChecklistDataSet tfrchkds_ = new TFRChecklistDataSet();
                tfrchkds_.Tables["tblTFRSlips"].Merge(dtbl.Tables[0], true, MissingSchemaAction.Ignore);
                string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\OpenTransfer\\Seller_TFRSlipsReport_OfficeCopy.rpt";
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
        private void btnTransferAllocationslip_Click(object sender, EventArgs e)
        {
            TFRSlipReportOffice();
        }


        private void TransferReport()
        {
            try
            {
                int ndcno = int.Parse(lblNDCNo.Text);
                string fileno = lblFileNo.Text;
                string fileid = lblFileID.Text;
                string pertransferID = lblPerTFRNo.Text;

                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","GetTransferData"),
                    new SqlParameter("@NDCNo",ndcno),
                    new SqlParameter("@PerTransferID",pertransferID),
                    new SqlParameter("@FileNo",fileno),
                    new SqlParameter("@FileID",fileid)
                };
                DataSet dtbl = new DataSet();
                dtbl = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpentransferReport", prm);
                TransferReportDS dstfr = new TransferReportDS();
                dstfr.EnforceConstraints = false;
                dstfr.Tables[0].Merge(dtbl.Tables[0], true, MissingSchemaAction.Ignore);
                ReportDocument rd = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\ReportFile\\TransferReport.rpt";
                rd.Load(path);
                rd.SetDataSource(dstfr.Tables[0]);
                OpenTransferReportViewer.ReportSource = rd;
                OpenTransferReportViewer.Refresh();
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
      

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            TransferReport();
        }
      
        private void UndertakingReport()
        {
            int ndcno = int.Parse(lblNDCNo.Text);
            string fileno = lblFileNo.Text;
            string fileid = lblFileID.Text;
            string pertransferID = lblPerTFRNo.Text;

            SqlParameter[] prm =
            {
                    new SqlParameter("@Task","GetTSlipReport"),
                    new SqlParameter("@NDCNo",ndcno),
                    new SqlParameter("@PerTransferID",pertransferID),
                    new SqlParameter("@FileNo",fileno),
                    new SqlParameter("@FileID",fileid)
                };
            DataSet dtbl = new DataSet();
            dtbl = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpentransferReport", prm);
            ReportDocument rptdoc1 = new ReportDocument();
            TFRChecklistDataSet tfrchkds_ = new TFRChecklistDataSet();
            tfrchkds_.Tables["tblTFRSlips"].Merge(dtbl.Tables[0], true, MissingSchemaAction.Ignore);
            string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\TFRSlipsReportQuestionare.rpt";
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
        private void TransferCheckList()
        {
            int ndcno = int.Parse(lblNDCNo.Text);
            string fileno = lblFileNo.Text;
            string fileid = lblFileID.Text;
            string pertransferID = lblPerTFRNo.Text;
            
            OpenTransferCheckList frmobj = new OpenTransferCheckList(ndcno,fileno,fileid,pertransferID,"");
            frmobj.ShowDialog();
            if (TransferCheckListData != null)
            {

         
            if (TransferCheckListData.Rows.Count>0)
            {
                #region Check List Report
                ReportDocument rptdoc = new ReportDocument();
                TFRChecklistDataSet tfrchkds = new TFRChecklistDataSet();
                tfrchkds.Tables["tblTFRChecklist"].Merge(TransferCheckListData, true, MissingSchemaAction.Ignore);
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\TFRChecklistReport.rpt";
                if (!string.IsNullOrEmpty(path))
                {
                    rptdoc.Load(path);
                }
                rptdoc.SetDataSource(tfrchkds);
                OpenTransferReportViewer.ReportSource = rptdoc;
                OpenTransferReportViewer.Refresh();

                #endregion
                //GetTransferCheckList
             }
            }
        }
        private void btnTransfercheckList_Click(object sender, EventArgs e)
        {
            TransferCheckList();
        }

        private void btnTransferImage_Click(object sender, EventArgs e)
        {
            int ndcno = int.Parse(lblNDCNo.Text);
            string fileno = lblFileNo.Text;
            string fileid = lblFileID.Text;
            string pertransferID = lblPerTFRNo.Text;
            OpenTransferTakePictures tfrimage = new OpenTransferTakePictures(fileno,ndcno,0,int.Parse(fileid),"","",0);
            tfrimage.ShowDialog();


            SqlParameter[] prm =
            {
                    new SqlParameter("@Task","TransferImageReport"),
                    new SqlParameter("@NDCNo",ndcno),
                    new SqlParameter("@PerTransferID",pertransferID),
                    new SqlParameter("@FileNo",fileno),
                    new SqlParameter("@FileID",fileid)
                };
            DataSet dst = new DataSet();
            dst = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.OpentransferReport", prm);

            TransferReportImageDS dstfr = new TransferReportImageDS();
            //ds.EnforceConstraints = false;
            dstfr.EnforceConstraints = false;
            dstfr.Tables[0].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
            //ds.EnforceConstraints = true;
            ReportDocument rd = new ReportDocument();
            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\ReportFile\\TransferReportImage_rpt.rpt";
            rd.Load(path);


            rd.SetDataSource(dstfr.Tables[0]);
            OpenTransferReportViewer.ReportSource = rd;
            OpenTransferReportViewer.Refresh();
           
        }
    }
}
