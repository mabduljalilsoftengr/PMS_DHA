using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Telerik.Charting;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.DashBoards
{
    public partial class frm_FinDashBoard : Telerik.WinControls.UI.RadForm
    {
        public frm_FinDashBoard()
        {
            InitializeComponent();
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }

        private void TransferSummary()
        {
            SqlParameter[] param = { new SqlParameter("@Task", "FileState") };
            DataTable dt = Data_Layer.clsTransferSummary.cls_dl_TransferSummary.TransferSumary_Read(param).Tables[0];
            //Balloting
            //Investor
            //Svc Benefit


        }
        private void frm_FinDashBoard_Load(object sender, EventArgs e)
        {
            try
            {
                if (clsUser.ThemeName == String.Empty)
                {
                    ApplyTheme("TelerikMetro");
                }
                else
                {
                    ApplyTheme(clsUser.ThemeName);
                }

                btnRefreshofSummary_Click(null, null);
                SqlParameter[] parameter = { new SqlParameter("@Task", "FileState") };
                DGVFileState.DataSource = Data_Layer.clsTransferSummary.cls_dl_TransferSummary.TransferSumary_Read(parameter).Tables[0].DefaultView;

                SqlParameter[] parameterdp = { new SqlParameter("@Task", "SectorDropDown") };
                DataSet dst = PeshawarDHASW.Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(parameterdp);
                dpSectorList.DisplayMember = "Sector";
                dpSectorList.ValueMember = "Sector_ID";
                dpSectorList.DataSource = dst.Tables[0].DefaultView;

                SqlParameter[] customreport = { new SqlParameter("@Task", "All_Task") };
                dgvCustomReport.DataSource = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.CustomReport", customreport).Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CCCWbtnFetch_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task", "CustomerCollectionSummaries"),
                    new SqlParameter("@fromdate", CCCWdtpfromdate.Value),
                    new SqlParameter("@todate", CCCWdtptodate.Value)
                };
                DataSet dst = PeshawarDHASW.Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(param);
                CustomerCollectionGrid.DataSource = dst.Tables[0].DefaultView;
                foreach (GridViewDataColumn column in CustomerCollectionGrid.Columns)
                {
                    column.BestFit();
                }
                this.UseWaitCursor = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.UseWaitCursor = false;
            }
        }

        private void Summary_Column()
        {
            this.radgdInstReceive.SummaryRowsBottom.Clear();
            GridViewSummaryItem summaryItem = new GridViewSummaryItem();
            summaryItem.Name = "Amount";
            summaryItem.Aggregate = GridAggregateFunction.Sum;
            summaryItem.FormatString = "{0:#,###0.00;(#,###0.00);0}";

            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            summaryRowItem.Add(summaryItem);

            this.radgdInstReceive.SummaryRowsBottom.Add(summaryRowItem);

        }
        private DataSet ds { get; set; }
        private void SearchingDD()
        {
            string ddstatus = string.Empty;
            if (drpDDstatus.SelectedIndex > 0)
            {
                ddstatus = drpDDstatus.SelectedItem.ToString();
            }
            //object ddstatus = drpDDstatus.SelectedItem.ToString() == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : drpDDstatus.SelectedItem.ToString();
            SqlParameter[] parameters =
            {
                new SqlParameter("@Task", "List_Of_DD_ReadyForBank"),
                new SqlParameter("@FromDate",dtpFromDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@ToDate",dtpToDate.Value.ToString("yyyy-MM-dd")),
                new SqlParameter("@DDStatus",clsPluginHelper.DbNullIfNullOrEmpty(ddstatus)),
            };
            ds = cls_dl_InstRece.Inst_Rece_Read(parameters);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    radgdInstReceive.DataSource = ds.Tables[0].DefaultView;

                }
                else
                {
                    MessageBox.Show("Check The Date Field.", "Warning", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("Their is no Data in These Dates.");
            }
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            #region
            if (dtpFromDate.Value.Date != null && dtpToDate.Value.Date != null)
            {
                SearchingDD();
                foreach (GridViewDataColumn column in radgdInstReceive.Columns)
                {
                    column.BestFit();
                }
               // Summary_Column();
            }
            else
            {
                RadMessageBox.Show("Please Fill all the Fields.", "Information", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }
            #endregion
        }

        private void radgdInstReceive_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement.ColumnInfo.Name == "S.No" && string.IsNullOrEmpty(e.CellElement.Text))
            {
                e.CellElement.Text = (e.CellElement.RowIndex + 1).ToString();
            }
        }

        private void btnRefreshofSummary_Click(object sender, EventArgs e)
        {
            SqlParameter[] param = { new SqlParameter("@Task", "DashBoardQueries") };
            DataSet dst = PeshawarDHASW.Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(param);
            grdperiodwisedd.DataSource = dst.Tables[0].DefaultView;
            grdalldds.DataSource = dst.Tables[1].DefaultView;
            grdack.DataSource = dst.Tables[2].DefaultView;
            grdfiles.DataSource = dst.Tables[3].DefaultView;
            //double ToDayDDsEntried = double.Parse(dst.Tables[0].Rows[0]["ToDayDDsEntried"].ToString());
            //double TodayTotalAmount = double.Parse(dst.Tables[0].Rows[0]["TodayTotalAmount"].ToString());

            //double PreciousDayDDsEntried = double.Parse(dst.Tables[0].Rows[0]["PreciousDayDDsEntried"].ToString());
            //double PreciousDayTotalAmount = double.Parse(dst.Tables[0].Rows[0]["PreciousDayTotalAmount"].ToString());

            //double CleardDDsEntried = double.Parse(dst.Tables[0].Rows[0]["CleardDDsEntried"].ToString());
            //double ClearedTotalAmount = double.Parse(dst.Tables[0].Rows[0]["ClearedTotalAmount"].ToString());

            //double ReceivedDDsEntried = double.Parse(dst.Tables[0].Rows[0]["ReceivedDDsEntried"].ToString());
            //double ReceivedTotalAmount = double.Parse(dst.Tables[0].Rows[0]["ReceivedTotalAmount"].ToString());

            //double TotalPrintedEntried = double.Parse(dst.Tables[0].Rows[0]["TotalPrintedEntried"].ToString());
            //double TotalNotPrintedAck = double.Parse(dst.Tables[0].Rows[0]["TotalNotPrintedAck"].ToString());

            //double TotalActiveFiles = double.Parse(dst.Tables[0].Rows[0]["TotalActiveFiles"].ToString());
            //double TotalCancelFiles = double.Parse(dst.Tables[0].Rows[0]["TotalCancelFiles"].ToString());

            //double TotalDDCancel = double.Parse(dst.Tables[0].Rows[0]["TotalCancelDDs"].ToString());
            //double TotalDDCancelAmount = double.Parse(dst.Tables[0].Rows[0]["TotalCancelDDsAmount"].ToString());

            //double TotalReturnDD = double.Parse(dst.Tables[0].Rows[0]["TotalReturnDDs"].ToString());
            //double TotalReturnDDAmount = double.Parse(dst.Tables[0].Rows[0]["TotalReturnDDsAmount"].ToString());

            //double TotalCurrentMonth = double.Parse(dst.Tables[0].Rows[0]["TotalCurrentMonth"].ToString());
            //double TotalCurrentMonthAmount = double.Parse(dst.Tables[0].Rows[0]["TotalCurrentMonthAmount"].ToString());

            //double TotalPreciousMonth = double.Parse(dst.Tables[0].Rows[0]["TotalPreciousMonth"].ToString());
            //double TotalPreciousMonthAmount = double.Parse(dst.Tables[0].Rows[0]["TotalPreciousMonthAmount"].ToString());

            //string TodayDDEntried = string.Format("Today Entries " + ToDayDDsEntried.ToString() + "\nTotal Amount  {0:n0}", TodayTotalAmount);
            //string PreciousDay_DDsEntried = string.Format("Precious Day Entries " + PreciousDayDDsEntried.ToString() + " \nTotal Amount {0:n0}", PreciousDayTotalAmount);
            //string ReceivedDD_Entried = string.Format("Total Received " + ReceivedDDsEntried.ToString() + " \nTotal Amount {0:n0}", ReceivedTotalAmount);
            //string CleardDD_Entried = string.Format("Total Cleared DD's " + CleardDDsEntried.ToString() + " \nTotal Amount {0:n0}", ClearedTotalAmount);
            //string TotalActive_Files = "Total Active Files " + TotalActiveFiles.ToString();
            //string TotalCancel_Files = "Total Cancel Files " + TotalCancelFiles.ToString();
            //string TotalPrinted_Entried = "Total Printed Acknowledgement " + TotalPrintedEntried.ToString();
            //string TotalNotPrinted_Ack = "Total Not Printed Acknowledgement " + TotalNotPrintedAck.ToString();
            //string TotalDDCancels = string.Format("Total Canceled DD's " + TotalDDCancel.ToString() + " \nTotal Amount {0:n0}", TotalDDCancelAmount);
            //string TotalReturnDDs = string.Format("Total Return DD's " + TotalReturnDD.ToString() + " \nTotal Amount {0:n0}", TotalReturnDDAmount);
            //string TotalCurrentMonths = string.Format("Total Current Month DD's " + TotalCurrentMonth.ToString() + " \nTotal Amount {0:n0}", TotalCurrentMonthAmount);
            //string TotalPreciousMonths = string.Format("Total Previous Month DD's " + TotalPreciousMonth.ToString() + " \nTotal Amount {0:n0}", TotalPreciousMonthAmount);

            //TodayReceiveItem.Text = TodayDDEntried;
            //PreciousDayReceiveItem.Text = PreciousDay_DDsEntried;
            //TotalReceiveItem.Text = ReceivedDD_Entried;
            //TotalClearedItem.Text = CleardDD_Entried;
            //lblTotalReturnDDs.Text = TotalReturnDDs;
            //lblTotalCancelDDs.Text = TotalDDCancels;
            //lblCurrentMonth.Text = TotalCurrentMonths;
            //lblPreciousMonth.Text = TotalPreciousMonths;

        }

        private void btnSectorPlots_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameterdp = {
                new SqlParameter("@Task", "Sector_Wise_Plot_Information"),
                new SqlParameter("@SectorID",dpSectorList.SelectedItem.Value)

            };
            DataSet dst = PeshawarDHASW.Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(parameterdp);

            DGVSectorInformation.DataSource = dst.Tables[0].DefaultView;
        }

        private void btnAllSectorData_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameterdp = {
                new SqlParameter("@Task", "Sector_Wise_Plot_Information")            
            };
            DataSet dst = PeshawarDHASW.Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(parameterdp);

            DGVSectorInformation.DataSource = dst.Tables[0].DefaultView;
        }

        private void dpSectorList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //SqlParameter[] parameterdp = {
            //    new SqlParameter("@Task", "Sector_Wise_Plot_Information"),
            //    new SqlParameter("@SectorID",dpSectorList.SelectedValue)

            //};
            //DataSet dst = PeshawarDHASW.Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(parameterdp);

            //DGVSectorInformation.DataSource = dst.Tables[0].DefaultView;
        }

        private void dpSectorList_SelectedValueChanged(object sender, EventArgs e)
        {
            SqlParameter[] parameterdp = {
                new SqlParameter("@Task", "Sector_Wise_Plot_Information"),
                new SqlParameter("@SectorID",dpSectorList.SelectedValue)

            };
            DataSet dst = PeshawarDHASW.Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(parameterdp);

            DGVSectorInformation.DataSource = dst.Tables[0].DefaultView;
        }

        private void MasterTemplate_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {

            int SectorID = int.Parse(e.Row.Cells["Sector_ID"].Value.ToString());
            string PlotSize = e.Row.Cells["PlotSize"].Value.ToString();
            frm_DashBoardDetail.frm_SectorDetail obj = new frm_DashBoardDetail.frm_SectorDetail(SectorID, PlotSize);
            obj.Show();
        }

        private void btnPeriodExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(CustomerCollectionGrid);
        }

        private void btnFileStateExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGVFileState);
        }

        private void btnSectorWiseReceiving_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(radgdInstReceive);
        }

        private void btnSectorWiseTotalReceiveexport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(DGVSectorInformation);
        }

        private void btnSWR_Fetch_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameterdp = {
                new SqlParameter("@Task", "SectorWiseCompleteBreakup"),
                new SqlParameter("@FromDate",SWR_fromDate.Value),
                new SqlParameter("@ToDate",SWR_toDate.Value),
                new SqlParameter("@SectorID",dpSectorList.SelectedValue)

            };
            DataSet dst = PeshawarDHASW.Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(parameterdp);
            SWR_DGVBreakup.DataSource = dst.Tables[0].DefaultView;

        }

        private void btnSWR_ExporttoExcel_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(SWR_DGVBreakup);
        }

        private void MasterTemplate_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ControlName")
            {
                string FCR_ID = e.Row.Cells["FCR_ID"].Value.ToString();
                lblReportHead.Text = e.Row.Cells["ControlName"].Value.ToString();
                SqlParameter[] customreport = { new SqlParameter("@Task", "ExcuteReportQuery"), new SqlParameter("@FCR_ID", FCR_ID) };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.CustomReport", customreport);
                dgvCustomerReport_Data.DataSource = ds.Tables[0].DefaultView;
                foreach (GridViewDataColumn column in dgvCustomerReport_Data.Columns)
                {
                    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                }
                dgvCustomReport.EnableFiltering = true;
                dgvCustomReport.ShowFilteringRow = false;
                dgvCustomReport.ShowHeaderCellButtons = true;
                dgvCustomReport.EnableAlternatingRowColor = true;

            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            Helper.clsPluginHelper.GridViewData_Export_to_Excel(dgvCustomerReport_Data);
        }

        private void btnPDFPrint_Click(object sender, EventArgs e)
        {
            RadPrintDocument document = new RadPrintDocument();
            document.HeaderHeight = 64;
            document.HeaderFont = new Font("Arial", 14);
            document.Landscape = true;

            //document.Logo = resizeImage(Properties.Resources.DHALogo,64,64);
            // document.LeftHeader = "[Logo]";
            document.LeftHeader = "DHA Peshawar";
            document.MiddleHeader = lblReportHead.Text;
            document.RightHeader = "[Date Printed]";
            document.ReverseHeaderOnEvenPages = true;
            document.FooterHeight = 30;
            document.FooterFont = new Font("Arial", 12);
            document.LeftFooter = "Page [Page #] of [Total Pages]. Printed on [Date Printed] [Time Printed].";
            //   document.MiddleFooter = "Middle footer";
            //   document.RightFooter = "Right footer";
            //  document.ReverseFooterOnEvenPages = true;
            //WatermarkTextSettings textSettings = new WatermarkTextSettings();
            //textSettings.Text = "Purple Watermark";
            //textSettings.RotateAngle = 30;
            //textSettings.Opacity = 1;
            //textSettings.ForegroundColor = Colors.Purple;

            document.AssociatedObject = this.dgvCustomerReport_Data;
            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog(document);
            dialog.Show();
        }

        public static Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }

        private void btnprdws_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdperiodwisedd);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnalldd_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdalldds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnack_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdack);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnfile_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(grdfiles);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }
    }
}
