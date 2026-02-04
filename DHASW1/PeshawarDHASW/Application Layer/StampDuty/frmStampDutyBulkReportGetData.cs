using CrystalDecisions.CrystalReports.Engine;
using PeshawarDHASW.Data_Layer.clsPlotSize;
using PeshawarDHASW.Data_Layer.clsStampDuty;
using PeshawarDHASW.Report.Stamp_Duty;
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

namespace PeshawarDHASW.Application_Layer.StampDuty
{
    public partial class frmStampDutyBulkReportGetData : Telerik.WinControls.UI.RadForm
    {
        private DataSet dst { get; set; }
        public frmStampDutyBulkReportGetData()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","StampDutyReport"),
                new SqlParameter("@FromDate",dtpFromDate.Value),
                new SqlParameter("@ToDate",dtpToDate.Value),
                new SqlParameter("@PlotSize", drpPlotSize.Text =="-- Select --"? null : drpPlotSize.SelectedItem.ToString()),
                new SqlParameter("@Type",ddlplottype.Text =="-- Select --"? null : ddlplottype.SelectedItem.ToString()),
                new SqlParameter("@FileNo",txtFileNo.Text == "" ? null : txtFileNo.Text)
            };
            dst = cls_dl_StampDuty.StampDuty_Reader(prm);
            grdStampDuty.DataSource = dst.Tables[0].DefaultView;
           

           
        }

        private void frmStampDutyBulkReport_Load(object sender, EventArgs e)
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select --";
            this.drpPlotSize.Items.Add(Select);
            SqlParameter[] prm1 =
            {
                new SqlParameter("@Task","Select")
            };
            DataSet dst = cls_dl_PlotSize.PlotSize_Reader(prm1);

            foreach (DataRow row in dst.Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ID"].ToString();
                dataItem.Text = row["PlotSize"].ToString();
                this.drpPlotSize.Items.Add(dataItem);
            }
            drpPlotSize.SelectedIndex = 0;
            ddlplottype.SelectedIndex = 0;

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            dst.Tables[0].Columns.Add("FromDate", typeof(System.DateTime));
            dst.Tables[0].Columns.Add("ToDate", typeof(System.DateTime));
            foreach (DataRow row in dst.Tables[0].Rows)
            {
                row["FromDate"] = dtpFromDate.Value.Date;
                row["ToDate"] = dtpToDate.Value.Date;
            }
            frmStampDutyBulkReport frmobj = new frmStampDutyBulkReport(dst);
            frmobj.ShowDialog();
        }

        private void grdStampDuty_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "SNo")
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }

        private void btn_Excel_Export_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdStampDuty);
        }
    }
}
