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

namespace PeshawarDHASW.Application_Layer.FileMap.SvcBenefitFiles
{
    public partial class frmFileAttachments : Telerik.WinControls.UI.RadForm
    {
        public frmFileAttachments()
        {
            InitializeComponent();
        }
        public string FileMapKey { get; set; }
        public string FileNo { get; set; }
        public frmFileAttachments(string _FileMapKey,string _FileNo)
        {
            InitializeComponent();
            FileMapKey = _FileMapKey;
            FileNo = _FileNo;
            lblFileNo.Text = _FileNo;
        }

        private void ImageLoading()
        {
            SqlParameter[] param ={
                                new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                                new SqlParameter("@FileMapKey",FileMapKey)
                        };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_FileMapImages", param);
            if (ds.Tables.Count > 0)
            {
                ImageSource.DataSource = ds.Tables[0].DefaultView;
                ImageSource.Refresh();
            }
        }
        private void frmFileAttachments_Load(object sender, EventArgs e)
        {
            ImageLoading();
        }

        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {
            try
            {
            
                string FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + lblFileNo.Text;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {

                    string[] files = openFileDialog1.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            MemoryStream ms = new MemoryStream();
                            Image con = Image.FromFile(pngFile);
                            con.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            Byte[] ImageArray = ms.ToArray();


                            SqlParameter[] parameters ={
                                        new SqlParameter("@Task", "Insert"),
                                        new SqlParameter("@FileMapKey", FileMapKey),
                                        new SqlParameter("@ImageFile", ImageArray),
                                        new SqlParameter("@ImageName", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff")+"-FileNo"+lblFileNo.Text),
                                        new SqlParameter("@Description", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff")+"-FileNo"+lblFileNo.Text),
                                        new SqlParameter("@user_ID", clsUser.ID),
                                         };
                                int result = Helper.SQLHelper.ExecuteNonQuery(
                                                        clsMostUseVars.VerifiedImageConnectionstring,
                                                        CommandType.StoredProcedure,
                                                        "usp_tbl_FileMapImages",
                                                        parameters
                                                        );
                            if (result>0)
                            {
                                MessageBox.Show("Attachement is Saved");
                                ImageLoading();
                            }
                            else
                            {
                                MessageBox.Show("Attachement is Not Uploaded");
                            }

                            
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
            }
        }

        private void ImageSource_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                var imgdata = (byte[])e.Row.Cells["ImageFile"].Value;
                MemoryStream ms = new MemoryStream(imgdata);
                ms.Position = 0;
                Image img = Image.FromStream(ms);
                Image_View.Image = img;
            }
            catch (Exception ex)
            {
               
            }
          
        }
    }
}
