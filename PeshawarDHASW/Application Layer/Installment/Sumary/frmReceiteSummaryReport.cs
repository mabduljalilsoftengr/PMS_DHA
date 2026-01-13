using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
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

namespace PeshawarDHASW.Application_Layer.Installment.Sumary
{
    public partial class frmReceiteSummaryReport : Telerik.WinControls.UI.RadForm
    {
        public frmReceiteSummaryReport()
        {
            InitializeComponent();
        }

        private void frmReceiteSummaryReport_Load(object sender, EventArgs e)
        {
            this.grdReport.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        { 
            // Validation
            if (txtfromdate.Value.Date > txttodate.Value.Date)
            {
                MessageBox.Show("From Date cannot be greater than To Date.",
                                "Validation",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "ReceitSummaryReport"),
                     new SqlParameter("@DateFrom", txtfromdate.Value.Date),
                    new SqlParameter("@DateTo", txttodate.Value.Date)
                   
                };
                DataSet ds = cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjustRetrive(parameters);
                grdReport.DataSource = ds.Tables[0].DefaultView;

                // Auto-fit columns and rows
                grdReport.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdReport);
        }
    }
}
