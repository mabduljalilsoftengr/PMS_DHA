using PeshawarDHASW.Application_Layer.CustomDialog;
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

namespace PeshawarDHASW.Application_Layer.Contractor
{
    public partial class frmAttachmentContractor : Telerik.WinControls.UI.RadForm
    {
        public frmAttachmentContractor()
        {
            InitializeComponent();
        }

        public frmAttachmentContractor(string ContractorID,string ContractorName)
        {
            InitializeComponent();
            lblContractorID.Text = ContractorID;
            lblContractorName.Text = ContractorName;
            DataLoading();
        }

        public frmAttachmentContractor(string ContractorID, string ContractorName,bool Flag)
        {
            InitializeComponent();
            lblContractorID.Text = ContractorID;
            lblContractorName.Text = ContractorName;
            btnAddImage.Visible = false;

            DataLoading();
        }

        private void frmAttachmentContractor_Load(object sender, EventArgs e)
        {

        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opendialog = new OpenFileDialog();
                opendialog.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                opendialog.Title = "Select Photos";
                opendialog.Multiselect = true;
                DialogResult dr = opendialog.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    string[] files = opendialog.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                           var pngImage = Image.FromFile(pngFile);
                            FileInfo fileinfo = new FileInfo(pngFile);
                            MemoryStream ms = new MemoryStream();
                            pngImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            Byte[] byteImage = ms.ToArray();
                            SqlParameter[] parameters =
                            {
                                new SqlParameter("@Task", "Insert"),
                                new SqlParameter("@ContractorID", lblContractorID.Text),
                                new SqlParameter("@ImageFile", byteImage),
                                new SqlParameter("@ImageName", lblContractorID.Text+"-"+lblContractorName.Text),
                                new SqlParameter("@Description", fileinfo.Name),
                                new SqlParameter("@user_ID", clsUser.ID),
                            };
                            int result = Helper.SQLHelper.ExecuteNonQuery(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_ContractorVendorImages", parameters);
                            MessageBox.Show("Attactment is Successfully Uplodaed");
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Contractor | Vendor.", ex, "Contractor | Vendor Image Upload");
                frmobj.ShowDialog();

            }
        }

        private Image ImageRetrive(byte[] imgdata)
        {
            MemoryStream ms = new MemoryStream(imgdata);
            ms.Position = 0;
            return Image.FromStream(ms);
        }

        private void DataLoading()
        {
            SqlParameter[] param ={
                                new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                                new SqlParameter("@ContractorID",lblContractorID.Text)
                        };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_ContractorVendorImages", param);
            if (ds.Tables.Count > 0)
            {
                GDVImageInfo.DataSource = ds.Tables[0].DefaultView;
                GDVImageInfo.Refresh();
            }
        }

        private void GDVImageInfo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                Image img = ImageRetrive((byte[])e.Row.Cells["ImageFile"].Value);
                Image_View.Image = img;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
