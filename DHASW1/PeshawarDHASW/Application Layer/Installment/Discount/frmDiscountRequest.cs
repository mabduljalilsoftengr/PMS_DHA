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

namespace PeshawarDHASW.Application_Layer.Installment.Discount
{
    public partial class frmDiscountRequest : Telerik.WinControls.UI.RadForm
    {
        public frmDiscountRequest()
        {
            InitializeComponent();
            btnRequestofDiscount.Enabled = false;
        }

        public string Discount_FileMapKey { get; set; }
        public string Discount_Member { get; set; }

        public DataSet dst { get; set; }
        public DataTable data { get; set; }

        private void ReceiveAdjustment(string FileNo)
        {
            SqlParameter[] prmt =
                   {
                     new SqlParameter("@Task","Rece_Plan_Adjust"),
                     new SqlParameter("@FileNo",FileNo)
                    };
            int rsult = Data_Layer.Installment.cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prmt);

        }

        private void ClearForm()
        {
            lblFileNo.Text = "";
            lblName.Text = "";
            lblFileCategory.Text = "";
            lblDiscountAmt.Text = "";
            txtRemarks_New.Text = "";
            txtMinuteSheetNo.Text = "";
            txtDiscountPercent.Text = "";
            lblLastReceivedDate.Text = "";
            lblRemainingDueAmount.Text = "";
            lblTotalPayable.Text = "";
            lblScheduleDate.Text = "";
            lblSurchargeDue.Text = "";
            lblRemaingAmountforDiscount.Text = "";
            lblDueAmount.Text = "";
            lblTotalPlanAmount.Text = "";
            lblTotalPaidAmount.Text = "";

        }

        private bool AccountStatmentView(string FileNo)
        {
            #region Account Statement Reading
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Account_Statement_Reading"),
                new SqlParameter("@FileNo",FileNo),
                new SqlParameter("@userID",Models.clsUser.ID)
            };
            dst = new DataSet();

