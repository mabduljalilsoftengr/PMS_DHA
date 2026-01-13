using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Image_Archiving.File_Images
{
    public partial class File_Related_Images_radGridView : Telerik.WinControls.UI.RadForm
    {
        public File_Related_Images_radGridView()
        {
            InitializeComponent();
        }
        private DataTable dt { get; set; }
        public File_Related_Images_radGridView(DataTable dtbl)
        {
            InitializeComponent();
            dt = dtbl;
            #region DataTable
            DataTable t = new DataTable();
            t.Columns.Add("Image", typeof(Image));
            t.Columns.Add("ID", typeof(Int32));
            t.Columns.Add("ImageName", typeof(string));
            t.Columns.Add("Description", typeof(string));
            foreach (DataRow row in dtbl.Rows)
            {
                Image img = ImageRetrive((byte[])row["ImageFile"]);
                int ID = int.Parse(row["ID"].ToString());
                string img_name = row["ImageName"].ToString();
                string description = row["Description"].ToString();
                t.Rows.Add(img, ID, img_name, description);
            }
            #endregion
            #region Bind DataTable with ListView DataSource
            grd_Detail.DataSource = t;
            #endregion
        }
        #region Convert Byte Array to Image
        private Image ImageRetrive(byte[] rw)
        {
            byte[] imgData = rw;
            MemoryStream ms = new MemoryStream(imgData);
            ms.Position = 0;
            return Image.FromStream(ms);
        }
        #endregion
        #region GridView Columns Generate
        private void GridViewColumn_Generate()
        {
            //--------------------------------------------------------------------------
            GridViewCommandColumn imgpreview = new GridViewCommandColumn();
            imgpreview.Name = "imgpr";
            imgpreview.HeaderText = "Image Preview";
            imgpreview.DefaultText = "Preview";
            imgpreview.Width = 150;
            imgpreview.UseDefaultText = true;
            grd_Detail.Columns.Add(imgpreview);
            /////////////////////////////////////////////////////////////////////////////
            grd_Detail.AutoGenerateColumns = false;
        }
        #endregion

        private void File_Related_Images_radGridView_Load(object sender, EventArgs e)
        {
            GridViewColumn_Generate();
        }

        private void grd_Detail_CellClick(object sender, GridViewCellEventArgs e)
        {
            if(e.Column.Name == "imgpr")
            {
                Image img = (Image)grd_Detail.CurrentRow.Cells["Image"].Value;
                ScannedImagePreview objf = new ScannedImagePreview(img);
                objf.ShowDialog();
            }
        }
    }
}
