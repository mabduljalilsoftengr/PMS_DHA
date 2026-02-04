using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using PeshawarDHASW.Helper;
using Telerik.WinControls.UI;
using System.Drawing.Printing;
using PeshawarDHASW.Application_Layer.Installment.AcknowledgmentSearch.Account_Statement_Report;
using PeshawarDHASW.Models;
using System.Linq;
using PeshawarDHASW.Data_Layer.clsMemberShip;

namespace PeshawarDHASW.Application_Layer.Installment
{
    public partial class frmAccountStatement : Telerik.WinControls.UI.RadForm
    {
        public DataSet dst { get; set; }
        public DataTable data { get; set; }
        public frmAccountStatement()
        {
            InitializeComponent();
        }

        public frmAccountStatement(string FileNo)
        {
            InitializeComponent();
            txtFileNo.Text = FileNo;
            btnFind_Click(null, null);
        }

        Report.Datasets.Sample.AcknowledgementReport dsAck { get; set; }
        private void txtFileNo_Leave(object sender, EventArgs e)
        {

        }
        private bool AccountStatmentView()
        {
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
                //Check The FileNo Informatoin Not Entered
                if (dst.Tables[1].Rows.Count > 0)
                {
                    lblFileNo.Text = dst.Tables[1].Rows[0]["FileNo"].ToString();
                    lblName.Text = dst.Tables[1].Rows[0]["Name"].ToString();
                    lblCNIC.Text = dst.Tables[1].Rows[0]["NIC/NICOP"].ToString();
                    lblMobileno.Text = dst.Tables[1].Rows[0]["MobileNo"].ToString();
                    lblplotsize.Text = dst.Tables[1].Rows[0]["PlotSize"].ToString();
                    lblPlotNo.Text = dst.Tables[1].Rows[0]["PlotNo"].ToString();
                    lblMembershipNo.Text = dst.Tables[1].Rows[0]["MembershipNo"].ToString();
                }
                else
                {
                    MessageBox.Show("This File No have no Membership Record in System. Kindly Contact to Transfer for Membership Information");
                    ClearForm();
                }
                // Receive Information have any Receiving or Not.
                if (dst.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = new DataTable();
                    DataTable dtwithNull = new DataTable();
                 //   if (string.IsNullOrEmpty(dst.Tables[0].Rows[0]["DDReceDate"].ToString())!= true)
                        if (string.IsNullOrEmpty(dst.Tables[0].Rows[0]["DueDate"].ToString()) != true)
                        {
                        // dt = dst.Tables[0].Select("DDReceDate IS NOT NULL").CopyToDataTable();
                         dt = dst.Tables[0].Select("Surcharge IS NOT NULL").CopyToDataTable();
                        var Rows = (from row in dt.AsEnumerable()
                                    orderby row["DueDate"] ascending
                                    select row);
                        dt = Rows.AsDataView().ToTable();
                        double TotalSurchargePaid = 0;
                        bool res = double.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
                        if (TotalSurchargePaid > 0)
                        {
                            foreach (DataRow item in dt.Rows)
                            {
                                double SurchargeDue = 0;
                                bool SurchargeFlag = double.TryParse(item["Surcharge"].ToString(),out SurchargeDue);
                                double Wavier = 0;
                                bool WavierFlag = double.TryParse(item["TotalWaiveOffSurcharge"].ToString(),out Wavier);
                                double SurchargetoBePaid = SurchargeDue - Wavier;
                               // if (!string.IsNullOrEmpty(item["Outstanding"].ToString()))
                                 if (!string.IsNullOrEmpty(item["Surcharge"].ToString()))
                                 {
                                    try
                                    {
                                        if (TotalSurchargePaid == 0)
                                            continue;
                                        double outstanding = 0;
                                        bool outstandingFlag = double.TryParse(item["Outstanding"].ToString(), out outstanding);
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
                                        /*if (TotalSurchargePaid < outstanding)
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
                                        }*/
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Receive Information Error \n"+ex.Message+"\n---------\n"+ex.StackTrace);
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
                       // if (dst.Tables[0].Select("DDReceDate IS  NULL").Count() > 0)
                       //// if (dst.Tables[0].Select("DueDate IS  NULL").Count() > 0)
                       // {
                       //     dtwithNull = dst.Tables[0].Select("DDReceDate IS  NULL").CopyToDataTable();
                       //     //dtwithNull = dst.Tables[0].Select("DueDate IS  NULL").CopyToDataTable();
                       //     dtt.Merge(dtwithNull);
                       // }
                        
                        DataTable CustomerInfo = new DataTable("Table");
                        CustomerInfo = dst.Tables[1].Copy();
                        dst.Tables[0].Rows.Clear();
                        dst.Tables[1].Rows.Clear();

                        var DataSorting = (from row in dtt.AsEnumerable()
                                           orderby row["PlanID"] ascending, row["AccountHead"] ascending, row["InstallmentMode"] ascending, row["DueDate"] ascending
                                           select row);

                        dst.Tables[0].Merge(DataSorting.AsDataView().ToTable());
                        dst.Tables[1].Merge(CustomerInfo);

                        MasterTemplate.DataSource = dtt.DefaultView;


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Datatable conversion error.\n"+ex.Message );
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
            lblName.Text = ""; lblFileNo.Text = ""; lblMobileno.Text = ""; lblplotsize.Text = ""; lblPlotNo.Text = ""; lblCNIC.Text = "";
            lblTotalDue.Text = "0"; lblTotalReceive.Text = "0"; lblDueRemaing.Text = "0"; lblGrandDueTotal.Text = "0";
            lblTotalSurcharge.Text = "0"; lblTotalSurcPaid.Text = "0"; lblTotalWaiedOffSur.Text = "0"; lblDueSurcharge.Text = "0";
            //lblFileStatus.Text = "";
            MasterTemplate.DataSource = null;
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
                        lblAmag.Visible = true;
                        IsAmalgamatedchk.Visible = true;
                        lblPaentAm.Visible = true;
                        lblAmalgFileNo.Visible = true;
                        lblAmalgFileNo.Text = ds.Tables[0].Rows[0]["ParentFile"].ToString();
                        IsAmalgamatedchk.Text = ds.Tables[0].Rows[0]["Amalgamated"].ToString();
                    }

                   
                }
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            lblAmag.Visible = false;
            IsAmalgamatedchk.Visible = false;
            lblPaentAm.Visible = false;
            lblAmalgFileNo.Visible = false;
            try
            {
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
                    SqlParameter[] parameter = {
                    new SqlParameter("@Task","FileLockStatus"),
                    new SqlParameter("@FileNo",txtFileNo.Text),
                    new SqlParameter("@LockbyUser",clsUser.ID)
                                                    };
                dst = new DataSet();
               string FileStatus = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", parameter).ToString();
                // dst = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", parameter).ToString();

                dst = Data_Layer.Installment.cls_dl_FinanceDashBoard.Filestatus_Reader(parameter);
                
                string status = "";
                if (dst.Tables.Count > 0)
                {
                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        //  FileStatus = dst.Tables[0].Rows[0]["FileLock"].ToString();
                        if (dst.Tables[1].Rows.Count > 0)
                        {
                            status = dst.Tables[1].Rows[0]["Status"].ToString();
                        }
                    }
                }
                if (FileStatus == "1")
                {
                    //ClearForm();
                    lblFileStatus.Text = "Block";
                    lblfilestatus2.Text = status;
                }
                if (1==1)//(FileStatus == "0") || (clsUser.ID == 3) || (clsUser.ID == 35))
                {
                    if(FileStatus == "1")
                    {
                        lblFileStatus.Text = "Block";
                        lblfilestatus2.Text = status;

                    }
                    else
                    {
                        lblFileStatus.Text = "Active";
                        lblfilestatus2.Text = status;
                    }

                    Amalgamationcheck();
                    ReceiveAdjustment();
                    bool isOK = AccountStatmentView();
                    if (!isOK)
                        return;
                    //MessageBox.Show(clsMostUseVars.ServerDateTime.ToString());
                    // Total Due Amount of Plan
                    int TotalDueAmountofPlan = dst.Tables[0].AsEnumerable()
                                              .Sum(r => r.Field<int>("PlanAdjustAmount"));
                    // Till Current Date Total Due Amount
                    int TotalAmount = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                       .Sum(r => r.Field<int>("PlanAdjustAmount"));
                  
                    // Total Receieve Upto Current + Onward in Case of Advance Payment
                    int TotalReceive = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null)
                                        .Sum(r => r.Field<int>("ReceAdjustAmount"));
                    // Till Current Date Total Receieve 
                    int TotalReceiveUptoCurrentDate = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("ReceAdjustAmount") != null &&  r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                        .Sum(r => r.Field<int>("ReceAdjustAmount"));

                    // Till Current Surcharge
                    int Surcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= clsMostUseVars.ServerDateTime)
                                         .Sum(r => r.Field<int>("Surcharge"));

                    // Total WaiverOff Surcharge
                    int TotalWaieOffSurcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("TotalWaiveOffSurcharge") != null)
                                                  .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));

                    #region code
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
                    #endregion
                    bool res = double.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalSurchargePaid);
                    DueRemaingAmount = TotalAmount - TotalReceive;
                    DueSurchAmount = Surcharge - TotalSurchargePaid - TotalWaieOffSurcharge;
                    // double Refund = TotalSurchargePaid - TotalWaieOffSurcharge;

