using PeshawarDHASW.Data_Layer.Installment;
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

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge
{
    public partial class frmSurchageWaiveOffRequest : Telerik.WinControls.UI.RadForm
    {
        public frmSurchageWaiveOffRequest()
        {
            InitializeComponent();
            ApplyTheme(clsUser.ThemeName);
        }

        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }
        private void frmSurchageWaiveOffRequest_Load(object sender, EventArgs e)
        {
            LoadDataGridData();
        }
        private void LoadDataGridData()
        {
            try
            {
                SqlParameter[] param = {
                                            new SqlParameter("@Task","GetSuchargeWaiveOffListByUser"),
                                            new SqlParameter("@RequestedBy",clsUser.ID),
                                        };

                DataSet dst = new DataSet();
                dst = cls_dl_Surcharge.Surcharge_Reader(param);
                grd_DDTransferBasket.DataSource = dst.Tables[0].DefaultView;

                //ConditionalFormattingObject obj = new ConditionalFormattingObject("MyCondition", ConditionTypes.Equal, "Pending", "", true);
                //obj.CellForeColor = Color.Red;
                //obj.RowBackColor = Color.SkyBlue;
                //obj.IsValueSet("Edit");
                //this.grd_DDTransferBasket.Columns["Status"].ConditionalFormattingObjectList.Add(obj);
            }
            catch (Exception)
            {
            }

        }

        private void grd_DDTransferBasket_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ViewDetails")
            {
                try
                {
                    bool isEditable = e.Row.Cells["Status"].Value.ToString() == "Pending" ? true : false;
                    frm_SurchargeWaveoffModifybyFile frm = new frm_SurchargeWaveoffModifybyFile(e.Row.Cells["FileNo"].Value.ToString(), true, isEditable, e.Row.Cells["SurWayOffMasID"].Value.ToString());
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
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtfileno.Text.Trim()))
            {
                MessageBox.Show("Please enter File No. first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtfileno.Focus();
            }
            else
            {

                SqlParameter[] param = {
                                            new SqlParameter("@Task","GetSuchargeWaiveOffListByUserbyfileno"),
                                              new SqlParameter("@FileNo",txtfileno.Text),
                                            new SqlParameter("@RequestedBy",clsUser.ID),
                                        };

                DataSet dst = new DataSet();
                dst = cls_dl_Surcharge.Surcharge_Reader(param);
                grd_DDTransferBasket.DataSource = dst.Tables[0].DefaultView;


                //SqlParameter[] param = {
                //                    new SqlParameter("@Task","SurchargeSearch"),
                //                    new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text)),
                //                   };
                //DataSet ds = cls_dl_Surcharge.Surcharge_Reader(param);
                //if (ds.Tables.Count > 0)
                //{
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        frm_SurchargeWaveoffModifybyFile frm = new frm_SurchargeWaveoffModifybyFile(ds.Tables[0].Rows[0]["FileNo"].ToString(), true, true, null);
                //        frm.ShowDialog();
                //        LoadDataGridData();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Please enter a valid File No. or Create new Waivedoff against this File No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("Please enter a valid File No. or Create new Waivedoff against this File No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtfileno.Focus();
                //}
            }
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grd_DDTransferBasket);
        }
    }
}
