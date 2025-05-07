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
    public partial class frmLockEdit : Telerik.WinControls.UI.RadForm
    {
        public frmLockEdit()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        public string FileMapKey { get; set; }
        public frmLockEdit(Telerik.WinControls.UI.GridViewCellEventArgs data)
        {
            InitializeComponent();
            FileMapKey = data.Row.Cells["FileMapKey"].Value.ToString();
            txtFileNo.Text=   data.Row.Cells["FileNo"].Value.ToString();
            txtPlotNo.Text=   data.Row.Cells["PlotNo"].Value.ToString();
            txtName.Text=   data.Row.Cells["MemberName"].Value.ToString();
            txtFather.Text =  data.Row.Cells["Father"].Value.ToString();

            string val = data.Row.Cells["FileLock"].Value.ToString();
            bool rdlockstatus = false;
            bool Statusvalue = bool.TryParse(data.Row.Cells["FileLock"].Value.ToString(),out rdlockstatus);
            if (rdlockstatus == true)
            {
                rdStatus.CheckState = CheckState.Checked;
                LockStatus = true;
            }
            else
            {
                rdStatus.CheckState = CheckState.Unchecked;
                LockStatus = false;
            }
            txtremarks.Text = data.Row.Cells["LockRemarks"].Value.ToString();
            //data.Row.Cells["LockbyUser"].Value.ToString();
            //data.Row.Cells["LockDate"].Value.ToString();
        }

        private void frmLockEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@Task","FileLockSetting"),
                new SqlParameter("@FileMapKey",FileMapKey),
                new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty( txtPlotNo.Text)),
                new SqlParameter("@FileLock", LockStatus),
                new SqlParameter("@LockRemarks",txtremarks.Text),
                new SqlParameter("@LockbyUser",clsUser.ID),
                //new SqlParameter("@LockDate",""),
                };
                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileLock", param);
                if (result > 0)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Lock Process is Incomplete due incomplete request. \n"+ex.Message);
            }       
        }

        public bool LockStatus { get; set; }
        private void rdStatus_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState.ToString() == "On")
            {
                LockStatus = true;
            }
            else
            {
                LockStatus = false;
            }
           
        }
    }
}
