using AForge.Video.DirectShow;
using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsFileMap;
using PeshawarDHASW.Data_Layer.clsTFR;
using PeshawarDHASW.Report.Simple_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PeshawarDHASW.Helper;

namespace PeshawarDHASW.Application_Layer.Transfer
{
    public partial class frmTakeImage : Telerik.WinControls.UI.RadForm
    {
        public string FileNo { get; set; }
        public int ChalanNo { get; set; }
        public int NDCNo { get; set; }
        public int PurchaseID { get; set; }
        public int TransferAppID { get; set; }
        public int FileMapKey { get; set; }
        public string SellerMSNOString { get; set; }
        public string BuyerMSNOString { get; set; }
        public int TransferNo { get; set; }

        public int result { get; set; } = 0;
        public frmTakeImage(string get_FileNo, int get_NDCNo, int get_PurchaseTypeID,string get_SellerMSNOString,string get_BuyerMSNOString,int get_TransferNo)
        {
            InitializeComponent();
            FileNo = get_FileNo;
            //ChalanNo = get_ChalanNo;
            NDCNo = get_NDCNo;
            PurchaseID = get_PurchaseTypeID;
            //TransferAppID = get_TFRAppointmentID;
            SellerMSNOString = get_SellerMSNOString;
            BuyerMSNOString = get_BuyerMSNOString;
            TransferNo = get_TransferNo;
        }
        public frmTakeImage()
        {
            InitializeComponent();
            getCamList();
        }
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;
        public static string imagepath { get; set; }

        int cropX;
        int cropY;
        int cropWidth;
        public DashStyle cropDashStyle = DashStyle.DashDot;
        int cropHeight;
        
        public Pen cropPen;
        PictureBox Img_;

