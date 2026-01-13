using PeshawarDHASW.Models;
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

namespace PeshawarDHASW.Application_Layer.TransferSummary
{
    public partial class frmTransferSummary : Telerik.WinControls.UI.RadForm
    {
        public frmTransferSummary()
        {
            InitializeComponent();
        }
        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }

        private void DataLoading()
        {
            SqlParameter[] param = { new SqlParameter("@Task", "FileState10112021") };
            DGVFileState.DataSource = Data_Layer.clsTransferSummary.cls_dl_TransferSummary.TransferSumary_Read(param).Tables[0].DefaultView;
            DGVFileStateCom.DataSource = Data_Layer.clsTransferSummary.cls_dl_TransferSummary.TransferSumary_Read(param).Tables[1].DefaultView;
            foreach (GridViewDataColumn column in DGVFileState.Columns)
            {
                column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
            }
            foreach (GridViewDataColumn column in DGVFileStateCom.Columns)
            {
                column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
            }
            Summary_Column_Template_Wise_Search();
            Summary_Column_Template_Wise_Search_Com();

        }
        private void frmTransferSummary_Load(object sender, EventArgs e)
        {
            if (clsUser.ThemeName == String.Empty)
            {
                ApplyTheme("TelerikMetro");
            }
            else
            {
                ApplyTheme(clsUser.ThemeName);
            }
            this.DGVFileState.SummaryRowsBottom.Clear();
            this.DGVFileStateCom.SummaryRowsBottom.Clear();
            DataLoading();
        }

        private void DGVFileState_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

                int rowindex = DGVFileState.CurrentCell.RowIndex;
                int columnindex = DGVFileState.CurrentCell.ColumnIndex;

                #region View Summary
                if (e.Column.Name == "ViewSummary")
                {
                    //string OwnerCategoryID = DGVFileState.CurrentRow.Cells["OwnerCategoryID"].Value.ToString();
                    //string PlotBusinessTypeID = DGVFileState.CurrentRow.Cells["PlotBusinessTypeID"].Value.ToString();
                    //string BusinessType = DGVFileState.CurrentRow.Cells["BusinessType"].Value.ToString();
                    //if (OwnerCategoryID != string.Empty & PlotBusinessTypeID != string.Empty & BusinessType != string.Empty)
                    //{
                    //    frmTransferState obj = new frmTransferState(FileType, BusinessType);
                    //    obj.ShowDialog();
                    //}
                    //else
                    //{
                    //    RadMessageBox.Show("File Type is not exist.", "Warning", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);

                    //}
                }
                #endregion

