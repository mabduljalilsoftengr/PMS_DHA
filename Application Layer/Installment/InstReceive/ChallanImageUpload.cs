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
using PeshawarDHASW.Data_Layer.clsChallanRece;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    public partial class ChallanImageUpload : Telerik.WinControls.UI.RadForm
    {
        public ChallanImageUpload()
        {
            InitializeComponent();
        }
        public int InstallmentRsvID { get; set; } 
        public string challanImageType { get; set; }
        public int _CRID { get; set; }
        public ChallanImageUpload(int ID_Get,string text)
        {
            InstallmentRsvID = ID_Get;
            challanImageType = text;
            InitializeComponent();
        }

        public ChallanImageUpload(int CRID,int ID_Get, string text)
        {
            InstallmentRsvID = ID_Get;
            challanImageType = text;
            _CRID = CRID;
            InitializeComponent();
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
                    pbChallanimage.Image = new Bitmap(opendialog.FileName);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBrowseImage_Click.", ex, "ChallanImageUpload");
                frmobj.ShowDialog();
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_CRID != 0)
                {
                    MemoryStream ms = new MemoryStream();
                    pbChallanimage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    Byte[] Image = ms.ToArray();
                    SqlParameter[] parameters =
                    {
                    new SqlParameter("@Task", "Update"),
                    new SqlParameter("@ID",_CRID),
                    new SqlParameter("@ImageName", txtImageName.Text),
                    new SqlParameter("@ImageType", challanImageType),
                    new SqlParameter("@Image", Image),
                    new SqlParameter("@ChallanImageID", InstallmentRsvID),
                    // Here @DDImageID is the foreign key of RecieveInstallmentID
                    new SqlParameter("@user_ID", clsUser.ID),
                };
                    int result = cls_dl_ChallanRece.DML_Challan_Images(parameters);
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
                else
                {
                    MemoryStream ms = new MemoryStream();
                    pbChallanimage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    Byte[] Image = ms.ToArray();
                    SqlParameter[] parameters =
                    {
                    new SqlParameter("@Task", "Insert"),
                    new SqlParameter("@ImageName", txtImageName.Text),
                    new SqlParameter("@ImageType", challanImageType),
                    new SqlParameter("@Image", Image),
                    new SqlParameter("@ChallanImageID", InstallmentRsvID),
                    // Here @DDImageID is the foreign key of RecieveInstallmentID
                    new SqlParameter("@user_ID", clsUser.ID),
                };
                    int result = cls_dl_ChallanRece.DML_Challan_Images(parameters);
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
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSave_Click.", ex, "ChallanImageUpload");
                frmobj.ShowDialog();
            }
           
        }

        private void ChallanImageUpload_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
        }
    }
}
