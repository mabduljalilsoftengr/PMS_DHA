using PeshawarDHASW.Application_Layer.Acknowledgement;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsAcknowledgment;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
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
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.AcknowledgmentSearch
{
    public partial class AcknowledgementView : Telerik.WinControls.UI.RadForm
    {
        public AcknowledgementView()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = {
                                            new SqlParameter("@Task","Search"),
                                            new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                                            new SqlParameter("@DDNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtDDno.Text))
                                       };
                DataSet ds = new DataSet();
                ds = cls_Fin_Acknowledgement.Fin_AcknowledgementDataRead(param);
                DGV_Acknowledgement.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DGV_Acknowledgement_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
         {
            try
            {

                if (e.Column.Name == "btnReportView")
                {
                    int AckID = int.Parse(DGV_Acknowledgement.ChildRows[DGV_Acknowledgement.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    Application_Layer.Installment.AcknowledgmentSearch.AckFinReportViewer rd = new AckFinReportViewer(AckID.ToString(), true, isDuplicate.Checked == true ? true : false);
                    rd.ShowDialog();
                }
                else if (e.Column.Name == "btnAudit")
                {
                    int AckID = int.Parse(DGV_Acknowledgement.ChildRows[DGV_Acknowledgement.CurrentCell.RowIndex].Cells["FinAckID"].Value.ToString());
                    Application_Layer.Installment.AcknowledgmentSearch.frmAcknowledgmentAudit rd = new frmAcknowledgmentAudit(AckID);
                    rd.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDGV_CellClick.", ex.InnerException, "frmMembershipSearch");
                //frmobj.ShowDialog();
            }
        }

        private void AcknowledgementView_Load(object sender, EventArgs e)
        {
            if (clsUser.Role == "1" || clsUser.Role == "6")
            {
                isDuplicate.Visible = true;
                btnUploadQsr.Visible = true;
            }
            else
            {
                btnUploadQsr.Visible = false;
                isDuplicate.Visible = false;
            }
        }

        private void btnUploadQsr_Click(object sender, EventArgs e)
        {
            frmAckQSR frm = new frmAckQSR();
            frm.ShowDialog();
            #region [OLD CODE]
            //var datafound = SQLHelper.ExecuteScalar(SQLHelper.createConnection(), CommandType.Text, "Select isnull(Max(ackQsrID),0)+1 as ackQsrID from dbo.tbl_AcknowledgmentQSR");
            //int a = (int)datafound;

            //MessageBox.Show("Next S.No will be start from " + a + "\n\nPlease Make sure that\n1. Data should be in this format\n\nS.No. | CN Number | Booking Date | Pieces | Weight | Consignee | Dest Zone | Dest Branch | Reason | Delivery Date | Delivery Time | Received By\n\n2. Record data should be in Sheet2.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "Excel files|*.xls;*.xlsx;";
            //openFileDialog1.FilterIndex = 2;
            //openFileDialog1.RestoreDirectory = true;
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    string excelfilepath = openFileDialog1.FileName;
            //    string ssqltable = "tbl_AcknowledgmentQSR";
            //    try
            //    {
            //        //create our connection strings
            //        string sexcelconnectionstring = "";

            //        if (Path.GetExtension(excelfilepath).ToLower().Trim() == ".xls" && Environment.Is64BitOperatingSystem == false)
            //            sexcelconnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelfilepath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
            //        else
            //            sexcelconnectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelfilepath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";

            //        DataTable dt = new DataTable();
            //        string ssqlconnectionstring = clsMostUseVars.Connectionstring;
            //        OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            //        oledbconn.Open();

            //        //dt = oledbconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            //        //String[] excelSheets = new String[dt.Rows.Count];
            //        //int i = 0;

            //        //// Add the sheet name to the string array.
            //        //foreach (DataRow row in dt.Rows)
            //        //{
            //        //    excelSheets[i] = row["TABLE_NAME"].ToString();
            //        //    i++;
            //        //}

            //        //S.No. CN Number   Booking Date    pieces Weight  Consignee Dest Zone Dest Branch Reason  Delivery Date   Delivery Time   Received By
            //        //S No	CN Number	Booking Date	pieces	Weight	Service	Consignee	Org Zone	Dest Zone	Dest Branch	Reason	Delivery Date	Delivery Time	Received By

            //        // for (int i = 1; i < 11; i++)
            //        {
            //            string myexceldataquery = "select * from [sheet" + 2 + "$]";
            //            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);

            //            OleDbDataReader dr = oledbcmd.ExecuteReader();
            //            SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring, SqlBulkCopyOptions.KeepNulls);
            //            bulkcopy.DestinationTableName = ssqltable;
            //            bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(1, "CNNumber"));
            //            bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(2, "BookingDate"));
            //            bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(3, "NoOfPieces"));
            //            bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(4, "Weight"));
            //            //bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(5, "Service"));
            //            bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(5, "Consignee"));
            //            //bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(7, "OrgZone"));
            //            bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(6, "DestZone"));
            //            bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(7, "DestBranch"));
            //            bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(8, "Reason"));
            //            bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(9, "DeliveryDate"));
            //            bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(10, "DeliveryTime"));
            //            bulkcopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(11, "ReceivedBy"));
            //           // while (dr.Read())
            //            {

            //              //  dt.Load(dr);

            //                //DataTable dtCloned = dt.Clone();
            //                //dtCloned.Columns[2].DataType = typeof(DateTime);
            //                ////dtCloned.Columns[2].MaxLength = 20;
            //                //dtCloned.Columns[9].DataType = typeof(DateTime);
            //                ////dtCloned.Columns[9].MaxLength = 20;
            //                //foreach (DataRow row in dt.Rows)
            //                //{
            //                //    dtCloned.ImportRow(row);
            //                //}
            //                //dtCloned.Load(dr);
            //                //foreach (DataRow row in dt.Rows)
            //                //{
            //                //    foreach (DataColumn col in dt.Columns)
            //                //    {
            //                //        if (row.IsNull(col) && col.ColumnName == "F10")
            //                //            row.SetField(col, string.Empty);
            //                //    }
            //                //}
            //                bulkcopy.WriteToServer(dr);
            //            }
            //            oledbconn.Close();
            //            MessageBox.Show("File upload successfuly..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            //for (int i = 0; i < dt.Rows.Count; i++)
            //            //{
            //            //    //string conn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //            //    SqlConnection con = new SqlConnection(ssqlconnectionstring);
            //            //    string query = @"INSERT INTO [dbo].[tbl_AcknowledgmentQSR]
            //            //([CNNumber]
            //            //,[BookingDate]
            //            //,[NoOfPieces]
            //            //,[Weight]
            //            //,[Service]
            //            //,[Consignee]
            //            //,[OrgZone]
            //            //,[DestZone]
            //            //,[DestBranch]
            //            //,[Reason]
            //            //,[DeliveryDate]
            //            //,[DeliveryTime]
            //            //,[ReceivedBy]) Values('" +
            //            //    dt.Rows[i][1].ToString() + "','" +
            //            //    dt.Rows[i][2].ToString() + "','" +
            //            //    dt.Rows[i][3].ToString() + "','" +
            //            //    dt.Rows[i][4].ToString() + "','" +
            //            //    dt.Rows[i][5].ToString() + "','" +
            //            //    dt.Rows[i][6].ToString() + "','" +
            //            //    dt.Rows[i][7].ToString() + "','" +
            //            //    dt.Rows[i][8].ToString() + "','" +
            //            //    dt.Rows[i][9].ToString() + "','" +
            //            //    dt.Rows[i][10].ToString() + "','" +
            //            //    dt.Rows[i][11].ToString() + "','" +
            //            //    dt.Rows[i][12].ToString() + "','" +
            //            //    dt.Rows[i][13].ToString() + "')";
            //            //    con.Open();
            //            //    SqlCommand cmd = new SqlCommand(query, con);
            //            //    cmd.ExecuteNonQuery();
            //            //    con.Close();
            //            //}
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //handle exception
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    } 
            #endregion
            //}
        }
    }
}
