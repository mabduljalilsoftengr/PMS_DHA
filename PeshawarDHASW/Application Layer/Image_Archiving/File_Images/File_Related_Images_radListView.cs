using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Image_Archiving.File_Images
{
    public partial class File_Related_Images_radListView : Telerik.WinControls.UI.RadForm
    {
        public File_Related_Images_radListView()
        {
            InitializeComponent();
        }
        #region 
        private DataTable dtbl { get; set; }
        public File_Related_Images_radListView(DataTable get_dtbl)
        {
            InitializeComponent();            
            dtbl = get_dtbl;
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
            lstv_Images.ItemDataBound += Lstv_Images_ItemDataBound;
            lstv_Images.DataSource = t;
            lstv_Images.DisplayMember = "ID";
            #endregion
            #region Group By Image Name
            lstv_Images.EnableGrouping = true;
            lstv_Images.ShowGroups = true;            
            GroupDescriptor groupByValue = new GroupDescriptor(new SortDescriptor[] { new SortDescriptor("ImageName", ListSortDirection.Ascending) });
            lstv_Images.GroupDescriptors.Add(groupByValue);
            #endregion
        }
        #endregion
        #region ItemDataBound
        private void Lstv_Images_ItemDataBound(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            DataRowView rowView = e.Item.DataBoundItem as DataRowView;
            e.Item.Image = rowView.Row["Image"] as Image;
        }
        #endregion
        #region Convert Byte Array to Image
        private Image ImageRetrive(byte[] rw)
        {
            byte[] imgData = rw;
            MemoryStream ms = new MemoryStream(imgData);
            ms.Position = 0;
            return Image.FromStream(ms);
        }
        #endregion
        private void File_Related_Images_Load(object sender, EventArgs e)
        {

        }      
        private void radButton1_Click_1(object sender, EventArgs e)
        {
            //lstv_Images.EnableGrouping = true;
            //lstv_Images.ShowGroups = true;
            //GroupDescriptor groupByValue = new GroupDescriptor(new SortDescriptor[] { new SortDescriptor("ImageName", ListSortDirection.Ascending) });
            //lstv_Images.GroupDescriptors.Add(groupByValue);
        }

         }
}
