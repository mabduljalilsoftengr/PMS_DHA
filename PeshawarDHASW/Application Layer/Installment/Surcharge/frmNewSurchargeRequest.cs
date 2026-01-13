using PeshawarDHASW.Helper;
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

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge
{
    public partial class frmNewSurchargeRequest : Telerik.WinControls.UI.RadForm
    {
        public frmNewSurchargeRequest()
        {
            InitializeComponent();
            ApplyTheme(clsUser.ThemeName);
        }
        private string FileNo { get; set; }
        private string applystatus = "";

        public frmNewSurchargeRequest(string fl_no,string str)
        {
            InitializeComponent();
            FileNo = fl_no;
            txtFileNo.Text = fl_no;
            btnAccountStatmentView_Click(null, null);

        }
        
        public frmNewSurchargeRequest(int srpr,string flno,string applysts)
        {
            InitializeComponent();
            txtFileNo.Text = flno;
            btnAccountStatmentView_Click(null,null);
            txtWavierPer.Text = srpr.ToString();
            btnApplySurchargeAtOnce_Click(null, null);
            applystatus = applysts;
        }
        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        public DataSet dst { get; set; }
        //   public AccountStatmentofCustomer ds = new AccountStatmentofCustomer();
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
                            lblRefrenceNo.Text = dst.Tables[1].Rows[0]["RefrenceNo"].ToString();
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
            lblFileStatus.Text = "";lblRefrenceNo.Text = "";
            grd_AccountStatment.DataSource = null;
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
                    else
                    {
                        SqlParameter[] paramlock = {
                            new SqlParameter("@Task","LockStatusCheck"),
                            new SqlParameter("@FileNo",lblFileNo.Text),
                            new SqlParameter("@CNIC",lblCNIC.Text)
                        };
                        int LockStatus = int.Parse(Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierMasterRecord", paramlock).ToString());
                        if (LockStatus > 0)
                        {
                            MessageBox.Show("FileNo: " + lblFileNo.Text + "-- CNIC:" + lblCNIC.Text + " have already request present in system. Please search on FileNo.");
                            ClearForm();
                        }
                        else
                        {
                            #region Calculation
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
                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n---------------\nThis File No is Block for Account Statment View Or This File Have No Plan Attached.", "Attention");
            }
        }

        private void btnAccountStatmentView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnAccountStatmentView_Click(null, null);
            }
        }

        private void txtFileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnAccountStatmentView_Click(null, null);
                foreach (var column in grd_AccountStatment.Columns)
                {
                    column.BestFit();
                }
            }
        }

        private void grd_AccountStatment_CellEndEdit(object sender, GridViewCellEventArgs e)
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

        private void grd_AccountStatment_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {

        }

        private void btnApplySurchargeAtOnce_Click(object sender, EventArgs e)
        {
            decimal WavierVal = 0;
            bool WaverFlag = decimal.TryParse(txtWavierPer.Text, out WavierVal);
            if (WavierVal > -1 && WavierVal < 101)
            {
                foreach (var item in grd_AccountStatment.Rows)
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
                clsPluginHelper.GridColumnBestFit(grd_AccountStatment);
                clsPluginHelper.Summary_Column_Template_Wise_Search(grd_AccountStatment);
            }
            else
            {
                MessageBox.Show("Invalid Value in Waveir Field");
                txtWavierPer.Text = "0";
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
                openFileDialog1.Multiselect = true;
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {

                    string[] files = openFileDialog1.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            obj.MemberImage = Image.FromFile(pngFile);
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }
                    ImageContainer.Add(obj);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ImageSource_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnRemove")
            {
                ///  string ID = e.Row.Cells[""].Value.ToString();
                try
                {
                    if (e.Row == null)
                        return;
                    ImageContainer.RemoveAt(e.RowIndex);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = ImageContainer;
                    if (ImageContainer.Count == 0)
                        ImageSource.DataSource = null;
                }
                catch (Exception)
                {
                    ImageSource.DataSource = null;
                }
            }
        }

        private void btnSurchargeWavierRequest_Click(object sender, EventArgs e)
        {
            try
            {
                int wavierper = 0;
                bool waviercheck = int.TryParse(txtWavierPer.Text, out wavierper);
                if (waviercheck)
                {
                    if (wavierper > 0 && wavierper < 101)
                    {
                        #region Wavier Request Saving
                        DataTable dt = GridtoDatatableConverter(grd_AccountStatment);
                        decimal TotalDueSurcRemaing = 0;
                        decimal WavieOffSurcAmount = 0;
                        decimal DueSurcRemaing = 0;
                        foreach (DataRow item in dt.Rows)
                        {
                            decimal TotalDueRow = 0;
                            bool TotalDueSurcRemaingFlag = decimal.TryParse(item["Outstanding"].ToString(), out TotalDueRow);
                            TotalDueSurcRemaing = TotalDueSurcRemaing + (TotalDueSurcRemaingFlag == true ? TotalDueRow : 0);
                            decimal WavieOffSurc = 0;
                            bool WavieOffSurcAmountFlag = decimal.TryParse(item["NewWavierAmount"].ToString(), out WavieOffSurc);
                            WavieOffSurcAmount = WavieOffSurcAmount + (WavieOffSurcAmountFlag == true ? WavieOffSurc : 0);
                            decimal DueSurc = 0;
                            bool DueSurcRemaingFlag = decimal.TryParse(item["SurchargeDueRemaing"].ToString(), out DueSurc);
                            DueSurcRemaing = DueSurcRemaing + (DueSurcRemaingFlag == true ? DueSurc : 0);
                        }

                        SqlParameter[] paramMaster = 
                        {
                                            new SqlParameter("@Task","NewRequestforWavierOffSurcharge"),
                                            new SqlParameter("@FileNo",lblFileNo.Text),
                                            new SqlParameter("@MemberName",lblName.Text),
                                            new SqlParameter("@CNIC",lblCNIC.Text),
                                            new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(lblPlotNo.Text)),
                                            new SqlParameter("@PlotSize",lblplotsize.Text),
                                            new SqlParameter("@MobileNo",lblMobileno.Text),
                                            new SqlParameter("@Remarks",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtRemarks.Text)),
                                            new SqlParameter("@SurStatus","Pending"),
                                            new SqlParameter("@RequestBy",clsUser.Name),
                                            new SqlParameter("@RequestRemarks",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtRemarks.Text)),
                                            new SqlParameter("@RequestedDate",DateTime.Now),
                                            new SqlParameter("@ApprovedBy",Helper.clsPluginHelper.DbNullIfNullOrEmpty("")),
                                            new SqlParameter("@ApprovedRemarks",Helper.clsPluginHelper.DbNullIfNullOrEmpty("")),
                                            new SqlParameter("@ApprovedDate",Helper.clsPluginHelper.DbNullIfNullOrEmpty("")),
                                            new SqlParameter("@WavierPercent",txtWavierPer.Text),
                                            new SqlParameter("@TotalDueSurcRemaing",TotalDueSurcRemaing),
                                            new SqlParameter("@WavieOffSurcAmount",WavieOffSurcAmount),
                                            new SqlParameter("@DueSurcRemaing",DueSurcRemaing),
                                            new SqlParameter("@SurchargeTillDate",Helper.clsMostUseVars.ServerDateTime),
                                            new SqlParameter("@RefrenceNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(lblRefrenceNo.Text))
                        };
                        int SurchargeMasterID = int.Parse(Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierMasterRecord", paramMaster).ToString());
                        if (SurchargeMasterID > 0)
                        {
                            foreach (DataRow item in dt.Rows)
                            {
                                SqlParameter[] paramDetail = { new SqlParameter("@Task","NewRequestSaving"),
                                 new SqlParameter("@SurMasterID",SurchargeMasterID),
                                 new SqlParameter("@PlanID",item["PlanID"].ToString()),
                                 new SqlParameter("@Descp",item["Descp"].ToString()),
                                 new SqlParameter("@InstallmentMode",item["InstallmentMode"].ToString()),
                                 new SqlParameter("@DueDate",Convert.ToDateTime(item["DueDate"].ToString()).Date),
                                 new SqlParameter("@ReceAmount",item["ReceAmount"].ToString()),
                                 new SqlParameter("@TotalDueSurcharge",item["TotalDueSurcharge"].ToString()),
                                 new SqlParameter("@TotalWaiveoffSurcharge",item["TotalWaiveoffSurcharge"].ToString()),
                                 new SqlParameter("@OutstandingSurcharge",item["Outstanding"].ToString()),
                                 new SqlParameter("@PaidSurcharge",item["PaidSurcharge"].ToString()),
                                 //new SqlParameter("@TotalPaidSurcharge",item["TotalPaidSurcharge"].ToString()),
                                 new SqlParameter("@WavierPer",item["WavieOffInPer"].ToString()),
                                 new SqlParameter("@NewWavierAmount",item["NewWavierAmount"].ToString()),
                                 new SqlParameter("@NewDueSurcRemaing",item["SurchargeDueRemaing"].ToString()),
                                 new SqlParameter("@StatusofSur","Pending"),
                                 new SqlParameter("@Requestedby",clsUser.Name),
                                 new SqlParameter("@DateofRequest",DateTime.Now),
                                 new SqlParameter("@SurchargeTillDate",Helper.clsMostUseVars.ServerDateTime)
                                 };
                                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierDetailRecord", paramDetail);
                                if (result > 0)
                                {
                                    ///MessageBox.Show("Successfully Submitted for Approval.");
                                    if(applystatus == "CallFromNDCCreateForm")
                                    {
                                        /////// Now approve the Waiver Request
                                        SqlParameter[] param = {
                                        new SqlParameter("@Task","SurchargeWavierApproved"),
                                        new SqlParameter("@SurMasterID",SurchargeMasterID),
                                        new SqlParameter("@ApprovedBy",clsUser.Name),
                                        new SqlParameter("@ApprovedRemarks","Approved")
                                        };
                                        int res = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "Surc.USP_tbl_SurchargeWavierMasterRecord", param);
                                        if (res > 0)
                                        {
                                            this.Close();
                                        }
                                  }
                                }
                            }

                            try
                            {
                                foreach (clsMemberImage row in ImageContainer)
                                {
                                    MemoryStream ms = new MemoryStream();
                                    row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                                    Byte[] Image = ms.ToArray();
                                    SqlParameter[] parameters =
                                    {
                                    new SqlParameter("@Task", "Insert"),
                                    new SqlParameter("@SurMasID", SurchargeMasterID),
                                    new SqlParameter("@ImageFile", Image),
                                    new SqlParameter("@ImageName", row.ImageName),
                                    new SqlParameter("@Description", row.Description),
                                    new SqlParameter("@user_ID", clsUser.ID),
                                    };
                                    int re = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_SurchargeWaiverMasterRecord", parameters);

                                }
                                ImageContainer.Clear();
                                ImageSource.DataSource = null;
                                this.Close();
                            }
                            catch (Exception rc)
                            {

                            }
                        }
                        else
                        {
                            MessageBox.Show("Request is Fail Please Try Again.");
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Invalid Value in Waveir Field");
                        txtWavierPer.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Value in Waveir Field");
                    txtWavierPer.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void frmNewSurchargeRequest_Load(object sender, EventArgs e)
        {

        }
    }
}
