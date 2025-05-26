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

namespace PeshawarDHASW.Application_Layer.FileBock
{
    public partial class frmFileBlock : Telerik.WinControls.UI.RadForm
    {
        public frmFileBlock()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        private void frmFileBlock_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","DataView"),
               // new SqlParameter("@FileMapKey",),
                new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtPlotNo.Text))
                //new SqlParameter("@MemberName",),
                //new SqlParameter("@Father",),
                //new SqlParameter("@ACBlock",),
                //new SqlParameter("@FileLock",),
                //new SqlParameter("@LockRemarks",),
                //new SqlParameter("@LockbyUser",),
                //new SqlParameter("@LockDate",""),
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", param);
            FileBlockRecord.DataSource = ds.Tables[0].DefaultView;
        }

        private void FileBlockRecord_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Edit")
            {
                frmLockEdit frmobj = new frmLockEdit(e);
                frmobj.ShowDialog();
                btnFind_Click(null, null);
            }
        }
    }
}
