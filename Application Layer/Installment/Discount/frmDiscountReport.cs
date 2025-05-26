using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.Discount
{
    public partial class frmDiscountReport : Telerik.WinControls.UI.RadForm
    {
        public frmDiscountReport()
        {
            InitializeComponent();
        }
        private void themeapplying()
        {
            if (clsUser.ThemeName == String.Empty)
            {
                ApplyTheme("TelerikMetro");
            }
            else
            {
                ApplyTheme(clsUser.ThemeName);
            }
        }

        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }

        public DataSet dataset { get; set; }
        public frmDiscountReport(DataSet ds)
        {
            InitializeComponent();
            dataset = ds;
        }


        private void frmDiscountReport_Load(object sender, EventArgs e)
        {
            themeapplying();
            try
            {
                Report.FinAcknowledgementReport.DiscountDS dstrpt = new Report.FinAcknowledgementReport.DiscountDS();
                dstrpt.Discount.Merge(dataset.Tables[0], true, MissingSchemaAction.Ignore);
              
                //dstrpt.AccountStatement_DueAmountSum.Merge(dst.Tables[2], true, MissingSchemaAction.Ignore);
                //dstrpt.AccountStatement_ReceAmountSum.Merge(dst.Tables[3], true, MissingSchemaAction.Ignore);
                ReportDocument rptdoc = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\FinAcknowledgementReport\\DiscountReport.rpt";
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
    }
}
