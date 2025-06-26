using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    public partial class frmNewTemplateForCreateClone : Form
    {
        public frmNewTemplateForCreateClone()
        {
            InitializeComponent();
            SetupGridColumns();
            grdplandata.UserAddedRow += Grdplandata_UserAddedRow;

            txtFileNo.Visible = false;
            lblFileNo.Visible = false;

            

        }
        private int acctSeriesCounter = 1;

        private void Grdplandata_UserAddedRow(object sender, GridViewRowEventArgs e)
        {
            // Make sure it’s a data row and not the placeholder
            GridViewDataRowInfo newRow = e.Row as GridViewDataRowInfo;
            if (newRow != null)
            {
                newRow.Cells["AcctStSeries"].Value = acctSeriesCounter.ToString();
                acctSeriesCounter++;
            }
        }

        private void SetupGridColumns()
        {
            grdplandata.Columns.Clear();

            // Add Text Columns
            grdplandata.Columns.Add("Installment No", "Installment No");
            grdplandata.Columns.Add("Description", "Description");
            //grdplandata.Columns.Add("Amount", "Amount");
            GridViewDecimalColumn amountColumn = new GridViewDecimalColumn
            {
                Name = "Amount",
                HeaderText = "Amount",
                FieldName = "Amount",
                DecimalPlaces = 2,
                Minimum = 0,
                Maximum = decimal.MaxValue,
                FormatString = "{0:N2}" // Optional: shows commas and 2 decimal places
            };
            grdplandata.Columns.Add(amountColumn);


            // ComboBox Column - Installment Mode
            GridViewComboBoxColumn gvcb_InstallmentMode = new GridViewComboBoxColumn
            {
                Name = "gvcb_InstallmentMode",
                HeaderText = "Installment Mode",
                FieldName = "InstallmentMode",
                DataSource =  new string[] { "--Select--", "Development Charges", "Installment", "Corner Plot Charges", "Extra Land Charges", "Additional Development Charges", "TAX", "OTHER" } 
            };
            grdplandata.Columns.Add(gvcb_InstallmentMode);

            // ComboBox Column - Code
            GridViewComboBoxColumn gvcb_Code = new GridViewComboBoxColumn
            {
                Name = "gvcb_Code",
                HeaderText = "Code",
                FieldName = "CODE",
                DataSource = new string[] { "--Select--", "TAX", "DCDP", "DC", "INSDP", "INST", "CPC", "ELC" } // You can fetch these from DB
            };
            grdplandata.Columns.Add(gvcb_Code);

            // DateTime Column - Due Date
            GridViewDateTimeColumn gvc_DueDate = new GridViewDateTimeColumn
            {
                Name = "gvc_DueDate",
                HeaderText = "Due Date",
                FieldName = "DueDate",
                FormatString = "{0:dd-MM-yyyy}"
            };
            grdplandata.Columns.Add(gvc_DueDate);

            grdplandata.Columns.Add("AcctStSeries", "Account Series");

            grdplandata.AllowAddNewRow = true;
            grdplandata.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        }


        private void btnCreateInstallmentPlan(object sender, EventArgs e)
        {
            //int accntSeriesCounter = 1*/; // <-- Start from 1 or any desired number
           // string finalTemplateName = txtTemplateName.Text.Trim();
            string fileNo = txtFileNo.Text.Trim();
            int userId = Models.clsUser.ID;

            string finalTemplateName = txtTemplateName.Text.Trim() + clonsrt;
            //string fileNo = txtFileNo.Text.Trim();
            string plnsts = cbStatus.Text;
            string temltsts = cmbTempGroup.Text;


            // Create a DataTable to hold all installment data
            DataTable installmentTable = new DataTable();
            installmentTable.Columns.Add("InstNo", typeof(string));
            installmentTable.Columns.Add("Descp", typeof(string));
            installmentTable.Columns.Add("DueDate", typeof(DateTime));
            installmentTable.Columns.Add("Amount", typeof(decimal));
            installmentTable.Columns.Add("InstallmentMode", typeof(string));
            installmentTable.Columns.Add("CODE", typeof(string));
            installmentTable.Columns.Add("userID", typeof(int)); // Assuming Models.clsUser.ID is int
            installmentTable.Columns.Add("AcctStSeries", typeof(string));


            if (cbSpecificFilNo.Checked)
              {
                //bool hasError = false;

                foreach (GridViewRowInfo row in grdplandata.Rows)
                {
                    GridViewDataRowInfo dataRow = row as GridViewDataRowInfo;
                    if (dataRow != null) // Skip the placeholder new row
                    {
                        try
                        {
                            string instNo = Convert.ToString(dataRow.Cells["Installment No"].Value ?? string.Empty);
                            string desc = Convert.ToString(dataRow.Cells["Description"].Value ?? string.Empty);
                            string amountStr = Convert.ToString(dataRow.Cells["Amount"].Value ?? "0");
                            string installmentMode = Convert.ToString(dataRow.Cells["gvcb_InstallmentMode"].Value ?? string.Empty);
                            string code = Convert.ToString(dataRow.Cells["gvcb_Code"].Value ?? string.Empty);
                            string accntSeries = Convert.ToString(dataRow.Cells["AcctStSeries"].Value ?? string.Empty);
                            //string accntSeries = accntSeriesCounter.ToString();


                            dataRow.Cells["AcctStSeries"].Value = accntSeries;

                            DateTime dueDate = DateTime.MinValue;
                            if (dataRow.Cells["gvc_DueDate"].Value != null)
                                dueDate = Convert.ToDateTime(dataRow.Cells["gvc_DueDate"].Value);

                            decimal amount = 0;
                            decimal.TryParse(amountStr, out amount);
                            // Added new code and commented old code

                            // Add a new row to the DataTable for each installment
                        installmentTable.Rows.Add(
                            instNo,
                            desc,
                            dueDate,
                            amount,
                            installmentMode,
                            code,
                            Models.clsUser.ID,
                            accntSeries
                        );

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while saving: " + ex.Message);
                            return;
                        }
                    }
                }


                try
                {
                    // Call the method to bulk insert  store procedure name is "usp_InsertInstallmentPlan"
                    int result = cls_dl_instPlan.BulkInsertInstallments(installmentTable, fileNo, plnsts, temltsts, finalTemplateName, userId);

                    if (result <= 0)
                    {
                        MessageBox.Show("Failed to insert installments");
                        return;
                    }
                    MessageBox.Show("Installments saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while saving: " + ex.Message);
                }

                grdplandata.Rows.Clear();

               

            }
            else // this is for Clone 
            {

                foreach (GridViewRowInfo row in grdplandata.Rows)
                {
                    GridViewDataRowInfo dataRow = row as GridViewDataRowInfo;
                    if (dataRow != null) // Skip the placeholder new row
                    {
                        try
                        {
                            string instNo = Convert.ToString(dataRow.Cells["Installment No"].Value ?? string.Empty);
                            string desc = Convert.ToString(dataRow.Cells["Description"].Value ?? string.Empty);
                            string amountStr = Convert.ToString(dataRow.Cells["Amount"].Value ?? "0");
                            string installmentMode = Convert.ToString(dataRow.Cells["gvcb_InstallmentMode"].Value ?? string.Empty);
                            string code = Convert.ToString(dataRow.Cells["gvcb_Code"].Value ?? string.Empty);
                            string accntSeries = Convert.ToString(dataRow.Cells["AcctStSeries"].Value ?? string.Empty);

                            // string accntSeries = accntSeriesCounter.ToString();


                            dataRow.Cells["AcctStSeries"].Value = accntSeries;

                            DateTime dueDate = DateTime.MinValue;
                            if (dataRow.Cells["gvc_DueDate"].Value != null)
                                dueDate = Convert.ToDateTime(dataRow.Cells["gvc_DueDate"].Value);

                            decimal amount = 0;
                            decimal.TryParse(amountStr, out amount);
                            // Added new code and commented old code

                            // Add a new row to the DataTable for each installment
                            installmentTable.Rows.Add(
                                instNo,
                                desc,
                                dueDate,
                                amount,
                                installmentMode,
                                code,
                                Models.clsUser.ID,
                                accntSeries
                            );

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while saving: " + ex.Message);
                            return;
                        }
                    }
                }


                try
                {
                    // Call the method to bulk insert  store procedure name is "usp_InsertInstallmentPlan"
                    int result = cls_dl_instPlan.BulkInsertInstallments(installmentTable, fileNo, plnsts, temltsts, finalTemplateName, userId);

                    if (result <= 0)
                    {
                        MessageBox.Show("Failed to insert installments");
                        return;
                    }
                    MessageBox.Show("Installments saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while saving: " + ex.Message);
                }

                grdplandata.Rows.Clear();
            }

        }

        string clonsrt = "";
        private void cbCreateClone_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCreateClone.Checked)
            {
                cbSpecificFilNo.Enabled = false;

                clonsrt = " - For Clone";
            }
            else
            {
                cbSpecificFilNo.Enabled = true;

                clonsrt = "";
            }
        }


        private bool IsFileNoExists(string fileNo)
        {
            SqlParameter[] param =
             {
                new SqlParameter("@Task", "IsFileNoAlreadyExist"),
                new SqlParameter("@FileNoForReview", fileNo)
            };
            DataSet ds = clsInstallmentTemplate.CreateInsallmentTemplate(param);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int count = Convert.ToInt32(ds.Tables[0].Rows[0]["FileNoCount"]);
                return count > 0;
            }

            return false;
        }

        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            
            string fileNo = txtFileNo.Text;

            if (string.IsNullOrEmpty(fileNo))
                return;

            // Check if the file number exists in the database
            if (IsFileNoExists(fileNo))
            {
                DialogResult result = RadMessageBox.Show(
                    "This File No is already exist. Do you want to review it?",
                    "Duplicate File No",
                    MessageBoxButtons.YesNo,
                    RadMessageIcon.Question);

                if (result == DialogResult.Yes)
                {

                    frmReviewPlanAgainstFileNo reviewForm = new frmReviewPlanAgainstFileNo(fileNo);
                    reviewForm.ShowDialog(); //.Show();
                }
            }
        }

        
        private void cbSpecificFilNo_CheckedChanged(object sender, EventArgs e)
        {


            if (cbSpecificFilNo.Checked)
            {
                // Disable cbCreateClone
                cbCreateClone.Enabled = false;

                // Enable textbox and label
                txtFileNo.Enabled = true;
                lblFileNo.Enabled = true;

                txtFileNo.Visible = true;
                lblFileNo.Visible = true;
            }
            else
            {
                cbCreateClone.Enabled = true;

                txtFileNo.Enabled = false;
                lblFileNo.Enabled = false;

                txtFileNo.Visible = false;
                lblFileNo.Visible = false;
            }
        }

        private void frmNewTemplateForCreateClone_Load(object sender, EventArgs e)
        {
            //new added code
            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, "SELECT [InstallmentTemplateStatusID] ,[InstallmentTemplateStatus]  FROM [dbo].[tbl_InstallmentTemplateStatusType]");
            if (ds.Tables.Count > 0)
            {
                cbStatus.DataSource = ds.Tables[0];
                cbStatus.ValueMember = "InstallmentTemplateStatusID";
                cbStatus.DisplayMember = "InstallmentTemplateStatus";
            }

            DataSet dsTempGroup = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, "select PlanGroupID,Name from tbl_InstallmentTemplateGroup");
            if (dsTempGroup.Tables.Count > 0)
            {
                cmbTempGroup.DataSource = dsTempGroup.Tables[0];
                cmbTempGroup.ValueMember = "PlanGroupID";
                cmbTempGroup.DisplayMember = "Name";
            }
        }
    }
}
