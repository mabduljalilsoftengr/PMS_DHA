using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    public partial class frmAcknowledgementReportViewer : Telerik.WinControls.UI.RadForm
    {
        public frmAcknowledgementReportViewer()
        {
            InitializeComponent();
        }

        public DataSet DsDataSet { get; set; }
        public frmAcknowledgementReportViewer(DataSet ds)
        {
            DsDataSet = ds;
            InitializeComponent();
        }
       


        private void ReportPrint(DataSet ds)
        {
            try
            {
                ReportDocument rd = new ReportDocument();
                string path = System.Windows.Forms.Application.StartupPath + "\\Report\\ReportFile\\AcknowledgementReport.rpt";
                rd.Load(path);
                rd.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rd;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ReportPrint.", ex, "frmAcknowledgmentReportViewer");
                frmobj.ShowDialog();

            }
        }
        private void frmAcknowledgementReportViewer_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            ReportPrint(DsDataSet);
        }
    }
}
