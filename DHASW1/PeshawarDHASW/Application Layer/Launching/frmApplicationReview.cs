using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class frmApplicationReview : Telerik.WinControls.UI.RadForm
    {
        public frmApplicationReview()
        {
            InitializeComponent();
        }

        private void frmApplicationReview_Load(object sender, EventArgs e)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","ReviewApplication")
            };
            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.Get_ApplicationReview", param);
            DGV_ReviewInfo.DataSource = ds.Tables[0].DefaultView;
        }

        private void DGV_ReviewInfo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            txtFormNo.Text = e.Row.Cells["FormNo"].Value.ToString();
            txtCategoryName.Text = e.Row.Cells["Catergory"].Value.ToString();
            txtAppName.Text = e.Row.Cells["ApplicantName"].Value.ToString();
            txtPlotSize.Text = e.Row.Cells["PlotSize"].Value.ToString();
            txtCNIC.Text = e.Row.Cells["CNIC_NICOP"].Value.ToString();
            txtMobileNo.Text = e.Row.Cells["ConnectionType"].Value.ToString() +"-"+ e.Row.Cells["MobileNo"].Value.ToString();
            txtEmail.Text  = e.Row.Cells["Email"].Value.ToString();
        }
    }
}
