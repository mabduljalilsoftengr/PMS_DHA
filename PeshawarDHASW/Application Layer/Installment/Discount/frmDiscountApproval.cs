using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Models;
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

namespace PeshawarDHASW.Application_Layer.Installment.Discount
{
    public partial class frmDiscountApproval : Telerik.WinControls.UI.RadForm
    {
        public frmDiscountApproval()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = { new SqlParameter("@Task", "GetDiscountRecordsPendingApprovedCancel") };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_ReceDiscount", param);
            grdPendingDiscountInfo.DataSource = ds.Tables[0].DefaultView;
            grdApprovalDiscountInfo.DataSource = ds.Tables[1].DefaultView;
        
            foreach (GridViewDataColumn column in grdPendingDiscountInfo.Columns)
            {
                column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
            }
            foreach (GridViewDataColumn column in grdApprovalDiscountInfo.Columns)
            {
                column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
            }
          
        }

        private void MasterTemplate_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnImageView")
            {
                try
                {
                    int DiscountRqID = int.Parse(grdPendingDiscountInfo.Rows[grdPendingDiscountInfo.CurrentCell.RowIndex].Cells["DiscountRqID"].Value.ToString()); // ReceID
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
                catch (Exception)
                {
                }
            }
            if (e.Column.Name == "btnDiscountStatus")
            {
                string Val = e.Row.Cells["btnDiscountStatus"].Value.ToString();
                string DiscountRqID = e.Row.Cells["DiscountRqID"].Value.ToString();
                if (Val == "Pending")
                {
                    CustomizeMessageBox obj = new CustomizeMessageBox("Discount.\n Do you want to..", true);
                    obj.ShowDialog();
                    if (obj.status != null)
                    {
                        if (obj.status == "Approve")
                        {
                             SqlParameter[] param = {
                                new SqlParameter("@Task","DiscountStatusApprovedorCancel"),
                                new SqlParameter("@DiscountStatus","Approved"),
                                new SqlParameter("@ApprovedBy",clsUser.ID),
                                new SqlParameter("@ApprovedDate",DateTime.Now.ToString("yyyy/MM/dd")),
                                new SqlParameter("@ApprovedRemarksa",obj.Remarks),
                                new SqlParameter("@DiscountRqID",DiscountRqID),
                            };
                           int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_ReceDiscount", param);
                            if (result != 0)
                            {
                                MessageBox.Show("Discount has been Approved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            btnRefresh_Click(null, null);
                        }
                        if (obj.status == "Cancel")
                        {
                            SqlParameter[] param = {
                                new SqlParameter("@Task","DiscountStatusApprovedorCancel"),
                                new SqlParameter("@DiscountStatus","Cancelled"),
                                new SqlParameter("@ApprovedBy",clsUser.ID),
                                new SqlParameter("@ApprovedDate",DateTime.Now.ToString("yyyy/MM/dd")),
                                new SqlParameter("@ApprovedRemarksa",obj.Remarks),
                                new SqlParameter("@DiscountRqID",DiscountRqID),
                            };
                            int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_ReceDiscount", param);
                            if (result != 0)
                            {
                                MessageBox.Show("Discount has been Cancelled successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            btnRefresh_Click(null, null);
                        }
                    }
                }
               
            }
        }

        private void frmDiscountApproval_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdPendingDiscountInfo);
        }

        private void btnExportAppro_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdApprovalDiscountInfo);
        }

        private void grdApprovalDiscountInfo_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnImageView")
            {
                try
                {
                    int DiscountRqID = int.Parse(grdApprovalDiscountInfo.Rows[grdApprovalDiscountInfo.CurrentCell.RowIndex].Cells["DiscountRqID"].Value.ToString()); // ReceID
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
                catch (Exception)
                {
                }
            }
        }
    }
}
