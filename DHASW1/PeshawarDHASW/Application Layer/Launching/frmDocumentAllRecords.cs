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
    public partial class frmDocumentAllRecords : Telerik.WinControls.UI.RadForm
    {
        public frmDocumentAllRecords()
        {
            InitializeComponent();
        }

        private void btnSearchComplete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                new SqlParameter("@ApplicantName", Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtApplicantNameCA.Text)),
                new SqlParameter("@CNIC_NICOP",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC_CA.Text)),
                new SqlParameter("@MobileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMobileNoCA.Text)),
                new SqlParameter("@FormNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFormNoCA.Text))
            };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationInfoDocRecord", param);
                DGV_CompleteForms.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in DGV_CompleteForms.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGV_CompleteForms_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnViewImage")
            {
                string ApplicationID = e.Row.Cells["ApplicationID"].Value.ToString();
                frmDocImageViewing obj = new frmDocImageViewing(ApplicationID);
                obj.ShowDialog();
            }
        }
    }
}
