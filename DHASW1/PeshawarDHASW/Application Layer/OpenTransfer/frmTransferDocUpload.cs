using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
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

namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    public partial class frmTransferDocUpload : Telerik.WinControls.UI.RadForm
    {
        public frmTransferDocUpload()
        {
            InitializeComponent();
        }
        public string FileMapID { get; set; }
        public string NDCNo { get; set; }
        public string FileNo { get; set; }
        public string PreTransferID { get; set; }
        public frmTransferDocUpload(string FileMapID_, string NDCNo_, string FileNo_,string PreTransferID_)
        {
            FileMapID = FileMapID_;
            NDCNo = NDCNo_;
            FileNo = FileNo_;
            PreTransferID = PreTransferID_;
            InitializeComponent();
        }

        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter =
                @"PDF (*.PDF;)|*.PDF;| All files (.)|*.*";
            openFileDialog1.Title = "Select PDF Report";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                lblFilePath.Text = openFileDialog1.FileName;
            }
        }

        static byte[] ConvertPdfToVarBinary(string pdfFilePath)
        {
            try
            {
                // Read the contents of the PDF file into a byte array
                byte[] pdfBytes = File.ReadAllBytes(pdfFilePath);

                return pdfBytes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        private void btnUploadReporttoDB_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] pdfBytes = ConvertPdfToVarBinary(lblFilePath.Text);
                SqlParameter[] param = {
                    new SqlParameter("@Task","NewDocumentUpload"),
                    new SqlParameter("@PreTransferID",PreTransferID),
                    new SqlParameter("@FileID",FileMapID),
                    new SqlParameter("@NDCNo", NDCNo),
                    new SqlParameter("@FileNo",FileNo),
                    new SqlParameter("@Description",DateTime.Now.ToString("yyyyMMdd")+"-"+NDCNo+"-"+FileNo.Replace("/","")),
                    new SqlParameter("@FileDetail",pdfBytes),
                    new SqlParameter("@userID",clsUser.ID),
                };
                int result = SQLHelper.ExecuteNonQuery(clsMostUseVars.VerifiedImageConnectionstring
                    , CommandType.StoredProcedure,"OpenTransferSellerDoc",param);
                if (result>0)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
