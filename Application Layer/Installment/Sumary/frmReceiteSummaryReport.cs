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

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
