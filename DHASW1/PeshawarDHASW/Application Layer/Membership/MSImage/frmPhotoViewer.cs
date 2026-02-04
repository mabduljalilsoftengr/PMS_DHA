using PeshawarDHASW.Application_Layer.CustomDialog;
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

namespace PeshawarDHASW.Application_Layer.Membership.MSImage
{
    public partial class frmPhotoViewer : Form
    {
        private DataTable _dt { get; set; }
        public int ImageID { get; set; } = 0;
       
        public frmPhotoViewer()
        {
            InitializeComponent();
        }
        public frmPhotoViewer(DataTable dtbl)
        {
            InitializeComponent();
            _dt = dtbl;
            groupBox1.Text = "DD Transfer Images";
            GDVImageInfo.DataSource = _dt;
            btnAddImage.Visible = false;

            foreach (var item in GDVImageInfo.Columns)
            {
                if (item.Name == "btnRemove")
                {
                    item.IsVisible = false;
                }
              
            }
        }

        public string FormName { get; set; }
        public string ID_Control { get; set; }
        public string discountStatus { get; set; }
        public frmPhotoViewer(string formname,string DiscountStatus,string ID, DataTable dtbl)
        {
            InitializeComponent();
            _dt = dtbl;
            FormName = formname;
            ID_Control = ID;
            groupBox1.Text = formname;
            discountStatus = DiscountStatus;
            GDVImageInfo.DataSource = _dt;
            GDVImageInfo.Refresh();
            if (DiscountStatus != "Pending")
            {
                btnAddImage.Visible = false;
            }
        }


        private void frmPhotoViewer_Load(object sender, EventArgs e)
        {
            //groupBox1.Text = "DD Transfer Images";
            //GDVImageInfo.DataSource = _dt;
        }
     

        private void GDVImageInfo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "btnRemove")
                {
                    if (FormName == "Discount")
                    {
                        if (FormName == "Discount" && discountStatus == "Pending")
                        {

                            if (MessageBox.Show("Are you Sure", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                int ID = int.Parse(e.Row.Cells["ID"].Value.ToString()); // ReceID
                                SqlParameter[] param ={
                                new SqlParameter("@Task","DeleteImage"),//usp_tbl_DDTransferImages
                                new SqlParameter("@DiscountRqID",ID_Control),
                                new SqlParameter("@ID",ID)
                                };

                                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "USP_tbl_ReceDiscountImage", param);
                                if (ds.Tables.Count > 0)
                                {
                                    GDVImageInfo.DataSource = ds.Tables[0].DefaultView;
                                    GDVImageInfo.Refresh();
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Discount is Approved | Cancel Image Cannot be Delete.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Image Cannot be Remove.");
                    }
                   
                }
                else
                {
                    Image img = ImageRetrive((byte[])_dt.Rows[e.RowIndex]["ImageFile"]);
                    Image_View.Image = img;
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDGV_CellClick.", ex, "frmPhotoViewer");
            }
        }
        private Image ImageRetrive(byte[] imgdata)
        {
            MemoryStream ms = new MemoryStream(imgdata);
            ms.Position = 0;
            return Image.FromStream(ms);
        }
        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();
        private void btnAddImage_Click(object sender, EventArgs e)
        {

            try
            {
                if (FormName == "Discount")
                {


                    int imageCount = ImageContainer.Count() + 1;
                    clsMemberImage obj = new clsMemberImage();
                    obj.ImageName = DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                    obj.Description = "Attachment with Discount.";

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
                        foreach (clsMemberImage row in ImageContainer)
                        {
                            MemoryStream ms = new MemoryStream();
                            row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            Byte[] Image = ms.ToArray();
                            SqlParameter[] parameters =
                            {
                                new SqlParameter("@Task", "Insert"),
                                new SqlParameter("@DiscountRqID", ID_Control),
                                new SqlParameter("@ImageFile", Image),
                                new SqlParameter("@ImageName", row.ImageName),
                                new SqlParameter("@Description", row.Description),
                                new SqlParameter("@user_ID", clsUser.ID),
                            };
                            int result = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "USP_tbl_ReceDiscountImage", parameters);

                        }
                        ImageContainer = null;
                        SqlParameter[] param ={
                                new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                                new SqlParameter("@DiscountRqID",ID_Control)
                        };
                        DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "USP_tbl_ReceDiscountImage", param);
                        if (ds.Tables.Count > 0)
                        {
                            GDVImageInfo.DataSource = ds.Tables[0].DefaultView;
                            GDVImageInfo.Refresh();
                        }
                        //ImageSource.TableElement.RowHeight = 50;
                        //ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                        //ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
