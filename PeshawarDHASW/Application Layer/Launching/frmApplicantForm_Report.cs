using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Report.Datasets.ApplicantDataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class frmApplicantForm_Report : Telerik.WinControls.UI.RadForm
    {
        public frmApplicantForm_Report()
        {
            InitializeComponent();
        }
        private DataSet dst_app { get; set; }
        public frmApplicantForm_Report(DataSet AppData)
        {
            InitializeComponent();
            dst_app = AppData;
        }

        private void frmApplicantForm_Report_Load(object sender, EventArgs e)
        {
            ReportDocument rptdoc = new ReportDocument();
            ApplicantDataSet dstapp = new ApplicantDataSet();
            dstapp.Tables[0].Merge(dst_app.Tables[0], true, MissingSchemaAction.Ignore);


            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\ApplicantReport.rpt";
            if (!string.IsNullOrEmpty(path))
            {
                rptdoc.Load(path);
            }

            //NDC_ds.EnforceConstraints = true;
            rptdoc.SetDataSource(dstapp);
            crptApplicantRptViewer.ReportSource = rptdoc;
            crptApplicantRptViewer.Refresh();
        }
    }
}
