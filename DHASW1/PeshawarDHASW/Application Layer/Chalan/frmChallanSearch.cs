using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Report.Challan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Chalan
{
    public partial class frmChallanSearch : Telerik.WinControls.UI.RadForm
    {
        public frmChallanSearch()
        {
            InitializeComponent();
        }

        public frmChallanSearch(string ChallanNo)
        {
            InitializeComponent();
        }

        private void frmChallanSearch_Load(object sender, EventArgs e)
        {
            
            FillDataGrid(null);
            //gridViewTemplate1.Columns["ChallanID"].IsVisible = false;
            //gridViewTemplate1.Columns["SerialNo"].Width = 55;
            //gridViewTemplate1.Columns["SerialNo"].HeaderText = "S. No.";
            //gridViewTemplate1.Columns["Particular"].Width = 330;
            //gridViewTemplate1.Columns["Amount"].Width = 100;
        }

        private void dgChallanSearch_RowSourceNeeded(object sender, GridViewRowSourceNeededEventArgs e)
        {
            //DataRowView rowView = e.ParentRow.DataBoundItem as DataRowView;
            //DataRow[] rows = rowView.Row.GetChildRows("ProductModel_Product");
            //foreach (DataRow dataRow in rows)
            //{
            //    GridViewRowInfo row = e.Template.Rows.NewRow();
            //    row.Cells["Name"].Value = dataRow["Name"];
            //    row.Cells["ProductNumber"].Value = dataRow["ProductNumber"];
            //    row.Cells["Color"].Value = dataRow["Color"];
            //    row.Cells["ListPrice"].Value = dataRow["ListPrice"];
            //    row.Cells["Size"].Value = dataRow["Size"];
            //    row.Cells["Weight"].Value = dataRow["Weight"];
            //    row.Cells["DiscontinuedDate"].Value = dataRow["DiscontinuedDate"];
            //    e.SourceCollection.Add(row);
            //}
        }

        private void btnCreateButton_Click(object sender, EventArgs e)
        {
            frmCreateChallan fm = new frmCreateChallan();
            fm.Show();
            btnSearch_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgChallanSearch.TableElement.Text = "";
            DateTime? dt = null;
            if (string.IsNullOrEmpty(ChallanDate.Text))
                dt = null;
            else
                dt = ChallanDate.Value.Date;
            FillDataGrid(dt);
        }

      
        private void FillDataGrid(DateTime? dt)
        {
            try
            {
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","GetChallanDetailSearch"),
                new SqlParameter("@FileNo", string.IsNullOrEmpty(txtFileNo.Text.Trim())? null : txtFileNo.Text.Trim()),
                new SqlParameter("@ChalanNo", string.IsNullOrEmpty(txtChallanNo.Text.Trim())? null : txtChallanNo.Text.Trim()),
                new SqlParameter("@ClearDate", dt),

                };
                DataSet ds = cls_dl_Challan.Challan_Reader(prm);
                if (ds.Tables.Count > 0)
                {
                    ChallanDetailDS _ds = new ChallanDetailDS();
                    _ds.Tables[0].Merge(ds.Tables[0]);
                    _ds.Tables[1].Merge(ds.Tables[1]);
                    dgChallanSearch.DataSource = _ds.Tables[0];
                    gridViewTemplate1.DataSource = _ds.Tables[1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtfileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch_Click(null, null);
            }
        }

        private void txtplotno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch_Click(null, null);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFileNo.Clear();
            txtChallanNo.Clear();
            this.ChallanDate.NullableValue = null;
            this.ChallanDate.SetToNullValue();
            btnSearch_Click(null, null);
        }

        private void ChallanDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch_Click(null, null);
            }
        }

        private void dgChallanSearch_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Edit")
                {
                    if (e.Row.Cells["Status"].Value.ToString() == "Pending")
                    {
                        if (e.Row.Cells["ChallanGroup"].Value.ToString()== "Normal")
                        {
                            frmCreateChallan frm = new frmCreateChallan(e.Row.Cells["ChallanID"].Value.ToString());
                            frm.ShowDialog();
                            btnSearch_Click(null, null);
                        }
                       else if (e.Row.Cells["ChallanGroup"].Value.ToString() == "TB-BC-Challan")
                        {
                            frmTP_BC_Challan frm = new frmTP_BC_Challan(e.Row.Cells["ChallanID"].Value.ToString());
                            frm.ShowDialog();
                            btnSearch_Click(null, null);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Unable to modify Recieved Challan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }   
                }
                else if (e.Column.Name == "PrintPreview")
                {
                    DataSet ds = new DataSet();
                    SqlParameter[] prm3 =
                    {
                        new SqlParameter("@Task","GetChallReportDetail"),
                        new SqlParameter("@ChallanID",e.Row.Cells[0].Value)
                    };

                    ds = cls_dl_Challan.Challan_Reader(prm3);
                    ChallanDataset _ds = new ChallanDataset();

                    _ds.Tables["tblChallan"].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                    _ds.Tables["tblChallanDetail"].Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                    ds = null;
                    frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                    obj.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void txtChallanNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearch_Click(null, null);
            }
        }

       
    }
}
