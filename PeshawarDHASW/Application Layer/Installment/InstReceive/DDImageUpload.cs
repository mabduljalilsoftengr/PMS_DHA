using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Models;
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

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class DDImageUpload : Telerik.WinControls.UI.RadForm
    {
        public DDImageUpload()
        {
            InitializeComponent();
        }
        private int RsInstallmentid { get; set; }
        private string ddImageType { get; set;}
        private int Rece_ID { get; set; }

        public DDImageUpload(int ImageID, string text)
        {
            RsInstallmentid = ImageID;
            ddImageType = text;
            InitializeComponent();
        }

        public DDImageUpload(int ImageID, int ReceID , string text)
        {
            Rece_ID = ReceID;
            RsInstallmentid = ImageID;
            ddImageType = text;
            InitializeComponent();
            pbDDimage.Image = ImageRetrive();
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opendialog = new OpenFileDialog();
                opendialog.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                opendialog.Title = "Select Photos";

                DialogResult dr = opendialog.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    pbDDimage.Image = new Bitmap(opendialog.FileName);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBrowseImage_Click.", ex, "DDImageUpload");
                frmobj.ShowDialog();

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Rece_ID != 0)
            {
                Update_Rece_InstallmentImage();
            }
            else
            {
                Saving_ReceInstImage();
            }
           
        }

        #region Update _Rece_Installment Image
        private void Update_Rece_InstallmentImage()
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pbDDimage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Byte[] Image = ms.ToArray();
                SqlParameter[] parameters =
                {
                                new SqlParameter("@Task", "Update"),
                                new SqlParameter("@ID",RsInstallmentid), 
                                new SqlParameter("@ImageName", txtImageName.Text),
                                new SqlParameter("@ImageType", ddImageType),
                                new SqlParameter("@Image", Image),
                                new SqlParameter("@DDImageID",Rece_ID),  // Here @DDImageID is the foreign key of RecieveInstallmentID
                                new SqlParameter("@user_ID", clsUser.ID),
                            };
                int result = cls_dl_InstRece.Insert_DD_Images(parameters);
                if (result > 0)
                {
                    lblstatusofimage.Visible = true;
                    lblstatusofimage.Text = "Sucessful";
                    this.Close();
                }
                else
                {
                    lblstatusofimage.Visible = true;
                    lblstatusofimage.Text = "Unsucessful";
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Update_Rece_InstallmentImage.", ex, "DDImageUpload");
                frmobj.ShowDialog();
            }
         
        }
        #endregion

        #region Saving Image of Rece Inst
        private void Saving_ReceInstImage()
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pbDDimage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Byte[] Image = ms.ToArray();
                SqlParameter[] parameters =
                {
                                new SqlParameter("@Task", "InsertDDImage"),
                                new SqlParameter("@ImageName", txtImageName.Text),
                                new SqlParameter("@ImageType", ddImageType),
                                new SqlParameter("@Image", Image),
                                new SqlParameter("@DDImageID",RsInstallmentid),  // Here @DDImageID is the foreign key of RecieveInstallmentID
                                new SqlParameter("@user_ID", clsUser.ID),
                            };
                int result = cls_dl_InstRece.Insert_DD_Images(parameters);
                if (result > 0)
                {
                    lblstatusofimage.Visible = true;
                    lblstatusofimage.Text = "Sucessful";
                    this.Close();
                }
                else
                {
                    lblstatusofimage.Visible = true;
                    lblstatusofimage.Text = "Unsucessful";
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Saving_ReceInstImage.", ex, "DDImageUpload");
                frmobj.ShowDialog();
            }
           
        }
        #endregion

        private void DDImageUpload_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }

        private DataSet IMageLoading(int DDImageID)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "Select"),
                    new SqlParameter("@ID", DDImageID),
                };
                ds = cls_dl_InstRece.ReturnAllIDs(parameters);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on IMageLoading.", ex, "DDImageUpload");
                frmobj.ShowDialog();
            }
            return ds;
        }

        private Image ImageRetrive()
        {
            DataSet ds = IMageLoading(Rece_ID);
            MemoryStream ms = new MemoryStream();
            try
            {
                txtImageName.Text = ds.Tables[0].Rows[0]["ImageName"].ToString();
                byte[] imgData = (byte[])ds.Tables[0].Rows[0]["Image"];
                ms = new MemoryStream(imgData);
                ms.Position = 0;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ImageRetrive.", ex, "DDImageUpload");
                frmobj.ShowDialog();
            }
            return Image.FromStream(ms);
        }
    }
}
