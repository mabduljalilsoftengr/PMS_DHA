using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.Installment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge
{
    public partial class SurchargeWaiveOffList : Telerik.WinControls.UI.RadForm
    {
        public SurchargeWaiveOffList()
        {
            InitializeComponent();
        }

        private void SurchargeWaiveOffList_Load(object sender, EventArgs e)
        {
            LoadDataGridData();
        }
        private void LoadDataGridData()
        {
            try
            {
                SqlParameter[] param = {
                                            new SqlParameter("@Task","GetPendingSurchargeWaieveOff"),
                                        };

                DataSet dst = new DataSet();
                dst = cls_dl_Surcharge.Surcharge_Reader(param);
                grd_DDTransferBasket.DataSource = dst.Tables[0].DefaultView;
                grdApprovedTransfeer.DataSource = dst.Tables[1].DefaultView;
                grdCancelledTrans.DataSource = dst.Tables[2].DefaultView;
            }
            catch (Exception)
            {
            }

        }

        private void grd_DDTransferBasket_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "ViewDetails")
            {
                try
                {
                    frm_SurchargeWaveoffModifybyFile frm = new frm_SurchargeWaveoffModifybyFile(e.Row.Cells["FileNo"].Value.ToString(), true);
                    frm.ShowDialog();
                }
                catch (Exception)
                {
                    
                }
            }
            if (e.Column.Name == "ImageView")
            {
                try
                {
                    int SurWayOffMasID = int.Parse(e.Row.Cells["SurWayOffMasID"].Value.ToString());
                    SqlParameter[] param =
                    {
                        new SqlParameter("@Task","Select"),
                        new SqlParameter("@SurWayOffMasID",SurWayOffMasID)
                    };
                    DataSet ds = Data_Layer.clsMembershipImage.cls_dl_MembershipImage.SurchargeWaiveOffImage_Retriving(param);
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

            if (e.Column.Name == "btnApproved")
            {
                int SurWayOffMasID = int.Parse(e.Row.Cells["SurWayOffMasID"].Value.ToString());

                CustomizeMessageBox obj = new CustomizeMessageBox("Surcharge Waived-Off is ready for Approval.\n Do you want to..", true);
                obj.ShowDialog();
                if (obj.status != null)
                {
                    if (obj.status == "Approve")
                    {
                        SqlParameter[] prm =
                        {
                            new SqlParameter("@Task","UpdateSurchargeWaiveOffRe"),
                            new SqlParameter("@SurWayOffMasID", SurWayOffMasID),
                            new SqlParameter("@Status", "Approved"),
                            new SqlParameter("@ApprovalRemarks", obj.Remarks),
                            new SqlParameter("@ApprovedBy", Models.clsUser.ID)
                        };
                        int rslt = cls_dl_Surcharge.Surcharge_NonQuery(prm);
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
                            new SqlParameter("@Task","UpdateSurchargeWaiveOffRe"),
                            new SqlParameter("@SurWayOffMasID", SurWayOffMasID),
                            new SqlParameter("@Status", "Cancelled"),
                            new SqlParameter("@ApprovalRemarks", obj.Remarks),
                            new SqlParameter("@ApprovedBy", Models.clsUser.ID)
                        };
                        int rslt = cls_dl_Surcharge.Surcharge_NonQuery(prm);
                        if (rslt != 0)
                        {
                            MessageBox.Show("Transaction has been Cancelled successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        LoadDataGridData();
                    }

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
