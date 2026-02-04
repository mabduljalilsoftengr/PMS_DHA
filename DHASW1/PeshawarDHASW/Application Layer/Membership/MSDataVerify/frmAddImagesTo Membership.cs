using PeshawarDHASW.Data_Layer.clsMemberShip;

using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Membership.MSDataVerify
{
    public partial class frmAddImagesTo_Membership : Telerik.WinControls.UI.RadForm
    {
        public frmAddImagesTo_Membership()
        {
            InitializeComponent();
        }

        public string passMembershipno { get; set; }
        public frmAddImagesTo_Membership(string Membershipno)
        {
            passMembershipno = Membershipno;
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {

        }

        private void txtimageDescription_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void txtnic_Leave(object sender, EventArgs e)
        {

        }

        private void txtnic_Validating(object sender, CancelEventArgs e)
        {

        }

 

        private void txtmsno_Validating(object sender, CancelEventArgs e)
        {

        }
        public string memberID { get; set; } = "0";
        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();

        private void memberverify()
        {
            ImageContainer.Clear();
            try
            {
               
                    SqlParameter[] parameter =
                    {
                        new SqlParameter("@Task", "VerifyMember"),
                        new SqlParameter("@MembershipNo", clsPluginHelper.DbNullIfNullOrEmpty(passMembershipno)),
                       // new SqlParameter("@NICNICOP", clsPluginHelper.DbNullIfNullOrEmpty(txtnic.Text)),
                    };
                    DataSet ds = cls_dl_Membership.Membership_PersonalInfo_Retrive(parameter);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            memberID = row["ID"].ToString();
                            lblname.Text = row["Name"].ToString();
                            LBLFATHERNAME.Text = row["Father"].ToString();
                            lblmsnumber.Text = row["MembershipNo"].ToString();
                            lblmobilenumber.Text = row["MobileNo"].ToString();
                            lblcnic.Text = row["NIC/NICOP"].ToString();
                        }
                        btnSave.Visible = true;
                      //  gbimage.Visible = true;
                        ImageSource.Visible = true;
                    }
                    else
                    {
                        btnSave.Visible = false;
                        //gbimage.Visible = false;
                        ImageSource.Visible = false;

                    }
                
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on memberverify.", ex, "frmAddImagesToMembership");
                frmobj.ShowDialog();
            }
        }
        private void txtmsno_Leave_1(object sender, EventArgs e)
        {
            memberverify();
        }

        private void btnBrowseforSingleimage_Click_1(object sender, EventArgs e)
        {
            try
            {
                //ImageName Adding
                string var = comboBox1.SelectedItem.ToString();
                clsMemberImage obj = new clsMemberImage();
                obj.ImageName = var;
                obj.Description = txtimageDescription.Text;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {

                    string[] files = openFileDialog1.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            obj.MemberImage = Image.FromFile(pngFile);
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }
                }
                ImageContainer.Add(obj);
                ImageSource.TableElement.RowHeight = 100;
                ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                //}
                //else
                //{
                //    MessageBox.Show("Please Enter the Image Description.");
                //}

                comboBox1.Text = "";
                txtimageDescription.Text = "";
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnBrowseforSingleimage_Click_1.", ex, "frmAddImagesToMembership");
                frmobj.ShowDialog();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                int count = ImageContainer.Count;
                MessageBox.Show("Total Browsed Images ==> " + count.ToString(), "Warning", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (count > 1)
                {

                    if (memberID != "0")
                    {
                        foreach (clsMemberImage row in ImageContainer)
                        {
                            MemoryStream ms = new MemoryStream();
                            row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            Byte[] Image = ms.ToArray();
                            SqlParameter[] parameters =
                            {
                                new SqlParameter("@Task", "Insert"),
                                new SqlParameter("@MemberID", memberID),
                                new SqlParameter("@ImageFile", Image),
                                new SqlParameter("@ImageName", row.ImageName),
                                new SqlParameter("@Description", row.Description),
                                new SqlParameter("@user_ID", clsUser.ID),
                            };
                            int result = cls_dl_Membership.Membership_Image_NonQuery(parameters);
                            if (result > 0)
                            {
                                lblstatusofimage.Text = "Sucessful";

                            }
                            else
                            {
                                lblstatusofimage.Text = "Unsucessful";
                            }
                        }
                        //clearing
                        this.Close();
                        ImageContainer.Clear();
                        ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSave_Click_1.", ex, "frmAddImagesToMembership");
                frmobj.ShowDialog();
            }
            //txtmemberimagename.Text = "";
            txtimageDescription.Text = "";           
            comboBox1.Text = "";
        }

        private void frmAddImagesTo_Membership_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            memberverify();
        }
    }
}
