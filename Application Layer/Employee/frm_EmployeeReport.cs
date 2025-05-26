using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Report.Datasets.Employee_DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Employee
{
    public partial class frm_EmployeeBulkReport : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst { get; set; }
        public frm_EmployeeBulkReport()
        {
            InitializeComponent();
        }
        public frm_EmployeeBulkReport(DataSet ds)
        {
            InitializeComponent();
            dst = ds;
        }

        private void frm_EmployeeBulkReport_Load(object sender, EventArgs e)
        {
            ReportDocument rptdoc = new ReportDocument();

            EmployeeDataset EMP_ds = new EmployeeDataset();
            EMP_ds.Tables[0].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
            
            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\EmployeeBulkReport.rpt";
            if (!string.IsNullOrEmpty(path))
            {
                rptdoc.Load(path);
            }

            EMP_ds.EnforceConstraints = true;
            rptdoc.SetDataSource(EMP_ds);
            emp_bulk_report.ReportSource = rptdoc;
            emp_bulk_report.Refresh();
        }
    }
}
