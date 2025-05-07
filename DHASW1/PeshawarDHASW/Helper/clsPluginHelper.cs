using Newtonsoft.Json;
using OfficeOpenXml;
using PeshawarDHASW.Application_Layer.CustomDialog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Helper
{
    public static class clsPluginHelper
    {

        public static void GridColumnBestFit(RadGridView dgv)
        {
            foreach (GridViewDataColumn column in dgv.Columns)
            {
                column.BestFit();//.AutoSizeMode = BestFitColumnMode.DisplayedDataCells;
            }
        }

        /// <summary>
        /// This Function is use as Helper for 
        /// if textbox is empty this function help
        /// to return a DB NULL value in it.
        /// </summary>
        /// <param name="str">Text</param>
        /// <returns>text</returns>

        #region DbNULLifNULLorEmpty
        public static object DbNullIfNullOrEmpty(string str)
        {
            return !String.IsNullOrEmpty(str) ? str : (object)DBNull.Value;
        }

        #endregion

        /// <summary>
        /// Grid View Columan Add
        /// </summary>
        /// <param name="Name"> Column Name </param>
        /// <param name="FieldName"> Field Name </param>
        /// <param name="HeaderText"> Header Text </param>
        /// <param name="DefaultText"> Default Text </param>
        /// <param name="Size"> Column Width</param>
        /// <returns> GridViewCommandColumn </returns>
        public static GridViewCommandColumn GdButton(
            string Name = "Cell1",
            string FieldName = "",
            string HeaderText = "",
            string DefaultText = "",
            int Size = 80)
        {
            GridViewCommandColumn CustomControl = new GridViewCommandColumn();
            CustomControl.Name = Name;
            CustomControl.UseDefaultText = true;
            CustomControl.FieldName = FieldName;
            CustomControl.DefaultText = DefaultText;
            CustomControl.Width = Size;
            //CustomControl.ReadOnly = true;
            CustomControl.TextAlignment = ContentAlignment.MiddleCenter;
            CustomControl.HeaderText = HeaderText;
            return CustomControl;
        }

        public static bool FieldMustbefill(ErrorProvider ErrorWarning, ErrorProvider ErrorCorrect,
            ErrorProvider ErrorWrongFormat,
            TextBox txt, string Message, Regex numberchk)
        {
            if (txt.Text == string.Empty)
            {
                ErrorWarning.SetError(txt, "Please Enter " + Message);
                ErrorCorrect.SetError(txt, "");
                ErrorWrongFormat.SetError(txt, "");
                return false;
                //  btnSave.Enabled = false;
            }

            else
            {
                ErrorWarning.SetError(txt, "");
                ErrorCorrect.SetError(txt, "");
                ErrorWrongFormat.SetError(txt, "");
                return true;
            }
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public static SqlParameter Parameter(SqlDbType dbtype, string ParameterName, string Value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParameterName;
            param.SqlDbType = dbtype;
            param.SqlValue = Value;
            return param;
            // cmd.Parameters.Add(param);
        }

        public static bool formatValidator(
            ErrorProvider ErrorWarning,
            ErrorProvider ErrorCorrect,
            ErrorProvider ErrorWrongFormat,
            TextBox txt, string Message, Regex numberchk)
        {

            if (numberchk.IsMatch(txt.Text))
            {
                ErrorWarning.SetError(txt, "");
                ErrorWrongFormat.SetError(txt, "");
                ErrorCorrect.SetError(txt, "Correct " + Message);
                return true;
            }
            else
            {
                ErrorWarning.SetError(txt, "");
                ErrorWrongFormat.SetError(txt, "Wrong format " + Message);
                ErrorCorrect.SetError(txt, "");
                return false;
            }

        }



        public static bool RadFieldMustbefill(ErrorProvider ErrorWarning, ErrorProvider ErrorCorrect,
            ErrorProvider ErrorWrongFormat,
            RadTextBox txt, String Message, Regex numberchk)
        {
            if (txt.Text == string.Empty)
            {
                ErrorWarning.SetError(txt, "Please Enter " + Message);
                ErrorCorrect.SetError(txt, "");
                ErrorWrongFormat.SetError(txt, "");
                return false;
                //  btnSave.Enabled = false;
            }

            else
            {
                ErrorWarning.SetError(txt, "");
                ErrorCorrect.SetError(txt, "");
                ErrorWrongFormat.SetError(txt, "");
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ErrorWarning"> ErrorPorviderWarning</param>
        /// <param name="ErrorCorrect">ErrorProviderCorrect</param>
        /// <param name="ErrorWrongFormat">ErrorProviderFormat</param>
        /// <param name="txt">RadTextBox Name</param>
        /// <param name="Message"> Message in String</param>
        /// <param name="numberchk"> Regular Expression</param>
        /// <returns> True False</returns>
        public static bool RadformatValidator(
            ErrorProvider ErrorWarning,
            ErrorProvider ErrorCorrect,
            ErrorProvider ErrorWrongFormat,
            RadTextBox txt, String Message, Regex numberchk)
        {

            if (numberchk.IsMatch(txt.Text))
            {
                ErrorWarning.SetError(txt, "");
                ErrorWrongFormat.SetError(txt, "");
                ErrorCorrect.SetError(txt, "Correct " + Message);
                return true;
            }
            else
            {
                ErrorWarning.SetError(txt, "");
                ErrorWrongFormat.SetError(txt, "Wrong format " + Message);
                ErrorCorrect.SetError(txt, "");
                return false;
            }

        }

        public static bool RadformatValidatorDropDownList(
            ErrorProvider ErrorWarning,
            ErrorProvider ErrorCorrect,
            ErrorProvider ErrorWrongFormat,
            RadDropDownList txt, String Message, Regex numberchk)
        {

            if (numberchk.IsMatch(txt.Text))
            {
                ErrorWarning.SetError(txt, "");
                ErrorWrongFormat.SetError(txt, "");
                ErrorCorrect.SetError(txt, "Correct " + Message);
                return true;
            }
            else
            {
                ErrorWarning.SetError(txt, "");
                ErrorWrongFormat.SetError(txt, "Wrong format " + Message);
                ErrorCorrect.SetError(txt, "");
                return false;
            }

        }

        /// <summary>
        /// For CheckBox Value Checking
        /// </summary>
        /// <param name="Chk">RadCheckBox</param>
        /// <returns>0,1</returns>
        public static string CheckboxCheck(RadCheckBox Chk)
        {
            return Chk.Checked == true ? "1" : "0";
        }

        public static DataTable Convert_Grid_To_DataTable(RadGridView dgv)
        {
            var dt = new DataTable();
            foreach (var dataGridViewColumn in dgv.Columns)
            {
                // if (dataGridViewColumn.Visible)
                {
                    dt.Columns.Add(dataGridViewColumn.Name);
                }
            }

            var cell = new object[dgv.Columns.Count];
            foreach (var dataGridViewRow in dgv.Rows)
            {
                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
                {
                    string drf = dataGridViewRow.Cells[i].ColumnInfo.ToString();
                    string nl = "NULL";
                    if (drf.Contains("GridViewDecimalColumn"))
                    {
                        cell[i] = (dataGridViewRow.Cells[i].Value == null || dataGridViewRow.Cells[i].Value.ToString() == "") ? 0 : dataGridViewRow.Cells[i].Value;
                    }
                    else if (drf.Contains("GridViewTextBoxColumn"))
                    {
                        cell[i] = (dataGridViewRow.Cells[i].Value == null || dataGridViewRow.Cells[i].Value.ToString() == "") ? nl : dataGridViewRow.Cells[i].Value;
                    }
                    else if (drf.Contains("GridViewComboBoxColumn"))
                    {
                        cell[i] = (dataGridViewRow.Cells[i].Value == null || dataGridViewRow.Cells[i].Value.ToString() == "") ? "" : dataGridViewRow.Cells[i].Value;
                    }
                    else if (drf.Contains("GridViewDateTimeColumn"))
                    {
                        cell[i] = (dataGridViewRow.Cells[i].Value == null || dataGridViewRow.Cells[i].Value.ToString() == "") ? DateTime.Now : dataGridViewRow.Cells[i].Value;
                    }
                    else
                    {
                        cell[i] = (dataGridViewRow.Cells[i].Value == null || dataGridViewRow.Cells[i].Value.ToString() == "") ? nl : dataGridViewRow.Cells[i].Value;
                    }

                }

                dt.Rows.Add(cell);
            }

            return dt;
        }

        /// <summary>
        /// This Function is design for get the Data member value from Rad DropDownList
        /// </summary>
        /// <param name="radDropDownList"></param>
        /// <returns>Number in String Format</returns>
        public static string RadDropDownSelectValue(RadDropDownList radDropDownList)
        {
            string str = "";
            foreach (RadListDataItem item in radDropDownList.SelectedItems)
            {
                DataRowView dv = (DataRowView)item.Value;
                str = dv.Row[0].ToString();
            }

            return str;
        }

        public static void RadDropDownSelectedbyValue(RadDropDownList rd, int Value)
        {
            foreach (RadListDataItem item in rd.Items)
            {
                string strv = item.Value.ToString();
                if (strv == Value.ToString())
                {
                    item.Selected = true;
                }

            }
        }

        public static void RadDropDownSelectByText(this RadDropDownList dropDown, string searchItem)
        {
            dropDown.SelectedIndex = dropDown.FindString(searchItem);
        }

        public static void DateTimePickerBinding(RadDateTimePicker rdtp, string date)
        {
            rdtp.DateTimePickerElement.Value = DateTime.ParseExact(date, "dd/MM/yyyy", null);
        }

        public static SqlParameter SqlparameterAttachtext(string ParamName, string Text)
        {
            return new SqlParameter(ParamName, clsPluginHelper.DbNullIfNullOrEmpty(Text));
        }

        public static Image ImageRetrive(byte[] imgdata)
        {
            MemoryStream ms = new MemoryStream(imgdata);
            ms.Position = 0;
            return Image.FromStream(ms);
        }

        public static DataTable ColmnsCreateinDatatable(List<DataTable_column> ColmnsName)
        {
            DataTable dt = new DataTable();
            foreach (DataTable_column row in ColmnsName)
            {
                dt.Columns.Add(row.ColmnName, row.type);
            }

            return dt;
        }

        public static string Convert_Number_To_Text(int number, bool isUK)
        {
            if (number == 0) return "Zero";
            string and = isUK ? "and " : ""; // deals with UK or US numbering
            if (number == -2147483648)
                return "Minus Two Billion One Hundred " + and +
                       "Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
                       "Six Hundred " + and + "Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }

            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 =
            {
                "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ",
                "Eighteen ", "Nineteen "
            };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };
            num[0] = number % 1000; // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2]; // thousands
            num[3] = number / 1000000000; // billions
            num[2] = num[2] - 1000 * num[3]; // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }

            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10; // ones
                t = num[i] / 10;
                h = num[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }

                if (i != 0) sb.Append(words3[i - 1]);
            }

            return sb.ToString().TrimEnd();
        }


        public static void GridViewData_Export_to_Excel(RadGridView RdGridView)
        {
            string s = "default.xlsx";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            dialog.Title = "Select a Excel file";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                s = dialog.FileName;
                string exportFile = s;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    Telerik.WinControls.Export.GridViewSpreadExport exporter =
                        new Telerik.WinControls.Export.GridViewSpreadExport(RdGridView);
                    exporter.ExportChildRowsGrouped = true;
                    Telerik.WinControls.Export.SpreadExportRenderer renderer =
                        new Telerik.WinControls.Export.SpreadExportRenderer();
                    exporter.ExportHierarchy = true;
                    exporter.RunExport(ms, renderer);

                    using (System.IO.FileStream fileStream =
                        new System.IO.FileStream(exportFile, FileMode.Create, FileAccess.Write))
                    {
                        ms.WriteTo(fileStream);
                    }
                }

                MessageBox.Show("Data Succesfully Export to Excel File.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static DateTime GetDateTime(string date)
        {
            try
            {
                if (string.IsNullOrEmpty(date))
                    return DateTime.Now;
                //DateTime result;
                if (!string.IsNullOrEmpty(date))
                {
                    if (date != "null")
                    {
                        #region Date Formats

                        string[] fmts =
                        {
                            "dd-MMM-yyyy h:m:s tt",
                            "dd/MM/yyyy HH:mm:ss tt",
                            "dd/MM/yyyy H:mm:ss tt",
                            "dd/MM/yyyy h:mm:ss tt",
                            "dd/MM/yyyy hh:mm:ss tt",
                            "dd/MM/yyyyy hh:mm:ss tt",
                            "dddd,MMMM d,yyyy",
                            "MM-dd-yyyy HH:mm:ss",
                            "M/d/yyyy",
                            "dd/MM/yyyy",
                            "M/d/yy",
                            "MM/dd/yy",
                            "MM/dd/yyyy",
                            "yy/MM/dd",
                            "yyyy-MM-dd",
                            "dd-MMM-yy",
                            "M/d/yyyy h:mm tt",
                            "M/d/yyyy hh:mm tt",
                            "M/d/yyyy H:mm",
                            "M/d/yyyy HH:mm",
                            "M/d/yy h:mm tt",
                            "M/d/yy hh:mm tt",
                            "M/d/yy H:mm",
                            "M/d/yy HH:mm",
                            "MM/dd/yy h:mm tt",
                            "MM/dd/yy hh:mm tt",
                            "MM/dd/yy H:mm",
                            "MM/dd/yy HH:mm",
                            "MM/dd/yyyy h:mm tt",
                            "MM/dd/yyyy hh:mm tt",
                            "MM/dd/yyyy H:mm",
                            "MM/dd/yyyy HH:mm",
                            "yy/MM/dd h:mm tt",
                            "yy/MM/dd hh:mm tt",
                            "yy/MM/dd H:mm",
                            "yy/MM/dd HH:mm",
                            "yyyy-MM-dd h:mm tt",
                            "yyyy-MM-dd hh:mm tt",
                            "yyyy-MM-dd H:mm",
                            "yyyy-MM-dd HH:mm",
                            "dd-MMM-yy h:mm tt",
                            "dd-MMM-yy hh:mm tt",
                            "dd-MMM-yy H:mm",
                            "dd-MMM-yy HH:mm",
                            "M/d/yyyy h:mm:ss tt",
                            "M/d/yyyy hh:mm:ss tt",
                            "M/d/yyyy H:mm:ss",
                            "M/d/yyyy HH:mm:ss",
                            "M/d/yy h:mm:ss tt",
                            "M/d/yy hh:mm:ss tt",
                            "M/d/yy H:mm:ss",
                            "M/d/yy HH:mm:ss",
                            "MM/dd/yy h:mm:ss tt",
                            "MM/dd/yy hh:mm:ss tt",
                            "MM/dd/yy H:mm:ss",
                            "MM/dd/yy HH:mm:ss",
                            "MM/dd/yyyy h:mm:ss tt",
                            "MM/dd/yyyy hh:mm:ss tt",
                            "MM/dd/yyyy H:mm:ss",
                            "MM/dd/yyyy HH:mm:ss",
                            "yy/MM/dd h:mm:ss tt",
                            "yy/MM/dd hh:mm:ss tt",
                            "yy/MM/dd H:mm:ss",
                            "yy/MM/dd HH:mm:ss",
                            "yyyy-MM-dd h:mm:ss tt",
                            "yyyy-MM-dd hh:mm:ss tt",
                            "yyyy-MM-dd H:mm:ss",
                            "yyyy-MM-dd HH:mm:ss",
                            "dd-MMM-yy h:mm:ss tt",
                            "dd-MMM-yy hh:mm:ss tt",
                            "dd-MMM-yy H:mm:ss",
                            "dd-MMM-yy HH:mm:ss",
                            "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",
                            "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",
                            "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'",
                            "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'",
                            "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                            "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                            "MMMM d,yyyy",
                            "dddd, d MMMM,yyyy",
                            "d MMMMM,yyyy"
                        };

                        #endregion

                        DateTime dt;
                        if (DateTime.TryParseExact(date, fmts.ToArray(), CultureInfo.CurrentCulture,
                            DateTimeStyles.None, out dt))
                        {
                            return dt; //.ToString(outputFormat);.ToString("dd-MMM-yy hh:mm:ss tt +00:00")
                        }
                        else
                        {

                            throw new NotImplementedException(
                                "No appropriate method find to translate " + date + " into date format.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("DateTime Exception", ex, "HelperClsPlugin");
                frmobj.ShowDialog();
            }

            return DateTime.Now;
        }
        public static DateTime GetDate(string date)
        {

            if (string.IsNullOrEmpty(date))
                return DateTime.Now;

            #region Date Formats

            string[] fmts =
            {

                "dd/MM/yyyy",
                "M/d/yyyy",
                "MM/dd/yyyy",
                "yyyy-MM-dd",
                "dd-MMM-yy",
                "dddd,MMMM d,yyyy",
                "MMMM d,yyyy",
                "dddd, d MMMM,yyyy",
                "d MMMMM,yyyy"
            };

            #endregion

            DateTime dt;
            if (DateTime.TryParseExact(date, fmts.ToArray(), CultureInfo.CurrentCulture, DateTimeStyles.None, out dt))
            {
                return dt;
            }
            else
            {
                return DateTime.Now;
            }
        }

        public static DateTime? GetDateTimeChecking(string date)
        {

            if (string.IsNullOrEmpty(date))
                return null;

            #region Date Formats

            string[] fmts =
            {

                "d/M/yyyy",
                "dd/MM/yyyy", 
            };

            #endregion

            DateTime dt;
            if (DateTime.TryParseExact(date, fmts.ToArray(), CultureInfo.CurrentCulture, DateTimeStyles.None, out dt))
            {
                return dt; //.ToString(outputFormat);.ToString("dd-MMM-yy hh:mm:ss tt +00:00")
            }
            else
            {

                throw new NotImplementedException("No appropriate method find to translate " + date +
                                                  " into date format.");
            }
        }

        public static bool SMSSEnding(string MobileNo, string Message)
        {
            bool SMSStatus = false;
            string checkstring = MobileNo[0].ToString();

            if (checkstring == "0")
            {
                var aStringBuilder = new StringBuilder(MobileNo);
                aStringBuilder.Remove(0, 1);
                aStringBuilder.Insert(0, "92");
                MobileNo = aStringBuilder.ToString();
            }
          
          
            string Username = "dhapeshwar@bizsms.pk";//ConfigurationManager.AppSettings["Sms.Username"];
            string Password = "dh2p3sh1w";//ConfigurationManager.AppSettings["Sms.Password"];
            string SenderNum = MobileNo;//ConfigurationManager.AppSettings["Sms.Sendernum"];
            string Masking = "DHAPESHAWAR";

            try
            {
                using (var client = new WebClient())
                {
                    Uri SmsAPILink = new Uri(@"http://api.bizsms.pk/api-send-branded-sms.aspx?username=" + Username +
                                   "&pass=" + Password + "&" + "text=" + Message + "&" +
                                   "masking=" + Masking +
                                   "&destinationnum=" + MobileNo + "&language=English");
                    string jasonData = client.DownloadString(SmsAPILink);

                    if (jasonData.Contains("SMS Sent Successfully") == true)
                    {
                        jasonData = "SMS Sent Successfully";
                        SMSStatus= true;
                       

                    }
                    if (jasonData.Contains("Invalid Number") == true)
                    {
                        jasonData = "Invalid Number";
                        SMSStatus = false;

                    }
                    if (jasonData.Contains("Invalid Paramenters") == true)
                    {
                        jasonData = "Invalid Paramenters";
                        SMSStatus = false;
                    }
                    if (jasonData.Contains("Invalid Username or Passwor") == true)
                    {
                        jasonData = "Invalid Username or Passwords";
                        SMSStatus = false;
                    }
                    if (jasonData.Contains("Invalid Short Code") == true)
                    {
                        jasonData = "Invalid Short Code";
                        SMSStatus = false;
                    }
                    if (jasonData.Contains("Your Package Has Been Expire.") == true)
                    {
                        jasonData = "Your Package Has Been Expire.";
                        SMSStatus = false;
                    }
                    if (jasonData.Contains("Insufficent Balance") == true)
                    {
                        jasonData = "Insufficent Balance";
                        SMSStatus = false;
                    }
                    if (jasonData.Contains("Failed To Send SMS") == true)
                    {
                        jasonData = "Failed To Send SMS";
                        SMSStatus = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return SMSStatus;
        }


        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }


        /// <summary>
        /// Group Sum add to Bottom of Each Grid
        /// </summary>
        /// <param name="RGV"></param>
        public static void Summary_Column_Template_Wise_Search(RadGridView RGV)
        {
            GridViewSummaryRowItem summaryRowItem = new GridViewSummaryRowItem();
            foreach (GridViewDataColumn item in RGV.Columns)
            {
                GridViewSummaryItem summaryItem = new GridViewSummaryItem();
                summaryItem.Name = item.Name;
                summaryItem.Aggregate = GridAggregateFunction.Sum;
                summaryItem.FormatString = "{0:#,###0.00;(#,###0.00);0}";
                summaryRowItem.Add(summaryItem);
            }
            #region Summary Columns
            RGV.SummaryRowsBottom.Add(summaryRowItem);
            RGV.MasterView.SummaryRows[0].PinPosition = PinnedRowPosition.Bottom;
            #endregion

        }


        public static void EmailTesting()
        {
            string Subject = "Testing Email";
            string EmailCC = "";
            string exe = Process.GetCurrentProcess().MainModule.FileName;
            string path = Path.GetDirectoryName(exe);
            string _body = File.ReadAllText(path + "\\index.html");
            _body = _body.Replace("#Date", DateTime.Now.ToString())
                         .Replace("#AckNo", "Test12")
                         .Replace("#Name","Testing")
                         .Replace("#MobileNo", "Testing")
                         .Replace("#Subject", Subject)
                         .Replace("#FileNo", "Test123")
                         .Replace("#PlotNo", "Test123")
                         .Replace("#DepositType","test123")
                         .Replace("#ChalanNo", "Test123")
                         .Replace("#BankName", "Test123")
                         .Replace("#Amount", "Test123")
                         .Replace("#AmnInWord", "Test123")
                         .Replace("#ReceivedDate", "Test123");

            string _bcc ="";
            string _ReplyTo = "kngkhan72@gmail.com";

            bool isDelivered = PostEmail(
                //"abduljalilmatora@gmail.com"
                "kngkhan72@gmail.com"
                , EmailCC, _body, _bcc, _ReplyTo, Subject);
        }

        public static bool PostEmail(string EmailTo, string EmailCC, string _body, string _bcc, string _ReplyTo, string Subject)
        {
            if (string.IsNullOrEmpty(EmailTo) || EmailTo == "NA")
                return false;

            EmailTo = EmailTo.ToLower();
            string _smtpServer = "webmail.dhapeshawar.org";
            string _userName = "acknowledgement@dhapeshawar.org";
            string _displayName = "DHA Peshawar";
            string _password = "Samsung@831";
            string _Port = "25";//465";

            // string _body = File.ReadAllText("index.html");
            MailMessage msg;
            try
            {
                msg = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                //sender email address
                msg.From = new MailAddress(_userName, _displayName);
                if (!string.IsNullOrEmpty(_ReplyTo))
                    msg.ReplyToList.Add(_ReplyTo);

                //Receiver email address
                msg.To.Add(EmailTo);
                msg.AlternateViews.Add(getEmbeddedImage("logo.ico", _body));
                if (!string.IsNullOrEmpty(_bcc))
                    msg.Bcc.Add(_bcc);
                if (!string.IsNullOrEmpty(EmailCC))
                    msg.CC.Add(EmailCC);
                msg.Subject = Subject;
                msg.IsBodyHtml = true;
                var smtpClient = new SmtpClient();
                smtpClient.EnableSsl = false;//true;// bool.Parse(true);
                smtpClient.Host = _smtpServer;
                smtpClient.Port = string.IsNullOrEmpty(_Port) ? 25 : int.Parse(_Port);

                var networkCred = new System.Net.NetworkCredential
                {
                    UserName = _userName,
                    Password = _password
                };
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCred;
                try
               {
                    smtpClient.Send(msg);
                    return true;
                    //Thread T1 = new Thread(delegate ()
                    //{
                    //    {
                    //        smtpClient.Send(msg);
                    //    }
                    //});

                    //T1.Start();

                }
                catch (SmtpFailedRecipientException ex)
                {
                    MessageBox.Show(ex.Message);
                    SmtpStatusCode statusCode = ex.StatusCode;
                    if (statusCode == SmtpStatusCode.MailboxBusy ||
                    statusCode == SmtpStatusCode.MailboxUnavailable ||
                    statusCode == SmtpStatusCode.TransactionFailed)
                    {
                        // wait 5 seconds, try a second time
                        System.Threading.Thread.Sleep(5000);
                        smtpClient.Send(msg);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }


        private static AlternateView getEmbeddedImage(String filePath, string htmlBody)
        {
            string exe = Process.GetCurrentProcess().MainModule.FileName;
            string path = Path.GetDirectoryName(exe);

            LinkedResource res = new LinkedResource(path + "\\" + filePath);
            res.ContentId = Guid.NewGuid().ToString();
            string source = @"<img src='cid:" + res.ContentId + @"' style=' float: left; width: 100px; height: 100px;'/>";
            htmlBody = htmlBody.Replace("#logo", source);
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }


        public static DataTable RemoveBlankRows(DataTable dt)
        {
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i][1] == DBNull.Value)
                {
                    dt.Rows[i].Delete();
                }
            }
            dt.AcceptChanges();
            return dt;
        }

        public static DataTable DataTableConvertColumnType(this DataTable dt, string columnName, Type newType)
        {
            using (DataColumn dc = new DataColumn(columnName + "_new", newType))
            {
                // Add the new column which has the new type, and move it to the ordinal of the old column
                int ordinal = dt.Columns[columnName].Ordinal;
                dt.Columns.Add(dc);
                dc.SetOrdinal(ordinal);

                // Get and convert the values of the old column, and insert them into the new
                foreach (DataRow dr in dt.Rows)
                {
                    dr[dc.ColumnName] = Convert.ChangeType(dr[columnName], newType);
                }
                // Remove the old column
                dt.Columns.Remove(columnName);

                // Give the new column the old column's name
                dc.ColumnName = columnName;
            }
            dt.AcceptChanges();
            return dt;
        }
    }


    public class DataTable_column
    {
        public string ColmnName { get; set; }
        public Type type { get; set; }
    }

    public class SMSSession
    {
        public string sessionid { get; set; }
        public string status { get; set; }
    }
}

