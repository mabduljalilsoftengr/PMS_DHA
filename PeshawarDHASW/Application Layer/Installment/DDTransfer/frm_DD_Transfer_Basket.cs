using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Application_Layer.Membership.MSImage;
using PeshawarDHASW.Data_Layer.Installment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.DDTransfer
{
    public partial class frm_DD_Transfer_Basket : Telerik.WinControls.UI.RadForm
    {
        public frm_DD_Transfer_Basket()
        {
            InitializeComponent();
        }

        private void frm_DD_Transfer_Basket_Load(object sender, EventArgs e)
        {
            LoadDataGridData();
        }
        private void LoadDataGridData()
        {
            try
            {
                SqlParameter[] prm = { new SqlParameter("@Task", "Select_DDTransfer_Data") };
                DataSet dst = cls_dl_InstRece.Inst_Rece_Read(prm);
                grd_DDTransferBasket.DataSource = dst.Tables[0].DefaultView;
                grdApprovedTransfeer.DataSource = dst.Tables[1].DefaultView;
                grdCancelledTrans.DataSource = dst.Tables[2].DefaultView;

                foreach (GridViewDataColumn column in grd_DDTransferBasket.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
                foreach (GridViewDataColumn column in grdApprovedTransfeer.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
                foreach (GridViewDataColumn column in grdCancelledTrans.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
            }
            catch (Exception)
            {
            }

        }

        private void grd_DDTransferBasket_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ImageView")
            {
                try
                {
                    int TDDI_ID = int.Parse(grd_DDTransferBasket.Rows[grd_DDTransferBasket.CurrentCell.RowIndex].Cells["TDDI_ID"].Value.ToString()); // ReceID
                    SqlParameter[] param =
                               {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@DDTransferID",TDDI_ID)
                };
                    DataSet ds = Data_Layer.clsMembershipImage.cls_dl_MembershipImage.DDTransferImage_Retriving(param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                            //obj.Show();

                            frmImageViewer frmobj = new frmImageViewer(ds.Tables[0]);
                            frmobj.ShowDialog();
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

            if (e.Column.Name == "btn_TransferDD")
            {
                int TDDI_ID = int.Parse(grd_DDTransferBasket.Rows[grd_DDTransferBasket.CurrentCell.RowIndex].Cells["TDDI_ID"].Value.ToString()); // ReceID
                int ReceID = int.Parse(grd_DDTransferBasket.Rows[grd_DDTransferBasket.CurrentCell.RowIndex].Cells["ReceID"].Value.ToString());
                int newFileKey = int.Parse(grd_DDTransferBasket.Rows[grd_DDTransferBasket.CurrentCell.RowIndex].Cells["New_FileKey"].Value.ToString());
                int newMemberID = int.Parse(grd_DDTransferBasket.Rows[grd_DDTransferBasket.CurrentCell.RowIndex].Cells["New_MemberID"].Value.ToString());
                int oldFileKey = int.Parse(grd_DDTransferBasket.Rows[grd_DDTransferBasket.CurrentCell.RowIndex].Cells["Old_FileKey"].Value.ToString());
                int oldMemberID = int.Parse(grd_DDTransferBasket.Rows[grd_DDTransferBasket.CurrentCell.RowIndex].Cells["Old_MemberID"].Value.ToString());


                CustomizeMessageBox obj = new CustomizeMessageBox("Demand Draft/ Challan is ready for Transfer.\n Do you want to..", true);
                obj.ShowDialog();
                if (obj.status != null)
                {
                    if (obj.status == "Approve")
                    {
                        SqlParameter[] prm =
                        {
                            new SqlParameter("@Task","Update_DDTransfer_SpecificData"),
                            new SqlParameter("@ReceID", ReceID),
                            new SqlParameter("@TfrNew_FileKey", newFileKey),
                            new SqlParameter("@TfrNew_MemberIDnt", newMemberID),
                            new SqlParameter("@TDDI_ID", TDDI_ID),
                            new SqlParameter("@oldFileKey",oldFileKey),
                            new SqlParameter("@Status", obj.status),
                            new SqlParameter("@Remarks_on", obj.Remarks),
                            new SqlParameter("@UserID", Models.clsUser.ID)
                        };
                        int rslt = cls_dl_InstRece.DDTransfer_NonQuery(prm);
                        if (rslt != 0)
                        {
                            MessageBox.Show("Transaction has been Approved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        LoadDataGridData();
                    }
                    else if (obj.status == "Cancel")
                    {
                        SqlParameter[] prm =
                        {
                            new SqlParameter("@Task","Update_DDTransfer_SpecificData"),
                            new SqlParameter("@ReceID", ReceID),
                            new SqlParameter("@TfrNew_FileKey", newFileKey),
                            new SqlParameter("@TfrNew_MemberIDnt", newMemberID),
                            new SqlParameter("@TDDI_ID", TDDI_ID),
                            new SqlParameter("@Status", "Canceled"),
                            new SqlParameter("@Remarks_on", obj.Remarks),
                            new SqlParameter("@UserID", Models.clsUser.ID)
                        };
                        int rslt = cls_dl_InstRece.DDTransfer_NonQuery(prm);
                        if (rslt != 0)
                        {
                            MessageBox.Show("Transaction has been Cancelled successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        LoadDataGridData();
                    }

                }
            }
        }

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {
            LoadDataGridData();
        }

        private void grd_DDTransferBasket_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.Value != null)
            {
                e.CellElement.ToolTipText = e.CellElement.Value.ToString();
            }
        }

        private void grdApprovedTransfeer_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.Value != null)
            {
                e.CellElement.ToolTipText = e.CellElement.Value.ToString();
            }
        }

        private void grdCancelledTrans_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.Value != null)
            {
                e.CellElement.ToolTipText = e.CellElement.Value.ToString();
            }
        }

        private void MasterTemplate_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ImageView")
            {
                try
                {
                    int TDDI_ID = int.Parse(grdApprovedTransfeer.Rows[grdApprovedTransfeer.CurrentCell.RowIndex].Cells["TDDI_ID"].Value.ToString()); // ReceID
                    SqlParameter[] param =
                               {
                                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                                    new SqlParameter("@DDTransferID",TDDI_ID)
                               };
                    DataSet ds = Data_Layer.clsMembershipImage.cls_dl_MembershipImage.DDTransferImage_Retriving(param);
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

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grd_DDTransferBasket);
        }

        private void btnExportAppro_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdApprovedTransfeer);
        }

        private void btnExportCancel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdCancelledTrans);
        }
    }
}
