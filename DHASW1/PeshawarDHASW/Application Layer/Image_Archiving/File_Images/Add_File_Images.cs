using PeshawarDHASW.Data_Layer.clsImageArchiving;
using PeshawarDHASW.Data_Layer.clsMemberShip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Image_Archiving.File_Images
{
    public partial class Add_File_Images : Telerik.WinControls.UI.RadForm
    {
        public Add_File_Images()
        {
            InitializeComponent();
        }
        private int FileID { get; set; }
        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Get_FileID"),
                new SqlParameter("@FileNo",txtFileNo.Text)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_Image.File_Info_Retrive(prm);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    FileID = int.Parse(dst.Tables[0].Rows[0]["FileMapKey"].ToString());
                    if(CheckFileID_InImageTable(FileID))
                    {
                        // Bind Data with radGridView/radListView
                        DataTable dtbl = Images_Detail(FileID);
                        //File_Related_Images_radListView frmobj = new File_Related_Images_radListView(dtbl);
                        //frmobj.ShowDialog();
                        DialogResult rslt = MessageBox.Show("Images of this FileNo is already Uploaded, Are you sure you want to Modify ?","Attention !!!",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                        if (rslt == DialogResult.Yes)
                        {
                            File_Related_Images_radGridView frmobj = new File_Related_Images_radGridView(dtbl);
                            frmobj.ShowDialog();
                        }                       
                    }
                    else
                    {
                        btn_NewFileImage.Enabled = true;
                        btn_Browse.Enabled = true;
                    }                   
                }
                else
                {
                    MessageBox.Show("File Number :"+ txtFileNo.Text+" is not recognized.");
                }
            }
        }
        private bool CheckFileID_InImageTable(int fl_id)
        {
            bool flid = false;
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Select_File"),
                new SqlParameter("@FileMapID",fl_id)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_Image.Reader_FileID_ImagesTable(prm);
            if (dst.Tables.Count > 0)
            {
             if(dst.Tables[0].Rows.Count > 0)
                {
                    flid = true;
                }
                else
                {
                    flid = false;
                }
            }
            else
            {
                flid = false;
            }
            return flid;
        }
        private DataTable Images_Detail(int get_FileID)
        {
            DataTable dt = new DataTable();
            SqlParameter[] prm =
           {
                new SqlParameter("@Task","Get_FileRelated_Images"),
                new SqlParameter("@FileMapID",get_FileID)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_Image.Reader_FileID_ImagesTable(prm);
            dt = dst.Tables[0];
            return dt;
        }
        private void btn_NewFileImage_Click(object sender, EventArgs e)
        {
            if (txtFileNo.Text == null | txtFileNo.Text == string.Empty)
            {
                MessageBox.Show("Please Fill Membership No.");
            }
            else
            {               
                SelectScanner obj = new SelectScanner();
                obj.ShowDialog();
                List<Image> imgs = Data_Layer.clsImageArchiving.cls_ImageHolder.ImagesContainer;
                foreach (Image img in imgs)
                {
                    #region Add Row to GridView
                    grdImagesDetail.Rows.Add(null, null, null, img);
                    btnSave.Enabled = true;
                    #endregion
                }
                cls_ImageHolder.ImagesContainer.Clear();
            }
        }
        private void GridViewButtons()
        {
            //////////////////////// GridView Columns/////////////////////////////////////
            GridViewTextBoxColumn name = new GridViewTextBoxColumn();
            name.Name = "Name";
            name.HeaderText = "Name";
            name.Width = 150;
            grdImagesDetail.MasterTemplate.Columns.Add(name);
            //---------------------------------------------------------------------------
            GridViewTextBoxColumn description = new GridViewTextBoxColumn();
            description.Name = "Description";
            description.HeaderText = "Description";
            description.Width = 150;
            grdImagesDetail.Columns.Add(description);
            //---------------------------------------------------------------------------
            GridViewTextBoxColumn remarks = new GridViewTextBoxColumn();
            remarks.Name = "Remarks";
            remarks.HeaderText = "Remarks";
            remarks.Width = 150;
            grdImagesDetail.Columns.Add(remarks);
            //---------------------------------------------------------------------------
            GridViewImageColumn img = new GridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "Image Column";
            img.ImageLayout = ImageLayout.Stretch;
            img.Width = 600;
            grdImagesDetail.Columns.Add(img);
            //--------------------------------------------------------------------------
            GridViewCommandColumn imgpreview = new GridViewCommandColumn();
            imgpreview.Name = "imgpr";
            imgpreview.HeaderText = "Image Preview";
            imgpreview.DefaultText = "Preview";
            imgpreview.Width = 150;
            imgpreview.UseDefaultText = true;
            grdImagesDetail.Columns.Add(imgpreview);
            /////////////////////////////////////////////////////////////////////////////
            grdImagesDetail.AutoGenerateColumns = false;
        }

        private void Add_File_Images_Load(object sender, EventArgs e)
        {
            GridViewButtons();
            btn_NewFileImage.Enabled = false;
            btnSave.Enabled = false;
            btn_Browse.Enabled = false;
        }

        private void grdImagesDetail_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "imgpr")
            {
                Image img = (Image)grdImagesDetail.CurrentRow.Cells["img"].Value;
                ScannedImagePreview frmobj = new ScannedImagePreview(img);
                frmobj.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dr = MessageBox.Show("Are you sure that all Images of this File is Complete ?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    int count = grdImagesDetail.RowCount;
                    for (int i = 0; i < count; i++)
                    {
                        #region Retrive Name,Description,Remarks
                        string Name = (string)grdImagesDetail.Rows[i].Cells["Name"].Value;
                        string Description = (string)grdImagesDetail.Rows[i].Cells["Description"].Value;
                        string Remarks = (string)grdImagesDetail.Rows[i].Cells["Remarks"].Value;
                        #endregion
                        #region/////////////Retrive Image from GridView////////////////////
                        Image img = (Image)grdImagesDetail.Rows[i].Cells["img"].Value;
                        #endregion
                        #region/////////////////Convert Image to Byte Array////////////////
                        MemoryStream ms = new MemoryStream();
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        Byte[] Image = ms.ToArray();
                        //byte[] compress = Compress(Image);
                        #endregion
                        #region Save Image and Detail in DataBase
                        SqlParameter[] prmtr =
                        {
                        new SqlParameter("@Task","Insert_File_Images"),
                        new SqlParameter("@ImageName",Name),
                        new SqlParameter("@Description",Description),
                        new SqlParameter("@Remarks",Remarks),
                        new SqlParameter("@ImageFile",Image),
                        new SqlParameter("@FileMapID",FileID),
                        new SqlParameter("@user_ID",Models.clsUser.ID)
                    };
                        int rslt = cls_dl_Image.ImageSaving(prmtr);
                        if (rslt > 0)
                        {                          
                            //MessageBox.Show("Images and its Detail Inserted Successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Contact with Administartion.");
                        }
                        #endregion
                    }
                    txtFileNo.Text = "";
                    grdImagesDetail.DataSource = null;
                    grdImagesDetail.Rows.Clear();
                    #region Enabled = false
                    btnSave.Enabled = false;
                    btn_NewFileImage.Enabled = false;
                    btn_Browse.Enabled = false;
                    #endregion
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message+ex.InnerException);
            }
        }
        public static byte[] Compress(byte[] raw)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(memory,
                    CompressionMode.Compress, true))
                {
                    gzip.Write(raw, 0, raw.Length);
                }
                return memory.ToArray();
            }
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "All Files (*.*)|*.*|.png|.jpg|.jpeg|.GIF|.TIFF|.BMP|.IMG|";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                List<Image> imgfiles = new List<Image>();
                string[] str = openFileDialog1.FileNames;
                foreach (string st in str)
                {
                    Image img = new Bitmap(st);
                    imgfiles.Add(img);
                }
                if (imgfiles.Count > 0)
                {
                    foreach (Image im in imgfiles)
                    {
                        grdImagesDetail.Rows.Add(null,null,null,im);
                        if (grdImagesDetail.Rows.Count > 0)
                        {
                            btnSave.Enabled = true;
                        }
                    }
                }
            }
        }
    }
}
