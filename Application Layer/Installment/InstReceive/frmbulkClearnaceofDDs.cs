using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using System.Data.OleDb;
using System.Data.SqlClient;
using PeshawarDHASW.Data_Layer.NDC;
using System.Net;
using System.IO;
using System.Threading;
using PeshawarDHASW.Helper;
using OfficeOpenXml;
using System.Configuration;
using System.Linq;
using PeshawarDHASW.Models;
using PeshawarDHASW.Data_Layer.Installment;
using System.Globalization;
using PeshawarDHASW.Data_Layer.clsAcknowledgment;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class frmbulkClearnaceofDDs : Telerik.WinControls.UI.RadForm
    {
        public frmbulkClearnaceofDDs()
        {
            InitializeComponent();
            btnVerification.Enabled = false;
            btnBulkClearanceStart.Enabled = false;
        }
        public static string UserInfoKey { get; set; } = "";
        public DataTable DDList { get; set; }
        private void btnExcelImport_Click(object sender, EventArgs e)
        {
            UserInfoKey  = clsUser.Name.ToUpper() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmssffff");
            OpenFileDialog ExcelImportDialog = new OpenFileDialog();

            ExcelImportDialog.InitialDirectory = @"C:\";
            ExcelImportDialog.Title = "Browse Excel File (xlsx)";

            ExcelImportDialog.CheckFileExists = true;
            ExcelImportDialog.CheckPathExists = true;

            ExcelImportDialog.DefaultExt = "xlsx";
            ExcelImportDialog.Filter = "Excel Worksheets|*.xlsx";
            ExcelImportDialog.FilterIndex = 2;
            ExcelImportDialog.RestoreDirectory = true;

            ExcelImportDialog.ReadOnlyChecked = true;
            ExcelImportDialog.ShowReadOnly = true;

            if (ExcelImportDialog.ShowDialog() == DialogResult.OK)
            {
                string file = ExcelImportDialog.FileName;
                try
                {
                    string fileExt = file;
                   
                    FileInfo fileDetail = new FileInfo(file);
                    lblfileName.Text = fileDetail.FullName;
                    using (ExcelPackage package = new ExcelPackage(fileDetail))
                    {
                        string File = System.IO.Path.GetFileName(file);
                        int sheets = package.Workbook.Worksheets.Count;
                        int index = 1, sheet = 1;
                        foreach (var item in package.Workbook.Worksheets)
                        {
                            //ExcelWorksheet worksheet = item;
                            int rowCount = item.Dimension.Rows;
                            DDList = ExcelPackageToDataTable(item, sheet);
                            lblTotalRecords.Text = DDList.Rows.Count.ToString();
                            btnVerification.Enabled = true;
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                    btnVerification.Enabled = false;
                    btnBulkClearanceStart.Enabled = false;
                }
            }
        }

        public static DataTable ExcelPackageToDataTable(ExcelWorksheet excelPackage, int index)
        {
            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[index];

            //check if the worksheet is completely empty
            if (worksheet.Dimension == null)
            {
                return dt;
            }

            //create a list to hold the column names
            List<string> columnNames = new List<string>();

            //needed to keep track of empty column headers
            int currentColumn = 1;

            //loop all columns in the sheet and add them to the datatable
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columnName = cell.Text.Trim();

                //check if the previous header was empty and add it if it was
                if (cell.Start.Column != currentColumn)
                {
                    columnNames.Add("Header_" + currentColumn);
                    dt.Columns.Add("Header_" + currentColumn);
                    currentColumn++;
                }

                //add the column name to the list to count the duplicates
                columnNames.Add(columnName);

                //count the duplicate column names and make them unique to avoid the exception
                //A column named 'Name' already belongs to this DataTable
                int occurrences = columnNames.Count(x => x.Equals(columnName));
                if (occurrences > 1)
                {
                    columnName = columnName + "_" + occurrences;
                }

                //add the column to the datatable
                dt.Columns.Add(columnName);

                currentColumn++;
            }

            dt.Columns.Add("UserInfo");
            
            //start adding the contents of the excel file to the datatable
            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                DataRow newRow = dt.NewRow();
                int CellCount = 1;
                //loop all cells in the row
                foreach (var cell in row)
                {
                    //newRow[cell.Start.Column - 1] = cell.Text;
                    if ((cell.Start.Column - 1) < cell.Start.Column)
                    {

                        newRow[cell.Start.Column - 1] = cell.Text;
                    }
                    if (cell.Start.Column == row.Columns)
                    {
                        newRow[row.Columns] = UserInfoKey;
                     
                    }
                }

                dt.Rows.Add(newRow);
            }

            return dt;
        }
        public  DataSet VerificationDataSet { get; set; }
        private void btnVerification_Click(object sender, EventArgs e)
        {
            try
            {

                if (VerificationDataSet == null || VerificationDataSet.Tables[0].Rows.Count == 0 )
                {
                    string cs = clsMostUseVars.Connectionstring;
                    using (SqlConnection sqlConn = new SqlConnection(cs))
                    {
                        sqlConn.Open();
                        using (SqlBulkCopy sqlbc = new SqlBulkCopy(sqlConn, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null))
                        {
                            sqlbc.DestinationTableName = "tbl_BulkClearance";
                            sqlbc.ColumnMappings.Add("TrxID", "TrxID");
                            sqlbc.ColumnMappings.Add("DDNo", "DDNo");
                            sqlbc.ColumnMappings.Add("CDate", "CDate");
                            //sqlbc.ColumnMappings.Add("Print", "Print");
                            //sqlbc.ColumnMappings.Add("SMS", "SMS");
                            //sqlbc.ColumnMappings.Add("EMAIL", "EMAIL");
                            sqlbc.ColumnMappings.Add("UserInfo", "UserInfo");
                            sqlbc.BulkCopyTimeout = 0;
                            sqlbc.WriteToServer(DDList);
                        }
                        sqlConn.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("List Already Uploaded to Server.\n Bulk Clearance Key: "+UserInfoKey.ToUpper());
                }

                SqlParameter[] param = { new SqlParameter("@Task","BulkClearanceVerification"),
                    new SqlParameter("@BulkClearanceCode",UserInfoKey) };
                VerificationDataSet = Helper.SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_ReceInst", param  );
                GridViewListData.DataSource = VerificationDataSet.Tables[0].DefaultView;
                lblVerifiedcount.Text = VerificationDataSet.Tables[0].Rows.Count.ToString();
                if (DDList.Rows.Count == VerificationDataSet.Tables[0].Rows.Count)
                {
                    btnVerification.Enabled = false;
                    btnBulkClearanceStart.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please Verify your Transaction TrxID"
                        +"\n"
                        +"List TrxID Count = "+ DDList.Rows.Count.ToString()
                          + "\n System Verified TrxID Count = " + VerificationDataSet.Tables[0].Rows.Count.ToString()
                          +"\n which is not matched"
                        );


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnVerification.Enabled = false;
                btnBulkClearanceStart.Enabled = false;
            }
           
        }
        private void GridViewListData_RowsChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
            //lblTotalRecords.Text = GridViewListData.Rows.Count.ToString();
        }

        private void btnBulkClearanceStart_Click(object sender, EventArgs e)
        {
            try
            {
                    string BulkClearanceKey_ = VerificationDataSet.Tables[0].Rows[0]["UserInfo"].ToString();
                    AcknowledgementGeneration( BulkClearanceKey_);
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Transaction Found in the List or Check your Internet Connection");
            }
        }
        #region Bulk Acknowledgement
        private void AcknowledgementGeneration(string BulkClearanceKey)
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@UserKeyValue", clsUser.ID),
                    new SqlParameter("@userInfo",BulkClearanceKey)
                 };
                int result = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.Bulk_Clearance", param);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bulk Clearance Transaction Key:"+ BulkClearanceKey + "\nPlease on page before processing further.\n Error Message:\t"+ ex.Message);
            }
           
        }
        #endregion

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(GridViewListData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occurs\n Error -> \n" + ex.Message);
            }
        }
    }
}
