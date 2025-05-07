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

namespace PeshawarDHASW.Application_Layer.FileMap.FileBlockManagement
{
    public partial class AddNewFile : Telerik.WinControls.UI.RadForm
    {
        public int AcFileLockID { get; set; } = 0;
        public AddNewFile()
        {
            InitializeComponent();
            btnSaveUpdate.Enabled = false;
        }

        public AddNewFile(int AcFileLockId)
        {
            AcFileLockID = AcFileLockId;
            txtFileNo.ReadOnly = true;
            InitializeComponent();
        }


        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (AcFileLockID == 0)
            {
                SqlParameter[] param = {
                                new SqlParameter("@Task","NewRecord"),
                               // new SqlParameter("@AcLockID",),
                                new SqlParameter("@FileNo",txtFileNo.Text),
                                new SqlParameter("@FileMapKey",FileMapKey),
                                new SqlParameter("@Dateofblock",dtpLockDate.Value),
                                new SqlParameter("@UserID",clsUser.ID),
                                new SqlParameter("@Status",chkStatus.CheckState),
                                new SqlParameter("@Remarks", txtRemarks.Text)
             };
                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_AcLockforFile", param);
                if (result > 0)
                {
                    MessageBox.Show("File No is Added to Lock List Sucessfully.", "Information");
                    this.Close();
                }
            }
            else
            {
                SqlParameter[] param = {
                                new SqlParameter("@Task","NewRecord"),
                                new SqlParameter("@AcLockID",AcFileLockID),
                                new SqlParameter("@FileNo",txtFileNo.Text),
                                new SqlParameter("@FileMapKey",FileMapKey),
                                new SqlParameter("@Dateofblock",dtpLockDate.Value),
                                new SqlParameter("@UserID",clsUser.ID),
                                new SqlParameter("@Status",chkStatus.CheckState),
                                new SqlParameter("@Remarks", txtRemarks.Text)
             };
                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_AcLockforFile", param);
                if (result > 0)
                {
                    MessageBox.Show("File No is Update to Lock List Sucessfully.", "Information");
                    this.Close();
                }
            }
        }

        public int FileMapKey { get; set; }
        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                                    new SqlParameter("@Task","FileNoSearch"),
                                    new SqlParameter("@FileNo",txtFileNo.Text)
                                    };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_AcLockforFile", param);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count >0)
                {
                    FileMapKey = int.Parse(ds.Tables[0].Rows[0]["FileMapKey"].ToString());
                    btnSaveUpdate.Enabled = true;
                }
                else
                {
                    btnSaveUpdate.Enabled = false;
                    MessageBox.Show("Invalid File No is Entered or File No is not Exist.");
                }
            }
            else
            {
                btnSaveUpdate.Enabled = false;
            }
        }
    }
}
