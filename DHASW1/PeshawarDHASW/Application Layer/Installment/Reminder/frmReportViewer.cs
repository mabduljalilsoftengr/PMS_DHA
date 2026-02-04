using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Report.Datasets.Installment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.Reminder
{
    public partial class frmReportViewer : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst { get; set; }
        public frmReportViewer()
        {
            InitializeComponent();
        }

        public frmReportViewer(DataSet ds)
        {
            InitializeComponent();
            dst = ds;
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            dstReminderDuesAndSurcharge dst_active = new dstReminderDuesAndSurcharge();
            ReportDocument rptdoc = new ReportDocument();
            
            dst_active.Tables["tbl_ReminderOfDuesAndSurcharge"].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);

            //MessageBox.Show(dst_active.Tables["tbl_ReminderOfDuesAndSurcharge"].Rows.Count.ToString());
            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\ReminderDuesAndSurcharge10DaysFutureEnglish.rpt";
            //string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\My_Reports\\testingreport.rpt";// ReminderDuesAndSurcharge10DaysFuture.rpt";   //testingreport
            if (!string.IsNullOrEmpty(path))
            {
                rptdoc.Load(path);
            }
            
            rptdoc.SetDataSource(dst_active);
            crpReminderDuesSurcharge.ReportSource = rptdoc;
            crpReminderDuesSurcharge.Refresh();
        }
    }
}
