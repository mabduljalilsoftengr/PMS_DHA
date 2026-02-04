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

namespace PeshawarDHASW.Application_Layer.Transfer.Transfer_Information.Total_Transfer_Detail
{
    public partial class TotalTransferReportViewer : Telerik.WinControls.UI.RadForm
    {
        public TotalTransferReportViewer()
        {
            InitializeComponent();
        }
        public DataTable dts  { get; set; }
        public DataTable dtcs { get; set; }
        public TotalTransferReportViewer(DataTable dt,DataTable dtc)
        {
            dts = dt;
            dtcs = dtc;
            InitializeComponent();
        }
        //private void themeapplying()
        //{
        //    if (clsUser.ThemeName == String.Empty)
        //    {
        //        ApplyTheme("TelerikMetro");
        //    }
        //    else
        //    {
        //        ApplyTheme(clsUser.ThemeName);
        //    }
        //}

     

        private void TotalTransferReportViewer_Load(object sender, EventArgs e)
        {
            //themeapplying();
            try
            {
                AllTransfersRecords dstrpt = new AllTransfersRecords();
                dstrpt.SummaryInfor.Merge(dts, true, MissingSchemaAction.Ignore);
                dstrpt.FileInformation.Merge(dtcs, true, MissingSchemaAction.Ignore);
                //dstrpt.AccountStatement_DueAmountSum.Merge(dst.Tables[2], true, MissingSchemaAction.Ignore);
                //dstrpt.AccountStatement_ReceAmountSum.Merge(dst.Tables[3], true, MissingSchemaAction.Ignore);
                ReportDocument rptdoc = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Application Layer\\Transfer\\Transfer Information\\Total Transfer Detail\\TotalTransferReport.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(dstrpt);
                rptAccountStatement.ReportSource = rptdoc;
                rptAccountStatement.Refresh();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message + ex.InnerException);
            }
        }
    }
}
