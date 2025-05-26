using PeshawarDHASW.Helper;
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

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class frmDocPictureModify : Telerik.WinControls.UI.RadForm
    {
        public frmDocPictureModify()
        {
            InitializeComponent();
        }

        public string ApplicaitionID_ { get; set; }
        public frmDocPictureModify(string ApplicationID)
        {
            InitializeComponent();
            ApplicaitionID_ = ApplicationID;
            DataLoading(ApplicaitionID_);
        }
        private void DataLoading(string ApplicationID)
        {
            SqlParameter[] par = {
                new SqlParameter("@Task","GetDocList"),
                new SqlParameter("@ApplicationID",ApplicationID)
            };
            DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "p_Gettbl_ApplicationDocInfo", par);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DGV_ImageInfo.DataSource = ds.Tables[0].DefaultView;
                    DGVMissingDoc.DataSource = ds.Tables[1].DefaultView;
                    foreach (var item in DGV_ImageInfo.Columns)
                    {
                        item.BestFit();
                    }
                }
                else
                {
                    MessageBox.Show("No Record Found.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Connection Error");
            }
        }
        private void frmDocPictureModify_Load(object sender, EventArgs e)
        {

        }

        private void DGV_ImageInfo_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            string DocID = e.Row.Cells["DocumentTRX"].Value.ToString();
            string DocName = e.Row.Cells["DocumentType"].Value.ToString();
            if (e.Column.Name == "btnEdit")
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                //openFileDialog1.Multiselect = true;
                openFileDialog1.Filter = @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select " + DocName;
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    Image item = System.Drawing.Image.FromFile(openFileDialog1.FileName.ToString());
                    MemoryStream ms = new MemoryStream();
                    item.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                    Byte[] Image = ms.ToArray();
                    SqlParameter[] param = {
                            new  SqlParameter("@Task","GetDocUpdate"),
                            new SqlParameter("@DocID",DocID),
                            new SqlParameter("@ApplicationDoc",Image)
                    };
                    SQLHelper.ExecuteNonQuery(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "p_Gettbl_ApplicationDocInfo", param);
                    DataLoading(ApplicaitionID_);
                }
                 
            }
            else
            {
                SqlParameter[] par = {
                new SqlParameter("@Task","GetDoc"),
                new SqlParameter("@DocID",DocID)
                  };

                DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "p_Gettbl_ApplicationDocInfo", par);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        byte[] imgData = (byte[])ds.Tables[0].Rows[0]["ApplicationDoc"];
                        MemoryStream ms = new MemoryStream(imgData);
                        ms.Position = 0;
                        pb_Doc.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Connection Error");
                }
            }
           
        }
        public string ApplicationID { get; set; } = "0";
        List<ImageUploadingModel> ImageContainer = new List<ImageUploadingModel>();
        private void ImageAddtoGrid(string chkName)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Multiselect = true;
                openFileDialog1.Filter = @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select " + chkName;
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    string[] files = openFileDialog1.FileNames;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            int imageCount = ImageContainer.Count + 1;
                            ImageUploadingModel obj = new ImageUploadingModel();
                            obj.Remarks = chkName + "-" + DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                            obj.DocumentType = chkName;
                            obj.ApplicationDoc = Image.FromFile(pngFile);
                            obj.InsertBy = clsUser.Name;
                            obj.ApplicationID = int.Parse(ApplicationID);
                            obj.Status = "Active";
                            ImageContainer.Add(obj);
                        }
                        catch
                        {
                            Console.WriteLine("This is not an image file");
                        }
                        
                    }

                    //ImageSource.TableElement.RowHeight = 50;
                    //ImageSource.Columns["ApplicationDoc"].ImageLayout = ImageLayout.Stretch;
                    //ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                }
                
            }
            catch (Exception ex)
            {
            }
        }

        private void DGVMissingDoc_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                string DocID = ApplicaitionID_;// e.Row.Cells["ApplicationID"].Value.ToString();
                string DocName = e.Row.Cells["DocumentType"].Value.ToString();
                if (e.Column.Name == "UploadDoc")
                {
                    ApplicationID = DocID;
                    ImageAddtoGrid(DocName);
                    List<ImageUploadingModel_DB> DBListObj = new List<ImageUploadingModel_DB>();
                    foreach (var item in ImageContainer)
                    {
                        MemoryStream ms = new MemoryStream();
                        item.ApplicationDoc.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                        Byte[] Image = ms.ToArray();
                        ImageUploadingModel_DB obsj = new ImageUploadingModel_DB();
                        obsj.ApplicationDoc = Image;
                        obsj.ApplicationID = item.ApplicationID;
                        obsj.DocumentType = item.DocumentType;
                        obsj.InsertBy = item.InsertBy;

                        obsj.Remarks = item.Remarks;
                        obsj.Status = item.Status;
                        DBListObj.Add(obsj);
                    }
                    DataTable dt = clsPluginHelper.ToDataTable(DBListObj);
                    SqlParameter[] param = {
                         new SqlParameter() { ParameterName= "@TT_Image", SqlDbType=SqlDbType.Structured, Value= dt,Direction = ParameterDirection.Input,TypeName="dbo.TT_ImageUploading" },
                         new SqlParameter("@ApplicationStatus","Complete"),
                         new SqlParameter("@Remarks",DocName+" Uploaded")
                    };
                    int result = Helper.SQLHelper.ExecuteNonQuery(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "tbl_ApplicationImageUpload", param);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }


}
