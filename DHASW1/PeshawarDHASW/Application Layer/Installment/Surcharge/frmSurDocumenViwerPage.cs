using PeshawarDHASW.Application_Layer.CustomDialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Installment.Surcharge
{
    public partial class frmSurDocumenViwerPage : Telerik.WinControls.UI.RadForm
    {
        public frmSurDocumenViwerPage()
        {
            InitializeComponent();
        }
        private DataTable dt_ = new DataTable();
        public frmSurDocumenViwerPage(DataTable dtbl)
        {
            InitializeComponent();
            dt_ = dtbl;
            GDVImageInfo.DataSource = dt_;
        }
        private void frmSurDocumenViwerPage_Load(object sender, EventArgs e)
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
                    Image img = ImageRetrive((byte[])dt_.Rows[e.RowIndex]["ImageFile"]);
                    Image_View.Image = img;
                
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDGV_CellClick.", ex, "frmMembershipSearch");
            }
        }
    }
}
