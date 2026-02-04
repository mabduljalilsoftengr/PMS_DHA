using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Report.List_OF_DD_ReadyForBank;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmListOfDD_ReadyForBankDeposite_ReportViewer : Telerik.WinControls.UI.RadForm
    {
        public frmListOfDD_ReadyForBankDeposite_ReportViewer()
        {
            InitializeComponent();
        }
        private DataSet dst { get; set; }
        public frmListOfDD_ReadyForBankDeposite_ReportViewer(DataSet get_ds)
        {
            InitializeComponent();
            dst = get_ds;
        }
        private void frmListOfDD_ReadyForBankDeposite_ReportViewer_Load(object sender, EventArgs e)
        {
            List_Of_DD_ReadyForBank dst_ddlst = new List_Of_DD_ReadyForBank();
            dst_ddlst.list_odds_ready_for_bank.Merge(dst.Tables[0]);
            dst_ddlst.BankDetail.Merge(dst.Tables[1]);
            //dstrpt.AccountStatement_Report.Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
            ReportDocument rptdoc = new ReportDocument();
            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\List_OF_DD_ReadyForBank\\List_Of_DD_ReadyForBank_Report.rpt";
            rptdoc.Load(path);
            rptdoc.SetDataSource(dst_ddlst);
            crViewerListOfDDInBank.ReportSource = rptdoc;
            crViewerListOfDDInBank.Refresh();
        }
    }
}
