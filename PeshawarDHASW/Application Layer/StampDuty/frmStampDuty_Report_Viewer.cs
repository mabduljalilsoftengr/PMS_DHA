using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Report.Stamp_Duty;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.StampDuty
{
    public partial class frmStampDuty_Report_Viewer : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst { get; set; } 
        public frmStampDuty_Report_Viewer()
        {
            InitializeComponent();
        }
        public frmStampDuty_Report_Viewer(DataSet get_dst)
        {
            InitializeComponent();
            dst = get_dst;
        }

        private void frmStampDuty_Report_Viewer_Load(object sender, EventArgs e)
        {
            //rpt_stamp_duty.ShowPrintButton = false;
            Stamp_Duty_DataSet stmp_dataset = new Stamp_Duty_DataSet();
            stmp_dataset.stamp_duty_report_view.Merge(dst.Tables[0]);
            //stmp_dataset.tbl_StampDuty_SellerBuyer.Merge(dst.Tables[1]);
            ReportDocument rptdl = new ReportDocument();
            string path_rpt = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\Stamp_Duty\\Stamp_Duty_Report.rpt";
            rptdl.Load(path_rpt);
            rptdl.SetDataSource(stmp_dataset);
            rpt_stamp_duty.ReportSource = rptdl;
            rpt_stamp_duty.Refresh();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            DialogResult dr = printDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ReportDocument crReportDocument = (ReportDocument)rpt_stamp_duty.ReportSource;
                System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
                //Get the Copy times
                int nCopy = 2;// printDocument1.PrinterSettings.Copies;
                //Get the number of Start Page
                int sPage = printDocument1.PrinterSettings.FromPage;
                //Get the number of End Page
                int ePage = printDocument1.PrinterSettings.ToPage;
                //printDocument1.PrinterSettings.PrintRange range = System.Drawing.Printing.PrintRange()
                crReportDocument.PrintOptions.PrinterName = printDocument1.PrinterSettings.PrinterName;
                //Start the printing process.  Provide details of the print job
                crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

            }
        }

        /*
         PrintDialog printDialog = new PrintDialog();
                DialogResult dr = printDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ReportDocument crReportDocument = (ReportDocument)AcknowledgementReportViewer.ReportSource;
                    System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
                    //Get the Copy times
                    int nCopy = printDocument1.PrinterSettings.Copies;
                    //Get the number of Start Page
                    int sPage = printDocument1.PrinterSettings.FromPage;
                    //Get the number of End Page
                    int ePage = printDocument1.PrinterSettings.ToPage;
                    //printDocument1.PrinterSettings.PrintRange range = System.Drawing.Printing.PrintRange()
                    crReportDocument.PrintOptions.PrinterName = printDocument1.PrinterSettings.PrinterName;
                    //Start the printing process.  Provide details of the print job
                    crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);
                    //SqlParameter[] param =
                    //{
                    //   new SqlParameter("@Task","StatusUpdatetoPrintedinBulk"),
                    //   new SqlParameter("@AckIDList",FinAckList),
                    //   new SqlParameter("@userID",Models.clsUser.ID)
                    //};
                    //int result = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(param);

                    SqlParameter[] param =
                    {
                       new SqlParameter("@Task","InsertAckAudit"),
                       new SqlParameter("@AckFinID",Ack_Fin_ID),
                       new SqlParameter("@userID",Models.clsUser.ID),
                       new SqlParameter("@Remark","Duplicate Acknowledgment Printed."),
                       new SqlParameter("@AuditDate",DateTime.Now.ToString("dd/MM/yyyy HH:mm tt"))
                    };
                    int result = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(param);
                    this.Close();
                    //                                        Form_Printerd = true;
                }*/

    }
}
