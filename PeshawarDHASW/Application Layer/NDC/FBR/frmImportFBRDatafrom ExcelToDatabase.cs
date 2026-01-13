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

namespace PeshawarDHASW.Application_Layer.NDC.FBR
{
    public partial class frmImportFBRDatafrom_ExcelToDatabase : Telerik.WinControls.UI.RadForm
    {
        public frmImportFBRDatafrom_ExcelToDatabase()
        {
            InitializeComponent();
        }
        public delegate void delLwActivityLog(int index, string line);
        public delegate void delStatusActivityLog(string line);
        public void LwActivityLog(int index, string line)
        {
            if (this.dgvActivityLog.InvokeRequired)
            {
                delLwActivityLog dfw = new delLwActivityLog(LwActivityLog);
                this.Invoke(dfw, new object[] { index, line });
            }
            else
            {
                //this.dgvActivityLog.Rows.Add(line);

                ListViewItem lvi = new ListViewItem();
                lvi.Text = index.ToString();
                lvi.SubItems.Add(line);
                dgvActivityLog.Items.Add(lvi);
                dgvActivityLog.Refresh();
            }
        }
        public void writeStatusLabel(string line)
        {
            if (this.lblStatus.InvokeRequired)
            {
                delStatusActivityLog dfw = new delStatusActivityLog(writeStatusLabel);
                this.Invoke(dfw, new object[] { line });
            }
            else
            {
                lblStatus.Text = line;
                lblStatus.Refresh();
            }
        }
        string connstring = clsMostUseVars.Connectionstring; 

        private void btnImportFromExcelToDatabase_Click(object sender, EventArgs e)
        {
            #region Previous Code
            /*try
            {
                btnDownload.Enabled = false;
                if (MessageBox.Show("Are you sure, that you download the latest Excel file from FBR Website ?","Attention !!!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                
                string fileName = "";
                //OpenFileDialog ofd = new OpenFileDialog();
                //if (ofd.ShowDialog() == DialogResult.OK)
                //{
                //    fileName = ofd.FileName;
                //}
                
                fileName = clsMostUseVars.applicationstartuppath + "\\FBRData\\FBR_OwnerType.xlsx";  // @"E:\FBR_Owner_Type_Data\FBR_OwnerType.xlsx";
                // DataTable dataTable = ImportDataFromExcel(@"C:\\Users\\SoftwareEngr MAJM\\Desktop\\voice_recognition_icon\\04-05.xlsx", "complete rep");
                DataTable dataTable1 = ImportDataFromExcel(fileName, "Part1");
                DataTable dataTable2 = ImportDataFromExcel(fileName, "Part2");
                DataTable dataTable3 = ImportDataFromExcel(fileName, "Part3");
                DataTable dataTable4 = ImportDataFromExcel(fileName, "Part4");
                DataTable dataTable5 = ImportDataFromExcel(fileName, "Part5");
                DataTable dataTable6 = ImportDataFromExcel(fileName, "Part6");
                DataTable dataTable7 = ImportDataFromExcel(fileName, "Part7");
                DataTable dataTable8 = ImportDataFromExcel(fileName, "Part8");

                DataTable results1 = dataTable1.Select("SR_NO IS NOT NULL").CopyToDataTable();
                DataTable results2 = dataTable2.Select("SR_NO IS NOT NULL").CopyToDataTable();
                DataTable results3 = dataTable3.Select("SR_NO IS NOT NULL").CopyToDataTable();
                DataTable results4 = dataTable4.Select("SR_NO IS NOT NULL").CopyToDataTable();
                DataTable results5 = dataTable5.Select("SR_NO IS NOT NULL").CopyToDataTable();
                DataTable results6 = dataTable6.Select("SR_NO IS NOT NULL").CopyToDataTable();
                DataTable results7 = dataTable7.Select("SR_NO IS NOT NULL").CopyToDataTable();
                DataTable results8 = dataTable8.Select("SR_NO IS NOT NULL").CopyToDataTable();

                DataTable dtTotal = new DataTable();
                dtTotal.Merge(results1);
                dtTotal.Merge(results2);
                dtTotal.Merge(results3);
                dtTotal.Merge(results4);
                dtTotal.Merge(results5);
                dtTotal.Merge(results6);
                dtTotal.Merge(results7);
                dtTotal.Merge(results8);
                //MessageBox.Show(dtTotal.Rows.Count.ToString());
                if (WriteToDatabase(dtTotal) == true)
                {
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","GetFBROwnerTypeData")
                    };
                    DataSet ds = cls_dl_NDC.NdcRetrival(prm);
                    lblSuccessmessage.Text = ds.Tables[0].Rows[0]["Mesg"].ToString();
                    if(lblSuccessmessage.Text == "Data entered successfully.")
                    {
                        lblSuccessmessage.BackColor = Color.Green;
                        btnDownload.Enabled = true;
                        }
                    else
                    {
                        lblSuccessmessage.BackColor = Color.Red;
                    }

                    //SqlConnection con = new SqlConnection(connection);
                    //SqlCommand delete_item = new SqlCommand("Insertin_tbl_testData", connection);
                    //delete_item.CommandType = CommandType.StoredProcedure;
                    //connection.Open();
                    //delete_item.ExecuteNonQuery();
                    //connection.Close();
                }
                else
                {
                    lblSuccessmessage.Text = "Error !";
                    lblSuccessmessage.BackColor = Color.Red;
                }

              }
              else
              {
                  btnDownload.Enabled = true;
              }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }*/
            #endregion           
             
                Thread Tr1 = new Thread(DataSaving);
                Tr1.Priority = ThreadPriority.Normal;
                Tr1.Start();
            
        }

