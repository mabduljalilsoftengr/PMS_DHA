using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Online_Files
{
    public partial class frmOnlineFiles : Telerik.WinControls.UI.RadForm
    {
        public frmOnlineFiles()
        {
            InitializeComponent();
            DataView();
        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            frmNewOnlineFile obj = new frmNewOnlineFile();
            obj.ShowDialog();
            DataView();
        }

        private void DataView()
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","DataView")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection_ComplaintMgt(), CommandType.StoredProcedure, "dbo.USP_File", param);
                gdvFiledata.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
