using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls; 
using PeshawarDHASW.Models;
using CrystalDecisions.CrystalReports.Engine;

namespace PeshawarDHASW.Application_Layer.Chalan
{
    public partial class frmChallanReportViewer : Telerik.WinControls.UI.RadForm
    {
        DataSet _ds = new DataSet();
        public frmChallanReportViewer(DataSet ds)
        {
            _ds = ds;
            InitializeComponent();
        }
        public frmChallanReportViewer()
        {
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
         
        private void frmChallanReportViewer_Load(object sender, EventArgs e)
        {
            themeapplying();
            try
            {

                ReportDocument rptdoc = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\Challan\\ChallanReport.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(_ds);
                challanViewer.ReportSource = rptdoc;
                challanViewer.Refresh();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message + ex.InnerException);
            }
        }
    }
}
