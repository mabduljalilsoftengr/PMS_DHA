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
    public partial class frmContractorNew : Telerik.WinControls.UI.RadForm
    {
        public frmContractorNew()
        {
            InitializeComponent();
            rdContractor.CheckState = CheckState.Checked;
            ContractorStatus.SelectedIndex = 0;
        }

        public frmContractorNew(string ContractorID,bool flag)
        {

            InitializeComponent();
            btnSaveChanges.Visible = false;
            gpContractorInfo.Enabled = false;
            gpfeeInfo.Enabled = false;
            gpSelection.Enabled = false;
            gpReceive.Enabled = false;

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

                if (ds.Tables[0].Rows[0]["DataType"].ToString() == "Contractor")
                {
                    rdContractor.CheckState = CheckState.Checked;
                    // rdContractor_ToggleStateChanged(null, null);
                    Helper.clsPluginHelper.RadDropDownSelectByText(ddlContractorList, ds.Tables[0].Rows[0]["ContractorTitle"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DataType"].ToString() == "Vendor")
                {
                    rdVendor.CheckState = CheckState.Checked;
                    txtContractorFeeAmount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                    //  rdVendor_ToggleStateChanged(null, null);
                    Helper.clsPluginHelper.RadDropDownSelectByText(ddlVendorList, ds.Tables[0].Rows[0]["ContractorTitle"].ToString());
                }
                string PaymentType = ds.Tables[0].Rows[0]["TransactionType"].ToString();
                Helper.clsPluginHelper.RadDropDownSelectByText(drpPaymentMethod, PaymentType);
                DDNo.Text = ds.Tables[0].Rows[0]["DDNo"].ToString();
                DateTime ReceiveDate = DateTime.Now;
                bool flagReceiveDate = DateTime.TryParse(ds.Tables[0].Rows[0]["ReceiveDate"].ToString(), out ExpirDate);
                dtpReceDate.Value = ReceiveDate;
                txtbank.Text = ds.Tables[0].Rows[0]["BankName"].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public frmContractorNew(string ContractorID)
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

                if (ds.Tables[0].Rows[0]["DataType"].ToString()=="Contractor")
                {
                    rdContractor.CheckState = CheckState.Checked;
                   // rdContractor_ToggleStateChanged(null, null);
                    Helper.clsPluginHelper.RadDropDownSelectByText(ddlContractorList, ds.Tables[0].Rows[0]["ContractorTitle"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DataType"].ToString() == "Vendor")
                {
                    rdVendor.CheckState = CheckState.Checked;
                    txtContractorFeeAmount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                  //  rdVendor_ToggleStateChanged(null, null);
                    Helper.clsPluginHelper.RadDropDownSelectByText(ddlVendorList, ds.Tables[0].Rows[0]["ContractorTitle"].ToString());
                }
                string PaymentType = ds.Tables[0].Rows[0]["TransactionType"].ToString();
                 Helper.clsPluginHelper.RadDropDownSelectByText(drpPaymentMethod, PaymentType);
                DDNo.Text = ds.Tables[0].Rows[0]["DDNo"].ToString();
                DateTime ReceiveDate = DateTime.Now;
                bool flagReceiveDate = DateTime.TryParse(ds.Tables[0].Rows[0]["ReceiveDate"].ToString(), out ExpirDate);
                dtpReceDate.Value = ReceiveDate;
                txtbank.Text = ds.Tables[0].Rows[0]["BankName"].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void Contractor_DDL()
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","ContractorList")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_Contractor_Vendor_Type", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlContractorList.DataSource = ds.Tables[0].DefaultView;
                        ddlContractorList.DisplayMember = "ContractorName";
                        ddlContractorList.ValueMember = "TypeID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Vendor_DDL()
        {
            try
            {
                SqlParameter[] param =
                {
                     new SqlParameter("@Task","VendorList")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_Contractor_Vendor_Type", param);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlVendorList.DataSource = ds.Tables[0].DefaultView;
                        ddlVendorList.DisplayMember = "ContractorName";
                        ddlVendorList.ValueMember = "TypeID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Contractor_Vendor_FindbyTypeID(string ID)
        {
            try
            {
                int TypeID = 0;
                bool TypeIDParse = int.TryParse(ID, out TypeID);
                if (TypeIDParse ==true)
                {
                    SqlParameter[] param =
                                    {
                    new SqlParameter("@Task","Contractor_VendorbyID"),
                    new SqlParameter("@TypeID",TypeID)
                };
                    DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_Contractor_Vendor_Type", param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblgroupType.Text = ds.Tables[0].Rows[0]["GroupType"].ToString();
                            lblContractName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                            lblLimitofAwardcontract.Text = ds.Tables[0].Rows[0]["LimitofAwardofContract"].ToString();
                            lblRegFeeCorp.Text = ds.Tables[0].Rows[0]["RegistrationFeeCorporate"].ToString();
                            lblRegFeeNonCorp.Text = ds.Tables[0].Rows[0]["RegistrationFeeNonCorporate"].ToString();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contractor Type Error"+ex.Message);
            }
        }
        private void frmContractorNew_Load(object sender, EventArgs e)
        {
            
        }

        private void rdContractor_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdContractor.CheckState == CheckState.Checked)
            {
                rdCorporateFee.CheckState = CheckState.Checked;
                rdNonCorporateFee.Enabled = false;
                txtContractorFeeAmount.Text = lblRegFeeCorp.Text;
                Contractor_DDL();
                ddlVendorList.DataSource = null;
            }

        }

        private void rdVendor_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdVendor.CheckState == CheckState.Checked)
            {

                rdCorporateFee.CheckState = CheckState.Checked;
                rdNonCorporateFee.Enabled = true;
                txtContractorFeeAmount.Text = lblRegFeeCorp.Text;
                Vendor_DDL();
                ddlContractorList.DataSource = null;
            }
        }

        private void ddlContractorList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                Contractor_Vendor_FindbyTypeID(ddlContractorList.SelectedItem.Value.ToString());
                txtContractorFeeAmount.Text = lblRegFeeCorp.Text;
            }
            catch (Exception)
            {
            }
           
        }

        private void ddlVendorList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                Contractor_Vendor_FindbyTypeID(ddlVendorList.SelectedItem.Value.ToString());
            }
            catch (Exception)
            {
            }
           
        }

        private void radGroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void rdCorporateFee_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdCorporateFee.CheckState == CheckState.Checked)
            {
                txtContractorFeeAmount.Text = lblRegFeeCorp.Text;
            }
            else
            {
                rdCorporateFee.CheckState = CheckState.Unchecked;
            }
        }

        private void rdNonCorporateFee_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdNonCorporateFee.CheckState == CheckState.Checked)
            {
                txtContractorFeeAmount.Text = lblRegFeeNonCorp.Text;
            }
            else
            {
                rdNonCorporateFee.CheckState = CheckState.Unchecked;
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","NewContractor_Vendor")
                    ,new SqlParameter("@ContractorID",lblContractorID.Text)
                    ,new SqlParameter("@DataType",rdContractor.CheckState==CheckState.Checked?"Contractor":"Vendor")
                    ,new SqlParameter("@ContractorName",ContractorName.Text)
                    ,new SqlParameter("@ContractorCNIC",ContractorCNIC.Text)
                    ,new SqlParameter("@ContractorMobileNo",ContractorMobileNo.Text)
                    ,new SqlParameter("@ContractorAddress",ContactorAddress.Text)
                    ,new SqlParameter("@ContractorCompany",ContractorCompany.Text)
                    ,new SqlParameter("@ContractorNTN",ContractorNTN.Text)
                    ,new SqlParameter("@DateofRegistration",DateofRegistration.Value.Date)
                    ,new SqlParameter("@DateofExpiry",DateTime.Now.AddYears(1))
                    ,new SqlParameter("@ContractorRemarks",ContractorRemarks.Text)
                    ,new SqlParameter("@ContractorStatus",ContractorStatus.Text)
                    ,new SqlParameter("@CorporateFeeType",rdCorporateFee.CheckState==CheckState.Checked?"Corporate-Fee":"Non-Corporate-Fee")
                    ,new SqlParameter("@Amount",txtContractorFeeAmount.Text)
                    ,new SqlParameter("@ContractorGroup",lblgroupType.Text)
                    ,new SqlParameter("@ContractorTitle",lblContractName.Text)
                    ,new SqlParameter("@LimitofAwardContract",lblLimitofAwardcontract.Text)
                    ,new SqlParameter("@TransactionType",drpPaymentMethod.SelectedItem.Text)
                    ,new SqlParameter("@BankName",txtbank.Text)
                    ,new SqlParameter("@DDNo",DDNo.Text)
                    ,new SqlParameter("@ReceiveDate",dtpReceDate.Value.Date)
                    ,new SqlParameter("@EntryDate",DateTime.Now)
                    ,new SqlParameter("@InsertBy",clsUser.ID)
                    ,new SqlParameter("@InsertDate",DateTime.Now)
                     ,new SqlParameter("@Updateby",clsUser.ID)
                    ,new SqlParameter("@UpdateDate",DateTime.Now)
                };

                int Result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),
                    CommandType.StoredProcedure,
                    "USP_Contractor_Vendor",
                    param
                    );
                if (Result>0)
                {
                    MessageBox.Show("Successfull");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error Occurs.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
