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
    public partial class frmSearchContractor : Telerik.WinControls.UI.RadForm
    {
        public frmSearchContractor()
        {
            InitializeComponent();
            dlDataType.SelectedIndex = 0;
        }

        private void btnContractorVendorNew_Click(object sender, EventArgs e)
        {
            frmContractorNew con = new frmContractorNew();
            con.ShowDialog();
            LoadingData();
        }

        private void frmSearchContractor_Load(object sender, EventArgs e)
        {
            LoadContractorType();
            LoadingData();
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
                SqlParameter[] param = {
                    new SqlParameter("@Task","SelectContractorVendor"),
                    new SqlParameter("@DataType",Helper.clsPluginHelper.DbNullIfNullOrEmpty(dlDataType.SelectedItem.Text)),
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

        private void rgvContractor_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnEdit")
                {
                    string ContractorID = e.Row.Cells["ContractorID"].Value.ToString();
                    frmContractorNew obj = new frmContractorNew(ContractorID);
                    obj.ShowDialog();
                }
                if (e.Column.Name== "btnAttachment")
                {
                    string ContractorID = e.Row.Cells["ContractorID"].Value.ToString();
                    string ContractorName = e.Row.Cells["ContractorName"].Value.ToString() +":"+ e.Row.Cells["ContractorCNIC"].Value.ToString() ;
                    frmAttachmentContractor obj = new frmAttachmentContractor(ContractorID, ContractorName);
                    obj.ShowDialog();
                }
                if (e.Column.Name == "Services")
                {
                    string ContractorID = e.Row.Cells["ContractorID"].Value.ToString();
                    string ContractorName = e.Row.Cells["ContractorName"].Value.ToString() + ":" + e.Row.Cells["ContractorCNIC"].Value.ToString();
                    frmServicesContractor obj = new frmServicesContractor(ContractorID);
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
