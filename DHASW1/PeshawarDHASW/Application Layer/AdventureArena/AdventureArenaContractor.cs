using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.AdventureArena
{
    public partial class AdventureArenaContractor : Telerik.WinControls.UI.RadForm
    {
        public AdventureArenaContractor()
        {
            InitializeComponent();
            DataLoadingTicketInformation();
        }

        private void DataLoadingTicketInformation()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","ContractorSelect")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureContractor", param
                    );
                dgvContractor.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvContractor_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;
                bool dtRegParse = DateTime.TryParse(e.Row.Cells["DateofRegistration"].Value.ToString(), out dt);
                ContractorID.Text = e.Row.Cells["ContractorID"].Value.ToString();
                ContractorName.Text = e.Row.Cells["ContractorName"].Value.ToString();
                ContractorMobileNo.Text = e.Row.Cells["ContractorMobileNo"].Value.ToString();
                ContractorCNIC.Text = e.Row.Cells["ContractorCNIC"].Value.ToString();
                ContractorCompany.Text = e.Row.Cells["ContractorCompany"].Value.ToString();
                ContractorNTN.Text = e.Row.Cells["ContractorNTN"].Value.ToString();
                ContactorAddress.Text = e.Row.Cells["ContactorAddress"].Value.ToString();
                DateofRegistration.Value = dt.Date;
                ContractorRemarks.Text = e.Row.Cells["Remarks"].Value.ToString();
                Helper.clsPluginHelper.RadDropDownSelectByText(ContractorStatus, e.Row.Cells["ContractorStatus"].Value.ToString());
            }
            catch (Exception)
            {
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ContractorID.Text = "0";
            ContractorName.Text = "";
            ContractorMobileNo.Text = "";
            ContractorCNIC.Text = "";
            ContractorCompany.Text = "";
            ContractorNTN.Text = "";
            ContactorAddress.Text = "";
            DateofRegistration.Value = DateTime.Now;
            ContractorRemarks.Text = "";
        }

        private void btnSavechanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ContractorName.Text))
                {
                    MessageBox.Show("Name Field is Empty");
                    return;
                }
                if (string.IsNullOrWhiteSpace(ContractorCNIC.Text))
                {
                    MessageBox.Show("CNIC Field is Empty");
                    return;
                }
                if (string.IsNullOrWhiteSpace(ContractorMobileNo.Text))
                {
                    MessageBox.Show("MobileNo Field is Empty");
                    return;
                }
                SqlParameter[] param = {
                    new SqlParameter("@Task","NewContractor"),
                    new SqlParameter("@ContractorID",ContractorID.Text),
                    new SqlParameter("@ContractorName",ContractorName.Text),
                    new SqlParameter("@ContractorCNIC", ContractorCNIC.Text),
                    new SqlParameter("@ContractorMobileNo",ContractorMobileNo.Text),
                    new SqlParameter("@ContactorAddress", ContactorAddress.Text),
                    new SqlParameter("@ContractorCompany",ContractorCompany.Text),
                    new SqlParameter("@ContractorNTN",ContractorNTN.Text),
                    new SqlParameter("@DateofRegistration",DateofRegistration.Value),
                    new SqlParameter("@Remarks",ContractorRemarks.Text),
                    new SqlParameter("@ContractorStatus",ContractorStatus.SelectedItem.Text)
                };
                int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_AdventureContractor", param);
                if (result>0)
                {
                    MessageBox.Show("Save Changes Successfully.");
                    ContractorID.Text = "0";
                    ContractorName.Text = "";
                    ContractorMobileNo.Text = "";
                    ContractorCNIC.Text = "";
                    ContractorCompany.Text = "";
                    ContractorNTN.Text = "";
                    ContactorAddress.Text = "";
                    DateofRegistration.Value = DateTime.Now;
                    ContractorRemarks.Text = "";
                    ContractorStatus.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
