using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.Account_Statement.AdjustmentModule
{
    public partial class frmImagePreview : Telerik.WinControls.UI.RadForm
    {
        public frmImagePreview()
        {
            InitializeComponent();
        }
        private DataTable dtbl { get; set; }
        public frmImagePreview(DataTable dt)
        {
            InitializeComponent();
            dtbl = dt;
        }

        private void frmImagePreview_Load(object sender, EventArgs e)
        {
            grdimgdata.DataSource = dtbl.DefaultView;
        }

       
        private void grdimgdata_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            Image img = ImageRetrive((byte[])dtbl.Rows[e.RowIndex]["Image"]);
            pcbImage.Image = img;
        }
        private Image ImageRetrive(byte[] imgdata)
        {
            MemoryStream ms = new MemoryStream(imgdata);
            ms.Position = 0;
            return Image.FromStream(ms);
        }
    }
}
