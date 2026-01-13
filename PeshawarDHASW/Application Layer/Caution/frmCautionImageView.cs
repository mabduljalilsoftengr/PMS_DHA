using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;
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

namespace PeshawarDHASW.Application_Layer.Caution
{
    public partial class frmCautionImageView : Telerik.WinControls.UI.RadForm
    {
        public frmCautionImageView()
        {
            InitializeComponent();
        }
        private int CatnID { get; set; }
        public frmCautionImageView(int cautnID)
        {
            InitializeComponent();
            CatnID = cautnID;
        }

        private void frmCautionImageView_Load(object sender, EventArgs e)
        {
            SqlParameter[] param =
                            {
                    new SqlParameter("@Task","Select_Caution_Images"),//usp_tbl_DDTransferImages
                    new SqlParameter("@ctnID",CatnID)
                };
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_Caution", param);
            GDVImageInfo.DataSource = ds.Tables[0];
        }

        private void GDVImageInfo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "CautionAddRemoveStatus")
                {
                    int ID = int.Parse(GDVImageInfo.CurrentRow.Cells["CautionImageID"].Value.ToString());
                    SqlParameter[] param =
                     {
                          new SqlParameter("@Task","Select_Caution_Images"),
                          new SqlParameter("@CautionImageID",ID)
                     };
                    DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_Caution", param);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Image img = ImageRetrive((byte[])ds.Tables[0].Rows[0]["CautionImage"]);
                        ImageView.Image = img;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Field");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on SearchDGV_CellClick.", ex, "frmMembershipSearch");
                //frmobj.ShowDialog();
            }
        }
        private Image ImageRetrive(byte[] imgdata)
        {
            MemoryStream ms = new MemoryStream(imgdata);
            ms.Position = 0;
            return Image.FromStream(ms);
        }
    }
}
