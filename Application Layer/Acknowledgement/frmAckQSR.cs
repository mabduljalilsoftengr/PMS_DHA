using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using OfficeOpenXml;


namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    public partial class frmAckQSR : Telerik.WinControls.UI.RadForm
    {
        public frmAckQSR()
        {
            InitializeComponent();
        }

        public static  DataTable ExcelPackageToDataTable(ExcelWorksheet excelPackage, int index)
        {
            DataTable FinalDatatableData = new DataTable();
            try
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
            //start adding the contents of the excel file to the datatable
            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                DataRow newRow = dt.NewRow();
               
                //loop all cells in the row
                foreach (var cell in row)
                {
                    //newRow[cell.Start.Column - 1] = cell.Text;
                    if ((cell.Start.Column - 1) < cell.Start.Column)
                    {
                        newRow[cell.Start.Column - 1] = cell.Text;
                    }
                }

                dt.Rows.Add(newRow);
            }
                DataTable dtb = clsPluginHelper.RemoveBlankRows(dt);
              //  dtb = clsPluginHelper.DataTableConvertColumnType(dtb, "Booking Date", typeof(DateTime));
              //  dtb = clsPluginHelper.DataTableConvertColumnType(dtb, "Delivery Date", typeof(DateTime));
                FinalDatatableData = dtb;
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return FinalDatatableData;
        }



        private void QSRUploading(string filePath)
        {
            try
            {
                FileInfo fileDetail = new FileInfo(filePath);
                using (ExcelPackage package = new ExcelPackage(fileDetail))
                {

                    int sheets = package.Workbook.Worksheets.Count;
                    int index = 2, sheet = 2;
                    if (sheets != 2)
                    {
                        MessageBox.Show("Invalid Excel Sheet -- Sheet2 is Missing");
                        return;
                    }
                    //foreach (var item in package.Workbook.Worksheets)
                    //{
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[index];
                        //var item = package.Workbook.Worksheets;
                        int rowCount = worksheet.Dimension.Rows;
                        var dd = ExcelPackageToDataTable(worksheet, sheet);
                        string cs = PMS_Setting.MainConnections.ConnectionString_MainServer;
                        using (SqlConnection sqlConn = new SqlConnection(cs))
                        {

                            sqlConn.Open();
                            using (SqlBulkCopy sqlbc = new SqlBulkCopy(sqlConn, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null))
                            {
                                sqlbc.DestinationTableName = "tbl_AcknowledgmentQSR";
                                sqlbc.ColumnMappings.Add("CN Number", "CNNumber");
                                sqlbc.ColumnMappings.Add("Booking Date", "BookingDate");
                                sqlbc.ColumnMappings.Add("pieces", "NoOfPieces");
                                sqlbc.ColumnMappings.Add("Weight", "Weight");
                                sqlbc.ColumnMappings.Add("Consignee", "Consignee");
                                sqlbc.ColumnMappings.Add("Dest Zone", "DestZone");
                                sqlbc.ColumnMappings.Add("Dest Branch", "DestBranch");
                                sqlbc.ColumnMappings.Add("Reason", "Reason");
                                sqlbc.ColumnMappings.Add("Delivery Date", "DeliveryDate");
                                sqlbc.ColumnMappings.Add("Delivery Time", "DeliveryTime");
                                sqlbc.ColumnMappings.Add("Received By", "ReceivedBy");
                                sqlbc.BulkCopyTimeout = 0;
                                sqlbc.WriteToServer(dd);
                                MessageBox.Show("Data is Uploaded Successfully \n\n Total Records:->"+ dd.Rows.Count.ToString());
                            }
                        }
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void btnUploadQsr_Click(object sender, EventArgs e)
        {
            string NextSerial = SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.Text, "Select isnull(Max(ackQsrID),0)+1 as ackQsrID from dbo.tbl_AcknowledgmentQSR").ToString();
            MessageBox.Show(@"Next S.No will be start from " + NextSerial + "\n\nPlease Make sure that\n1. Data should be in this format"
                +"\n\nS.No. | CN Number | Booking Date | Pieces | Weight | Consignee | Dest Zone | Dest Branch | Reason | Delivery Date | Delivery Time | Received By"
                +"\n\n2. Record data should be in Sheet2.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Excel files|*.xls;*.xlsx;";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string excelfilepath = openFileDialog1.FileName;
                QSRUploading(excelfilepath);
            }
        }
        private void OldQSRUpload(string excelfilepath)
        {
            string ssqltable = "tbl_AcknowledgmentQSR";
            try
            {
                //create our connection strings
                string sexcelconnectionstring = "";

                if (Path.GetExtension(excelfilepath).ToLower().Trim() == ".xls" && Environment.Is64BitOperatingSystem == false)
                    sexcelconnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelfilepath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                else
                    sexcelconnectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelfilepath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";

                DataTable dt = new DataTable();
                string ssqlconnectionstring = clsMostUseVars.Connectionstring;
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                oledbconn.Open();
                {
                    string myexceldataquery = "select * from [sheet" + 2 + "$]";
                    OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);

                    OleDbDataReader dr = oledbcmd.ExecuteReader();
                    SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring, SqlBulkCopyOptions.KeepNulls);
                    bulkcopy.DestinationTableName = ssqltable;
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(1, "CNNumber"));
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(2, "BookingDate"));
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(3, "NoOfPieces"));
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(4, "Weight"));
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(5, "Consignee"));
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(6, "DestZone"));
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(7, "DestBranch"));
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(8, "Reason"));
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(9, "DeliveryDate"));
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(10, "DeliveryTime"));
                    bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(11, "ReceivedBy"));
                    {
                        bulkcopy.WriteToServer(dr);
                    }
                    oledbconn.Close();
                    MessageBox.Show("File uploaded successfuly..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                //handle exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            try
            {
                Helper.clsPluginHelper.GridViewData_Export_to_Excel(dgAckQSR);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kindly Install the Third Software First.\n Error -> \n" + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime? dateFrom = null;
            DateTime? dateTo = null;

            if (dtFrom.Value.Date.Year == 1)
                dateFrom = null;
            else
            {
                dateFrom = dtFrom.Value.Date;
                if (dtTo.Value.Date.Year == 1)
                    dateTo = DateTime.Now.Date;
                else
                    dateTo = dtTo.Value.Date;
            }



            SqlParameter[] param = {
                                        new SqlParameter("@Task","GetAckQSR"),
                                        new SqlParameter("@FromDate",dateFrom),
                                        new SqlParameter("@ToDate",dateTo),
                                        new SqlParameter("@AckFinID", string.IsNullOrEmpty(txtAckNo.Text.Trim())? null : txtAckNo.Text.Trim()),
                                        new SqlParameter("@FileNo", string.IsNullOrEmpty(txtFileNo.Text.Trim())? null : txtFileNo.Text.Trim())
                                    };
            DataSet ds = new DataSet();
            ds = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(param);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgAckQSR.DataSource = ds.Tables[0].DefaultView;
                }
                else
                {
                    dgAckQSR.DataSource = null;
                }
            }
            else
            {
                dgAckQSR.DataSource = null;
            }

        }

        private void frmAckQSR_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void txtFileNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}