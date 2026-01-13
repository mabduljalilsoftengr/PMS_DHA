using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Report.SurchargeWavierApplicationReport
{
    public partial class SurcWvrAppReportViewer : Telerik.WinControls.UI.RadForm
    {
        public SurcWvrAppReportViewer()
        {
            InitializeComponent();
        }
        public string SurchargeWaiveApplicationID { get; set; }
        public string ReportTypetoPrint { get; set; }
        public SurchargeWavierApplicationReport.SurWaiveApp data { get; set; }
        public SurcWvrAppReportViewer(SurchargeWavierApplicationReport.SurWaiveApp dataset, string ReportTypetoGenerate)
        {
            InitializeComponent();
            ReportTypetoPrint = ReportTypetoGenerate;
            data = dataset;
        }
        ReportDocument rptdoc = new ReportDocument();
        public DataSet dst { get; set; }
        private void ReceiveAdjustment(string FileNo)
        {
            SqlParameter[] prmt =
                   {
                     new SqlParameter("@Task","Rece_Plan_Adjust"),
                     new SqlParameter("@FileNo",FileNo)
                    };
            int rsult = Data_Layer.Installment.cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prmt);

        }

        private bool AccountStatmentView(string FileNo)
        {
            #region Account Statement Reading
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","AccountStatmentforCustomer"),
                new SqlParameter("@FileNo",FileNo),
                new SqlParameter("@userID",clsUser.ID)
            };
            dst = new DataSet();

            dst = Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);

            var ReceData = (from row in dst.Tables[0].AsEnumerable()
                                // where (string.IsNullOrEmpty(row["ReceAmount"].ToString()) ? 0 : (float)row["ReceAmount"]) > 0
                            orderby row["DueDate"] ascending
                            select row);
            DataTable dt = ReceData.AsDataView().ToTable();

            //var RemaingData = (from row in dst.Tables[0].AsEnumerable()
            //                 //  where (string.IsNullOrEmpty(row["ReceAmount"].ToString()) ? 0 : (float)row["ReceAmount"]) < 1
            //                   orderby row["DueDate"] ascending
            //                   select row);

            //DataTable dtwithNull = RemaingData.AsDataView().ToTable();

            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    if (dst.Tables[1].Rows.Count > 0)
                    {
                        if (dst.Tables[0].Rows.Count > 0)
                        {
                            
                            double TotalSurchargePaid = 0;
                            bool res = double.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
                            if (TotalSurchargePaid > 0)
                            {
                                foreach (DataRow item in dt.Rows)
                                {

                                    double SurchargeDue = 0;
                                    bool SurchargeFlag = double.TryParse(item["TotalDueSurcharge"].ToString(), out SurchargeDue);
                                    double Wavier = 0;
                                    bool WavierFlag = double.TryParse(item["TotalWaiveOffSurcharge"].ToString(), out Wavier);
                                    double SurchargetoBePaid = SurchargeDue - Wavier;
                                    if (!string.IsNullOrEmpty(item["TotalDueSurcharge"].ToString()))
                                    {
                                        try
                                        {
                                            if (TotalSurchargePaid == 0)
                                                continue;
                                            double outstanding = 0;
                                            bool outstandingflag = double.TryParse(item["Outstanding"].ToString(), out outstanding);
                                            if (TotalSurchargePaid > SurchargetoBePaid)
                                            {
                                                item["PaidSurcharge"] = SurchargetoBePaid;
                                                item["Outstanding"] = (outstanding - SurchargetoBePaid);
                                            }
                                            else if (TotalSurchargePaid <= SurchargetoBePaid)
                                            {
                                                if (TotalSurchargePaid < 0)
                                                {
                                                    item["PaidSurcharge"] = "0";
                                                }
                                                else
                                                {
                                                    item["PaidSurcharge"] = TotalSurchargePaid;
                                                    item["Outstanding"] = (outstanding - TotalSurchargePaid);
                                                }

                                            }
                                            else
                                            {
                                                TotalSurchargePaid = 0;
                                            }
                                            TotalSurchargePaid = TotalSurchargePaid - SurchargetoBePaid;
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Receive Information Error \n" + ex.Message + "\n---------\n" + ex.StackTrace);
                                        }
                                    }
                                }
                            }


                            DataTable dtt = new DataTable("Table1");
                            dtt = dt.Copy();
                            //  dtt.Merge(dtwithNull);
                            DataTable CustomerInfo = new DataTable("Table");
                            CustomerInfo = dst.Tables[1].Copy();
                            dst.Tables[0].Rows.Clear();
                            dst.Tables[1].Rows.Clear();

                            var DataSorting = (from row in dtt.AsEnumerable()
                                               orderby row["PlanID"] ascending, row["Descp"] ascending, row["InstallmentMode"] ascending, row["DueDate"] ascending
                                               select row);

                            dst.Tables[0].Merge(DataSorting.AsDataView().ToTable());
                            dst.Tables[1].Merge(CustomerInfo);

                        }
                        else
                        {
                            MessageBox.Show("Membership Information not Found. Contact to Transfer Branch.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Membership Information is not found. Contact to Transfer Branch.");
                    }


                    return true;

                }
                else
                {
                    MessageBox.Show("There is no Plan attached against this File No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
                return false;
            #endregion

        }

        private bool FileLock(string FileNo)
        {
            SqlParameter[] parameter =
              {
                    new SqlParameter("@Task","FileLockStatus"),
                    new SqlParameter("@FileNo",FileNo),
                    new SqlParameter("@LockbyUser",clsUser.ID)
                };
            string FileStatus = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", parameter).ToString();
            if (FileStatus == "1")
            {
                MessageBox.Show("File No: "+FileNo+" is Block.");
                return  false;
            }
            else
            {
                return true;
            }
        }
        private void ReportGenerate()
        {
            try
            {
                SurchargeWaiveApplicationID = data.Tables[0].Rows[0]["SWA_ID"].ToString();
            if (ReportTypetoPrint == "Approved")
                {
                    string FileNo = data.Tables[0].Rows[0]["FileNo"].ToString();
                    string StatmentDate = data.Tables[0].Rows[0]["StatementDate"].ToString();
                    bool FileStatus = FileLock(FileNo);
                    if (!string.IsNullOrWhiteSpace(StatmentDate))
                    {
                        if (FileStatus == true)
                        {
                            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\SurchargeWavierApplicationReport\\SurcWavierApproved.rpt";
                            rptdoc.Load(path);
                            rptdoc.SetDataSource(data);
                            crystalReportViewer1.ReportSource = rptdoc;
                            crystalReportViewer1.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Letter is enable to Print Due to File is Block.");
                        }
                    }
                    else
                    {
                        if (FileStatus == true)
                        {
                            ReceiveAdjustment(FileNo);
                            bool isOK = AccountStatmentView(FileNo);
                            if (!isOK)
                                return;
                            int TotalAmount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                                                 .Sum(r => r.Field<int>("DueAmount"));
                            int Surcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                                                 .Sum(r => r.Field<int>("TotalDueSurcharge"));
                            int TotalReceive = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAmount") != null)
                                               .Sum(r => r.Field<int>("ReceAmount"));
                            int TotalWaieOffSurcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("TotalWaiveOffSurcharge") != null)
                                                        .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));


                            double TotalSurchargePaid = 0;
                            double DueRemaingAmount = 0;
                            double DueSurchAmount = 0;

                            bool res = double.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
                            DueRemaingAmount = TotalAmount - TotalReceive;
                            DueSurchAmount = Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge;
                            double GrandTotal = 0;
                            GrandTotal = (DueRemaingAmount + DueSurchAmount);
                            data.Tables[0].Rows[0]["DueAmount"] = (decimal)TotalAmount;
                            data.Tables[0].Rows[0]["TotalReceived"] = (decimal)TotalReceive;
                            data.Tables[0].Rows[0]["DueRemaing"] = (decimal)DueRemaingAmount;
                            data.Tables[0].Rows[0]["TotalSurcharge"] = (decimal)Surcharge;//TotalSurcharge
                            data.Tables[0].Rows[0]["TotalPaidSurcharge"] = (decimal)TotalSurchargePaid;
                            data.Tables[0].Rows[0]["TotalWaiveoffSurcharge"] = (decimal)TotalWaieOffSurcharge;
                            data.Tables[0].Rows[0]["DueRemaingSurcharge"] = (decimal)DueSurchAmount;
                            data.Tables[0].Rows[0]["DueGrandTotal"] = (decimal)GrandTotal;
                            data.Tables[0].Rows[0]["StatementDate"] = DateTime.Now.ToString("yyyy-MM-dd");

                            string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\SurchargeWavierApplicationReport\\SurcWavierApproved.rpt";
                            rptdoc.Load(path);
                            rptdoc.SetDataSource(data);
                            crystalReportViewer1.ReportSource = rptdoc;
                            crystalReportViewer1.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Letter is enable to Print Due to File is Block.");
                        }
                    }

                   
            }
            else if (ReportTypetoPrint == "Sector A, B, C Not Approved")
            {
               
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\SurchargeWavierApplicationReport\\SectorABCNotApproved.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(data);
                crystalReportViewer1.ReportSource = rptdoc;
                crystalReportViewer1.Refresh();
             }
            else if (ReportTypetoPrint == "After Clearance of All Dues")
            {
                    string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\SurchargeWavierApplicationReport\\AfterLearnaceofAllDues.rpt";
                    rptdoc.Load(path);
                    rptdoc.SetDataSource(data);
                    crystalReportViewer1.ReportSource = rptdoc;
                    crystalReportViewer1.Refresh();
                }

            else if (ReportTypetoPrint== "After Clearnce of All Due -UnBalloted")
                {
                    string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\SurchargeWavierApplicationReport\\AfterLearnaceofAllDuesforUnBallot.rpt";
                    rptdoc.Load(path);
                    rptdoc.SetDataSource(data);
                    crystalReportViewer1.ReportSource = rptdoc;
                    crystalReportViewer1.Refresh();
                }
                else if (ReportTypetoPrint == "Already Waived-Off")//curent stoped by Dir Finance
            {
                
                string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\SurchargeWavierApplicationReport\\AlreadyWiavedOff.rpt";
                rptdoc.Load(path);
                rptdoc.SetDataSource(data);
                crystalReportViewer1.ReportSource = rptdoc;
                crystalReportViewer1.Refresh();
            }
            else if (ReportTypetoPrint == "Sector C Ext Not Approved")//curent stoped by Dir Finance
                {

                    string path = Helper.clsMostUseVars.applicationstartuppath + "\\Report\\SurchargeWavierApplicationReport\\SectorCExtReport.rpt";
                    rptdoc.Load(path);
                    rptdoc.SetDataSource(data);
                    crystalReportViewer1.ReportSource = rptdoc;
                    crystalReportViewer1.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SurcWvrAppReportViewer_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ShowPrintButton = false;
            crystalReportViewer1.ShowExportButton = false;
            ReportGenerate();
        }
        private void ExporttoExcel()
        {
            crystalReportViewer1.ExportReport();
            //SqlParameter[] param =
            //       {
            //           new SqlParameter("@Task","StatusUpdatetoPrintedinBulk"),
            //           new SqlParameter("@AckIDList",FinAckList),
            //           new SqlParameter("@userID",Models.clsUser.ID)
            //        };
            //int result = cls_Fin_Acknowledgement.Fin_Acknowledgment_NonQuery(param);
            //this.Close();
        }

        private void PrintOption()
        {
            try
            {
                //show Print Dialog
                PrintDialog printDialog = new PrintDialog();
                DialogResult dr = printDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    ReportDocument crReportDocument = rptdoc;
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
                    crReportDocument.PrintToPrinter(3, false, sPage, ePage);

                    decimal DueAmount = 0;
                    bool FDueAmount = decimal.TryParse(data.Tables[0].Rows[0]["DueAmount"].ToString(), out DueAmount);
                    decimal TotalReceived = 0;
                    bool FTotalReceived = decimal.TryParse(data.Tables[0].Rows[0]["TotalReceived"].ToString(), out TotalReceived);
                    decimal DueRemaing = 0;
                    bool FDueRemaing = decimal.TryParse(data.Tables[0].Rows[0]["DueRemaing"].ToString(), out DueRemaing);
                    decimal TotalSurcharge = 0;
                    bool FTotalSurcharge = decimal.TryParse(data.Tables[0].Rows[0]["TotalSurcharge"].ToString(), out TotalSurcharge);
                    decimal TotalPaidSurcharge = 0;
                    bool FTotalPaidSurcharge = decimal.TryParse(data.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalPaidSurcharge);
                    decimal TotalWaiveoffSurcharge = 0;
                    bool FTotalWaiveoffSurcharge = decimal.TryParse(data.Tables[0].Rows[0]["TotalWaiveoffSurcharge"].ToString(), out TotalWaiveoffSurcharge);
                    decimal DueRemaingSurcharge = 0;
                    bool FDueRemaingSurcharge = decimal.TryParse(data.Tables[0].Rows[0]["DueRemaingSurcharge"].ToString(), out DueRemaingSurcharge);
                    decimal DueGrandTotal = 0;
                    bool FDueGrandTotal = decimal.TryParse(data.Tables[0].Rows[0]["DueGrandTotal"].ToString(), out DueGrandTotal);

                    SqlParameter[] param = {
                    new SqlParameter("@Task","PrintedWaiver"),
                    new SqlParameter("@SWA_ID",SurchargeWaiveApplicationID),
                    new SqlParameter("@PrintStatus","Printed"),
                    new SqlParameter("@UpdateBy",clsUser.ID),
                    new SqlParameter("@DueAmount", DueAmount ),
                    new SqlParameter("@TotalReceived",TotalReceived ),
                    new SqlParameter("@DueRemaing", DueRemaing ),
                    new SqlParameter("@TotalSurcharge", TotalSurcharge ),
                    new SqlParameter("@TotalPaidSurcharge",TotalPaidSurcharge ),
                    new SqlParameter("@TotalWaiveoffSurcharge",  TotalWaiveoffSurcharge ),
                    new SqlParameter("@DueRemaingSurcharge",  DueRemaingSurcharge ),
                    new SqlParameter("@DueGrandTotal",   DueGrandTotal )
                    };

                    int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),CommandType.StoredProcedure, "App.USP_SurchargeWavier_ApplicationStatus", param);
                    this.Close();

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintOption();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExporttoExcel();
        }
    }
}
