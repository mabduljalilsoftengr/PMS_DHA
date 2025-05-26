using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.FBR
{
    public partial class frmFBR_FilerNonFilerReport : Telerik.WinControls.UI.RadForm
    {
        public frmFBR_FilerNonFilerReport()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.FBR_FilerNonFiler");
                radGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(radGridView1);
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }
    }
}
