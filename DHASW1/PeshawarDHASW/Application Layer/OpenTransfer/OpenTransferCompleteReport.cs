using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    public partial class OpenTransferCompleteReport : Telerik.WinControls.UI.RadForm
    {
        public OpenTransferCompleteReport()
        {
            InitializeComponent();

        }
        private void DataLoading()
        {
            try
            {
                SqlParameter[] parameter = { new SqlParameter("@Task", "GetRecordTransferBranchComplete")         };
                DataSet DataRefund = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_PreTransferRequest", parameter);
                grd_PreTransferRequestInformation.DataSource = DataRefund.Tables[0].DefaultView;


                foreach (GridViewDataColumn column in grd_PreTransferRequestInformation.Columns)
                {
                    column.BestFit();
                }
            }
            catch (Exception ex)
            {

            }


        }

        private void OpenTransferCompleteReport_Load(object sender, EventArgs e)
        {
            DataLoading();
        }

        private void grd_PreTransferRequestInformation_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Attachment")
            {
                string PerTransferID = e.Row.Cells["ID"].Value.ToString();
                string NDCNo = e.Row.Cells["NDCNo"].Value.ToString();
                string UploadStatus = e.Row.Cells["SellerReport"].Value.ToString();
                if (UploadStatus == "Pending")
                {
                    MessageBox.Show("Seller Report is Incomplete. Please Upload Seller Document.");
                }
                else
                {
                    SqlParameter[] parameter = {
                    new SqlParameter("@Task", "SelectReportbyID"),
                    new SqlParameter("@PreTransferID",PerTransferID),
                    new SqlParameter("@NDCNo",NDCNo),
                     };
                    DataSet DataDoc = Helper.SQLHelper.ExecuteDataset(clsMostUseVars.VerifiedImageConnectionstring,
                        CommandType.StoredProcedure, "OpenTransferSellerDoc",
                        parameter);
                    if (DataDoc.Tables.Count > 0)
                    {
                        if (DataDoc.Tables[0].Rows.Count > 0)
                        {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            string FileName = DataDoc.Tables[0].Rows[0]["Description"].ToString() + ".pdf";

                            // Set the default file name and extension
                            //saveFileDialog.FileName = FileName;
                           // saveFileDialog.DefaultExt = "pdf";

                            // Set the initial directory (optional)
                            saveFileDialog.InitialDirectory = @"D:\";
                           
                            // Set the file filters
                            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                            saveFileDialog.FilterIndex = 1; // Default filter index

                            // Display the dialog and check if the user clicked OK
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                // Get the selected file name and display it in a MessageBox
                                string fileName = saveFileDialog.FileName;
                                ConvertByteArrayToPdf((byte[])DataDoc.Tables[0].Rows[0]["FileDetail"], fileName);

                                frmPDFViewer viewer = new frmPDFViewer(fileName);
                                viewer.ShowDialog();
                               // MessageBox.Show($"File saved to: {fileName}", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Here, you can perform additional actions, such as saving data to the selected file
                            }
                        }
                    }
                } 
                
            }
        }
        static void ConvertByteArrayToPdf(byte[] pdfBytes, string outputFilePath)
        {
            // Write the byte array to a PDF file
            File.WriteAllBytes(outputFilePath, pdfBytes);
        }
    }
}
