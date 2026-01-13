using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.FileMap.TradeOff
{
    public partial class frmTradeOffDataView : Telerik.WinControls.UI.RadForm
    {
        public frmTradeOffDataView()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","TradeOffDataView")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_FileMap", param);
                rgvTradeOff.DataSource = ds.Tables[0].DefaultView;
                rgvTradeOffforFiles.DataSource = ds.Tables[1].DefaultView;
                dgvTradeOffOfferedFiles.DataSource = ds.Tables[2].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmTradeOffDataView_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(null,null);
        }

        private void btnNewTradeOff_Click(object sender, EventArgs e)
        {
            frm_TradeOffCreate obj = new frm_TradeOffCreate();
            obj.ShowDialog();
        }
    }
}
