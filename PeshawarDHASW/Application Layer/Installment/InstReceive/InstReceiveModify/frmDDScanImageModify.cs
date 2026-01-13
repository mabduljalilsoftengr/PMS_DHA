using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify
{
    public partial class frmDDScanImageModify : Telerik.WinControls.UI.RadForm
    {
        public string Rece_ID { get; set; }
        public frmDDScanImageModify(string ReceID)
        {
            Rece_ID = ReceID;
            InitializeComponent();
        }
        PictureBox objPrint = new PictureBox();
        private void ImageSource_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnRemove")
            {
                string ImageID = e.Row.Cells["ID"].Value.ToString();
                if (MessageBox.Show("Are you sure to delete this image.","Attention",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
                {
                    SqlParameter[] param = {
                    new SqlParameter("@Task","DeleteDDScanDocument"),
                    new SqlParameter("@ID",ImageID)
                    };
                    int ds = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "USP_tbl_ReceDDImages", param);
                    if (ds>0)
                    {
                        DDScanLoading();
                    }
                }
            }
            //Image Reading
            else
            {
                try
                {
                    // long ID = int.Parse(e.Row.Cells["ID"].Value.ToString()); // ReceID

                    byte[] imageData = (byte[])e.Row.Cells["MemberImage"].Value;

                    //Initialize image variable
                    Image newImage;
                    //Read image data into a memory stream
                    using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                    {
                        ms.Write(imageData, 0, imageData.Length);
                        //Set image variable value using memory stream.
                        newImage = Image.FromStream(ms, true);
                    }

                    // set picture
                    objPrint.Image = newImage;
                    ImageBox.Image = newImage;
                }
                catch (Exception)
                {
                }
              
            }
        }
        private void DDScanLoading()
        {
            SqlParameter[] param = {
                    new SqlParameter("@Task","Select"),
                    new SqlParameter("@ReceID",Rece_ID)
                    };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "USP_tbl_ReceDDImages", param);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ImageSource.DataSource = ds.Tables[0].DefaultView;
                    //Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                    //obj.Show();
                }
                else
                {
                    MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
            }
            else
            {
                MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();
            }
        }
        private void frmDDScanImageModify_Load(object sender, EventArgs e)
        {
            SqlParameter[] param =
                              {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@ReceID",Rece_ID)
                    };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "USP_tbl_ReceDDImages", param);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ImageSource.DataSource = ds.Tables[0].DefaultView;
                    //Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                    //obj.Show();
                }
                else
                {
                    MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // this.Close();
                }
            }
            else
            {
                MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // this.Close();
            }
        }

        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {
            try
            {
                //int imageCount = ImageContainer.Count() + 1;
               // clsMemberImage obj = new clsMemberImage();
                //obj.ImageName = DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
               // obj.Description = Rece_ID + " Attachment with Image.";

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    byte[] Image = File.ReadAllBytes(openFileDialog1.FileName);
                    //Image ImageFile;
                    //MemoryStream ms = new MemoryStream();
                    // ImageFile.Save(ms, System.Drawing.Imaging.ImageFormat.Gif)
                    //Byte[] Image = ms.ToArray();
                    SqlParameter[] parameters ={
                                new SqlParameter("@Task", "Insert"),
                                new SqlParameter("@ReceID", Rece_ID),
                                new SqlParameter("@ImageFile", Image),
                                new SqlParameter("@ImageName",DateTime.Now.ToString("yyyyMMddhhmmss")+clsUser.ID),
                                new SqlParameter("@Description", Rece_ID+" Attachment with Image."),
                                new SqlParameter("@user_ID", clsUser.ID),
                            };
                    int result = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "USP_tbl_ReceDDImages", parameters);
                    if (result>0)
                    {
                        DDScanLoading();
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnPrintImage_Click(object sender, EventArgs e)
        {
            //Show print dialog
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;    
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Print image
            Bitmap bm = new Bitmap(objPrint.Width, objPrint.Height);
            objPrint.DrawToBitmap(bm, new Rectangle(0, 0, objPrint.Width, objPrint.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }
    }
}
