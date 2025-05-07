using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Data_Layer.clsTFR;
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
    public partial class frmTransferReportImages : Telerik.WinControls.UI.RadForm
    {
        public frmTransferReportImages() 
        {
            InitializeComponent();
        }
        private string FileNo { get; set; }
        private int NDCNo { get; set; }
        private int PurchaseTypeID { get; set; }
        private int TransferNo { get; set; }
        public frmTransferReportImages(string get_fileNo,int get_ndcno, int get_purchasetypeID, int get_TransferNo) 
        {
            InitializeComponent();
            FileNo = get_fileNo;
            NDCNo = get_ndcno;
            PurchaseTypeID = get_purchasetypeID;
            TransferNo = get_TransferNo;
        }

        private void frmTransferReportImages_Load(object sender, EventArgs e)
        {
            DataSet dst = GetReportData();
            TransferReportImageDS dstfr = new TransferReportImageDS();
            //ds.EnforceConstraints = false;
            dstfr.EnforceConstraints = false;
            dstfr.Tables[0].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
            //ds.EnforceConstraints = true;
            ReportDocument rd = new ReportDocument();
            string path = Application.StartupPath + "\\Report\\ReportFile\\TransferReportImage_rpt.rpt";
            rd.Load(path);
            //rd.SetDataSource((DataTable)dstfr.VW_TFR_Report);
            //ds.EnforceConstraints = true;
            //dstfr.EnforceConstraints = true;

            rd.SetDataSource(dstfr.Tables[0]);
            crp_TFRImages.ReportSource = rd;
            crp_TFRImages.Refresh();
        }
        private DataSet GetReportData()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Get_TFRReportImages"),
                new SqlParameter("@TransferNo",TransferNo),
                new SqlParameter("@FileNo",FileNo),
                new SqlParameter("@NDCNo",NDCNo)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_TFRHistory.TFRReport_Reader(prm);
            return dst;
        }
    }
}
