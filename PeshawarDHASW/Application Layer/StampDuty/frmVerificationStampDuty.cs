using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsStampDuty;
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

namespace PeshawarDHASW.Application_Layer.StampDuty
{
    public partial class frmVerificationStampDuty : Telerik.WinControls.UI.RadForm
    {
        public frmVerificationStampDuty()
        {
            InitializeComponent();
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] prm =
          {
              new SqlParameter("@Task","Select_StampDuty_Buyer_Seller"),
              new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
              new SqlParameter("@RefNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtReferenceNo.Text)),
              new SqlParameter("@Name",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtName.Text)),
              new SqlParameter("@CNIC",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC.Text)),
              new SqlParameter("@MembershipNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMSNo.Text)),
            };
                DataSet dst = new DataSet();
                dst = cls_dl_StampDuty.StampDuty_Reader(prm);
                StampDutyDs stampdutyds = new StampDutyDs();
                stampdutyds.StampDutyHeader.Merge(dst.Tables[0]);
                stampdutyds.StampDutyDetail.Merge(dst.Tables[1]);
                radGridView2.DataSource = stampdutyds.StampDutyHeader.DefaultView;
                gridViewTemplate1.DataSource = stampdutyds.StampDutyDetail.DefaultView;
                foreach (var item in radGridView2.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void grd_StampDuty_Data_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "Stm_Dt_SellerBuyer_ID")
            {
                e.CellElement.Visibility = ElementVisibility.Collapsed;
                e.Column.IsVisible = false;
            }
            if (e.CellElement.ColumnInfo.Name == "StampDuty_ID")
            {
                e.CellElement.Visibility = ElementVisibility.Collapsed;
                e.Column.IsVisible = false;
            }

            if (e.CellElement.ColumnInfo.Name == "Type")
            {
                e.Column.Width = 60;
                e.Column.WrapText = true;
            }
            if (e.CellElement.ColumnInfo.Name == "Name")
            {
                e.Column.Width = 250;
                e.Column.WrapText = true;
            }
            if (e.CellElement.ColumnInfo.Name == "CNIC")
            {
                e.Column.Width = 150;
                e.Column.WrapText = true;
            }
            if (e.CellElement.ColumnInfo.Name == "MembershipNo")
            {
                e.Column.Width = 150;
                e.Column.WrapText = true;
            }
        }

        private void grd_StampDuty_Data_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Row.Cells["Status"].Value.ToString()=="Pending")
                {
                    if (e.Column.Name == "Verification")
                    {
                        CustomizeMessageBox obj = new CustomizeMessageBox("Stamp Duty Details will never be modified after update.\n Do you want..", true);
                        obj.ShowDialog();
                        if (obj.status != null)
                        {
                            if (obj.status == "Approve")
                            {
                                SqlParameter[] param = {
                                                        new SqlParameter("@Task","StampDutyVerification"),
                                                        new SqlParameter("@StmpDuty_ID",e.Row.Cells["StmpDuty_ID"].Value.ToString()),
                                                        new SqlParameter("@Status","Not-Use"),
                                                        new SqlParameter("@Remarks",obj.Remarks),
                                                        new SqlParameter("@Verifiedby",clsUser.ID),
                                                        new SqlParameter("@VerifiedDate",Helper.clsMostUseVars.ServerDateTime)
                                                     };
                                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.Usp_tbl_StampDuty", param);
                                if (result > 0)
                                {
                                    MessageBox.Show("Recieved successfuly.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btn_Find_Click(null, null);
                                }
                            }
                            if (obj.status == "Cancel")
                            {
                                SqlParameter[] param = {
                                                new SqlParameter("@Task","StampDutyVerification"),
                                                new SqlParameter("@StmpDuty_ID",e.Row.Cells["StmpDuty_ID"].Value.ToString()),
                                                new SqlParameter("@Status","Cancelled"),
                                                 new SqlParameter("@Remarks",obj.Remarks),
                                                  new SqlParameter("@Verifiedby",clsUser.ID),
                                                        new SqlParameter("@VerifiedDate",Helper.clsMostUseVars.ServerDateTime)
                                                     };
                                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.Usp_tbl_StampDuty", param);
                                if (result > 0)
                                {
                                    MessageBox.Show("Cancelled successfuly.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    btn_Find_Click(null, null);
                                }
                            }
                        }

                    }
                }
               

            }
            catch (Exception)
            {
                
            }
        }

        private void frmVerificationStampDuty_Load(object sender, EventArgs e)
        {

        }
    }
}

