using PeshawarDHASW.Data_Layer.clsMemberShip;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using PeshawarDHASW.Report.Account_Statement_Report;
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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.Account_Statement
{
    public partial class AccountStatementforCustomer : Telerik.WinControls.UI.RadForm
    {

        public AccountStatementforCustomer()
        {
            InitializeComponent();
        }

        public DataSet dst { get; set; }
        public AccountStatmentofCustomer ds = new AccountStatmentofCustomer();
        private bool AccountStatmentView()
        {

            if (this.grd_AccountStatment.SummaryRowsBottom.Count > 0)
            {
                this.grd_AccountStatment.SummaryRowsBottom.Clear();
            }
            grd_AccountStatment.DataSource = null;


            #region Account Statement Reading
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","AccountStatmentforCustomer"),
                new SqlParameter("@FileNo",txtFileNo.Text),
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
                            lblFileNo.Text = dst.Tables[1].Rows[0]["FileNo"].ToString();
                            lblName.Text = dst.Tables[1].Rows[0]["Name"].ToString();
                            lblCNIC.Text = dst.Tables[1].Rows[0]["NIC"].ToString();
                            lblMobileno.Text = dst.Tables[1].Rows[0]["MobileNo"].ToString();
                            lblplotsize.Text = dst.Tables[1].Rows[0]["PlotSize"].ToString();
                            lblPlotNo.Text = dst.Tables[1].Rows[0]["PlotNo"].ToString();
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
                                            bool outstandingflag = double.TryParse(item["Outstanding"].ToString(),out outstanding);
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
                                            ClearForm();
                                        }
                                    }
                                    //if (!string.IsNullOrEmpty(item["Outstanding"].ToString()))
                                    //{
                                    //    try
                                    //    {
                                    //        if (TotalSurchargePaid == 0)
                                    //            continue;
                                    //        double outstanding = double.Parse(item["Outstanding"].ToString());
                                    //        if (TotalSurchargePaid < outstanding)
                                    //        {
                                    //            item["PaidSurcharge"] = TotalSurchargePaid;
                                    //            item["Outstanding"] = (outstanding - TotalSurchargePaid);
                                    //        }
                                    //        TotalSurchargePaid = TotalSurchargePaid - outstanding;

                                    //        if (TotalSurchargePaid > -1)
                                    //        {
                                    //            item["Outstanding"] = "0";
                                    //        }
                                    //        if (TotalSurchargePaid > -1)
                                    //            item["PaidSurcharge"] = outstanding;
                                    //        else
                                    //        {
                                    //            TotalSurchargePaid = 0;
                                    //        }
                                    //    }
                                    //    catch (Exception ex)
                                    //    {
                                    //    }
                                    //}
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
                            grd_AccountStatment.DataSource = dst.Tables[0].DefaultView;

                            #region Summary Columns
                            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                            summaryItem.Name = "DueAmount";
                            summaryItem.Aggregate = GridAggregateFunction.Sum;
                            summaryItem.FormatString = "{0:#,###0;(#,###0);0}";

                            GridViewSummaryItem summaryItem1 = new GridViewSummaryItem();
                            summaryItem1.Name = "ReceAmount";
                            summaryItem1.Aggregate = GridAggregateFunction.Sum;
                            summaryItem1.FormatString = "{0:#,###0;(#,###0);0}";

                            GridViewSummaryItem summaryItem3 = new GridViewSummaryItem();
                            summaryItem3.Name = "TotalDueSurcharge";
                            summaryItem3.Aggregate = GridAggregateFunction.Sum;
                            summaryItem3.FormatString = "{0:#,###0;(#,###0);0}";

                            GridViewSummaryItem summaryItem4 = new GridViewSummaryItem();
                            summaryItem3.Name = "Outstanding";
                            summaryItem3.Aggregate = GridAggregateFunction.Sum;
                            summaryItem3.FormatString = "{0:#,###0;(#,###0);0}";


                            GridViewSummaryItem summaryItem5 = new GridViewSummaryItem();
                            summaryItem5.Name = "PaidSurcharge";
                            summaryItem5.Aggregate = GridAggregateFunction.Sum;
                            summaryItem5.FormatString = "{0:#,###0;(#,###0);0}";


                            GridViewSummaryItem summaryItem6 = new GridViewSummaryItem();
                            summaryItem6.Name = "TotalWaiveOffSurcharge";
                            summaryItem6.Aggregate = GridAggregateFunction.Sum;
                            summaryItem6.FormatString = "{0:#,###0;(#,###0);0}";


                            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
                            summaryRowItem.Add(summaryItem);
                            summaryRowItem.Add(summaryItem1);
                            summaryRowItem.Add(summaryItem3);
                            summaryRowItem.Add(summaryItem4);
                            summaryRowItem.Add(summaryItem5);
                            summaryRowItem.Add(summaryItem6);

                            this.grd_AccountStatment.SummaryRowsBottom.Add(summaryRowItem);
                            #endregion
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


        #region Adjustment of Receiving of this File
        private void ReceiveAdjustment()
        {
            SqlParameter[] prmt =
                   {
                     new SqlParameter("@Task","Rece_Plan_Adjust"),
                     new SqlParameter("@FileNo",txtFileNo.Text)
                    };
            int rsult = Data_Layer.Installment.cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prmt);

        }
        #endregion
        private void AccountStatementforCustomer_Load(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            foreach (DataRow row in clsMostUseVars.ReportDs.Rows)
            {
                if (btnPrint.AccessibleName == row["ControlName"].ToString())
                {
                    btnPrint.Enabled = true;
                    break;
                }
                else
                {
                    btnPrint.Enabled = false;
                }
            }
        }
        private void Amalgamationcheck()
        {
            SqlParameter[] param_Amalg = {
                                new SqlParameter("@Task","IsAmalgamated"),
                                new SqlParameter("@FileNo",txtFileNo.Text)
                            };
            lblAmalgFileNo.Text = "";
            IsAmalgamatedchk.Text = "";
            DataSet ds = Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_FileMap", param_Amalg);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrWhiteSpace(ds.Tables[0].Rows[0]["ParentFile"].ToString()))
                    {
                    lblamg.Visible = true;
                    lblparentamg.Visible = true;
                    lblAmalgFileNo.Visible = true;
                    IsAmalgamatedchk.Visible = true;

                    lblAmalgFileNo.Text = ds.Tables[0].Rows[0]["ParentFile"].ToString();
                    IsAmalgamatedchk.Text = ds.Tables[0].Rows[0]["Amalgamated"].ToString();
                    }
                }
            }
        }
        private void ClearForm()
        {
            lblName.Text = ""; lblFileNo.Text = ""; lblMobileno.Text = ""; lblplotsize.Text = ""; lblPlotNo.Text = ""; lblCNIC.Text = "";
            lblTotalDue.Text = "0"; lblTotalReceive.Text = "0"; lblDueRemaing.Text = "0"; lblGrandDueTotal.Text = "0";
            lblTotalSurcharge.Text = "0"; lblTotalSurcPaid.Text = "0"; lblTotalWaiedOffSur.Text = "0"; lblDueSurcharge.Text = "0";
            lblFileStatus.Text = "";
            grd_AccountStatment.DataSource = null;
        }

        private void btnAccountStatmentView_Click(object sender, EventArgs e)
        {
            try
            {
                lblamg.Visible = false;
                lblparentamg.Visible = false;
                lblAmalgFileNo.Visible = false;
                IsAmalgamatedchk.Visible = false;

                if (!string.IsNullOrEmpty(txtplotno.Text))
                {
                    SqlParameter[] param = new[]
                    {
                     new SqlParameter("@Task","SelectFileNoFormPlotNo"),
                     new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtplotno.Text))
                    };
                    DataSet dst_ = cls_dl_Membership.Membership_PersonalInfo_Retrive(param);
                    if (dst_.Tables.Count > 0)
                    {
                        if (dst_.Tables[0].Rows.Count > 0)
                        {
                            txtFileNo.Text = dst_.Tables[0].Rows[0]["FileNo"].ToString();
                            Amalgamationcheck();
                        }
                        else
                        {
                            MessageBox.Show("File No. Not Exist.");
                        }


                    }
                    else
                    {
                        MessageBox.Show("File No. Not Exist.");
                    }
                }



                SqlParameter[] parameter =
                {
                    new SqlParameter("@Task","FileLockStatusCust"),
                    new SqlParameter("@FileNo",txtFileNo.Text),
                    new SqlParameter("@LockbyUser",clsUser.ID)
                };
                DataSet FileStatus = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", parameter);
                if(FileStatus.Tables.Count > 0)
                {
                    if(FileStatus.Tables[0].Rows.Count > 0)
                    {
                        lblFileStatus.Text = FileStatus.Tables[0].Rows[0]["FileLockStatus"].ToString();  
                        lblactivecancel.Text = FileStatus.Tables[1].Rows[0]["Status"].ToString();
                    }
                    else
                    {
                        lblFileStatus.Text = FileStatus.Tables[0].Rows[0]["FileLockStatus"].ToString();
                        lblactivecancel.Text = FileStatus.Tables[1].Rows[0]["Status"].ToString();
                    }
                }
                else
                {
                    lblFileStatus.Text = FileStatus.Tables[0].Rows[0]["FileLockStatus"].ToString();
                    lblactivecancel.Text = FileStatus.Tables[1].Rows[0]["Status"].ToString();
                }

                
                if (FileStatus.Tables[0].Rows[0]["FileLockStatus"].ToString() == "Block")
                {
                    // ClearForm();
                    lblFileStatus.Text = FileStatus.Tables[0].Rows[0]["FileLockStatus"].ToString();
                    lblactivecancel.Text = FileStatus.Tables[1].Rows[0]["Status"].ToString();
                }
                if (1==1)//(FileStatus.Tables[0].Rows[0]["FileLockStatus"].ToString() == "Active") || (clsUser.ID == 3) || (clsUser.ID == 35))
                {
                    lblFileStatus.Text = FileStatus.Tables[0].Rows[0]["FileLockStatus"].ToString();
                    lblactivecancel.Text = FileStatus.Tables[1].Rows[0]["Status"].ToString();
                    Amalgamationcheck();
                    ReceiveAdjustment();
                    bool isOK = AccountStatmentView();
                    if (!isOK)
                        return;
                    int TotalAmount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                                         .Sum(r => r.Field<int>("DueAmount"));
                    int Surcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                                         .Sum(r => r.Field<int>("TotalDueSurcharge"));

                    //if(txtFileNo.Text == "B/RES/1679")
                    //{
                    //    Surcharge = Surcharge + 174760;
                    //}

                    int TotalReceive = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAmount") != null)
                                       .Sum(r => r.Field<int>("ReceAmount"));
                    int TotalWaieOffSurcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("TotalWaiveOffSurcharge") != null)
                                                .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));

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

                    bool res = double.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
                    DueRemaingAmount = TotalAmount - TotalReceive;
                    DueSurchAmount = Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge;
                    // double Refund = TotalSurchargePaid - TotalWaieOffSurcharge;
                    // for Stopping of Surcharge Paid to minus 
                    /// Surcharge 2000 : Paid Surcharge : 2000 : WavierOff: 1000 : 2000-(2000+1000) = -1000

                    lblTotalSurcPaid.Text = string.Format("{0:n0}", TotalSurchargePaid);
                    lblDueRemaing.Text = string.Format("{0:n0}", DueRemaingAmount);
                    double GrandTotal = 0;
                    dst.Tables[0].Rows[0]["TotalPaidSurcharge"] = TotalSurchargePaid;
                    GrandTotal = (DueRemaingAmount + DueSurchAmount);
                    lblDueSurcharge.Text = string.Format("{0:n0}", DueSurchAmount);

                    /*
                        Due Amount = 1000           Total Receive = 800         Due Remaing = 200           Grand Due Amount
                        Total Surcharge = 200       Total Paid = 120            Due Surcharge = 80              280
                    */
                    lblTotalDue.Text = string.Format("{0:n0}", TotalAmount);
                    lblTotalSurcharge.Text = string.Format("{0:n0}", Surcharge);
                    lblTotalReceive.Text = string.Format("{0:n0}", TotalReceive);
                    lblGrandDueTotal.Text = string.Format("{0:n0}", GrandTotal);
                    lblTotalWaiedOffSur.Text = string.Format("{0:n0}", TotalWaieOffSurcharge);

                    ds = new AccountStatmentofCustomer();
                    ds.Tables["tbl_AcStatment"].Merge(dst.Tables[0], true, MissingSchemaAction.Ignore);
                    ds.Tables["tbl_FileInformation"].Merge(dst.Tables[1], true, MissingSchemaAction.Ignore);

                    //if(txtFileNo.Text == "B/RES/1679")
                    //{
                    //    DataRow row = ds.Tables["tbl_AcStatment"].NewRow();
                    //    row["PlanID"] = 0;
                    //    row["Descp"] = "Surcharge Adjustment";
                    //    row["InstallmentMode"] = "Surcharge Adjustment";
                    //    row["DueAmount"] = 0;
                    //    row["DueDate"] = Convert.ToDateTime("2020-08-07");
                    //    row["ReceAmount"] = 0;
                    //    row["Outstanding"] = 0;
                    //    row["TotalPaidSurcharge"] = 0;
                    //    row["TotalDueSurcharge"] = 174760;
                    //    row["TotalWaiveOffSurcharge"] = 0;
                    //    row["PaidSurcharge"] = 0;
                    //    ds.Tables["tbl_AcStatment"].Rows.Add(row);
                    //}




                    dst = null;
                    btnPrint.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attention");
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if(ds.Tables.Count > 0)
            {

               string flno = ds.Tables["tbl_FileInformation"].Rows[0]["FileNo"].ToString();
               SqlParameter[] parameter =
               {
                    new SqlParameter("@Task","CheckMembershipForPrintPermission"),
                    new SqlParameter("@FileNo",flno)
               };
               DataSet FileStatus = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Membership", parameter);
                if(FileStatus.Tables.Count > 0)
                {
                    if(FileStatus.Tables[0].Rows.Count > 0)
                    {
                        int chksts = Convert.ToInt32(FileStatus.Tables[0].Rows[0]["CheckStatus"].ToString());
                        if(chksts == 1)
                        {
                            int usid = clsUser.ID;
                            if( (usid != 35 && chksts >= 1) && (usid != 1041 && chksts >= 1))
                            {
                                MessageBox.Show("Print not allowed, Please contact with administrator.");
                                return;
                            }
                            else
                            {
                                
                            }
                            
                        }
                    }
                }
            }
            // DataSet dstt = ds;
            AccountStatementforCustomerReportViewer obj = new AccountStatementforCustomerReportViewer(ds);
            obj.ShowDialog();
            //AccountforCustomer_Doc.AssociatedObject = grd_AccountStatment;
            btnPrint.Enabled = false;
            //RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            //dialog.Document = AccountforCustomer_Doc;
            //dialog.ShowDialog();


        }

        private void txtFileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnAccountStatmentView_Click(null, null);
            }
        }

        private void radGroupBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
