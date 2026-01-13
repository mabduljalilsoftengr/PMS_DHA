using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Data_Layer.NDC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmTransferLetterImageUpload : Telerik.WinControls.UI.RadForm
    {
        public string SellerInfo { get; set; }
        public string BuyerInfo { get; set; }
        public string TransferInfo { get; set; }
        public string TFRDate { get; set; }
        public string FileNo { get; set; }
        public int FileKey { get; set; }
        public int TFRNo { get; set; }
        public int NDCNo { get; set; }
        public frmTransferLetterImageUpload()
        {
            InitializeComponent();
        }
        public frmTransferLetterImageUpload(int get_TFRNo,string get_fileNo, int get_NdcNo)
        {
            FileNo = get_fileNo;
            TFRNo = get_TFRNo;
            NDCNo = get_NdcNo;

            InitializeComponent();
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG,*.PNG)|*.BMP;*.JPG;*.PNG| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {

                    string[] files = openFileDialog1.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            pbTFR_Image.Image = Image.FromFile(pngFile);
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBrows_Click.", ex, "frmTransferLetterImageUpload");
                frmobj.ShowDialog();
            }
           
        }

        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                // Image to Byte
                MemoryStream ms = new MemoryStream();
                pbTFR_Image.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] Image = ms.ToArray();
                //-------------------------------------
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@Image",Image),
                new SqlParameter("@TFRInformation",TransferInfo),
                new SqlParameter("@Description","Transfer_Letter_Image."),
                new SqlParameter("@Remarks",txtRemarks.Text),
                new SqlParameter("@CurrentDate",TFRDate),
                new SqlParameter("@Status","Complete"),
                new SqlParameter("@FileKey",FileKey),
                new SqlParameter("@TransferNo",TFRNo)
                };
                int rslt = 0;
                rslt = cls_dl_TFRHistory.TFRHistory_NonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Image Inserted Successfully.");
                    this.Close();
                    #region Update the Status of Transfer Tracking to "TFRLetterImageUplloadCompleted" 
                    SqlParameter[] prmtr =
                    {
                    new SqlParameter("@Task","Update_TransferTracking_Status"),
                    new SqlParameter("@TRFTrackingStatus","TFRLetterImageUplloadCompleted"),
                    new SqlParameter("@TransferNo",TFRNo)
                };
                    int rst = cls_dl_TFRVerification.TFRVerification_NonQuery(prmtr);
                    if (rst > 0)
                    {
                        MessageBox.Show("Successfull.");
                        //frmTransferLetterImageUpload_Basket frm = new frmTransferLetterImageUpload_Basket();
                        //frm.ShowDialog();
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btn_SaveImage_Click.", ex, "frmTransferLetterImageUpload");
                frmobj.ShowDialog();
            }
          

        }

        private void txtTransferNo_Leave(object sender, EventArgs e)
        {
            
        }

        private void frmTransferLetterImageUpload_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            Get_TransferTracking_Info();
        }

        private void Get_TransferTracking_Info()
        {
            try
            {
                #region Get TransferTracking Info
                SqlParameter[] prmt =
                {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@TransferNo",TFRNo)
            };
                DataSet dst = cls_dl_TransferTracking.TransferTracking_Reader(prmt);
                SellerInfo = dst.Tables[0].Rows[0]["SellerMS_String"].ToString();
                BuyerInfo = dst.Tables[0].Rows[0]["BuyerMS_String"].ToString();
                TransferInfo = "Buyers:" + BuyerInfo + "  " + "Sellers:" + SellerInfo;
                TFRDate = dst.Tables[0].Rows[0]["TransferDate"].ToString();
                FileNo = dst.Tables[0].Rows[0]["FileNo"].ToString();
                FileKey = int.Parse(dst.Tables[1].Rows[0]["FileMapKey"].ToString());
                #endregion
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Get_TransferTracking_Info.", ex, "frmTransferLetterImageUpload");
                frmobj.ShowDialog();
            }
           
        }
    }
}
