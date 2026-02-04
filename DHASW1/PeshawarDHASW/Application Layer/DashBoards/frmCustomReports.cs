using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.DashBoards
{
    public partial class frmCustomReports : Telerik.WinControls.UI.RadForm
    {
        public frmCustomReports()
        {
            InitializeComponent();
        }
        private int FCR_ID { get; set; }
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

        private void dgvCustomReport_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ControlName")
            {
                FCR_ID = Convert.ToInt32(e.Row.Cells["FCR_ID"].Value.ToString());
                if( FCR_ID == 13 || FCR_ID == 28)
                {
                    dtpfromDate.Enabled = true;
                    dtptoDate.Enabled = true;
                    btnFind.Enabled = true;
                }
                else
                {
                    dtpfromDate.Enabled = false;
                    dtptoDate.Enabled = false;
                    btnFind.Enabled = false;
                }
                //   
                if ( (FCR_ID == 19) )
                {
                    dtpsur_duesRemainnig.Enabled = true;
                    btnFind.Enabled = true;
                }
                else 
                {
                    dtpsur_duesRemainnig.Enabled = false;
                }
                lblReportHead.Text = e.Row.Cells["ControlName"].Value.ToString();
                SqlParameter[] customreport = 
                {
                    new SqlParameter("@Task", "ExcuteReportQuery_AM"),
                    new SqlParameter("@FCR_ID", FCR_ID)
                };
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

        private void frmCustomReports_Load(object sender, EventArgs e)
        {
            try
            {
                dtpfromDate.Enabled = false;
                dtptoDate.Enabled = false;
                btnFind.Enabled = false;
                dtpsur_duesRemainnig.Enabled = false;

                SqlParameter[] customreport = { new SqlParameter("@Task", "All_Task_AM") };
            DataSet ds   = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.CustomReport", customreport);
                dgvCustomReport.DataSource = ds.Tables[0].DefaultView;
                AdvanceGrid.DataSource = ds.Tables[1].DefaultView;

               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Process is intercepted -> \n"+ex.Message);
            }
          
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if(FCR_ID == 13)
                {
                    SqlParameter[] customreport =
                    {
                    new SqlParameter("@Task", "DateWise_Report_In_All_Task_AM"),
                    new SqlParameter("@frmDate",dtpfromDate.Value.Date),
                    new SqlParameter("@todt",dtptoDate.Value.Date)
                    };
                    dgvCustomerReport_Data.DataSource = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.CustomReport", customreport).Tables[0].DefaultView;
                    foreach (GridViewDataColumn column in dgvCustomerReport_Data.Columns)
                    {
                        column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                    }
                }
                else if (FCR_ID == 19)
                {
                    ////////////// Calculate the Due's and Surcharge Data
                    SqlParameter[] customreport =
                    {
                    new SqlParameter("@Task", "AllRemainingDuesAndSurchargeUptoProvidedDate"),
                    new SqlParameter("@CurrentDate",dtpsur_duesRemainnig.Value.Date)
                    };

                    Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.CustomReport", customreport);
                    /////////////// Now get data and Bind with Grid
                    SqlParameter[] customreportget =
                    {
                    new SqlParameter("@Task", "GetAllRemainingDuesAndSurchargeUptoProvidedDate"),
                    new SqlParameter("@CurrentDate",dtpsur_duesRemainnig.Value.Date)
                    };
                    dgvCustomerReport_Data.DataSource = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),
                        CommandType.StoredProcedure, "App.CustomReport", customreportget).Tables[0].DefaultView;
                    foreach (GridViewDataColumn column in dgvCustomerReport_Data.Columns)
                    {
                        column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                    }
                }
                else if (FCR_ID == 28)
                {
                    SqlParameter[] customreport =
                    {
                    new SqlParameter("@Task", "DateWise_Dues_Report"),
                    new SqlParameter("@Fromdatedues",dtpfromDate.Value.Date),
                    new SqlParameter("@ToDatedues",dtptoDate.Value.Date)
                    };
                    dgvCustomerReport_Data.DataSource = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.CustomReport", customreport).Tables[0].DefaultView;
                    foreach (GridViewDataColumn column in dgvCustomerReport_Data.Columns)
                    {
                        column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Process is intercepted -> \n" + ex.Message);
            }
        }

        private void btnFindSurDues_Click(object sender, EventArgs e)
        {
            try
            {
               // ////////////// Calculate the Due's and Surcharge Data
               // SqlParameter[] customreport =
               // {
               //     new SqlParameter("@Task", "AllRemainingDuesAndSurchargeUptoProvidedDate"),
               //     new SqlParameter("@CurrentDate",dtpsur_duesRemainnig.Value.Date)
               // };
                
               // Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.CustomReport", customreport);
               // /////////////// Now get data and Bind with Grid
               //SqlParameter[] customreportget =
               //{
               //     new SqlParameter("@Task", "GetAllRemainingDuesAndSurchargeUptoProvidedDate"),
               //     new SqlParameter("@CurrentDate",dtpsur_duesRemainnig.Value.Date)
               // };
               // dgvCustomerReport_Data.DataSource = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), 
               //     CommandType.StoredProcedure, "App.CustomReport", customreportget).Tables[0].DefaultView;
               // foreach (GridViewDataColumn column in dgvCustomerReport_Data.Columns)
               // {
               //     column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
               // }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Process is intercepted -> \n" + ex.Message);
            }
        }

        private void btnshowdata_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlParameter[] customreport =
                //{
                //    new SqlParameter("@Task", "GetAllRemainingDuesAndSurchargeUptoProvidedDate"),
                //    new SqlParameter("@CurrentDate",dtpsur_duesRemainnig.Value.Date)
                //};
                //dgvCustomerReport_Data.DataSource = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.CustomReport", customreport).Tables[0].DefaultView;
                //foreach (GridViewDataColumn column in dgvCustomerReport_Data.Columns)
                //{
                //    column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Process is intercepted -> \n" + ex.Message);
            }
        }

        private void AdvanceGrid_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "ControlName")
            {
                try
                {
                    string ReportTitle = e.Row.Cells["ControlName"].Value.ToString();
                    string ServerPath = e.Row.Cells["ServerPath"].Value.ToString();
                    string ReportPath = e.Row.Cells["ReportPath"].Value.ToString();
                    ReportViewerShow(ServerPath.Replace("\n", ""), ReportPath.Replace("\n",""));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
            }
       }
        private void ReportViewerShow(string ServerPath,string ReportPath)
        {
            try
            {
                string urlReportServer = ServerPath;//ConfigurationManager.AppSettings["ReportServerURL"].ToString();
                reportViewer1.ProcessingMode = ProcessingMode.Remote; // ProcessingMode will be Either Remote or Local
                //reportViewer1.ShowCredentialPrompts = false;
                NetworkCredential myCred = new NetworkCredential("Administrator", "Dr3am#@!", "");
                reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = myCred;
                reportViewer1.ServerReport.ReportServerUrl = new Uri(urlReportServer); //Set the ReportServer Url
                reportViewer1.ServerReport.ReportPath = ReportPath; //Passing the Report Path
                
                reportViewer1.ServerReport.Refresh();
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
