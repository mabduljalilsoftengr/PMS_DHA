using PeshawarDHASW.Application_Layer.Chalan;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using PeshawarDHASW.Report.Challan;
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

namespace PeshawarDHASW.Application_Layer.PlotsPosession
{
    public partial class frmPossessionChallan : Telerik.WinControls.UI.RadForm
    {
        public DataSet dst { get; set; }
        public DataTable data { get; set; }
        private int P_ID { get; set; }
        public frmPossessionChallan()
        {
            InitializeComponent();
          //  chkPossessionCharges.CheckState = CheckState.Checked;
           // chkSecuirtycharges.CheckState = CheckState.Checked;
        }
        public frmPossessionChallan(int pid)
        {
            InitializeComponent();
            P_ID = pid;
            txtPossessionNo.Text = P_ID.ToString();
            chkPossessionCharges.CheckState = CheckState.Checked;
          //  chkSecuirtycharges.CheckState = CheckState.Checked;
        }
       

        private void btnPossessionNoVerify_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = 
            {
                new SqlParameter("@Task","PossessionVerification"),
                new SqlParameter("@PFormNo",txtPossessionNo.Text)
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Posession", param);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    txtfileno.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                    AccountStatement(txtfileno.Text);
                    txtmembershipno.Text = ds.Tables[0].Rows[0]["MembershipNo"].ToString();
                    lblname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    lblfhname.Text = ds.Tables[0].Rows[0]["FH_name"].ToString();
                    lblcnic.Text = ds.Tables[0].Rows[0]["CNIC"].ToString();
                    lblmobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();

                    lblphase.Text = ds.Tables[0].Rows[0]["Phase"].ToString();
                    lblsector.Text = ds.Tables[0].Rows[0]["Sector"].ToString();
                    lblplotno.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                    lblcorner.Text = ds.Tables[0].Rows[0]["Conor"].ToString();
                    if (lblcorner.Text == "Yes")
                    {
                        chkCornerCharges.CheckState = CheckState.Checked;
                    }
                 //   lblMainBouleward.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                 //   lblParkFacing.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    lblPlotSize.Text = ds.Tables[0].Rows[0]["PlotSize"].ToString();
                }
                else
                {
                    MessageBox.Show("Possession No is not Found. Please Confrim Possession No from Transfer Branch.");
                }
            }
            else
            {
                MessageBox.Show("Possession Data is not Found or Possession No is not Entered.");
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
                    ClearForm();
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
                                        ClearForm();
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
                        ClearForm();
                    }

                }
                else
                {
                    MessageBox.Show("There is no Plan attached against this File No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    return false;
                }
            }
            else
                return true;
            #endregion
            return true;
        }
        private void ClearForm()
        {
            lblname.Text = ""; txtfileno.Text = ""; lblmobileno.Text = ""; lblPlotSize.Text = ""; lblplotno.Text = ""; lblcnic.Text = "";
            lblTotalDue.Text = "0"; lblTotalReceive.Text = "0"; lblDueRemaing.Text = "0"; lblGrandDueTotal.Text = "0";
            lblTotalSurcharge.Text = "0"; lblTotalSurcPaid.Text = "0"; lblTotalWaiedOffSur.Text = "0"; lblDueSurcharge.Text = "0";
            //lblFileStatus.Text = "";
          //  MasterTemplate.DataSource = null;
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
                    ClearForm();
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
                    lblTotalSurcPaid.Text = string.Format("{0:n0}", TotalSurchargePaid);
                    lblDueRemaing.Text = string.Format("{0:n0}", DueRemaingAmount);
                    double GrandTotal = 0;
                    dst.Tables[0].Rows[0]["TotalPaidSurcharge"] = TotalSurchargePaid;
                    GrandTotal = (DueRemaingAmount + DueSurchAmount);
                    lblDueSurcharge.Text = string.Format("{0:n0}", DueSurchAmount);


                    lblTotalDue.Text = string.Format("{0:n0}", TotalAmount); ;
                    lblTotalSurcharge.Text = string.Format("{0:n0}", Surcharge);
                    lblTotalReceive.Text = string.Format("{0:n0}", TotalReceive); 
                    lblGrandDueTotal.Text = string.Format("{0:n0}", GrandTotal);
                    lblTotalWaiedOffSur.Text = string.Format("{0:n0}", TotalWaieOffSurcharge);
                    if (TotalAmount == TotalReceive & DueSurchAmount<=0)
                    {
                        //gpOtherCharges.Enabled = true;
                        btnGenerationofChallan.Enabled = true;
                        btnPayInstalandChallan.Enabled = false;
                       
                    }
                    else
                    {
                       // gpOtherCharges.Enabled = false;
                        btnGenerationofChallan.Enabled = false;
                        btnPayInstalandChallan.Enabled = true;
                        MessageBox.Show("Please Clear the Installment and Surcharge of Your File.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void frmPossessionChallan_Load(object sender, EventArgs e)
        {
            btnPossessionNoVerify_Click(sender,e);
            gpOtherCharges.Enabled = true;
        }

        private void btnGenerationofChallan_Click(object sender, EventArgs e)
        {
            try
            {

                bool PosCharges = chkPossessionCharges.CheckState == CheckState.Checked ? true : false;
                bool PosCorner = chkCornerCharges.CheckState == CheckState.Checked ? true : false;
                bool ParkChrges = chkParkfacingCharges.CheckState == CheckState.Checked ? true : false;
                bool drawingChrges = chkdrawingcharges.CheckState == CheckState.Checked ? true : false;
                bool SecurityChrges = chkSecuirtycharges.CheckState == CheckState.Checked ? true : false;
                bool BoulewardCharges = chkMainBoulewardCharges.CheckState == CheckState.Checked ? true : false;
                SqlParameter[] param = {
                new SqlParameter("@Task","SavingPossessionChallan"),
                new SqlParameter("@FileNo",txtfileno.Text),
                new SqlParameter("@PlotNo",lblplotno.Text),
                new SqlParameter("@Sector",lblsector.Text),
                new SqlParameter("@Phase",lblphase.Text),
                new SqlParameter("@MembershipNo",txtmembershipno.Text),
                new SqlParameter("@PlotSizeID",lblPlotSize.Text),
                new SqlParameter("@Name",lblname.Text),
                new SqlParameter("@CNIC",lblcnic.Text),
                new SqlParameter("@PossessionID",txtPossessionNo.Text),
                new SqlParameter("@Remarks",""),
                new SqlParameter("@PossessionCharges",PosCharges),
                new SqlParameter("@CornerCharges",PosCorner),
                new SqlParameter("@ParkFacingCharges",ParkChrges),
                new SqlParameter("@DrawingCharges",drawingChrges),
                new SqlParameter("@SecurityCharges",SecurityChrges),
                new SqlParameter("@MainBoulewardCharges",BoulewardCharges),
                new SqlParameter("@UserID",clsUser.ID)
            };
                DataSet ds  = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Pos.USP_PossessionChallan", param);
                ChallanDataset _ds = new ChallanDataset();

                _ds.Tables["tblChallan"].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                _ds.Tables["tblChallanDetail"].Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                ds = null;
                frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                obj.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPayInstalandChallan_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtfileno.Text))
            {
                Chalan.frmCreateChallan obj = new frmCreateChallan(txtfileno.Text, true);
                obj.Show();
            }
            else
            {
                MessageBox.Show("Please Enter Correct Possession No.");
            }
        }
    }
}
