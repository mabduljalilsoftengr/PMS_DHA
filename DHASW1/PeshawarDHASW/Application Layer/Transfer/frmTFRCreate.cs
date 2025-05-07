using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using PeshawarDHASW.Application_Layer.Membership;
using PeshawarDHASW.clsMemberShip;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Transfer
{
    public partial class frmTFRCreate : Telerik.WinControls.UI.RadForm
    {
        #region the search and modify form in the transfer of file has no functionality 
        #endregion
        public frmTFRCreate(string get_FileNo,int get_ChalanNo,int get_NDCNo,int get_PurchaseTypeID,int get_TFRAppointmentID)
        {
            InitializeComponent();
        }
        public frmTFRCreate()
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
        Image _img;
        public Pen cropPen;
        PictureBox Img_;

        public byte[] photo;
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
            mainviewpicture.Image = (Bitmap)eventArgs.Frame.Clone();// clone the bitmap
            OrigionalImage.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        #endregion

        #region closing form
        private void NewTFR_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (videoSource.IsRunning == true) videoSource.Stop();
            }
            catch (Exception)
            {


            }
        }
        #endregion

        #region Image Saving
        private void saveimage()
        {
            using (SaveFileDialog sfdlg = new SaveFileDialog())
            {
                sfdlg.Title = "Save Image";
                sfdlg.Filter = "Transfer Image (*.jpg)|*.jpg|All files(*.*)|*.*";
                sfdlg.FileName = "T# " + txtsellerMSNo.Text + " --C# " + txtpurchaseMSNO.Text + "-- " +
                                           DateTime.Now.ToString("dd-MM-yyyy");
                if (sfdlg.ShowDialog() == DialogResult.OK)
                {
                   
                    using (Bitmap bmp = new Bitmap(OrigionalImage.Width, OrigionalImage.Height))
                    {
                        OrigionalImage.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                        OrigionalImage.Image = new Bitmap(OrigionalImage.Width, OrigionalImage.Height, PixelFormat.Format16bppArgb1555);
                        bmp.Save(sfdlg.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        MessageBox.Show("Saved Successfully.....");
                    }
                    imagepath = sfdlg.FileName;
                }
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
            catch (Exception)
            {


            }
        }
        #endregion

        #region Browse Image
        private void btnimagebrowse_Click(object sender, EventArgs e)
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
        #endregion

        public static object DbNullIfNullOrEmpty(string str)
        {
            return !String.IsNullOrEmpty(str) ? str : (object)DBNull.Value;
        }

        #region Search Function
        private void bntSearch_Click(object sender, EventArgs e)
        {
            SqlParameter[] param =
           {
                new SqlParameter("@FileNo",DbNullIfNullOrEmpty(txtFileNO.Text)),
                new SqlParameter("@PlotNo",DbNullIfNullOrEmpty(txtPlotNo.Text))
            };
            DataSet ds = Data_Layer.clsTFR.cls_dl_TFR.SearchForMembership(param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    sellerMemberID.Text = row["ID"].ToString();
                    lblFileNO.Text = row["FileNo"].ToString();
                    lblPlotNo.Text = row["PlotNo"].ToString();
                    lblSector.Text = row["Sector"].ToString();
                    lblPhase.Text = row["Phase"].ToString();
                    lblDHA.Text = row["DHA"].ToString();

                    txtsellerMSNo.Text = row["MembershipNo"].ToString();
                    txtsellername.Text = row["Name"].ToString();
                    txtsellfather.Text = row["Father"].ToString();
                    txtsellcontact.Text = row["MobileNo"].ToString();
                    txtsellnic.Text = row["NIC"].ToString();
                    txtselldateofpurchase.Text = row["DateofPurchase"].ToString();
                }
            }
            else
            {
                MessageBox.Show("File No or PlotNo is not Exist","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
          
        }
        #endregion

        #region Seller MemberViewVerify
        private void btnMemberView_Click(object sender, EventArgs e)
        {
            if (txtsellerMSNo.Text == String.Empty)
            {
                frmMembershipSearch obj = new frmMembershipSearch();
                obj.ShowDialog();
            }
            else
            {
                frmMembershipSearch obj = new frmMembershipSearch(txtsellerMSNo.Text);
                obj.ShowDialog();
            }
            
        }
        #endregion

        #region Purchaser Membership View
        private void View_Click(object sender, EventArgs e)
        {
            if (txtpurchaseMSNO.Text == String.Empty)
            {
                frmMembershipSearch obj = new frmMembershipSearch();
                obj.ShowDialog();
            }
            else
            {
                frmMembershipSearch obj = new frmMembershipSearch(txtpurchaseMSNO.Text);
                obj.ShowDialog();
            }
            
        }
        #endregion

        #region Pruchase Information Finder
        private void btnPurchaseMSfinder_Click(object sender, EventArgs e)
        {
            //if (txtsellerMSNo.Text != txtpurchaseMSNO.Text)
            //{
            //    SqlParameter[] param =
            //    {
            //        new SqlParameter("@MembershipNo", DbNullIfNullOrEmpty(txtpurchaseMSNO.Text))
            //    };
            //    DataSet ds = Data_Layer.clsTFR.cls_dl_TFR.SearchNewMS(param);

            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        PurchasememberID.Text = row["ID"].ToString();
            //        //txtpurchaseMSNO.Text = row["MembershipNo"].ToString();
            //        txtpurchaseName.Text = row["Name"].ToString();
            //        txtpurchaseFather.Text = row["Father"].ToString();
            //        txtpurchaseContact.Text = row["MobileNo"].ToString();
            //        txtpurchaseNIC.Text = row["NIC"].ToString();
            //        //txtpurchaseDate.Text = row["DateofPurchase"].ToString();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Membership No is Same Cannot Allow!");
            //}
        }
        #endregion

        #region On Leave Membership Data Find
        private void txtpurchaseMSNO_Leave(object sender, EventArgs e)
        {
            //if (txtsellerMSNo.Text != txtpurchaseMSNO.Text)
            //{
            //    SqlParameter[] paramMS =
            //   {
            //        new SqlParameter("@MS", DbNullIfNullOrEmpty(txtpurchaseMSNO.Text))
            //    };
            //    DataSet dst = Data_Layer.clsTFR.cls_dl_TFR.Check_MS_ThatNotuseofAnyTFR(paramMS);
            //    if (dst.Tables[0].Rows.Count==0)
            //    {
            //        SqlParameter[] param =
            //        {
            //            new SqlParameter("@MembershipNo", DbNullIfNullOrEmpty(txtpurchaseMSNO.Text))
            //        };
            //        DataSet ds = Data_Layer.clsTFR.cls_dl_TFR.SearchNewMS(param);

            //        foreach (DataRow row in ds.Tables[0].Rows)
            //        {
            //            PurchasememberID.Text = row["ID"].ToString();
            //            //txtpurchaseMSNO.Text = row["MembershipNo"].ToString();
            //            txtpurchaseName.Text = row["Name"].ToString();
            //            txtpurchaseFather.Text = row["Father"].ToString();
            //            txtpurchaseContact.Text = row["MobileNo"].ToString();
            //            txtpurchaseNIC.Text = row["NIC"].ToString();
            //            //txtpurchaseDate.Text = row["DateofPurchase"].ToString();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Membership No is already in used for TFR not Allow to use again!");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Membership No is Same Cannot Allow!");
            //}
        }
        #endregion

        #region New TFR Load Event
        private void NewTFR_Load(object sender, EventArgs e)
        {
            #region Loading Type of TFR
            //SqlParameter[] param =
            //   {
            //        new SqlParameter("@Test", DbNullIfNullOrEmpty("1"))
            //    };
            //cmbTFRType.DataSource = Data_Layer.clsTFR.cls_dl_TFR.TypeofTFR(param).Tables[0];
            //cmbTFRType.ValueMember = "TypeID";
            //cmbTFRType.DisplayMember = "Name";
            #endregion

            #region Visiblity Contorl of Tab Control
            //tabsingletfr.Visible = false;
            //tabsingletfr.Enabled = false; // this disables the controls on it
            //tabmtfrm.Visible = false;
            //tabmtfrm.Enabled = false;
            //tabImage.Visible = false;
            //tabImage.Enabled = false;
            #endregion
        }
        #endregion

        #region Select TFR Type
        private void cmbTFRType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tabsingletfr.Enabled = false; 
            //tabsingletfr.Visible = false;
            //tabmtfrm.Enabled = false;
            //tabmtfrm.Visible = false;
            //tabImage.Enabled = false;
            //tabImage.Visible = false;
            //single TFR
            //int SelectedValue = 0;
            //bool parse = int.TryParse(cmbTFRType.SelectedValue.ToString(),out SelectedValue);
            //if (SelectedValue == 1)
            //{

            //    tabmtfrm.Enabled = false;
            //    tabmtfrm.Visible = false;
            //    tabsingletfr.Enabled = true;
            //    tabsingletfr.Visible = true;
            //    tabImage.Enabled = true;
            //    tabImage.Visible = true;
            //}
            //else
            //{
            //    tabsingletfr.Enabled = false;
            //    tabsingletfr.Visible = false;
            //    tabmtfrm.Enabled = true;
            //    tabmtfrm.Visible = true;
            //    tabImage.Enabled = true;
            //    tabImage.Visible = true;
            //}
        }
        #endregion

        #region Save TFR Event
        private void btnSaveTFR_Click_1(object sender, EventArgs e)
        {
            // MessageBox.Show(cmbTFRType.Text + cmbTFRType.SelectedValue.ToString());
        }
        #endregion

        private void btnimagebrowse_Click_1(object sender, EventArgs e)
        {

        }

        private void btnTakePicture_Click_1(object sender, EventArgs e)
        {

        }
    }
}
