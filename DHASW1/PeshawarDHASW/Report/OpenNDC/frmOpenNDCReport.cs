using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Report.OpenNDC
{
    public partial class frmOpenNDCReport : Telerik.WinControls.UI.RadForm
    {
        public frmOpenNDCReport()
        {
            InitializeComponent();
        }
        public int PerTransferID { get; set; }
        public frmOpenNDCReport(int PerTransferID_)
        {
            PerTransferID = PerTransferID_;
            InitializeComponent();
        }

        private void GenerateReport()
        {
            try
            {

                SqlParameter[] searchparam =
                {
                    new SqlParameter("@Task","GetDataforReport"),
                    new SqlParameter("@ID", PerTransferID)
                };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PreTransferRequest", searchparam);
                Report.OpenNDC.OpenNDCDs dstrpt = new OpenNDCDs();
                dstrpt.PreTransfer.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                ReportDocument rptdoc = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\OpenNDC\\DealReport.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(dstrpt);
                crystalReportViewer1.ReportSource = rptdoc;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message + ex.InnerException);
            }
        }

        private void frmOpenNDCReport_Load(object sender, EventArgs e)
        {
            GenerateReport();
        }
    }
}
