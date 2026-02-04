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
    public partial class frm_StampDuty_Modification : Telerik.WinControls.UI.RadForm
    {
        public frm_StampDuty_Modification()
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

        private void radGridView2_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Row.Cells["Status"].Value.ToString() == "Pending")
                {
                    if (e.Column.Name == "Verification")
                    {
                        int StampDuty_ID = int.Parse(e.Row.Cells["StmpDuty_ID"].Value.ToString());
                        frmStampDuty_Modify obj = new frmStampDuty_Modify(StampDuty_ID);
                        obj.ShowDialog();
                    }
                }
                if (e.Column.Name == "Make_Report")
                {
                    //int rowindx = grd_StampDuty_Data.CurrentRow.Index;
                    int stmp_duty_id = int.Parse(e.Row.Cells["StmpDuty_ID"].Value.ToString());
                    if (stmp_duty_id > 0)
                    {
                        SqlParameter[] prm =
                        {
                        new SqlParameter("@Task","Retrive_Stamp_Duty_Data_For_Report"),
                        new SqlParameter("@StmpDuty_ID",stmp_duty_id)
                        };
                        DataSet dst = new DataSet();
                        dst = cls_dl_StampDuty.StampDuty_Reader(prm);
                        dst.Tables[0].Columns.Add(new DataColumn("UserName", typeof(string)));
                        string username = clsUser.Name;
                        foreach (DataRow dr in dst.Tables[0].Rows)
                        {
                            dr["UserName"] = username;
                        }
                        if (dst.Tables.Count > 0)
                        {
                            frmStampDuty_Report_Viewer frmobj = new frmStampDuty_Report_Viewer(dst);
                            frmobj.ShowDialog();
                        }
                    }
                }
                else if (e.Column.Name == "StmModify")
                {
                    int stmp_duty_id = int.Parse(e.Row.Cells["StmpDuty_ID"].Value.ToString());
                    frmStampDuty_Modify frm = new frmStampDuty_Modify(stmp_duty_id);
                    frm.ShowDialog();
                    btn_Find_Click(sender,e);


                }
                else if(e.Column.Name == "btn_Mdf_ntus_us")
                {
                    if (MessageBox.Show("Are you sure to Use the Stamp Duty without NDC generation.", "Attention !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        SqlParameter[] prm =
                        {
                         new SqlParameter("@Task","NotUse_Use"),
                         new SqlParameter("@FileNo",e.Row.Cells["FileNo"].Value.ToString()),
                         new SqlParameter("@StmpDuty_ID",e.Row.Cells["StmpDuty_ID"].Value.ToString()),
                         new SqlParameter("@user_ID",Models.clsUser.ID)
                        };
                        int rsl = cls_dl_StampDuty.StampDuty_NonQuery(prm);
                        if (rsl > 0)
                            MessageBox.Show("Successful.");
                            btn_Find_Click(sender,e);
                    }
                }


            }
            catch (Exception)
            {

            }
        }

        private void radGridView2_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
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
    }
}
