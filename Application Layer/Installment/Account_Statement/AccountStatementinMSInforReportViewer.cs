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

namespace PeshawarDHASW.Application_Layer.Installment.Account_Statement
{
    public partial class AccountStatementinMSInforReportViewer : Telerik.WinControls.UI.RadForm
    {
        public DataSet dst { get; set; }
        public AccountStatementinMSInforReportViewer(DataSet ds)
        {
            dst = ds;
            InitializeComponent();
        }
        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
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
        private void AccountStatementinMSInforReportViewer_Load(object sender, EventArgs e)
        {
            themeapplying();
            try
            {
                Report.Account_Statement_Report.AccountStatementinDetail dstrpt = new Report.Account_Statement_Report.AccountStatementinDetail();
                dstrpt.tbl_AccountStatement.Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
                dstrpt.FileInformation.Merge(dst.Tables[1], true, MissingSchemaAction.Ignore);
                //dstrpt.AccountStatement_DueAmountSum.Merge(dst.Tables[2], true, MissingSchemaAction.Ignore);
                //dstrpt.AccountStatement_ReceAmountSum.Merge(dst.Tables[3], true, MissingSchemaAction.Ignore);
                ReportDocument rptdoc = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\Account_Statement_Report\\AccountStatementinMSInfo.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(dstrpt);
                ReportViewer.ReportSource = rptdoc;
                ReportViewer.Refresh();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message + ex.InnerException);
            }
        }
    }
}
