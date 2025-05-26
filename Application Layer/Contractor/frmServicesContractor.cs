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

namespace PeshawarDHASW.Application_Layer.Contractor
{
    public partial class frmServicesContractor : Telerik.WinControls.UI.RadForm
    {
        public frmServicesContractor()
        {
            InitializeComponent();
        }

        public frmServicesContractor(string ContractorID,bool flag)
        {
            InitializeComponent();
            gbservice.Enabled = false;
            btnServiceNew.Visible = false;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","SelectContractorVendorByID"),
                    new SqlParameter("@ContractorID",ContractorID)
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(
                    Helper.SQLHelper.createConnection(),
                    CommandType.StoredProcedure, "USP_Contractor_Vendor", param);
                lblContractorID.Text = ds.Tables[0].Rows[0]["ContractorID"].ToString();
                ContractorName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                ContractorCNIC.Text = ds.Tables[0].Rows[0]["ContractorCNIC"].ToString();
                ContractorCompany.Text = ds.Tables[0].Rows[0]["ContractorCompany"].ToString();
                ContractorMobileNo.Text = ds.Tables[0].Rows[0]["ContractorMobileNo"].ToString();
                ContactorAddress.Text = ds.Tables[0].Rows[0]["ContractorAddress"].ToString();
                ContractorNTN.Text = ds.Tables[0].Rows[0]["ContractorNTN"].ToString();
                DateTime Registerationdate = DateTime.Now;
                bool flagRegisterationdate = DateTime.TryParse(ds.Tables[0].Rows[0]["DateofRegistration"].ToString(), out Registerationdate);
                DateTime ExpirDate = DateTime.Now;
                bool flagExpirDate = DateTime.TryParse(ds.Tables[0].Rows[0]["DateofExpiry"].ToString(), out ExpirDate);
                DateofRegistration.Value = Registerationdate;
                ExpiryDate.Value = ExpirDate;
                ContractorRemarks.Text = ds.Tables[0].Rows[0]["ContractorRemarks"].ToString();
                ContractorStatus.Text = ds.Tables[0].Rows[0]["ContractorStatus"].ToString();
                string PaymentType = ds.Tables[0].Rows[0]["TransactionType"].ToString();
                Services_DDL();
                DDL_DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public frmServicesContractor(string ContractorID)
        {
            InitializeComponent();
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","SelectContractorVendorByID"),
                    new SqlParameter("@ContractorID",ContractorID)
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(
                    Helper.SQLHelper.createConnection(),
                    CommandType.StoredProcedure, "USP_Contractor_Vendor", param);
                lblContractorID.Text = ds.Tables[0].Rows[0]["ContractorID"].ToString();
                ContractorName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                ContractorCNIC.Text = ds.Tables[0].Rows[0]["ContractorCNIC"].ToString();
                ContractorCompany.Text = ds.Tables[0].Rows[0]["ContractorCompany"].ToString();
                ContractorMobileNo.Text = ds.Tables[0].Rows[0]["ContractorMobileNo"].ToString();
                ContactorAddress.Text = ds.Tables[0].Rows[0]["ContractorAddress"].ToString();
                ContractorNTN.Text = ds.Tables[0].Rows[0]["ContractorNTN"].ToString();
                DateTime Registerationdate = DateTime.Now;
                bool flagRegisterationdate = DateTime.TryParse(ds.Tables[0].Rows[0]["DateofRegistration"].ToString(), out Registerationdate);
                DateTime ExpirDate = DateTime.Now;
                bool flagExpirDate = DateTime.TryParse(ds.Tables[0].Rows[0]["DateofExpiry"].ToString(), out ExpirDate);
                DateofRegistration.Value = Registerationdate;
                ExpiryDate.Value = ExpirDate;
                ContractorRemarks.Text = ds.Tables[0].Rows[0]["ContractorRemarks"].ToString();
                ContractorStatus.Text = ds.Tables[0].Rows[0]["ContractorStatus"].ToString();
                string PaymentType = ds.Tables[0].Rows[0]["TransactionType"].ToString();
                Services_DDL();
                DDL_DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void Services_DDL()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","ContractorServiceList")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "USP_tbl_Contractor_Vendor_Services", param );
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtpServices.DataSource = ds.Tables[0].DefaultView;
                        dtpServices.DisplayMember = "ServiceName";
                        dtpServices.ValueMember = "ID";
                        dtpServices.Tag = "ServiceCode";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void frmServicesContractor_Load(object sender, EventArgs e)
        {

        }

        private void DDL_DataLoad()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","Selectbycontractor"),
                    new SqlParameter("@ContractorID",lblContractorID.Text),
                };
                gdvServices.DataSource = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection()
                     , CommandType.StoredProcedure, "USP_tbl_Contractor_Vendor_Services", param
                    ).Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnServiceNew_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (var item in gdvServices.Rows)
                {
                    if (dtpServices.SelectedItem.Text.ToString() == item.Cells["ServiceName"].Value.ToString())
                    {
                        MessageBox.Show(dtpServices.SelectedItem.Text.ToString() + " is already in the List.");
                        return;
                    }
                }

                SqlParameter[] param = {
                    new SqlParameter("@Task","NewEntryServices"),
                    new SqlParameter("@ID",0),
                    new SqlParameter("@ContractorID",lblContractorID.Text),
                    new SqlParameter("@ServiceID",dtpServices.SelectedItem.Value),
                    new SqlParameter("@ServiceCode",dtpServices.SelectedItem.Tag),
                    new SqlParameter("@ServiceName",dtpServices.SelectedItem.Text),
                    new SqlParameter("@UserID",clsUser.ID),
                    new SqlParameter("@EntryDate",DateTime.Now),
                };
                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection()
                     ,CommandType.StoredProcedure, "USP_tbl_Contractor_Vendor_Services", param
                    );
                DDL_DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gdvServices_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnRemove")
            {
                string ID = e.Row.Cells["ID"].Value.ToString();
                if(MessageBox.Show("Warning","Are you Sure",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SqlParameter[] param = {
                    new SqlParameter("@Task","DeleteServicebyID"),
                    new SqlParameter("@ID",ID),
                };
                    int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection()
                         , CommandType.StoredProcedure, "USP_tbl_Contractor_Vendor_Services", param
                        );
                }
                DDL_DataLoad();
            }
        }
    }
}