        public byte[] photo;
        #region Browse Image
        private void btnimagebrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoDevices.Count > 0)
                {
                    if (videoSource.IsRunning == true) videoSource.Stop();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through.", ex, "frmTakeImage");
                frmobj.ShowDialog();
            }

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                //dlg.ShowDialog();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string fileName;
                    fileName = dlg.FileName;
                    mainviewpicture.Image = new Bitmap(dlg.FileName);
                    OrigionalImage.Image = new Bitmap(dlg.FileName);
                    //MessageBox.Show(fileName);
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnimagebrowse_Click.", ex, "frmTakeImage");
                frmobj.ShowDialog();
            }
           
        }
        #endregion

        #region Take Picture
        private void btnTakePicture_Click(object sender, EventArgs e)
        {

            try
            {
                if (videoSource.IsRunning == true) videoSource.Stop();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnTakePicture_Click.", ex, "frmTakeImage");
                frmobj.ShowDialog();
            }
        }
        #endregion
        private void getCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                cmbCamera.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    cmbCamera.Items.Add(device.Name);
                }
                cmbCamera.SelectedIndex = 0; //make dafault to first cam
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                cmbCamera.Items.Add("No capture device on your system");
            }
        }

        private void btnstartcam_Click(object sender, EventArgs e)
        {
            try
            {
                videoSource = new VideoCaptureDevice(videoDevices[cmbCamera.SelectedIndex].MonikerString);// specified web cam and its filter moniker string
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Camera Found.");
            }
        }
        #region Image to PictureBox
        private void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            try
            {
                mainviewpicture.Image = (Bitmap)eventArgs.Frame.Clone();// clone the bitmap
                OrigionalImage.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on VideoSource_NewFrame.", ex, "frmTakeImage");
                frmobj.ShowDialog();
            }
      
        }
        #endregion
        #region Closing Form , i.e Closing of the port of Camera
        //"FormClosing" is an Event that can create by Right click on Form and Double click on the "FormClosing" property in the "Evens Window", which is used
        //To Close the port to which the Camera is Connected, in this case when the Camera is start
        //and don't take the picture ,then it by force Close the port, because in this case if the Camera is don't close 
        // then in this case when again start the camera , then it will give the message that the camera is already is open.
        private void frmTakeImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (videoSource != null && videoSource.IsRunning == true) videoSource.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ex.InnerException);
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmTakeImage_FormClosing.", ex, "frmTakeImage");
                frmobj.ShowDialog();

            }
        }
        #endregion
        #region Save Image
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                string TFRInfo = "Sellers:" + SellerMSNOString + "Buyers:" + BuyerMSNOString + "F.N:" + FileNo;
                //---(1) Convert PictureBox Image Into Byte Array
                #region
                for(int i=0; i < grdImagesContainer.RowCount; i++)
                {
                    #region +++++++++++++ Get Image From Grid View and Convert to Byte Array +++++++++++++++
                    Image img = (Image)grdImagesContainer.Rows[i].Cells["TFRImage"].Value;                   
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Byte[] Im = ms.ToArray();
                    #endregion +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    #region ++++++++++++ Retrive Remarks from RadGridView ++++++++++++++++++
                    //object dscrp = grdImagesContainer.Rows[i].Cells["Description"].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : grdImagesContainer.Rows[i].Cells["Description"].Value.ToString();
                    object rmrks = grdImagesContainer.Rows[i].Cells["Remarks"].Value == null ? clsPluginHelper.DbNullIfNullOrEmpty("") : grdImagesContainer.Rows[i].Cells["Remarks"].Value.ToString();
                    #endregion +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    #region Insert New Image
                    SqlParameter[] parmtr =
                    {
                          new SqlParameter("@Task","Insert"),
                          new SqlParameter("@Image",Im),
                          new SqlParameter("@TFRInformation",TFRInfo),
                          new SqlParameter("@Description","TFR_Persons_Group_Photo"),
                          new SqlParameter("@Remarks",rmrks),
                          new SqlParameter("@CurrentDate",DateTime.Now.ToString("dd/MM/yyyy")),
                          new SqlParameter("@Status","Pending"),        // "Pending" means that the Image is not Verified Yet
                          new SqlParameter("@FileKey",FileMapKey),
                          new SqlParameter("@TransferNo",TransferNo),
                          new SqlParameter("@userID",Models.clsUser.ID),
                          new SqlParameter("@NDCNo",NDCNo)
                    };
                    result = cls_dl_TFRHistory.TFRHistory_NonQuery(parmtr);
                   
                    #endregion
                }
                if (result > 0)
                {  
                    //bmp.Save(sfdlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("Saved Successfully.");

                    videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    cmbCamera.Items.Clear();
                    if (videoDevices.Count > 0)
                    {
                        btnTakePicture_Click(sender, e);
                    }
                    //UpdateTransferTrackingStatus();
                    this.Hide();
                    //frmSimpleReport frm_obj = new frmSimpleReport(FileNo, NDCNo, PurchaseID);
                    //frm_obj.ShowDialog();

                }
                else
                {
                    MessageBox.Show("There is no Data for saving."+Environment.NewLine+"Please Contact With Administration.","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                #endregion
                //-----(1)---End-----------------------------------------------------------------------
                //--(2)-Check that this Image is already exist OR not , If Not then Insert else not-----
                #region   
                //SqlParameter[] parameter =
                //{
                //new SqlParameter("@Task","Check_For_Image_Existance"),
                //new SqlParameter("@FileNO",FileNo),
                //new SqlParameter("@Status","Pending"), // "Pending" means that the Image is not Verified Yet
                //new SqlParameter("@Description","TFR_Persons_Group_Photo"),
                //new SqlParameter("@TransferNo",TransferNo)
                //};
                //DataSet ds = new DataSet();
                //ds = cls_dl_TFRHistory.TFRHistory_Reader(parameter);
                //if (ds.Tables[0].Rows.Count == 0)
                //{
                #region Insert New Image
                //SqlParameter[] parmtr =
                //{
                //          new SqlParameter("@Task","Insert"),
                //          new SqlParameter("@Image",Im),
                //          new SqlParameter("@TFRInformation",TFRInfo),
                //          new SqlParameter("@Description","TFR_Persons_Group_Photo"),
                //          new SqlParameter("@Remarks",txtRemarks.Text),
                //          new SqlParameter("@CurrentDate",DateTime.Now.ToString("dd/MM/yyyy")),
                //          new SqlParameter("@Status","Pending"),        // "Pending" means that the Image is not Verified Yet
                //          new SqlParameter("@FileKey",FileMapKey),
                //          new SqlParameter("@TransferNo",TransferNo)
                //    };
                //int result = 0;
                //result = cls_dl_TFRHistory.TFRHistory_NonQuery(parmtr);
                //if (result > 0)
                //{
                //    this.Hide();
                //    //bmp.Save(sfdlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                //    MessageBox.Show("Saved Successfully.....");
                //    UpdateTransferTrackingStatus();
                //    //frmSimpleReport frm_obj = new frmSimpleReport(FileNo, NDCNo, PurchaseID);
                //    //frm_obj.ShowDialog();

                //}
                //else
                //{
                //    MessageBox.Show("Please Contact With Administration.");
                //}
                #endregion
                //}
                //else
                //{
                #region Updation
                //    SqlParameter[] parmtr =
                //    {
                //          new SqlParameter("@Task","Update"),
                //          new SqlParameter("@Image",Image),
                //          new SqlParameter("@TFRInformation",TFRInfo),
                //          //new SqlParameter("@Description","TFR_Persons_Group_Photo"),
                //          new SqlParameter("@Remarks",txtRemarks.Text),
                //          new SqlParameter("@CurrentDate",DateTime.Now.ToString("dd/MM/yyyy")),
                //          new SqlParameter("@Status","Pending"),        // "Pending" means that the Image is not Verified Yet
                //          //new SqlParameter("@FileKey",FileMapKey),
                //          //new SqlParameter("@TransferNo",TransferNo)
                //    };
                //    int result = 0;
                //    result = cls_dl_TFRHistory.TFRHistory_NonQuery(parmtr);
                //    if (result > 0)
                //    {
                //        this.Hide();
                //        //bmp.Save(sfdlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                //        MessageBox.Show("Saved Successfully.....");
                //        UpdateTransferTrackingStatus();
                //        //frmSimpleReport frm_obj = new frmSimpleReport(FileNo, NDCNo, PurchaseID);
                //        //frm_obj.ShowDialog();

                //    }
                //    else
                //    {
                //        MessageBox.Show("Please Contact With Administration.");
                //    }
                #endregion
                //}
                #endregion
                //--(2) ------End------------------------------------------
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnSave_Click.", ex, "frmTakeImage");
                frmobj.ShowDialog();
            }
        

        }
        //}
        #endregion

        #region Get FileKey from FileNO
        private void frmTakeImage_Load(object sender, EventArgs e)
        {
            try
            {
                getCamList();
                SqlParameter[] parmtr =
                {
                new SqlParameter("@Task","select"),
                new SqlParameter("@FileNo",FileNo)
                };
                DataSet ds = new DataSet();
                ds = cls_dl_FileMap.FileMap_Reader(parmtr);
                FileMapKey = int.Parse(ds.Tables[0].Rows[0]["FileMapKey"].ToString());
                btnstartcam_Click(sender,e);
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmTakeImage_Load.", ex, "frmTakeImage");
                frmobj.ShowDialog();
            }
            
        }
        #endregion

        private void UpdateTransferTrackingStatus()
        {
            try
            {
                #region Update TransferTracking Status to "ReadyForReport"
                SqlParameter[] prmt_r =
                {
                 new SqlParameter("@Task","Update_TransferTracking_Status"),
                 new SqlParameter("@TFR_Status", "ReadyForReport"),
                 new SqlParameter("@TransferNo", TransferNo)
                };
                int rslt = cls_dl_TransferTracking.TransferTracking_NonQuery(prmt_r);
                if (rslt > 0)
                {
                    //MessageBox.Show("");
                }
                else
                {
                    MessageBox.Show("Updation of Transfer Tracking Staus is Failed.");
                }
                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message+Environment.NewLine+ "Updation of Transfer Tracking Staus is Failed.");
            }
               
        }

        private void btn_Add_To_Grid_Click(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cmbCamera.Items.Clear();
            if (videoDevices.Count > 0)
            {
                //DeviceExist = true;
                btnTakePicture_Click(sender, e);
            }
            GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(this.grdImagesContainer.MasterView);
            rowInfo.Cells[0].Value = mainviewpicture.Image;
            grdImagesContainer.Rows.Add(rowInfo);
            getCamList();
            if (videoDevices.Count > 0)
            {
                btnstartcam_Click(sender, e);
            }
        }

        private void grdImagesContainer_CellClick(object sender, GridViewCellEventArgs e)
        {
            if(e.Column.Name == "btn_Remove")
            {
                if(e.RowIndex >= 0)
                this.grdImagesContainer.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
