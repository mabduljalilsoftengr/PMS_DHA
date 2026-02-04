using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Diagnostics;
using System.IO.Compression;
using Telerik.WinControls.Zip;
using System.Reflection;
using Telerik.WinControls.Zip.Extensions;

namespace PeshawarDHASW.Application_Layer.Download
{
    public partial class frmDownload : Telerik.WinControls.UI.RadForm
    {
        public string NewVersion { get; set; }
        MemoryStream memStream;
        private byte[] downloadedData;
        public string Connected { get; set; }
        public bool IsDownload { get; set; }
        public frmDownload()
        {
            InitializeComponent();
        }
        public frmDownload(string UpdateContent, string NewVersion, string Connected)
        {
            InitializeComponent();
            notificationtext.Text = UpdateContent;
            this.NewVersion = NewVersion;
            this.Connected = Connected;
        }

        private void frmDownload_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "The latest version of DHA-MIS (" + NewVersion + ") with fixes is ready to install now.";
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadFile(Connected + "Update.zip");
        }

        private void DownloadFile(string url)
        {
            btnDownload.Enabled = false;
           
            lblSize.Visible = true;
            //lblHead.Content = "Downloading...";
            radProgressBar1.Value1 = 0;
            string result = System.IO.Path.GetTempPath();
            downloadedData = new byte[0];
            try
            {
                System.Windows.Forms.Application.DoEvents();
                //Optional
                radProgressBar1.Text = "Connecting...";
                //MessageLabelTextBlock.Text = "Please wait while an update for MRO is being downloaded.";
                //Get a data stream from the url
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();

                //Download in chuncks
                byte[] buffer = new byte[1024];

                //Get Total Size
                int dataLength = (int)response.ContentLength;

                //With the total data we can set up our progress indicators
                radProgressBar1.Maximum = dataLength;
                //lbProgress.Text = "0/" + dataLength.ToString();

                radProgressBar1.Text = "Downloading...";
                //Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                //Download to memory
                //Note: adjust the streams here to download directly to the hard drive
                memStream = new MemoryStream();
                while (true)
                {
                    //Try to read the data
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        //Finished downloading
                        radProgressBar1.Value1 = radProgressBar1.Maximum;
                        break;
                    }
                    else
                    {
                        //Write the downloaded data
                        memStream.Write(buffer, 0, bytesRead);

                        //Update the progress bar
                        if (radProgressBar1.Value1 + bytesRead <= radProgressBar1.Maximum)
                        {
                            radProgressBar1.Value1 += bytesRead;
                            System.Windows.Forms.Application.DoEvents();
                            lblSize.Text = "File size " + dataLength / 1000 + " KB";
                            Int64 percent = (Convert.ToInt64(radProgressBar1.Value1) * 100) / Convert.ToInt64(dataLength);
                            radProgressBar1.Text = percent + "%";
                        }
                    }
                }

                //Convert the downloaded stream to a byte array
                downloadedData = memStream.ToArray();
                //Clean up
                stream.Close();
                memStream.Close();

                string resultPath = result + "MISDHA\\MISDHASetup";
                if (downloadedData != null && downloadedData.Length != 0)
                {
                    try
                    {

                        if (!Directory.Exists(result + "MISDHA"))
                        {
                            Directory.CreateDirectory(result + "MISDHA");
                        }
                        result = result + "MISDHA\\MISDHASetup.zip";
                        if (File.Exists(result))
                        {
                            File.Delete(result);
                        }
                        FileStream newFile = new FileStream(result, FileMode.Create);
                        newFile.Write(downloadedData, 0, downloadedData.Length);
                        newFile.Close();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Access denied please contact your administrator.", "Information", MessageBoxButtons.OK);
                        this.Close();
                    }
                    try
                    {
                        if (File.Exists(result))
                        {
                            if (Directory.Exists(resultPath))
                            {
                                Directory.Delete(resultPath, true);
                            }
                            if (!Directory.Exists(resultPath))
                            {
                                Directory.CreateDirectory(resultPath);
                            }

                            string zipPath = result;
                            string extractPath = resultPath;

                            try
                            {
                                ZipFile.ExtractToDirectory(zipPath, extractPath);

                                //using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
                                //{
                                //    archive.ExtractToDirectory(extractPath);
                                //}
                            }
                            catch (Exception )
                            {
                            }
                            #region New Change
                            string command = AppDomain.CurrentDomain.BaseDirectory.ToString();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            Process.Start(resultPath + @"\DHAMIS Script.exe", command);

                            #endregion
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            IsDownload = true;

                            System.Windows.Forms.Application.Exit();
                        }
                        else
                        {
                            btnDownload.Enabled = true;
                            MessageBox.Show("Update file has been effected by antivirus. Please contact support.", "Information", MessageBoxButtons.OK);
                            //CustomizedMessageBox cmb = new CustomizedMessageBox("Information", "File effected by antivirus. Please contact support.", "Error");
                            //this.ShowInTaskbar = false;
                            //cmb.ShowDialog();
                            //this.ShowInTaskbar = true;
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Access denied please contact your administrator.", "Information", MessageBoxButtons.OK);
                        btnDownload.Enabled = true;
                        //CustomizedMessageBox cmb = new CustomizedMessageBox("Information", "Access denied please contact your administrator.", "Error");
                        //this.ShowInTaskbar = false;
                        //cmb.ShowDialog();
                        //this.ShowInTaskbar = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK);
                //CustomizedMessageBox cmb = new CustomizedMessageBox("Information", "There was an error accessing the URL.", "Error");
                //this.ShowInTaskbar = false;
                //cmb.ShowDialog();
                //this.ShowInTaskbar = true;
                btnDownload.Enabled = true;
                //return;
            }

            //txtData.Text = downloadedData.Length.ToString();
            //this.Text = "Download Data through HTTP";
        }



    }
}
