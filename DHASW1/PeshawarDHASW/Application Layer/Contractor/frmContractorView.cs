using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Contractor
{
    public partial class frmContractorView : Telerik.WinControls.UI.RadForm
    {
        public frmContractorView()
        {
            InitializeComponent();
        }
        private void LoadContractorType()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","LimitAwardContract")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),
                    CommandType.StoredProcedure,
                    "USP_Contractor_Vendor",
                    param
                    );
                ddlContractorType.DataSource = ds.Tables[0].DefaultView;
                ddlContractorType.DisplayMember = "TypeVal";
                ddlContractorType.ValueMember = "TypeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadingData()
        {
            try
            {   
                string val = string.IsNullOrWhiteSpace(dlDataType.SelectedItem.Text) ? "" : dlDataType.SelectedItem.Text;

                SqlParameter[] param = {
                    new SqlParameter("@Task","SelectContractorVendor"),
                    new SqlParameter("@DataType",Helper.clsPluginHelper.DbNullIfNullOrEmpty(val)),
                    new SqlParameter("@ContractorTitle",Helper.clsPluginHelper.DbNullIfNullOrEmpty(ddlContractorType.SelectedItem.Text))
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),
                    CommandType.StoredProcedure,
                    "USP_Contractor_Vendor",
                    param
                    );
                rgvContractor.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in rgvContractor.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmContractorView_Load(object sender, EventArgs e)
        {
            LoadContractorType();
            dlDataType.SelectedIndex = 0;
            LoadingData();
        }

        private void rgvContractor_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnEdit")
                {
                    string ContractorID = e.Row.Cells["ContractorID"].Value.ToString();
                    frmContractorNew obj = new frmContractorNew(ContractorID,false);
                    obj.ShowDialog();
                }
                if (e.Column.Name == "btnAttachment")
                {
                    string ContractorID = e.Row.Cells["ContractorID"].Value.ToString();
                    string ContractorName = e.Row.Cells["ContractorName"].Value.ToString() + ":" + e.Row.Cells["ContractorCNIC"].Value.ToString();
                    frmAttachmentContractor obj = new frmAttachmentContractor(ContractorID, ContractorName,false);
                    obj.ShowDialog();
                }
                if (e.Column.Name == "Services")
                {
                    string ContractorID = e.Row.Cells["ContractorID"].Value.ToString();
                    string ContractorName = e.Row.Cells["ContractorName"].Value.ToString() + ":" + e.Row.Cells["ContractorCNIC"].Value.ToString();
                    frmServicesContractor obj = new frmServicesContractor(ContractorID,false);
                    obj.ShowDialog();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadingData();
        }
    }
}
