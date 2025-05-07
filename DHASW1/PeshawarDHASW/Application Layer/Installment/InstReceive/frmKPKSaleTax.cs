using PeshawarDHASW.Data_Layer.Installment;
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

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmKPKSaleTax : Telerik.WinControls.UI.RadForm
    {
        public frmKPKSaleTax()
        {
            InitializeComponent();
        }

        private void radGroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void frmKPKSaleTax_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            if (radgdInstReceive.Rows.Count > 0)
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(radgdInstReceive);
            else
                MessageBox.Show("No record to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            #region Searching
            if (dtpFromDate.Value.Date != null && dtpToDate.Value.Date != null)
            {
                SearchingDD();
            }
            else
            {
                RadMessageBox.Show("Please Fill all the Fields.", "Information", MessageBoxButtons.OK, RadMessageIcon.Info);
            }
            #endregion
        }
        private void SearchingDD()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Task", "GetKPKSaleTax"),
                new SqlParameter("@FromDate",dtpFromDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@ToDate",dtpToDate.Value.ToString("yyyy-MM-dd")),
            };
            DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    radgdInstReceive.DataSource = ds.Tables[0].DefaultView;
                    foreach (GridViewDataColumn column in radgdInstReceive.Columns)
                    {
                        column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                    }
                }
                else
                {
                    radgdInstReceive.DataSource = null;
                    MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                radgdInstReceive.DataSource = null;
                MessageBox.Show("No record found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void radgdInstReceive_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "S.No" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@Task", "GetKPKSaleTax"),
                        new SqlParameter("@FromDate","2018-01-01"),
                        new SqlParameter("@ToDate",DateTime.Now.ToString("yyyy-MM-dd")),
                    };
                    DataSet ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            radgdInstReceive.DataSource = ds.Tables[0].DefaultView;
                            foreach (GridViewDataColumn column in radgdInstReceive.Columns)
                            {
                                column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                            }
                        }
                        else
                        {
                            radgdInstReceive.DataSource = null;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error While Occuring in the Process \n\n"+ex.Message);
                }
            }
        }
    }
}
