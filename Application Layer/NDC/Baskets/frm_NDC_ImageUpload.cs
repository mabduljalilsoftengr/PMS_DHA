using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.NDC;
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

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frm_NDC_ImageUpload : Telerik.WinControls.UI.RadForm
    {
        public int NDCNO { get; set; }
        public frm_NDC_ImageUpload()
        {
            InitializeComponent();
        }
        public frm_NDC_ImageUpload(int get_NDCNo)
        {
            NDCNO = get_NDCNo;
            InitializeComponent();
        }
        private void btnBrows_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG,*.PNG)|*.BMP;*.JPG;*.PNG| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {

                    string[] files = openFileDialog1.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            pbNDC_Image.Image = Image.FromFile(pngFile);
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
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBrows_Click.", ex, "frm_NDC_ImageUpload");
                frmobj.ShowDialog();
            }
           
        }

        private void btn_SaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                // Image to Byte
                MemoryStream ms = new MemoryStream();
                pbNDC_Image.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] Image = ms.ToArray();
                //-------------------------------------
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@NDC_Image",Image),
                new SqlParameter("@NDCNo",NDCNO)
            };
                int rslt = 0;
                rslt = cls_dl_NDC.NdcNonQueryImage(prm);
                if (rslt > 0)
                {
                    //MessageBox.Show("Saved Successfully.");
                    ForwardForMembership();
                    btnBack.Enabled = false;
                    btnBrows.Enabled = false;
                    btn_SaveImage.Enabled = false;
                    //this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btn_SaveImage_Click.", ex, "frm_NDC_ImageUpload");
                frmobj.ShowDialog();
            }
           
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                frmGoBackRemarks frm = new frmGoBackRemarks();
                frm.ShowDialog();
                string rmksGoBack = clsNDC.goBackRemarks;
                SqlParameter[] prm =
              {
                new SqlParameter("@Task","Update_NDC_Status"),
                new SqlParameter("@StatusofNDC","PrintAndNotSigned"),
                new SqlParameter("@NDCNo",NDCNO),
                new SqlParameter("@GoBack_Remarks",rmksGoBack)
              };
                int rslt = 0;
                rslt = cls_dl_NDC.NdcNonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Back Successfully.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBack_Click.", ex, "frm_NDC_ImageUpload");
                frmobj.ShowDialog();
            }
           
        }
        private void ForwardForMembership()
        {
            try
            {
                SqlParameter[] prm =
                          {
                new SqlParameter("@Task","Update_NDC_Status"),
                new SqlParameter("@StatusofNDC","ReadyForTFRAppointment"),//   IssueAndImageUploaded
                new SqlParameter("@NDCNo",NDCNO)
            };
                int rslt = 0;
                rslt = cls_dl_NDC.NdcNonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Image Save and Forwarded Successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contact with Administration.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ForwardForMembership.", ex, "frm_NDC_ImageUpload");
                frmobj.ShowDialog();
            }
           
        }
        private void btnForward_Click(object sender, EventArgs e)
        {
            //ForwardForMembership;
        }

        private void frm_NDC_ImageUpload_Load(object sender, EventArgs e)
        {

        }
    }
}
