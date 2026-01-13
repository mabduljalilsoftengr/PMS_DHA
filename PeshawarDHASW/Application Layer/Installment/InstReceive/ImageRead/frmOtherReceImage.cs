using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify;
using PeshawarDHASW.Data_Layer.clsChallanRece;
using PeshawarDHASW.Data_Layer.Installment;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Installment.InstReceive.ImageRead
{
    public partial class frmOtherReceImage : Telerik.WinControls.UI.RadForm
    {
        public frmOtherReceImage()
        {
            InitializeComponent();
        }

        private int imageindex { get; set; } = 0;
        private int Challan_Image_ID { get; set; }
        private int TotalImage { get; set; } = 0;
        private int ChallanRece_ID { get; set; }
        private DataSet dsImage { get; set; }

        public frmOtherReceImage(int CRID, bool GBShow = true)
        {
            ChallanRece_ID = CRID;
            InitializeComponent();
            radgbControls.Visible = GBShow;
        }
        public frmOtherReceImage(int get_rcID,bool get_fls,int get_int)
        {
            InitializeComponent();
            ChallanRece_ID = get_rcID;
            radgbControls.Visible = get_fls;
        }

        private void btnpreciousimage_Click(object sender, EventArgs e)
        {
            try
            {
                if (imageindex != 0)
                {
                    imageindex = imageindex - 1;
                    pictureBox1.Image = ImageRetrive(imageindex);
                }
                else
                {

                    pictureBox1.Image = ImageRetrive(imageindex);
                }
            }
            catch (Exception ex)
            {
               
            }

        }

        private void btnnextimage_Click(object sender, EventArgs e)
        {
            try
            {
                if (imageindex != TotalImage - 1)
                {
                    imageindex = imageindex + 1;
                    pictureBox1.Image = ImageRetrive(imageindex);
                }
                else
                {

                    pictureBox1.Image = ImageRetrive(imageindex);

                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnnextimage_Click.", ex, "frmOtherReceImage");
                frmobj.ShowDialog();

            }

        }

        private void frmOtherReceImage_Load(object sender, EventArgs e)
        {
            try
            {
                inforviewofotherrece(ChallanRece_ID);
                dsImage = IMageLoading(ChallanRece_ID);
                if (dsImage.Tables[0].Rows.Count > 0)
                {
                    pictureBox1.Image = ImageRetrive(imageindex);
                }
                else
                {
                    MessageBox.Show("Their is  No Image Attached with Document");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmOtherReceImage_Load.", ex, "frmOtherReceImage");
                frmobj.ShowDialog();
            }
          
        }

    
        private DataSet IMageLoading(int memberID)
        {

            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task", "Select"),
                    new SqlParameter("@ChallanImageID", memberID),
                };
                ds = cls_dl_ChallanRece.OtherRece_Image_Retrive(parameters);
                TotalImage = ds.Tables[0].Rows.Count;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException);
            }
            return ds;
        }

        private Image ImageRetrive(int imageindex)
        {
            
            // Transfer everything to the Image property of the picture box....
            Challan_Image_ID = int.Parse(dsImage.Tables[0].Rows[imageindex]["ID"].ToString());
            byte[] imgData = (byte[]) dsImage.Tables[0].Rows[imageindex]["Image"];
            MemoryStream ms = new MemoryStream(imgData);
            ms.Position = 0;
            return Image.FromStream(ms);
        }



        private void ClearFunction()
        {
            lblfileno.Text = "";
            lblplotno.Text = "";
            lblRecordNo.Text = "";
            lblmsno.Text = "";
            lblNIC.Text = "";
            lblpassport.Text = "";
            lblname.Text = "";
            lblcontact.Text = "";
            lblDateofRece.Text = "";
            lblremarks.Text = "";
            lblchallanDDno.Text = "";
            lblAmount.Text = "";
            lblbank.Text = "";
            lblbranch.Text = "";
            lblstatus.Text = "";
            lblRefno.Text = "";
        }

   
        private void inforviewofotherrece(int CRID)
        {
            try
            {
                SqlParameter[] parameters =
            {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@CRID",CRID),
            };
                DataSet ds = cls_dl_ChallanRece.ChallanRece_Reader(parameters);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ChallanRece_ID = int.Parse(row["CRID"].ToString());
                    lblfileno.Text = row["FileNo"].ToString();
                    lblplotno.Text = row["PlotNo"].ToString();
                    lblRecordNo.Text = row["RecordNo"].ToString();
                    lblmsno.Text = row["MembershipNo"].ToString();
                    lblNIC.Text = row["NIC"].ToString();
                    lblpassport.Text = row["PassportNo"].ToString();
                    lblname.Text = row["Name"].ToString();
                    lblcontact.Text = row["MobileNo"].ToString();
                    lblDateofRece.Text = row["DateofRece"].ToString();
                    lblremarks.Text = row["Remarks"].ToString();
                    lblchallanDDno.Text = row["ChallanNo"].ToString();
                    lblAmount.Text = row["Amount"].ToString();
                    lblbank.Text = row["Bank"].ToString();
                    lblbranch.Text = row["Branch"].ToString();
                    lblstatus.Text = row["Status"].ToString();
                    lblRefno.Text = row["RefNo"].ToString();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on inforviewofotherrece.", ex, "frmOtherReceImage");
                frmobj.ShowDialog();
            }
            
        }

        private void btnimagemodify_Click(object sender, EventArgs e)
        {
            ChallanImageUpload objImageUpload = new ChallanImageUpload(Challan_Image_ID,ChallanRece_ID,"FrontBack");
            objImageUpload.ShowDialog();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            frmChallanModify objChallanModify = new frmChallanModify(ChallanRece_ID);
            objChallanModify.ShowDialog();
        }
    }
}
