using iTextSharp.text;
using iTextSharp.text.pdf;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Image_Archiving
{
    public partial class frmBulkFileUpload : Telerik.WinControls.UI.RadForm
    {
        

        public string ImageArchServerIP { get; set; }
        public string ImageArchUsername { get; set; } = clsUser.Name;
        public string ImageArchPassword { get; set; }
        public string PredefinePath_DataUploading { get; set; }
        public string ImageArchID { get; set; }
        public int Progressvalue { get; set; }
        public frmBulkFileUpload()
        {
            InitializeComponent();
            ImageArchServerIP = ConfigurationSettings.AppSettings.Get("FTPServerIP");
            ImageArchUsername = ConfigurationSettings.AppSettings.Get("Username");
            ImageArchPassword = ConfigurationSettings.AppSettings.Get("Password");
            PredefinePath_DataUploading = ConfigurationSettings.AppSettings.Get("PredefinePath_DataUploading");
        }

        public void CreateAppSettings(string sectionName, string key, string value)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings[key].Value = value;
                configuration.Save();
                ConfigurationManager.RefreshSection(sectionName);
            }
            catch (ConfigurationErrorsException exception)
            {
                Console.WriteLine("[CreateAppSettings: {0}]", exception.ToString());
                Console.WriteLine();
            }
        }

        #region Running Time Update Control

        public delegate void delLwActivityLog(int index, string line);
        public delegate void delStatusActivityLog(string line);
        //public void LwActivityLog(int index, string line)
        //{
        //    if (this.dgvActivityLog.InvokeRequired)
        //    {
        //        delLwActivityLog dfw = new delLwActivityLog(LwActivityLog);
        //        this.Invoke(dfw, new object[] { index, line });
        //        return;
        //    }
        //    ListViewItem lvi = new ListViewItem();
        //    lvi.Text = index.ToString();
        //    lvi.SubItems.Add(line);
        //    dgvActivityLog.Items.Add(lvi);
        //    dgvActivityLog.Refresh();
        //}

        public void LwActivityLog(int index, string line)
        {
            if (this.radListView1.InvokeRequired)
            {
                delLwActivityLog dfw = new delLwActivityLog(LwActivityLog);
                this.Invoke(dfw, new object[] { index, line });
                return;
            }
            ListViewDataItem lvi = new ListViewDataItem();
            lvi.SubItems.Add(index.ToString());
            lvi.SubItems.Add(line);
            radListView1.Items.Add(lvi);
            radListView1.Refresh();
            radListView1.ListViewElement.ViewElement.Scroller.ScrollToItem(radListView1.Items[radListView1.Items.Count-1]);
        }
        public void writeStatusLabel(string line)
        {
            if (this.lblStatus.InvokeRequired)
            {
                delStatusActivityLog dfw = new delStatusActivityLog(writeStatusLabel);
                this.Invoke(dfw, new object[] { line });
                return;
            }
            lblStatus.Text = line;
            lblStatus.Refresh();
        }

        #endregion


        private void DirectoryExistingCheck(string DirectoryPath)
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
                return;
            }
            else
            {
                Console.WriteLine("Diriectory Exist");
                return;
            }

        }

        private void UploadingData()
        {
            try
            {
                delLwActivityLog delwActivitylog = new delLwActivityLog(LwActivityLog);
                string folderName = @clsMostUseVars.applicationstartuppath + @"\FileInfo\";
                string str2 = @clsMostUseVars.applicationstartuppath + @"\InputDoc\";
                string output = @clsMostUseVars.applicationstartuppath + @"\OutputDoc\";
                string str4 = @clsMostUseVars.applicationstartuppath + @"\MergedDoc\";
                DirectoryExistingCheck(folderName);
                DirectoryExistingCheck(str2);
                DirectoryExistingCheck(output);
                DirectoryExistingCheck(str4);


                string[] files = Directory.GetFiles(this.PredefinePath_DataUploading + @"\" + DateTime.Now.ToString("dd-MM-yyyy"));
                DriveInfo drive = new DriveInfo(PredefinePath_DataUploading);
                string UploadFileMovelocation = @drive.Name + "ScannedDocUploaded";
                DirectoryExistingCheck(UploadFileMovelocation);

                int No = 0;
                if (files.Length != 0)
                {
                    foreach (string str5 in files)
                    {
                        writeStatusLabel("Please Wait Loading is in progress.");
                        delwActivitylog(No,"File Selected:-> "+ str5);

                        string password = "dhapeshawar";//clsPluginHelper.RandomPassword();
                        FileInfo info = new FileInfo(str5);
                        string name = info.Name;
                        string[] textArray1 = new string[] { "_", clsUser.Name, "_", DateTime.Now.ToString("ddMMyyyy-HHmmssfffffff"), ".PDF" };
                        string str8 = name.Replace(".PDF", string.Concat(textArray1));
                        string destFileName = folderName + str8;
                        System.IO.File.Copy(str5, destFileName);
                        //file Copy Move to Origional Data
                        UploadFileToFtp(this.ImageArchServerIP + "/OrigionalFileData/", destFileName, this.ImageArchUsername, this.ImageArchPassword);
                        delwActivitylog(No, "Origional Data Copied to Server ->"+ destFileName);
                        char[] separator = new char[] { '_' };
                        string[] strArray3 = name.Split(separator);
                        string str10 = strArray3[0].Replace('-', '/');
                        string str11 = strArray3[1];
                        SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Task", "MembershipFinder"), new SqlParameter("@FileNo", str10), new SqlParameter("@Membership", str11) };
                        DataSet set = SQLHelper.ExecuteDataset(PMS_Setting.MainConnections.ConnectionString_ImageArchive, CommandType.StoredProcedure, "USP_MembershipConfrim", commandParameters);
                        if (set.Tables.Count <= 0)
                        {
                            delwActivitylog(No, "FileNo->" + str10+"---- MembershipNo:"+str11+" Issue Fields.");
                            MessageBox.Show("Check the FileNo and Membership Fields. FileNo" + str10 + "Membership No:" + str11);
                            break;
                        }
                        delwActivitylog(No, "FileNo -->" + str10 + " ---> MembershipNo:" + str11 +"--> Verification");
                        SqlParameter[] parameterArray2 = new SqlParameter[] { new SqlParameter("@Task", "GetFiles"), new SqlParameter("@FileNo", str10), new SqlParameter("@Membership", str11) };
                        DataSet set2 = SQLHelper.ExecuteDataset(PMS_Setting.MainConnections.ConnectionString_ImageArchive, CommandType.StoredProcedure, "USP_DocumentSaving", parameterArray2);
                        if ((set2.Tables.Count > 0) && (set2.Tables[0].Rows.Count > 0))
                        {
                            this.ImageArchID = set2.Tables[0].Rows[0]["ImageArchID"].ToString();
                            PdfConverttoSinglePDF(CreateFile((byte[])set2.Tables[0].Rows[0]["Doc"], name), output);
                        }
                        string[] strArray4 = Directory.GetFiles(output);
                        string fileName = str5;
                        if (fileName.Length > 0)
                        {
                            FileInfo info2 = new FileInfo(fileName);
                            if (info2.Name.Contains(".jpg"))
                            {
                                string str18 = output + (strArray4.Length + 1).ToString() + ".pdf";
                                ConvertImageToPdf(fileName, fileName);
                            }
                            if (info2.Name.Contains(".PDF") | info2.Name.Contains(".pdf"))
                            {
                                PdfConverttoSinglePDF(fileName, output);
                            }
                            string startupPath = clsMostUseVars.applicationstartuppath;
                            string[] textArray2 = new string[] { str4, str10.Replace("/", "-"), "_", str11, ".pdf" };
                            string outPutFilePath = string.Concat(textArray2);
                            string[] textArray3 = new string[] { str4, str10.Replace("/", "-"), "_", str11, "Secure.pdf" };
                            MergePDFs(outPutFilePath, Directory.GetFiles(output));
                            MergePDFsandProtect(outPutFilePath, password, string.Concat(textArray3));
                            byte[] buffer2 = ReadFile(outPutFilePath);


                            SqlParameter[] parameterArray5 = new SqlParameter[0x12];
                            parameterArray5[0] = new SqlParameter("@Task", "SavingDocument");
                            parameterArray5[1] = new SqlParameter("@ImageArchID", this.ImageArchID);
                            parameterArray5[2] = new SqlParameter("@Front", SqlDbType.BigInt);
                            parameterArray5[3] = new SqlParameter("@Back", SqlDbType.BigInt);
                            parameterArray5[4] = new SqlParameter("@FileNo", str10);
                            parameterArray5[5] = new SqlParameter("@Membership", str11);
                            parameterArray5[6] = new SqlParameter("@ProtectedKey", password);
                            string[] textArray4 = new string[] { this.ImageArchServerIP, str10.Replace("/", "-"), "_", str11, "Secure.pdf" };
                            parameterArray5[7] = new SqlParameter("@DocumentPath", string.Concat(textArray4));
                            parameterArray5[8] = new SqlParameter("@DocumentByte", buffer2);
                            parameterArray5[9] = new SqlParameter("@CreatedBy", clsUser.ID.ToString());
                            parameterArray5[10] = new SqlParameter("@IsUpdate", SqlDbType.BigInt);
                            parameterArray5[11] = new SqlParameter("@Updatedby", clsUser.ID.ToString());
                            parameterArray5[12] = new SqlParameter("@IsDelete", SqlDbType.BigInt);
                            parameterArray5[13] = new SqlParameter("@DeleteBy", "");
                            DateTime now = DateTime.Now;
                            parameterArray5[14] = new SqlParameter("@Created_Date", now.ToString("yyyy-MM-dd"));
                            parameterArray5[15] = new SqlParameter("@FileType", "PDF");
                            parameterArray5[0x10] = new SqlParameter("@BackupReplicated", SqlDbType.BigInt);
                            parameterArray5[0x11] = new SqlParameter("@FileSize", "10");
                            SqlParameter[] parameterArray3 = parameterArray5;
                            if (SQLHelper.ExecuteNonQuery(PMS_Setting.MainConnections.ConnectionString_ImageArchive, CommandType.StoredProcedure, "USP_DocumentSaving", parameterArray3) <= 0)
                            {
                                MessageBox.Show("Data is not Uploaded to Server Retry ");
                            }
                            else
                            {
                                delwActivitylog(No, "Data is Uploaded to Database -> FileNo -->" + str10 + " ---> MembershipNo:" + str11 );
                                string str19 = startupPath + @"\InputDoc\";
                                string str20 = startupPath + @"\OutputDoc\";
                                string path = startupPath + @"\MergedDoc\";
                                string[] strArray7 = Directory.GetFiles(path);
                                int index = 0;
                                while (true)
                                {
                                    if (index >= strArray7.Length)
                                    {
                                        ClearFolder(folderName);
                                        ClearFolder(str19);
                                        ClearFolder(path);
                                        ClearFolder(str20);
                                        break;
                                    }
                                    string filePath = strArray7[index];
                                    if (filePath.Contains("Secure"))
                                    {
                                        //FTPUpload to Main Server
                                        UploadFileToFtp(this.ImageArchServerIP + "FileSecurePDF/", filePath, this.ImageArchUsername, this.ImageArchPassword);
                                        MoveFileFolder(str5, UploadFileMovelocation);
                                        delwActivitylog(No, "File Complete:-"+ str10+"-"+str11);
                                    }
                                    index++;
                                }

                            }
                        }
                        No = No + 1;
                    }
                    writeStatusLabel("Loading is Complete.");
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }

        private void UploadingData(string SelectPath)
        {
            try
            {
                delLwActivityLog delwActivitylog = new delLwActivityLog(LwActivityLog);
                string folderName = @clsMostUseVars.applicationstartuppath + @"\FileInfo\";
                string str2 = @clsMostUseVars.applicationstartuppath + @"\InputDoc\";
                string output = @clsMostUseVars.applicationstartuppath + @"\OutputDoc\";
                string str4 = @clsMostUseVars.applicationstartuppath + @"\MergedDoc\";
                DirectoryExistingCheck(folderName);
                DirectoryExistingCheck(str2);
                DirectoryExistingCheck(output);
                DirectoryExistingCheck(str4);
                string[] files = Directory.GetFiles(SelectPath);
                DriveInfo drive = new DriveInfo(SelectPath);
                string UploadFileMovelocation = @drive.Name + "ScannedDocUploaded";
                DirectoryExistingCheck(UploadFileMovelocation);

                int No = 0;
                if (files.Length != 0)
                {
                    foreach (string str5 in files)
                    {
                        writeStatusLabel("Please Wait Loading is in progress.");
                        delwActivitylog(No, "File Selected:-> " + str5);

                        string password = "dhapeshawar";//clsPluginHelper.RandomPassword();
                        FileInfo info = new FileInfo(str5);
                        string name = info.Name;
                        string[] textArray1 = new string[] { "_", clsUser.Name, "_", DateTime.Now.ToString("ddMMyyyy-HHmmssfffffff"), ".PDF" };
                        string str8 = name.Replace(".PDF", string.Concat(textArray1));
                        string destFileName = folderName + str8;
                        System.IO.File.Copy(str5, destFileName);
                        //file Copy Move to Origional Data
                        UploadFileToFtp(this.ImageArchServerIP + "/OrigionalFileData/", destFileName, this.ImageArchUsername, this.ImageArchPassword);
                        delwActivitylog(No, "Origional Data Copied to Server ->" + destFileName);
                        char[] separator = new char[] { '_' };
                        string[] strArray3 = name.Split(separator);
                        string str10 = strArray3[0].Replace('-', '/');
                        string str11 = strArray3[1];
                        SqlParameter[] commandParameters = new SqlParameter[] { new SqlParameter("@Task", "MembershipFinder"), new SqlParameter("@FileNo", str10), new SqlParameter("@Membership", str11) };
                        DataSet set = SQLHelper.ExecuteDataset(PMS_Setting.MainConnections.ConnectionString_ImageArchive, CommandType.StoredProcedure, "USP_MembershipConfrim", commandParameters);
                        if (set.Tables.Count <= 0)
                        {
                            delwActivitylog(No, "FileNo->" + str10 + "---- MembershipNo:" + str11 + " Issue Fields.");
                            MessageBox.Show("Check the FileNo and Membership Fields. FileNo" + str10 + "Membership No:" + str11);
                            break;
                        }
                        delwActivitylog(No, "FileNo -->" + str10 + " ---> MembershipNo:" + str11 + "--> Verification");
                        SqlParameter[] parameterArray2 = new SqlParameter[] { new SqlParameter("@Task", "GetFiles"), new SqlParameter("@FileNo", str10), new SqlParameter("@Membership", str11) };
                        DataSet set2 = SQLHelper.ExecuteDataset(PMS_Setting.MainConnections.ConnectionString_ImageArchive, CommandType.StoredProcedure, "USP_DocumentSaving", parameterArray2);
                        if ((set2.Tables.Count > 0) && (set2.Tables[0].Rows.Count > 0))
                        {
                            this.ImageArchID = set2.Tables[0].Rows[0]["ImageArchID"].ToString();
                            PdfConverttoSinglePDF(CreateFile((byte[])set2.Tables[0].Rows[0]["Doc"], name), output);
                        }
                        string[] strArray4 = Directory.GetFiles(output);
                        string fileName = str5;
                        if (fileName.Length > 0)
                        {
                            FileInfo info2 = new FileInfo(fileName);
                            if (info2.Name.Contains(".jpg"))
                            {
                                string str18 = output + (strArray4.Length + 1).ToString() + ".pdf";
                                ConvertImageToPdf(fileName, fileName);
                            }
                            if (info2.Name.Contains(".PDF") | info2.Name.Contains(".pdf"))
                            {
                                PdfConverttoSinglePDF(fileName, output);
                            }
                            string startupPath = clsMostUseVars.applicationstartuppath;
                            string[] textArray2 = new string[] { str4, str10.Replace("/", "-"), "_", str11, ".pdf" };
                            string outPutFilePath = string.Concat(textArray2);
                            string[] textArray3 = new string[] { str4, str10.Replace("/", "-"), "_", str11, "Secure.pdf" };
                            MergePDFs(outPutFilePath, Directory.GetFiles(output));
                            MergePDFsandProtect(outPutFilePath, password, string.Concat(textArray3));
                            byte[] buffer2 = ReadFile(outPutFilePath);


                            SqlParameter[] parameterArray5 = new SqlParameter[0x12];
                            parameterArray5[0] = new SqlParameter("@Task", "SavingDocument");
                            parameterArray5[1] = new SqlParameter("@ImageArchID", this.ImageArchID);
                            parameterArray5[2] = new SqlParameter("@Front", SqlDbType.BigInt);
                            parameterArray5[3] = new SqlParameter("@Back", SqlDbType.BigInt);
                            parameterArray5[4] = new SqlParameter("@FileNo", str10);
                            parameterArray5[5] = new SqlParameter("@Membership", str11);
                            parameterArray5[6] = new SqlParameter("@ProtectedKey", password);
                            string[] textArray4 = new string[] { this.ImageArchServerIP, str10.Replace("/", "-"), "_", str11, "Secure.pdf" };
                            parameterArray5[7] = new SqlParameter("@DocumentPath", string.Concat(textArray4));
                            parameterArray5[8] = new SqlParameter("@DocumentByte", buffer2);
                            parameterArray5[9] = new SqlParameter("@CreatedBy", clsUser.ID.ToString());
                            parameterArray5[10] = new SqlParameter("@IsUpdate", SqlDbType.BigInt);
                            parameterArray5[11] = new SqlParameter("@Updatedby", clsUser.ID.ToString());
                            parameterArray5[12] = new SqlParameter("@IsDelete", SqlDbType.BigInt);
                            parameterArray5[13] = new SqlParameter("@DeleteBy", "");
                            DateTime now = DateTime.Now;
                            parameterArray5[14] = new SqlParameter("@Created_Date", now.ToString("yyyy-MM-dd"));
                            parameterArray5[15] = new SqlParameter("@FileType", "PDF");
                            parameterArray5[0x10] = new SqlParameter("@BackupReplicated", SqlDbType.BigInt);
                            parameterArray5[0x11] = new SqlParameter("@FileSize", "10");
                            SqlParameter[] parameterArray3 = parameterArray5;
                            if (SQLHelper.ExecuteNonQuery(PMS_Setting.MainConnections.ConnectionString_ImageArchive, CommandType.StoredProcedure, "USP_DocumentSaving", parameterArray3) <= 0)
                            {
                                MessageBox.Show("Data is not Uploaded to Server Retry ");
                            }
                            else
                            {
                                delwActivitylog(No, "Data is Uploaded to Database -> FileNo -->" + str10 + " ---> MembershipNo:" + str11);
                                string str19 = startupPath + @"\InputDoc\";
                                string str20 = startupPath + @"\OutputDoc\";
                                string path = startupPath + @"\MergedDoc\";
                                string[] strArray7 = Directory.GetFiles(path);
                                int index = 0;
                                while (true)
                                {
                                    if (index >= strArray7.Length)
                                    {
                                        ClearFolder(folderName);
                                        ClearFolder(str19);
                                        ClearFolder(path);
                                        ClearFolder(str20);
                                        break;
                                    }
                                    string filePath = strArray7[index];
                                    if (filePath.Contains("Secure"))
                                    {
                                        //FTPUpload to Main Server
                                        UploadFileToFtp(this.ImageArchServerIP + "FileSecurePDF/", filePath, this.ImageArchUsername, this.ImageArchPassword); 
                                        MoveFileFolder(str5, UploadFileMovelocation);
                                        delwActivitylog(No, "File Complete:-" + str10 + "-" + str11);
                                    }
                                    index++;
                                }

                            }
                        }
                        No = No + 1;
                    }
                    writeStatusLabel("Loading is Complete.");
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.Message);
            }
        }
        public void DataSaving()
        {
            UploadingData();
        }
        private void btnUploadFiletoServer_Click(object sender, EventArgs e)
        {
            Thread Tr1 = new Thread(DataSaving);
            Tr1.Priority = ThreadPriority.Normal;
            Tr1.Start();
        }
        private void btnCustomFolderUpload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string FileFolder = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
                Thread Tr1 = new Thread(delegate() { UploadingData(FileFolder); });
                Tr1.Priority = ThreadPriority.Normal;
                Tr1.Start();

            }
        }

        #region Image Converter to Byte
        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream stream = new MemoryStream(byteArrayIn))
            {
                return System.Drawing.Image.FromStream(stream);
            }
        }

        public  byte[] imgToByteArray(System.Drawing.Image img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, img.RawFormat);
                return stream.ToArray();
            }
        }

        public  byte[] imgToByteConverter(System.Drawing.Image inImg) =>
            (byte[])new ImageConverter().ConvertTo(inImg, typeof(byte[]));
        #endregion

        #region PDF Helper
        public static void MoveFileFolder(string FromFolderName,string toFolderName)
        {
            try
            {
                
                FileInfo files = new FileInfo(FromFolderName);
                if (files.Exists)
                {
                    files.IsReadOnly = false;

                    File.Move(FromFolderName, toFolderName+"\\"+files.Name);
                    //files.MoveTo(toFolderName);
                }
                
            }
            catch (Exception ex)
            {
            }
        }

        public static void ClearFolder(string FolderName)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(FolderName);
                FileInfo[] files = info.GetFiles();
                int index = 0;
                while (true)
                {
                    if (index >= files.Length)
                    {
                        foreach (DirectoryInfo info3 in info.GetDirectories())
                        {
                            ClearFolder(info3.FullName);
                            info3.Delete();
                        }
                        break;
                    }
                    FileInfo info2 = files[index];
                    info2.IsReadOnly = false;
                    info2.Delete();
                    index++;
                }
            }
            catch (Exception)
            {
            }
        }
        public static void ConvertImageToPdf(string srcFilename, string dstFilename)
        {
            iTextSharp.text.Rectangle pageSize = null;
            using (Bitmap bitmap = new Bitmap(srcFilename))
            {
                pageSize = new iTextSharp.text.Rectangle(0f, 0f, (float)bitmap.Width, (float)bitmap.Height);
            }
            using (MemoryStream stream = new MemoryStream())
            {
                Document document = new Document(pageSize, 0f, 0f, 0f, 0f);
                PdfWriter.GetInstance(document, stream).SetFullCompression();
                document.Open();
                document.Add(iTextSharp.text.Image.GetInstance(srcFilename));
                document.Close();
                System.IO.File.WriteAllBytes(dstFilename, stream.ToArray());
            }
        }
        public static string CreateFile(byte[] FileData, string FileNo)
        {
            string path =clsMostUseVars.applicationstartuppath + @"\InputDoc\" + FileNo + ".pdf";
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                stream.Write(FileData, 0, FileData.Length);
                stream.Close();
            }
            return path;
        }
        public static void MergePDFs(string outPutFilePath, params string[] filesPath)
        {
            try
            {
                List<PdfReader> list = new List<PdfReader>();
                string[] strArray = filesPath;
                int index = 0;
                while (true)
                {
                    if (index >= strArray.Length)
                    {
                        Document document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
                        using (FileStream stream = new FileStream(outPutFilePath, FileMode.Create, FileAccess.Write))
                        {
                            using (StreamWriter writer = new StreamWriter(stream))
                            {
                                PdfWriter instance = PdfWriter.GetInstance(document, writer.BaseStream);
                                document.Open();
                                foreach (PdfReader reader2 in list)
                                {
                                    int pageNumber = 1;
                                    while (true)
                                    {
                                        if (pageNumber > reader2.NumberOfPages)
                                        {
                                            break;
                                        }
                                        PdfImportedPage importedPage = instance.GetImportedPage(reader2, pageNumber);
                                        document.Add(iTextSharp.text.Image.GetInstance(importedPage));
                                        pageNumber++;
                                    }
                                }
                                document.Close();
                                writer.Dispose();
                            }
                        }
                        break;
                    }
                    string filename = strArray[index];
                    PdfReader item = new PdfReader(filename);
                    list.Add(item);
                    index++;
                }
            }
            catch (Exception)
            {
            }
        }
        public static void MergePDFsandProtect(string ToFilePath, string Password, string OutputLocation)
        {
            try
            {
                string path = OutputLocation;
                using (Stream stream = new FileStream(ToFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (Stream stream2 = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        PdfEncryptor.Encrypt(new PdfReader(stream), stream2, true, Password, Password, 0x200);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public static void PdfConverttoSinglePDF(string input, string output)
        {
            string filename = input;
            string outputPath = output;
            int interval = 1;
            int num2 = 0;
            PdfReader reader = new PdfReader(filename);
            FileInfo info = new FileInfo(filename);
            string[] files = Directory.GetFiles(output);
            for (int i = 1; i <= reader.NumberOfPages; i += interval)
            {
                num2++;
                string pdfFileName = string.Format(output + (files.Length + i).ToString() + ".pdf", num2);
                SplitAndSaveInterval(filename, outputPath, i, interval, pdfFileName);
            }
        }
        public static byte[] PDFtoVarbinary(string PathFile)
        {
            FileStream stream = System.IO.File.OpenRead(PathFile);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);
            stream.Close();
            return buffer;
        }
        public static byte[] ReadFile(string sPath)
        {
            byte[] buffer = null;
            FileStream input = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(input);
            buffer = reader.ReadBytes((int)new FileInfo(sPath).Length);
            reader.Close();
            input.Close();
            return buffer;
        }
        public static void SplitAndSaveInterval(string pdfFilePath, string outputPath, int startPage, int interval, string pdfFileName)
        {
            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                Document document = new Document();
                PdfCopy copy = new PdfCopy(document, new FileStream(Path.Combine(outputPath, pdfFileName + ".pdf"), FileMode.Create));
                document.Open();
                int pageNumber = startPage;
                while (true)
                {
                    if ((pageNumber < (startPage + interval)) && (reader.NumberOfPages >= pageNumber))
                    {
                        copy.AddPage(copy.GetImportedPage(reader, pageNumber));
                        pageNumber++;
                        continue;
                    }
                    document.Close();
                    break;
                }
            }
        }
        public static void UploadFileToFtp(string url, string filePath, string username, string password)
        {
            string fileName = Path.GetFileName(filePath);
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url + fileName);
            request.Method = "STOR";
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            using (FileStream stream = System.IO.File.OpenRead(filePath))
            {
                using (Stream stream2 = request.GetRequestStream())
                {
                    stream.CopyTo(stream2);
                    stream2.Close();
                }
            }
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Console.WriteLine("Upload done: {0}", response.StatusDescription);
            response.Close();
        }

        #endregion

        
    }
}
