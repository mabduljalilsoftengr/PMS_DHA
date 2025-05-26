using PeshawarDHASW.Application_Layer.CustomDialog;
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
    public partial class frmSearchUser : Telerik.WinControls.UI.RadForm
    {
        public frmSearchUser()
        {
            InitializeComponent();
        }

        private void frmSearchUser_Load(object sender, EventArgs e)
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
                grdUser_Search.DataSource = dst.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadAllDataForGrid.", ex, "frmSearchUser");
                frmobj.ShowDialog();
            }
            
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRequiredDataForGrid();
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
                grdUser_Search.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadAllDataForGrid.", ex, "frmSearchUser");
                frmobj.ShowDialog();
            }
        
        }

        #endregion
    }
}
