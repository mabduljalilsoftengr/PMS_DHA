using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Report.Stamp_Duty;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.StampDuty
{
    public partial class frmStampDutyBulkReport : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst1 { get; set; }
        public frmStampDutyBulkReport()
        {
            InitializeComponent();
        }

        public frmStampDutyBulkReport(DataSet dst)
        {
            InitializeComponent();
            dst1 = dst;
        }

        private void frmStampDutyBulkReport_Load(object sender, EventArgs e)
        {
            ReportDocument rptdoc = new ReportDocument();
            Stamp_Duty_DataSet STM_ds = new Stamp_Duty_DataSet();
            STM_ds.Tables[1].Merge(dst1.Tables[0], true, MissingSchemaAction.Ignore);
            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\Stamp_Duty\\Stamp_Duty_Bulk_Report.rpt";
            if (!string.IsNullOrEmpty(path))
            {
                rptdoc.Load(path);
            }

            rptdoc.SetDataSource(STM_ds);
            crvStampDuty.ReportSource = rptdoc;
            crvStampDuty.Refresh();
        }
    }
}
