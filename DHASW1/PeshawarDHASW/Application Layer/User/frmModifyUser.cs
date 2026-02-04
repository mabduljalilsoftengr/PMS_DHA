using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsEmployee;
using PeshawarDHASW.Data_Layer.clsUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.User
{
    public partial class frmModifyUser : Telerik.WinControls.UI.RadForm
    {
        public frmModifyUser()
        {
            InitializeComponent();
        }
        #region LoadRequiredDataForGrid
        private void LoadRequiredDataForGrid()
        {
            try
            {
                SqlParameter[] prmtr =
                         {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Name",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtName.Text)),
                new SqlParameter("@username",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtUserName.Text)),
                new SqlParameter("@Mobile",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtMobile.Text)),
                new SqlParameter("@Address",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtAddress.Text)),
            };
                DataSet ds = cls_dl_User.UserReader(prmtr);
                grdUser_Modify.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadRequiredDataForGrid.", ex, "frmModifyUser");
                frmobj.ShowDialog();
            }
         
        }

        #endregion

        private void frmModifyUser_Load(object sender, EventArgs e)
        {
            LoadAllDataForGrid();
        }
        #region Load Data For Grid
        private void LoadAllDataForGrid()
        {
            try
            {
                SqlParameter[] prmtr =
                         {
                new SqlParameter("@Task","Select")
            };
                DataSet dst = cls_dl_User.UserReader(prmtr);
                grdUser_Modify.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadAllDataForGrid.", ex, "frmModifyUser");
                frmobj.ShowDialog();
            }
         
        }
        #endregion
       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRequiredDataForGrid();
        }

        private void grdUser_Modify_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int rowindex = grdUser_Modify.CurrentCell.RowIndex;
                int userid = int.Parse(grdUser_Modify.Rows[rowindex].Cells[0].Value.ToString());
                if (e.Column.Name == "btnModify")
                {
                    frmUserInsertion obj = new frmUserInsertion(userid);
                    obj.ShowDialog();
                    LoadRequiredDataForGrid();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdUser_Modify_CellClick.", ex, "frmModifyUser");
                frmobj.ShowDialog();
            }
           
        }
    }
}
