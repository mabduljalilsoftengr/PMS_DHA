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
    public partial class frm_Employee_Report : Telerik.WinControls.UI.RadForm
    {
        private DataSet ds { get; set; }
        private string str { get; set; }
        public frm_Employee_Report()
        {
            InitializeComponent();
        }
        public frm_Employee_Report(DataSet dst,string getstr)
        {
            InitializeComponent();
            ds = dst;
            str = getstr;
        }

        private void frm_Employee_Report_Load(object sender, EventArgs e)
        {
            if(str == "BulkReport")
            {
                ReportDocument rptdc = new ReportDocument();
                EmployeeDataset Emp_ds = new EmployeeDataset();
                Emp_ds.Tables["tbl_Employee"].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);

                string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\EmployeeBulkReport.rpt";
                if (!string.IsNullOrEmpty(path1))
                {
                    rptdc.Load(path1);
                }
                rptdc.SetDataSource(Emp_ds);
                emp_report_viewer.ReportSource = rptdc;
                emp_report_viewer.Refresh();
            }
            else if(str == "SingleReport")
            {
                ReportDocument rptdc = new ReportDocument();
                EmployeeDataset Emp_ds = new EmployeeDataset();
                Emp_ds.Tables["tbl_Employee"].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);

                string path1 = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\EmployeeReport.rpt";
                if (!string.IsNullOrEmpty(path1))
                {
                    rptdc.Load(path1);
                }
                rptdc.SetDataSource(Emp_ds);
                emp_report_viewer.ReportSource = rptdc;
                emp_report_viewer.Refresh();
            }
            
        }
    }
}
