using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    public partial class frmInstalPlanEdit : Form
    {
        GridViewRowInfo draggedRow;

        public frmInstalPlanEdit()
        {
            InitializeComponent();
        }

        private void frmInstalPlanEdit_Load(object sender, EventArgs e)
        {
            planEditGridView.AllowDrop = true;
            planEditGridView.MouseDown += PlanEditGridView_MouseDown;
            planEditGridView.DragEnter += PlanEditGridView_DragEnter;
            planEditGridView.DragDrop += PlanEditGridView_DragDrop;
        }

        private void btn_viewPlan_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "SelectInstalPlan"),
                    new SqlParameter("@FileNo", textBoxFileNo.Text)
                };

                DataSet ds = clsInstallmentTemplate.InstalTemplate_Reader(parameters);

                if (ds.Tables.Count > 0)
                {
                    planEditGridView.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlanEditGridView_MouseDown(object sender, MouseEventArgs e)
        {
            var element = planEditGridView.ElementTree.GetElementAtPoint(e.Location) as GridDataCellElement;
            if (element != null)
            {
                draggedRow = element.RowInfo;
                planEditGridView.DoDragDrop(draggedRow, DragDropEffects.Move);
            }
        }

        private void PlanEditGridView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void PlanEditGridView_DragDrop(object sender, DragEventArgs e)
        {
            if (draggedRow == null) return;

            Point clientPoint = planEditGridView.PointToClient(new Point(e.X, e.Y));
            var element = planEditGridView.ElementTree.GetElementAtPoint(clientPoint) as GridDataCellElement;

            if (element != null && element.RowInfo != null && element.RowInfo != draggedRow)
            {
                MoveAndReorderRows(draggedRow, element.RowInfo);
            }

            draggedRow = null;
        }

        private void MoveAndReorderRows(GridViewRowInfo sourceRow, GridViewRowInfo targetRow)
        {
            var dataTable = planEditGridView.DataSource as DataTable;
            if (dataTable == null) return;

            int sourceIndex = planEditGridView.Rows.IndexOf(sourceRow);
            int targetIndex = planEditGridView.Rows.IndexOf(targetRow);

            var movedRow = dataTable.Rows[sourceIndex].ItemArray;
            dataTable.Rows.RemoveAt(sourceIndex);
            dataTable.Rows.InsertAt(dataTable.NewRow(), targetIndex);
            dataTable.Rows[targetIndex].ItemArray = movedRow;

            ReorderAcctSeries(dataTable);
            planEditGridView.DataSource = dataTable;
        }

        private void ReorderAcctSeries(DataTable dataTable)
        {
            int acctSeries = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                row["AcctStSeries"] = acctSeries++;
            }
        }


        private void planEditGridView_Click(object sender, EventArgs e)
        {
            // Optional click logic
        }

        private void btnUpdateInstallment_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable updateTable = new DataTable("UpdatedPlan");
                updateTable.Columns.Add("PlanId", typeof(int));
                updateTable.Columns.Add("AcctStSeries", typeof(int));

                foreach (GridViewRowInfo row in planEditGridView.ChildRows)
                {
                    if (row.Cells["PlanId"] != null && row.Cells["AcctStSeries"] != null)
                    {
                        int planId = Convert.ToInt32(row.Cells["PlanId"].Value);
                        int acctStSeries = Convert.ToInt32(row.Cells["AcctStSeries"].Value);

                        updateTable.Rows.Add(planId, acctStSeries);
                    }
                }

                using (SqlConnection conn = new SqlConnection(clsMostUseVars.Connectionstring))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("[App].[USP_InstallmentTemplate]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Task", "UpdateInstalPlan");

                        SqlParameter tvpParam = cmd.Parameters.AddWithValue("@PlanUpdateType", updateTable);
                        tvpParam.SqlDbType = SqlDbType.Structured;
                        tvpParam.TypeName = "dbo.PlanUpdateType";

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Series Updated Successfully.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
