using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsCaution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Caution
{
    public partial class Caution_Search : Telerik.WinControls.UI.RadForm
    {
        public Caution_Search()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckCaution();
        }

        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            CheckCaution();
        }
        private void CheckCaution()
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Load_Caution"),
                new SqlParameter("@FileNo",txtFileNo.Text == "" ? null : txtFileNo.Text)
                };
                DataSet ds = cls_dl_Caution.Caution_Reader(prm);
                grdMessageBox.DataSource = null;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdMessageBox.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on CheckCaution.", ex, "Caution_Search");
                frmobj.ShowDialog();

            }


        }

        private void Caution_Search_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            CheckAllCaution();
        }
        private void CheckAllCaution()
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Load_Caution")
                };
                DataSet ds = cls_dl_Caution.Caution_Reader(prm);
                grdMessageBox.DataSource = null;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdMessageBox.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on CheckAllCaution.", ex, "Caution_Search");
                frmobj.ShowDialog();
            }
        }

        private void grdMessageBox_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "CautionImageUpload")
            {
                int ID = int.Parse(grdMessageBox.CurrentRow.Cells["CautionID"].Value.ToString());
                frmCautionImageUpload frm = new frmCautionImageUpload(ID);
                frm.ShowDialog();
            }
            else if(e.Column.Name == "btnImageView")
            {
                int ID = int.Parse(grdMessageBox.CurrentRow.Cells["CautionID"].Value.ToString());
                frmCautionImageView frm = new frmCautionImageView(ID);
                frm.ShowDialog();
            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdMessageBox);
        }
    }
}
