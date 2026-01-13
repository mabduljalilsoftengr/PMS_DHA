using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Data_Layer.NDC;
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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Refund
{
    public partial class frmRefundProcess : Telerik.WinControls.UI.RadForm
    {
        public frmRefundProcess()
        {
            InitializeComponent();
        }

        private void grd_RefundPendingBasket_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

            if (e.Column.Name == "ImageView")
            {
                try
                {
                    int RefundID = int.Parse(e.Row.Cells["RefundID"].Value.ToString()); // ReceID
                    int NDCNo = string.IsNullOrEmpty(e.Row.Cells["NDCNo"].Value.ToString()) ? 0 : int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                    DataSet ds = new DataSet();
                    if (NDCNo > 0)
                    {
                        SqlParameter[] param =
                        {
                        new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                        new SqlParameter("@NDCNo",NDCNo)
                        };
                        ds = SQLHelper.ExecuteDataset(
                                                            clsMostUseVars.VerifiedImageConnectionstring,
                                                            CommandType.StoredProcedure,
                                                            "usp_tbl_RefundImage",
                                                            param
                                                            );
                    }
                    else
                    {
                        SqlParameter[] param =
                        {
                        new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                        new SqlParameter("@RefundID",RefundID)
                        };
                        ds = SQLHelper.ExecuteDataset(
                                                            clsMostUseVars.VerifiedImageConnectionstring,
                                                            CommandType.StoredProcedure,
                                                            "usp_tbl_RefundImage",
                                                            param
                                                            );
                    }
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
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
                catch (Exception ex)
                {
                }
            }

            if (e.Column.Name == "btn_TransferDD")
            {
                try
                {
                    #region Refund of Challan , Surcharge and Transfer Surcharge to Installment
                    CustomizeMessageBox obj = new CustomizeMessageBox("Refund Challan / Surcharge or Transfer to Installment\n  Do you want to..", true);
                    obj.ShowDialog();
                    if (obj.status != null)
                    {
                        if (obj.status == "Approve")
                        {

                            int RefundID = int.Parse(e.Row.Cells["RefundID"].Value.ToString()); // ReceID
                            int RefundAmount = (int)Math.Round(double.Parse(e.Row.Cells["RefundAmount"].Value.ToString()));

                            #region Surcharge Refund to Customer
                            if (e.Row.Cells["AdjustmentType"].Value.ToString().Contains("Surcharge Refund"))
                            {
                                SqlParameter[] prm =
                                    {
                                    new SqlParameter("@Task","RefundUpdate"),
                                    new SqlParameter("@RefundID", RefundID),
                                    new SqlParameter("@Approvedby", Models.clsUser.Name),
                                    new SqlParameter("@ApprovedDate", DateTime.Now.ToString("yyyy-MM-dd")),
                                    new SqlParameter("@ApprovedRemarks", obj.Remarks),
                                    new SqlParameter("@STATUS", "Approved")
                                };
                               DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", prm);
                                if (ds.Tables.Count > 0)
                                {

                                   MessageBox.Show(ds.Tables[0].Rows[0]["MessageStatus"].ToString());
                                }
                            }
                            #endregion

                            #region Challan Refund for NDC

                            //if (e.Row.Cells["AdjustmentType"].Value.ToString() == "Challan Refunded") //COMMENTED ACCORDING TO JALIL CHANGES 

                                if (e.Row.Cells["AdjustmentType"].Value.ToString() == "Challan Refunded" || e.Row.Cells["AdjustmentType"].Value.ToString() == "Challan Refund")
                                                           {
                                int ndc = int.Parse(e.Row.Cells["NDCNo"].Value.ToString());
                                string AdjustType = e.Row.Cells["AdjustmentType"].Value.ToString();
                                SqlParameter[] prm =
                                    {
                                    new SqlParameter("@Task","RefundUpdateOfNDCChallan"),
                                    new SqlParameter("@RefundID", RefundID),
                                    new SqlParameter("@Approvedby", Models.clsUser.Name),
                                    new SqlParameter("@ApprovedDate", DateTime.Now.ToString("yyyy-MM-dd")),
                                    new SqlParameter("@ApprovedRemarks", obj.Remarks),
                                    new SqlParameter("@AdjustmentType", AdjustType),
                                    new SqlParameter("@STATUS", "Approved")
                                };
                                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", prm);
                                if (result > 0)
                                {
                                    //MessageBox.Show("Process Successful");
                                    //// Update the NDC Status
                                    SqlParameter[] prtm =
                                    {
                                    new SqlParameter("@Task","UpdateNDC_Sts"),
                                    new SqlParameter("@NDCNo",ndc),
                                    new SqlParameter("@StatusofNDC","RefundApproved")
                                    };
                                    int rsl = cls_dl_NDC.NdcNonQuery(prtm);
                                    DataLoading();
                                    return;
                                }
                            }
                            #endregion

                            #region Surcharge Adjust in Installment
                            if (e.Row.Cells["AdjustmentType"].Value.ToString() == "Surcharge Adjust")
                            {
                                SqlParameter[] paramerforMember = 
                                {
                                      new SqlParameter("@Task", "GetMemberID"),
                                      new  SqlParameter("@FileMapKey_MID", e.Row.Cells["FileMapKey"].Value.ToString())
                                };

                                DataSet ds = new DataSet();
                                ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", paramerforMember);
                                if (ds.Tables.Count>0)
                                {
                                    if (ds.Tables[0].Rows.Count>0)
                                    {
                                        string Memberid = ds.Tables[0].Rows[0]["MemberID"].ToString();
                                        SqlParameter[] param =
                                        {
                                            new SqlParameter("@Task", "insert"),
                                            new SqlParameter() {
                                                ParameterName = "@Date",
                                                SqlDbType = SqlDbType.Date,
                                                SqlValue =  clsMostUseVars.ServerDateTime.ToString("yyyy/MM/dd") ,

                                            },
                                              new SqlParameter() {
                                                ParameterName = "@DDGenerationDate",
                                                SqlDbType = SqlDbType.Date,
                                                SqlValue = clsMostUseVars.ServerDateTime.ToString("yyyy/MM/dd") ,
                                            },
                                            new SqlParameter("@Amountinwords", Helper.clsPluginHelper.Convert_Number_To_Text(RefundAmount,true)),
                                            new SqlParameter("@PaymentMethod", "Challan"),
                                            new SqlParameter("@Amount", RefundAmount),
                                            new SqlParameter("@DDNo", "Adj-"+e.Row.Cells["ChallanNo"].Value.ToString()), // I-098
                                            new SqlParameter("@BankName", "Askari Bank Limited"),
                                            new SqlParameter("@Branch", "Peshawar Cantt"),
                                            new SqlParameter("@Status", "Challan For Single File"),
                                            new SqlParameter("@DDStatus", "Received"),
                                            new SqlParameter("@Remarks", "Total Amount of Challan : "+RefundAmount.ToString()),
                                            new SqlParameter("@MemberID", Memberid),
                                            new SqlParameter("@FileKeyID", e.Row.Cells["FileMapKey"].Value.ToString()),
                                            new SqlParameter("@userID", Models.clsUser.ID),
                                         };

                                        int Inst_result = 0;
                                        Inst_result = cls_dl_InstRece.Inst_Rece_NonQuery(param);

                                        SqlParameter[] prm ={
                                            new SqlParameter("@Task","RefundUpdate"),
                                            new SqlParameter("@RefundID", RefundID),
                                            new SqlParameter("@Approvedby", Models.clsUser.Name),
                                            new SqlParameter("@ApprovedDate", DateTime.Now.ToString("yyyy-MM-dd")),
                                            new SqlParameter("@ApprovedRemarks", obj.Remarks),
                                            new SqlParameter("@STATUS", "Approved")
                                        };
                                        int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", prm);
                                        if (result > 0)
                                        {
                                            //  MessageBox.Show("Process Successful");
                                        }
                                    }
                                }
                            

                                
                            }
                            #endregion

                            #region Demand Drafts Refund to Customer
                            if (e.Row.Cells["AdjustmentType"].Value.ToString() == "DD Refunded")
                            {


                                SqlParameter[] prm =
                                   {
                                    new SqlParameter("@Task","DDRefund"),
                                    new SqlParameter("@RefundID", RefundID),
                                    new SqlParameter("@Approvedby", Models.clsUser.Name),
                                    new SqlParameter("@ApprovedDate", DateTime.Now.ToString("yyyy-MM-dd")),
                                    new SqlParameter("@ApprovedRemarks", obj.Remarks),
                                    new SqlParameter("@STATUS", "Approved")
                                };
                                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", prm);
                                if (result > 0)
                                {
                                    //MessageBox.Show("Process Successful");
                                }
                            }
                            if (e.Row.Cells["AdjustmentType"].Value.ToString() == "SR-of-TFR-File")
                            {


                                SqlParameter[] prm =
                                   {
                                    new SqlParameter("@Task","ApprovalforChallanRefund_Surcharge"),
                                    new SqlParameter("@RefundID", RefundID),
                                    new SqlParameter("@Approvedby", Models.clsUser.Name),
                                    new SqlParameter("@ApprovedDate", DateTime.Now.ToString("yyyy-MM-dd")),
                                    new SqlParameter("@ApprovedRemarks", obj.Remarks),
                                    new SqlParameter("@STATUS", "Approved")
                                };
                                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", prm);
                                if (result > 0)
                                {
                                    //MessageBox.Show("Process Successful");
                                }
                            }
                            #endregion

                            DataLoading();

                        }

                        else if (obj.status == "Cancel")
                        {
                            int RefundID = int.Parse(e.Row.Cells["RefundID"].Value.ToString()); // ReceID
                                SqlParameter[] prm =
                                    {
                                    new SqlParameter("@Task","RefundUpdate"),
                                    new SqlParameter("@RefundID", RefundID),
                                    new SqlParameter("@Approvedby", Models.clsUser.Name),
                                    new SqlParameter("@ApprovedDate", DateTime.Now.ToString("yyyy-MM-dd")),
                                    new SqlParameter("@ApprovedRemarks", obj.Remarks),
                                    new SqlParameter("@STATUS", "Cancel")
                                };
                                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", prm);
                                if (result > 0)
                                {
                                    // MessageBox.Show("Process Successful");
                                }
                            DataLoading();
                        }

                    }
                    #endregion
                }
                catch (Exception ex)
                {

                }
            }
            if (e.Column.Name == "PaymentMode")
            {
                string RefundID = e.Row.Cells["RefundID"].Value.ToString();
                string ChequeNo = e.Row.Cells["ChequeNo"].Value.ToString();
                PaymentModeSetting pms = new PaymentModeSetting(RefundID,ChequeNo);
                pms.ShowDialog();
                DataLoading();
            }

        }
        private void DataLoading()
        {
            SqlParameter[] parameter = {
                new SqlParameter("@Task","RetriveDataofSurchargeRefund")
            };
            DataSet DataRefund = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_Refund", parameter);
            grd_RefundPendingBasket.DataSource = DataRefund.Tables[0].DefaultView;
            grdApprovedRefund.DataSource = DataRefund.Tables[1].DefaultView;
            grdCancelRefund.DataSource = DataRefund.Tables[2].DefaultView;
            grdrefunddata.DataSource = DataRefund.Tables[3].DefaultView;

            foreach (GridViewDataColumn column in grd_RefundPendingBasket.Columns)
            {
                column.BestFit();
            }
            foreach (GridViewDataColumn column in grdApprovedRefund.Columns)
            {
                column.BestFit();
            }
            foreach (GridViewDataColumn column in grdCancelRefund.Columns)
            {
                column.BestFit();
            }
            foreach (GridViewDataColumn column in grdrefunddata.Columns)
            {
                column.BestFit();
            }
        }
        private void frmRefundProcess_Load(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void grdApprovedRefund_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ImageView")
            {
                try
                {
                    int RefundID = int.Parse(e.Row.Cells["RefundID"].Value.ToString()); // ReceID
                    SqlParameter[] param =
                    {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@RefundID",RefundID)
                    };
                    DataSet ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_RefundImage",
                                                        param
                                                        );
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
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
                catch (Exception ex)
                {
                }
            }
            if (e.Column.Name == "PaymentMode")
            {
                string RefundID = e.Row.Cells["RefundID"].Value.ToString();
                string ChequeNo = e.Row.Cells["ChequeNo"].Value.ToString();
                PaymentModeSetting pms = new PaymentModeSetting(RefundID, ChequeNo);
                pms.ShowDialog();
                DataLoading();
            }
        }

        private void grdCancelRefund_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ImageView")
            {
                try
                {
                    int RefundID = int.Parse(e.Row.Cells["RefundID"].Value.ToString()); // ReceID
                    SqlParameter[] param =
                               {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@RefundID",RefundID)
                };
                    DataSet ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_RefundImage",
                                                        param
                                                        );
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
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
                catch (Exception ex)
                {
                }
            }
        }

        private void btnrefreshRefund_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void refshpn_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void rfundapprvd_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void btncancelled_Click(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void grdrefunddata_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnAttachment")
            {
                try
                {
                    int RefundID = int.Parse(e.Row.Cells["RefundID"].Value.ToString()); // ReceID
                    SqlParameter[] param =
                    {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@RefundID",RefundID)
                    };
                    DataSet ds = SQLHelper.ExecuteDataset(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_RefundImage",
                                                        param
                                                        );
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
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
                catch (Exception ex)
                {
                }
            }
       }
    }
}
