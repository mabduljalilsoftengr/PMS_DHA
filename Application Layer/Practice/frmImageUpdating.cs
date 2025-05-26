using PeshawarDHASW.Data_Layer.Installment;
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

namespace PeshawarDHASW.Application_Layer.Practice
{
    public partial class frmImageUpdating : Telerik.WinControls.UI.RadForm
    {
        public frmImageUpdating()
        {
            InitializeComponent();
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            try
            {
                //int imageCount = ImageContainer.Count() + 1;
                //clsMemberImage obj = new clsMemberImage();
                //obj.ImageName = DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                //obj.Description = "Attachment with DD Transfer.";

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    pictureBox1.ImageLocation = openFileDialog1.FileName;

                    //string[] files = openFileDialog1.FileNames;
                    //foreach (var pngFile in files)
                    //{

                    //    //try
                    //    //{
                    //    //    obj.MemberImage = Image.FromFile(pngFile);
                    //    //}
                    //    //catch
                    //    //{
                    //    //    Console.WriteLine("This is not an image file");
                    //    //}
                    //}
                    //ImageContainer.Add(obj);
                    //ImageSource.TableElement.RowHeight = 50;
                    //ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    //ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnUploadtoDB_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Byte[] Image = ms.ToArray();
//            string SqlQuery = @"update VerifiedDbMembershipImages.dbo.tbl_FileCancelationImages
//set ImageFile ='"+Image+"'
//where ID = 13";
            SqlParameter[] parameters =
            {
                                new SqlParameter("@Task", "ImageUploadSingleUpdate"),
                                new SqlParameter("@ID", 13),
                                new SqlParameter("@ImageFile", Image),
                                //new SqlParameter("@ImageName", row.ImageName),
                                //new SqlParameter("@Description", row.Description),
                                //new SqlParameter("@user_ID", clsUser.ID),
                            };
            int result = SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_tbl_FileCancelationImages",
                                                    parameters
                                                    );
        }
    }
}
