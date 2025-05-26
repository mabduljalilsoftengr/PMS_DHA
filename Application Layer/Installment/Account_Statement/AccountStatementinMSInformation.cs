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
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.Account_Statement
{
    public partial class AccountStatementinMSInformation : Telerik.WinControls.UI.RadForm
    {
        public AccountStatementinMSInformation()
        {
            InitializeComponent();
        }
        public DataSet dst { get; set; }

        #region Account Statement View
        private bool AccountStatmentView()
        {

            if (this.grd_Acknowledgment.SummaryRowsBottom.Count > 0)
            {
                this.grd_Acknowledgment.SummaryRowsBottom.Clear();
            }
            grd_Acknowledgment.DataSource = null;


            #region Account Statement Reading
            SqlParameter[] prm =
            {
               new SqlParameter("@Task","Account_Statement_Reading"),
               new SqlParameter("@FileNo",txtFileNo.Text),
               new SqlParameter("@userID",Models.clsUser.ID)
            };
            dst = new DataSet();

            dst = Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);
           
            
            if (dst.Tables.Count > 0)
            {
                DataTable dt;
                DataTable dtwithNull;

                dt = dst.Tables[0].Select("DDReceDate IS NOT NULL").CopyToDataTable();

              
                var Rows = (from row in dt.AsEnumerable()
                            orderby row["DDReceDate"] ascending
                            select row);
                dt = Rows.AsDataView().ToTable();
                if (dst.Tables[0].Rows.Count > 0)
                {

                    lblFileNo.Text = dst.Tables[1].Rows[0]["FileNo"].ToString();
                    lblName.Text = dst.Tables[1].Rows[0]["Name"].ToString();
                    lblCNIC.Text = dst.Tables[1].Rows[0]["NIC/NICOP"].ToString();
                    lblMobileno.Text = dst.Tables[1].Rows[0]["MobileNo"].ToString();
                    lblplotsize.Text = dst.Tables[1].Rows[0]["PlotSize"].ToString();
                    lblPlotNo.Text = dst.Tables[1].Rows[0]["PlotNo"].ToString();

                    #region Surcharge Spliting
                    double TotalSurchargePaid = 0;
                    bool res = double.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
                    if (TotalSurchargePaid > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            if (!string.IsNullOrEmpty(item["Outstanding"].ToString()))
                            {
                                try
                                {
                                    if (TotalSurchargePaid == 0)
                                        continue;
                                    double outstanding = double.Parse(item["Outstanding"].ToString());
                                    if (TotalSurchargePaid < outstanding)
                                    {
                                        item["PaidSurcharge"] = TotalSurchargePaid;
                                        item["Outstanding"] = (outstanding - TotalSurchargePaid);
                                    }
                                    TotalSurchargePaid = TotalSurchargePaid - outstanding;

                                    if (TotalSurchargePaid > -1)
                                    {
                                        item["Outstanding"] = "0";
                                    }
                                    if (TotalSurchargePaid > -1)
                                        item["PaidSurcharge"] = outstanding;
                                    else
                                    {
                                        TotalSurchargePaid = 0;
                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }
                    }
                    #endregion


                    DataTable dtt = new DataTable("Table1");
                    dtt = dt.Copy();
                    if (dst.Tables[0].Select("DDReceDate IS  NULL").Count() > 0)
                    {
                        dtwithNull = dst.Tables[0].Select("DDReceDate IS  NULL").CopyToDataTable();
                        dtt.Merge(dtwithNull);
                    }
                   
                    DataTable CustomerInfo = new DataTable("Table");
                    CustomerInfo = dst.Tables[1].Copy();
                    dst.Tables[0].Rows.Clear();
                    dst.Tables[1].Rows.Clear();

                    var DataSorting = (from row in dtt.AsEnumerable()
                                       orderby row["PlanID"] ascending, row["AccountHead"] ascending, row["InstallmentMode"] ascending, row["DueDate"] ascending
                                       select row);

                    dst.Tables[0].Merge(DataSorting.AsDataView().ToTable());
                    dst.Tables[1].Merge(CustomerInfo);

                    grd_Acknowledgment.DataSource = dtt.DefaultView;

                    #region Summary Columns
                    GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                    summaryItem.Name = "PlanAdjustAmount";
                    summaryItem.Aggregate = GridAggregateFunction.Sum;
                    summaryItem.FormatString = "{0:#,###0.00;(#,###0.00);0}";

                    GridViewSummaryItem summaryItem1 = new GridViewSummaryItem();
                    summaryItem1.Name = "ReceAdjustAmount";
                    summaryItem1.Aggregate = GridAggregateFunction.Sum;
                    summaryItem1.FormatString = "{0:#,###0.00;(#,###0.00);0}";

                    GridViewSummaryItem summaryItem3 = new GridViewSummaryItem();
                    summaryItem3.Name = "Surcharge";
                    summaryItem3.Aggregate = GridAggregateFunction.Sum;
                    summaryItem3.FormatString = "{0:#,###0.00;(#,###0.00);0}";

                    GridViewSummaryItem summaryItem4 = new GridViewSummaryItem();
                    summaryItem3.Name = "Outstanding";
                    summaryItem3.Aggregate = GridAggregateFunction.Sum;
                    summaryItem3.FormatString = "{0:#,###0.00;(#,###0.00);0}";

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
                    this.grd_Acknowledgment.SummaryRowsBottom.Add(summaryRowItem);
                    #endregion
                }
                else
                {
                    MessageBox.Show("There is no Plan attached  against this File No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
                return false;
            #endregion
            return true;
        }
        #endregion

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
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameter = {
                    new SqlParameter("@Task","FileLockStatus"),
                    new SqlParameter("@FileNo",txtFileNo.Text),
                    new SqlParameter("@LockbyUser",clsUser.ID)
                };

                int FileLock = int.Parse(Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", parameter).ToString());
                if (FileLock > 0)
                {
                    SqlParameter[] DataInfo = {
                    new SqlParameter("@Task","FileLockInfo"),
                    new SqlParameter("@FileNo",txtFileNo.Text)
                   };
                    string FileStatus = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", parameter).ToString();
                    lblFileStatus.Text =  "Block";
                    grd_Acknowledgment.DataSource = null;
                    // MessageBox.Show("This File is Block Account Statement View.");
                }
                else
                {
                    SqlParameter[] DataInfo = {
                    new SqlParameter("@Task","FileLockInfo"),
                    new SqlParameter("@FileNo",txtFileNo.Text)
                   };
                    string FileStatus = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", parameter).ToString();
                    lblFileStatus.Text = "Active";
                    ReceiveAdjustment();
                    bool isOK = AccountStatmentView();
                    if (!isOK)
                        return;
                    int TotalAmount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                                       .Sum(r => r.Field<int>("PlanAdjustAmount"));
                    int Surcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                                         .Sum(r => r.Field<int>("Surcharge"));
                    int TotalReceive = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null)
                                        .Sum(r => r.Field<int>("ReceAdjustAmount"));

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

                    lblDueSurcharge.Text = string.Format("{0:n0}", DueSurchAmount);
                    lblTotalSurcPaid.Text = string.Format("{0:n0}", TotalSurchargePaid);
                    lblDueRemaing.Text = string.Format("{0:n0}", DueRemaingAmount);

                    double GrandTotal = (DueRemaingAmount + DueSurchAmount);

                    lblTotalDue.Text = string.Format("{0:n0}", TotalAmount); ;
                    lblTotalSurcharge.Text = string.Format("{0:n0}", Surcharge);
                    lblTotalReceive.Text = string.Format("{0:n0}", TotalReceive);
                    lblGrandDueTotal.Text = string.Format("{0:n0}", GrandTotal);
                    lblTotalWaiedOffSur.Text = string.Format("{0:n0}", TotalWaieOffSurcharge);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("This File is Block for View the Account Statement.");
            }
          
        }

        private void AccountStatementinMSInformation_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            AccountStatementinMSInforReportViewer obj = new AccountStatementinMSInforReportViewer(dst);
            obj.ShowDialog();
        }

        private void txtFileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFind_Click(null, null);
            }
        }
    }
}
