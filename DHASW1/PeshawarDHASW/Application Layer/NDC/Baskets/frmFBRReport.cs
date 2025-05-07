using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Report.Datasets.FBR_DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmFBRReport : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst { get; set; }
        public frmFBRReport()
        {
            InitializeComponent();
        }
        public frmFBRReport(DataSet ds)
        {
            InitializeComponent();
            dst = ds;
        }

        private void frmFBRReport_Load(object sender, EventArgs e)
        {
            #region Check List Report
            ReportDocument rptdoc = new ReportDocument();

            FBR_DataSet_dst FBR_ds = new FBR_DataSet_dst();
            FBR_ds.Tables[0].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
            FBR_ds.Tables[1].Merge(dst.Tables[1], true, MissingSchemaAction.Ignore);
            FBR_ds.Tables[2].Merge(dst.Tables[2], true, MissingSchemaAction.Ignore);
            FBR_ds.Tables[3].Merge(dst.Tables[3], true, MissingSchemaAction.Ignore);
            FBR_ds.Tables[4].Merge(dst.Tables[4], true, MissingSchemaAction.Ignore);


            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\FBRDetail_Report.rpt";
            if (!string.IsNullOrEmpty(path))
            {
                rptdoc.Load(path);
            }

            FBR_ds.EnforceConstraints = true;
            rptdoc.SetDataSource(FBR_ds);
            rptViewerFBRData.ReportSource = rptdoc;
            rptViewerFBRData.Refresh();
            #endregion
        }
    }
}
