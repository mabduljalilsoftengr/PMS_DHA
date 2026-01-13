using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;
using System.IO;
using PeshawarDHASW.Models;

namespace PeshawarDHASW.Application_Layer.Membership.MSImage
{
    public partial class frmMSImage : Telerik.WinControls.UI.RadForm
    {
        public bool isTransfer { get; set; }
        public frmMSImage()
        {
            InitializeComponent();
        }
        public int MemberID { get; set; }
        public frmMSImage(int MembershipID,bool isDDTransfer = false)
        {
            MemberID = MembershipID;
            InitializeComponent();
            //delete Option for Developer only
            if (clsUser.ID == 3 || clsUser.ID == 8)
            {
                btnImageDelete.Visible = true;
            }
            else
            {
                btnImageDelete.Visible = false;
            }
            isTransfer = isDDTransfer;
        }
        private void frmMSImage_Load(object sender, EventArgs e)
        {
            if (isTransfer)
            {
                groupBox1.Text = "DD Transfer Images";
                SqlParameter[] param =
                                {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@DDTransferID",MemberID)
                };
                DataSet ds = Data_Layer.clsMembershipImage.cls_dl_MembershipImage.DDTransferImage_Retriving(param);
                GDVImageInfo.DataSource = ds.Tables[0];
            }
            else
            {
                SqlParameter[] param =
                    {
                    new SqlParameter("@Task","SelectbyMemberID"),
                    new SqlParameter("@Memberid",MemberID)
                };
                DataSet ds = Data_Layer.clsMembershipImage.cls_dl_MembershipImage.Image_Retriving(param);
                GDVImageInfo.DataSource = ds.Tables[0];
            }
        }

        public int ImageID { get; set; } = 0;

        private void GDVImageInfo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "ImageName")
                {
                    int ID = int.Parse(GDVImageInfo.CurrentRow.Cells[0].Value.ToString());
                    ImageID = ID;
                    SqlParameter[] param =
                     {
                          new SqlParameter("@Task","SearchImage"),
                          new SqlParameter("@ID",ID)
                     };
                    DataSet ds = Data_Layer.clsMembershipImage.cls_dl_MembershipImage.Image_Retriving(param);
             
                    if (ds.Tables[0].Rows.Count >0)
                    {
                        Image img = ImageRetrive((byte[])ds.Tables[0].Rows[0][0]);
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

        private void btnImageDelete_Click(object sender, EventArgs e)
        {
            if (ImageID >0)
            {
                if (MessageBox.Show("Warning are you sure to Delete this Image.", "Attention Image ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SqlParameter[] param =
                     {
                    new SqlParameter("@Task","DeleteImage"),
                    new SqlParameter("@ID",ImageID)
                    };
                    int ds = Data_Layer.clsMembershipImage.cls_dl_MembershipImage.ImageSaving(param);
                    if (ds > 0)
                    {
                        RadMessageBox.Show("Successfull");
                    }
                }
            }
            else
            {
                MessageBox.Show("No Image is Selected");
            }
            
        }
    }
}
