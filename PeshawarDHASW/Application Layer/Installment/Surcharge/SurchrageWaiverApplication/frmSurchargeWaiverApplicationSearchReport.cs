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

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge.SurchrageWaiverApplication
{
    public partial class frmSurchargeWaiverApplicationSearchReport : Telerik.WinControls.UI.RadForm
    {
        public frmSurchargeWaiverApplicationSearchReport()
        {
            InitializeComponent();
        }

        private void frmSurchargeWaiverApplicationSearchReport_Load(object sender, EventArgs e)
        {
            FillDataGrid(null);
        }
        private void FillDataGrid(DateTime? dt)
        {
            try
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","GetOverAllAppData"),
                    new SqlParameter("@FileNo", clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                    new SqlParameter("@RefrenceNo", clsPluginHelper.DbNullIfNullOrEmpty(txtRefrenceNo.Text)),
                    new SqlParameter("@PlotNo", clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text))
                };
                DataSet ds = cls_dl_SurchargeWavier_ApplicationStatus.SurchargeWavier_ApplicationStatus_Reader(prm);
                if (ds.Tables.Count > 0)
                {
                    GVSurchargeWaiverAppOverAllDataList.DataSource = ds.Tables[0].DefaultView;
                    foreach (GridViewDataColumn column in GVSurchargeWaiverAppOverAllDataList.Columns)
                    {
                        column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                    }
                    //  GVApproved.DataSource = ds.Tables[1].DefaultView;
                    //  GVNotApproved.DataSource = ds.Tables[2].DefaultView;
                    //GVNotApproved.DataSource = ds.Tables[2].DefaultView;
                    //ChallanDetailDS _ds = new ChallanDetailDS();
                    //_ds.Tables[0].Merge(ds.Tables[0]);
                    //_ds.Tables[1].Merge(ds.Tables[1]);
                    //dgChallanSearch.DataSource = _ds.Tables[0];
                    //gridViewTemplate1.DataSource = _ds.Tables[1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillDataGrid(null);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFileNo.Text = "";
            txtRefrenceNo.Text = "";
            FillDataGrid(null);
            txtPlotNo.Text = "";
        }

        private void btnperiodsearchsp_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(GVSurchargeWaiverAppOverAllDataList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