            dst = Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);

            if (dst.Tables.Count > 0)
            {
                //Check The FileNo Informatoin Not Entered
                if (dst.Tables[1].Rows.Count > 0)
                {

                }
                else
                {
                    MessageBox.Show("This File No have no Membership Present in System. Kindly Contact to Transfer for Membership Information");
                    //ClearForm();
                }
                // Receive Information have any Receiving or Not.
                if (dst.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    DataTable dtwithNull = new DataTable();
                    if (string.IsNullOrEmpty(dst.Tables[0].Rows[0]["DDReceDate"].ToString()) != true)
                    {
                        dt = dst.Tables[0].Select("DDReceDate IS NOT NULL").CopyToDataTable();
                        var Rows = (from row in dt.AsEnumerable()
                                    orderby row["DDReceDate"] ascending
                                    select row);
                        dt = Rows.AsDataView().ToTable();
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
                                        MessageBox.Show("Receive Information Error \n" + ex.Message + "\n---------\n" + ex.StackTrace);
                                      //  ClearForm();
                                    }
                                }
                            }
                        }
                    }
                    try
                    {



                        DataTable dtt = new DataTable("Table1");
                        if (dt.Rows.Count > 0)
                        {
                            dtt = dt.Copy();
                        }
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
                                           where !row["AccountHead"].ToString().Contains("CP Charges")
                                           orderby row["PlanID"] ascending, row["AccountHead"] ascending, row["InstallmentMode"] ascending, row["DueDate"] ascending
                                           select row);

                        dst.Tables[0].Merge(DataSorting.AsDataView().ToTable());
                        dst.Tables[1].Merge(CustomerInfo);

                        //  MasterTemplate.DataSource = dtt.DefaultView;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Datatable conversion error.\n" + ex.Message);
                      //  ClearForm();
                    }

                }
                else
                {
                    MessageBox.Show("There is no Plan attached against this File No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // ClearForm();
                    return false;
                }
            }
            else
                return true;
            #endregion
            return true;
        }

        private void AccountStatement(string FileNo)
        {
            try
            {
                SqlParameter[] parameter = {
                    new SqlParameter("@Task","FileLockStatus"),
                    new SqlParameter("@FileNo",FileNo),
                    new SqlParameter("@LockbyUser",clsUser.ID)
                };
                string FileStatus = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", parameter).ToString();
                if (FileStatus == "1")
                {
                   // ClearForm();
                    MessageBox.Show("FileNo is Lock for Account Statement View.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void btnFileNo_plotSearch_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","FileOrPlotNoVerification"),
                new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text)),
            };
            DataSet dsInfo = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_ReceDiscount", param);
            if (dsInfo.Tables.Count>0)
            {
                if (dsInfo.Tables[0].Rows.Count>0)
                {
                    lblFileNo.Text = dsInfo.Tables[0].Rows[0]["FileNo"].ToString();
                    lblName.Text = dsInfo.Tables[0].Rows[0]["MemberName"].ToString();
                    lblFileCategory.Text = dsInfo.Tables[0].Rows[0]["Category_Name"].ToString();
                    Discount_FileMapKey = dsInfo.Tables[0].Rows[0]["FileMapKey"].ToString();
                    Discount_Member = dsInfo.Tables[0].Rows[0]["MemberID"].ToString();
                    ReceiveAdjustment(txtFileNo.Text);
                    AccountStatement(txtFileNo.Text);
                }
            }
        }

        private void frmDiscountRequest_Load(object sender, EventArgs e)
        {
            DiscountType.SelectedIndex = 0;
            btnRefresh_Click(null, null);
        }

        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();
        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {
            try
            {
                int imageCount = ImageContainer.Count() + 1;
                clsMemberImage obj = new clsMemberImage();
                obj.ImageName = DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                obj.Description = "Attachment with Discount.";

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

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

        private void ImageSource_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnRemove")
            {
                try
                {
                    ImageContainer.RemoveAt(e.RowIndex);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                    if (ImageContainer.Count == 0)
                        ImageSource.DataSource = null;
                }
                catch (Exception)
                {
                    ImageSource.DataSource = null;
                }
            }
        }



        private void btn_tfr_new_owner_Click(object sender, EventArgs e)
        {
            if (ImageContainer.Count>0 &  Discount_FileMapKey != "" & Discount_Member != "")
            {
                if (MessageBox.Show("Are you Sure","Attention",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    int DiscountAmount;
                    string Number = "";
                    bool NumberCheck = int.TryParse(lblDiscountAmt.Text, out DiscountAmount);
                    if (NumberCheck == true)
                    {
                         Number = Helper.clsPluginHelper.Convert_Number_To_Text(DiscountAmount, false);
                       
                    }
                    SqlParameter[] param = {
                     new SqlParameter("@Task","NewDiscountRequest"),
                     new SqlParameter("@FileMapKey",Discount_FileMapKey),
                     new SqlParameter("@MemberID",Discount_Member),
                     new SqlParameter("@DateofDiscount",dtpDiscountDate.Value.Date),
                     new SqlParameter("@DiscountAmount",lblDiscountAmt.Text),
                     new SqlParameter("@AmountinWords",Number),
                     new SqlParameter("@RequestedBy",clsUser.ID),
                     new SqlParameter("@RequestRemarks",txtRemarks_New.Text),
                     new SqlParameter("@MinuteSheetNo",txtMinuteSheetNo.Text),
                     new SqlParameter("@DiscountPercentage",txtDiscountPercent.Text),
                     new SqlParameter("@EligibleCriteria",lblPercent.Text),
                     new SqlParameter("@LastReceiptDate",lblLastReceivedDate.Text),
                     new SqlParameter("@PastDueRemaining",lblRemainingDueAmount.Text),
                     new SqlParameter("@RemainingPayable",lblTotalPayable.Text),//Owner to Pay
                     new SqlParameter("@ScheduleDueDate",lblScheduleDate.Text),
                     new SqlParameter("@Surcharge",lblSurchargeDue.Text),
                     new SqlParameter("@TotalAmountForDiscount",lblRemaingAmountforDiscount.Text),
                     new SqlParameter("@TotalDueAmount",lblDueAmount.Text),
                     new SqlParameter("@TotalPlanAmount",lblTotalPlanAmount.Text),
                     new SqlParameter("@TotalReceiveAmount",lblTotalPaidAmount.Text),
                     new SqlParameter("@DiscountType",DiscountType.SelectedItem.Text),
                     
                     };
                    string DiscountRqID = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_ReceDiscount", param).ToString();
                    if (DiscountRqID != "")
                    {
                        //Uploading Images
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
                                new SqlParameter("@DiscountRqID", DiscountRqID),
                                new SqlParameter("@ImageFile", Image),
                                new SqlParameter("@ImageName", row.ImageName),
                                new SqlParameter("@Description", row.Description),
                                new SqlParameter("@user_ID", clsUser.ID),
                            };
                                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "USP_tbl_ReceDiscountImage", parameters);

                            }
                            ImageContainer.Clear();
                            ImageSource.DataSource = null;

                        }
                        catch (Exception rc)
                        {
                        }
                        //Clearing
                        btnRefresh_Click(null, null);
                        Discount_FileMapKey = "";
                        Discount_Member = "";
                        ImageContainer.Clear();
                        Discount_FileMapKey ="";
                        Discount_Member = "";
                        
                        txtRemarks_New.Text = "";
                        txtMinuteSheetNo.Text = "";
                        SqlParameter[] Parameterforreprt = {
                            new SqlParameter("@Task","DiscountReportforSingle"),
                            new SqlParameter("@DiscountRqID",DiscountRqID)            
                        };
                        DataSet ds = new DataSet();
                        ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_ReceDiscount", Parameterforreprt);
                        frmDiscountReport obj = new frmDiscountReport(ds);
                        obj.ShowDialog();

                        ClearForm();
                    }
                }
              
            }
            else
            {
                MessageBox.Show("Please Attach the Image or Discount Amount,FileNo Field is Empty or Invalid.");
            }
        }

        private void txtFileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFileNo_plotSearch_Click(null, null);
            }
        }

        private void txtPlotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFileNo_plotSearch_Click(null, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = { new SqlParameter("@Task", "GetAllDiscountRecords") };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_ReceDiscount", param);
            grdAllDiscountInfo.DataSource = ds.Tables[0].DefaultView;
            foreach (GridViewDataColumn column in grdAllDiscountInfo.Columns)
            {
                column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
            }
        }

        private void MasterTemplate_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnViewImage")
            {
                try
                {
                    int DiscountRqID = int.Parse(grdAllDiscountInfo.Rows[grdAllDiscountInfo.CurrentCell.RowIndex].Cells["DiscountRqID"].Value.ToString()); // ReceID
                    string DiscountStatus = grdAllDiscountInfo.Rows[grdAllDiscountInfo.CurrentCell.RowIndex].Cells["DiscountStatus"].Value.ToString(); // ReceID
                    SqlParameter[] param =
                               {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@DiscountRqID",DiscountRqID)
                 };
                    DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "USP_tbl_ReceDiscountImage", param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer("Discount", DiscountStatus, DiscountRqID.ToString(), ds.Tables[0]);
                            obj.Show();
                        }
                        else
                        {
                            MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                }
            }
            if (e.Column.Name == "ReportView")
            {
                int DiscountRqID = int.Parse(grdAllDiscountInfo.Rows[grdAllDiscountInfo.CurrentCell.RowIndex].Cells["DiscountRqID"].Value.ToString()); // ReceID
                SqlParameter[] Parameterforreprt = {
                            new SqlParameter("@Task","DiscountReportforSingle"),
                            new SqlParameter("@DiscountRqID",DiscountRqID)
                        };
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_ReceDiscount", Parameterforreprt);
                frmDiscountReport obj = new frmDiscountReport(ds);
                obj.ShowDialog();
            }
            if (e.Column.Name == "Correction")
            {
                int DiscountRqID = int.Parse(grdAllDiscountInfo.Rows[grdAllDiscountInfo.CurrentCell.RowIndex].Cells["DiscountRqID"].Value.ToString()); // ReceID
                string FileNo = grdAllDiscountInfo.Rows[grdAllDiscountInfo.CurrentCell.RowIndex].Cells["FileNo"].Value.ToString();
                string DateofDiscount = grdAllDiscountInfo.Rows[grdAllDiscountInfo.CurrentCell.RowIndex].Cells["DateofDiscount"].Value.ToString();
                string DiscountStatus = grdAllDiscountInfo.Rows[grdAllDiscountInfo.CurrentCell.RowIndex].Cells["DiscountStatus"].Value.ToString(); // ReceID
                if (DiscountStatus=="Pending")
                {
                    CorrectionForm obj = new CorrectionForm(DiscountRqID.ToString());
                    obj.ShowDialog();
                    this.radPageView1.SelectedPage = this.radPageViewPage2;
                    txtFileNo.Text = FileNo;
                    btnFileNo_plotSearch_Click(null, null);
                    dtpDiscountDate.Value = DateTime.Parse(DateofDiscount);
                    btnDiscountCalculation_Click(null, null);
                    btnRefresh_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Discount is Appoved OR Cancelled Cannot be Change Further.");
                }
               
            }
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdAllDiscountInfo);
        }

        private void txtFileNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDiscountCalculation_Click(object sender, EventArgs e)
        {
            txtDiscountPercent.Text = "5";
            SqlParameter[] parameter = {
                    new SqlParameter("@Task","FileLockStatus"),
                    new SqlParameter("@FileNo",txtFileNo.Text),
                    new SqlParameter("@LockbyUser",clsUser.ID)
                };
            string FileStatus = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", parameter).ToString();
            if (FileStatus == "1")
            {
                //ClearForm();
                MessageBox.Show("File No is Lock.");
            }
            if (FileStatus == "0")
            {
                //lblFileStatus.Text = "Active";
                ReceiveAdjustment(txtFileNo.Text);
                bool isOK = AccountStatmentView(txtFileNo.Text);
                if (!isOK)
                    return;
                #region Full Discount
                if (DiscountType.SelectedItem.Text == "Full")
                {

                    try
                    {

                   

                    int TotalDueAmountofPlan = dst.Tables[0].AsEnumerable()
                                                   .Sum(r => r.Field<int>("PlanAdjustAmount"));

                    DateTime DateInstallment = dst.Tables[0].AsEnumerable()
                            .Where(r => r.Field<DateTime?>("DueDate") <= dtpDiscountDate.Value.Date )
                            .Max(r => r.Field<DateTime>("DueDate"));

                        int count = dst.Tables[0].Rows.Count;
                        int Nullablecount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DDReceDate") == null).Count();
                        int NotNullableCount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DDReceDate") != null).Count();
                        bool DDReceDateisNull = count == Nullablecount ? true : false;


                        DateTime? DDRECEDATE= null;
                        int TotalReceive = 0;
                        int TotalReceiveUptoCurrentDate = 0;
                        if (DDReceDateisNull == false)
                        {
                            DDRECEDATE = dst.Tables[0].AsEnumerable().Where(r => (r.Field<DateTime?>("DDReceDate") != null && r.Field<DateTime>("DDReceDate") <= dtpDiscountDate.Value.Date))
                                              .OrderBy(x => x.Field<DateTime?>("DDReceDate"))
                                              .Max(r => r.Field<DateTime>("DDReceDate"));
                            TotalReceive = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null
                                           && r.Field<DateTime>("DDReceDate") <= DDRECEDATE
                                           ).Sum(r => r.Field<int>("ReceAdjustAmount"));
                            // Till Current Date Total Receieve 
                            TotalReceiveUptoCurrentDate = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null && r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                            .Sum(r => r.Field<int>("ReceAdjustAmount"));

                            lblLastReceivedDate.Text = DDRECEDATE == null ? "" : DDRECEDATE?.ToString("yyyy-MM-dd");

                        }

                        

                        // Total Receieve Upto Current + Onward in Case of Advance Payment
                       

                    // Till Current Surcharge
                    int Surcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                         .Sum(r => r.Field<int>("Surcharge"));

                    // Total WaiverOff Surcharge
                    int TotalWaieOffSurcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("TotalWaiveOffSurcharge") != null)
                                                  .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));
                    decimal TotalSurchargePaid = 0;
                    bool res = decimal.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
                    decimal DueSurchAmount = Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge;


                    lblScheduleDate.Text = DateInstallment.ToString("yyyy-MM-dd");
 
                    //Total Plan Amount 2250000
                    lblTotalPlanAmount.Text = TotalDueAmountofPlan.ToString();
                    //Only Amount that Due Filter by Discount Date
                    DateTime DiscountDate = dtpDiscountDate.Value.Date;
                    // Till Current Date Total Due Amount
                    int TotalAmount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DiscountDate)
                                       .Sum(r => r.Field<int>("PlanAdjustAmount"));
                    lblDueAmount.Text = TotalAmount.ToString();

                    lblTotalPaidAmount.Text = TotalReceive.ToString();
                    decimal RemaingDues = (TotalAmount - TotalReceive) > 0 ? (TotalAmount - TotalReceive) : 0;

                    lblRemainingDueAmount.Text = RemaingDues.ToString();


                    decimal Total_DeductionAmount = (TotalReceive > TotalAmount ? TotalAmount : TotalReceive) + RemaingDues;


                    decimal RemainingAmount = TotalDueAmountofPlan - Total_DeductionAmount;
                    decimal Percentage = Math.Round((RemainingAmount / TotalDueAmountofPlan) * 100, 2);
                    if (Percentage > 40)
                    {
                        lblPercent.ForeColor = Color.Green;
                        btnRequestofDiscount.Enabled = true;
                    }
                    else
                    {
                        lblPercent.ForeColor = Color.Black;
                        btnRequestofDiscount.Enabled = false;
                    }
                    lblPercent.Text = Percentage.ToString();
                    lblRemaingAmountforDiscount.Text = RemainingAmount.ToString();
                    decimal Discount = 0;
                    decimal DistAmt = 0;
                    bool DiscountFlag = decimal.TryParse(txtDiscountPercent.Text, out Discount);
                    if (DiscountFlag == false)
                    {
                        MessageBox.Show("Invalid Discount Percentage");
                    }
                    else
                    {
                        DistAmt = (Discount / 100) * RemainingAmount;
                        lblDiscountAmt.Text = DistAmt.ToString();
                        lblTotalPayableAmount.Text = (RemainingAmount - DistAmt).ToString();
                    }

                    decimal NetPayable_After = RemainingAmount - DistAmt;
                    lblNetPayable.Text = NetPayable_After.ToString();
                    lblPreviousDue.Text = RemaingDues.ToString();
                    decimal AdvancePayment = 0;
                    AdvancePayment = TotalAmount < TotalReceive ? TotalReceive - TotalAmount : 0;
                    lblAdvancePayment.Text = AdvancePayment.ToString();
                    lblSurchargeDue.Text = DueSurchAmount.ToString();
                    decimal TotalNetPayable = (NetPayable_After + RemaingDues + DueSurchAmount) - AdvancePayment;
                    lblTotalPayable.Text = TotalNetPayable.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Plan or Date is Selected. "+ex.Message);
                    }
                }
                #endregion

                #region Discount on Installment Only
                if (DiscountType.SelectedItem.Text == "Installment")
                {

                    try
                    {
                        int InstallmentExists = dst.Tables[0].AsEnumerable().Where(r => r.Field<String>("InstallmentMode").Equals("Installment")).Count();

                        if (InstallmentExists == 0)
                        {
                            MessageBox.Show("Invalid Date Selected OR Installment Not Exist");
                            return;
                        }
                        int TotalDueAmountofPlan = dst.Tables[0].AsEnumerable().Where(r => r.Field<String>("InstallmentMode").Equals("Installment"))
                                                       .Sum(r => r.Field<int>("PlanAdjustAmount"));

                        DateTime DateInstallment = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DueDate") <= dtpDiscountDate.Value.Date
                        ).Max(r => r.Field<DateTime>("DueDate"));

                        int count = dst.Tables[0].Rows.Count;
                        int Nullablecount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DDReceDate") == null).Count();
                        int NotNullableCount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DDReceDate") != null).Count();
                        decimal DueSurchAmount = 0;
                        bool DDReceDateisNull = count == Nullablecount ? true : false;


                        DateTime? DDRECEDATE = null;
                        int TotalReceive = 0;
                        int TotalReceiveUptoCurrentDate = 0;

                        bool DDReceDateisNull1 = count == Nullablecount ? true : false;
                        if (DDReceDateisNull1 == false)
                        {
                            DDRECEDATE = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DDReceDate") != null
                            && r.Field<DateTime>("DDReceDate") <= dtpDiscountDate.Value.Date
                            && r.Field<String>("InstallmentMode").Equals("Installment"))
                                .OrderBy(x => x.Field<DateTime?>("DDReceDate"))
                                .Max(r => r.Field<DateTime>("DDReceDate"));

                            // Total Receieve Upto Current + Onward in Case of Advance Payment
                            TotalReceive = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null
                           && r.Field<DateTime>("DDReceDate") <= DDRECEDATE
                           && r.Field<String>("InstallmentMode").Equals("Installment")
                           ).Sum(r => r.Field<int>("ReceAdjustAmount"));

                            // Till Current Date Total Receieve 
                            TotalReceiveUptoCurrentDate = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null
                           && r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime
                           && r.Field<String>("InstallmentMode").Equals("Installment"))
                                               .Sum(r => r.Field<int>("ReceAdjustAmount"));

                            // Till Current Surcharge
                            int Surcharge = dst.Tables[0].AsEnumerable().Where(r =>
                            r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime
                            && r.Field<String>("InstallmentMode").Equals("Installment"))
                                                 .Sum(r => r.Field<int>("Surcharge"));

                            // Total WaiverOff Surcharge
                            int TotalWaieOffSurcharge = dst.Tables[0].AsEnumerable().Where(r =>
                            r.Field<int?>("TotalWaiveOffSurcharge") != null
                            && r.Field<String>("InstallmentMode").Equals("Installment"))
                                                          .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));
                            decimal TotalSurchargePaid = 0;
                            bool res = decimal.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
                             DueSurchAmount = Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge;


                            lblScheduleDate.Text = DateInstallment.ToString("yyyy-MM-dd");
                            lblLastReceivedDate.Text = DDRECEDATE == null ? "" : DDRECEDATE?.ToString("yyyy-MM-dd");
                        }
                            //Total Plan Amount 2250000
                            lblTotalPlanAmount.Text = TotalDueAmountofPlan.ToString();
                            //Only Amount that Due Filter by Discount Date
                            DateTime DiscountDate = dtpDiscountDate.Value.Date;
                            // Till Current Date Total Due Amount
                            int TotalAmount = dst.Tables[0].AsEnumerable().Where(r =>
                            r.Field<DateTime>("DueDate") <= DiscountDate &&
                            r.Field<String>("InstallmentMode").Equals("Installment"))
                                               .Sum(r => r.Field<int>("PlanAdjustAmount"));
                            lblDueAmount.Text = TotalAmount.ToString();

                            lblTotalPaidAmount.Text = TotalReceive.ToString();
                            decimal RemaingDues = (TotalAmount - TotalReceive) > 0 ? (TotalAmount - TotalReceive) : 0;

                            lblRemainingDueAmount.Text = RemaingDues.ToString();


                            decimal Total_DeductionAmount = (TotalReceive > TotalAmount ? TotalAmount : TotalReceive) + RemaingDues;


                            decimal RemainingAmount = TotalDueAmountofPlan - Total_DeductionAmount;
                            decimal Percentage = Math.Round((RemainingAmount / TotalDueAmountofPlan) * 100, 2);
                            if (Percentage > 40)
                            {
                                lblPercent.ForeColor = Color.Green;
                                btnRequestofDiscount.Enabled = true;
                            }
                            else
                            {
                                lblPercent.ForeColor = Color.Black;
                                btnRequestofDiscount.Enabled = false;
                            }
                            lblPercent.Text = Percentage.ToString();
                            lblRemaingAmountforDiscount.Text = RemainingAmount.ToString();
                            decimal Discount = 0;
                            decimal DistAmt = 0;
                            bool DiscountFlag = decimal.TryParse(txtDiscountPercent.Text, out Discount);
                            if (DiscountFlag == false)
                            {
                                MessageBox.Show("Invalid Discount Percentage");
                            }
                            else
                            {
                                DistAmt = (Discount / 100) * RemainingAmount;
                                lblDiscountAmt.Text = DistAmt.ToString();
                                lblTotalPayableAmount.Text = (RemainingAmount - DistAmt).ToString();
                            }

                            decimal NetPayable_After = RemainingAmount - DistAmt;
                            lblNetPayable.Text = NetPayable_After.ToString();
                            lblPreviousDue.Text = RemaingDues.ToString();
                            decimal AdvancePayment = 0;
                            AdvancePayment = TotalAmount < TotalReceive ? TotalReceive - TotalAmount : 0;
                            lblAdvancePayment.Text = AdvancePayment.ToString();
                            lblSurchargeDue.Text = DueSurchAmount.ToString();
                            decimal TotalNetPayable = (NetPayable_After + RemaingDues + DueSurchAmount) - AdvancePayment;
                            lblTotalPayable.Text = TotalNetPayable.ToString();
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Installment is not Exist in the Select Date." + ex.Message);
                    }
                
                     
                }
                #endregion

                #region Discount on Development Charges
                if (DiscountType.SelectedItem.Text == "Development Charges")
                {
                    try
                    {
                       int DevelopChargesExists =  dst.Tables[0].AsEnumerable().Where(r => r.Field<String>("InstallmentMode").Equals("Development Charge")).Count();

                        if (DevelopChargesExists ==0)
                        {
                            MessageBox.Show("Invalid Date Selected OR Development Charges Not Exist");
                            return;
                        }
                        int TotalDueAmountofPlan = dst.Tables[0].AsEnumerable().Where(r => r.Field<String>("InstallmentMode").Equals("Development Charge") && !r.Field<String>("AccountHead").Contains("KPK Sales tax"))
                                                    .Sum(r => r.Field<int>("PlanAdjustAmount"));

                        int count = dst.Tables[0].Rows.Count;
                        int Nullablecount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DDReceDate") == null).Count();
                        int NotNullableCount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DDReceDate") != null).Count();
                        decimal DueSurchAmount = 0;
                        bool DDReceDateisNull = count == Nullablecount ? true : false;


                        DateTime? DDRECEDATE = null;
                        int TotalReceive = 0;
                        int TotalReceiveUptoCurrentDate = 0;

                        bool DDReceDateisNull2 = count == Nullablecount ? true : false;
                        if (DDReceDateisNull2 == false)
                        {
                            DateTime DateInstallment = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DueDate") <= dtpDiscountDate.Value.Date
                        && r.Field<String>("InstallmentMode").Equals("Development Charge")).Max(r => r.Field<DateTime>("DueDate"));
                            DDRECEDATE = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DDReceDate") != null
                           && r.Field<String>("InstallmentMode").Equals("Development Charge")
                           && r.Field<DateTime>("DDReceDate") <= dtpDiscountDate.Value.Date
                           ).OrderBy(x => x.Field<DateTime?>("DDReceDate")).Max(r => r.Field<DateTime>("DDReceDate"));

                            // Total Receieve Upto Current + Onward in Case of Advance Payment
                            TotalReceive = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null
                           && r.Field<String>("InstallmentMode").Equals("Development Charge")
                           && r.Field<DateTime>("DDReceDate") <= DDRECEDATE
                           ).Sum(r => r.Field<int>("ReceAdjustAmount"));
                            // Till Current Date Total Receieve 
                            TotalReceiveUptoCurrentDate = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null
                           && r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime
                           && r.Field<String>("InstallmentMode").Equals("Development Charge"))
                                               .Sum(r => r.Field<int>("ReceAdjustAmount"));

                            // Till Current Surcharge
                            int Surcharge = dst.Tables[0].AsEnumerable().Where(r =>
                            r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime
                            && r.Field<String>("InstallmentMode").Equals("Development Charge"))
                                                 .Sum(r => r.Field<int>("Surcharge"));

                            // Total WaiverOff Surcharge
                            int TotalWaieOffSurcharge = dst.Tables[0].AsEnumerable().Where(r =>
                            r.Field<int?>("TotalWaiveOffSurcharge") != null
                            && r.Field<String>("InstallmentMode").Equals("Development Charge"))
                                                          .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));
                            decimal TotalSurchargePaid = 0;
                            bool res = decimal.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
                             DueSurchAmount = Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge;


                            lblScheduleDate.Text = DateInstallment.ToString("yyyy-MM-dd");
                            lblLastReceivedDate.Text = DDRECEDATE?.ToString("yyyy-MM-dd");
                        }
                            //Total Plan Amount 2250000
                            lblTotalPlanAmount.Text = TotalDueAmountofPlan.ToString();
                            //Only Amount that Due Filter by Discount Date
                            DateTime DiscountDate = dtpDiscountDate.Value.Date;
                            // Till Current Date Total Due Amount
                            int TotalAmount = dst.Tables[0].AsEnumerable().Where(r =>
                            r.Field<DateTime>("DueDate") <= DiscountDate &&
                            r.Field<String>("InstallmentMode").Equals("Development Charge")  /*&& !r.Field<String>("AccountHead").Contains("KPK Sales tax")*/)
                                               .Sum(r => r.Field<int>("PlanAdjustAmount"));
                            lblDueAmount.Text = TotalAmount.ToString();

                            lblTotalPaidAmount.Text = TotalReceive.ToString();
                            decimal RemaingDues = (TotalAmount - TotalReceive) > 0 ? (TotalAmount - TotalReceive) : 0;

                            lblRemainingDueAmount.Text = RemaingDues.ToString();


                            decimal Total_DeductionAmount = (TotalReceive > TotalAmount ? TotalAmount : TotalReceive) + RemaingDues;


                            decimal RemainingAmount = TotalDueAmountofPlan /*- Total_DeductionAmount*/;
                            decimal Percentage = Math.Round((RemainingAmount / TotalDueAmountofPlan) * 100, 2);
                            if (Percentage > 40)
                            {
                                lblPercent.ForeColor = Color.Green;
                                btnRequestofDiscount.Enabled = true;
                            }
                            else
                            {
                                lblPercent.ForeColor = Color.Black;
                                btnRequestofDiscount.Enabled = false;
                            }
                            lblPercent.Text = Percentage.ToString();
                            lblRemaingAmountforDiscount.Text = RemainingAmount.ToString();
                            decimal Discount = 0;
                            decimal DistAmt = 0;
                            bool DiscountFlag = decimal.TryParse(txtDiscountPercent.Text, out Discount);
                            if (DiscountFlag == false)
                            {
                                MessageBox.Show("Invalid Discount Percentage");
                            }
                            else
                            {
                                DistAmt = (Discount / 100) * RemainingAmount;
                                lblDiscountAmt.Text = DistAmt.ToString();
                                lblTotalPayableAmount.Text = (RemainingAmount - DistAmt).ToString();
                            }

                            decimal NetPayable_After = RemainingAmount - DistAmt;
                            lblNetPayable.Text = NetPayable_After.ToString();
                            lblPreviousDue.Text = RemaingDues.ToString();
                            decimal AdvancePayment = 0;
                            AdvancePayment = TotalAmount < TotalReceive ? TotalReceive - TotalAmount : 0;
                            lblAdvancePayment.Text = AdvancePayment.ToString();
                            lblSurchargeDue.Text = DueSurchAmount.ToString();
                            decimal TotalNetPayable = (NetPayable_After + RemaingDues + DueSurchAmount) - AdvancePayment;
                            lblTotalPayable.Text = TotalNetPayable.ToString();
                      
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Development Charges are not in the select Date."+ ex.Message);
                    }
                }
                #endregion

                #region Discount on Additional Developmental Charges
                if (DiscountType.SelectedItem.Text == "Addl Charges")
                {
                    try
                    {
                        int DevelopChargesExists = dst.Tables[0].AsEnumerable().Where(r => r.Field<String>("InstallmentMode").Equals("Additional Development Charges")).Count();

                        if (DevelopChargesExists == 0)
                        {
                            MessageBox.Show("Invalid Date Selected OR Additional Development Charges Not Exist");
                            return;
                        }
                        int TotalDueAmountofPlan = dst.Tables[0].AsEnumerable().Where(r => r.Field<String>("InstallmentMode").Equals("Additional Development Charges") && !r.Field<String>("AccountHead").Contains("KPK Sales tax"))
                                                    .Sum(r => r.Field<int>("PlanAdjustAmount"));

                        int count = dst.Tables[0].Rows.Count;
                        int Nullablecount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DDReceDate") == null).Count();
                        int NotNullableCount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DDReceDate") != null).Count();
                        decimal DueSurchAmount = 0;
                        bool DDReceDateisNull = count == Nullablecount ? true : false;


                        DateTime? DDRECEDATE = null;
                        int TotalReceive = 0;
                        int TotalReceiveUptoCurrentDate = 0;

                        bool DDReceDateisNull2 = count == Nullablecount ? true : false;
                        if (DDReceDateisNull2 == false)
                        {
                            DateTime DateInstallment = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DueDate") <= dtpDiscountDate.Value.Date
                        && r.Field<String>("InstallmentMode").Equals("Additional Development Charges")).Max(r => r.Field<DateTime>("DueDate"));
                            DDRECEDATE = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime?>("DDReceDate") != null
                           && r.Field<String>("InstallmentMode").Equals("Additional Development Charges")
                           && r.Field<DateTime>("DDReceDate") <= dtpDiscountDate.Value.Date
                           ).OrderBy(x => x.Field<DateTime?>("DDReceDate")).Max(r => r.Field<DateTime>("DDReceDate"));

                            // Total Receieve Upto Current + Onward in Case of Advance Payment
                            TotalReceive = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null
                           && r.Field<String>("InstallmentMode").Equals("Additional Development Charges")
                           && r.Field<DateTime>("DDReceDate") <= DDRECEDATE
                           ).Sum(r => r.Field<int>("ReceAdjustAmount"));
                            // Till Current Date Total Receieve 
                            TotalReceiveUptoCurrentDate = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null
                           && r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime
                           && r.Field<String>("InstallmentMode").Equals("Additional Development Charges"))
                                               .Sum(r => r.Field<int>("ReceAdjustAmount"));

                            // Till Current Surcharge
                            int Surcharge = dst.Tables[0].AsEnumerable().Where(r =>
                            r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime
                            && r.Field<String>("InstallmentMode").Equals("Additional Development Charges"))
                                                 .Sum(r => r.Field<int>("Surcharge"));

                            // Total WaiverOff Surcharge
                            int TotalWaieOffSurcharge = dst.Tables[0].AsEnumerable().Where(r =>
                            r.Field<int?>("TotalWaiveOffSurcharge") != null
                            && r.Field<String>("InstallmentMode").Equals("Additional Development Charges"))
                                                          .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));
                            decimal TotalSurchargePaid = 0;
                            bool res = decimal.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
                            DueSurchAmount = Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge;


                            lblScheduleDate.Text = DateInstallment.ToString("yyyy-MM-dd");
                            lblLastReceivedDate.Text = DDRECEDATE?.ToString("yyyy-MM-dd");
                        }
                        //Total Plan Amount 2250000
                        lblTotalPlanAmount.Text = TotalDueAmountofPlan.ToString();
                        //Only Amount that Due Filter by Discount Date
                        DateTime DiscountDate = dtpDiscountDate.Value.Date;
                        // Till Current Date Total Due Amount
                        int TotalAmount = dst.Tables[0].AsEnumerable().Where(r =>
                        r.Field<DateTime>("DueDate") <= DiscountDate &&
                        r.Field<String>("InstallmentMode").Equals("Additional Development Charges")  /*&& !r.Field<String>("AccountHead").Contains("KPK Sales tax")*/)
                                           .Sum(r => r.Field<int>("PlanAdjustAmount"));
                        lblDueAmount.Text = TotalAmount.ToString();

                        lblTotalPaidAmount.Text = TotalReceive.ToString();
                        decimal RemaingDues = (TotalAmount - TotalReceive) > 0 ? (TotalAmount - TotalReceive) : 0;

                        lblRemainingDueAmount.Text = RemaingDues.ToString();


                        decimal Total_DeductionAmount = (TotalReceive > TotalAmount ? TotalAmount : TotalReceive) + RemaingDues;


                        decimal RemainingAmount = TotalDueAmountofPlan /*- Total_DeductionAmount*/;
                        decimal Percentage = Math.Round((RemainingAmount / TotalDueAmountofPlan) * 100, 2);
                        if (Percentage > 40)
                        {
                            lblPercent.ForeColor = Color.Green;
                            btnRequestofDiscount.Enabled = true;
                        }
                        else
                        {
                            lblPercent.ForeColor = Color.Black;
                            btnRequestofDiscount.Enabled = false;
                        }
                        lblPercent.Text = Percentage.ToString();
                        lblRemaingAmountforDiscount.Text = RemainingAmount.ToString();
                        decimal Discount = 0;
                        decimal DistAmt = 0;
                        bool DiscountFlag = decimal.TryParse(txtDiscountPercent.Text, out Discount);
                        if (DiscountFlag == false)
                        {
                            MessageBox.Show("Invalid Discount Percentage");
                        }
                        else
                        {
                            DistAmt = (Discount / 100) * RemainingAmount;
                            lblDiscountAmt.Text = DistAmt.ToString();
                            lblTotalPayableAmount.Text = (RemainingAmount - DistAmt).ToString();
                        }

                        decimal NetPayable_After = RemainingAmount - DistAmt;
                        lblNetPayable.Text = NetPayable_After.ToString();
                        lblPreviousDue.Text = RemaingDues.ToString();
                        decimal AdvancePayment = 0;
                        AdvancePayment = TotalAmount < TotalReceive ? TotalReceive - TotalAmount : 0;
                        lblAdvancePayment.Text = AdvancePayment.ToString();
                        lblSurchargeDue.Text = DueSurchAmount.ToString();
                        decimal TotalNetPayable = (NetPayable_After + RemaingDues + DueSurchAmount) - AdvancePayment;
                        lblTotalPayable.Text = TotalNetPayable.ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Additional Development Charges are not in the select Date." + ex.Message);
                    }
                }
                #endregion
            }
        }

        private void grdAllDiscountInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
