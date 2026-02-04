using PeshawarDHASW.Application_Layer.CustomDialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeshawarDHASW.Application_Layer.Membership.MSImage
{
    public partial class frmImageViewer : Form
    {
        private DataTable dtbl { get; set; }
        public frmImageViewer()
        {
            InitializeComponent();
        }
        public frmImageViewer(DataTable dt)
        {
            InitializeComponent();
            dtbl = dt;
            groupBox1.Text = "DD Transfer Images";
            GDVImageInfo.DataSource = dtbl;
        }

        private void frmImageViewer_Load(object sender, EventArgs e)
        {
          
        }
        private Image ImageRetrive(byte[] imgdata)
        {
            MemoryStream ms = new MemoryStream(imgdata);
            ms.Position = 0;
            return Image.FromStream(ms);
        }

        private void GDVImageInfo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                //if (e.Column.Name == "ImageName")
                //{
                    Image img = ImageRetrive((byte[])dtbl.Rows[e.RowIndex]["ImageFile"]);
                    Image_View.Image = img;
                //}
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDGV_CellClick.", ex, "frmMembershipSearch");
            }
        }
    }
}
