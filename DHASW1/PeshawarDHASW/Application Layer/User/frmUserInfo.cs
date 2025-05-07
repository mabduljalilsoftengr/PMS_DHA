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
    public partial class frmUserInfo : Telerik.WinControls.UI.RadForm
    {
        public frmUserInfo()
        {
            InitializeComponent();
        }
        private void DataLoadingofUser()
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@Task", "UserInfo") };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_UserInfo", param);
                rgvUserInfo.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            DataLoadingofUser();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataLoadingofUser();
        }

        private void rgvUserInfo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Signature")
            {
                int ID = int.Parse(e.Row.Cells["id"].Value.ToString());
                string UserName = e.Row.Cells["username"].Value.ToString();
                UpdateSignature frm = new UpdateSignature(ID, UserName);
                frm.ShowDialog();
                DataLoadingofUser();
            }
        }
    }
}
