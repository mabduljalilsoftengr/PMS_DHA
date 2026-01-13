using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.Account_Statement.AdjustmentModule
{
    public partial class frmAddjustment_Process : Telerik.WinControls.UI.RadForm
    {
        public frmAddjustment_Process()
        {
            InitializeComponent();
        }

        private void frmAddjustment_Process_Load(object sender, EventArgs e)
        {
            GetData();
        }
        private void GetData()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetDataForAdjustment")
            };
            DataSet dst = cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);
            if(dst.Tables.Count > 0)
            {
                grdPending.DataSource = dst.Tables[0].DefaultView;
                grdappdata.DataSource = dst.Tables[1].DefaultView;
            }
           
        }

        private void btnrefreshapprvd_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnrefrehpend_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void grdPending_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnPreview")
            {
                int AdjID = Convert.ToInt32(e.Row.Cells["AdjID"].Value.ToString());
                SqlParameter[] prmtr =
                {
                    new SqlParameter("@Task","SelectPaymentsAdjustmentImages"),
                    new SqlParameter("@AdjID",AdjID)
                };
                DataSet dst =  Helper.SQLHelper.ExecuteDataset(
                                                            clsMostUseVars.VerifiedImageConnectionstring,
                                                            CommandType.StoredProcedure,
                                                            "usp_tbl_PaymentsAdjustmentImage",
                                                            prmtr
                                                            );
                if(dst.Tables.Count > 0)
                {
                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        frmImagePreview frmobj = new frmImagePreview(dst.Tables[0]);
                        frmobj.Show();
                    }
                   
                }
                

            }
            else if(e.Column.Name == "btnApproved")
            {
                int AdjID = Convert.ToInt32(e.Row.Cells["AdjID"].Value.ToString());
                string AdjType = e.Row.Cells["AdjType"].Value.ToString();
                if(MessageBox.Show("Are You Sure ?","Attention !",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    #region InstallmentToSurcharge
                    if (AdjType == "InstallmentToSurcharge")
                    {
                        int trxid = Convert.ToInt32(e.Row.Cells["TRXID"].Value.ToString());
                        string FileNoFrm = e.Row.Cells["FileNoFrm"].Value.ToString();
                        string MsNoFrm = e.Row.Cells["MsNoFrm"].Value.ToString();
                        decimal TotalAmountFrm = Convert.ToDecimal(e.Row.Cells["TotalAmountFrm"].Value.ToString());
                        string FileNoTo = e.Row.Cells["FileNoTo"].Value.ToString();
                        string MsNoTo = e.Row.Cells["MsNoTo"].Value.ToString();
                        decimal AmountAdj = Convert.ToDecimal(e.Row.Cells["AmountAdj"].Value.ToString());
                        string IsFullPartial = e.Row.Cells["IsFullPartial"].Value.ToString();

                        SqlParameter[] prm =
                        {
                      new SqlParameter("@Task","InstlToSurgAdjustment"),
                      new SqlParameter("@TRXID",trxid),
                      new SqlParameter("@ConvertedToFileNo_P",FileNoTo),
                      new SqlParameter("@ConvertedToDPRNo_P",MsNoTo),
                      new SqlParameter("@ApprovedByID",Models.clsUser.ID),
                      new SqlParameter("@IsFullPartial",IsFullPartial),
                      new SqlParameter("@AmountAdj",AmountAdj),
                      new SqlParameter("@AdjID",AdjID)
                    };
                        int rslt = cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prm);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Successful.");
                        }
                    }
                    #endregion
                    #region SurchargeToSurcharge
                    else if (AdjType == "SurchargeToSurcharge")
                    {
                        string ChallanNo = e.Row.Cells["ChallanNo"].Value.ToString();
                        string FileNoFrm = e.Row.Cells["FileNoFrm"].Value.ToString();
                        string MsNoFrm = e.Row.Cells["MsNoFrm"].Value.ToString();
                        decimal TotalAmountFrm = Convert.ToDecimal(e.Row.Cells["TotalAmountFrm"].Value.ToString());
                        string FileNoTo = e.Row.Cells["FileNoTo"].Value.ToString();
                        string MsNoTo = e.Row.Cells["MsNoTo"].Value.ToString();
                        decimal AmountAdj = Convert.ToDecimal(e.Row.Cells["AmountAdj"].Value.ToString());
                        string IsFullPartial = e.Row.Cells["IsFullPartial"].Value.ToString();

                        SqlParameter[] prm =
                        {
                    new SqlParameter("@Task","SurToSurofAnotherFile"),
                    new SqlParameter("@ChallanNo_chch",ChallanNo),
                    new SqlParameter("@ConvertedToFileNo_chch",FileNoTo),
                    new SqlParameter("@ConvertedToDPRNo_chch",MsNoTo),
                    new SqlParameter("@ApprovedByID",Models.clsUser.ID),
                    new SqlParameter("@IsFullPartial",IsFullPartial),
                    new SqlParameter("@AmountAdj",AmountAdj),
                    new SqlParameter("@AdjID",AdjID),
                    new SqlParameter("@FileNoFrm",FileNoFrm)
                    };
                        int rslt = cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prm);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Successful.");
                        }
                    }
                    #endregion
                    #region SurchargeToInstallment
                    else if (AdjType == "SurchargeToInstallment")
                    {
                        string ChallanNo = e.Row.Cells["ChallanNo"].Value.ToString();
                        string FileNoFrm = e.Row.Cells["FileNoFrm"].Value.ToString();
                        string MsNoFrm = e.Row.Cells["MsNoFrm"].Value.ToString();
                        decimal TotalAmountFrm = Convert.ToDecimal(e.Row.Cells["TotalAmountFrm"].Value.ToString());
                        string FileNoTo = e.Row.Cells["FileNoTo"].Value.ToString();
                        string MsNoTo = e.Row.Cells["MsNoTo"].Value.ToString();
                        decimal AmountAdj = Convert.ToDecimal(e.Row.Cells["AmountAdj"].Value.ToString());
                        string IsFullPartial = e.Row.Cells["IsFullPartial"].Value.ToString();

                        SqlParameter[] prm =
                        {
                    new SqlParameter("@Task","SurgToInstlAdjustment"),
                    new SqlParameter("@ChallanNo",ChallanNo),
                    new SqlParameter("@ConvertedToFileNoSurInstl",FileNoTo),
                    new SqlParameter("@ConvertedToDPRNoSurInstl",MsNoTo),
                    new SqlParameter("@ApprovedByID",Models.clsUser.ID),
                    new SqlParameter("@IsFullPartial",IsFullPartial),
                    new SqlParameter("@AmountAdj",AmountAdj),
                    new SqlParameter("@AdjID",AdjID)
                    };
                        int rslt = cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prm);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Successful.");
                        }
                    }
                    #endregion
                    GetData();
                }

            }
            else if(e.Column.Name == "btnCancel")
            {
                int AdjID = Convert.ToInt32(e.Row.Cells["AdjID"].Value.ToString());
                if (MessageBox.Show("Are You Sure ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SqlParameter[] prm =
                    {
                      new SqlParameter("@Task","UpdatePaymentAdjustmentStatus"),
                      new SqlParameter("@Status","Cancel"),
                      new SqlParameter("@ApprovedByID",Models.clsUser.ID),
                      new SqlParameter("@AdjID",AdjID)
                    };
                    int rslt = cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prm);
                    if (rslt > 0)
                    {
                        MessageBox.Show("Cancelled Successfully.");
                    }
                    GetData();
                }
            }
        }

        private void grdappdata_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnPreview")
            {
                int AdjID = Convert.ToInt32(e.Row.Cells["AdjID"].Value.ToString());
                SqlParameter[] prmtr =
                {
                    new SqlParameter("@Task","SelectPaymentsAdjustmentImages"),
                    new SqlParameter("@AdjID",AdjID)
                };
                DataSet dst = Helper.SQLHelper.ExecuteDataset(
                                                            clsMostUseVars.VerifiedImageConnectionstring,
                                                            CommandType.StoredProcedure,
                                                            "usp_tbl_PaymentsAdjustmentImage",
                                                            prmtr
                                                            );
                if (dst.Tables.Count > 0)
                {
                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        frmImagePreview frmobj = new frmImagePreview(dst.Tables[0]);
                        frmobj.Show();
                    }

                }


            }
        }

        private void btnexcelexportp_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdPending);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnexcelexportapcn_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdappdata);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }
    }
}