                    // for Stopping of Surcharge Paid to minus 
                    // Surcharge 2000 : Paid Surcharge : 2000 : WavierOff: 1000 : 2000-(2000+1000) = -1000
                    int TotalDueWithTillCurentDueCurrenrRece = TotalAmount - TotalReceiveUptoCurrentDate;
                    int TotalDueWithTotalPlanDueTotalRece = TotalDueAmountofPlan - TotalReceive;


                    lblTotalSurcPaid.Text = string.Format("{0:n0}", TotalSurchargePaid);
                    lblDueRemaing.Text = string.Format("{0:n0}", DueRemaingAmount);
                    double GrandTotal = 0;
                    dst.Tables[0].Rows[0]["TotalPaidSurcharge"] = TotalSurchargePaid;
                    GrandTotal = (DueRemaingAmount + DueSurchAmount); // DueAmountTillCurrentDate - TotalRece + DueSurchargeUptoCurrenDate
                    lblDueSurcharge.Text = string.Format("{0:n0}", DueSurchAmount);
                    
                 
                    lblTotalDue.Text = string.Format("{0:n0}", TotalAmount); ;
                    lblTotalSurcharge.Text = string.Format("{0:n0}", Surcharge);
                    lblTotalReceive.Text = string.Format("{0:n0}", TotalReceive);
                    lblTotalWaiedOffSur.Text = string.Format("{0:n0}", TotalWaieOffSurcharge);