                if (e.Column.Name == "VewFileDetail")
                {
                    string OwnerCategoryID = DGVFileState.CurrentRow.Cells["OwnerCategoryID"].Value.ToString();
                    string PlotBusinessTypeID = DGVFileState.CurrentRow.Cells["PlotBusinessTypeID"].Value.ToString();
                    string BusinessType = DGVFileState.CurrentRow.Cells["BusinessType"].Value.ToString();
                    string PlotSize = DGVFileState.CurrentRow.Cells["PlotSize"].Value.ToString();
                    if (OwnerCategoryID != string.Empty & PlotBusinessTypeID != string.Empty & BusinessType != string.Empty)
                    { 
                        frmFileExtenededView obj = new frmFileExtenededView(OwnerCategoryID, PlotBusinessTypeID, PlotSize, BusinessType);
                        obj.ShowDialog();
                    }
                    else
                    {
                        RadMessageBox.Show("File Type is not exist.", "Warning", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);

                    }
                }
            }
            catch (Exception ex)
            {
                #region Dangerous Error

                // MessageBox.Show("Search Grid \n Message -> "+ex.Message+"\nSource - > "+ex.Source);

                #endregion
            }
        }


        private void Summary_Column_Template_Wise_Search()
        {
            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            foreach (GridViewDataColumn item in DGVFileState.Columns)
            {
                GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                summaryItem.Name = item.Name;
                summaryItem.Aggregate = GridAggregateFunction.Sum;
                summaryRowItem.Add(summaryItem);
            }
            #region Summary Columns
            this.DGVFileState.SummaryRowsBottom.Add(summaryRowItem);
            DGVFileState.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            #endregion

        }

        private void Summary_Column_Template_Wise_Search_Com()
        {
            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            foreach (GridViewDataColumn item in DGVFileStateCom.Columns)
            {
                GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                summaryItem.Name = item.Name;
                summaryItem.Aggregate = GridAggregateFunction.Sum;
                summaryRowItem.Add(summaryItem);
            }
            #region Summary Columns
            this.DGVFileStateCom.SummaryRowsBottom.Add(summaryRowItem);
            DGVFileStateCom.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            #endregion

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            GridPrintStyle style = new GridPrintStyle();
            style.FitWidthMode = PrintFitWidthMode.FitPageWidth;
            style.PrintGrouping = true;
            style.PrintSummaries = false;
            style.PrintHeaderOnEachPage = true;
            style.PrintHiddenColumns = false;
            TableViewDefinitionPrintRenderer renderer = new TableViewDefinitionPrintRenderer(this.DGVFileState);
            renderer.PrintPages.Add(this.DGVFileState.Columns[0], 
                this.DGVFileState.Columns[1], this.DGVFileState.Columns[2],
                this.DGVFileState.Columns[3], this.DGVFileState.Columns[4], this.DGVFileState.Columns[5], this.DGVFileState.Columns[6]);
            style.PrintRenderer = renderer;
            DGVFileState.PrintStyle = style;
            DGVFileState.PrintStyle.PrintHiddenRows = false;
            DGVFileState.PrintStyle.PrintGrouping = true;
            DGVFileState.PrintStyle.PrintSummaries = true;

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            RadPrintDocument RadPrintDocument1 = new RadPrintDocument();
            RadPrintDocument1.AssociatedObject = DGVFileState;

            RadPrintDocument1.Landscape = true;
            RadPrintDocument1.MiddleHeader = "DHA Peshawar Residential File State Report ";
            RadPrintDocument1.MiddleFooter = "Page [Page #] of [Total Pages]";
            RadPrintDocument1.RightFooter = "[Date Printed]";
            dialog.Document = RadPrintDocument1;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();


        }

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {

            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGVFileState);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.DGVFileState.SummaryRowsBottom.Clear();
            DataLoading();
        }

        private void DGVFileStateCom_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {

                if (e.Column.Name == "VewFileDetail")
                {
                    string OwnerCategoryID = e.Row.Cells["OwnerCategoryID"].Value.ToString();
                    string PlotBusinessTypeID = e.Row.Cells["PlotBusinessTypeID"].Value.ToString();
                    string BusinessType = e.Row.Cells["BusinessType"].Value.ToString();
                    string PlotSize = e.Row.Cells["PlotSize"].Value.ToString();
                    if (OwnerCategoryID != string.Empty & PlotBusinessTypeID != string.Empty & BusinessType != string.Empty)
                    {
                        frmFileExtenededView obj = new frmFileExtenededView(OwnerCategoryID, PlotBusinessTypeID, PlotSize, BusinessType);
                        obj.ShowDialog();
                    }
                    else
                    {
                        RadMessageBox.Show("File Type is not exist.", "Warning", MessageBoxButtons.OK, RadMessageIcon.Info, MessageBoxDefaultButton.Button1);

                    }
                }
            }
            catch (Exception ex)
            {
                #region Dangerous Error

                // MessageBox.Show("Search Grid \n Message -> "+ex.Message+"\nSource - > "+ex.Source);

                #endregion
            }
        }

        private void btnComPrint_Click(object sender, EventArgs e)
        {
            GridPrintStyle style = new GridPrintStyle();
            style.FitWidthMode = PrintFitWidthMode.FitPageWidth;
            style.PrintGrouping = true;
            style.PrintSummaries = false;
            style.PrintHeaderOnEachPage = true;
            style.PrintHiddenColumns = false;
            TableViewDefinitionPrintRenderer renderer = new TableViewDefinitionPrintRenderer(this.DGVFileStateCom);
            renderer.PrintPages.Add(this.DGVFileState.Columns[0],
                this.DGVFileStateCom.Columns[1], this.DGVFileStateCom.Columns[2],
                this.DGVFileStateCom.Columns[3], this.DGVFileStateCom.Columns[4], this.DGVFileStateCom.Columns[5], this.DGVFileStateCom.Columns[6]);
            style.PrintRenderer = renderer;
            DGVFileStateCom.PrintStyle = style;
            DGVFileStateCom.PrintStyle.PrintHiddenRows = false;
            DGVFileStateCom.PrintStyle.PrintGrouping = true;
            DGVFileStateCom.PrintStyle.PrintSummaries = true;

            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog();
            RadPrintDocument RadPrintDocument1 = new RadPrintDocument();
            RadPrintDocument1.AssociatedObject = DGVFileState;

            RadPrintDocument1.Landscape = true;
            RadPrintDocument1.MiddleHeader = "DHA Peshawar Commercial File State Report ";
            RadPrintDocument1.MiddleFooter = "Page [Page #] of [Total Pages]";
            RadPrintDocument1.RightFooter = "[Date Printed]";
            dialog.Document = RadPrintDocument1;
            dialog.StartPosition = FormStartPosition.CenterScreen;
            dialog.ShowDialog();
        }

        private void btnComExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGVFileStateCom);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnComRefresh_Click(object sender, EventArgs e)
        {
            this.DGVFileStateCom.SummaryRowsBottom.Clear();
            DataLoading();
        }
    }
}