        #region Old Code
        public DataTable ImportDataFromExcel(string excelFilePath, string sheetName)
        {
            DataSet excelDataSet = new DataSet();
            //declare variables - edit these based on your particular situation 
            string ssqltable = "dbo.tbl_FBROwnerType_FirstTimeEntry";
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have    different 
            string myexceldataquery = "SELECT [NTN],'Filer' as [Type],[NAME],SR_NO,[BUSINESS_NAME] from [" + sheetName + "$]";
            try
            {

                string sexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + excelFilePath + "';Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";


                //execute a query to erase any previous data from our destination table 
                string sclearsql = "truncate table " + ssqltable;
                SqlConnection sqlconn = new SqlConnection(connstring);
                SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                //series of commands to bulk copy data from the excel file into our sql table 
                #region new Excel Select Code
                using (OleDbConnection conn = new OleDbConnection(sexcelconnectionstring))
                {
                    conn.Open();
                    OleDbDataAdapter objDA = new System.Data.OleDb.OleDbDataAdapter(myexceldataquery, conn);
                    objDA.Fill(excelDataSet);
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }
            return excelDataSet.Tables[0];
        }
        private bool WriteToDatabase(DataTable dataTable)
        {
            bool bl = false;
            try
            {
                using (SqlConnection sqlconn = new SqlConnection(connstring))
                {
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlconn, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
                    bulkCopy.DestinationTableName = "dbo.tbl_FBROwnerType_FirstTimeEntry";
                    sqlconn.Open();
                    bulkCopy.WriteToServer(dataTable);
                    sqlconn.Close();
                }
                dataTable.Clear();
            }
            catch (Exception ex)
            {
                bl = false;
                MessageBox.Show(ex.Message);
            }
            bl = true;

            return bl;

        }
        #endregion

        public void DataSaving()
        {
            delLwActivityLog delwActivitylog = new delLwActivityLog(LwActivityLog);
            try
            {
                // Truncate Table tbl_FBROwnerType_FirstTimeEntry
                SqlParameter[] param = { new SqlParameter("@Task", "TRUNCATE_TABLE_tbl_FBROwnerType") };
                SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_NDC", param);

                string fileExt = string.Empty;
                string filePath = clsMostUseVars.applicationstartuppath + "\\FBRData\\FBR_OwnerType.xlsx"; 
                FileInfo fileDetail = new FileInfo(filePath);
                using (ExcelPackage package = new ExcelPackage(fileDetail))
                {
                    writeStatusLabel("Please Wait Loading is in progress.");
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
                            string cs = connstring;
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
                            delwActivitylog(index, item.Name.ToString() + " -- is Complete Total Rows= " + rowCount.ToString());
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
                    writeStatusLabel("Loading is Complete.");
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
                    if(cell.Start.Column ==  row.Columns)
                    {
                        newRow[row.Columns] = "Filer";
                    }
                }
                
                dt.Rows.Add(newRow);
            }

            return dt;
        }




        #region Downloading File From FBR
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, you want to download the latest Excel file from FBR Website ?", "Attention !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                btnImportFromExcelToDatabase.Enabled = false;
            btnDownload.Enabled = false;
            string Path = clsMostUseVars.applicationstartuppath+"\\FBRData\\";
            //Cursor.Current = Cursors.WaitCursor;
            //pcbdownload.Visible = true;
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string filePath in filePaths)
            {
                File.Delete(filePath);
            }
            Thread thread = new Thread(() => {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                webClient.DownloadFileAsync(new Uri("https://www.fbr.gov.pk/Downloads/?id=3901&Type=Docs"), Path+"FBR_OwnerType.xlsx");
            }
            });
            thread.Start();
               
                //pcbdownload.Visible = false;
                //Cursor.Current = Cursors.Default;
            }
        }
        public void wc_DownloadProgressChanged(Object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                radLabel1.Text = "Downloaded " + e.BytesReceived/1000000 +" Mb's"+ "   of   " + e.TotalBytesToReceive / 1000000 + " Mb's";
                prgbdownload.Value = int.Parse(Math.Truncate(percentage).ToString());
                radLabel2.Text = "( "+ Math.Truncate(percentage).ToString()+" %" +" )";
            });

            //prgbdownload.Value = e.ProgressPercentage;

        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                radLabel1.Text = "Download Completed.";
                btnDownload.Enabled = true;
                btnImportFromExcelToDatabase.Enabled = true;
            });
        }
        #endregion

        private void frmImportFBRDatafrom_ExcelToDatabase_Load(object sender, EventArgs e)
        {
            //pcbdownload.Visible = false;
        }
        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
