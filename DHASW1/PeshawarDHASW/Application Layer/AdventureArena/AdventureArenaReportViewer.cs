using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.AdventureArena
{
    public partial class AdventureArenaReportViewer : Telerik.WinControls.UI.RadForm
    {
        public AdventureArenaReportViewer()
        {
            InitializeComponent();
        }

        public AdventureArenaReportViewer(string ReportName,
            object Dataset
            //,Report.AdventureArena.AdventureArenaDs objAADs =null
            //,Report.AdventureArena.AdventureArenaBookPrintingDs objAABPds = null
            )
        {
            InitializeComponent();
            if (ReportName =="AdventureArenaChallan")
            {
                Reportloading((Report.AdventureArena.AdventureArenaDs)Dataset);
            }
            if (ReportName == "AdventureArenaTicketBook")
            {
                ReportloadingTicketBook((Report.AdventureArena.AdventureArenaBookPrintingDs)Dataset);
            }
        }
        private void Reportloading(Report.AdventureArena.AdventureArenaDs AdArDs)
        {
            ReportDocument rptdoc = new ReportDocument();
            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\AdventureArena\\AdventureChallanReport.rpt";
            rptdoc.Load(path);
            rptdoc.SetDataSource(AdArDs);
            crystalReportViewer1.ReportSource = rptdoc;
            crystalReportViewer1.Refresh();
        }

        private void ReportloadingTicketBook(Report.AdventureArena.AdventureArenaBookPrintingDs AdArDs)
        {
            ReportDocument rptdoc = new ReportDocument();
            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\AdventureArena\\AdventureArenaTicketPrint.rpt";
            rptdoc.Load(path);
            rptdoc.SetDataSource(AdArDs);
            crystalReportViewer1.ReportSource = rptdoc;
            crystalReportViewer1.Refresh();
        }
        private void AdventureArenaReportViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
