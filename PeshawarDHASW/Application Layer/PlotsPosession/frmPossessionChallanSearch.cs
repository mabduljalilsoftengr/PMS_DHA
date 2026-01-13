using PeshawarDHASW.Application_Layer.Chalan;
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

namespace PeshawarDHASW.Application_Layer.PlotsPosession
{
    public partial class frmPossessionChallanSearch : Telerik.WinControls.UI.RadForm
    {
        public frmPossessionChallanSearch()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFileNo.Clear();
            txtChallanNo.Clear();
            this.ChallanDate.NullableValue = null;
            this.ChallanDate.SetToNullValue();
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
                new SqlParameter("@Task","GetPossessionChallanDetailSearch"),
                new SqlParameter("@FileNo", string.IsNullOrEmpty(txtFileNo.Text.Trim())? null : txtFileNo.Text.Trim()),
                new SqlParameter("@ChalanNo", string.IsNullOrEmpty(txtChallanNo.Text.Trim())? null : txtChallanNo.Text.Trim()),
                new SqlParameter("@ClearDate", dt),

                 };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),CommandType.StoredProcedure, "Pos.USP_PossessionChallan", prm);
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

        private void btnCreateButton_Click(object sender, EventArgs e)
        {
            frmPossessionChallan obj = new frmPossessionChallan();
            obj.ShowDialog();
        }

        private void dgChallanSearch_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "Edit")
                {
                    if (e.Row.Cells["Status"].Value.ToString() == "Pending")
                    {
                        MessageBox.Show("Edit");
                        //frmCreateChallan frm = new frmCreateChallan(e.Row.Cells["ChallanID"].Value.ToString());
                        //frm.ShowDialog();
                        //btnSearch_Click(null, null);
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
                        new SqlParameter("@Task","GetPossessionChallReportDetail"),
                        new SqlParameter("@ChallanID",e.Row.Cells[0].Value)
                    };

                    ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Pos.USP_PossessionChallan", prm3); 
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
    }
}
