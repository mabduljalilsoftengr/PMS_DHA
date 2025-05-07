using PeshawarDHASW.Data_Layer.clsFileMap;
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

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmBuyBackImage : Telerik.WinControls.UI.RadForm
    {
        public frmBuyBackImage()
        {
            InitializeComponent();
        }

        private int BID { get; set; }
        public frmBuyBackImage(int b_id)
        {
            InitializeComponent();
            BID = b_id;
        }

        private void frmBuyBackImage_Load(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter =
            @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|
            All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                /////////// Declare Table
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("Image", typeof(Image));
                dt.Columns.Add("ImageName", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                string[] files = openFileDialog1.FileNames;
                int i = 1;
                foreach (var pngFile in files)
                {
                    try
                    {
                        DataRow _ravi = dt.NewRow();
                        _ravi["Image"] = Image.FromFile(pngFile);
                        _ravi["ImageName"] = DateTime.Now.ToString("yyyyMMdd") + "_" + i;
                        _ravi["Description"] = "Documents.";
                        dt.Rows.Add(_ravi);
                        i = i + 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("This is not an image file");
                    }
                }
                grdimages.TableElement.RowHeight = 50;
                grdimages.Columns["Image"].ImageLayout = ImageLayout.Stretch;
                grdimages.DataSource = dt.DefaultView;
            }
        }

        private void grdimages_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            Image img = (Image)e.Row.Cells["Image"].Value;
            pcbimage.Image = img;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdimages.RowCount; i++)
            {
                Image img = (Image)grdimages.Rows[i].Cells["Image"].Value;
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] Im = ms.ToArray();

                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","SaveBuyBackImages"),
                    new SqlParameter("@ImageFile",Im),
                    new SqlParameter("@ImageName","Image_"+i),
                    new SqlParameter("@BuyBackID",BID),
                    new SqlParameter("@user_ID",Models.clsUser.ID)
                };
                int rslt = cls_dl_FileMap.Main_FileMap_NonQuery_ImageSaving(prm);
                if(rslt > 0)
                {
                    MessageBox.Show("Successful.");
                    this.Close();
                }
            }
        }
    }
}
