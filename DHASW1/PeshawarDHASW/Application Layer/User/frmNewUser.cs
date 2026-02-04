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

namespace PeshawarDHASW.Application_Layer.User
{
    public partial class frmNewUser : Telerik.WinControls.UI.RadForm
    {
        public frmNewUser()
        {
            InitializeComponent();
        }

        private void btnImportFromExcelToDatabase_Click(object sender, EventArgs e)
        {
            //Thread Tr1 = new Thread(DataSaving);
            //Tr1.Priority = ThreadPriority.Normal;
            //Tr1.Start();
            DataSaving();
        }
        public void writeStatusLabel(string line)
        {
            //if (this.lblStatus.InvokeRequired)
            //{
            //    delStatusActivityLog dfw = new delStatusActivityLog(writeStatusLabel);
            //    this.Invoke(dfw, new object[] { line });
            //}
            //else
            //{
            //    lblStatus.Text = line;
            //    lblStatus.Refresh();
            //}
        }
        public void DataSaving()
        {
           // delLwActivityLog delwActivitylog = new delLwActivityLog(LwActivityLog);
            try
            {
                // Truncate Table tbl_FBROwnerType_FirstTimeEntry
                //SqlParameter[] param = { new SqlParameter("@Task", "TRUNCATE_TABLE_tbl_FBROwnerType") };
                //SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_NDC", param);

                string fileExt = string.Empty;
                //string filePath = clsMostUseVars.applicationstartuppath + "\\FBRData\\FBR_OwnerType.xlsx";
                string filePath = "E:\\Muhammad Abdul Jalil\\Projects\\RentalDHAP\\RentalDHAP\\RentalDHAP\\wwwroot\\Uploads\\data.xls";
                FileInfo fileDetail = new FileInfo(filePath);
                using (ExcelPackage package = new ExcelPackage(fileDetail))
                {
                   // writeStatusLabel("Please Wait Loading is in progress.");
                    string File = System.IO.Path.GetFileName(filePath);
                    int sheets = package.Workbook.Worksheets.Count;
                    int index = 1, sheet = 1;
                    foreach (var item in package.Workbook.Worksheets)
                    {
                        //ExcelWorksheet worksheet = item;
                        int rowCount = item.Dimension.Rows;
                        var dd = ExcelPackageToDataTable(item, sheet);

                        try
                        {
                            string cs = clsMostUseVars.Connectionstring;
                            using (SqlConnection sqlConn = new SqlConnection(cs))
                            {

                                sqlConn.Open();
                                using (SqlBulkCopy sqlbc = new SqlBulkCopy(sqlConn, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null))
                                {
                                    sqlbc.DestinationTableName = "tbl_FBROwnerType";
                                    sqlbc.ColumnMappings.Add("SR_NO", "SR_NO");
                                    sqlbc.ColumnMappings.Add("NTN", "NTN");
                                    sqlbc.ColumnMappings.Add("NAME", "NAME");
                                    sqlbc.ColumnMappings.Add("BUSINESS_NAME", "BUSINESS_NAME");
                                    sqlbc.ColumnMappings.Add("Type", "Type");
                                    sqlbc.BulkCopyTimeout = 0;
                                    sqlbc.WriteToServer(dd);
                                }
                            }
                            //delwActivitylog(index, item.Name.ToString() + " -- is Complete Total Rows= " + rowCount.ToString());
                            // MessageBox.Show(item.Name.ToString()+" -- is Complete Total Rows= "+ rowCount.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        index = index + 1;
                        sheet = sheet + 1;
                    }
                    //SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_Type_ToFiler_tbl_FBROwnerType");
                    //writeStatusLabel("Loading is Complete.");
                    // }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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
            dt.Columns.Add("Type");
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
                        newRow[row.Columns] = "Filer";
                    }
                }

                dt.Rows.Add(newRow);
            }

            return dt;
        }
    }
}
