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
    public partial class AccountStatementforCustomerReportViewer : Telerik.WinControls.UI.RadForm
    {
        DataSet AC_Customer_ds = new DataSet();
        public AccountStatementforCustomerReportViewer(DataSet ds)
        {
            AC_Customer_ds = ds;
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

        private void AccountStatementforCustomerReportViewer_Load(object sender, EventArgs e)
        {
            themeapplying();
            try
            {
                
                ReportDocument rptdoc = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\Account_Statement_Report\\AccountStatementforCustomer_Report.rpt";
            //    string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\Account_Statement_Report\\test.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(AC_Customer_ds);
                ReportViewer_AC.ReportSource = rptdoc;
                ReportViewer_AC.Refresh();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message + ex.InnerException);
            }
        }
    }
}
