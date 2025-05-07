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

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class frmDocumentUpload : Telerik.WinControls.UI.RadForm
    {
        public frmDocumentUpload()
        {
            InitializeComponent();
        }
        public string ApplicationID { get; set; } = "0";
        List<ImageUploadingModel> ImageContainer = new List<ImageUploadingModel>();
        private bool ImageAddtoGrid( CheckBox chkName)
        {
            bool FileStatus = false;
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Multiselect = true;
                openFileDialog1.Filter = @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select "+ chkName.Text;
                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                { 
                    string[] files = openFileDialog1.FileNames;
                    if (files.Length == 2)
                    {
                        FileStatus = true;
                        foreach (var pngFile in files)
                        {
                            try
                            {
                                int imageCount = ImageContainer.Count() + 1;
                                ImageUploadingModel obj = new ImageUploadingModel();
                                obj.Remarks = chkName.Text + "-" + DateTime.Now.ToString("yyyyMMdd") + "_" + imageCount;
                                obj.DocumentType = chkName.Text;
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
                            if (files.Length == 0)
                            { chkName.CheckState = CheckState.Unchecked; }
                        }

                        ImageSource.TableElement.RowHeight = 50;
                        ImageSource.Columns["ApplicationDoc"].ImageLayout = ImageLayout.Stretch;
                        ImageSource.DataSource = ImageContainer.DefaultIfEmpty();
                    }
                    else
                    {
                        chkName.CheckState = CheckState.Unchecked;
                        FileStatus = false;
                        MessageBox.Show("Please Upload the Document Both Side.");
                    }
                
                }
                
                if (dr == System.Windows.Forms.DialogResult.Cancel)
                {
                    chkName.CheckState = CheckState.Unchecked; 
                }
            }
            catch (Exception ex)
            {
            }
            return FileStatus;
        }


        private void ImageSource_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btnRemove")
            {
                try
                {
                    ImageContainer.RemoveAt(e.RowIndex);
                    ImageSource.TableElement.RowHeight = 50;
                    ImageSource.Columns["ApplicationDoc"].ImageLayout = ImageLayout.Stretch;
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

        private void UncheckAllBox()
        {
            ckform.CheckState = CheckState.Unchecked;
            chkCNIC.CheckState = CheckState.Unchecked;
            chkDischargeorRetirement.CheckState = CheckState.Unchecked;
            chkNICOP.CheckState = CheckState.Unchecked;
            chkPassport.CheckState = CheckState.Unchecked;
            chkServiceCertificate.CheckState = CheckState.Unchecked;
            chkDischargeorRetirement.CheckState = CheckState.Unchecked;
            form = true;
            CNIC = true;
            DischargeorRetirement = true;
            NICOP = true;
            Passport = true;
            ServiceCertificate = true;
            Dischargeor_Retirement = true;
        }

        public string  FormCategory { get; set; }
        private void btnFind_Click(object sender, EventArgs e)
        {
            gbCheckList.Enabled = false;
            gb_DocumentUpload.Enabled = false;
            if (!string.IsNullOrWhiteSpace(txtFormNo.Text) | !string.IsNullOrEmpty(txtFormNo.Text))
            {
                ImageContainer.Clear();
                ImageSource.DataSource = null;
                UncheckAllBox();

                try
                {
                    SqlParameter[] param = {
                new SqlParameter("@FormNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFormNo.Text))
            };
                    DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.p_Gettbl_ApplicationFeeInfo_Complete", param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ApplicationID = ds.Tables[0].Rows[0]["ApplicationID"].ToString();
                            string Category = ds.Tables[0].Rows[0]["Catergory"].ToString();
                            FormCategory = Category;
                            ChkDocumentControl(Category);
                            gbCheckList.Enabled = true;
                            gb_DocumentUpload.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Form No: " + txtFormNo.Text + " is pending in Fin Branch for Fee Clearnce. Or Check the Form No.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Enter a Valid Form No.");
            }
          
        }
        public bool form { get; set; }
        public bool CNIC { get; set; }
        public bool DischargeorRetirement { get; set; }
        public bool NICOP { get; set; }
        public bool Passport { get; set; }
        public bool ServiceCertificate { get; set; }
        public bool Dischargeor_Retirement { get; set; }

        private void ChkDocumentControl(string Category)
        {

            /*
            General Public
            Serving /Retd Armed Forces Persons
            Overseas Pakistanis
            Govt/Semi Employees
            Senior Citizens (above 65 years of age)
            Civilians Paid out Defence Estimates
            */
            if (Category == "General Public")
            {
                form = true;
                CNIC = true;

                chkCNIC.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = false;
                chkPassport.Enabled = false;
                chkServiceCertificate.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
                
            }
            else if (Category == "Overseas Pakistanis")
            {
                form = true;
                NICOP = true;
                Passport = true;

                chkCNIC.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = true;
                chkPassport.Enabled = true;
                chkServiceCertificate.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
            }
            else if (Category == "Serving /Retd Armed Forces Persons")
            {
                form = true;
                CNIC = true;
                ServiceCertificate = true;

                chkCNIC.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = false;
                chkPassport.Enabled = false;
                chkServiceCertificate.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
            }
            else if (Category == "Govt/Semi Employees")
            {
                form = true;
                CNIC = true;
                ServiceCertificate = true;

                chkCNIC.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = false;
                chkPassport.Enabled = false;
                chkServiceCertificate.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
            }
            else if (Category == "Civilians Paid out Defence Estimates")
            {
                form = true;
                CNIC = true;
                Dischargeor_Retirement = true;

                chkCNIC.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = false;
                chkPassport.Enabled = false;
                chkServiceCertificate.Enabled = false;
                chkDischargeorRetirement.Enabled = true;
            }
            else if (Category == "Senior Citizens (abvoce 65 years of age)")
            {
                form = true;
                CNIC = true;

                chkCNIC.Enabled = true;
                chkDischargeorRetirement.Enabled = false;
                chkNICOP.Enabled = false;
                chkPassport.Enabled = false;
                chkServiceCertificate.Enabled = false;
                chkDischargeorRetirement.Enabled = false;
            }
            else
            {
                MessageBox.Show("Invalid Category");
            }
        }

     
        private bool FileValid(string Category)
        {
            bool status = false;
            if (Category == "General Public")
            {
                if (form == true | CNIC == true)
                    status = true;
            }
            else if (Category == "Overseas Pakistanis")
            {
                if (form == true || NICOP == true || Passport == true)
                    status = true;
            }
            else if (Category == "Serving /Retd Armed Forces Persons")
            {
                if (form == true | CNIC == true | ServiceCertificate == true)
                    status = true;
            }
            else if (Category == "Govt/Semi Employees")
            {
                if (form == true | CNIC == true | ServiceCertificate == true)
                    status = true;
            }
            else if (Category == "Civilians Paid out Defence Estimates")
            {
                if (form == true| CNIC == true| Dischargeor_Retirement == true)
                    status = true;
            }
            else if (Category == "Senior Citizens (above 65 years of age)")
            {
                if (form == true | CNIC == true)
                    status= true;
            }
            else
            {
                status= false;
            }
            return status;
        }


        #region Chk List Verification
        private void chkCNIC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCNIC.CheckState == CheckState.Checked)
            {
               bool status = ImageAddtoGrid(chkCNIC);
              CNIC = status;
              
            }
        }

        private void chkPassport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassport.CheckState == CheckState.Checked)
            {
                bool status = ImageAddtoGrid(chkPassport);
                Passport = status;
            }   
        }

        private void chkNICOP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNICOP.CheckState == CheckState.Checked)
            {
                bool status = ImageAddtoGrid(chkNICOP);
               NICOP = status;
            }
        }

        private void chkServiceCertificate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkServiceCertificate.CheckState == CheckState.Checked)
            {
                bool status = ImageAddtoGrid(chkServiceCertificate);
                ServiceCertificate = status;
            }
        }

        private void chkDischargeorRetirement_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDischargeorRetirement.CheckState == CheckState.Checked)
            {
               bool status = ImageAddtoGrid(chkDischargeorRetirement);
                Dischargeor_Retirement = status;
            }
        }
        #endregion

        private void btnSaveImages_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtremarks.Text) | !string.IsNullOrEmpty(txtremarks.Text))
            {
                if (MessageBox.Show("Verify All the Image is Attach to the Form is Correct.", "Attention Confirm the Attachment before Saving.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string ApplicationStatus = "";
                    if (FileValid(FormCategory))
                    {
                        ApplicationStatus = "Complete";
                    }
                    else
                    {
                        ApplicationStatus = "Review";
                    }
                  
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
                         new SqlParameter("@ApplicationStatus",ApplicationStatus),
                         new SqlParameter("@Remarks",txtremarks.Text)
                    };
                    int result = Helper.SQLHelper.ExecuteNonQuery(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "tbl_ApplicationImageUpload", param);
                  
                    MessageBox.Show((result-1).ToString() + " Image are Attached with Form No"+txtFormNo.Text);
                    ImageContainer.Clear();
                    ImageSource.DataSource = null;
                    UncheckAllBox();
                    gb_DocumentUpload.Enabled = false; gbCheckList.Enabled = false;
                    txtFormNo.Text =string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Remarks Field empty. Please fill the remarks field.");
            }
        }

        private void btnforwardto_Observationteam_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!string.IsNullOrEmpty(txtremarks.Text) | !string.IsNullOrEmpty(txtremarks.Text))
                {
                    if (MessageBox.Show("Verification the Check List is All the Image is Attach to the Form or Not.", "Attention Confirm the Attachment before Saving.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
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
                         new SqlParameter() { ParameterName= "@TT_Image", SqlDbType=SqlDbType.Structured, Value= dt,Direction = ParameterDirection.Input },
                         new SqlParameter("@ApplicationStatus","Review"),
                         new SqlParameter("@Remarks",txtremarks.Text)
                    };
                        string totalrecord = Helper.SQLHelper.ExecuteNonQuery(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "tbl_ApplicationImageUpload", param).ToString();
                        MessageBox.Show(totalrecord + " Image are Attached with Form No" + txtFormNo.Text);
                        ImageContainer.Clear();
                        ImageSource.DataSource = null;
                        UncheckAllBox();
                        txtFormNo.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Remarks Field empty. Please fill the remarks field.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void frmDocumentUpload_Load(object sender, EventArgs e)
        {

        }

        private void ckform_CheckedChanged(object sender, EventArgs e)
        {
            if (ckform.CheckState == CheckState.Checked)
            {
               bool status = ImageAddtoGrid(ckform);
                form = status;
            }
        }
    }

    public class ImageUploadingModel
    {
        public int ApplicationID { get; set; }
        public string  DocumentType { get; set; }
        public Image ApplicationDoc { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string InsertBy { get; set; }

    }

    public class ImageUploadingModel_DB
    {
        public int ApplicationID { get; set; }
        public string DocumentType { get; set; }
        public byte[] ApplicationDoc { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string InsertBy { get; set; }

    }
}
