using Microsoft.Reporting.WinForms;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Properties;
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
    public partial class FinanceDashBoard : Telerik.WinControls.UI.RadForm
    {
        public FinanceDashBoard()
        {
            InitializeComponent();

            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FinanceReport", new SqlParameter("@Task", "ReportAllData"));
            this.radTreeView1.DisplayMember = "ReportName";
            this.radTreeView1.ParentMember = "ParentID";
            this.radTreeView1.ChildMember = "ReportID";
            this.radTreeView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.radTreeView1.Filter = radTextBox1.Text;
        }

        private void radTreeView1_NodeMouseClick(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            try
            {      
                //RadTreeViewMouseEventArgs args = e as RadTreeViewMouseEventArgs;
                string ReportName = e.Node.Text.Replace("\r\n", string.Empty);
                if ( !string.IsNullOrWhiteSpace(ReportName))
                {
                    SqlParameter[] param = {
                        new SqlParameter("@Task","ReportData"),
                        new SqlParameter("@ReportName",ReportName),
                    };
                    DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FinanceReport", param);
                    string ServerPath = ds.Tables[0].Rows[0]["ReportURL"].ToString();
                    string ReportPath = ds.Tables[0].Rows[0]["ReportPath"].ToString();
                    ReportViewerShow(ServerPath.Replace("\n", ""), ReportPath.Replace("\n", ""));
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void ReportViewerShow(string ServerPath, string ReportPath)
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

        private void radTreeView1_NodeFormatting(object sender, TreeNodeFormattingEventArgs e)
        {
            //if (e.Node.Level == 0)
            //{
            //    e.Node.Image = Resources.Lock;
            //}

        }
    }
}
