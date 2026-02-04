using PeshawarDHASW.Data_Layer.clsAuthorizeDealer;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.AuthorizedDealer
{
    public partial class frmNewPropertyDealerRegistration : Telerik.WinControls.UI.RadForm
    {
        public frmNewPropertyDealerRegistration()
        {
            InitializeComponent();
        }
        string ftpServerIP;
        string ftpUserID;
        string ftpPassword;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        OpenFileDialog openFileDialog2 = new OpenFileDialog();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateRegNo() && ValidateBuisinessTitle() && ValidateDisplaySeq() && ValidateBuisinessAddress() )
            {
                #region code
                string dn1 = ""; string dn2 = ""; string dn3 = ""; string dn4 = ""; string dn5 = "";
                string cnicno1 = ""; string cnicno2 = ""; string cnicno3 = ""; string cnicno4 = ""; string cnicno5 = "";
                string contno1 = ""; string contno2 = ""; string contno3 = ""; string contno4 = ""; string contno5 = "";
                string emaddress1 = ""; string emaddress2 = ""; string emaddress3 = ""; string emaddress4 = ""; string emaddress5 = "";

                int gridrowCount = grddealerdata.Rows.Count;
                for (int i = 0; i < gridrowCount; i++)
                {
                    if (i == 0)
                    {
                        dn1 = Convert.ToString(grddealerdata.Rows[i].Cells["dealername"].Value);
                        cnicno1 = Convert.ToString(grddealerdata.Rows[i].Cells["cnicno"].Value);
                        contno1 = Convert.ToString(grddealerdata.Rows[i].Cells["contactno"].Value);
                        emaddress1 = Convert.ToString(grddealerdata.Rows[i].Cells["emailaddress"].Value);
                    }
                    else if (i == 1)
                    {
                        dn2 = Convert.ToString(grddealerdata.Rows[i].Cells["dealername"].Value);
                        cnicno2 = Convert.ToString(grddealerdata.Rows[i].Cells["cnicno"].Value);
                        contno2 = Convert.ToString(grddealerdata.Rows[i].Cells["contactno"].Value);
                        emaddress2 = Convert.ToString(grddealerdata.Rows[i].Cells["emailaddress"].Value);
                    }
                    else if (i == 2)
                    {
                        dn3 = Convert.ToString(grddealerdata.Rows[i].Cells["dealername"].Value);
                        cnicno3 = Convert.ToString(grddealerdata.Rows[i].Cells["cnicno"].Value);
                        contno3 = Convert.ToString(grddealerdata.Rows[i].Cells["contactno"].Value);
                        emaddress3 = Convert.ToString(grddealerdata.Rows[i].Cells["emailaddress"].Value);
                    }
                    else if (i == 3)
                    {
                        dn4 = Convert.ToString(grddealerdata.Rows[i].Cells["dealername"].Value);
                        cnicno4 = Convert.ToString(grddealerdata.Rows[i].Cells["cnicno"].Value);
                        contno4 = Convert.ToString(grddealerdata.Rows[i].Cells["contactno"].Value);
                        emaddress4 = Convert.ToString(grddealerdata.Rows[i].Cells["emailaddress"].Value);
                    }
                    else if (i == 4)
                    {
                        dn5 = Convert.ToString(grddealerdata.Rows[i].Cells["dealername"].Value);
                        cnicno5 = Convert.ToString(grddealerdata.Rows[i].Cells["cnicno"].Value);
                        contno5 = Convert.ToString(grddealerdata.Rows[i].Cells["contactno"].Value);
                        emaddress5 = Convert.ToString(grddealerdata.Rows[i].Cells["emailaddress"].Value);
                    }

                }
                string imgpath = "";
                string logopath = "";
                try
                {
                    #region Save Dealer Image
                    //// Save Dealer Image
                    string iName = openFileDialog1.FileName;
                    string folder = clsMostUseVars.applicationstartuppath + "\\Images\\";
                    //string folder = @"E:\Muhammad_Abdul_Jalil\TFS\DHAPeshawarSW\DHASW1\PeshawarDHASW\Images\";
                    var path = Path.Combine(folder, Path.GetFileName(iName));
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    File.Copy(iName, path, true);

                    //pbdealerImage.Image.Save(path, ImageFormat.Jpeg);

                    imgpath = path;
                    #endregion
                    #region Save Buisiness Logo
                    //// Save Buisiness Logo
                    string iNamel = openFileDialog1.FileName;
                    string folderl = clsMostUseVars.applicationstartuppath + "\\Images\\";
                    var pathl = Path.Combine(folderl, Path.GetFileName(iNamel));
                    if (!Directory.Exists(folderl))
                    {
                        Directory.CreateDirectory(folderl);
                    }
                    File.Copy(iNamel, pathl, true);
                    logopath = pathl;
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                SqlParameter[] prm =
                {
                new SqlParameter("@Task","InsertNewPropertyDealer"),
                new SqlParameter("@RegnNo",txtregno.Text),
                new SqlParameter("@RegistrationDate",regdate.Value),
                new SqlParameter("@BussinessTitle",txtbuisinesstitle.Text),
                new SqlParameter("@Remarks",txtRemarks.Text),
                new SqlParameter("@DisplaySeq",txtdisplayseq.Text),
                new SqlParameter("@BussinessAddress",txtbuisinessaddress.Text),
                new SqlParameter("@Pic1",imgpath),
                new SqlParameter("@BusinessLogo",logopath),
                new SqlParameter("@DealerName1",dn1==""?null:dn1),new SqlParameter("@DealerName2",dn2==""?null:dn2),new SqlParameter("@DealerName3",dn3==""?null:dn3),
                new SqlParameter("@DealerName4",dn4==""?null:dn4),new SqlParameter("@DealerName5",dn5==""?null:dn5),
                new SqlParameter("@CNICNo1",cnicno1==""?null:cnicno1),new SqlParameter("@CNICNo2",cnicno2==""?null:cnicno2),new SqlParameter("@CNICNo3",cnicno3==""?null:cnicno3),
                new SqlParameter("@CNICNo4",cnicno4==""?null:cnicno4),new SqlParameter("@CNICNo5",cnicno5==""?null:cnicno5),
                new SqlParameter("@ContactNumber1",contno1==""?null:contno1),new SqlParameter("@ContactNumber2",contno2==""?null:contno2),new SqlParameter("@ContactNumber3",contno3==""?null:contno3),
                new SqlParameter("@ContactNumber4",contno4==""?null:contno4),new SqlParameter("@ContactNumber5",contno5==""?null:contno5),
                new SqlParameter("@EmailAddress1",emaddress1==""?null:emaddress1),new SqlParameter("@EmailAddress2",emaddress2==""?null:emaddress2),new SqlParameter("@EmailAddress3",emaddress3==""?null:emaddress3),
                new SqlParameter("@CreatedBy",Models.clsUser.ID)
                };
                int rslt = cls_dl_AuthorizeDealer.AuthorizeDealer_Local_NonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Insertion Successfull.");
                }
                #endregion
            }

        }
        private void btndimg_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.Filter =
            @"Images
            (*.BMP;*.JPEG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                pbdealerImage.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
        private void btnDlogo_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter =
            @"Images
            (*.BMP;*.JPEG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            openFileDialog2.Title = "Select Photos";
            DialogResult dr = openFileDialog2.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                pbBuisinesslogo.Image = new Bitmap(openFileDialog2.FileName);
            }
        }
        private void btnsaveinWebsite_Click(object sender, EventArgs e)
        {
            #region code
            try
            {

                Upload(openFileDialog1.FileName);
                Upload(openFileDialog2.FileName);

                #region Code 
                string dn1 = ""; string dn2 = ""; string dn3 = ""; string dn4 = ""; string dn5 = "";
                string cnicno1 = ""; string cnicno2 = ""; string cnicno3 = ""; string cnicno4 = ""; string cnicno5 = "";
                string contno1 = ""; string contno2 = ""; string contno3 = ""; string contno4 = ""; string contno5 = "";
                string emaddress1 = ""; string emaddress2 = ""; string emaddress3 = ""; string emaddress4 = ""; string emaddress5 = "";

                int gridrowCount = grddealerdata.Rows.Count;
                for (int i = 0; i < gridrowCount; i++)
                {
                    if (i == 0)
                    {
                        dn1 = Convert.ToString(grddealerdata.Rows[i].Cells["dealername"].Value);
                        cnicno1 = Convert.ToString(grddealerdata.Rows[i].Cells["cnicno"].Value);
                        contno1 = Convert.ToString(grddealerdata.Rows[i].Cells["contactno"].Value);
                        emaddress1 = Convert.ToString(grddealerdata.Rows[i].Cells["emailaddress"].Value);
                    }
                    else if (i == 1)
                    {
                        dn2 = Convert.ToString(grddealerdata.Rows[i].Cells["dealername"].Value);
                        cnicno2 = Convert.ToString(grddealerdata.Rows[i].Cells["cnicno"].Value);
                        contno2 = Convert.ToString(grddealerdata.Rows[i].Cells["contactno"].Value);
                        emaddress2 = Convert.ToString(grddealerdata.Rows[i].Cells["emailaddress"].Value);
                    }
                    else if (i == 2)
                    {
                        dn3 = Convert.ToString(grddealerdata.Rows[i].Cells["dealername"].Value);
                        cnicno3 = Convert.ToString(grddealerdata.Rows[i].Cells["cnicno"].Value);
                        contno3 = Convert.ToString(grddealerdata.Rows[i].Cells["contactno"].Value);
                        emaddress3 = Convert.ToString(grddealerdata.Rows[i].Cells["emailaddress"].Value);
                    }
                    else if (i == 3)
                    {
                        dn4 = Convert.ToString(grddealerdata.Rows[i].Cells["dealername"].Value);
                        cnicno4 = Convert.ToString(grddealerdata.Rows[i].Cells["cnicno"].Value);
                        contno4 = Convert.ToString(grddealerdata.Rows[i].Cells["contactno"].Value);
                        emaddress4 = Convert.ToString(grddealerdata.Rows[i].Cells["emailaddress"].Value);
                    }
                    else if (i == 4)
                    {
                        dn5 = Convert.ToString(grddealerdata.Rows[i].Cells["dealername"].Value);
                        cnicno5 = Convert.ToString(grddealerdata.Rows[i].Cells["cnicno"].Value);
                        contno5 = Convert.ToString(grddealerdata.Rows[i].Cells["contactno"].Value);
                        emaddress5 = Convert.ToString(grddealerdata.Rows[i].Cells["emailaddress"].Value);
                    }

                }
                string imgpath = "";
                string logopath = "";


                SqlParameter[] prm =
                {
                new SqlParameter("@Task","InsertNewPropertyDealer"),
                new SqlParameter("@RegnNo",txtregno.Text),
                new SqlParameter("@RegistrationDate",regdate.Value),
                new SqlParameter("@BussinessTitle",txtbuisinesstitle.Text),
                new SqlParameter("@Remarks",txtRemarks.Text),
                new SqlParameter("@DisplaySeq",txtdisplayseq.Text),
                new SqlParameter("@BussinessAddress",txtbuisinessaddress.Text),
                new SqlParameter("@Pic1",Path.GetFileName(openFileDialog1.FileName)),
                new SqlParameter("@BusinessLogo",Path.GetFileName(openFileDialog2.FileName)),
                new SqlParameter("@DealerName1",dn1==""?null:dn1),new SqlParameter("@DealerName2",dn2==""?null:dn2),new SqlParameter("@DealerName3",dn3==""?null:dn3),
                new SqlParameter("@DealerName4",dn4==""?null:dn4),new SqlParameter("@DealerName5",dn5==""?null:dn5),
                new SqlParameter("@CNICNo1",cnicno1==""?null:cnicno1),new SqlParameter("@CNICNo2",cnicno2==""?null:cnicno2),new SqlParameter("@CNICNo3",cnicno3==""?null:cnicno3),
                new SqlParameter("@CNICNo4",cnicno4==""?null:cnicno4),new SqlParameter("@CNICNo5",cnicno5==""?null:cnicno5),
                new SqlParameter("@ContactNumber1",contno1==""?null:contno1),new SqlParameter("@ContactNumber2",contno2==""?null:contno2),new SqlParameter("@ContactNumber3",contno3==""?null:contno3),
                new SqlParameter("@ContactNumber4",contno4==""?null:contno4),new SqlParameter("@ContactNumber5",contno5==""?null:contno5),
                new SqlParameter("@EmailAddress1",emaddress1==""?null:emaddress1),new SqlParameter("@EmailAddress2",emaddress2==""?null:emaddress2),new SqlParameter("@EmailAddress3",emaddress3==""?null:emaddress3),
                new SqlParameter("@CreatedBy",Models.clsUser.ID)
                };
                int rslt = cls_dl_AuthorizeDealer.AuthorizeDealer_Web_NonQuery(prm);
                if (rslt > 0)
                {
                    MessageBox.Show("Insertion Successfull.");
                }
                #endregion


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            #endregion
        }
        private void Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            //string uri = ftpServerIP + "/dhapeshawarorg/content/web/img/list_for_website_files/" + fileInf.Name;
            string uri = ftpServerIP +"/"+ fileInf.Name;
            FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            ServicePoint sp = reqFTP.ServicePoint;
            // reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
            // reqFTP.EnableSsl = true;
            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }
        private void frmNewPropertyDealerRegistration_Load(object sender, EventArgs e)
        {
            ftpServerIP = "ftp://ftp.site4now.net";
            //ftpUserID = "dhapeshawar-001";   propertydealerimages
            //ftpPassword = "Samsung@831";
            ftpUserID = "propertydealerimages";
            ftpPassword = "dhapeshawar@2019pd";
        }
        private void txtregno_Validating(object sender, CancelEventArgs e)
        {
            ValidateRegNo();
        }
        private bool ValidateRegNo()
        {
            bool bStatus = true;
            if (txtregno.Text == "")
            {
                errorProvider1.SetError(txtregno, "Please enter Registration No.");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtregno, "");
            return bStatus;
        }
        private void txtbuisinesstitle_Validating(object sender, CancelEventArgs e)
        {
            ValidateBuisinessTitle();
        }
        private bool ValidateBuisinessTitle()
        {
            bool bStatus = true;
            if (txtbuisinesstitle.Text == "")
            {
                errorProvider1.SetError(txtbuisinesstitle, "Please enter Buisiness Title.");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtbuisinesstitle, "");
            return bStatus;
        }
        private void txtdisplayseq_Validating(object sender, CancelEventArgs e)
        {
            ValidateDisplaySeq();
        }
        private bool ValidateDisplaySeq()
        {
            bool bStatus = true;
            if (txtdisplayseq.Text == "")
            {
                errorProvider1.SetError(txtdisplayseq, "Please enter Display Sequence.");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtdisplayseq, "");
            return bStatus;
        }
        private void txtbuisinessaddress_Validating(object sender, CancelEventArgs e)
        {
            ValidateBuisinessAddress();
        }
        private bool ValidateBuisinessAddress()
        {
            bool bStatus = true;
            if (txtbuisinessaddress.Text == "")
            {
                errorProvider1.SetError(txtbuisinessaddress, "Please enter Buisiness Address.");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtbuisinessaddress, "");
            return bStatus;
        }
    }
}
