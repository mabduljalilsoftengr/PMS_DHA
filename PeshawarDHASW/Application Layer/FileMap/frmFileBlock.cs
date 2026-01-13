using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap
{
    public partial class frmFileBlock : Telerik.WinControls.UI.RadForm
    {
        public frmFileBlock()
        {
            InitializeComponent();
        }

        private void btnAddNewFile_Click(object sender, EventArgs e)
        {
            FileBlockManagement.AddNewFile obj = new FileBlockManagement.AddNewFile();
            obj.ShowDialog();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                                    new SqlParameter("@Task","FileNoSearch"),
                                    new SqlParameter("@FileNo",txtFileNo.Text)
                                    };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.usp_tbl_AcLockforFile", param);
            FileLockInformation.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
