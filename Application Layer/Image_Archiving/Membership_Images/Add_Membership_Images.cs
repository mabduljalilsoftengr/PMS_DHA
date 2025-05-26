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
using WIA;

namespace PeshawarDHASW.Application_Layer.Image_Archiving
{
    public partial class Add_Image : Telerik.WinControls.UI.RadForm
    {
        public Add_Image()
        {
            InitializeComponent();
        }
        private int MemberID { get; set; } = 0;
        private void btn_NewImage_Click(object sender, EventArgs e)
        {
            if (txtMembershipNo.Text != null | txtMembershipNo.Text != string.Empty)
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
            else
            {
                MessageBox.Show("Please Fill the Membership Textbox.");
            }
           
        }

        private void Add_Image_Load(object sender, EventArgs e)
        {
            GridViewButtons();
            btn_NewImage.Enabled = false;
            btnSave.Enabled = false;
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
            DialogResult dr = MessageBox.Show("Are you sure that all the Images of Member is Completed ?","Attention!",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
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
                    #endregion
                    #region Save Image and Detail in DataBase
                    SqlParameter[] prmtr =
                    {
                        new SqlParameter("@Task","Insert_Member_Images"),
                        new SqlParameter("@ImageName",Name),
                        new SqlParameter("@Description",Description),
                        new SqlParameter("@Remarks",Remarks),
                        new SqlParameter("@ImageFile",Image),
                        new SqlParameter("@MemberID",MemberID),
                        new SqlParameter("@user_ID",Models.clsUser.ID)
                    };
                    int rslt = cls_dl_Image.ImageSaving(prmtr);
                    if(rslt > 0)
                    {
                        txtMembershipNo.Text = "";
                        grdImagesDetail.DataSource = null;
                        grdImagesDetail.Rows.Clear();
                        #region Enabled = false
                        btnSave.Enabled = false;
                        btn_NewImage.Enabled = false;
                        #endregion
                        //GridViewButtons();
                        //MessageBox.Show("Images and its Detail Inserted Successfully. ");
                    }
                    else
                    {
                        MessageBox.Show("Contact with Administartion.");
                    }
                    #endregion
                }
            }
           
        }
      
        private void txtMembershipNo_Leave(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Get_MemberID"),
                new SqlParameter("@MembershipNo",txtMembershipNo.Text)
            };
            DataSet dst = new DataSet();
            dst = cls_dl_Image.Membership_PersonalInfo_Retrive(prm);
            if (dst.Tables.Count > 0)
            {
              if(dst.Tables[0].Rows.Count > 0)
                {
                   MemberID = int.Parse(dst.Tables[0].Rows[0]["ID"].ToString());
                   btn_NewImage.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Membership No. "+txtMembershipNo.Text+" is not Recognized.");
                }
            }
            else
            {
                MessageBox.Show("There is no Data for Membership No. " + txtMembershipNo.Text );
            }
        }

        private void txtMembershipNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        private void lblms_Click(object sender, EventArgs e)
        {

        }
    }
}
