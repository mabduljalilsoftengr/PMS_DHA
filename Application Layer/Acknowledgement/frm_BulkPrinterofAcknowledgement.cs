
using PeshawarDHASW.Application_Layer.Installment.AcknowledgmentSearch;
using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using PeshawarDHASW.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    public partial class frm_BulkPrinterofAcknowledgement : Telerik.WinControls.UI.RadForm
    {
        public frm_BulkPrinterofAcknowledgement()
        {
            InitializeComponent();
        }

        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        private string File_No { get; set; }
        private DataSet dst { get; set; }
        private DataSet ds_rpt { get; set; }
        private long AckID { get; set; }
        private void frm_BulkPrinterofAcknowledgement_Load(object sender, EventArgs e)
        {
            ApplyTheme(clsUser.ThemeName);
            dtSummaryDate.Value = DateTime.Now.Date;
            dtSummaryDateTo.Value = DateTime.Now.Date;
        }

        Report.AcknowledgementReportDs reportDs = new Report.AcknowledgementReportDs();
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            DataLoadingofAcknowledgement.RunWorkerAsync();
        }

        private void btnReadyforPrint_Click(object sender, EventArgs e)
        {
            FinAckIDsList = FinAckIDs_ListCreation();

            AckFinReportViewer obj = new AckFinReportViewer(reportDs, FinAckIDsList,"BulkPrinting");
            obj.ShowDialog();

            reportDs.Clear();
            DGV_Acknowledgement.DataSource = null;
        }

        private void DataLoadingofAcknowledgement_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var item in DGV_Acknowledgement.Rows)
            {

                if (item.Cells["StatusAck"].Value.ToString() == "Not-Printed")
                {
                    
                    SqlParameter[] prm =
                     {
                     new SqlParameter("@Task","ReportAck"),
                     new SqlParameter("@AckFinID",item.Cells["FinAckID"].Value)
                     };
                    ds_rpt = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(prm);

                    AckID = Convert.ToInt64(item.Cells["FinAckID"].Value.ToString());

                    File_No = GetFileNoFromACKID(item.Cells["FinAckID"].Value.ToString());
                    //AccountStatementDetailInAckReport();


                    reportDs.EnforceConstraints = false;
                    reportDs.Acknowledgement.Merge(ds_rpt.Tables[1], true, MissingSchemaAction.Ignore);
                    reportDs.vw_tbl_Acknowledgement.Merge(ds_rpt.Tables[0], true, MissingSchemaAction.Ignore);
                }
                
            }
           
           // MessageBox.Show(reportDs.vw_tbl_Acknowledgement.Rows.Count.ToString());
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
            if (d_s.Tables.Count > 0)
            {
                if (d_s.Tables[0].Rows.Count > 0)
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

            DueRemaingAmount =  (TotalAmount - TotalReceive) >= 0 ? (TotalAmount - TotalReceive) : 0 ;                                                               //DueRemaingAmount

            DueSurchAmount = (Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge) >= 0 ? (Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge) : 0 ;         //DueSurcharge  

            double GrandTotal = 0;
            dst.Tables[0].Rows[0]["TotalPaidSurcharge"] = TotalSurchargePaid;
            GrandTotal = (DueRemaingAmount + DueSurchAmount);

            decimal damnt, Receamnt, r_d_amn, srcg, pdsrcg, wvrsrcg, drsrcg, G_T_Rmng;
            damnt = TotalAmount; Receamnt = TotalReceive;
            r_d_amn = Convert.ToDecimal(DueRemaingAmount);
            srcg = Surcharge;
            pdsrcg = Convert.ToDecimal(TotalSurchargePaid);
            wvrsrcg = TotalWaieOffSurcharge;
            drsrcg = Convert.ToDecimal(DueSurchAmount);
            G_T_Rmng = Convert.ToDecimal(GrandTotal);


            //if (ds_rpt.Tables[0].Columns.Count > 0)
            //{
            //    ds_rpt.Clear();
            //}

            if (ds_rpt.Tables[0].Columns.Contains("DueAmount")) { } else { ds_rpt.Tables[0].Columns.Add("DueAmount", typeof(decimal)); }
            if (ds_rpt.Tables[0].Columns.Contains("ReceAmount")) { } else { ds_rpt.Tables[0].Columns.Add("ReceAmount", typeof(decimal)); }
            if (ds_rpt.Tables[0].Columns.Contains("DueRemainingAmount")) { } else { ds_rpt.Tables[0].Columns.Add("DueRemainingAmount", typeof(decimal)); }
            if (ds_rpt.Tables[0].Columns.Contains("DueSurcharge")) { } else { ds_rpt.Tables[0].Columns.Add("DueSurcharge", typeof(decimal)); }
            if (ds_rpt.Tables[0].Columns.Contains("PaidSurcharge")) { } else { ds_rpt.Tables[0].Columns.Add("PaidSurcharge", typeof(decimal)); }
            if (ds_rpt.Tables[0].Columns.Contains("WaiveroffSurcharge")) { } else { ds_rpt.Tables[0].Columns.Add("WaiveroffSurcharge", typeof(decimal)); }
            if (ds_rpt.Tables[0].Columns.Contains("RemainingSurcharge")) { } else { ds_rpt.Tables[0].Columns.Add("RemainingSurcharge", typeof(decimal)); }
            if (ds_rpt.Tables[0].Columns.Contains("DueGrandTotal")) { } else { ds_rpt.Tables[0].Columns.Add("DueGrandTotal", typeof(decimal)); }


            //ds_rpt.Tables[0].Columns.Add("ReceAmount", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("DueRemainingAmount", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("DueSurcharge", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("", typeof(decimal));
            //ds_rpt.Tables[0].Columns.Add("", typeof(DateTime));

            foreach (DataRow dr in ds_rpt.Tables[0].Rows) // search whole table
            {
                if (Convert.ToInt64(dr["FinAckID"].ToString()) == AckID) // if id==2
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
            if (dst_.Tables.Count > 0)
            {
                if (dst_.Tables[0].Rows.Count > 0)
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

            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
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

        private string FinAckIDs_ListCreation()
        {
            string FinAckIDs = "";
            foreach (var item in DGV_Acknowledgement.Rows)
            {
                FinAckIDs += item.Cells["FinAckID"].Value.ToString() + ",";
            }
            return FinAckIDs;
        }
        private void DataLoadingofAcknowledgement_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (reportDs.Tables.Count > 0)
            {
                btnReadyforPrint.Enabled = true;
            }
        }
        public string FinAckIDsList { get; set; }
        private void btnLoadAcknowledgementData_Click(object sender, EventArgs e)
        {
            try
            {
                btnLoadData.Enabled = true;
                btnReadyforPrint.Enabled = false;
                SqlParameter[] param = {
                    new SqlParameter("@Task","LoadLimitRecordforPrinting"),
                    new SqlParameter("@SizeofRecord",Helper.clsPluginHelper.DbNullIfNullOrEmpty(dpRecordSize.Text)),
                     };
                DataSet ds = new DataSet();
                ds = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(param);
                //MessageBox.Show(ds.Tables[0].Rows.Count.ToString());
                DGV_Acknowledgement.DataSource = ds.Tables[0].DefaultView;
               // MessageBox.Show("GridCunt-> "+DGV_Acknowledgement.Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                reportDs.vw_tbl_Acknowledgement.Clear();
                btnLoadData.Enabled = false;
                btnReadyforPrint.Enabled = false;
                SqlParameter[] param = {
                                        new SqlParameter("@Task","LoadSummaryReport"),
                                        new SqlParameter("@PrintedDate",dtSummaryDate.Value.Date),
                                        new SqlParameter("@PrintedDateTo", dtSummaryDateTo.Value.Date)
                                    };
                DataSet ds = new DataSet();
                ds = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DGV_Acknowledgement.DataSource = ds.Tables[0].DefaultView;
                        reportDs.EnforceConstraints = false;
                        reportDs.vw_tbl_Acknowledgement.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                        if (reportDs.vw_tbl_Acknowledgement.Rows.Count == DGV_Acknowledgement.RowCount)
                        {
                            AckFinReportViewer obj = new AckFinReportViewer(reportDs, FinAckIDsList,"", true);
                            obj.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Retry for Load Data. Acknowledgement is not Generated Successfully.");
                        }
                        reportDs.vw_tbl_Acknowledgement.Clear();
                        reportDs.Acknowledgement.Clear();
                    }
                    else
                    {
                        reportDs.vw_tbl_Acknowledgement.Clear(); DGV_Acknowledgement.DataSource = null;
                        MessageBox.Show("No data found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    reportDs.vw_tbl_Acknowledgement.Clear(); DGV_Acknowledgement.DataSource = null;
                    MessageBox.Show("No data found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data not Loaded please try again.\n"+ex.Message);
            }

         


        }

        private void btnAckCount_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                                        new SqlParameter("@Task","LoadSummaryReport"),
                                        new SqlParameter("@PrintedDate",dtSummaryDate.Value.Date),
                                        new SqlParameter("@PrintedDateTo", dtSummaryDateTo.Value.Date)
                                    };
            DataSet ds = new DataSet();
            ds = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(param);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    frm_AcknowledgementCount frm = new frm_AcknowledgementCount(ds.Tables[1]);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No data found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No data found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
