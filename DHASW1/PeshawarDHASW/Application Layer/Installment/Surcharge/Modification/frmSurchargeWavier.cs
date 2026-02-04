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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge.Modification
{
    public partial class frmSurchargeWavier : Telerik.WinControls.UI.RadForm
    {
        public string SurMasterID { get; set; }
        public string Sur_Status { get; set; }
        public frmSurchargeWavier()
        {
            InitializeComponent();
            ApplyTheme(clsUser.ThemeName);
        }

        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        public frmSurchargeWavier(string Sur_Master_ID,string SurStatus)
        {
            InitializeComponent();
            SurMasterID = Sur_Master_ID;
            Sur_Status = SurStatus;
            ApplyTheme(clsUser.ThemeName);
        }
        private void SurchargeWavierDetailLoad()
        {
            grd_AccountStatment.DataSource = null;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","SingleRecordDetailofSurcharge"),
                    new SqlParameter("@SurMasterID",SurMasterID),
                    new SqlParameter("@SurStatus",Sur_Status)
                };
                DataSet ds = new DataSet();
                ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierMasterRecord", param);
                lblFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                lblName.Text = ds.Tables[0].Rows[0]["MemberName"].ToString();
                lblCNIC.Text = ds.Tables[0].Rows[0]["CNIC"].ToString();
                lblMobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                lblplotsize.Text = ds.Tables[0].Rows[0]["PlotSize"].ToString();
                lblPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                grd_AccountStatment.DataSource = ds.Tables[1].DefaultView;
                foreach (var item in grd_AccountStatment.Columns)
                {
                    item.BestFit();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmSurchargeWavier_Load(object sender, EventArgs e)
        {
            SurchargeWavierDetailLoad();
            txtFileNo.Text = lblFileNo.Text;
            txtFileNo.ReadOnly = true;
            // ClearForm();
            btnAccountStatmentView_Click(null, null);
            SurchargeWavierImageLoad();
        }

        private void SurchargeWavierImageLoad()
        {
            SqlParameter[] param =
                              {
                         new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                         new SqlParameter("@SurMasID",SurMasterID)
                     };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_SurchargeWaiverMasterRecord", param);
            ImageSource.DataSource = ds.Tables[0].DefaultView;
        }
        public DataSet dst { get; set; }
        //   public AccountStatmentofCustomer ds = new AccountStatmentofCustomer();
        private bool AccountStatmentView()
        {

            if (this.grdSurchargeWavierModification.SummaryRowsBottom.Count > 0)
            {
                this.grdSurchargeWavierModification.SummaryRowsBottom.Clear();
            }
            grdSurchargeWavierModification.DataSource = null;


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
                            // Remove The Installment and Development Charges Amount from Outstanding only Show Remaing Surcharge
                            if (TotalSurchargePaid == 0)
                            {
                                foreach (DataRow item in dt.Rows)
                                {
                                    double ReceAmount = 0, InstallmentDueAmount = 0, outstandingReceMinus = 0;
                                    bool ReceAmountFlag = double.TryParse(item["ReceAmount"].ToString(), out ReceAmount);
                                    bool InstallmentDueAmountFlag = double.TryParse(item["DueAmount"].ToString(), out InstallmentDueAmount);
                                    bool outstandingReceMinusFlag = double.TryParse(item["Outstanding"].ToString(), out outstandingReceMinus);
                                    double AmountRemaing = InstallmentDueAmount - ReceAmount;
                                    if (ReceAmountFlag && AmountRemaing > 0)
                                    {
                                        item["Outstanding"] = outstandingReceMinus - AmountRemaing;
                                    }

                                }
                            }
                            //
                            if (TotalSurchargePaid > 0)
                            {
                                foreach (DataRow item in dt.Rows)
                                {


                                    if (!string.IsNullOrEmpty(item["Outstanding"].ToString()))
                                    {
                                        try
                                        {
                                            double ReceAmount = 0, InstallmentDueAmount = 0, outstandingReceMinus = 0;
                                            bool ReceAmountFlag = double.TryParse(item["ReceAmount"].ToString(), out ReceAmount);
                                            bool InstallmentDueAmountFlag = double.TryParse(item["DueAmount"].ToString(), out InstallmentDueAmount);
                                            bool outstandingReceMinusFlag = double.TryParse(item["Outstanding"].ToString(), out outstandingReceMinus);
                                            double AmountRemaing = InstallmentDueAmount - ReceAmount;
                                            if (ReceAmountFlag && AmountRemaing > 0)
                                            {
                                                item["Outstanding"] = outstandingReceMinus - AmountRemaing;
                                            }
                                            double outstanding = double.Parse(item["Outstanding"].ToString());
                                            if (TotalSurchargePaid == 0)
                                                continue;

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
                            grdSurchargeWavierModification.DataSource = dst.Tables[0].DefaultView;

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

                            this.grdSurchargeWavierModification.SummaryRowsBottom.Add(summaryRowItem);
                            foreach (var item in grdSurchargeWavierModification.Columns)
                            {
                                item.BestFit();
                            }
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
                    #endregion
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

        private void ClearForm()
        {
            lblName.Text = ""; lblFileNo.Text = ""; lblMobileno.Text = ""; lblplotsize.Text = ""; lblPlotNo.Text = ""; lblCNIC.Text = "";
            lblTotalDue.Text = "0"; lblTotalReceive.Text = "0"; lblDueRemaing.Text = "0"; lblGrandDueTotal.Text = "0";
            lblTotalSurcharge.Text = "0"; lblTotalSurcPaid.Text = "0"; lblTotalWaiedOffSur.Text = "0"; lblDueSurcharge.Text = "0";
            lblFileStatus.Text = "";
            grdSurchargeWavierModification.DataSource = null;
            grdSurchargeWavierModification.SummaryRowsBottom.Clear();
        }
        private void btnAccountStatmentView_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameter = {
                    new SqlParameter("@Task","FileLockStatus"),
                    new SqlParameter("@FileNo",txtFileNo.Text),
                    new SqlParameter("@LockbyUser",clsUser.ID)
                };
                string FileStatus = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", parameter).ToString();
                if (FileStatus == "1")
                {
                    ClearForm();
                    lblFileStatus.Text = "Block";
                }
                if (FileStatus == "0")
                {
                    lblFileStatus.Text = "Active";
                    ReceiveAdjustment();
                    bool isOK = AccountStatmentView();
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

                    //ds = new AccountStatmentofCustomer();
                    //ds.Tables["tbl_AcStatment"].Merge(dst.Tables[0]);
                    //ds.Tables["tbl_FileInformation"].Merge(dst.Tables[1]);
                    //dst = null;
                    //btnPrint.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n---------------\nThis File No is Block for Account Statment View Or This File Have No Plan Attached.", "Attention");
            }
        }

        private void grdSurchargeWavierModification_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "WavieOffInPer")
            {
                try
                {
                    decimal percentage = 0;
                    bool percentageFlag = decimal.TryParse(e.Row.Cells["WavieOffInPer"].Value.ToString(), out percentage);
                    if (percentageFlag)
                    {
                        if (percentage > -1 && percentage < 101)
                        {
                            //btnSaveSurcharge.Enabled = true;
                            try
                            {
                                Decimal currentSurch = 0;
                                if (!string.IsNullOrEmpty(e.Row.Cells["Outstanding"].Value.ToString()))
                                    currentSurch = Decimal.Parse(e.Row.Cells["Outstanding"].Value.ToString());

                                Decimal TotalWav = currentSurch * percentage / 100;
                                Decimal RemaingSurch = currentSurch - TotalWav;
                                e.Row.Cells["NewWavierAmount"].Value = TotalWav;
                                e.Row.Cells["SurchargeDueRemaing"].Value = RemaingSurch;
                                //  e.Row.Cells["SurchargeStatus"].Value = "Pending";
                                //  e.Row.Cells["SurWayOffMasID"].Value = null;
                                //SurWayOffMasID = null;
                                // DGVSurcharge.Refresh();
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                        else
                        {
                            MessageBox.Show("Check your Wavieroff value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //  btnSaveSurcharge.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }


        private void btnApplySurchargeAtOnce_Click(object sender, EventArgs e)
        {
            decimal WavierVal = 0;
            bool WaverFlag = decimal.TryParse(txtWavierPer.Text, out WavierVal);
            if (WavierVal > -1 && WavierVal < 101)
            {
                foreach (var item in grdSurchargeWavierModification.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["Outstanding"].Value.ToString()))
                    {

                        if (item.Cells["Outstanding"].Value.ToString() != "0")
                        {
                            decimal RemaingSurcharge = decimal.Parse(item.Cells["Outstanding"].Value.ToString());
                            item.Cells["WavieOffInPer"].Value = WavierVal;
                            decimal waviewoffamount = (WavierVal / 100) * RemaingSurcharge;
                            item.Cells["NewWavierAmount"].Value = waviewoffamount;
                            decimal RemaingDueSurcharge = RemaingSurcharge - waviewoffamount;
                            item.Cells["SurchargeDueRemaing"].Value = RemaingDueSurcharge;

                        }

                    }
                }
                foreach (var column in grdSurchargeWavierModification.Columns)
                {
                    column.BestFit();
                }
            }
            else
            {
                MessageBox.Show("Invalid Value in Waveir Field");
                txtWavierPer.Text = "0";
            }
        }

        private void btnRequestmodification_Click(object sender, EventArgs e)
        {
            DataTable dt = GridtoDatatableConverter(grdSurchargeWavierModification);
            //SurMasterID
            if (!string.IsNullOrEmpty(SurMasterID))
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","CancelPreviousRequest"),
                    new SqlParameter("@Remarks",txtremarksSur.Text),
                    new SqlParameter("@UserId",clsUser.ID),
                    new SqlParameter("@SurMasterID",SurMasterID)
                };

                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierDetailRecord", param);
                if (result > 0)
                {
                    ///MessageBox.Show("Successfully Submitted for Approval.");
                    foreach (DataRow item in dt.Rows)
                    {

                        SqlParameter[] paramDetail = { new SqlParameter("@Task","NewRequestSaving"),
                                 new SqlParameter("@SurMasterID",SurMasterID),
                                 new SqlParameter("@PlanID",item["PlanID"].ToString()),
                                 new SqlParameter("@Descp",item["Descp"].ToString()),
                                 new SqlParameter("@InstallmentMode",item["InstallmentMode"].ToString()),
                                 new SqlParameter("@DueDate",item["DueDate"].ToString()),
                                 new SqlParameter("@ReceAmount",item["ReceAmount"].ToString()),
                                 new SqlParameter("@TotalDueSurcharge",item["TotalDueSurcharge"].ToString()),
                                 new SqlParameter("@TotalWaiveoffSurcharge",item["TotalWaiveoffSurcharge"].ToString()),
                                 new SqlParameter("@OutstandingSurcharge",item["Outstanding"].ToString()),
                                 new SqlParameter("@PaidSurcharge",item["PaidSurcharge"].ToString()),
                               //  new SqlParameter("@TotalPaidSurcharge",item["TotalPaidSurcharge"].ToString()),
                                 new SqlParameter("@WavierPer",item["WavieOffInPer"].ToString()),
                                 new SqlParameter("@NewWavierAmount",item["NewWavierAmount"].ToString()),
                                 new SqlParameter("@NewDueSurcRemaing",item["SurchargeDueRemaing"].ToString()),
                                 new SqlParameter("@StatusofSur","Pending"),
                                 new SqlParameter("@Requestedby",clsUser.Name),
                                 new SqlParameter("@DateofRequest",DateTime.Now),
                                 new SqlParameter("@SurchargeTillDate",Helper.clsMostUseVars.ServerDateTime)
                            };
                        int resulti = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierDetailRecord", paramDetail);
                        if (result > 0)
                        {
                           //
                        }
                    }
                   SqlParameter[] paramSumary = {
                                new SqlParameter("@Task","AfterWavierModifiedSummaryChange"),
                                new SqlParameter("@SurMasterID",SurMasterID)
                            };
                    int result2 = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierDetailRecord", paramSumary);
                    if (result2 > 0)
                    {
                        MessageBox.Show("Successfully Modified Wavier.");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong Surcharge wavier is not modified successfull contact to IT Branch.");
                    }
                }
                else
                {
                    MessageBox.Show("Surcharge Cannot be Modify because it Already Approved.");
                }


            }
        }
        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();
        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {
            try
            {
                int imageCount = ImageContainer.Count() + 1;
                clsMemberImage obj = new clsMemberImage();
                obj.ImageName = DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                obj.Description = "Attachment with Surcharge Waiver.";

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {

                    byte[] Image = File.ReadAllBytes(openFileDialog1.FileName);

                    SqlParameter[] parameters =
                          {
                            new SqlParameter("@Task", "Insert"),
                            new SqlParameter("@SurMasID", SurMasterID),
                            new SqlParameter("@ImageFile", Image),
                            new SqlParameter("@ImageName","Surcharge Wavier Master ID"+ SurMasterID+DateTime.Now.ToLongDateString()+"User"+clsUser.Name),
                            new SqlParameter("@Description", SurMasterID+DateTime.Now.ToLongDateString()+"User"+clsUser.Name),
                            new SqlParameter("@user_ID", clsUser.ID),
                            };
                    int re = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_SurchargeWaiverMasterRecord", parameters);
                    if (re > 0)
                    {
                        SqlParameter[] param =
                                            {
                         new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                         new SqlParameter("@SurMasID",SurMasterID)
                     };
                        DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_SurchargeWaiverMasterRecord", param);
                        ImageSource.DataSource = ds.Tables[0].DefaultView;
                    }


                    //string[] files = openFileDialog1.FileNames;
                    //foreach (var pngFile in files)
                    //{
                    //    try
                    //    {
                    //        obj.MemberImage = Image.FromFile(pngFile);
                    //    }
                    //    catch
                    //    {
                    //        Console.WriteLine("This is not an image file");
                    //    }
                    //}
                    //ImageContainer.Add(obj);
                    //ImageSource.TableElement.RowHeight = 50;
                    //ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    //ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                }
            }
            catch (Exception ex)
            {
            }
        }

        PictureBox objPrint = new PictureBox();
        private void ImageSource_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnRemove")
            {
                string ImageID = e.Row.Cells["ID"].Value.ToString();
                if (MessageBox.Show("Are you sure to delete this image.", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SqlParameter[] param = {
                    new SqlParameter("@Task","DeleteImages"),
                    new SqlParameter("@ID",ImageID)
                    };
                    int ds = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_SurchargeWaiverMasterRecord", param);
                    if (ds > 0)
                    {
                        SurchargeWavierImageLoad();
                    }
                }
            }
            //Image Reading
            else
            {
                try
                {
                    // long ID = int.Parse(e.Row.Cells["ID"].Value.ToString()); // ReceID

                    byte[] imageData = (byte[])e.Row.Cells["ImageFile"].Value;

                    //Initialize image variable
                    Image newImage;
                    //Read image data into a memory stream
                    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                    {
                        ms.Write(imageData, 0, imageData.Length);
                        //Set image variable value using memory stream.
                        newImage = Image.FromStream(ms, true);
                    }

                    // set picture
                    objPrint.Image = newImage;
                    ImageBox.Image = newImage;
                }
                catch (Exception)
                {
                }

            }
        }

        private DataTable GridtoDatatableConverter(RadGridView Grid)
        {
            DataTable dt = new DataTable();

            // add the columns to the datatable            
            if (Grid.ColumnCount > 0)
            {
                foreach (var item in Grid.Columns)
                {
                    dt.Columns.Add(item.Name.ToString());
                }

            }

            //  add each of the data rows to the table
            foreach (var row in Grid.Rows)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    string val = row.Cells[i].Value != null ? row.Cells[i].Value.ToString().Replace("&nbsp;", "") : "0";
                    if (!string.IsNullOrWhiteSpace(val))
                    {
                        dr[i] = val;
                    }
                    else
                    {
                        dr[i] = "0";
                    }
                }
                dt.Rows.Add(dr);
            }

            ////  add the footer row to the table
            //if (GridView1.FooterRow != null)
            //{
            //    DataRow dr;
            //    dr = dt.NewRow();

            //    for (int i = 0; i < GridView1.FooterRow.Cells.Count; i++)
            //    {
            //        dr[i] = GridView1.FooterRow.Cells[i].Text.Replace("&nbsp;", "");
            //    }
            //    dt.Rows.Add(dr);
            //}
            return dt;
        }
    }
}
