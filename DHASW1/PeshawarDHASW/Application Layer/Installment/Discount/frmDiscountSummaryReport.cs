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

namespace PeshawarDHASW.Application_Layer.Installment.Discount
{
    public partial class frmDiscountSummaryReport : Telerik.WinControls.UI.RadForm
    {
        public frmDiscountSummaryReport()
        {
            InitializeComponent();
        }

        private void frmDiscountSummaryReport_Load(object sender, EventArgs e)
        {
            SqlParameter[] Parameterforreprt = {      new SqlParameter("@Task","DiscountReport")  };
            DataSet ds = new DataSet();
            ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_ReceDiscount", Parameterforreprt);
            grdAllDiscountInfo.DataSource = ds.Tables[0].DefaultView;
            foreach (GridViewDataColumn column in grdAllDiscountInfo.Columns)
            {
                column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdAllDiscountInfo);
        }
    }
}
