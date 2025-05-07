using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.IN_OUT_Mail
{
    public partial class OutgoingMailNew : Telerik.WinControls.UI.RadForm
    {
        public OutgoingMailNew()
        {
            InitializeComponent();
        }
        List<clsMemberImage> ImageContainer = new List<clsMemberImage>();
        private void btnBrowseforSingleimage_Click(object sender, EventArgs e)
        {
            try
            {
                int imageCount = ImageContainer.Count() + 1;
                clsMemberImage obj = new clsMemberImage();
                obj.ImageName = DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                obj.Description = "Attachment with DD Transfer.";

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
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
                    ImageContainer.Add(obj);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ImageSource_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnRemove")
            {
                try
                {
                    ImageContainer.RemoveAt(e.RowIndex);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["MemberImage"].ImageLayout = ImageLayout.Stretch;
                    ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                    if (ImageContainer.Count == 0)
                        ImageSource.DataSource = null;
                }
                catch (Exception)
                {
                    ImageSource.DataSource = null;
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtLetterNo.Text))
                {
                    MessageBox.Show("Receive Date is Mandatory.");
                    return;
                }
                if (dtpForwardDate.Value.Date == null)
                {
                    MessageBox.Show("Receive Date is Mandatory.");
                    return;
                }
                SqlParameter[] param = {
                    new SqlParameter("@Task","OutgoingSave"),
                    new SqlParameter("@FileNo",txtFileNo.Text),
                    new SqlParameter("@DiaryNo",lblDiaryNo.Text),
                    new SqlParameter("@LtrNo",txtLetterNo.Text),
                    new SqlParameter("@Date_FileNo",dtpForwardDate.Value.Date),
                    new SqlParameter("@ToWhomFwd",txtFromWhomFwd.Text),
                     new SqlParameter("@ReceivedBy",txtReceivedby.Text),
                    new SqlParameter("@Subj",txtSubject.Text),
                    new SqlParameter("@Remarks",txtRemarks.Text),
                    new SqlParameter("@Createdby",clsUser.ID),
                    new SqlParameter("@CreatedDate",DateTime.Now),
                    new SqlParameter("@Status","Active"),
                };
                string outGoingID = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_Outgoing_mail", param).ToString();
                if (!string.IsNullOrWhiteSpace(outGoingID))
                {

                    try
                    {
                        foreach (clsMemberImage row in ImageContainer)
                        {
                            MemoryStream ms = new MemoryStream();
                            row.MemberImage.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            Byte[] Image = ms.ToArray();
                            SqlParameter[] parameters =
                            {
                                        new SqlParameter("@Task", "Insert"),
                                        new SqlParameter("@OutgoingID", outGoingID),
                                        new SqlParameter("@ImageFile", Image),
                                        new SqlParameter("@ImageName", row.ImageName),
                                        new SqlParameter("@Description", row.Description),
                                        new SqlParameter("@user_ID", clsUser.ID),
                                         };
                            int result = Helper.SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_tbl_OutgoingMail",
                                                    parameters
                                                    );

                        }
                        ImageContainer.Clear();
                        ImageSource.DataSource = null;

                    }
                    catch (Exception rc)
                    {
                    }
                    MessageBox.Show("Change Save Sucessfull");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Something invalid.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
