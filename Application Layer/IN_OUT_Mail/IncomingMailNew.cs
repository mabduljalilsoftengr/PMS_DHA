using PeshawarDHASW.Helper;
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
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.IN_OUT_Mail
{
    public partial class IncomingMailNew : Telerik.WinControls.UI.RadForm
    {
        public IncomingMailNew()
        {
            InitializeComponent();
        }

       
        private void DataViewing(string DiaryNo)
        {
            SqlParameter[] param = {
                new SqlParameter("@Task","IncomingMailSingle"),
                  new SqlParameter("@DiaryNo",DiaryNo)
            };
            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.Incoming_mail", param);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    lblDiaryNo.Text = ds.Tables[0].Rows[0]["DiaryNo"].ToString();
                    txtLetterNo.Text = ds.Tables[0].Rows[0]["LtrNo"].ToString();
                    dtpReceiveDate.Value =  DateTime.Parse(ds.Tables[0].Rows[0]["ReceivedDate"].ToString());
                    txtLetterName.Text = ds.Tables[0].Rows[0]["Date_FileNo"].ToString();
                    txtFromWhomReceived.Text = ds.Tables[0].Rows[0]["FromWhomReceived"].ToString();
                    txtSubject.Text = ds.Tables[0].Rows[0]["Subj"].ToString();
                    txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }
            }
        }

        private void IncomingMailNew_Load(object sender, EventArgs e)
        {
           // dtpReceiveDate.NullDate = DateTime.Now; 
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
                if (dtpReceiveDate.Value.Date == null)
                {
                    MessageBox.Show("Receive Date is Mandatory.");
                    return;
                }
                SqlParameter[] param = {
                    new SqlParameter("@Task","IncomingMailInsert"),
                    new SqlParameter("@DiaryNo",lblDiaryNo.Text),
                    new SqlParameter("@ReceivedDate",dtpReceiveDate.Value.Date),
                    new SqlParameter("@LtrNo",txtLetterNo.Text),
                    new SqlParameter("@Date_FileNo",txtLetterName.Text),
                    new SqlParameter("@FromWhomReceived",txtFromWhomReceived.Text),
                    new SqlParameter("@Subj",txtSubject.Text),
                    new SqlParameter("@Remarks",txtRemarks.Text),
                    new SqlParameter("@Createdby",clsUser.ID),
                    new SqlParameter("@CreatedDate",DateTime.Now),
                    new SqlParameter("@Status","Active"),
                };
               string IncomingID = Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.Incoming_mail", param).ToString();
                if (!string.IsNullOrWhiteSpace(IncomingID))
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
                                        new SqlParameter("@IncomingID", IncomingID),
                                        new SqlParameter("@ImageFile", Image),
                                        new SqlParameter("@ImageName", row.ImageName),
                                        new SqlParameter("@Description", row.Description),
                                        new SqlParameter("@user_ID", clsUser.ID),
                                         };
                            int result = Helper.SQLHelper.ExecuteNonQuery(
                                                    clsMostUseVars.VerifiedImageConnectionstring,
                                                    CommandType.StoredProcedure,
                                                    "usp_tbl_IncomingMail",
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
    }
}
