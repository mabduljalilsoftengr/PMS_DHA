using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Report.ScheuldeCopy
{
    public partial class frmSchedulePrint : Telerik.WinControls.UI.RadForm
    {
        public frmSchedulePrint()
        {
            InitializeComponent();
        }
        
        public int Filekey { get; set; }
        public string File_No { get; set; }
        object flk;
        object FilNo;
        public frmSchedulePrint(int FileMapKey, string FileNo)
        {
            flk = (object)FileMapKey;
            File_No = FileNo;
            flk = FileMapKey==0 ? DBNull.Value : (object)FileMapKey;
            FilNo = string.IsNullOrEmpty(FileNo) ? DBNull.Value : (object)FileNo;

            InitializeComponent();
          
            
        }

        private void frmSchedulePrint_Load(object sender, EventArgs e)
        {
            themeapplying();
            try
            {
               
                SqlParameter[] searchparam =
                {
                    new SqlParameter("@Task","PlanPrintCopy"),
                    new SqlParameter("@FileMapKey", flk),
                    new SqlParameter("@FileNo",FilNo)
                };
                DataSet ds = Data_Layer.Installment.clsInstallmentTemplate.InstalTemplate_Reader(searchparam);
                Report.ScheuldeCopy.ScheudleCopyDs dstrpt = new Report.ScheuldeCopy.ScheudleCopyDs();
                dstrpt.tbl_Report.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                ReportDocument rptdoc = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\ScheuldeCopy\\SchuduleCopyRpt.rpt";
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
    }
}
