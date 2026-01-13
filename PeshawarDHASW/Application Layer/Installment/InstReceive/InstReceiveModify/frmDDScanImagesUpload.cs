using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify
{
    public partial class frmDDScanImagesUpload : Telerik.WinControls.UI.RadForm
    {
        public frmDDScanImagesUpload()
        {
            InitializeComponent();
        }
        public long Rece_ID { get; set; }
        public frmDDScanImagesUpload(long ReceID)
        {
            InitializeComponent();
            Rece_ID = ReceID;
        }

        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();
        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {
            try
            {
                int imageCount = ImageContainer.Count() + 1;
                clsMemberImage obj = new clsMemberImage();
                obj.ImageName = DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                obj.Description = Rece_ID+" Attachment with Image.";

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";
                openFileDialog1.Multiselect = true;

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
                    ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                   
                }
            }
            catch (Exception ex)
            {
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
                    ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                    if (ImageContainer.Count == 0)
                        ImageSource.DataSource = null;
                }
                catch (Exception)
                {
                    ImageSource.DataSource = null;
                }
            }
            else
            {
                try
                {
                    //var data = (Byte[])(e.Row.Cells["MemberImage"].Value);
                    //var stream = new MemoryStream(data);
                    //ImageBox.Image = Image.FromStream(stream);
                    Image image = (Image)e.Row.Cells["MemberImage"].Value;
                    ImageBox.Image = image;
                    //  ImageBox.Image = Image.FromFile(e.Row.Cells["MemberImage"].Value.ToString());
                }
                catch (Exception)
                {
                  //  MessageBox.Show("Erorr in Attachment Viewing.");
                }
              
            }
        }

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            //Uploading Images
            try
            {
                if (ImageContainer.Count < 1)
                {
                    MessageBox.Show("Their is no Attachment Present in the list.");
                }
                else
                {
                    foreach (clsMemberImage row in ImageContainer)
                    {
                        MemoryStream ms = new MemoryStream();
                        row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                        Byte[] Image = ms.ToArray();
                        SqlParameter[] parameters =
                        {
                                new SqlParameter("@Task", "Insert"),
                                new SqlParameter("@ReceID", Rece_ID),
                                new SqlParameter("@ImageFile", Image),
                                new SqlParameter("@ImageName", row.ImageName),
                                new SqlParameter("@Description", row.Description),
                                new SqlParameter("@user_ID", clsUser.ID),
                            };
                        int result = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "USP_tbl_ReceDDImages", parameters);

                    }
                    ImageContainer.Clear();
                    ImageSource.DataSource = null;
                    this.Close();
                }
            }
            catch (Exception rc)
            {
            }
        }

        private void frmDDScanImagesUpload_Load(object sender, EventArgs e)
        {

        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void radGroupBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
