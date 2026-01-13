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
    public partial class frmPossessionChallanReport : Telerik.WinControls.UI.RadForm
    {
        public frmPossessionChallanReport()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? dateFrom = null;
                DateTime? dateTo = null;

                if (dtpFromDate.Value.Date.Year == 1)
                    dateFrom = null;
                else
                {
                    dateFrom = dtpFromDate.Value.Date;
                    if (dtpToDate.Value.Date.Year == 1)
                        dateTo = DateTime.Now.Date;
                    else
                        dateTo = dtpToDate.Value.Date;
                }

                //string ChallanType = null;
                //if (cmbChallanType.Text == "Installment")
                //    ChallanType = "0";
                //else if (cmbChallanType.Text == "Nomination Fee")
                //    ChallanType = "-1";
                //else if (cmbChallanType.Text == "Registration Of Property Dealers")
                //    ChallanType = "-2";
                //else if (cmbChallanType.Text == "Renewal Fee for Registration Of Property Dealers")
                //    ChallanType = "-3";
                //else
                //    ChallanType = null;

                SqlParameter[] prm =
                {
                    new SqlParameter("@Task", "GetChallanReportDetails"),
                    new SqlParameter("@FileNo", string.IsNullOrEmpty(txtFileNo.Text.Trim()) ? null : txtFileNo.Text.Trim()),
                    new SqlParameter("@ChalanNo", string.IsNullOrEmpty(txtChallanNo.Text.Trim()) ? null : txtChallanNo.Text.Trim()),
                    new SqlParameter("@Status", string.IsNullOrEmpty(drpDDstatus.Text.Trim())? null : drpDDstatus.Text.Trim()),
                    new SqlParameter("@FromDate", dateFrom),
                    new SqlParameter("@ToDate", dateTo)
                 //   new SqlParameter("@ParticularID", cmbChallanHeDetail.SelectedValue),
                 //   new SqlParameter("@ChallanType",ChallanType )
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "Pos.USP_PossessionChallan", prm);
                if (ds.Tables.Count > 0)
                {
                    dgChallanReport.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtChallanNo.Clear();
            txtFileNo.Clear();

            dtpFromDate.Text = "";
            dtpToDate.Text = "";
            drpDDstatus.SelectedIndex = -1;

            dgChallanReport.DataSource = null;
        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(dgChallanReport);
        }
    }
}
