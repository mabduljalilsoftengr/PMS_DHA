using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.AcknowledgmentSearch
{
    public partial class AckFinReportViewer : Telerik.WinControls.UI.RadForm
    {
        public AckFinReportViewer()
        {
            InitializeComponent();
        }
        public string Ack_Fin_ID { get; set; }
        public AckFinReportViewer(string AckFinID)
        {
            Ack_Fin_ID = AckFinID;
            InitializeComponent();

        }

        public DataSet datasetReport { get; set; }
        public DataSet dst { get; set; }
        private DataSet dsrpt { get; set; }
        private string File_No { get; set; }
        public string FinAckList { get; set; }
        public bool isDuplicate { get; set; }
        DataTable dt = new DataTable();
        public AckFinReportViewer(DataSet dsreport, string Fin_Ack_List,string txt , bool isSummary = false)
        {
            InitializeComponent();
            datasetReport = dsreport;
            FinAckList = Fin_Ack_List;
            if (isSummary)
            {
                tabMain.Enabled = false;
                //radPageView1.DefaultPage = TabSummary;
                radPageView1.SelectedPage = TabSummary;
            }
            else
            {
                radPageView1.SelectedPage = tabMain;
            }
        }

        public AckFinReportViewer(string FinAckList, bool ButtonVisible, bool isDuplicate)
        {
            Ack_Fin_ID = FinAckList;
            InitializeComponent();
            //btnPrint.Visible = ButtonVisible;
            //btnexporttofile.Visible = ButtonVisible;
            AcknowledgementReportViewer.Dock = DockStyle.Fill;
            AcknowledgementReportViewer.ShowPrintButton = true;
            this.isDuplicate = isDuplicate;

        }
        private void AckFinReportViewer_Load(object sender, EventArgs e)
        {
            AcknowledgementReportViewer.ShowPrintButton = false;
            if (Ack_Fin_ID != "")
            {
                //File_No = GetFileNoFromACKID(Ack_Fin_ID);
                //AccountStatementDetailInAckReport();
                SingleAcknowledgment(Ack_Fin_ID);
            }
            if (datasetReport != null)
            {
                ReportDocument rptdoc = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\FinAcknowledgementReportDDInfo\\AcknowledgementReportDDinfo1.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(datasetReport);
                AcknowledgementReportViewer.ReportSource = rptdoc;
                AcknowledgementReportViewer.Refresh();
            }
            if (datasetReport != null)
            {
                ReportDocument rptdoc = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\FinAcknowledgementReportDDInfo\\AcknowledgmentSummaryReport.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(datasetReport);
                SummarReportViewer.ReportSource = rptdoc;
                SummarReportViewer.Refresh();
            }

        }
      private string GetFileNoFromACKID(string Ack_Fin_ID)
      {
            string fileno = "";
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetFileNo"),
                new SqlParameter("@AckFinID",Convert.ToInt64(Ack_Fin_ID))
            };
            DataSet d_s = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(prm);
            if(d_s.Tables.Count > 0)
            {
                if(d_s.Tables[0].Rows.Count > 0)
                {
                    fileno = d_s.Tables[0].Rows[0]["FileNo"].ToString();
                }
            }
            
            return fileno;
      }
        private void AccountStatementDetailInAckReport()
        {
            dst = null;
            DateTime nxtinstdte = GetNextLastInstallmentDate();
            ReceiveAdjustment();
            bool isOK = AccountStatmentView();
            if (!isOK)
                return;
            int TotalAmount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                                 .Sum(r => r.Field<int>("DueAmount"));                                                // DueAmount
            int Surcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                                 .Sum(r => r.Field<int>("TotalDueSurcharge"));                                        //DueSurcharge
            int TotalReceive = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAmount") != null)
                               .Sum(r => r.Field<int>("ReceAmount"));                                              // ReceiveAmount
            int TotalWaieOffSurcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("TotalWaiveOffSurcharge") != null)
                                        .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));                          // WaveroffSurcharge

            dst.Tables[1].Columns.Add("TotalDueSurcharge", typeof(Int32));
            dst.Tables[1].Columns.Add("TotalDueAmount", typeof(Int32));
            dst.Tables[1].Columns.Add("TotalRecAmount", typeof(Int32));
            dst.Tables[1].Columns.Add("TotalWaiveOffSurcharge", typeof(Int32));

            dst.Tables[1].Rows[0]["TotalDueSurcharge"] = Surcharge;
            dst.Tables[1].Rows[0]["TotalDueAmount"] = TotalAmount;
            dst.Tables[1].Rows[0]["TotalRecAmount"] = TotalReceive;
            dst.Tables[1].Rows[0]["TotalWaiveOffSurcharge"] = TotalWaieOffSurcharge;

            double TotalSurchargePaid = 0;

            double DueRemaingAmount = 0;
            double DueSurchAmount = 0;

            bool res = double.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);   // PaidSurcharge
            DueRemaingAmount = (TotalAmount - TotalReceive) >= 0 ? (TotalAmount - TotalReceive) : 0;                                                               //DueRemaingAmount
            DueSurchAmount = (Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge) >= 0 ? (Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge) : 0;         //DueSurcharge  

            double GrandTotal = 0;
            dst.Tables[0].Rows[0]["TotalPaidSurcharge"] = TotalSurchargePaid;
            GrandTotal = (DueRemaingAmount + DueSurchAmount);

            decimal damnt, Receamnt, r_d_amn, srcg, pdsrcg, wvrsrcg, drsrcg, G_T_Rmng;
            damnt = TotalAmount; Receamnt = TotalReceive; r_d_amn = Convert.ToDecimal(DueRemaingAmount);
            srcg = Surcharge; pdsrcg = Convert.ToDecimal(TotalSurchargePaid); wvrsrcg = TotalWaieOffSurcharge; drsrcg = Convert.ToDecimal(DueSurchAmount);
            G_T_Rmng = Convert.ToDecimal(GrandTotal);


            //if (ds_rpt.Tables[0].Columns.Count > 0)
            //{
            //    ds_rpt.Clear();
            //}

            if (dsrpt.Tables[0].Columns.Contains("DueAmount")) { } else { dsrpt.Tables[0].Columns.Add("DueAmount", typeof(decimal)); }
            if (dsrpt.Tables[0].Columns.Contains("ReceAmount")) { } else { dsrpt.Tables[0].Columns.Add("ReceAmount", typeof(decimal)); }
            if (dsrpt.Tables[0].Columns.Contains("DueRemainingAmount")) { } else { dsrpt.Tables[0].Columns.Add("DueRemainingAmount", typeof(decimal)); }
            if (dsrpt.Tables[0].Columns.Contains("DueSurcharge")) { } else { dsrpt.Tables[0].Columns.Add("DueSurcharge", typeof(decimal)); }
            if (dsrpt.Tables[0].Columns.Contains("PaidSurcharge")) { } else { dsrpt.Tables[0].Columns.Add("PaidSurcharge", typeof(decimal)); }
            if (dsrpt.Tables[0].Columns.Contains("WaiveroffSurcharge")) { } else { dsrpt.Tables[0].Columns.Add("WaiveroffSurcharge", typeof(decimal)); }
            if (dsrpt.Tables[0].Columns.Contains("RemainingSurcharge")) { } else { dsrpt.Tables[0].Columns.Add("RemainingSurcharge", typeof(decimal)); }
            if (dsrpt.Tables[0].Columns.Contains("DueGrandTotal")) { } else { dsrpt.Tables[0].Columns.Add("DueGrandTotal", typeof(decimal)); }


            //ds_rpt.Tables[0].Columns.Add("ReceAmount", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("DueRemainingAmount", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("DueSurcharge", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("", typeof(DateTime));

            foreach (DataRow dr in dsrpt.Tables[0].Rows) // search whole table
            {
                if (Convert.ToInt64(dr["FinAckID"].ToString()) == Convert.ToInt64(Ack_Fin_ID)) // if id==2
                {
                    //DataRow row = ds_rpt.Tables[0].NewRow();
                    dr["DueAmount"] = Convert.ToDecimal(damnt);
                    dr["ReceAmount"] = Receamnt;
                    dr["DueRemainingAmount"] = r_d_amn;
                    dr["DueSurcharge"] = srcg;
                    dr["PaidSurcharge"] = pdsrcg;
                    dr["WaiveroffSurcharge"] = wvrsrcg;
                    dr["RemainingSurcharge"] = drsrcg;
                    dr["DueGrandTotal"] = G_T_Rmng;
                    //ds_rpt.Tables[0].Rows.Add(row);
                    // btnPrint.Enabled = true;
                }
            }



        }

        private DateTime GetNextLastInstallmentDate()
        {
            DateTime dtnext = new DateTime();
            SqlParameter[] prmt =
            {
                new SqlParameter("@Task","GetLast_Installment_Date"),
                new SqlParameter("@FileNo",File_No)
            };
            DataSet dst_ = cls_dl_Acknowledgment.AcknowledgementReader(prmt);   // DueDate
            if(dst_.Tables.Count > 0)
            {
                if(dst_.Tables[0].Rows.Count > 0)
                {
                    dtnext = Convert.ToDateTime(dst_.Tables[0].Rows[0]["DueDate"].ToString());
                }
            }
            return dtnext;
        }
        private bool AccountStatmentView()
        {
            bool bl = false;
            #region Account Statement Reading
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","AccountStatmentforCustomer"),
                new SqlParameter("@FileNo",File_No),
                new SqlParameter("@userID",clsUser.ID)
           };
            dst = new DataSet();

            dst = Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);
            
            if(dst.Tables.Count > 0)
            {
                if(dst.Tables[0].Rows.Count > 0)
                {
                    bl = true;
                }
                else
                {
                    bl = false;
                }
            }
            else
            {
                bl = false;
            }


            return bl;
            #endregion

        }
        #region Adjustment of Receiving of this File
        private void ReceiveAdjustment()
        {
            SqlParameter[] prmt =
                   {
                     new SqlParameter("@Task","Rece_Plan_Adjust"),
                     new SqlParameter("@FileNo",File_No)
                    };
            int rsult = Data_Layer.Installment.cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prmt);

        }
        #endregion
        ReportDocument objdoc = new ReportDocument();
        private void SingleAcknowledgment(string AckID)
        {
            try
            {
              

                SqlParameter[] prm =
                {
                new SqlParameter("@Task","DuplicateReportAck"),
                new SqlParameter("@AckFinID",Ack_Fin_ID)
                };
                dsrpt = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(prm);


                File_No = GetFileNoFromACKID(Ack_Fin_ID);
                //AccountStatementDetailInAckReport();

                Report.AcknowledgementReportDs reportDs = new Report.AcknowledgementReportDs();
                reportDs.EnforceConstraints = false;
                reportDs.Acknowledgement.Merge(dsrpt.Tables[1], true, MissingSchemaAction.Ignore);
                reportDs.vw_tbl_Acknowledgement.Merge(dsrpt.Tables[0], true, MissingSchemaAction.Ignore);
                if (isDuplicate)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("WaterMarkPath", typeof(string));
                    dt.Rows.Add(Helper.clsMostUseVars.applicationstartuppath + "\\Images\\duplicate.png");
                    reportDs.ReportDetails.Merge(dt, true, MissingSchemaAction.Ignore);
                }
                reportDs.tblTotalDueRemainigData.Merge(dt);
               // reportDs.EnforceConstraints = true;
                ReportDocument rptdoc = new ReportDocument();
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\FinAcknowledgementReportDDInfo\\AcknowledgementReportDDinfo1.rpt";
                
                //string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\ackrpttest.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(reportDs);
                objdoc = rptdoc;
                //rptdoc.PrintToPrinter(1, false, 0, 0);
                AcknowledgementReportViewer.ReportSource = rptdoc;
                AcknowledgementReportViewer.Refresh();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message + ex.InnerException);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //show Print Dialog
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
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnexporttofile_Click(object sender, EventArgs e)
        {
            AcknowledgementReportViewer.ExportReport();
            SqlParameter[] param =
                   {
                       new SqlParameter("@Task","StatusUpdatetoPrintedinBulk"),
                       new SqlParameter("@AckIDList",FinAckList),
                       new SqlParameter("@userID",Models.clsUser.ID)
                    };
            int result = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(param);
            this.Close();
        }

        private void btnDuplicatePrint_Click(object sender, EventArgs e)
        {

        }
    }
}
