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

namespace PeshawarDHASW.Application_Layer.Installment.InstallmentSummary
{
    public partial class frmReceiptSummaryReport : Telerik.WinControls.UI.RadForm
    {
        public frmReceiptSummaryReport()
        {
            InitializeComponent();
        }

        private void frmReceiptSummaryReport_Load(object sender, EventArgs e)
        {
            //dtDevfromdate.Value = DateTime.Now;
            //dtpDevtodate.Value = DateTime.Now;
            //dtpInsfrom.Value = DateTime.Now;
            //dtpInsto.Value = DateTime.Now;

            DevelopmentChargesSummary();
            PlotInstallmentSummary();
        }


        private void DevelopmentChargesSummary(DateTime? Datefrom = null, DateTime? DateTo = null)
        {
            SqlParameter[] prm =
                                {
                                    new SqlParameter("@Task","DevelopmentChargesSummaryReport"),
                                    new SqlParameter("@DateFrom",Datefrom),
                                    new SqlParameter("@DateTo",DateTo)
                                };
            DataSet dst = new DataSet();
            dst = cls_dl_FinanceDashBoard.InstallmentWise_Search_Reader(prm);
            radDevelopmentCharges.DataSource = null;
            radDevelopmentCharges.DataSource = dst.Tables.Count > 0 ? dst.Tables[0].DefaultView : null;
            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            foreach (GridViewDataColumn item in radDevelopmentCharges.Columns)
            {
                GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                summaryItem.Name = item.Name;
                summaryItem.Aggregate = GridAggregateFunction.Sum;
                summaryItem.FormatString = "{0:#,###0;(#,###0);0}";
                summaryRowItem.Add(summaryItem);
            }
            #region Summary Columns
            this.radDevelopmentCharges.SummaryRowsBottom.Add(summaryRowItem);
            radDevelopmentCharges.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            #endregion
        }


        private void PlotInstallmentSummary(DateTime? Datefrom = null, DateTime? DateTo = null)
        {
            SqlParameter[] prm =
                                {
                                    new SqlParameter("@Task","PlotInstallmentSummaryReport"),
                                    new SqlParameter("@DateFrom",Datefrom),
                                    new SqlParameter("@DateTo",DateTo)
                                };
            DataSet dst = new DataSet();
            dst = cls_dl_FinanceDashBoard.InstallmentWise_Search_Reader(prm);
            gridInstallment.DataSource = null;
            gridInstallment.DataSource = dst.Tables.Count > 0 ? dst.Tables[0].DefaultView : null;

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            foreach (GridViewDataColumn item in gridInstallment.Columns)
            {
                GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                summaryItem.Name = item.Name;
                summaryItem.Aggregate = GridAggregateFunction.Sum;
                summaryItem.FormatString = "{0:#,###0;(#,###0);0}";
                summaryRowItem.Add(summaryItem);
            }
            #region Summary Columns
            this.gridInstallment.SummaryRowsBottom.Add(summaryRowItem);
            gridInstallment.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            #endregion
        }

        private void btnInstalFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dtpInsfrom.Text))
                PlotInstallmentSummary();
            else
                PlotInstallmentSummary(dtpInsfrom.Value, dtpInsto.Value);
        }

        private void btnDevFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dtDevfromdate.Text))
                DevelopmentChargesSummary();
            else
                DevelopmentChargesSummary(dtDevfromdate.Value, dtpDevtodate.Value);
        }
        
        private void btnDevReport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(radDevelopmentCharges);
        }

        private void btnPlotInsReport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(gridInstallment);
        }
    }
}
