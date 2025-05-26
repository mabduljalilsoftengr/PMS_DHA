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
using System.Linq;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.IN_OUT_Mail
{
    public partial class IncomingImageModification : Telerik.WinControls.UI.RadForm
    {
        public IncomingImageModification()
        {
            InitializeComponent();
        }
        public IncomingImageModification(string DiaryNo)
        {
            InitializeComponent();
            lblDariyNo.Text = DiaryNo;
        }
        private DataTable _dt = new DataTable();

        private Image ImageRetrive(byte[] imgdata)
        {
            MemoryStream ms = new MemoryStream(imgdata);
            ms.Position = 0;
            return Image.FromStream(ms);
        }
        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                List<clsMemberImage> ImageContainer1 = new List<clsMemberImage>();

                int imageCount = ImageContainer1 !=  null ? ImageContainer1.Count() + 1:0;
                    clsMemberImage obj = new clsMemberImage();
                    obj.ImageName = DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                    obj.Description = "Attachment with Incoming Mail.";

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
                        ImageContainer1.Add(obj);
                        foreach (clsMemberImage row in ImageContainer1)
                        {
                            MemoryStream ms = new MemoryStream();
                            row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            Byte[] Image = ms.ToArray();
                            SqlParameter[] parameters =
                              {
                                            new SqlParameter("@Task", "Insert"),
                                            new SqlParameter("@IncomingID", lblDariyNo.Text),
                                            new SqlParameter("@ImageFile", Image),
                                            new SqlParameter("@ImageName", row.ImageName),
                                            new SqlParameter("@Description", row.Description),
                                            new SqlParameter("@user_ID", clsUser.ID),
                                             };
                        int result = Helper.SQLHelper.ExecuteNonQuery(
                                                clsMostUseVars.VerifiedImageConnectionstring,
                                                CommandType.StoredProcedure,
                                                "usp_tbl_IncomingMail",
                                                parameters
                                                );
                    }
                        ImageContainer1 = null;
                        SqlParameter[] param ={
                                new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                                new SqlParameter("@IncomingID",lblDariyNo.Text)
                        };
                        DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_IncomingMail", param);
                        if (ds.Tables.Count > 0)
                        {
                              _dt = ds.Tables[0];
                            GDVImageInfo.DataSource = ds.Tables[0].DefaultView;
                            GDVImageInfo.Refresh();
                        }
                    //ImageSource.TableElement.RowHeight = 50;
                    //ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageContainer.Clear();
                    }
                
            }
            catch (Exception ex)
            {
            }
        }

        private void GDVImageInfo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnRemove")
            {
                if (MessageBox.Show("Are you sure to remove this Image", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string DocID = e.Row.Cells["ID"].Value.ToString();
                    SqlParameter[] param = {
                    new SqlParameter("@Task","RemoveImage"),
                    new SqlParameter("@ID",DocID)
                };
                    int result = Helper.SQLHelper.ExecuteNonQuery(
                                                   clsMostUseVars.VerifiedImageConnectionstring,
                                                   CommandType.StoredProcedure,
                                                   "usp_tbl_IncomingMail",
                                                   param
                                                  );
                    if (result > 0)
                    {
                        MessageBox.Show("Removed Successfull");

                        if (!string.IsNullOrWhiteSpace(lblDariyNo.Text))
                        {
                            SqlParameter[] paramete = {
                                                    new SqlParameter("@Task","Select"),
                                                    new SqlParameter("@IncomingID",lblDariyNo.Text),
                                                };
                            DataSet ds = Helper.SQLHelper.ExecuteDataset(
                                                                  clsMostUseVars.VerifiedImageConnectionstring,
                                                                  CommandType.StoredProcedure,
                                                                  "usp_tbl_IncomingMail",
                                                                  paramete
                                                                  );
                            _dt = ds.Tables[0];
                            GDVImageInfo.DataSource = _dt;
                            GDVImageInfo.Refresh();
                        }
                    }
                }
            }
            else
            {
                Image img = ImageRetrive((byte[])_dt.Rows[e.RowIndex]["ImageFile"]);
                Image_View.Image = img;
            }
        }

        private void IncomingImageModification_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(lblDariyNo.Text))
                {
                    SqlParameter[] param = {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@IncomingID",lblDariyNo.Text),
            };
                    DataSet ds = Helper.SQLHelper.ExecuteDataset(
                                                          clsMostUseVars.VerifiedImageConnectionstring,
                                                          CommandType.StoredProcedure,
                                                          "usp_tbl_IncomingMail",
                                                          param
                                                          );
                    _dt = ds.Tables[0];
                    GDVImageInfo.DataSource = _dt;
                    GDVImageInfo.Refresh();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occur Incoming Mail Message:->"+ex.Message);
            }
           
          
        }
    }
}
