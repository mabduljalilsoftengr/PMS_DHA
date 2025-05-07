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
    public partial class frmSurWaiverAppPrint : Telerik.WinControls.UI.RadForm
    {
        public frmSurWaiverAppPrint()
        {
            InitializeComponent();
        }
        private void FillDataGrid()
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
                    //GVSurchargeWaiverAppOverAllDataList.MasterTemplate.DataSource = ds.Tables[0].DefaultView;
                    MasterTemplate.DataSource = ds.Tables[0].DefaultView;
                    foreach (GridViewDataColumn column in MasterTemplate.Columns)
                    {
                        column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmSurWaiverAppPrint_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFileNo.Text = "";
            txtRefrenceNo.Text = "";
            FillDataGrid();
            txtPlotNo.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillDataGrid();
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

        private void GVSurchargeWaiverAppOverAllDataList_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name=="PrintLetter")
            {
                try
                {
                    string SwaID = e.Row.Cells["SWA_ID"].Value.ToString();
                    string SectorCExt = e.Row.Cells["SectorCExt"].Value.ToString();
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","SurchargeWavierLetter"),
                    new SqlParameter("@SWA_ID", clsPluginHelper.DbNullIfNullOrEmpty(SwaID)),
                     };
                    DataSet ds = cls_dl_SurchargeWavier_ApplicationStatus.SurchargeWavier_ApplicationStatus_Reader(prm);
                    if (ds.Tables.Count > 0)
                    {
                       
                        if (ds.Tables[0].Rows[0]["PrintStatus"].ToString() == "Pending")
                        {
                            Report.SurchargeWavierApplicationReport.SurWaiveApp SurcWavAppDataMergeRpt = new Report.SurchargeWavierApplicationReport.SurWaiveApp();
                            SurcWavAppDataMergeRpt.Tables[0].Merge(ds.Tables[0], false, MissingSchemaAction.Ignore);
                            Report.SurchargeWavierApplicationReport.SurcWvrAppReportViewer objrpt = new Report.SurchargeWavierApplicationReport.SurcWvrAppReportViewer(SurcWavAppDataMergeRpt, ds.Tables[0].Rows[0]["Status"].ToString());
                            objrpt.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Please Verify the Print Status (Hold | Printed)");
                        }
                    }
                }
                catch (Exception ex)
                {
                        
                }
               
            }
        }
    }
}
