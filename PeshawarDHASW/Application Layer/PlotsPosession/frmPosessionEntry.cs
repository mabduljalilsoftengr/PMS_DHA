using PeshawarDHASW.Application_Layer.PlotsPosession;
using PeshawarDHASW.Data_Layer.clsPosession;
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

namespace PeshawarDHASW.Application_Layer.Transfer.PlotsPosession
{
    public partial class frmPosessionEntry : Telerik.WinControls.UI.RadForm
    {
        public DataSet dst { get; set; }
        public frmPosessionEntry()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetInstallmentPlan")
            };
            DataSet ds = cls_dl_posession.Posession_Reader(prm);
            #region DataTable
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("InstNo");
            dt.Columns.Add("DueDate");
            dt.Columns.Add("Amount");
            #endregion
            Decimal receamount = 720000;
            decimal remainingamount = receamount;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string instno = ds.Tables[0].Rows[i]["InstNo"].ToString();
                DateTime duedte = Convert.ToDateTime(ds.Tables[0].Rows[i]["DueDate"].ToString());
                decimal planamount = Convert.ToDecimal(ds.Tables[0].Rows[i]["Amount"].ToString());
                remainingamount = remainingamount - planamount;
                // Insert Data into Plan DataTable
                DataRow row = dt.NewRow();
                row["InstNo"] = instno;
                row["DueDate"] = duedte;
                row["Amount"] = remainingamount;
                dt.Rows.Add(row);
                if (remainingamount < planamount)
                {
                    decimal scndpart = planamount - remainingamount;
                    DataRow row1 = dt.NewRow();
                    row1["InstNo"] = instno;
                    row1["DueDate"] = duedte;
                    row1["Amount"] = scndpart;
                    dt.Rows.Add(row1);
                    // Insert Data into Plan DataTable
                }


            }
            AccountStatement(txtfileno.Text);
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
                    Clear();
                    MessageBox.Show("FileNo is Lock for Account Statement View.");
                }
                if (FileStatus == "0")
                {
                    //lblFileStatus.Text = "Active";
                    ReceiveAdjustment(FileNo);
                    bool isOK = AccountStatmentView(FileNo);
                    if (!isOK)
                        return;

                    int TotalAmount = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("PlanAdjustAmount") != null)//.Where(r => r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                       .Sum(r => r.Field<int>("PlanAdjustAmount"));
                    int Surcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                         .Sum(r => r.Field<int>("Surcharge"));
                    int TotalReceive = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null)
                                        .Sum(r => r.Field<int>("ReceAdjustAmount"));

                    int TotalWaieOffSurcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("TotalWaiveOffSurcharge") != null)
                                                  .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));


                    //Check That Owner Information Exist or Not
                    if (dst.Tables[1].Rows.Count > 0)
                    {
                        dst.Tables[1].Columns.Add("TotalDueSurcharge", typeof(Int32));
                        dst.Tables[1].Columns.Add("TotalDueAmount", typeof(Int32));
                        dst.Tables[1].Columns.Add("TotalRecAmount", typeof(Int32));
                        dst.Tables[1].Columns.Add("TotalWaiveOffSurcharge", typeof(Int32));

                        dst.Tables[1].Rows[0]["TotalDueSurcharge"] = (Int32)Surcharge;
                        dst.Tables[1].Rows[0]["TotalDueAmount"] = (Int32)TotalAmount;
                        dst.Tables[1].Rows[0]["TotalRecAmount"] = (Int32)TotalReceive;
                        dst.Tables[1].Rows[0]["TotalWaiveOffSurcharge"] = (Int32)TotalWaieOffSurcharge;

                    }

                    //Check Dataset value of Surcharge
                    double TotalSurchargePaid = 0;
                    double DueRemaingAmount = 0;
                    double DueSurchAmount = 0;

                    bool res = double.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
                    DueRemaingAmount = TotalAmount - TotalReceive;
                    DueSurchAmount = Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge;
                    // double Refund = TotalSurchargePaid - TotalWaieOffSurcharge;

                    // for Stopping of Surcharge Paid to minus 
                    /// Surcharge 2000 : Paid Surcharge : 2000 : WavierOff: 1000 : 2000-(2000+1000) = -1000


                    double GrandTotal = 0;
                    dst.Tables[0].Rows[0]["TotalPaidSurcharge"] = TotalSurchargePaid;
                    GrandTotal = (DueRemaingAmount + DueSurchAmount);


                    string Total_Due_ReceAmount = string.Format("{0:n0}", TotalAmount);
                    string Total_ReceAmount = string.Format("{0:n0}", TotalReceive);
                    string TotalRemainingDueRece_Amount = string.Format("{0:n0}", DueRemaingAmount);
                    string Total_Due_Surcharge = string.Format("{0:n0}", Surcharge);
                    string TotalSurcPaid = string.Format("{0:n0}", TotalSurchargePaid);
                    string TotalWaiedOffSur = string.Format("{0:n0}", TotalWaieOffSurcharge);
                    string TotalRemaining_DueSurcharge = string.Format("{0:n0}", DueSurchAmount);
                    string GrandDueTotal = string.Format("{0:n0}", GrandTotal);
                    if (TotalAmount == TotalReceive & DueSurchAmount <= 0)
                    {
                        GetOwnerDeatil();
                    }
                    else
                    {
                        Clear();

                        DataTable dt = new DataTable();
                        dt.Clear();
                        dt.Columns.Add("FileNo");
                        dt.Columns.Add("Total_Due_ReceAmount");
                        dt.Columns.Add("Total_ReceAmount");
                        dt.Columns.Add("TotalRemainingDueRece_Amount");
                        dt.Columns.Add("Total_Due_Surcharge");
                        dt.Columns.Add("TotalSurcPaid");
                        dt.Columns.Add("TotalWaiedOffSur");
                        dt.Columns.Add("TotalRemaining_DueSurcharge");
                        dt.Columns.Add("GrandDueTotal");
                        DataRow row = dt.NewRow();
                        row["FileNo"] = FileNo;
                        row["Total_Due_ReceAmount"] = Total_Due_ReceAmount;
                        row["Total_ReceAmount"] = Total_ReceAmount;
                        row["TotalRemainingDueRece_Amount"] = TotalRemainingDueRece_Amount;
                        row["Total_Due_Surcharge"] = Total_Due_Surcharge;
                        row["TotalSurcPaid"] = TotalSurcPaid;
                        row["TotalWaiedOffSur"] = TotalWaiedOffSur;
                        row["TotalRemaining_DueSurcharge"] = TotalRemaining_DueSurcharge;
                        row["GrandDueTotal"] = GrandDueTotal;
                        dt.Rows.Add(row);
                        frrmRepot_DuesRemainingUptoPosesion frm = new frrmRepot_DuesRemainingUptoPosesion(dt);
                        frm.Show();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }
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
                    Clear();
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
                                        Clear();
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
                                           orderby row["PlanID"] ascending, row["AccountHead"] ascending, row["InstallmentMode"] ascending, row["DueDate"] ascending
                                           select row);

                        dst.Tables[0].Merge(DataSorting.AsDataView().ToTable());
                        dst.Tables[1].Merge(CustomerInfo);

                        //  MasterTemplate.DataSource = dtt.DefaultView;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Datatable conversion error.\n" + ex.Message);
                        Clear();
                    }

                }
                else
                {
                    MessageBox.Show("There is no Plan attached against this File No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    return false;
                }
            }
            else
                return true;
            #endregion
            return true;
        }
        private void GetOwnerDeatil()
        {
            if (ValidateMembershipNo() && ValidateFileNo())
            {
                #region code
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","GetOwnerDetail"),
                new SqlParameter("@FileNo",txtfileno.Text),
                new SqlParameter("@MembershipNo",txtmembershipno.Text)
                };
                DataSet ds = cls_dl_posession.Posession_Reader(prm);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblplotno.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                        lblsector.Text = ds.Tables[0].Rows[0]["SectorName"].ToString();
                        lblphase.Text = ds.Tables[0].Rows[0]["PhaseName"].ToString();
                        lblname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        lblfhname.Text = ds.Tables[0].Rows[0]["Father"].ToString();
                        lblplotsize.Text = ds.Tables[0].Rows[0]["PlotSize"].ToString();
                        lblcategory.Text = ds.Tables[0].Rows[0]["Category_Name"].ToString();
                        lblmobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        lblcnic.Text = ds.Tables[0].Rows[0]["NIC"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No data found, please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("No data found, please try again.");
                }
                #endregion
            }
        }
        private void btnuploadimage_Click(object sender, EventArgs e)
        {
            if (ValidateCNIC() && ValidatePlotNo())
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Multiselect = true;
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    frmpic.Image = new Bitmap(openFileDialog1.FileName);

                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (ValidateApplyDate() && ValidateFileNo())
            {

                Cursor.Current = Cursors.WaitCursor;
                Byte[] Imge;
                if (frmpic.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    frmpic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Imge = ms.ToArray();
                }
                else
                {
                    Imge = null;
                }

                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@PlotNo",lblplotno.Text),
                new SqlParameter("@FileNo",txtfileno.Text),
                new SqlParameter("@OwnerCategory",lblcategory.Text),
                new SqlParameter("@PlotSize",lblplotsize.Text),
                new SqlParameter("@Sector",lblsector.Text),
                new SqlParameter("@Phase",lblphase.Text),
                new SqlParameter("@MembershipNo",txtmembershipno.Text),
                new SqlParameter("@Name",lblname.Text),
                new SqlParameter("@FH_name",lblfhname.Text),
                new SqlParameter("@CNIC",lblcnic.Text),
                new SqlParameter("@MobileNo",lblmobileno.Text),
                new SqlParameter("@Date",dtpdate.Value.Date),
                new SqlParameter("@Enteredby",Models.clsUser.Name),
                new SqlParameter("@Image",Imge),
                new SqlParameter("@ImageName",DateTime.Now.ToString("yyyyMMdd")+"-1"),
                new SqlParameter("@Description","Attachments of Posession Form Part-1.")

                };
                int rslt = cls_dl_posession.Posession_NonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Posession Form is successfuly inserted.", "Success.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    LoadPsessionData();
                    Cursor.Current = Cursors.Default;
                }
            }
        }
        private void Clear()
        {
            txtfileno.Text = "";
            txtmembershipno.Text = "";
            lblplotno.Text = "";
            lblsector.Text = "";
            lblphase.Text = "";
            lblname.Text = "";
            lblfhname.Text = "";
            lblplotsize.Text = "";
            lblcnic.Text = "";
            lblmobileno.Text = "";
            lblcategory.Text = "";
            dtpdate.Text = "";
            if (frmpic.Image != null)
            {
                frmpic.Image.Dispose();
                frmpic.Image = null;
            }
        }

        private void txtfileno_Validating(object sender, CancelEventArgs e)
        {
            ValidateFileNo();
        }
        private bool ValidateFileNo()
        {
            bool bStatus = true;
            if (txtfileno.Text == "")
            {
                errorProvider.SetError(txtfileno, "Please enter File No.");
                bStatus = false;
            }
            else
                errorProvider.SetError(txtfileno, "");
            return bStatus;
        }
        private void txtmembershipno_Validating(object sender, CancelEventArgs e)
        {
            ValidateMembershipNo();
        }
        private bool ValidateMembershipNo()
        {
            bool bStatus = true;
            if (txtmembershipno.Text == "")
            {
                errorProvider.SetError(txtmembershipno, "Please enter Membership No.");
                bStatus = false;
            }
            else
                errorProvider.SetError(txtmembershipno, "");
            return bStatus;
        }
        private void frmPosessionEntry_Load(object sender, EventArgs e)
        {
            btnVerify.Focus();
            LoadPsessionData();
        }
        private void LoadPsessionData()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetFreshPosessionData")
            };
            DataSet ds = cls_dl_posession.Posession_Reader(prm);
            grdeditdelete.DataSource = ds.Tables[0].DefaultView;
        }

        private void grdeditdelete_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int pid = int.Parse(e.Row.Cells["PID"].Value.ToString());
            if (e.Column.Name == "btnDelete")
            {
                if (MessageBox.Show("Are you sure to delete the posession record.", "Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","deletePosession"),
                    new SqlParameter("@PID",pid)
                    };
                    int rslt = cls_dl_posession.Posession_NonQuery(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Posession record is deleted succesfuly.");
                        LoadPsessionData();
                    }
                }
            }
        }

        private void dtpdate_Validating(object sender, CancelEventArgs e)
        {
            ValidateApplyDate();
        }
        private bool ValidateApplyDate()
        {
            bool bStatus = true;
            if (dtpdate.Text == "")
            {
                errorProvider.SetError(dtpdate, "Please provide apply date.");
                bStatus = false;
            }
            else
                errorProvider.SetError(dtpdate, "");
            return bStatus;
        }

        private void lblplotno_Validating(object sender, CancelEventArgs e)
        {
            ValidatePlotNo();
        }
        private bool ValidatePlotNo()
        {
            bool bStatus = true;
            if (lblplotno.Text == "")
            {
                errorProvider.SetError(lblplotno, "Please provide Plot No.");
                bStatus = false;
            }
            else
                errorProvider.SetError(lblplotno, "");
            return bStatus;
        }
        private void lblcnic_Validating(object sender, CancelEventArgs e)
        {
            ValidateCNIC();
        }
        private bool ValidateCNIC()
        {
            bool bStatus = true;
            if (lblcnic.Text == "")
            {
                errorProvider.SetError(lblcnic, "Please provide CNIC.");
                bStatus = false;
            }
            else
                errorProvider.SetError(lblcnic, "");
            return bStatus;
        }
    }
}