                    lblGrandDueTotal.Text = string.Format("{0:n0}", GrandTotal); // DueAmountTillCurrentDate - TotalRece + DueSurchargeUptoCurrenDate
                    lbl_TDTCD_TRTCD.Text = string.Format("{0:n0}", TotalDueWithTillCurentDueCurrenrRece);
                    lbl_TDAP_TRA.Text = string.Format("{0:n0}", TotalDueWithTotalPlanDueTotalRece);
                    lblTotalDuePlanAmount.Text = string.Format("{0:n0}", TotalDueAmountofPlan);
                    lblTotalReceTillCurrentDate.Text = string.Format("{0:n0}", TotalReceiveUptoCurrentDate);
                    //DueSurchAmount
                    lbl_TDAP_TRA_DS.Text = string.Format("{0:n0}", (TotalDueAmountofPlan - TotalReceive + DueSurchAmount));
                    lbl_TDTCD_TRTCD_DS.Text = string.Format("{0:n0}", (TotalAmount - TotalReceiveUptoCurrentDate + DueSurchAmount));
                }
            }
            catch (Exception ex)
            {
                ClearForm();
                MessageBox.Show(ex.Message+ex.StackTrace);
            }
           

        }
        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        private void themeapplying()
        {
            if (clsUser.ThemeName == String.Empty)
            {
                ApplyTheme("TelerikMetro");
            }
            else
            {
                ApplyTheme(clsUser.ThemeName);
            }
        }
        private void frmAcknowledgmentInformationSearch_Load(object sender, EventArgs e)
        {
            themeapplying();
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



        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dst.Tables.Count > 0)
            {

                string flno = dst.Tables["Table1"].Rows[0]["FileNo"].ToString();
                SqlParameter[] parameter =
                {
                    new SqlParameter("@Task","CheckMembershipForPrintPermission"),
                    new SqlParameter("@FileNo",flno)
                };
                DataSet FileStatus = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Membership", parameter);
                if (FileStatus.Tables.Count > 0)
                {
                    if (FileStatus.Tables[0].Rows.Count > 0)
                    {
                        int chksts = Convert.ToInt32(FileStatus.Tables[0].Rows[0]["CheckStatus"].ToString());
                        if (chksts == 1)
                        {
                            int usid = clsUser.ID;
                            if ((usid != 35 && chksts >= 1) && (usid != 1041 && chksts >= 1))
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

            frmAccountStatementReport frmobj = new frmAccountStatementReport(dst);
            frmobj.ShowDialog();

        }

        private void btnAcexport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grd_Acknowledgment);
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
