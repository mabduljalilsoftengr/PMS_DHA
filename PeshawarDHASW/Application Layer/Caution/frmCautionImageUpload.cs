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

namespace PeshawarDHASW.Application_Layer.Caution
{
    public partial class frmCautionImageUpload : Telerik.WinControls.UI.RadForm
    {
        private int ctnID { get; set; }
        public frmCautionImageUpload()
        {
            InitializeComponent();
        }
        public frmCautionImageUpload(int cautionID)
        {
            InitializeComponent();
            ctnID = cautionID;
        }

        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();
        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {
            try
            {
                int imageCount = ImageContainer.Count + 1;
                clsMemberImage obj = new clsMemberImage();
                obj.ImageName = txtFrontBack.Text+ "_" + DateTime.Now.ToString("yyyyMMdd")  ;

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
                            obj.MemberImage = Image.FromFile(pngFile);
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }
                    ImageContainer.Add(obj);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = null;
                    ImageSource.DataSource = ImageContainer;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = 0;
            foreach (clsMemberImage row in ImageContainer)
            {
                MemoryStream ms = new MemoryStream();
                row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Byte[] Image = ms.ToArray();
                SqlParameter[] parameters =
                {
                                new SqlParameter("@Task", "Insert_Image"),
                                new SqlParameter("@ImageFile", Image),
                                new SqlParameter("@ImageName", row.ImageName),
                                new SqlParameter("@ctnID",ctnID),
                                new SqlParameter("@user_ID", clsUser.ID)
                 };
                 result = SQLHelper.ExecuteNonQuery(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_Caution", parameters);

            }
            if(result > 0)
            {
                MessageBox.Show("Successfull.");
                this.Close();
            }
        }

        private void ImageSource_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnRemove")
            {
                try
                {
                    ImageContainer.RemoveAt(e.RowIndex);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = null;
                    ImageSource.DataSource = ImageContainer;
                    if (ImageContainer.Count == 0)
                        ImageSource.DataSource = null;
                }
                catch (Exception)
                {
                    ImageSource.DataSource = null;
                }
            }
        }
    }
}
